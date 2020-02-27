// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module lt.Annotations.JavaScript {
   export enum AnnCursorType {
      selectObject,
      selectedObject,
      controlPoint,
      controlPointNWSE,
      controlPointNS,
      controlPointNESW,
      controlPointWE,
      selectRectangle,
      run,
      rotateCenterControlPoint,
      rotateGripperControlPoint,
      Default,
      count
   }

   export class AutomationManagerHelper {
      private _manager: lt.Annotations.Automation.AnnAutomationManager;

      public get automationManager(): lt.Annotations.Automation.AnnAutomationManager {
         return this._manager;
      }

      // The path to the resources. This is thee default value. Will replace all ##RESOURCES_PATH## in the code
      private _resourcesPath = "../Resources";
      public static _resourcesTamplate: string = "##RESOURCES_PATH##";

      private static _drawCursorsTemplate: { [objectId: string]: string } = {
         "-2":  "url('##RESOURCES_PATH##/Cursors/Draw/ToolLine.cur'),default",
         "-3":  "url('##RESOURCES_PATH##/Cursors/Draw/ToolRectangle.cur'),default",
         "-4":  "url('##RESOURCES_PATH##/Cursors/Draw/ToolEllipse.cur'),default",
         "-5":  "url('##RESOURCES_PATH##/Cursors/Draw/ToolPolyline.cur'),default",
         "-6":  "url('##RESOURCES_PATH##/Cursors/Draw/ToolPolygon.cur'),default",
         "-7":  "url('##RESOURCES_PATH##/Cursors/Draw/ToolCurve.cur'),default",
         "-8":  "url('##RESOURCES_PATH##/Cursors/Draw/ToolClosedCurve.cur'),default",
         "-9":  "url('##RESOURCES_PATH##/Cursors/Draw/ToolPointer.cur'),default",
         "-10": "url('##RESOURCES_PATH##/Cursors/Draw/ToolFreehand.cur'),default",
         "-11": "url('##RESOURCES_PATH##/Cursors/Draw/ToolHilite.cur'),default",
         "-12": "url('##RESOURCES_PATH##/Cursors/Draw/ToolText.cur'),default",
         "-14": "url('##RESOURCES_PATH##/Cursors/Draw/ToolTextPointer.cur'),default",
         "-15": "url('##RESOURCES_PATH##/Cursors/Draw/ToolNote.cur'),default",
         "-16": "url('##RESOURCES_PATH##/Cursors/Draw/ToolStamp.cur'),default",
         "-17": "url('##RESOURCES_PATH##/Cursors/Draw/ToolRubberStamp.cur'),default",
         "-18": "url('##RESOURCES_PATH##/Cursors/Draw/ToolHotspot.cur'),default",
         "-19": "url('##RESOURCES_PATH##/Cursors/Draw/ToolFreehandHotspot.cur'),default",
         "-21": "url('##RESOURCES_PATH##/Cursors/Draw/ToolPoint.cur'),default",
         "-22": "url('##RESOURCES_PATH##/Cursors/Draw/ToolRedaction.cur'),default",
         "-23": "url('##RESOURCES_PATH##/Cursors/Draw/ToolRuler.cur'),default",
         "-24": "url('##RESOURCES_PATH##/Cursors/Draw/ToolPolyruler.cur'),default",
         "-25": "url('##RESOURCES_PATH##/Cursors/Draw/ToolProtractor.cur'),default",
         "-26": "url('##RESOURCES_PATH##/Cursors/Draw/ToolCrossProduct.cur'),default",
         "-13": "url('##RESOURCES_PATH##/Cursors/Draw/ToolTextRollup.cur'),default",
         "-28": "url('##RESOURCES_PATH##/Cursors/Draw/ToolAudio.cur'),default",
         "-30": "url('##RESOURCES_PATH##/Cursors/Draw/ToolVideo.cur'),default",
         "-27": "url('##RESOURCES_PATH##/Cursors/Draw/ToolEncrypt.cur'),default"
      };

      private static _objectsImagesTemplate: { [objectId: string]: string } = {
         "-2":  "##RESOURCES_PATH##/Images/Icons/Line.png",
         "-3":  "##RESOURCES_PATH##/Images/Icons/Rectangle.png",
         "-4":  "##RESOURCES_PATH##/Images/Icons/Circle.png",
         "-5":  "##RESOURCES_PATH##/Images/Icons/Polyline.png",
         "-6":  "##RESOURCES_PATH##/Images/Icons/Polygon.png",
         "-7":  "##RESOURCES_PATH##/Images/Icons/SCurve.png",
         "-8":  "##RESOURCES_PATH##/Images/Icons/BSpline.png",
         "-9":  "##RESOURCES_PATH##/Images/Icons/Pointer.png",
         "-10": "##RESOURCES_PATH##/Images/Icons/Pen.png",
         "-11": "##RESOURCES_PATH##/Images/Icons/Highlight.png",
         "-12": "##RESOURCES_PATH##/Images/Icons/A.png",
         "-14": "##RESOURCES_PATH##/Images/Icons/AArrow.png",
         "-15": "##RESOURCES_PATH##/Images/Icons/Note.png",
         "-16": "##RESOURCES_PATH##/Images/Icons/Image.png",
         "-17": "##RESOURCES_PATH##/Images/Icons/Stamp.png",
         "-18": "##RESOURCES_PATH##/Images/Icons/H.png",
         "-19": "##RESOURCES_PATH##/Images/Icons/HSquiggles.png",
         "-21": "##RESOURCES_PATH##/Images/Icons/RoundX.png",
         "-22": "##RESOURCES_PATH##/Images/Icons/Redact.png",
         "-23": "##RESOURCES_PATH##/Images/Icons/Ruler.png",
         "-24": "##RESOURCES_PATH##/Images/Icons/90DegreeRuler.png",
         "-25": "##RESOURCES_PATH##/Images/Icons/Protractor.png",
         "-26": "##RESOURCES_PATH##/Images/Icons/Intersect.png",
         "-13": "##RESOURCES_PATH##/Images/Icons/Pin.png",
         "-28": "##RESOURCES_PATH##/Images/Icons/Sound.png",
         "-30": "##RESOURCES_PATH##/Images/Icons/Video.png",
         "-27": "##RESOURCES_PATH##/Images/Icons/Lock.png",
         "-33": "##RESOURCES_PATH##/Images/Icons/THighlight.png",
         "-34": "##RESOURCES_PATH##/Images/Icons/Strikethrough.png",
         "-35": "##RESOURCES_PATH##/Images/Icons/Underline.png",
         "-36": "##RESOURCES_PATH##/Images/Icons/TRedact.png",
         "-32": "##RESOURCES_PATH##/Images/Icons/StickyNotes.png",
      };

      private _drawCursors: { [objectId: string]: string } = {};
      get drawCursors(): { [objectId: string]: string } {
         return this._drawCursors;
      }

      private _objectsImages: { [objectId: string]: string } = {};

      private static _undoImageUrlTemplate: string = "url('##RESOURCES_PATH##/Images/Icons/Undo.png')";

      private static _automationCursors: { [key: number]: string } = {};
      get automationCursors(): { [key: number]: string } {
         return AutomationManagerHelper._automationCursors;
      }

      constructor(manager: lt.Annotations.Automation.AnnAutomationManager, resourcesPath: string) {
         if (manager == null) alert("Error, AnnAutomationManager is null");

         this._manager = manager;

         if (this._manager.renderingEngine == null) {
            this._manager.renderingEngine = new lt.Annotations.Rendering.AnnHtml5RenderingEngine();
         }

         AutomationManagerHelper._automationCursors[AnnCursorType.controlPoint] = "url('##RESOURCES_PATH##/Cursors/Edit/ControlPoint.cur'),default";
         AutomationManagerHelper._automationCursors[AnnCursorType.rotateCenterControlPoint] = "url('##RESOURCES_PATH##/Cursors/Edit/Anchor.cur'), default";
         AutomationManagerHelper._automationCursors[AnnCursorType.rotateGripperControlPoint] = "url('##RESOURCES_PATH##/Cursors/Edit/Rotate.cur'),default";
         AutomationManagerHelper._automationCursors[AnnCursorType.selectObject] = "url('##RESOURCES_PATH##/Cursors/Edit/SelectObject.cur'), default";
         AutomationManagerHelper._automationCursors[AnnCursorType.selectedObject] = "url('##RESOURCES_PATH##/Cursors/Edit/SelectedObject.cur'),default";
         AutomationManagerHelper._automationCursors[AnnCursorType.run] = "pointer";

         // Update the resources
         this.updateResourcePaths(resourcesPath);

         // To track modifier keys
         if (lt.LTHelper.supportsMouse) {
            // Tell lt.Controls.InteractiveService to listen for modifier keys even if no ImageViewer exists
            lt.Controls.InteractiveService.registerGlobalModifierKeys();

            // Initialize the platform callbacks
            var callbacks = lt.Annotations.Automation.AnnAutomationManager.platformCallbacks;
            callbacks.checkModifier = AutomationManagerHelper.checkModifierKey;
         }

         this.updateAutomationObjects();
      }

      private updateResourcePaths(resourcesPath: string): void {
         for (var key in AutomationManagerHelper._drawCursorsTemplate) {
            var originalValue = AutomationManagerHelper._drawCursorsTemplate[key];
            var thisValue = originalValue.replace(AutomationManagerHelper._resourcesTamplate, resourcesPath);
            this._drawCursors[key] = thisValue;
         }

         for (var key in AutomationManagerHelper._objectsImagesTemplate) {
            var originalValue = AutomationManagerHelper._objectsImagesTemplate[key];
            var thisValue = originalValue.replace(AutomationManagerHelper._resourcesTamplate, resourcesPath);
            this._objectsImages[key] = thisValue;
         }

         AutomationManagerHelper._automationCursors[AnnCursorType.controlPoint] = AutomationManagerHelper._automationCursors[AnnCursorType.controlPoint].replace(AutomationManagerHelper._resourcesTamplate, resourcesPath);
         AutomationManagerHelper._automationCursors[AnnCursorType.rotateCenterControlPoint] = AutomationManagerHelper._automationCursors[AnnCursorType.rotateCenterControlPoint].replace(AutomationManagerHelper._resourcesTamplate, resourcesPath);
         AutomationManagerHelper._automationCursors[AnnCursorType.rotateGripperControlPoint] = AutomationManagerHelper._automationCursors[AnnCursorType.rotateGripperControlPoint].replace(AutomationManagerHelper._resourcesTamplate, resourcesPath);
         AutomationManagerHelper._automationCursors[AnnCursorType.selectObject] = AutomationManagerHelper._automationCursors[AnnCursorType.selectObject].replace(AutomationManagerHelper._resourcesTamplate, resourcesPath);
         AutomationManagerHelper._automationCursors[AnnCursorType.selectedObject] = AutomationManagerHelper._automationCursors[AnnCursorType.selectedObject].replace(AutomationManagerHelper._resourcesTamplate, resourcesPath);
         //ReviewTreeNode.undoImageUrl = AutomationManagerHelper._undoImageUrlTemplate.replace(AutomationManagerHelper._resourcesTamplate, resourcesPath);
      }

      public updateAutomationObjects(): void {
         if (this._manager == null)
            return;

         for (var i = 0; i < this._manager.objects.count; i++) {
            var automationObject = this._manager.objects.item(i);
            AutomationManagerHelper.updateAutomationObject(automationObject);
         }
      }

      private static updateAutomationObject(automationObject: lt.Annotations.Automation.AnnAutomationObject): void {
         if (automationObject.objectTemplate != null && automationObject.objectTemplate.supportsFill && automationObject.objectTemplate.fill == null)
            automationObject.objectTemplate.fill = lt.Annotations.Engine.AnnSolidColorBrush.create("transparent");
      }

      // Gets the cursor for the automation object with this id
      public getAutomationObjectCursor(objectId: number): any {
         //don't add cursors for the these objects
         if (objectId == lt.Annotations.Engine.AnnObject.imageObjectId)
            return null;

         if (objectId == lt.Annotations.Engine.AnnObject.textHiliteObjectId ||
            objectId == lt.Annotations.Engine.AnnObject.textStrikeoutObjectId ||
            objectId == lt.Annotations.Engine.AnnObject.textUnderlineObjectId ||
            objectId == lt.Annotations.Engine.AnnObject.textRedactionObjectId)
            return "text";

         if (objectId == lt.Annotations.Engine.AnnObject.stickyNoteObjectId)
            return "crosshair";

         var annObject = this._manager.findObjectById(objectId);

         if (annObject != null) {
            return this._drawCursors[objectId.toString()];
         }

         return null;
      }

      public getAutomationObjectImage(objectId: number): any {
         var annObject = this._manager.findObjectById(objectId);

         if (annObject != null) {
            return this._objectsImages[objectId.toString()];
         }

         return null;
      }

      private static checkModifierKey(annKey: lt.Annotations.Engine.AnnKeys): boolean {
         // Map the AnnKeys to our lt.Controls modifier keys so we don't have to listen for keyup/keydown ourself.
         var AnnKeys = lt.Annotations.Engine.AnnKeys;
         var ControlsKeys = lt.Controls.Keys;
         var ControlsModifierKeys = lt.Controls.InteractiveService.modifierKeys;

         if ((annKey & AnnKeys.shift) == AnnKeys.shift)
            return (ControlsModifierKeys & ControlsKeys.shift) === ControlsKeys.shift;
         if ((annKey & lt.Annotations.Engine.AnnKeys.control) == lt.Annotations.Engine.AnnKeys.control)
            return (ControlsModifierKeys & ControlsKeys.control) === ControlsKeys.control;
         if ((annKey & lt.Annotations.Engine.AnnKeys.alt) == lt.Annotations.Engine.AnnKeys.alt)
            return (ControlsModifierKeys & ControlsKeys.alt) === ControlsKeys.alt;
         return false;
      }

      LoadPackage(annPackage: lt.Annotations.Automation.IAnnPackage): void {
         if (annPackage != null) {
            // Update the automation objects as we load ...
            var handler = this._manager.objects.collectionChanged.add((sender, e) => {
               if (e.action == lt.NotifyLeadCollectionChangedAction.add) {
                  for (var i = 0; i < e.newItems.length; i++)
                     var automationObject = <lt.Annotations.Automation.AnnAutomationObject>e.newItems[i];
                  AutomationManagerHelper.updateAutomationObject(automationObject);
               }
            });

            this._manager.loadPackage(annPackage, annPackage.get_friendlyName());
            this._manager.objects.collectionChanged.remove(handler);
         }
      }
   }
}
