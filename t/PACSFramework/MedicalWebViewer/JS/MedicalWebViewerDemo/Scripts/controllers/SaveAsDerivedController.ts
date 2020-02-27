// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface ISaveAsDerivedControllerScope extends ng.IScope {        
        derivedInfo: Models.DerivedInfo;
        editSeriesNumber: boolean;
        editProtocolName: boolean;

        ok();
        cancel();
    }

    export class SaveAsDerivedController {
        static $inject = ['$scope', 'optionsService', '$modalInstance', 'derivedInfo'];

        private _overlayManagerService: OverlayManagerService;

        constructor($scope: ISaveAsDerivedControllerScope, optionsService:OptionsService, $modalInstance, derivedInfo:Models.DerivedInfo) {                                   
            $scope.derivedInfo = derivedInfo;
            $scope.editSeriesNumber = optionsService.get(OptionNames.EnableSeriesNumberEdit);
            $scope.editProtocolName = optionsService.get(OptionNames.EnableProtocolNameEdit);

            $scope.ok = function () {               
                $modalInstance.close($scope.derivedInfo);
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };            
        }
    }
}