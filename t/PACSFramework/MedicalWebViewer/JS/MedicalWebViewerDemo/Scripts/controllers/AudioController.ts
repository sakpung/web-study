// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

module Controllers {
    export interface IAudioControllerScope extends ng.IScope {
        uiType: string;
        href: string;
        close();
    }

    export class AudioController {

        static $inject = ['$scope', '$modalInstance', 'seriesManagerService', 'objectRetrieveService'];

        constructor($scope: IAudioControllerScope, $modalInstance, seriesManagerService: SeriesManagerService, objectRetrieveService: ObjectRetrieveService) {
            var cellFrame = seriesManagerService.get_activeCellFrame();
            var sopInstanceUID = cellFrame.Instance.SOPInstanceUID;

            $scope.uiType = "none";            

            objectRetrieveService.GetAudioGroupsCount(sopInstanceUID).then(function (result) {
                if (result.status == 200) {                    
                    if (result.data && result.data > 0) {
                        if (lt.LTHelper.OS == lt.LTOS.iOS) {
                            if (lt.LTHelper.device == lt.LTDevice.tablet) {
                                $scope.uiType = "download";                                
                            }
                        }
                        if ($scope.uiType != 'download') {
                            $scope.uiType = 'playback';
                        }

                        $scope.href = objectRetrieveService.BuildAudioUrl(sopInstanceUID, 0, 'audio/wav');
                    }
                    else
                        $scope.uiType = 'none';
                }

            }, function (error) {
                $scope.uiType = 'none';
                });

            $scope.close = function () {
                $modalInstance.close();
            }
        }
    }
}