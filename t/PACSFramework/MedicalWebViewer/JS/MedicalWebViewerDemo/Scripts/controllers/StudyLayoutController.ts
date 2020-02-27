// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IStudyLayoutControllerScope extends ng.IScope {
        layout: any;
        customStudyLayoutOptions: Array<any>;

        templates: Array<Models.Template>;

        isFormValid(): boolean;

        isRowValid(): boolean;
        getIsRowValidError(): string;

        isColumnValid(): boolean;
        getIsColumnValidError(): string;

        doHideCustomLayouts(): boolean;

        ok();
        cancel();
    }

    export class StudyLayoutController {
        static $inject = ['$scope', 'optionsService', '$modalInstance', 'layout', 'templateService', 'dialogs', 'authenticationService'];

        private _$scope: ISeriesLayoutControllerScope;

        private _overlayManagerService: OverlayManagerService;

        private _optionsService: OptionsService;

        constructor($scope: IStudyLayoutControllerScope, optionsService: OptionsService, $modalInstance, layout, templateService: TemplateService, dialogs, authenticationService : AuthenticationService) {
            this._$scope = $scope;
            var index;

            this._optionsService = optionsService;

            $scope.customStudyLayoutOptions = this.GetLayoutFromXMLFile(0);
            $scope.layout = layout;
            if (layout.custom != null) {
                index = $scope.customStudyLayoutOptions.map(x => x.Text).indexOf(layout.custom);
                if (index != -1) {
                    $scope.layout.custom = $scope.customStudyLayoutOptions[index];
                }
            }

            $scope.ok = function () {
                $modalInstance.close($scope.layout);
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };

            $scope.isRowValid = this.isRowValid.bind(this);
            $scope.getIsRowValidError = this.getIsRowValidError.bind(this);

            $scope.isColumnValid = this.isColumnValid.bind(this);
            $scope.getIsColumnValidError = this.getIsColumnValidError.bind(this);

            $scope.doHideCustomLayouts = this.doHideCustomLayouts.bind(this);

            $scope.isFormValid = this.isFormValid.bind(this);

            if (authenticationService.hasPermission(PermissionNames.CanViewTemplates)) {
                templateService.GetAllTemplates().success(function (templates) {
                    var selectedTemplates: Array<Models.Template> = null;

                    if (layout.custom != null) {
                        var selectedTemplates: Array<Models.Template> = $.grep(templates, function (template: Models.Template, index: number) {
                            return template.Id == layout.custom;
                        });
                    }
                    else {
                        templates = $.grep(templates, function (template: Models.Template, index: number) {
                            return (template.Availability == Models.TemplateAvailability.Study || template.Availability == Models.TemplateAvailability.SeriesAndStudy);
                        });
                    }

                    $scope.templates = templates;
                    $scope.layout = {
                        rows: layout.rows,
                        columns: layout.columns,
                        custom: null
                    };

                    if (angular.isDefined(selectedTemplates) && selectedTemplates != null && selectedTemplates.length > 0) {
                        $scope.layout.custom = selectedTemplates[0];
                    }
                }.bind(this))
                    .error(function (error) {
                        dialogs.error(this._errorMesssage + ": " + error);
                    }.bind(this));
            }
        }

        private GetLayoutFromXMLFile(startIndex) {
            var request = new XMLHttpRequest();
            request.open('GET', 'StudyLayouts.xml', false);
            request.send();

            var xml = request.responseText;
            var doc = $.parseXML(xml);

            var layoutNode = doc.getElementsByTagName('Layout');

            var length = layoutNode.length - startIndex;
            var index = 0;
            var layout = [];

            var boxElement;
            var childIndex;
            var childsLength = 0;

            var attributes;            
            var icon;
            var text;

            for (; index < length; index++) {
                layout[index] = [];

                childsLength = layoutNode[index + startIndex].childElementCount;
                boxElement = layoutNode[index + startIndex].firstElementChild;
                attributes = layoutNode[index + startIndex].attributes;
                
                layout[index]["Icon"] = attributes.getNamedItem("icon").value;
                layout[index]["Text"] = attributes.getNamedItem("text").value;

                for (childIndex = 0; childIndex < childsLength; childIndex++) {
                    layout[index][childIndex] = this.stringArrayToFloatArray(boxElement.textContent);
                    boxElement = boxElement.nextElementSibling;
                }
            }
            return layout;
        }

        private stringArrayToFloatArray(text) {
            var array = text.split(',');

            if (array == null) {
                return null;
            }
            if (!array.length) {
                return null;
            }
            var index;
            var result = new Array(array.length);
            for (index = 0; index < array.length; index++) {
                result[index] = parseFloat(array[index]);
            }
            return result;
        }

        public doHideCustomLayouts(): boolean {
            var hideCustomLayouts: boolean = this._optionsService.get(OptionNames.HideCustomLayouts);

            if (hideCustomLayouts == null) {
                hideCustomLayouts = true;
            }

            return hideCustomLayouts;
        }

        public isRowValid(): boolean {

            var errorMessage: string = this.getIsRowValidError();
            return (errorMessage == "");
        }

        public getIsRowValidError(): string {

            if (!$.isNumeric(this._$scope.layout.rows)) {
                return "Must be numeric";
            }

            if (this._$scope.layout.rows <= 0) {
                return "Must be greater than 0";
            }

            return "";
        }


        public isColumnValid(): boolean {

            var errorMessage: string = this.getIsColumnValidError();
            return (errorMessage == "");
        }

        public getIsColumnValidError(): string {

            if (!$.isNumeric(this._$scope.layout.columns)) {
                return "Must be numeric";
            }

            if (this._$scope.layout.columns <= 0) {
                return "Must be greater than 0";
            }

            return "";
        }

        public isFormValid(): boolean {
            return this.isRowValid() && this.isColumnValid();
        }
    }
}