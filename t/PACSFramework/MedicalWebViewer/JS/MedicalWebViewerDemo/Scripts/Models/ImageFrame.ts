// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************

module Models {
    var ImageFrame = function () { }

ImageFrame.prototype = {
        Instance: {},
        ImageElement: null,
        FrameIndex: 0,
        FrameNumber: 1,
        DicomData: null,
        CanvasData: null,
        DrawingCanvas: null,
        WLRenderer: null,
        ImageData: null,
        IsProcessing: false,
        DataReady: false,
        IsDirty: false,
        updateImageData: true,

        DataCanvasElement: null,
        DataImageElement: null,

        IPFunctionsData: null,
        IPFunctionsName: null

    };



    var FrameSavedProperties = function () { }
FrameSavedProperties.prototype = {

        seriesPropertiesOffsetX: 0,
        seriesPropertiesOffsetY: 0,
        seriesPropertiesScale: 0,
        seriesPropertiesRotateAngle: 0,
        seriesPropertiesFlipped: 0,
        seriesPropertiesReversed: 0,

        framePropertiesOffsetX: 0,
        framePropertiesOffsetY: 0,
        framePropertiesScale: 0,
        framePropertiesSizeMode: 0,
        framePropertiesRotateAngle: 0,
        framePropertiesFlipped: 0,
        framePropertiesReversed: 0

    };


    export class FramePresentationInfo {
        private _cineOptions;

        public get cineOptions() {
            return this._cineOptions;
        }
        public set cineOptions(value) {
            this._cineOptions = value;
        }

        private _orientationOverlay;

        public get orientationOverlay() {
            return this._orientationOverlay;
        }
        public set orientationOverlay(value) {
            this._orientationOverlay = value;
        }

        private _position;

        public get position() {
            return this._position;
        }
        public set position(value) {
            this._position = value;
        }

        private _orientation;

        public get orientation() {
            return this._orientation;
        }
        public set orientation(value) {
            this._orientation = value;
        }

        private _rowSpacing;

        public get rowSpacing() {
            return this._rowSpacing;
        }
        public set rowSpacing(value) {
            this._rowSpacing = value;
        }

        private _columnSpacing;

        public get columnSpacing() {
            return this._columnSpacing;
        }
        public set columnSpacing(value) {
            this._columnSpacing = value;
        }

        private _instanceNumber;

        public get instanceNumber() {
            return this._instanceNumber;
        }
        public set instanceNumber(value) {
            this._instanceNumber = value;
        }

        private _width;

        public get width() {
            return this._width;
        }
        public set width(value) {
            this._width = value;
        }

        private _height;

        public get height() {
            return this._height;
        }
        public set height(value) {
            this._height = value;
        }

        private _patientOrientation;

        public get patientOrientation() {
            return this._patientOrientation;
        }
        public set patientOrientation(value) {
            this._patientOrientation = value;
        }

        constructor() {
            this._cineOptions = null;
            this._orientationOverlay = null;
            this._position = null;
            this._orientation = null;
            this._rowSpacing = 0;
            this._columnSpacing = 0;
            this._instanceNumber = 0;
            this._width = 0;
            this._height = 0;
            this._patientOrientation = null;
        }
    };

    var ImageProperties = function () {
        this.OriginalWindowLevelWidth = 0;
        this.OriginalWindowLevelCenter = 0;
        this.Reset();
    }

ImageProperties.prototype = {
        Reset: function () {
            this.Flipped = false;
            this.Reversed = false;
            this.RotateAngle = 0;
            this.Inverted = false;
            this.WindowLevelWidth = this.OriginalWindowLevelWidth;
            this.WindowLevelCenter = this.OriginalWindowLevelCenter;
            this.OffsetX = 0;
            this.OffsetY = 0;
            this.Scale = 0;
            this.SizeMode = false;
            this.SetDirectly = false;
        },

        ResetScale: function (sizeMode) {
            this.OffsetX = 0;
            this.OffsetY = 0;
            this.Scale = 0;
            this.SizeMode = sizeMode;
        }
    };

    export class ImageProcessingFunction {

        public Name;
        public Parameters;

        constructor() {
            this.Name = null;
            this.Parameters = null;
        }
    };

    class ImageSize {
        public width;
        public height;
        public functions;

        constructor() {
            this.width = 0;
            this.height = 0;
            this.functions = {};
        }
    }
}
