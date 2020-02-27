// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IViewerControllerScope extends ng.IScope {
        toolbars: Array<Models.Toolbar>;
        seriesList: Array<MedicalViewerSeries>;
        query: Models.QueryOptions;
        searchInfo: any;
        layoutConfig: any;
        viewerId: string;
        overflowId: string;
        viewerConfig: MedicalViewerConfig;
        tabId: string;
        viewerapi: any;
        layoutApi: any;
        postion: number;
        numberOfFrames: number;
        currentPosition: number;
        hideTimeline: boolean;        
        retrieveUrl: string;
        timelineApi: any;
        replaceCell: any;
        appendCell: any;
        seriesDropped: any;

        positionChanged(position: number);
        previousImage();
        nextImage();
        ondelete();
        stackChanged(sender, e);
    }


    export class ViewerController {
        static $inject = ['$scope', 'eventService', 'toolbarService', '$modal', 'tabService', 'optionsService', 'dataService',
            'seriesManagerService', 'safeApply', 'app.config', 'hotkeys', '$timeout', '$commangular', 'auditLogService',
            'objectRetrieveService', 'dicomLoaderService', 'templateService'];

        private _scope: IViewerControllerScope;
        private _seriesManagerService: SeriesManagerService;
        private _dataService: DataService;
        private _tabService: TabService;
        private _timeoutService: ng.ITimeoutService;
        private _eventService: EventService;
        private _auditLogService: AuditLogService;
        private _objectRetrieveService: ObjectRetrieveService;
        private _overflowManager: OverflowManager;
        private _viewerApi: Directives.MedicalViewerApi;
        private _toolbarService: ToolbarService;

        private _isComposing: boolean;

        public get isComposing(): boolean {
            return this._isComposing;
        }

        public set isComposing(value: boolean) {
            this._isComposing = value;
        }

        constructor($scope: IViewerControllerScope, eventService: EventService, toolbarService: ToolbarService, $modal, tabService: TabService,
            optionsService: OptionsService, dataService: DataService, seriesManagerService: SeriesManagerService, safeApply, config, hotkeys, $timeout: ng.ITimeoutService, $commangular, auditLogService: AuditLogService, objectRetrieveService: ObjectRetrieveService, dicomLoaderService: DicomLoaderService, templateService: TemplateService) {
            var spacingSize = Utils.get_spacingSize();
            var singleSeries: boolean = optionsService.get(OptionNames.SingleSeriesMode);
            var rows: number = optionsService.get(OptionNames.DefaultSeriesRowCount);
            var columns: number = optionsService.get(OptionNames.DefaultSeriesColumnCount);
            var overflowSize = optionsService.get(OptionNames.SeriesThumbnailWidth) * 3;
            var self = this;

            this._scope = $scope;
            this._seriesManagerService = seriesManagerService;
            this._dataService = dataService;
            this._tabService = tabService;
            this._timeoutService = $timeout;
            this._eventService = eventService;
            this._auditLogService = auditLogService;
            this._objectRetrieveService = objectRetrieveService;
            this._toolbarService = toolbarService;

            $scope.query = new Models.QueryOptions();
            $scope.retrieveUrl = config.urls.serviceUrl + config.urls.objectRetrieveLocalServiceName; 
            $scope.timelineApi = {}
            
            if (overflowSize > 150)
                overflowSize = 150;
            
            $scope.layoutConfig = {                
                applyDemoStyles: true,
                scrollToBookmarkOnLoad: false,
                spacing_closed: spacingSize,
                spacing_open: spacingSize,
                livePaneResizing: false,                            
                north__size: lt.LTHelper.device == lt.LTDevice.mobile ? "25" : "auto",
                north__resizable: false,
                north__initHidden: false, 
                north__showOverflowOnHover: true,
                south__resizable: false,
                south__initHidden: false,                
                south__size: 100,                
                south__resizerToggle: false,
                south__spacing_closed: 0,
                south__spacing_open: 0,
                east__initHidden: true, 
                east__size: overflowSize,
                east__maxSize: overflowSize,
                east__minSize: overflowSize,
                east__resizable: false,
                onopen: this.onOpenPane.bind(this)
            } 

            $scope.toolbars = toolbarService.getToolbars();
            $scope.tabId = '';
            $scope.viewerId = UUID.generate();
            $scope.postion = 15;
            $scope.numberOfFrames = 0;
            $scope.currentPosition = 0;
            $scope.hideTimeline = true;  
            $scope.overflowId = UUID.generate();           

            $scope.viewerConfig = new MedicalViewerConfig();
            $scope.viewerConfig.rows = singleSeries?1:rows;
            $scope.viewerConfig.columns = singleSeries?1:columns;
            $scope.viewerConfig.splitterSize = Utils.get_splitterSize();                
            $scope.viewerConfig.OnApiReady = function (viewerApi: Directives.MedicalViewerApi) {
                self._viewerApi = viewerApi;
                self._toolbarService.enable("DeleteStudyStructuredDisplay" + self._tabService.selectedTab.id, function () {
                    return viewerApi.hasLayout;
                });
            };
            $scope.viewerConfig.OnSelectionChanged = this.selectionChanged.bind(this);
            $scope.viewerConfig.studyLayout = templateService.currentStudyLayout;
            $scope.viewerConfig.hangingProtocol = templateService.currentHangingProtocol;

            templateService.currentHangingProtocol = null;

            $scope.viewerConfig.customLayout = optionsService.get(OptionNames.CustomStudyLayout);

            $scope.viewerapi = {};
            $scope.layoutApi = {};
            $scope.seriesList = new Array<MedicalViewerSeries>();

            var deregister = $scope.$watch('tabId', function (newValue, oldValue) {   
                var unsubscribe;

                tabService.set_tabData($scope.tabId, TabDataKeys.ViewController, self);
                tabService.set_tabData($scope.tabId, TabDataKeys.Linked, true);
                deregister();  

                unsubscribe = eventService.subscribe(EventNames.ToolbarCreated, function (event, data) {

                    var linked = optionsService.get(OptionNames.LinkImages);

                    toolbarService.updateClass('LinkImages' + $scope.tabId, 'Linked', 'UnLinked', function () { return linked; });

                    unsubscribe();
                    if (angular.isDefined($scope.layoutApi.refresh)) {
                        setTimeout(function () {
                            $scope.layoutApi.openPane('north');
                            $scope.layoutApi.refresh();
                        }, 900);
                    }
                });  
                
                function updateGridLayoutSize(viewer: lt.Controls.Medical.MedicalViewer, cellCount: number) {
                    if (viewer == null)
                        return;
                    if (viewer.gridLayout.rows * viewer.gridLayout.columns < cellCount) {
                        var sq = Math.sqrt(cellCount);

                        if (viewer.cellsArrangement == lt.Controls.Medical.CellsArrangement.grid) {
                            viewer.layout.beginUpdate();
                            viewer.gridLayout.rows = Math.floor(sq + 0.1);
                            viewer.gridLayout.columns = Math.ceil(cellCount / viewer.gridLayout.rows);
                            viewer.layout.endUpdate();
                        }
                    }
                }

                eventService.subscribe(EventNames.LoadSeries + $scope.tabId, function (event, data) {
                    var tab = seriesManagerService.get_seriesTab(data.args.series.InstanceUID);

                    if (tab != null && tab.id == $scope.tabId) {
                        var series: MedicalViewerSeries = new MedicalViewerSeries(data.args.series.InstanceUID, data.args.series.Patient.ID);

                        // series.sopInstanceUIDS: null or empty if all instances in the series should be loaded
                        //                       : contains a list of SOPInstanceUids
                        series.sopInstanceUIDS = data.args.series.SopInstanceUIDs; //new Array<string>(2);


                        series.template = data.args.template;
                        series.dislaySetNumber = data.args.displaySetNumber;
                        if (data.args != null)
                            series.view = data.args.view;
                        (<any>series).mrtiCell = data.args.series.mrtiCell;
                        if (self._overflowManager != null) {
                            self._overflowManager.clear();
                        }

                        if (singleSeries) {
                            $scope.seriesList.length = 0;
                        }
                        else {
                            var s = data.args.series;
                            var result = $.grep($scope.seriesList, function (e, index) {
                                return s.Patient.ID != e.patientID;
                            });

                            if (result.length != 0) {
                                $scope.seriesList.length = 0;
                            }
                        }
                        if (!angular.isDefined(series.dislaySetNumber)) {
                        objectRetrieveService.GetSeriesStacks(data.args.series.InstanceUID).then(function (result) {
                            var stacks:Array<any> = result.data;

                            series.link = optionsService.get(OptionNames.LinkImages);

                            if (stacks.length > 1)
                                series.sopInstanceUIDS = stacks[0].SopInstanceUIDs;

                            tab.itemCount += (stacks.length != 0) ? stacks.length : 1;

                            var cellCount = tab.itemCount;

                            if (!cellCount)
                                cellCount = 0;

                            if ($scope.viewerapi != null) {
                                var viewer: lt.Controls.Medical.MedicalViewer = $scope.viewerapi.getMedicalViewer();
                                updateGridLayoutSize(viewer, cellCount);
                            }

                            $scope.seriesList.push(series);

                            if (stacks.length > 1 && !singleSeries) {                                
                                for (var i = 1; i < stacks.length; i++) {
                                    var stackSeries: MedicalViewerSeries;                                    


                                    stackSeries = angular.copy(series);

                                    //Add the parent display number
                                    if (data.args != null)
                                        stackSeries.view = data.args.view;

                                    stackSeries.id = UUID.genV4().toString();
                                    stackSeries.sopInstanceUIDS = stacks[i].SopInstanceUIDs;
                                    $scope.seriesList.push(stackSeries);
                                }                                
                            }                            
                        }.bind(this));                        
                    }
                        else {

                            if ($scope.viewerapi != null) {
                                if ($scope.viewerapi.getMedicalViewer != null) {
                                    var viewer: lt.Controls.Medical.MedicalViewer = $scope.viewerapi.getMedicalViewer();
                                    tab.itemCount++;
                                    updateGridLayoutSize(viewer, tab.itemCount);
                                }
                            }

                            $scope.seriesList.push(series);
                        }
                    }
                    if ($scope.layoutApi && $scope.layoutApi.closePane) {
                        $scope.layoutApi.closePane('east');
                    }
                });
            });

            $scope.replaceCell = $.proxy(this.replaceCell, this);
            $scope.appendCell = $.proxy(this.appendCell, this);
            $scope.seriesDropped = $.proxy(this.seriesDropped, this);                       

            eventService.subscribe(EventNames.LoadingSeriesFrames, function (event, data) { 
                 var tab = seriesManagerService.get_seriesTab(data.args.seriesInstanceUID);

                if (tab != null && tab.id == $scope.tabId) {
                    self.initializeSlider($scope, seriesManagerService, data.args.seriesInstanceUID, data.args.id);
                    self.refreshTimeline(data.args.seriesInstanceUID);
                }
            }); 

            eventService.subscribe(EventNames.ActiveSeriesChanged, function (event, data) {
                var tab = seriesManagerService.get_seriesTab(data.args.seriesInstanceUID);
                var overflowInstances: Array<any> = seriesManagerService.get_seriesOverflow(data.args.seriesInstanceUID);
                var cell = seriesManagerService.get_seriesCellById(data.args.id);

                if (tab != null && tab.id == $scope.tabId) {
                    self.initializeSlider($scope, seriesManagerService, data.args.seriesInstanceUID, data.args.id);
                    self.refreshTimeline(data.args.seriesInstanceUID);
                }

                if (self._overflowManager) {
                    self._overflowManager.clear();
                    if (overflowInstances.length > 0 && self._overflowManager != null) {
                        self._overflowManager.addInstances(overflowInstances);
                    }
                }
            });  

            eventService.subscribe(EventNames.OpenStudyTimeLine, function (event, data) {

                var showStudyTimeLine = optionsService.get(OptionNames.ShowStudyTimeLine);

                if (data.args.show || showStudyTimeLine) {
                    self.showTimeLine();

                    setTimeout(function () {
                        $scope.layoutApi.openPane('north');
                        $scope.layoutApi.refresh();
                    }, 900);

                }
                else {

                    setTimeout(function () {
                        $scope.layoutApi.closePane('south');
                        $scope.layoutApi.refresh();
                    }, 900);

                }
            }); 


            eventService.subscribe(EventNames.InstanceOverflow, function (event, data) {
                var tab = seriesManagerService.get_seriesTab(data.args.instance.SeriesInstanceUID);

                if (tab != null && tab.id == $scope.tabId) {
                    $scope.layoutApi.openPane('east');                    
                    if (self._overflowManager == null) {
                        self._overflowManager = new OverflowManager("#" + $scope.overflowId, dicomLoaderService.get_newLoader(), { api: self._scope.layoutApi, direction: 'east' }, false);
                    }

                    if (angular.isDefined(data.args.clear) && data.args.clear) {
                        self._overflowManager.clear();
                    }

                    self._overflowManager.add(data.args);
                    self._seriesManagerService.add_seriesOverflow(data.args);
                }                
            }); 

            eventService.subscribe(EventNames.InstanceOverflowClear, function (event, data) {
                var tab = seriesManagerService.get_seriesTab(data.args.seriesInstanceUID);

                if (tab != null && tab.id == $scope.tabId) {
                    if (self._overflowManager != null) {
                        self._overflowManager.clear();
                    }             
                }
            }); 
            
            eventService.subscribe(EventNames.InstanceOverflowClose, function (event, data) {
                var tab = seriesManagerService.get_seriesTab(data.args.seriesInstanceUID);

                if (tab != null && tab.id == $scope.tabId) {
                    $scope.layoutApi.closePane('east'); 
                }
            });   

            $scope.positionChanged = function (position: number) {
                var cell:lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

                cell.currentOffset = position;
            }

            $scope.previousImage = function () {
                var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
                var current = cell.currentOffset;

                if (current != 0 && current >=1) {
                    cell.currentOffset = current - 1;
                    $scope.currentPosition = current-1;
                }                
            }

            $scope.nextImage = function () {
                var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
                var max = seriesManagerService.get_maxAllowedStackIndex(cell);
                var current = cell.currentOffset;

                if (current != -1 && ((current+1) < max)) {
                    cell.currentOffset = current + 1;
                    $scope.currentPosition = current + 2;
                }
            } 

            $scope.ondelete = function () {
                $commangular.dispatch('DeleteCell');
            }

            $scope.stackChanged = function (sender, e) {
                var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
                if (cell) {
                    var current = cell.currentOffset;

                    safeApply($scope, function () {
                        $scope.currentPosition = current + 1;
                    });
                }
            }

                hotkeys.bindTo($scope)
                .add({
                    combo: ['+', 'down'],
                    description: 'Next Image',
                    callback: $scope.nextImage
                })
                .add({
                    combo: ['-', 'up'],
                    description: 'Previous Image',
                    callback: $scope.previousImage
                })
                .add({
                    combo: 'left',
                    description: 'Align Left',
                    callback: function () {
                        var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

                    }
                })
                .add({
                    combo: 'right',
                    description: 'Align Right',
                    callback: function () {
                        var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

                    }
                })
                .add({
                    combo: 'top',
                    description: 'Align Top',
                    callback: function () {
                        var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

                    }
                })
                .add({
                    combo: 'bottom',
                    description: 'Align Bottom',
                    callback: function () {
                        var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

                    }
                });;
        }

        public selectionChanged(count: number) {
            if (this.isComposing) {
                var self = this;

                this._toolbarService.enable('MergeCells' + this._scope.tabId, function () {
                    return self._viewerApi.canMerge && (count > 1);
                });                                                                
            }
        }

        public refreshTimeline(seriesInstanceUID: string) {
            if (this._scope.timelineApi.refresh) {
                var series = this._seriesManagerService.get_seriesInfo(seriesInstanceUID);
                var state = this._scope.layoutApi.get_state('south');

                if (series == null) {
                    series = this._dataService.get_Series(seriesInstanceUID);
                }

                if (state.isVisible) {
                    this._scope.timelineApi.refresh(series.Patient.ID, series.StudyInstanceUID, seriesInstanceUID);
                }
            }
        }
        
        public getViewer() {
            if (!this._scope.viewerapi.getMedicalViewer)
                return null;
            return this._scope.viewerapi.getMedicalViewer();
        }

        public getOverflowManager() {
            return this._overflowManager;
        } 

        public refreshLayout() {
            this._scope.layoutApi.refresh();
        }

        public initializeSlider(scope: IViewerControllerScope, seriesManagerService: SeriesManagerService, seriesInstanceUID: string, id:string) {
            var tab: Models.Tab = seriesManagerService.get_seriesTab(seriesInstanceUID);

            if (tab && tab.id == scope.tabId) {
                var cell = seriesManagerService.get_seriesCellById(id);

                if (cell) {
                    scope.numberOfFrames = seriesManagerService.get_maxAllowedStackIndex(cell);
                }
            }
        } 

        public toggleView(panel: string, toggle : boolean, show : boolean) {
            switch (panel) {
                case 'south':
                    var seriesInstanceUID = this._seriesManagerService.activeSeriesInstanceUID;

                    if (seriesInstanceUID && seriesInstanceUID.length > 0) {
                    var series = this._seriesManagerService.get_seriesInfo(seriesInstanceUID);

                        if (series != null) {
                    var __this = this;

                    this._timeoutService(function () {
                        __this._scope.hideTimeline = toggle ? !__this._scope.hideTimeline : !show;
                        __this._scope.$apply();
                                __this._scope.timelineApi.toggle(series.StudyInstanceUID, series.Patient.ID, __this._scope.hideTimeline);
                    });
                        }
                    }
                    break;
            }
        }

        public showTimeLine() {
            if (this._scope.hideTimeline) {
                this.toggleView('south', false, true);
            }
        }

        public isTimeLineShowing() {
            return !this._scope.hideTimeline;
        }

        public hideTimeLine() {
            if (!this._scope.hideTimeline) {
                var seriesInstanceUID = this._seriesManagerService.activeSeriesInstanceUID;
                var series = this._seriesManagerService.get_seriesInfo(seriesInstanceUID);

                var __this = this;

                this._timeoutService(function () {
                    __this._scope.hideTimeline = !__this._scope.hideTimeline;
                    __this._scope.$apply();
                    __this._scope.timelineApi.toggle(series.StudyInstanceUID, series.Patient.ID, __this._scope.hideTimeline);
                });
            }
        }

        public mergeSelectedCells() {
            if (this.isComposing) {
                this._viewerApi.mergeSelectedCells();
            }
        }

        public hasLayout():boolean {
            return this._viewerApi.hasLayout;
        }

        public getStudyLayout() {
            return this._viewerApi.studyLayout;
        }

        public clearLayout() {
            this._viewerApi.clearLayout();
        }

        public setStudyLayout(layout: Models.StudyLayout) {
            this._viewerApi.studyLayout = layout;
        }

        public replaceCell(seriesInstanceUID: string) {
            var viewer:lt.Controls.Medical.MedicalViewer = this.getViewer();
            var cell:any = viewer.layout.get_selectedItem();
            var item, emptyItems;
            var position, rowPosition;
            var colPosition, bounds = null;
            var length: number;
            var series = this._dataService.get_Series(seriesInstanceUID);
            var newSeries: MedicalViewerSeries = new MedicalViewerSeries(seriesInstanceUID, series.Patient.ID);
            var tab: Models.Tab = this._tabService.find_tab(this._scope.tabId);

            if (viewer.exploded) {
                viewer.explode(<lt.Controls.Medical.Cell>viewer.explodedCell, false);
            }

            if (cell != null) {
                if (seriesInstanceUID == cell.get_seriesInstanceUID()) {
                    return;
                }

                position = cell.get_position();
                rowPosition = cell.get_rowPosition();
                colPosition = cell.get_columnsPosition();
                bounds = cell.get_bounds();
            }

            item = viewer.get_emptyDivs().get_selectedItem();
            if (item != null) {
                position = item.get_position();
                rowPosition = item.get_rowPosition();
                colPosition = item.get_columnsPosition();
                bounds = item.get_bounds();
            }

            emptyItems = viewer.get_emptyDivs().get_items();
            length = emptyItems.get_count();            
            for (var index = 0; index < length; index++) {
                var cellDiv: HTMLDivElement;

                item = emptyItems.get_item(index);
                cellDiv = <HTMLDivElement>document.getElementById(item.get_divID());

                if (<any>cellDiv == this) {
                    position = item.get_position();
                    rowPosition = item.get_rowPosition();
                    colPosition = item.get_columnsPosition();
                    bounds = item.get_bounds();

                    item.dispose();
                    break;
                }
            }

            if (bounds == null)
                return;
                        
            this._seriesManagerService.set_seriesTab(seriesInstanceUID, tab);
            this._objectRetrieveService.GetSeriesStacks(newSeries.seriesInstanceUID).then(function (result) {
                var stacks: Array<any> = result.data;
                var frame: lt.Controls.Medical.Frame = this._seriesManagerService.get_activeCellFrame();

                if (stacks.length > 1)
                    newSeries.sopInstanceUIDS = stacks[0].SopInstanceUIDs;

                this._scope.viewerapi.replaceSeries(cell.get_seriesInstanceUID(), (<any>frame).Instance.SOPInstanceUID, newSeries, position, rowPosition, colPosition, bounds);

                if (stacks.length > 1) {
                    for (var i = 1; i < stacks.length; i++) {
                        var stackSeries: MedicalViewerSeries;

                        stackSeries = angular.copy(newSeries);
                        stackSeries.id = UUID.genV4().toString();
                        stackSeries.sopInstanceUIDS = stacks[i].SopInstanceUIDs;
                        this._scope.seriesList.push(stackSeries);
                    }
                    newSeries.sopInstanceUIDS = stacks[0].SopInstanceUIDs;
                }
            }.bind(this));            
        }

        public appendCell(seriesInstanceUID: string) {
            var __this = this;
            var series = this._dataService.get_Series(seriesInstanceUID);
            var newSeries: MedicalViewerSeries = new MedicalViewerSeries(seriesInstanceUID, series.Patient.ID);
            var tab: Models.Tab = this._tabService.find_tab(this._scope.tabId);
            var addCell = this._eventService.subscribe(EventNames.NewCellsAdded, function (event, data) {
                if (data.args.cells && data.args.cells.length == 1) {
                    var cell: lt.Controls.Medical.Cell = data.args.cells[0];

                    if (cell.get_seriesInstanceUID() == seriesInstanceUID) {
                        __this._seriesManagerService.set_seriesInfo(seriesInstanceUID, series);
                    }
                }
                addCell();
            });
            
            this._seriesManagerService.set_seriesTab(seriesInstanceUID, tab);            
            this._objectRetrieveService.GetSeriesStacks(newSeries.seriesInstanceUID).then(function (result) {
                var stacks: Array<any> = result.data;

                if (stacks.length > 1)
                    newSeries.sopInstanceUIDS = stacks[0].SopInstanceUIDs;

                this._scope.seriesList.push(newSeries);

                if (stacks.length > 1) {
                    for (var i = 1; i < stacks.length; i++) {
                        var stackSeries: MedicalViewerSeries;

                        stackSeries = angular.copy(newSeries);
                        stackSeries.id = UUID.genV4().toString();
                        stackSeries.sopInstanceUIDS = stacks[i].SopInstanceUIDs;
                        this._scope.seriesList.push(stackSeries);
                    }
                    newSeries.sopInstanceUIDS = stacks[0].SopInstanceUIDs;
                }
            }.bind(this));
        } 

        public seriesDropped(viewer, oldSeriesInstanceUID:string, seriesInstanceUID: string, position: number, rowPosition: number, colPosition: number, bounds) { 
            var series = this._dataService.get_Series(seriesInstanceUID);
            var newSeries: MedicalViewerSeries = new MedicalViewerSeries(seriesInstanceUID, series.Patient.ID);
            var tab: Models.Tab = this._tabService.find_tab(this._scope.tabId);

            this._auditLogService.log_showSeries(series);
            this._seriesManagerService.set_seriesTab(seriesInstanceUID, tab);
            this._seriesManagerService.set_seriesInfo(seriesInstanceUID, series);            
            this._objectRetrieveService.GetSeriesStacks(newSeries.seriesInstanceUID).then(function (result) {
                var stacks: Array<any> = result.data;

                if (stacks.length > 1)
                    newSeries.sopInstanceUIDS = stacks[0].SopInstanceUIDs;

                this._scope.viewerapi.replaceSeries(oldSeriesInstanceUID, '', newSeries, position, rowPosition, colPosition, bounds); 
                
                if (stacks.length > 1) {
                    for (var i = 1; i < stacks.length; i++) {
                        var stackSeries: MedicalViewerSeries;

                        stackSeries = angular.copy(newSeries);
                        stackSeries.id = UUID.genV4().toString();
                        stackSeries.sopInstanceUIDS = stacks[i].SopInstanceUIDs;
                        this._scope.seriesList.push(stackSeries);
                    }
                    newSeries.sopInstanceUIDS = stacks[0].SopInstanceUIDs;
                }                
            }.bind(this));            
        }     

        private onOpenPane(pane: string, item, state) {
            //if (pane == 'east' && this._overflowManager != null) {
                //var seriesInstanceUID = this._seriesManagerService.activeSeriesInstanceUID;
                //var overflowInstances: Array<any> = this._seriesManagerService.get_seriesOverflow(seriesInstanceUID);

                //if (overflowInstances.length > 0) {
                //    this._overflowManager.clear();
                //    this._overflowManager.addInstances(overflowInstances);
                //}                
            //}
        }      
    }
}
