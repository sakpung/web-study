// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="Scopes.ts" />
/// <reference path="../Services/QueryArchiveService.ts" />

declare var uiGridConstants;

module Controllers {
    export interface IViewerSearchControllerScope extends ISearchControllerScope {
        config: any;
        studies: Array<any>;
        resultButtons: Array<any>;
        gridOptions: any;
        gridOptionsSeries: any;

        OnStudySearchError: Function;
        OnStudySearchSuccess: Function;
        patientids(value: string);
        patientNames(value: string);
        onClickRow(row: any);
        onViewStudy(row: any);
        resize();
        hpContextMenu(data: any): void;
        handleCellClicked(data: any): void;
    }

    export class SearchViewController extends SearchController {
        static $inject = ['$rootScope', '$scope', '$modal', 'eventService', 'queryArchiveService', 'optionsService', 'dataService', 'queryPacsService', 'authenticationService', 'tabService', 'seriesManagerService', 'objectStoreService', 'templateService', 'templateEditorService', '$translate', 'objectRetrieveService', 'dataCache'];

        private _$scope: IViewerSearchControllerScope;
        private _queryPacsService: QueryPacsService;
        private _objectStoreService: ObjectStoreService;
        private _objectRetrieveService: ObjectRetrieveService;
        private _dataService: DataService;
        private _optionsService: OptionsService;
        private _eventService: EventService;
        private _tabService: TabService;
        private _seriesManagerService: SeriesManagerService;
        private _selectedStudy;
        private _selectedSeries;
        private _viewStudy: boolean;
        private _dataCache: any;
        private _hpOpenWith: string;
        private _sdOpenWith: string;
        private _loadingStudySeries: boolean;
        private _loadingHangingProtocols: boolean;
        private _hangingProtocols: Array<Models.HangingProtocolQueryResult>;
        private _rowIndexPrevious: number;

        constructor($rootScope, $scope: IViewerSearchControllerScope, $modal, eventService: EventService, queryArchiveService: QueryArchiveService, optionsService: OptionsService, dataService: DataService, queryPacsService: QueryPacsService, authenticationService: AuthenticationService, tabService: TabService, seriesManagerService: SeriesManagerService, objectStoreService: ObjectStoreService, templateService: TemplateService, templateEditorService: TemplateEditorService, $translate, objectRetrieveService: ObjectRetrieveService, dataCache) {
            var __this;
            var dateFormat = optionsService.get(OptionNames.DateFormat);
            var timeFormat = optionsService.get(OptionNames.TimeFormat);
            var maxStudyResults: string = optionsService.get(OptionNames.MaxStudyResults);
            var previous = UUID.generate();
            var next = UUID.generate();
            var selection;
            var studiesGroup = "Studies";
            var seriesGroup = "Series";

            super($rootScope, $scope, queryArchiveService, optionsService, authenticationService, queryPacsService, tabService, eventService, templateService, templateEditorService, $translate);

            __this = this;
            this._$scope = $scope;
            this._queryArchiveService = queryArchiveService;
            this._queryPacsService = queryPacsService;
            this._dataService = dataService;
            this._optionsService = optionsService;
            this._eventService = eventService;
            this._tabService = tabService;
            this._seriesManagerService = seriesManagerService;
            this._objectStoreService = objectStoreService;            
            this._objectRetrieveService = objectRetrieveService;
            this._viewStudy = false;
            this._dataCache = dataCache;
            this._hpOpenWith = "Hanging Protocol";
            this._sdOpenWith = "Structured Display";
            this._rowIndexPrevious = -1;

            $scope.hpContextMenu = this.hpContextMenu.bind(this);
            $scope.handleCellClicked = this.handleCellClicked.bind(this);

            $scope.gridOptions = {
                rowSelection: 'single',
                suppressNoRowsOverlay: true,
                groupHeaders: true,               
                enableSorting: true,
                rowClass: 'studyContext',
                angularCompileRows: true,
                columnDefs: [
                    {
                        headerName: studiesGroup,
                        children: [
                            {
                                headerName: "",
                                cellRenderer: Utils.countRenderer,
                                width: 35,
                                suppressSizeToFit: true,
                                onCellContextMenu: this.hpContextMenu.bind(this),
                                onCellClicked: this.handleCellClicked.bind(this)
                            },
                            {
                                headerName: "Patient ID",
                                valueGetter: function (params) {
                                    return Utils.nameFormatter(params.data.Patient.ID);},
                                cellRenderer: Utils.hyperlinkPatientIdRenderer,
                                onCellContextMenu: this.hpContextMenu.bind(this),
                                onCellClicked: this.handleCellClicked.bind(this)
                            },
                            {
                                headerName: "Name", valueGetter: function (params) {
                                    return Utils.nameFormatter(params.data.Patient.Name);
                            },
                                onCellContextMenu: this.hpContextMenu.bind(this),
                                onCellClicked: this.handleCellClicked.bind(this)
                            },
                            {
                                headerName: "Accession #",
                                field: "AccessionNumber",
                                onCellContextMenu: this.hpContextMenu.bind(this),
                                onCellClicked: this.handleCellClicked.bind(this)

                            },
                            {
                                headerName: "Study Date",
                                field: "Date",
                                cellRenderer: Utils.dateRenderer,
                                comparator: Utils.dateComparator,
                                onCellContextMenu: this.hpContextMenu.bind(this),
                                onCellClicked: this.handleCellClicked.bind(this)
                            },
                            {
                                headerName: "Refer Dr Name", valueGetter: function (params) {
                                    return Utils.nameFormatter(params.data.ReferringPhysiciansName);
                                },
                                onCellContextMenu: this.hpContextMenu.bind(this),
                                onCellClicked: this.handleCellClicked.bind(this)
                            },
                            {
                                headerName: "Description",
                                field: "Description",
                                onCellContextMenu: this.hpContextMenu.bind(this),
                                onCellClicked: this.handleCellClicked.bind(this)
                                }
                        ]
                    }
                ],                
                onRowSelected: this.studySelected.bind(this),
                rowData: null,
                onGridReady: function () {
                    $scope.gridOptions.api.hideOverlay();
                    setTimeout(function () {
                        $scope.gridOptions.api.sizeColumnsToFit();
                    }, 500);  

                    $.contextMenu({
                        selector: '.studyContext',
                        trigger: 'none',
                        className: 'data-title',
                        build: function ($trigger, e) {
                            var options = {
                                callback: function (key, options) {
                                    var selectedNodes: Array<any> = __this._$scope.gridOptions.api.getSelectedNodes();
                                    if (key == "NoHangingProtocolFound_407B6C09-83C2-4A7F-9643-AA4301F6A67A") {
                                        return;
                                    }
                                    
                                    __this.viewHangingProtocol(selectedNodes[0], key);
                                    },
                                // items: __this.get_hangingProtocols_test()
                                items: __this.get_hangingProtocols()
                            }

                            return options;
                        }
                    });
                }                
            }

            $scope.gridOptionsSeries = {
                rowSelection: 'single',
                suppressNoRowsOverlay: true,
                enableSorting: true,
                rowClass: 'seriesContext',
                groupHeaders: true,
                overlayNoRowsTemplate: '<span style="padding: 10px; border: 2px solid #444; background: lightgoldenrodyellow;">No Series Found</span>',
                rowHeight: parseInt(optionsService.get(OptionNames.SeriesThumbnailHeight)),
                columnDefs: [
                    {
                        headerName: seriesGroup,
                        children: [
                            {
                                headerName: "",
                                cellRenderer: Utils.has_mrtiRenderer,
                                width: 29,
                                suppressSizeToFit: true,
                                onCellContextMenu: this.contextMenu.bind(this),
                                suppressSorting: true
                            },
                            {
                                headerName: "",
                                cellRenderer: Utils.thumbnailRenderer,
                                hide: !optionsService.get(OptionNames.ShowSearchThumbnails),
                                width: parseInt(optionsService.get(OptionNames.SeriesThumbnailWidth)),
                                onCellContextMenu: this.contextMenu.bind(this),
                                suppressSorting: true
                            },                                                   
                            {
                                headerName: 'Number', field: 'Number',
                                onCellContextMenu: this.contextMenu.bind(this)
                            },
                            {
                                headerName: 'Series Date', field: 'Date',
                                cellRenderer: Utils.dateRenderer,
                                onCellContextMenu: this.contextMenu.bind(this),
                                comparator: Utils.dateComparator
                            },
                            {
                                headerName: 'Description', field: 'Description',
                                onCellContextMenu: this.contextMenu.bind(this)
                            },
                            {
                                headerName: 'Modality', field: 'Modality',
                                onCellContextMenu: this.contextMenu.bind(this)
                            },
                            {
                                headerName: 'Instances', field: 'NumberOfRelatedInstances',
                                onCellContextMenu: this.contextMenu.bind(this)
                            }
                        ]
                    }
                ],
                onRowSelected: this.seriesSelected.bind(this),
                rowData: null,
                onGridReady: function () {   
                    $scope.gridOptionsSeries.api.hideOverlay();                                                       

                    $.contextMenu({
                        selector: '.seriesContext',
                        trigger: 'none',
                        className: 'data-title',
                        build: function ($trigger, e) {

                            return {                                
                                callback: function (key, options) {                                    
                                    __this._eventService.publish(EventNames.SeriesSelected, {
                                        study: __this._selectedStudy, series: __this._selectedSeries,
                                        remote: __this._$scope.querySource.name == 'pacs',
                                        template: __this.getTemplate(key)
                                    });
                                },
                                items: __this.getTemplateMenu(__this._selectedSeries.Modality)
                            }
                        }
                    });
                    
                    setTimeout(function () {
                        $scope.gridOptionsSeries.api.sizeColumnsToFit();
                    }, 500);                      
                },                             
            }

            $scope.queryOptions = new Models.QueryOptions();
            $scope.studies = new Array<any>();
            $scope.pacsConnections = queryPacsService.remoteConnections;

            selection = $scope.pacsConnections.filter(function (connection: Models.PACSConnection, index: number, array) {
                return connection.isDefault;
            });

            if (selection.length > 0) {
                $scope.querySource.pacs = selection[0];
            }           

            $scope.doSearch = function () {
                this._rowIndexPrevious = -1;

                var queryOptions: Models.QueryOptions = angular.copy($scope.queryOptions);

                if (angular.isDefined(queryOptions.PatientsOptions.PatientName)) {
                    var m = queryOptions.PatientsOptions.PatientName.match(/"(.*?)"/);

                    if (m == null) {
                        queryOptions.PatientsOptions.PatientName = queryOptions.PatientsOptions.PatientName.replace(' ', '^');
                    }
                    else {
                        queryOptions.PatientsOptions.PatientName = m[1].replace(/"/g, '');
                    }
                }

                if (angular.isDefined(queryOptions.StudiesOptions.ReferDoctorName)) {
                    var m = queryOptions.StudiesOptions.ReferDoctorName.match(/"(.*?)"/);

                    if (m == null) {
                        queryOptions.StudiesOptions.ReferDoctorName = queryOptions.StudiesOptions.ReferDoctorName.replace(' ', '^');
                    }
                    else {
                        queryOptions.StudiesOptions.ReferDoctorName = m[1].replace(/"/g, '');
                    }
                }

                if (angular.isDefined(queryOptions.StudiesOptions.ModalitiesInStudy)) {
                    if (queryOptions.StudiesOptions.ModalitiesInStudy.length > 0) {
                        var modality: string = (<any>queryOptions.StudiesOptions.ModalitiesInStudy);

                        queryOptions.StudiesOptions.ModalitiesInStudy = [];
                        queryOptions.StudiesOptions.ModalitiesInStudy.push(modality);
                    }
                }
                __this._selectedStudy = null;
                __this._selectedSeries = null;
                $scope.gridOptions.api.setRowData([]);                
                $scope.gridOptionsSeries.api.setRowData([]);
                $scope.gridOptionsSeries.api.hideOverlay();
                switch ($scope.querySource.name) {
                    case 'database':
                        queryArchiveService.FindStudies(queryOptions, maxStudyResults).then(function (result) {
                            eventService.publish("Search/Study/Success", result.data);
                            $scope.gridOptions.api.setRowData(result.data);
                        }, function (error) {
                            eventService.publish("Search/Study/Failure", { error: error });
                        });
                        break;
                    case 'pacs':
                        queryPacsService.FindStudies($scope.querySource.pacs, queryPacsService.clientAETitle, queryOptions).then(function (result) {
                            eventService.publish("Search/Study/Success", result.data);
                            $scope.gridOptions.api.setRowData(result.data);
                        }, function (error) {
                            eventService.publish("Search/Study/Failure", { error: error });
                        });
                        break;
                }
            }

            $scope.clear = function () {
                $scope.queryOptions = new Models.QueryOptions();
                $scope.gridOptions.api.setRowData([]);
                $scope.gridOptionsSeries.api.setRowData([]);

                __this._selectedStudy = null;
                __this._selectedSeries = null;
            }

            $scope.queryModeChanged = function () {
                $scope.studies.length = 0;
            }            

            $scope.patientids = $.proxy(this.patientids, this);
            $scope.patientNames = $.proxy(this.patientNames, this);    
            
            $scope.onLayoutChanged = function (newValue, oldValue) {
                setTimeout(function () {
                    if ($scope.gridOptions.api)
                        $scope.gridOptions.api.sizeColumnsToFit();
                    if ($scope.gridOptionsSeries.api)
                        $scope.gridOptionsSeries.api.sizeColumnsToFit();
                }, 250);
            }

            $scope.onSearchTabSelected = function () {
                setTimeout(function () {
                    var studyNodes = $scope.gridOptions.api.getSelectedNodes();
                    var seriesNodes = $scope.gridOptions.api.getSelectedNodes();

                    $scope.gridOptions.api.refreshView();
                    $scope.gridOptionsSeries.api.refreshView();
                    $scope.gridOptions.api.sizeColumnsToFit();
                    $scope.gridOptionsSeries.api.sizeColumnsToFit();     
                                                       
                    if (studyNodes.length > 0) {
                        $scope.gridOptions.api.ensureNodeVisible(studyNodes[0]);
                    }

                    if (seriesNodes.length > 0) {
                        $scope.gridOptionsSeries.api.ensureNodeVisible(seriesNodes[0]);
                    }
                    
                }, 225);
            }               
            
            $scope.$watch('windowDimensions', function (newValue, oldValue) {
                if ($scope.gridOptions.api) {
                    setTimeout(function () {                        
                        $scope.gridOptions.api.sizeColumnsToFit();
                        $scope.gridOptionsSeries.api.sizeColumnsToFit();
                    }, 500);
                }
            }); 

            //eventService.subscribe(EventNames.MrtiInfoReady, function (event, data) {
            //    Utils.clearMrti(this._$scope.gridOptionsSeries.api, this._$scope.gridOptionsSeries.rowData, data.args.seriesInstanceUID);
            //}.bind(this));

            $scope.onViewStudy = this.onViewStudy.bind(this);

        }

        private onViewStudy(data: any) {
            this._viewStudy = true;
        }

        private viewHangingProtocol(data, sopInstanceUID: string) {
            var self = this;            

            this._objectRetrieveService.GetHangingProtocol(sopInstanceUID).then(function (result) {
                var hp: Models.HangingProtocol = result.data;

                self._templateService.currentStudyLayout = null;
                self._templateService.currentHangingProtocol = hp;
                self._objectRetrieveService.GetHangingProtocolInstances(sopInstanceUID, self._selectedStudy.Patient.ID, self._selectedStudy.InstanceUID, self._selectedStudy.Date).then(function (result) {
                    self.loadHangingProtocol(result.data, hp);
                }, function (error) {
                });                
            });
        }

        private studySelected(data, hpSopInstanceUID?:string) {
            var selectedNodes: Array<any> = this._$scope.gridOptions.api.getSelectedNodes();
            var viewStudy = this._viewStudy;

            this._viewStudy = false;
            this._loadingStudySeries = true;
            if (selectedNodes.length == 1 && selectedNodes[0].data != this._selectedStudy) {
                var query: Models.QueryOptions = new Models.QueryOptions;
                var maxSeriesResults: string = this._optionsService.get(OptionNames.MaxSeriesResults);
                var __this = this;
                var modalitiesInStudy = this._$scope.queryOptions.StudiesOptions.ModalitiesInStudy;

                this._selectedStudy = data.node.data;
                this._$scope.gridOptionsSeries.api.setRowData(undefined);
                this._$scope.gridOptionsSeries.api.showLoadingOverlay();
                query.StudiesOptions = new Models.StudyQueryOptions();
                query.StudiesOptions.StudyInstanceUID = data.node.data.InstanceUID;
                if (angular.isDefined(modalitiesInStudy)) {
                    if (modalitiesInStudy.length > 0) {
                        var modality: string = (<any>modalitiesInStudy);

                        query.StudiesOptions.ModalitiesInStudy = [];
                        query.StudiesOptions.ModalitiesInStudy.push(modality);
                    }
                }
                             
                switch (this._$scope.querySource.name) {
                    case 'database':
                        this._queryArchiveService.FindSeries(query, maxSeriesResults).then(function (result) {
                            if (result.data["FaultType"]) {
                                if (result.data["Message"]) {
                                    __this._$scope.gridOptionsSeries.api.hideOverlay();
                                    alert(result.data["Message"]);                                    
                                }
                            }
                            else {
                                __this._dataService.set_Series(result.data);
                                if (__this._selectedStudy.InstanceUID == result.data[0].StudyInstanceUID) {
                                __this._$scope.gridOptionsSeries.api.setRowData(result.data);
                                    if (viewStudy) {
                                        __this.loadStudy();
                                    }
                                }
                            }
                            __this._loadingStudySeries = false;
                        });
                        break;
                    case 'pacs':
                        this._queryPacsService.FindSeries(this._$scope.querySource.pacs, this._queryPacsService.clientAETitle, query).then(function (result) {
                            if (result.data["FaultType"]) {
                                if (result.data["Message"]) {
                                    __this._$scope.gridOptionsSeries.api.hideLoadingOverlay();
                                    alert(result.data["Message"]);
                                }
                            }
                            else {
                                __this._dataService.set_Series(result.data);
                                if (__this._selectedStudy.InstanceUID == result.data[0].StudyInstanceUID) {                                    
                                __this._$scope.gridOptionsSeries.api.setRowData(result.data);
                                    if (viewStudy) {
                                        __this.loadStudy();
                                    }
                                }
                            }
                            __this._loadingStudySeries = false;
                        });
                        break;
                }
            }
            else {
                this._loadingStudySeries = false;
                if (viewStudy) {
                    this.loadStudy();
                }
            }
        }

        private loadHangingProtocol(views: Array<any>, hp: Models.HangingProtocol) {
            var self = this;

            angular.forEach(views, function (value, key) {
                var study = {
                    InstanceUID: value.Series.StudyInstanceUID,
                    Patient: value.Series.Patient
                };

                self.loadHangingProtocolSeries(study, value.Series, value);
            });
        }

        private queryForSeries(self, seriesInstanceUID: string, imageBoxNumber: number, sopInstanceUidList: string[]) {
            var query: Models.QueryOptions = new Models.QueryOptions;

            var _seriesInstanceUID = seriesInstanceUID;
            var _imageBoxNumber = imageBoxNumber;
            var _sopInstanceList = sopInstanceUidList;

            query.SeriesOptions.SeriesInstanceUID = _seriesInstanceUID;
            switch (self._$scope.querySource.name) {
                case 'database':
                    self._queryArchiveService.FindSeries(query, 1).then(function (result) {
                        if (result.data["FaultType"]) {
                            if (result.data["Message"]) {
                                alert(result.data["Message"]);
                            }
                        }
                        else {
                            if (result.data && result.data.length > 0) {
                                result.data[0].ImageBoxNumber = _imageBoxNumber; // studyLayout.ImageBoxNumber;
                                result.data[0].SopInstanceUIDs = _sopInstanceList;
                                self.loadSeries({ InstanceUID: result.data[0].StudyInstanceUI}, result.data[0]
                                );
                            }
                        }
                    });
                    break;
                case 'pacs':
                    self._queryPacsService.FindSeries(self._$scope.querySource.pacs, self._queryPacsService.clientAETitle, query).then(function (result) {
                        if (result.data["FaultType"]) {
                            if (result.data["Message"]) {
                                alert(result.data["Message"]);
                            }
                        }
                        else {
                            if (result.data && result.data.length > 0) {
                                result.data[0].SopInstanceUIDs = _sopInstanceList;
                                self.loadSeries({ InstanceUID: result.data[0].StudyInstanceUID}, result.data[0]);
                            }
                        }
                    });
                    break;
            }
        }


        private getImageBox(imageBoxNumber: number, boxes) {

            var index = 0;
            var length = boxes.length;

            for (index = 0; index < length; index++) {
                if (boxes[index].ImageBoxNumber == imageBoxNumber)
                    return index;
            }

            return -1;
        }


        private loadStudy(checkHangingProtocol?: boolean) {
            var self = this;

            //eventService.subscribe(EventNames.SelectedTabChanged, function (event, data) {
            //}.bind(this));

            this._dataCache['StudyInstanceUID'] = this._selectedStudy.InstanceUID;
            var studyLayout: Models.StudyLayout = null;
            this._objectRetrieveService.GetStudyLayout(<any>(this._selectedStudy.InstanceUID)).then(function (result) {
                studyLayout= result.data;

                self._templateService.currentHangingProtocol = null;

                if (result.data == "") {

                    var counter = 0;
                    var index = 0;
                    var length = self._$scope.gridOptionsSeries.rowData.length;
                    for (index = 0; index < length; index++) {
                        if (self._$scope.gridOptionsSeries.rowData[index].CompleteMRTI) {
                            counter++;
                        }
                    }
                }

                self._templateService.currentStudyLayout = studyLayout;

                if (!angular.isDefined(studyLayout["Series"])) {
                    self.loadSeries(self._selectedStudy, self._$scope.gridOptionsSeries.rowData[0]);
                    
                }
                else {
                        studyLayout['studyInstanceUID'] = self._selectedStudy.InstanceUID;
                        $.each(studyLayout.Series, function (index: number, item: Models.SeriesInfo) {
                            var series = self._seriesManagerService.get_seriesInfo(item.SeriesInstanceUID);

                            if (!series) {
                                self.queryForSeries(self, item.SeriesInstanceUID, item.ImageBoxNumber, studyLayout.Boxes[self.getImageBox(item.ImageBoxNumber, studyLayout.Boxes)].referencedSOPInstanceUID);
                            }
                        });

                        $.each(studyLayout.OtherStudies, function (index: number, study: Models.OtherStudies) {
                            $.each(study.Series, function (index: number, item: Models.SeriesInfo) {
                                var series = self._seriesManagerService.get_seriesInfo(item.SeriesInstanceUID);

                                if (!series) {
                                    self.queryForSeries(self, item.SeriesInstanceUID, item.ImageBoxNumber, studyLayout.Boxes[self.getImageBox(item.ImageBoxNumber, studyLayout.Boxes)].referencedSOPInstanceUID);
                                }
                            });
                        });
                    }
            });

            this._viewStudy = false;
        }

        private autoLoadWithHangingProtocol() {
            var nodes = this._$scope.gridOptions.api.getSelectedNodes();

            this.studySelected(nodes[0]);
            this.waitForSeries(nodes[0], true);
        }

        private loadSeries(study, series) {
            this._eventService.publish(EventNames.SeriesSelected, {
                study: study,
                series: series,
                remote: this._$scope.querySource.name == 'pacs',
                studyLoad: true
            });
        }

        private loadHangingProtocolSeries(study, series, view) {
            this._eventService.publish(EventNames.SeriesSelected, {
                study: study,
                series: series,
                view : view,
                remote: this._$scope.querySource.name == 'pacs',                
                displaySetNumber: view.DisplaySetNumber               
            });
        }
        
        private matchTemplateForSeries(data) {
            var StudyInstanceUID = data.node.data.StudyInstanceUID;
            var SeriesInstanceUID = data.node.data.InstanceUID;

            if (StudyInstanceUID && SeriesInstanceUID) {                
                
                    //read first instance's json
                    var promise = this._objectRetrieveService.GetDicomJSON(StudyInstanceUID, SeriesInstanceUID, '');

                    //on success
                    promise.success(function (json) {

                        var _template = null;

                        this.getAutoMatchTemplates().some((template: Models.Template) => {                            

                            //parse the json and see if we have a match
                            try
                            {
                                if (!_template) {
                                    if (Utils.executeScript(template.AutoMatching, json)) {
                                        console.log('template auto-match found');
                                        _template = template;
                                        return true;//break;
                                    }
                                }
                            }
                            catch (e)
                            {
                                console.log(e);
                            }
                            return false;//continue
                        });

                        //use template (if any) to view
                        this._eventService.publish(EventNames.SeriesSelected, {
                            study: this._selectedStudy,
                            series: data.node.data,
                            remote: this._$scope.querySource.name == 'pacs',
                            template: _template
                        });

                    }.bind(this));

                    //on error - default to no template - continue loading
                    promise.error(function (e) {
                        console.log(e);

                        this._eventService.publish(EventNames.SeriesSelected, {
                            study: this._selectedStudy,
                            series: data.node.data,
                            remote: this._$scope.querySource.name == 'pacs'
                        });
                    });
                
            }
            else {
                console.log('failed to read study/series id');

                //default to no template - continue loading
                this._eventService.publish(EventNames.SeriesSelected, {
                    study: this._selectedStudy,
                    series: data.node.data,
                    remote: this._$scope.querySource.name == 'pacs'
                });
            }
        }

        private seriesSelected(data) {
            var selectedNodes: Array<any> = this._$scope.gridOptionsSeries.api.getSelectedNodes();

            this._templateService.currentStudyLayout = null;

            if (selectedNodes.length == 1) {
                if (selectedNodes[0].data != this._selectedSeries) {
                    this._selectedSeries = data.node.data;
                    if (this.isAnyTemplateAutoMatch()) {
                        this.matchTemplateForSeries(data);                        
                    }
                    else {                        
                    this._eventService.publish(EventNames.SeriesSelected, {
                        study: this._selectedStudy,
                        series: data.node.data,
                            remote: this._$scope.querySource.name == 'pacs'
                    });
                    }
                }
                else if (selectedNodes[0].data == this._selectedSeries) {
                    var tab: Models.Tab = this._seriesManagerService.get_seriesTab(data.node.data.InstanceUID);

                    if (tab != null) {
                        this._tabService.select_tab(tab.id);
                    }
                    else {
                        if (this.isAnyTemplateAutoMatch()) {
                            this.matchTemplateForSeries(data);
                        }
                        else {
                        this._eventService.publish(EventNames.SeriesSelected, {
                            study: this._selectedStudy,
                            series: data.node.data,
                                remote: this._$scope.querySource.name == 'pacs'
                        });
                        }
                    }
                }
            }
        }

        private contextMenu(data) {
            //this._selectedSeries = data.data;
            //this._$scope.gridOptionsSeries.api.selectNode(data.node, false, true);
            //$('.seriesContext').contextMenu({ x: data.event.pageX, y: data.event.pageY });
            //if (this._openWith.length > 0) {
            //    $('.data-title').attr('data-menutitle', this._openWith);
            //}
        }

        private hpContextMenu(data) : void {                
            this._$scope.gridOptions.api.selectNode(data.node, false, true);
            this.studySelected(data);
            this.waitForSeries(data);
        }

        private handleCellClicked(params) {
            if (lt.LTHelper.OS == lt.LTOS.iOS && lt.LTHelper.device != lt.LTDevice.desktop) {
                if (this._rowIndexPrevious == params.rowIndex) {
                    if (this._viewStudy == false) {
                        this._$scope.hpContextMenu(params)
                    }
                }
                this._rowIndexPrevious = params.rowIndex;
            }
        }

        private waitForSeries(data, loadBest?: boolean) {
            var self = this;

            if (this._loadingStudySeries == true) {
                setTimeout(function () {
                    self.waitForSeries(data);        
                }, 100);
            }
            else {
                var query: Models.HangingProtocolQuery = new Models.HangingProtocolQuery();
                var modalites: Array<string> = this.get_ModalitesInActiveStudy();

                this._loadingHangingProtocols = true;
                this._hangingProtocols = new Array<Models.HangingProtocolQueryResult>();
                var isDental: boolean = this._optionsService.get(OptionNames.DentalMode);

                this.waitForHangingProtocols(data, loadBest);

                this._queryArchiveService.FindHangingProtocols(data.data.InstanceUID).then(function (result) {
                    self._hangingProtocols = result.data;
                    self._loadingHangingProtocols = false;
                });                             
            }
        }


        private showStructuredDisplayMenu(data, loadBest?: boolean) {
            var self = this;
            if (this._loadingHangingProtocols == true) {
                setTimeout(function () {
                    self.showStructuredDisplayMenu(data, loadBest);
                }, 100);
            }
            else {
                $('.studyContext').contextMenu({ x: data.event.pageX, y: data.event.pageY });
                if (this._sdOpenWith.length > 0) {
                    $('.data-title').attr('data-menutitle', this._sdOpenWith);
                }
            }
        }

        //
        // Waits for all the hanging protocols to be loaded.  If load best is true then the
        // best matched hanging protocol will be loaded. 
        //
        private waitForHangingProtocols(data, loadBest?:boolean) {
            var self = this;

            if (this._loadingHangingProtocols == true) {
                setTimeout(function () {
                    self.waitForHangingProtocols(data, loadBest);
                }, 100);
            }
            else {
                if (this._hangingProtocols && this._hangingProtocols.length >= 0) {
                    if (!loadBest) {
                        $('.studyContext').contextMenu({ x: data.event.pageX, y: data.event.pageY });
                        if (this._hpOpenWith.length > 0) {
                            $('.data-title').attr('data-menutitle', this._hpOpenWith);
                        }
                    }
                    else {
                        if (this._hangingProtocols.length == 0) {
                            this._objectRetrieveService.GetHangingProtocol(self._hangingProtocols[0].SOPInstanceUID).then(function (result) {
                                var hp: Models.HangingProtocol = result.data;

                                self._templateService.currentStudyLayout = null;
                                self._templateService.currentHangingProtocol = hp;
                                self._objectRetrieveService.GetHangingProtocolInstances(self._hangingProtocols[0].SOPInstanceUID, self._selectedStudy.Patient.ID, self._selectedStudy.InstanceUID, null).then(function (result) {
                                    self.loadHangingProtocol(result.data, hp);
                                }, function (error) {
                                });
                            });
                        }
                    }
                }
                //else {
                //    self.loadStudy(false);
                //}
            }            
        }

        private get_ModalitesInActiveStudy(): Array<string> {
            var modalities: Array<string> = new Array<string>();
            var count: number = this._$scope.gridOptionsSeries.rowData.length;

        for (var i = 0; i < count; i++) {
            var series = this._$scope.gridOptionsSeries.rowData[i];

            if (modalities.indexOf(series.Modality) == -1)
                modalities.push(series.Modality);
        }

        return modalities;
        }


        public get_hangingProtocolsType(level: Models.HangingProtocolLevel) {
            var menuItems = {};
            var isEmpty: boolean = true;

            var iconName: string = "";
            switch (level) {
                case Models.HangingProtocolLevel.Manufacturer:
                    iconName = "fa-gear";
                    break;
                case Models.HangingProtocolLevel.Site:
                    iconName = "fa-institution";
                    break;
                case Models.HangingProtocolLevel.UserGroup:
                    iconName = "fa-group";
                    break;

                case Models.HangingProtocolLevel.SingleUser:
                    iconName = "fa-user";
                    break;
            }

            for (var i = 0; i < this._hangingProtocols.length; i++) {
                var protocolResult: Models.HangingProtocolQueryResult = this._hangingProtocols[i];
                if (protocolResult.Level == level) {
                    isEmpty = false;
                    menuItems[protocolResult.SOPInstanceUID] = {
                        name: protocolResult.Name,
                        icon: iconName
                    };
                }
            }

            if (isEmpty) {
                menuItems = null;
            }
            return menuItems;
        }

        public addSeparator(menuItems, needsSeparator: boolean, separatorName: string) {
            if (needsSeparator)
                menuItems[separatorName] = "---------";
        }

        public get_hangingProtocols() {
            var menuItems = {};

            var manufacturerItems = this.get_hangingProtocolsType(Models.HangingProtocolLevel.Manufacturer);
            var siteItems = this.get_hangingProtocolsType(Models.HangingProtocolLevel.Site);
            var userGroupItems = this.get_hangingProtocolsType(Models.HangingProtocolLevel.UserGroup);
            var singleUserItems = this.get_hangingProtocolsType(Models.HangingProtocolLevel.SingleUser);

            var needsSeparator: boolean = false;

            // Manufacturer Items
            if (manufacturerItems != null) {
                menuItems = jQuery.extend(menuItems, manufacturerItems);
                needsSeparator = true;
            }

            // Site
            if (siteItems != null) {
                this.addSeparator(menuItems, needsSeparator, "sepSite");
                menuItems = jQuery.extend(menuItems, siteItems);
                needsSeparator = true;
            }

            // User Group
            if (userGroupItems != null) {
                this.addSeparator(menuItems, needsSeparator, "sepUserGroup");
                menuItems = jQuery.extend(menuItems, userGroupItems);
                needsSeparator = true;
            }

            // Single User
            if (singleUserItems != null) {
                this.addSeparator(menuItems, needsSeparator, "sepSingleUser");
                menuItems = jQuery.extend(menuItems, singleUserItems);
                needsSeparator = true;
            }

            // No Hanging Protocols found, so create a menu that indicates this
            if (needsSeparator == false) {
                menuItems = {
                    "NoHangingProtocolFound_407B6C09-83C2-4A7F-9643-AA4301F6A67A":
                    {
                        name: "No Hanging Protocols",
                        // disabled: true,
                        icon: "fa-exclamation-triangle",
                        className: "context-menu-red-message"
                    },
                };
            }
           
            return menuItems;
        }

        private get_hangingProtocols_test() {
            var items = {
                "Manufacturer": { name: "Manufacturer", disabled : true},
                "edit": { name: "Edit", icon: "edit" },
                "cut": { name: "Cut", icon: "fa-gear" },

                "sepSite": "---------",
                "Site": { name: "Site", disabled: true },

                "copy": { name: "Copy", icon: "copy" },
                "paste": { name: "Paste", icon: "paste" },
                "stayOpen": { name: "StayOpen", icon: "paste", callback: function () { return false;} },

                "sepUserGroup": "---------",
                "UserGroup": { name: "User Group", disabled: true },
            }

            return items;
        }


    }



    //export class SearchViewController extends SearchController {
    //}

}