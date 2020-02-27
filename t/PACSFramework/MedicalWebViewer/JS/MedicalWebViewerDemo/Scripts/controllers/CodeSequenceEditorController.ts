// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface ICodeSequenceEditorControllerScope extends ng.IScope {
        item: Models.CodeSequence;
        title: string;
               
        ok();
        cancel();

        isCodeValueValid(): boolean;
        getCodeValueError(): string;

        isCodeSchemeDesignatorValid(): boolean;
        getCodeSchemeDesignatorError(): string;

        isCodeMeaningValid(): boolean;
        getCodeMeaningError(): string;

        isFormValid(): boolean;        
    }

    export class CodeSequenceEditorController {
        static $inject = ['$scope', '$modalInstance','item', 'title'];        

        constructor($scope: ICodeSequenceEditorControllerScope, $modalInstance, item, title) {           
            $scope.item = item || new Models.CodeSequence();
            $scope.title = title;                       

            $scope.isFormValid = function () {
                var valid: boolean = $scope.isCodeValueValid() && $scope.isCodeSchemeDesignatorValid() && $scope.isCodeMeaningValid();
                return valid;
            }

            $scope.isCodeValueValid = function () : boolean {
                var errorMessage: string = $scope.getCodeValueError();
                return errorMessage.length == 0;
            }

            // SH -- short string (16 characters)
            $scope.getCodeValueError = function (): string {
                var errorMessage: string = "";
                var codeValue: string = $scope.item.CodeValue.trim();
                if (codeValue.length == 0) {
                    errorMessage = "Value must not be empty.";
                }
                if (codeValue.length > 16) {
                    errorMessage = "Must be less than 16 characters.";
                }
                return errorMessage;
            }

            $scope.isCodeSchemeDesignatorValid = function (): boolean {
                var errorMessage: string = $scope.getCodeSchemeDesignatorError();
                return errorMessage.length == 0;
            }

            // SH -- short string (16 characters)
            $scope.getCodeSchemeDesignatorError = function (): string {
                var errorMessage: string = "";
                var codeSchemeDesignator: string = $scope.item.CodeSchemeDesignator.trim();
                if (codeSchemeDesignator.length > 16) {
                    errorMessage = "Must be less than 16 characters.";
                }
                return errorMessage;
            }

            $scope.isCodeMeaningValid = function (): boolean {
                var errorMessage: string = $scope.getCodeMeaningError();
                return errorMessage.length == 0;
            }

            // LO -- long string (64 characters)
            $scope.getCodeMeaningError = function (): string {
                var errorMessage: string = "";
                var codeMeaning: string = $scope.item.CodeMeaning.trim();
                if (codeMeaning.length > 64) {
                    errorMessage = "Must be less than 64 characters.";
                }
                return errorMessage;
            }


            $scope.ok = function () {
                $modalInstance.close($scope.item);
            }           

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }
        }
    }
}