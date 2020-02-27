//***********************************************************************************************
//   Type definitions for Leadtools.Annotations.Automation.js
//   Updated: 12/3/2019 19:01
//   Version: 20.0.0.23
//
//   Dependencies:
//      Leadtools.d.ts
//      Leadtools.Annotations.Designers.d.ts
//      Leadtools.Annotations.Engine.d.ts
//
//   Copyright (c) 1991-2019 All Rights Reserved. LEAD Technologies, Inc.
//   https://www.leadtools.com
//***********************************************************************************************

declare module lt.Annotations.Automation {

   class AnnAutomationUndoRedoObject {
   }

   class AnnAutomation {
      get_canBringToFront(): boolean;
      get_canBringToFirst(): boolean;
      get_canSendToLast(): boolean;
      get_canSendToBack(): boolean;
      get_canApplyAllEncryptors(): boolean;
      get_canApplyAllDecryptors(): boolean;
      get_canFlip(): boolean;
      get_canResetRotatePoints(): boolean;
      get_canShowObjectProperties(): boolean;
      applyEncryptor(): void;
      applyDecryptor(): void;
      copy(): void;
      paste(): void;
      pasteStringAt(data: string, position: lt.LeadPointD): void;
      pasteAt(position: lt.LeadPointD): void;
      get_canAlign(): boolean;
      alignLefts(): void;
      alignCenters(): void;
      alignRights(): void;
      alignTops(): void;
      alignMiddles(): void;
      alignBottoms(): void;
      makeSameWidth(): void;
      makeSameHeight(): void;
      makeSameSize(): void;
      bringToFront(first: boolean): void;
      sendToBack(last: boolean): void;
      flip(horizontal: boolean): void;
      resetRotatePoints(): void;
      applyAllEncryptors(): void;
      applyAllDecryptors(): void;
      showContextMenu(): void;
      get_canShowObjectContextMenu(): boolean;
      showObjectContextMenu(): void;
      showObjectProperties(): void;
      get_canSelectNone(): boolean;
      add_deserializeObjectError(value: lt.Annotations.Engine.AnnSerializeObjectEventHandler): void;
      remove_deserializeObjectError(value: lt.Annotations.Engine.AnnSerializeObjectEventHandler): void;
      addLayer(parentLayer: lt.Annotations.Engine.AnnLayer, layer: lt.Annotations.Engine.AnnLayer): void;
      deleteLayer(layer: lt.Annotations.Engine.AnnLayer, deleteChildren: boolean): void;
      selectLayer(activeLayer: lt.Annotations.Engine.AnnLayer): lt.Annotations.Engine.AnnLayer;
      get_canBringLayerToFront(): boolean;
      get_canBringLayerToFirst(): boolean;
      get_canSendLayerToBack(): boolean;
      get_canSendLayerToLast(): boolean;
      sendLayerToBack(last: boolean): void;
      bringLayerToFront(first: boolean): void;
      layerFromSelectedObjects(layerName: string): lt.Annotations.Engine.AnnLayer;
      endDesigner(): void;
      add_currentDesignerChanged(value: lt.LeadEventHandler): void;
      remove_currentDesignerChanged(value: lt.LeadEventHandler): void;
      onCurrentDesignerChanged(e: lt.LeadEventArgs): void;  // protected
      get_active(): boolean;
      set_active(value: boolean): void;
      cancel(): void;
      beginUndo(): void;
      onUndoRedoChanged(e: lt.LeadEventArgs): void;  // protected
      add_afterUndoRedo(value: lt.LeadEventHandler): void;
      remove_afterUndoRedo(value: lt.LeadEventHandler): void;
      onAfterUndoRedo(e: lt.LeadEventArgs): void;  // protected
      endUndo(): void;
      cancelUndo(): void;
      undo(): void;
      redo(): void;
      onObjectModified(e: AnnObjectModifiedEventArgs): void;  // protected
      invokeObjectModified(objects: lt.Annotations.Engine.AnnObjectCollection, changeType: AnnObjectChangedType): void;
      invokeAfterObjectChanged(objects: lt.Annotations.Engine.AnnObjectCollection, changeType: AnnObjectChangedType): void;
      add_beforeObjectChanged(value: AnnBeforeObjectChangedEventHandler): void;
      remove_beforeObjectChanged(value: AnnBeforeObjectChangedEventHandler): void;
      add_afterObjectChanged(value: AnnAfterObjectChangedEventHandler): void;
      remove_afterObjectChanged(value: AnnAfterObjectChangedEventHandler): void;
      onBeforeObjectChanged(e: AnnBeforeObjectChangedEventArgs): void;  // protected
      onAfterObjectChanged(e: AnnAfterObjectChangedEventArgs): void;  // protected
      getContainerInvalidRect(container: lt.Annotations.Engine.AnnContainer, includeObjects: boolean): lt.LeadRectD;
      lock(): void;
      get_canUnlock(): boolean;
      unlock(): void;
      get_manager(): AnnAutomationManager;
      get_container(): lt.Annotations.Engine.AnnContainer;
      get_currentDesigner(): lt.Annotations.Designers.AnnDesigner;
      get_currentEditObject(): lt.Annotations.Engine.AnnObject;
      get_canUndo(): boolean;
      get_canRedo(): boolean;
      get_undoCapacity(): number;
      set_undoCapacity(value: number): void;
      get_canLock(): boolean;
      get_canRealizeRedaction(): boolean;
      realizeRedaction(): void;
      get_canRestoreRedaction(): boolean;
      restoreRedaction(): void;
      get_canRealizeAllRedactions(): boolean;
      realizeAllRedactions(): void;
      get_canRestoreAllRedactions(): boolean;
      restoreAllRedactions(): void;
      get_canSelectObjects(): boolean;
      selectObject(annObject: lt.Annotations.Engine.AnnObject): void;
      selectObjects(objects: lt.Annotations.Engine.AnnObjectCollection): void;
      get_canDeleteObjects(): boolean;
      deleteSelectedObjects(): void;
      get_canShowProperties(): boolean;
      get_canApplyDecryptor(): boolean;
      get_canApplyEncryptor(): boolean;
      get_canGroup(): boolean;
      get_canUngroup(): boolean;
      get_canCopy(): boolean;
      get_canPaste(): boolean;
      get_enableDragDrop(): boolean;
      set_enableDragDrop(value: boolean): void;
      get_containers(): lt.Annotations.Engine.AnnContainerCollection;
      add_objectModified(value: AnnObjectModifiedEventHandler): void;
      remove_objectModified(value: AnnObjectModifiedEventHandler): void;
      add_dragDrop(value: AnnDragDropEventHandler): void;
      remove_dragDrop(value: AnnDragDropEventHandler): void;
      onDragDrop(e: AnnDragDropEventArgs): void;  // protected
      add_lockObject(value: lt.Annotations.Engine.AnnLockObjectEventHandler): void;
      remove_lockObject(value: lt.Annotations.Engine.AnnLockObjectEventHandler): void;
      add_unlockObject(value: lt.Annotations.Engine.AnnLockObjectEventHandler): void;
      remove_unlockObject(value: lt.Annotations.Engine.AnnLockObjectEventHandler): void;
      add_editText(value: lt.Annotations.Engine.AnnEditTextEventHandler): void;
      remove_editText(value: lt.Annotations.Engine.AnnEditTextEventHandler): void;
      add_editContent(value: lt.Annotations.Engine.AnnEditContentEventHandler): void;
      remove_editContent(value: lt.Annotations.Engine.AnnEditContentEventHandler): void;
      add_undoRedoChanged(value: lt.LeadEventHandler): void;
      remove_undoRedoChanged(value: lt.LeadEventHandler): void;
      add_draw(value: lt.Annotations.Engine.AnnDrawDesignerEventHandler): void;
      remove_draw(value: lt.Annotations.Engine.AnnDrawDesignerEventHandler): void;
      add_edit(value: lt.Annotations.Engine.AnnEditDesignerEventHandler): void;
      remove_edit(value: lt.Annotations.Engine.AnnEditDesignerEventHandler): void;
      add_run(value: lt.Annotations.Engine.AnnRunDesignerEventHandler): void;
      remove_run(value: lt.Annotations.Engine.AnnRunDesignerEventHandler): void;
      add_selectedObjectsChanged(value: lt.LeadEventHandler): void;
      remove_selectedObjectsChanged(value: lt.LeadEventHandler): void;
      add_onShowContextMenu(value: AnnAutomationEventHandler): void;
      remove_onShowContextMenu(value: AnnAutomationEventHandler): void;
      add_onShowObjectProperties(value: AnnAutomationEventHandler): void;
      remove_onShowObjectProperties(value: AnnAutomationEventHandler): void;
      add_setCursor(value: AnnCursorEventHandler): void;
      remove_setCursor(value: AnnCursorEventHandler): void;
      add_restoreCursor(value: lt.LeadEventHandler): void;
      remove_restoreCursor(value: lt.LeadEventHandler): void;
      add_toolTip(value: lt.Annotations.Engine.AnnToolTipEventHandler): void;
      remove_toolTip(value: lt.Annotations.Engine.AnnToolTipEventHandler): void;
      beginUpdateContainers(): void;
      endUpdateContainers(): void;
      hitTestContainer(location: lt.LeadPointD, includeObjects: boolean): lt.Annotations.Engine.AnnContainer;
      attachContainer(container: lt.Annotations.Engine.AnnContainer, undoRedoObject: AnnAutomationUndoRedoObject): void;
      getUndoRedoObject(): AnnAutomationUndoRedoObject;
      get_automationControl(): lt.Annotations.Engine.IAnnAutomationControl;
      invalidate(rc: lt.LeadRectD): void;
      getObjectInvalidateRect(annObject: lt.Annotations.Engine.AnnObject): lt.LeadRectD;
      invalidateObject(annObject: lt.Annotations.Engine.AnnObject): void;
      invalidateContainer(container: lt.Annotations.Engine.AnnContainer): void;
      attach(automationControl: lt.Annotations.Engine.IAnnAutomationControl): void;
      detach(): void;
      get_activeContainer(): lt.Annotations.Engine.AnnContainer;
      set_activeContainer(value: lt.Annotations.Engine.AnnContainer): void;
      add_activeContainerChanged(value: lt.LeadEventHandler): void;
      remove_activeContainerChanged(value: lt.LeadEventHandler): void;
      get_defaultCurrentObjectId(): number;
      set_defaultCurrentObjectId(value: number): void;
      getDefaultCurrentObjectId(): number;  // protected
      onAutomationPointerDown(e: lt.Annotations.Engine.AnnPointerEventArgs): void;  // protected
      onAutomationPointerUp(e: lt.Annotations.Engine.AnnPointerEventArgs): void;  // protected
      resolveObject(): void;  // protected
      onAutomationPointerMove(e: lt.Annotations.Engine.AnnPointerEventArgs): void;  // protected
      constructor(automationManager: AnnAutomationManager, automationControl: lt.Annotations.Engine.IAnnAutomationControl);
      enableDragDrop: boolean;
      containers: lt.Annotations.Engine.AnnContainerCollection; // read-only
      automationControl: lt.Annotations.Engine.IAnnAutomationControl; // read-only
      activeContainer: lt.Annotations.Engine.AnnContainer;
      defaultCurrentObjectId: number;
      active: boolean;
      canUnlock: boolean; // read-only
      manager: AnnAutomationManager; // read-only
      container: lt.Annotations.Engine.AnnContainer; // read-only
      currentDesigner: lt.Annotations.Designers.AnnDesigner; // read-only
      currentEditObject: lt.Annotations.Engine.AnnObject; // read-only
      canUndo: boolean; // read-only
      canRedo: boolean; // read-only
      undoCapacity: number;
      canLock: boolean; // read-only
      canRealizeRedaction: boolean; // read-only
      canRestoreRedaction: boolean; // read-only
      canRealizeAllRedactions: boolean; // read-only
      canRestoreAllRedactions: boolean; // read-only
      canSelectObjects: boolean; // read-only
      canDeleteObjects: boolean; // read-only
      canShowProperties: boolean; // read-only
      canApplyDecryptor: boolean; // read-only
      canApplyEncryptor: boolean; // read-only
      canGroup: boolean; // read-only
      canUngroup: boolean; // read-only
      canCopy: boolean; // read-only
      canPaste: boolean; // read-only
      canBringToFront: boolean; // read-only
      canBringToFirst: boolean; // read-only
      canSendToLast: boolean; // read-only
      canSendToBack: boolean; // read-only
      canApplyAllEncryptors: boolean; // read-only
      canApplyAllDecryptors: boolean; // read-only
      canFlip: boolean; // read-only
      canResetRotatePoints: boolean; // read-only
      canShowObjectProperties: boolean; // read-only
      canAlign: boolean; // read-only
      canShowObjectContextMenu: boolean; // read-only
      canSelectNone: boolean; // read-only
      canBringLayerToFront: boolean; // read-only
      canBringLayerToFirst: boolean; // read-only
      canSendLayerToBack: boolean; // read-only
      canSendLayerToLast: boolean; // read-only
      objectModified: AnnObjectModifiedEventType; // read-only
      dragDrop: AnnDragDropEventType; // read-only
      lockObject: lt.Annotations.Engine.AnnLockObjectEventType; // read-only
      unlockObject: lt.Annotations.Engine.AnnLockObjectEventType; // read-only
      editText: lt.Annotations.Engine.AnnEditTextEventType; // read-only
      editContent: lt.Annotations.Engine.AnnEditContentEventType; // read-only
      undoRedoChanged: lt.LeadEventType; // read-only
      draw: lt.Annotations.Engine.AnnDrawDesignerEventType; // read-only
      edit: lt.Annotations.Engine.AnnEditDesignerEventType; // read-only
      run: lt.Annotations.Engine.AnnRunDesignerEventType; // read-only
      selectedObjectsChanged: lt.LeadEventType; // read-only
      onShowContextMenu: AnnAutomationEventType; // read-only
      onShowObjectProperties: AnnAutomationEventType; // read-only
      setCursor: AnnCursorEventType; // read-only
      restoreCursor: lt.LeadEventType; // read-only
      toolTip: lt.Annotations.Engine.AnnToolTipEventType; // read-only
      activeContainerChanged: lt.LeadEventType; // read-only
      currentDesignerChanged: lt.LeadEventType; // read-only
      afterUndoRedo: lt.LeadEventType; // read-only
      beforeObjectChanged: AnnBeforeObjectChangedEventType; // read-only
      afterObjectChanged: AnnAfterObjectChangedEventType; // read-only
      deserializeObjectError: lt.Annotations.Engine.AnnSerializeObjectEventType; // read-only
   }

   interface AnnGetClipboardDataCallback {
      (automation: AnnAutomation, position: lt.LeadPointD, format: string): void;
   }

   interface AnnSetClipboardDataCallback {
      (automation: AnnAutomation, format: string, data: string): void;
   }

   interface AnnIsClipboardDataPresentCallback {
      (automation: AnnAutomation, format: string): boolean;
   }

   class AnnPlatformCallbacks {
      get_checkModifier(): lt.Annotations.Engine.AnnCheckModifierCallback;
      set_checkModifier(value: lt.Annotations.Engine.AnnCheckModifierCallback): void;
      get_getClipboardData(): AnnGetClipboardDataCallback;
      set_getClipboardData(value: AnnGetClipboardDataCallback): void;
      get_setClipboardData(): AnnSetClipboardDataCallback;
      set_setClipboardData(value: AnnSetClipboardDataCallback): void;
      get_isClipboardDataPresent(): AnnIsClipboardDataPresentCallback;
      set_isClipboardDataPresent(value: AnnIsClipboardDataPresentCallback): void;
      constructor();
      checkModifier: lt.Annotations.Engine.AnnCheckModifierCallback;
      getClipboardData: AnnGetClipboardDataCallback;
      setClipboardData: AnnSetClipboardDataCallback;
      isClipboardDataPresent: AnnIsClipboardDataPresentCallback;
   }

   class AnnAutomationManager {
      get_rotateModifierKey(): lt.Annotations.Engine.AnnKeys;
      set_rotateModifierKey(value: lt.Annotations.Engine.AnnKeys): void;
      get_extendedModeModifierKey(): lt.Annotations.Engine.AnnKeys;
      set_extendedModeModifierKey(value: lt.Annotations.Engine.AnnKeys): void;
      get_multiSelectModifierKey(): lt.Annotations.Engine.AnnKeys;
      set_multiSelectModifierKey(value: lt.Annotations.Engine.AnnKeys): void;
      get_enableDeselectObject(): boolean;
      set_enableDeselectObject(value: boolean): void;
      get_groupsRoles(): lt.Annotations.Engine.AnnGroupsRoles;
      set_groupsRoles(value: lt.Annotations.Engine.AnnGroupsRoles): void;
      get_renderingEngine(): lt.Annotations.Engine.AnnRenderingEngine;
      set_renderingEngine(value: lt.Annotations.Engine.AnnRenderingEngine): void;
      get_enableToolTip(): boolean;
      set_enableToolTip(value: boolean): void;
      get_resources(): lt.Annotations.Engine.AnnResources;
      set_resources(value: lt.Annotations.Engine.AnnResources): void;
      get_enablePartialDrop(): boolean;
      set_enablePartialDrop(value: boolean): void;
      get_forceSelectionModifierKey(): boolean;
      set_forceSelectionModifierKey(value: boolean): void;
      get_selectionModifierKey(): lt.Annotations.Engine.AnnKeys;
      set_selectionModifierKey(value: lt.Annotations.Engine.AnnKeys): void;
      get_snapToGridOptions(): lt.Annotations.Engine.AnnSnapToGridOptions;
      set_snapToGridOptions(value: lt.Annotations.Engine.AnnSnapToGridOptions): void;
      get_deselectOnDown(): boolean;
      set_deselectOnDown(value: boolean): void;
      get_useRotateThumbs(): boolean;
      set_useRotateThumbs(value: boolean): void;
      get_endEditDesignerBeforeDraw(): boolean;
      set_endEditDesignerBeforeDraw(value: boolean): void;
      get_hitTestBehavior(): lt.Annotations.Engine.AnnHitTestBehavior;
      set_hitTestBehavior(value: lt.Annotations.Engine.AnnHitTestBehavior): void;
      get_redactionRealizePassword(): string;
      set_redactionRealizePassword(value: string): void;
      static get_platformCallbacks(): AnnPlatformCallbacks;
      static create(engine: lt.Annotations.Engine.AnnRenderingEngine): AnnAutomationManager;
      get_automations(): AnnAutomations;
      get_objects(): AnnAutomationObjects;
      get_userMode(): lt.Annotations.Engine.AnnUserMode;
      set_userMode(value: lt.Annotations.Engine.AnnUserMode): void;
      get_thumbsHitTestBuffer(): number;
      set_thumbsHitTestBuffer(value: number): void;
      get_runHitTestBuffer(): number;
      set_runHitTestBuffer(value: number): void;
      get_currentObjectId(): number;
      set_currentObjectId(value: number): void;
      get_editObjectAfterDraw(): boolean;
      set_editObjectAfterDraw(value: boolean): void;
      get_cancelInactiveDesigners(): boolean;
      set_cancelInactiveDesigners(value: boolean): void;
      get_endDrawWhenLostFocus(): boolean;
      set_endDrawWhenLostFocus(value: boolean): void;
      get_maintainAspectRatio(): boolean;
      set_maintainAspectRatio(value: boolean): void;
      get_showThumbs(): boolean;
      set_showThumbs(value: boolean): void;
      get_restrictDesigners(): boolean;
      set_restrictDesigners(value: boolean): void;
      get_enableThumbsSelection(): boolean;
      set_enableThumbsSelection(value: boolean): void;
      get_thumbsGap(): number;
      set_thumbsGap(value: number): void;
      get_editContentAfterDraw(): boolean;
      set_editContentAfterDraw(value: boolean): void;
      get_editTextAfterDraw(): boolean;
      set_editTextAfterDraw(value: boolean): void;
      get_useFreehandSelection(): boolean;
      set_useFreehandSelection(value: boolean): void;
      add_currentObjectIdChanged(value: lt.LeadEventHandler): void;
      remove_currentObjectIdChanged(value: lt.LeadEventHandler): void;
      createAutomationObject(): AnnAutomationObject;  // protected
      createSelectAutomationObject(): AnnAutomationObject;  // protected
      createLineAutomationObject(): AnnAutomationObject;  // protected
      createRectangleAutomationObject(): AnnAutomationObject;  // protected
      createEllipseAutomationObject(): AnnAutomationObject;  // protected
      createPolylineAutomationObject(): AnnAutomationObject;  // protected
      createPolygonAutomationObject(): AnnAutomationObject;  // protected
      createCurveAutomationObject(): AnnAutomationObject;  // protected
      createClosedCurveAutomationObject(): AnnAutomationObject;  // protected
      createPointerAutomationObject(): AnnAutomationObject;  // protected
      createFreeHandAutomationObject(): AnnAutomationObject;  // protected
      createHiliteAutomationObject(): AnnAutomationObject;  // protected
      createTextAutomationObject(): AnnAutomationObject;  // protected
      createTextPointerAutomationObject(): AnnAutomationObject;  // protected
      createNoteAutomationObject(): AnnAutomationObject;  // protected
      createStampAutomationObject(): AnnAutomationObject;  // protected
      createRubberStampAutomationObject(): AnnAutomationObject;  // protected
      createHotspotAutomationObject(): AnnAutomationObject;  // protected
      createFreehandHotspotAutomationObject(): AnnAutomationObject;  // protected
      createPointAutomationObject(): AnnAutomationObject;  // protected
      createRedactionAutomationObject(): AnnAutomationObject;  // protected
      createRulerAutomationObject(): AnnAutomationObject;  // protected
      createPolyRulerAutomationObject(): AnnAutomationObject;  // protected
      createProtractorAutomationObject(): AnnAutomationObject;  // protected
      createCrossProductAutomationObject(): AnnAutomationObject;  // protected
      createVideoAutomationObject(): AnnAutomationObject;  // protected
      createEncryptAutomationObject(): AnnAutomationObject;  // protected
      createAudioAutomationObject(): AnnAutomationObject;  // protected
      createTextRollupAutomationObject(): AnnAutomationObject;  // protected
      createImageAutomationObject(): AnnAutomationObject;  // protected
      createTextHilite(): AnnAutomationObject;  // protected
      createTextStrikeout(): AnnAutomationObject;  // protected
      createTextUnderline(): AnnAutomationObject;  // protected
      createTextRedaction(): AnnAutomationObject;  // protected
      createStickyNote(): AnnAutomationObject;  // protected
      createDefaultObjects(): void;
      loadPackage(pack: IAnnPackage, groupName: string): void;
      findObject(obj: lt.Annotations.Engine.AnnObject): AnnAutomationObject;
      findObjectById(id: number): AnnAutomationObject;
      add_userModeChanged(value: lt.LeadEventHandler): void;
      remove_userModeChanged(value: lt.LeadEventHandler): void;
      add_currentRubberStampTypeChanged(value: lt.LeadEventHandler): void;
      remove_currentRubberStampTypeChanged(value: lt.LeadEventHandler): void;
      get_currentRubberStampType(): lt.Annotations.Engine.AnnRubberStampType;
      set_currentRubberStampType(value: lt.Annotations.Engine.AnnRubberStampType): void;
      get_enableObjectsAlignment(): boolean;
      set_enableObjectsAlignment(value: boolean): void;
      get_usePDFMode(): boolean;
      set_usePDFMode(value: boolean): void;
      get_fontRelativeToImageDpi(): boolean;
      set_fontRelativeToImageDpi(value: boolean): void;
      constructor();
      hitTestBehavior: lt.Annotations.Engine.AnnHitTestBehavior;
      redactionRealizePassword: string;
      static platformCallbacks: AnnPlatformCallbacks; // read-only
      automations: AnnAutomations; // read-only
      objects: AnnAutomationObjects; // read-only
      userMode: lt.Annotations.Engine.AnnUserMode;
      thumbsHitTestBuffer: number;
      runHitTestBuffer: number;
      currentObjectId: number;
      editObjectAfterDraw: boolean;
      cancelInactiveDesigners: boolean;
      endDrawWhenLostFocus: boolean;
      maintainAspectRatio: boolean;
      showThumbs: boolean;
      restrictDesigners: boolean;
      enableThumbsSelection: boolean;
      thumbsGap: number;
      editContentAfterDraw: boolean;
      editTextAfterDraw: boolean;
      useFreehandSelection: boolean;
      currentRubberStampType: lt.Annotations.Engine.AnnRubberStampType;
      enableObjectsAlignment: boolean;
      usePDFMode: boolean;
      fontRelativeToImageDpi: boolean;
      rotateModifierKey: lt.Annotations.Engine.AnnKeys;
      extendedModeModifierKey: lt.Annotations.Engine.AnnKeys;
      multiSelectModifierKey: lt.Annotations.Engine.AnnKeys;
      enableDeselectObject: boolean;
      groupsRoles: lt.Annotations.Engine.AnnGroupsRoles;
      renderingEngine: lt.Annotations.Engine.AnnRenderingEngine;
      enableToolTip: boolean;
      resources: lt.Annotations.Engine.AnnResources;
      enablePartialDrop: boolean;
      forceSelectionModifierKey: boolean;
      selectionModifierKey: lt.Annotations.Engine.AnnKeys;
      snapToGridOptions: lt.Annotations.Engine.AnnSnapToGridOptions;
      deselectOnDown: boolean;
      useRotateThumbs: boolean;
      endEditDesignerBeforeDraw: boolean;
      currentObjectIdChanged: lt.LeadEventType; // read-only
      userModeChanged: lt.LeadEventType; // read-only
      currentRubberStampTypeChanged: lt.LeadEventType; // read-only
   }

   class AnnAutomationObject {
      get_groupName(): string;
      set_groupName(value: string): void;
      get_nextNumber(): number;
      set_nextNumber(value: number): void;
      get_labelTemplate(): string;
      set_labelTemplate(value: string): void;
      get_userData(): any;
      set_userData(value: any): void;
      get_id(): number;
      set_id(value: number): void;
      get_renderer(): lt.Annotations.Engine.IAnnObjectRenderer;
      set_renderer(value: lt.Annotations.Engine.IAnnObjectRenderer): void;
      get_name(): string;
      set_name(value: string): void;
      get_objectTemplate(): lt.Annotations.Engine.AnnObject;
      set_objectTemplate(value: lt.Annotations.Engine.AnnObject): void;
      get_drawDesignerType(): any;
      set_drawDesignerType(value: any): void;
      get_editDesignerType(): any;
      set_editDesignerType(value: any): void;
      get_runDesignerType(): any;
      set_runDesignerType(value: any): void;
      get_toolBarImage(): any;
      set_toolBarImage(value: any): void;
      get_toolBarToolTipText(): string;
      set_toolBarToolTipText(value: string): void;
      get_drawCursor(): any;
      set_drawCursor(value: any): void;
      get_contextMenu(): any;
      set_contextMenu(value: any): void;
      get_useRotateThumbs(): boolean;
      set_useRotateThumbs(value: boolean): void;
      constructor();
      groupName: string;
      nextNumber: number;
      labelTemplate: string;
      userData: any;
      id: number;
      renderer: lt.Annotations.Engine.IAnnObjectRenderer;
      name: string;
      objectTemplate: lt.Annotations.Engine.AnnObject;
      drawDesignerType: any;
      editDesignerType: any;
      runDesignerType: any;
      toolBarImage: any;
      toolBarToolTipText: string;
      drawCursor: any;
      contextMenu: any;
      useRotateThumbs: boolean;
   }

   class AnnAutomationObjects extends lt.LeadCollection {
      remove(item: AnnAutomationObject): void;
      add(item: AnnAutomationObject): void;
      addRange(items: AnnAutomationObject[]): void;
      contains(item: AnnAutomationObject): boolean;
      get_item(i: number): AnnAutomationObject;
      set_item(i: number, value: AnnAutomationObject): void;
      toArray(): AnnAutomationObject[];
      insertItem(index: number, item: AnnAutomationObject): void;  // protected
      insert(index: number, item: AnnAutomationObject): void;
      insertRange(index: number, items: AnnAutomationObject[]): void;
      insertItemRange(index: number, items: AnnAutomationObject[]): void;  // protected
      setItem(index: number, item: AnnAutomationObject): void;  // protected
      indexOf(item: AnnAutomationObject): number;
      add_collectionChanged(value: lt.Annotations.Engine.AnnNotifyCollectionChangedEventHandler): void;
      remove_collectionChanged(value: lt.Annotations.Engine.AnnNotifyCollectionChangedEventHandler): void;
      onCollectionChanged(e: lt.NotifyLeadCollectionChangedEventArgs): void;  // protected
      constructor();
      item(index: number, value?: AnnAutomationObject): AnnAutomationObject;
      collectionChanged: lt.Annotations.Engine.AnnNotifyCollectionChangedEventType; // read-only
   }

   class AnnAutomations extends lt.LeadCollection {
      remove(item: AnnAutomation): void;
      add(item: AnnAutomation): void;
      addRange(items: AnnAutomation[]): void;
      contains(item: AnnAutomation): boolean;
      get_item(i: number): AnnAutomation;
      set_item(i: number, value: AnnAutomation): void;
      toArray(): AnnAutomation[];
      insertItem(index: number, item: AnnAutomation): void;  // protected
      insert(index: number, item: AnnAutomation): void;
      insertRange(index: number, items: AnnAutomation[]): void;
      insertItemRange(index: number, items: AnnAutomation[]): void;  // protected
      setItem(index: number, item: AnnAutomation): void;  // protected
      indexOf(item: AnnAutomation): number;
      add_collectionChanged(value: lt.Annotations.Engine.AnnNotifyCollectionChangedEventHandler): void;
      remove_collectionChanged(value: lt.Annotations.Engine.AnnNotifyCollectionChangedEventHandler): void;
      onCollectionChanged(e: lt.NotifyLeadCollectionChangedEventArgs): void;  // protected
      constructor();
      item(index: number, value?: AnnAutomation): AnnAutomation;
      collectionChanged: lt.Annotations.Engine.AnnNotifyCollectionChangedEventType; // read-only
   }

   interface AnnAutomationEventHandler extends lt.LeadEventHandler {
      (sender: any, e: AnnAutomationEventArgs): void;
   }

   class AnnAutomationEventType extends lt.LeadEvent {
      add(value: AnnAutomationEventHandler): AnnAutomationEventHandler;
      remove(value: AnnAutomationEventHandler): void;
   }

   class AnnAutomationEventArgs extends lt.LeadEventArgs {
      static create(obj: AnnAutomationObject): AnnAutomationEventArgs;
      get_object(): AnnAutomationObject;
      get_cancel(): boolean;
      set_cancel(value: boolean): void;
      constructor();
      object: AnnAutomationObject; // read-only
      cancel: boolean;
   }

   enum AnnDesignerType {
      none = 0,
      draw = 1,
      run = 2,
      edit = 3
   }

   interface AnnCursorEventHandler extends lt.LeadEventHandler {
      (sender: any, e: AnnCursorEventArgs): void;
   }

   class AnnCursorEventType extends lt.LeadEvent {
      add(value: AnnCursorEventHandler): AnnCursorEventHandler;
      remove(value: AnnCursorEventHandler): void;
   }

   class AnnCursorEventArgs extends lt.LeadEventArgs {
      get_id(): number;
      get_designerType(): AnnDesignerType;
      get_thumbIndex(): number;
      get_isRotateCenter(): boolean;
      get_isRotateGripper(): boolean;
      get_pointerEvent(): lt.Annotations.Engine.AnnPointerEventArgs;
      get_dragDropEvent(): AnnDragDropEventArgs;
      constructor(id: number, type: AnnDesignerType, thumbIndex: number, isRotateCenter: boolean, isRotateGripper: boolean, pointerEvent: lt.Annotations.Engine.AnnPointerEventArgs, dragDropEvent: AnnDragDropEventArgs);
      id: number; // read-only
      designerType: AnnDesignerType; // read-only
      thumbIndex: number; // read-only
      isRotateCenter: boolean; // read-only
      isRotateGripper: boolean; // read-only
      pointerEvent: lt.Annotations.Engine.AnnPointerEventArgs; // read-only
      dragDropEvent: AnnDragDropEventArgs; // read-only
   }

   enum AnnDragDropOperation {
      enter = 0,
      leave = 1,
      over = 2,
      drop = 3
   }

   interface AnnDragDropEventHandler extends lt.LeadEventHandler {
      (sender: any, e: AnnDragDropEventArgs): void;
   }

   class AnnDragDropEventType extends lt.LeadEvent {
      add(value: AnnDragDropEventHandler): AnnDragDropEventHandler;
      remove(value: AnnDragDropEventHandler): void;
   }

   class AnnDragDropEventArgs extends lt.LeadEventArgs {
      static create(annObject: lt.Annotations.Engine.AnnObject, sourceContainer: lt.Annotations.Engine.AnnContainer, targetContainer: lt.Annotations.Engine.AnnContainer, operation: AnnDragDropOperation, operationContainer: lt.Annotations.Engine.AnnContainer): AnnDragDropEventArgs;
      get_sourceContainer(): lt.Annotations.Engine.AnnContainer;
      get_targetContainer(): lt.Annotations.Engine.AnnContainer;
      get_annObject(): lt.Annotations.Engine.AnnObject;
      get_operation(): AnnDragDropOperation;
      get_operationContainer(): lt.Annotations.Engine.AnnContainer;
      get_allowed(): boolean;
      set_allowed(value: boolean): void;
      get_canDrop(): boolean;
      get_resizeLargeObject(): boolean;
      set_resizeLargeObject(value: boolean): void;
      sourceContainer: lt.Annotations.Engine.AnnContainer; // read-only
      targetContainer: lt.Annotations.Engine.AnnContainer; // read-only
      annObject: lt.Annotations.Engine.AnnObject; // read-only
      operation: AnnDragDropOperation; // read-only
      operationContainer: lt.Annotations.Engine.AnnContainer; // read-only
      allowed: boolean;
      canDrop: boolean; // read-only
      resizeLargeObject: boolean;
   }

   enum AnnObjectChangedType {
      none = 0,
      bringToFront = 1,
      sendToBack = 2,
      deleted = 3,
      lock = 4,
      unlock = 5,
      paste = 6,
      flip = 7,
      realizeRedaction = 8,
      restoreRedaction = 9,
      applyEncryptor = 10,
      applyDecryptor = 11,
      name = 12,
      hyperlink = 13,
      text = 14,
      picture = 15,
      pictures = 16,
      ruler = 17,
      stroke = 18,
      fill = 19,
      font = 20,
      encrypt = 21,
      polygon = 22,
      curve = 23,
      protractor = 24,
      rubberStamp = 25,
      point = 26,
      audio = 27,
      thumbs = 28,
      hilite = 29,
      designerDraw = 30,
      designerEdit = 31,
      resetRotatePoints = 32,
      fixed = 33,
      added = 34,
      modified = 35,
      metadata = 36
   }

   interface AnnBeforeObjectChangedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: AnnBeforeObjectChangedEventArgs): void;
   }

   class AnnBeforeObjectChangedEventType extends lt.LeadEvent {
      add(value: AnnBeforeObjectChangedEventHandler): AnnBeforeObjectChangedEventHandler;
      remove(value: AnnBeforeObjectChangedEventHandler): void;
   }

   class AnnBeforeObjectChangedEventArgs extends lt.LeadEventArgs {
      get_objects(): lt.Annotations.Engine.AnnObjectCollection;
      get_changeType(): AnnObjectChangedType;
      get_designer(): lt.Annotations.Designers.AnnDesigner;
      get_cancel(): boolean;
      set_cancel(value: boolean): void;
      constructor(objects: lt.Annotations.Engine.AnnObjectCollection, changeType: AnnObjectChangedType, designer: lt.Annotations.Designers.AnnDesigner);
      objects: lt.Annotations.Engine.AnnObjectCollection; // read-only
      changeType: AnnObjectChangedType; // read-only
      designer: lt.Annotations.Designers.AnnDesigner; // read-only
      cancel: boolean;
   }

   interface AnnAfterObjectChangedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: AnnAfterObjectChangedEventArgs): void;
   }

   class AnnAfterObjectChangedEventType extends lt.LeadEvent {
      add(value: AnnAfterObjectChangedEventHandler): AnnAfterObjectChangedEventHandler;
      remove(value: AnnAfterObjectChangedEventHandler): void;
   }

   class AnnAfterObjectChangedEventArgs extends lt.LeadEventArgs {
      get_objects(): lt.Annotations.Engine.AnnObjectCollection;
      get_changeType(): AnnObjectChangedType;
      get_designer(): lt.Annotations.Designers.AnnDesigner;
      get_cancel(): boolean;
      set_cancel(value: boolean): void;
      constructor(objects: lt.Annotations.Engine.AnnObjectCollection, changeType: AnnObjectChangedType, designer: lt.Annotations.Designers.AnnDesigner);
      objects: lt.Annotations.Engine.AnnObjectCollection; // read-only
      changeType: AnnObjectChangedType; // read-only
      designer: lt.Annotations.Designers.AnnDesigner; // read-only
      cancel: boolean;
   }

   interface AnnObjectModifiedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: AnnObjectModifiedEventArgs): void;
   }

   class AnnObjectModifiedEventType extends lt.LeadEvent {
      add(value: AnnObjectModifiedEventHandler): AnnObjectModifiedEventHandler;
      remove(value: AnnObjectModifiedEventHandler): void;
   }

   class AnnObjectModifiedEventArgs extends lt.LeadEventArgs {
      get_objects(): lt.Annotations.Engine.AnnObjectCollection;
      get_changeType(): AnnObjectChangedType;
      constructor(objects: lt.Annotations.Engine.AnnObjectCollection, changeType: AnnObjectChangedType);
      objects: lt.Annotations.Engine.AnnObjectCollection; // read-only
      changeType: AnnObjectChangedType; // read-only
   }

   interface IAnnPackage {
      get_author(): string;
      get_description(): string;
      get_friendlyName(): string;
      getAutomationObjects(): AnnAutomationObject[];
      author: string; // read-only
      description: string; // read-only
      friendlyName: string; // read-only
   }
}
