// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/LEADTOOLS/jquery/jquery.d.ts" />
/// <reference path="../../lib/LEADTOOLS/Leadtools.d.ts" />
/// <reference path="../../lib/LEADTOOLS/Leadtools.Annotations.Engine.d.ts" />
/// <reference path="../../lib/LEADTOOLS/Leadtools.Annotations.Designers.d.ts" />
/// <reference path="../../lib/LEADTOOLS/Leadtools.Annotations.Automation.d.ts" />
/// <reference path="../../lib/LEADTOOLS/Leadtools.Annotations.Rendering.JavaScript.d.ts" />
/// <reference path="../../lib/LEADTOOLS/Leadtools.Controls.d.ts" />
/// <reference path="../../lib/LEADTOOLS/Leadtools.Controls.Medical.d.ts" />

declare function touchScroll(div);

class OverflowManager {
    private _overflowTag: JQuery;
    private _loader: DicomLoader;
    private _row;
    private _cellSize;
    private _parent: JQuery;
    private _overflowInstances: Array<string>;
    private _overflowInfo: any;
    private _selectedImg: HTMLImageElement;
    private _injectorService: ng.auto.IInjectorService;
    private _layout: any;
    private _dragDropBindings;
    private _eventService: EventService;

    private _horizontal: boolean;

    public get horizontal(): boolean {
        return this._horizontal;
    }

    public set horizontal(value: boolean) {
        this._horizontal = value;
    }    

    constructor(overflowId, loader: DicomLoader, layout, horizontal?: boolean) {
        this._injectorService = angular.element(document.getElementById('app')).injector();

        this._overflowTag = $(overflowId);
        this._parent = this._overflowTag.find('.scroll-body-inner');
        if (this._parent.length == 0)
            this._parent = this._overflowTag;

        this._loader = loader;
        this._horizontal = angular.isDefined(horizontal) ? horizontal : true;
        this._overflowInstances = new Array<string>();
        this._overflowInfo = {};
        this._selectedImg = null;
        this._layout = layout;
        this._dragDropBindings = {};
        this.Initialize();
    }

    private Initialize() {
        var position = lt.LTHelper.getElementStyle(this._overflowTag[0], 'position');

        this._overflowTag[0].style.border = "0px";
        this._overflowTag[0].style.padding = "0px";
        this._overflowTag[0].style.margin = "0px";

    }

    public add(data) {
        setTimeout(function () {
            this._cellSize = this._horizontal ? this._overflowTag.height() * 0.90 : this._overflowTag.width() * 0.80;
        var parentDiv: JQuery = $("<div style='position: relative; border: 0; background-color: black'></div>");
        var size = this._cellSize + "px";

        parentDiv.width(size);
        parentDiv.height(size);
        if (!this._horizontal) {
            parentDiv.css('margin-left', 'auto');
            parentDiv.css('margin-right', 'auto');
            parentDiv.css('margin-top', '5px');
            parentDiv.css('margin-bottom', '0px');
        }
        else {            
            parentDiv.css('margin-left', '5px');
            parentDiv.css('margin-right', '0px');            
            parentDiv.css('margin-bottom', 'auto');               
        }
        parentDiv.attr('id', data.instance.SOPInstanceUID + "_parent");
        this._parent.append(parentDiv);

        if (this.horizontal) {
            var optionsService: OptionsService = this._injectorService.get('optionsService');
            var overflowSize = optionsService.get(OptionNames.SeriesThumbnailWidth) * 2;            
            var margin;

            if (overflowSize > 150)
                overflowSize = 150;

            margin = overflowSize / 2 - this._cellSize / 2;
            parentDiv.css('margin-top', margin + 'px');
        }

        this.CreateViewer(parentDiv[0], data);
        this._overflowInfo[data.instance.SOPInstanceUID] = data;
        this._overflowInstances.push(data.instance.SOPInstanceUID);
        }.bind(this), 500);
    }

    public addInstances(instances: Array<any>) {
        var length: number;

        instances = instances || new Array<any>();
        length = instances.length;
        for (var i = 0; i < length; i++) {
            if (!this.hasInstance(instances[i].instance.SOPInstanceUID)) {
                this.add(instances[i]);
            }
        }
    }

    public hasInstance(instanceUID: string): boolean {
        var children = this._parent.find("#" + instanceUID);

        return children.length > 0;
    }

    public clear() {
        this._parent.empty();
        this._overflowInstances = new Array<string>();
        this._overflowInfo = {};        
    }    

    public get_overflowInstances(): Array<any> {
        var instances: Array<any> = new Array<any>();

        for (var i: number = 0; i < this._overflowInstances.length; i++) {
            if (angular.isDefined(this._overflowInstances[i])) {
                instances.push(this._overflowInfo[this._overflowInstances[i]].instance);
            }
        }

        return instances;
    }

    private CreateViewer(parentDiv, data) {
        var imageElement = document.createElement('img');
        var optionsService: OptionsService = this._injectorService.get('optionsService');
        var authService: AuthenticationService = this._injectorService.get('authenticationService');
        var config = this._injectorService.get('app.config');
        var imageUrl = config.urls.serviceUrl + config.urls.objectRetrieveLocalServiceName;
        var dragDrop: DragDrop.DragDropBinding;
        var cell: lt.Controls.Medical.Cell = data.parentCell;
        var elements: Array<HTMLElement> = new Array<HTMLElement>();

        imageUrl += '/GetImage?';
        imageUrl += 'auth=' + encodeURIComponent(authService.authenticationCode);
        imageUrl += '&instance=' + data.instance.SOPInstanceUID;
        imageUrl += '&frame=0';
        imageUrl += '&mime=' + encodeURIComponent('image/jpeg');
        imageUrl += '&bp=24';
        imageUrl += '&qf=10';
        imageUrl += '&cx=' + Math.ceil(this._cellSize);
        imageUrl += '&cy=' + Math.ceil(this._cellSize);
        imageUrl += '&r=' + Date.now();

        imageElement.setAttribute('id', data.instance.SOPInstanceUID);
        imageElement.src = imageUrl;
        imageElement.alt = "loading...";
        imageElement.style.maxHeight = "100%";
        imageElement.style.maxWidth = "100%";

        if (this._horizontal) {
            imageElement.style.display = 'block';
            imageElement.style.margin = 'auto';
        }

        for (var i = 0; i < cell.imageViewer.items.count; i++) {
            var subCell: lt.Controls.Medical.SubCell = <lt.Controls.Medical.SubCell>(cell.imageViewer.items.item(i));

            $(subCell.overlayCanvas).data('subcell', subCell);            
            elements.push(subCell.overlayCanvas);
            }

        dragDrop = new DragDrop.DragDropBinding(<any>{
            sources: [imageElement],
            targets: elements,
            anchors: [],
            onTargetUp: this.overlayItemDropped.bind(this),
            onMouseDown: this.onMouseDown.bind(this)
        });
        
        dragDrop.start();
        this._dragDropBindings[data.instance.SOPInstanceUID] = dragDrop;        

        parentDiv.appendChild(imageElement);
    }   

    private overlayItemDropped(dragDropBinding: DragDrop.DragDropBinding, element: HTMLElement, targets: HTMLElement[]) {
        var subcell: lt.Controls.Medical.SubCell = <any>(($(targets[0]).data("subcell")));
        var sopInstanceUID: string = element.id;
        var cell: lt.Controls.Medical.Cell = subcell.parentCell;
        var frameMapping = cell.framesMappingIndex;
        var isMapped = false;
        var index = cell.imageViewer.items.indexOf(subcell);

        if (frameMapping && frameMapping[index] != -1) {
            isMapped = true;
        }

        if (subcell.attachedFrame != null || isMapped) {
            var attachedFrame = subcell.attachedFrame;

            if (attachedFrame == null) {
                attachedFrame = cell.frames.item(frameMapping[index]);
            }

            this.onInstanceSwap(null, {
                sopInstanceUID: sopInstanceUID,
                cellFrame: attachedFrame,
                frame: (<any>attachedFrame).FrameIndex,
                instance: (<any>attachedFrame).Instance,
                metadata: (<any>attachedFrame).metadata,
                parentCell: cell,
                subCell: subcell
            });
        }
        else {
            this.onInstanceAdd(null, {
                sopInstanceUID: sopInstanceUID,
                parentCell: cell,
                subCell: subcell
            });
        }        
    }

    private onMouseDown(dragDropBinding: DragDrop.DragDropBinding, element: HTMLElement) {
        if (this._selectedImg != element) {
            this.selectImg(<HTMLImageElement>element, this._selectedImg);
        }
    }

    private selectImg(current: HTMLImageElement, previous: HTMLImageElement) {
        if (previous != null) {
            previous.style.border = '0px';
        }

        if (current != null) {
            current.style.border = '3px solid #5C880C';
            this._selectedImg = current;
        }
    }

    private onInstanceSwap(event, data) {   
        var newInstanceData = this._overflowInfo[data.sopInstanceUID];
        var itemData = {
            frame: data.frame,
            instance: data.instance,
            metadata: data.metadata,
            parentCell: data.parentCell
            };
        var cellFrame: lt.Controls.Medical.Frame = Utils.findFirst((<lt.Controls.Medical.Cell>data.parentCell).frames.toArray(), function (frame: lt.Controls.Medical.Frame) {
            if ((<any>frame).Instance) {
                return (<any>frame).Instance.SOPInstanceUID == data.sopInstanceUID;
            }
            return false;
        });

        if (cellFrame) {            
            (<lt.Controls.Medical.Cell>data.parentCell).imageViewer.beginUpdate();
            
            data.subCell.attachedFrame = cellFrame;
            data.subCell["isMapped"] = true;

            this.add(itemData);
            this.removeInstance(data.sopInstanceUID);
            (<lt.Controls.Medical.Cell>data.parentCell).imageViewer.endUpdate();
            (<lt.Controls.Medical.Cell>data.parentCell).onSizeChanged();
        }                     
    }

    private onInstanceAdd(event, data) {
        var newInstanceData = this._overflowInfo[data.sopInstanceUID];
        var cellFrame: lt.Controls.Medical.Frame = Utils.findFirst((<lt.Controls.Medical.Cell>data.parentCell).frames.toArray(), function (frame: lt.Controls.Medical.Frame) {
            if ((<any>frame).Instance) {
                return (<any>frame).Instance.SOPInstanceUID == data.sopInstanceUID;
            }
            return false;
        });

        if (cellFrame) {
            (<lt.Controls.Medical.Cell>data.parentCell).imageViewer.beginUpdate();
            data.subCell["isMapped"] = true;
            data.subCell.attachedFrame = cellFrame;

            this.removeInstance(data.sopInstanceUID);
            (<lt.Controls.Medical.Cell>data.parentCell).imageViewer.endUpdate();
            (<lt.Controls.Medical.Cell>data.parentCell).onSizeChanged();
        }
    }

    private removeInstance(sopInstanceUID: string) {
        var parentElement: HTMLDivElement = <HTMLDivElement>document.getElementById(sopInstanceUID + "_parent"); 

        if (parentElement != null) {
            var index: number = this._overflowInstances.indexOf(sopInstanceUID);

            $(parentElement).remove();
            if (index != -1) {
                this._overflowInstances.splice(index, 1);
                delete this._overflowInfo[sopInstanceUID];
                delete this._dragDropBindings[sopInstanceUID];

                if (this._overflowInstances.length == 0) {
                    this.checkCanClose(parentElement);
                }
            }
        }
    }

    private checkCanClose(parent: HTMLDivElement) {
        if (this._layout != null) {   
            this._layout.api.closePane(this._layout.direction);         
        }
    }    

    private prepareCellFrame(cellFrame: lt.Controls.Medical.Frame, instanceData) {
        var information = DicomHelper.GetDicomImageInformation(instanceData.metadata);       

        (<any>cellFrame).set_instanceNumber(instanceData.instance.InstanceNumber);
        (<any>cellFrame).metadata = instanceData.metadata;
        (<any>cellFrame).Instance = instanceData.instance;
        (<any>cellFrame).FrameNumber = instanceData.frame + 1;
        (<any>cellFrame).FrameIndex = instanceData.frame

        if (instanceData.frame == 0) {
            var width;
            var height;
            var currentIndex = instanceData.parentCell.frames.indexOf(cellFrame);
            var currentStackIndex = instanceData.parentCell.currentOffset;
            var seriesInstanceUID = instanceData.parentCell.get_seriesInstanceUID();
            
            cellFrame.set_information(information);            
            cellFrame.set_imagePosition(information.position);
            cellFrame.set_imageType(information.imageType);
            cellFrame.set_lossyCompression(information.lossyImageCompression);            
            cellFrame.isWaveForm = information.isWaveForm;           

            width = information.get_width();
            height = information.get_height();

            cellFrame.set_width(width);
            cellFrame.set_height(height); 

            cellFrame.set_rowSpacing(information.rowSpacing);
            cellFrame.set_columnSpacing(information.columnSpacing);            

            (<any>cellFrame).originalSize = { width: information.get_width(), height: information.get_height() };                                    

        }
        else {
            var information = DicomHelper.GetDicomImageInformation(instanceData.metadata);       
            cellFrame.set_information(information);
            (<any>cellFrame).originalSize = { width: information.get_width(), height: information.get_height() };
            cellFrame.set_width(information.get_width());
            cellFrame.set_height(information.get_height());
            cellFrame.isWaveForm = information.isWaveForm; 
        }
    }
};