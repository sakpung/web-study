// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="Scopes.ts" />
module Controllers {
   export interface ITemplateEditorControllerScope extends ng.IScope {
      warning: any;
      idleWait: number;
      timedout: any;
      layoutConfig: any;
      layoutApi: any;
      optionsLayoutConfig: any;
      optionsLayoutApi: any;
      editorApi: any;
      editorConfig: any;
      layout: any;
      selectedFrames: Array<Models.Frame>;
      propertyGridItems: Array<PropertyGridItem>;
      currentTemplate: Models.Template;
      templates: Array<Models.Template>;
      cancelMove: boolean;
      toolbars: Array<Models.Toolbar>;

      layoutResized(name, element, state, options, layoutName);
      onSelect();
      onExitEditor();
      onNewTemplate();
      onCopyTemplate();
      canSave(): boolean;
      canDraw(): boolean;
      canAdd(): boolean;
      onNewFrame(frame: Models.Frame);

      onPropertyChanged(name: string, value: any);
      onPropertyClicked(name: string, value: any);
      loadTemplate(template: Models.Template);
   }

   export class TemplateEditorController {
      private _scope: ITemplateEditorControllerScope;
      private _templateEditorService: TemplateEditorService;
      private _templateService: TemplateService;
      private _optionsService: OptionsService;

      private _descriptions: Array<Models.AnatomicDescription>;
      /* Reserved for capture
       *
      private _anatomicDescriptions: string;
      */

      private _isDirty: boolean;
      private _isNew: boolean;
      private _modal: any;

      private _newString: string = "New";
      private _templateString: string = "Template";
      private _originalTemplate: Models.Template;

      private _errorTitle: string = "Notification";
      private _notifyTitle: string = "Error";
      private _updateMessage: string = "Template successfully updated";
      private _addMessage: string = "New template successfully added";

      private _authenticationService: AuthenticationService;
      private _toolbarService: ToolbarService;
      private _dialogs: any;
      private _dateFormat: string;
      private _timeFormat: string;
      private _timerId: number;
      private _alignmentActions: Array<string>;
      private _$window: ng.IWindowService;

      private _toolbarKey: string = "BE0855F9-9BA9-4068-A7B9-AEC8D5F8FA17";

      public get currentTemplateName(): string {
         return this._scope.currentTemplate.Name
      }

      public get currentTemplateId(): string {
         return this._scope.currentTemplate.Id;
      }

      static $inject = ["$rootScope", "$scope", "templateEditorService", "$location", "templates", "$modal", "eventService", "$translate", "authenticationService", "templateService", "dialogs", "optionsService", "toolbarService", "$timeout", "$window", "$idle"]
      constructor($rootScope, $scope: ITemplateEditorControllerScope, templateEditorService: TemplateEditorService, $location: ng.ILocationService, templates: Array<Models.Template>, $modal, eventService: EventService, $translate, authenticationService: AuthenticationService, templateService: TemplateService, dialogs, optionsService: OptionsService, toolbarService: ToolbarService, $timeout, $window: ng.IWindowService, $idle) {
         var spacingSize = Utils.get_spacingSize();      
         var unsubscribe;
         var self = this;
         var showWest = Utils.debounce(function () {
            var state = $scope.layoutApi.get_state("west");

            if (!state.isClosed) {
               $scope.layoutApi.openPane("west");
            }
         }, 250);

         if (templates && templates.length > 0) {
            templates.sort(function (a, b) {
               return a.Frames.length - b.Frames.length;
            });
         }

         unsubscribe = eventService.subscribe(EventNames.ToolbarCreated, function (event, data) {
            toolbarService.disable("SaveTemplate" + self._toolbarKey);
            toolbarService.enable('NewTemplate' + self._toolbarKey, function () {
               return self.canAdd();
            });
            toolbarService.enable(['DrawTemplateBox' + self._toolbarKey, 'DeleteTemplateBox' + self._toolbarKey], function () {
               return self.canDraw();
            });
            toolbarService.enable('DeleteTemplate' + self._toolbarKey, function () {
               return self._authenticationService.hasPermission(PermissionNames.CanDeleteTemplates);
            });
            toolbarService.enable('RenameTemplate' + self._toolbarKey, function () {
               return self.canDraw();
            });
            toolbarService.enable('ImportTemplates' + self._toolbarKey, function () {
               return authenticationService.hasPermission(PermissionNames.CanImportTemplates);
            });
            toolbarService.enable('ExportTemplates' + self._toolbarKey, function () {
               return authenticationService.hasPermission(PermissionNames.CanExportTemplates);
            });

            toolbarService.enable(['ToggleGrid' + self._toolbarKey, 'ToggleSnapToGrid' + self._toolbarKey], function () {
               return self._authenticationService.hasPermission(PermissionNames.CanEditTemplates);
            });

            toolbarService.enable(self._alignmentActions, function () {
               return false;
            });

            toolbarService.press('SelectTemplateBox' + self._toolbarKey);
            unsubscribe();

            self.setToggleGridState();
            self.setToggleSnapToGridState();
         });

         eventService.subscribe(EventNames.TemplatesImported, this.templatesImported.bind(this));

         this._authenticationService = authenticationService;
         this._templateEditorService = templateEditorService;
         this._templateService = templateService;
         this._toolbarService = toolbarService;
         this._dialogs = dialogs;
         this._$window = $window;
         $scope.idleWait = optionsService.get(OptionNames.IdleWarningDuration);

         this._dateFormat = optionsService.get(OptionNames.DateFormat);
         this._timeFormat = optionsService.get(OptionNames.TimeFormat);

         templateEditorService.templateEditController = this;

         $translate('NEW').then(function (translation) {
            this.newString = translation;
         }.bind(this));

         $translate('TEMPLATE').then(function (translation) {
            this.templateString = translation;
         }.bind(this));

         $translate('DIALOGS_NOTIFICATION').then(function (translation) {
            this._notifyTitle = translation;
         }.bind(this));

         $translate('DIALOGS_ERROR').then(function (translation) {
            this._errorTitle = translation;
         }.bind(this));

         $translate('DIALOGS_TEMPLATE_ADDED').then(function (translation) {
            this._addMessage = translation;
         }.bind(this));

         $translate('DIALOGS_TEMPLATE_UPDATE').then(function (translation) {
            this._updateMessage = translation;
         }.bind(this));

         this._scope = $scope;
         /* Reserved for capture
          *        
         this._descriptions = anatomicDescriptions; */
         this._modal = $modal;
         this._isDirty = false;

         this.initializeToolbar();

         /* Reserved for capture
          *
         this._anatomicDescriptions = "NONE";
         for (var i = 0; i < length; i++) {
             this._anatomicDescriptions += "|" + anatomicDescriptions[i].Name;
         }*/

         $scope.layoutConfig = {
            applyDemoStyles: true,
            scrollToBookmarkOnLoad: false,
            spacing_closed: spacingSize,
            spacing_open: spacingSize,
            livePaneResizing: false,
            north__size: lt.LTHelper.device == lt.LTDevice.mobile ? "auto" : "auto",
            north__resizable: false,
            north__showOverflowOnHover: true,
            west__size: lt.LTHelper.device == lt.LTDevice.tablet ? '30%' : lt.LTHelper.device == lt.LTDevice.mobile ? '60%' : '20%',
            //west__initClosed: lt.LTHelper.device == lt.LTDevice.mobile ? true : false               
            west__initClosed: false
         }
         $scope.layoutApi = {};
         $scope.editorApi = {};

         $scope.layout = {};
         $scope.templates = templates;

         $scope.editorConfig = {
            keepDrawing: true, // Whether to keep drawing after a box is drawn, defaults to false
            editorMode: EditorMode.Select,
            editAfterDraw: false,
            onSelectedItemsChanged: this.onSelectedItemsChanged.bind(this),
            onFrameChanged: this.onFrameChanged.bind(this),
            borderSize: optionsService.get(OptionNames.TemplateBorderSize),
            borderColor: optionsService.get(OptionNames.TemplateBorderColor),
            backgroundColor: optionsService.get(OptionNames.TemplateBackgroundColor),
            foreColor: optionsService.get(OptionNames.TemplateForeColor),
            boundsNotification: optionsService.get(OptionNames.TemplateBoundsNotification)
         };

         eventService.subscribe(EventNames.CenterPaneResized, function (event, data) {
            if (data.args.element.attr('id') == "mainCenter") {
               showWest();
            }
         });

         $scope.onSelect = this.onSelect.bind(this);
         $scope.onNewTemplate = this.onNewTemplate.bind(this);
         $scope.onCopyTemplate = this.onCopyTemplate.bind(this);
         $scope.loadTemplate = this.loadTemplate.bind(this);
         $scope.onPropertyChanged = this.onPropertyChanged.bind(this);
         $scope.onPropertyClicked = this.onPropertyClicked.bind(this);
         $scope.onNewFrame = this.onNewFrame.bind(this);

         $scope.onExitEditor = function () {
            $location.path('/');
         }

         if ($scope.templates.length > 0) {
            this.load($scope.templates[0]);
            if (angular.isDefined($scope.currentTemplate)) {
               this._scope.cancelMove = this._scope.currentTemplate.BuiltIn;
            }
         }

         $scope.canSave = this.canSave.bind(this);
         $scope.canDraw = this.canDraw.bind(this);
         $scope.canAdd = this.canAdd.bind(this);

         this._timerId = null;
         this._optionsService = optionsService;

         $scope.$watch('windowDimensions', function (newValue, oldValue) {
            if ($scope.layoutApi) {
               if ($scope.layoutApi.refresh) {
                  $scope.layoutApi.refresh();
               }
               else {
                  var self = this;

                  setTimeout(function () {
                     $scope.layoutApi.refresh();
                     $scope.layoutApi.openPane("west");
                  }, 1000);
               }
            }
         });

         function closeModals() {
            if ($scope.warning) {
               $scope.warning.close();
               $scope.warning = null;
            }

            if ($scope.timedout) {
               $scope.timedout.close();
               $scope.timedout = null;
            }
         }

         $scope.$on('$idleStart', function () {
            $scope.warning = $modal.open({
               templateUrl: 'warning-dialog.html',
               windowClass: 'modal-danger'
            });
         });

         $scope.$on('$idleEnd', function () {
            closeModals();
         });

         $scope.$on('$idleTimeout', function () {
            closeModals();
            $idle.unwatch();
            authenticationService.logout();
         });
      }

      private initializeToolbar() {
         var toolbar: Models.Toolbar = new Models.Toolbar();
         var item: Models.ToolbarItem;

         this._scope.toolbars = new Array<Models.Toolbar>();
         toolbar.name = "Template";
         this._alignmentActions = Array<string>();

         this.addToolbarItem(toolbar, "NewTemplate", "OnNewTemplate", "New Template", "NewTemplate", "New");
          this.addToolbarItem(toolbar, "SaveTemplate", "OnSaveTemplate", "Save Template", "SaveTemplate", "Save");
          this.addToolbarItem(toolbar, "RenameSeperator", "", "", "", "", "seperator");
          this.addToolbarItem(toolbar, "RenameTemplate", "OnRenameTemplate", "Rename Template", "RenameTemplate", "Rename");
          this.addToolbarItem(toolbar, "CopyTemplate", "OnCopyTemplate", "Copy Template", "CopyTemplate", "Copy");
          this.addToolbarItem(toolbar, "DeleteTemplate", "OnDeleteTemplate", "Delete Template", "DeleteTemplate", "Delete");
          this.addToolbarItem(toolbar, "GridSeperator", "", "", "", "", "seperator");
          this.addToolbarItem(toolbar, "ConfigureGrid", "OnConfigureGrid", "Configure Grid", "Configure", "Configure");
          this.addToolbarItem(toolbar, "ToggleGrid", "OnToggleGrid", "Toggle Grid", "ToggleGrid", "Grid");
         this.addToolbarItem(toolbar, "ToggleSnapToGrid", "OnToggleSnapToGrid", "Toggle Snap to Grid", "SnapToGrid", "Snap");
          this.addToolbarItem(toolbar, "SelectSeperator", "", "", "", "", "seperator");
          this.addToolbarItem(toolbar, "SelectTemplateBox", "OnSelectBox", "Select Box", "SelectTemplateBox", "Select Box");
          this.addToolbarItem(toolbar, "DrawTemplateBox", "OnDrawBox", "Draw Box", "DrawTemplateBox", "Draw Box");
          this.addToolbarItem(toolbar, "DeleteTemplateBox", "OnDeleteBox", "Delete Box", "DeleteTemplateBox", "Delete Box");
          this.addToolbarItem(toolbar, "AlignmentSeperator", "", "", "", "", "seperator");
          this.addToolbarItem(toolbar, "AlignLeft", "OnAlignLeft", "Align Left", "AlignLeft", "Align left");
         this._alignmentActions.push("AlignLeft" + this._toolbarKey);
          this.addToolbarItem(toolbar, "AlignRight", "OnAlignRight", "Align Right", "AlignRight", "Align right");
         this._alignmentActions.push("AlignRight" + this._toolbarKey);
          this.addToolbarItem(toolbar, "AlignCenter", "OnAlignCenter", "Align Center", "AlignCenter", "Align center");
         this._alignmentActions.push("AlignCenter" + this._toolbarKey);
          this.addToolbarItem(toolbar, "AlignTop", "OnAlignTop", "Align Top", "AlignTop", "Align top");
         this._alignmentActions.push("AlignTop" + this._toolbarKey);
          this.addToolbarItem(toolbar, "AlignBottom", "OnAlignBottom", "Align Bottom", "AlignBottom", "Align bottom");
         this._alignmentActions.push("AlignBottom" + this._toolbarKey);
          this.addToolbarItem(toolbar, "AlignMiddle", "OnAlignMiddle", "Align Middle", "AlignMiddle", "Align middle");
         this._alignmentActions.push("AlignMiddle" + this._toolbarKey);
          this.addToolbarItem(toolbar, "SameWidth", "OnMakeSameWidth", "Make Same Width", "MakeSameWidth", "Same Width");
         this._alignmentActions.push("SameWidth" + this._toolbarKey);
          this.addToolbarItem(toolbar, "SameHeight", "OnMakeSameHeight", "Make Same Height", "MakeSameHeight", "Same Height");
         this._alignmentActions.push("SameHeight" + this._toolbarKey);
          this.addToolbarItem(toolbar, "SameSize", "OnMakeSameSize", "Make Same Size", "MakeSameSize", "Same Size");
         this._alignmentActions.push("SameSize" + this._toolbarKey);
         this.addToolbarItem(toolbar, "ExportSeperator", "", "", "", "", "seperator");
          this.addToolbarItem(toolbar, "ExportTemplates", "OnExportTemplates", "Export All Templates", "ExportTemplates", "Export"); 
          this.addToolbarItem(toolbar, "ImportTemplates", "OnImportTemplates", "Import Templates", "ImportTemplates", "Import");
          this.addToolbarItem(toolbar, "ReturnToViewer", "OnReturnToViewer", "Return to viewer", "RotateCounterClock", "Return");

         this._scope.toolbars.push(toolbar);
      }

       private addToolbarItem(toolbar: Models.Toolbar, id: string, action: string, tooltip: string, cssIconClass: string, caption?: string, type?: string) {
         var item: Models.ToolbarItem;

         item = new Models.ToolbarItem();
         item.id = id;
         item.action = action;
         item.tooltip = tooltip;
         item.cssIconClass = cssIconClass;
         item.type = type || "button";
         item.caption = caption;
         toolbar.items.push(item);
      }

      public onSelect() {
         this._scope.editorConfig.editorMode = EditorMode.Select;
         this._toolbarService.press('SelectTemplateBox' + this._toolbarKey);
         this._toolbarService.unpress('DrawTemplateBox' + this._toolbarKey);
      }

      public onDraw() {
         this._scope.editorConfig.editorMode = EditorMode.Draw;
         this._toolbarService.unpress('SelectTemplateBox' + this._toolbarKey);
         this._toolbarService.press('DrawTemplateBox' + this._toolbarKey);
      }

      public onDeleteSelectedFrames() {
         var frames: Array<Models.Frame> = this._templateEditorService.selectedFrames;

         if (this._scope.currentTemplate.Frames && frames) {
            var length: number = frames.length;

            for (var i = 0; i < length; i++) {
               var index: number = this._scope.currentTemplate.Frames.indexOf(frames[i]);

               if (index != -1) {
                  this._scope.currentTemplate.Frames.splice(index, 1);
               }
            }
         }
      }

      public saveTemplate(afterSave?: Function) {
         var __this = this;

         if (this._scope.currentTemplate.Frames.length == 0) {
            alert("Template is Empty, it will not be saved.");
            return;
         }

         if (this._isNew) {
            this._templateService.AddTemplate(this._scope.currentTemplate).then(function () {
               if (__this._isNew) {
                  __this._isNew = false;
                  delete (<any>(__this._scope.currentTemplate)).isNew;
               }
               __this._isDirty = false;
               __this.checkSave();
               if (angular.isDefined(afterSave))
                  afterSave();
               __this._dialogs.notify(__this._notifyTitle, __this._addMessage);
            }, function (error) {
            });
         }
         else {
            this._templateService.UpdateTemplate(this._scope.currentTemplate).then(function (result) {
               if (result.data["FaultType"]) {
                  if (result.data["Message"]) {
                     alert(result.data["Message"]);
                  }
               }
               else {
                  __this._isDirty = false;
                  if (angular.isDefined(afterSave))
                     afterSave();
                  __this.checkSave();
                  __this._dialogs.notify(__this._notifyTitle, __this._updateMessage);
               }
            }, function (error) {
            });
         }
      }

      private setNewTemplateProperties(newTemplate: Models.Template) {
         this._scope.currentTemplate = newTemplate;
         (<any>(this._scope.currentTemplate)).isNew = true;
         this._scope.templates.push(this._scope.currentTemplate);
         this._templateEditorService.selectedFrames = [];
         this._scope.selectedFrames = [];
         this._scope.cancelMove = false;
         this._isNew = true;
         this._isDirty = true;
         this.checkSave();
         this.setTemplateProperties();

         this._toolbarService.enable(['DrawTemplateBox' + this._toolbarKey, 'DeleteTemplateBox' + this._toolbarKey], function () {
            return this.canDraw();
         }.bind(this));

         this._toolbarService.enable(['DeleteTemplateBox' + this._toolbarKey], function () {
            return this.canDraw() && (this._selectedFrames && this._selectedFrames.length) > 0;
         }.bind(this));

         this.onSelect();
      }

      private setCloneTemplateProperties(newTemplate: Models.Template) {
         this._scope.currentTemplate = newTemplate;
         (<any>(this._scope.currentTemplate)).isNew = true;
         this._scope.templates.push(this._scope.currentTemplate);

         if (this._scope.currentTemplate.Frames && this._scope.currentTemplate.Frames.length > 0) {
            this._templateEditorService.selectedFrames = [this._scope.currentTemplate.Frames[0]];
            this._scope.selectedFrames = this._templateEditorService.selectedFrames;
            this.setFrameProperties(this._scope.selectedFrames[0]);
         }
         else
            this.setTemplateProperties();
         this._toolbarService.enable(['DrawTemplateBox' + this._toolbarKey], function () {
            return this.canDraw();
         }.bind(this));
         this._originalTemplate = angular.copy(newTemplate);

         this._isNew = true;
         this._isDirty = true;
         this.checkSave();

         this.onSelect();
      }

      public onNewTemplate() {
         var newTemplate: Models.Template = new Models.Template(this._newString + ' ' + this._templateString + " " + this.getDateTime());
         this.setNewTemplateProperties(newTemplate);
      }

      public onCopyTemplate() {
         var clonedTemplate: Models.Template = new Models.Template("Copy " + /*this._templateString +*/ " " + this.getDateTime());

         var currentTemplate: Models.Template = this._scope.currentTemplate;

         clonedTemplate.Modality = currentTemplate.Modality;
         clonedTemplate.Comments = currentTemplate.Comments;
         clonedTemplate.AutoMatching = currentTemplate.AutoMatching;
         clonedTemplate.BuiltIn = false;
         clonedTemplate.Hidden = false;;
         clonedTemplate.Availability = Models.TemplateAvailability.SeriesAndStudy;

         for (var i = 0; i < this._scope.currentTemplate.Frames.length; i++) {
            var currentFrame: Models.Frame = currentTemplate.Frames[i];
            var newFrame: Models.Frame = new Models.Frame(currentFrame.Position);

            newFrame.FrameNumber = currentFrame.FrameNumber;
            newFrame.SequenceNumber = currentFrame.SequenceNumber;
            newFrame.Rotation = currentFrame.Rotation;
            newFrame.ImageComments = currentFrame.ImageComments;
            newFrame.Script = currentFrame.Script;
            newFrame.Flip = currentFrame.Flip;
            newFrame.Reverse = currentFrame.Reverse;
            newFrame.Invert = currentFrame.Invert;
            newFrame.HorizontalJustification = currentFrame.HorizontalJustification;
            newFrame.VerticalJustification = currentFrame.VerticalJustification;
            newFrame.PresentationSizeMode = currentFrame.PresentationSizeMode;
            newFrame.Magnification = currentFrame.Magnification;

            clonedTemplate.Frames.push(newFrame);
         }

         this.setCloneTemplateProperties(clonedTemplate);
      }


      public canSave(): boolean {
         return this._isDirty;
      }

      public canDraw(): boolean {
         return this._scope.currentTemplate != null && !this._scope.currentTemplate.BuiltIn && this._authenticationService.hasPermission(PermissionNames.CanEditTemplates);
      }

      public canAdd(): boolean {
         return this._authenticationService.hasPermission(PermissionNames.CanAddTemplates);
      }

      public loadTemplate(template: Models.Template) {
         if (this._scope.currentTemplate == template)
            return;

         if (angular.isDefined((<any>(this._scope.currentTemplate)).isNew)) {
            if (this._scope.currentTemplate.Frames.length == 0) {
               var index = this._scope.templates.indexOf(this._scope.currentTemplate);

               this._scope.templates.splice(index, 1);
               this.load(template);
            }
         }

         if (this._isDirty) {
            this.confirmSave(function (save) {
               if (save) {
                  this.saveTemplate(function () {
                     if (angular.isDefined((<any>(this._scope.currentTemplate)).isNew)) {
                        delete (<any>(this._scope.currentTemplate)).isNew;
                     }
                     this.load(template)
                  }.bind(this));
               }
               else {
                  this.load(template);
               }
            }.bind(this));
         }
         else {
            this.load(template);
         }
      }

      public deleteCurrentTemplate() {
         var index: number = this._scope.templates.indexOf(this._scope.currentTemplate);

         if (index != -1) {
            this._scope.templates.splice(index, 1);
         }

         index = index - 1;
         if (index < 0)
            index = 0;

         if (this._scope.templates.length > 0) {
            this.load(this._scope.templates[index]);
         }
      }

      public onAlignLeft() {
         this.getAutomation().alignLefts();
         this._scope.editorApi.updatePositions();
      }

      public onAlignRight() {
         this.getAutomation().alignRights();
         this._scope.editorApi.updatePositions();
      }

      public onAlignCenter() {
         this.getAutomation().alignCenters();
         this._scope.editorApi.updatePositions();
      }

      public onAlignTop() {
         this.getAutomation().alignTops();
         this._scope.editorApi.updatePositions();
      }

      public onAlignBottom() {
         this.getAutomation().alignBottoms();
         this._scope.editorApi.updatePositions();
      }

      public onAlignMiddle() {
         this.getAutomation().alignMiddles();
         this._scope.editorApi.updatePositions();
      }

      public onMakeSameWidth() {
         this.getAutomation().makeSameWidth();
         this._scope.editorApi.updatePositions();
      }

      public onMakeSameHeight() {
         this.getAutomation().makeSameHeight();
         this._scope.editorApi.updatePositions();
      }

      public onMakeSameSize() {
         this.getAutomation().makeSameSize();
         this._scope.editorApi.updatePositions();
      }

      public onToggleGrid() {
         this.getAutomation().manager.snapToGridOptions.showGrid = !this.getAutomation().manager.snapToGridOptions.showGrid;
         this.setToggleGridState();
         this.getAutomation().invalidate(lt.LeadRectD.empty);
         this._optionsService.saveUserOption(OptionNames.ShowGrid, this.getAutomation().manager.snapToGridOptions.showGrid).success(function () {
            this._optionsService.set(OptionNames.ShowGrid, this.getAutomation().manager.snapToGridOptions.showGrid);
         }.bind(this)).
            error(function (error, status) {
            });
      }

      private setToggleGridState() {
         if (this.getAutomation().manager.snapToGridOptions.showGrid)
            this._toolbarService.press("ToggleGrid" + this._toolbarKey);
         else
            this._toolbarService.unpress("ToggleGrid" + this._toolbarKey);
      }

      public onToggleSnapToGrid() {
         this.getAutomation().manager.snapToGridOptions.enableSnap = !this.getAutomation().manager.snapToGridOptions.enableSnap;
         this.setToggleSnapToGridState();
         this._optionsService.saveUserOption(OptionNames.SnapToGrid, this.getAutomation().manager.snapToGridOptions.enableSnap).success(function () {
            this._optionsService.set(OptionNames.SnapToGrid, this.getAutomation().manager.snapToGridOptions.enableSnap);
         }.bind(this)).
            error(function (error, status) {
            });
      }

      public setToggleSnapToGridState() {
         if (this.getAutomation().manager.snapToGridOptions.enableSnap)
            this._toolbarService.press("ToggleSnapToGrid" + this._toolbarKey);
         else
            this._toolbarService.unpress("ToggleSnapToGrid" + this._toolbarKey);
      }

      public onReturnToViewer() {
         if (this._isDirty) {
            this.confirmSave(function (save) {
               if (save) {
                  this.saveTemplate(function () {
                     if (angular.isDefined((<any>(this._scope.currentTemplate)).isNew)) {
                        delete (<any>(this._scope.currentTemplate)).isNew;
                     }
                     this.reload();
                  }.bind(this));
               }
               else {
                  this.reload();
               }
            }.bind(this));
         }
         else {
            this.reload();
         }
      }

      private reload() {
         sessionStorage.setItem('AuthCode', this._authenticationService.authenticationCode);
         this._$window.location.reload();
      }

      public get_GetLineSpacing(): number {
         return this.getAutomation().manager.snapToGridOptions.lineSpacing;
      }

      public get_GridLength(): number {
         return this.getAutomation().manager.snapToGridOptions.gridLength;
      }

      public set_LineSpacing(size: number) {
         if (size != this.getAutomation().manager.snapToGridOptions.lineSpacing) {
            this.getAutomation().manager.snapToGridOptions.lineSpacing = size;
            this.getAutomation().invalidate(lt.LeadRectD.empty);
         }
      }

      public set_GridLength(size: number) {
         if (size != this.getAutomation().manager.snapToGridOptions.gridLength) {
            this.getAutomation().manager.snapToGridOptions.gridLength = size;
            this.getAutomation().invalidate(lt.LeadRectD.empty);
         }
      }

      private getAutomation(): lt.Annotations.Automation.AnnAutomation {
         return this._scope.editorApi.getAutomation();
      }

      private load(template: Models.Template) {
         this._scope.currentTemplate = template;
         this._scope.cancelMove = this._scope.currentTemplate.BuiltIn || !this._authenticationService.hasPermission(PermissionNames.CanEditTemplates);
         if (this._scope.currentTemplate.Frames && this._scope.currentTemplate.Frames.length > 0) {
            this._templateEditorService.selectedFrames = [this._scope.currentTemplate.Frames[0]];
            this._scope.selectedFrames = this._templateEditorService.selectedFrames;
            this.setFrameProperties(this._scope.selectedFrames[0]);
         }
         else
            this.setTemplateProperties();
         this._toolbarService.enable(['DrawTemplateBox' + this._toolbarKey], function () {
            return this.canDraw();
         }.bind(this));
         this._originalTemplate = angular.copy(template);
         this._isDirty = false;
      }

      public onSelectedItemsChanged(frames: Array<Models.Frame>) {
         var canDelete: boolean = false;

         if (frames.length == 0 || frames.length > 1) {
            this.setTemplateProperties();
            if (frames.length > 1) {
               canDelete = true;
            }
         }
         else {
            this.setFrameProperties(frames[0]);
            canDelete = true;
            if (this._scope.editorConfig.editorMode == EditorMode.Draw) {
               this._scope.editorConfig.editorMode = EditorMode.Select;
               this._toolbarService.press('SelectTemplateBox' + this._toolbarKey);
               this._toolbarService.unpress('DrawTemplateBox' + this._toolbarKey);
            }
         }

         this._toolbarService.enable(['DeleteTemplateBox' + this._toolbarKey], function () {
            return this.canDraw() && canDelete;
         }.bind(this));
         this._templateEditorService.selectedFrames = frames;

         if (frames.length > 1) {
            if (this._timerId == null) {
               this._timerId = setInterval(this.onCheckAlignment.bind(this), 500);
            }
         }
         else {
            if (this._timerId != null) {
               clearInterval(this._timerId);
               this._timerId = null;

               this._toolbarService.enable(this._alignmentActions, function () {
                  return false;
               });
            }
         }
      }

      public onCheckAlignment() {
         var automation: lt.Annotations.Automation.AnnAutomation = this.getAutomation();

         if (automation.currentEditObject instanceof lt.Annotations.Engine.AnnSelectionObject) {
            var selectionObject: lt.Annotations.Engine.AnnSelectionObject = <lt.Annotations.Engine.AnnSelectionObject>automation.currentEditObject;
            var canEdit: boolean = !this._scope.currentTemplate.BuiltIn && this._authenticationService.hasPermission(PermissionNames.CanEditTemplates);

            this._toolbarService.enable(this._alignmentActions, function () {
               return selectionObject.alignmentTarget != null && canEdit;
            });
         }
      }

      public onFrameChanged(frame: Models.Frame, e: lt.Annotations.Automation.AnnAfterObjectChangedEventArgs) {
         this._isDirty = true;
         this.checkSave();
      }

      public onPropertyClicked(name: string, value: any) {
         var self = this;
         if (name == "Auto Match") {
            var modalInstance = this._modal.open({
               templateUrl: 'views/dialogs/ScriptEditor.html',
               controller: Controllers.ScriptEditorController,
               backdrop: 'static',
               size: 'lg',
               resolve: {
                  label: function () {
                     return "Script";
                  },
                  text: function () {
                     if (self._scope.currentTemplate.AutoMatching) {
                        return self._scope.currentTemplate.AutoMatching;
                     }
                     else {
                        var scrptDefault: string = "//following is an auto generated sample script "+
                           "\n//template will be applied automatically if the series number matches " +
                           "\nvar ars = dicom['00200011'];//series number tag " +
                           "\nvar success = false; " +
                           "\nif (ars && ars.Value && ars.Value.length > 0) { " +
                           "\nvar _val = ars.Value[0];" +
                           "\nsuccess = _val == 'series_number_here';//have the to-be-matched series number here " +
                           "\n} " +
                                "\nsuccess == true";

                        return scrptDefault;//default script
                     }
                  },
                  readOnly: function () {
                     return false;
                  },
               }
            });

            modalInstance.result.then(function (text) {
               var oldText = self._scope.currentTemplate.AutoMatching;

               if (oldText != text) {
                  self._scope.currentTemplate.AutoMatching = text;
                  self._isDirty = true;
                  self.checkSave();
                  self.setTemplateProperties();
               }
            });
         }
      }

      public onPropertyChanged(name: string, value: any) {
         this._isDirty = true;
         switch (name) {
            case 'Rotation':
               this._templateEditorService.selectedFrames[0].Rotation = this.getRotationValue(value);
               break;
            case 'Comments':
               if (this._templateEditorService.selectedFrames.length > 0) {
                  this._templateEditorService.selectedFrames[0].ImageComments = value;
               }
               else {
                  this._scope.currentTemplate.Comments = value;
               }
               break;
            case 'Auto Match':
               this._scope.currentTemplate.AutoMatching = value;
               break;
            case 'Auto Match Id':
               var scrptDefault: string = "//following is an auto generated sample script " +
                  "\n//template will be applied automatically if the series number matches " +
                  "\nvar ars = dicom['00200011'];//series number tag " +
                  "\nvar success = false; " +
                  "\nif (ars && ars.Value && ars.Value.length > 0) { " +
                  "\nvar _val = ars.Value[0];" +
                  "\nsuccess = _val == '" + value + "';//have the to-be-matched series number here " +
                  "\n} " +
                  "\nsuccess == true";

               this._scope.currentTemplate.AutoMatching = scrptDefault;
               break;
            case 'Name':
               this._scope.currentTemplate.Name = value;
               break;
            case 'Availability':
               this._scope.currentTemplate.Availability = this.set_availability(value);
               break;
            /* Reserved for capture
             *
            case 'Description':  
                this._templateEditorService.selectedFrames[0].AnatomicDescription = this.getAnatomicDescription(value);
                this.setFrameProperties(this._templateEditorService.selectedFrames[0]);
                break; */
            case 'SequenceNumber':
               this._templateEditorService.selectedFrames[0].SequenceNumber = value;
               break;
            case 'FrameNumber':
               this._templateEditorService.selectedFrames[0].FrameNumber = value;
               break;
            case 'Modality':
               this._scope.currentTemplate.Modality = this.getModalityInfo(value);
               break;
            case 'Flip':
               this._templateEditorService.selectedFrames[0].Flip = Utils.toBoolean(value, false);
               break;
            case 'Reverse':
               this._templateEditorService.selectedFrames[0].Reverse = Utils.toBoolean(value, false);
               break;
            case 'Invert':
               this._templateEditorService.selectedFrames[0].Invert = Utils.toBoolean(value, false);
               break;
            case 'Horizontal Justification':
               this._templateEditorService.selectedFrames[0].HorizontalJustification = this.set_horizontalJustification(value);
               break;
            case 'Vertical Justification':
               this._templateEditorService.selectedFrames[0].VerticalJustification = this.set_verticalJustification(value);
               break;
            case 'Presentation Size Mode':
               this._templateEditorService.selectedFrames[0].PresentationSizeMode = this.set_presentationSizeMode(value);
               break;
            case 'Magnification':
               this._templateEditorService.selectedFrames[0].Magnification = value;
               break;
         }
         this.checkSave();
      }

      public onNewFrame(frame: Models.Frame) {
         this._isDirty = true;
         this.checkSave();
      }

      public renameTemplate(newName: string) {
         var oldName: string = this._scope.currentTemplate.Name;

         this._scope.currentTemplate.Name = newName;
         this._isDirty = oldName != newName;
         if (this._isDirty) {
            this.setTemplateProperties();
         }
         this.checkSave();
      }

      public checkSave() {
         this._toolbarService.enable("SaveTemplate" + this._toolbarKey, function () {
            return this._isDirty;
         }.bind(this));
      }

      public setTemplateProperties() {
         if (this._scope.currentTemplate) {
            var items: Array<PropertyGridItem> = new Array<PropertyGridItem>();
            var item: PropertyGridItem;
            var canEdit: boolean = !this._scope.currentTemplate.BuiltIn && this._authenticationService.hasPermission(PermissionNames.CanEditTemplates);

            item = this.addProperty("Template", "input", "", "", "", this._scope.currentTemplate.Name, "Name");
            item.enabled = canEdit;
            items.push(item);

            item = this.addProperty("Template", "input", "", "", "", this._scope.currentTemplate.CreateDate, "Created");
            item.enabled = canEdit;
            items.push(item);

            item = this.addProperty("Template", "cdrop", "", this._templateEditorService.getModalityDescriptions(), "", this.getModality(this._scope.currentTemplate.Modality), "Modality");
            item.enabled = canEdit;
            items.push(item);

            item = this.addProperty("Template", "input", "", "", "", this._scope.currentTemplate.Comments != null ? this._scope.currentTemplate.Comments : "", "Comments");
            item.enabled = canEdit;
            items.push(item);

            item = this.addProperty("Template", "cdrop", "", "Not Available|Series Only|Study Only|Series and Study", "", this.get_availability(this._scope.currentTemplate.Availability), "Availability");
            item.enabled = true; // always enabled
            items.push(item);

            item = this.addProperty("Template", "dialog", "", "", "", this._scope.currentTemplate.AutoMatching ? "script" : "(empty)", "Auto Match");
            item.enabled = true;//always enabled
            items.push(item);

            item = this.addProperty("Template", "input", "", "", "", this.parseAutoMatchId(this._scope.currentTemplate.AutoMatching), "Auto Match Id");
            item.enabled = true;
            items.push(item);

            this._scope.propertyGridItems = items;
            if (!this._scope.$$phase) {
               this._scope.$digest();
            }
         }
      }

      private parseAutoMatchId(script: string): string {
         if (!script)
            return "";

         var txt1 = "success = _val == '";
         var txt2 = "'";

         var index1 = script.indexOf(txt1);
         if (index1==-1)
            return "";
         index1 += txt1.length;

         var index2 = script.indexOf(txt2, index1);
         if (index2 == -1 || index2<=index1)
            return "";

         return script.slice(index1, index2);
      }

      private updateSelectedFrameProperties() {
         this._scope.propertyGridItems[1].value = "hello";
      }

      private setFrameProperties(frame: Models.Frame) {
         var items: Array<PropertyGridItem> = new Array<PropertyGridItem>();
         var item: PropertyGridItem;
         var canEdit: boolean = !this._scope.currentTemplate.BuiltIn && this._authenticationService.hasPermission(PermissionNames.CanEditTemplates);

         (<any>frame).readOnly = this._scope.currentTemplate.BuiltIn;
         item = this.addProperty("Template Frames", "num", "", "", "", frame.SequenceNumber, "SequenceNumber");
         item.enabled = canEdit;
         items.push(item);

         item = this.addProperty("Template Frames", "num", "", "", "", frame.FrameNumber, "FrameNumber");
         item.enabled = canEdit;
         items.push(item);

         item = this.addProperty("Template Frames", "cdrop", "", "0\xB0|90\xB0|180\xB0|270\xB0", "", Utils.getRotation(frame.Rotation), "Rotation");
         item.enabled = canEdit;
         items.push(item);

         item = this.addProperty("Template Frames", "cdrop", "", "true|false", "", frame.Flip.toString(), "Flip");
         item.enabled = canEdit;
         items.push(item);

         item = this.addProperty("Template Frames", "cdrop", "", "true|false", "", frame.Reverse.toString(), "Reverse");
         item.enabled = canEdit;
         items.push(item);

         item = this.addProperty("Template Frames", "cdrop", "", "true|false", "", frame.Invert.toString(), "Invert");
         item.enabled = canEdit;
         items.push(item);

         item = this.addProperty("Template Frames", "cdrop", "", "Left|Center|Right", "", this.get_horizontalJustification(frame.HorizontalJustification), "Horizontal Justification");
         item.enabled = canEdit;
         items.push(item);

         item = this.addProperty("Template Frames", "cdrop", "", "Top|Center|Bottom", "", this.get_verticalJustification(frame.VerticalJustification), "Vertical Justification");
         item.enabled = canEdit;
         items.push(item);

         item = this.addProperty("Template Frames", "cdrop", "", "Scale To Fit|True Size|Magnify", "", this.get_presentationSizeMode(frame.PresentationSizeMode), "Presentation Size Mode");
         item.enabled = canEdit;
         items.push(item);

         item = this.addProperty("Template Frames", "num", "", "", "", frame.Magnification, "Magnification");
         item.enabled = canEdit;
         items.push(item);

         /* Reserved for capture
           *
         item = this.addProperty("Anatomic Information", "cdrop", "", this._anatomicDescriptions, "", this.getAnatomicDescriptionItem(frame, "Name", "NONE"), "Description");
         item.enabled = !this._scope.currentTemplate.BuiltIn;
         items.push(item);

         item = this.addProperty("Anatomic Information", "input", "", "", "", this.getLaterality(frame), "Laterality");
         item.enabled = false;
         items.push(item);

         item = this.addProperty("Anatomic Information", "input", "", "", "", Utils.accessProperty(frame, "AnatomicDescription.AnatomicRegionSequence.CodeMeaning"), "Region");
         item.enabled = false;
         items.push(item);

         item = this.addProperty("Anatomic Information", "input", "", "", "", Utils.accessProperty(frame, "AnatomicDescription.AnatomicRegionModifierSequence.CodeMeaning"), "Modifer");
         item.enabled = false;
         items.push(item);

         item = this.addProperty("Anatomic Information", "input", "", "", "", frame.ImageComments != null ? frame.ImageComments : "", "Comments");*/
         item = this.addProperty("Template Frames", "input", "", "", "", frame.ImageComments != null ? frame.ImageComments : "", "Comments");
         item.enabled = canEdit;
         items.push(item);

         this._scope.propertyGridItems = items;
         if (!this._scope.$$phase) {
            this._scope.$digest();
         }
      }

      private getModality(modalityInfo: string) {
         var data: Array<string> = modalityInfo.split('|');
         var modalities: Array<Modality>;
         var defaultModalites: Array<Modality> = this._templateEditorService.getModalities();

         if (data.length == 0)
            return modalityInfo;

         if (data.length == 1) {
            modalities = $.grep(defaultModalites, function (modality: Modality, index: number) {
               return modality.classType == data[0];
            });
         }
         else {
            modalities = $.grep(defaultModalites, function (modality: Modality, index: number) {
               return modality.classType == data[0] && modality.description == data[1];
            });
         }

         if (modalities.length > 0)
            return modalities[0].name + ":" + modalities[0].description;
      }

      private getModalityInfo(modalityDescription: string) {
         var data: Array<string> = modalityDescription.split(":");
         var defaultModalites: Array<Modality> = this._templateEditorService.getModalities();

         if (data.length == 2) {
            var modalities: Array<Modality> = $.grep(defaultModalites, function (modality: Modality, index: number) {
               return modality.name == data[0] && modality.description == data[1];
            });

            if (modalities.length > 0) {
               var info: string = modalities[0].classType;

               if (modalities[0].saveDescription)
                  info += "|" + modalities[0].description;

               return info;
            }
         }

         return "";
      }

      public addProperty(groupName: string, rowType: string, cssName: string, drpFields: string, isSubGroup: string, value: any, propertyName: string): PropertyGridItem {
         var item: PropertyGridItem = new PropertyGridItem();

         item.groupName = groupName;
         item.rowType = rowType;
         item.cssName = cssName;
         item.dropFields = drpFields;
         item.isSubGroup = isSubGroup;
         item.value = value;
         item.propertyName = propertyName;
         item.enabled = true;

         return item;
      }

      private getRotationValue(name: string): Models.FrameRotation {
         switch (name) {
            case '180°':
               return Models.FrameRotation.Rotate180;
            case '270°':
               return Models.FrameRotation.Rotate270;
            case '90°':
               return Models.FrameRotation.Rotate90;
         }
         return Models.FrameRotation.None;
      }

      private getAnatomicDescriptionItem(frame: Models.Frame, property: string, defaultValue: string): string {
         if (!frame.AnatomicDescription)
            return defaultValue;

         if (frame.AnatomicDescription[property])
            return frame.AnatomicDescription[property].toString();

         return defaultValue;
      }

      private getLaterality(frame: Models.Frame): string {
         if (!frame.AnatomicDescription)
            return "NONE";

         switch (frame.AnatomicDescription.Laterality) {
            case Models.Laterality.Left:
               return "Left";
            case Models.Laterality.Right:
               return "Right";
            case Models.Laterality.Both:
               return "Both";
         }
         return "Unknown";
      }

      private get_horizontalJustification(value: Models.FrameHorizontalJustification): string {
         switch (value) {
            case Models.FrameHorizontalJustification.Left:
               return "LEFT";
            case Models.FrameHorizontalJustification.Right:
               return "RIGHT"
            default:
               return "CENTER";
         }
      }

      private set_horizontalJustification(value: string): Models.FrameHorizontalJustification {
         switch (value) {
            case "LEFT":
               return Models.FrameHorizontalJustification.Left;
            case "RIGHT":
               return Models.FrameHorizontalJustification.Right;
            default:
               return Models.FrameHorizontalJustification.Center;
         }
      }

      private get_verticalJustification(value: Models.FrameVerticalJustification): string {
         switch (value) {
            case Models.FrameVerticalJustification.Top:
               return "TOP";
            case Models.FrameVerticalJustification.Bottom:
               return "BOTTOM";
            default:
               return "CENTER";
         }
      }

      private set_verticalJustification(value: string): Models.FrameVerticalJustification {
         switch (value) {
            case "TOP":
               return Models.FrameVerticalJustification.Top;
            case "BOTTOM":
               return Models.FrameVerticalJustification.Bottom;
            default:
               return Models.FrameVerticalJustification.Center;
         }
      }

      private get_availability(value: Models.TemplateAvailability): string {
         switch (value) {
            case Models.TemplateAvailability.None:
               return "Not Available";
            case Models.TemplateAvailability.Series:
               return "Series Only";
            case Models.TemplateAvailability.Study:
               return "Study Only";
            case Models.TemplateAvailability.SeriesAndStudy:
               return "Series and Study";
            default:
               return "Series Only";
         }
      }

      private set_availability(value: string): Models.TemplateAvailability {
         switch (value) {
            case "Not Available":
               return Models.TemplateAvailability.None;
            case "Series Only":
               return Models.TemplateAvailability.Series;
            case "Study Only":
               return Models.TemplateAvailability.Study;
            case "Series and Study":
               return Models.TemplateAvailability.SeriesAndStudy;
            default:
               return Models.TemplateAvailability.Series;
         }
      }


      private get_presentationSizeMode(value: Models.FramePresentationSizeMode): string {
         switch (value) {
            case Models.FramePresentationSizeMode.Magnify:
               return "Magnify";
            case Models.FramePresentationSizeMode.TrueSize:
               return "True Size";
            default:
               return "Scale To Fit";
         }
      }

      private set_presentationSizeMode(value: string): Models.FramePresentationSizeMode {
         switch (value) {
            case "Magnify":
               return Models.FramePresentationSizeMode.Magnify;
            case "True Size":
               return Models.FramePresentationSizeMode.TrueSize;
            default:
               return Models.FramePresentationSizeMode.ScaleToFit;
         }
      }

      /* Reserved for capture
       *
      private getAnatomicDescription(description: string): Models.AnatomicDescription {            
          var length: number = this._descriptions.length;

          for (var index = 0; index < length; index++) {
              if (description == this._descriptions[index].Name) {
                  return this._descriptions[index];
              }
          }

          return null;
      }*/

      private confirmSave(success: Function) {
         var __this = this;
         var modalInstance = this._modal.open({
            templateUrl: 'views/dialogs/Confirmation.html',
            controller: Controllers.ConfirmDialogControllerScope,
            backdrop: 'static',
            resolve: {
               data: function () {
                  return {
                     header: 'Template Changed',
                     msg: 'Do you want to save changes',
                  };
               }
            }
         });

         modalInstance.result.then(function (btn: string) {
            if (btn != 'cancel') {
               if (btn == 'no') {
                  var index: number = __this._scope.templates.indexOf(__this._scope.currentTemplate);

                  if (index != -1) {
                     __this._scope.templates[index] = __this._originalTemplate;
                  }
               }
               success(btn == 'yes');
            }
         });
      }

      private templatesImported(event, data) {
         var newTemplates: Array<Models.Template> = this.getDiff(data.args.templates, this._scope.templates);

         if (newTemplates.length > 0) {
            data.args.templates.forEach(function (template: Models.Template) {
               this._scope.templates.push(template);
            }.bind(this));

            if (!angular.isDefined(this._scope.currentTemplate)) {
               this.load(this._scope.templates[0]);
            }
         }
      }

      private getDiff(a: Array<Models.Template>, b: Array<Models.Template>): Array<Models.Template> {
         var oldIds = {};

         b.forEach(function (template: Models.Template) {
            return oldIds[template.Id] = template;
         });

         return a.filter(function (box: Models.Template) {
            return !(box.Id in oldIds);
         });
      }

      private getDateTime(): string {
         var DateJS: IDateJS = <any>(new Date());
         var formattedString: string;

         formattedString = DateJS.toString(this._dateFormat + " " + this._timeFormat);
         return formattedString;
      }
   }
}