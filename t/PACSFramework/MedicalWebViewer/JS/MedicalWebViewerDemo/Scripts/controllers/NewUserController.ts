// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface INewUserControllerScope extends ng.IScope {                
        username: string;
        password: string;
        confirmPassword: string;        
        validateOnAd: boolean;
        validateOnIdP: boolean;

       createUser(username: string, password: string);
    }

    export class NewUserController {
        static $inject = ['$scope', 'optionsService', 'authenticationService', 'dialogs', '$translate'];  

        private _authenticationService: AuthenticationService;  
        private _scope: INewUserControllerScope;   
        private _dialogs: any;
        private _notifyTitle: string;
        private _errorTitle: string;

        constructor($scope: INewUserControllerScope, optionsService: OptionsService, authenticationService: AuthenticationService, dialogs, $translate) {  
            var __this = this;
                                                                            
            $scope.username = '';
            $scope.password = '';
            $scope.confirmPassword = '';            
            $scope.validateOnAd = false;
            $scope.validateOnIdP= false;

            $scope.createUser = $.proxy(this.createUser, this);

            this._authenticationService = authenticationService;
            this._scope = $scope;
            this._dialogs = dialogs;

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                __this._notifyTitle = translation;
            });

            $translate('DIALOGS_ERROR').then(function (translation) {
                __this._errorTitle = translation;
            });
        }

        private createUser(username: string, password: string, validateOnAd: boolean, validateOnIdP: boolean) {
            var __this = this;
            
            var userType = 'classic';
            if(validateOnAd)
               userType = 'activedirectory';
            else if(validateOnIdP)
               userType = 'federatedIdP';

            this._authenticationService.createUser(username, password, userType)
                .success(function (result) {   
                    if (angular.isDefined(result.FaultType)) { 
                        __this._dialogs.error(__this._errorTitle, result.Message);                       
                    }
                    else { 
                        __this._dialogs.notify(__this._notifyTitle, "User created successfully.");                       
                    }                 
                })
                .error(function (error) {
                    if (angular.isDefined(error.FaultType)) {
                        __this._dialogs.error(__this._errorTitle, error.Message);
                    }
                    else
                        __this._dialogs.error(__this._errorTitle,error); 
                });
        }
    }
}