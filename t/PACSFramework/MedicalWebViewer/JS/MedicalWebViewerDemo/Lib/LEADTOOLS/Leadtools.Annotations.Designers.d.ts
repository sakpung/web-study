//***********************************************************************************************
//   Type definitions for Leadtools.Annotations.Designers.js
//   Updated: 12/3/2019 19:00
//   Version: 20.0.0.9
//
//   Dependencies:
//      Leadtools.d.ts
//      Leadtools.Annotations.Engine.d.ts
//
//   Copyright (c) 1991-2019 All Rights Reserved. LEAD Technologies, Inc.
//   https://www.leadtools.com
//***********************************************************************************************

declare module lt.Annotations.Designers {

   class AnnDesigner {
      get_isMouseLeftButtonDown(): boolean;
      set_isMouseLeftButtonDown(value: boolean): void;
      get_targetObject(): lt.Annotations.Engine.AnnObject;
      set_targetObject(value: lt.Annotations.Engine.AnnObject): void;
      get_finalTargetObject(): lt.Annotations.Engine.AnnObject;
      get_container(): lt.Annotations.Engine.AnnContainer;  // protected
      set_restrictDesigners(value: boolean): void;
      get_restrictDesigners(): boolean;
      get_clipRectangle(): lt.LeadRectD;  // protected
      clipPoint(point: lt.LeadPointD, clipRect: lt.LeadRectD): lt.LeadPointD;  // protected
      getRenderer(): lt.Annotations.Engine.IAnnObjectRenderer;
      get_automationControl(): lt.Annotations.Engine.IAnnAutomationControl;
      invalidate(rc: lt.LeadRectD): void;
      get_hasStarted(): boolean;
      start(): void;
      end(): void;
      cancel(): void;
      onPointerDoubleClick(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerDown(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerUp(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerMove(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      snapPointToGrid(position: lt.LeadPointD, clipToContainer: boolean): lt.LeadPointD;
      get_snapToGridOptions(): lt.Annotations.Engine.AnnSnapToGridOptions;
      set_snapToGridOptions(value: lt.Annotations.Engine.AnnSnapToGridOptions): void;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annObject: lt.Annotations.Engine.AnnObject);
      isMouseLeftButtonDown: boolean;
      targetObject: lt.Annotations.Engine.AnnObject;
      finalTargetObject: lt.Annotations.Engine.AnnObject; // read-only
      container: lt.Annotations.Engine.AnnContainer; // read-only
      restrictDesigners: boolean;
      clipRectangle: lt.LeadRectD; // read-only
      automationControl: lt.Annotations.Engine.IAnnAutomationControl; // read-only
      hasStarted: boolean; // read-only
      snapToGridOptions: lt.Annotations.Engine.AnnSnapToGridOptions;
   }

   class AnnCrossProductDrawDesigner extends AnnDrawDesigner {
      onPointerDown(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerMove(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerUp(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annCrossProductObject: lt.Annotations.Engine.AnnCrossProductObject);
   }

   class AnnDrawDesigner extends AnnDesigner {
      get_operationStatus(): lt.Annotations.Engine.AnnDesignerOperationStatus;
      add_draw(value: lt.Annotations.Engine.AnnDrawDesignerEventHandler): void;
      remove_draw(value: lt.Annotations.Engine.AnnDrawDesignerEventHandler): void;
      start(): void;
      end(): void;
      onDraw(e: lt.Annotations.Engine.AnnDrawDesignerEventArgs): void;  // protected
      get_isTargetObjectAdded(): boolean;
      startWorking(): boolean;  // protected
      working(): boolean;  // protected
      cancel(): void;
      endWorking(): boolean;  // protected
      get_extendedMode(): boolean;
      set_extendedMode(value: boolean): void;
      get_extendedModeModifierKey(): lt.Annotations.Engine.AnnKeys;
      set_extendedModeModifierKey(value: lt.Annotations.Engine.AnnKeys): void;
      get_isExtendedMode(): boolean;  // protected
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annObject: lt.Annotations.Engine.AnnObject);
      operationStatus: lt.Annotations.Engine.AnnDesignerOperationStatus; // read-only
      isTargetObjectAdded: boolean; // read-only
      extendedMode: boolean;
      extendedModeModifierKey: lt.Annotations.Engine.AnnKeys;
      isExtendedMode: boolean; // read-only
      draw: lt.Annotations.Engine.AnnDrawDesignerEventType; // read-only
   }

   class AnnFreehandDrawDesigner extends AnnDrawDesigner {
      get_spacing(): number;
      set_spacing(value: number): void;
      onPointerDown(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerMove(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerUp(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annPolylineObject: lt.Annotations.Engine.AnnPolylineObject);
      spacing: number;
   }

   class AnnFreeHandSelectionDrawDesigner extends AnnFreehandDrawDesigner {
      get_finalTargetObject(): lt.Annotations.Engine.AnnObject;
      startWorking(): boolean;  // protected
      endWorking(): boolean;  // protected
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annRectangleObject: lt.Annotations.Engine.AnnRectangleObject);
      finalTargetObject: lt.Annotations.Engine.AnnObject; // read-only
   }

   class AnnLineDrawDesigner extends AnnPolylineDrawDesigner {
      onPointerDown(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerMove(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerUp(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerDoubleClick(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annLineObject: lt.Annotations.Engine.AnnPolylineObject);
   }

   class AnnPointDrawDesigner extends AnnDrawDesigner {
      onPointerDown(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annPointObject: lt.Annotations.Engine.AnnPointObject);
   }

   class AnnPolylineDrawDesigner extends AnnDrawDesigner {
      get_firstPointOnClick(): boolean;
      set_firstPointOnClick(value: boolean): void;
      onPointerDown(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerMove(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerUp(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerDoubleClick(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      endWorking(): boolean;  // protected
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annPolylineObject: lt.Annotations.Engine.AnnPolylineObject);
      firstPointOnClick: boolean;
   }

   class AnnProtractorDrawDesigner extends AnnDrawDesigner {
      onPointerDown(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerMove(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerUp(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annProtractorObject: lt.Annotations.Engine.AnnProtractorObject);
   }

   class AnnRectangleDrawDesigner extends AnnDrawDesigner {
      get_drawOnClick(): boolean;
      set_drawOnClick(value: boolean): void;
      onPointerDown(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerMove(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerUp(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annRectObject: lt.Annotations.Engine.AnnRectangleObject);
      drawOnClick: boolean;
   }

   class AnnStickyNoteDrawDesigner extends AnnDrawDesigner {
      onPointerDown(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annStickyNoteObject: lt.Annotations.Engine.AnnStickyNoteObject);
   }

   class AnnTextPointerDrawDesigner extends AnnDrawDesigner {
      get_defaultText(): string;
      set_defaultText(value: string): void;
      cancel(): void;
      endWorking(): boolean;  // protected
      onPointerDown(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerMove(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerUp(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annTextPointerObject: lt.Annotations.Engine.AnnTextPointerObject);
      defaultText: string;
   }

   class AnnTextReviewDrawDesigner extends AnnRectangleDrawDesigner {
      get_finalTargetObject(): lt.Annotations.Engine.AnnObject;
      endWorking(): boolean;  // protected
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annTextReviewObject: lt.Annotations.Engine.AnnTextReviewObject);
      finalTargetObject: lt.Annotations.Engine.AnnObject; // read-only
   }

   class AnnCrossProductEditDesigner extends AnnEditDesigner {
      getThumbLocations(): lt.LeadPointD[];
      moveThumb(thumbIndex: number, offset: lt.LeadPointD): void;  // protected
      move(offsetX: number, offsetY: number): void;  // protected
      getRotationReferencePoints(): lt.LeadPointD[];  // protected
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annCrossProductObject: lt.Annotations.Engine.AnnCrossProductObject);
   }

   class AnnEditDesigner extends AnnDesigner {
      add_editContent(value: lt.Annotations.Engine.AnnEditContentEventHandler): void;
      remove_editContent(value: lt.Annotations.Engine.AnnEditContentEventHandler): void;
      get_rotateModifierKey(): lt.Annotations.Engine.AnnKeys;
      set_rotateModifierKey(value: lt.Annotations.Engine.AnnKeys): void;
      add_edit(value: lt.Annotations.Engine.AnnEditDesignerEventHandler): void;
      remove_edit(value: lt.Annotations.Engine.AnnEditDesignerEventHandler): void;
      getRotationReferencePoints(): lt.LeadPointD[];  // protected
      getRotateCenterPoint(): lt.LeadPointD;  // protected
      getRotateGripper(): lt.LeadPointD;
      get_useRotateThumbs(): boolean;
      set_useRotateThumbs(value: boolean): void;
      getThumbLocations(): lt.LeadPointD[];
      get_thumbsHitTestBuffer(): number;
      set_thumbsHitTestBuffer(value: number): void;
      get_workingBuffer(): number;
      set_workingBuffer(value: number): void;
      cancel(): void;
      get_maintainAspectRatio(): boolean;
      set_maintainAspectRatio(value: boolean): void;
      get_operation(): lt.Annotations.Engine.AnnEditDesignerOperation;
      set_operation(value: lt.Annotations.Engine.AnnEditDesignerOperation): void;
      get_moveThumbIndex(): number;
      get_showThumbs(): boolean;
      set_showThumbs(value: boolean): void;
      get_thumbsEnabled(): boolean;
      set_thumbsEnabled(value: boolean): void;
      get_ignoreHitTestThumbs(): boolean;
      set_ignoreHitTestThumbs(value: boolean): void;
      get_isModified(): boolean;
      set_isModified(value: boolean): void;
      start(): void;
      end(): void;
      hitTestThumbs(pt: lt.LeadPointD): boolean;
      onPointerDown(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerMove(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      getIntersectionWithReferencePoints(): lt.LeadPointD;  // protected
      startWorking(operation: lt.Annotations.Engine.AnnEditDesignerOperation, thumbIndex: number): boolean;  // protected
      working(): boolean;  // protected
      endWorking(): boolean;  // protected
      onEdit(e: lt.Annotations.Engine.AnnEditDesignerEventArgs): void;  // protected
      move(offsetX: number, offsetY: number): void;  // protected
      callMove(offsetX: number, offsetY: number): void;
      snapObjectToGrid(targetObject: lt.Annotations.Engine.AnnObject, clipToContainer: boolean): void;
      invalidate(rc: lt.LeadRectD): void;
      moveThumb(thumbIndex: number, offset: lt.LeadPointD): void;  // protected
      resetRotateThumbs(): void;
      callResetRotateThumbs(invalidate: boolean): void;
      onPointerUp(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerDoubleClick(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annObject: lt.Annotations.Engine.AnnObject);
      rotateModifierKey: lt.Annotations.Engine.AnnKeys;
      useRotateThumbs: boolean;
      thumbsHitTestBuffer: number;
      workingBuffer: number;
      maintainAspectRatio: boolean;
      operation: lt.Annotations.Engine.AnnEditDesignerOperation;
      moveThumbIndex: number; // read-only
      showThumbs: boolean;
      thumbsEnabled: boolean;
      ignoreHitTestThumbs: boolean;
      isModified: boolean;
      editContent: lt.Annotations.Engine.AnnEditContentEventType; // read-only
      edit: lt.Annotations.Engine.AnnEditDesignerEventType; // read-only
   }

   class AnnPointEditDesigner extends AnnEditDesigner {
      getRotationReferencePoints(): lt.LeadPointD[];  // protected
      getThumbLocations(): lt.LeadPointD[];
      moveThumb(thumbIndex: number, offset: lt.LeadPointD): void;  // protected
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annPointObject: lt.Annotations.Engine.AnnPointObject);
   }

   class AnnPolylineEditDesigner extends AnnEditDesigner {
      get_thumbsGap(): number;
      set_thumbsGap(value: number): void;
      getThumbLocations(): lt.LeadPointD[];
      moveThumb(thumbIndex: number, offset: lt.LeadPointD): void;  // protected
      getRotateCenterPoint(): lt.LeadPointD;  // protected
      getRotationReferencePoints(): lt.LeadPointD[];  // protected
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annPolylineObject: lt.Annotations.Engine.AnnPolylineObject);
      thumbsGap: number;
   }

   class AnnRectangleEditDesigner extends AnnEditDesigner {
      get_minimumSize(): lt.LeadSizeD;
      set_minimumSize(value: lt.LeadSizeD): void;
      onPointerDown(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      getThumbLocations(): lt.LeadPointD[];
      moveThumb(thumbIndex: number, offset: lt.LeadPointD): void;  // protected
      snapObjectToGrid(targetObject: lt.Annotations.Engine.AnnObject, clipToContainer: boolean): void;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annRectangleObject: lt.Annotations.Engine.AnnRectangleObject);
      minimumSize: lt.LeadSizeD;
   }

   class AnnSelectionEditDesigner extends AnnRectangleEditDesigner {
      start(): void;
      move(offsetX: number, offsetY: number): void;  // protected
      get_maintainAspectRatio(): boolean;
      set_maintainAspectRatio(value: boolean): void;
      getThumbLocations(): lt.LeadPointD[];
      moveThumb(thumbIndex: number, offset: lt.LeadPointD): void;  // protected
      end(): void;
      onPointerMove(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annSelectionObject: lt.Annotations.Engine.AnnSelectionObject);
      maintainAspectRatio: boolean;
   }

   class AnnTextEditDesigner extends AnnRectangleEditDesigner {
      add_editText(value: lt.Annotations.Engine.AnnEditTextEventHandler): void;
      remove_editText(value: lt.Annotations.Engine.AnnEditTextEventHandler): void;
      get_acceptsReturn(): boolean;
      set_acceptsReturn(value: boolean): void;
      get_autoSizeAfterEdit(): boolean;
      set_autoSizeAfterEdit(value: boolean): void;
      get_autoSizeRotatedOnly(): boolean;
      set_autoSizeRotatedOnly(value: boolean): void;
      onPointerDoubleClick(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      invalidate(rc: lt.LeadRectD): void;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annTextObject: lt.Annotations.Engine.AnnTextObject);
      acceptsReturn: boolean;
      autoSizeAfterEdit: boolean;
      autoSizeRotatedOnly: boolean;
      editText: lt.Annotations.Engine.AnnEditTextEventType; // read-only
   }

   class AnnTextPointerEditDesigner extends AnnTextEditDesigner {
      getThumbLocations(): lt.LeadPointD[];
      moveThumb(thumbIndex: number, offset: lt.LeadPointD): void;  // protected
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annTextPointerObject: lt.Annotations.Engine.AnnTextPointerObject);
   }

   class AnnTextReviewEditDesigner extends AnnEditDesigner {
      move(offsetX: number, offsetY: number): void;  // protected
      getThumbLocations(): lt.LeadPointD[];
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annObject: lt.Annotations.Engine.AnnObject);
   }

   class AnnRunDesigner extends AnnDesigner {
      add_run(value: lt.Annotations.Engine.AnnRunDesignerEventHandler): void;
      remove_run(value: lt.Annotations.Engine.AnnRunDesignerEventHandler): void;
      get_hitTestBuffer(): number;
      set_hitTestBuffer(value: number): void;
      cancel(): void;
      startWorking(): boolean;  // protected
      working(): boolean;  // protected
      endWorking(): boolean;  // protected
      onRun(e: lt.Annotations.Engine.AnnRunDesignerEventArgs): void;  // protected
      onPointerDown(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerMove(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerUp(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      onPointerDoubleClick(sender: lt.Annotations.Engine.AnnContainer, e: lt.Annotations.Engine.AnnPointerEventArgs): boolean;
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annObject: lt.Annotations.Engine.AnnObject);
      hitTestBuffer: number;
      run: lt.Annotations.Engine.AnnRunDesignerEventType; // read-only
   }

   class AnnTextRollupRunDesigner extends AnnRunDesigner {
      onRun(e: lt.Annotations.Engine.AnnRunDesignerEventArgs): void;  // protected
      constructor(automationControl: lt.Annotations.Engine.IAnnAutomationControl, container: lt.Annotations.Engine.AnnContainer, annTextRollupObject: lt.Annotations.Engine.AnnTextRollupObject);
   }
}
