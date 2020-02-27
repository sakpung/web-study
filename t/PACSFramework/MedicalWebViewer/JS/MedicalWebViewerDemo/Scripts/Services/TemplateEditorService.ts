// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
class Modality {
    public name: string;
    public description: string;
    public classType: string;
    public saveDescription: boolean;

    constructor(name: string, description: string, classType?: string, saveDescription?: boolean) {
        this.name = name;
        this.description = description;
        this.classType = classType;
        this.saveDescription = saveDescription;
    }
}

class TemplateEditorService {
    private _modalities: Array<Modality> = new Array<Modality>();

    private _automation: lt.Annotations.Automation.AnnAutomation;

    public get automation(): lt.Annotations.Automation.AnnAutomation {
        return this._automation;
    }

    public set automation(value: lt.Annotations.Automation.AnnAutomation) {
        this._automation = value;
    }

    private _selectedFrames: Array<Models.Frame>;

    public get selectedFrames(): Array<Models.Frame> {
        return this._selectedFrames;
    }

    public set selectedFrames(value: Array<Models.Frame>) {
        this._selectedFrames = value;
    }

    private _templateController: Controllers.TemplateEditorController;

    public get templateEditController(): Controllers.TemplateEditorController {
        return this._templateController;
    }

    public set templateEditController(value: Controllers.TemplateEditorController) {
        this._templateController = value;
    }

    constructor() {
        this.initializeModalities();
    }

    public loadTemplates(): Array<Models.Frame> {
        return null;
    }

    public deleteSelectedAnnotations() {       
        if (this._automation != null && this._automation.canDeleteObjects) {
            this._automation.deleteSelectedObjects();
        }
    }

    public loadBW2(): Array<Models.Frame> {
        var boxes: Array<Models.Frame> = new Array<Models.Frame>();

        boxes.push(new Models.Frame(new Models.FramePosition(lt.LeadPointD.create(0.06, 0.75), lt.LeadPointD.create(0.45, 0.25))));
        boxes.push(new Models.Frame(new Models.FramePosition(lt.LeadPointD.create(0.55, 0.75), lt.LeadPointD.create(0.94, 0.25))));

        return boxes;
    }

    private initializeModalities() {
        var length: number;

        this._modalities.push(new Modality('IO', 'Intra Oral X-Ray', 'DXIntraoralImageStorageProcessing'));
        this._modalities.push(new Modality('SC', 'Secondary Capture', 'SCImageStorage'));
        this._modalities.push(new Modality('VL', 'Endoscopy', 'VLEndoscopicImageStorage', true));
        this._modalities.push(new Modality('VL', 'Microscopy', 'VLMicroscopicImageStorage', true));
        this._modalities.push(new Modality('VL', 'Photography', 'VLPhotographicImageStorage', true));
        this._modalities.push(new Modality('DX', 'Panaromic', 'DXImageStoragePresentation', true));
        this._modalities.push(new Modality('DX', 'Cephalometric', 'DXImageStoragePresentation', true));
        this._modalities.push(new Modality('DX', 'General', 'DXImageStoragePresentation', true));
        this._modalities.push(new Modality('DX', 'Skull', 'DXImageStoragePresentation', true));
        this._modalities.push(new Modality('MG', 'Mammography', 'DXMammographyImageStorageProcessing'));  
        this._modalities.push(new Modality('CR', 'Computed Radiography', 'CRImageStorage'));          
    }

    public getModalityDescriptions() {
        var descriptions:string = "NONE";
        var length: number = this._modalities.length;

        for (var i = 0; i < length; i++) {
            descriptions += "|" + this._modalities[i].name + ":" + this._modalities[i].description;
        }
        return descriptions;
    }

    public getModalities(): Array<Modality> {
        return this._modalities;
    }
}

services.service('templateEditorService', TemplateEditorService);