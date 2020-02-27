// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IGridSettingsControllerScope extends ng.IScope {
        input: any;
        label: string;
        title: string;

        cancel();
        ok();
    }

    export class GridSettingsController {
        static $inject = ['$scope', '$modalInstance','label','spacing','length', 'title'];

        constructor($scope: IGridSettingsControllerScope, $modalInstance, label, spacing, length, title) {  
            $scope.title = title;
            $scope.label = label;
            $scope.input = {
                spacing: parseInt(spacing),
                length: parseInt(length)
            }            
                     
            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }

            $scope.ok = function () {
                $modalInstance.close({
                    spacing: $scope.input.spacing,
                    length: $scope.input.length
                });
            }                    
        }
    }
} 