// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/LEADTOOLS/jquery/jquery.d.ts" />
/// <reference path="../../lib/custom.d.ts" />
/// <reference path="Scopes.ts" />
/// <reference path="SearchController.ts" />

module Controllers {   
    export interface IDentalSearchControllerScope extends ISearchControllerScope {
        openDateStart: Function;
        openDateEnd: Function;
        dateStartOpened: boolean;
        dateEndOpened: boolean;
        config: any;              
        virtualgridapi: any;
        dateFormat: string;
        dateOptions: any;

        datePicker: any;  
        gridOptions: any; 
        gridOptionsSeries: any; 
                         
        patientids(value: string);
        patientNames(value: string);

        hpContextMenu(data: any): void;
        handleCellClicked(data: any): void;


        resize();
    }    

    export class DentalSearchViewController extends SearchController {
        static $inject = ['$rootScope', '$scope', '$modal', 'uiGridConstants', 'eventService', 'queryArchiveService', 'optionsService', 'dataService', 'authenticationService', 'queryPacsService', 'seriesManagerService', 'tabService', 'templateService', 'templateEditorService', 'objectRetrieveService', '$translate'];                

        private _$scope: IDentalSearchControllerScope;
        private _objectRetrieveService: ObjectRetrieveService;
        private _seriesManagerService: SeriesManagerService;
        private _eventService: EventService;
        private _queryPacsService: QueryPacsService;
        private _optionsService: OptionsService;
        private _tabService: TabService;
        private _dataService: DataService;
        private _selectedSeries;
        private _selectedStudy;
        private _selectedPatient;
        private _sdOpenWith: string;
        private _viewStudy: boolean;
        private _rowIndexPrevious: number;
        private _loadingStructuredDisplay: boolean;
        private _loadingPatientSeries: boolean;
        private _localStructuredDisplay: Array<Models.HangingProtocolQueryResult>;
        private _loadingStudySeries;
         
        constructor($rootScope, $scope: IDentalSearchControllerScope, $modal, uiGridConstants, eventService: EventService, queryArchiveService: QueryArchiveService, optionsService: OptionsService, dataService: DataService, authenticationService: AuthenticationService, queryPacsService: QueryPacsService, seriesManagerService: SeriesManagerService, tabService: TabService, templateService: TemplateService, templateEditorService: TemplateEditorService, objectRetrieveService: ObjectRetrieveService, $translate) {           
            var __this;                      
            var selection;                       
            var patientGroup = "Patients";
            var seriesGroup = "Series";  
            var dateFormat = optionsService.get(OptionNames.DateFormat);
            var timeFormat = optionsService.get(OptionNames.TimeFormat);                                               

            super($rootScope, $scope, queryArchiveService, optionsService, authenticationService, queryPacsService, tabService, eventService, templateService, templateEditorService, $translate);

            __this = this;
            this._$scope = $scope;
            this._seriesManagerService = seriesManagerService;
            this._eventService = eventService;
            this._queryArchiveService = queryArchiveService;
            this._queryPacsService = queryPacsService;
            this._optionsService = optionsService;
            this._tabService = tabService;
            this._dataService = dataService;
            this._objectRetrieveService = objectRetrieveService;
            this._viewStudy = false;
            this._rowIndexPrevious = -1;

            $scope.hpContextMenu = this.hpContextMenu.bind(this);
            $scope.handleCellClicked = this.handleCellClicked.bind(this);
            $scope.patientids = $.proxy(this.patientids, this);
            $scope.patientNames = $.proxy(this.patientNames, this);    

            this._tabService.set_tabData(this._tabService.tabs[0].id, TabDataKeys.searchViewerController, this);






            $scope.gridOptions = {
                rowSelection: 'single',
                rowClass: 'patientContext',
                groupHeaders: true,
                suppressNoRowsOverlay: true,
                columnDefs: [
                    {
                        headerName: patientGroup,
                        children: [
                            {
                                headerName: "",
                                cellRenderer: Utils.countRenderer,                                
                                width: 29,
                                onCellContextMenu: this.hpContextMenu.bind(this),
                                suppressSizeToFit: true
                            },
                            {
                                headerName: "Patient ID",
                                field: "ID",
                                onCellContextMenu: this.hpContextMenu.bind(this),
                            },
                            {
                                headerName: "Name",
                                onCellContextMenu: this.hpContextMenu.bind(this),
                                valueGetter: function (params)  {
                                    return Utils.nameFormatter(params.data.Name);
                                }
                            },
                            {
                                headerName: "Sex",
                                onCellContextMenu: this.hpContextMenu.bind(this),
                                field: "Sex"
                            },
                            {
                                headerName: "Birth Date",
                                onCellContextMenu: this.hpContextMenu.bind(this),
                                field: "BirthDate",
                                cellRenderer: Utils.dateRenderer
                            }
                        ]
                    }
                ],                
                onRowSelected: this.patientSelected.bind(this),                
                rowData: null,
                onGridReady: function () {
                    $scope.gridOptions.api.hideOverlay();
                    setTimeout(function () {
                        $scope.gridOptions.api.sizeColumnsToFit();
                    }, 500);                    

                    $.contextMenu({
                    selector: '.patientContext',
                    trigger: 'none',
                    className: 'data-title',
                        build: function ($trigger, e) {
                            return {
                                callback: function (key, options) {


                                   
                                    __this._seriesManagerService.currentPatientSeries = __this._$scope.gridOptionsSeries.rowData;

                                    var index = 0;
                                    var length = __this._localStructuredDisplay.length;
                                    for (index = 0; index < length; index++) {
                                        if (__this._localStructuredDisplay[index].Name == key) {
                                            __this._seriesManagerService.currentLoadingSeries = __this.getSelectedSeries(__this._localStructuredDisplay[index]);
                                            __this._seriesManagerService.structuredDisplayList = __this._localStructuredDisplay;

                                            __this._seriesManagerService._currentStructuredDisplay = __this._localStructuredDisplay[index];

                                            __this.loadselectedStructureDisplay(__this._localStructuredDisplay[index]);
                                            return;
                                        }
                                    }
                                },
                                items: __this.get_PatientStructuredDisplayItems()
                            }
                        }
                    });
                }
            }

            $scope.gridOptionsSeries = {    
                rowSelection: 'single',
                suppressNoRowsOverlay: true,
                groupHeaders: true,
                rowClass: 'seriesContext',
                rowHeight: parseInt(optionsService.get(OptionNames.SeriesThumbnailHeight)),
                overlayNoRowsTemplate: '<span style="padding: 10px; border: 2px solid #444; background: lightgoldenrodyellow;">No Series Found</span>',
                columnDefs: [
                    {
                        headerName: seriesGroup,
                        children: [
                            {
                                headerName: "",
                                cellRenderer: Utils.has_mrtiRenderer,                                
                                width: 29,
                                suppressSizeToFit: true,
                                onCellContextMenu: this.contextMenu.bind(this)
                            },
                            {
                                headerName: "",
                                cellRenderer: Utils.thumbnailRenderer,                                
                                hide: !optionsService.get(OptionNames.ShowSearchThumbnails),
                                width: parseInt(optionsService.get(OptionNames.SeriesThumbnailWidth)),
                                onCellContextMenu: this.contextMenu.bind(this),                                
                            },                           
                            {
                                headerName: 'Number', field: 'Number',
                                onCellContextMenu: this.contextMenu.bind(this)},
                            {
                                headerName: 'Series Date', field: 'Date',
                                cellRenderer: Utils.dateRenderer,
                                onCellContextMenu: this.contextMenu.bind(this)
                            },
                            {
                                headerName: 'Description',
                                field: 'Description',
                                onCellContextMenu: this.contextMenu.bind(this)
                            },
                            {
                                headerName: 'Modality',
                                field: 'Modality',
                                onCellContextMenu: this.contextMenu.bind(this)
                            },
                            {
                                headerName: 'Instances',
                                field: 'NumberOfRelatedInstances',
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


                                    /*
                                    __this._seriesManagerService.currentPatientSeries = __this._$scope.gridOptionsSeries.rowData;

                                    var index = 0;
                                    var length = __this._localStructuredDisplay.length;
                                    for (index = 0; index < length; index++) {
                                        if (__this._localStructuredDisplay[index].Name == key) {
                                            __this._seriesManagerService.currentLoadingSeries = __this.getSelectedSeries(__this._localStructuredDisplay[index]);
                                            __this._seriesManagerService.structuredDisplayList = __this._localStructuredDisplay;

                                            __this._seriesManagerService._currentStructuredDisplay = __this._localStructuredDisplay[index];

                                            __this.loadselectedStructureDisplay(__this._localStructuredDisplay[index]);
                                            return;
                                        }
                                    }*/

                                    var structuredDisplay = __this.createStructuredDisplayFromTemplate(__this.getTemplate(key));


                                    __this._seriesManagerService.currentLoadingSeries = __this.getSelectedSeries(structuredDisplay);
                                    __this._seriesManagerService.structuredDisplayList = __this._localStructuredDisplay;

                                    __this._seriesManagerService._currentStructuredDisplay = structuredDisplay;

                                    __this.loadselectedStructureDisplay(structuredDisplay);

                                    return;




                                    /*

                                    __this._seriesManagerService.currentLoadingSeries = __this._selectedSeries;
                                    __this._seriesManagerService.currentPatientSeries = __this._$scope.gridOptionsSeries.rowData;

                                    __this._templateService.currentStudyLayout = null;

                                    __this._eventService.publish(EventNames.SeriesSelected, {
                                        study: __this._selectedStudy,
                                        series: __this._selectedSeries,
                                        remote: __this._$scope.querySource.name == 'pacs',
                                        template: __this.getTemplate(key)
                                    });*/
                                },
                                items: __this.getTemplateMenu(__this._selectedSeries.Modality)
                            }
                        }
                    });

                    setTimeout(function () {
                        $scope.gridOptionsSeries.api.sizeColumnsToFit();
                    }, 500); 
                }                         
            }                      
                         
            $scope.queryOptions = new Models.QueryOptions(); 
            $scope.queryOptions.PatientsOptions.PatientID = '';
            $scope.pacsConnections = queryPacsService.remoteConnections;  
            $scope.dateFormat = dateFormat; 
            $scope.dateOptions = {
                'show-weeks': false
            };       
            $scope.datePicker = {};
            $scope.datePicker.dateStartOpened = false;   
            $scope.datePicker.dateEndOpened = false; 

            selection = $scope.pacsConnections.filter(function (connection: Models.PACSConnection, index: number, array) {
                return connection.isDefault;
            });

            if (selection.length > 0) {
                $scope.querySource.pacs = selection[0];
            }                              
                                                                                                                             
            $scope.doSearch = function () {   
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

                __this._selectedSeries = null;
                this.gridOptions.api.setRowData([]);
                this.gridOptionsSeries.api.setRowData([]); 
                this.gridOptionsSeries.api.hideOverlay();  
                switch ($scope.querySource.name) {
                    case 'database':                        
                        queryArchiveService.FindPatients(queryOptions).then(function (result) {
                            if (result.data["FaultType"]) {
                                if (result.data["Message"]) {
                                    __this._$scope.gridOptionsSeries.api.hideOverlay();
                                    alert(result.data["Message"]);
                                }
                            }
                            else {                                
                                eventService.publish(EventNames.SearchPatientsSuccess, result.data);                                
                                $scope.gridOptions.api.setRowData(result.data);
                            }
                        }, function (error) {
                            });
                        break;
                    case 'pacs':
                        queryPacsService.FindPatients($scope.querySource.pacs, queryPacsService.clientAETitle, queryOptions).then(function (result) {
                            if (result.data["FaultType"]) {
                                if (result.data["Message"]) {
                                    __this._$scope.gridOptionsSeries.api.hideOverlay();
                                    alert(result.data["Message"]);
                                }
                            }
                            else {                                
                                eventService.publish(EventNames.SearchPatientsSuccess, result.data);                                
                                $scope.gridOptions.api.setRowData(result.data);
                            }
                        }, function (error) {
                                eventService.publish("Search/Study/Failure", { error: error });
                            });
                        break;
                }
            }


            $scope.clear = function () {
                $scope.queryOptions = new Models.QueryOptions();
                this.gridOptions.api.setRowData([]);    
                this.gridOptionsSeries.api.setRowData([]);   
                this._selectedSeries = null;         
            }
           
            $scope.OnSeriesSearchError = function (data, status) {
                eventService.publish(EventNames.SearchSeriesFailure, { data: data, status: status });
            }                     

            $scope.openDateStart = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.datePicker.dateStartOpened = !$scope.datePicker.dateStartOpened;
            } 

            $scope.openDateEnd = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.datePicker.dateEndOpened = !$scope.datePicker.dateEndOpened;
            }

            $scope.queryModeChanged = function () {
                $scope.clear();
            }  
            
            $scope.onLayoutChanged = function (newValue, oldValue) {
                setTimeout(function () {
                    try {
                        $scope.gridOptions.api.sizeColumnsToFit();
                        $scope.gridOptionsSeries.api.sizeColumnsToFit();                    
                    }
                    catch (e) {
                    }
                }, 250);
            }  
            
            $scope.onSearchTabSelected = function () {
                setTimeout(function () {
                    var studyNodes = $scope.gridOptions.api.getSelectedNodes();
                    var seriesNodes = $scope.gridOptions.api.getSelectedNodes();

                    $scope.gridOptions.api.sizeColumnsToFit();
                    $scope.gridOptionsSeries.api.sizeColumnsToFit();
                    $scope.gridOptions.api.refreshView();
                    $scope.gridOptionsSeries.api.refreshView();

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



            eventService.subscribe(EventNames.MrtiInfoReady, function (event, data) {
                Utils.clearMrti(this._$scope.gridOptionsSeries.api, this._$scope.gridOptionsSeries.rowData, data.args.seriesInstanceUID);
            }.bind(this));
        }                       


        private getSelectedSeries(structureDisplay)
        {
            var studyInstanceUID = structureDisplay.Series[0].StudyInstanceUID;

            var index = 0;
            var seriesArray = this._$scope.gridOptionsSeries.rowData;
            var length = seriesArray.length;

            for (index = 0; index < length; index++) {
                if (seriesArray[index].StudyInstanceUID == studyInstanceUID)
                    return seriesArray[index];
            }
        }

        private get_PatientStructuredDisplayItems() {
            var menuItems = {};

            for (var i = 0; i < this._localStructuredDisplay.length; i++) {
                var protocolResult: Models.HangingProtocolQueryResult = this._localStructuredDisplay[i];
                menuItems[protocolResult.Name] = {
                    name: protocolResult.Name
                }
            }

            return menuItems;
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

        private queryForSeries(self, seriesInstanceUID: string, imageBoxNumber: number, sopInstanceUidList: string[], loadstructureDisplay : boolean) {
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
                                self.loadSeries({ InstanceUID: result.data[0].StudyInstanceUI }, result.data[0], loadstructureDisplay
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
                                self.loadSeries({ InstanceUID: result.data[0].StudyInstanceUID }, result.data[0], loadstructureDisplay);
                            }
                        }
                    });
                    break;
            }
        }

        private loadSeries(study, series, loadstructureDisplay) {
            this._eventService.publish(EventNames.SeriesSelected, {
                study: study,
                series: series,
                remote: this._$scope.querySource.name == 'pacs',
                structureDisplay: loadstructureDisplay, 
                studyLoad: true,
                dentalSearchController: this
            });
        }

        public loadselectedStructureDisplay(data) {
            var self = this;

            //eventService.subscribe(EventNames.SelectedTabChanged, function (event, data) {
            //}.bind(this));



            var loadstructureDisplay: boolean = true;

            //this._dataCache['StudyInstanceUID'] = this._selectedStudy.InstanceUID;
            var studyLayout: Models.StudyLayout = null;
            //this._objectRetrieveService.GetStudyLayout(<any>(this._selectedStudy.InstanceUID)).then(function (result) {
                studyLayout = data;

                self._templateService.currentHangingProtocol = null;

                if (data == "") {

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


                // when you load the structured display, remove any previous series loaded on that tab, this value will become false after clearing the series.
                self._seriesManagerService.cleanupSeries = true;

                if (!angular.isDefined(studyLayout["Series"])) {
                    self.loadSeries(self._selectedStudy, self._$scope.gridOptionsSeries.rowData[0], loadstructureDisplay);

                }
                else {
                    studyLayout['studyInstanceUID'] = self._selectedStudy.InstanceUID;
                    $.each(studyLayout.Series, function (index: number, item: Models.SeriesInfo) {
                        var series = self._seriesManagerService.get_seriesInfo(item.SeriesInstanceUID);

                        if (studyLayout.Boxes[self.getImageBox(item.ImageBoxNumber, studyLayout.Boxes)]) {
                            self.queryForSeries(self, item.SeriesInstanceUID, item.ImageBoxNumber, studyLayout.Boxes[self.getImageBox(item.ImageBoxNumber, studyLayout.Boxes)].referencedSOPInstanceUID, loadstructureDisplay);
                        }
                    });

                    $.each(studyLayout.OtherStudies, function (index: number, study: Models.OtherStudies) {
                        $.each(study.Series, function (index: number, item: Models.SeriesInfo) {
                            var series = self._seriesManagerService.get_seriesInfo(item.SeriesInstanceUID);

                            if (studyLayout.Boxes[self.getImageBox(item.ImageBoxNumber, studyLayout.Boxes)]) {
                                self.queryForSeries(self, item.SeriesInstanceUID, item.ImageBoxNumber, studyLayout.Boxes[self.getImageBox(item.ImageBoxNumber, studyLayout.Boxes)].referencedSOPInstanceUID, loadstructureDisplay);
                            }
                        });
                    });
                }
            //});

            this._viewStudy = false;
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


        private waitForStructuredDisplayData(data, loadBest?: boolean) {
            var self = this;

            // if we are still loading the patient series, then keep trying until we are done loading (the flag will be false by then).
            if (self._loadingPatientSeries == true) {
                setTimeout(function () {
                    self.waitForStructuredDisplayData(data);
                }, 100);
            }
            else {
                var query: Models.HangingProtocolQuery = new Models.HangingProtocolQuery();

                this._loadingStructuredDisplay = true;
                this._localStructuredDisplay = new Array<Models.HangingProtocolQueryResult>();

                // show the structured display once we done loading them.
                 this.showStructuredDisplayMenu(data, loadBest);

                this._objectRetrieveService.GetPatientStructuredDisplay(data.data.ID).then(function (result) {
                    self._localStructuredDisplay = result.data;
                    self.set_structuredDisplay(result.data);
                    self._loadingStructuredDisplay = false;

                });
            }
        }


        private showStructuredDisplayMenu(data, loadBest?: boolean) {
            var self = this;
            if (this._loadingStructuredDisplay == true) {
                setTimeout(function () {
                    self.showStructuredDisplayMenu(data, loadBest);
                }, 100);
            }
            else {
                try
                {
                    if (this._localStructuredDisplay != null) {
                        if (this._localStructuredDisplay.length != 0) {
                            $('.patientContext').contextMenu({ x: data.event.pageX, y: data.event.pageY });
                        }
                    }
                }
                catch { }
                if (this._sdOpenWith.length > 0) {
                    $('.data-title').attr('data-menutitle', this._sdOpenWith);
                }
            }
        }
        private patientSelected(evt) {
            var selectedNodes: Array<any> = this._$scope.gridOptions.api.getSelectedNodes();
            var self = this;

            if (selectedNodes.length == 1 && selectedNodes[0].data != this._selectedPatient) {
                var queryOptions: Models.QueryOptions = new Models.QueryOptions();
                var maxSeriesResults: string = this._optionsService.get(OptionNames.MaxSeriesResults);
                
                queryOptions.PatientsOptions.PatientID = evt.node.data.ID;
                this._selectedPatient = evt.node.data;

                if (angular.isDefined(this._$scope.queryOptions.SeriesOptions.SeriesDateStart)) {
                    queryOptions.SeriesOptions.SeriesDateStart = this._$scope.queryOptions.SeriesOptions.SeriesDateStart;
                }

                if (angular.isDefined(this._$scope.queryOptions.SeriesOptions.SeriesDateEnd)) {
                    queryOptions.SeriesOptions.SeriesDateEnd = this._$scope.queryOptions.SeriesOptions.SeriesDateEnd;
                }

                if (angular.isDefined(this._$scope.queryOptions.SeriesOptions.SeriesDescription)) {
                    queryOptions.SeriesOptions.SeriesDescription = this._$scope.queryOptions.SeriesOptions.SeriesDescription;
                }

                // status is.... we are loading the patient series now.
                self._loadingPatientSeries = true;

                this._$scope.gridOptionsSeries.api.setRowData([]);    
                this._$scope.gridOptionsSeries.api.hideOverlay();           
                switch (this._$scope.querySource.name) {
                    case 'database':
                        this._queryArchiveService.FindSeries(queryOptions, maxSeriesResults).then(function (result) {
                            if (result.data["FaultType"]) {
                                if (result.data["Message"]) {
                                    self._$scope.gridOptionsSeries.api.hideOverlay();
                                    alert(result.data["Message"]);
                                }
                            }
                            else {
                                var index = 0;
                                var length = result.data.length;

                                var sortArray : any[] = [];

                                for (index = 0; index < length; index++) {
                                    sortArray[index] = result.data[index];
                                    sortArray[index].NumericalDate = Utils.getSortableDate(sortArray[index].Date);
                                }


                                var newest = 1;
                                var newestIndex = 0;
                                var sortIndex = 0;

                                for (index = 0; index < length; index++) {
                                    newest = 1;
                                    newestIndex = 0;
                                    sortIndex = 0;

                                    for (sortIndex = 0; sortIndex < sortArray.length; sortIndex++) {
                                        if (sortArray[sortIndex].NumericalDate > newest) {
                                            newest = sortArray[sortIndex].NumericalDate;
                                            newestIndex = sortIndex;
                                        }
                                    }

                                    result.data[index] = sortArray[newestIndex];

                                    sortArray.splice(newestIndex, 1);
                                   
                                }
                                self._dataService.set_Series(result.data);
                                self._$scope.gridOptionsSeries.api.setRowData(result.data);
                                if (result.data.length == 0) {
                                    self._$scope.gridOptionsSeries.suppressNoRowsOverlay = false;
                                    self._$scope.gridOptionsSeries.api.showNoRowsOverlay()
                                }
                            }
                            self._loadingPatientSeries = false;
                        });
                        break;
                    case 'pacs':
                        self._queryPacsService.FindSeries(this._$scope.querySource.pacs, self._queryPacsService.clientAETitle, queryOptions).then(function (result) {
                            if (result.data["FaultType"]) {
                                if (result.data["Message"]) {
                                    self._$scope.gridOptionsSeries.api.hideLoadingOverlay();
                                    alert(result.data["Message"]);
                                }
                            }
                            else {
                                self._dataService.set_Series(result.data);
                                self._$scope.gridOptionsSeries.api.setRowData(result.data);
                                if (result.data.length == 0) {
                                    self._$scope.gridOptionsSeries.suppressNoRowsOverlay = false;
                                    self._$scope.gridOptionsSeries.api.showNoRowsOverlay()
                                }
                            }

                            self._loadingPatientSeries = false;
                        });
                        break;
                }
            }
            
            this._selectedSeries = null;
            this._selectedStudy = evt.node.data;
        }

        private matchTemplateForSeries(data, selectedStudies: Array<any>) {
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
                        try {
                            if (!_template) {
                                if (Utils.executeScript(template.AutoMatching, json)) {
                                    console.log('template auto-match found');
                                    _template = template;
                                    return true;//break;
                                }
                            }
                        }
                        catch (e) {
                            console.log(e);
                        }
                        return false;//continue
                    });

                    //use template (if any) to view
                    this._eventService.publish(EventNames.SeriesSelected, {
                        study: selectedStudies[0].data,
                        series: data.node.data,
                        remote: this._$scope.querySource.name == 'pacs',
                        template: _template
                    });

                }.bind(this));

                //on error - default to no template - continue loading
                promise.error(function (e) {
                    console.log(e);

                    this._eventService.publish(EventNames.SeriesSelected, {
                        study: selectedStudies[0].data,
                        series: data.node.data,
                        remote: this._$scope.querySource.name == 'pacs'
                    });
                });

            }
            else {
                console.log('failed to read study/series id');

                //default to no template - continue loading
                this._eventService.publish(EventNames.SeriesSelected, {
                    study: selectedStudies[0].data,
                    series: data.node.data,
                    remote: this._$scope.querySource.name == 'pacs'
                });
            }
        }

        private seriesSelected(data) {
            this._seriesManagerService.currentStructuredDisplay = null;
            var selectedStudies: Array<any> = this._$scope.gridOptions.api.getSelectedNodes();
            this._templateService.currentStudyLayout = null;
            if (selectedStudies.length == 1) {
                var selectedSeries: Array < any > = this._$scope.gridOptionsSeries.api.getSelectedNodes();                             

                if (selectedSeries.length == 1) {
                    if (selectedSeries[0].data != this._selectedSeries) {
                        this._selectedSeries = data.node.data;
                        this._seriesManagerService.currentLoadingSeries = data.node.data;
                        this._seriesManagerService.currentPatientSeries = this._$scope.gridOptionsSeries.rowData;
                        if (this.isAnyTemplateAutoMatch()) {
                            this.matchTemplateForSeries(data, selectedStudies);
                        }
                        else {
                        this._eventService.publish(EventNames.SeriesSelected, {
                            study: selectedStudies[0].data,
                            series: data.node.data,
                            remote: this._$scope.querySource.name == 'pacs',
                            dentalSearchController: this
                        });
                        }
                    }
                    else if (selectedSeries[0].data == this._selectedSeries) {
                        var tab: Models.Tab = this._seriesManagerService.get_seriesTab(data.node.data.InstanceUID);

                        if (tab != null) {
                            this._tabService.select_tab(tab.id);
                        }
                        else {
                            this._seriesManagerService.currentLoadingSeries = data.node.data;
                            this._seriesManagerService.currentPatientSeries = this._$scope.gridOptionsSeries.rowData;
                            if (this.isAnyTemplateAutoMatch()) {
                                this.matchTemplateForSeries(data, selectedStudies);
                            }
                            else {
                            this._eventService.publish(EventNames.SeriesSelected, {
                                study: selectedStudies[0].data,
                                series: data.node.data,
                                remote: this._$scope.querySource.name == 'pacs',
                                dentalSearchController: this
                            });
                            }
                        }
                    }
                }
            }
        }

        private hpContextMenu(data): void {
            this._$scope.gridOptions.api.selectNode(data.node, false, true);

            //$('.patientContext').contextMenu({ x: data.event.pageX, y: data.event.pageY });
            //if (this._sdOpenWith.length > 0) {
            //    $('.data-title').attr('data-menutitle', this._sdOpenWith);
            //}

            this.patientSelected(data);
            this.waitForStructuredDisplayData(data);
        }


        private contextMenu(data) {
            //this._selectedSeries = data.data;
            //this._$scope.gridOptionsSeries.api.selectNode(data.node, false, true);
            //$('.seriesContext').contextMenu({ x: data.event.pageX, y: data.event.pageY });
            //if (this._openWith.length > 0) {
            //    $('.data-title').attr('data-menutitle', this._openWith);
            //}
        }
    }

}