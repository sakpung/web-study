// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module lt.Annotations.JavaScript {

   export enum AutomationControlMultiContainerMode {
      SinglePage,       // All containers belong to the same item (ActiveItem in the ImageViewer)
      MultiPage         // One container per image viewer item
   }

   // this version of IAnnAutomationControl contains an image viewer
   export class ImageViewerAutomationControl implements lt.Annotations.Engine.IAnnAutomationControl {

      constructor() {
      }

      private _multiContainerMode: AutomationControlMultiContainerMode = AutomationControlMultiContainerMode.SinglePage;
      public get multiContainerMode(): AutomationControlMultiContainerMode { return this._multiContainerMode; }
      public set multiContainerMode(value: AutomationControlMultiContainerMode) { this._multiContainerMode = value; }

      dispose(): void { this.unHook(); }

      private _imageViewer: lt.Controls.ImageViewer;
      public get imageViewer(): lt.Controls.ImageViewer { return this._imageViewer; }
      public set imageViewer(value: lt.Controls.ImageViewer) {
         if (this._imageViewer != value) {
            this.unHook();
            this._imageViewer = value;
            this.hook();
         }
      }

      private handleGotFocus = (): void => {
         this.automationGotFocus.invoke(this, lt.LeadEventArgs.empty);
      }

      private hook(): void {
         if (this._imageViewer == null)
            return;

         // Hook to the image viewer events we need
         this._imageViewer.add_propertyChanged(this.imageViewer_PropertyChanged);
         this._imageViewer.add_itemChanged(this.imageViewer_ItemChanged);
         this._imageViewer.add_activeItemChanged(this.imageViewer_ActiveItemChanged);
         this._imageViewer.add_transformChanged(this.imageViewer_TransformChanged);
         this._imageViewer.add_postRender(this.imageViewer_PostRender);
         this._imageViewer.get_interactiveService().add_tap(this.handleGotFocus);
      }

      private unHook(): void {
         if (this._imageViewer == null)
            return;

         // Unhook from the image viewer events
         this._imageViewer.remove_propertyChanged(this.imageViewer_PropertyChanged);
         this._imageViewer.remove_itemChanged(this.imageViewer_ItemChanged);
         this._imageViewer.remove_activeItemChanged(this.imageViewer_ActiveItemChanged);
         this._imageViewer.remove_transformChanged(this.imageViewer_TransformChanged);
         this._imageViewer.remove_postRender(this.imageViewer_PostRender);
         this._imageViewer.get_interactiveService().remove_tap(this.handleGotFocus);

         if (this.automationObject != null)
            this.automationObject.remove_activeContainerChanged(this.automationObject_ActiveContainerChanged);
      }

      // Automation object
      automationObject: lt.Annotations.Automation.AnnAutomation;
      get_automationObject() { return this.automationObject; }
      set_automationObject(value: lt.Annotations.Automation.AnnAutomation) {
         this.automationObject = value;

         if (this.automationObject != null)
            this.automationObject.remove_activeContainerChanged(this.automationObject_ActiveContainerChanged);

         this.automationObject = value;

         if (this.automationObject != null)
            this.automationObject.add_activeContainerChanged(this.automationObject_ActiveContainerChanged);
      }

      automationPointerDown: lt.Annotations.Engine.AnnPointerEventType = <lt.Annotations.Engine.AnnPointerEventType>lt.LeadEvent.create(this, "automationPointerDown"); // read-only
      add_automationPointerDown(value: lt.Annotations.Engine.AnnPointerEventHandler): void { this.automationPointerDown.add(value); }
      remove_automationPointerDown(value: lt.Annotations.Engine.AnnPointerEventHandler): void { this.automationPointerDown.remove(value); }

      automationPointerMove: lt.Annotations.Engine.AnnPointerEventType = <lt.Annotations.Engine.AnnPointerEventType>lt.LeadEvent.create(this, "automationPointerMove");// read-only
      add_automationPointerMove(value: lt.Annotations.Engine.AnnPointerEventHandler): void { this.automationPointerMove.add(value); }
      remove_automationPointerMove(value: lt.Annotations.Engine.AnnPointerEventHandler): void { this.automationPointerMove.remove(value); }

      automationPointerUp: lt.Annotations.Engine.AnnPointerEventType = <lt.Annotations.Engine.AnnPointerEventType>lt.LeadEvent.create(this, "automationPointerUp"); // read-only
      add_automationPointerUp(value: lt.Annotations.Engine.AnnPointerEventHandler): void { this.automationPointerUp.add(value); }
      remove_automationPointerUp(value: lt.Annotations.Engine.AnnPointerEventHandler): void { this.automationPointerUp.remove(value); }

      automationDoubleClick: lt.Annotations.Engine.AnnPointerEventType = <lt.Annotations.Engine.AnnPointerEventType>lt.LeadEvent.create(this, "automationDoubleClick"); // read-only
      add_automationDoubleClick(value: lt.Annotations.Engine.AnnPointerEventHandler): void { this.automationDoubleClick.add(value); }
      remove_automationDoubleClick(value: lt.Annotations.Engine.AnnPointerEventHandler): void { this.automationDoubleClick.remove(value); }

      public onAutomationPointerDown(args: lt.Annotations.Engine.AnnPointerEventArgs) {
         if (this.automationPointerDown != null) {
            this.automationPointerDown.invoke(this, args);
         }
      }

      public onAutomationPointerMove(args: lt.Annotations.Engine.AnnPointerEventArgs) {
         if (this.automationPointerMove != null)
            this.automationPointerMove.invoke(this, args);
      }

      public onAutomationPointerUp(args: lt.Annotations.Engine.AnnPointerEventArgs) {
         if (this.automationPointerUp != null)
            this.automationPointerUp.invoke(this, args);
      }

      public onAutomationDoubleClick(args: lt.Annotations.Engine.AnnPointerEventArgs) {
         if (this.automationDoubleClick != null)
            this.automationDoubleClick.invoke(this, args);
      }

      // Resolution
      automationDpiX: number; // read-only
      automationDpiY: number; // read-only
      get_automationDpiX(): number { return this._imageViewer != null ? this._imageViewer.get_screenDpi().get_width() : 96; }
      get_automationDpiY(): number { return this._imageViewer != null ? this._imageViewer.get_screenDpi().get_height() : 96; }


      automationScaleFactor: number; // read-only
      automationRotateAngle: number; // read-only
      isAutomationEventsHooked: boolean;

      get_automationScaleFactor(): number { return 1 };
      get_automationRotateAngle(): number { return 0 };
      get_isAutomationEventsHooked(): boolean { return false };
      set_isAutomationEventsHooked(value: boolean):  void {};

      // Enabled/Focus
      automationEnabled: boolean; // read-only
      get_automationEnabled(): boolean { return true; }

      automationEnabledChanged: lt.LeadEventType = lt.LeadEvent.create(this, "automationEnabledChanged"); // read-only
      add_automationEnabledChanged(value: lt.LeadEventHandler): void { this.automationEnabledChanged.add(value); }
      remove_automationEnabledChanged(value: lt.LeadEventHandler): void { this.automationEnabledChanged.remove(value); }

      onEnabledChanged(e: lt.LeadEventArgs): void {
         if (this.automationEnabledChanged != null)
            this.automationEnabledChanged.invoke(this, lt.LeadEventArgs.empty);
      }

      //Automation Focus Event Handler
      automationLostFocus: lt.LeadEventType = lt.LeadEvent.create(this, "automationLostFocus"); // read-only
      add_automationLostFocus(value: lt.LeadEventHandler): void { this.automationLostFocus.add(value); }
      remove_automationLostFocus(value: lt.LeadEventHandler): void { this.automationLostFocus.remove(value); }

      automationGotFocus: lt.LeadEventType = lt.LeadEvent.create(this, "automationGotFocus"); // read-only
      add_automationGotFocus(value: lt.LeadEventHandler): void { this.automationGotFocus.add(value); }
      remove_automationGotFocus(value: lt.LeadEventHandler): void { this.automationGotFocus.remove(value); }

      // Automation items properties
      automationSizeChanged: lt.LeadEventType = lt.LeadEvent.create(this, "automationSizeChanged"); // read-only
      add_automationSizeChanged(value: lt.LeadEventHandler): void { this.automationSizeChanged.add(value); }
      remove_automationSizeChanged(value: lt.LeadEventHandler): void { this.automationSizeChanged.remove(value); }

      private imageViewer_ItemChanged = (sender: any, e: lt.Controls.ImageViewerItemChangedEventArgs): void => {
         switch (e.get_reason()) {
            case lt.Controls.ImageViewerItemChangedReason.url:
            case lt.Controls.ImageViewerItemChangedReason.image:
            case lt.Controls.ImageViewerItemChangedReason.imageChanged:
            case lt.Controls.ImageViewerItemChangedReason.size:
            case lt.Controls.ImageViewerItemChangedReason.transform:
               // Let the automation know the size of item has changed
               if (this.automationTransformChanged != null)
                  this.automationTransformChanged.invoke(this, lt.LeadEventArgs.empty);
               if (this.automationSizeChanged != null)
                  this.automationSizeChanged.invoke(this, lt.LeadEventArgs.empty);
               break;

            default:
               break;
         }
      }

      private imageViewer_ActiveItemChanged = (sender: any, e: lt.LeadEventArgs): void => {
         this.syncActiveItemContainer(true);
      }

      private automationObject_ActiveContainerChanged = (sender: any, e: LeadEventArgs): void => {
         this.syncActiveItemContainer(false);
      }

      private syncActiveItemContainer(fromViewer: boolean): void {
         // Ensure that both the image viewer and automation active "item" is the same
         if (this.automationObject == null || this._imageViewer == null)
            return;

         var itemsCount = this._imageViewer.get_items().get_count();
         var containersCount = this.automationObject.get_containers().get_count();
         if (itemsCount == 0 || itemsCount != containersCount)
            return;

         var imageViewerIndex = this._imageViewer.get_items().indexOf(this._imageViewer.get_activeItem());
         var containerIndex = -1;
         if (this.automationObject.get_activeContainer() != null)
            containerIndex = this.automationObject.get_containers().indexOf(this.automationObject.get_activeContainer());

         if (imageViewerIndex != containerIndex) {
            if (fromViewer) {
               if (imageViewerIndex != -1)
                  this.automationObject.set_activeContainer(this.automationObject.get_containers().get_item(imageViewerIndex));
            }
            else {
               if (containerIndex != -1)
                  this._imageViewer.set_activeItem(this._imageViewer.get_items().get_item(containerIndex));
            }
         }
      }

      private getItemForCurrentContainer(): lt.Controls.ImageViewerItem {
         if (this._imageViewer == null)
            return null;

         // Multiple container support?
         if (this.automationContainerIndex != -1) {
            // Yes, get the item
            switch (this._multiContainerMode) {
               case AutomationControlMultiContainerMode.MultiPage:
                  // One container for each item
                  // Sanity check
                  if (this.automationContainerIndex >= 0 && this.automationContainerIndex < this._imageViewer.get_items().get_count())
                     return this._imageViewer.get_items().get_item(this.automationContainerIndex);

                  return null;

               case AutomationControlMultiContainerMode.SinglePage:
               default:
                  // All containers belong to the first item
                  return this._imageViewer.activeItem;
            }
         }
         else {
            // No, active item
            return this._imageViewer.activeItem;
         }
      }

      private getCurrentContainer(): lt.Annotations.Engine.AnnContainer {
         if (this.automationObject != null && this.automationContainerIndex != -1)
            return this.automationObject.get_containers().get_item(this.automationContainerIndex);

         return null;
      }

      // Annotations toolkit will handle the DPI, so always return the transform without one
      automationTransform: lt.LeadMatrix; // read-only
      get_automationTransform(): lt.LeadMatrix {
         var item: lt.Controls.ImageViewerItem = this.getItemForCurrentContainer();
         var container = this.getCurrentContainer();
         if (item != null) {
            return this._imageViewer.getItemImageTransformWithDpi(item, false);
         }
         else
            return LeadMatrix.identity;
      }

      automationTransformChanged: lt.LeadEventType = lt.LeadEvent.create(this, "automationTransformChanged"); // read-only
      add_automationTransformChanged(value: lt.LeadEventHandler): void { this.automationTransformChanged.add(value); }
      remove_automationTransformChanged(value: lt.LeadEventHandler): void { this.automationTransformChanged.remove(value); }

      private imageViewer_TransformChanged = (sender: any, e: lt.Controls.ImageViewerItemChangedEventArgs): void => {
         // Let the automation know
         if (this.automationTransformChanged != null)
            this.automationTransformChanged.invoke(this, lt.LeadEventArgs.empty);
      }

      automationUseDpi: boolean; // read-only
      get_automationUseDpi(): boolean { return this._imageViewer != null && this._imageViewer.get_useDpi(); }

      automationUseDpiChanged: lt.LeadEventType = lt.LeadEvent.create(this, "automationUseDpiChanged"); // read-only
      add_automationUseDpiChanged(value: lt.LeadEventHandler): void { this.automationUseDpiChanged.add(value); }
      remove_automationUseDpiChanged(value: lt.LeadEventHandler): void { this.automationUseDpiChanged.remove(value); }

      imageViewer_PropertyChanged = (sender: any, e: lt.Controls.PropertyChangedEventArgs): void => {
         switch (e.propertyName) {
            case "UseDpi":
               if (this.automationUseDpiChanged != null)
                  this.automationUseDpiChanged.invoke(this, lt.LeadEventArgs.empty);
               break;
            default:
               break;
         }
      }

      automationXResolution: number; // read-only
      automationYResolution: number; // read-only
      get_automationXResolution(): number {
         var item: lt.Controls.ImageViewerItem = this.getItemForCurrentContainer();
         if (item != null)
            return item.get_resolution().get_width();
         else
            return 96.0;
      }
      get_automationYResolution(): number {
         var item: lt.Controls.ImageViewerItem = this.getItemForCurrentContainer();
         if (item != null)
            return item.get_resolution().get_height();
         else
            return 96.0;
      }

      // Rendering
      automationInvalidate(rc: lt.LeadRectD): void {
         // Invalidate the viewer
         if (this._imageViewer != null) {
            this._imageViewer.invalidate(rc);
         }
      }

      // Turn anti aliasing on and off
      automationAntiAlias: boolean = false;
      get_automationAntiAlias(): boolean { return this.automationAntiAlias; }
      set_automationAntiAlias(value: boolean) {
         this.automationAntiAlias = value;
         if (this._imageViewer) {
            this._imageViewer.invalidate(lt.LeadRectD.empty);
         }
      }

      renderingEngine: lt.Annotations.Engine.AnnRenderingEngine = null;
      get_renderingEngine(): lt.Annotations.Engine.AnnRenderingEngine { return this.renderingEngine; }
      set_renderingEngine(value: lt.Annotations.Engine.AnnRenderingEngine): void { this.renderingEngine = value; }

      private imageViewer_PostRender = (sender: any, e: lt.Controls.ImageViewerRenderEventArgs): void => {
         // Do we have a rendering engine?
         var renderingEngine = <lt.Annotations.Rendering.AnnHtml5RenderingEngine>this.renderingEngine;
         if (renderingEngine == null)
            return;

         var runMode = false;
         if (this.automationObject != null && this.automationObject.manager != null)
            runMode = (this.automationObject.manager.userMode == lt.Annotations.Engine.AnnUserMode.run);

         var context = e.get_context();

         var saveSmoothingMode = context["msImageSmoothingEnabled"];

         try {
            // Set the anti alias mode
            if (this.get_automationAntiAlias()) {
               if (!context["msImageSmoothingEnabled"])
                  context["msImageSmoothingEnabled"] = true;
            }
            else {
               if (context["msImageSmoothingEnabled"])
                  context["msImageSmoothingEnabled"] = false;
            }

            // Do we have multiple containers?
            var container: lt.Annotations.Engine.AnnContainer;
            if (this.automationGetContainersCallback != null) {
               // Yes, get the container for this item
               var containers = this.automationGetContainersCallback().toArray();

               if (containers != null) {
                  switch (this._multiContainerMode) {
                     case AutomationControlMultiContainerMode.MultiPage:
                        // Each container belong to an item
                        for (var index = 0; index < containers.length; index++) {
                           if (index < this._imageViewer.get_items().get_count()) {
                              var container = containers[index];
                              var item = this._imageViewer.get_items().get_item(index);
                              var containerBounds = this.automationObject.getContainerInvalidRect(container, true);
                              var intersects: boolean = !containerBounds.get_isEmpty();

                              if (intersects || !this._imageViewer.getItemViewBounds(item, lt.Controls.ImageViewerItemPart.item, true).isEmpty)
                                 lt.Annotations.JavaScript.ImageViewerAutomationControl.renderContainer(e, renderingEngine, container, runMode);
                           }
                        }
                        break;

                     case AutomationControlMultiContainerMode.SinglePage:
                     default:
                        // All containers belong to the active item
                        if (this._imageViewer.activeItem != null &&
                           !this._imageViewer.getItemViewBounds(this._imageViewer.activeItem, lt.Controls.ImageViewerItemPart.item, true).isEmpty) {
                           for (var index = 0; index < containers.length; index++) {
                              var container = containers[index];
                              var containerBounds = this.automationObject.getContainerInvalidRect(container, true);
                              var intersects: boolean = !containerBounds.get_isEmpty();

                              if (intersects)
                                 lt.Annotations.JavaScript.ImageViewerAutomationControl.renderContainer(e, renderingEngine, container, runMode);
                           }
                        }
                        break;
                  }
               }
            }
            else {
               // Using single-containers, just render the one the user set
               container = this._container;
               if (container != null)
                  lt.Annotations.JavaScript.ImageViewerAutomationControl.renderContainer(e, renderingEngine, container, runMode);
            }
         }
         finally {
            if (context["msImageSmoothingEnabled"] !== saveSmoothingMode)
               context["msImageSmoothingEnabled"] = saveSmoothingMode;
         }
      }

      private static renderContainer(e: lt.Controls.ImageViewerRenderEventArgs, renderingEngine: lt.Annotations.Rendering.AnnHtml5RenderingEngine, container: lt.Annotations.Engine.AnnContainer, runMode:boolean) {
         // Attach to the current container and context.
         var context: CanvasRenderingContext2D = e.get_context();
         var clipRectangle = e.get_clipRectangle();

         // Render the annotatirons
         renderingEngine.attach(container, context);
         try {
            // Convert the clip rectangle to annotation coordinates
            var annClipRect: lt.LeadRectD = container.mapper.rectToContainerCoordinates(clipRectangle);
         renderingEngine.render(annClipRect, runMode);
         }
         finally {
            renderingEngine.detach();
         }
      }

      // Containers support
      // Multi container support
      automationGetContainersCallback: lt.Annotations.Engine.AnnAutomationControlGetContainersCallback;
      get_automationGetContainersCallback(): lt.Annotations.Engine.AnnAutomationControlGetContainersCallback { return this.automationGetContainersCallback; }
      set_automationGetContainersCallback(value: lt.Annotations.Engine.AnnAutomationControlGetContainersCallback): void { this.automationGetContainersCallback = value; }

      automationContainerIndex: number = -1;
      get_automationContainerIndex(): number { return this.automationContainerIndex; }
      set_automationContainerIndex(value: number): void { this.automationContainerIndex = value; }

      // Single container support
      _container: lt.Annotations.Engine.AnnContainer;
      automationAttach(container: lt.Annotations.Engine.AnnContainer): void { this._container = container; }
      automationDetach(): void { this._container = null; }

      // Data provider for the images
      automationDataProvider: lt.Annotations.Engine.AnnDataProvider = new lt.Annotations.Engine.AnnDataProvider(); // read-only
      get_automationDataProvider(): lt.Annotations.Engine.AnnDataProvider { return this.automationDataProvider; }
      set_automationDataProvider(value: lt.Annotations.Engine.AnnDataProvider): void { this.automationDataProvider = value; }

      // Scroll Offset values for viewer
      automationScrollOffset: lt.LeadPointD; // read-only
      get_automationScrollOffset(): lt.LeadPointD {
         return this._imageViewer != null ? this._imageViewer.get_scrollOffset() : lt.LeadPointD.create(0, 0);
      }
   }
}