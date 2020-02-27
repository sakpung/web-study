// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IViewDicomControllerScope extends ng.IScope {
        gridOptions: any;
        ok();            
        stackChanged(event, data);    
    }

    export class ViewDicomController {
        static $inject = ['$scope', 'eventService', 'toolbarService', '$modalInstance', 'optionsService', 'dicom', 'frame', 'objectRetrieveService', '$translate'];

        private _dateFormat: string;
        private _timeFormat: string;
        private _scope: IViewDicomControllerScope;
        private _unknownString: string = "Unknown";
        private _objectRetrieveService: ObjectRetrieveService;

        constructor($scope: IViewDicomControllerScope, eventService: EventService, toolbarService: ToolbarService, $modalInstance, optionsService: OptionsService, dicom, frame, objectRetrieveService: ObjectRetrieveService, $translate) {
            var model = [];
            var __this = this;

            this._dateFormat = optionsService.get(OptionNames.DateFormat);
            this._timeFormat = optionsService.get(OptionNames.TimeFormat);
            this._scope = $scope;
            this._objectRetrieveService = objectRetrieveService;

            $scope.gridOptions = {
                columnDefs: [
                    {
                        headerName: "Tag", field: "tag", width: 150,
                        cellRenderer: {
                            renderer: 'group',
                            innerRenderer: this.innerCellRenderer.bind(this)
                        }
                    },
                    { headerName: "Name", field: "name", width: 250 },
                    {
                        headerName: "Value",
                        field: "value",
                        width: 250                        
                    }
                ],
                rowData: this.buildData(dicom, new Array<Models.DicomTagRow>()),
                rowSelection: 'multiple',
                rowsAlreadyGrouped: true,
                enableColResize: true,
                enableSorting: true,
                rowHeight: 20,
                icons: {
                    groupExpanded: '<i class="fa fa-minus-square-o"/>',
                    groupContracted: '<i class="fa fa-plus-square-o"/>'
                },
                onGridReady: function () {
                    $scope.gridOptions.api.hideOverlay();                    
                },
            }                      
            
            $scope.ok = function () {
                $modalInstance.close();
            } 
            
            $translate('UNKNOWN').then(function (translation) {
                this._unknownString = translation;
            }.bind(this));  
            
            eventService.subscribe(EventNames.StackChanged, this.stackChanged.bind(this));                      
        }       

        private innerCellRenderer(params): string {           
            if (params.data.vr == 'SQ') {
                return '<span><i class="fa fa-tags" style="color: blue"></i>&nbsp;' + params.data.tag + '</span>';
            }
            
            return '<span><i class="fa fa-tag" style="color: blue"></i>&nbsp;' + params.data.tag + '</span>';
        }        

        private buildData(dicom, data: Array<Models.DicomTagRow>): Array<Models.DicomTagRow> {            
            for (var key in dicom) {
                var dcmData = new Models.DicomData(this.splitCamelCaseToString(dicom[key].keyword), key);
                var row = new Models.DicomTagRow(dcmData); 
                
                if (!dcmData.name) {
                    dcmData.name = this._unknownString;
                }               

                dcmData.vr = dicom[key].vr;
                if (dicom[key].vr == 'PN') {
                    dcmData.value = DicomHelper.getPatientNameFromTag(dicom[key]);
                }
                else if (dicom[key].vr != 'SQ') {
                    var value: string = DicomHelper.getConvertValue(dicom[key]);

                    if (dicom[key].vr == 'DA') {
                        if (value) {
                            var DateJS: IDateJS = <any>(new Date(DicomHelper.parseDicomDate(value)));

                            value = DateJS.toString(this._dateFormat);
                        }
                    }

                    if (dicom[key].vr == 'TM') {
                        if (value) {
                            var DateJS: IDateJS = (<any>Date).today().at(DicomHelper.parseDicomTime(value));

                            value = DateJS.toString(this._timeFormat);
                        }
                    }                    

                    dcmData.value = value;
                }
                else {
                    if (dicom[key].Value && dicom[key].Value.length > 0) {
                        var length: number = dicom[key].Value.length;

                        row.group = true;
                        row.expanded = false;
                        for (var index=0; index < length; index++) {
                            var dcmData = new Models.DicomData("Item", "FFFEE000");
                            var itemRow = new Models.DicomTagRow(dcmData); 

                            itemRow.group = true;
                            itemRow.expanded = false;
                            row.children.push(itemRow);
                            this.buildData(dicom[key].Value[index], itemRow.children);
                        }
                    }                                        
                }               
                                
                data.push(row);
            }

            return data;
        }

        private getDateTime(): string {
            var DateJS: IDateJS = <any>(new Date());
            var formattedString: string;

            formattedString = DateJS.toString(this._dateFormat + " " + this._timeFormat);
            return formattedString;
        }  

        private splitCamelCaseToString(s) {
            if (!s)
                return '';

            return s.replace
                (/(^[a-z]+)|[0-9]+|[A-Z][a-z]+|[A-Z]+(?=[A-Z][a-z]|[0-9])/g
                , function (match, first) {
                    if (first) match = match[0].toUpperCase() + match.substr(1);
                    return match + ' ';
                }
                ).trim();
        }

        private stackChanged(event, data) {
            var frame = data.args.frame;

            if (frame && frame.metadata != null) {
                var tagRow: Array<Models.DicomTagRow> = new Array<Models.DicomTagRow>();
                var rows: Array<Models.DicomTagRow> = this.buildData(frame.metadata, tagRow);

                this._scope.gridOptions.api.setRowData(rows);
            }
            else if (frame && !frame.metadata) {
                if (frame.Instance) {
                    this._objectRetrieveService.GetDicomJSON(frame.Instance.StudyInstanceUID, frame.Instance.SeriesInstanceUID, frame.Instance.SOPInstanceUID).success(function (result) {
                        try {
                            frame.metadata = JSON.parse(result);

                            if (frame.metadata) {
                                var tagRow: Array<Models.DicomTagRow> = new Array<Models.DicomTagRow>();
                                var rows: Array<Models.DicomTagRow> = this.buildData(frame.metadata, tagRow);

                                this._scope.gridOptions.api.setRowData(rows);
                            }
                        }
                        catch (e) {
                            console.log(e);
                        }
                    }.bind(this));
                }
            }
        }
    }
}