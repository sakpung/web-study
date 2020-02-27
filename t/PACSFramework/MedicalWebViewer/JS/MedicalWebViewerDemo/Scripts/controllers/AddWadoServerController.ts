// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IAddWadoServerControllerScope extends ng.IScope {
        server: Models.WadoConnection;
        title: string;        

        ok();
        cancel();        
    }

    export class AddWadoServerController {
        static $inject = ['$scope', '$modalInstance','server', 'blockUI', '$translate', 'dialogs'];        

        constructor($scope: IAddWadoServerControllerScope, $modalInstance, server: Models.WadoConnection, blockUI, $translate, dialogs) { 
            var notifyTitle: string = '';
            var errorTitle: string = '';
            
                      
            $scope.title = 'DIALOGS_ADD_WADO_TITLE';
            if (server) {
                $scope.title = 'DIALOGS_EDIT_WADO_TITLE'; 
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

           

            $scope.server = server || new Models.WadoConnection();                                       

            $scope.ok = function () {
                $modalInstance.close($scope.server);
            }           

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }                       
        }
    }
}