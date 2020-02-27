// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Models {
    export class CodeSequence {
        public CodeValue: string;
        public CodeSchemeDesignator: string;
        public CodingSchemeVersion: string;
        public CodeMeaning: string;

        constructor() {
            this.CodeValue = "";
            this.CodeSchemeDesignator = "";
            this.CodingSchemeVersion = "";
            this.CodeMeaning = "";
        }

        public toString():string {
            return this.CodeMeaning;
        }

        public toFullString(): string {
            var sequenceString = '';

            sequenceString += "[" + this.CodeValue + "," + this.CodeSchemeDesignator + "," + this.CodeMeaning;
            if (this.CodingSchemeVersion && this.CodingSchemeVersion.length > 0)
                sequenceString += "," + this.CodingSchemeVersion;
            sequenceString += "]";
                        
            return sequenceString;
        }
    }

    export class AnatomicDescription {
        public Name: string;
        public AnatomicRegionSequence: CodeSequence;
        public AnatomicRegionModifierSequence: CodeSequence;
        public Laterality: number;   

        constructor() {
            this.Name = '';
            this.AnatomicRegionSequence = new CodeSequence();
            this.AnatomicRegionModifierSequence = new CodeSequence();
            this.Laterality = 0;
        }     
    }

    export class Frame {
        public Position: FramePosition;        
        public Id: string;
        public FrameNumber: number;
        public SequenceNumber: number;        
        public Rotation: FrameRotation;        
        public HorizontalJustification: FrameHorizontalJustification;
        public VerticalJustification: FrameVerticalJustification;
        public PresentationSizeMode: FramePresentationSizeMode;
        public Magnification: number;
        public ImageComments: string;
        public PatientOrientation: string;
        public AnatomicDescription: AnatomicDescription;
        public Script: string;
        public Flip: boolean;
        public Reverse: boolean;
        public Invert: boolean;

        constructor(position: FramePosition) {
            this.Position = position;
            this.Id = UUID.genV4().toString();
            this.FrameNumber = -1;
            this.SequenceNumber = -1;
            this.Rotation = FrameRotation.None;
            this.ImageComments = '';
            this.AnatomicDescription = new AnatomicDescription();
            this.Script = '';
            this.Flip = false;
            this.Reverse = false;
            this.Invert = false;
            this.HorizontalJustification = FrameHorizontalJustification.Center;
            this.VerticalJustification = FrameVerticalJustification.Center;
            this.PresentationSizeMode = FramePresentationSizeMode.ScaleToFit;
            this.Magnification = 1.0;
        }
    }

    export class Template {
        public Id: string;
        public Name: string;
        public CreateDate: Date;
        public Modality: string;
        public Comments: string;
        public AutoMatching: string;
        public BuiltIn: boolean;
        public Hidden: boolean;
        public Frames: Array<Models.Frame>;
        public Availability: TemplateAvailability;

        constructor(name: string) {
            this.Id = UUID.genV4().toString();
            this.Name = name;
            this.CreateDate = new Date();
            this.Modality = "";
            this.Comments = "";
            this.AutoMatching = "";
            this.BuiltIn = false;
            this.Hidden = false;
            this.Frames = new Array<Models.Frame>();
            this.Availability = TemplateAvailability.SeriesAndStudy;
        }
    }    

    export class FramePosition {
        public leftTop: lt.LeadPointD;
        public rightBottom: lt.LeadPointD;

        constructor(leftTop?: lt.LeadPointD, rightBottom?: lt.LeadPointD) {
            this.leftTop = leftTop;
            this.rightBottom = rightBottom;
        }
    }

    export enum FrameRotation {
        None,
        Rotate90,
        Rotate180,
        Rotate270
    }

    export enum FrameHorizontalJustification {
        Left,
        Center,
        Right
    }

    export enum FrameVerticalJustification {
        Top,
        Center,
        Bottom
    }

    export enum Laterality {
        Left,
        Right,
        Both,
        Unpaired
    }

    export enum FramePresentationSizeMode {
        ScaleToFit,
        TrueSize,
        Magnify
    }

    export enum TemplateAvailability {
        None,
        Series,
        Study,
        SeriesAndStudy
    }
}