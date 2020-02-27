// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IUpdatePasswordControllerScope extends ng.IScope {                
        user: string;
        curPassword: string;
        password: string;
        confirmPassword: string;       
        
        resetPassword(curPassword: string, password: string);
    }

    export class UpdatePasswordController {
        static $inject = ['$scope', 'optionsService', 'authenticationService', 'dialogs', '$translate','$timeout'];  

        private _authenticationService: AuthenticationService;          
        private _dialogs: any;
        private _successMessage: string;
        private _notifyTitle: string;
        private _errorTitle: string;
        private _scope: IUpdatePasswordControllerScope;        
                       

        constructor($scope: IUpdatePasswordControllerScope, optionsService: OptionsService, authenticationService: AuthenticationService, dialogs, $translate) {  
            var __this = this;
                                                                                       
            this._authenticationService = authenticationService;            
            this._dialogs = dialogs;                        
        
            $scope.curPassword = '';
            $scope.password = '';
            $scope.confirmPassword = '';             
           
            $scope.resetPassword = $.proxy(this.resetPassword, this);
            
            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                __this._notifyTitle = translation;
            });

            $translate('DIALOGS_ERROR').then(function (translation) {
                __this._errorTitle = translation;
            });
            
            this._scope = $scope;
        }
        
        private resetPassword(curPassword:string, password:string) {
            var __this = this;

            this._authenticationService.validatePassword(password).
                success(function (result) {
                    if (result.length == 0) {
                        __this._authenticationService.resetCurrentPassword(curPassword, password).
                            success(function (result) {
                                if (result) {
                                    __this._dialogs.notify(__this._notifyTitle, "Password changed successfully.");                                    
                                }
                                else {
                                    __this._dialogs.error(__this._errorTitle, "Failed to change password, make sure the current password is correct.");
                                }
                            }).
                            error(function (error) {
                                __this._dialogs.error(__this._errorTitle, error);
                            });
                    }
                    else {
                        __this._dialogs.error(__this._errorTitle, result);
                    }
                }).
                error(function (error) {
                    __this._dialogs.error(__this._errorTitle, error);
                });           
        }
    }
}

interface String {
    format(...replacements: string[]): string;
}

if (!String.prototype.format) {
    String.prototype.format = function () {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
                ? args[number]
                : match
                ;
        });
    };
}