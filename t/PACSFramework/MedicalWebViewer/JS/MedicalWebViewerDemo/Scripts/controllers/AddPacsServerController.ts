// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IAddPacsServerControllerScope extends ng.IScope {
        server: Models.PACSConnection;
        title: string;        

        ok();
        cancel();        
        verify();     
    }

    export class AddPacsServerController {
        static $inject = ['$scope', '$modalInstance','server', 'clientAE', 'queryPacsService', 'blockUI', '$translate', 'dialogs'];        

        constructor($scope: IAddPacsServerControllerScope, $modalInstance, server:Models.PACSConnection, clientAE, queryPacsService: QueryPacsService, blockUI, $translate, dialogs) { 
            var notifyTitle: string = '';
            var errorTitle: string = '';
            var verifySuccess: string = '';
            var verifyFailure: string = '';
                      
            $scope.title = 'DIALOGS_ADD_REMOTE_PACS_TITLE';
            if (server) {
                $scope.title = 'DIALOGS_EDIT_REMOTE_PACS_TITLE'; 
                if(typeof server.isDefault == "string")
                {
                    server.isDefault = <any>(server.isDefault) == "true" ? true : false;
                }               
            }           

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                notifyTitle = translation;
            });

            $translate('DIALOGS_ERROR').then(function (translation) {
                errorTitle = translation;
            });

            $translate('VERIFY_SUCCESS').then(function (translation) {
                verifySuccess = translation;
            });

            $translate('VERIFY_FAILURE').then(function (translation) {
                verifyFailure = translation;
            });

            $scope.server = server || new Models.PACSConnection();                                       

            $scope.ok = function () {
                $modalInstance.close($scope.server);
            }           

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }           

            $scope.verify = function () {
                blockUI.start("Verifying Connection...");
                queryPacsService.VerifyConnection($scope.server, clientAE).success(function (message:string) {
                    blockUI.stop();
                    if (message.replace(/(\r\n|\n|\")/gm, "").length > 0) {
                        dialogs.error(errorTitle, verifyFailure + ": " + message);
                    }
                    else
                        dialogs.notify(notifyTitle, verifySuccess);
                }).
                    error(function (error) {
                        blockUI.stop();
                        if (angular.isDefined(error.Message)) {
                            dialogs.error(errorTitle, verifyFailure + ": " + error.Message);
                        }
                        else
                            dialogs.error(errorTitle, verifyFailure + ": " + error);
                });
            }
        }
    }
}