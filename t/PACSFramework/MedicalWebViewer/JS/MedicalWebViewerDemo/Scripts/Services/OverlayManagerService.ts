// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../Scripts/controllers/OverlaySettingsController.ts" />

class OverlayManagerService {
    static $inject = ['optionsService', 'eventService'];

    private _optionsService: OptionsService = null;
    private _defaultOverlayTags: Controllers.OverlayTags = null;    

    constructor(optionsService: OptionsService, eventService: EventService) {
        this._optionsService = optionsService;
    }

    public getOverlayTags(): Controllers.OverlayTags {
        var data = this._optionsService.get(OptionNames.OverlaySettings);
        var tags: Controllers.OverlayTags;

        if (data == null || data=="") {
            if (this._defaultOverlayTags == null) {
                this._defaultOverlayTags = new Controllers.OverlayTags();
                this.BuildDefaultOverlay();
                this._optionsService.set(OptionNames.OverlaySettings, JSON.stringify(this._defaultOverlayTags));
            }
            tags = this._defaultOverlayTags;
        }
        else {
            tags = JSON.parse(data);
        }

        return tags;
    }

    public saveOverlayTags(overlayTags: Controllers.OverlayTags): ng.IHttpPromise<any>{
        return this._optionsService.saveDefaultOptions({ OverlaySettings: JSON.stringify(overlayTags) });
    }

    public getOverlayType(option) {
        switch (option) {
            case "Window Level":
                return lt.Controls.Medical.OverlayTextType.windowLevel;
            case "Instance Number":
                return lt.Controls.Medical.OverlayTextType.instanceNumber;
            case "User Data":
                return lt.Controls.Medical.OverlayTextType.userData;
            case "Image Quality":
                return lt.Controls.Medical.OverlayTextType.imageQuality;
            case "Frame Number":
                return lt.Controls.Medical.OverlayTextType.frameNumber;
            case "Left Orientation":
                return lt.Controls.Medical.OverlayTextType.leftOrientation;
            case "Right Orientation":
                return lt.Controls.Medical.OverlayTextType.rightOrientation;
            case "Top Orientation":
                return lt.Controls.Medical.OverlayTextType.topOrientation;
            case "Bottom Orientation":
                return lt.Controls.Medical.OverlayTextType.bottomOrientation;
        }

        return lt.Controls.Medical.OverlayTextType.userData;
    }

    public getOverlayTypeName(type) {
        switch (type) {
            case lt.Controls.Medical.OverlayTextType.windowLevel:
                return "WindowLevel";
            case lt.Controls.Medical.OverlayTextType.instanceNumber:
                return "InstanceNumber";
            case lt.Controls.Medical.OverlayTextType.userData:
                return "UserData";
            case lt.Controls.Medical.OverlayTextType.imageQuality:
                return "Image Quality";
            case lt.Controls.Medical.OverlayTextType.frameNumber:
                return "FrameNumber";
            case lt.Controls.Medical.OverlayTextType.leftOrientation:
                return "LeftOrientation";
            case lt.Controls.Medical.OverlayTextType.rightOrientation:
                return "RightOrientation";
            case lt.Controls.Medical.OverlayTextType.topOrientation:
                return "TopOrientation";
            case lt.Controls.Medical.OverlayTextType.bottomOrientation:
                return "BottomOrientation";
        }
        return "UserData";
    }

    private AddTag(cell, text, alignment, overlayType, positionIndex, color?) {
        var overlay = new lt.Controls.Medical.OverlayText();

        overlay.set_text(text);
        overlay.set_alignment(alignment);
        overlay.set_type(overlayType);
        overlay.set_positionIndex(positionIndex);
        overlay.set_color(color == undefined ? "#FFFFFF" : color);

        if (overlayType == lt.Controls.Medical.OverlayTextType.windowLevel) {
            overlay.set_weight(10);
        }

        if (!(cell instanceof lt.Controls.Medical.Cell3D) && !(cell instanceof lt.Controls.Medical.STLCell))
            cell.get_overlays().add(overlay);
        else {
            var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>cell;
            cell3D.labels.add(overlay);
        }
    }

    private AddDefaultTag(location: Array<Controllers.OverlayTag>, title: string, dicomTag?: string, overlayType?: number,color?:string) {
        var tag: Controllers.OverlayTag;

        tag = new Controllers.OverlayTag();
        tag.tag = dicomTag;
        tag.title = title;
        tag.overlayType = overlayType;
        tag.id = UUID.generate();
        tag.color = color == undefined ? "#FFFFFF" : color;

        location.push(tag);
    }

    private BuildDefaultOverlay() {
        this.AddDefaultTag(this._defaultOverlayTags.topRight, "Name: ", DicomTag.PatientName);
        this.AddDefaultTag(this._defaultOverlayTags.topRight, "PID: ", DicomTag.PatientID);
        this.AddDefaultTag(this._defaultOverlayTags.topRight, "Sex: ", DicomTag.PatientSex);
        this.AddDefaultTag(this._defaultOverlayTags.topRight, "DOB: ", DicomTag.PatientBirthDate);

        this.AddDefaultTag(this._defaultOverlayTags.topLeft, "", undefined, lt.Controls.Medical.OverlayTextType.frameNumber);
        this.AddDefaultTag(this._defaultOverlayTags.topLeft, "Acc#: ", DicomTag.AccessionNumber);
        this.AddDefaultTag(this._defaultOverlayTags.topLeft, "Study Date: ", DicomTag.StudyDate); 
        this.AddDefaultTag(this._defaultOverlayTags.topLeft, "Study: ", DicomTag.StudyDescription);
        this.AddDefaultTag(this._defaultOverlayTags.topLeft, "Series: ", DicomTag.SeriesDescription);
        this.AddDefaultTag(this._defaultOverlayTags.topLeft, "Se#: ", DicomTag.SeriesNumber);
        this.AddDefaultTag(this._defaultOverlayTags.topLeft, "", undefined, lt.Controls.Medical.OverlayTextType.instanceNumber);

        this.AddDefaultTag(this._defaultOverlayTags.topLeft, "", undefined, lt.Controls.Medical.OverlayTextType.windowLevel);
        this.AddDefaultTag(this._defaultOverlayTags.topRight, "", undefined, lt.Controls.Medical.OverlayTextType.laterality);
        this.AddDefaultTag(this._defaultOverlayTags.bottomLeft, "", undefined, lt.Controls.Medical.OverlayTextType.imageQuality,"#FF0000");

        this.AddDefaultTag(this._defaultOverlayTags.centerLeft, "", undefined, lt.Controls.Medical.OverlayTextType.leftOrientation);
        this.AddDefaultTag(this._defaultOverlayTags.centerTop, "", undefined, lt.Controls.Medical.OverlayTextType.topOrientation);
        this.AddDefaultTag(this._defaultOverlayTags.centerRight, "", undefined, lt.Controls.Medical.OverlayTextType.rightOrientation);
        this.AddDefaultTag(this._defaultOverlayTags.centerBottom, "", undefined, lt.Controls.Medical.OverlayTextType.bottomOrientation);

        this.AddDefaultTag(this._defaultOverlayTags.bottomRight, "", undefined, lt.Controls.Medical.OverlayTextType.mprType);
        this.AddDefaultTag(this._defaultOverlayTags.bottomLeft, "", undefined, lt.Controls.Medical.OverlayTextType.fieldOfView);
    }


    public set_cellOverlays(cell, metadata, isWaveForm) {
        var overlays: Controllers.OverlayTags = this.getOverlayTags();
        var currentAlignment;
        var addTagFunction = function (index, value) {
            var overlayTag: Controllers.OverlayTag = value;            

            if (currentAlignment == lt.Controls.Medical.OverlayAlignment.bottomRight)
                index += 1;

            if (overlayTag.tag != null && overlayTag.tag.length > 0) {
                var element;
                element = metadata[overlayTag.tag];

                var text = '';

                if (element && element.Value && element.Value.length > 0 && element.vr == 'PN') {
                    text = DicomHelper.getPatientName(metadata, overlayTag.tag);
                }
                else {
                    text = element ? DicomHelper.get_TagValue(metadata, overlayTag.tag) : '';                    
                }

                if (element && element.Value && element.Value.length > 0 && element.vr == 'DA')
                    text = DicomHelper.parseDicomDate(text);

                if (element && element.Value && element.Value.length > 0 && element.vr == 'TM')
                    text = DicomHelper.parseDicomTime(text);


                this.AddTag(cell, overlayTag.title + text, currentAlignment, lt.Controls.Medical.OverlayTextType.userData, index, isWaveForm ? "rgba(0, 0, 0, 1)" : overlayTag.color);
            }
            else if (overlayTag.overlayType != null) {
                if (!isWaveForm) {
                    this.AddTag(cell, overlayTag.title, currentAlignment, overlayTag.overlayType, index, overlayTag.color);
                }
            }
        };        

        currentAlignment = lt.Controls.Medical.OverlayAlignment.topRight;
        $.each(overlays.topRight, $.proxy(addTagFunction, this));

        currentAlignment = lt.Controls.Medical.OverlayAlignment.topLeft;
        $.each(overlays.topLeft, $.proxy(addTagFunction, this));


        if (!(cell instanceof lt.Controls.Medical.Cell3D) && !(cell instanceof lt.Controls.Medical.STLCell))
        {
            currentAlignment = lt.Controls.Medical.OverlayAlignment.bottomRight;
            $.each(overlays.bottomRight, $.proxy(addTagFunction, this));

            currentAlignment = lt.Controls.Medical.OverlayAlignment.bottomLeft;
            $.each(overlays.bottomLeft, $.proxy(addTagFunction, this));        

            currentAlignment = lt.Controls.Medical.OverlayAlignment.centerLeft;
            $.each(overlays.centerLeft, $.proxy(addTagFunction, this));

            currentAlignment = lt.Controls.Medical.OverlayAlignment.centerTop;
            $.each(overlays.centerTop, $.proxy(addTagFunction, this));

            currentAlignment = lt.Controls.Medical.OverlayAlignment.centerRight;
            $.each(overlays.centerRight, $.proxy(addTagFunction, this));

            currentAlignment = lt.Controls.Medical.OverlayAlignment.centerBottom;
            $.each(overlays.centerBottom, $.proxy(addTagFunction, this));
        }
    } 

    public cell_hasOverlays(cell: lt.Controls.Medical.Cell): boolean {
        return cell.overlays.count > 0;
    }
} 

services.service('overlayManagerService', OverlayManagerService);