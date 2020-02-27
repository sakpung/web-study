// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />
/// <reference path="../../Scripts/models/Tab.ts" />
/// <reference path="../../Scripts/Services/OptionsService.ts" />
/// <reference path="../../Scripts/Services/TabService.ts" />
/// <reference path="../../Scripts/externalCommand/ExternalCommandHandlerService.ts" />
/// <reference path="../../Scripts/externalCommand/AutoService.ts" />

module Controllers {
    export interface IMedicalWebViewerControllerScope extends ng.IScope {
        tabs: Array<Models.Tab>;
        activeTab: number;
        tabSelected: Function;
        tabManager: TabService;
        user: string;
        logout: Function;
        findTab: Function;
        deleteTab: Function;
        warning: any;
        timedout: any;
        idleWait: number;
        countdown: number;
        openAdminOverlay: Function;
        openAdminGlobal: Function;
        openAdminToolbar: Function;
        clearCachedObjects: Function;
        aboutDialog: Function;
        themeDialog: Function;
        openAdminCalibration: Function;
        openChangePassword: Function;
        openPermissionsManagement: Function;
        openRolePatientsAccessManagement();
        openUserPatientsAccessManagement();
        canCalibrateMonitor(): boolean;
        openRemotePacs();
        openRemoteWado();
        openTemplateEditor();
        canManageRemotePacs(): boolean;
        canDeleteCache(): boolean;
        canManagePermissions(): boolean;
        canManageAccessRights(): boolean;
        canShowTemplates(): boolean;
        isAdmin(): boolean;
        doUpload(files);
        canStore(): boolean;
    }

    export class MedicalWebViewerController {
        static $inject = ['$scope', 'eventService', 'authenticationService', 'optionsService', 
        'externalCommandHandlerService', 'tabService', 'dataService', '$modal', '$idle',
        'monitorCalibrationService', 'seriesManagerService', 'toolbarService', 'auditLogService',
            '$commangular', 'queryPacsService', '$window', 'hotkeys', 'sharedPropertiesService', 'cinePlayerService', '$timeout', '$templateCache', '$q', '$location', 'dataCache', 'objectRetrieveService', 'dialogs', 'autoService'];

        private _seriesManagerService: SeriesManagerService;
        private _toolbarService: ToolbarService;
        private _authenticationService: AuthenticationService;
        private _optionsService: OptionsService;
        private _tabService: TabService;
        private _commangular;
        private _dataService: DataService;
        private _hideOverlay: boolean; 
        private _cinePlayerService: CinePlayerService;             
        private _objectRetrieveService: ObjectRetrieveService;
        private _dialogs: any;
        private _eventService: EventService;

        constructor($scope: IMedicalWebViewerControllerScope, eventService: EventService, authenticationService: AuthenticationService, optionsService: OptionsService,
            externalCommandHandlerService: ExternalCommandHandlerService,
            tabService: TabService, dataService: DataService, $modal, $idle, monitorCalibrationService: MonitorCalibrationService, seriesManagerService: SeriesManagerService,
            toolbarService: ToolbarService, auditLogService: AuditLogService, $commangular, queryPacsService: QueryPacsService, $window: ng.IWindowService, hotkeys,
            sharedPropertiesService: SharedPropertiesService, cinePlayerService: CinePlayerService, $timeout: ng.ITimeoutService, $templateCache: ng.ITemplateCacheService, $q: ng.IQService, $location: ng.ILocationService, dataCache, objectRetrieveService: ObjectRetrieveService, dialogs, autoService: AutoService) {
            var tab: Models.Tab;
            var __this = this;
            var initViewTab = false;
            var dentalMode: boolean = optionsService.get(OptionNames.DentalMode);
            this._eventService = eventService;

            $templateCache.put("template/tabs/tabset.html",
                "\n" +
                "<div>\n" +
                "  <ul class=\"nav nav-{{type || 'tabs'}}\" ng-class=\"{'nav-stacked': vertical, 'nav-justified': justified}\" ng-transclude></ul>\n" +
                "  <div class=\"vbox boxItem tab-content\">\n" +
                "    <div class=\"vbox boxItem tab-pane\" \n" +
                "         ng-repeat=\"tab in tabs\" \n" +
                "         ng-class=\"{active: tab.active}\"\n" +
                "         tab-content-transclude=\"tab\">\n" +
                "    </div>\n" +
                "  </div>\n" +
                "</div>\n" +
                "");

            if (tabService.get_allTabs().length == 0) {
                if (!sharedPropertiesService.GetExternalControlMode()) {
                    if (!dentalMode) {
                        tab = tabService.add_tab(UUID.generate(), "Search", "views/SearchView.html", Controllers.SearchViewController);
                        tab.type = TabTypes.Search;
                    }
                    else {
                        tab = tabService.add_tab(UUID.generate(), "Search", "views/DentalSearchView.html", Controllers.DentalSearchViewController);
                        tab.type = TabTypes.Search;
                    }
                }


                if ($commangular != null) {
                    window.addEventListener('keydown', function (e) {
                        if (e.keyCode == 13) {
                            $commangular.dispatch("ToggleFullScreen");
                        }
                        //if (e.keyCode == 32) {
                        //    $commangular.dispatch("OnToggleCine");
                        //} 
                    }, false);
                }

                if (!sharedPropertiesService.GetExternalControlMode() && authenticationService.hasPermission(PermissionNames.CanDownloadImages) && optionsService.get(OptionNames.ShowPacsQuery)) {
                    var tab: Models.Tab = tabService.add_tab(UUID.generate(), "User Queue", "views/UserQueueView.html", Controllers.UserQueueController);

                    tab.type = TabTypes.UserQueue;
                }
            }

            externalCommandHandlerService.Initialize();
            autoService.Initialize();
            $scope.tabs = tabService.get_allTabs();
            $scope.user = authenticationService.user;
            $scope.countdown = optionsService.get(OptionNames.IdleWarningDuration);
            $scope.idleWait = optionsService.get(OptionNames.IdleWarningDuration);

            eventService.publish("ViewerTab\AddTabs", { tabs: $scope.tabs });

            $scope.$watch('activeTab', function (newValue: Models.Tab, oldValue: Models.Tab) {
                if (newValue != oldValue) {
                    if (newValue.type == TabTypes.Viewer) {
                        var controller = tabService.get_tabData(newValue.id, TabDataKeys.ViewController);
                        if (controller) {
                            var viewer:lt.Controls.Medical.MedicalViewer = controller.getViewer();
                            var cell = viewer.layout.get_selectedItem();

                            if (angular.isDefined(cell)) {
                                seriesManagerService.set_activeCell(cell.divID);
                            }

                            $timeout(function () {
                                viewer.onSizeChanged();                                
                            }, 500);
                        }                        
                    }
                    tabService.activeTab = tabService.get_allTabs().indexOf(newValue);
                    eventService.publish(EventNames.SelectedTabChanged, { previousTab: oldValue, currentTab: newValue });
                }
            }, true);

            $scope.tabSelected = function (index) {
                $scope.activeTab = index;
            }

            $scope.logout = function () {
                authenticationService.logout();
                externalCommandHandlerService.LogoutNotify("User Logout");
                autoService.LogoutNotify("User Logout");
            }

            $scope.findTab = function (id: string) {
                var foundTab: Models.Tab;

                $.each($scope.tabs, function (index, tab) {
                    if (tab.id == id) {
                        foundTab = tab;
                        return false;
                    }
                });
                return foundTab;
            }
            

            eventService.subscribe(EventNames.DeleteTab, function (event, data) {
                $scope.deleteTab(data.args.id);
            });

            $scope.deleteTab = function (id, event) {
                
                var tab = tabService.find_tab(id);
                var anycell: lt.Controls.Medical.Cell = seriesManagerService.get_anyCell();

                if (tab && tab.type == TabTypes.Viewer) {
                    var seriesList: Array<string> = seriesManagerService.get_allSeries();

                    for (var i = 0; i < seriesList.length; i++) {
                        var seriesTab: Models.Tab = seriesManagerService.get_seriesTab(seriesList[i]);

                        if (seriesTab == tab) {
                            seriesManagerService.set_seriesTab(seriesList[i], null);
                            seriesManagerService.dispose_seriesCell(seriesList[i]);

                            eventService.publish(EventNames.DeleteSeries, { seriesInstanceUID: seriesList[i] });
                        }
                    }    
                    
                }

                var patientId : string = tabService.get_tabData(tab.id, TabDataKeys.PatientId);
                tabService.set_tabData(tab.id, TabDataKeys.PatientId, "");

                var activiatedTab;

                activiatedTab = tabService.findTabByKey(TabDataKeys.PatientId, patientId);
                if (activiatedTab == null)
                    activiatedTab = tabService.find_tabsByType(TabTypes.Search);

                $timeout(function () {
                    if (activiatedTab != null) {
                        if (angular.isDefined(activiatedTab) && activiatedTab.length > 0) {
                            activiatedTab[0].active = true;
                        }
                    }
                    tabService.delete_tab(id);
                }, 200, true);
            }

            function closeModals() {
                if ($scope.warning) {
                    $scope.warning.close();
                    $scope.warning = null;
                }

                if ($scope.timedout) {
                    $scope.timedout.close();
                    $scope.timedout = null;
                }
            }

            $scope.$on('$idleStart', function () {
                closeModals();

                $scope.warning = $modal.open({
                    templateUrl: 'warning-dialog.html',
                    windowClass: 'modal-danger'
                });
            });

            $scope.$on('$idleEnd', function () {
                closeModals();
            });

            $scope.$on('$idleTimeout', function () {
                closeModals();
                $idle.unwatch();
                authenticationService.logout();
                // externalCommandHandlerService.LogoutNotify("Idle Timeout");
            });

            $scope.$on('$keepaliveResponse', function (event, data, status) {
            });

            $scope.openAdminOverlay = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/OverlaySettings.html',
                    controller: OverlaySettingsController,
                    backdrop: 'static'
                });
            };

            $scope.openAdminGlobal = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/GlobalOptions.html',
                    controller: GlobalOptionsController,
                    backdrop: 'static'
                });

                modalInstance.result.then(function (saved: boolean) {
                    if (saved) {
                        sessionStorage.setItem('AuthCode', authenticationService.authenticationCode);
                        $window.location.reload();
                    }
                });
            };

            $scope.openAdminToolbar = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/ToolbarSettings.html',
                    controller: AdminToolbarSettingsController,
                    backdrop: 'static'
                });

                modalInstance.result.then(function (saved: boolean) {
                    if (saved) {
                        sessionStorage.setItem('AuthCode', authenticationService.authenticationCode);
                        $window.location.reload();
                    }
                });
            };

            function imageExists(url, callback) {
                var img = new Image();
                img.onload = function () { callback(true); };
                img.onerror = function () { callback(false); };
                img.src = url;
            }

            $scope.aboutDialog = function () {
                // if (optionsService.get(OptionNames.UseMedicoreLogo)) {

                var imageUrl = 'images/mipacsAboutDark.jpg';
                var currentTheme = window.localStorage.getItem("leadmedicalwebviewertheme");
                switch (currentTheme) {
                    case "dark":
                        imageUrl = 'images/mipacsAboutDark.jpg';
                        break;
                    case "light":
                        imageUrl = 'images/mipacsAboutLight.jpg';
                        break;
                }
                imageExists(imageUrl, function (exists) {
                    if (exists) {
                        var opts = {
                            size: 'lg'
                        };
                        dialogs.notify("About", "<center><img src=" + imageUrl + " width=600 height=400  align=\"middle\"></img></center> <center><br><b>MiPACS HTML5 Web Viewer</b></br>  -  Version 3.0.0.5<br/><br/>Copyright (c) 1991-2019 LEAD Technologies, Inc.<\center>", opts);
                    }
                    else {
                        dialogs.notify("About", "<b>Medical Web Viewer</b>  -  Version 20.0.0.5<br/><br/>Copyright (c) 1991-2019 LEAD Technologies, Inc.");
                    }
                });
            };


           $scope.themeDialog = function () {



              //launch dialog
              var modalInstance = $modal.open({
                 templateUrl: 'views/dialogs/UISettings.html',
                 controller: UISettingsController,
                 backdrop: 'static'
              });



           };

            $scope.clearCachedObjects = function () {

                var promise = objectRetrieveService.ClearCache();
                promise.then(function (result) {
                    if (angular.isDefined(result.data) && angular.isDefined(result.data.Message)) {
                        dialogs.error("Cache", result.data.Message);
                    }
                    else {                        
                        dialogs.notify("Cache", "Cached objects were cleared.");
                    }
                },
                    function (error) {
                        dialogs.error("Cache", error);
                    });
            };

            $scope.openAdminCalibration = function () {
                monitorCalibrationService.GetCalibrations().success(function (calibrations) {
                    var modalInstance = $modal.open({
                        templateUrl: 'views/dialogs/MonitorCalibration.html',
                        controller: MonitorCalibrationController,
                        backdrop: 'static',
                        resolve: {
                            calibrations: function () {
                                return calibrations;
                            }
                        }
                    });
                }).error(function (error, status) {
                    });
            }

           $scope.openRemotePacs = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/RemotePacs.html',
                    controller: RemotePacsController,
                    backdrop: 'static'
                });

                if (optionsService.get(OptionNames.ShowPacsQuery)) {
                    modalInstance.result.then(function (saved: boolean) {
                        if (saved) {
                            sessionStorage.setItem('AuthCode', authenticationService.authenticationCode);
                            $window.location.reload();
                        }
                    });
                }
            }

           $scope.openRemoteWado = function () {
               var modalInstance = $modal.open({
                   templateUrl: 'views/dialogs/RemoteWado.html',
                   controller: RemoteWadoController,
                   backdrop: 'static'
               });

               if (optionsService.get(OptionNames.ShowPacsQuery)) {
                   modalInstance.result.then(function (saved: boolean) {
                       if (saved) {
                           sessionStorage.setItem('AuthCode', authenticationService.authenticationCode);
                           $window.location.reload();
                       }
                   });
               }
           }

            $scope.openTemplateEditor = function () {
                $location.path('/templateeditor');
            };

           $scope.openChangePassword = function () {
              var modalInstance = $modal.open({
                 templateUrl: 'views/dialogs/PasswordChange.html',
                 controller: PermissionsManagementController,
                 backdrop: 'static'
              });

              modalInstance.result.then(
                 function (result) {
                    var tabId: string = __this.get_activeTabId();
                    __this._authenticationService.refreshPermissions().then(function (result) {
                       var canSaveHangingProtocol: boolean = __this._authenticationService.hasPermission(PermissionNames.CanSaveHangingProtocol);
                       toolbarService.enable('HangingProtocol' + tabId, function () {
                          return canSaveHangingProtocol;
                       });
                    });
                 }
              );
           };

            $scope.openPermissionsManagement = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/PermissionsManagement.html',
                    controller: PermissionsManagementController,
                    backdrop: 'static'                 
                });

                modalInstance.result.then(
                    function (result) {
                        var tabId: string = __this.get_activeTabId();
                        __this._authenticationService.refreshPermissions().then(function (result) {
                            var canSaveHangingProtocol: boolean = __this._authenticationService.hasPermission(PermissionNames.CanSaveHangingProtocol);
                            toolbarService.enable('HangingProtocol' + tabId, function () {
                                return canSaveHangingProtocol;
                            });
                        });
                    }
                );
            };

            function removeArray(arr,item?) {
                var what, a = arguments, L = a.length, ax;
                while (L > 1 && arr.length) {
                    what = a[--L];
                    while ((ax = arr.indexOf(what)) !== -1) {
                        arr.splice(ax, 1);
                    }
                }
                return arr;
            }

            $scope.openRolePatientsAccessManagement = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/RolePatientsAccess.html',
                    controller: RolePatientsAccessController,
                    backdrop: 'static',
                    resolve: {
                        roles: function () {
                            var deferred = $q.defer();

                            authenticationService.getRolesNames().success(function (roles) {
                                if (angular.isArray(roles)) {
                                    //
                                    // Administrative users always have access to patients
                                    //
                                    removeArray(roles, "Administrators");
                                }
                                deferred.resolve(roles);
                            }).error(function () {
                                    deferred.resolve(new Array<any>());
                                });
                            return deferred.promise;
                        }
                    }
                });
            }

            $scope.openUserPatientsAccessManagement = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/UserPatientsAccess.html',
                    controller: UserPatientsAccessController,
                    backdrop: 'static',
                    resolve: {
                        users: function () {
                            var deferred = $q.defer();

                            authenticationService.getAllUsers().success(function (users) {
                               var rusers = [];

                               if (users && users.length > 0) {
                                   for (var u of users) {
                                        if (u.UserName) {
                                            rusers.push(u.UserName);
                                        }
                                        else {
                                            rusers.push(u);
                                        }
                                    }
                                }

                               deferred.resolve(rusers);
                            }).error(function () {
                                deferred.resolve(new Array<any>());
                            });
                            return deferred.promise;
                        }                                                    
                    }
                });
            }

            $scope.doUpload = function (files) {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/UploadFiles.html',
                    controller: Controllers.UploadFileController,
                    backdrop: 'static'
                });
            }

            $scope.canStore = function () {                
                return authenticationService.hasPermission(PermissionNames.CanStore);
            }

            eventService.subscribe(EventNames.Logout, function (event, data) {
                auditLogService.log_logOut(<string>data.args.authenticationCode);
                externalCommandHandlerService.LogoutNotify("User Logout");
                autoService.LogoutNotify("User Logout");
            });

            eventService.subscribe(EventNames.ImageDataReady, $.proxy(this.onImageDataReady, this));
            eventService.subscribe(EventNames.CurrentDesignerChanged, $.proxy(this.onCurrentDesignerChanged, this));
            eventService.subscribe(EventNames.AnnotationsLoaded, $.proxy(this.onAnnotationsLoaded, this));
            eventService.subscribe(EventNames.LoadingSeriesFrames, $.proxy(this.onLoadingSeriesFrames, this));
            eventService.subscribe(EventNames.StackChanged, $.proxy(this.onStackChanged, this));
            eventService.subscribe(EventNames.NewSubCellSelected, $.proxy(this.onNewSubCellSelected, this));

            hotkeys.bindTo($scope)
                .add({
                    combo: 'del',
                    description: "Delete Cell",
                    callback: $.proxy(this.onDelete, this)
                });




            function resetSeriesArrangement(viewer, boxes: Array<Models.ImageBox>) {
                var cellLength = Math.min(boxes.length, viewer.layout.items.count);
                var length = viewer.get_emptyDivs().items.count;

                for (var index = 0; index < length; index++) {
                    viewer.get_emptyDivs().get_items().get_item(index).set_position(index + cellLength);
                }
            }

            function rearrangeSeries(viewer, structuredDisplay, boxes: Array<Models.ImageBox>) {
                var length = viewer.emptyDivs.items.count;

                viewer.layout.beginUpdate();
                for (var index = 0; index < length; index++) {
                    var boxNumber: number = index + 1;
                    var series = $.grep(structuredDisplay.Series, function (series: Models.SeriesInfo) {
                        return series.ImageBoxNumber == boxNumber;
                    });

                    if (series.length == 0) {
                        var item: lt.Controls.Medical.EmptyCell = viewer.emptyDivs.items.item(index);
                        var box: Models.ImageBox = boxes[index];
                        var rect: lt.LeadRectD = Utils.createLeadRect(box.Position.leftTop.x, box.Position.leftTop.y,
                            box.Position.rightBottom.x, box.Position.rightBottom.y);

                        item.bounds = rect;
                    }
                }

                viewer.layout.endUpdate();
            }


            eventService.subscribe(EventNames.StructuredDisplayUpdated, function (event, data) {
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
                var currentController = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
                if (currentController != null) {
                    var viewer: lt.Controls.Medical.MedicalViewer = currentController.getViewer();

                    (<any>viewer).SDInstances = data.args.InstanceUIDs;

                    if (viewer.exploded)
                        viewer.explode(<lt.Controls.Medical.Cell>viewer.explodedCell, false);

                    viewer.layout.beginUpdate();
                    var length = viewer.layout.items.count;
                    var cell: lt.Controls.Medical.Cell;
                    for (var index = 0; index < length; index++) {
                        cell = viewer.layout.items.get_item(index);
                        cell.visibility = data.args.InstanceUIDs[cell.seriesInstanceUID];
                    }
                    viewer.layout.endUpdate();

                }
            });

            eventService.subscribe(EventNames.StructuredDisplaySelected, function (event, data) {

                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
                var currentController = tabService.get_tabData(tab.id, TabDataKeys.ViewController);

                // this is filled for when you move from the search tab to the viewer tab.
                // now that we are here at the viewer tab, we don't need no more.
                currentController._viewerApi.studyLayout = null;
                if (currentController != null) {
                    var viewer: lt.Controls.Medical.MedicalViewer = currentController.getViewer();

                    //viewer.layout.beginUpdate();
                    //viewer.cellsArrangement = lt.Controls.Medical.CellsArrangement.grid;
                    //viewer.gridLayout.rows = 2;
                    //viewer.gridLayout.columns = 2;
                    //viewer.layout.endUpdate();

                    var structuredDisplay = data.args.structureDisplay;


                    if (structuredDisplay.Boxes) {
                        structuredDisplay.Boxes.sort(function (a: Models.ImageBox, b: Models.ImageBox) {
                            return a.ImageBoxNumber - b.ImageBoxNumber;
                        });
                    }


                    // delete all previous cells and start over.
                    __this.ResetViewer(seriesManagerService, eventService, tabService);

                    viewer.cellsArrangement = lt.Controls.Medical.CellsArrangement.random;
                    viewer.totalCells = structuredDisplay.Boxes.length;
                    resetSeriesArrangement(viewer, structuredDisplay.Boxes);
                    rearrangeSeries(viewer, structuredDisplay, structuredDisplay.Boxes);


                    var occupiedCellIndex = -1;

                    var index = 0;
                    var length = structuredDisplay.Boxes.length;

                    for (index = 0; index < length; index++) {
                        //if (item.referencedSOPInstanceUID.length == 0) {
                        var item: Models.ImageBox = structuredDisplay.Boxes[index];

                        var cell: lt.Controls.Medical.EmptyCell = viewer.emptyDivs.items.get_item(index); //new lt.Controls.Medical.EmptyCell(viewer.emptyDivs, viewer, UUID.generate(), 1, 1);

                        if (cell == null) {
                            if (occupiedCellIndex == -1)
                                occupiedCellIndex = index;

                            cell = viewer.layout.items.get_item(index - occupiedCellIndex);
                        }

                        var rect: lt.LeadRectD = Utils.createLeadRect(item.Position.leftTop.x, item.Position.leftTop.y,
                            item.Position.rightBottom.x, item.Position.rightBottom.y);

                        cell.position = item.ImageBoxNumber;
                        cell.bounds = rect;
                        //}
                    }
                }
            });

            eventService.subscribe(EventNames.SeriesSelected, function (event, data) {
                if (!data.args.remote) {
                    var structureDisplay: boolean = data.args.structureDisplay;
                    $timeout(function () {
                    var viewUrl: string = dentalMode ? "views/DentalViewer.html" : "views/Viewer.html";
                    var viewController: any = dentalMode ? <any>Controllers.DentalViewerController : <any>Controllers.ViewerController;
                    var tabController;
                    var tabPatientId;
                    var tabInfo: any; 
                    var currentController;                  
                    var forCompare: boolean = data.args.forCompare;
                    var series = data.args.series;
                    var style = data.args.style;

                    if (forCompare) {
                        viewUrl = "views/CompareView.html";
                        viewController = <any>Controllers.CompareViewController;
                        series = data.args.series[0];
                    }

                    __this._hideOverlay = false;

                    tabInfo = __this.get_patientTab(series, data.args.series, viewUrl, viewController, forCompare);


                    if (style && style === 'medicor') {
                        optionsService.set(OptionNames.UseMedicoreLogo, true);
                    }
                    else {
                        optionsService.set(OptionNames.UseMedicoreLogo, false);
                    }

                    if (!data.args.studyLoad) {
                        currentController = tabService.get_tabData(tabInfo.tab.id, TabDataKeys.ViewController);

                        if (currentController != null) {
                            // if the the current list has a different id, then free the series list row and populate it with the new patient serie
                            if (currentController._listController != null) {
                                if (currentController._listController._list.parentNode.id != series.Patient.ID) {

                                    currentController._listController.refreshContent(objectRetrieveService, seriesManagerService, series.Patient.ID);
                                }
                            }
                        }

                        if (forCompare) {
                            __this.log_OpenPatient(tabInfo.tab, tabService, auditLogService, series.Patient);
                            tabService.select_tab(tabInfo.tab.id);
                            tabInfo.tab.canDelete = true;
                            if (lt.LTHelper.device == lt.LTDevice.mobile) {
                                tabInfo.tab.title = 'Compare';
                            }
                            else {
                                tabInfo.tab.title = 'Compare [' + $.tmplParse("<%=Patient.Name.replace(/\^/g, ' ')%> - <%=Patient.ID%>", series) + ']';
                            }

                            tabController = tabService.get_tabData(tabInfo.tab.id, TabDataKeys.ViewController);

                            return;
                        }


                        if (currentController != null) {
                            var viewer: lt.Controls.Medical.MedicalViewer = currentController.getViewer();

                            if (data.args.resetLayout) {
                                viewer.layout.beginUpdate();
                                viewer.cellsArrangement = lt.Controls.Medical.CellsArrangement.grid;
                                viewer.gridLayout.rows = 1;
                                viewer.gridLayout.columns = 1;

                                // rest all the visibitly status.

                                for (var instance in (<any>viewer).SDInstances) {
                                    (<any>viewer).SDInstances[instance] = true;
                                }


                                viewer.layout.endUpdate();
                            }

                            if (viewer != null) {
                                if (viewer.exploded) {
                                    viewer.explode(<lt.Controls.Medical.Cell>viewer.explodedCell, false);
                                    window.setTimeout(function () {
                                        viewer.onSizeChanged();
                                    }, 250);
                                }
                            }
                            }
                        }
                        else {
                            tabInfo.tab.showStudyTimeLine = true;
                        }
                        __this.log_OpenPatient(tabInfo.tab, tabService, auditLogService, series.Patient);
                        tabService.select_tab(tabInfo.tab.id);
                        if (tabInfo.setOverlay) {
                            if (__this._hideOverlay) {
                                tabService.set_tabData(tabInfo.tab.id, TabDataKeys.TagToggle, false);
                            }
                        }

                        if (tabInfo.setLinked && dentalMode) {
                            tabService.set_tabData(tabInfo.tab.id, TabDataKeys.Linked, false);
                        }

                        if (dataCache["StudyInstanceUID"]) {
                            tabService.set_tabData(tabInfo.tab.id, TabDataKeys.LaunchingStudy, dataCache["StudyInstanceUID"]);
                            delete dataCache["StudyInstanceUID"];
                        }

                        seriesManagerService.set_seriesTab(series.InstanceUID, tabInfo.tab);
                        seriesManagerService.set_seriesInfo(series.InstanceUID, series);
                        seriesManagerService.set_activeCell(data.args.id);

                        tabInfo.tab.canDelete = true;
                        if (lt.LTHelper.device == lt.LTDevice.mobile) {
                            tabInfo.tab.title = 'Viewer';
                        }
                        else {
                            tabInfo.tab.title = 'Viewer [' + $.tmplParse("<%=Patient.Name.replace(/\^/g, ' ')%> - <%=Patient.ID%>", series) + ']';
                        }
                        tabController = tabService.get_tabData(tabInfo.tab.id, TabDataKeys.ViewController);

                        auditLogService.log_showSeries(series);
                        if (tabController != null) {
                            if (angular.isFunction(tabController.getListController)) {
                                var listControl = tabController.getListController();
                                if (listControl != null) {
                                    listControl.loadSeriesList(series.Patient.ID, series.InstanceUID, data.args.fromList);
                                }
                            }
                        }

                        //$timeout(function () {
                        $scope.$apply();
                        //});

                        // If from structured display,
                        var displaySetNumberTemp: number = data.args.displaySetNumber;
                        if (displaySetNumberTemp == null) {
                            displaySetNumberTemp = series.ImageBoxNumber;
                        }



                        eventService.publish((structureDisplay ? EventNames.LoadStructureDisplay : EventNames.LoadSeries) + tabInfo.tab.id, {
                            study: data.args.study,
                            tabid: tabInfo.tab.id,
                            series: series,
                            template: data.args.template,
                            view: data.args.view,
                            displaySetNumber: displaySetNumberTemp
                        });
                    });
                }
                else {
                    var queueTabs: Array<Models.Tab> = tabService.find_tabsByType(TabTypes.UserQueue);
                    var queueTab: Models.Tab = null;

                    if (queueTabs.length == 0) {
                        queueTab = tabService.add_tab(UUID.generate(), "User Queue", 'views/UserQueueView.html', Controllers.UserQueueController, TabTypes.UserQueue);
                    }
                    else
                        queueTab = queueTabs[0];

                    tabService.select_tab(queueTab.id);                    
                    setTimeout(function () { $scope.$apply(); });
                    data.args.series =
                    eventService.publish(EventNames.DownloadSeries, {
                        studyInfo: data.args.study,
                        pacsClientInfo: queryPacsService.server,
                        clientAe: queryPacsService.clientAETitle,
                        seriesInfo: data.args.series,
                    });
                }
            });

            eventService.subscribe(EventNames.ActiveSeriesChanged, function (event, data) {
                var cell = seriesManagerService.get_activeCell();

                __this.checkWindowLevelForSelectedViewer(cell, authenticationService);
                __this.updateMultiFrame(cell);

                if (!(cell instanceof lt.Controls.Medical.Cell3D))
                    __this.onAnnotationsLoaded(event, data);


                var tabId: string = __this.get_activeTabId();
                var tab: Models.Tab = __this.get_activeTab();

                eventService.publish(EventNames.OpenStudyTimeLine, { show: tab.showStudyTimeLine /*seriesManagerService.get_ShowStudyTimeLine()*/ });
            });

            function get_annotationVisiblity(tabid: string): boolean {
                var visibility: boolean = tabService.get_tabData(tabid, TabDataKeys.AnnotationVisiblity);

                if (visibility == undefined)
                    visibility = true;
                return visibility;
            }

            eventService.subscribe(EventNames.NewCellsAdded, function (event, data) {
                var cells: Array<lt.Controls.Medical.Cell> = data.args.cells;
                var length = cells.length;  
                var tabIndex: number = tabService.activeTab; 
                var tab: Models.Tab = tabIndex != -1 ? tabService.get_allTabs()[tabIndex] : null;             

                for (var index: number = 0; index < length; index++) {
                    var cell: any = cells[index];
                    if (cell == null)
                        continue;

                    if (!cell.get_automation)
                        continue;

                    var automation = cell.get_automation();
                    if (automation == null)
                        continue;
                    var viewer: lt.Controls.Medical.AutomationImageViewer = cell.get_imageViewer();

                    automation.add_activeContainerChanged(function (sender, e) {
                        if (automation.activeContainer != null) {
                            var tab: Models.Tab = seriesManagerService.get_seriesTab(cell.get_seriesInstanceUID());

                            if (tab != null) {
                                var visibility: boolean = get_annotationVisiblity(tab.id);

                                automation.activeContainer.set_isVisible(visibility);
                                automation.get_automationControl().automationInvalidate(lt.LeadRectD.empty);
                            }
                        }
                    });                                       

                    viewer.add_itemChanged(function (sender, e: lt.Controls.ImageViewerItemChangedEventArgs) {
                        if (e.get_reason() == lt.Controls.ImageViewerItemChangedReason.url) {
                            __this.checkWindowLevelForSelectedViewer(cell, authenticationService);
                        }
                    });
                }
            });

            $scope.canCalibrateMonitor = function (): boolean {
                return optionsService.get(OptionNames.DentalMode) && authenticationService.hasPermission(PermissionNames.CanCalibrateMonitor);
            }

            $scope.canManageRemotePacs = function (): boolean {
                return authenticationService.hasPermission(PermissionNames.CanManageRemotePACS);
            }

            $scope.canDeleteCache = function (): boolean {
                return authenticationService.hasPermission(PermissionNames.CanDeleteCache);
            }

            $scope.canManagePermissions = function (): boolean {
                return authenticationService.hasPermission(PermissionNames.CanManageRoles) || authenticationService.hasPermission(PermissionNames.CanManageUsers);
            }

            $scope.canManageAccessRights = function (): boolean {
                return authenticationService.hasPermission(PermissionNames.CanManageAccessRight);
            }

            $scope.isAdmin = function (): boolean {
                return authenticationService.permissions.isAdmin;
            }

            $scope.canShowTemplates = function (): boolean {
                //return authenticationService.hasPermission(PermissionNames.CanEditTemplates) || authenticationService.hasPermission(PermissionNames.CanViewTemplates);
                return authenticationService.hasPermission(PermissionNames.CanEditTemplates);
            }

            this._seriesManagerService = seriesManagerService;
            this._toolbarService = toolbarService;
            this._authenticationService = authenticationService;
            this._optionsService = optionsService;
            this._tabService = tabService;
            this._commangular = $commangular;
            this._dataService = dataService;     
            this._cinePlayerService = cinePlayerService;       
            this._objectRetrieveService = objectRetrieveService;
            this._dialogs = dialogs;
        }

        private ResetViewer(seriesManagerService: SeriesManagerService, eventService: EventService, tabService : TabService) {

            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

            var seriesList = seriesManagerService.get_allSeries();
            for (var i = 0; i < seriesList.length; i++) {
                var seriesTab = seriesManagerService.get_seriesTab(seriesList[i]);
                if (seriesTab == tab) {
                    seriesManagerService.remove_seriesCell(seriesList[i]);
                    //eventService.publish(EventNames.DeleteSeries, { seriesInstanceUID: seriesList[i] });
                }
            }
        }




        
        private get_patientTab(series: any, seriesArray : any, viewUrl, viewController, forCompare) {
            var singlePatientMode: boolean = this._optionsService.get(OptionNames.SinglePatientMode);
            var tab: Models.Tab;
            var setOverlay = false;
            var setLinked = false;

            if (forCompare) {
                //tab = this.getPatientTab(series.Patient.ID, this._tabService);

                tab = this._tabService.add_tab(UUID.generate(), "Compare", viewUrl, viewController, TabTypes.Compare);
                this._tabService.set_tabData(tab.id, TabDataKeys.CompareInstances, seriesArray);
                this._tabService.set_tabData(tab.id, TabDataKeys.TagToggle, false);
                setOverlay = true;
                setLinked = true;
            }
            else
            if (!singlePatientMode) {
                tab = this.getPatientTab(series.Patient.ID, this._tabService);

                if (!tab) {
                    tab = this._tabService.add_tab(UUID.generate(), "View", viewUrl, viewController, TabTypes.Viewer);                    
                    this._hideOverlay = this._optionsService.get(OptionNames.HideOverlays);
                    setOverlay = true;
                    setLinked = true;
                }
            }
            else {
                var viewerTabs: Array<Models.Tab> = this._tabService.find_tabsByType(TabTypes.Viewer);

                if (viewerTabs.length == 0) {
                    tab = this._tabService.add_tab(UUID.generate(), "View", viewUrl, viewController, TabTypes.Viewer);
                    this._hideOverlay = this._optionsService.get(OptionNames.HideOverlays);
                    setOverlay = true;
                    setLinked = true;
                }
                else {
                    tab = viewerTabs[0];
                }
            }
            return { tab: tab, setOverlay: setOverlay, setLinked: setLinked };
        }

        private log_OpenPatient(tab: Models.Tab, tabService: TabService, auditLogService: AuditLogService, patient) {
            var patientId = tabService.get_tabData(tab.id, TabDataKeys.PatientId);
            var log = true;

            if (patientId) {
                if (patientId != patient.ID) {
                    log = true;
                }
                else
                    log = false;
            }

            if (log) {
                auditLogService.log_openPatient(patient);
            }
            tabService.set_tabData(tab.id, TabDataKeys.PatientId, patient.ID);
        }

        private getPatientTab(patientid: string, tabService: TabService): Models.Tab {
            var seriesList: Array<string> = this._seriesManagerService.get_allSeries();

            for (var i = 0; i < seriesList.length; i++) {
                var series = this._seriesManagerService.get_seriesInfo(seriesList[i]);

                if (series && (patientid == series.Patient.ID)) {
                    var tab: Models.Tab = this._seriesManagerService.get_seriesTab(seriesList[i]);

                    return tab;
                }
            }
            return null;
        }

        private onImageDataReady(event, data) {
            var cell = this._seriesManagerService.get_seriesCellById(data.args.id);
            var tabId: string = this.get_activeTabId(); 
            var __this = this;
            var interactiveMode: number = CommandManager.LastCommand.Action;


            this.checkWindowLevelForSelectedViewer(cell, this._authenticationService);

            if (interactiveMode == MedicalViewerAction.WindowLevel && this._toolbarService.isEnabled("WindowLevel" + tabId)) {
                //this._commangular.dispatch('WindowLevelInteractiveMode', { buttonId: 'WindowLevel' + tabId });
            }
            {
                if (interactiveMode != -1) {
                    var commandId: string = '';

                    if (currentIcon[tabId])
                        commandId = currentIcon[tabId].id;
                    else if (interactiveMode == MedicalViewerAction.WindowLevel) {
                        commandId = 'WindowLevel' + tabId;
                    }
                    else if (interactiveMode == MedicalViewerAction.Offset) {
                        commandId = 'Pan' + tabId;
                    }
                    else if (interactiveMode == MedicalViewerAction.Scale) {
                        commandId = 'Zoom' + tabId;
                    }
                    else if (interactiveMode == MedicalViewerAction.Offset) {
                        commandId = 'Magnify' + tabId;
                    }
                    else if (interactiveMode == MedicalViewerAction.Stack) {
                        commandId = 'Stack' + tabId;
                    }
                    else if (interactiveMode == MedicalViewerAction.ProbeTool) {
                        commandId = 'ProbeTool' + tabId;
                    }

                    
                    if (commandId != '') {
                        SetCurrentInteractiveMode(this._toolbarService, this._tabService, interactiveMode, commandId);
                    }
                }
            }            
        }

        private EnableButtons(buttons: string[], enable: boolean, tabId) {

            var index = 0;
            var length = buttons.length;



            for (index = 0; index < length; index++) {
                if (enable)
                    this._toolbarService.enable(buttons[index] + tabId);
                else
                    this._toolbarService.disable(buttons[index] + tabId);
            }
        }


        private EnableButtonsFor3D(is3D: boolean, tabId) {

            this.EnableButtons(['LayoutCompose', 'MergeCells', 'HangingProtocol', 'DeleteStudyStructuredDisplay', 'Magnify', 'Stack', 'ProbeTool', 'Spyglass', 'OneToOne', 'ClearAllAnnotations', 'ClearAll', 'SaveAnn', 'TrueSizeDisplay', 'Orientation', 'HorizontalAlignment', 'VerticalAlignment', 'ScrollingType', 'SortSeries', 'Endo', 'Perio', 'Dentin', 'Annotations', 'Measurements', 'AnnotationShowHide', 'DeleteAnnotations', 'ClearAnnotations', 'SaveAnn', 'LoadAnn', 'LinkImages', 'Cursor3D', 'ReferenceLine', 'ShowFirstLast', 'SeriesLayouts', 'SynchronizeSeries', 'ToggleCine', 'WaveformBasicAudio', 'LinkCells', 'ShutterObject', 'LineProfile', 'SpyglassGroup', 'FitImage', 'EdgeEnhancment'],
                !is3D,
                tabId);
        }

        private Enable3DButtons(enable: boolean, tabId) {

            this.EnableButtons(['Rotate3D', 'DisplayOrientation', 'Settings3D'], enable, tabId);
        }

        private checkWindowLevelForSelectedViewer(cell: lt.Controls.Medical.Cell, authenticationService: AuthenticationService) {
            var index: number;
            var seriesInstanceUID: string;
            var tabId: string = this.get_activeTabId();            

            if (cell==null || !cell.get_selected())
                return;

            var isCell3D: boolean = cell instanceof lt.Controls.Medical.Cell3D;
            var isCellMPR: boolean = cell instanceof lt.Controls.Medical.MPRCell;

            if (CommandManager.Last3DCommand.ButtonID == "") {
                CommandManager.Last3DCommand.ButtonID = "Rotate3D" + tabId;
            }

            if (CommandManager.LastCommand.ButtonID == "") {
                CommandManager.LastCommand.ButtonID = "WindowLevel" + tabId;
            }


            var status: lt.Controls.Medical.CanDo3DStatus = lt.Controls.Medical.Object3DEngine.canDo3D(cell);

            this.EnableButtons(['VolumeType', 'DentalPanoramic'], (cell instanceof lt.Controls.Medical.Cell3D) || (status == lt.Controls.Medical.CanDo3DStatus.ok), tabId);


            seriesInstanceUID = cell.get_seriesInstanceUID();
            index = cell.currentOffset;

            this.EnableButtonsFor3D(isCell3D, tabId);

            this.Enable3DButtons((isCell3D), tabId);



            this.EnableButtons(['EdgeEnhancment'], !isCell3D && !isCellMPR, tabId);

            if (DicomHelper.supportWindowLevel(cell, index)) {
                if (this._seriesManagerService.isDataReady(cell, index)) {

                    this._toolbarService.enable("WindowLevel" + tabId);
                    this._toolbarService.enable("WindowLevelCustom" + tabId);
                    this._toolbarService.enable("Invert" + tabId);
                    this._toolbarService.disable("BrightnessContrast" + tabId);
                    this._toolbarService.disable("StretchHistogram" + tabId);
                    this._toolbarService.disable("HSL" + tabId);  
                }
                else {
                    this._toolbarService.enable("WindowLevel" + tabId);
                    this._toolbarService.enable("WindowLevelCustom" + tabId);
                    this._toolbarService.disable("Invert" + tabId);
                    this._toolbarService.disable("BrightnessContrast" + tabId);
                    this._toolbarService.disable("StretchHistogram" + tabId);
                    this._toolbarService.disable("HSL" + tabId);
                }
            }
            else {
                var enable = true;

                this._toolbarService.enable("WindowLevel" + tabId);
                this._toolbarService.enable("WindowLevelCustom" + tabId);
                this._toolbarService.enable(["Invert" + tabId, "BrightnessContrast" + tabId, "StretchHistogram" + tabId, "HSL" + tabId],  function () {
                    return enable;});                
            }

            var tab: Models.Tab = this.get_activeTab();
            if (isCell3D) {
                PressButton(this._toolbarService, tab, CommandManager.Last3DCommand.ButtonID);
            }
            else {
                PressButton(this._toolbarService, tab, CommandManager.LastCommand.ButtonID);
            }


            if (isCell3D) {
                var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>(<any>cell);
                this.EnableButtons(['WindowLevel', 'WindowLevelCustom'], cell3D.volumeType != lt.Controls.Medical.VolumeType.SSD, tabId);
            }

            if ((authenticationService) && (authenticationService.hasPermission)) {
                var canSaveStructuredDisplay = authenticationService.hasPermission(PermissionNames.CanSaveStructuredDisplay);

                var canStore = authenticationService.hasPermission(PermissionNames.CanStore);
                if (!canSaveStructuredDisplay) {
                    this.EnableButtons(['LayoutCompose'], false, tabId);
                }
            }


        }

        private onCurrentDesignerChanged(event, data) {
            var __this = this;
            var tabId: string = this.get_activeTabId();
            
            //this._toolbarService.enable("DeleteAnn" + tabId, function () {
            //    return data.args.automation.canDeleteObjects && data.args.automation.currentEditObject;
            //});

            this._toolbarService.enable("CalibrateRuler" + tabId, function () {
                return data.args.selectedObject instanceof lt.Annotations.Engine.AnnPolyRulerObject;
            });

            //this._toolbarService.enable("ShutterObject" + tabId, function () {
            //    return __this.enableShutterObject();
            //});
        }

        private enableShutterObject(): boolean {
            var cell = this._seriesManagerService.get_activeCell();            

            if (cell) {
                var frame:lt.Controls.Medical.Frame = this._seriesManagerService.get_activeCellFrame();
                var tab = this._tabService.get_allTabs()[this._tabService.activeTab];
                var controller = this._tabService.get_tabData(tab.id, TabDataKeys.ViewController);
                var medicalViewer = controller.getViewer();
                var automation: lt.Annotations.Automation.AnnAutomation;
                var editObject: lt.Annotations.Engine.AnnObject;

                if (medicalViewer == null)
                    return false;

                automation = cell.get_automation();
                editObject = automation.get_currentEditObject();

                if (!editObject)
                    return false;

                return lt.Controls.Medical.ShutterObject.isValid(editObject) && automation.selectObjects.length == 1;                
            }        
        }

        private enableCrossHair(subcell: lt.Controls.Medical.SubCell, frame: lt.Controls.Medical.Frame) {
            var cell: lt.Controls.Medical.Cell = subcell.parentCell;
            var mprcell: boolean = cell instanceof lt.Controls.Medical.MPRCell;
            var tabId: string = this.get_activeTabId();

            this._toolbarService.enable("CrossHair" + tabId, function () {
                return mprcell || cell.derivatives.count > 0;
            });
        }

        private onAnnotationsLoaded(event, data) {
            var annotations: Array<any> = this._seriesManagerService.get_annotationIDs(data.args.seriesInstanceUID, data.args.id);
            var tabId: string = this.get_activeTabId();
            var dentalMode = this._optionsService.get(OptionNames.DentalMode);
            var __this = this;

            if (annotations && annotations.length > 0 && this._authenticationService.hasPermission(PermissionNames.CanViewAnnotations)) {                

                this._toolbarService.enable("LoadAnn" + tabId);
                if (dentalMode) {
                    this._toolbarService.hilightBorder("LoadAnn" + tabId, "1px", "#ff0000");
                }
            }
            else {
                this._toolbarService.disable("LoadAnn" + tabId);
                if (dentalMode) {
                    this._toolbarService.unhilightBorder("LoadAnn" + tabId);
                }
            }

            this._toolbarService.enable("SaveAnn" + tabId, function () {
                return __this._authenticationService.hasPermission(PermissionNames.CanStoreAnnotations);
                });

            this._toolbarService.disable("DeleteAnn" + tabId);
            this._toolbarService.disable("CalibrateRuler" + tabId);


            this._toolbarService.enable("SecondaryCapture" + tabId, function () {
                return __this._authenticationService.hasPermission(PermissionNames.CanStore);
            });

            this._toolbarService.enable("LayoutCompose" + tabId, function () {
                return __this._authenticationService.hasPermission(PermissionNames.CanStore);
            });


        }

        public get_activeTabId() {
            if (this._tabService.activeTab != -1) {
                var tab: Models.Tab = this._tabService.get_allTabs()[this._tabService.activeTab];

                if (angular.isDefined(tab))
                    return tab.id;
            }
            return '';
        }

        public get_activeTab() {
            if (this._tabService.activeTab != -1) {
                var tab: Models.Tab = this._tabService.get_allTabs()[this._tabService.activeTab];

                return tab;
            }

            return null;
        }

        private onLoadingSeriesFrames(event, data) {
            var cell = this._seriesManagerService.get_seriesCellById(data.args.id);
            var tab: Models.Tab = this._tabService.get_allTabs()[this._tabService.activeTab];
            var tagToggle = this._tabService.get_tabData(tab.id, TabDataKeys.TagToggle);
            var controller = this._tabService.get_tabData(tab.id, TabDataKeys.ViewController);
            var viewer: lt.Controls.Medical.MedicalViewer = controller.getViewer();

            
            this.updateMultiFrame(cell);
            this.checkWindowLevelForSelectedViewer(cell, this._authenticationService);

            if (!tagToggle) {
                cell.set_overlayTextVisible(tagToggle);
            }

            if (viewer.showReferenceLine || viewer.showFirstAndLastReferenceLine) {
                var showRef = false;
                var showFirstLast = false;

                if (viewer.showReferenceLine) {
                    viewer.showReferenceLine = false;
                    showRef = true;
                }
                else {
                    viewer.showFirstAndLastReferenceLine = false;
                    showFirstLast = true;
                }

                if (showRef || showFirstLast) {
                    viewer.invalidate();
                    setTimeout(function () {                        
                        if(showRef)
                            viewer.showReferenceLine = true;
                        if (showFirstLast)
                            viewer.showFirstAndLastReferenceLine = true;
                        if (showRef || showFirstLast) {
                            viewer.refreshReferenceLine();
                        }
                    }, 350);
                }
            }
        }

        private updateMultiFrame(cell:lt.Controls.Medical.Cell) {            
            var maxStack: number = this._seriesManagerService.get_maxAllowedStackIndex(cell);
            var enableMultiFrame: boolean = (maxStack > 1);
            var tabId: string = this.get_activeTabId();

            this._toolbarService.enable(['CinePlayer' + tabId, 'Stack' + tabId], function () {
                return enableMultiFrame;
            });
        }

        private onStackChanged(event, data) {
            if (!this._cinePlayerService.isPlaying) {
                var cell = this._seriesManagerService.get_activeCell();

                if (cell) {
                    this.checkWindowLevelForSelectedViewer(cell, this._authenticationService);
                }
            }
        }

        private onNewSubCellSelected(event, data) {
            var frame: lt.Controls.Medical.Frame = data.args.frame;
            var subCell: lt.Controls.Medical.SubCell = data.args.subCell;
            var cell: lt.Controls.Medical.Cell = subCell.get_parentCell();
            var index = cell.frames.indexOf(frame);
            var tabId: string = this.get_activeTabId();

            if (DicomHelper.supportWindowLevel(cell, index) && frame.isDataReady) {
                this._toolbarService.enable("WindowLevel" + tabId);
                this._toolbarService.enable("WindowLevelCustom" + tabId);
                this._toolbarService.enable("Invert" + tabId);
                this._toolbarService.disable("BrightnessContrast" + tabId);
                this._toolbarService.disable("StretchHistogram" + tabId);
                this._toolbarService.disable("HSL" + tabId);
            }
            else {
                var enable = frame == null ? false : frame.mrtiInfo != null;

                this._toolbarService.enable("WindowLevel" + tabId);
                this._toolbarService.enable("WindowLevelCustom" + tabId);               
                this._toolbarService.enable(["Invert" + tabId, "BrightnessContrast" + tabId, "StretchHistogram" + tabId, "HSL" + tabId], function () {
                    return enable;
                });  
                this._toolbarService.enable("Invert" + tabId);
            }
            this.enableCrossHair(data.args.subCell, data.args.frame);            
        }

        private onDelete(event, key) {
            var cell: lt.Controls.Medical.Cell = this._seriesManagerService.get_activeCell();
            if (cell == null)
                return;
            var automation: lt.Annotations.Automation.AnnAutomation = cell.get_automation(); 
            var tabId: string = this.get_activeTabId();

            if (automation == null) {
                this._commangular.dispatch('DeleteCell');
                return;
            }

                
            var designer = (<any>automation.currentDesigner);
            
            if (designer != null && designer.operationStatus)
                automation.cancel();
            else {
                if (automation.canDeleteObjects && automation.currentEditObject) {
                    this._commangular.dispatch('OnDeleteAnnotation');
                }
                else {
                    this._commangular.dispatch('DeleteCell');
                }
            }
        }
    }
}