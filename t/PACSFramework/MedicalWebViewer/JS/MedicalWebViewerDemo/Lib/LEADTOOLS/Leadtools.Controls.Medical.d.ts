//***********************************************************************************************
//   Type definitions for Leadtools.Controls.Medical.js
//   Updated: 12/3/2019 19:01
//   Version: 20.0.0.8
//
//   Dependencies:
//      Leadtools.d.ts
//      Leadtools.Annotations.Automation.d.ts
//      Leadtools.Annotations.Designers.d.ts
//      Leadtools.Annotations.Engine.d.ts
//      Leadtools.Annotations.Rendering.JavaScript.d.ts
//      Leadtools.Controls.d.ts
//
//   Copyright (c) 1991-2019 All Rights Reserved. LEAD Technologies, Inc.
//   https://www.leadtools.com
//***********************************************************************************************

declare module lt.Controls.Medical {

   class AutomationImageViewer extends lt.Controls.ImageViewer {
      get_automationScrollOffset(): lt.LeadPointD;
      get_automationObject(): any;
      set_automationObject(value: any): void;
      automationAttach(container: lt.Annotations.Engine.AnnContainer): void;
      automationDetach(): void;
      add_automationDoubleClick(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
      remove_automationDoubleClick(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
      get_automationDpiX(): number;
      get_automationDpiY(): number;
      get_automationEnabled(): boolean;
      add_automationEnabledChanged(value: lt.LeadEventHandler): void;
      remove_automationEnabledChanged(value: lt.LeadEventHandler): void;
      get_automationGetContainersCallback(): lt.Annotations.Engine.AnnAutomationControlGetContainersCallback;
      set_automationGetContainersCallback(value: lt.Annotations.Engine.AnnAutomationControlGetContainersCallback): void;
      add_automationGotFocus(value: lt.LeadEventHandler): void;
      remove_automationGotFocus(value: lt.LeadEventHandler): void;
      automationInvalidate(invalidateRect: lt.LeadRectD): void;
      add_automationLostFocus(value: lt.LeadEventHandler): void;
      remove_automationLostFocus(value: lt.LeadEventHandler): void;
      add_automationPointerDown(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
      remove_automationPointerDown(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
      add_automationPointerMove(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
      remove_automationPointerMove(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
      add_automationPointerUp(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
      remove_automationPointerUp(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
      add_automationSizeChanged(value: lt.LeadEventHandler): void;
      remove_automationSizeChanged(value: lt.LeadEventHandler): void;
      get_automationTransform(): lt.LeadMatrix;
      add_automationTransformChanged(value: lt.LeadEventHandler): void;
      remove_automationTransformChanged(value: lt.LeadEventHandler): void;
      get_automationUseDpi(): boolean;
      add_automationUseDpiChanged(value: lt.LeadEventHandler): void;
      remove_automationUseDpiChanged(value: lt.LeadEventHandler): void;
      get_automationXResolution(): number;
      get_automationYResolution(): number;
      get_renderingEngine(): lt.Annotations.Engine.AnnRenderingEngine;
      set_renderingEngine(value: lt.Annotations.Engine.AnnRenderingEngine): void;
      onItemChanged(e: lt.Controls.ImageViewerItemChangedEventArgs): void;  // protected
      onTransformChanged(e: lt.LeadEventArgs): void;
      onAutomationPointerDown(args: lt.Annotations.Engine.AnnPointerEventArgs): void;
      onAutomationPointerMove(args: lt.Annotations.Engine.AnnPointerEventArgs): void;
      onAutomationPointerUp(args: lt.Annotations.Engine.AnnPointerEventArgs): void;
      onAutomationDoubleClick(args: lt.Annotations.Engine.AnnPointerEventArgs): void;
      get_automationDataProvider(): lt.Annotations.Engine.AnnDataProvider;
      set_automationDataProvider(value: lt.Annotations.Engine.AnnDataProvider): void;
      get_automationAntiAlias(): boolean;
      set_automationAntiAlias(value: boolean): void;
      get_automationContainerIndex(): number;
      set_automationContainerIndex(value: number): void;
      get_automationRotateAngle(): number;
      get_automationScaleFactor(): number;
      get_isAutomationEventsHooked(): boolean;
      set_isAutomationEventsHooked(value: boolean): void;
      constructor(createOptions: lt.Controls.ImageViewerCreateOptions, divID: string);
      automationScrollOffset: lt.LeadPointD; // read-only
      automationObject: any;
      automationDpiX: number; // read-only
      automationDpiY: number; // read-only
      automationEnabled: boolean; // read-only
      automationGetContainersCallback: lt.Annotations.Engine.AnnAutomationControlGetContainersCallback;
      automationTransform: lt.LeadMatrix; // read-only
      automationUseDpi: boolean; // read-only
      automationXResolution: number; // read-only
      automationYResolution: number; // read-only
      renderingEngine: lt.Annotations.Engine.AnnRenderingEngine;
      automationDataProvider: lt.Annotations.Engine.AnnDataProvider;
      automationAntiAlias: boolean;
      automationContainerIndex: number;
      automationRotateAngle: number; // read-only
      automationScaleFactor: number; // read-only
      isAutomationEventsHooked: boolean;
      automationDoubleClick: lt.Annotations.Engine.AnnPointerEventType; // read-only
      automationEnabledChanged: lt.LeadEventType; // read-only
      automationGotFocus: lt.LeadEventType; // read-only
      automationLostFocus: lt.LeadEventType; // read-only
      automationPointerDown: lt.Annotations.Engine.AnnPointerEventType; // read-only
      automationPointerMove: lt.Annotations.Engine.AnnPointerEventType; // read-only
      automationPointerUp: lt.Annotations.Engine.AnnPointerEventType; // read-only
      automationSizeChanged: lt.LeadEventType; // read-only
      automationTransformChanged: lt.LeadEventType; // read-only
      automationUseDpiChanged: lt.LeadEventType; // read-only
   }

   class AutomationInteractiveMode extends lt.Controls.ImageViewerInteractiveMode {
      get_id(): number;
      start(viewer: lt.Controls.ImageViewer): void;
      stop(viewer: lt.Controls.ImageViewer): void;
      get_name(): string;
      constructor();
      id: number; // read-only
      name: string; // read-only
   }

   class WindowLevelInfomation {
      get_minValue(): number;
      set_minValue(value: number): void;
      get_maxValue(): number;
      set_maxValue(value: number): void;
      get_windowWidth(): number;
      set_windowWidth(value: number): void;
      get_windowCenter(): number;
      set_windowCenter(value: number): void;
      get_signed(): boolean;
      set_signed(value: boolean): void;
      get_photometricInterpretation(): string;
      set_photometricInterpretation(value: string): void;
      get_autoScaleIntercept(): number;
      set_autoScaleIntercept(value: number): void;
      get_autoScaleSlope(): number;
      set_autoScaleSlope(value: number): void;
      constructor();
      minValue: number;
      maxValue: number;
      windowWidth: number;
      windowCenter: number;
      signed: boolean;
      photometricInterpretation: string;
      autoScaleIntercept: number;
      autoScaleSlope: number;
   }

   class DICOMImageInformation extends WindowLevelInfomation {
      get_image(): HTMLImageElement;
      set_image(value: HTMLImageElement): void;
      get_canvas(): HTMLCanvasElement;
      set_canvas(value: HTMLCanvasElement): void;
      get_width(): number;
      set_width(value: number): void;
      get_height(): number;
      set_height(value: number): void;
      get_bitsPerPixel(): number;
      set_bitsPerPixel(value: number): void;
      get_luT32(): number[];
      set_luT32(value: number[]): void;
      get_data32(): number[];
      set_data32(value: number[]): void;
      get_lowBit(): number;
      set_lowBit(value: number): void;
      get_highBit(): number;
      set_highBit(value: number): void;
      get_modalityIntercept(): number;
      set_modalityIntercept(value: number): void;
      get_modalitySlope(): number;
      set_modalitySlope(value: number): void;
      get_lutDescriptor(): number[];
      set_lutDescriptor(value: number[]): void;
      get_firstStoredPixelValueMapped(): number;
      set_firstStoredPixelValueMapped(value: number): void;
      clone(): DICOMImageInformation;
      constructor();
      image: HTMLImageElement;
      canvas: HTMLCanvasElement;
      width: number;
      height: number;
      bitsPerPixel: number;
      luT32: number[];
      data32: number[];
      lowBit: number;
      highBit: number;
      modalityIntercept: number;
      modalitySlope: number;
      lutDescriptor: number[];
      firstStoredPixelValueMapped: number;
   }

   enum WindowLevelPaletteType {
      none = 0,
      cool = 1,
      cyanHot = 2,
      fire = 3,
      icA2 = 4,
      ice = 5,
      orangeHot = 6,
      rainbowRGB = 7,
      redHot = 8,
      spectrum = 9
   }

   enum StackSynchronizationCriteria {
      imagePosition = 0,
      anatomy = 1,
      tag = 2,
      custom = 3
   }

   class DICOMImageInformationRenderer {
      dispose(): void;
      get_inverted(): boolean;
      set_inverted(value: boolean): void;
      get_isDirty(): boolean;
      get_information(): DICOMImageInformation;
      get_minimumWindowLevelWidth(): number;
      get_maximumWindowLevelWidth(): number;
      get_minimumWindowLevelCenter(): number;
      get_maximumWindowLevelCenter(): number;
      get_originalWindowLevelWidth(): number;
      get_originalWindowLevelCenter(): number;
      get_windowLevelWidth(): number;
      get_windowLevelCenter(): number;
      reset(): void;
      updateWindowLevelLUT(width: number, center: number): void;
      add_changed(value: lt.LeadEventHandler): void;
      remove_changed(value: lt.LeadEventHandler): void;
      onChanged(e: lt.LeadEventArgs): void;
      renderUsingCanvas(canvas: HTMLCanvasElement, isNewImageData: boolean): void;
      add_updateImageData(value: lt.LeadEventHandler): void;
      remove_updateImageData(value: lt.LeadEventHandler): void;
      onUpdateImageData(e: lt.LeadEventArgs): void;
      loadPaletteData(xmlFileName: string): void;
      get_paletteType(): WindowLevelPaletteType;
      set_paletteType(value: WindowLevelPaletteType): void;
      static shouldResize(width: number, height: number): number;
      constructor(information: DICOMImageInformation);
      inverted: boolean;
      isDirty: boolean; // read-only
      information: DICOMImageInformation; // read-only
      minimumWindowLevelWidth: number; // read-only
      maximumWindowLevelWidth: number; // read-only
      minimumWindowLevelCenter: number; // read-only
      maximumWindowLevelCenter: number; // read-only
      originalWindowLevelWidth: number; // read-only
      originalWindowLevelCenter: number; // read-only
      windowLevelWidth: number; // read-only
      windowLevelCenter: number; // read-only
      paletteType: WindowLevelPaletteType;
      changed: lt.LeadEventType; // read-only
      updateImageData: lt.LeadEventType; // read-only
   }

   class MenuItem {
      constructor(text: string, icon: HTMLImageElement, userData: any);
      text: string;
      icon: HTMLImageElement;
      userData: any;
   }

   interface MenuItemSelectedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: MenuItemSelectedEventArgs): void;
   }

   class MenuItemSelectedEventType extends lt.LeadEvent {
      add(value: MenuItemSelectedEventHandler): MenuItemSelectedEventHandler;
      remove(value: MenuItemSelectedEventHandler): void;
   }

   class MenuItemSelectedEventArgs extends lt.LeadEventArgs {
      get_item(): MenuItem;
      constructor(item: MenuItem);
      item: MenuItem; // read-only
   }

   class Menu {
      get_items(): lt.LeadCollection;
      set_items(value: lt.LeadCollection): void;
      add_menuItemSelected(value: MenuItemSelectedEventHandler): void;
      remove_menuItemSelected(value: MenuItemSelectedEventHandler): void;
      add_menuItemHover(value: MenuItemSelectedEventHandler): void;
      remove_menuItemHover(value: MenuItemSelectedEventHandler): void;
      add_menuItemLeave(value: MenuItemSelectedEventHandler): void;
      remove_menuItemLeave(value: MenuItemSelectedEventHandler): void;
      dispose(): void;
      get_id(): string;
      show(cell: LayoutManagerItem, x: number, y: number, boundaries: lt.LeadRectD): void;
      constructor(title: string);
      items: lt.LeadCollection;
      id: string; // read-only
      menuItemSelected: MenuItemSelectedEventType; // read-only
      menuItemHover: MenuItemSelectedEventType; // read-only
      menuItemLeave: MenuItemSelectedEventType; // read-only
      title: string;
   }

   class ImageProcessing {
      static getHistogramPoint(imageData: ImageData, threshold: number): lt.LeadPointD;
      static levelIntensity(imageData: ImageData, low: number, high: number): void;
      static stretchIntensity(imageData: ImageData, threshold: number): void;
      constructor();
   }

   enum ExplodeType {
      none = 0,
      auto = 1,
      cell = 2,
      viewer = 3
   }

   enum MedicalViewerSizeMode {
      none = 0,
      actualSize = 1,
      fit = 2,
      trueSize = 3
   }

   class LayoutManagerItem {
      get_drawables(): { [key: string]: Drawable };
      dispose(): void;
      get_viewer(): MedicalViewer;
      get_labels(): lt.LeadCollection;
      get_highlighted(): boolean;
      set_highlighted(value: boolean): void;
      get_numberOfRows(): number;
      get_numberOfColumns(): number;
      get_userData(): any;
      set_userData(value: any): void;
      get_div(): HTMLDivElement;
      get_divID(): string;
      set_divID(value: string): void;
      get_parent(): LayoutManager;
      set_parent(value: LayoutManager): void;
      get_displayRectangle(): lt.LeadRectD;
      set_displayRectangle(value: lt.LeadRectD): void;
      get_bounds(): lt.LeadRectD;
      set_bounds(value: lt.LeadRectD): void;
      get_selected(): boolean;
      set_selected(value: boolean): void;
      get_name(): string;
      onSizeChanged(): void;
      get_position(): number;
      set_position(value: number): void;
      get_rowPosition(): number;
      set_rowPosition(value: number): void;
      get_columnsPosition(): number;
      set_columnsPosition(value: number): void;
      get_visibility(): boolean;
      set_visibility(value: boolean): void;
      constructor(viewer: MedicalViewer, divID: string);
      drawables: { [key: string]: Drawable }; // read-only
      viewer: MedicalViewer; // read-only
      labels: lt.LeadCollection; // read-only
      highlighted: boolean;
      numberOfRows: number;
      numberOfColumns: number;
      userData: any;
      div: HTMLDivElement; // read-only
      divID: string;
      parent: LayoutManager;
      displayRectangle: lt.LeadRectD;
      bounds: lt.LeadRectD;
      selected: boolean;
      name: string; // read-only
      position: number;
      rowPosition: number;
      columnsPosition: number;
      visibility: boolean;
   }

   class LayoutManager {
      get_items(): lt.LeadCollection;
      get_highlightedItems(): lt.LeadCollection;
      get_selectedItems(): lt.LeadCollection;
      get_selectedItem(): LayoutManagerItem;
      set_selectedItem(value: LayoutManagerItem): void;
      selectItem(item: LayoutManagerItem, select: boolean): void;
      get_viewer(): MedicalViewer;
      get_div(): HTMLDivElement;
      onSizeChanged(): void;
      beginUpdate(): void;
      canUpdate(): boolean;
      endUpdate(): void;
      constructor(divParent: HTMLDivElement, viewer: MedicalViewer);
      items: lt.LeadCollection; // read-only
      highlightedItems: lt.LeadCollection; // read-only
      selectedItems: lt.LeadCollection; // read-only
      selectedItem: LayoutManagerItem;
      viewer: MedicalViewer; // read-only
      div: HTMLDivElement; // read-only
   }

   class GridLayout {
      get_splitterSize(): number;
      set_splitterSize(value: number): void;
      get_rows(): number;
      set_rows(value: number): void;
      get_columns(): number;
      set_columns(value: number): void;
      get_horizontalSplitters(): number[];
      get_verticalSplitters(): number[];
      get_splittersMovable(): boolean;
      set_splittersMovable(value: boolean): void;
      constructor(viewer: MedicalViewer, rows: number, columns: number);
      splitterSize: number;
      rows: number;
      columns: number;
      horizontalSplitters: number[]; // read-only
      verticalSplitters: number[]; // read-only
      splittersMovable: boolean;
   }

   enum CellsArrangement {
      grid = 0,
      random = 1
   }

   class MedicalViewer extends lt.Controls.InteractiveService {
      set_cellsArrangement(value: CellsArrangement): void;
      get_cellsArrangement(): CellsArrangement;
      get_gridLayout(): GridLayout;
      onDragStarted(e: lt.Controls.InteractiveDragStartedEventArgs): void;  // protected
      onDragDelta(e: lt.Controls.InteractiveDragDeltaEventArgs): void;  // protected
      onDragCompleted(e: lt.Controls.InteractiveDragCompletedEventArgs): void;  // protected
      get_backgroundColor(): string;
      set_backgroundColor(value: string): void;
      onSizeChanged(): void;
      renderViewer(): void;
      layoutCells(): void;
      get_replaceEmptyDivs(): boolean;
      set_replaceEmptyDivs(value: boolean): void;
      canMerge(): boolean;
      mergeSelected(): void;
      get_multipleSelection(): boolean;
      set_multipleSelection(value: boolean): void;
      add_selectionChanged(value: lt.LeadEventHandler): void;
      remove_selectionChanged(value: lt.LeadEventHandler): void;
      add_matchedFrame(value: MatchedFrameEventHandler): void;
      remove_matchedFrame(value: MatchedFrameEventHandler): void;
      refreshReferenceLine(): void;
      get_totalCells(): number;
      set_totalCells(value: number): void;
      synchronizeSeries(cell: Cell): void;
      get_emptyDivs(): LayoutManager;
      invalidate(): void;
      synchronizeStudies(key: string, studies: string[], fidutialPoints: LeadPoint3D[][]): void;
      removeKey(key: string): void;
      get_matchedCells(): { [key: string]: Cell[] };
      get_emptyCellColor(): string;
      set_emptyCellColor(value: string): void;
      get_selectedSeries(): lt.LeadCollection;
      get_activeSeries(): Cell;
      set_activeSeries(value: Cell): void;
      get_showReferenceLine(): boolean;
      set_showReferenceLine(value: boolean): void;
      get_showFirstAndLastReferenceLine(): boolean;
      set_showFirstAndLastReferenceLine(value: boolean): void;
      get_synchronizeDicomTag(): number;
      set_synchronizeDicomTag(value: number): void;
      get_synchronizationCriteria(): StackSynchronizationCriteria;
      set_synchronizationCriteria(value: StackSynchronizationCriteria): void;
      get_enableSynchronization(): boolean;
      set_enableSynchronization(value: boolean): void;
      get_explodeType(): ExplodeType;
      set_explodeType(value: ExplodeType): void;
      explode(cell: Cell, exploded: boolean): void;
      get_exploded(): boolean;
      get_explodedCell(): LayoutManagerItem;
      add_beforeCellExploded(value: CellExplodedEventHandler): void;
      remove_beforeCellExploded(value: CellExplodedEventHandler): void;
      add_afterCellExploded(value: CellExplodedEventHandler): void;
      remove_afterCellExploded(value: CellExplodedEventHandler): void;
      onAfterCellExploded(cell: LayoutManagerItem): void;  // protected
      onBeforeCellExploded(cell: LayoutManagerItem): void;  // protected
      get_splittersColor(): string;
      set_splittersColor(value: string): void;
      get_divId(): string;
      constructor(parent: HTMLDivElement, rows: number, columns: number);
      replaceEmptyDivs: boolean;
      multipleSelection: boolean;
      totalCells: number;
      emptyDivs: LayoutManager; // read-only
      matchedCells: { [key: string]: Cell[] }; // read-only
      emptyCellColor: string;
      selectedSeries: lt.LeadCollection; // read-only
      activeSeries: Cell;
      showReferenceLine: boolean;
      showFirstAndLastReferenceLine: boolean;
      synchronizeDicomTag: number;
      synchronizationCriteria: StackSynchronizationCriteria;
      enableSynchronization: boolean;
      explodeType: ExplodeType;
      exploded: boolean; // read-only
      explodedCell: LayoutManagerItem; // read-only
      splittersColor: string;
      divId: string; // read-only
      cellsArrangement: CellsArrangement;
      gridLayout: GridLayout; // read-only
      backgroundColor: string;
      selectionChanged: lt.LeadEventType; // read-only
      matchedFrame: MatchedFrameEventType; // read-only
      beforeCellExploded: CellExplodedEventType; // read-only
      afterCellExploded: CellExplodedEventType; // read-only
      layout: LayoutManager;
      emptyCellClicked: lt.LeadEventType;
   }

   enum FrameArrangement {
      grid = 0,
      custom = 1,
      rowSymmetric = 2,
      colSymmetric = 3
   }

   class CellGridLayout {
      get_value1(): number;
      set_value1(value: number): void;
      get_value2(): number;
      set_value2(value: number): void;
      get_value3(): number;
      set_value3(value: number): void;
      get_value4(): number;
      set_value4(value: number): void;
      get_rows(): number;
      set_rows(value: number): void;
      get_columns(): number;
      set_columns(value: number): void;
      constructor(cell: Cell, rows: number, columns: number);
      value1: number;
      value2: number;
      value3: number;
      value4: number;
      rows: number;
      columns: number;
   }

   class Slice {
      add_sliceUpdated(value: lt.LeadEventHandler): void;
      remove_sliceUpdated(value: lt.LeadEventHandler): void;
      get_slicePosition(): number;
      set_slicePosition(value: number): void;
      get_length(): number;
      set_length(value: number): void;
      get_startingPoint(): number;
      set_startingPoint(value: number): void;
      get_point1(): lt.LeadPointD;
      get_point2(): lt.LeadPointD;
      get_verticalPoints(): lt.LeadCollection;
      refresh(): void;
      constructor();
      slicePosition: number;
      length: number;
      startingPoint: number;
      point1: lt.LeadPointD; // read-only
      point2: lt.LeadPointD; // read-only
      verticalPoints: lt.LeadCollection; // read-only
      sliceUpdated: lt.LeadEventType; // read-only
   }

   class ParaxialFrame extends Frame {
      get_sliceData(): Slice;
      constructor(cell: Cell, slice: Slice);
      sliceData: Slice; // read-only
   }

   class ParaxialSlice {
      constructor();
   }

   class ParaxialSlicesCell extends Cell {
      get_URI(): string;
      set_URI(value: string): void;
      get_name(): string;
      get_engine(): Object3DEngine;
      set_engine(value: Object3DEngine): void;
      dispose(): void;
      constructor(viewer: MedicalViewer, divID: string, rows: number, columns: number);
      URI: string;
      name: string; // read-only
      engine: Object3DEngine;
   }

   class PanoramicCell extends Cell {
      get_URI(): string;
      set_URI(value: string): void;
      get_name(): string;
      get_polygon(): PanoramicPolygon;
      set_polygon(value: PanoramicPolygon): void;
      get_engine(): Object3DEngine;
      set_engine(value: Object3DEngine): void;
      get_imagePosition(): number[][];
      set_imagePosition(value: number[][]): void;
      get_imageOrientation(): number[][];
      set_imageOrientation(value: number[][]): void;
      constructor(viewer: MedicalViewer, divID: string);
      URI: string;
      name: string; // read-only
      polygon: PanoramicPolygon;
      engine: Object3DEngine;
      imagePosition: number[][];
      imageOrientation: number[][];
   }

   class EmptyCell extends LayoutManagerItem {
      get_name(): string;
      get_backgroundColor(): string;
      set_backgroundColor(value: string): void;
      dispose(): void;
      constructor(manager: LayoutManager, viewer: MedicalViewer, id: string, rowPosition: number, columnPosition: number);
      name: string; // read-only
      backgroundColor: string;
   }

   interface MatchedFrameEventHandler extends lt.LeadEventHandler {
      (sender: any, e: MatchedFrameEventArgs): void;
   }

   class MatchedFrameEventType extends lt.LeadEvent {
      add(value: MatchedFrameEventHandler): MatchedFrameEventHandler;
      remove(value: MatchedFrameEventHandler): void;
   }

   class MatchedFrameEventArgs extends CellEventArgs {
      get_targetFrame(): Frame;
      get_matched(): boolean;
      set_matched(value: boolean): void;
      constructor(frame: Frame, targetFrame: Frame);
      targetFrame: Frame; // read-only
      matched: boolean;
   }

   interface ImageURLChangedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: ImageURLChangedEventArgs): void;
   }

   class ImageURLChangedEventType extends lt.LeadEvent {
      add(value: ImageURLChangedEventHandler): ImageURLChangedEventHandler;
      remove(value: ImageURLChangedEventHandler): void;
   }

   class ImageURLChangedEventArgs extends CellEventArgs {
      constructor(frame: Frame);
   }

   interface ImageProcessingReadyEventHandler extends lt.LeadEventHandler {
      (sender: any, e: ImageProcessingReadyEventArgs): void;
   }

   class ImageProcessingReadyEventType extends lt.LeadEvent {
      add(value: ImageProcessingReadyEventHandler): ImageProcessingReadyEventHandler;
      remove(value: ImageProcessingReadyEventHandler): void;
   }

   class ImageProcessingReadyEventArgs extends lt.LeadEventArgs {
      get_imageProcessing(): lt.ImageProcessing;
      get_frame(): Frame;
      constructor(frame: Frame, imageProcessing: lt.ImageProcessing);
      imageProcessing: lt.ImageProcessing; // read-only
      frame: Frame; // read-only
   }

   enum CanDo3DStatus {
      ok = 0,
      imageOrientationNotTheSame = -5,
      cellNotValid = -4,
      allFramesNotReady = -3,
      imagePositionNotReady = -2,
      notEnoughFrames = -1
   }

   enum MPRStatus {
      ok = 0,
      imageOrientationNotTheSame = -5,
      cellNotValid = -4,
      allFramesNotReady = -3,
      imagePositionNotReady = -2,
      notEnoughFrames = -1
   }

   interface CellEventHandler extends lt.LeadEventHandler {
      (sender: any, e: CellEventArgs): void;
   }

   class CellEventType extends lt.LeadEvent {
      add(value: CellEventHandler): CellEventHandler;
      remove(value: CellEventHandler): void;
   }

   class CellEventArgs extends lt.LeadEventArgs {
      get_frame(): Frame;
      constructor(frame: Frame);
      frame: Frame; // read-only
   }

   interface CellExplodedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: CellExplodedEventArgs): void;
   }

   class CellExplodedEventType extends lt.LeadEvent {
      add(value: CellExplodedEventHandler): CellExplodedEventHandler;
      remove(value: CellExplodedEventHandler): void;
   }

   class CellExplodedEventArgs extends lt.LeadEventArgs {
      get_cell(): LayoutManagerItem;
      constructor(cell: LayoutManagerItem);
      cell: LayoutManagerItem; // read-only
   }

   interface FrameAttachedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: FrameAttachedEventArgs): void;
   }

   class FrameAttachedEventType extends lt.LeadEvent {
      add(value: FrameAttachedEventHandler): FrameAttachedEventHandler;
      remove(value: FrameAttachedEventHandler): void;
   }

   class FrameAttachedEventArgs extends lt.LeadEventArgs {
      get_subCell(): SubCell;
      get_frame(): Frame;
      constructor(subCell: SubCell, frame: Frame);
      subCell: SubCell; // read-only
      frame: Frame; // read-only
   }

   enum CellMPRType {
      axial = 0,
      sagittal = 1,
      coronal = 2,
      none = -1
   }

   class MPRCell extends Cell {
      get_serverSideRendering(): boolean;
      set_serverSideRendering(value: boolean): void;
      onSizeChanged(): void;
      get_generator(): Cell;
      set_generator(value: Cell): void;
      get_name(): string;
      prepareDrawingCanvas(frame: Frame, chunk: ChunkData): ChunkData;  // protected
      reloadMPR(): void;
      static canDoMPR(cell: Cell): MPRStatus;
      add_frameRequested(value: MPRFrameRequestedEventHandler): void;
      remove_frameRequested(value: MPRFrameRequestedEventHandler): void;
      constructor(generator: Cell, mprType: CellMPRType, divID: string, serverSideRendering: boolean);
      serverSideRendering: boolean;
      generator: Cell;
      name: string; // read-only
      frameRequested: MPRFrameRequestedEventType; // read-only
   }

   interface ScrollChangedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: ScrollChangedEventArgs): void;
   }

   class ScrollChangedEventType extends lt.LeadEvent {
      add(value: ScrollChangedEventHandler): ScrollChangedEventHandler;
      remove(value: ScrollChangedEventHandler): void;
   }

   class ScrollChangedEventArgs extends lt.LeadEventArgs {
      get_scrollOffset(): number;
      get_previousScrollOffset(): number;
      constructor(previousScrollOffset: number, scrollOffset: number);
      scrollOffset: number; // read-only
      previousScrollOffset: number; // read-only
   }

   enum ScrollType {
      none = 0,
      normal = 1,
      row = 2,
      column = 3,
      page = 4
   }

   class TickBox {
      get_parent(): LayoutManagerItem;
      add_tickBoxClicked(value: lt.LeadEventHandler): void;
      remove_tickBoxClicked(value: lt.LeadEventHandler): void;
      dispose(): void;
      get_div(): HTMLDivElement;
      get_checked(): boolean;
      set_checked(value: boolean): void;
      get_visible(): boolean;
      set_visible(value: boolean): void;
      onSizeChanged(): void;
      constructor(cell: LayoutManagerItem);
      parent: LayoutManagerItem; // read-only
      div: HTMLDivElement; // read-only
      checked: boolean;
      visible: boolean;
      tickBoxClicked: lt.LeadEventType; // read-only
   }

   class Series extends LayoutManagerItem {
      get_imageViewer(): AutomationImageViewer;
      set_imageViewer(value: AutomationImageViewer): void;
      onPostRender(sender: any, e: lt.Controls.ImageViewerRenderEventArgs): void;  // protected
      get_selectedItems(): lt.LeadCollection;
      set_selectedItems(value: lt.LeadCollection): void;
      layoutItems(viewRect: lt.LeadRectD, bounds: lt.LeadRectD[]): void;
      get_automation(): lt.Annotations.Automation.AnnAutomation;
      get_exploded(): boolean;
      set_exploded(value: boolean): void;
      set_borderThickness(value: number): void;
      get_borderThickness(): number;
      get_studyInstanceUID(): string;
      set_studyInstanceUID(value: string): void;
      get_seriesNumber(): number;
      set_seriesNumber(value: number): void;
      get_patientName(): string;
      set_patientName(value: string): void;
      get_seriesInstanceUID(): string;
      set_seriesInstanceUID(value: string): void;
      get_frameOfReferenceUID(): string;
      set_frameOfReferenceUID(value: string): void;
      get_name(): string;
      get_showFrameBorder(): boolean;
      set_showFrameBorder(value: boolean): void;
      get_selectedBorderColor(): string;
      set_selectedBorderColor(value: string): void;
      get_unselectedBorderColor(): string;
      set_unselectedBorderColor(value: string): void;
      get_selectedSubCellBorderColor(): string;
      set_selectedSubCellBorderColor(value: string): void;
      get_highlightedSubCellBorderColor(): string;
      set_highlightedSubCellBorderColor(value: string): void;
      beginUpdate(): void;
      endUpdate(): void;
      get_inverted(): boolean;
      set_inverted(value: boolean): void;
      onInvertChanged(): void;  // protected
      invalidate(): void;  // protected
      onSizeChanged(): void;
      constructor(viewer: MedicalViewer, divID: string);
      imageViewer: AutomationImageViewer;
      selectedItems: lt.LeadCollection;
      automation: lt.Annotations.Automation.AnnAutomation; // read-only
      exploded: boolean;
      borderThickness: number;
      studyInstanceUID: string;
      seriesNumber: number;
      patientName: string;
      seriesInstanceUID: string;
      frameOfReferenceUID: string;
      name: string; // read-only
      showFrameBorder: boolean;
      selectedBorderColor: string;
      unselectedBorderColor: string;
      selectedSubCellBorderColor: string;
      highlightedSubCellBorderColor: string;
      inverted: boolean;
   }

   class Cell extends LayoutManagerItem {
      get_windowLevel(): WindowLevelInteractiveMode;
      set_windowLevel(value: WindowLevelInteractiveMode): void;
      get_drawCrossHairLines(): boolean;
      set_drawCrossHairLines(value: boolean): void;
      set_borderThickness(value: number): void;
      get_borderThickness(): number;
      get_arrangement(): FrameArrangement;
      set_arrangement(value: FrameArrangement): void;
      get_showFrameBorder(): boolean;
      set_showFrameBorder(value: boolean): void;
      get_currentOffset(): number;
      set_currentOffset(value: number): void;
      get_framesMappingIndex(): number[];
      set_framesMappingIndex(value: number[]): void;
      get_frames(): lt.LeadCollection;
      get_overlays(): lt.LeadCollection;
      invalidate(): void;
      add_disposing(value: lt.LeadEventHandler): void;
      remove_disposing(value: lt.LeadEventHandler): void;
      dispose(): void;
      supportWindowLevel(frameIndex: number): boolean;
      onSizeChanged(): void;
      get_visibility(): boolean;
      set_visibility(value: boolean): void;
      get_overlayTextVisible(): boolean;
      set_overlayTextVisible(value: boolean): void;
      suspendCalculation(): void;
      resumeCalcuation(): void;
      setCommand(commandID: number, command: ActionCommand): void;
      stopCommand(commandID: number): void;
      getCommandInteractiveMode(commandID: number): any;
      getCommand(commandID: number): any;
      runCommand(commandID: number): void;
      get_seriesNumber(): number;
      set_seriesNumber(value: number): void;
      get_patientName(): string;
      set_patientName(value: string): void;
      get_seriesInstanceUID(): string;
      set_seriesInstanceUID(value: string): void;
      get_frameOfReferenceUID(): string;
      set_frameOfReferenceUID(value: string): void;
      get_linked(): boolean;
      set_linked(value: boolean): void;
      withinVisibleRange(index: number): boolean;
      updateSubCellCount(newCount: number): void;
      get_imageViewer(): AutomationImageViewer;
      set_imageViewer(value: AutomationImageViewer): void;
      get_gridLayout(): CellGridLayout;
      get_progress(): ProgressLoading;
      set_progress(value: ProgressLoading): void;
      add_outOfBounds(value: lt.LeadEventHandler): void;
      remove_outOfBounds(value: lt.LeadEventHandler): void;
      add_currentOffsetChanged(value: lt.LeadEventHandler): void;
      remove_currentOffsetChanged(value: lt.LeadEventHandler): void;
      add_cellClicked(value: lt.Controls.InteractiveEventHandler): void;
      remove_cellClicked(value: lt.Controls.InteractiveEventHandler): void;
      add_mouseDown(value: lt.Controls.InteractiveEventHandler): void;
      remove_mouseDown(value: lt.Controls.InteractiveEventHandler): void;
      add_firstFrameReady(value: CellEventHandler): void;
      remove_firstFrameReady(value: CellEventHandler): void;
      add_imageURLChanged(value: ImageURLChangedEventHandler): void;
      remove_imageURLChanged(value: ImageURLChangedEventHandler): void;
      add_postRender(value: lt.Controls.ImageViewerRenderEventHandler): void;
      remove_postRender(value: lt.Controls.ImageViewerRenderEventHandler): void;
      add_sizeChanged(value: lt.LeadEventHandler): void;
      remove_sizeChanged(value: lt.LeadEventHandler): void;
      add_scrollChanged(value: ScrollChangedEventHandler): void;
      remove_scrollChanged(value: ScrollChangedEventHandler): void;
      add_progressCompleted(value: lt.LeadEventHandler): void;
      remove_progressCompleted(value: lt.LeadEventHandler): void;
      add_imageProcessingReady(value: ImageProcessingReadyEventHandler): void;
      remove_imageProcessingReady(value: ImageProcessingReadyEventHandler): void;
      add_imageDownloaded(value: CellEventHandler): void;
      remove_imageDownloaded(value: CellEventHandler): void;
      add_frameRequestedSrc(value: FrameRequestedSrcEventHandler): void;
      remove_frameRequestedSrc(value: FrameRequestedSrcEventHandler): void;
      matchFramesScale(referenceCell: Cell, all: boolean): void;
      prepareDrawingCanvas(frame: Frame, chunk: ChunkData): ChunkData;  // protected
      get_name(): string;
      get_create3D(): boolean;
      set_create3D(value: boolean): void;
      add_data3DGenerated(value: lt.LeadEventHandler): void;
      remove_data3DGenerated(value: lt.LeadEventHandler): void;
      get_signed3D(): boolean;
      set_signed3D(value: boolean): void;
      get_commands(): { [key: number]: ActionCommand };
      get_exploded(): boolean;
      set_exploded(value: boolean): void;
      get_studyInstanceUID(): string;
      set_studyInstanceUID(value: string): void;
      get_tickBoxes(): TickBox[];
      get_fullDownload(): boolean;
      set_fullDownload(value: boolean): void;
      get_marginFramesCount(): number;
      set_marginFramesCount(value: number): void;
      get_sortingOperationsSequence(): SortingOperation[];
      set_sortingOperationsSequence(value: SortingOperation[]): void;
      get_scrollType(): ScrollType;
      set_scrollType(value: ScrollType): void;
      get_cinePlayer(): CinePlayer;
      get_lineProfile(): LineProfileObject;
      set_lineProfile(value: LineProfileObject): void;
      get_mprType(): CellMPRType;
      set_mprType(value: CellMPRType): void;
      get_derivatives(): lt.LeadCollection;
      beginUpdate(): void;
      endUpdate(): void;
      get_selectedItems(): lt.LeadCollection;
      set_selectedItems(value: lt.LeadCollection): void;
      get_selectedItem(): SubCell;
      set_selectedItem(value: SubCell): void;
      get_automationManager(): lt.Annotations.Automation.AnnAutomationManager;
      get_automation(): lt.Annotations.Automation.AnnAutomation;
      get_selectedBorderColor(): string;
      set_selectedBorderColor(value: string): void;
      get_unselectedBorderColor(): string;
      set_unselectedBorderColor(value: string): void;
      get_selectedSubCellBorderColor(): string;
      set_selectedSubCellBorderColor(value: string): void;
      get_highlightedSubCellBorderColor(): string;
      set_highlightedSubCellBorderColor(value: string): void;
      get_useBackCanvas(): boolean;
      set_useBackCanvas(value: boolean): void;
      constructor(viewer: MedicalViewer, divID: string, rows: number, columns: number);
      name: string; // read-only
      create3D: boolean;
      signed3D: boolean;
      commands: { [key: number]: ActionCommand }; // read-only
      exploded: boolean;
      studyInstanceUID: string;
      tickBoxes: TickBox[]; // read-only
      fullDownload: boolean;
      marginFramesCount: number;
      sortingOperationsSequence: SortingOperation[];
      scrollType: ScrollType;
      cinePlayer: CinePlayer;
      lineProfile: LineProfileObject;
      mprType: CellMPRType;
      derivatives: lt.LeadCollection; // read-only
      selectedItems: lt.LeadCollection;
      selectedItem: SubCell;
      automationManager: lt.Annotations.Automation.AnnAutomationManager; // read-only
      automation: lt.Annotations.Automation.AnnAutomation; // read-only
      selectedBorderColor: string;
      unselectedBorderColor: string;
      selectedSubCellBorderColor: string;
      highlightedSubCellBorderColor: string;
      useBackCanvas: boolean;
      overlayTextVisible: boolean;
      seriesNumber: number;
      patientName: string;
      seriesInstanceUID: string;
      frameOfReferenceUID: string;
      linked: boolean;
      imageViewer: AutomationImageViewer;
      gridLayout: CellGridLayout; // read-only
      progress: ProgressLoading;
      windowLevel: WindowLevelInteractiveMode;
      drawCrossHairLines: boolean;
      borderThickness: number;
      arrangement: FrameArrangement;
      showFrameBorder: boolean;
      currentOffset: number;
      framesMappingIndex: number[];
      frames: lt.LeadCollection; // read-only
      overlays: lt.LeadCollection; // read-only
      visibility: boolean;
      outOfBounds: lt.LeadEventType; // read-only
      currentOffsetChanged: lt.LeadEventType; // read-only
      cellClicked: lt.Controls.InteractiveEventType; // read-only
      mouseDown: lt.Controls.InteractiveEventType; // read-only
      firstFrameReady: CellEventType; // read-only
      imageURLChanged: ImageURLChangedEventType; // read-only
      postRender: lt.Controls.ImageViewerRenderEventType; // read-only
      sizeChanged: lt.LeadEventType; // read-only
      scrollChanged: ScrollChangedEventType; // read-only
      progressCompleted: lt.LeadEventType; // read-only
      imageProcessingReady: ImageProcessingReadyEventType; // read-only
      imageDownloaded: CellEventType; // read-only
      frameRequestedSrc: FrameRequestedSrcEventType; // read-only
      data3DGenerated: lt.LeadEventType; // read-only
      disposing: lt.LeadEventType; // read-only
   }

   class CellItem extends lt.Controls.ImageViewerItem {
      get_bounds(): lt.LeadRectD;
      set_bounds(value: lt.LeadRectD): void;
      onSizeChanged(): void;
      constructor();
      bounds: lt.LeadRectD;
   }

   class SubCell extends CellItem {
      get_backColor(): string;
      set_backColor(value: string): void;
      get_fieldOfView(): lt.LeadPointD;
      get_selected(): boolean;
      set_selected(value: boolean): void;
      get_div(): HTMLDivElement;
      get_divID(): string;
      set_divID(value: string): void;
      get_overlayCanvas(): HTMLCanvasElement;
      get_parentCell(): Cell;
      get_foreColor(): string;
      set_foreColor(value: string): void;
      add_frameAttached(value: FrameAttachedEventHandler): void;
      remove_frameAttached(value: FrameAttachedEventHandler): void;
      invalidate(): void;
      get_attachedFrame(): Frame;
      set_attachedFrame(value: Frame): void;
      get_annotationCanvas(): HTMLCanvasElement;
      set_annotationCanvas(value: HTMLCanvasElement): void;
      onSizeChanged(): void;
      dispose(): void;
      constructor(cell: Cell, divID: string);
      backColor: string;
      fieldOfView: lt.LeadPointD; // read-only
      selected: boolean;
      div: HTMLDivElement; // read-only
      divID: string;
      overlayCanvas: HTMLCanvasElement; // read-only
      parentCell: Cell; // read-only
      foreColor: string;
      attachedFrame: Frame;
      annotationCanvas: HTMLCanvasElement;
      frameAttached: FrameAttachedEventType; // read-only
   }

   class MRTISubCell extends SubCell {
      getForground(): HTMLCanvasElement;
      get_chunkList(): ChunkData[];
      add_sizeChanged(value: lt.LeadEventHandler): void;
      remove_sizeChanged(value: lt.LeadEventHandler): void;
      onSizeChanged(): void;
      static getFloatImageRect(imageViewer: lt.Controls.ImageViewer, item: lt.Controls.ImageViewerItem): lt.LeadRectD;
      get_tileResolution(): lt.LeadSizeD;
      constructor(cell: Cell, divID: string);
      chunkList: ChunkData[]; // read-only
      tileResolution: lt.LeadSizeD;
      sizeChanged: lt.LeadEventType; // read-only
   }

   enum HorizontalAlignmentType {
      middle = 0,
      left = 1,
      right = 2
   }

   enum VerticalAlignmentType {
      middle = 0,
      top = 1,
      bottom = 2
   }

   class Frame {
      set_imageURL(value: string): void;
      get_previewURI(): string;
      set_previewURI(value: string): void;
      set_highBit(value: number): void;
      get_bitStored(): number;
      set_bitStored(value: number): void;
      get_rescaleintercept(): number;
      set_rescaleintercept(value: number): void;
      get_rescaleSlope(): number;
      set_rescaleSlope(value: number): void;
      get_voiLUTSequence(): number[];
      set_voiLUTSequence(value: number[]): void;
      get_imageType(): string[];
      set_imageType(value: string[]): void;
      get_lossyCompression(): boolean;
      set_lossyCompression(value: boolean): void;
      get_isWaveForm(): boolean;
      set_isWaveForm(value: boolean): void;
      get_frameOfReferenceID(): string;
      set_frameOfReferenceID(value: string): void;
      get_photometricInterpretation(): string;
      set_photometricInterpretation(value: string): void;
      get_flipped(): boolean;
      set_flipped(value: boolean): void;
      get_reversed(): boolean;
      set_reversed(value: boolean): void;
      get_rotateAngle(): number;
      set_rotateAngle(value: number): void;
      get_offsetX(): number;
      set_offsetX(value: number): void;
      get_offsetY(): number;
      set_offsetY(value: number): void;
      get_scale(): number;
      zoom(sizeMode: MedicalViewerSizeMode, scaleFactor: number): void;
      get_scaleMode(): MedicalViewerSizeMode;
      reset(): void;
      get_useDPI(): boolean;
      set_useDPI(value: boolean): void;
      add_imageDataError(value: lt.LeadEventHandler): void;
      remove_imageDataError(value: lt.LeadEventHandler): void;
      add_previewError(value: lt.LeadEventHandler): void;
      remove_previewError(value: lt.LeadEventHandler): void;
      add_previewLoaded(value: lt.LeadEventHandler): void;
      remove_previewLoaded(value: lt.LeadEventHandler): void;
      add_imageDrawn(value: lt.LeadEventHandler): void;
      remove_imageDrawn(value: lt.LeadEventHandler): void;
      setPNGDataSrc(src: string, width: number, height: number): void;
      get_isFullImageReceived(): boolean;
      get_isPNGDataReady(): boolean;
      get_preview16BitPNG(): string;
      set_preview16BitPNG(value: string): void;
      get_drawingCanvas(): HTMLCanvasElement;
      get_pngDataSrc(): string;
      get_imageData(): number[];
      set_imageData(value: number[]): void;
      get_previewImage(): HTMLImageElement;
      set_previewImage(value: HTMLImageElement): void;
      get_requestInterval(): number;
      set_requestInterval(value: number): void;
      get_dataSize(): lt.LeadSizeD;
      set_dataSize(value: lt.LeadSizeD): void;
      get_imageURL(): string;
      get_wlData(): WindowLevelData;
      get_userData(): any;
      set_userData(value: any): void;
      dispose(): void;
      get_isDataReady(): boolean;
      get_information(): DICOMImageInformation;
      set_information(value: DICOMImageInformation): void;
      get_imagePosition(): number[];
      set_imagePosition(value: number[]): void;
      get_imageOrientation(): number[];
      set_imageOrientation(value: number[]): void;
      isImageDataAvailable(): boolean;
      get_wlRenderer(): DICOMImageInformationRenderer;
      get_width(): number;
      set_width(value: number): void;
      get_height(): number;
      set_height(value: number): void;
      get_rowSpacing(): number;
      set_rowSpacing(value: number): void;
      get_columnSpacing(): number;
      set_columnSpacing(value: number): void;
      get_projectionOrientation(): ProjectionOrientationType;
      set_projectionOrientation(value: ProjectionOrientationType): void;
      get_patientProjection(): string[];
      set_patientProjection(value: string[]): void;
      get_instanceNumber(): number;
      set_instanceNumber(value: number): void;
      get_bitPerpixel(): number;
      set_bitPerpixel(value: number): void;
      get_defaultWindowLevelWidth(): number;
      get_defaultWindowLevelCenter(): number;
      setWindowLevelDefaultValues(width: number, center: number): void;
      get_windowWidth(): number;
      get_windowCenter(): number;
      setWindowLevel(width: number, center: number): void;
      get_minValue(): number;
      set_minValue(value: number): void;
      get_maxValue(): number;
      set_maxValue(value: number): void;
      get_lowBit(): number;
      set_lowBit(value: number): void;
      get_highBit(): number;
      add_imageDataReady(value: lt.LeadEventHandler): void;
      remove_imageDataReady(value: lt.LeadEventHandler): void;
      get_dataModified(): boolean;
      set_dataModified(value: boolean): void;
      get_blob(): number[];
      set_blob(value: number[]): void;
      get_laterality(): string;
      set_laterality(value: string): void;
      get_viewPosition(): string;
      set_viewPosition(value: string): void;
      get_JSON(): any;
      set_JSON(value: any): void;
      get_imageProcessingList(): lt.LeadCollection;
      getPreviewCanvas(): HTMLCanvasElement;
      get_verticalAlignment(): VerticalAlignmentType;
      set_verticalAlignment(value: VerticalAlignmentType): void;
      get_horizontalAlignment(): HorizontalAlignmentType;
      set_horizontalAlignment(value: HorizontalAlignmentType): void;
      get_backgroundSize(): lt.LeadSizeD;
      set_backgroundSize(value: lt.LeadSizeD): void;
      get_mrtiInfo(): MRTIImage;
      set_mrtiInfo(value: MRTIImage): void;
      get_retakeIndex(): number;
      set_retakeIndex(value: number): void;
      get_nFrame(): Frame;
      get_retakes(): lt.LeadCollection;
      get_subCell(): SubCell;
      get_shutter(): ShutterObject;
      get_imageQuality(): string;
      get_container(): lt.Annotations.Engine.AnnContainer;
      get_enableDraw(): boolean;
      set_enableDraw(value: boolean): void;
      get_parentCell(): Cell;
      get_targetOrientation(): string[];
      set_targetOrientation(value: string[]): void;
      get_inverted(): boolean;
      set_inverted(value: boolean): void;
      constructor(parent: Cell);
      dataModified: boolean;
      blob: number[];
      laterality: string;
      viewPosition: string;
      JSON: any;
      imageProcessingList: lt.LeadCollection; // read-only
      verticalAlignment: VerticalAlignmentType;
      horizontalAlignment: HorizontalAlignmentType;
      backgroundSize: lt.LeadSizeD;
      mrtiInfo: MRTIImage;
      retakeIndex: number;
      nFrame: Frame;
      retakes: lt.LeadCollection;
      subCell: SubCell; // read-only
      shutter: ShutterObject; // read-only
      imageQuality: string; // read-only
      container: lt.Annotations.Engine.AnnContainer; // read-only
      enableDraw: boolean;
      parentCell: Cell; // read-only
      targetOrientation: string[];
      inverted: boolean;
      wlData: WindowLevelData; // read-only
      userData: any;
      isDataReady: boolean;
      information: DICOMImageInformation;
      imagePosition: number[];
      imageOrientation: number[];
      wlRenderer: DICOMImageInformationRenderer;
      width: number;
      height: number;
      rowSpacing: number;
      columnSpacing: number;
      projectionOrientation: ProjectionOrientationType;
      patientProjection: string[];
      instanceNumber: number;
      bitPerpixel: number;
      defaultWindowLevelWidth: number; // read-only
      defaultWindowLevelCenter: number; // read-only
      windowWidth: number; // read-only
      windowCenter: number; // read-only
      minValue: number;
      maxValue: number;
      lowBit: number;
      highBit: number;
      bitStored: number;
      rescaleintercept: number;
      rescaleSlope: number;
      voiLUTSequence: number[];
      imageType: string[];
      lossyCompression: boolean;
      isWaveForm: boolean;
      frameOfReferenceID: string;
      photometricInterpretation: string;
      flipped: boolean;
      reversed: boolean;
      rotateAngle: number;
      offsetX: number;
      offsetY: number;
      scale: number;
      scaleMode: MedicalViewerSizeMode; // read-only
      useDPI: boolean;
      isFullImageReceived: boolean; // read-only
      isPNGDataReady: boolean; // read-only
      preview16BitPNG: string;
      drawingCanvas: HTMLCanvasElement; // read-only
      pngDataSrc: string; // read-only
      imageData: number[];
      previewImage: HTMLImageElement;
      requestInterval: number;
      dataSize: lt.LeadSizeD;
      imageURL: string;
      previewURI: string;
      imageDataReady: lt.LeadEventType; // read-only
      imageDataError: lt.LeadEventType; // read-only
      previewError: lt.LeadEventType; // read-only
      previewLoaded: lt.LeadEventType; // read-only
      imageDrawn: lt.LeadEventType; // read-only
      lowResImage: ChunkData;
      thumbnailImage: ChunkData;
   }

   enum OverlayTextType {
      windowLevel = 0,
      instanceNumber = 1,
      userData = 2,
      imageQuality = 3,
      frameNumber = 4,
      leftOrientation = 5,
      rightOrientation = 6,
      topOrientation = 7,
      bottomOrientation = 8,
      mprType = 9,
      retakeImage = 10,
      laterality = 11,
      fieldOfView = 12
   }

   enum OverlayAlignment {
      topLeft = 0,
      topRight = 1,
      bottomLeft = 2,
      bottomRight = 3,
      centerTop = 4,
      centerLeft = 5,
      centerRight = 6,
      centerBottom = 7,
      none = -1
   }

   class OverlayText {
      get_text(): string;
      set_text(value: string): void;
      get_positionIndex(): number;
      set_positionIndex(value: number): void;
      get_alignment(): OverlayAlignment;
      set_alignment(value: OverlayAlignment): void;
      get_type(): OverlayTextType;
      set_type(value: OverlayTextType): void;
      get_color(): string;
      set_color(value: string): void;
      get_weight(): number;
      set_weight(value: number): void;
      constructor();
      text: string;
      positionIndex: number;
      alignment: OverlayAlignment;
      type: OverlayTextType;
      color: string;
      weight: number;
   }

   class Tools {
      static resetCanvas(canvas: HTMLCanvasElement): void;
      static getSizeRatio(item: lt.Controls.ImageViewerItem): lt.LeadSizeD;
      static logicalToPhysicalValue(item: lt.Controls.ImageViewerItem, value: number): number;
      static logicalToPhysical(item: lt.Controls.ImageViewerItem, point: lt.LeadPointD): lt.LeadPointD;
      static physicalToLogical(item: lt.Controls.ImageViewerItem, point: lt.LeadPointD): lt.LeadPointD;
      constructor();
      static pointerdown: string;
      static pointerup: string;
      static pointercancel: string;
      static pointermove: string;
   }

   class ActionCommand {
      get_linked(): lt.LeadCollection;
      set_linked(value: lt.LeadCollection): void;
      get_parent(): Cell;
      set_parent(value: Cell): void;
      get_viewer(): lt.Controls.ImageViewer;
      get_button(): lt.Controls.MouseButtons;
      set_button(value: lt.Controls.MouseButtons): void;
      dispose(item: any): void;
      get_isStarted(): boolean;
      init(): any;
      start(actionObject: any): void;
      constructor();
      linked: lt.LeadCollection;
      parent: Cell;
      viewer: lt.Controls.ImageViewer;
      button: lt.Controls.MouseButtons;
      isStarted: boolean;
   }

   class OffsetAction extends ActionCommand {
      init(): any;
      start(actionObject: any): void;
      dispose(item: any): void;
      constructor();
   }

   class LineProfileAction extends ActionCommand {
      init(): any;
      start(actionObject: any): void;
      dispose(item: any): void;
      constructor();
   }

   class TransformItemAction extends ActionCommand {
      init(): any;
      start(actionObject: any): void;
      dispose(item: any): void;
      constructor(cell: Cell);
   }

   class ScaleAction extends ActionCommand {
      init(): any;
      start(actionObject: any): void;
      dispose(item: any): void;
      constructor();
   }

   class MagnifyAction extends ActionCommand {
      init(): any;
      start(actionObject: any): void;
      constructor();
   }

   class LeadPoint3D {
      get_x(): number;
      set_x(value: number): void;
      get_y(): number;
      set_y(value: number): void;
      get_z(): number;
      set_z(value: number): void;
      static create(x: number, y: number, z: number): LeadPoint3D;
      static get_empty(): LeadPoint3D;
      clone(): LeadPoint3D;
      constructor(x: number, y: number, z: number);
      x: number;
      y: number;
      z: number;
      static empty: LeadPoint3D; // read-only
   }

   class CrossHairAction extends ActionCommand {
      init(): any;
      start(actionObject: any): void;
      constructor();
   }

   class ProbeToolAction extends ActionCommand {
      add_probeToolUpdated(value: ProbeToolEventHandler): void;
      remove_probeToolUpdated(value: ProbeToolEventHandler): void;
      init(): any;
      get_interactiveObject(): ProbeToolInteractiveMode;
      start(actionObject: any): void;
      constructor();
      interactiveObject: ProbeToolInteractiveMode; // read-only
      probeToolUpdated: ProbeToolEventType; // read-only
   }

   class SpyGlassAction extends MagnifyAction {
      add_imageRequested(value: SpyGlassEventHandler): void;
      remove_imageRequested(value: SpyGlassEventHandler): void;
      add_workCompleted(value: SpyGlassEventHandler): void;
      remove_workCompleted(value: SpyGlassEventHandler): void;
      add_positionChanged(value: SpyGlassPositionChangedEventHandler): void;
      remove_positionChanged(value: SpyGlassPositionChangedEventHandler): void;
      add_chunkLoaded(value: ChunkLoadedEventHandler): void;
      remove_chunkLoaded(value: ChunkLoadedEventHandler): void;
      get_tiling(): boolean;
      set_tiling(value: boolean): void;
      get_resizeGlassOnScroll(): boolean;
      set_resizeGlassOnScroll(value: boolean): void;
      init(): any;
      start(actionObject: any): void;
      constructor();
      tiling: boolean;
      resizeGlassOnScroll: boolean;
      imageRequested: SpyGlassEventType; // read-only
      workCompleted: SpyGlassEventType; // read-only
      positionChanged: SpyGlassPositionChangedEventType; // read-only
      chunkLoaded: ChunkLoadedEventType; // read-only
   }

   class StackAction extends ActionCommand {
      add_stackChanged(value: StackChangedEventHandler): void;
      remove_stackChanged(value: StackChangedEventHandler): void;
      get_enableWheel(): boolean;
      set_enableWheel(value: boolean): void;
      init(): any;
      start(actionObject: any): void;
      constructor();
      enableWheel: boolean;
      stackChanged: StackChangedEventType; // read-only
   }

   interface StackChangedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: StackChangedEventArgs): void;
   }

   class StackChangedEventType extends lt.LeadEvent {
      add(value: StackChangedEventHandler): StackChangedEventHandler;
      remove(value: StackChangedEventHandler): void;
   }

   class StackChangedEventArgs extends lt.LeadEventArgs {
      get_scroll(): boolean;
      set_scroll(value: boolean): void;
      get_scrollDelta(): number;
      set_scrollDelta(value: number): void;
      constructor(scrollDelta: number);
      scroll: boolean;
      scrollDelta: number;
   }

   class StackInteractiveMode extends lt.Controls.ImageViewerInteractiveMode {
      loadImages(cell: Cell): void;
      get_id(): number;
      get_enableWheel(): boolean;
      set_enableWheel(value: boolean): void;
      start(viewer: lt.Controls.ImageViewer): void;
      stop(viewer: lt.Controls.ImageViewer): void;
      add_stackChanged(value: StackChangedEventHandler): void;
      remove_stackChanged(value: StackChangedEventHandler): void;
      get_name(): string;
      constructor();
      id: number; // read-only
      enableWheel: boolean;
      name: string; // read-only
      stackChanged: StackChangedEventType; // read-only
   }

   class WindowLevelAction extends ActionCommand {
      init(): any;
      dispose(item: any): void;
      start(actionObject: any): void;
      constructor();
   }

   class AutomationInteractiveAction extends ActionCommand {
      init(): any;
      get_objectID(): number;
      set_objectID(value: number): void;
      start(actionObject: any): void;
      constructor(objectID: number);
      objectID: number;
   }

   class CobbAngle {
      add_cobbAngleChanged(value: lt.LeadEventHandler): void;
      remove_cobbAngleChanged(value: lt.LeadEventHandler): void;
      dispose(): void;
      get_line1(): lt.Annotations.Engine.AnnPolylineObject;
      set_line1(value: lt.Annotations.Engine.AnnPolylineObject): void;
      get_line2(): lt.Annotations.Engine.AnnPolylineObject;
      set_line2(value: lt.Annotations.Engine.AnnPolylineObject): void;
      get_angle(): number;
      get_backgroundColor(): string;
      set_backgroundColor(value: string): void;
      get_borderColor(): string;
      set_borderColor(value: string): void;
      draw(context: CanvasRenderingContext2D): void;
      constructor(automation: lt.Annotations.Automation.AnnAutomation, line1: lt.Annotations.Engine.AnnPolylineObject, line2: lt.Annotations.Engine.AnnPolylineObject);
      line1: lt.Annotations.Engine.AnnPolylineObject;
      line2: lt.Annotations.Engine.AnnPolylineObject;
      angle: number; // read-only
      backgroundColor: string;
      borderColor: string;
      cobbAngleChanged: lt.LeadEventType; // read-only
   }

   class ProgressLoading {
      get_visible(): boolean;
      set_visible(value: boolean): void;
      draw(context: CanvasRenderingContext2D, displayRect: lt.LeadRectD): void;
      setColor(r: number, g: number, b: number): void;
      set_totalFrames(value: number): void;
      get_totalFrames(): number;
      set_progressPercent(value: number): void;
      get_progressPercent(): number;
      set_progress(value: number): void;
      get_progress(): number;
      constructor(cell: Cell);
      visible: boolean;
      totalFrames: number;
      progressPercent: number;
      progress: number;
   }

   class LineProfileObject {
      get_histogramMarker(): number;
      set_histogramMarker(value: number): void;
      end(): void;
      refresh(): void;
      beginUpdate(): void;
      endUpdate(): void;
      get_logicalStartPoint(): lt.LeadPointD;
      set_logicalStartPoint(value: lt.LeadPointD): void;
      get_logicalEndPoint(): lt.LeadPointD;
      set_logicalEndPoint(value: lt.LeadPointD): void;
      get_physicalStartPoint(): lt.LeadPointD;
      set_physicalStartPoint(value: lt.LeadPointD): void;
      get_physicalEndPoint(): lt.LeadPointD;
      set_physicalEndPoint(value: lt.LeadPointD): void;
      attachFrame(frame: Frame): void;
      add_histogramGenerated(value: HistogramGeneratedEventHandler): void;
      remove_histogramGenerated(value: HistogramGeneratedEventHandler): void;
      draw(context: CanvasRenderingContext2D): void;
      get_histogramColorType(): ColorType;
      set_histogramColorType(value: ColorType): void;
      constructor();
      histogramMarker: number;
      logicalStartPoint: lt.LeadPointD;
      logicalEndPoint: lt.LeadPointD;
      physicalStartPoint: lt.LeadPointD;
      physicalEndPoint: lt.LeadPointD;
      histogramColorType: ColorType;
      histogramGenerated: HistogramGeneratedEventType; // read-only
   }

   class ShutterObject {
      static isValid(annotationobject: lt.Annotations.Engine.AnnObject): boolean;
      get_objects(): lt.LeadCollection;
      set_objects(value: lt.LeadCollection): void;
      get_visible(): boolean;
      set_visible(value: boolean): void;
      attach(item: lt.Controls.ImageViewerItem): void;
      onSizeChanged(): void;
      updateView(): void;
      get_fillStyle(): string;
      set_fillStyle(value: string): void;
      constructor(frame: Frame, automation: lt.Annotations.Automation.AnnAutomation);
      objects: lt.LeadCollection;
      visible: boolean;
      fillStyle: string;
   }

   interface SpyGlassPositionChangedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: SpyGlassPositionChangedEventArgs): void;
   }

   class SpyGlassPositionChangedEventType extends lt.LeadEvent {
      add(value: SpyGlassPositionChangedEventHandler): SpyGlassPositionChangedEventHandler;
      remove(value: SpyGlassPositionChangedEventHandler): void;
   }

   class SpyGlassPositionChangedEventArgs extends lt.LeadEventArgs {
      get_chunkList(): ChunkData[];
      get_displayRect(): lt.LeadRectD;
      get_canvas(): HTMLCanvasElement;
      get_inputCanvas(): HTMLCanvasElement;
      get_subCell(): SubCell;
      constructor(canvas: HTMLCanvasElement, inputCanvas: HTMLCanvasElement, displayRect: lt.LeadRectD, subCell: SubCell, chunkList: ChunkData[]);
      chunkList: ChunkData[]; // read-only
      displayRect: lt.LeadRectD; // read-only
      canvas: HTMLCanvasElement; // read-only
      inputCanvas: HTMLCanvasElement; // read-only
      subCell: SubCell; // read-only
   }

   interface SpyGlassEventHandler extends lt.LeadEventHandler {
      (sender: any, e: SpyGlassEventArgs): void;
   }

   class SpyGlassEventType extends lt.LeadEvent {
      add(value: SpyGlassEventHandler): SpyGlassEventHandler;
      remove(value: SpyGlassEventHandler): void;
   }

   class SpyGlassEventArgs extends lt.LeadEventArgs {
      get_inputCanvas(): HTMLCanvasElement;
      set_inputCanvas(value: HTMLCanvasElement): void;
      get_canvas(): HTMLCanvasElement;
      set_canvas(value: HTMLCanvasElement): void;
      get_userData(): any;
      set_userData(value: any): void;
      constructor(inputCanvas: HTMLCanvasElement, canvas: HTMLCanvasElement, userData: any);
      inputCanvas: HTMLCanvasElement;
      canvas: HTMLCanvasElement;
      userData: any;
   }

   class MedicalSpyGlassInteractiveMode extends lt.Controls.ImageViewerMagnifyGlassInteractiveMode {
      get_resizeGlassOnScroll(): boolean;
      set_resizeGlassOnScroll(value: boolean): void;
      add_imageRequested(value: SpyGlassEventHandler): void;
      remove_imageRequested(value: SpyGlassEventHandler): void;
      add_positionChanged(value: SpyGlassPositionChangedEventHandler): void;
      remove_positionChanged(value: SpyGlassPositionChangedEventHandler): void;
      refresh(): void;
      dispose(): void;
      start(viewer: lt.Controls.ImageViewer): void;
      stop(viewer: lt.Controls.ImageViewer): void;
      get_scale(): number;
      set_scale(value: number): void;
      get_text(): string;
      set_text(value: string): void;
      get_showOverlayText(): boolean;
      set_showOverlayText(value: boolean): void;
      get_name(): string;
      constructor();
      resizeGlassOnScroll: boolean;
      scale: number;
      text: string;
      showOverlayText: boolean;
      name: string; // read-only
      imageRequested: SpyGlassEventType; // read-only
      positionChanged: SpyGlassPositionChangedEventType; // read-only
      tiling: boolean;
   }

   interface ProbeToolEventHandler extends lt.LeadEventHandler {
      (sender: any, e: ProbeToolEventArgs): void;
   }

   class ProbeToolEventType extends lt.LeadEvent {
      add(value: ProbeToolEventHandler): ProbeToolEventHandler;
      remove(value: ProbeToolEventHandler): void;
   }

   class ProbeToolEventArgs extends lt.LeadEventArgs {
      get_position(): lt.LeadPointD;
      get_pixelValue(): string;
      set_pixelValue(value: string): void;
      get_target(): Frame;
      constructor(position: lt.LeadPointD, target: Frame);
      position: lt.LeadPointD; // read-only
      pixelValue: string;
      target: Frame; // read-only
   }

   class ProbeToolInteractiveMode extends lt.Controls.ImageViewerInteractiveMode {
      dispose(): void;
      get_id(): number;
      start(viewer: lt.Controls.ImageViewer): void;
      stop(viewer: lt.Controls.ImageViewer): void;
      add_probeToolUpdated(value: ProbeToolEventHandler): void;
      remove_probeToolUpdated(value: ProbeToolEventHandler): void;
      get_backgroundColor(): string;
      set_backgroundColor(value: string): void;
      get_textColor(): string;
      set_textColor(value: string): void;
      get_showBorder(): boolean;
      set_showBorder(value: boolean): void;
      get_name(): string;
      static getPixelValue(frame: Frame, x: number, y: number): number[];
      static getHuFromData(info: DICOMImageInformation, data: number): number;
      static getHuValue(frame: Frame, x: number, y: number, data: number): string;
      constructor(cell: Cell);
      id: number; // read-only
      backgroundColor: string;
      textColor: string;
      showBorder: boolean;
      name: string; // read-only
      probeToolUpdated: ProbeToolEventType; // read-only
   }

   enum ColorType {
      auto = 0,
      RGB = 1,
      gray = 2
   }

   interface HistogramGeneratedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: HistogramGeneratedEventArgs): void;
   }

   class HistogramGeneratedEventType extends lt.LeadEvent {
      add(value: HistogramGeneratedEventHandler): HistogramGeneratedEventHandler;
      remove(value: HistogramGeneratedEventHandler): void;
   }

   class HistogramGeneratedEventArgs extends lt.LeadEventArgs {
      get_histogram(): number[];
      get_frame(): Frame;
      get_type(): ColorType;
      constructor(histogram: number[], frame: Frame, type: ColorType);
      histogram: number[]; // read-only
      frame: Frame; // read-only
      type: ColorType; // read-only
   }

   class LineProfileInteractiveMode extends lt.Controls.ImageViewerInteractiveMode {
      refresh(cell: Cell): void;
      get_name(): string;
      get_id(): number;
      start(viewer: lt.Controls.ImageViewer): void;
      stop(viewer: lt.Controls.ImageViewer): void;
      get_histogramMarker(): number;
      set_histogramMarker(value: number): void;
      get_histogramColorType(): ColorType;
      set_histogramColorType(value: ColorType): void;
      constructor();
      name: string; // read-only
      id: number; // read-only
      histogramMarker: number;
      histogramColorType: ColorType;
   }

   class TransformItemInteractiveMode extends lt.Controls.ImageViewerInteractiveMode {
      get_id(): number;
      get_name(): string;
      start(viewer: lt.Controls.ImageViewer): void;
      stop(viewer: lt.Controls.ImageViewer): void;
      constructor(cell: Cell);
      id: number; // read-only
      name: string; // read-only
   }

   enum PlayingDirection {
      forward = 0,
      backward = 1,
      shuffle = 2,
      sweep = 3
   }

   interface FrameChangedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: FrameChangedEventArgs): void;
   }

   class FrameChangedEventType extends lt.LeadEvent {
      add(value: FrameChangedEventHandler): FrameChangedEventHandler;
      remove(value: FrameChangedEventHandler): void;
   }

   class FrameChangedEventArgs extends lt.LeadEventArgs {
      get_frameIndex(): number;
      constructor(frameIndex: number);
      frameIndex: number; // read-only
   }

   class CinePlayer {
      get_isPlaying(): boolean;
      get_currentFrame(): number;
      set_currentFrame(value: number): void;
      get_FPS(): number;
      set_FPS(value: number): void;
      get_loop(): boolean;
      set_loop(value: boolean): void;
      get_direction(): PlayingDirection;
      set_direction(value: PlayingDirection): void;
      get_maxSkip(): number;
      set_maxSkip(value: number): void;
      add_frameChanged(value: FrameChangedEventHandler): void;
      remove_frameChanged(value: FrameChangedEventHandler): void;
      dispose(): void;
      play(): void;
      stop(): void;
      constructor(cell: Cell);
      isPlaying: boolean; // read-only
      currentFrame: number;
      FPS: number;
      loop: boolean;
      direction: PlayingDirection;
      maxSkip: number;
      frameChanged: FrameChangedEventType; // read-only
   }

   class Cursor3DInteractiveMode extends lt.Controls.ImageViewerInteractiveMode {
      get_id(): number;
      start(viewer: lt.Controls.ImageViewer): void;
      stop(viewer: lt.Controls.ImageViewer): void;
      static get3DPointPosition(frame: Frame, point: lt.LeadPointD): number[];
      get_scroll(): boolean;
      set_scroll(value: boolean): void;
      get_name(): string;
      constructor();
      id: number; // read-only
      scroll: boolean;
      name: string; // read-only
   }

   class Cursor3DAction extends ActionCommand {
      init(): any;
      get_scroll(): boolean;
      set_scroll(value: boolean): void;
      start(actionObject: any): void;
      constructor();
      scroll: boolean;
   }

   class MagnifyGlassInteractiveMode extends lt.Controls.ImageViewerMagnifyGlassInteractiveMode {
      get_resizeGlassOnScroll(): boolean;
      set_resizeGlassOnScroll(value: boolean): void;
      refresh(): void;
      dispose(): void;
      start(viewer: lt.Controls.ImageViewer): void;
      stop(viewer: lt.Controls.ImageViewer): void;
      add_positionChanged(value: lt.Controls.InteractiveDragEventHandler): void;
      remove_positionChanged(value: lt.Controls.InteractiveDragEventHandler): void;
      get_scale(): number;
      set_scale(value: number): void;
      get_name(): string;
      constructor();
      resizeGlassOnScroll: boolean;
      scale: number;
      name: string; // read-only
      positionChanged: lt.Controls.InteractiveDragEventType; // read-only
   }

   enum VolumeType {
      VRT = 0,
      SSD = 1,
      MIP = 2,
      MPR = 3,
      minIP = 4
   }

   enum Interactive3DAction {
      offset = 0,
      scale = 1,
      windowLevel = 2,
      rotate3D = 3
   }

   class MPRVolumeProperties {
      get_enableCrossLines(): boolean;
      set_enableCrossLines(value: boolean): void;
      get_axialPosition(): number;
      set_axialPosition(value: number): void;
      get_sagittalPosition(): number;
      set_sagittalPosition(value: number): void;
      get_coronalPosition(): number;
      set_coronalPosition(value: number): void;
      constructor(parent: Cell3D);
      enableCrossLines: boolean;
      axialPosition: number;
      sagittalPosition: number;
      coronalPosition: number;
   }

   class VolumeProperties {
      get_enableClippingFrame(): boolean;
      set_enableClippingFrame(value: boolean): void;
      get_lowResQuality(): number;
      set_lowResQuality(value: number): void;
      constructor(parent: Cell3D);
      enableClippingFrame: boolean;
      lowResQuality: number;
   }

   enum ProjectionMethod {
      orthogonal = 0,
      perspective = 1
   }

   enum OrientationFace {
      right = 0,
      left = 1,
      posterior = 2,
      anterior = 3,
      superior = 4,
      inferior = 5,
      reset = -1
   }

   enum Object3DStatus {
      notInitialized = 0,
      loading = 1,
      ready = 2,
      error = 3
   }

   class Object3DEngine {
      add_request3DData(value: Request3DDataEventHandler): void;
      remove_request3DData(value: Request3DDataEventHandler): void;
      add_statusChanged(value: StatusChangedEventHandler): void;
      remove_statusChanged(value: StatusChangedEventHandler): void;
      add_object3DReady(value: lt.LeadEventHandler): void;
      remove_object3DReady(value: lt.LeadEventHandler): void;
      add_progressUpdated(value: lt.LeadEventHandler): void;
      remove_progressUpdated(value: lt.LeadEventHandler): void;
      get_status(): Object3DStatus;
      set_status(value: Object3DStatus): void;
      get_errorMessage(): string;
      set_errorMessage(value: string): void;
      getSettings(json: string): void;
      setSettings(json: string): void;
      get_volumeReady(): boolean;
      get_id(): string;
      set_id(value: string): void;
      start(extraCriteria: string, studyInstanceUID: string, seriesInstanceUID: string): void;
      get_URL(): string;
      set_URL(value: string): void;
      renderPanoramic(cell: PanoramicCell, polygon: PanoramicPolygon): void;
      render3D(url: string): void;
      get_progress(): number;
      set_progress(value: number): void;
      invalidate(): void;
      static canDo3D(cell: Cell): CanDo3DStatus;
      requestImage(): void;
      end(): void;
      drawProgress(div: HTMLDivElement, context: CanvasRenderingContext2D): void;
      constructor(id: string);
      status: Object3DStatus;
      errorMessage: string;
      volumeReady: boolean; // read-only
      id: string;
      URL: string;
      progress: number;
      request3DData: Request3DDataEventType; // read-only
      statusChanged: StatusChangedEventType; // read-only
      object3DReady: lt.LeadEventType; // read-only
      progressUpdated: lt.LeadEventType; // read-only
   }

   class STLCell extends Series {
      add_render(value: lt.LeadEventHandler): void;
      remove_render(value: lt.LeadEventHandler): void;
      dispose(): void;
      load(fileName: string): void;
      get_outputCanvas(): HTMLCanvasElement;
      set_outputCanvas(value: HTMLCanvasElement): void;
      onSizeChanged(): void;
      invalidate(): void;  // protected
      constructor(viewer: MedicalViewer, path: string, divID: string);
      outputCanvas: HTMLCanvasElement;
      render: lt.LeadEventType; // read-only
   }

   class Cell3D extends Series {
      add_cellClicked(value: lt.Controls.InteractiveEventHandler): void;
      remove_cellClicked(value: lt.Controls.InteractiveEventHandler): void;
      get_object3D(): Object3DEngine;
      set_object3D(value: Object3DEngine): void;
      get_referenceCell(): Cell;
      set_referenceCell(value: Cell): void;
      get_orientation(): OrientationFace;
      set_orientation(value: OrientationFace): void;
      updateWindowLevelValues(): void;
      set_information(value: WindowLevelInfomation): void;
      get_information(): WindowLevelInfomation;
      get_JSON(): any;
      set_JSON(value: any): void;
      get_projection(): ProjectionMethod;
      set_projection(value: ProjectionMethod): void;
      get_showRotationCube(): boolean;
      set_showRotationCube(value: boolean): void;
      get_showVolumeBorder(): boolean;
      set_showVolumeBorder(value: boolean): void;
      get_volume(): VolumeProperties;
      get_MPR(): MPRVolumeProperties;
      get_defaultWindowLevelWidth(): number;
      get_defaultWindowLevelCenter(): number;
      add_volumeTypeChanged(value: lt.LeadEventHandler): void;
      remove_volumeTypeChanged(value: lt.LeadEventHandler): void;
      get_volumeType(): VolumeType;
      set_volumeType(value: VolumeType): void;
      start(extraCriteria: string): void;
      onInvertChanged(): void;  // protected
      invalidate(): void;  // protected
      updateView(): void;
      refresh(): void;
      endUpdate(): void;
      get_name(): string;
      get_sensitivity(): number;
      set_sensitivity(value: number): void;
      get_resizeFactor(): number;
      set_resizeFactor(value: number): void;
      benchmark(): void;
      get_actions(): { [key: number]: Interactive3DAction };
      get_URL(): string;
      set_URL(value: string): void;
      get_image(): HTMLImageElement;
      onSizeChanged(): void;
      dispose(): void;
      get_overlayTextVisible(): boolean;
      set_overlayTextVisible(value: boolean): void;
      reset(): void;
      constructor(viewer: MedicalViewer, divID: string);
      object3D: Object3DEngine;
      referenceCell: Cell;
      orientation: OrientationFace;
      information: WindowLevelInfomation;
      JSON: any;
      projection: ProjectionMethod;
      showRotationCube: boolean;
      showVolumeBorder: boolean;
      volume: VolumeProperties; // read-only
      MPR: MPRVolumeProperties; // read-only
      defaultWindowLevelWidth: number; // read-only
      defaultWindowLevelCenter: number; // read-only
      volumeType: VolumeType;
      name: string; // read-only
      sensitivity: number;
      resizeFactor: number;
      actions: { [key: number]: Interactive3DAction }; // read-only
      URL: string;
      image: HTMLImageElement; // read-only
      overlayTextVisible: boolean;
      cellClicked: lt.Controls.InteractiveEventType; // read-only
      volumeTypeChanged: lt.LeadEventType; // read-only
   }

   class Drawable {
      get_userData(): any;
      set_userData(value: any): void;
      beginUpdate(): void;
      endUpdate(): void;
      canUpdate(): boolean;
      refresh(): void;
      draw(item: lt.Controls.ImageViewerItem, context: CanvasRenderingContext2D, rect: lt.LeadRectD): void;
      get_visible(): boolean;
      set_visible(value: boolean): void;
      get_activeItem(): boolean;
      set_activeItem(value: boolean): void;
      hitTest(item: lt.Controls.ImageViewerItem, x: number, y: number): boolean;
      handleDragStarted(item: lt.Controls.ImageViewerItem, x: number, y: number, args: lt.Controls.InteractiveDragStartedEventArgs): void;
      handleDragDelta(x: number, y: number, args: lt.Controls.InteractiveDragDeltaEventArgs): void;
      handleDragCompleted(x: number, y: number, args: lt.Controls.InteractiveDragCompletedEventArgs): void;
      handleDoubleTap(item: lt.Controls.ImageViewerItem, x: number, y: number, args: lt.Controls.InteractiveEventArgs): void;
      handleMove(item: lt.Controls.ImageViewerItem, x: number, y: number, args: lt.Controls.InteractiveEventArgs): void;
      constructor();
      userData: any;
      visible: boolean;
      activeItem: boolean;
   }

   enum PolygonPart {
      none = 0,
      handle = 1,
      line = 2,
      thickness = 4
   }

   interface PolygonEditEventHandler extends lt.LeadEventHandler {
      (sender: any, e: PolygonEditEventArgs): void;
   }

   class PolygonEditEventType extends lt.LeadEvent {
      add(value: PolygonEditEventHandler): PolygonEditEventHandler;
      remove(value: PolygonEditEventHandler): void;
   }

   class PolygonEditEventArgs extends lt.Controls.InteractiveEventArgs {
      get_index(): number;
      get_part(): PolygonPart;
      constructor(part: PolygonPart, index: number, x: number, y: number, button: lt.Controls.MouseButtons);
      index: number; // read-only
      part: PolygonPart; // read-only
   }

   enum PanoramicPolygonState {
      draw = 0,
      edit = 1
   }

   class PanoramicPolygon extends Drawable {
      get_paraxialSlices(): lt.LeadCollection;
      createSlice(item: lt.Controls.ImageViewerItem, point: lt.LeadPointD, length: number, lineIndex: number): Slice;
      add_clicked(value: lt.Controls.InteractiveEventHandler): void;
      remove_clicked(value: lt.Controls.InteractiveEventHandler): void;
      get_thickness(): number;
      set_thickness(value: number): void;
      get_angle(): number;
      set_angle(value: number): void;
      get_type(): VolumeType;
      set_type(value: VolumeType): void;
      refresh(): void;
      get_state(): PanoramicPolygonState;
      set_state(value: PanoramicPolygonState): void;
      get_currentPoint(): lt.LeadPointD;
      set_currentPoint(value: lt.LeadPointD): void;
      get_points(): lt.LeadPointD[];
      handleMove(item: lt.Controls.ImageViewerItem, x: number, y: number, args: lt.Controls.InteractiveEventArgs): void;
      handleDoubleTap(item: lt.Controls.ImageViewerItem, x: number, y: number, args: lt.Controls.InteractiveEventArgs): void;
      handleDragStarted(item: lt.Controls.ImageViewerItem, x: number, y: number, e: lt.Controls.InteractiveDragStartedEventArgs): void;
      handleDragDelta(x: number, y: number, args: lt.Controls.InteractiveDragDeltaEventArgs): void;
      handleDragCompleted(x: number, y: number, args: lt.Controls.InteractiveDragCompletedEventArgs): void;
      add_panoramicUpdated(value: PanoramicChangedEventHandler): void;
      remove_panoramicUpdated(value: PanoramicChangedEventHandler): void;
      add_panoramicGenerated(value: PanoramicChangedEventHandler): void;
      remove_panoramicGenerated(value: PanoramicChangedEventHandler): void;
      dispose(): void;
      draw(item: lt.Controls.ImageViewerItem, context: CanvasRenderingContext2D, rect: lt.LeadRectD): void;
      get_visible(): boolean;
      set_visible(value: boolean): void;
      get_activeItem(): boolean;
      set_activeItem(value: boolean): void;
      get_hitTestResult(): PolygonPart;
      get_hitTestIndex(): number;
      hitTest(item: lt.Controls.ImageViewerItem, x: number, y: number): boolean;
      constructor(cell: Cell);
      paraxialSlices: lt.LeadCollection; // read-only
      thickness: number;
      angle: number;
      type: VolumeType;
      state: PanoramicPolygonState;
      currentPoint: lt.LeadPointD;
      points: lt.LeadPointD[]; // read-only
      visible: boolean;
      activeItem: boolean;
      hitTestResult: PolygonPart; // read-only
      hitTestIndex: number; // read-only
      clicked: lt.Controls.InteractiveEventType; // read-only
      panoramicUpdated: PanoramicChangedEventType; // read-only
      panoramicGenerated: PanoramicChangedEventType; // read-only
   }

   interface ChunkLoadedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: ChunkLoadedEventArgs): void;
   }

   class ChunkLoadedEventType extends lt.LeadEvent {
      add(value: ChunkLoadedEventHandler): ChunkLoadedEventHandler;
      remove(value: ChunkLoadedEventHandler): void;
   }

   class ChunkLoadedEventArgs extends lt.LeadEventArgs {
      get_chunk(): ChunkData;
      constructor(chunk: ChunkData);
      chunk: ChunkData; // read-only
   }

   interface FrameRequestedSrcEventHandler extends lt.LeadEventHandler {
      (sender: any, e: FrameRequestedSrcEventArgs): void;
   }

   class FrameRequestedSrcEventType extends lt.LeadEvent {
      add(value: FrameRequestedSrcEventHandler): FrameRequestedSrcEventHandler;
      remove(value: FrameRequestedSrcEventHandler): void;
   }

   class FrameRequestedSrcEventArgs extends lt.LeadEventArgs {
      get_frame(): Frame;
      get_src(): string;
      set_src(value: string): void;
      constructor(frame: Frame, src: string);
      frame: Frame; // read-only
      src: string;
   }

   class ChunkData {
      get_src(): string;
      set_src(value: string): void;
      get_canvas(): HTMLCanvasElement;
      set_canvas(value: HTMLCanvasElement): void;
      get_backCanvas(): HTMLCanvasElement;
      set_backCanvas(value: HTMLCanvasElement): void;
      get_resolution(): lt.LeadSizeD;
      set_resolution(value: lt.LeadSizeD): void;
      get_userData(): any;
      set_userData(value: any): void;
      get_rect(): lt.LeadRectD;
      set_rect(value: lt.LeadRectD): void;
      dispose(): void;
      equal(chunk: ChunkData): boolean;
      clone(): ChunkData;
      constructor(image: HTMLImageElement, rect: lt.LeadRectD, resolution: lt.LeadSizeD, canvas: HTMLCanvasElement);
      src: string;
      canvas: HTMLCanvasElement;
      backCanvas: HTMLCanvasElement;
      resolution: lt.LeadSizeD;
      userData: any;
      rect: lt.LeadRectD;
   }

   class MRTIImage {
      get_frameIndex(): number;
      set_frameIndex(value: number): void;
      get_imageUri(): string;
      set_imageUri(value: string): void;
      get_imageName(): string;
      set_imageName(value: string): void;
      get_mimeType(): string;
      set_mimeType(value: string): void;
      get_fullSize(): lt.LeadSizeD;
      set_fullSize(value: lt.LeadSizeD): void;
      get_fullDpi(): lt.LeadSizeD;
      set_fullDpi(value: lt.LeadSizeD): void;
      get_resolutions(): lt.LeadSizeD[];
      set_resolutions(value: lt.LeadSizeD[]): void;
      get_tileSize(): lt.LeadSizeD;
      set_tileSize(value: lt.LeadSizeD): void;
      get_supportWindowLevel(): boolean;
      set_supportWindowLevel(value: boolean): void;
      constructor();
      frameIndex: number;
      imageUri: string;
      imageName: string;
      mimeType: string;
      fullSize: lt.LeadSizeD;
      fullDpi: lt.LeadSizeD;
      resolutions: lt.LeadSizeD[];
      tileSize: lt.LeadSizeD;
      supportWindowLevel: boolean;
   }

   enum ProjectionOrientationType {
      none = 0,
      faceToFace = 1,
      faceToBack = 2
   }

   class StackSynchronization {
      static alignFrames(frameToAlign: Frame, referencePoint1: LeadPoint3D, cell: Cell, referencePoint2: LeadPoint3D): number;
      constructor();
   }

   interface PanoramicChangedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: PanoramicChangedEventArgs): void;
   }

   class PanoramicChangedEventType extends lt.LeadEvent {
      add(value: PanoramicChangedEventHandler): PanoramicChangedEventHandler;
      remove(value: PanoramicChangedEventHandler): void;
   }

   class PanoramicChangedEventArgs extends lt.LeadEventArgs {
      get_points(): lt.LeadPointD[];
      constructor(points: lt.LeadPointD[]);
      points: lt.LeadPointD[]; // read-only
   }

   class PanoramicAction extends ActionCommand {
      init(): any;
      start(actionObject: any): void;
      dispose(item: any): void;
      add_panoramicUpdated(value: PanoramicChangedEventHandler): void;
      remove_panoramicUpdated(value: PanoramicChangedEventHandler): void;
      add_panoramicGenerated(value: PanoramicChangedEventHandler): void;
      remove_panoramicGenerated(value: PanoramicChangedEventHandler): void;
      constructor(cell: Cell);
      panoramicUpdated: PanoramicChangedEventType; // read-only
      panoramicGenerated: PanoramicChangedEventType; // read-only
   }

   class LeadLine {
      constructor(x1: number, y1: number, x2: number, y2: number);
      point1: lt.LeadPointD;
      point2: lt.LeadPointD;
   }

   class ReferenceLine {
      static rotate(line: LeadLine, angle: number, width: number, height: number): LeadLine;
      static flip(line: LeadLine, width: number, height: number): LeadLine;
      static reverse(line: LeadLine, width: number, height: number): LeadLine;
      static draw(context: CanvasRenderingContext2D, displayRect: lt.LeadRectD, imageRect: lt.LeadRectD, line: LeadLine, lineNumber: string): boolean;
      static find(orientation1: number[], imageposition1: number[], voxelspacing1: lt.LeadPointD, width1: number, height1: number, orientation2: number[], imageposition2: number[], voxelspacing2: lt.LeadPointD, width2: number, height2: number): LeadLine;
      constructor();
   }

   enum Requested3DDataType {
      create3DObject = 0,
      render = 1,
      creationProgress = 2,
      keepServerObjectAlive = 3,
      delete3DObject = 4,
      update3DSettings = 5,
      get3DInfo = 6,
      renderPanoramic = 7
   }

   interface StatusChangedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: StatusChangedEventArgs): void;
   }

   class StatusChangedEventType extends lt.LeadEvent {
      add(value: StatusChangedEventHandler): StatusChangedEventHandler;
      remove(value: StatusChangedEventHandler): void;
   }

   class StatusChangedEventArgs extends lt.LeadEventArgs {
      get_status(): Object3DStatus;
      get_message(): string;
      constructor(status: Object3DStatus, message: string);
      status: Object3DStatus; // read-only
      message: string; // read-only
   }

   interface Request3DDataEventHandler extends lt.LeadEventHandler {
      (sender: any, e: Request3DDataEventArgs): void;
   }

   class Request3DDataEventType extends lt.LeadEvent {
      add(value: Request3DDataEventHandler): Request3DDataEventHandler;
      remove(value: Request3DDataEventHandler): void;
   }

   class Request3DDataEventArgs extends lt.LeadEventArgs {
      get_JSON(): string;
      get_type(): Requested3DDataType;
      constructor(Json: string, type: Requested3DDataType);
      JSON: string; // read-only
      type: Requested3DDataType; // read-only
   }

   interface MPRFrameRequestedEventHandler extends lt.LeadEventHandler {
      (sender: any, e: MPRFrameRequestedEventArgs): void;
   }

   class MPRFrameRequestedEventType extends lt.LeadEvent {
      add(value: MPRFrameRequestedEventHandler): MPRFrameRequestedEventHandler;
      remove(value: MPRFrameRequestedEventHandler): void;
   }

   class MPRFrameRequestedEventArgs extends lt.LeadEventArgs {
      get_image(): HTMLImageElement;
      get_index(): number;
      get_mprType(): CellMPRType;
      constructor(index: number, mprType: CellMPRType, image: HTMLImageElement);
      image: HTMLImageElement; // read-only
      index: number; // read-only
      mprType: CellMPRType; // read-only
   }

   enum SortType {
      none = 0,
      byAxis = 1,
      byAcquisitionTime = 2
   }

   enum SortOrder {
      ascending = 0,
      descending = 2
   }

   class SortingOperation {
      get_sortByCategory(): SortType;
      set_sortByCategory(value: SortType): void;
      get_selectorAttribute(): number;
      set_selectorAttribute(value: number): void;
      get_order(): SortOrder;
      set_order(value: SortOrder): void;
      clone(): SortingOperation;
      constructor();
      sortByCategory: SortType;
      selectorAttribute: number;
      order: SortOrder;
   }

   class WindowLevelData {
      get_interactiveMode(): WindowLevelInteractiveMode;
      get_renderer(): DICOMImageInformationRenderer;
      set_renderer(value: DICOMImageInformationRenderer): void;
      get_image(): HTMLImageElement;
      set_image(value: HTMLImageElement): void;
      get_canvas(): HTMLCanvasElement;
      set_canvas(value: HTMLCanvasElement): void;
      get_dragDeltaSensitivity(): number;
      set_dragDeltaSensitivity(value: number): void;
      get_windowLevelSensitivity(): number;
      get_enableWindowLevelSensitivity(): boolean;
      set_enableWindowLevelSensitivity(value: boolean): void;
      get_resizedCanvas(): HTMLCanvasElement;
      get_resizedRenderer(): DICOMImageInformationRenderer;
      get_imageData(): ImageData;
      set_imageData(value: ImageData): void;
      get_resizedImageData(): ImageData;
      set_resizedImageData(value: ImageData): void;
      get_resizeFactor(): number;
      set_resizeFactor(value: number): void;
      constructor();
      interactiveMode: WindowLevelInteractiveMode;
      renderer: DICOMImageInformationRenderer;
      image: HTMLImageElement;
      canvas: HTMLCanvasElement;
      dragDeltaSensitivity: number;
      windowLevelSensitivity: number; // read-only
      enableWindowLevelSensitivity: boolean;
      resizedCanvas: HTMLCanvasElement; // read-only
      resizedRenderer: DICOMImageInformationRenderer; // read-only
      imageData: ImageData;
      resizedImageData: ImageData;
      resizeFactor: number;
   }

   class WindowLevelInteractiveMode extends lt.Controls.ImageViewerInteractiveMode {
      get_id(): number;
      get_data(): WindowLevelData;
      set_data(value: WindowLevelData): void;
      get_name(): string;
      reset(): void;
      start(viewer: lt.Controls.ImageViewer): void;
      stop(viewer: lt.Controls.ImageViewer): void;
      add_render(value: lt.LeadEventHandler): void;
      remove_render(value: lt.LeadEventHandler): void;
      add_workDelta(value: lt.Controls.InteractiveDragDeltaEventHandler): void;
      remove_workDelta(value: lt.Controls.InteractiveDragDeltaEventHandler): void;
      add_renderCompleted(value: lt.LeadEventHandler): void;
      remove_renderCompleted(value: lt.LeadEventHandler): void;
      dispose(): void;
      constructor();
      id: number; // read-only
      data: WindowLevelData;
      name: string; // read-only
      render: lt.LeadEventType; // read-only
      workDelta: lt.Controls.InteractiveDragDeltaEventType; // read-only
      renderCompleted: lt.LeadEventType; // read-only
   }
}
