// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module lt.Annotations.JavaScript {
   export class AutomationInteractiveMode extends lt.Controls.ImageViewerInteractiveMode {

      public automationId: number = AutomationInteractiveMode.userModeId;

      constructor() {
         super();
         // Hook to left and right mouse button (if supported)
         this.mouseButtons = lt.Controls.MouseButtons.left;//| lt.Controls.MouseButtons.right;
         // Setup our item mode, when the user first click, make this our item
         this.autoItemMode = lt.Controls.ImageViewerAutoItemMode.autoSet;
         // Work on the image
         this.itemPart = lt.Controls.ImageViewerItemPart.image;
         // So selection works even if we click outside the items
          this.workOnBounds = false;
          // Don't  fire drag events on mouse wheel
          this.isDragMouseWheelEnabled = false;
      }

      private _id: number = this.automationId;
      get_id(): number { return this._id; }

      public setId(value: number): void {
         this._id = value;
      }

      // Supports either setting the automation control or if the ImageViewer itself implements IAnnAutomationControl
      private _automationControl: lt.Annotations.Engine.IAnnAutomationControl;
      public get automationControl(): lt.Annotations.Engine.IAnnAutomationControl {
         return this._automationControl;
      }
      public set automationControl(value: lt.Annotations.Engine.IAnnAutomationControl) {
         this._automationControl = value;
      }

      private get workAutomationControl(): lt.Annotations.Engine.IAnnAutomationControl {
         if (this._automationControl != null)
            return this._automationControl;
         else
            return <lt.Annotations.Engine.IAnnAutomationControl><any>(this.imageViewer);
      }

      get_name(): string {
         return "AutomationInteractiveMode";
      }

      canStartWork(e: lt.Controls.InteractiveEventArgs): boolean {
         return super.canStartWork(e) && this.workAutomationControl != null;
      }

      private _dragStartedHandler: lt.Controls.InteractiveDragStartedEventHandler;
      private _dragDeltaHandler: lt.Controls.InteractiveDragDeltaEventHandler;
      private _dragCompletedHandler: lt.Controls.InteractiveDragCompletedEventHandler;
      private _tapHandler: lt.Controls.InteractiveEventHandler;
      private _doubleTapHandler: lt.Controls.InteractiveEventHandler;
      private _moveHandler: lt.Controls.InteractiveEventHandler;


      start(imageViewer: lt.Controls.ImageViewer) {
         super.start(imageViewer);

         var interactiveService = this.interactiveService;

         this._dragStartedHandler = interactiveService.dragStarted.add(this.interactiveService_DragStarted);
         this._dragDeltaHandler = interactiveService.dragDelta.add(this.interactiveService_DragDelta);
         this._dragCompletedHandler = interactiveService.dragCompleted.add(this.interactiveService_DragCompleted);
         this._tapHandler =  interactiveService.tap.add(this.interactiveService_Tap);
         this._doubleTapHandler = interactiveService.doubleTap.add(this.interactiveService_DoubleTap);
         this._moveHandler = interactiveService.move.add(this.interactiveService_Move);
      }

      stop(imageViewer: lt.Controls.ImageViewer): void {
         if (this.isStarted) {
            var interactiveService: lt.Controls.InteractiveService = super.get_interactiveService();

            interactiveService.dragStarted.remove(this._dragStartedHandler);
            interactiveService.dragDelta.remove(this._dragDeltaHandler);
            interactiveService.dragCompleted.remove(this._dragCompletedHandler);
            interactiveService.tap.remove(this.interactiveService_Tap);
            interactiveService.doubleTap.remove(this._doubleTapHandler);
            interactiveService.move.remove(this._moveHandler);

            super.stop(imageViewer);
         }
      }

      private static convertPointerEventArgs(e: lt.Controls.InteractiveEventArgs, isDoubleTap: boolean): lt.Annotations.Engine.AnnPointerEventArgs {
         // Convert the point
         var point = LeadPointD.create(e.position.x, e.position.y);

         // Convert the mouse button
         var mouseButton = lt.Annotations.Engine.AnnMouseButton.none;

         if (!isDoubleTap) {
            if (e.mouseButton == lt.Controls.MouseButtons.left)
               mouseButton = lt.Annotations.Engine.AnnMouseButton.left;
            if (e.mouseButton == lt.Controls.MouseButtons.right)
               mouseButton = lt.Annotations.Engine.AnnMouseButton.right;
         }
         else {
            mouseButton = lt.Annotations.Engine.AnnMouseButton.left;
         }

         var args = lt.Annotations.Engine.AnnPointerEventArgs.create(mouseButton, point);
         args.isHandled = e.isHandled;
         return args;
      }

      private interactiveService_DragStarted = (sender: any, e: lt.Controls.InteractiveDragStartedEventArgs) => {
         if (this.canStartWork(e)) {
            this.onWorkStarted(LeadEventArgs.empty);
            var annArgs = lt.Annotations.JavaScript.AutomationInteractiveMode.convertPointerEventArgs(e, false);
            if (!e.isHandled) {
               this.workAutomationControl.onAutomationPointerDown(annArgs);
               e.isHandled = annArgs.isHandled;

               if (!e.isHandled)
                  this.onWorkCompleted(LeadEventArgs.empty);
            }
         }
      }

      private interactiveService_DragDelta = (sender: any, e: lt.Controls.InteractiveDragDeltaEventArgs) => {
         if (this.isWorking) {
            var annArgs = lt.Annotations.JavaScript.AutomationInteractiveMode.convertPointerEventArgs(e, false);
            if (!e.isHandled) {
               this.workAutomationControl.onAutomationPointerMove(annArgs);
               e.isHandled = annArgs.isHandled;
            }
         }
      }

      private interactiveService_DragCompleted = (sender: any, e: lt.Controls.InteractiveDragCompletedEventArgs) => {
         if (this.isWorking) {
            var annArgs = lt.Annotations.JavaScript.AutomationInteractiveMode.convertPointerEventArgs(e, false);
            if (!e.isHandled) {
               this.workAutomationControl.onAutomationPointerUp(annArgs);
               e.isHandled = annArgs.isHandled;
               this.onWorkCompleted(LeadEventArgs.empty);
            }
         }
      }

      private interactiveService_Tap = (sender: any, e: lt.Controls.InteractiveEventArgs) => {
         if (!this.isWorking && this.canStartWork(e)) {
            var annArgs = lt.Annotations.JavaScript.AutomationInteractiveMode.convertPointerEventArgs(e, true);
            if (!e.isHandled) {
               this.workAutomationControl.onAutomationPointerUp(annArgs);
               e.isHandled = annArgs.isHandled;
            }
         }
      }

      private interactiveService_DoubleTap = (sender: any, e: lt.Controls.InteractiveEventArgs) => {
         if (this.canStartWork(e)) {
            var annArgs = lt.Annotations.JavaScript.AutomationInteractiveMode.convertPointerEventArgs(e, true);
            if (!e.isHandled) {
               this.onWorkStarted(LeadEventArgs.empty);
               this.workAutomationControl.onAutomationDoubleClick(annArgs);
               e.isHandled = annArgs.isHandled;
               this.onWorkCompleted(LeadEventArgs.empty);
            }
         }
      }

      private interactiveService_Move = (sender: any, e: lt.Controls.InteractiveEventArgs) => {
         if (this.workAutomationControl == null) {
            return;
         }

         var annArgs = lt.Annotations.JavaScript.AutomationInteractiveMode.convertPointerEventArgs(e, false);
         this.workAutomationControl.onAutomationPointerMove(annArgs);
      }
   }
}