// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IAddToolbarItemControllerScope extends ng.IScope {
        item: Models.ToolbarItem;

        ok();
        cancel();
        isFormValid(): boolean;        
    }

    export class AddToolbarItemController {
        static $inject = ['$scope', '$modalInstance','item'];        

        constructor($scope: IAddToolbarItemControllerScope, $modalInstance, item) {           
            $scope.item = item || new Models.ToolbarItem();

            $scope.isFormValid = function () {
                return $scope.item.id != undefined && $scope.item.id.length != 0 &&
                       $scope.item.action!=undefined && $scope.item.action.length !=0;
            }

           $scope.ok = function () {
                $scope.item.type = "button";
                $modalInstance.close($scope.item);
            }           

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }
        }
    }
}