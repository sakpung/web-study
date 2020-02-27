// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IDSFilterOperationEditorControllerScope extends ng.IScope {
        operation: Models.FilterOperation;
        title: string;     
        tags: Array<Controllers.Tag>;  
        
        filterByOperatorList: Array<any>;      

        ok();
        cancel();

        getSelectorAttributeError(): string;
        isSelectorAttributeValid(): boolean;

        getSelectorValueError(): string;
        isSelectorValueValid(): boolean;

        isFormValid(): boolean; 
        isSequence(): boolean;   
        isMprPlane(): boolean;

        initializeFilterByOperatorList();
        isArrayNumeric(numbersArray: Array<string>, lengthToCheck: number): boolean;
        // verifyNumeric(selectorValue: string, lengthToCheck: number): string;
        verifyCount(selectorValue: string, requiredCount: number): string;
        verifyInequality(selectorValue: string, inclusive: boolean): string;

        chooseTag();
        editCodeSequence();

        isMprPlane(): boolean;

        isSelectorIndexValid(): boolean;
        getSelectorIndexError(): string;
    }    

    export class DSFilterOperationEditorController {
        static $inject = ['$scope', '$modal', '$modalInstance', 'item', 'title', 'dicom', 'currentTags'];

        private _$modal: any;       
        private _$scope: IDSFilterOperationEditorControllerScope;
        private _dicom: any;    
        private _currentTags: any; // : Array<string>;    

        constructor($scope: IDSFilterOperationEditorControllerScope, $modal, $modalInstance, item: Models.FilterOperation, title, dicom, currentTags: Array<string>) {
            $scope.operation = item;
            $scope.title = title;
            $scope.filterByOperatorList = [
                { "value": 6, "text": "Member Of" },
                { "value": 7, "text": "Not Member Of" },
            ];

            this._$scope = $scope;
            this._$modal = $modal;
            this._dicom = dicom;
            this._currentTags = currentTags;

            $scope.chooseTag = this.chooseTag.bind(this);
            $scope.isSequence = this.isSequence.bind(this);
            $scope.isMprPlane = this.isMprPlane.bind(this);
            $scope.editCodeSequence = this.editCodeSequence.bind(this);

            $scope.isFormValid = function () {
                return this.isSelectorValueValid() && this.isSelectorIndexValid();
            }

            $scope.initializeFilterByOperatorList = this.initializeFilterByOperatorList.bind(this);

            $scope.ok = function () {
                $modalInstance.close($scope.operation);
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }

            $scope.isMprPlane = function () {
                var isMprPlane: boolean = $scope.operation.FilterByCategory == "IMAGE_PLANE";
                return isMprPlane;
            }

            $scope.isSelectorAttributeValid = function () {
                var errorMessage: string = this.getSelectorAttributeError();
                return errorMessage.length == 0;
            }

            $scope.getSelectorAttributeError = function () {
                var errorMessage: string = "";
                var selectorAttribute = $scope.operation.WCFSelectorAttribute.trim();
                if (selectorAttribute.length == 0) {
                    errorMessage = "Value must not be empty.";
                }
                return errorMessage;
            }

            $scope.isSelectorValueValid = function () {
                var errorMessage: string = this.getSelectorValueError();
                return errorMessage.length == 0;
            }

            $scope.getSelectorValueError = function () {
                // Split into an array and remove the empty values
                var selectorValues: Array<string> = $scope.operation.SelectorValue.split("\\", 5).filter(function (el) { return el.length != 0 });
                var separatorCount: number = $scope.operation.SelectorValue.split("\\", 5).length - 1;
                var selectorValueCount: number = selectorValues.length;

                var errorMessage: string = "";
                switch ($scope.operation.FilterByOperator) {
                    case Models.FilterByOperator.RangeInclusive:
                        errorMessage = this.verifyCount($scope.operation.SelectorValue, 2);

                        if (errorMessage.length == 0) {
                            errorMessage = Utils.verifyNumeric($scope.operation.SelectorValue, 2);
                        }

                        if (errorMessage.length == 0) {
                            errorMessage = this.verifyInequality($scope.operation.SelectorValue, true);
                        }
                        break;

                    case Models.FilterByOperator.RangeExclusive:
                        errorMessage = this.verifyCount($scope.operation.SelectorValue, 2);

                        if (errorMessage.length == 0) {
                            errorMessage = Utils.verifyNumeric($scope.operation.SelectorValue, 2);
                        }

                        if (errorMessage.length == 0) {
                            errorMessage = this.verifyInequality($scope.operation.SelectorValue, false);
                        }
                        break;

                    case Models.FilterByOperator.GreaterOrEqual:
                        errorMessage = this.verifyCount($scope.operation.SelectorValue, 1);

                        if (errorMessage.length == 0) {
                            errorMessage = Utils.verifyNumeric($scope.operation.SelectorValue, 1);
                        }
                        break;

                    case Models.FilterByOperator.GreaterThan:
                        errorMessage = this.verifyCount($scope.operation.SelectorValue, 1);

                        if (errorMessage.length == 0) {
                            errorMessage = Utils.verifyNumeric($scope.operation.SelectorValue, 1);
                        }
                        break;

                    case Models.FilterByOperator.LessOrEqual:
                        errorMessage = this.verifyCount($scope.operation.SelectorValue, 1);

                        if (errorMessage.length == 0) {
                            errorMessage = Utils.verifyNumeric($scope.operation.SelectorValue, 1);
                        }
                        break;

                    case Models.FilterByOperator.LessThan:
                        errorMessage = this.verifyCount($scope.operation.SelectorValue, 1);

                        if (errorMessage.length == 0) {
                            errorMessage = Utils.verifyNumeric($scope.operation.SelectorValue, 1);
                        }
                        break;

                    case Models.FilterByOperator.MemberOf:
                        errorMessage = this.verifyCount($scope.operation.SelectorValue, 0);
                        break;

                    case Models.FilterByOperator.NotMemberOf:
                        errorMessage = this.verifyCount($scope.operation.SelectorValue, 0);
                        break;
                }

                if (errorMessage.length == 0) {
                    // Test if VR is numeric
                    if (Utils.isNumericVr($scope.operation.SelectorAttributeVr))
                        errorMessage = Utils.verifyNumeric($scope.operation.SelectorValue, 0);
                }


                return errorMessage;
            }

            $scope.verifyCount = this.verifyCount.bind(this);  

            $scope.verifyInequality = this.verifyInequality.bind(this);  

            $scope.isSelectorIndexValid = this.isSelectorIndexValid.bind(this);   
            $scope.getSelectorIndexError = this.getSelectorIndexError.bind(this); 

            this.initializeFilterByOperatorList();     

        }

        private verifyInequality(selectorValue: string, inclusive: boolean): string {
            var errorMessage: string = "";

            var selectorValues: Array<string> = selectorValue.split("\\", 5).filter(function (el) { return el.length != 0 });

            if (selectorValues.length != 2) {
                errorMessage = "Must have exactly two values. (Example: 1\\3)";
            }

            var number0: number = parseFloat(selectorValues[0]);
            if (isNaN(number0)) {
                errorMessage = "First value is not a number.";
                return errorMessage;
            }

            var number1: number = parseFloat(selectorValues[1]);
            if (isNaN(number1)) {
                errorMessage = "Second value is not a number.";
                return errorMessage;
            }

            if (inclusive) {
                // inclusive
                if (number0 > number1) {
                    errorMessage = "First value must be less than or equal to Second value. (Example: 1\\3)";
                }
            }
            else {
                // exclusive
                if (number0 >= number1) {
                    errorMessage = "First value must be less than Second value. (Example: 1\\3)";
                }
            }
            return errorMessage;
        }

        private verifyCount(selectorValue: string, requiredCount: number): string {
            return Utils.verifySelectorCount(selectorValue, requiredCount);
        }
        
        private initializeFilterByOperatorList () {
            if (this.isMprPlane() || !Utils.isNumericVr(this._$scope.operation.SelectorAttributeVr) ){
                // this._$scope.operation.ImagePlaneSelectorValue = "TRANSVERSE";


                this._$scope.filterByOperatorList = [
                    { "value": 6, "text": "Member Of" },
                    { "value": 7, "text": "Not Member Of" },
                ];
            }
            else {
                // this._$scope.operation.ImagePlaneSelectorValue = "";

                this._$scope.filterByOperatorList = [
                    { "value": 0, "text": "Range Inclusive" },
                    { "value": 1, "text": "Range Exclusive" },
                    { "value": 2, "text": "Greater Or Equal" },
                    { "value": 3, "text": "Less Or Equal" },
                    { "value": 4, "text": "Greater Than" },
                    { "value": 5, "text": "Less Than" },
                    { "value": 6, "text": "Member Of" },
                    { "value": 7, "text": "Not Member Of" },
                ];
            }
        }       

        private chooseTag() {
            var self = this;

            var modalInstance = this._$modal.open({
                templateUrl: 'views/dialogs/TagChooserDialog.html',
                controller: Controllers.TagChooserController,
                backdrop: 'static',
                resolve: {
                    dicom: function () {
                        return self._dicom;
                    },
                    selector: function () {
                        return self._$scope.operation;
                    },
                    currentTags: function () {
                        return self._currentTags;
                    }
                }                 
            });

            modalInstance.result.then(function (tag: Models.DicomData) {
                var isSameTag: boolean = (tag.tag == self._$scope.operation.WCFSelectorAttribute);
                if (isSameTag) {
                    if (tag.hasOwnProperty('selectorSequencePointerItems')) {
                        isSameTag = (self._$scope.operation.WCFSelectorSequencePointerItems == tag['selectorSequencePointerItems']);
                    }
                }

                if (!isSameTag) {
                    self._$scope.operation.SelectorName = tag.name;
                    self._$scope.operation.WCFSelectorAttribute = tag.tag;

                    if (!tag['isCodeSequence']) {
                        self._$scope.operation.SelectorValue = tag.value;
                        self._$scope.operation.SelectorAttributeVr = tag.vr;
                        self._$scope.operation.SelectorCodeSequenceValue = undefined;

                        if (tag['selectorSequencePointer']) {
                            self._$scope.operation.WCFSelectorSequencePointer = tag['selectorSequencePointer'];
                            self._$scope.operation['SequencePointerName'] = tag['sequencePointerName'];
                            self._$scope.operation.WCFSelectorSequencePointerItems = tag['selectorSequencePointerItems'];
                        }
                        else {
                            self._$scope.operation.WCFSelectorSequencePointer = '';
                            delete self._$scope.operation['SequencePointerName'];
                        }
                    }
                    else {
                        self._$scope.operation.WCFSelectorSequencePointer = tag['selectorSequencePointer']; //'';
                        self._$scope.operation.WCFSelectorSequencePointerItems = tag['selectorSequencePointerItems'];
                        var tagList = tag['selectorSequencePointer'];
                        var itemList = tag['selectorSequencePointerItems'];

                        self._$scope.operation.SelectorCodeSequenceValue = DicomHelper.getCodeSequenceList(self._dicom, tagList, itemList);
                        if (self._$scope.operation.SelectorCodeSequenceValue && self._$scope.operation.SelectorCodeSequenceValue.length > 0) {
                            self._$scope.operation.SelectorValue = self._$scope.operation.SelectorCodeSequenceValue[0].toFullString();
                        }
                        else {
                            self._$scope.operation.SelectorValue = '';
                        }
                    }
                    self._$scope.initializeFilterByOperatorList();
                }                         
            });
        }

        private isSequence(): boolean {
            return this._$scope.operation.SelectorCodeSequenceValue && this._$scope.operation.SelectorCodeSequenceValue.length > 0;
        }

        private isMprPlane(): boolean {
            return (this._$scope.operation.FilterByCategory != null) && (this._$scope.operation.FilterByCategory == "IMAGE_PLANE");
        }

        private editCodeSequence() {
            var self = this;

            var modalInstance = this._$modal.open({
                templateUrl: 'views/dialogs/CodeSequenceEditor.html',
                controller: Controllers.CodeSequenceEditorController,
                backdrop: 'static',
                resolve: {
                    item: function () {
                        return angular.copy(self._$scope.operation.SelectorCodeSequenceValue[0]);
                    },
                    title: function () {
                        return "Edit Code Sequence";
                    }
                }
            });

            modalInstance.result.then(function (codeSequence: Models.CodeSequence) {
                var diff = Utils.diff(self._$scope.operation.SelectorCodeSequenceValue[0], codeSequence);

                if (diff.changed != "equal") {
                    self._$scope.operation.SelectorCodeSequenceValue = new Array<Models.CodeSequence>();
                    self._$scope.operation.SelectorCodeSequenceValue.push(codeSequence);
                    self._$scope.operation.SelectorValue = self._$scope.operation.SelectorCodeSequenceValue[0].toFullString();
                }
            });
        }

        private isSelectorIndexValid(): boolean {
            if (!$.isNumeric(this._$scope.operation.SelectorValueNumber)) {
                return false;
            }

            if (this._$scope.operation.SelectorValueNumber < 0 || this._$scope.operation.SelectorValueNumber > 9)
                return false;

            return true;
        }

        private getSelectorIndexError(): string {
            var valid =
                        $.isNumeric(this._$scope.operation.SelectorValueNumber) &&
                        (this._$scope.operation.SelectorValueNumber >= 0 && this._$scope.operation.SelectorValueNumber <= 9);
            if (!valid)
                return "Must be 0 through 9.";

            return "";
        }       
    }
}