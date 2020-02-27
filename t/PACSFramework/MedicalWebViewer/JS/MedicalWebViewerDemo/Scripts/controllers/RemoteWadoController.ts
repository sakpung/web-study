// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/datejs.d.ts" />

module Controllers {
    export interface IRemoteWadoControllerScope extends ng.IScope {
        gridOptions: any;       
        windowDimensions: any;                
        wadoConfig: Models.RemoteConfig;
        wadoConnections: Array<Models.WadoConnection>;
        selectedServer: any;

        close();
        save();
        addWadoServer();
        editWadoServer();
        deleteWadoServer();           
    }

    export class RemoteWadoController {
        static $inject = ['$scope', '$modalInstance', 'optionsService', '$modal', 'authenticationService', 'dialogs', '$translate', '$timeout'];

        private _modal;
        private _saveSuccessMsg: string;
        private _saveFailureMsg: string;
        private _notificationTitle: string;

        private wadoConnections(config:Models.RemoteConfig): Models.RemoteConfig {
            var result: Models.RemoteConfig = new Models.RemoteConfig();

            result.client = config.client;

            for (var index = 0; index < config.servers.length; index++) {
                if (config.servers[index].type == 'wado') {
                    result.servers.push(config.servers[index] as Models.WadoConnection);
                }
            }

            return result;
        }

        private filter(connections: Array<Models.RemoteConnection>, filtered: Array<Models.WadoConnection>): void {

            if (filtered.length > 0)
                filtered.splice(0, filtered.length);

            for (var index = 0; index < connections.length; index++) {
                if (connections[index].type == 'wado') {
                    filtered.push(connections[index] as Models.WadoConnection);
                }
            }
        }

        constructor($scope: IRemoteWadoControllerScope, $modalInstance, optionsService: OptionsService, $modal, authenticationService: AuthenticationService,dialogs,$translate, $timeout:ng.ITimeoutService) {                        
            var __this = this;
            var saved:boolean = false;          

            this._modal = $modal;           
            $scope.selectedServer = null;

            $scope.wadoConfig = Models.RemoteConfig.Factory(optionsService.get(OptionNames.RemoteConfig)); 
            $scope.wadoConnections = new Array<Models.WadoConnection>();
            __this.filter($scope.wadoConfig.servers, $scope.wadoConnections);

            $scope.gridOptions = {
                enableSorting: true,
                enableRowSelection: true,
                enableRowHeaderSelection: lt.LTHelper.device == lt.LTDevice.mobile || lt.LTHelper.device == lt.LTDevice.tablet,
                noUnselect: false,
                multiSelect: false,
                onRegisterApi: function (gridApi) {

                    gridApi.selection.on.rowSelectionChanged($scope, function (selectedRow) {                        
                        $scope.selectedServer = selectedRow.entity;
                    });                    
                },
                columnDefs: [
                    { name: "Friendly Name", field: "title", enableHiding: false, displayName: "Friendly Name" },
                    { name: "DicomWeb Address", field: "dicomWebRoot", enableHiding: false, displayName: "DicomWeb Address" },
                    { name: "Uri Address", field: "UriAddress", enableHiding: false, displayName: "Uri Address" },
                    { name: "Default", field: "isDefault", enableHiding: false },
                ],
                data: $scope.wadoConnections
            };
                                                          
                
            $scope.addWadoServer = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/AddWadoServer.html',
                    controller: AddWadoServerController,
                    backdrop: 'static',
                    resolve: {
                        server: function () {
                            return undefined;
                        }
                    }
                });

                modalInstance.result.then(function (server: Models.WadoConnection) {                    
                    for (var i = 0; i < $scope.wadoConfig.servers.length; i++) {
                        if (server.isDefault) {
                            $scope.wadoConfig.servers[i].isDefault = false;
                        }
                    }
                    $scope.wadoConfig.servers.push(server);   
                    __this.filter($scope.wadoConfig.servers, $scope.wadoConnections);//update filtered for view connections                                     
                });
            }           

            $scope.deleteWadoServer = function () {
                var result: Array<Models.RemoteConnection> = $.grep($scope.wadoConfig.servers, function (item: Models.RemoteConnection, index: number) {
                    return item.id == $scope.selectedServer.id;
                });

                if (result.length > 0) {
                    var index = $scope.wadoConfig.servers.indexOf(result[0]);

                    $scope.wadoConfig.servers.splice(index, 1);
                    $scope.selectedServer = null;   
                    __this.filter($scope.wadoConfig.servers, $scope.wadoConnections);//update filtered for view connections                                                      
                }
            }           

            $scope.editWadoServer = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/AddWadoServer.html',
                    controller: AddWadoServerController,
                    backdrop: 'static',
                    resolve: {
                        server: function () {
                            return $scope.selectedServer;
                        }
                    }
                });

                modalInstance.result.then(function (server: Models.WadoConnection) {
                    var result: Array<Models.RemoteConnection> = $.grep($scope.wadoConfig.servers, function (item: Models.RemoteConnection, index: number) {
                        return item.id == server.id;
                    });                    
                    if (result.length > 0) {
                        var index = $scope.wadoConfig.servers.indexOf(result[0]);                        

                        for (var i = 0; i < $scope.wadoConfig.servers.length; i++) {
                            if (i != index && server.isDefault) {
                                $scope.wadoConfig.servers[i].isDefault = false;
                            }
                        }

                        $scope.wadoConfig.servers[index] = server;
                        __this.filter($scope.wadoConfig.servers, $scope.wadoConnections);//update filtered for view connections                                     
                    }
                });
            } 

            $scope.save = function () {
                var data = {};
                var json = JSON.stringify($scope.wadoConfig);                

                data[OptionNames.RemoteConfig] = json;
                optionsService.saveDefaultOptions(data).success(function () {
                    optionsService.set(OptionNames.RemoteConfig, json);
                    dialogs.notify(__this._notificationTitle, __this._saveSuccessMsg);
                    saved = true;
                }).error(function (e) {
                    dialogs.error(__this._saveFailureMsg + ": " + status);
                    });
            }          

            $scope.close = function () {
                $modalInstance.close(saved);
            };

            $translate('NOTIFY_WADOCONFIG_SAVE_SUCCESS').then(function (translation) {
                __this._saveSuccessMsg = translation;
            });

            $translate('NOTIFY_WADOCONFIG_SAVE_FAILURE').then(function (translation) {
                __this._saveFailureMsg = translation;
            });

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                __this._notificationTitle = translation;
            });
        }                
    }
}