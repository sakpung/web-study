// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IHPTimeBasedImageSetsEditorControllerScope extends ng.IScope {
        timeBasedImageSet: Models.TimeBasedImageSet;
        title: string;   
        
        oldRelativeTime: number[];
        oldAbstractPriorValue: number[];     
        oldRelativeTimeUnits: number;   

        ok();
        cancel();
        getIsFormValidError(): string;
        isFormValid(): boolean;
        isRelativeTime(): boolean;
        dropDownChanged();

        isMinimumRelativeValid(): boolean;
        isMaximumRelativeValid(): boolean;
        isMinimumAbstractValid(): boolean;
        isMaximumAbstractValid(): boolean;

        isRelativeValid(): boolean;
        isAbstractValid(): boolean;

        getRelativeError(): string;
        getAbstractError(): string;
    }    

    export class HPTimeBasedImageSetsEditorController {
        static $inject = ['$scope', '$modal', '$modalInstance', 'item', 'title'];

        private _$modal: any;       
        private _$scope: IHPTimeBasedImageSetsEditorControllerScope;
        //private _oldRelativeTime: number[];   
        //private _oldAbstractPriorValue: number[];   

        constructor($scope: IHPTimeBasedImageSetsEditorControllerScope, $modal, $modalInstance, item: Models.TimeBasedImageSet, title) {                                    
            $scope.timeBasedImageSet = item;
            $scope.title = title;   
            //$scope.oldRelativeTime = oldRelativeTime;
            //$scope.oldAbstractPriorValue = oldAbstractPriorValue;         
            
            this._$scope = $scope;  
            this._$modal = $modal; 

            $scope.oldRelativeTime = [0, 0];
            $scope.oldAbstractPriorValue = [1, 1];
            $scope.oldRelativeTimeUnits = Models.RelativeTimeUnits.Days;

            $scope.getIsFormValidError = function () {
                

                var errorMessage : string = "";
                if ($scope.isRelativeTime()) {
                    var relativeTime = $scope.timeBasedImageSet.RelativeTime;

                    if (relativeTime.length != 2) {
                        return ""; 
                    }

                    if ($scope.timeBasedImageSet.RelativeTimeUnits == null || $scope.timeBasedImageSet.RelativeTimeUnits < 0 || $scope.timeBasedImageSet.RelativeTimeUnits > 6) {
                        return "Relative Time Units: Must not be empty";
                    }

                    if (!$.isNumeric(relativeTime[0])) {
                        return "Relative Time: Minimum must be a number from 0 to 9";
                    }

                    if (!$.isNumeric(relativeTime[1])) {
                        return "Relative Time: Maximum must be a number from 0 to 9";
                    }

                    if (relativeTime[0] > relativeTime[1]) {
                        return "Relative Time: Maximum must be greater than or equal to Minimum";
                    }
                }
                else {
                    var abstractPriorValue = $scope.timeBasedImageSet.AbstractPriorValue;

                    if (abstractPriorValue.length != 2) {
                        return "";
                    }

                    if (!$.isNumeric(abstractPriorValue[0])) {
                        return "Abstract Prior Value: Minimum must be -1 (oldest), or 1 to 9";
                    }

                    if (!$.isNumeric(abstractPriorValue[1])) {
                        return "Abstract Prior Value: Maximum must be -1 (oldest) or 1 to 9";
                    }

                    // 2nd value (-1) is always valid
                    if (abstractPriorValue[1] == -1) {
                        return "";
                    }

                    if (abstractPriorValue[0] == -1 && abstractPriorValue[1] != -1) {
                        return "Abstract Prior Value: if Minimum is -1 (oldest), then Maximum must be -1";
                    }

                    if (abstractPriorValue[0] > abstractPriorValue[1]) {
                        return "Abstract Prior Value: Maximum must be greater than or equal to Minimum";
                    }
                }
                return errorMessage;
            }

            $scope.isFormValid = function () {
                //return $scope.item.id != undefined && $scope.item.id.length != 0 &&
                //       $scope.item.action!=undefined && $scope.item.action.length !=0;
                var error : string = this.getIsFormValidError();

                return error.length == 0;
            }

            $scope.isRelativeTime = function() {

                var ret: boolean = ($scope.timeBasedImageSet.ImageSetSelectorCategory == Models.ImageSetSelectorCategory.RelativeTime);
                return ret;
            }

            $scope.dropDownChanged = function () {
                if ($scope.isRelativeTime()) {
                    $scope.oldAbstractPriorValue = $scope.timeBasedImageSet.AbstractPriorValue;
                    $scope.timeBasedImageSet.AbstractPriorValue = [];

                    $scope.timeBasedImageSet.RelativeTime = $scope.oldRelativeTime;
                    $scope.timeBasedImageSet.RelativeTimeUnits = $scope.oldRelativeTimeUnits;
                }
                else {
                    $scope.oldRelativeTime = $scope.timeBasedImageSet.RelativeTime;
                    $scope.oldRelativeTimeUnits = $scope.timeBasedImageSet.RelativeTimeUnits;

                    $scope.timeBasedImageSet.RelativeTime = [];
                    $scope.timeBasedImageSet.RelativeTimeUnits = -1;

                    $scope.timeBasedImageSet.AbstractPriorValue = $scope.oldAbstractPriorValue 
                }
            };

            $scope.ok = function () {               
                $modalInstance.close($scope.timeBasedImageSet);
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }     
            
            $scope.isMinimumRelativeValid = this.isMinimumRelativeValid.bind(this);
            $scope.isMaximumRelativeValid = this.isMaximumRelativeValid.bind(this);
            $scope.isMinimumAbstractValid = this.isMinimumAbstractValid.bind(this);
            $scope.isMaximumAbstractValid = this.isMaximumAbstractValid.bind(this); 
            $scope.isRelativeValid        = this.isRelativeValid.bind(this); 
            $scope.isAbstractValid        = this.isAbstractValid.bind(this); 
            
            $scope.getRelativeError = this.getRelativeError.bind(this);    
            $scope.getAbstractError = this.getAbstractError.bind(this);    
        }
        
        private isMinimumRelativeValid(): boolean {
            if (this._$scope.isRelativeTime()) {
                var relativeTime = this._$scope.timeBasedImageSet.RelativeTime;

                if (relativeTime.length != 2) {
                    return false;
                }

                if (this._$scope.timeBasedImageSet.RelativeTimeUnits == null || this._$scope.timeBasedImageSet.RelativeTimeUnits < 0 || this._$scope.timeBasedImageSet.RelativeTimeUnits > 6) {
                    return false;
                }

                if (!$.isNumeric(relativeTime[0])) {
                    return false;
                }

                //if (!$.isNumeric(relativeTime[1])) {
                //    return "Relative Time: Maximum must be a number from 0 to 9";
                //}

                if (relativeTime[0] > relativeTime[1]) {
                    return false;
                }
            }
            return true;
        } 
        
        private isMaximumRelativeValid(): boolean {
            if (this._$scope.isRelativeTime()) {
                var relativeTime = this._$scope.timeBasedImageSet.RelativeTime;

                if (!$.isNumeric(relativeTime[1])) {
                    return false;
                }
            }
            return true;
        }  

        private isRelativeValid(): boolean {
            return this.isMinimumRelativeValid() && this.isMaximumRelativeValid();
        }
        
        private getRelativeError(): string {
            if (this._$scope.isRelativeTime()) {
                var relativeTime = this._$scope.timeBasedImageSet.RelativeTime;

                if (relativeTime.length != 2) {
                    return "";
                }

                if (this._$scope.timeBasedImageSet.RelativeTimeUnits == null || this._$scope.timeBasedImageSet.RelativeTimeUnits < 0 || this._$scope.timeBasedImageSet.RelativeTimeUnits > 6) {
                    return "Must not be empty";
                }

                if (!$.isNumeric(relativeTime[0])) {
                    return "Must be a number from 0 to 9";
                }

                if (!$.isNumeric(relativeTime[1])) {
                    return "Maximum must be a number from 0 to 9";
                }

                if (relativeTime[0] > relativeTime[1]) {
                    return "Minimum must be less than or equal to Maximum";
                }
            }

            return "";
        }  

        
        private isMinimumAbstractValid(): boolean {
            if (this._$scope.isRelativeTime() == false) {
                var abstractPriorValue = this._$scope.timeBasedImageSet.AbstractPriorValue;

                if (abstractPriorValue.length != 2) {
                    return true;
                }

                if (!$.isNumeric(abstractPriorValue[0])) {
                    return false;
                }

                //if (!$.isNumeric(abstractPriorValue[1])) {
                //    return false;
                //}

                // 2nd value (-1) is always valid
                if (abstractPriorValue[1] == -1) {
                    return true;
                }

                if (abstractPriorValue[0] == -1 && abstractPriorValue[1] != -1) {
                    return false;
                }

                if (abstractPriorValue[0] > abstractPriorValue[1]) {
                    return false;
                }
            }

            return true;
        }   
        
        private isMaximumAbstractValid(): boolean {
            if (this._$scope.isRelativeTime() == false) {
                var abstractPriorValue = this._$scope.timeBasedImageSet.AbstractPriorValue;

                if (!$.isNumeric(abstractPriorValue[1])) {
                    return false;
                }

                if (abstractPriorValue[0] == -1 && abstractPriorValue[1] != -1) {
                    return false;
                }
            }

            return true;
        } 
        
        private isAbstractValid(): boolean {
            return this.isMinimumAbstractValid() && this.isMaximumAbstractValid();
        }    

        private getAbstractError(): string {
            if (this._$scope.isRelativeTime() == false) {
                var abstractPriorValue = this._$scope.timeBasedImageSet.AbstractPriorValue;

                if (abstractPriorValue.length != 2) {
                    return "";
                }

                if (!$.isNumeric(abstractPriorValue[0])) {
                    return "Minimum must be -1 (oldest), or 1 to 9";
                }

                if (!$.isNumeric(abstractPriorValue[1])) {
                    return "Maximum must be -1 (oldest) or 1 to 9";
                }

                // 2nd value (-1) is always valid
                if (abstractPriorValue[1] == -1) {
                    return "";
                }

                if (abstractPriorValue[0] == -1 && abstractPriorValue[1] != -1) {
                    return "If Minimum is -1 (oldest), then Maximum must be -1";
                }

                if (abstractPriorValue[0] > abstractPriorValue[1]) {
                    return "Minimum must be less than or equal to Maximum";
                }
            }

            return "";
        } 
 
    }
}