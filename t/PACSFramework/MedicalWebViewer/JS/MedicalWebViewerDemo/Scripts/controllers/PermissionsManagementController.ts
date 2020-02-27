// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IPermissionsManagementControllerScope extends ng.IScope {        
        edit: any;
        ok();
        cancel();
        isFormValid(): boolean;

        canManageUsers(): boolean;
        canManageRoles(): boolean;          
    }

    export class PermissionsManagementController {
        static $inject = ['$scope', '$modalInstance', 'authenticationService'];        

        constructor($scope: IPermissionsManagementControllerScope, $modalInstance, authenticationService: AuthenticationService) {                                   
            $scope.edit = {};            

            $scope.canManageRoles = function (): boolean {
                return authenticationService.hasPermission(PermissionNames.CanManageRoles);
            }

            $scope.canManageUsers = function (): boolean {
                return authenticationService.hasPermission(PermissionNames.CanManageUsers);
            }

            $scope.ok = function () {
                $modalInstance.close('ok');
            }                                  

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }

            $scope.isFormValid = function () {
                return true;
            }

            if ($scope.canManageUsers()) {
                $scope.edit.view = "NewUser";
            }
            else {
                $scope.edit.view = "NewRole";
            }
        }
    }
}