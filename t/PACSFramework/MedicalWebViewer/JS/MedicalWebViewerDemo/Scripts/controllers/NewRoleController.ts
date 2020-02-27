// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface INewRoleControllerScope extends ng.IScope {                
        role: string;
        description: string;
        
        createRole(role:string);
    }

    export class NewRoleController {
        static $inject = ['$scope', 'optionsService', 'authenticationService', 'dialogs', '$translate'];  

        private _authenticationService: AuthenticationService;          
        private _dialogs: any;
        private _successMessage: string;
        private _notifyTitle: string;
        private _errorTitle: string;

        constructor($scope: INewRoleControllerScope, optionsService: OptionsService, authenticationService: AuthenticationService, dialogs, $translate) {  
            var __this = this;
                                                                            
            $scope.role = '';            
            $scope.createRole = $.proxy(this.createRole, this);

            this._authenticationService = authenticationService;            
            this._dialogs = dialogs;

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                __this._notifyTitle = translation;
            });

            $translate('DIALOGS_ERROR').then(function (translation) {
                __this._errorTitle = translation;
            });
        }

        private createRole(role: string, description:string) {
            var __this = this;
            
            this._authenticationService.createRole(role,description)
                .success(function (result) {   
                    if (angular.isDefined(result.FaultType)) { 
                        __this._dialogs.error(__this._errorTitle, result.Message);                       
                    }
                    else { 
                        __this._dialogs.notify(__this._notifyTitle, "Role [" + role + "] created successfully.");                       
                    }                 
                })
                .error(function (error) {
                    __this._dialogs.error(__this._errorTitle,error); 
                });
        }
    }
}