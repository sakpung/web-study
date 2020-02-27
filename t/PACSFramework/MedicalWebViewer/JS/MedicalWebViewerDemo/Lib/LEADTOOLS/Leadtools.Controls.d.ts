//***********************************************************************************************
//   Type definitions for Leadtools.Controls.js
//   Updated: 12/3/2019 19:00
//   Version: 20.0.0.56
//
//   Dependencies:
//      Leadtools.d.ts
//
//   Copyright (c) 1991-2019 All Rights Reserved. LEAD Technologies, Inc.
//   https://www.leadtools.com
//***********************************************************************************************

declare module lt.Controls {

   class CanvasOptions {
      static get_autoScale(): boolean;
      static set_autoScale(value: boolean): void;
      static get_maximumSize(): number;
      static set_maximumSize(value: number): void;
      static get_maximumInterpolationSize(): number;
      static set_maximumInterpolationSize(value: number): void;
      static autoScale: boolean;
      static maximumSize: number;
      static maximumInterpolationSize: number;
   }

   class ControlDropShadowOptions {
      static createDefault(): ControlDropShadowOptions;
      clone(): ControlDropShadowOptions;
      get_isVisible(): boolean;
      set_isVisible(value: boolean): void;
      get_color(): string;
      set_color(value: string): void;
      get_offsetX(): number;
      set_offsetX(value: number): void;
      get_offsetY(): number;
      set_offsetY(value: number): void;
      get_blur(): number;
      set_blur(value: number): void;
      isVisible: boolean;
      color: string;
      offsetX: number;
      offsetY: number;
      blur: number;
   }

   enum ControlScrollMode {
      auto = 0,
      hidden = 1,
      disabled = 2
   }

   enum ControlAlignment {
      near = 0,
      center = 1,
      far = 2
   }

   enum ControlSizeMode {
      none = 0,
      actualSize = 1,
      fit = 2,
      fitAlways = 3,
      fitWidth = 4,
      fitHeight = 5,
      stretch = 6
   }

   enum ControlTextTrimming {
      none = 0,
      character = 1,
      word = 2,
      ellipsisCharacter = 3,
      ellipsisWord = 4,
      ellipsisPath = 5
   }

   enum InterpolationRunMode {
      sequential = 0,
      parallel = 1
   }

   enum InterpolationMode {
      none = 0,
      resample = 1,
      scaleToGray = 2
   }

   enum InterpolationStatus {
      started = 0,
      completed = 1,
      aborted = 2,
      error = 3
   }

   interface InterpolationEventHandler extends lt.LeadEventHandler {
      (sender: any, e: InterpolationEventArgs): void;
   }

   class InterpolationEventType extends lt.LeadEvent {
      add(value: InterpolationEventHandler): InterpolationEventHandler;
      remove(value: InterpolationEventHandler): void;
   }

   class InterpolationEventArgs extends lt.LeadEventArgs {
      static create(mode: InterpolationMode, item: ImageViewerItem, error: Error, status: InterpolationStatus): InterpolationEventArgs;
      get_mode(): InterpolationMode;
      get_item(): ImageViewerItem;
      get_status(): InterpolationStatus;
      get_error(): Error;
      get_isCanceled(): boolean;
      set_isCanceled(value: boolean): void;
      mode: InterpolationMode; // read-only
      item: ImageViewerItem; // read-only
      status: InterpolationStatus; // read-only
      error: Error; // read-only
      isCanceled: boolean;
   }

   enum Keys {
      none = 0,
      lButton = 1,
      rButton = 2,
      cancel = 3,
      mButton = 4,
      enter = 13,
      escape = 27,
      space = 32,
      pageUp = 33,
      pageDown = 34,
      end = 35,
      home = 36,
      left = 37,
      up = 38,
      right = 39,
      down = 40,
      keyCode = 65535,
      shift = 65536,
      control = 131072,
      alt = 262144,
      modifiers = -65536
   }

   enum MouseButtons {
      none = 0,
      left = 1,
      right = 2,
      middle = 4,
      xButton1 = 8,
      xButton2 = 16
   }

   class ControlPadding {
      clone(): ControlPadding;
      static create(left: number, top: number, right: number, bottom: number): ControlPadding;
      static createAll(all: number): ControlPadding;
      static get_empty(): ControlPadding;
      get_left(): number;
      set_left(value: number): void;
      get_top(): number;
      set_top(value: number): void;
      get_right(): number;
      set_right(value: number): void;
      get_bottom(): number;
      set_bottom(value: number): void;
      get_all(): number;
      set_all(value: number): void;
      constructor();
      static empty: ControlPadding; // read-only
      left: number;
      top: number;
      right: number;
      bottom: number;
      all: number;
   }

   interface PropertyChangedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: PropertyChangedEventArgs): void;
   }

   class PropertyChangedEventType extends lt.LeadEvent {
      add(value: PropertyChangedEventHandler): PropertyChangedEventHandler;
      remove(value: PropertyChangedEventHandler): void;
   }

   class PropertyChangedEventArgs extends lt.LeadEventArgs {
      static create(propertyName: string): PropertyChangedEventArgs;
      get_propertyName(): string;
      set_propertyName(value: string): void;
      constructor(propertyName: string);
      propertyName: string;
   }

   enum ControlRegionRenderMode {
      none = 0,
      fixed = 1,
      animated = 2
   }

   interface ControlRegionRenderCallback {
      (target: any, context: CanvasRenderingContext2D, transform: lt.LeadMatrix, region: any, opacity: number, animateIndex: number): void;
   }

   class ControlRegionRenderer {
      static get_instance(): ControlRegionRenderer;
      get_size(): number;
      set_size(value: number): void;
      get_regionRenderCallback(): ControlRegionRenderCallback;
      set_regionRenderCallback(value: ControlRegionRenderCallback): void;
      static instance: ControlRegionRenderer; // read-only
      size: number;
      regionRenderCallback: ControlRegionRenderCallback;
      static maximumAnimateIndex: number;
   }

   class ImageViewer {
      remove_autoItemElementsRemoved(value: ImageViewerRenderEventHandler): void;
      onAutoItemElementsRemoved(e: ImageViewerRenderEventArgs): void;  // protected
      add_elementsUpdated(value: ImageViewerElementsUpdatedEventHandler): void;
      remove_elementsUpdated(value: ImageViewerElementsUpdatedEventHandler): void;
      onElementsUpdated(e: ImageViewerElementsUpdatedEventArgs): void;  // protected
      disableTransitions(): void;
      get_isTransitionsEnabled(): boolean;
      enableTransitions(): void;
      add_imageLoading(value: ImageViewerImageLoadingEventHandler): void;
      remove_imageLoading(value: ImageViewerImageLoadingEventHandler): void;
      static getDestinationRectangle(sourceWidth: number, sourceHeight: number, destinationRect: lt.LeadRectD, sizeMode: ControlSizeMode, horizontalAlignment: ControlAlignment, verticalAlignment: ControlAlignment): lt.LeadRectD;
      static getScaleFactors(destinationSize: lt.LeadSizeD, sourceSize: lt.LeadSizeD, sizeMode: ControlSizeMode): lt.LeadSizeD;
      onForeCanvasSizeChanged(e: lt.LeadEventArgs): void;  // protected
      static get_imageProcessingLibrariesPath(): string;
      static set_imageProcessingLibrariesPath(value: string): void;
      setItemFloater(item: ImageViewerItem, newFloater: HTMLCanvasElement): void;
      get_eraseBackgroundOnInvalidate(): boolean;
      set_eraseBackgroundOnInvalidate(value: boolean): void;
      add_eraseBackground(value: ImageViewerRenderEventHandler): void;
      remove_eraseBackground(value: ImageViewerRenderEventHandler): void;
      onEraseBackground(e: ImageViewerRenderEventArgs): void;  // protected
      renderRedirect(context: CanvasRenderingContext2D, options: ImageViewerRenderRedirectOptions, clipRectangle: lt.LeadRectD): void;
      invalidate(rc: lt.LeadRectD): void;
      get_allowDrop(): boolean;
      set_allowDrop(value: boolean): void;
      processDragDropUrl(targetItem: ImageViewerItem, url: string): void;  // protected
      get_interpolationRunMode(): InterpolationRunMode;
      set_interpolationRunMode(value: InterpolationRunMode): void;
      get_interpolationMode(): InterpolationMode;
      set_interpolationMode(value: InterpolationMode): void;
      add_interpolation(value: InterpolationEventHandler): void;
      remove_interpolation(value: InterpolationEventHandler): void;
      get_image(): HTMLImageElement;
      set_image(value: HTMLImageElement): void;
      get_element(): HTMLElement;
      set_element(value: HTMLElement): void;
      get_canvas(): HTMLCanvasElement;
      set_canvas(value: HTMLCanvasElement): void;
      get_imageUrl(): string;
      set_imageUrl(value: string): void;
      get_backImageUrl(): string;
      set_backImageUrl(value: string): void;
      get_backImage(): HTMLElement;
      set_backImage(value: HTMLElement): void;
      get_floater(): HTMLCanvasElement;
      set_floater(value: HTMLCanvasElement): void;
      get_loadImageUrlMode(): lt.ImageLoaderUrlMode;
      set_loadImageUrlMode(value: lt.ImageLoaderUrlMode): void;
      get_backImageLoadImageUrlMode(): lt.ImageLoaderUrlMode;
      set_backImageLoadImageUrlMode(value: lt.ImageLoaderUrlMode): void;
      beginAutoSizeChanged(): void;
      endAutoSizeChanged(): void;
      get_updateShadowOnRotation(): boolean;
      set_updateShadowOnRotation(value: boolean): void;
      get_flipImageElement(): boolean;
      set_flipImageElement(value: boolean): void;
      get_reverseImageElement(): boolean;
      set_reverseImageElement(value: boolean): void;
      updateStyles(): void;
      add_autoItemElementsAdded(value: ImageViewerRenderEventHandler): void;
      remove_autoItemElementsAdded(value: ImageViewerRenderEventHandler): void;
      onAutoItemElementsAdded(e: ImageViewerRenderEventArgs): void;  // protected
      add_autoItemElementsRemoved(value: ImageViewerRenderEventHandler): void;
      onRenderText(e: ImageViewerRenderEventArgs): void;  // protected
      get_interactiveService(): InteractiveService;
      set_interactiveService(value: InteractiveService): void;
      get_interactiveModes(): ImageViewerInteractiveModes;
      get_workingInteractiveMode(): ImageViewerInteractiveMode;
      get_idleInteractiveMode(): ImageViewerInteractiveMode;
      get_hitTestStateInteractiveMode(): ImageViewerInteractiveMode;
      get_defaultInteractiveMode(): ImageViewerInteractiveMode;
      set_defaultInteractiveMode(value: ImageViewerInteractiveMode): void;
      get_dropCopyKeyState(): Keys;
      set_dropCopyKeyState(value: Keys): void;
      get_dropMoveKeyState(): Keys;
      set_dropMoveKeyState(value: Keys): void;
      get_dropLinkKeyState(): Keys;
      set_dropLinkKeyState(value: Keys): void;
      add_itemDragDrop(value: ImageViewerItemDragDropEventHandler): void;
      remove_itemDragDrop(value: ImageViewerItemDragDropEventHandler): void;
      onItemDragDrop(e: ImageViewerItemDragDropEventArgs): void;  // protected
      get_imageResolution(): lt.LeadSizeD;
      set_imageResolution(value: lt.LeadSizeD): void;
      get_imageSize(): lt.LeadSizeD;
      set_imageSize(value: lt.LeadSizeD): void;
      get_imageScale(): number;
      set_imageScale(value: number): void;
      get_hasImage(): boolean;
      get_imageTransform(): lt.LeadMatrix;
      getImageTransformWithDpi(useDpi: boolean): lt.LeadMatrix;
      get_floaterTransform(): lt.LeadMatrix;
      set_floaterTransform(value: lt.LeadMatrix): void;
      get_autoResetOptions(): ImageViewerAutoResetOptions;
      set_autoResetOptions(value: ImageViewerAutoResetOptions): void;
      reset(): void;
      get_imageBounds(): lt.LeadRectD;
      get_viewBounds(): lt.LeadRectD;
      get_useElements(): boolean;
      get_tag(): any;
      set_tag(value: any): void;
      dispose(): void;
      get_imagesDiv(): HTMLDivElement;
      get_mainDiv(): HTMLDivElement;
      get_autoScrollDiv(): HTMLDivElement;
      get_foreCanvas(): HTMLCanvasElement;
      get_eventCanvas(): HTMLCanvasElement;
      get_passthroughDiv(): HTMLDivElement;
      get_viewDiv(): HTMLDivElement;
      get_viewDivHolder(): HTMLDivElement;
      onSizeChanged(): void;
      get_controlSize(): lt.LeadSizeD;
      get_hasSize(): boolean;
      get_enableRequestAnimationFrame(): boolean;
      set_enableRequestAnimationFrame(value: boolean): void;
      get_autoCreateCanvas(): boolean;
      set_autoCreateCanvas(value: boolean): void;
      get_resizeElementForView(): boolean;
      set_resizeElementForView(value: boolean): void;
      add_foreCanvasSizeChanged(value: lt.LeadEventHandler): void;
      remove_foreCanvasSizeChanged(value: lt.LeadEventHandler): void;
      endTransform(): void;
      updateTransform(): void;
      get_canTransform(): boolean;  // protected
      get_viewTransform(): lt.LeadMatrix;
      get_viewSize(): lt.LeadSizeD;
      get_defaultZoomOrigin(): lt.LeadPointD;
      zoom(sizeMode: ControlSizeMode, zoomValue: number, origin: lt.LeadPointD): void;
      scrollBy(point: lt.LeadPointD): void;
      scrollByRestrict(point: lt.LeadPointD): void;
      zoomToRect(rect: lt.LeadRectD): void;
      centerAtPoint(point: lt.LeadPointD): void;
      get_ownerDraw(): boolean;
      set_ownerDraw(value: boolean): void;
      get_imageRegionRenderMode(): ControlRegionRenderMode;
      set_imageRegionRenderMode(value: ControlRegionRenderMode): void;
      get_floaterRegionRenderMode(): ControlRegionRenderMode;
      set_floaterRegionRenderMode(value: ControlRegionRenderMode): void;
      get_floaterOpacity(): number;
      set_floaterOpacity(value: number): void;
      combineFloater(deleteFloater: boolean): void;
      convertTransform(transform: lt.LeadMatrix, sourceItem: ImageViewerItem, destinationItem: ImageViewerItem): lt.LeadMatrix;
      beginRender(): void;
      endRender(): void;
      get_canRender(): boolean;  // protected
      get_isRenderRedirected(): boolean;
      add_redirectRender(value: ImageViewerRenderEventHandler): void;
      remove_redirectRender(value: ImageViewerRenderEventHandler): void;
      onRedirectRender(e: ImageViewerRenderEventArgs): void;  // protected
      add_renderError(value: ImageViewerRenderEventHandler): void;
      remove_renderError(value: ImageViewerRenderEventHandler): void;
      onRenderError(e: ImageViewerRenderEventArgs): void;  // protected
      add_preRender(value: ImageViewerRenderEventHandler): void;
      remove_preRender(value: ImageViewerRenderEventHandler): void;
      onPreRender(e: ImageViewerRenderEventArgs): void;  // protected
      add_render(value: ImageViewerRenderEventHandler): void;
      remove_render(value: ImageViewerRenderEventHandler): void;
      onRender(e: ImageViewerRenderEventArgs): void;  // protected
      add_postRender(value: ImageViewerRenderEventHandler): void;
      remove_postRender(value: ImageViewerRenderEventHandler): void;
      onPostRender(e: ImageViewerRenderEventArgs): void;  // protected
      add_preRenderItem(value: ImageViewerRenderEventHandler): void;
      remove_preRenderItem(value: ImageViewerRenderEventHandler): void;
      onPreRenderItem(e: ImageViewerRenderEventArgs): void;  // protected
      add_renderItem(value: ImageViewerRenderEventHandler): void;
      remove_renderItem(value: ImageViewerRenderEventHandler): void;
      onRenderItem(e: ImageViewerRenderEventArgs): void;  // protected
      add_postRenderItem(value: ImageViewerRenderEventHandler): void;
      remove_postRenderItem(value: ImageViewerRenderEventHandler): void;
      onPostRenderItem(e: ImageViewerRenderEventArgs): void;  // protected
      add_renderItemRegion(value: ImageViewerRenderEventHandler): void;
      remove_renderItemRegion(value: ImageViewerRenderEventHandler): void;
      onRenderItemRegion(e: ImageViewerRenderEventArgs): void;  // protected
      add_renderItemFloaterRegion(value: ImageViewerRenderEventHandler): void;
      remove_renderItemFloaterRegion(value: ImageViewerRenderEventHandler): void;
      onRenderItemFloaterRegion(e: ImageViewerRenderEventArgs): void;  // protected
      add_renderItemFloater(value: ImageViewerRenderEventHandler): void;
      remove_renderItemFloater(value: ImageViewerRenderEventHandler): void;
      onRenderItemFloater(e: ImageViewerRenderEventArgs): void;  // protected
      add_renderShadow(value: ImageViewerRenderEventHandler): void;
      remove_renderShadow(value: ImageViewerRenderEventHandler): void;
      onRenderShadow(e: ImageViewerRenderEventArgs): void;  // protected
      add_renderBorder(value: ImageViewerRenderEventHandler): void;
      remove_renderBorder(value: ImageViewerRenderEventHandler): void;
      onRenderBorder(e: ImageViewerRenderEventArgs): void;  // protected
      add_renderBackground(value: ImageViewerRenderEventHandler): void;
      remove_renderBackground(value: ImageViewerRenderEventHandler): void;
      onRenderBackground(e: ImageViewerRenderEventArgs): void;  // protected
      add_renderImage(value: ImageViewerRenderEventHandler): void;
      remove_renderImage(value: ImageViewerRenderEventHandler): void;
      onRenderImage(e: ImageViewerRenderEventArgs): void;  // protected
      add_renderText(value: ImageViewerRenderEventHandler): void;
      remove_renderText(value: ImageViewerRenderEventHandler): void;
      remove_selectedItemsChanged(value: lt.LeadEventHandler): void;
      onSelectedItemsChanged(e: lt.LeadEventArgs): void;  // protected
      get_activeItem(): ImageViewerItem;
      set_activeItem(value: ImageViewerItem): void;
      add_activeItemChanged(value: lt.LeadEventHandler): void;
      remove_activeItemChanged(value: lt.LeadEventHandler): void;
      onActiveItemChanged(e: lt.LeadEventArgs): void;  // protected
      get_hasItems(): boolean;
      getItemBounds(item: ImageViewerItem, part: ImageViewerItemPart): lt.LeadRectD;
      convertBoundsToView(bounds: lt.LeadRectD, clipped: boolean): lt.LeadRectD;
      getItemViewBounds(item: ImageViewerItem, part: ImageViewerItemPart, clipped: boolean): lt.LeadRectD;
      getViewBounds(withPadding: boolean, clipped: boolean): lt.LeadRectD;
      getItemTransform(item: ImageViewerItem): lt.LeadMatrix;
      getItemContentTransform(item: ImageViewerItem): lt.LeadMatrix;
      getItemImageTransform(item: ImageViewerItem): lt.LeadMatrix;
      getItemImageFloatingPointTransform(item: ImageViewerItem): lt.LeadMatrix;
      getItemImageTransformWithDpi(item: ImageViewerItem, useDpi: boolean): lt.LeadMatrix;
      getItemFloaterTransform(item: ImageViewerItem): lt.LeadMatrix;
      getFirstVisibleItemIndex(part: ImageViewerItemPart): number;
      isItemVisible(item: ImageViewerItem, part: ImageViewerItemPart): boolean;
      getFirstVisibleItem(part: ImageViewerItemPart): ImageViewerItem;
      getLastVisibleItem(part: ImageViewerItemPart): ImageViewerItem;
      getLastVisibleItemIndex(part: ImageViewerItemPart): number;
      getAllVisibleItems(part: ImageViewerItemPart): ImageViewerItem[];
      getLargestVisibleItemIndex(part: ImageViewerItemPart): number;
      getLargestVisibleItem(part: ImageViewerItemPart): ImageViewerItem;
      findNearestItem(point: lt.LeadPointD): ImageViewerItem;
      hitTestItems(rect: lt.LeadRectD): ImageViewerItem[];
      hitTestItem(point: lt.LeadPointD): ImageViewerItem;
      hitTestFloater(point: lt.LeadPointD): ImageViewerItem;
      hitTestItemPart(item: ImageViewerItem, point: lt.LeadPointD): ImageViewerItemPart;
      convertPoints(item: ImageViewerItem, fromType: ImageViewerCoordinateType, toType: ImageViewerCoordinateType, points: lt.LeadPointD[]): void;
      convertPoint(item: ImageViewerItem, fromType: ImageViewerCoordinateType, toType: ImageViewerCoordinateType, point: lt.LeadPointD): lt.LeadPointD;
      convertRect(item: ImageViewerItem, fromType: ImageViewerCoordinateType, toType: ImageViewerCoordinateType, rect: lt.LeadRectD): lt.LeadRectD;
      stopInertiaScroll(): void;
      gotoItemByIndex(index: number): void;
      gotoItem(item: ImageViewerItem): void;
      ensureItemVisibleByIndex(index: number): void;
      ensureItemVisible(item: ImageViewerItem): void;
      ensureBoundsVisible(bounds: lt.LeadRectD): void;
      get_viewLayout(): ImageViewerViewLayout;
      set_viewLayout(value: ImageViewerViewLayout): void;
      getItemImageSize(item: ImageViewerItem, useDpi: boolean): lt.LeadSizeD;
      getItemFloaterSize(item: ImageViewerItem, useDpi: boolean): lt.LeadSizeD;
      add_itemChanged(value: ImageViewerItemChangedEventHandler): void;
      remove_itemChanged(value: ImageViewerItemChangedEventHandler): void;
      onItemChanged(e: ImageViewerItemChangedEventArgs): void;  // protected
      add_itemError(value: ImageViewerItemErrorEventHandler): void;
      remove_itemError(value: ImageViewerItemErrorEventHandler): void;
      onItemError(e: ImageViewerItemErrorEventArgs): void;  // protected
      invalidateItemByIndex(index: number): void;
      invalidateItem(item: ImageViewerItem): void;
      get_aspectRatioCorrection(): number;
      set_aspectRatioCorrection(value: number): void;
      get_viewHorizontalAlignment(): ControlAlignment;
      set_viewHorizontalAlignment(value: ControlAlignment): void;
      get_viewVerticalAlignment(): ControlAlignment;
      set_viewVerticalAlignment(value: ControlAlignment): void;
      get_itemHorizontalAlignment(): ControlAlignment;
      set_itemHorizontalAlignment(value: ControlAlignment): void;
      get_itemVerticalAlignment(): ControlAlignment;
      set_itemVerticalAlignment(value: ControlAlignment): void;
      get_flip(): boolean;
      set_flip(value: boolean): void;
      get_reverse(): boolean;
      set_reverse(value: boolean): void;
      get_rotateAngle(): number;
      set_rotateAngle(value: number): void;
      get_invert(): boolean;
      set_invert(value: boolean): void;
      get_sizeMode(): ControlSizeMode;
      get_maximumScaleFactor(): number;
      set_maximumScaleFactor(value: number): void;
      get_minimumScaleFactor(): number;
      set_minimumScaleFactor(value: number): void;
      get_xScaleFactor(): number;
      get_yScaleFactor(): number;
      get_scaleFactor(): number;
      add_transformChanged(value: lt.LeadEventHandler): void;
      remove_transformChanged(value: lt.LeadEventHandler): void;
      onTransformChanged(e: lt.LeadEventArgs): void;
      beginUpdate(): void;
      endUpdate(): void;
      beginTransform(): void;
      add_propertyChanged(value: PropertyChangedEventHandler): void;
      remove_propertyChanged(value: PropertyChangedEventHandler): void;
      onPropertyChanged(propertyName: string): void;  // protected
      get_syncId(): number;
      set_isSyncSource(value: boolean): void;
      get_isSyncSource(): boolean;
      set_isSyncTarget(value: boolean): void;
      get_isSyncTarget(): boolean;
      static disableSync(syncId: number): void;
      static isSyncDisabled(syncId: number): boolean;
      static enableSync(syncId: number): void;
      static sync(imageViewers: ImageViewer[]): void;
      static getSynced(syncId: number): ImageViewer[];
      static unsync(imageViewer: ImageViewer): void;
      static unsyncGroup(syncId: number): ImageViewer[];
      get_screenDpi(): lt.LeadSizeD;
      set_screenDpi(value: lt.LeadSizeD): void;
      get_useDpi(): boolean;
      set_useDpi(value: boolean): void;
      get_scrollMode(): ControlScrollMode;
      set_scrollMode(value: ControlScrollMode): void;
      get_restrictScroll(): boolean;
      set_restrictScroll(value: boolean): void;
      get_scrollOffset(): lt.LeadPointD;
      set_scrollOffset(value: lt.LeadPointD): void;
      add_scrollOffsetChanged(value: lt.LeadEventHandler): void;
      remove_scrollOffsetChanged(value: lt.LeadEventHandler): void;
      onScrollOffsetChanged(e: lt.LeadEventArgs): void;  // protected
      get_maximumScrollSize(): lt.LeadSizeD;
      restrictScrollOffset(value: lt.LeadPointD): lt.LeadPointD;
      get_viewBorderThickness(): number;
      set_viewBorderThickness(value: number): void;
      get_viewBorderColor(): string;
      set_viewBorderColor(value: string): void;
      get_viewMargin(): ControlPadding;
      set_viewMargin(value: ControlPadding): void;
      get_viewPadding(): ControlPadding;
      set_viewPadding(value: ControlPadding): void;
      get_viewDropShadow(): ControlDropShadowOptions;
      set_viewDropShadow(value: ControlDropShadowOptions): void;
      get_itemBorderThickness(): number;
      set_itemBorderThickness(value: number): void;
      get_itemBorderColor(): string;
      set_itemBorderColor(value: string): void;
      get_itemMargin(): ControlPadding;
      set_itemMargin(value: ControlPadding): void;
      get_itemPadding(): ControlPadding;
      set_itemPadding(value: ControlPadding): void;
      get_imageBorderThickness(): number;
      set_imageBorderThickness(value: number): void;
      get_imageBorderColor(): string;
      set_imageBorderColor(value: string): void;
      get_imageDropShadow(): ControlDropShadowOptions;
      set_imageDropShadow(value: ControlDropShadowOptions): void;
      get_itemSpacing(): lt.LeadSizeD;
      set_itemSpacing(value: lt.LeadSizeD): void;
      get_itemBackgroundColor(): string;
      set_itemBackgroundColor(value: string): void;
      get_imageBackgroundColor(): string;
      set_imageBackgroundColor(value: string): void;
      get_selectedItemBorderColor(): string;
      set_selectedItemBorderColor(value: string): void;
      get_selectedItemBackgroundColor(): string;
      set_selectedItemBackgroundColor(value: string): void;
      get_hoveredItemBorderColor(): string;
      set_hoveredItemBorderColor(value: string): void;
      get_hoveredItemBackgroundColor(): string;
      set_hoveredItemBackgroundColor(value: string): void;
      get_activeItemBorderColor(): string;
      set_activeItemBorderColor(value: string): void;
      get_activeItemBackgroundColor(): string;
      set_activeItemBackgroundColor(value: string): void;
      get_itemTextFont(): string;
      set_itemTextFont(value: string): void;
      get_itemSize(): lt.LeadSizeD;
      set_itemSize(value: lt.LeadSizeD): void;
      get_itemSizeMode(): ControlSizeMode;
      set_itemSizeMode(value: ControlSizeMode): void;
      get_resizeOnTransform(): boolean;
      set_resizeOnTransform(value: boolean): void;
      get_clipImageToContent(): boolean;
      set_clipImageToContent(value: boolean): void;
      get_imageHorizontalAlignment(): ControlAlignment;
      set_imageHorizontalAlignment(value: ControlAlignment): void;
      get_imageVerticalAlignment(): ControlAlignment;
      set_imageVerticalAlignment(value: ControlAlignment): void;
      get_textHorizontalAlignment(): ControlAlignment;
      set_textHorizontalAlignment(value: ControlAlignment): void;
      get_textVerticalAlignment(): ControlAlignment;
      set_textVerticalAlignment(value: ControlAlignment): void;
      get_itemTextWrap(): boolean;
      set_itemTextWrap(value: boolean): void;
      get_itemTextTrimming(): ControlTextTrimming;
      set_itemTextTrimming(value: ControlTextTrimming): void;
      get_itemTextColor(): string;
      set_itemTextColor(value: string): void;
      get_selectedItemTextColor(): string;
      set_selectedItemTextColor(value: string): void;
      translateItemScaleFactor(item: ImageViewerItem, dx: number, dy: number, resetValues: boolean): void;
      get_items(): ImageViewerItems;
      add_selectedItemsChanged(value: lt.LeadEventHandler): void;
      constructor(createOptions: ImageViewerCreateOptions);
      syncId: number; // read-only
      isSyncSource: boolean;
      isSyncTarget: boolean;
      screenDpi: lt.LeadSizeD;
      useDpi: boolean;
      scrollMode: ControlScrollMode;
      restrictScroll: boolean;
      scrollOffset: lt.LeadPointD;
      maximumScrollSize: lt.LeadSizeD; // read-only
      viewBorderThickness: number;
      viewBorderColor: string;
      viewMargin: ControlPadding;
      viewPadding: ControlPadding;
      viewDropShadow: ControlDropShadowOptions;
      itemBorderThickness: number;
      itemBorderColor: string;
      itemMargin: ControlPadding;
      itemPadding: ControlPadding;
      imageBorderThickness: number;
      imageBorderColor: string;
      imageDropShadow: ControlDropShadowOptions;
      itemSpacing: lt.LeadSizeD;
      itemBackgroundColor: string;
      imageBackgroundColor: string;
      selectedItemBorderColor: string;
      selectedItemBackgroundColor: string;
      hoveredItemBorderColor: string;
      hoveredItemBackgroundColor: string;
      activeItemBorderColor: string;
      activeItemBackgroundColor: string;
      itemTextFont: string;
      itemSize: lt.LeadSizeD;
      itemSizeMode: ControlSizeMode;
      resizeOnTransform: boolean;
      clipImageToContent: boolean;
      imageHorizontalAlignment: ControlAlignment;
      imageVerticalAlignment: ControlAlignment;
      textHorizontalAlignment: ControlAlignment;
      textVerticalAlignment: ControlAlignment;
      itemTextWrap: boolean;
      itemTextTrimming: ControlTextTrimming;
      itemTextColor: string;
      selectedItemTextColor: string;
      items: ImageViewerItems; // read-only
      activeItem: ImageViewerItem;
      hasItems: boolean; // read-only
      viewLayout: ImageViewerViewLayout;
      aspectRatioCorrection: number;
      viewHorizontalAlignment: ControlAlignment;
      viewVerticalAlignment: ControlAlignment;
      itemHorizontalAlignment: ControlAlignment;
      itemVerticalAlignment: ControlAlignment;
      flip: boolean;
      reverse: boolean;
      rotateAngle: number;
      invert: boolean;
      sizeMode: ControlSizeMode; // read-only
      maximumScaleFactor: number;
      minimumScaleFactor: number;
      xScaleFactor: number; // read-only
      yScaleFactor: number; // read-only
      scaleFactor: number; // read-only
      canTransform: boolean; // read-only
      viewTransform: lt.LeadMatrix; // read-only
      viewSize: lt.LeadSizeD; // read-only
      defaultZoomOrigin: lt.LeadPointD; // read-only
      ownerDraw: boolean;
      imageRegionRenderMode: ControlRegionRenderMode;
      floaterRegionRenderMode: ControlRegionRenderMode;
      floaterOpacity: number;
      canRender: boolean; // read-only
      isRenderRedirected: boolean; // read-only
      interactiveService: InteractiveService;
      interactiveModes: ImageViewerInteractiveModes; // read-only
      workingInteractiveMode: ImageViewerInteractiveMode; // read-only
      idleInteractiveMode: ImageViewerInteractiveMode; // read-only
      hitTestStateInteractiveMode: ImageViewerInteractiveMode; // read-only
      defaultInteractiveMode: ImageViewerInteractiveMode;
      dropCopyKeyState: Keys;
      dropMoveKeyState: Keys;
      dropLinkKeyState: Keys;
      imageResolution: lt.LeadSizeD;
      imageSize: lt.LeadSizeD;
      imageScale: number;
      hasImage: boolean; // read-only
      imageTransform: lt.LeadMatrix; // read-only
      floaterTransform: lt.LeadMatrix;
      autoResetOptions: ImageViewerAutoResetOptions;
      imageBounds: lt.LeadRectD; // read-only
      viewBounds: lt.LeadRectD; // read-only
      useElements: boolean; // read-only
      tag: any;
      imagesDiv: HTMLDivElement; // read-only
      mainDiv: HTMLDivElement; // read-only
      autoScrollDiv: HTMLDivElement; // read-only
      foreCanvas: HTMLCanvasElement; // read-only
      eventCanvas: HTMLCanvasElement; // read-only
      passthroughDiv: HTMLDivElement; // read-only
      viewDiv: HTMLDivElement; // read-only
      viewDivHolder: HTMLDivElement; // read-only
      controlSize: lt.LeadSizeD; // read-only
      hasSize: boolean; // read-only
      enableRequestAnimationFrame: boolean;
      autoCreateCanvas: boolean;
      resizeElementForView: boolean;
      static imageProcessingLibrariesPath: string;
      eraseBackgroundOnInvalidate: boolean;
      allowDrop: boolean;
      interpolationRunMode: InterpolationRunMode;
      interpolationMode: InterpolationMode;
      image: HTMLImageElement;
      element: HTMLElement;
      canvas: HTMLCanvasElement;
      imageUrl: string;
      backImageUrl: string;
      backImage: HTMLElement;
      floater: HTMLCanvasElement;
      loadImageUrlMode: lt.ImageLoaderUrlMode;
      backImageLoadImageUrlMode: lt.ImageLoaderUrlMode;
      updateShadowOnRotation: boolean;
      flipImageElement: boolean;
      reverseImageElement: boolean;
      isTransitionsEnabled: boolean; // read-only
      propertyChanged: PropertyChangedEventType; // read-only
      scrollOffsetChanged: lt.LeadEventType; // read-only
      selectedItemsChanged: lt.LeadEventType; // read-only
      activeItemChanged: lt.LeadEventType; // read-only
      itemChanged: ImageViewerItemChangedEventType; // read-only
      itemError: ImageViewerItemErrorEventType; // read-only
      transformChanged: lt.LeadEventType; // read-only
      redirectRender: ImageViewerRenderEventType; // read-only
      renderError: ImageViewerRenderEventType; // read-only
      preRender: ImageViewerRenderEventType; // read-only
      render: ImageViewerRenderEventType; // read-only
      postRender: ImageViewerRenderEventType; // read-only
      preRenderItem: ImageViewerRenderEventType; // read-only
      renderItem: ImageViewerRenderEventType; // read-only
      postRenderItem: ImageViewerRenderEventType; // read-only
      renderItemRegion: ImageViewerRenderEventType; // read-only
      renderItemFloaterRegion: ImageViewerRenderEventType; // read-only
      renderItemFloater: ImageViewerRenderEventType; // read-only
      renderShadow: ImageViewerRenderEventType; // read-only
      renderBorder: ImageViewerRenderEventType; // read-only
      renderBackground: ImageViewerRenderEventType; // read-only
      renderImage: ImageViewerRenderEventType; // read-only
      renderText: ImageViewerRenderEventType; // read-only
      itemDragDrop: ImageViewerItemDragDropEventType; // read-only
      foreCanvasSizeChanged: lt.LeadEventType; // read-only
      eraseBackground: ImageViewerRenderEventType; // read-only
      interpolation: InterpolationEventType; // read-only
      autoItemElementsAdded: ImageViewerRenderEventType; // read-only
      autoItemElementsRemoved: ImageViewerRenderEventType; // read-only
      elementsUpdated: ImageViewerElementsUpdatedEventType; // read-only
      imageLoading: ImageViewerImageLoadingEventType; // read-only
      preventOptimizedRender: boolean;
   }

   interface ImageViewerImageLoadingEventHandler extends lt.LeadEventHandler {
      (sender: any, e: ImageViewerImageLoadingEventArgs): void;
   }

   class ImageViewerImageLoadingEventType extends lt.LeadEvent {
      add(value: ImageViewerImageLoadingEventHandler): ImageViewerImageLoadingEventHandler;
      remove(value: ImageViewerImageLoadingEventHandler): void;
   }

   class ImageViewerImageLoadingEventArgs extends lt.LeadEventArgs {
      get_imageLoader(): lt.ImageLoader;
      get_item(): ImageViewerItem;
      get_isBackImage(): boolean;
      constructor(imageLoader: lt.ImageLoader, item: ImageViewerItem, isBackImage: boolean);
      imageLoader: lt.ImageLoader; // read-only
      item: ImageViewerItem; // read-only
      isBackImage: boolean; // read-only
   }

   class ImageViewerCreateOptions {
      get_useElements(): boolean;
      set_useElements(value: boolean): void;
      get_elementsModeOptions(): ImageViewerElementsModeCreateOptions;
      set_elementsModeOptions(value: ImageViewerElementsModeCreateOptions): void;
      get_parentDiv(): HTMLElement;
      set_parentDiv(value: HTMLElement): void;
      get_parentDivClass(): string;
      set_parentDivClass(value: string): void;
      get_viewLayout(): ImageViewerViewLayout;
      set_viewLayout(value: ImageViewerViewLayout): void;
      constructor(parentDiv: HTMLElement);
      useElements: boolean;
      elementsModeOptions: ImageViewerElementsModeCreateOptions;
      parentDiv: HTMLElement;
      parentDivClass: string;
      viewLayout: ImageViewerViewLayout;
   }

   class ImageViewerElementsModeCreateOptions {
      get_autoRemoveItemElements(): boolean;
      set_autoRemoveItemElements(value: boolean): void;
      clone(prefixed: boolean): ImageViewerElementsModeCreateOptions;
      get_classPrefix(): string;
      set_classPrefix(value: string): void;
      get_viewElementClass(): string;
      set_viewElementClass(value: string): void;
      get_itemElementClass(): string;
      set_itemElementClass(value: string): void;
      get_itemImageElementClass(): string;
      set_itemImageElementClass(value: string): void;
      get_itemBackImageElementClass(): string;
      set_itemBackImageElementClass(value: string): void;
      get_itemImageBorderElementClass(): string;
      set_itemImageBorderElementClass(value: string): void;
      get_itemImageClippingElementClass(): string;
      set_itemImageClippingElementClass(value: string): void;
      get_itemImageFlipElementClass(): string;
      set_itemImageFlipElementClass(value: string): void;
      get_itemTextElementClass(): string;
      set_itemTextElementClass(value: string): void;
      get_itemHoverClass(): string;
      set_itemHoverClass(value: string): void;
      get_itemSelectClass(): string;
      set_itemSelectClass(value: string): void;
      get_itemActiveClass(): string;
      set_itemActiveClass(value: string): void;
      get_itemImageLoadingClass(): string;
      set_itemImageLoadingClass(value: string): void;
      get_itemImageLoadedClass(): string;
      set_itemImageLoadedClass(value: string): void;
      constructor();
      autoRemoveItemElements: boolean;
      classPrefix: string;
      viewElementClass: string;
      itemElementClass: string;
      itemImageElementClass: string;
      itemBackImageElementClass: string;
      itemImageBorderElementClass: string;
      itemImageClippingElementClass: string;
      itemImageFlipElementClass: string;
      itemTextElementClass: string;
      itemHoverClass: string;
      itemSelectClass: string;
      itemActiveClass: string;
      itemImageLoadingClass: string;
      itemImageLoadedClass: string;
      static defaultClassPrefix: string;
      static defaultViewElementClass: string;
      static defaultItemElementClass: string;
      static defaultItemImageElementClass: string;
      static defaultItemBackImageElementClass: string;
      static defaultItemImageClippingElementClass: string;
      static defaultItemImageFlipElementClass: string;
      static defaultItemImageBorderElementClass: string;
      static defaultItemTextElementClass: string;
      static defaultItemHoverClass: string;
      static defaultItemSelectClass: string;
      static defaultItemActiveClass: string;
      static defaultItemImageLoadingClass: string;
      static defaultItemImageLoadedClass: string;
   }

   enum ImageViewerCoordinateType {
      control = 0,
      view = 1,
      item = 2,
      content = 3,
      image = 4,
      floater = 5
   }

   enum ImageViewerItemPart {
      view = 0,
      item = 1,
      content = 2,
      image = 3,
      textArea = 4,
      text = 5,
      floater = 6
   }

   enum ImageViewerAutoResetOptions {
      none = 0,
      scroll = 1,
      zoom = 2,
      transformation = 4,
      effects = 8,
      all = 15
   }

   interface ImageViewerRenderEventHandler extends lt.LeadEventHandler {
      (sender: any, e: ImageViewerRenderEventArgs): void;
   }

   class ImageViewerRenderEventType extends lt.LeadEvent {
      add(value: ImageViewerRenderEventHandler): ImageViewerRenderEventHandler;
      remove(value: ImageViewerRenderEventHandler): void;
   }

   class ImageViewerRenderEventArgs extends lt.LeadEventArgs {
      get_item(): ImageViewerItem;
      get_part(): ImageViewerItemPart;
      get_error(): Error;
      static createForControl(control: HTMLCanvasElement): ImageViewerRenderEventArgs;
      static destroyForControl(value: ImageViewerRenderEventArgs): void;
      get_clipRectangle(): lt.LeadRectD;
      get_context(): CanvasRenderingContext2D;
      clone(): ImageViewerRenderEventArgs;
      constructor(context: CanvasRenderingContext2D, clipRectangle: lt.LeadRectD);
      item: ImageViewerItem; // read-only
      part: ImageViewerItemPart; // read-only
      error: Error; // read-only
      clipRectangle: lt.LeadRectD; // read-only
      context: CanvasRenderingContext2D; // read-only
   }

   enum ImageViewerItemChangedReason {
      size = 0,
      transform = 1,
      enabled = 2,
      selected = 3,
      hovered = 4,
      text = 5,
      url = 6,
      drop = 7,
      drag = 8,
      image = 9,
      imageChanged = 10,
      floater = 11,
      floaterTransform = 12,
      backImageUrl = 13,
      backImage = 14,
      visibility = 15
   }

   interface ImageViewerItemChangedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: ImageViewerItemChangedEventArgs): void;
   }

   class ImageViewerItemChangedEventType extends lt.LeadEvent {
      add(value: ImageViewerItemChangedEventHandler): ImageViewerItemChangedEventHandler;
      remove(value: ImageViewerItemChangedEventHandler): void;
   }

   class ImageViewerItemChangedEventArgs extends lt.LeadEventArgs {
      static create(item: ImageViewerItem, reason: ImageViewerItemChangedReason): ImageViewerItemChangedEventArgs;
      get_item(): ImageViewerItem;
      get_reason(): ImageViewerItemChangedReason;
      constructor();
      item: ImageViewerItem; // read-only
      reason: ImageViewerItemChangedReason; // read-only
   }

   interface ImageViewerItemErrorEventHandler extends lt.LeadEventHandler {
      (sender: any, e: ImageViewerItemErrorEventArgs): void;
   }

   class ImageViewerItemErrorEventType extends lt.LeadEvent {
      add(value: ImageViewerItemErrorEventHandler): ImageViewerItemErrorEventHandler;
      remove(value: ImageViewerItemErrorEventHandler): void;
   }

   class ImageViewerItemErrorEventArgs extends lt.LeadEventArgs {
      static create(item: ImageViewerItem, reason: ImageViewerItemChangedReason, data: any, error: Error): ImageViewerItemErrorEventArgs;
      get_item(): ImageViewerItem;
      get_reason(): ImageViewerItemChangedReason;
      get_data(): any;
      get_error(): Error;
      get_removeEmptyItem(): boolean;
      set_removeEmptyItem(value: boolean): void;
      constructor();
      item: ImageViewerItem; // read-only
      reason: ImageViewerItemChangedReason; // read-only
      data: any; // read-only
      error: Error; // read-only
      removeEmptyItem: boolean;
   }

   enum ImageViewerItemDragDropOperation {
      dragEnter = 0,
      dragOver = 1,
      dragLeave = 2,
      dragDrop = 3
   }

   interface ImageViewerItemDragDropEventHandler extends lt.LeadEventHandler {
      (sender: any, e: ImageViewerItemDragDropEventArgs): void;
   }

   class ImageViewerItemDragDropEventType extends lt.LeadEvent {
      add(value: ImageViewerItemDragDropEventHandler): ImageViewerItemDragDropEventHandler;
      remove(value: ImageViewerItemDragDropEventHandler): void;
   }

   class ImageViewerItemDragDropEventArgs extends lt.LeadEventArgs {
      get_sourceImageViewer(): ImageViewer;
      get_targetImageViewer(): ImageViewer;
      get_operation(): ImageViewerItemDragDropOperation;
      get_location(): lt.LeadPointD;
      get_nativeEvent(): Event;
      get_sourceItem(): ImageViewerItem;
      get_targetItem(): ImageViewerItem;
      set_targetItem(value: ImageViewerItem): void;
      get_effect(): string;
      set_effect(value: string): void;
      get_format(): string;
      get_abort(): boolean;
      set_abort(value: boolean): void;
      get_customDragElement(): HTMLElement;
      constructor();
      sourceImageViewer: ImageViewer; // read-only
      targetImageViewer: ImageViewer; // read-only
      operation: ImageViewerItemDragDropOperation; // read-only
      location: lt.LeadPointD; // read-only
      nativeEvent: Event; // read-only
      sourceItem: ImageViewerItem; // read-only
      targetItem: ImageViewerItem;
      effect: string;
      format: string; // read-only
      abort: boolean;
      customDragElement: HTMLElement; // read-only
   }

   interface ImageViewerElementsUpdatedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: ImageViewerElementsUpdatedEventArgs): void;
   }

   class ImageViewerElementsUpdatedEventType extends lt.LeadEvent {
      add(value: ImageViewerElementsUpdatedEventHandler): ImageViewerElementsUpdatedEventHandler;
      remove(value: ImageViewerElementsUpdatedEventHandler): void;
   }

   class ImageViewerElementsUpdatedEventArgs extends lt.LeadEventArgs {
      get_item(): ImageViewerItem;
      get_isTransitionsEnabled(): boolean;
      constructor();
      item: ImageViewerItem; // read-only
      isTransitionsEnabled: boolean; // read-only
   }

   class ImageViewerRenderRedirectOptions {
      get_renderBorders(): boolean;
      set_renderBorders(value: boolean): void;
      get_renderShadows(): boolean;
      set_renderShadows(value: boolean): void;
      get_renderBackgrounds(): boolean;
      set_renderBackgrounds(value: boolean): void;
      get_renderText(): boolean;
      set_renderText(value: boolean): void;
      get_renderItemStates(): boolean;
      set_renderItemStates(value: boolean): void;
      get_backgroundColor(): string;
      set_backgroundColor(value: string): void;
      get_transform(): lt.LeadMatrix;
      set_transform(value: lt.LeadMatrix): void;
      createTransform(imageViewer: ImageViewer, destinationRect: lt.LeadRectD, sourceRect: lt.LeadRectD, sizeMode: ControlSizeMode, horizontalAlignment: ControlAlignment, verticalAlignment: ControlAlignment): void;
      constructor();
      renderBorders: boolean;
      renderShadows: boolean;
      renderBackgrounds: boolean;
      renderText: boolean;
      renderItemStates: boolean;
      backgroundColor: string;
      transform: lt.LeadMatrix;
   }

   class InertiaParams {
      get_stop(): boolean;
      set_stop(value: boolean): void;
      get_options(): ControlInertiaScrollOptions;
      get_target(): any;
      get_reason(): InteractiveEventArgs;
      get_reasonTimestamp(): number;
      get_amplitude(): lt.LeadPointD;
      set_amplitude(value: lt.LeadPointD): void;
      get_velocity(): lt.LeadPointD;
      set_velocity(value: lt.LeadPointD): void;
      constructor();
      stop: boolean;
      options: ControlInertiaScrollOptions; // read-only
      target: any; // read-only
      reason: InteractiveEventArgs; // read-only
      reasonTimestamp: number; // read-only
      amplitude: lt.LeadPointD;
      velocity: lt.LeadPointD;
   }

   interface CalculateInertiaCallback {
      (inertiaParams: InertiaParams): lt.LeadPointD;
   }

   class ControlInertiaScrollOptions {
      static createDefault(): ControlInertiaScrollOptions;
      clone(): ControlInertiaScrollOptions;
      get_isEnabled(): boolean;
      set_isEnabled(value: boolean): void;
      get_defaultBezierPoint1(): lt.LeadPointD;
      set_defaultBezierPoint1(value: lt.LeadPointD): void;
      get_defaultBezierPoint2(): lt.LeadPointD;
      set_defaultBezierPoint2(value: lt.LeadPointD): void;
      get_defaultDuration(): number;
      set_defaultDuration(value: number): void;
      get_defaultPower(): number;
      set_defaultPower(value: number): void;
      get_calculateInertia(): CalculateInertiaCallback;
      set_calculateInertia(value: CalculateInertiaCallback): void;
      static get_defaultCalculateInertia(): CalculateInertiaCallback;
      constructor();
      isEnabled: boolean;
      defaultBezierPoint1: lt.LeadPointD;
      defaultBezierPoint2: lt.LeadPointD;
      defaultDuration: number;
      defaultPower: number;
      calculateInertia: CalculateInertiaCallback;
      static defaultCalculateInertia: CalculateInertiaCallback; // read-only
   }

   class ImageViewerActiveItemInteractiveMode extends ImageViewerInteractiveMode {
      get_name(): string;
      get_id(): number;
      get_isHoverEnabled(): boolean;
      set_isHoverEnabled(value: boolean): void;
      get_isKeyboardEnabled(): boolean;
      set_isKeyboardEnabled(value: boolean): void;
      start(imageViewer: ImageViewer): void;
      stop(imageViewer: ImageViewer): void;
      get_item(): ImageViewerItem;
      set_item(value: ImageViewerItem): void;
      constructor();
      name: string; // read-only
      id: number; // read-only
      isHoverEnabled: boolean;
      isKeyboardEnabled: boolean;
      item: ImageViewerItem;
   }

   class ImageViewerAutoPanInteractiveMode extends ImageViewerInteractiveMode {
      get_name(): string;
      get_id(): number;
      get_edgeSize(): lt.LeadSizeD;
      set_edgeSize(value: lt.LeadSizeD): void;
      get_moveThreshold(): number;
      set_moveThreshold(value: number): void;
      get_beginDelay(): number;
      set_beginDelay(value: number): void;
      get_panDelay(): number;
      set_panDelay(value: number): void;
      start(imageViewer: ImageViewer): void;
      stop(imageViewer: ImageViewer): void;
      constructor();
      name: string; // read-only
      id: number; // read-only
      edgeSize: lt.LeadSizeD;
      moveThreshold: number;
      beginDelay: number;
      panDelay: number;
   }

   class ImageViewerCenterAtInteractiveMode extends ImageViewerInteractiveMode {
      get_name(): string;
      get_id(): number;
      get_scaleFactor(): number;
      set_scaleFactor(value: number): void;
      start(imageViewer: ImageViewer): void;
      stop(imageViewer: ImageViewer): void;
      constructor();
      name: string; // read-only
      id: number; // read-only
      scaleFactor: number;
   }

   enum ImageViewerDragTargetMode {
      all = 0,
      same = 1,
      others = 2
   }

   class ImageViewerDragInteractiveMode extends ImageViewerInteractiveMode {
      get_format(): string;
      set_format(value: string): void;
      get_allowedEffects(): string;
      set_allowedEffects(value: string): void;
      get_targetImageViewerMode(): ImageViewerDragTargetMode;
      set_targetImageViewerMode(value: ImageViewerDragTargetMode): void;
      get_name(): string;
      get_id(): number;
      start(imageViewer: ImageViewer): void;
      stop(imageViewer: ImageViewer): void;
      canWorkOnItem(item: ImageViewerItem): boolean;  // protected
      get_mouseButtons(): MouseButtons;
      set_mouseButtons(value: MouseButtons): void;
      get_dragMode(): ImageViewerDragMode;
      set_dragMode(value: ImageViewerDragMode): void;
      get_customDragElement(): HTMLElement;
      set_customDragElement(value: HTMLElement): void;
      constructor();
      format: string;
      allowedEffects: string;
      targetImageViewerMode: ImageViewerDragTargetMode;
      name: string; // read-only
      id: number; // read-only
      mouseButtons: MouseButtons;
      dragMode: ImageViewerDragMode;
      customDragElement: HTMLElement;
   }

   enum ImageViewerDragMode {
      htmlNative = 0,
      item = 1
   }

   class ImageViewerInteractiveModes extends lt.LeadCollection {
      onCollectionChanged(e: lt.NotifyLeadCollectionChangedEventArgs): void;  // protected
      beginUpdate(): void;
      endUpdate(): void;
      enableByIndex(index: number): void;
      enable(mode: ImageViewerInteractiveMode): void;
      enableById(id: number): void;
      findById(id: number): ImageViewerInteractiveMode;
      remove(item: ImageViewerInteractiveMode): void;
      add(item: ImageViewerInteractiveMode): void;
      addRange(items: ImageViewerInteractiveMode[]): void;
      contains(item: ImageViewerInteractiveMode): boolean;
      get_item(i: number): ImageViewerInteractiveMode;
      set_item(i: number, value: ImageViewerInteractiveMode): void;
      toArray(): ImageViewerInteractiveMode[];
      insertItem(index: number, item: ImageViewerInteractiveMode): void;  // protected
      insert(index: number, item: ImageViewerInteractiveMode): void;
      insertRange(index: number, items: ImageViewerInteractiveMode[]): void;
      insertItemRange(index: number, items: ImageViewerInteractiveMode[]): void;  // protected
      setItem(index: number, item: ImageViewerInteractiveMode): void;  // protected
      indexOf(item: ImageViewerInteractiveMode): number;
      item(index: number, value?: ImageViewerInteractiveMode): ImageViewerInteractiveMode;
   }

   enum ImageViewerAutoItemMode {
      none = 0,
      never = 1,
      autoSet = 2,
      autoSetActive = 3
   }

   class ImageViewerInteractiveMode {
      get_tag(): any;
      set_tag(value: any): void;
      get_name(): string;
      get_id(): number;
      toString(): string;
      get_idleCursor(): string;
      set_idleCursor(value: string): void;
      get_workingCursor(): string;
      set_workingCursor(value: string): void;
      get_hitTestStateCursor(): string;
      set_hitTestStateCursor(value: string): void;
      get_hitTestState(): boolean;
      set_hitTestState(value: boolean): void;
      get_interactiveService(): InteractiveService;
      get_imageViewer(): ImageViewer;
      get_isStarted(): boolean;
      get_isEnabled(): boolean;
      set_isEnabled(value: boolean): void;
      start(imageViewer: ImageViewer): void;
      stop(imageViewer: ImageViewer): void;
      get_isWorking(): boolean;
      add_workStarted(value: lt.LeadEventHandler): void;
      remove_workStarted(value: lt.LeadEventHandler): void;
      onWorkStarted(e: lt.LeadEventArgs): void;  // protected
      add_workCompleted(value: lt.LeadEventHandler): void;
      remove_workCompleted(value: lt.LeadEventHandler): void;
      onWorkCompleted(e: lt.LeadEventArgs): void;  // protected
      get_isDragMouseWheelEnabled(): boolean;
      set_isDragMouseWheelEnabled(value: boolean): void;
      get_workOnBounds(): boolean;
      set_workOnBounds(value: boolean): void;
      get_item(): ImageViewerItem;
      set_item(value: ImageViewerItem): void;
      get_itemPart(): ImageViewerItemPart;
      set_itemPart(value: ImageViewerItemPart): void;
      get_autoItemMode(): ImageViewerAutoItemMode;
      set_autoItemMode(value: ImageViewerAutoItemMode): void;
      getWorkBounds(imageViewer: ImageViewer, clipped: boolean): lt.LeadRectD;  // protected
      updateAutoItem(imageViewer: ImageViewer, position: lt.LeadPointD): void;  // protected
      getItemWorkBounds(imageViewer: ImageViewer, item: ImageViewerItem): lt.LeadRectD;  // protected
      canStartWork(e: InteractiveEventArgs): boolean;  // protected
      canWorkOnItem(item: ImageViewerItem): boolean;  // protected
      get_autoDisableTransitions(): boolean;
      set_autoDisableTransitions(value: boolean): void;
      get_mouseButtons(): MouseButtons;
      set_mouseButtons(value: MouseButtons): void;
      constructor();
      tag: any;
      name: string; // read-only
      id: number; // read-only
      idleCursor: string;
      workingCursor: string;
      hitTestStateCursor: string;
      hitTestState: boolean;
      interactiveService: InteractiveService; // read-only
      imageViewer: ImageViewer; // read-only
      isStarted: boolean; // read-only
      isEnabled: boolean;
      isWorking: boolean; // read-only
      isDragMouseWheelEnabled: boolean;
      workOnBounds: boolean;
      item: ImageViewerItem;
      itemPart: ImageViewerItemPart;
      autoItemMode: ImageViewerAutoItemMode;
      autoDisableTransitions: boolean;
      mouseButtons: MouseButtons;
      workStarted: lt.LeadEventType; // read-only
      workCompleted: lt.LeadEventType; // read-only
      static noneModeId: number;
      static panZoomModeId: number;
      static centerAtModeId: number;
      static zoomAtModeId: number;
      static zoomToModeId: number;
      static autoPanModeId: number;
      static rubberBandModeId: number;
      static spyGlassModeId: number;
      static magnifyGlassModeId: number;
      static activeItemModeId: number;
      static addRegionModeId: number;
      static dragModeId: number;
      static pagerModeId: number;
      static selectItemsModeId: number;
      static floaterModeId: number;
      static userModeId: number;
   }

   class ImageViewerMagnifyGlassInteractiveMode extends ImageViewerSpyGlassInteractiveMode {
      get_scaleFactor(): number;
      set_scaleFactor(value: number): void;
      get_renderRedirectOptions(): ImageViewerRenderRedirectOptions;
      set_renderRedirectOptions(value: ImageViewerRenderRedirectOptions): void;
      get_name(): string;
      get_id(): number;
      onWorkStarted(e: lt.LeadEventArgs): void;  // protected
      onWorkCompleted(e: lt.LeadEventArgs): void;  // protected
      get_alwaysFillBackground(): boolean;  // protected
      onDrawImage(e: ImageViewerSpyGlassDrawImageEventArgs): void;  // protected
      constructor();
      scaleFactor: number;
      renderRedirectOptions: ImageViewerRenderRedirectOptions;
      name: string; // read-only
      id: number; // read-only
      alwaysFillBackground: boolean; // read-only
   }

   class ImageViewerNoneInteractiveMode extends ImageViewerInteractiveMode {
      get_name(): string;
      get_id(): number;
      start(imageViewer: ImageViewer): void;
      stop(imageViewer: ImageViewer): void;
      constructor();
      name: string; // read-only
      id: number; // read-only
   }

   class ImageViewerPagerInteractiveMode extends ImageViewerInteractiveMode {
      get_name(): string;
      get_id(): number;
      start(imageViewer: ImageViewer): void;
      stop(imageViewer: ImageViewer): void;
      constructor();
      name: string; // read-only
      id: number; // read-only
   }

   class ImageViewerPanControl {
      get_interactiveService(): InteractiveService;
      get_imageViewer(): ImageViewer;
      set_imageViewer(value: ImageViewer): void;
      get_control(): HTMLElement;
      set_control(value: HTMLElement): void;
      get_workingCursor(): string;
      set_workingCursor(value: string): void;
      get_enablePan(): boolean;
      set_enablePan(value: boolean): void;
      get_canvas(): HTMLCanvasElement;
      set_canvas(value: HTMLCanvasElement): void;
      get_borderColor(): string;
      set_borderColor(value: string): void;
      get_borderThickness(): number;
      set_borderThickness(value: number): void;
      get_insideColor(): string;
      set_insideColor(value: string): void;
      get_outsideColor(): string;
      set_outsideColor(value: string): void;
      get_mouseButton(): MouseButtons;
      set_mouseButton(value: MouseButtons): void;
      dispose(): void;
      constructor();
      interactiveService: InteractiveService; // read-only
      imageViewer: ImageViewer;
      control: HTMLElement;
      workingCursor: string;
      enablePan: boolean;
      canvas: HTMLCanvasElement;
      borderColor: string;
      borderThickness: number;
      insideColor: string;
      outsideColor: string;
      mouseButton: MouseButtons;
   }

   class ImageViewerPanZoomInteractiveMode extends ImageViewerInteractiveMode {
      get_enablePan(): boolean;
      set_enablePan(value: boolean): void;
      get_enableZoom(): boolean;
      set_enableZoom(value: boolean): void;
      get_enablePinchZoom(): boolean;
      set_enablePinchZoom(value: boolean): void;
      get_transformTarget(): ImageViewerInteractiveModeTransformTarget;
      set_transformTarget(value: ImageViewerInteractiveModeTransformTarget): void;
      get_zoomAtWorkBoundsCenter(): boolean;
      set_zoomAtWorkBoundsCenter(value: boolean): void;
      get_minimumScaleFactor(): number;
      set_minimumScaleFactor(value: number): void;
      get_doubleTapSizeMode(): ControlSizeMode;
      set_doubleTapSizeMode(value: ControlSizeMode): void;
      get_name(): string;
      get_id(): number;
      start(imageViewer: ImageViewer): void;
      stop(imageViewer: ImageViewer): void;
      pan(imageViewer: ImageViewer, e: InteractiveDragDeltaEventArgs): void;  // protected
      zoom(imageViewer: ImageViewer, e: InteractiveDragDeltaEventArgs): void;  // protected
      doubleTapZoom(imageViewer: ImageViewer, e: InteractiveEventArgs): void;  // protected
      get_inertiaScrollOptions(): ControlInertiaScrollOptions;
      set_inertiaScrollOptions(value: ControlInertiaScrollOptions): void;
      get_zoomKeyModifier(): Keys;
      set_zoomKeyModifier(value: Keys): void;
      get_pageKeyModifier(): Keys;
      set_pageKeyModifier(value: Keys): void;
      get_isKeyboardEnabled(): boolean;
      set_isKeyboardEnabled(value: boolean): void;
      constructor();
      enablePan: boolean;
      enableZoom: boolean;
      enablePinchZoom: boolean;
      transformTarget: ImageViewerInteractiveModeTransformTarget;
      zoomAtWorkBoundsCenter: boolean;
      minimumScaleFactor: number;
      doubleTapSizeMode: ControlSizeMode;
      name: string; // read-only
      id: number; // read-only
      inertiaScrollOptions: ControlInertiaScrollOptions;
      zoomKeyModifier: Keys;
      pageKeyModifier: Keys;
      isKeyboardEnabled: boolean;
   }

   interface ImageViewerRubberBandEventHandler extends lt.LeadEventHandler {
      (sender: any, e: ImageViewerRubberBandEventArgs): void;
   }

   class ImageViewerRubberBandEventType extends lt.LeadEvent {
      add(value: ImageViewerRubberBandEventHandler): ImageViewerRubberBandEventHandler;
      remove(value: ImageViewerRubberBandEventHandler): void;
   }

   class ImageViewerRubberBandEventArgs extends lt.LeadEventArgs {
      get_interactiveEventArgs(): InteractiveEventArgs;
      get_isCanceled(): boolean;
      set_isCanceled(value: boolean): void;
      get_points(): lt.LeadPointD[];
      constructor(args: InteractiveEventArgs);
      interactiveEventArgs: InteractiveEventArgs; // read-only
      isCanceled: boolean;
      points: lt.LeadPointD[]; // read-only
   }

   enum ImageViewerRubberBandShape {
      rectangle = 0,
      roundRectangle = 1,
      ellipse = 2,
      freehand = 3
   }

   class ImageViewerRubberBandInteractiveMode extends ImageViewerInteractiveMode {
      get_shape(): ImageViewerRubberBandShape;
      set_shape(value: ImageViewerRubberBandShape): void;
      get_roundRectangleRadius(): lt.LeadSizeD;
      set_roundRectangleRadius(value: lt.LeadSizeD): void;
      add_rubberBandStarted(value: ImageViewerRubberBandEventHandler): void;
      remove_rubberBandStarted(value: ImageViewerRubberBandEventHandler): void;
      onRubberBandStarted(e: ImageViewerRubberBandEventArgs): void;  // protected
      add_rubberBandDelta(value: ImageViewerRubberBandEventHandler): void;
      remove_rubberBandDelta(value: ImageViewerRubberBandEventHandler): void;
      onRubberBandDelta(e: ImageViewerRubberBandEventArgs): void;  // protected
      add_rubberBandCompleted(value: ImageViewerRubberBandEventHandler): void;
      remove_rubberBandCompleted(value: ImageViewerRubberBandEventHandler): void;
      onRubberBandCompleted(e: ImageViewerRubberBandEventArgs): void;  // protected
      get_restrictToWorkBounds(): boolean;
      set_restrictToWorkBounds(value: boolean): void;
      get_name(): string;
      get_id(): number;
      start(imageViewer: ImageViewer): void;
      stop(imageViewer: ImageViewer): void;
      get_borderColor(): string;
      set_borderColor(value: string): void;
      get_borderStyle(): string;
      set_borderStyle(value: string): void;
      get_borderThickness(): number;
      set_borderThickness(value: number): void;
      get_backgroundStyle(): string;
      set_backgroundStyle(value: string): void;
      get_interactiveModeCanvas(): HTMLCanvasElement;  // protected
      set_interactiveModeCanvas(value: HTMLCanvasElement): void;  // protected
      createInteractiveModeCanvas(viewer: ImageViewer): void;  // protected
      destroyInteractiveModeCanvas(): void;  // protected
      constructor();
      shape: ImageViewerRubberBandShape;
      roundRectangleRadius: lt.LeadSizeD;
      restrictToWorkBounds: boolean;
      name: string; // read-only
      id: number; // read-only
      borderColor: string;
      borderStyle: string;
      borderThickness: number;
      backgroundStyle: string;
      interactiveModeCanvas: HTMLCanvasElement;
      rubberBandStarted: ImageViewerRubberBandEventType; // read-only
      rubberBandDelta: ImageViewerRubberBandEventType; // read-only
      rubberBandCompleted: ImageViewerRubberBandEventType; // read-only
   }

   enum ImageViewerSelectionMode {
      none = 0,
      single = 1,
      multi = 2
   }

   class ImageViewerSelectItemsInteractiveMode extends ImageViewerRubberBandInteractiveMode {
      get_name(): string;
      get_id(): number;
      get_canSelectDisabledItems(): boolean;
      set_canSelectDisabledItems(value: boolean): void;
      get_canHoverDisabledItems(): boolean;
      set_canHoverDisabledItems(value: boolean): void;
      get_selectionMode(): ImageViewerSelectionMode;
      set_selectionMode(value: ImageViewerSelectionMode): void;
      get_isKeyboardEnabled(): boolean;
      set_isKeyboardEnabled(value: boolean): void;
      start(imageViewer: ImageViewer): void;
      stop(imageViewer: ImageViewer): void;
      get_item(): ImageViewerItem;
      set_item(value: ImageViewerItem): void;
      get_shape(): ImageViewerRubberBandShape;
      set_shape(value: ImageViewerRubberBandShape): void;
      get_multiSelectKeyModifier(): Keys;
      set_multiSelectKeyModifier(value: Keys): void;
      onRubberBandStarted(e: ImageViewerRubberBandEventArgs): void;  // protected
      onRubberBandDelta(e: ImageViewerRubberBandEventArgs): void;  // protected
      constructor();
      name: string; // read-only
      id: number; // read-only
      canSelectDisabledItems: boolean;
      canHoverDisabledItems: boolean;
      selectionMode: ImageViewerSelectionMode;
      isKeyboardEnabled: boolean;
      item: ImageViewerItem;
      shape: ImageViewerRubberBandShape;
      multiSelectKeyModifier: Keys;
   }

   enum ImageViewerSpyGlassShape {
      none = 0,
      rectangle = 1,
      roundRectangle = 2,
      ellipse = 3
   }

   enum ImageViewerSpyGlassCrosshair {
      none = 0,
      fine = 1
   }

   interface ImageViewerSpyGlassDrawImageEventHandler extends lt.LeadEventHandler {
      (sender: any, e: ImageViewerSpyGlassDrawImageEventArgs): void;
   }

   class ImageViewerSpyGlassDrawImageEventType extends lt.LeadEvent {
      add(value: ImageViewerSpyGlassDrawImageEventHandler): ImageViewerSpyGlassDrawImageEventHandler;
      remove(value: ImageViewerSpyGlassDrawImageEventHandler): void;
   }

   class ImageViewerSpyGlassDrawImageEventArgs extends lt.LeadEventArgs {
      get_destinationRectangle(): lt.LeadRectD;
      set_destinationRectangle(value: lt.LeadRectD): void;
      get_offset(): lt.LeadPointD;
      set_offset(value: lt.LeadPointD): void;
      get_context(): CanvasRenderingContext2D;
      set_context(value: CanvasRenderingContext2D): void;
      constructor();
      destinationRectangle: lt.LeadRectD;
      offset: lt.LeadPointD;
      context: CanvasRenderingContext2D;
   }

   class ImageViewerSpyGlassInteractiveMode extends ImageViewerInteractiveMode {
      add_drawImage(value: ImageViewerSpyGlassDrawImageEventHandler): void;
      remove_drawImage(value: ImageViewerSpyGlassDrawImageEventHandler): void;
      onDrawImage(e: ImageViewerSpyGlassDrawImageEventArgs): void;  // protected
      get_size(): lt.LeadSizeD;
      set_size(value: lt.LeadSizeD): void;
      get_shape(): ImageViewerSpyGlassShape;
      set_shape(value: ImageViewerSpyGlassShape): void;
      get_roundRectangleRadius(): lt.LeadSizeD;
      set_roundRectangleRadius(value: lt.LeadSizeD): void;
      get_crosshair(): ImageViewerSpyGlassCrosshair;
      set_crosshair(value: ImageViewerSpyGlassCrosshair): void;
      get_offset(): lt.LeadPointD;
      set_offset(value: lt.LeadPointD): void;
      get_ensureVisible(): boolean;
      set_ensureVisible(value: boolean): void;
      get_name(): string;
      get_id(): number;
      set_currentPosition(value: lt.LeadPointD): void;  // protected
      get_currentPosition(): lt.LeadPointD;  // protected
      start(imageViewer: ImageViewer): void;
      stop(imageViewer: ImageViewer): void;
      add_workDelta(value: InteractiveDragDeltaEventHandler): void;
      remove_workDelta(value: InteractiveDragDeltaEventHandler): void;
      get_isVisible(): boolean;
      manualStart(position: lt.LeadPointD): void;
      manualStop(): void;
      manualMove(position: lt.LeadPointD): void;
      get_backgroundColor(): string;
      set_backgroundColor(value: string): void;
      get_alwaysFillBackground(): boolean;  // protected
      get_borderColor(): string;
      set_borderColor(value: string): void;
      get_borderThickness(): number;
      set_borderThickness(value: number): void;
      get_crosshairColor(): string;
      set_crosshairColor(value: string): void;
      get_crosshairThickness(): number;
      set_crosshairThickness(value: number): void;
      get_redirectCanvas(): HTMLCanvasElement;
      set_redirectCanvas(value: HTMLCanvasElement): void;
      restart(): void;
      get_interactiveModeCanvas(): HTMLCanvasElement;  // protected
      set_interactiveModeCanvas(value: HTMLCanvasElement): void;  // protected
      createInteractiveModeCanvas(viewer: ImageViewer): void;  // protected
      destroyInteractiveModeCanvas(): void;  // protected
      invalidate(): void;
      constructor();
      size: lt.LeadSizeD;
      shape: ImageViewerSpyGlassShape;
      roundRectangleRadius: lt.LeadSizeD;
      crosshair: ImageViewerSpyGlassCrosshair;
      offset: lt.LeadPointD;
      ensureVisible: boolean;
      name: string; // read-only
      id: number; // read-only
      currentPosition: lt.LeadPointD;
      isVisible: boolean; // read-only
      backgroundColor: string;
      alwaysFillBackground: boolean; // read-only
      borderColor: string;
      borderThickness: number;
      crosshairColor: string;
      crosshairThickness: number;
      redirectCanvas: HTMLCanvasElement;
      interactiveModeCanvas: HTMLCanvasElement;
      drawImage: ImageViewerSpyGlassDrawImageEventType; // read-only
      workDelta: InteractiveDragDeltaEventType; // read-only
   }

   class ImageViewerZoomAtInteractiveMode extends ImageViewerInteractiveMode {
      get_name(): string;
      get_id(): number;
      get_scaleFactor(): number;
      set_scaleFactor(value: number): void;
      start(imageViewer: ImageViewer): void;
      stop(imageViewer: ImageViewer): void;
      get_transformTarget(): ImageViewerInteractiveModeTransformTarget;
      set_transformTarget(value: ImageViewerInteractiveModeTransformTarget): void;
      constructor();
      name: string; // read-only
      id: number; // read-only
      scaleFactor: number;
      transformTarget: ImageViewerInteractiveModeTransformTarget;
   }

   enum ImageViewerInteractiveModeTransformTarget {
      imageViewer = 0,
      allItems = 1,
      item = 2
   }

   class ImageViewerZoomToInteractiveMode extends ImageViewerRubberBandInteractiveMode {
      get_name(): string;
      get_id(): number;
      get_transformTarget(): ImageViewerInteractiveModeTransformTarget;
      set_transformTarget(value: ImageViewerInteractiveModeTransformTarget): void;
      get_shape(): ImageViewerRubberBandShape;
      set_shape(value: ImageViewerRubberBandShape): void;
      onRubberBandCompleted(e: ImageViewerRubberBandEventArgs): void;  // protected
      constructor();
      name: string; // read-only
      id: number; // read-only
      transformTarget: ImageViewerInteractiveModeTransformTarget;
      shape: ImageViewerRubberBandShape;
   }

   class ImageViewerItem {
      static createFromImage(image: HTMLImageElement, resolution: lt.LeadSizeD): ImageViewerItem;
      static createFromCanvas(canvas: HTMLCanvasElement, resolution: lt.LeadSizeD): ImageViewerItem;
      static createFromElement(element: HTMLElement, resolution: lt.LeadSizeD): ImageViewerItem;
      get_flipImageElement(): boolean;
      set_flipImageElement(value: boolean): void;
      get_reverseImageElement(): boolean;
      set_reverseImageElement(value: boolean): void;
      get_image(): HTMLImageElement;
      set_image(value: HTMLImageElement): void;
      get_element(): HTMLElement;
      set_element(value: HTMLElement): void;
      get_canvas(): HTMLCanvasElement;
      set_canvas(value: HTMLCanvasElement): void;
      get_backImage(): HTMLElement;
      set_backImage(value: HTMLElement): void;
      get_canvasScale(): number;
      get_floater(): HTMLCanvasElement;
      set_floater(value: HTMLCanvasElement): void;
      get_hasImage(): boolean;
      deleteImage(): void;
      get_backImageUrl(): string;
      set_backImageUrl(value: string): void;
      get_imageSize(): lt.LeadSizeD;
      set_imageSize(value: lt.LeadSizeD): void;
      get_loadUrlMode(): lt.ImageLoaderUrlMode;
      set_loadUrlMode(value: lt.ImageLoaderUrlMode): void;
      get_backImageLoadUrlMode(): lt.ImageLoaderUrlMode;
      set_backImageLoadUrlMode(value: lt.ImageLoaderUrlMode): void;
      get_hasFloater(): boolean;
      deleteFloater(): void;  // protected
      get_floaterSize(): lt.LeadSizeD;
      combineFloater(targetItem: ImageViewerItem, deleteFloater: boolean): boolean;
      imageRegionToFloater(): boolean;
      get_imageViewer(): ImageViewer;
      beginChange(reason: ImageViewerItemChangedReason): void;  // protected
      endChange(reason: ImageViewerItemChangedReason): void;  // protected
      get_rowIndex(): number;
      set_rowIndex(value: number): void;
      get_columnIndex(): number;
      set_columnIndex(value: number): void;
      get_size(): lt.LeadSizeD;
      set_size(value: lt.LeadSizeD): void;
      get_resolution(): lt.LeadSizeD;
      set_resolution(value: lt.LeadSizeD): void;
      get_isVisible(): boolean;
      set_isVisible(value: boolean): void;
      get_isEnabled(): boolean;
      set_isEnabled(value: boolean): void;
      get_isSelected(): boolean;
      set_isSelected(value: boolean): void;
      get_isHovered(): boolean;
      set_isHovered(value: boolean): void;
      get_text(): string;
      set_text(value: string): void;
      get_tag(): any;
      set_tag(value: any): void;
      get_url(): string;
      set_url(value: string): void;
      get_transform(): lt.LeadMatrix;
      set_transform(value: lt.LeadMatrix): void;
      get_sizeMode(): ControlSizeMode;
      zoom(sizeMode: ControlSizeMode, value: number, origin: lt.LeadPointD): void;
      get_origin(): lt.LeadPointD;
      get_defaultZoomOrigin(): lt.LeadPointD;
      get_flip(): boolean;
      set_flip(value: boolean): void;
      get_reverse(): boolean;
      set_reverse(value: boolean): void;
      get_rotateAngle(): number;
      set_rotateAngle(value: number): void;
      get_scale(): lt.LeadSizeD;
      set_scale(value: lt.LeadSizeD): void;
      get_scaleFactors(): lt.LeadSizeD;
      get_scaleFactor(): number;
      get_offset(): lt.LeadPointD;
      set_offset(value: lt.LeadPointD): void;
      offsetBy(value: lt.LeadPointD): void;
      get_resizeOnTransform(): boolean;
      set_resizeOnTransform(value: boolean): void;
      get_clipImageToContent(): boolean;
      set_clipImageToContent(value: boolean): void;
      get_imageHorizontalAlignment(): ControlAlignment;
      set_imageHorizontalAlignment(value: ControlAlignment): void;
      get_imageVerticalAlignment(): ControlAlignment;
      set_imageVerticalAlignment(value: ControlAlignment): void;
      get_textHorizontalAlignment(): ControlAlignment;
      set_textHorizontalAlignment(value: ControlAlignment): void;
      get_textVerticalAlignment(): ControlAlignment;
      set_textVerticalAlignment(value: ControlAlignment): void;
      get_floaterTransform(): lt.LeadMatrix;
      set_floaterTransform(value: lt.LeadMatrix): void;
      get_floaterOpacity(): number;
      set_floaterOpacity(value: number): void;
      get_hasVisibleFloater(): boolean;
      get_imageScale(): number;
      set_imageScale(value: number): void;
      get_leadIndex(): number;
      set_leadIndex(value: number): void;
      get_autoCreateCanvas(): boolean;
      set_autoCreateCanvas(value: boolean): void;
      get_resizeElementForView(): boolean;
      set_resizeElementForView(value: boolean): void;
      get_itemElement(): HTMLElement;
      get_imageElement(): HTMLElement;
      get_backImageElement(): HTMLElement;
      get_textElement(): HTMLElement;
      get_imageBorderElement(): HTMLElement;
      get_imageClippingElement(): HTMLElement;
      get_imageFlipElement(): HTMLElement;
      constructor();
      imageViewer: ImageViewer; // read-only
      rowIndex: number;
      columnIndex: number;
      size: lt.LeadSizeD;
      resolution: lt.LeadSizeD;
      isVisible: boolean;
      isEnabled: boolean;
      isSelected: boolean;
      isHovered: boolean;
      text: string;
      tag: any;
      url: string;
      transform: lt.LeadMatrix;
      sizeMode: ControlSizeMode; // read-only
      origin: lt.LeadPointD; // read-only
      defaultZoomOrigin: lt.LeadPointD; // read-only
      flip: boolean;
      reverse: boolean;
      rotateAngle: number;
      scale: lt.LeadSizeD;
      scaleFactors: lt.LeadSizeD; // read-only
      scaleFactor: number; // read-only
      offset: lt.LeadPointD;
      resizeOnTransform: boolean;
      clipImageToContent: boolean;
      imageHorizontalAlignment: ControlAlignment;
      imageVerticalAlignment: ControlAlignment;
      textHorizontalAlignment: ControlAlignment;
      textVerticalAlignment: ControlAlignment;
      floaterTransform: lt.LeadMatrix;
      floaterOpacity: number;
      hasVisibleFloater: boolean; // read-only
      imageScale: number;
      leadIndex: number;
      autoCreateCanvas: boolean;
      resizeElementForView: boolean;
      itemElement: HTMLElement; // read-only
      imageElement: HTMLElement; // read-only
      backImageElement: HTMLElement; // read-only
      textElement: HTMLElement; // read-only
      imageBorderElement: HTMLElement; // read-only
      imageClippingElement: HTMLElement; // read-only
      imageFlipElement: HTMLElement; // read-only
      flipImageElement: boolean;
      reverseImageElement: boolean;
      image: HTMLImageElement;
      element: HTMLElement;
      canvas: HTMLCanvasElement;
      backImage: HTMLElement;
      canvasScale: number; // read-only
      floater: HTMLCanvasElement;
      hasImage: boolean; // read-only
      backImageUrl: string;
      imageSize: lt.LeadSizeD;
      loadUrlMode: lt.ImageLoaderUrlMode;
      backImageLoadUrlMode: lt.ImageLoaderUrlMode;
      hasFloater: boolean; // read-only
      floaterSize: lt.LeadSizeD; // read-only
   }

   class ElementInsertionHelper {
      static removePointerEventsFromRoot(rootElement: HTMLElement): void;
      static forcePointerEventsFromRoot(rootElement: HTMLElement): void;
      static clearPointerEventChangesFromRoot(rootElement: HTMLElement): void;
      static removePointerEvents(elements: any[]): void;
      static forcePointerEvents(elements: any[]): void;
      static clearPointerEventChanges(elements: any[]): void;
   }

   class ImageViewerItems extends lt.LeadCollection {
      get_imageViewer(): ImageViewer;
      insertItem(index: number, item: ImageViewerItem): void;  // protected
      insertItemRange(index: number, items: ImageViewerItem[]): void;  // protected
      removeItem(index: number): void;  // protected
      removeItemRange(index: number, count: number): void;  // protected
      clearItems(): void;  // protected
      setItem(index: number, item: ImageViewerItem): void;  // protected
      moveItem(oldIndex: number, newIndex: number): void;  // protected
      indexOf(item: ImageViewerItem): number;
      getSelected(): ImageViewerItem[];
      select(selectedItems: ImageViewerItem[]): void;
      onCollectionChanged(e: lt.NotifyLeadCollectionChangedEventArgs): void;  // protected
      remove(item: ImageViewerItem): void;
      add(item: ImageViewerItem): void;
      addRange(items: ImageViewerItem[]): void;
      contains(item: ImageViewerItem): boolean;
      get_item(index: number): ImageViewerItem;
      set_item(index: number, value: ImageViewerItem): void;
      toArray(): ImageViewerItem[];
      insert(index: number, item: ImageViewerItem): void;
      insertRange(index: number, items: ImageViewerItem[]): void;
      addFromImage(image: HTMLImageElement, resolution: lt.LeadSizeD): ImageViewerItem;
      insertFromImage(index: number, image: HTMLImageElement, resolution: lt.LeadSizeD): ImageViewerItem;
      addFromElement(element: HTMLElement, resolution: lt.LeadSizeD): ImageViewerItem;
      insertFromElement(index: number, element: HTMLElement, resolution: lt.LeadSizeD): ImageViewerItem;
      addFromCanvas(canvas: HTMLCanvasElement, resolution: lt.LeadSizeD): ImageViewerItem;
      insertFromCanvas(index: number, canvas: HTMLCanvasElement, resolution: lt.LeadSizeD): ImageViewerItem;
      addFromUrl(url: string, resolution: lt.LeadSizeD): ImageViewerItem;
      insertFromUrl(index: number, url: string, resolution: lt.LeadSizeD): ImageViewerItem;
      addFromSvgUrl(url: string, resolution: lt.LeadSizeD): ImageViewerItem;
      insertFromSvgUrl(index: number, url: string, resolution: lt.LeadSizeD): ImageViewerItem;
      updateImage(item: ImageViewerItem, image: HTMLImageElement, resolution: lt.LeadSizeD): void;
      updateElement(item: ImageViewerItem, element: HTMLElement, resolution: lt.LeadSizeD): void;
      updateCanvas(item: ImageViewerItem, canvas: HTMLCanvasElement, resolution: lt.LeadSizeD): void;
      updateUrl(item: ImageViewerItem, url: string, resolution: lt.LeadSizeD): void;
      imageViewer: ImageViewer; // read-only
      item(index: number, value?: ImageViewerItem): ImageViewerItem;
   }

   class ImageViewerHorizontalViewLayout extends ImageViewerViewLayout {
      get_name(): string;
      get_rows(): number;
      set_rows(value: number): void;
      updateTransform(imageViewer: ImageViewer, xScaleFactor: number, yScaleFactor: number, sizeMode: ControlSizeMode, viewRect: lt.LeadRectD, itemBounds: lt.LeadRectD[]): void;  // protected
      constructor();
      name: string; // read-only
      rows: number;
   }

   class ImageViewerSingleViewLayout extends ImageViewerViewLayout {
      get_name(): string;
      updateTransform(imageViewer: ImageViewer, xScaleFactor: number, yScaleFactor: number, sizeMode: ControlSizeMode, viewRect: lt.LeadRectD, itemBounds: lt.LeadRectD[]): void;  // protected
      constructor();
      name: string; // read-only
   }

   class ImageViewerVerticalViewLayout extends ImageViewerViewLayout {
      get_name(): string;
      get_columns(): number;
      set_columns(value: number): void;
      updateTransform(imageViewer: ImageViewer, xScaleFactor: number, yScaleFactor: number, sizeMode: ControlSizeMode, viewRect: lt.LeadRectD, itemBounds: lt.LeadRectD[]): void;  // protected
      constructor();
      name: string; // read-only
      columns: number;
   }

   class ImageViewerViewLayoutVector {
      get_firstItemIndex(): number;
      set_firstItemIndex(value: number): void;
      get_lastItemIndex(): number;
      set_lastItemIndex(value: number): void;
      constructor();
      firstItemIndex: number;
      lastItemIndex: number;
   }

   class ImageViewerViewLayout {
      get_name(): string;
      toString(): string;
      get_sizeModeWidth(): number;
      set_sizeModeWidth(value: number): void;
      get_sizeModeWidthItemCount(): number;
      set_sizeModeWidthItemCount(value: number): void;
      get_sizeModeHeight(): number;
      set_sizeModeHeight(value: number): void;
      get_sizeModeHeightItemCount(): number;
      set_sizeModeHeightItemCount(value: number): void;
      get_vectors(): ImageViewerViewLayoutVector[];
      updateTransform(imageViewer: ImageViewer, xScaleFactor: number, yScaleFactor: number, sizeMode: ControlSizeMode, viewRect: lt.LeadRectD, itemBounds: lt.LeadRectD[]): void;  // protected
      alignHeights(firstItemIndex: number, lastItemIndex: number, itemBounds: lt.LeadRectD[], alignment: ControlAlignment): lt.LeadRectD;  // protected
      alignWidths(firstItemIndex: number, lastItemIndex: number, itemBounds: lt.LeadRectD[], alignment: ControlAlignment): lt.LeadRectD;  // protected
      alignRow(firstItemIndex: number, lastItemIndex: number, itemBounds: lt.LeadRectD[], rowWidth: number, totalWidth: number, alignment: ControlAlignment): void;  // protected
      alignColumn(firstItemIndex: number, lastItemIndex: number, itemBounds: lt.LeadRectD[], columnHeight: number, totalHeight: number, alignment: ControlAlignment): void;  // protected
      constructor();
      name: string; // read-only
      sizeModeWidth: number;
      sizeModeWidthItemCount: number;
      sizeModeHeight: number;
      sizeModeHeightItemCount: number;
      vectors: ImageViewerViewLayoutVector[]; // read-only
   }

   class InteractiveService {
      get_preventContextMenu(): boolean;
      set_preventContextMenu(value: boolean): void;
      add_contextMenu(value: InteractiveEventHandler): void;
      remove_contextMenu(value: InteractiveEventHandler): void;
      onContextMenu(e: InteractiveEventArgs): void;  // protected
      get_enableSelection(): boolean;
      set_enableSelection(value: boolean): void;
      onSizeChanged(): void;
      static checkKeyModifier(e: Event, key: Keys): boolean;
      get_supportsMouse(): boolean;
      static create(owner: any, eventsSource: HTMLElement, eventsTarget: HTMLElement): InteractiveService;
      createControl(owner: any, eventsSource: HTMLElement, eventsTarget: HTMLElement): void;  // protected
      get_owner(): any;
      get_eventsSource(): HTMLElement;
      get_eventsTarget(): HTMLElement;
      set_eventsTarget(value: HTMLElement): void;
      get_hitTestBuffer(): number;
      set_hitTestBuffer(value: number): void;
      get_targetOffset(): lt.LeadPointD;
      get_isListening(): boolean;
      startListening(): void;
      stopListening(): void;
      get_tapOnDown(): boolean;
      set_tapOnDown(value: boolean): void;
      get_enableHold(): boolean;
      set_enableHold(value: boolean): void;
      get_holdDelay(): number;
      set_holdDelay(value: number): void;
      get_dragStartsOnDown(): boolean;
      set_dragStartsOnDown(value: boolean): void;
      get_pinchStartsOnDown(): boolean;
      set_pinchStartsOnDown(value: boolean): void;
      get_enableMouseWheel(): boolean;
      set_enableMouseWheel(value: boolean): void;
      get_mouseWheelDeltaMultiplier(): number;
      set_mouseWheelDeltaMultiplier(value: number): void;
      get_doubleTapDelay(): number;
      set_doubleTapDelay(value: number): void;
      get_cancelOnEscape(): boolean;
      set_cancelOnEscape(value: boolean): void;
      add_move(value: InteractiveEventHandler): void;
      remove_move(value: InteractiveEventHandler): void;
      onMove(e: InteractiveEventArgs): void;  // protected
      add_tap(value: InteractiveEventHandler): void;
      remove_tap(value: InteractiveEventHandler): void;
      onTap(e: InteractiveEventArgs): void;  // protected
      add_hold(value: InteractiveEventHandler): void;
      remove_hold(value: InteractiveEventHandler): void;
      onHold(e: InteractiveEventArgs): void;  // protected
      add_doubleTap(value: InteractiveEventHandler): void;
      remove_doubleTap(value: InteractiveEventHandler): void;
      onDoubleTap(e: InteractiveEventArgs): void;  // protected
      add_dragStarted(value: InteractiveDragStartedEventHandler): void;
      remove_dragStarted(value: InteractiveDragStartedEventHandler): void;
      onDragStarted(e: InteractiveDragStartedEventArgs): void;  // protected
      add_dragDelta(value: InteractiveDragDeltaEventHandler): void;
      remove_dragDelta(value: InteractiveDragDeltaEventHandler): void;
      onDragDelta(e: InteractiveDragDeltaEventArgs): void;  // protected
      add_dragCompleted(value: InteractiveDragCompletedEventHandler): void;
      remove_dragCompleted(value: InteractiveDragCompletedEventHandler): void;
      onDragCompleted(e: InteractiveDragCompletedEventArgs): void;  // protected
      add_keyDown(value: InteractiveKeyEventHandler): void;
      remove_keyDown(value: InteractiveKeyEventHandler): void;
      onKeyDown(e: InteractiveKeyEventArgs): void;  // protected
      add_keyUp(value: InteractiveKeyEventHandler): void;
      remove_keyUp(value: InteractiveKeyEventHandler): void;
      onKeyUp(e: InteractiveKeyEventArgs): void;  // protected
      add_pinchStarted(value: InteractivePinchStartedEventHandler): void;
      remove_pinchStarted(value: InteractivePinchStartedEventHandler): void;
      onPinchStarted(e: InteractivePinchStartedEventArgs): void;  // protected
      add_pinchDelta(value: InteractivePinchDeltaEventHandler): void;
      remove_pinchDelta(value: InteractivePinchDeltaEventHandler): void;
      onPinchDelta(e: InteractivePinchDeltaEventArgs): void;  // protected
      add_pinchCompleted(value: InteractivePinchCompletedEventHandler): void;
      remove_pinchCompleted(value: InteractivePinchCompletedEventHandler): void;
      onPinchCompleted(e: InteractivePinchCompletedEventArgs): void;  // protected
      static registerGlobalModifierKeys(): void;
      static deregisterGlobalModifierKeys(): void;
      static get_modifierKeys(): Keys;
      get_userControls(): HTMLElement[];
      dispose(): void;
      constructor();
      owner: any; // read-only
      eventsSource: HTMLElement; // read-only
      eventsTarget: HTMLElement;
      hitTestBuffer: number;
      targetOffset: lt.LeadPointD; // read-only
      isListening: boolean; // read-only
      tapOnDown: boolean;
      enableHold: boolean;
      holdDelay: number;
      dragStartsOnDown: boolean;
      pinchStartsOnDown: boolean;
      enableMouseWheel: boolean;
      mouseWheelDeltaMultiplier: number;
      doubleTapDelay: number;
      cancelOnEscape: boolean;
      static modifierKeys: Keys; // read-only
      userControls: HTMLElement[]; // read-only
      preventContextMenu: boolean;
      enableSelection: boolean;
      supportsMouse: boolean; // read-only
      move: InteractiveEventType; // read-only
      tap: InteractiveEventType; // read-only
      hold: InteractiveEventType; // read-only
      doubleTap: InteractiveEventType; // read-only
      dragStarted: InteractiveDragStartedEventType; // read-only
      dragDelta: InteractiveDragDeltaEventType; // read-only
      dragCompleted: InteractiveDragCompletedEventType; // read-only
      keyDown: InteractiveKeyEventType; // read-only
      keyUp: InteractiveKeyEventType; // read-only
      pinchStarted: InteractivePinchStartedEventType; // read-only
      pinchDelta: InteractivePinchDeltaEventType; // read-only
      pinchCompleted: InteractivePinchCompletedEventType; // read-only
      contextMenu: InteractiveEventType; // read-only
   }

   enum InteractiveDirection {
      horizontal = 0,
      vertical = 1
   }

   interface InteractiveEventHandler extends lt.LeadEventHandler {
      (sender: any, e: InteractiveEventArgs): void;
   }

   class InteractiveEventType extends lt.LeadEvent {
      add(value: InteractiveEventHandler): InteractiveEventHandler;
      remove(value: InteractiveEventHandler): void;
   }

   class InteractiveEventArgs extends lt.LeadEventArgs {
      get_mouseButton(): MouseButtons;
      set_mouseButton(value: MouseButtons): void;
      get_nativeEvent(): Event;
      set_nativeEvent(value: Event): void;
      get_origin(): lt.LeadPointD;
      set_origin(value: lt.LeadPointD): void;
      get_position(): lt.LeadPointD;
      set_position(value: lt.LeadPointD): void;
      get_isTouch(): boolean;
      set_isTouch(value: boolean): void;
      get_points(): lt.LeadPointD[];
      set_points(value: lt.LeadPointD[]): void;
      get_isHandled(): boolean;
      set_isHandled(value: boolean): void;
      constructor();
      mouseButton: MouseButtons;
      nativeEvent: Event;
      origin: lt.LeadPointD;
      position: lt.LeadPointD;
      isTouch: boolean;
      points: lt.LeadPointD[];
      isHandled: boolean;
   }

   interface InteractiveDragEventHandler extends lt.LeadEventHandler {
      (sender: any, e: InteractiveDragEventArgs): void;
   }

   class InteractiveDragEventType extends lt.LeadEvent {
      add(value: InteractiveDragEventHandler): InteractiveDragEventHandler;
      remove(value: InteractiveDragEventHandler): void;
   }

   class InteractiveDragEventArgs extends InteractiveEventArgs {
      get_change(): lt.LeadPointD;
      set_change(value: lt.LeadPointD): void;
      get_isMouseWheel(): boolean;
      set_isMouseWheel(value: boolean): void;
      constructor();
      change: lt.LeadPointD;
      isMouseWheel: boolean;
   }

   interface InteractiveDragStartedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: InteractiveDragStartedEventArgs): void;
   }

   class InteractiveDragStartedEventType extends lt.LeadEvent {
      add(value: InteractiveDragStartedEventHandler): InteractiveDragStartedEventHandler;
      remove(value: InteractiveDragStartedEventHandler): void;
   }

   class InteractiveDragStartedEventArgs extends InteractiveDragEventArgs {
      constructor();
   }

   interface InteractiveDragDeltaEventHandler extends lt.LeadEventHandler {
      (sender: any, e: InteractiveDragDeltaEventArgs): void;
   }

   class InteractiveDragDeltaEventType extends lt.LeadEvent {
      add(value: InteractiveDragDeltaEventHandler): InteractiveDragDeltaEventHandler;
      remove(value: InteractiveDragDeltaEventHandler): void;
   }

   class InteractiveDragDeltaEventArgs extends InteractiveDragEventArgs {
      get_direction(): InteractiveDirection;
      set_direction(value: InteractiveDirection): void;
      constructor();
      direction: InteractiveDirection;
   }

   interface InteractiveDragCompletedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: InteractiveDragCompletedEventArgs): void;
   }

   class InteractiveDragCompletedEventType extends lt.LeadEvent {
      add(value: InteractiveDragCompletedEventHandler): InteractiveDragCompletedEventHandler;
      remove(value: InteractiveDragCompletedEventHandler): void;
   }

   class InteractiveDragCompletedEventArgs extends InteractiveDragEventArgs {
      get_direction(): InteractiveDirection;
      set_direction(value: InteractiveDirection): void;
      get_velocity(): lt.LeadPointD;
      set_velocity(value: lt.LeadPointD): void;
      get_isCanceled(): boolean;
      set_isCanceled(value: boolean): void;
      constructor();
      direction: InteractiveDirection;
      velocity: lt.LeadPointD;
      isCanceled: boolean;
   }

   interface InteractiveKeyEventHandler extends lt.LeadEventHandler {
      (sender: any, e: InteractiveKeyEventArgs): void;
   }

   class InteractiveKeyEventType extends lt.LeadEvent {
      add(value: InteractiveKeyEventHandler): InteractiveKeyEventHandler;
      remove(value: InteractiveKeyEventHandler): void;
   }

   class InteractiveKeyEventArgs extends lt.LeadEventArgs {
      get_nativeEvent(): Event;
      set_nativeEvent(value: Event): void;
      get_keyCode(): Keys;
      set_keyCode(value: Keys): void;
      get_isHandled(): boolean;
      set_isHandled(value: boolean): void;
      constructor();
      nativeEvent: Event;
      keyCode: Keys;
      isHandled: boolean;
   }

   interface InteractiveMultiTouchEventHandler extends lt.LeadEventHandler {
      (sender: any, e: InteractiveMultiTouchEventArgs): void;
   }

   class InteractiveMultiTouchEventType extends lt.LeadEvent {
      add(value: InteractiveMultiTouchEventHandler): InteractiveMultiTouchEventHandler;
      remove(value: InteractiveMultiTouchEventHandler): void;
   }

   class InteractiveMultiTouchEventArgs extends InteractiveEventArgs {
      get_origin2(): lt.LeadPointD;
      set_origin2(value: lt.LeadPointD): void;
      get_position2(): lt.LeadPointD;
      set_position2(value: lt.LeadPointD): void;
      constructor();
      origin2: lt.LeadPointD;
      position2: lt.LeadPointD;
   }

   interface InteractivePinchStartedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: InteractivePinchStartedEventArgs): void;
   }

   class InteractivePinchStartedEventType extends lt.LeadEvent {
      add(value: InteractivePinchStartedEventHandler): InteractivePinchStartedEventHandler;
      remove(value: InteractivePinchStartedEventHandler): void;
   }

   class InteractivePinchStartedEventArgs extends InteractiveMultiTouchEventArgs {
      get_angle(): number;
      set_angle(value: number): void;
      get_distance(): number;
      set_distance(value: number): void;
      constructor();
      angle: number;
      distance: number;
   }

   interface InteractivePinchDeltaEventHandler extends lt.LeadEventHandler {
      (sender: any, e: InteractivePinchDeltaEventArgs): void;
   }

   class InteractivePinchDeltaEventType extends lt.LeadEvent {
      add(value: InteractivePinchDeltaEventHandler): InteractivePinchDeltaEventHandler;
      remove(value: InteractivePinchDeltaEventHandler): void;
   }

   class InteractivePinchDeltaEventArgs extends InteractiveMultiTouchEventArgs {
      get_distanceRatio(): number;
      set_distanceRatio(value: number): void;
      get_totalAngleDelta(): number;
      set_totalAngleDelta(value: number): void;
      constructor();
      distanceRatio: number;
      totalAngleDelta: number;
   }

   interface InteractivePinchCompletedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: InteractivePinchCompletedEventArgs): void;
   }

   class InteractivePinchCompletedEventType extends lt.LeadEvent {
      add(value: InteractivePinchCompletedEventHandler): InteractivePinchCompletedEventHandler;
      remove(value: InteractivePinchCompletedEventHandler): void;
   }

   class InteractivePinchCompletedEventArgs extends InteractivePinchDeltaEventArgs {
      get_isCanceled(): boolean;
      set_isCanceled(value: boolean): void;
      constructor();
      isCanceled: boolean;
   }
}
