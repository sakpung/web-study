// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IUpdateRoleControllerScope extends ng.IScope {                
        role: Models.Role;
        roles: Array<Models.Role>;
        permissions: Array<Models.Permission>;
        selectedPermissions: Array<string>;

        deleteRole(role: Models.Role);
        roleChanged(role: Models.Role);
        updateRole(role: Models.Role, permissions: Array<string>);
    }

    export class UpdateRoleController {
        static $inject = ['$scope', 'optionsService', 'authenticationService', 'dialogs', '$translate'];  

        private _authenticationService: AuthenticationService;          
        private _dialogs: any;
        private _successMessage: string;
        private _notifyTitle: string;
        private _errorTitle: string;
        private _scope: IUpdateRoleControllerScope;

        constructor($scope: IUpdateRoleControllerScope, optionsService: OptionsService, authenticationService: AuthenticationService, dialogs, $translate) {  
            var __this = this;
                                                                            
            $scope.role = null;                        
            $scope.selectedPermissions = new Array<string>();

            $scope.deleteRole = $.proxy(this.deleteRole, this);
            $scope.roleChanged = $.proxy(this.roleChanged, this);
            $scope.updateRole = $.proxy(this.updateRole, this);

            this._authenticationService = authenticationService;            
            this._dialogs = dialogs;

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                __this._notifyTitle = translation;
            });

            $translate('DIALOGS_ERROR').then(function (translation) {
                __this._errorTitle = translation;
            });

            authenticationService.getRoles().
                success(function (result) {
                    $scope.roles = result; 
                    if ($scope.roles && $scope.roles.length > 0) {
                        $scope.role = $scope.roles[0];
                        __this.roleChanged($scope.role);
                    }                                           
                }).
                error(function (error) {
                });

            authenticationService.getPermissions().
                success(function (result) { 
                    $scope.permissions = result;                   
                    __this.roleChanged($scope.role);
                }).
                error(function (error) {
                });
            this._scope = $scope;
        }

        private deleteRole(role: Models.Role) {
            var __this = this;
            
            this._authenticationService.deleteRole(role.Name)
                .success(function (result) {   
                    if (angular.isDefined(result.FaultType)) { 
                        __this._dialogs.error(__this._errorTitle, result.Message);                       
                    }
                    else { 
                        var index = __this._scope.roles.map(r => r.Name).indexOf(role.Name);

                        __this._dialogs.notify(__this._notifyTitle, "Role [" + role.Name + "] deleted successfully."); 
                        if (index != -1) {
                            __this._scope.roles.splice(index, 1);
                            __this._scope.selectedPermissions.length = 0;
                        }                                              
                    }                 
                })
                .error(function (error) {
                    __this._dialogs.error(__this._errorTitle,error); 
                });
        }

        private roleChanged(role: Models.Role) {
            this._scope.selectedPermissions.length = 0;
            if (role != null) {
                var length: number = role.AssignedPermissions.length;

                for (var i = 0; i < length; i++) {
                    this._scope.selectedPermissions.push(role.AssignedPermissions[i]);
                }
            }
        }

        private updateRole(role: Models.Role, permissions: Array<string>) {
            var __this = this;

            this._authenticationService.updateRolePermissions(role.Name, permissions).
                success(function (result) {
                    if (angular.isDefined(result.FaultType)) {
                        __this._dialogs.error(__this._errorTitle, result.Message);
                    }
                    else {
                        role.AssignedPermissions = permissions;

                        __this._dialogs.notify(__this._notifyTitle, "Role [" + role.Name + "] updated successfully.");
                    }                     
                }).
                error(function (error) {
                    __this._dialogs.error(__this._errorTitle, error);
                });
        }
    }
}