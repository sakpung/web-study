// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {

    export interface IHPDialogControllerScope extends ng.IScope {
        steps: Array<any>;
        hp: Models.HangingProtocol;
        objectStoreService: ObjectStoreService;
        selectedRole: Models.Role;
        roles: Array<Models.Role>;
        modalities: Array<string>;
        selectedDisplaySet: Models.DisplaySet;
        selectedImageSet: Models.ImageSet;
        selectedTimeBasedImageSet: Models.TimeBasedImageSet;

        HPImageSetOptions: any;
        HPImageSetSelectorOptions: any;
        HPTimeBasedImageSetsOptions: any;
        DSFilterOperationsOptions: any;
        PCSOptions: any;
        RFROptions: any;
        ARSOptions: any;
        HPPDOptions: any;

        onStepChange();

        selectedRoleChanged();
        selectedLevelChanged();

        editHPDefinition();
        deleteHPDefinition();
        isHPDefinitionSelected(): boolean;

        addImageSetSelector();
        editImageSetSelector();
        deleteImageSetSelector();
        isImageSetSelectorSelected(): boolean;

        editTimeBasedImageSets();
        isTimeBasedImageSetsSelected(): boolean;

        addFilterOperation();
        editFilterOperation();
        mergeFilterOperation();
        cloneFilterOperation();
        canMergeFilterOperation();
        deleteFilterOperation();
        deleteSimilarFilterOperations();
        isFilterOperationSelected(): boolean;

        // ****
        isHangingProtocolNameValid(): boolean;
        getHangingProtocolNameError(): string;
        isHangingProtocolDescriptionValid(): boolean;
        isLevelUserGroup(): boolean;
        getHangingProtocolDescriptionError(): string;
        isFormValid(): boolean; 
        // ****

        editImageSetLabel();
        editDisplaySetLabel();

        addMultipleTags();
        addMulitipleImageSetTags();

        selectedDisplaySetChanged(displaySet: Models.DisplaySet);
        selectedImageSetChanged(imageSet: Models.ImageSet);
        // selectedTimeBasedImageSetChanged(timeBasedImageSet: Models.TimeBasedImageSet);


        filterByImageSetNumber();
        falseFunction(): boolean;
        trueFunction(): boolean;

        saveHangingProtocol(): void;

        getButtonStyle(): string;

        isAdmin(): boolean;
        hangingProtocolLevelOptions: Array<Models.DropDownItem>;
        setHangingProtocolLevelOptions(): Array<Models.DropDownItem>;
    }

    export class Tag {
        public name: string;
        public code: string;

        constructor(name: string, code: string) {
            this.name = name;
            this.code = code;
        }
    }

    export class HPDialogControllerScope {
        static $inject = ["$scope", "$modalInstance", "$translate", 'authenticationService', 'dataset', '$modal', 'hp', 'objectStoreService', 'dialogs'];

        private _$modal: any;
        private _$scope: IHPDialogControllerScope;
        private _dataset: any;
        private _$translate: any;
        private _dialogs: any;
        private _tags: Array<Tag>;
        private _multiStepFormInstance: any;
        private _activeStepIndex = -1;

        constructor($scope: IHPDialogControllerScope, $modalInstance, $translate, authenticationService: AuthenticationService, dataset, $modal, hp: Models.HangingProtocol, objectStoreService: ObjectStoreService, dialogs) {
            var self: HPDialogControllerScope = this;

            $scope.steps = new Array<any>(
                {
                    templateUrl: 'views/dialogs/HangingProtocol-Step1.html',
                    title: 'Definition'
                },
                {
                    templateUrl: 'views/dialogs/HangingProtocol-Step2.html',
                    title: 'Selection Criteria'
                },
                {
                    templateUrl: 'views/dialogs/HangingProtocol-Step3.html',
                    title: 'Image/Series Selection'
                }
                ,
                {
                    templateUrl: 'views/dialogs/HangingProtocol-Step4.html',
                    title: 'Display Sets'
                }
            );

            this._$modal = $modal;
            this._$scope = $scope;
            this._dataset = dataset;
            this._$translate = $translate;
            this._dialogs = dialogs;

            $scope.selectedDisplaySetChanged = this.selectedDisplaySetChanged.bind(this);
            $scope.selectedImageSetChanged = this.selectedImageSetChanged.bind(this);
            // $scope.selectedTimeBasedImageSetChanged = this.selectedTimeBasedImageSetChanged.bind(this);

            authenticationService.getRoles().
                success(function (result) {
                    $scope.roles = result.GetRolesResult;

                    if ($scope.roles != null && $scope.roles.length > 0) {
                        $scope.selectedRole = $scope.roles[0];
                        $scope.hp.HangingProtocolUserGroupName = $scope.selectedRole.Name;
                    }
                }).
                error(function (error) {
                });

            $scope.hp = hp;
            $scope.objectStoreService = objectStoreService;

            this.init_HangingProtocolDefinitionGrid($scope);
            this.init_ImageSetSelectorGrid($scope);
            this.init_TimeBasedImageSetSelectorGrid($scope);
            this.init_FilterOperationsGrid($scope);

            $scope.selectedRoleChanged = this.selectedRoleChanged.bind(this);
            $scope.selectedLevelChanged = this.selectedLevelChanged.bind(this);

            $scope.editHPDefinition = this.editHPDefinition.bind(this);
            $scope.deleteHPDefinition = this.deleteHPDefinition.bind(this);
            $scope.isHPDefinitionSelected = this.isHPDefinitionSelected.bind(this);

            $scope.addImageSetSelector = this.addImageSetSelector.bind(this);
            $scope.editImageSetSelector = this.editImageSetSelector.bind(this);
            $scope.deleteImageSetSelector = this.deleteImageSetSelector.bind(this);
            $scope.isImageSetSelectorSelected = this.isImageSetSelectorSelected.bind(this);

            $scope.editTimeBasedImageSets = this.editTimeBasedImageSets.bind(this);
            $scope.isTimeBasedImageSetsSelected = this.isTimeBasedImageSetsSelected.bind(this);

            $scope.addFilterOperation = this.addFilterOperation.bind(this);
            $scope.editFilterOperation = this.editFilterOperation.bind(this);
            $scope.mergeFilterOperation = this.mergeFilterOperation.bind(this);
            $scope.cloneFilterOperation = this.cloneFilterOperation.bind(this);
            $scope.canMergeFilterOperation = this.canMergeFilterOperation.bind(this);
            $scope.deleteFilterOperation = this.deleteFilterOperation.bind(this);
            $scope.deleteSimilarFilterOperations = this.deleteSimilarFilterOperations.bind(this);
            $scope.isFilterOperationSelected = this.isFilterOperationSelected.bind(this);

            // ****
            $scope.isHangingProtocolNameValid = this.isHangingProtocolNameValid.bind(this);
            $scope.getHangingProtocolNameError = this.getHangingProtocolNameError.bind(this);
            $scope.isHangingProtocolDescriptionValid = this.isHangingProtocolDescriptionValid.bind(this);
            $scope.isLevelUserGroup = this.isLevelUserGroup.bind(this);
            $scope.getHangingProtocolDescriptionError = this.getHangingProtocolDescriptionError.bind(this);
            $scope.isFormValid = this.isFormValid.bind(this);
            // ****

            $scope.addMultipleTags = this.addMultipleTags.bind(this);
            $scope.addMulitipleImageSetTags = this.addMulitipleImageSetTags.bind(this);

            $scope.editImageSetLabel = this.editImageSetLabel.bind(this);
            $scope.editDisplaySetLabel = this.editDisplaySetLabel.bind(this);

            $scope.falseFunction = this.falseFunction.bind(this);
            $scope.trueFunction = this.trueFunction.bind(this);
            $scope.saveHangingProtocol = this.saveHangingProtocol.bind(this);

            $scope.getButtonStyle = this.getButtonStyle.bind(this);

            $scope.isAdmin = function (): boolean {
                return authenticationService.permissions.isAdmin;
            }

            // Fills the dropdown for HangingProtocolOptions (i.e. Manufacturer, Site, UserGroup, SingleUser)
            this.setHangingProtocolLevelOptions();

            $scope.modalities = Utils.get_Modalities();

            if (hp.DisplaySets.length > 0) {
                this.selectedDisplaySetChanged(hp.DisplaySets[0]);
            }

            if (hp.ImageSetsSequence.length > 0) {
                this.selectedImageSetChanged(hp.ImageSetsSequence[0]);

                //if (hp.ImageSetsSequence[0].TimeBasedImageSetsSequence.length > 0) {
                //    this.selectedTimeBasedImageSetChanged(hp.ImageSetsSequence[0].TimeBasedImageSetsSequence[0]);
                // }
            }

            $scope.onStepChange = function () {
                var cell: lt.Controls.Medical.Cell = self._$scope.selectedDisplaySet['cell'];

                self._activeStepIndex = this.$getActiveIndex();
                if (self._activeStepIndex == 4) {
                    cell.viewer.layout.highlightedItems.add(cell);
                }
                else
                    cell.viewer.layout.highlightedItems.clear();
            };

            $scope.filterByImageSetNumber = function () {
                return function (displaySet: Models.DisplaySet) {
                    return displaySet.ImageSetNumber != -1;
                }
            };
        }

        private selectedLevelChanged() {
        }

        private selectedRoleChanged(selectedRole : Models.Role) {
            var myHp = this._$scope.hp;
            myHp.HangingProtocolUserGroupName = selectedRole.Name;
        }

        private editHPDefinition() {
            var modalInstance;
            var self = this;
            var originalDefinition: Models.HangingProtocolDefinition;

            modalInstance = this._$modal.open({
                templateUrl: 'views/dialogs/HangingProtocolDefinitionSequence.html',
                controller: Controllers.HPDefinitionSequenceDialogControllerScope,
                backdrop: 'static',
                resolve: {
                    hpDefinition: function () {
                        var nodes: Array<any> = self._$scope.HPPDOptions.api.getSelectedNodes()

                        if (nodes.length > 0) {
                            originalDefinition = nodes[0].data;

                            return angular.copy(originalDefinition);
                        }

                        return null;
                    },
                    dataset: function () {
                        return self._dataset;
                    }
                }
            });

            modalInstance.result.then(function (hpDefinition: Models.HangingProtocolDefinition) {
                var diff = Utils.diff(originalDefinition, hpDefinition)

                if (diff.changed != "equal") {
                    var index = self._$scope.HPPDOptions.rowData.indexOf(originalDefinition);

                    if (index != -1) {
                        self._$scope.HPPDOptions.rowData[index] = hpDefinition;
                        self._$scope.HPPDOptions.api.setRowData(self._$scope.HPPDOptions.rowData);
                        self._$scope.HPPDOptions.api.selectIndex(index);
                    }
                }
            });
        }

        private deleteHPDefinition() {
            var nodes: Array<any> = this._$scope.HPPDOptions.api.getSelectedNodes()

            if (nodes.length > 0) {
                var index: number = this._$scope.HPPDOptions.rowData.indexOf(nodes[0].data);

                this._$scope.HPPDOptions.rowData.splice(index, 1);
                this._$scope.HPPDOptions.api.setRowData(this._$scope.HPPDOptions.rowData);
            }
        }

        private isHPDefinitionSelected(): boolean {
            return angular.isDefined(this._$scope.HPPDOptions.api) && this._$scope.HPPDOptions.api.getSelectedNodes().length > 0;
        }

        private addImageSetSelector() {
            var self = this;

            this._$translate('DIALOGS_IMAGESET_SELECTOR_ADD_TITLE').then(function (translation) {
                var modalInstance = this._$modal.open({
                    templateUrl: 'views/dialogs/HPImageSetSelectorEditor.html',
                    controller: Controllers.HPImageSetSelectorEditorController,
                    backdrop: 'static',
                    resolve: {
                        item: function () {
                            var selector: Models.ImageSetSelector = new Models.ImageSetSelector();

                            selector.SelectorValueNumber = 1;
                            selector.ImageSetSelectorUsageFlag = Models.ImageSetSelectorUsage.NoMatch;
                            return selector;
                        },
                        title: function () {
                            return translation;
                        },
                        dicom: function () {
                            return self._$scope.selectedImageSet['metadata'];
                        },
                        currentTags: function () {
                            return self.get_currentSelectorTags();
                        }
                    }
                });

                modalInstance.result.then(function (item: Models.ImageSetSelector) {
                    if (!self._$scope.HPImageSetSelectorOptions.rowData) {
                        self._$scope.HPImageSetSelectorOptions.rowData = [];
                    }

                    self._$scope.HPImageSetSelectorOptions.rowData.push(item);
                    self._$scope.HPImageSetSelectorOptions.api.onNewRows();
                    self._$scope.HPImageSetSelectorOptions.api.selectIndex(self._$scope.HPImageSetSelectorOptions.rowData.indexOf(item));
                });

            }.bind(this));
        }

        private editImageSetSelector() {
            var self = this;
            var originalSelector: Models.ImageSetSelector;            

            this._$translate('DIALOGS_IMAGESET_SELECTOR_EDIT_TITLE').then(function (translation) {
                var modalInstance = this._$modal.open({
                    templateUrl: 'views/dialogs/HPImageSetSelectorEditor.html',
                    controller: Controllers.HPImageSetSelectorEditorController,
                    backdrop: 'static',
                    resolve: {
                        item: function () {
                            var nodes: Array<any> = self._$scope.HPImageSetSelectorOptions.api.getSelectedNodes();
                            
                            originalSelector = nodes[0].data;
                            return angular.copy(originalSelector);
                        },
                        title: function () {
                            return translation;
                        },
                        dicom: function () {
                            return self._$scope.selectedImageSet['metadata'];
                        },
                        currentTags: function () {
                            return self.get_currentSelectorTags();
                        }
                    }
                });

                modalInstance.result.then(function (item: Models.ImageSetSelector) {
                    var diff = Utils.diff(originalSelector, item);

                    if (diff.changed != "equal") {
                        var index = self._$scope.HPImageSetSelectorOptions.rowData.indexOf(originalSelector);

                        if (index != -1) {
                            self._$scope.HPImageSetSelectorOptions.rowData[index] = item;
                            self._$scope.HPImageSetSelectorOptions.api.setRowData(self._$scope.HPImageSetSelectorOptions.rowData);
                            self._$scope.HPImageSetSelectorOptions.api.selectIndex(index);
                        }
                    }
                });

            }.bind(this));
        }

        private editTimeBasedImageSets() {
            var self = this;
            var originalTimeBasedImageSet: Models.TimeBasedImageSet;

            this._$translate('DIALOGS_TIME_BASED_IMAGE_SETS_EDIT_TITLE').then(function (translation) {
                var modalInstance = this._$modal.open({
                    templateUrl: 'views/dialogs/HPTimeBasedImageSetsEditor.html',
                    controller: Controllers.HPTimeBasedImageSetsEditorController,
                    backdrop: 'static',
                    resolve: {
                        item: function () {
                            var nodes: Array<any> = self._$scope.HPTimeBasedImageSetsOptions.api.getSelectedNodes();

                            originalTimeBasedImageSet = nodes[0].data;
                            return angular.copy(originalTimeBasedImageSet);
                        },
                        title: function () {
                            return translation;
                        }
                    }
                });

                modalInstance.result.then(function (item: Models.ImageSetSelector) {
                    var diff = Utils.diff(originalTimeBasedImageSet, item);

                    if (diff.changed != "equal") {
                        var index = self._$scope.HPTimeBasedImageSetsOptions.rowData.indexOf(originalTimeBasedImageSet);

                        if (index != -1) {
                            self._$scope.HPTimeBasedImageSetsOptions.rowData[index] = item;
                            self._$scope.HPTimeBasedImageSetsOptions.api.setRowData(self._$scope.HPTimeBasedImageSetsOptions.rowData);
                            self._$scope.HPTimeBasedImageSetsOptions.api.selectIndex(index);
                        }
                    }
                });

            }.bind(this));
        }

        private deleteImageSetSelector() {
            var nodes: Array<any> = this._$scope.HPImageSetSelectorOptions.api.getSelectedNodes()

            if (nodes.length > 0) {
                var index: number = this._$scope.HPImageSetSelectorOptions.rowData.indexOf(nodes[0].data);

                this._$scope.HPImageSetSelectorOptions.rowData.splice(index, 1);
                this._$scope.HPImageSetSelectorOptions.api.setRowData(this._$scope.HPImageSetSelectorOptions.rowData);
            }
        }

        private isImageSetSelectorSelected(): boolean {
            return angular.isDefined(this._$scope.HPImageSetSelectorOptions.api) && this._$scope.HPImageSetSelectorOptions.api.getSelectedNodes().length > 0;
        }

        private isTimeBasedImageSetsSelected(): boolean {
            return angular.isDefined(this._$scope.HPTimeBasedImageSetsOptions.api) && this._$scope.HPTimeBasedImageSetsOptions.api.getSelectedNodes().length > 0;
        }

        private addFilterOperation() {
            var self = this;

            this._$translate('DIALOGS_FILTER_OPERATION_ADD_TITLE').then(function (translation) {
                var modalInstance = this._$modal.open({
                    templateUrl: 'views/dialogs/DSFilterOperationEditor.html',
                    controller: Controllers.DSFilterOperationEditorController,
                    backdrop: 'static',
                    resolve: {
                        item: function () {
                            var operation: Models.FilterOperation = new Models.FilterOperation();

                            operation.SelectorValueNumber = 1;
                            operation.FilterByOperator = Models.FilterByOperator.MemberOf;
                            return operation;
                        },
                        title: function () {
                            return translation;
                        },
                        dicom: function () {
                            return self._$scope.selectedDisplaySet['metadata'];
                        },
                        currentTags: function () {
                            return self.get_currentFilterOperationTags();
                        }
                    }
                });

                modalInstance.result.then(function (item: Models.FilterOperation) {
                    if (!self._$scope.DSFilterOperationsOptions.rowData) {
                        self._$scope.DSFilterOperationsOptions.rowData = [];
                    }

                    self._$scope.DSFilterOperationsOptions.rowData.push(item);
                    self._$scope.DSFilterOperationsOptions.api.onNewRows();
                    self._$scope.DSFilterOperationsOptions.api.selectIndex(self._$scope.DSFilterOperationsOptions.rowData.indexOf(item));
                });

            }.bind(this));
        }       

        private addMultipleTags() {
            var self = this;            

            this.select_tags(function (tags: Array<Models.DicomData>) {
                if (!self._$scope.DSFilterOperationsOptions.rowData) {
                    self._$scope.DSFilterOperationsOptions.rowData = [];
                }

                for (var i = 0; i < tags.length; i++) {
                    var operation: Models.FilterOperation = new Models.FilterOperation();
                    var data: Models.DicomData = tags[i];

                    operation.SelectorName = data.name;
                    operation.WCFSelectorAttribute = data.tag;
                    operation.SelectorValueNumber = 1;
                    operation.FilterByOperator = Models.FilterByOperator.MemberOf;
                    operation.ImageSetSelectorUsageFlag = Models.ImageSetSelectorUsage.Match;

                    if (!data['isCodeSequence']) {
                        operation.SelectorValue = data.value;
                        operation.SelectorAttributeVr = data.vr;
                        operation.SelectorCodeSequenceValue = undefined; 
  
                        operation.SelectorValueNumber = 1;
                        operation.FilterByOperator = Models.FilterByOperator.MemberOf;

                        if (data['selectorSequencePointer']) {
                            operation.WCFSelectorSequencePointer = data['selectorSequencePointer'];
                            operation['SequencePointerName'] = data['sequencePointerName'];
                            operation.WCFSelectorSequencePointerItems = data['selectorSequencePointerItems'];
                        }
                        else {
                            operation.WCFSelectorSequencePointer = '';
                            delete operation['SequencePointerName'];
                        }
                    }
                    else {
                        operation.WCFSelectorSequencePointer = data['selectorSequencePointer']; 
                        operation.WCFSelectorSequencePointerItems = data['selectorSequencePointerItems'];
                        var tagList = data['selectorSequencePointer'];
                        var itemList = data['selectorSequencePointerItems'];

                        operation.SelectorCodeSequenceValue = DicomHelper.getCodeSequenceList(self._$scope.selectedDisplaySet['metadata'], tagList, itemList);
                        if (operation.SelectorCodeSequenceValue && operation.SelectorCodeSequenceValue.length > 0) {
                            operation.SelectorValue = operation.SelectorCodeSequenceValue[0].toFullString();
                        }
                        else {
                            operation.SelectorValue = '';
                        }
                    }

                    // Do not add the filter operation if the SelectorValue is empty
                    // This would allow the user to create an invalid HP
                    if (operation.SelectorValue != null && operation.SelectorValue.trim().length > 0) {
                        self._$scope.DSFilterOperationsOptions.rowData.push(operation);
                    }
                }
                self._$scope.DSFilterOperationsOptions.api.onNewRows();
            }, this.get_currentFilterOperationTags());
        }         

        private addMulitipleImageSetTags() {
            var self = this;            

            this.select_tags(function (tags: Array<Models.DicomData>) {
                if (!self._$scope.HPImageSetSelectorOptions.rowData) {
                    self._$scope.HPImageSetSelectorOptions.rowData = [];
                }

                for (var i = 0; i < tags.length; i++) {
                    var selector: Models.ImageSetSelector = new Models.ImageSetSelector();                    
                    var data: Models.DicomData = tags[i];

                    selector.SelectorName = data.name;
                    selector.WCFSelectorAttribute = data.tag;

                    if (!data['isCodeSequence']) {
                        selector.ImageSetSelectorUsageFlag = Models.ImageSetSelectorUsage.Match;
                        selector.SelectorValue = data.value;
                        selector.SelectorValueNumber = 1;                        
                        selector.SelectorCodeSequenceValue = undefined;                        

                        if (data['selectorSequencePointer']) {
                            selector.WCFSelectorSequencePointer = data['selectorSequencePointer'];
                            selector['SequencePointerName'] = data['sequencePointerName'];
                        }
                        else {
                            selector.WCFSelectorSequencePointer = '';
                            delete selector['SequencePointerName'];
                        }
                    }
                    else {
                        selector.WCFSelectorSequencePointer = '';                        
                        selector.SelectorCodeSequenceValue = DicomHelper.getCodeSequenceList(self._$scope.selectedImageSet['metadata'], data.tag.replace(':', ''), null);
                        if (selector.SelectorCodeSequenceValue && selector.SelectorCodeSequenceValue.length > 0) {
                            selector.SelectorValue = selector.SelectorCodeSequenceValue[0].toFullString();
                        }
                        else {
                            selector.SelectorValue = '';
                        }
                    }
                    self._$scope.HPImageSetSelectorOptions.rowData.push(selector);
                }
                self._$scope.HPImageSetSelectorOptions.api.onNewRows();
            }, this.get_currentSelectorTags());
        }

        private get_currentFilterOperationTags(): Array<string> {
            var currentTags: Array<string> = new Array<string>();

            this._$scope.DSFilterOperationsOptions.api.forEachNode(function (node, index) {
                var operation: Models.FilterOperation = node.data;

                currentTags.push(operation.WCFSelectorAttribute);
            });
            return currentTags;
        }

        private get_currentSelectorTags(): Array<string> {
            var currentTags: Array<string> = new Array<string>();

            this._$scope.HPImageSetSelectorOptions.api.forEachNode(function (node, index) {
                var selector: Models.ImageSetSelector = node.data;

                currentTags.push(selector.WCFSelectorAttribute);
            });
            return currentTags;
        }

        private select_tags(callback: Function, currentTags:Array<string>) {
            var self = this;

            var modalInstance = this._$modal.open({
                templateUrl: 'views/dialogs/TagChooserDialog.html',
                controller: Controllers.TagChooserController,
                backdrop: 'static',
                resolve: {
                    dicom: function () {
                        return self._$scope.selectedDisplaySet['metadata'];
                    },
                    selector: function () {
                        return null;
                    },
                    currentTags: function () {
                        return currentTags;
                    }
                }
            });

            modalInstance.result.then(function (tags: Array<Models.DicomData>) {
                callback(tags);
            });
        }

        private editFilterOperation() {
            var self = this;
            var originalFilterOperation: Models.FilterOperation;

            this._$translate('DIALOGS_FILTER_OPERATION_EDIT_TITLE').then(function (translation) {
                var modalInstance = this._$modal.open({
                    templateUrl: 'views/dialogs/DSFilterOperationEditor.html',
                    controller: Controllers.DSFilterOperationEditorController,
                    backdrop: 'static',
                    resolve: {
                        item: function () {
                            var nodes: Array<any> = self._$scope.DSFilterOperationsOptions.api.getSelectedNodes();

                            originalFilterOperation = nodes[0].data;
                            return angular.copy(originalFilterOperation);
                        },
                        title: function () {
                            return translation;
                        },
                        dicom: function () {
                            return self._$scope.selectedDisplaySet['metadata'];
                        },
                        currentTags: function () {
                            return self.get_currentSelectorTags();
                        }
                    }
                });

                modalInstance.result.then(function (item: Models.FilterOperation) {
                    var diff = Utils.diff(originalFilterOperation, item);

                    if (diff.changed != "equal") {
                        var index = self._$scope.DSFilterOperationsOptions.rowData.indexOf(originalFilterOperation);

                        if (index != -1) {
                            self._$scope.DSFilterOperationsOptions.rowData[index] = item;
                            self._$scope.DSFilterOperationsOptions.api.setRowData(self._$scope.DSFilterOperationsOptions.rowData);
                            self._$scope.DSFilterOperationsOptions.api.selectIndex(index);
                        }
                    }
                });

            }.bind(this));
        }

        private deleteFilterOperation() {
            var nodes: Array<any> = this._$scope.DSFilterOperationsOptions.api.getSelectedNodes()

            if (nodes.length > 0) {
                var index: number = this._$scope.DSFilterOperationsOptions.rowData.indexOf(nodes[0].data);

                this._$scope.DSFilterOperationsOptions.rowData.splice(index, 1);
                this._$scope.DSFilterOperationsOptions.api.setRowData(this._$scope.DSFilterOperationsOptions.rowData);
            }
        }

        private deleteSimilarFilterOperations() {

            var myHp = this._$scope.hp;

            var nodes: Array<any> = this._$scope.DSFilterOperationsOptions.api.getSelectedNodes()
            if (nodes.length > 0) {
                var selectedFilterOperation: Models.FilterOperation = nodes[0].data;
                var index: number = this._$scope.DSFilterOperationsOptions.rowData.indexOf(selectedFilterOperation);

                myHp.deleteSimilarFilterOperations(selectedFilterOperation);

                this._$scope.DSFilterOperationsOptions.api.refreshView();
                
                if (index != -1) {
                    this._$scope.DSFilterOperationsOptions.api.setRowData(this._$scope.DSFilterOperationsOptions.rowData);
                }
            }
        }

        private cloneFilterOperation() {
            var myHp = this._$scope.hp;

            var nodes: Array<any> = this._$scope.DSFilterOperationsOptions.api.getSelectedNodes();
            if (nodes.length > 0) {
                var selectedFilterOperation: Models.FilterOperation = nodes[0].data;
                myHp.cloneFilterOperation(selectedFilterOperation);
                myHp.sortFilterOperations();
            }
        }

        private mergeFilterOperation() {
            var myHp = this._$scope.hp;

            var nodes: Array<any> = this._$scope.DSFilterOperationsOptions.api.getSelectedNodes();
            if (nodes.length > 0) {
                var selectedFilterOperation: Models.FilterOperation = nodes[0].data;
                var index: number = this._$scope.DSFilterOperationsOptions.rowData.indexOf(selectedFilterOperation);
                var selectorValue: string = selectedFilterOperation.SelectorValue;

                // go through all hp DisplaySets
                myHp.mergeFilterOperationValues(selectedFilterOperation);
            }
            if (index != -1) {
                this._$scope.DSFilterOperationsOptions.api.setRowData(this._$scope.DSFilterOperationsOptions.rowData);
            }
        }

        // VRs that do not support multiValue: 
        //      LT : Long Text
        //      ST : Short Text
        //      UT : Unlimited Text
        //      UI : Unique Identifier
        private multiValueVR : Array<string> = ["AT", "CS", "IS", "LO", "PN", "SH", "DS", "FD", "FL", "UL", "US", "SL", "SS"]; 


        private canMergeFilterOperation(): boolean {
            var canMerge: boolean = false;
            var nodes: Array<any> = this._$scope.DSFilterOperationsOptions.api.getSelectedNodes();
            if (nodes.length > 0) {
                var selectedFilterOperation: Models.FilterOperation = nodes[0].data;
                if (selectedFilterOperation.SelectorAttributeVr != null) {
                    canMerge = (this.multiValueVR.indexOf(selectedFilterOperation.SelectorAttributeVr) != -1);
                }
                else {
                    canMerge = true;
                }

            }
            return canMerge;
        }

        private falseFunction(): boolean {
            return false;
        }

        private trueFunction(): boolean {
            return true;
        }

        private saveHangingProtocol(): void {
            var hpTemp = this._$scope.hp;
            var hpCloned: Models.HangingProtocol = Utils.myclone(hpTemp, ['cell', 'metadata']);
            var dialogs = this._dialogs;

            // angular.copy(this._$scope.hp, hpCloned);
            // var hpCloned = Utils.myclone(this._$scope.hp, ['cell', 'metadata']);

            //angular.forEach(hpTemp.DisplaySets, function (displaySet: Models.DisplaySet, index) {
            //    delete displaySet['cell'];
            //    delete displaySet['metadata'];
            //});

            //angular.forEach(hpTemp.ImageSetsSequence, function (imageSet: Models.ImageSet, index) {
            //    delete imageSet['metadata'];
            //});

            
            // var hpCloned : Models.HangingProtocol = Utils.myclone(hpTemp, ['cell', 'metadata']);

            // var successMessage: string = "Hanging Protocol Saved: " + hpCloned.HangingProtocolName + " (" + hpCloned.HangingProtocolDescription + ")";

            var successMessage: string;
            var title: string;

            //this._$translate('DIALOGS_NOTIFICATION').then(function (translation) {
            //    title = translation;
            //});

            this._$translate('NOTIFY_SAVE_HP_SUCCESS').then(function (translation) {
                title = translation;
            });

            //this._$translate('NOTIFY_SAVE_HP_SUCCESS').then(function (translation) {
            //    successMessage = translation + "\n" + hpCloned.HangingProtocolName + " (" + hpCloned.HangingProtocolDescription + ")";
            //});

            successMessage = hpCloned.HangingProtocolName + " (" + hpCloned.HangingProtocolDescription + ")";

    
            this._$scope.objectStoreService.StoreHangingProtocol(hpCloned).success(function (response) {
                if (angular.isDefined(response.FaultType)) {
                    alert(response.Message);
                }
                else {
                    dialogs.notify(title, successMessage);
                }
            }).
                error(function (error) {
                    alert(error);
                });

            ;
        }

        private getButtonStyle(): string {
            return "color: grey";
        }

        private isFilterOperationSelected(): boolean {
            var isSelected: boolean = angular.isDefined(this._$scope.DSFilterOperationsOptions.api) && this._$scope.DSFilterOperationsOptions.api.getSelectedNodes().length > 0;
            return isSelected;
        }

        // ****
        private isHangingProtocolNameValid(): boolean {
            var error: string = this.getHangingProtocolNameError();
            return Utils.isStringEmpty(error);
        }

        private getHangingProtocolNameError(): string {
            var errorMessage: string = "";
            var hangingProtocolName = this._$scope.hp.HangingProtocolName;

            if (Utils.isStringEmpty(hangingProtocolName)) {
                errorMessage = "Must have a value.";
            }

            if (hangingProtocolName.trim().length > 16) {
                errorMessage = "Must be 1 to 16 characters.";
            }
            return errorMessage;
        }

        private isHangingProtocolDescriptionValid(): boolean {
            var error: string = this.getHangingProtocolDescriptionError();
            return Utils.isStringEmpty(error);
        }

        private isLevelUserGroup(): boolean {
            var userGroupSelected: boolean = this._$scope.hp.HangingProtocolLevel == Models.HangingProtocolLevel.UserGroup;
            return userGroupSelected;
        } 

        private getHangingProtocolDescriptionError(): string {
            var errorMessage: string = "";
            var hangingProtocolDescription = this._$scope.hp.HangingProtocolDescription;

            if (Utils.isStringEmpty(hangingProtocolDescription)) {
                errorMessage = "Must have a value.";
            }

            if (hangingProtocolDescription.trim().length > 64) {
                errorMessage = "Must be 1 to 64 characters.";
            }
            return errorMessage;
        }

        private isFormValid(): boolean {
            return this.isHangingProtocolNameValid() && this.isHangingProtocolDescriptionValid();
        }
        // ****

        private init_HangingProtocolDefinitionGrid($scope: IHPDialogControllerScope) {
            $scope.HPPDOptions = {
                groupHeaders: true,
                angularCompileHeaders: true,
                rowSelection: 'single',
                enableColResize: true,
                columnDefs: [
                    {
                        headerName: "Modality",
                        field: "Modality",
                        width: 75
                    },
                    {
                        headerName: "Study Description",
                        field: "StudyDescription",
                        width: 150
                    },
                    {
                        headerName: "Anatomic Region Sequence",
                        field: "AnatomicRegionSequence",
                        cellRenderer: this.codeSequenceRenderer.bind(this),
                        width: 200
                    },
                    {
                        headerName: "Laterality",
                        field: "Laterality",
                        width: 100,
                        cellRenderer: this.lateralityRenderer.bind(this)
                    },
                    {
                        headerName: "Procedure Code Sequence",
                        field: "ProcedureCodeSequence",
                        cellRenderer: this.codeSequenceRenderer.bind(this),
                        width: 200
                    },
                    {
                        headerName: "Reason for Requested Procedure",
                        field: "ReasonForRequestedProcedureCodeSequence",
                        cellRenderer: this.codeSequenceRenderer.bind(this),
                        width: 200
                    },
                    {
                        headerName: "Body Part Examined",
                        field: "BodyPartExamined",
                        width: 200
                    },
                    {
                        headerName: "Protocol Name",
                        field: "ProtocolName",                        
                        width: 200
                    }
                ],
                rowData: $scope.hp.HangingProtocolDefinitionSequence,
                onGridReady: function () {
                    $scope.HPPDOptions.api.hideOverlay();
                    if ($scope.HPPDOptions.rowData && $scope.HPPDOptions.rowData.length > 0) {
                        $scope.HPPDOptions.api.selectIndex(0);                       
                    }
                },
            }
        }

        private init_TimeBasedImageSetSelectorGrid($scope: IHPDialogControllerScope) {
            $scope.HPTimeBasedImageSetsOptions = {
                groupHeaders: true,
                angularCompileHeaders: true,
                rowSelection: 'single',
                enableColResize: true,
                suppressNoRowsOverlay: true,
                columnDefs: [
                    {
                        headerName: "Time Based Image Sets",
                        children: [
                            {
                                headerName: "#",
                                field: "ImageSetNumber",
                                width: 50                  // (length * 95 / 11)
                            },
                            {
                                headerName: "Label",
                                field: "ImageSetLabel",
                                width: 100
                            },
                            {
                                headerTooltip: "Selector Category",
                                headerName: "Image Set Selector Category",
                                field: "ImageSetSelectorCategory",
                                width: 115,
                                cellRenderer: this.imageSetSelectorCategoryRenderer
                            },
                            {
                                headerName: "Relative Time",
                                field: "RelativeTime",
                                width: 110
                            },
                            {
                                headerName: "Relative Time Units",
                                field: "RelativeTimeUnits",
                                width: 165,
                                cellRenderer: this.relativeTimeUnitsRenderer
                            },
                            {
                                headerName: "Abstract Prior Value",
                                field: "AbstractPriorValue",
                                width: 175
                            },
                            {
                                headerName: "Study Date",
                                field: "StudyDateTime",
                                width: 175
                            },
                        ]
                    }
                ],
                rowData: [],
                onGridReady: function () {
                    $scope.HPTimeBasedImageSetsOptions.api.hideOverlay();
                },
            }
        }


        private init_ImageSetSelectorGrid($scope: IHPDialogControllerScope) {
            $scope.HPImageSetSelectorOptions = {
                groupHeaders: true,
                angularCompileHeaders: true,
                rowSelection: 'single',
                enableColResize: true,
                suppressNoRowsOverlay: true,
                columnDefs: [
                    {
                        headerName: "Image Set Selector",
                        children: [
                            {
                                headerName: "Usage",
                                field: "ImageSetSelectorUsageFlag",
                                width: 75,
                                cellRenderer: this.selectorUsageRenderer
                            },
                            {
                                headerName: "Attribute",
                                field: "WCFSelectorAttribute",
                                width: 95
                            },
                            {
                                headerName: "Tag Name",
                                field: "SelectorName",
                                width: 95
                            },
                            {
                                headerName: "Value",
                                field: "SelectorValue",
                                width: 95
                            },
                            {
                                headerName: "Value Index",
                                field: "SelectorValueNumber",
                                width: 95
                            },
                            {
                                headerName: "Selector Sequence Pointer",
                                field: "WCFSelectorSequencePointer",
                                width: 215,                                
                            },
                            {
                                headerName: "Sequence Pointer Name",
                                field: "SequencePointerName",
                                width: 180,
                            }                        
                        ]
                    }
                ],
                rowData: [],
                onGridReady: function () {
                    $scope.HPImageSetSelectorOptions.api.hideOverlay();                    
                },
            }
        }

        private init_FilterOperationsGrid($scope: IHPDialogControllerScope) {
            var self = this;

            $scope.DSFilterOperationsOptions = {
                groupHeaders: true,
                angularCompileHeaders: true,
                rowSelection: 'single',
                enableColResize: true,
                suppressNoRowsOverlay: true,
                columnDefs: [
                    {
                        headerName: "Filter Operations",
                        children: [
                            {
                                headerName: "Usage",
                                field: "ImageSetSelectorUsageFlag",
                                width: 75,
                                cellRenderer: this.selectorUsageRenderer
                            },
                            {
                                headerName: "Attribute",
                                field: "WCFSelectorAttribute",
                                width: 95
                            },
                            {
                                headerName: "Tag Name",
                                field: "SelectorName",
                                width: 95
                            },
                            {
                                headerName: "Value",
                                field: "SelectorValue",
                                width: 150
                            },
                            {
                                headerName: "Value Index",
                                field: "SelectorValueNumber",
                                width: 95
                            },
                            {
                                headerName: "Filter By Operator",
                                field: "FilterByOperator",
                                width: 125,
                                cellRenderer: this.filterByOperatorRenderer
                            },
                            // IMAGE_PLANE or empty
                            //{
                            //    headerName: "Filter By Category",
                            //    field: "FilterByCategory",
                            //    width: 125
                            //},
                            {
                                headerName: "Selector Sequence Pointer",
                                field: "WCFSelectorSequencePointer",
                                width: 180,
                            },
                            {
                                headerName: "Selector Sequence Pointer Items",
                                field: "WCFSelectorSequencePointerItems",
                                width: 180,
                            },
                            {
                                headerName: "Sequence Pointer Name",
                                field: "SequencePointerName",
                                width: 180,
                            }   
                        ]
                    }
                ],
                rowData: [],
                onGridReady: function () {
                    $scope.DSFilterOperationsOptions.api.hideOverlay();
                    $scope.DSFilterOperationsOptions.api.setRowData($scope.selectedDisplaySet.FilterOperationsSequence);
                },
            }
        }

        private imageSetSelectorCategoryRenderer(evt) {
            switch (parseInt(evt.data.ImageSetSelectorCategory)) {
                case Models.ImageSetSelectorCategory.AbstractPrior:
                    return 'Abstract Prior';
                case Models.ImageSetSelectorCategory.RelativeTime:
                    return 'Relative Time';
            }
            return '';
        }

        private relativeTimeUnitsRenderer(evt) {
            switch (parseInt(evt.data.RelativeTimeUnits)) {
                case Models.RelativeTimeUnits.Days:
                    return 'Days';
                case Models.RelativeTimeUnits.Hours:
                    return 'Hours';
                case Models.RelativeTimeUnits.Minutes:
                    return 'Minutes';
                case Models.RelativeTimeUnits.Months:
                    return 'Months';
                case Models.RelativeTimeUnits.Seconds:
                    return 'Seconds';
                case Models.RelativeTimeUnits.Weeks:
                    return 'Weeks';
                case Models.RelativeTimeUnits.Years:
                    return 'Years';
            }
            return '';
        }

        private selectorUsageRenderer(evt) {
            switch (parseInt(evt.data.ImageSetSelectorUsageFlag)) {
                case Models.ImageSetSelectorUsage.Match:
                    return 'Match';
                case Models.ImageSetSelectorUsage.NoMatch:
                    return 'No Match';
            }
            return '';
        }

        private filterByOperatorRenderer(evt) {
            switch (parseInt(evt.data.FilterByOperator)) {
                case Models.FilterByOperator.GreaterOrEqual:
                    return 'Greater Or Equal';
                case Models.FilterByOperator.GreaterThan:
                    return 'Greater Than';
                case Models.FilterByOperator.LessOrEqual:
                    return 'Less Or Equal';
                case Models.FilterByOperator.LessThan:
                    return 'Less Than';
                case Models.FilterByOperator.MemberOf:
                    return 'Member Of';
                case Models.FilterByOperator.NotMemberOf:
                    return 'Not Member Of';
                case Models.FilterByOperator.RangeExclusive:
                    return 'Range Exclusive';
                case Models.FilterByOperator.RangeInclusive:
                    return 'Range Inclusive';
            }
            return '';
        }

        private lateralityRenderer(evt) {
            var hpDefinition: Models.HangingProtocolDefinition = evt.data;

            if (!hpDefinition.Laterality)
                return "";

            switch (parseInt(hpDefinition.Laterality.toString())) {
                case Models.Laterality.Both:
                    return "Both";
                case Models.Laterality.Left:
                    return "Left";
                case Models.Laterality.Right:
                    return "Right";
                case Models.Laterality.Unpaired:
                    return "Unpaired";
            }

            return "";
        }

        private codeSequenceRenderer(evt) {
            var hpDefinition: Models.HangingProtocolDefinition = evt.data;

            if (hpDefinition[evt.colDef.field] && hpDefinition[evt.colDef.field].length > 0) {
                return this.get_CodeSequenceString(hpDefinition[evt.colDef.field]);
            }

            return "";
        }

        private get_CodeSequenceString(sequence: Array<Models.CodeSequence>): string {
            var sequenceString: string = "";

            for (var i = 0; i < sequence.length; i++) {
                var item: Models.CodeSequence = sequence[i];

                sequenceString += item.toFullString();     
                if ((i + 1) < sequence.length) {
                    sequenceString += ", ";
                }
            }

            return sequenceString;
        }

        private selectedDisplaySetChanged(displaySet: Models.DisplaySet) {
            var cell: lt.Controls.Medical.Cell = displaySet['cell'];

            if (cell && this._activeStepIndex == 4) {
                cell.viewer.layout.highlightedItems.clear();
                cell.viewer.layout.highlightedItems.add(cell);
            }

            if (angular.isDefined(this._$scope.DSFilterOperationsOptions.api)) {
                this._$scope.DSFilterOperationsOptions.api.setRowData(displaySet.FilterOperationsSequence);
            }
            this._$scope.selectedDisplaySet = displaySet;
        }

        private selectedImageSetChanged(imageSet: Models.ImageSet) {
            if (imageSet) {
                if (this._$scope.HPImageSetSelectorOptions.api) {
                    this._$scope.HPImageSetSelectorOptions.api.setRowData(imageSet.ImageSetSelectorSequence);
                    this._$scope.HPTimeBasedImageSetsOptions.api.sizeColumnsToFit();


                    this._$scope.HPTimeBasedImageSetsOptions.api.setRowData(imageSet.TimeBasedImageSetsSequence);
                    this._$scope.HPTimeBasedImageSetsOptions.api.sizeColumnsToFit();
                }
                else {
                    this._$scope.HPImageSetSelectorOptions.rowData = imageSet.ImageSetSelectorSequence;
                    this._$scope.HPTimeBasedImageSetsOptions.rowData = imageSet.TimeBasedImageSetsSequence;
                }
            }

            this._$scope.selectedImageSet = imageSet;
        }

        private editImageSetLabel() {
            var self = this;
            var modalInstance = this._$modal.open({
                templateUrl: 'views/dialogs/Prompt.html',
                controller: Controllers.PromptController,
                backdrop: 'static',
                resolve: {
                    label: function () {
                        return "Image Set Label";
                    },
                    text: function () {
                        return self._$scope.selectedImageSet.Name;
                    }
                }
            });

            modalInstance.result.then(function (text:string) {
                if (text != self._$scope.selectedImageSet.Name) {
                   self._$scope.selectedImageSet.Name = text;
                }
            });
        }

        private editDisplaySetLabel() {
            var self = this;
            var modalInstance = this._$modal.open({
                templateUrl: 'views/dialogs/Prompt.html',
                controller: Controllers.PromptController,
                backdrop: 'static',
                resolve: {
                    label: function () {
                        return "Display Set Label";
                    },
                    text: function () {
                        return self._$scope.selectedDisplaySet.DisplaySetLabel;
                    }
                }
            });

            modalInstance.result.then(function (text:string) {
                var imageSet: Models.ImageSet = Utils.findFirst(self._$scope.hp.ImageSetsSequence, function (item: Models.ImageSet) {
                    var is: Models.TimeBasedImageSet = Utils.findFirst(item.TimeBasedImageSetsSequence, function (tsItem) {
                        return tsItem.ImageSetNumber == self._$scope.selectedDisplaySet.ImageSetNumber;
                    });

                    return is?true:false;
                });

                if (text != self._$scope.selectedDisplaySet.DisplaySetLabel && text.length > 0) {
                    self._$scope.selectedDisplaySet.DisplaySetLabel = text;                    
                    self._$scope.selectedDisplaySet["CombinedName"] = text + " - " + imageSet.Name;                    
                }
            });
        }

        private setHangingProtocolLevelOptions()  {
            this._$scope.hangingProtocolLevelOptions = [];

            if (this._$scope.isAdmin()) {
                this._$scope.hangingProtocolLevelOptions.push(new Models.DropDownItem(0, "Manufacturer"));
                this._$scope.hangingProtocolLevelOptions.push(new Models.DropDownItem(1, "Site"));
                this._$scope.hangingProtocolLevelOptions.push(new Models.DropDownItem(2, "User Group"));
            }
            this._$scope.hangingProtocolLevelOptions.push(new Models.DropDownItem(3, "Single User"));

            // Default for dropdown
            this._$scope.hp.HangingProtocolLevel = Models.HangingProtocolLevel.SingleUser;
        }

    }
}