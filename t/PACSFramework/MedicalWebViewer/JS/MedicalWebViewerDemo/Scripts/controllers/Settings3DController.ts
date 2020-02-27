// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface ISettings3DControllerScope extends ng.IScope {
        ok();
        cancel();
        isFormValid(): boolean; 
        isSelectorValueValid(): boolean;
        isSelectorIndexValid(): boolean;
        getSelectorIndexError(): string;
        getIsoThresholdError(): string;
        getSelectorValueError(): string;
        range: Models.ValueRange;
        source: Models.Settings3DOptions;

    }

    export class Settings3DController {

        static $inject = ['$scope', 'eventService', 'toolbarService', '$modalInstance', 'optionsService', 'objectRetrieveService', '$translate', 'cell'];

        private _dateFormat: string;
        private _timeFormat: string;
        private _$scope: ISettings3DControllerScope;
        private _unknownString: string = "Unknown";
        private _objectRetrieveService: ObjectRetrieveService;

        GetVolume = function (volumeType) {
            switch (volumeType) {
                case lt.Controls.Medical.VolumeType.VRT:
                case lt.Controls.Medical.VolumeType.MIP:
                    return "Volume";
                case lt.Controls.Medical.VolumeType.MPR:
                    return "MPR";
            }
        }

        constructor($scope: ISettings3DControllerScope, eventService: EventService, toolbarService: ToolbarService, $modalInstance, optionsService: OptionsService, objectRetrieveService: ObjectRetrieveService, $translate, cell) {
            this._$scope = $scope; 
            var model = [];
            var __this = this;

            $scope.source = new Models.Settings3DOptions();
            $scope.range = new Models.ValueRange();

            var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>cell;

            $scope.range.ValueMaximum = parseInt(cell3D.information.maxValue.toString());
            $scope.range.ValueMinimum = parseInt(cell3D.information.minValue.toString());

            $scope.source.volumeType = this.GetVolume(cell.volumeType);


            $scope.source.lowResQuality = cell.volume.lowResQuality;
            $scope.source.showClippingFrame = cell.volume.enableClippingFrame;
            $scope.source.showCrossLines = cell.MPR.enableCrossLines;
            $scope.source.projectionMethod = cell.projection;
            $scope.source.showRotationCube = cell.showRotationCube;
            $scope.source.showVolumeBorder = cell.showVolumeBorder;
            $scope.source.resizeFactor = cell.resizeFactor;


            $scope.ok = function () {

                var output : any = {};
                output.IsoThreshold = __this._$scope.source.isoThreshold;

                output.LowResQuality     = __this._$scope.source.lowResQuality;
                output.ProjectionMethod  = __this._$scope.source.projectionMethod;
                output.ShowClippingFrame = __this._$scope.source.showClippingFrame;
                output.ShowMPRCrossLines = __this._$scope.source.showCrossLines;
                output.ShowRotationCube  = __this._$scope.source.showRotationCube;
                output.ShowVolumeBorder = __this._$scope.source.showVolumeBorder;
                cell.resizeFactor = __this._$scope.source.resizeFactor;
                output.AxialPosition = -1;
                output.SagittalPosition = -1;
                output.CoronalPosition = -1;


                $modalInstance.close(output);
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };

            $scope.isSelectorIndexValid = this.isSelectorIndexValid.bind(this);   
            $scope.getSelectorIndexError = this.getSelectorIndexError.bind(this); 
            $scope.getIsoThresholdError = this.getIsoThresholdError.bind(this);

            $scope.isFormValid = function () {
                return this.isSelectorIndexValid();
            }


            $scope.getSelectorValueError = function () {
                return "error test";
            }




        }

        private getIsoThresholdError(): string {
            var value: number = this._$scope.source.isoThreshold;

            if (!$.isNumeric(value)) {
                return "invalid value, must be numerical";
            }

            if (value < this._$scope.range.ValueMinimum || value >= this._$scope.range.ValueMaximum)
                return "value must be betweren (" + this._$scope.range.ValueMinimum + ") and ( " + this._$scope.range.ValueMaximum + " )";

            return "";
        }       


        private getSelectorIndexError(): string {
            var lowQuality = this._$scope.source.lowResQuality;

            if (!$.isNumeric(lowQuality)) {
                return "invalid value, must be numerical";
            }

            if (lowQuality < 0 || lowQuality > 1)
                return "value must be btween 0 and 1";
            return "";
        }       

        private isSelectorIndexValid(): boolean {

            var value: number = this._$scope.source.isoThreshold;
            var lowQuality = this._$scope.source.lowResQuality;

            if (value < this._$scope.range.ValueMinimum  || value >= this._$scope.range.ValueMaximum)
                return false;

            if (lowQuality < 0 || lowQuality > 1)
                return false;

            return true;
        }








    }
}