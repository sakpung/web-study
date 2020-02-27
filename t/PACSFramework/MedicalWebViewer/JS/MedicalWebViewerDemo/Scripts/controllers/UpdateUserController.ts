// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IUpdateUserControllerScope extends ng.IScope {                
        user: string;
        users: Array<string>;
        roles: Array<Models.Role>;
        selectedRoles: Array<string>;
        permissions: Array<Models.Permission>;
        selectedPermissions: Array<string>;
        password: string;
        confirmPassword: string;       
        usersInfo: { [name: string]: any; };

        deleteUser(user: string);
        isCurrentUserSelected(user: string) : boolean;
        userChanged(role: Models.Role);
        resetPassword(user: string, password: string);
        canSetPermission(permission: string): boolean;
        updateUser(user: string, roles: Array<string>, permissions: Array<string>);
        userHasPermission(user: string, permission:string): boolean;
    }

    export class UpdateUserController {
        static $inject = ['$scope', 'optionsService', 'authenticationService', 'dialogs', '$translate','$timeout'];  

        private _authenticationService: AuthenticationService;          
        private _dialogs: any;
        private _successMessage: string;
        private _notifyTitle: string;
        private _errorTitle: string;
        private _scope: IUpdateUserControllerScope;
        private _userPermissions: any;
        private _userRoles: any;
        private _timeout: ng.ITimeoutService;
        private _confirmDeleteUserTitle: string;
        private _confirmDeleteUserMessage: string;

        constructor($scope: IUpdateUserControllerScope, optionsService: OptionsService, authenticationService: AuthenticationService, dialogs, $translate,$timeout:ng.ITimeoutService) {  
            var __this = this;
                                                                                       
            this._authenticationService = authenticationService;            
            this._dialogs = dialogs;
            this._userPermissions = {};
            this._userRoles = {};
            this._timeout = $timeout;

            $scope.selectedPermissions = new Array<string>();
            $scope.selectedRoles = new Array<string>();
            $scope.password = '';
            $scope.confirmPassword = '';             

            $scope.deleteUser = $.proxy(this.deleteUser, this);
            $scope.isCurrentUserSelected = $.proxy(this.isCurrentUserSelected, this);
            $scope.userChanged = $.proxy(this.userChanged, this);
            $scope.resetPassword = $.proxy(this.resetPassword, this);
            $scope.updateUser = $.proxy(this.updateUser, this);
            $scope.userHasPermission = $.proxy(this.userHasPermission, this);

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                __this._notifyTitle = translation;
            });

            $translate('DIALOGS_ERROR').then(function (translation) {
                __this._errorTitle = translation;
            });

            this._confirmDeleteUserTitle = "Confirm Delete";
            $translate('DIALOGS_CONFIRMATION_DELETE_USER_TITLE').then(function (translation) {
                this._confirmDeleteUserTitle = translation;
            }.bind(this));

            this._confirmDeleteUserMessage = "Are you sure you want to delete the currently selected user ({0})?";
            $translate('DIALOGS_CONFIRMATION_DELETE_USER_MESSAGE').then(function (translation) {
                this._confirmDeleteUserMessage = translation;
            }.bind(this));

            authenticationService.getAllUsers().
                success(function (result) {   
                    $scope.usersInfo = {};
                    $scope.users = [];

                    if (result && result.length > 0) {
                        for (var u of result) {
                            if (u.UserName) {
                                $scope.usersInfo[u.UserName] = u;
                                $scope.users.push(u.UserName);
                            }
                            else {
                                $scope.usersInfo[u] = u;
                                $scope.users.push(u);
                            }
                        }
                    }
                    
                    if ($scope.users && $scope.users.length > 0) {
                        $scope.user = $scope.users[0];                        
                    }
                    authenticationService.getRoles().
                        success(function (result) {
                            $scope.roles = result || [];                            
                            authenticationService.getPermissions().
                                success(function (result) {
                                    $scope.permissions = result;
                                    __this.userChanged($scope.user);
                                }).
                                error(function (error) {
                                });  
                        }).
                        error(function (error) {
                        });                                                     
                }).
                error(function (error) {
                });                                   

            $scope.canSetPermission = $.proxy(this.canSetPermission, this);
            
            this._scope = $scope;
        }

        private deleteUser(user:string) {
            var __this = this; 

            var confirmationMessage: string = this._confirmDeleteUserMessage.format(user);
            var dlg = this._dialogs.confirm(this._confirmDeleteUserTitle, confirmationMessage);

            dlg.result.then(function (btn) {
                if (btn == "yes") {
                    __this._authenticationService.deleteUser(user)
                        .success(function (result) {
                            if (angular.isDefined(result.FaultType)) {
                                __this._dialogs.error(__this._errorTitle, result.Message);
                            }
                            else {
                                var index = __this._scope.users.map(r => r).indexOf(user);

                                __this._dialogs.notify(__this._notifyTitle, "User [" + user + "] deleted successfully.");
                                if (index != -1) {
                                    __this._scope.users.splice(index, 1);
                                    __this._scope.selectedPermissions.length = 0;
                                    __this._scope.selectedRoles.length = 0;
                                }
                            }
                        })
                        .error(function (error) {
                            __this._dialogs.error(__this._errorTitle, error);
                        });
                }
            }); 
        }

        private isCurrentUserSelected(currentUser: string): boolean {
            var currentUserSelected: boolean = false;
            if (currentUser != null) {
                currentUserSelected = (currentUser == this._authenticationService.user);
            }
            return currentUserSelected;
        }

        private userChanged(user: string) {
            var __this = this;
            
            this._scope.password = '';
            this._scope.confirmPassword = '';           

            if(!angular.isDefined(this._userRoles[user])) {
                this._authenticationService.getUserRoles(user).
                    success(function (result) {
                        __this._scope.selectedRoles = result;
                        __this._userRoles[user] = angular.copy(__this._scope.selectedRoles);
                    }).
                    error(function (error) {
                        __this._dialogs.error(__this._errorTitle, error);
                    });
            }
            else {
                __this._scope.selectedRoles = this._userRoles[user];
            }
            
            if(!angular.isDefined(this._userPermissions[user])) {
                this._authenticationService.getUserPermissions(user).
                    success(function (result) {
                        __this._scope.selectedPermissions = result;                        
                    }).
                    error(function (error) {
                        __this._dialogs.error(__this._errorTitle, error);
                    });
            }
            else {
                __this._scope.selectedPermissions = this._userPermissions[user];
            }            
        }

        private resetPassword(user:string, password:string) {
            var __this = this;

            this._authenticationService.validatePassword(password).
                success(function (result) {
                    if (result.length == 0) {
                        __this._authenticationService.resetPassword(user, password).
                            success(function (result) {
                                if (angular.isDefined(result.FaultType)) {
                                    __this._dialogs.error(__this._errorTitle, result.Message);
                                }
                                else {
                                    __this._dialogs.notify(__this._notifyTitle, "User [" + user + "] password reset successfully.");
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

        private canSetPermission(permission: string): boolean {
            var length = this._scope.selectedRoles.length;

            for (var i = 0; i < length; i++) {
                var index: number = this._scope.roles.map(r => r.Name).indexOf(this._scope.selectedRoles[i]);

                if (index != -1) {
                    var role: Models.Role = this._scope.roles[index];

                    if (role.AssignedPermissions.indexOf(permission) != -1) {
                        return false;
                    }
                }
            }
            return true;
        }

        private updateUser(user: string, roles: Array<string>, permissions: Array<string>) {
            var length: number = this._scope.roles.length;
            var __this = this;

            for (var i = 0; i < length; i++) {
                var role: string = this._scope.roles[i].Name;
                var index: number = roles.map(r => r).indexOf(role);                

                if (index != -1) {  
                    __this.grantRole(user, role);                                   
                }
                else {
                    __this.denyRole(user, role);
                }
            } 

            length = this._scope.permissions.length;
            for (var i = 0; i < length; i++) {
                var permission: string = this._scope.permissions[i].Name;
                var index: number = permissions.map(p => p).indexOf(permission);

                if (index != -1) {
                    __this.grantPermission(user, permission);                
                }
                else {
                    __this.denyPermission(user, permission);
                }
            }
            __this._dialogs.notify(__this._notifyTitle, "User [" + user + "] updated successfully.");
        }

        private grantRole(user: string, role: string) {            
            var __this = this;

            this._authenticationService.grantRole(user, role).
                success(function (result) {
                    var index: number = __this._userRoles[user].indexOf(role);

                    if (index == -1) {
                        __this._userRoles[user].push(role);
                    }                            
                }).
                error(function (error) {
                }); 
        }

        private denyRole(user: string, role: string) {
            var __this = this;
            
            this._authenticationService.denyRole(user, role).
                success(function (result) {
                    var index: number = __this._userRoles[user].indexOf(role);

                    if (index != -1) {
                        __this._userRoles[user].slice(index, 1);
                    }   
                }).
                error(function (error) {
                });
        } 

        private grantPermission(user: string, permission: string) {
            var __this = this;
            
            this._authenticationService.grantPermission(user, permission).
                success(function (result) {
                    if (__this._userPermissions[user]) {
                    var index: number = __this._userPermissions[user].indexOf(permission);

                    if (index == -1) {
                        __this._userPermissions[user].push(permission);
                    }   
                    }
                }).
                error(function (error) {
                }); 
        }  
        
        private denyPermission(user: string, permission: string) {
            var __this = this;

            this._authenticationService.denyPermission(user, permission).
                success(function (result) {
                    if (__this._userPermissions[user]) {
                    var index: number = __this._userPermissions[user].indexOf(permission);

                    if (index != -1) {
                        __this._userPermissions[user].slice(index, 1);
                        }
                    } 
                }).
                error(function (error) {
                });
        }            

        private userHasPermission(user: string, permission:string): boolean {
            if(angular.isDefined(this._userPermissions[user])) {
                return this._userPermissions[user].indexOf(permission) != -1;
            }
            return false;
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