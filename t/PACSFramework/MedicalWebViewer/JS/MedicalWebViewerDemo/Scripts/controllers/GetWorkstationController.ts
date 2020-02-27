// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IGetWorkstationControllerScope extends ng.IScope {
        info: any;
        isWorkstationEmpty(): boolean;
        cancel();
        ok();
    }

    export class GetWorkstationController {
        static $inject = ['$scope', '$modalInstance', 'optionsService'];

        constructor($scope: IGetWorkstationControllerScope, $modalInstance, optionsService: OptionsService) {
            $scope.info = { workstation: '', comments: '' };            

            $scope.isWorkstationEmpty = function () {
                return $scope.info.workstation.length == 0;
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }

            $scope.ok = function () {
                $modalInstance.close({ workstation: $scope.info.workstation, comments: $scope.info.comments });
            }                    
        }
    }
} 