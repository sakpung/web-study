// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IOverlaySettingsControllerScope extends ng.IScope {                
        position: any;
        overlays: OverlayTags;
        hasChanged: boolean; 
        windowDimensions: any;
        gridOptions: any;
        selectedOverlay: OverlayTag;

        close: Function;
        addTag();
        editTag();        
        deleteTag();
        hasSelection(): boolean;
        restore();
        save();
        getColor(row);
            
    }

    export class OverlayTag {
        public id: string = "";
        public tag: string = "";
        public overlayType: number = 0;
        public color: string = "#FFFFFF";
        public title: string = "";        
    }

    export class OverlayTags {
        public topLeft: Array<OverlayTag>;
        public topRight: Array<OverlayTag>;
        public bottomLeft: Array<OverlayTag>;
        public bottomRight: Array<OverlayTag>;
        public centerLeft: Array<OverlayTag>;
        public centerTop: Array<OverlayTag>;
        public centerRight: Array<OverlayTag>;
        public centerBottom: Array<OverlayTag>;                    

        constructor() {
            this.topRight = new Array<OverlayTag>();
            this.topLeft = new Array<OverlayTag>();
            this.bottomLeft = new Array<OverlayTag>();
            this.bottomRight = new Array<OverlayTag>();
            this.centerLeft = new Array<OverlayTag>();
            this.centerTop = new Array<OverlayTag>();
            this.centerRight = new Array<OverlayTag>();
            this.centerBottom = new Array<OverlayTag>();
        }
    }

    export class OverlaySettingsController {
        static $inject = ['$scope', '$modalInstance', 'eventService', 'authenticationService', 'optionsService', 'overlayManagerService', '$modal', 'dialogs','$translate', '$timeout'];

        private _overlayManagerService: OverlayManagerService;
        private _scope: IOverlaySettingsControllerScope;        
        private _overlaySuccessMsg: string;
        private _notificationTitle: string;        

        constructor($scope: IOverlaySettingsControllerScope, $modalInstance, eventService: EventService, authenticationService: AuthenticationService, optionsService: OptionsService,
            overlayManagerService: OverlayManagerService, $modal, dialogs, $translate, $timeout:ng.ITimeoutService) {
            var __this = this;
            var saved: boolean = false;

            this._overlayManagerService = overlayManagerService;
            this._scope = $scope;  
            $scope.position = {value: 'topLeft'};
            
            $scope.gridOptions = {
                appScopeProvider: $scope,
                enableSorting: true,
                enableRowSelection: true,
                enableRowHeaderSelection: lt.LTHelper.device == lt.LTDevice.mobile || lt.LTHelper.device == lt.LTDevice.tablet,
                noUnselect: true,
                multiSelect: false,
                onRegisterApi: function (gridApi) {

                    gridApi.selection.on.rowSelectionChanged($scope, function (selectedRow) {
                        $scope.selectedOverlay = selectedRow.entity;
                    });                    
                },
                columnDefs: [
                    {
                        name: "Type",
                        field: "overlayType",
                        enableHiding: false,
                        cellFilter: 'mapType'                        
                    },
                    { name: "Title", field: "title", enableHiding: false },
                    { name: "Tag", field: "tag", enableHiding: false },
                    {
                        name: "Color",
                        field: "color",
                        enableHiding: false,
                        enableSorting: false,
                        cellTemplate: '<div class="ui-grid-cell-contents" title="TOOLTIP"><div style="background-color:{{COL_FIELD}}; width:inherit; height:inherit"></div></div>'
                    },
                ],
                data: 'overlays[position.value]'
            };                     

            $scope.overlays = Utils.clone(overlayManagerService.getOverlayTags());

            $scope.close = function () {
                $modalInstance.close();
            }  

            $scope.addTag = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/AddOverlayTag.html',
                    controller: AddTagController,
                    backdrop: 'static',
                    resolve: {
                        tag: function () {
                            return null;
                        }
                    }                    
                });

                modalInstance.result.then(function (tag) {
                    if (!angular.isDefined($scope.overlays[$scope.position.value])) {
                        $scope.overlays[$scope.position.value] = [];
                    }
                    $scope.overlays[$scope.position.value].push(tag);
                    $scope.hasChanged = true;                    
                }, function () {});
            } 

            $scope.editTag = function () {                
                var overlayTag: OverlayTag = $scope.selectedOverlay;                

                if (overlayTag != null) {
                    var modalInstance = $modal.open({
                        templateUrl: 'views/dialogs/AddOverlayTag.html',
                        controller: AddTagController,
                        backdrop: 'static',
                        resolve: {
                            tag: function () {
                                return overlayTag;
                            }
                        }
                    });

                    modalInstance.result.then(function (tag) {
                        var index:number = $scope.overlays[$scope.position.value].indexOf(overlayTag);

                        $scope.overlays[$scope.position.value][index] = tag;
                        $scope.hasChanged = true;
                    }, function () { });
                }                
            }            

            $scope.deleteTag = function () {
                var data = $scope.selectedOverlay;

                if (data != null) {
                    var results = $.grep($scope.overlays[$scope.position.value], function (overlay: Controllers.OverlayTag, index: number) { return overlay.id == data.id });

                    if (results.length > 0) {
                        var index = $scope.overlays[$scope.position.value].indexOf(results[0]);

                        if (index != -1) {
                            $scope.overlays[$scope.position.value].splice(index, 1);
                            $scope.hasChanged = true;
                        }
                    }
                }
            }

            $scope.restore = function () {
                $scope.overlays = Utils.clone(overlayManagerService.getOverlayTags());
                $scope.hasChanged = false;
            } 

            $scope.save = function () {
                overlayManagerService.saveOverlayTags($scope.overlays).success(function () {
                    optionsService.set(OptionNames.OverlaySettings, JSON.stringify($scope.overlays));
                    dialogs.notify(__this._notificationTitle, __this._overlaySuccessMsg);
                    $scope.hasChanged = false;
                    saved = true;
                }).error(function (data,status) {
                    });
            } 

            $scope.getColor = function (row) {
            }       

            $scope.hasSelection = function () {                
                return !angular.isUndefined($scope.selectedOverlay) && $scope.selectedOverlay != null;
            }

            $translate('DIALOGS_OVERLAY_SAVED').then(function (translation) {
                __this._overlaySuccessMsg = translation;
            });

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                __this._notificationTitle = translation;
            });       
        }      
    }
} 

app.filter('mapType', function () {    
    return function (code) {
        var olm: OverlayManagerService = angular.element('*[ng-app]').injector().get("overlayManagerService");

        if (!angular.isDefined(code)) {
            return 'UserData';
        } else {
            return olm.getOverlayTypeName(code);
        }
    };
});