// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />
/// <reference path="../app.ts" />

module EditorMode {
    export var Select: number = 0;
    export var Draw: number = 1;
}

module TemplateEditor {
    export class Config {
        public editAfterDraw: boolean;
        public editorMode: number;
        public backgroundColor: string;
        public foreColor: string;
        public borderColor: string;
        public borderSize: number;
        public onSelectedItemsChanged: Function;
        public onFrameChanged: Function;
        public boundsNotification: boolean;

        constructor() {
            this.editAfterDraw = false;
            this.editorMode = EditorMode.Draw;
            this.backgroundColor = 'lightgray';
            this.borderColor = 'red';
            this.borderSize = 0;
            this.onSelectedItemsChanged = null;
            this.boundsNotification = true;
            this.foreColor = "white";
        }
    }
}

interface ITemplateEditorScope extends ng.IScope {
    config: TemplateEditor.Config;
    editorApi: any;
    selectedItems: Array<Models.Frame>;
    cancelMove: boolean;

    onNewFrame: Function;
}

directives.directive('templateEditor', ["eventService", "$rootScope", "$timeout", "templateEditorService", "$modal", "optionsService", function (eventService: EventService, $rootScope, $timeout: ng.ITimeoutService, templateEditorService: TemplateEditorService, $modal, optionsService: OptionsService): ng.IDirective {
    return {
        restrict: 'A',
        require: 'ngModel',
        scope: {
            editorApi: "=?",
            config: "=",
            selectedItems: "=",
            cancelMove: "=",
            onNewFrame: "&",
        },
        link: function (scope: ITemplateEditorScope, elem, attr: any, ngModel: ng.INgModelController) {
            var options: lt.Controls.ImageViewerCreateOptions = new lt.Controls.ImageViewerCreateOptions(<HTMLDivElement>$(elem)[0]);
            var viewer: lt.Controls.ImageViewer = new lt.Controls.ImageViewer(options);
            var renderingEngine: lt.Annotations.Rendering.AnnHtml5RenderingEngine = new lt.Annotations.Rendering.AnnHtml5RenderingEngine();
            var manager: lt.Annotations.Automation.AnnAutomationManager = lt.Annotations.Automation.AnnAutomationManager.create(renderingEngine);
            var automationControl: lt.Annotations.JavaScript.ImageViewerAutomationControl = new lt.Annotations.JavaScript.ImageViewerAutomationControl();
            var automationInteractiveMode: lt.Annotations.JavaScript.AutomationInteractiveMode = new lt.Annotations.JavaScript.AutomationInteractiveMode();
            var automation = new lt.Annotations.Automation.AnnAutomation(manager, automationControl);
            var configOptions = new TemplateEditor.Config();
            var dcmLayoutRect = {
                left: 0,
                top: 1,
                width: 1,
                height: - 1
            };
            var debouncedPosition: Function = Utils.debounce(positionFrames, 350);
            var automationHelper: lt.Annotations.JavaScript.AutomationManagerHelper;

            templateEditorService.automation = automation;
            scope.config = $.extend(configOptions, scope.config);
            viewer.items.get_item(0).imageSize = lt.LeadSizeD.create(1, 1);
            createAutomationObjects(manager);
            setThumbPreferences(manager.renderingEngine.renderers);
            automationControl.imageViewer = viewer;
            automationInteractiveMode.automationControl = automationControl;
            viewer.defaultInteractiveMode = automationInteractiveMode;

            automation.add_currentDesignerChanged(onCurrentDesignerChanged);
            automation.add_beforeObjectChanged(onBeforeObjectChanged);
            automation.add_afterObjectChanged(onAfterObjectChanged);
            automation.add_selectedObjectsChanged(onSelectedObjectsChanged);
            automation.add_draw(onTextDraw);
            automation.add_editText(onEditText);

            setEditorMode();
            automation.active = true;
            manager.editObjectAfterDraw = scope.config.editAfterDraw;
            manager.restrictDesigners = true;
            manager.snapToGridOptions.showGrid = true;
            manager.snapToGridOptions.enableSnap = true;
            manager.enableObjectsAlignment = true;
            initializeGrid();

            automationHelper = new lt.Annotations.JavaScript.AutomationManagerHelper(manager, '');
            lt.Annotations.Engine.Utils.checkModifierKey = (<any>lt.Annotations.JavaScript.AutomationManagerHelper).checkModifierKey;

            manager.multiSelectModifierKey = lt.Annotations.Engine.AnnKeys.control;

            $(elem).resize(function () {
                resizeView();
                $timeout(function () {
                    resizeView();
                }, 800);
            });

            scope.editorApi = scope.editorApi || {};
            scope.cancelMove = scope.cancelMove || false;
            scope.editorApi.resize = function () {
                resizeView();
                $timeout(function () {
                    resizeView();
                }, 800);
            }

            scope.editorApi.getAutomation = function (): lt.Annotations.Automation.AnnAutomation {
                return automation;
            }

            scope.editorApi.updatePositions = function () {
                var selectionObject: lt.Annotations.Engine.AnnSelectionObject = automation.container.selectionObject;
                var selectCount = selectionObject.selectedObjects.count;

                for (var x = 0; x < selectCount; x++) {
                    var stamp: lt.Annotations.Engine.AnnTextObject = <lt.Annotations.Engine.AnnTextObject>(selectionObject.selectedObjects.item(x));
                    var frame: Models.Frame = findFrame(stamp.tag);

                    if (frame) {
                        var position: Models.FramePosition = getPosition(stamp.rect);

                        frame.Position = position;
                        scope.config.onFrameChanged(frame, lt.Annotations.Automation.AnnAfterObjectChangedEventArgs.empty);
                    }
                }
            }

            scope.$watch(function () {
                return ngModel.$modelValue;
            }, onModelChanged, true);

            scope.$watch('config', function (newValue, oldValue) {
                if (angular.isDefined(oldValue)) {
                    var differences = Utils.diff(newValue, oldValue);

                    if (differences.changed != "equal") {
                        getChanges(differences.value);
                    }
                }
            }, true);

            scope.$watch('selectedItems', function (newValue: Array<Models.Frame>, oldValue: Array<Models.Frame>) {
                if (angular.isDefined(newValue) && newValue != null) {
                    var length: number = newValue.length;
                    var selectedObjects: lt.Annotations.Engine.AnnObjectCollection = new lt.Annotations.Engine.AnnObjectCollection();

                    for (var i = 0; i < length; i++) {
                        var stamp: lt.Annotations.Engine.AnnTextObject = findAnnotationItem(newValue[i].Id);

                        if (stamp != null) {
                            selectedObjects.add(stamp);
                        }
                    }

                    if (selectedObjects.count > 0) {
                        automation.selectObjects(selectedObjects);
                    }
                }
            });

            function initializeGrid() {
                var value = optionsService.get(OptionNames.SnapToGrid);

                if (value != undefined) {
                    manager.snapToGridOptions.enableSnap = value;
                }

                value = optionsService.get(OptionNames.ShowGrid);
                if (value != undefined) {
                    manager.snapToGridOptions.showGrid = value;
                }

                value = optionsService.get(OptionNames.GridLength);
                if (value) {
                    manager.snapToGridOptions.gridLength = parseInt(value);
                }

                value = optionsService.get(OptionNames.GridSpacing);
                if (value) {
                    manager.snapToGridOptions.lineSpacing = parseInt(value);
                }
            }

            function getChanges(changes) {
                for (var key in changes) {
                    if (changes.hasOwnProperty(key)) {
                        if (changes[key].changed != "equal") {
                            switch (key) {
                                case 'editorMode':
                                    setEditorMode();
                                    break;
                                case 'editAfterDraw':
                                    manager.editObjectAfterDraw = scope.config.editAfterDraw;
                                    break;
                            }
                        }
                    }
                }
            }

            function setEditorMode() {
                automation.defaultCurrentObjectId = scope.config.editorMode == EditorMode.Draw ? lt.Annotations.Engine.AnnObject.textObjectId : lt.Annotations.Engine.AnnObject.selectObjectId;
                manager.currentObjectId = automation.defaultCurrentObjectId;
            }

            function getAnnPicture(url: string): lt.Annotations.Engine.AnnPicture {
                var picture: lt.Annotations.Engine.AnnPicture = null;

                if (url) {
                    picture = new lt.Annotations.Engine.AnnPicture(url);

                    return picture;
                }

                return picture;
            }

            function onModelChanged(newValue: Array<Models.Frame>, oldValue: Array<Models.Frame>) {
                if (!newValue)
                    return;
                newValue.forEach(function (frame: Models.Frame, index: number) {
                    if (!angular.isDefined((<any>frame).isWatching) || !(<any>frame).isWatching['Rotation']) {
                        (<any>frame).watch('Rotation', onRotationChanged);
                        //(<any>frame).watch('SequenceNumber', onSequenceNumberChanged); 
                        (<any>frame).watch('FrameNumber', onFrameNumberChanged);
                    }
                });

                removeFrames(getDiff(oldValue, newValue));
                if (newValue instanceof Array) {
                    positionFrames(newValue);
                }
            }

            function onRotationChanged(frame: Models.Frame, name: string, oldValue: any, newValue: any) {
                var stamp: lt.Annotations.Engine.AnnTextObject = findAnnotationItem(frame.Id);

                if (stamp.labels["rotation"]) {
                    stamp.labels["rotation"].text = getRotation(newValue);
                }
                automation.invalidateObject(stamp);
                return newValue;
            }

            function getRotation(value: number): string {
                if (value == Models.FrameRotation.None)
                    return '';

                return Utils.getRotation(value);
            }

            //function onSequenceNumberChanged(frame: Models.Frame, name: string, oldValue: any, newValue: any) {
            //    var stamp: lt.Annotations.Engine.AnnTextObject = findAnnotationItem(frame.Id);

            //    updateFrameNumber(stamp, frame.FrameNumber, newValue);            
            //    return newValue;
            //}

            function onFrameNumberChanged(frame: Models.Frame, name: string, oldValue: any, newValue: any) {
                var stamp: lt.Annotations.Engine.AnnTextObject = findAnnotationItem(frame.Id);

                updateFrameNumber(stamp, newValue, frame.SequenceNumber);
                return newValue;
            }

            function updateFrameNumber(stamp: lt.Annotations.Engine.AnnTextObject, frame: number, sequence: number) {
                var label: lt.Annotations.Engine.AnnLabel = stamp.labels['frameNumber'];

                if (angular.isDefined(label)) {
                    /* Reserved for capture
                    *
                    label.text = frame + ", Sequence: " + sequence;*/
                    label.text = frame.toString();
                    automation.invalidateObject(stamp);
                }
            }

            function getDiff(a: Array<Models.Frame>, b: Array<Models.Frame>): Array<Models.Frame> {
                var oldIds = {};

                b.forEach(function (box: Models.Frame) {
                    return oldIds[box.Id] = box;
                });

                return a.filter(function (box: Models.Frame) {
                    return !(box.Id in oldIds);
                });
            }

            function removeFrames(frames: Array<Models.Frame>) {
                frames.forEach(function (box: Models.Frame, index: number) {
                    var id = box.Id;
                    var stamp: lt.Annotations.Engine.AnnObject = findAnnotationItem(id);

                    if (stamp != null) {
                        automation.container.children.remove(stamp);
                    }

                    (<any>box).unwatch('Rotation');
                    (<any>box).unwatch('SequenceNumber');
                });

                if (frames.length > 0) {
                    automation.container.selectionObject.selectedObjects.clear();
                    automation.invalidateContainer(automation.container);
                }
            }

            function findAnnotationItem(id: string): lt.Annotations.Engine.AnnTextObject {
                var stamps: Array<lt.Annotations.Engine.AnnObject> = automation.container.children.toArray().filter(function (value: lt.Annotations.Engine.AnnObject, index: number) {
                    return value.tag == id;
                });

                if (stamps.length > 0) {
                    return <lt.Annotations.Engine.AnnTextObject>stamps[0];
                }
                return null;
            }

            function findFrame(id: string): Models.Frame {
                var frames: Array<Models.Frame> = ngModel.$modelValue.filter(function (value: Models.Frame, index: number) {
                    return value.Id == id;
                });

                if (frames.length > 0) {
                    return frames[0];
                }
                return null;
            }

            function positionFrames(frames: Array<Models.Frame>) {
                frames.forEach(function (box: Models.Frame, index: number) {
                    positionFrame(box);
                });

                automation.invalidate(lt.LeadRectD.empty);
            }

            function positionFrame(frame: Models.Frame) {
                var rect: lt.LeadRectD = computeRectangle(frame.Position);
                var stamp: lt.Annotations.Engine.AnnTextObject = null;
                var objects: Array<lt.Annotations.Engine.AnnTextObject> = (<Array<lt.Annotations.Engine.AnnTextObject>>automation.container.children.toArray());
                var foundObjects: Array<lt.Annotations.Engine.AnnTextObject>;

                foundObjects = objects.filter(function (object: lt.Annotations.Engine.AnnTextObject, index: number) {
                    return object.tag == frame.Id;
                });

                if (foundObjects.length > 0) {
                    stamp = foundObjects[0];
                }
                else {
                    stamp = <lt.Annotations.Engine.AnnTextObject>manager.objects.get_item(1).objectTemplate.clone();
                    stamp.tag = frame.Id;
                    if (frame.FrameNumber == -1)
                        frame.FrameNumber = getFrameNumber();
                    if (frame.SequenceNumber == -1)
                        frame.SequenceNumber = getSequenceNumber();

                    stamp.text = frame.Script;
                    automation.container.children.add(stamp);
                }

                if (stamp != null) {
                    stamp.set_rect(rect);

                    if (!stamp.labels["frameNumber"]) {
                        setLabel(stamp, frame);
                    }

                    if ((scope.selectedItems != null && scope.selectedItems.length == 1 && scope.selectedItems[0].Id == frame.Id) && !stamp.isSelected) {
                        automation.selectObject(stamp);
                    }
                }
            }

            function setLabel(stamp: lt.Annotations.Engine.AnnTextObject, box: Models.Frame) {
                var label: lt.Annotations.Engine.AnnLabel;
                var height: number;

                label = new lt.Annotations.Engine.AnnLabel();
                /* Reserved for capture
                *
                label.text = box.FrameNumber + ", Sequence: " + box.SequenceNumber;*/
                label.text = box.FrameNumber.toString();
                label.foreground = lt.Annotations.Engine.AnnSolidColorBrush.create(scope.config.foreColor);
                label.isVisible = true;
                label.restrictionMode = lt.Annotations.Engine.AnnLabelRestriction.restrictToObjectBounds;
                height = renderingEngine.measureString(label.text, label.font).height;
                label.originalPosition = lt.LeadPointD.create(0, height);
                label.positionMode = lt.Annotations.Engine.AnnLabelPositionMode.relativeToObject;
                stamp.labels["frameNumber"] = label;

                label = new lt.Annotations.Engine.AnnLabel();
                /* Reserved for capture
                *
                label.text = box.FrameNumber + ", Sequence: " + box.SequenceNumber;*/
                label.text = getRotation(box.Rotation);
                label.foreground = lt.Annotations.Engine.AnnSolidColorBrush.create(scope.config.foreColor);
                label.isVisible = true;
                label.restrictionMode = lt.Annotations.Engine.AnnLabelRestriction.restrictToObjectBounds;
                label.originalPosition = lt.LeadPointD.create(0, stamp.bounds.height - height);
                label.positionMode = lt.Annotations.Engine.AnnLabelPositionMode.relativeToObject;
                stamp.labels["rotation"] = label;
            }

            function computeRectangle(position: Models.FramePosition): lt.LeadRectD {
                var xpos1, xpos2, ypos1, ypos2: number;
                var point;
                var rect = lt.LeadRectD.create(0, 0, automation.container.size.width, automation.container.size.height);

                point = Utils.transformRectangle(dcmLayoutRect, rect, position.leftTop);
                xpos1 = point.x;
                ypos1 = point.y;

                point = Utils.transformRectangle(dcmLayoutRect, rect, position.rightBottom);
                xpos2 = point.x;
                ypos2 = point.y;

                return lt.LeadRectD.create(xpos1, ypos1, xpos2 - xpos1, Math.abs(ypos2 - ypos1));
            }

            function resizeView() {
                var container: lt.Annotations.Engine.AnnContainer = automation.container;
                var size: lt.LeadSizeD = lt.LeadSizeD.create($(elem).width(), $(elem).height());

                viewer.onSizeChanged();
                if (container != null) {
                    container.size = container.mapper.sizeToContainerCoordinates(size);
                }

                if (angular.isDefined(ngModel.$modelValue)) {
                    debouncedPosition(ngModel.$modelValue);
                }
            }

            function createAutomationObjects(automationManager: lt.Annotations.Automation.AnnAutomationManager) {
                var automationObjects: lt.Annotations.Automation.AnnAutomationObjects = automationManager.get_objects();
                var automationObject: lt.Annotations.Automation.AnnAutomationObject = null;

                automationObject = new lt.Annotations.Automation.AnnAutomationObject();
                automationObject.set_id(lt.Annotations.Engine.AnnObject.selectObjectId);
                automationObject.set_name("Select");
                automationObject.set_drawDesignerType(lt.Annotations.Designers.AnnRectangleDrawDesigner);
                automationObject.set_editDesignerType(lt.Annotations.Designers.AnnSelectionEditDesigner);
                automationObject.set_runDesignerType(null);

                var selectionObject: lt.Annotations.Engine.AnnSelectionObject = new lt.Annotations.Engine.AnnSelectionObject();

                selectionObject.set_stroke(lt.Annotations.Engine.AnnStroke.create(lt.Annotations.Engine.AnnSolidColorBrush.create("darkgreen"), lt.LeadLengthD.create(2)));
                automationObject.set_objectTemplate(selectionObject);

                automationObjects.add(automationObject);

                automationObject = new lt.Annotations.Automation.AnnAutomationObject();
                automationObject.set_id(lt.Annotations.Engine.AnnObject.textObjectId);
                automationObject.set_name("Text");
                automationObject.set_drawDesignerType(lt.Annotations.Designers.AnnRectangleDrawDesigner);
                automationObject.set_editDesignerType(lt.Annotations.Designers.AnnTextEditDesigner);
                automationObject.set_runDesignerType(lt.Annotations.Designers.AnnRunDesigner);
                automationObject.useRotateThumbs = false;

                //
                // Create the object template for it, use the default stroke and fill
                //
                var textObject: lt.Annotations.Engine.AnnTextObject = new lt.Annotations.Engine.AnnTextObject();


                textObject.fill = lt.Annotations.Engine.AnnSolidColorBrush.create(scope.config.backgroundColor);
                textObject.text = "";
                textObject.stroke = lt.Annotations.Engine.AnnStroke.create(lt.Annotations.Engine.AnnSolidColorBrush.create(scope.config.borderColor), lt.LeadLengthD.create(scope.config.borderSize));

                automationObject.set_objectTemplate(textObject);
                automationObjects.add(automationObject);
            }

            function setThumbPreferences(renderers: { [key: number]: lt.Annotations.Engine.IAnnObjectRenderer }) {
                var bigThumbSize = 80 * 2;
                var smallThumbSize = 80;
                var locationThumbStyle: lt.Annotations.Rendering.AnnRectangleThumbStyle = new lt.Annotations.Rendering.AnnRectangleThumbStyle();
                var rotateCenterThumbStyle = new lt.Annotations.Rendering.AnnEllipseThumbStyle();
                var rotateGripperThumbStyle = new lt.Annotations.Rendering.AnnEllipseThumbStyle();

                if (lt.LTHelper.device == lt.LTDevice.desktop) {
                    locationThumbStyle.set_size(lt.LeadSizeD.create(smallThumbSize, smallThumbSize));
                } else {
                    locationThumbStyle.set_size(lt.LeadSizeD.create(bigThumbSize, bigThumbSize));
                }

                locationThumbStyle.set_stroke(lt.Annotations.Engine.AnnStroke.create(lt.Annotations.Engine.AnnSolidColorBrush.create('black'), lt.LeadLengthD.create(1)));
                locationThumbStyle.set_fill(lt.Annotations.Engine.AnnSolidColorBrush.create('rgba(173, 216, 230, 1)'));

                rotateCenterThumbStyle.isVisible = false;
                rotateGripperThumbStyle.isVisible = false;

                for (var $key2 in renderers) {
                    var item = { key: $key2, value: renderers[$key2] };
                    var renderer: lt.Annotations.Engine.IAnnObjectRenderer = item.value;

                    renderer.set_locationsThumbStyle(locationThumbStyle);
                    renderer.set_rotateCenterThumbStyle(rotateCenterThumbStyle);
                    renderer.set_rotateGripperThumbStyle(rotateGripperThumbStyle);
                }
            }

            function onCurrentDesignerChanged(sender, e: lt.LeadEventArgs) {
                if (automation.currentDesigner instanceof lt.Annotations.Designers.AnnTextEditDesigner) {
                    var editDesigner: lt.Annotations.Designers.AnnTextEditDesigner = <lt.Annotations.Designers.AnnTextEditDesigner>(automation.currentDesigner);

                    editDesigner.add_edit(onTextEdit);
                }
            }

            function onTextEdit(sender, e: lt.Annotations.Engine.AnnEditDesignerEventArgs) {
                if (e.object instanceof lt.Annotations.Engine.AnnTextObject) {
                    var stamp: lt.Annotations.Engine.AnnTextObject = <lt.Annotations.Engine.AnnTextObject>e.object;

                    if (e.operation == lt.Annotations.Engine.AnnEditDesignerOperation.move && e.operationStatus == lt.Annotations.Engine.AnnDesignerOperationStatus.start && scope.cancelMove) {
                        e.cancel = true;
                        return;
                    }

                    if (e.operation == lt.Annotations.Engine.AnnEditDesignerOperation.moveThumb && e.operationStatus == lt.Annotations.Engine.AnnDesignerOperationStatus.working) {
                        if (stamp.labels["rotation"]) {
                            var height = renderingEngine.measureString(stamp.labels["rotation"].text, stamp.labels["rotation"].font).height;

                            stamp.labels["rotation"].originalPosition = lt.LeadPointD.create(0, stamp.bounds.bottom - height);
                        }
                    }

                    if (e.operation == lt.Annotations.Engine.AnnEditDesignerOperation.move && e.operationStatus == lt.Annotations.Engine.AnnDesignerOperationStatus.working) {
                        var bounds: lt.LeadRectD = stamp.bounds;
                        var x, y: number;

                        x = bounds.left;
                        y = bounds.top;

                        if (bounds.width > 0) {

                            //
                            // Change rectangle if the object is about to go out of bounds                            
                            //

                            if (scope.config.boundsNotification) {
                                if (x < 0 || y < 0 || ((automation.container.size.height - bounds.bottom) < 0) || ((automation.container.size.width - bounds.right) < 0)) {
                                    stamp.stroke.strokeThickness = lt.LeadLengthD.create(3);
                                    stamp.stroke.strokeDashArray = [5, 5, 2, 5];
                                    function doAnts() {
                                        if (stamp.stroke.strokeDashArray != null) {
                                            var offset = stamp.stroke.strokeDashOffset;

                                            if (offset > 100) {
                                                offset = 0;
                                            }
                                            stamp.stroke.strokeDashOffset = offset + 1;
                                            automation.invalidateObject(stamp);
                                            setTimeout(function () {
                                                doAnts();
                                            }, 10);
                                        }
                                    }
                                    doAnts();
                                }
                                else {
                                    if (stamp.stroke.strokeDashArray != null) {
                                        stamp.stroke.strokeThickness = lt.LeadLengthD.create(scope.config.borderSize);
                                        stamp.stroke.strokeDashArray = null;
                                    }
                                }
                            }
                        }
                    }

                    if ((e.operation == lt.Annotations.Engine.AnnEditDesignerOperation.move || e.operation == lt.Annotations.Engine.AnnEditDesignerOperation.moveThumb)
                        && e.operationStatus == lt.Annotations.Engine.AnnDesignerOperationStatus.end) {
                        updatePosition(stamp);
                        if (scope.config.boundsNotification && stamp.stroke.strokeDashArray != null) {
                            stamp.stroke.strokeThickness = lt.LeadLengthD.create(scope.config.borderSize);
                            stamp.stroke.strokeDashArray = null;
                        }
                    }
                }
            }

            function onTextDraw(sender, e: lt.Annotations.Engine.AnnDrawDesignerEventArgs) {
                if (e.operationStatus == lt.Annotations.Engine.AnnDesignerOperationStatus.end && (e.object instanceof lt.Annotations.Engine.AnnTextObject)) {
                    var stamp: lt.Annotations.Engine.AnnTextObject = <lt.Annotations.Engine.AnnTextObject>e.object;

                    //
                    // If the user id is null then we do not have an Image Box for this annotation stamp.  Need to create one.
                    //
                    if (stamp.tag == null) {
                        var position: Models.FramePosition = getPosition(stamp.rect);
                        var box: Models.Frame = new Models.Frame(position);

                        stamp.tag = box.Id;
                        stamp.text = optionsService.get(OptionNames.DefaultScript);
                        box.FrameNumber = getFrameNumber();
                        box.SequenceNumber = getSequenceNumber();
                        setLabel(stamp, box);
                        ngModel.$modelValue.push(box);

                        scope.onNewFrame({ frame: box });
                    }
                }
            }

            function onEditText(sender, e: lt.Annotations.Engine.AnnEditTextEventArgs) {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/ScriptEditor.html',
                    controller: Controllers.ScriptEditorController,
                    backdrop: 'static',
                    size: 'lg',
                    resolve: {
                        label: function () {
                            return "Script";
                        },
                        text: function () {
                            return e.textObject.text;
                        },
                        readOnly: function () {
                            var frame: Models.Frame = findFrame(e.textObject.tag);

                            return (<any>frame).readOnly;
                        },
                    }
                });

                modalInstance.result.then(function (text) {
                    var oldText = e.textObject.text;

                    if (oldText != text) {
                        e.get_textObject().set_text(text);
                        automation.get_automationControl().automationInvalidate(lt.LeadRectD.empty);
                        if (scope.config.onFrameChanged) {
                            var frame: Models.Frame = findFrame(e.textObject.tag);

                            frame.Script = text;
                            scope.config.onFrameChanged(frame, null);
                        }
                    }
                });
            }

            function moveCaretToEnd(element: HTMLTextAreaElement): void {
                if (typeof element.selectionStart == "number") {
                    element.selectionStart = element.selectionEnd = element.value.length;
                } else if (typeof (element["createTextRange"]) != "undefined") {
                    element.focus();
                    var range: any = element["createTextRange"];
                    range.collapse(false);
                    range.select();
                }
            }

            function automation_GotFocus(sender, e, id) {
                var parent = viewer.get_foreCanvas().parentNode;
                var child: any = document.getElementById(id);

                if (child) {
                    child.userData.set_text(child.value);
                    parent.removeChild(child);
                    automation.get_automationControl().automationInvalidate(lt.LeadRectD.empty);
                }
            }

            function onBeforeObjectChanged(sender, e: lt.Annotations.Automation.AnnBeforeObjectChangedEventArgs) {
                if (e.changeType == lt.Annotations.Automation.AnnObjectChangedType.deleted) {
                    for (var i = 0; i < e.objects.count; i++) {
                        var stamp: lt.Annotations.Engine.AnnTextObject = <lt.Annotations.Engine.AnnTextObject>e.objects.get_item(i);
                        var imageBox: Array<Models.Frame> = ngModel.$modelValue.filter(function (box: Models.Frame) {
                            return box.Id == stamp.tag;
                        });

                        // 
                        // Remove imagebox since the stamp object has been deleted
                        //
                        if (imageBox.length > 0) {
                            ngModel.$modelValue.splice(ngModel.$modelValue.indexOf(imageBox[0]), 1);
                        }
                    }
                }
            }

            function onAfterObjectChanged(sender, e: lt.Annotations.Automation.AnnAfterObjectChangedEventArgs) {
                var count: number = e.objects.count;

                if (e.changeType == lt.Annotations.Automation.AnnObjectChangedType.picture) {
                    automation.invalidate(lt.LeadRectD.empty);
                }

                for (var i = 0; i < count; i++) {

                    if (e.objects.item(i) instanceof lt.Annotations.Engine.AnnSelectionObject) {
                        var selectionObject: lt.Annotations.Engine.AnnSelectionObject = <lt.Annotations.Engine.AnnSelectionObject>(e.objects.item(i));
                        var selectCount = selectionObject.selectedObjects.count;

                        for (var x = 0; x < selectCount; x++) {
                            var stamp: lt.Annotations.Engine.AnnTextObject = <lt.Annotations.Engine.AnnTextObject>(selectionObject.selectedObjects.item(x));
                            var frame: Models.Frame = findFrame(stamp.tag);

                            if (frame) {
                                var position: Models.FramePosition = getPosition(stamp.rect);

                                frame.Position = position;
                                scope.config.onFrameChanged(frame, e);
                            }
                        }
                    }
                    else {
                        if (scope.config.onFrameChanged) {
                            var stamp: lt.Annotations.Engine.AnnTextObject = <lt.Annotations.Engine.AnnTextObject>(e.objects.item(i));
                            var frame: Models.Frame = findFrame(stamp.tag);

                            if (frame) {
                                scope.config.onFrameChanged(frame, e);
                            }
                        }
                    }
                }
            }

            function onSelectedObjectsChanged(sender, e: lt.LeadEventArgs) {
                var selectedItems = automation.container.get_selectionObject().get_selectedObjects();

                if (selectedItems.count > 0 && scope.config.onSelectedItemsChanged) {
                    var boxes: Array<Models.Frame> = new Array<Models.Frame>();

                    for (var i = 0; i < selectedItems.count; i++) {
                        var stamp: lt.Annotations.Engine.AnnTextObject = <lt.Annotations.Engine.AnnTextObject>(selectedItems.item(i));
                        var box: Models.Frame = findFrame(stamp.tag);

                        boxes.push(box);
                    }

                    scope.config.onSelectedItemsChanged(boxes);
                    return;
                }
                scope.selectedItems = null;
                if (scope.config.onSelectedItemsChanged) {
                    scope.config.onSelectedItemsChanged(new Array<Models.Frame>());
                }
            }

            function updatePosition(stamp: lt.Annotations.Engine.AnnTextObject) {
                var foundObjects: Array<Models.Frame> = ngModel.$modelValue.filter(function (object: Models.Frame, index: number) {
                    return stamp.tag == object.Id;
                });

                if (foundObjects.length > 0) {
                    var frame: Models.Frame = foundObjects[0];

                    frame.Position = getPosition(stamp.rect);
                }
            }

            function getPosition(rect: lt.LeadRectD): Models.FramePosition {
                var position: Models.FramePosition = new Models.FramePosition();

                position.leftTop = new lt.LeadPointD();
                position.leftTop.x = rect.left / automation.container.size.width;
                position.leftTop.y = 1 - (rect.top / automation.container.size.height);

                position.rightBottom = new lt.LeadPointD();
                position.rightBottom.x = position.leftTop.x + rect.width / automation.container.size.width;
                position.rightBottom.y = position.leftTop.y - rect.height / automation.container.size.height;


                return position;
            }

            function getFrameNumber() {
                var sortedList: Array<number> = getSortedList("FrameNumber");

                return getNextNumber(sortedList);
            }

            function getSequenceNumber() {
                var sortedList = getSortedList("SequenceNumber");

                return getNextNumber(sortedList);
            }

            function getSortedList(property: string): Array<number> {
                var list: Array<number> = new Array<number>();

                for (var i = 0; i < ngModel.$modelValue.length; i++) {
                    var box: Models.Frame = ngModel.$modelValue[i];

                    if (box[property] == -1)
                        continue;

                    list.push(box[property]);
                }

                return list.sort((a: number, b: number) => {
                    if (a > b) {
                        return 1;
                    }

                    if (a < b) {
                        return -1;
                    }

                    return 0;
                })
            }

            function getNextNumber(sequence: Array<number>) {
                var nextSquence = function formula(n) { return n + 1; }
                var i = 0;

                for (; i < sequence.length; i++) {
                    var x = nextSquence(i);

                    if (sequence[i] != x) {
                        sequence.splice(i, 0, x); // insert x here
                        sequence.length = 10; // chop of rest
                        return x;
                    }
                }
                return i + 1;
            }
        }
    }
}]);