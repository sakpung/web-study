// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IAddTagControllerScope extends ng.IScope {
        tag: Controllers.OverlayTag;
        ok: Function;
        cancel: Function;
        isUserData(type: number): boolean;
        types: Array<any>;
        overlay: any;
    }

    export class AddTagController {
        static $inject = ['$scope', '$modalInstance','tag'];

        private _overlayManagerService: OverlayManagerService;

        constructor($scope: IAddTagControllerScope, $modalInstance, tag:OverlayTag) {            
            $scope.types = [
                { name: 'Window Level', id: 0 },
                { name: 'Instance Number', id: 1 },
                { name: 'User Data', id: 2 },
                { name: 'Image Quality', id: 3 },
                { name: 'Frame Number', id: 4 },
                { name: 'Left Orientation', id: 5 },
                { name: 'Right Orientation', id: 6 },
                { name: 'Top Orientation', id: 7 },
                { name: 'Bottom Orientation', id: 8 }
            ];

            $scope.overlay = {};
            if (tag == null) {
                $scope.tag = new OverlayTag();
                $scope.overlay.item = $scope.types[0];
            }
            else {
                var types: Array<any>;

                if (tag.overlayType == undefined)
                    tag.overlayType = 2;
                types = $.grep($scope.types, function (type: any, index: number) { return type.id == tag.overlayType });
                $scope.tag = tag;
                $scope.overlay.item = types[0];
            }

            $scope.ok = function () {
                if (tag != null) {
                    $scope.tag.overlayType = $scope.overlay.item.id;
                    $scope.tag.id = UUID.generate();
                }
                else
                    $scope.tag.overlayType = $scope.overlay.item.id;

                $modalInstance.close($scope.tag);
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };

            $scope.isUserData = function (type:number): boolean {
                return type == lt.Controls.Medical.OverlayTextType.userData;
            }
        }
    }
}