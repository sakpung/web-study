// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IHPImageSetSelectorEditorControllerScope extends ng.IScope {
        selector: Models.ImageSetSelector;
        title: string;     
        tags: Array<Controllers.Tag>;        

        ok();
        cancel();

        getSelectorAttributeError(): string;
        isSelectorAttributeValid(): boolean;

        getSelectorValueError(): string;
        isSelectorValueValid(): boolean;

        isFormValid(): boolean;
        isSequence(): boolean;   

        chooseTag();
        editCodeSequence();

        isSelectorIndexValid(): boolean;
        getSelectorIndexError(): string;
    }    

    export class HPImageSetSelectorEditorController {
        static $inject = ['$scope', '$modal', '$modalInstance', 'item', 'title', 'dicom', 'currentTags'];

        private _$modal: any;       
        private _$scope: IHPImageSetSelectorEditorControllerScope;
        private _dicom: any;  
        private _currentTags: Array<string>;      

        constructor($scope: IHPImageSetSelectorEditorControllerScope, $modal, $modalInstance, item: Models.ImageSetSelector, title, dicom, currentTags:Array<string>) {                                    
            $scope.selector = item;
            $scope.title = title;            
            
            this._$scope = $scope;  
            this._$modal = $modal; 
            this._dicom = dicom;  
            this._currentTags = currentTags;          

            $scope.chooseTag = this.chooseTag.bind(this);
            $scope.isSequence = this.isSequence.bind(this);
            $scope.editCodeSequence = this.editCodeSequence.bind(this);

            $scope.isFormValid = function () {
                var valid: boolean = this.isSelectorIndexValid() && this.isSelectorValueValid();
                return valid;
            }

            $scope.ok = function () {               
                $modalInstance.close($scope.selector);
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }    
            
            $scope.isSelectorAttributeValid = function () {
                var errorMessage: string = this.getSelectorAttributeError();
                return errorMessage.length == 0;
            }

            $scope.getSelectorAttributeError = function () {
                var errorMessage: string = "";
                var selectorAttribute = $scope.selector.WCFSelectorAttribute.trim();
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
                var selectorValues: Array<string> = $scope.selector.SelectorValue.split("\\", 5).filter(function (el) { return el.length != 0 });
                var separatorCount: number = $scope.selector.SelectorValue.split("\\", 5).length - 1;
                var selectorValueCount: number = selectorValues.length;


                var errorMessage: string = Utils.verifySelectorCount($scope.selector.SelectorValue, 0);

                if (errorMessage.length == 0) {
                    // Test if VR is numeric
                    if (Utils.isNumericVr($scope.selector.SelectorAttributeVr))
                        errorMessage = Utils.verifyNumeric($scope.selector.SelectorValue, 0);
                }

                return errorMessage;
            } 
            
            $scope.isSelectorIndexValid = this.isSelectorIndexValid.bind(this);    
            $scope.getSelectorIndexError = this.getSelectorIndexError.bind(this);         
        }   
        
        private isSelectorIndexValid(): boolean {
            if (!$.isNumeric(this._$scope.selector.SelectorValueNumber)) {
                return false;
            }

            if (this._$scope.selector.SelectorValueNumber < 0 || this._$scope.selector.SelectorValueNumber > 9)
                return false;

            return true;
        } 
        
        private getSelectorIndexError(): string {
            if (!$.isNumeric(this._$scope.selector.SelectorValueNumber)) {
                return "Must be 0 through 9.";
            }
            return "";
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
                        return self._$scope.selector;
                    },
                    currentTags: function () {
                        return self._currentTags;
                    }
                }                 
            });

            modalInstance.result.then(function (tag: Models.DicomData) {

                var isSameTag: boolean = (tag.tag == self._$scope.selector.WCFSelectorAttribute);

                // Commented out because Models.ImageSetSelector does not have a 'WCFSelectorSequencePointerItems' property
                //if (isSameTag) {
                //    if (tag.hasOwnProperty('selectorSequencePointerItems')) {
                //        isSameTag = (self._$scope.selector.WCFSelectorSequencePointerItems == tag['selectorSequencePointerItems']);
                //    }
                //}

                if (!isSameTag) {
                    if (!tag['isCodeSequence']) {
                        self._$scope.selector.WCFSelectorAttribute = tag.tag;
                        self._$scope.selector.SelectorValue = tag.value;
                        self._$scope.selector.SelectorName = tag.name;
                        self._$scope.selector.SelectorAttributeVr = tag.vr;
                        self._$scope.selector.SelectorCodeSequenceValue = undefined;

                        if (tag['selectorSequencePointer']) {
                            self._$scope.selector.WCFSelectorSequencePointer = tag['selectorSequencePointer'];
                            self._$scope.selector['SequencePointerName'] = tag['sequencePointerName'];
                        }
                        else {
                            self._$scope.selector.WCFSelectorSequencePointer = '';
                            delete self._$scope.selector['SequencePointerName'];
                        }
                    }
                    else {          
                        self._$scope.selector.WCFSelectorSequencePointer = '';              
                        self._$scope.selector.WCFSelectorAttribute = tag.tag;                                              
                        self._$scope.selector.SelectorName = tag.name;
                        self._$scope.selector.SelectorCodeSequenceValue = DicomHelper.getCodeSequenceList(self._dicom, tag.tag.replace(':', ''), null);
                        if (self._$scope.selector.SelectorCodeSequenceValue && self._$scope.selector.SelectorCodeSequenceValue.length > 0) {
                            self._$scope.selector.SelectorValue = self._$scope.selector.SelectorCodeSequenceValue[0].toFullString();
                        }
                        else {
                            self._$scope.selector.SelectorValue = '';                            
                        }                       
                    }
                }             
            });
        }

        private isSequence(): boolean {
            return this._$scope.selector.SelectorCodeSequenceValue && this._$scope.selector.SelectorCodeSequenceValue.length > 0;
        }

        private editCodeSequence() {
            var self = this;

            var modalInstance = this._$modal.open({
                templateUrl: 'views/dialogs/CodeSequenceEditor.html',
                controller: Controllers.CodeSequenceEditorController,
                backdrop: 'static',
                resolve: {
                    item: function () {
                        return angular.copy(self._$scope.selector.SelectorCodeSequenceValue[0]);
                    },
                    title: function () {
                        return "Edit Code Sequence";
                    }                    
                }
            });

            modalInstance.result.then(function (codeSequence: Models.CodeSequence) {
                var diff = Utils.diff(self._$scope.selector.SelectorCodeSequenceValue[0], codeSequence);

                if (diff.changed != "equal") {
                    self._$scope.selector.SelectorCodeSequenceValue = new Array<Models.CodeSequence>();
                    self._$scope.selector.SelectorCodeSequenceValue.push(codeSequence);
                }
            });
        }
    }
}