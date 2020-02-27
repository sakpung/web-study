//***********************************************************************************************
//   Type definitions for Leadtools.Annotations.Rendering.JavaScript.js
//   Updated: 12/3/2019 19:00
//   Version: 20.0.0.42
//
//   Dependencies:
//      Leadtools.d.ts
//      Leadtools.Annotations.Engine.d.ts
//
//   Copyright (c) 1991-2019 All Rights Reserved. LEAD Technologies, Inc.
//   https://www.leadtools.com
//***********************************************************************************************

declare module lt.Annotations.Rendering {

   class AnnHtml5RenderingEngine extends lt.Annotations.Engine.AnnRenderingEngine {
      get_context(): CanvasRenderingContext2D;
      set_context(value: CanvasRenderingContext2D): void;
      attach(container: lt.Annotations.Engine.AnnContainer, context: CanvasRenderingContext2D): void;
      detach(): void;
      static setFont(context: CanvasRenderingContext2D, font: lt.Annotations.Engine.AnnFont): void;
      measureString(text: string, font: lt.Annotations.Engine.AnnFont): lt.LeadSizeD;
      static measureTextHeight(context: CanvasRenderingContext2D, font: lt.Annotations.Engine.AnnFont): number;
      static setFill(context: CanvasRenderingContext2D, brush: lt.Annotations.Engine.AnnBrush): void;
      static setFillOpacityAndBounds(context: CanvasRenderingContext2D, brush: lt.Annotations.Engine.AnnBrush, opacity: number, brushBounds: lt.LeadRectD): void;
      static setFillWithOpacity(context: CanvasRenderingContext2D, brush: lt.Annotations.Engine.AnnBrush, opacity: number): void;
      static setStroke(context: CanvasRenderingContext2D, stroke: lt.Annotations.Engine.AnnStroke): void;
      static setStrokeWithOpacity(context: CanvasRenderingContext2D, stroke: lt.Annotations.Engine.AnnStroke, opacity: number): void;
      static drawCurve(context: CanvasRenderingContext2D, points: lt.LeadPointD[], tension: number): void;
      static drawClosedCurve(context: CanvasRenderingContext2D, points: lt.LeadPointD[], tension: number): void;
      static drawEllipse(context: CanvasRenderingContext2D, rc: lt.LeadRectD): void;
      drawPicture(picture: lt.Annotations.Engine.AnnPicture, rc: lt.LeadRectD, annObject: lt.Annotations.Engine.AnnObject): void;
      onLoadPicture(e: lt.Annotations.Engine.AnnLoadPictureEventArgs): void;
      static getTextSize(text: string, annFont: lt.Annotations.Engine.AnnFont, layoutArea: lt.LeadSizeD): lt.LeadSizeD;
      renderGrid(runMode: boolean, container: lt.Annotations.Engine.AnnContainer): void;
      constructor();
      context: CanvasRenderingContext2D;
   }

   class AnnSvgRenderingEngine extends lt.Annotations.Engine.AnnRenderingEngine {
      static exportSvg(container: lt.Annotations.Engine.AnnContainer, mapper: lt.Annotations.Engine.AnnContainerMapper, renderers: { [key: number]: lt.Annotations.Engine.IAnnObjectRenderer }): string;
      get_element(): HTMLElement;
      set_element(value: HTMLElement): void;
      renderGrid(runMode: boolean, container: lt.Annotations.Engine.AnnContainer): void;
      render(clipRect: lt.LeadRectD, clear: boolean): void;
      measureString(text: string, font: lt.Annotations.Engine.AnnFont): lt.LeadSizeD;
      attach(container: lt.Annotations.Engine.AnnContainer, element: HTMLElement): void;
      detach(): void;
      get_stateless(): boolean;
      constructor();
      element: HTMLElement;
      stateless: boolean; // read-only
   }

   class AnnCrossProductObjectRenderer extends AnnPolyRulerObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnCurveObjectRenderer extends AnnPolylineObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnEllipseObjectRenderer extends AnnObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnFreehandHotspotObjectRenderer extends AnnPolylineObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnHiliteObjectRenderer extends AnnRectangleObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnHotspotObjectRenderer extends AnnRectangleObjectRenderer {
      get_showAtRunMode(): boolean;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
      showAtRunMode: boolean; // read-only
   }

   class AnnImageObjectRenderer extends AnnRectangleObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnLabelRenderer {
      get_rotateWithParent(): boolean;
      set_rotateWithParent(value: boolean): void;
      initialize(renderingEngine: lt.Annotations.Engine.AnnRenderingEngine): void;
      get_offsetHeight(): boolean;
      set_offsetHeight(value: boolean): void;
      get_renderingEngine(): lt.Annotations.Engine.AnnRenderingEngine;
      getBounds(mapper: lt.Annotations.Engine.AnnContainerMapper, label: lt.Annotations.Engine.AnnLabel, operations: lt.Annotations.Engine.AnnFixedStateOperations): lt.LeadRectD;
      renderLabel(mapper: lt.Annotations.Engine.AnnContainerMapper, label: lt.Annotations.Engine.AnnLabel, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;
      constructor();
      rotateWithParent: boolean;
      offsetHeight: boolean;
      renderingEngine: lt.Annotations.Engine.AnnRenderingEngine; // read-only
   }

   class AnnNoteObjectRenderer extends AnnTextObjectRenderer {
      renderShadow(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnObjectRenderer {
      get_clipPath(): boolean;  // protected
      set_clipPath(value: boolean): void;  // protected
      beginClipPath(): any;  // protected
      endClipPath(state: any): void;  // protected
      addObject(annObject: lt.Annotations.Engine.AnnObject): void;
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      renderHatchBrushFill(engine: AnnHtml5RenderingEngine, mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      drawLine(context: CanvasRenderingContext2D, startX: number, startY: number, endX: number, endY: number): void;  // protected
      get_locationsThumbStyle(): lt.Annotations.Engine.IAnnThumbStyle;
      set_locationsThumbStyle(value: lt.Annotations.Engine.IAnnThumbStyle): void;
      get_rotateCenterThumbStyle(): lt.Annotations.Engine.IAnnThumbStyle;
      set_rotateCenterThumbStyle(value: lt.Annotations.Engine.IAnnThumbStyle): void;
      get_rotateGripperThumbStyle(): lt.Annotations.Engine.IAnnThumbStyle;
      set_rotateGripperThumbStyle(value: lt.Annotations.Engine.IAnnThumbStyle): void;
      initialize(renderingEngine: lt.Annotations.Engine.AnnRenderingEngine): void;
      renderLocked(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      renderSelection(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      renderAlignmentTarget(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      renderContent(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;
      renderThumbs(mapper: lt.Annotations.Engine.AnnContainerMapper, thumbLocations: lt.LeadPointD[], operations: lt.Annotations.Engine.AnnFixedStateOperations): void;
      renderRotatePointThumbs(mapper: lt.Annotations.Engine.AnnContainerMapper, rotateCenterLocation: lt.LeadPointD, rotateGripperLocation: lt.LeadPointD, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;
      getRenderPoints(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): lt.LeadPointD[];
      get_renderingEngine(): lt.Annotations.Engine.AnnRenderingEngine;
      get_labelRenderer(): lt.Annotations.Engine.IAnnLabelRenderer;
      set_labelRenderer(value: lt.Annotations.Engine.IAnnLabelRenderer): void;
      constructor();
      clipPath: boolean;
      locationsThumbStyle: lt.Annotations.Engine.IAnnThumbStyle;
      rotateCenterThumbStyle: lt.Annotations.Engine.IAnnThumbStyle;
      rotateGripperThumbStyle: lt.Annotations.Engine.IAnnThumbStyle;
      renderingEngine: lt.Annotations.Engine.AnnRenderingEngine; // read-only
      labelRenderer: lt.Annotations.Engine.IAnnLabelRenderer;
   }

   class AnnPointerObjectRenderer extends AnnPolylineObjectRenderer {
      get_fixedArrowLength(): boolean;
      set_fixedArrowLength(value: boolean): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
      fixedArrowLength: boolean;
   }

   class AnnPointObjectRenderer extends AnnObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnPolylineObjectRenderer extends AnnObjectRenderer {
      set_useSplineMode(value: boolean): void;
      get_useSplineMode(): boolean;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      renderEndingStyles(mapper: lt.Annotations.Engine.AnnContainerMapper, annPolyLineObject: lt.Annotations.Engine.AnnPolylineObject): void;
      constructor();
      useSplineMode: boolean;
   }

   class AnnPolyRulerObjectRenderer extends AnnPolylineObjectRenderer {
      get_fixedTickMarksLength(): boolean;
      set_fixedTickMarksLength(value: boolean): void;
      get_fixedGaugeLength(): boolean;
      set_fixedGaugeLength(value: boolean): void;
      drawTickMarks(mapper: lt.Annotations.Engine.AnnContainerMapper, startPoint: lt.LeadPointD, endPoint: lt.LeadPointD, tickMarkLength: lt.LeadLengthD, unit: lt.Annotations.Engine.AnnUnit, stroke: lt.Annotations.Engine.AnnStroke, operations: lt.Annotations.Engine.AnnFixedStateOperations, rulerDpiX: number, rulerDpiY: number): void;  // protected
      drawGauge(mapper: lt.Annotations.Engine.AnnContainerMapper, startPoint: lt.LeadPointD, endPoint: lt.LeadPointD, gaugeLength: lt.LeadLengthD, stroke: lt.Annotations.Engine.AnnStroke, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;  // protected
      drawLengthText(mapper: lt.Annotations.Engine.AnnContainerMapper, label: lt.Annotations.Engine.AnnLabel, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;  // protected
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
      fixedTickMarksLength: boolean;
      fixedGaugeLength: boolean;
   }

   class AnnProtractorObjectRenderer extends AnnPolyRulerObjectRenderer {
      getAngleText(angle: number, precision: number, unit: lt.Annotations.Engine.AnnAngularUnit, unitsAbbreviation: { [key: number]: string }): string;
      drawArc(mapper: lt.Annotations.Engine.AnnContainerMapper, center: lt.LeadPointD, startAngle: number, sweepAngle: number, radius: lt.LeadLengthD, stroke: lt.Annotations.Engine.AnnStroke, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;  // protected
      drawAngleText(mapper: lt.Annotations.Engine.AnnContainerMapper, label: lt.Annotations.Engine.AnnLabel, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnRectangleObjectRenderer extends AnnObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnRubberStampObjectRenderer extends AnnRectangleObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnStampObjectRenderer extends AnnTextObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnStickyNoteObjectRenderer extends AnnObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      renderSelection(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      renderContent(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;
      constructor();
   }

   class AnnTextObjectRenderer extends AnnRectangleObjectRenderer {
      get_flipReverseText(): boolean;
      set_flipReverseText(value: boolean): void;
      get_multiLinesOffset(): number;
      set_multiLinesOffset(value: number): void;
      get_fixedPadding(): boolean;
      set_fixedPadding(value: boolean): void;
      getTextSize(text: string, annFont: lt.Annotations.Engine.AnnFont, layoutArea: lt.LeadSizeD): lt.LeadSizeD;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
      flipReverseText: boolean;
      multiLinesOffset: number;
      fixedPadding: boolean;
   }

   class AnnTextPointerObjectRenderer extends AnnTextObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnTextRedactionObjectRenderer extends AnnTextReviewObjectRenderer {
      renderShape(mapper: lt.Annotations.Engine.AnnContainerMapper, annTextReviewObject: lt.Annotations.Engine.AnnTextReviewObject, context: CanvasRenderingContext2D, rect: lt.LeadRectD): void;  // protected
      constructor();
   }

   class AnnTextReviewObjectRenderer extends AnnObjectRenderer {
      renderShape(mapper: lt.Annotations.Engine.AnnContainerMapper, annTextReviewObject: lt.Annotations.Engine.AnnTextReviewObject, context: CanvasRenderingContext2D, rect: lt.LeadRectD): void;  // protected
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      renderSelection(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      renderContent(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;
      constructor();
   }

   class AnnTextHiliteObjectRenderer extends AnnTextReviewObjectRenderer {
      renderShape(mapper: lt.Annotations.Engine.AnnContainerMapper, annTextReviewObject: lt.Annotations.Engine.AnnTextReviewObject, context: CanvasRenderingContext2D, rect: lt.LeadRectD): void;  // protected
      constructor();
   }

   class AnnTextRollupObjectRenderer extends AnnNoteObjectRenderer {
      getRenderPoints(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): lt.LeadPointD[];
      constructor();
   }

   class AnnTextStrikeoutObjectRenderer extends AnnTextReviewObjectRenderer {
      get_thickness(): number;
      set_thickness(value: number): void;
      get_position(): number;
      set_position(value: number): void;
      renderShape(mapper: lt.Annotations.Engine.AnnContainerMapper, annTextReviewObject: lt.Annotations.Engine.AnnTextReviewObject, context: CanvasRenderingContext2D, rect: lt.LeadRectD): void;  // protected
      constructor();
      thickness: number;
      position: number;
   }

   class AnnTextUnderlineObjectRenderer extends AnnTextReviewObjectRenderer {
      get_thickness(): number;
      set_thickness(value: number): void;
      get_position(): number;
      set_position(value: number): void;
      renderShape(mapper: lt.Annotations.Engine.AnnContainerMapper, annTextReviewObject: lt.Annotations.Engine.AnnTextReviewObject, context: CanvasRenderingContext2D, rect: lt.LeadRectD): void;  // protected
      constructor();
      thickness: number;
      position: number;
   }

   class AnnThumbStyle {
      get_renderer(): lt.Annotations.Engine.IAnnObjectRenderer;
      set_renderer(value: lt.Annotations.Engine.IAnnObjectRenderer): void;
      clone(): AnnThumbStyle;
      get_size(): lt.LeadSizeD;
      set_size(value: lt.LeadSizeD): void;
      get_fill(): lt.Annotations.Engine.AnnBrush;
      set_fill(value: lt.Annotations.Engine.AnnBrush): void;
      get_stroke(): lt.Annotations.Engine.AnnStroke;
      set_stroke(value: lt.Annotations.Engine.AnnStroke): void;
      get_isVisible(): boolean;
      set_isVisible(value: boolean): void;
      renderHitTest(location: lt.LeadPointD, testPoint: lt.LeadPointD, hitTestBuffer: number, mapper: lt.Annotations.Engine.AnnContainerMapper): boolean;
      hitTest(location: lt.LeadPointD, testPoint: lt.LeadPointD, hitTestBuffer: number): boolean;
      render(renderer: lt.Annotations.Engine.IAnnObjectRenderer, mapper: lt.Annotations.Engine.AnnContainerMapper, location: lt.LeadPointD, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;
      create(): AnnThumbStyle;  // protected
      addPath(context: CanvasRenderingContext2D, rect: lt.LeadRectD): void;  // protected
      constructor();
      renderer: lt.Annotations.Engine.IAnnObjectRenderer;
      size: lt.LeadSizeD;
      fill: lt.Annotations.Engine.AnnBrush;
      stroke: lt.Annotations.Engine.AnnStroke;
      isVisible: boolean;
   }

   class AnnRectangleThumbStyle extends AnnThumbStyle {
      create(): AnnThumbStyle;  // protected
      addPath(context: CanvasRenderingContext2D, rect: lt.LeadRectD): void;  // protected
      constructor();
   }

   class AnnEllipseThumbStyle extends AnnThumbStyle {
      create(): AnnThumbStyle;  // protected
      addPath(context: CanvasRenderingContext2D, rect: lt.LeadRectD): void;  // protected
      constructor();
   }

   class AnnEncryptObjectRenderer extends AnnRectangleObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnMediaObjectRenderer extends AnnHotspotObjectRenderer {
      get_showAtRunMode(): boolean;
      constructor();
      showAtRunMode: boolean; // read-only
   }

   class AnnSvgCrossProductObjectRenderer extends AnnSvgPolyRulerObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgCurveObjectRenderer extends AnnSvgPolylineObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgEllipseObjectRenderer extends AnnSvgObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgEncryptObjectRenderer extends AnnSvgRectangleObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgFreehandHotspotObjectRenderer extends AnnSvgPolylineObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgHiliteObjectRenderer extends AnnSvgRectangleObjectRenderer {
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgHotspotObjectRenderer extends AnnSvgRectangleObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      get_showAtRunMode(): boolean;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
      showAtRunMode: boolean; // read-only
   }

   class AnnSvgMediaObjectRenderer extends AnnSvgHotspotObjectRenderer {
      get_showAtRunMode(): boolean;
      constructor();
      showAtRunMode: boolean; // read-only
   }

   class AnnSvgNoteObjectRenderer extends AnnSvgTextObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgObjectRenderer extends AnnObjectRenderer {
      createElement(): any;
      removeElementById(id: string): void;
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      addObject(annObject: lt.Annotations.Engine.AnnObject): void;
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      renderLocked(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;
      constructor();
   }

   class AnnSvgPointerObjectRenderer extends AnnSvgPolylineObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgPointObjectRenderer extends AnnSvgObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgPolylineObjectRenderer extends AnnSvgObjectRenderer {
      setActivePolyLineID(Id: string): void;
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgPolyRulerObjectRenderer extends AnnSvgPolylineObjectRenderer {
      get_tickmarksId1(): string;  // protected
      set_tickmarksId1(value: string): void;  // protected
      getTickMarksId(objectStateId: string): string;  // protected
      drawTickMarks(mapper: lt.Annotations.Engine.AnnContainerMapper, startPoint: lt.LeadPointD, endPoint: lt.LeadPointD, tickMarkLength: lt.LeadLengthD, unit: lt.Annotations.Engine.AnnUnit, stroke: lt.Annotations.Engine.AnnStroke, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;  // protected
      drawGauge(mapper: lt.Annotations.Engine.AnnContainerMapper, startPoint: lt.LeadPointD, endPoint: lt.LeadPointD, gaugeLength: lt.LeadLengthD, stroke: lt.Annotations.Engine.AnnStroke, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;  // protected
      drawLengthText(mapper: lt.Annotations.Engine.AnnContainerMapper, label: lt.Annotations.Engine.AnnLabel, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;  // protected
      addObject(annObject: lt.Annotations.Engine.AnnObject): void;
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
      tickmarksId1: string;
   }

   class AnnSvgProtractorObjectRenderer extends AnnSvgPolyRulerObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      getAngleText(angle: number, precision: number, unit: lt.Annotations.Engine.AnnAngularUnit, unitsAbbreviation: { [key: number]: string }): string;
      getPoint(size: lt.LeadSizeD, firstPoint: lt.LeadPointD, centerPoint: lt.LeadPointD, secondPoint: lt.LeadPointD, angle1: number, angle2: number, acute: boolean, arcRadius: number, unit: lt.Annotations.Engine.AnnAngularUnit): lt.LeadPointD;
      drawArc(mapper: lt.Annotations.Engine.AnnContainerMapper, center: lt.LeadPointD, startAngle: number, sweepAngle: number, radius: lt.LeadLengthD, stroke: lt.Annotations.Engine.AnnStroke, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;  // protected
      drawAngleText(mapper: lt.Annotations.Engine.AnnContainerMapper, label: lt.Annotations.Engine.AnnLabel, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgRectangleObjectRenderer extends AnnSvgObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgRubberStampObjectRenderer extends AnnSvgRectangleObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgStampObjectRenderer extends AnnSvgTextObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgStickyNoteObjectRenderer extends AnnSvgObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      renderSelection(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgTextObjectRenderer extends AnnSvgRectangleObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      get_flipReverseText(): boolean;
      set_flipReverseText(value: boolean): void;
      get_multiLinesOffset(): number;
      set_multiLinesOffset(value: number): void;
      get_fixedPadding(): boolean;
      set_fixedPadding(value: boolean): void;
      getTextSize(text: string, annFont: lt.Annotations.Engine.AnnFont, layoutArea: lt.LeadSizeD): lt.LeadSizeD;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
      flipReverseText: boolean;
      multiLinesOffset: number;
      fixedPadding: boolean;
   }

   class AnnSvgTextPointerObjectRenderer extends AnnSvgTextObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      removeObject(annObject: lt.Annotations.Engine.AnnObject): void;
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgTextRedactionObjectRenderer extends AnnSvgTextReviewObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      renderShape(mapper: lt.Annotations.Engine.AnnContainerMapper, annTextReviewObject: lt.Annotations.Engine.AnnTextReviewObject, rectangles: lt.LeadRectD[]): void;  // protected
      constructor();
   }

   class AnnSvgTextReviewObjectRenderer extends AnnSvgObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      renderShape(mapper: lt.Annotations.Engine.AnnContainerMapper, annTextReviewObject: lt.Annotations.Engine.AnnTextReviewObject, rectangles: lt.LeadRectD[]): void;  // protected
      render(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      renderSelection(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgTextRollupObjectRenderer extends AnnSvgNoteObjectRenderer {
      getRenderPoints(mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): lt.LeadPointD[];
      constructor();
   }

   class AnnSvgTextUnderlineObjectRenderer extends AnnSvgTextReviewObjectRenderer {
      get_thickness(): number;
      set_thickness(value: number): void;
      get_position(): number;
      set_position(value: number): void;
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      renderShape(mapper: lt.Annotations.Engine.AnnContainerMapper, annTextReviewObject: lt.Annotations.Engine.AnnTextReviewObject, rectangles: lt.LeadRectD[]): void;  // protected
      constructor();
      thickness: number;
      position: number;
   }

   class AnnSvgThumbStyle {
      get_renderer(): lt.Annotations.Engine.IAnnObjectRenderer;
      set_renderer(value: lt.Annotations.Engine.IAnnObjectRenderer): void;
      clone(): AnnSvgThumbStyle;
      get_size(): lt.LeadSizeD;
      set_size(value: lt.LeadSizeD): void;
      get_fill(): lt.Annotations.Engine.AnnBrush;
      set_fill(value: lt.Annotations.Engine.AnnBrush): void;
      get_stroke(): lt.Annotations.Engine.AnnStroke;
      set_stroke(value: lt.Annotations.Engine.AnnStroke): void;
      get_isVisible(): boolean;
      set_isVisible(value: boolean): void;
      renderHitTest(location: lt.LeadPointD, testPoint: lt.LeadPointD, hitTestBuffer: number, mapper: lt.Annotations.Engine.AnnContainerMapper): boolean;
      hitTest(location: lt.LeadPointD, testPoint: lt.LeadPointD, hitTestBuffer: number): boolean;
      render(renderer: lt.Annotations.Engine.IAnnObjectRenderer, mapper: lt.Annotations.Engine.AnnContainerMapper, location: lt.LeadPointD, operations: lt.Annotations.Engine.AnnFixedStateOperations): void;
      create(): AnnSvgThumbStyle;  // protected
      addPath(element: HTMLElement, rect: lt.LeadRectD): void;  // protected
      constructor();
      renderer: lt.Annotations.Engine.IAnnObjectRenderer;
      size: lt.LeadSizeD;
      fill: lt.Annotations.Engine.AnnBrush;
      stroke: lt.Annotations.Engine.AnnStroke;
      isVisible: boolean;
   }

   class AnnSvgRectangleThumbStyle extends AnnSvgThumbStyle {
      create(): AnnSvgThumbStyle;  // protected
      addPath(element: HTMLElement, rect: lt.LeadRectD): void;  // protected
      constructor();
   }

   class AnnSvgEllipseThumbStyle extends AnnSvgThumbStyle {
      create(): AnnSvgThumbStyle;  // protected
      addPath(element: HTMLElement, rect: lt.LeadRectD): void;  // protected
      constructor();
   }

   class AnnSvgTextHiliteObjectRenderer extends AnnSvgTextReviewObjectRenderer {
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      renderShape(mapper: lt.Annotations.Engine.AnnContainerMapper, annTextReviewObject: lt.Annotations.Engine.AnnTextReviewObject, rectangles: lt.LeadRectD[]): void;  // protected
      constructor();
   }

   class AnnSvgTextStrikeoutObjectRenderer extends AnnSvgTextReviewObjectRenderer {
      get_thickness(): number;
      set_thickness(value: number): void;
      get_position(): number;
      set_position(value: number): void;
      createObject(annObject: lt.Annotations.Engine.AnnObject): void;  // protected
      renderShape(mapper: lt.Annotations.Engine.AnnContainerMapper, annTextReviewObject: lt.Annotations.Engine.AnnTextReviewObject, rectangles: lt.LeadRectD[]): void;  // protected
      constructor();
      thickness: number;
      position: number;
   }

   class SvgDrawingHelper {
      static drawCurve(element: HTMLElement, points: lt.LeadPointD[], tension: number, closed: boolean): void;
      static drawClosedCurve(element: HTMLElement, pts: lt.LeadPointD[], tension: number): void;
      static drawEllipse(element: HTMLElement, mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      static drawPolyline(element: HTMLElement, mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      static drawPicture(element: HTMLElement, picture: lt.Annotations.Engine.AnnPicture, rc: lt.LeadRectD, annObject: lt.Annotations.Engine.AnnObject, mapper: lt.Annotations.Engine.AnnContainerMapper): void;
      static drawHilite(element: HTMLElement, mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      static drawRect(element: HTMLElement, mapper: lt.Annotations.Engine.AnnContainerMapper, annObject: lt.Annotations.Engine.AnnObject): void;
      constructor();
   }

   class AnnSvgHelpers {
      static createElementNS(NS: string, tagName: string): HTMLElement;
      static appendElement(parent: HTMLElement, element: HTMLElement): void;
      static insertBefore(parent: HTMLElement, newChild: HTMLElement, referenceChild: HTMLElement): void;
      static removeElement(parent: HTMLElement, element: HTMLElement): void;
      static getElementById(id: string): HTMLElement;
      static createRoot(): HTMLElement;
      static createRect(): HTMLElement;
      static createClipPath(): HTMLElement;
      static createImage(): HTMLElement;
      static createTSpan(text: string, x: number, y: number): HTMLElement;
      static createGroup(): HTMLElement;
      static createEllipse(): HTMLElement;
      static createText(): HTMLElement;
      static createPolyline(): HTMLElement;
      static createPath(): HTMLElement;
      static setTransformAttribute(element: HTMLElement, matrix: lt.LeadMatrix): void;
      static setFillAttribute(element: HTMLElement, brush: lt.Annotations.Engine.AnnBrush, supportFill: boolean): void;
      static setVisibleAttribute(element: HTMLElement, visible: boolean): void;
      static setPathAttribute(element: HTMLElement, path: string): void;
      static setFillOpacityAttribute(element: HTMLElement, opacity: number): void;
      static setOpacityAttribute(element: HTMLElement, opacity: number): void;
      static setStrokeOpacityAttribute(element: HTMLElement, opacity: number): void;
      static setStrokeAttribute(element: HTMLElement, stroke: lt.Annotations.Engine.AnnStroke, supportStroke: boolean): void;
      static setPointsAttribute(element: HTMLElement, points: lt.LeadPointD[], closed: boolean): void;
      static setEllipseAttribute(element: HTMLElement, rc: lt.LeadRectD): void;
      static setBaselineAttribute(element: HTMLElement, align: string): void;
      static setRectAttribute(element: HTMLElement, rc: lt.LeadRectD): void;
      static setPreserveAspectRatioAttribute(element: HTMLElement, value: string): void;
      static setSourceAttribute(element: HTMLElement, source: string): void;
      static setSourceAttributePngDataUri(element: HTMLElement, data: string): void;
      static setClipPathAttribute(element: HTMLElement, pathId: string): void;
      static setFontAttribute(element: HTMLElement, font: lt.Annotations.Engine.AnnFont): void;
      static getLockId(parentId: string): string;
      static getLabelsId(parentId: string): string;
      static getClipPathId(parentId: string): string;
      static getImageId(parentId: string): string;
      static getPolylineId(parentId: string): string;
      static getSecondPolylineId(parentId: string): string;
      static getEllipseId(parentId: string): string;
      static getGroupId(parentId: string): string;
      static getShadowId(parentId: string): string;
      static getArrowId(parentId: string): string;
      static getRectId(parentId: string): string;
      static getTextBackgroundId(parentId: string): string;
      static getTextId(parentId: string): string;
      static getPointerId(parentId: string): string;
      static svgNameSpace: string;
   }
}
