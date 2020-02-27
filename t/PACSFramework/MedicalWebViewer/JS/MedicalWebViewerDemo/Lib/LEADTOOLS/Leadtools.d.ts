//***********************************************************************************************
//   Type definitions for Leadtools.js
//   Updated: 12/3/2019 19:00
//   Version: 20.0.0.20
//
//   Dependencies:
//      Ltkrn.d.ts
//
//   Copyright (c) 1991-2019 All Rights Reserved. LEAD Technologies, Inc.
//   https://www.leadtools.com
//***********************************************************************************************

declare module lt {

         class LeadEventArgs {
         constructor();
         static empty: LeadEventArgs; // read-only
         static addToEvent(target: any, eventName: string, method: Function): void;
         static removeFromEvent(target: any, eventName: string, method: Function): void;
         }

         interface LeadEventHandler {
         (sender: any, e: LeadEventArgs): void;
         }

         class LeadEvent {
         add(value: LeadEventHandler): LeadEventHandler;
         remove(value: LeadEventHandler): void;
         static create(target: any, eventName: string): LeadEvent;
         invoke(sender: any, e: LeadEventArgs): void;
         }

         class LeadEventType extends LeadEvent {
         add(value: LeadEventHandler): LeadEventHandler;
         remove(value: LeadEventHandler): void;
         }
      

   enum NotifyLeadCollectionChangedAction {
      add = 0,
      remove = 1,
      replace = 2,
      move = 3,
      reset = 4
   }

   interface NotifyLeadCollectionChangedEventHandler extends LeadEventHandler {
      (sender: any, e: NotifyLeadCollectionChangedEventArgs): void;
   }

   class NotifyLeadCollectionChangedEventType extends LeadEvent {
      add(value: NotifyLeadCollectionChangedEventHandler): NotifyLeadCollectionChangedEventHandler;
      remove(value: NotifyLeadCollectionChangedEventHandler): void;
   }

   class NotifyLeadCollectionChangedEventArgs extends LeadEventArgs {
      static create(action: NotifyLeadCollectionChangedAction): NotifyLeadCollectionChangedEventArgs;
      static createAdd(newStartingIndex: number): NotifyLeadCollectionChangedEventArgs;
      static createRemove(index: number): NotifyLeadCollectionChangedEventArgs;
      static createMove(oldStartingIndex: number, newStartingIndex: number): NotifyLeadCollectionChangedEventArgs;
      static createReplace(index: number): NotifyLeadCollectionChangedEventArgs;
      static createReset(): NotifyLeadCollectionChangedEventArgs;
      get_action(): NotifyLeadCollectionChangedAction;
      set_action(value: NotifyLeadCollectionChangedAction): void;
      get_newItems(): any[];
      set_newItems(value: any[]): void;
      get_oldItems(): any[];
      set_oldItems(value: any[]): void;
      get_newStartingIndex(): number;
      set_newStartingIndex(value: number): void;
      get_oldStartingIndex(): number;
      set_oldStartingIndex(value: number): void;
      constructor();
      action: NotifyLeadCollectionChangedAction;
      newItems: any[];
      oldItems: any[];
      newStartingIndex: number;
      oldStartingIndex: number;
   }

   class LeadCollection {
      get_count(): number;
      clear(): void;
      remove(item: any): void;
      add(item: any): void;
      addRange(items: any[]): void;
      contains(item: any): boolean;
      getEnumerator(): any;
      get_item(i: number): any;
      set_item(i: number, value: any): void;
      toArray(): any[];
      insertItem(index: number, item: any): void;  // protected
      move(oldIndex: number, newIndex: number): void;
      insert(index: number, item: any): void;
      insertRange(index: number, items: any[]): void;
      insertItemRange(index: number, items: any[]): void;  // protected
      moveItem(oldIndex: number, newIndex: number): void;  // protected
      onCollectionChanged(e: NotifyLeadCollectionChangedEventArgs): void;  // protected
      removeAt(index: number): void;
      removeItem(index: number): void;  // protected
      removeRange(index: number, count: number): void;
      removeItemRange(index: number, count: number): void;  // protected
      setItem(index: number, item: any): void;  // protected
      clearItems(): void;  // protected
      indexOf(item: any): number;
      add_collectionChanged(value: NotifyLeadCollectionChangedEventHandler): void;
      remove_collectionChanged(value: NotifyLeadCollectionChangedEventHandler): void;
      constructor();
      count: number; // read-only
      item(index: number, value?: any): any;
      collectionChanged: NotifyLeadCollectionChangedEventType; // read-only
   }

   interface NotifyLeadMultiCollectionChangedEventHandler extends LeadEventHandler {
      (sender: any, e: NotifyLeadMultiCollectionChangedEventArgs): void;
   }

   class NotifyLeadMultiCollectionChangedEventType extends LeadEvent {
      add(value: NotifyLeadMultiCollectionChangedEventHandler): NotifyLeadMultiCollectionChangedEventHandler;
      remove(value: NotifyLeadMultiCollectionChangedEventHandler): void;
   }

   class NotifyLeadMultiCollectionChangedEventArgs extends NotifyLeadCollectionChangedEventArgs {
      static createFrom(collectionIndex: number, e: NotifyLeadCollectionChangedEventArgs): NotifyLeadMultiCollectionChangedEventArgs;
      get_collectionIndex(): number;
      set_collectionIndex(value: number): void;
      constructor();
      collectionIndex: number;
   }

   class LeadMultiCollection extends LeadCollection {
      get_invokeOnSelf(): boolean;
      set_invokeOnSelf(value: boolean): void;
      subCollectionChanged(source: any, e: NotifyLeadCollectionChangedEventArgs): void;  // protected
      onCollectionChanged(e: NotifyLeadCollectionChangedEventArgs): void;  // protected
      onMultiCollectionChanged(e: NotifyLeadMultiCollectionChangedEventArgs): void;  // protected
      add_multiCollectionChanged(value: NotifyLeadMultiCollectionChangedEventHandler): void;
      remove_multiCollectionChanged(value: NotifyLeadMultiCollectionChangedEventHandler): void;
      constructor();
      invokeOnSelf: boolean;
      multiCollectionChanged: NotifyLeadMultiCollectionChangedEventType; // read-only
   }

   interface ImageProcessingProgressEventHandler extends LeadEventHandler {
      (sender: any, e: ImageProcessingProgressEventArgs): void;
   }

   class ImageProcessingProgressEventType extends LeadEvent {
      add(value: ImageProcessingProgressEventHandler): ImageProcessingProgressEventHandler;
      remove(value: ImageProcessingProgressEventHandler): void;
   }

   class ImageProcessingProgressEventArgs extends LeadEventArgs {
      static create(percentage: number): ImageProcessingProgressEventArgs;
      get_percentage(): number;
      get_cancel(): boolean;
      set_cancel(value: boolean): void;
      constructor();
      percentage: number; // read-only
      cancel: boolean;
   }

   interface ImageProcessingCompletedEventHandler extends LeadEventHandler {
      (sender: any, e: ImageProcessingCompletedEventArgs): void;
   }

   class ImageProcessingCompletedEventType extends LeadEvent {
      add(value: ImageProcessingCompletedEventHandler): ImageProcessingCompletedEventHandler;
      remove(value: ImageProcessingCompletedEventHandler): void;
   }

   class ImageProcessingCompletedEventArgs extends LeadEventArgs {
      create(imageData: ImageData, results: any[][]): ImageProcessingCompletedEventArgs;
      get_imageData(): ImageData;
      get_results(): any[][];
      constructor();
      imageData: ImageData; // read-only
      results: any[][]; // read-only
   }

   interface ImageProcessingErrorEventHandler extends LeadEventHandler {
      (sender: any, e: ImageProcessingErrorEventArgs): void;
   }

   class ImageProcessingErrorEventType extends LeadEvent {
      add(value: ImageProcessingErrorEventHandler): ImageProcessingErrorEventHandler;
      remove(value: ImageProcessingErrorEventHandler): void;
   }

   class ImageProcessingErrorEventArgs extends LeadEventArgs {
      static create(error: Error): ImageProcessingErrorEventArgs;
      get_error(): Error;
      constructor();
      error: Error; // read-only
   }

   class ImageProcessing {
      get_jsFilePath(): string;
      set_jsFilePath(value: string): void;
      get_command(): string;
      set_command(value: string): void;
      get_imageData(): ImageData;
      set_imageData(value: ImageData): void;
      get_arguments(): any[][];
      add_progress(value: ImageProcessingProgressEventHandler): void;
      remove_progress(value: ImageProcessingProgressEventHandler): void;
      add_completed(value: ImageProcessingCompletedEventHandler): void;
      remove_completed(value: ImageProcessingCompletedEventHandler): void;
      add_error(value: ImageProcessingErrorEventHandler): void;
      remove_error(value: ImageProcessingErrorEventHandler): void;
      get_isRunning(): boolean;
      abort(): void;
      get_runInMainThread(): boolean;
      set_runInMainThread(value: boolean): void;
      run(): void;
      constructor();
      jsFilePath: string;
      command: string;
      imageData: ImageData;
      arguments: any[][]; // read-only
      isRunning: boolean; // read-only
      runInMainThread: boolean;
      progress: ImageProcessingProgressEventType; // read-only
      completed: ImageProcessingCompletedEventType; // read-only
      error: ImageProcessingErrorEventType; // read-only
   }

   class GeometryTools {
      static getCornerPoints(rect: LeadRectD): LeadPointD[];
      static getBoundingRect(points: LeadPointD[]): LeadRectD;
      static getCenterPoint(rect: LeadRectD): LeadPointD;
   }

   class LeadLengthD {
      static create(value: number): LeadLengthD;
      clone(): LeadLengthD;
      get_value(): number;
      set_value(value: number): void;
      static equals(length1: LeadLengthD, length2: LeadLengthD): boolean;
      toString(): string;
      toJSON(): any;
      static fromJSON(jsonObject: any): LeadLengthD;
      constructor();
      value: number;
   }

   class LeadDoubleTools {
      static areClose(value1: number, value2: number): boolean;
      static lessThan(value1: number, value2: number): boolean;
      static greaterThan(value1: number, value2: number): boolean;
      static lessThanOrClose(value1: number, value2: number): boolean;
      static greaterThanOrClose(value1: number, value2: number): boolean;
      static isOne(value: number): boolean;
      static isZero(value: number): boolean;
      static areClosePoints(point1: LeadPointD, point2: LeadPointD): boolean;
      static areCloseSizes(size1: LeadSizeD, size2: LeadSizeD): boolean;
      static areCloseRects(rect1: LeadRectD, rect2: LeadRectD): boolean;
      static isBetweenZeroAndOne(value: number): boolean;
      static doubleToInt(value: number): number;
      static rectHasNaN(rect: LeadRectD): boolean;
      static isNaN(value: number): boolean;
      static isInfinity(value: number): boolean;
      static normalizeAngle(angle: number): number;
      static naN: number;
      static positiveInfinity: number;
      static negativeInfinity: number;
   }

   class LeadMatrix {
      static create(m11: number, m12: number, m21: number, m22: number, offsetX: number, offsetY: number): LeadMatrix;
      clone(): LeadMatrix;
      static get_identity(): LeadMatrix;
      get_isIdentity(): boolean;
      get_determinant(): number;
      get_hasInverse(): boolean;
      get_m11(): number;
      set_m11(value: number): void;
      get_m12(): number;
      set_m12(value: number): void;
      get_m21(): number;
      set_m21(value: number): void;
      get_m22(): number;
      set_m22(value: number): void;
      get_offsetX(): number;
      set_offsetX(value: number): void;
      get_offsetY(): number;
      set_offsetY(value: number): void;
      setIdentity(): void;
      static multiply(trans1: LeadMatrix, trans2: LeadMatrix): LeadMatrix;
      append(matrix: LeadMatrix): void;
      prepend(matrix: LeadMatrix): void;
      rotate(angle: number): void;
      rotatePrepend(angle: number): void;
      rotateAt(angle: number, centerX: number, centerY: number): void;
      rotateAtPrepend(angle: number, centerX: number, centerY: number): void;
      scale(scaleX: number, scaleY: number): void;
      scalePrepend(scaleX: number, scaleY: number): void;
      scaleAt(scaleX: number, scaleY: number, centerX: number, centerY: number): void;
      scaleAtPrepend(scaleX: number, scaleY: number, centerX: number, centerY: number): void;
      skew(skewX: number, skewY: number): void;
      skewPrepend(skewX: number, skewY: number): void;
      translate(offsetX: number, offsetY: number): void;
      translatePrepend(offsetX: number, offsetY: number): void;
      transformPoint(point: LeadPointD): LeadPointD;
      transformVector(point: LeadPointD): LeadPointD;
      transformRect(rect: LeadRectD): LeadRectD;
      transformPoints(points: LeadPointD[]): void;
      invert(): void;
      static equals(matrix1: LeadMatrix, matrix2: LeadMatrix): boolean;
      toString(): string;
      toJSON(): any;
      static fromJSON(jsonObject: any): LeadMatrix;
      constructor();
      static identity: LeadMatrix; // read-only
      isIdentity: boolean; // read-only
      determinant: number; // read-only
      hasInverse: boolean; // read-only
      m11: number;
      m12: number;
      m21: number;
      m22: number;
      offsetX: number;
      offsetY: number;
   }

   class LeadMatrixUtil {
      static transformRect(rect: LeadRectD, matrix: LeadMatrix): LeadRectD;
      static multiplyMatrix(matrix1: LeadMatrix, matrix2: LeadMatrix): LeadMatrix;
   }

   class LeadPointD {
      static get_empty(): LeadPointD;
      get_isEmpty(): boolean;
      static create(x: number, y: number): LeadPointD;
      clone(): LeadPointD;
      get_x(): number;
      set_x(value: number): void;
      get_y(): number;
      set_y(value: number): void;
      static equals(point1: LeadPointD, point2: LeadPointD): boolean;
      toString(): string;
      toJSON(): any;
      static fromJSON(jsonObject: any): LeadPointD;
      constructor();
      static empty: LeadPointD; // read-only
      isEmpty: boolean; // read-only
      x: number;
      y: number;
   }

   class LeadRectD {
      static create(x: number, y: number, width: number, height: number): LeadRectD;
      static fromLTRB(left: number, top: number, right: number, bottom: number): LeadRectD;
      clone(): LeadRectD;
      static get_empty(): LeadRectD;
      get_isEmpty(): boolean;
      get_location(): LeadPointD;
      set_location(value: LeadPointD): void;
      get_size(): LeadSizeD;
      set_size(value: LeadSizeD): void;
      get_x(): number;
      set_x(value: number): void;
      get_y(): number;
      set_y(value: number): void;
      get_width(): number;
      set_width(value: number): void;
      get_height(): number;
      set_height(value: number): void;
      get_left(): number;
      get_top(): number;
      get_right(): number;
      get_bottom(): number;
      get_topLeft(): LeadPointD;
      get_topRight(): LeadPointD;
      get_bottomLeft(): LeadPointD;
      get_bottomRight(): LeadPointD;
      static equals(rect1: LeadRectD, rect2: LeadRectD): boolean;
      toString(): string;
      toJSON(): any;
      static fromJSON(jsonObject: any): LeadRectD;
      containsPoint(point: LeadPointD): boolean;
      contains(x: number, y: number): boolean;
      containsRect(rect: LeadRectD): boolean;
      intersectsWith(rect: LeadRectD): boolean;
      intersect(rect: LeadRectD): void;
      static intersectRects(rect1: LeadRectD, rect2: LeadRectD): LeadRectD;
      union(rect: LeadRectD): void;
      static unionRects(rect1: LeadRectD, rect2: LeadRectD): LeadRectD;
      offset(offsetX: number, offsetY: number): void;
      inflate(width: number, height: number): void;
      static inflateRect(rect: LeadRectD, width: number, height: number): LeadRectD;
      scale(scaleX: number, scaleY: number): void;
      constructor();
      static empty: LeadRectD; // read-only
      isEmpty: boolean; // read-only
      location: LeadPointD;
      size: LeadSizeD;
      x: number;
      y: number;
      width: number;
      height: number;
      left: number; // read-only
      top: number; // read-only
      right: number; // read-only
      bottom: number; // read-only
      topLeft: LeadPointD; // read-only
      topRight: LeadPointD; // read-only
      bottomLeft: LeadPointD; // read-only
      bottomRight: LeadPointD; // read-only
   }

   class LeadSizeD {
      static create(width: number, height: number): LeadSizeD;
      clone(): LeadSizeD;
      static get_empty(): LeadSizeD;
      get_isEmpty(): boolean;
      get_width(): number;
      set_width(value: number): void;
      get_height(): number;
      set_height(value: number): void;
      static equals(size1: LeadSizeD, size2: LeadSizeD): boolean;
      toString(): string;
      toJSON(): any;
      static fromJSON(jsonObject: any): LeadSizeD;
      constructor();
      static empty: LeadSizeD; // read-only
      isEmpty: boolean; // read-only
      width: number;
      height: number;
   }

   enum RasterViewPerspective {
      topLeft = 1,
      bottomLeft180 = 2,
      topRight = 2,
      bottomRight = 3,
      topLeft180 = 3,
      bottomLeft = 4,
      bottomLeft90 = 5,
      leftTop = 5,
      rightTop = 6,
      topLeft90 = 6,
      bottomLeft270 = 7,
      rightBottom = 7,
      leftBottom = 8,
      topLeft270 = 8
   }

   enum RasterSupportType {
      document = 0,
      barcodes1D = 1,
      barcodes2D = 2,
      rasterPdfRead = 3,
      rasterPdfSave = 4,
      pdfAdvanced = 5,
      jbig2 = 6,
      ocrLEAD = 7,
      ocrPlus = 8,
      ocrOmniPage = 9,
      ocrOmniPageAsian = 10,
      ocrOmniPageArabic = 11,
      ocrLEADPdfOutput = 12,
      ocrPlusPdfOutput = 13,
      ocrOmniPagePdfOutput = 14,
      ocrOmniPageArabicPdfOutput = 15,
      omr = 16,
      icrPlus = 17,
      icrOmniPage = 18,
      documentWriters = 19,
      documentWritersPdf = 20,
      printDriver = 21,
      printDriverServer = 22,
      printDriverNetwork = 23,
      forms = 24,
      mediaWriter = 25,
      medical = 26,
      medical3d = 27,
      dicomCommunication = 28,
      ccow = 29,
      vector = 30,
      cloud = 31,
      appStore = 32,
      basic = 33,
      hl7 = 34,
      multimediaStreaming = 35
   }

   enum RasterKernelType {
      release = 0,
      evaluation = 1
   }

   class SetLicenseUriResult {
      constructor(result: boolean, message: string);
      result: boolean;
      message: string;
   }

   class RasterSupport {
      static setLicenseUri(licenseUri: string, developerKey: string, completed: (arg: SetLicenseUriResult) => any): void;
      static setLicenseBuffer(licenseBuffer: number[], developerKey: string): void;
      static setLicenseText(licenseText: string, developerKey: string): void;
      static isLocked(support: RasterSupportType): boolean;
      static get_kernelType(): RasterKernelType;
      static get_kernelExpired(): boolean;
      static kernelType: RasterKernelType; // read-only
      static kernelExpired: boolean; // read-only
      static requestTimeout: number;
      static licenseDirectory: string;
   }

   class LTVersion {
      static get_file(): string;
      static get_fileMajor(): number;
      static get_fileMinor(): number;
      static get_fileBuild(): number;
      static get_fileRevision(): number;
      static file: string; // read-only
      static fileMajor: number; // read-only
      static fileMinor: number; // read-only
      static fileBuild: number; // read-only
      static fileRevision: number; // read-only
   }

   class TextFontRuler {
      get_font(): string;
      set_font(value: string): void;
      get_context(): CanvasRenderingContext2D;
      measureWidth(text: string): number;
      measure(text: string): LeadSizeD;
      get_height(): number;
      dispose(): void;
      constructor(font: string);
      font: string;
      context: CanvasRenderingContext2D; // read-only
      height: number; // read-only
   }

   interface ImageLoaderProcessAjaxDataCallback {
      (imageLoader: ImageLoader, data: any, next: (arg: any) => any): void;
   }

   enum ImageLoaderUrlMode {
      imageUrl = 0,
      ajaxDataUrl = 1,
      ajaxXml = 2
   }

   interface ImageLoaderPreRunEventHandler extends LeadEventHandler {
      (sender: any, e: ImageLoaderPreRunEventArgs): void;
   }

   class ImageLoaderPreRunEventType extends LeadEvent {
      add(value: ImageLoaderPreRunEventHandler): ImageLoaderPreRunEventHandler;
      remove(value: ImageLoaderPreRunEventHandler): void;
   }

   class ImageLoaderPreRunEventArgs extends LeadEventArgs {
      get_cancel(): boolean;
      set_cancel(value: boolean): void;
      constructor();
      cancel: boolean;
   }

   interface ImageLoaderPreSendEventHandler extends LeadEventHandler {
      (sender: any, e: ImageLoaderPreSendEventArgs): void;
   }

   class ImageLoaderPreSendEventType extends LeadEvent {
      add(value: ImageLoaderPreSendEventHandler): ImageLoaderPreSendEventHandler;
      remove(value: ImageLoaderPreSendEventHandler): void;
   }

   class ImageLoaderPreSendEventArgs extends LeadEventArgs {
      get_cancel(): boolean;
      set_cancel(value: boolean): void;
      constructor();
      cancel: boolean;
   }

   class ImageLoaderAjaxOptions {
      set_headers(value: { [key: string]: string }): void;
      get_headers(): { [key: string]: string };
      get_method(): string;
      set_method(value: string): void;
      get_postData(): string;
      set_postData(value: string): void;
      constructor();
      headers: { [key: string]: string };
      method: string;
      postData: string;
   }

   class ImageLoader {
      static add_preSend(value: ImageLoaderPreSendEventHandler): void;
      static remove_preSend(value: ImageLoaderPreSendEventHandler): void;
      add_preRun(value: ImageLoaderPreRunEventHandler): void;
      remove_preRun(value: ImageLoaderPreRunEventHandler): void;
      add_done(value: LeadEventHandler): void;
      remove_done(value: LeadEventHandler): void;
      add_fail(value: LeadEventHandler): void;
      remove_fail(value: LeadEventHandler): void;
      add_always(value: LeadEventHandler): void;
      remove_always(value: LeadEventHandler): void;
      get_urlMode(): ImageLoaderUrlMode;
      set_urlMode(value: ImageLoaderUrlMode): void;
      get_tag(): any;
      set_tag(value: any): void;
      get_workingImageElement(): HTMLElement;
      set_workingImageElement(value: HTMLElement): void;
      get_xhr(): any;
      set_xhr(value: any): void;
      get_processAjaxData(): ImageLoaderProcessAjaxDataCallback;
      set_processAjaxData(value: ImageLoaderProcessAjaxDataCallback): void;
      get_imgCrossOrigin(): string;
      set_imgCrossOrigin(value: string): void;
      get_ajaxWithCredentials(): boolean;
      set_ajaxWithCredentials(value: boolean): void;
      get_element(): HTMLElement;
      get_isHTMLImageElement(): boolean;
      get_width(): number;
      get_height(): number;
      get_error(): Error;
      get_isWorking(): boolean;
      get_ajaxOptions(): ImageLoaderAjaxOptions;
      set_ajaxOptions(value: ImageLoaderAjaxOptions): void;
      get_url(): string;
      set_url(value: string): void;
      get_imagesHolder(): HTMLElement;
      set_imagesHolder(value: HTMLElement): void;
      get_isAborted(): boolean;
      abort(): void;
      dispose(): void;
      get_canRun(): boolean;
      run(): void;
      constructor();
      urlMode: ImageLoaderUrlMode;
      tag: any;
      workingImageElement: HTMLElement;
      xhr: any;
      processAjaxData: ImageLoaderProcessAjaxDataCallback;
      imgCrossOrigin: string;
      ajaxWithCredentials: boolean;
      element: HTMLElement; // read-only
      isHTMLImageElement: boolean; // read-only
      width: number; // read-only
      height: number; // read-only
      error: Error; // read-only
      isWorking: boolean; // read-only
      ajaxOptions: ImageLoaderAjaxOptions;
      url: string;
      imagesHolder: HTMLElement;
      isAborted: boolean; // read-only
      canRun: boolean; // read-only
      static preSend: ImageLoaderPreSendEventType; // read-only
      preRun: ImageLoaderPreRunEventType; // read-only
      done: LeadEventType; // read-only
      fail: LeadEventType; // read-only
      always: LeadEventType; // read-only
      static defaultImgCrossOrigin: string;
      static defaultAjaxWithCredentials: boolean;
   }

   enum LTDevice {
      unknown = 0,
      desktop = 1,
      mobile = 2,
      tablet = 3
   }

   enum LTOS {
      unknown = 0,
      windows = 1,
      mac = 2,
      iOS = 3,
      android = 4,
      linux = 5,
      blackberry = 6,
      webOS = 7,
      windows7 = 8,
      windows8 = 9,
      windows10 = 10
   }

   enum LTBrowser {
      unknown = 0,
      internetExplorer = 1,
      firefox = 2,
      chrome = 3,
      safari = 4,
      opera = 5,
      android = 6,
      edge = 7
   }

   interface LTRender {
      (): void;
   }

   interface LTRequestAnimationFrame {
      (callback: LTRender): number;
   }

   interface LTCancelAnimationFrame {
      (id: number): void;
   }

   class LTHelper {
      static log(arg: any): void;
      static logWarning(arg: any): void;
      static logError(arg: any): void;
      static requestAnimationFrame(callback: LTRender): number;
      static cancelAnimationFrame(id: number): void;
      static getElementStyle(element: HTMLElement, styleProp: string): string;
      static getPosition(element: HTMLElement, parent: HTMLElement): LeadPointD;
      static hasClass(element: HTMLElement, className: string): boolean;
      static removeClass(element: HTMLElement, className: string): void;
      static addClass(element: HTMLElement, className: string): void;
      static base64Encode(input: number[], removeLinefeed: boolean): string;
      static base64Decode(input: string): number[];
      static base64DecodeToArrayBuffer(input: string): any;
      static base64DecodeToByteArray(input: string): number[];
      static base64EncodeFromArrayBuffer(buffer: any): string;
      static utf8Encode(value: number[], removeLinefeed: boolean): string;
      static utf8Decode(utf: string): number[];
      static loadJS(fileName: string, callback: Function): void;
      static removeJS(fileName: string): void;
      static ensureUsableCanvas(canvas: HTMLCanvasElement): number;
      static newGuid(): string;
      static lt_CheckSupportLocked(support: number): void;
      static requestCustomHeaders: { [key: string]: any };
      static device: LTDevice;
      static OS: LTOS;
      static browser: LTBrowser;
      static version: number;
      static vendor: string;
      static supportsHTMLPointerEvents: boolean;
      static supportsCSSTransitions: boolean;
      static supportsFileReader: boolean;
      static supportsCanvas: boolean;
      static supportsTypedArray: boolean;
      static supportsTouch: boolean;
      static supportsMultiTouch: boolean;
      static supportsMouse: boolean;
      static supportsScroll: boolean;
      static supportsWebGL: boolean;
      static supportsTransform: boolean;
      static supportsAnimationFrame: boolean;
      static supportsWebWorker: boolean;
      static msPointerEnabled: boolean;
      static resizeEvent: string;
      static dragStartEvent: string;
      static dragDeltaEvent: string;
      static dragCompletedEvent: string;
      static dragCancelEvent: string;
      static mouseWheelEvent: string;
      static licenseDirectory: string;
   }
}
