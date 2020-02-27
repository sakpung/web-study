// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {

    export interface IHPDefinitionSequenceDialogControllerScope extends ng.IScope {
        steps: Array<any>;
        hpDefinition: Models.HangingProtocolDefinition;
        roles: Array<Models.Role>;
        modalities: Array<any>;
        selectedModalities: Array<string>;
       
        PCSOptions: any;
        RFROptions: any;
        ARSOptions: any; 

        extractLaterality();     
        extractModality();
        extractStudyDescription();
        extractBodyPartExamined();
        extractProtocolName();

        deleteSequenceItem(options);

        cancel(); 
        ok();       
    }

    export class HPDefinitionSequenceDialogControllerScope {
        static $inject = ["$scope", "$modalInstance", "$translate", 'authenticationService', 'hpDefinition', 'dataset'];

        private _$modal: any;
        private _$scope: IHPDefinitionSequenceDialogControllerScope;  
        private _dataset: any;      

        constructor($scope: IHPDefinitionSequenceDialogControllerScope, $modalInstance, $translate, authenticationService: AuthenticationService, hpDefinition: Models.HangingProtocolDefinition, dataset) {
            var modalities: Array<string> = hpDefinition.Modality.split('\\');
            var self = this;

            this._$scope = $scope;                 

            $scope.modalities = Utils.get_Modalities();
            angular.forEach($scope.modalities, function (item, key) {
                item.ticked = false;
            });

            angular.forEach(modalities, function (item, key) {
                self.selectModality(item);
            });

            $scope.selectedModalities = new Array<any>();
            $scope.hpDefinition = hpDefinition;

            $scope.extractLaterality = this.extractLaterality.bind(this);            
            $scope.extractModality = this.extractModality.bind(this);
            $scope.extractStudyDescription = this.extractStudyDescription.bind(this);
            $scope.extractBodyPartExamined = this.extractBodyPartExamined.bind(this);
            $scope.extractProtocolName = this.extractProtocolName.bind(this);

            $scope.deleteSequenceItem = this.deleteSequenceItem.bind(this);

            $scope.cancel = () => {
                $modalInstance.dismiss("cancel");
            };
            $scope.ok = () => {
                var modalities: Array<string> = new Array<string>();

                angular.forEach($scope.modalities, function (item, key) {
                    if (item.ticked) {
                        modalities.push(item.name);
                    }
                });
                hpDefinition.Modality = modalities.join('\\');
                $modalInstance.close(hpDefinition); 
            };

            this.init_grid($scope, 'PCSOptions', 'Procedure Code Sequence', DicomHelper.getCodeSequenceList(hpDefinition["metadata"], DicomTag.ProcedureCodeSequence, null),
                           this.PCSSelectionChanged, 'ProcedureCodeSequence');
            this.init_grid($scope, 'RFROptions', 'Reason For Requested Procedure Code Sequence', DicomHelper.getCodeSequenceList(hpDefinition["metadata"], DicomTag.ReasonForRequestedProcedureCodeSequence, null),
                this.PCSSelectionChanged, 'ReasonForRequestedProcedureCodeSequence');
            this.init_grid($scope, 'ARSOptions', 'Anatomic Region Sequence', DicomHelper.getCodeSequenceList(hpDefinition["metadata"], DicomTag.AnatomicRegionSequence, null),
                this.ARSSelectionChanged, 'AnatomicRegionSequence');

            this._dataset = dataset;
        }        

        private get_ColumnDefs(headerName: string) {
            var columnDefs = [
                {
                    headerName: headerName,
                    children: [
                        {
                            headerName: "Code Scheme",
                            field: "CodeSchemeDesignator",
                            width: 95,
                            checkboxSelection: true,
                        },
                        {
                            headerName: "Code Value",
                            field: "CodeValue",
                            width: 95
                        },
                        {
                            headerName: "Code Meaning",
                            field: "CodeMeaning",
                            width: 95
                        },
                        {
                            headerName: "Coding Scheme Version",
                            field: "CodingSchemeVersion",
                            width: 125
                        }
                    ]
                }
            ];

            return columnDefs;
        }

        private init_grid($scope: IHPDefinitionSequenceDialogControllerScope, optionName: string, headerName: string, data, callback, property:string) {
            $scope[optionName] = {
                groupHeaders: true,
                angularCompileHeaders: true,
                rowSelection: 'multiple',
                suppressRowClickSelection: true,
                enableColResize: true,
                columnDefs: this.get_ColumnDefs(headerName),
                rowData: data,
                onGridReady: function () {
                    $scope[optionName].api.hideOverlay();
                    $scope[optionName].api.sizeColumnsToFit();

                    this.doSelection($scope[optionName].api, property);
                }.bind(this),
                onSelectionChanged: callback.bind(this),               
            }
        }

        private doSelection(api, property: string) {
            var sequence: Array<Models.CodeSequence> = this._$scope.hpDefinition[property];

            if ( sequence && sequence.length > 0) {                
                api.forEachNode(function (node, index) {
                    var nodeItem: Models.CodeSequence = node.data;
                    var item = Utils.findFirst(sequence, function (item: Models.CodeSequence) {
                        return item.CodeMeaning == nodeItem.CodeMeaning && item.CodeValue == nodeItem.CodeValue && item.CodeSchemeDesignator == nodeItem.CodeSchemeDesignator;
                    });

                    if (item) {
                        api.selectNode(node);
                    }
                });
            }
        }

        private ARSSelectionChanged(evt) {
            this._$scope.hpDefinition.AnatomicRegionSequence = evt.selectedRows;
        }

        private RFRSelectionChanged(evt) {
            this._$scope.hpDefinition.ReasonForRequestedProcedureCodeSequence = evt.selectedRows;
        }

        private PCSSelectionChanged(evt) {
            this._$scope.hpDefinition.ProcedureCodeSequence = evt.selectedRows;
        }

        private extractLaterality() {
            var laterality: string = DicomHelper.getDicomTagValue(this._dataset, DicomTag.Laterality);

            if (!laterality || laterality.length == 0) {
                laterality = DicomHelper.getDicomTagValue(this._dataset, DicomTag.ImageLaterality);
            }

            if (laterality && laterality.length > 0) {
                switch (laterality.toUpperCase()) {
                    case "L":
                        this._$scope.hpDefinition.Laterality = Models.Laterality.Left;
                        break;
                    case "R":
                        this._$scope.hpDefinition.Laterality = Models.Laterality.Right;
                        break;
                    case "B":
                        this._$scope.hpDefinition.Laterality = Models.Laterality.Both;
                        break;
                    case "U":
                        this._$scope.hpDefinition.Laterality = Models.Laterality.Unpaired;
                        break;
                }                
            }
        }
        
        private extractModality() {
            var modality:string = DicomHelper.getDicomTagValue(this._dataset, DicomTag.Modality);

            if (modality && modality.length > 0) {
                this.selectModality(modality);
            }
        }

        private selectModality(modality: string): void {
            var item = Utils.findFirst(this._$scope.modalities, function (item) {
                return item.name == modality;
            });

            if (item) {
                item.ticked = true;                
            }
        }

        private extractStudyDescription() {
            this._$scope.hpDefinition.StudyDescription = DicomHelper.getDicomTagValue(this._dataset, DicomTag.StudyDescription);
        }        

        private deleteSequenceItem(options) {
            var nodes: Array<any> = options.api.getSelectedNodes();

            if (nodes.length > 0) {
                var index = options.rowData.indexOf(nodes[0].data);

                options.rowData.splice(index, 1);
                options.api.setRowData(options.rowData);
            }
        }

        private extractBodyPartExamined() {
            this._$scope.hpDefinition.BodyPartExamined = DicomHelper.getDicomTagValue(this._dataset, DicomTag.BodyPartExamined);
        }       

        private extractProtocolName() {
            this._$scope.hpDefinition.ProtocolName = DicomHelper.getDicomTagValue(this._dataset, DicomTag.ProtocolName);
        }       
    }
}