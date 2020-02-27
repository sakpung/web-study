// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/datejs.d.ts" />

module Controllers {
    export interface IRemotePacsControllerScope extends ng.IScope {
        gridOptions: any;       
        windowDimensions: any;                
        pacsConfig: Models.RemoteConfig;
        pacsConnections: Array<Models.PACSConnection>;
        selectedServer: any;
        gridApi: any;
        close();
        save();
        addPacsServer();
        editPacsServer();
        deletePacsServer();           
    }

    export class RemotePacsController {
        static $inject = ['$scope', '$modalInstance', 'optionsService', '$modal', 'authenticationService', 'dialogs', '$translate', '$timeout'];

        private _modal;
        private _saveSuccessMsg: string;
        private _saveFailureMsg: string;
        private _notificationTitle: string;

        private filter(connections: Array<Models.RemoteConnection>, filtered: Array<Models.PACSConnection>): void{

            if (filtered.length > 0)
                filtered.splice(0, filtered.length);

            for (var index = 0; index < connections.length; index++) {
                if (connections[index].type == 'pacs') {
                    filtered.push(connections[index] as Models.PACSConnection);
                }
            }
        }

        constructor($scope: IRemotePacsControllerScope, $modalInstance, optionsService: OptionsService, $modal, authenticationService: AuthenticationService,dialogs,$translate, $timeout:ng.ITimeoutService) {                        
            var __this = this;
            var saved:boolean = false;          

            this._modal = $modal;           
            $scope.selectedServer = null;

            $scope.pacsConfig = Models.RemoteConfig.Factory(optionsService.get(OptionNames.RemoteConfig));
            $scope.pacsConnections = new Array<Models.PACSConnection>();
            __this.filter($scope.pacsConfig.servers, $scope.pacsConnections);

            $scope.gridOptions = {
                enableSorting: true,
                enableRowSelection: true,
                enableRowHeaderSelection: lt.LTHelper.device == lt.LTDevice.mobile || lt.LTHelper.device == lt.LTDevice.tablet,
                noUnselect: false,
                multiSelect: false,
                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                    gridApi.selection.on.rowSelectionChanged($scope, function (selectedRow) {                        
                        $scope.selectedServer = selectedRow.entity;
                    });                    
                },
                columnDefs: [
                    { name: "AE Title", field: "AETitle", enableHiding: false, displayName: "AE Title" },
                    { name: "IP Address", field: "IPAddress", enableHiding: false, displayName: "IP Address" },
                    { name: "Port", field: "Port", enableHiding: false },
                    { name: "Default", field: "isDefault", enableHiding: false },
                ],
                data: $scope.pacsConnections
            };
                                                          
                
            $scope.addPacsServer = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/AddPacsServer.html',
                    controller: AddPacsServerController,
                    backdrop: 'static',
                    resolve: {
                        server: function () {
                            return undefined;
                        },
                        clientAE: function () {
                            return $scope.pacsConfig.client;
                        }
                    }
                });

                modalInstance.result.then(function (server: Models.PACSConnection) {                    
                    for (var i = 0; i < $scope.pacsConfig.servers.length; i++) {
                        if (server.isDefault) {
                            $scope.pacsConfig.servers[i].isDefault = false;
                        }
                    }
                    $scope.pacsConfig.servers.push(server);                    
                    __this.filter($scope.pacsConfig.servers, $scope.pacsConnections);//update filtered for view connections                    
                });
            }           

            $scope.deletePacsServer = function () {
                var result: Array<Models.RemoteConnection> = $.grep($scope.pacsConfig.servers, function (item: Models.RemoteConnection, index: number) {
                    return (item.id == $scope.selectedServer.id) && (item.type=='pacs');
                });

                if (result.length > 0) {
                    var index = $scope.pacsConfig.servers.indexOf(result[0]);

                    $scope.pacsConfig.servers.splice(index, 1);
                    $scope.selectedServer = null;                    
                    __this.filter($scope.pacsConfig.servers, $scope.pacsConnections);//update filtered for view connections               
                }
            }           

            $scope.editPacsServer = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/AddPacsServer.html',
                    controller: AddPacsServerController,
                    backdrop: 'static',
                    resolve: {
                        server: function () {
                            return $scope.selectedServer;
                        },
                        clientAE: function () {
                            return $scope.pacsConfig.client;
                        }
                    }
                });

                modalInstance.result.then(function (server: Models.PACSConnection) {
                    var result: Array<Models.RemoteConnection> = $.grep($scope.pacsConfig.servers, function (item: Models.RemoteConnection, index: number) {
                        return (item.id == $scope.selectedServer.id) && (item.type == 'pacs');
                    });                    
                    if (result.length > 0) {
                        var index = $scope.pacsConfig.servers.indexOf(result[0]);                        

                        for (var i = 0; i < $scope.pacsConfig.servers.length; i++) {
                            if (i != index && server.isDefault) {
                                $scope.pacsConfig.servers[i].isDefault = false;
                            }
                        }

                        $scope.pacsConfig.servers[index] = server;
                        __this.filter($scope.pacsConfig.servers, $scope.pacsConnections);//update filtered for view connections
                    }
                });
            } 

            $scope.save = function () {
                var data = {};
                var json = JSON.stringify($scope.pacsConfig);                

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

            $translate('NOTIFY_PACSCONFIG_SAVE_SUCCESS').then(function (translation) {
                __this._saveSuccessMsg = translation;
            });

            $translate('NOTIFY_PACSCONFIG_SAVE_FAILURE').then(function (translation) {
                __this._saveFailureMsg = translation;
            });

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                __this._notificationTitle = translation;
            });
        }                
    }
}