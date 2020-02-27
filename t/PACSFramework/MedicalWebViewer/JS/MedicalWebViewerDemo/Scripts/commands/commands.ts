// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
declare var commangular;

function emptyFunction(e) {
    if (e.type == 'mouseleave')
        e.currentTarget.style.backgroundColor = 'rgba(255, 255, 255, 0.0)';
    else
        e.currentTarget.style.backgroundColor = 'rgba(255, 255, 255, 0.5)';
}

function ShowStudyTimeLine(tab : Models.Tab, controller, enable) {

    if (enable == controller.studyTimeLineVisible) {
        return;
    }

    controller.studyTimeLineVisible = enable;
    tab.showStudyTimeLine = enable;

    controller.toggleView('south', true, false);


}

var currentInteractiveIcon = {};
var currentInteractiveMode = {};
var currentIcon = {};
var currentIconPressed = {};
var currentIconDisabled = {};
var currentIconDisabledPressed = {};
var parentDiv;
var testDiv;

function PressButton(toolbarService, tab, commandId, showpressed?: boolean) {

    if (commandId == "")
        return;

    if (tab) {
        if (currentIcon[tab.id]) {
            if (currentIcon[tab.id].id == commandId)
                return;
        }
    }


    if (commandId != null) {
        if (angular.isUndefined(showpressed) || showpressed) {
            toolbarService.press(commandId);
        }
    }



    var originalId: string;

    if (currentIcon[tab.id] != null) {

        var enabled = toolbarService.isEnabled(currentIcon[tab.id].id);

        $(currentInteractiveIcon[tab.id]).addClass(enabled ? currentIcon[tab.id].original : currentIconDisabled[tab.id]);
        $(currentInteractiveIcon[tab.id]).removeClass(enabled ? currentIconPressed[tab.id] : currentIconDisabledPressed[tab.id]);
    }

    currentIcon[tab.id] = {};
    originalId = $("#" + commandId + "_icon").attr('original-id');
    currentInteractiveIcon[tab.id] = "#" + commandId + "_icon";
    currentIcon[tab.id].id = commandId;
    currentIcon[tab.id].original = originalId;
    currentIconPressed[tab.id] = originalId + "Pressed";
    currentIconDisabled[tab.id] = "Disabled" + originalId;
    currentIconDisabledPressed[tab.id] = "Disabled" + originalId + "Pressed";
}



function showCustomWindowlevelDialog(toolbarService, seriesManagerService, tab, model) {
    if (toolbarService.isEnabled("WindowLevel" + tab.id)) {
        var modalInstance = null;
        var settings: any = {};
        var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

        var width ;
        var center;

        if (cell instanceof lt.Controls.Medical.Cell3D) {
            var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>cell;
            settings.width = cell3D.information.windowWidth;
            settings.center = cell3D.information.windowCenter;
            settings.originalWindowLevelCenter = cell3D.defaultWindowLevelCenter;
            settings.originalWindowLevelWidth = cell3D.defaultWindowLevelWidth;
        }
        else {
            var frame: lt.Controls.Medical.Frame = seriesManagerService.get_activeCellFrame();
            var renderer = frame.get_wlRenderer();
            if (renderer) {
                settings.width = renderer.get_windowLevelWidth();
                settings.center = renderer.get_windowLevelCenter();
                settings.originalWindowLevelCenter = renderer.originalWindowLevelCenter;
                settings.originalWindowLevelWidth = renderer.originalWindowLevelWidth;
            }
            else
                return;
        }

        modalInstance = model.open({
            templateUrl: 'views/dialogs/WindowLevelCustom.html',
            controller: Controllers.WindowLevelCustomController,
            backdrop: false,
            resolve: {
                settings: function () {
                    return settings;
                }
                ,
                currentFrame: function () {
                    return frame;
                }
                ,
                seriesService: function () {
                    return seriesManagerService;
                }
            }
        });

        if (modalInstance == null)
            return;


        modalInstance.result.then(function (wlSettings) {
            if (cell instanceof lt.Controls.Medical.Cell3D) {
                var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>cell;
                cell3D.information.windowWidth = wlSettings.width;
                cell3D.information.windowCenter = wlSettings.center;
                cell3D.updateWindowLevelValues();
            }
            else {
                var linked = cell.get_linked();

                if (linked) {
                    seriesManagerService.enumerateFrames(cell, function (frame, index) {
                        if (seriesManagerService.withinVisibleRange(cell, index)) {
                            frame.setWindowLevel(wlSettings.width, wlSettings.center);
                        }
                    });
                }
                else {
                    frame.setWindowLevel(wlSettings.width, wlSettings.center);
                }
            }

            toolbarService.unpress("Perio" + tab.id);
            toolbarService.unpress("Endo" + tab.id);
            toolbarService.unpress("Dentin" + tab.id);
        });
    }
}

function HideTab_And_ShiftToolbarButtons() { 
    // to remove the tab from the demo.
    var tabView: HTMLElement = document.getElementById('ltTabWrapper');
    var navTab: any = tabView.getElementsByClassName('nav nav-tabs')[0];
    navTab.style.left = "10000px";
    navTab.style.width = "0px";
    navTab.style.position = "absolute";


    // to scroll the toolbar buttons the left to make room for the MiPACS logo.
    var scrollBarArray = tabView.getElementsByClassName('toolbarbodyArea');

    var scrollBar : any = scrollBarArray[scrollBarArray.length - 1];
    // the scroll ammount


    var width = (lt.LTHelper.device == lt.LTDevice.mobile) ? 56 : 128;
    var height = (lt.LTHelper.device == lt.LTDevice.mobile) ? 26 : 53;
    var marginTop = (lt.LTHelper.device == lt.LTDevice.mobile) ? 8 : 16;

    var scrollBarParent: HTMLElement = scrollBar.parentNode;

    var imageBackground: HTMLDivElement = document.createElement("div");
    imageBackground.className = "appLogo scroll-body";
    imageBackground.style.width = width + "px";
    imageBackground.style.height = "100%";
    imageBackground.style.zIndex = "300";
    imageBackground.style.position = "absolute";




    var image: HTMLImageElement = document.createElement("img");
    image.style.left = "0px";
    image.style.top = "0px";
    image.style.width = width + "px";
    image.style.height = height + "px";
    image.style.position = "absolute";
    image.style.marginTop = marginTop + "px"
    image.style.zIndex = "300";
    image.src = ("images/mipacs2.png");

    var toolbarItem: any = scrollBarParent.children[0];
   
    toolbarItem.style.left = width + "px";


    scrollBarParent.insertBefore(imageBackground, toolbarItem);
    scrollBarParent.insertBefore(image, toolbarItem);
}


function ChangeScrollType(cell: lt.Controls.Medical.Cell) {
    var oldScrollType: lt.Controls.Medical.ScrollType = cell.scrollType;
    var newScrollType = oldScrollType;

    switch (cell.scrollType) {
        case lt.Controls.Medical.ScrollType.none:
            newScrollType = lt.Controls.Medical.ScrollType.normal;
            alert("ScrollType.normal");
            break;
        case lt.Controls.Medical.ScrollType.normal:
            newScrollType = lt.Controls.Medical.ScrollType.row;
            alert("ScrollType.row");
            break;
        case lt.Controls.Medical.ScrollType.row:
            newScrollType = lt.Controls.Medical.ScrollType.column;
            alert("ScrollType.column");
            break;
        case lt.Controls.Medical.ScrollType.column:
            newScrollType = lt.Controls.Medical.ScrollType.page;
            alert("ScrollType.page");
            break;
        case lt.Controls.Medical.ScrollType.page:
            newScrollType = lt.Controls.Medical.ScrollType.none;
            alert("ScrollType.none");
            break;
    }
    cell.scrollType = newScrollType;
}


function GetImageProcessingIndex(cellFrame : lt.Controls.Medical.Frame, commandName: string) {
    var index = 0;
    var length = cellFrame.imageProcessingList.count;

    for (index = 0; index < length; index++) {
        if (cellFrame.imageProcessingList.get_item(index).get_command() == commandName) {
            return index;
        }
    }

    return -1;
}


function ChangeStructureDisplay(e) {
}


function edgeEnhancment(e) {

    var index = e.currentTarget.getAttribute("itemIndex");
    var cellFrame: lt.Controls.Medical.Frame = e.currentTarget.cellFrame;
    var cell: lt.Controls.Medical.Cell = e.currentTarget.cell;

    var ipIndex = GetImageProcessingIndex(cellFrame, "Endo");


    var ip: lt.ImageProcessing = new lt.ImageProcessing();
    ip.set_jsFilePath("");

    ip.set_command("Endo");
    ip.get_arguments()["UnsharpMask"] = (index * 50).toString() + "," + (30 + (index * 5)).toString() + ",0";          

    if (ipIndex == -1)
        cellFrame.imageProcessingList.add(ip);
    else
        cellFrame.imageProcessingList.set_item(parseInt(ipIndex.toString()), ip);
}


function functionClick(e) {
    var index = e.currentTarget.getAttribute("itemIndex");
    var cellFrame :lt.Controls.Medical.Frame = e.currentTarget.cellFrame;

    var cell: lt.Controls.Medical.Cell = e.currentTarget.cell;//parentCell;

    var seriesManagerService = e.currentTarget.seriesManagerService;
    var model = e.currentTarget.model;
    var toolbarService = e.currentTarget.toolbarService;
    var tab = e.currentTarget.tab;
    var info = e.currentTarget.sortInfo;
    var item = e.currentTarget.item;

    if (info == null) {
        showCustomWindowlevelDialog(toolbarService, seriesManagerService, tab, model);
    }
    else {
        if (cell instanceof lt.Controls.Medical.Cell3D) {
            var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>cell;
            cell3D.information.windowWidth = info.W;
            cell3D.information.windowCenter = info.C;
            cell3D.updateWindowLevelValues();
        }
        else {
            if (cell.linked) {
                seriesManagerService.enumerateFrames(cell, function (frame, index) {
                    frame.setWindowLevel(info.W, info.C);
                    frame.currentCustomWindowlevel = item;
                });
            }
            else {
                cellFrame.setWindowLevel(info.W, info.C);
                (<any>cellFrame).currentCustomWindowlevel = item;
            }
        }
    }
}

function camelize(str) {
    return str.replace(/(?:^\w|[A-Z]|\b\w)/g, function (letter, index) {
        return index != 0 ? letter.toLowerCase() : letter.toUpperCase();
    });
}


function getWidthAndCenter(metadata, index) {

    var width;
    var center;
    var windowWidthTag = metadata[DicomTag.WindowWidth];
    var windowCenterTag = metadata[DicomTag.WindowCenter];

    if (windowWidthTag == null)
        windowWidthTag = this.findTag(metadata, DicomTag.WindowWidth);

    if (null != windowWidthTag && windowWidthTag.Value && windowWidthTag.Value.length > index) {
        width = windowWidthTag.Value[index] >> 0;
    }
    else {
        return null;
    }

    if (windowCenterTag == null)
        windowCenterTag = this.findTag(metadata, DicomTag.WindowCenter);

    if (null != windowCenterTag && windowCenterTag.Value && windowCenterTag.Value.length > 0) {
        center = windowCenterTag.Value[0] >> 0;
    }
    else {
        return null;
    }

    return { W : width, C : center };
}


function isFullscreen() {
    return (<any>document).fullscreenElement
        || (<any>document).webkitFullscreenElement
        || (<any>document).mozFullScreenElement
        || (<any>document).webkitCurrentFullScreenElement;

}




var keyDownAdded = false;


//commangular.command('EnableKey', ['seriesManagerService', 'tabService', 'dicomLoaderService', '$commangular', function (seriesManagerService: SeriesManagerService, tabService: TabService, dicomLoaderService: DicomLoaderService, $commangular) {
//    return {
//        execute: function () {

//            window.addEventListener('keydown', function (e) {
//                keyDownAdded = true;
//                if (e.keyCode == 13) {
//                    $commangular.dispatch('ToggleFullScreen');
//                }
//            }, false);
//        }
//    }
//}]);



commangular.command('Pan', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            SetCurrentInteractiveMode(toolbarService, tabService, MedicalViewerAction.Offset, buttonId);
            enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                CommandManager.RunCommand(cell, MedicalViewerAction.Offset, buttonId);
                //cell.runCommand(MedicalViewerAction.Offset);
                //cell.runCommand(MedicalViewerAction.Offset2);
            });
        }
    }
}]);

commangular.command('ZoomToInteractiveMode', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            SetCurrentInteractiveMode(toolbarService, tabService, MedicalViewerAction.Scale, buttonId);
            enumerateCell(tabService, function (cell) {
                //cell.stopCommand(MedicalViewerAction.Offset2);
                CommandManager.RunCommand(cell, MedicalViewerAction.Scale, buttonId);
            });
        }
    }
}]);

commangular.command('InteractiveMagnifyGlass', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            SetCurrentInteractiveMode(toolbarService, tabService, MedicalViewerAction.Magnify, buttonId);
            enumerateCell(tabService, function (cell) {
                //cell.stopCommand(MedicalViewerAction.Offset2);
                //cell.runCommand(MedicalViewerAction.Magnify);
                CommandManager.RunCommand(cell, MedicalViewerAction.Magnify, buttonId);
            });
        }
    }
}]);

commangular.command('InteractiveStack', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            SetCurrentInteractiveMode(toolbarService, tabService, MedicalViewerAction.Stack, buttonId);
            enumerateCell(tabService, function (cell) {
                //cell.stopCommand(MedicalViewerAction.Offset2);
                //cell.runCommand(MedicalViewerAction.Stack);
                CommandManager.RunCommand(cell, MedicalViewerAction.Stack, buttonId);
            });
        }
    }
}]);

commangular.command('WindowLevelInteractiveMode', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

            if (toolbarService.isEnabled("WindowLevel" + tab.id)) {
                SetCurrentInteractiveMode(toolbarService, tabService, MedicalViewerAction.WindowLevel, buttonId);
                enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                    //cell.stopCommand(MedicalViewerAction.Offset2);
                    //cell.runCommand(MedicalViewerAction.WindowLevel);
                    CommandManager.RunCommand(cell, MedicalViewerAction.WindowLevel, buttonId);
                    var command: lt.Controls.Medical.WindowLevelInteractiveMode = cell.getCommandInteractiveMode(MedicalViewerAction.WindowLevel);

                    if (command != null) {
                        var started = function (e: lt.LeadEventHandler) {
                            toolbarService.unpress("Perio" + tab.id);
                            toolbarService.unpress("Endo" + tab.id);
                            toolbarService.unpress("Dentin" + tab.id);
                        }

                        command.add_workStarted(started);
                    }
                });
            }
        }
    }
}]);

function GetPresetWindowLevelValuesArray() : Array<Object> {
    var wlArray: Array<Object> = new Array<Object>();
    
    wlArray.push({ VR: "CT", VoiType: Models.VoiType.Lung,               Text: camelize('LUNG'),                 Info: {W :1500, C :-600 }});
    wlArray.push({ VR: "CT", VoiType: Models.VoiType.Mediastinum,        Text: camelize('MEDIASTINUM'),          Info: {W :640,  C :95 }});
    wlArray.push({ VR: "CT", VoiType: Models.VoiType.AbdoPelvis,         Text: camelize('ABDO PELVIS'),          Info: {W :400,  C :40 }});
    wlArray.push({ VR: "CT", VoiType: Models.VoiType.Liver,              Text: camelize('LIVER'),                Info: {W :160,  C :70 }});
    wlArray.push({ VR: "CT", VoiType: Models.VoiType.SoftTissue,         Text: camelize('SOFT TISSUE'),          Info: {W :400,  C :40 }});
    wlArray.push({ VR: "CT", VoiType: Models.VoiType.Bone,               Text: camelize('BONE'),                 Info: {W :1500, C :150 }});
    wlArray.push({ VR: "CT", VoiType: Models.VoiType.Brain,              Text: camelize('BRAIN'),                Info: {W :150,  C :40 }});
    wlArray.push({ VR: "CT", VoiType: Models.VoiType.PostFossa,          Text: camelize('POST FOSSA'),           Info: {W : 250, C :45 }});

    wlArray.push({ VR: "MR", VoiType: Models.VoiType.BrainT1,            Text: camelize('Brain T1'),             Info: {W :500, C :250}});
    wlArray.push({ VR: "MR", VoiType: Models.VoiType.BrainT2,            Text: camelize('Brain T2'),             Info: {W :350, C :150}});
    wlArray.push({ VR: "MR", VoiType: Models.VoiType.SagT2,              Text: camelize('Sag T2'),               Info: {W :300, C :150}});
    wlArray.push({ VR: "MR", VoiType: Models.VoiType.HeadNeck,           Text: camelize('Head / Neck'),          Info: {W :500, C :250}});
    wlArray.push({ VR: "MR", VoiType: Models.VoiType.Spine,              Text: camelize('Spine'),                Info: {W :500, C :250}});
    wlArray.push({ VR: "MR", VoiType: Models.VoiType.AbdomenPelvisT1,    Text: camelize('Abdomen / Pelvis T1'),  Info: {W :600, C :180}});
    wlArray.push({ VR: "MR", VoiType: Models.VoiType.AbdomenPelvisT2,    Text: camelize('Abdomen/ Pelvis T2'),   Info: {W :850, C :150}});

    wlArray.push({ VR: "US", VoiType: Models.VoiType.LowContrast,        Text: camelize('Low Contrast'),         Info: {W :190, C : 80}});
    wlArray.push({ VR: "US", VoiType: Models.VoiType.MediumContrast,     Text: camelize('Medium Contrast'),      Info: {W :160, C : 70}});
    wlArray.push({ VR: "US", VoiType: Models.VoiType.HighContrast,       Text: camelize('High Contrast'),        Info: {W :120, C : 60}});

    return wlArray;
};


function AddOtherPresetWindowLevelValues(modality, items) {
    var wlArray: Array<Object> = GetPresetWindowLevelValuesArray();

    for (var i: number = 0; i < wlArray.length; i++) {
        var item = wlArray[i];
        if (item["VR"] == modality)
            items.add(item);
    }
}

function FindPresetWindowLevelValue(voiType: Models.VoiType) {
    var wlArray: Array<Object> = GetPresetWindowLevelValuesArray();

    for (var i: number = 0; i < wlArray.length; i++) {
        var item = wlArray[i];
        if (item["VoiType"] == voiType)
            return item;
    }
    return null;
}


//function AddOtherPresetWindowLevelValues(modality, items) {

//    var wlArray: Array<Object> = GetPresetWindowLevelValuesArray();

//    switch (modality) {
//        case 'CT':
//            items.add({ VoiType: Models.VoiType.Lung, Text: camelize('LUNG'), Info: { W: 1500, C: -600 } });
//            items.add({ VoiType: Models.VoiType.Mediastinum, Text: camelize('MEDIASTINUM'), Info: { W: 640, C: 95 } });
//            items.add({ VoiType: Models.VoiType.AbdoPelvis, Text: camelize('ABDO PELVIS'), Info: { W: 400, C: 40 } });
//            items.add({ VoiType: Models.VoiType.Liver, Text: camelize('LIVER'), Info: { W: 160, C: 70 } });
//            items.add({ VoiType: Models.VoiType.SoftTissue, Text: camelize('SOFT TISSUE'), Info: { W: 400, C: 40 } });
//            items.add({ VoiType: Models.VoiType.Bone, Text: camelize('BONE'), Info: { W: 1500, C: 150 } });
//            items.add({ VoiType: Models.VoiType.Brain, Text: camelize('BRAIN'), Info: { W: 150, C: 40 } });
//            items.add({ VoiType: Models.VoiType.PostFossa, Text: camelize('POST FOSSA'), Info: { W: 250, C: 45 } });
//            break;
//        case 'MR':
//            items.add({ VoiType: Models.VoiType.BrainT1, Text: camelize('Brain T1'), Info: { W: 500, C: 250 } });
//            items.add({ VoiType: Models.VoiType.BrainT2, Text: camelize('Brain T2'), Info: { W: 350, C: 150 } });
//            items.add({ VoiType: Models.VoiType.SagT2, Text: camelize('Sag T2'), Info: { W: 300, C: 150 } });
//            items.add({ VoiType: Models.VoiType.HeadNeck, Text: camelize('Head / Neck'), Info: { W: 500, C: 250 } });
//            items.add({ VoiType: Models.VoiType.Spine, Text: camelize('Spine'), Info: { W: 500, C: 250 } });
//            items.add({ VoiType: Models.VoiType.AbdomenPelvisT1, Text: camelize('Abdomen / Pelvis T1'), Info: { W: 600, C: 180 } });
//            items.add({ VoiType: Models.VoiType.AbdomenPelvisT2, Text: camelize('Abdomen/ Pelvis T2'), Info: { W: 850, C: 150 } });
//            break;
//        case 'US':
//            items.add({ VoiType: Models.VoiType.LowContrast, Text: camelize('Low Contrast'), Info: { W: 190, C: 80 } });
//            items.add({ VoiType: Models.VoiType.MediumContrast, Text: camelize('Medium Contrast'), Info: { W: 160, C: 70 } });
//            items.add({ VoiType: Models.VoiType.HighContrast, Text: camelize('High Contrast'), Info: { W: 120, C: 60 } });
//            break;
//    }
//}




commangular.command('OnEdgeEnhancment', ['toolbarService', 'tabService', 'buttonId', '$modal', 'seriesManagerService', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string, $modal, seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {

            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            var cellFrame = seriesManagerService.get_activeCellFrame();
            var metadata = (<any>cellFrame).metadata;



            var index = 0;
            var items: any = [];
            items.add({ Text: " No Effect", Info: 0 });
            for (index = 1; index < 11; index++) {
                items.add({ Text: " Sharpen ( " + (index).toString() + " )", Info: 0 });
            }

            // get the icon.
            var id = 'EdgeEnhancment' + tab.id;
            var icon = document.getElementById(id);

            // show the menu.
            ShowMenu(items, icon, edgeEnhancment, cellFrame, toolbarService, tabService, seriesManagerService, $modal, tab, -1);
        }
    }
}]);


commangular.command('WindowLevelCustom', ['toolbarService', 'tabService', 'buttonId', '$modal', 'seriesManagerService', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string, $modal, seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {

            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            var cellFrame: lt.Controls.Medical.Frame;
            var defaultWW;
            var defaultWC;

            var metadata;
            if (cell instanceof lt.Controls.Medical.Cell3D) {
                var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>cell;
                metadata = cell3D.JSON;
                defaultWW = cell3D.defaultWindowLevelWidth;
                defaultWC = cell3D.defaultWindowLevelCenter
            }
            else {
                cellFrame = seriesManagerService.get_activeCellFrame();
                metadata = (<any>cellFrame).metadata;
                defaultWW = cellFrame.defaultWindowLevelWidth;
                defaultWC = cellFrame.defaultWindowLevelCenter
            }

            var items: any = [];
            if (cell instanceof lt.Controls.Medical.Cell3D) {
                var widthCenter3D = { W: (<any>cell).bone.width, C: (<any>cell).bone.center };
                items.add({ Text: "Bone", Info: widthCenter3D });
            }
            else {
                var explantationTag = metadata[DicomTag.WindowCenterWidthExplanation];
                var modality = metadata[DicomTag.Modality].Value[0];


                // get the menu item text
                var explantationTag = metadata[DicomTag.WindowCenterWidthExplanation];
                var presetValueInDataSet = ((explantationTag != null) && (explantationTag.Value.length > 0));
                if (presetValueInDataSet) {
                    var length = explantationTag.Value.length;
                    var index = 0;

                    for (index = 0; index < length; index++) {
                        var widthCenter = getWidthAndCenter((<any>cellFrame).metadata, index);
                        items.add({ Text: camelize(explantationTag.Value[index]), Info: widthCenter });
                    }
                }

                // adding the modality specific preset window level value.
                AddOtherPresetWindowLevelValues(modality, items);
            }

            var customItem = { VoiType: Models.VoiType.Undefined, Text: "Custom", Info: null };
            // no preset window level value, so just show the custom window level dialog.
            if (items.length == 0) {
                showCustomWindowlevelDialog(toolbarService, seriesManagerService, tab, $modal);
                (<any>cellFrame).currentCustomWindowlevel = customItem;
                return;
            }

            // adding default one, to revert to the original window level value.
            if (!presetValueInDataSet) {
                items.insert(0, { Text: "Auto", Info: { W: defaultWW, C: defaultWC } });
            }

            // custom to show the custom window level dialog.
            items.add(customItem);










            // get the icon.
            var id = 'WindowLevelCustom' + tab.id;
            var icon = document.getElementById(id);
             

            // show the menu.
            ShowMenu(items, icon, functionClick, cellFrame, toolbarService, tabService, seriesManagerService, $modal, tab, -1);
        }
    }
}]);

commangular.command('FitImage', ['seriesManagerService', 'tabService', function (seriesManagerService: SeriesManagerService, tabService: TabService) {
    return {
        execute: function () {
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

            if (cell != null) {
                var linked = cell.get_linked();

                cell.get_imageViewer().beginUpdate();
                if (linked) {
                    seriesManagerService.enumerateFrames(cell, function (frame, index) {
                        frame.set_offsetX(0);
                        frame.set_offsetY(0);
                        frame.zoom(lt.Controls.Medical.MedicalViewerSizeMode.fit, 1);
                    });
                }
                else {
                    var cellFrame = seriesManagerService.get_activeCellFrame();

                    cellFrame.set_offsetX(0);
                    cellFrame.set_offsetY(0);
                    cellFrame.zoom(lt.Controls.Medical.MedicalViewerSizeMode.fit, 1);
                }
                cell.get_imageViewer().endUpdate();
            }
        }
    }
}]);




commangular.command('OnStructureDisplay', ['toolbarService', 'tabService', 'buttonId', '$modal', 'seriesManagerService', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string, $modal, seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {

            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            var cellFrame = seriesManagerService.get_activeCellFrame();
            var metadata = (<any>cellFrame).metadata;



            
            var controller: SearchController = tabService.get_tabData(tab.id, TabDataKeys.ViewController);

            var structuredDisplay: Array<Models.HangingProtocolQueryResult> = seriesManagerService.structuredDisplayList;

            var index = 0;
            var length = structuredDisplay.length;
            var items: any = [];

            for (index = 0; index < length; index++) {
                items.add({ Text: structuredDisplay[index].Name, Info: structuredDisplay[index] });
            }

            // get the icon.
            var id = 'StructureDisplay' + tab.id;
            var icon = document.getElementById(id);

            // show the menu.
            ShowMenu(items, icon, ChangeStructureDisplay, cellFrame, toolbarService, tabService, seriesManagerService, $modal, tab, -1);
        }
    }
}]);

commangular.command('OneToOne', ['seriesManagerService', 'tabService', function (seriesManagerService: SeriesManagerService, tabService: TabService) {
    return {
        execute: function () {
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

            if (cell != null) {
                var linked = cell.get_linked();

                cell.get_imageViewer().beginUpdate();
                if (linked) {
                    seriesManagerService.enumerateFrames(cell, function (frame: lt.Controls.Medical.Frame, index) {
                        frame.zoom(lt.Controls.Medical.MedicalViewerSizeMode.actualSize, 1);
                    });
                }
                else {
                    var cellFrame = seriesManagerService.get_activeCellFrame();

                    cellFrame.zoom(lt.Controls.Medical.MedicalViewerSizeMode.actualSize, 1);
                }
                cell.get_imageViewer().endUpdate();
            }
        }
    }
}]);


function getSortingOperation(sortType : lt.Controls.Medical.SortType, dicomTag: string)
{
    var sortingOp: lt.Controls.Medical.SortingOperation = new lt.Controls.Medical.SortingOperation();
    sortingOp.sortByCategory = sortType;
    sortingOp.selectorAttribute = parseInt(dicomTag, 16);

    return sortingOp;
}

commangular.command('TrueSizeDisplay', ['seriesManagerService', 'tabService', 'toolbarService', '$modal', function (seriesManagerService: SeriesManagerService, tabService: TabService, toolbarService: ToolbarService, $modal) {
    return {
        execute: function ()
        {
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            var cellFrame = seriesManagerService.get_activeCellFrame();

            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

            if (cell != null) {
                var linked = cell.get_linked();

                cell.get_imageViewer().beginUpdate();
                if (linked) {
                    seriesManagerService.enumerateFrames(cell, function (frame: lt.Controls.Medical.Frame, index) {
                        frame.set_offsetX(0);
                        frame.set_offsetY(0);
                        frame.zoom(lt.Controls.Medical.MedicalViewerSizeMode.trueSize, 1);
                    });
                }
                else {
                    var cellFrame = seriesManagerService.get_activeCellFrame();

                    cellFrame.set_offsetX(0);
                    cellFrame.set_offsetY(0);
                    cellFrame.zoom(lt.Controls.Medical.MedicalViewerSizeMode.trueSize, 1);
                }
                cell.get_imageViewer().endUpdate();
            }

        }
    }
}]);

commangular.command('ZoomIn', ['seriesManagerService', 'tabService', function (seriesManagerService: SeriesManagerService, tabService: TabService) {
    return {
        execute: function () {
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            if (cell != null) {
                var linked = cell.get_linked();

                cell.get_imageViewer().beginUpdate();
                if (linked) {
                    seriesManagerService.enumerateFrames(cell, function (frame: lt.Controls.Medical.Frame, index) {
                        frame.zoom(frame.get_scaleMode(), frame.get_scale() * 2);
                    });
                }
                else {
                    var cellFrame: lt.Controls.Medical.Frame = seriesManagerService.get_activeCellFrame();

                    cellFrame.zoom(cellFrame.get_scaleMode(), cellFrame.get_scale() * 2);

                }
                cell.get_imageViewer().endUpdate();
            }
        }
    }
}]);

commangular.command('ZoomOut', ['seriesManagerService', 'tabService', function (seriesManagerService: SeriesManagerService, tabService: TabService) {
    return {
        execute: function () {
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            if (cell != null) {
                var linked = cell.get_linked();

                cell.get_imageViewer().beginUpdate();
                if (linked) {
                    seriesManagerService.enumerateFrames(cell, function (frame: lt.Controls.Medical.Frame, index) {
                        frame.zoom(frame.get_scaleMode(), frame.get_scale() / 2);
                    });
                }
                else {
                    var cellFrame: lt.Controls.Medical.Frame = seriesManagerService.get_activeCellFrame();

                    cellFrame.zoom(cellFrame.get_scaleMode(), cellFrame.get_scale() / 2);

                }
                cell.get_imageViewer().endUpdate();
            }
        }
    }
}]);

commangular.command('RotateClockwise', ['seriesManagerService', 'tabService', function (seriesManagerService: SeriesManagerService, tabService: TabService) {
    return {
        execute: function () {           
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            if (cell != null) {
                var linked = cell.get_linked();

                cell.get_imageViewer().beginUpdate();
                if (linked) {
                    seriesManagerService.enumerateFrames(cell, function (frame, index) {
                        var angle = GetRealRotationAngle(90, frame);

                        frame.set_rotateAngle(frame.get_rotateAngle() + angle);
                        frame.IPFunctionParams.Rotate.Angle = frame.get_rotateAngle();
                    });
                }
                else {
                    var cellFrame = seriesManagerService.get_activeCellFrame();
                    var angle = GetRealRotationAngle(90, cellFrame);

                    cellFrame.set_rotateAngle(cellFrame.get_rotateAngle() + angle);
                }
                cell.get_imageViewer().endUpdate();
            }
        }
    }
}]);




commangular.command('RotateCounterclockwise', ['seriesManagerService', 'tabService', function (seriesManagerService: SeriesManagerService, tabService: TabService) {
    return {
        execute: function () {            
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            if (cell != null) {
                var linked = cell.get_linked();


                cell.get_imageViewer().beginUpdate();
                if (linked) {
                    seriesManagerService.enumerateFrames(cell, function (frame, index) {
                        var angle = GetRealRotationAngle(-90, frame);

                        frame.set_rotateAngle(frame.get_rotateAngle() + angle);                        
                    });
                }
                else {
                    var cellFrame = seriesManagerService.get_activeCellFrame();
                    var angle = GetRealRotationAngle(-90, cellFrame);

                    cellFrame.set_rotateAngle(cellFrame.get_rotateAngle() + angle);                    
                }
                cell.get_imageViewer().endUpdate();
            }
        }
    }
}]);

commangular.command('Flip', ['seriesManagerService', 'tabService', function (seriesManagerService: SeriesManagerService, tabService: TabService) {
    return {
        execute: function () {            
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

            if (cell != null) {
                var linked = cell.get_linked();

                cell.get_imageViewer().beginUpdate();
                if (linked) {
                    seriesManagerService.enumerateFrames(cell, function (frame, index) {
                        frame.set_flipped(!frame.get_flipped());                        
                    });
                }
                else {
                    var cellFrame = seriesManagerService.get_activeCellFrame();

                    cellFrame.set_flipped(!cellFrame.get_flipped());                    
                }
                cell.get_imageViewer().endUpdate();
            }
        }
    }
}]);

commangular.command('Reverse', ['seriesManagerService', 'tabService', function (seriesManagerService: SeriesManagerService, tabService: TabService) {
    return {
        execute: function () {            
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            if (cell != null) {
                var linked = cell.get_linked();

                cell.get_imageViewer().beginUpdate();
                if (linked) {
                    seriesManagerService.enumerateFrames(cell, function (frame, index) {
                        frame.set_reversed(!frame.get_reversed());                        
                    });
                }
                else {
                    var cellFrame = seriesManagerService.get_activeCellFrame();

                    cellFrame.set_reversed(!cellFrame.get_reversed());                    
                }
                cell.get_imageViewer().endUpdate();
            }
        }
    }
}]);

commangular.command('DentalPanoramic', ['seriesManagerService', 'tabService', 'dicomLoaderService', function (seriesManagerService: SeriesManagerService, tabService: TabService, dicomLoaderService: DicomLoaderService) {
    return {
        execute: function () {
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            cell.runCommand(MedicalViewerAction.PanoramicPolygon);

            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            enumerateCell(tabService, function (currentCell: lt.Controls.Medical.Cell) {
                currentCell.drawCrossHairLines = false;
            });
            
        }
    }
}]);



commangular.command('Invert', ['seriesManagerService', 'tabService', 'dicomLoaderService', function (seriesManagerService: SeriesManagerService, tabService: TabService, dicomLoaderService: DicomLoaderService) {
    return {
        execute: function () {
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

            if (cell instanceof lt.Controls.Medical.Cell3D) {
                var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>cell;
                cell3D.inverted = !cell3D.inverted;
                //cell3D.benchmark();

            }
            else
            if (cell != null) {
                var loader: DicomLoader = seriesManagerService.get_seriesLoaderById(cell);
                var linked = cell.get_linked();

                cell.get_imageViewer().beginUpdate();
                if (linked) {
                    var seriesInstanceUID = cell.get_seriesInstanceUID();
                    var instances: Array<any> = seriesManagerService.get_instances(seriesInstanceUID, cell.get_divID());

                    seriesManagerService.enumerateFrames(cell, function (frame: lt.Controls.Medical.Frame, index) {
                        try {
                            var inverted: boolean = !frame.inverted;                            

                            frame.set_inverted(inverted);
                        }
                        catch (exception) { }
                    });
                }
                else {
                    var cellFrame = seriesManagerService.get_activeCellFrame();
                    var inverted: boolean = !cellFrame.inverted;
                    
                    cellFrame.set_inverted(inverted);
                }
                cell.get_imageViewer().endUpdate();
            }
        }
    }
}]);

commangular.command('ShowDicom', ['seriesManagerService', '$modal', function (seriesManagerService: SeriesManagerService, $modal) {
    return {
        execute: function () {

            var cellFrame = null;
            var cell = seriesManagerService.get_activeCell();
            var derivedText;
            if (cell instanceof lt.Controls.Medical.Cell3D) {
                var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>cell;
                cell = cell3D.referenceCell;
                cellFrame = seriesManagerService.get_activeItemForCell(cell).attachedFrame;
            }
            else {
                cellFrame = seriesManagerService.get_activeViewer().attachedFrame;
            }

            if (cellFrame != null) {
                var modalInstance = $modal.open({
                    templateUrl: (lt.LTHelper.device == lt.LTDevice.mobile) ? 'views/dialogs/ViewDicom_Mobile.html': 'views/dialogs/ViewDicom.html',
                    controller: Controllers.ViewDicomController,
                    backdrop: 'static',
                    resolve: {
                        dicom: function () {
                            return cellFrame.metadata;
                        },
                        frame: function () {
                            return cellFrame;
                        }
                    }
                });

            }
        }
    }
}]);

commangular.command('SetLinked', ['seriesManagerService', 'tabService', 'toolbarService', 'optionsService', function (seriesManagerService: SeriesManagerService, tabService: TabService,
    toolbarService: ToolbarService, optionsService : OptionsService) {
    return {
        execute: function () {
            if (tabService.activeTab != -1) {
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
                var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

                if (cell != null) {
                    var linked: boolean = !cell.get_linked();

                    optionsService.set(OptionNames.LinkImages, linked);

                    tabService.set_tabData(tab.id, TabDataKeys.Linked, linked);
                    cell.set_linked(linked);
                    toolbarService.updateClass('LinkImages' + tab.id, 'Linked', 'UnLinked', function () { return linked });
                }
            }
        }
    }
}]);

commangular.command('OnReload', ['seriesManagerService', 'dicomLoaderService', 'toolbarService', 'tabService', function (seriesManagerService: SeriesManagerService, dicomLoaderService: DicomLoaderService, toolbarService: ToolbarService, tabService: TabService) {
    return {
        execute: function () {
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

            if (cell != null) {
                var loader: DicomLoader = seriesManagerService.get_seriesLoaderById(cell);
                var instances: Array<any> = seriesManagerService.get_instances(cell.get_seriesInstanceUID(), cell.get_divID());

                //cell.progress = null;
                seriesManagerService.enumerateFrames(cell, function (frame: lt.Controls.Medical.Frame, index) {                    
                    frame.reset();                    
                    Utils.clearAllShutter(frame);

                    frame.set_offsetX(0);
                    frame.set_offsetY(0);                    
                    if (frame.subCell != null)
                        Utils.subCell_setPresentationMode(<lt.Controls.Medical.MRTISubCell>frame.subCell);
                    frame.horizontalAlignment = lt.Controls.Medical.HorizontalAlignmentType.middle;
                    frame.verticalAlignment = lt.Controls.Medical.VerticalAlignmentType.middle;

                }, function (cell3D: lt.Controls.Medical.Cell3D) {
                    cell3D.reset();
                });

                toolbarService.unpress("Perio" + tab.id);
                toolbarService.unpress("Endo" + tab.id);
                toolbarService.unpress("Dentin" + tab.id);
            }
        }
    }
}]);

commangular.command('OnToggleTags', ['seriesManagerService', 'tabService', 'toolbarService', function (seriesManagerService: SeriesManagerService, tabService: TabService,
    toolbarService: ToolbarService) {
    return {
        execute: function () {
            if (tabService.activeTab != -1) {
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
                var visible = !tabService.get_tabData(tab.id, TabDataKeys.TagToggle);

                enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                    cell.set_overlayTextVisible(visible);
                    cell.onSizeChanged();
                    cell.invalidate();
                });

                tabService.set_tabData(tab.id, TabDataKeys.TagToggle, visible);
            }
        }
    }
}]);

commangular.command('ScrollFrame', ['seriesManagerService', 'tabService', 'toolbarService', function (seriesManagerService: SeriesManagerService, tabService: TabService,
    toolbarService: ToolbarService) {
    return {
        execute: function () {
            if (tabService.activeTab != -1) {
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
                var visible = !tabService.get_tabData(tab.id, TabDataKeys.TagToggle);

                enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                    cell.scrollType = lt.Controls.Medical.ScrollType.normal;
                });

                tabService.set_tabData(tab.id, TabDataKeys.TagToggle, visible);
            }
        }
    }
}]);

commangular.command('ScrollRow', ['seriesManagerService', 'tabService', 'toolbarService', function (seriesManagerService: SeriesManagerService, tabService: TabService,
    toolbarService: ToolbarService) {
    return {
        execute: function () {
            if (tabService.activeTab != -1) {
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
                var visible = !tabService.get_tabData(tab.id, TabDataKeys.TagToggle);

                enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                    cell.scrollType = lt.Controls.Medical.ScrollType.row;
                });

                tabService.set_tabData(tab.id, TabDataKeys.TagToggle, visible);
            }
        }
    }
}]);

commangular.command('ScrollColumn', ['seriesManagerService', 'tabService', 'toolbarService', function (seriesManagerService: SeriesManagerService, tabService: TabService,
    toolbarService: ToolbarService) {
    return {
        execute: function () {
            if (tabService.activeTab != -1) {
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
                var visible = !tabService.get_tabData(tab.id, TabDataKeys.TagToggle);

                enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                    cell.scrollType = lt.Controls.Medical.ScrollType.column;
                });

                tabService.set_tabData(tab.id, TabDataKeys.TagToggle, visible);
            }
        }
    }
}]);




var pointCounter = 0;

commangular.command('PreviousPoint', ['seriesManagerService', 'tabService', 'toolbarService', function (seriesManagerService: SeriesManagerService, tabService: TabService,
    toolbarService: ToolbarService) {
    return {
        execute: function () {
            if (tabService.activeTab != -1) {
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

                pointCounter--;
                if (pointCounter <= 0)
                    pointCounter = 0;


                enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                    cell.invalidate();
                });
            }
        }
    }
}]);


commangular.command('NextPoint', ['seriesManagerService', 'tabService', 'toolbarService', function (seriesManagerService: SeriesManagerService, tabService: TabService,
    toolbarService: ToolbarService) {
    return {
        execute: function () {
            if (tabService.activeTab != -1) {
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

                pointCounter++;

                enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                    cell.invalidate();
                });

            }
        }
    }
}]);




commangular.command('ScrollPage', ['seriesManagerService', 'tabService', 'toolbarService', function (seriesManagerService: SeriesManagerService, tabService: TabService,
    toolbarService: ToolbarService) {
    return {
        execute: function () {
            if (tabService.activeTab != -1) {
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
                var visible = !tabService.get_tabData(tab.id, TabDataKeys.TagToggle);

                enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                    cell.scrollType = lt.Controls.Medical.ScrollType.page;
                });

                tabService.set_tabData(tab.id, TabDataKeys.TagToggle, visible);
            }
        }
    }
}]);

commangular.command('SetEnableSeriesSynchronization', ['seriesManagerService', 'tabService', 'toolbarService', function (seriesManagerService: SeriesManagerService, tabService: TabService,
    toolbarService: ToolbarService) {
    return {
        execute: function () {
            var viewer = tabService.getActiveViewer();

            if (viewer) {
                var synchronization: boolean = !viewer.get_enableSynchronization();
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

                viewer.set_enableSynchronization(synchronization);
                toolbarService.updateClass('SynchronizeSeries' + tab.id, 'EnabledSynchronization', 'Synchronization', function () { return synchronization });
            }
        }
    }
}]);


var LinkedOn: boolean = false;

function markCell(sender, e: lt.Controls.ImageViewerRenderEventArgs) {

    var cell: lt.Controls.Medical.Cell = sender.parentCell;

    if (Studies[cell.studyInstanceUID]) {

        var index = 0;
        var length = Studies[cell.studyInstanceUID].PointsList.length;
        var point: lt.LeadPointD;

        for (index = 0; index < length; index++)
        {
            var frame: lt.Controls.Medical.Frame = Studies[cell.studyInstanceUID].PointsList[index].Frame;
            if (frame.subCell == null)
                continue;

            if (frame.subCell.parentCell != cell)
                continue;
            point = lt.Controls.Medical.Tools.logicalToPhysical(cell.selectedItem, Studies[cell.studyInstanceUID].PointsList[index].Point);

            //if (cell.selectedItem.attachedFrame != frame)
            //    return;

            if (!point)
                return;

            e.context.save();

            e.context.beginPath();
            e.context.strokeStyle = "blue";
            e.context.fillStyle = "blue";
            e.context.rect(point.x - 20, point.y - 20, 40, 40);
            e.context.font = "20px Arial"
            e.context.textAlign = "center";
            e.context.textBaseline = "middle";
            e.context.fillText(index.toString(), point.x, point.y);
            e.context.stroke();
            e.context.restore();
        }
    }

}


function markCellClicked(sender, e: lt.Controls.InteractiveEventArgs) {

    if (e.mouseButton == lt.Controls.MouseButtons.left) {
        var cell: lt.Controls.Medical.Cell = sender;


        AddFidutialPoint(cell, e.position.x, e.position.y);

        //if ((<any>cell).markedPoint == null)
        //    (<any>cell).markedPoint = [];

        //(<any>cell).markedPoint[pointCounter] = { Point: lt.Controls.Medical.Tools.physicalToLogical(cell.selectedItem, lt.LeadPointD.create(e.position.x, e.position.y)), Frame: cell.selectedItem.attachedFrame };
        cell.invalidate();
    }
}


var Studies = [];

function AddFidutialPoint(cell: lt.Controls.Medical.Cell, x: number, y: number) {
    var frame: lt.Controls.Medical.Frame = cell.selectedItem.attachedFrame;

    //var imagePosition = frame.imagePosition;

    //var convertedPoint: number[] = lt.Controls.Medical.Cursor3D.get3DPointPosition(frame, lt.LeadPointD.create(x, y) );

    //var pointPosition = lt.Controls.Medical.LeadPoint3D.create(convertedPoint[0], convertedPoint[1], convertedPoint[2])

    if (!Studies[cell.studyInstanceUID])
    {
        Studies[cell.studyInstanceUID] = {};
    }

    if (Studies[cell.studyInstanceUID].PointsList == null)
        Studies[cell.studyInstanceUID].PointsList = [];

    var point: lt.LeadPointD = lt.Controls.Medical.Tools.physicalToLogical(cell.selectedItem, lt.LeadPointD.create(x, y));

    var previousPoint = Studies[cell.studyInstanceUID].PointsList[pointCounter];

    Studies[cell.studyInstanceUID].PointsList[pointCounter] = { Frame: frame, Point: point };

    if (previousPoint != null)
        previousPoint.Frame.subCell.parentCell.invalidate();
}

commangular.command('SpatialRegsiteration', ['seriesManagerService', 'tabService', 'toolbarService', function (seriesManagerService: SeriesManagerService, tabService: TabService,
    toolbarService: ToolbarService) {
    return {
        execute: function () {


            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
            var medicalViewer: lt.Controls.Medical.MedicalViewer = controller.getViewer();


            var cells: any = [];
            var points: any = [];

            var points1 = [];
            var points2 = [];
            var cells1 = [];


            enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                if (!LinkedOn) {
                    cell.add_postRender(markCell);
                    cell.add_mouseDown(markCellClicked);
                }
                else {
                    cell.remove_postRender(markCell);
                    cell.remove_cellClicked(markCellClicked);

                    cell.invalidate();
                }
            });

            if (LinkedOn) {
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
                var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
                var medicalViewer: lt.Controls.Medical.MedicalViewer = controller.getViewer();

                for (var itemID in Studies) {
                    if (Studies.hasOwnProperty(itemID)) {

                        var item = Studies[itemID];

                        var index = 0;
                        var length = item.PointsList.length;
                        var convertedPoint: lt.Controls.Medical.LeadPoint3D[] = [];
                        var output;

                        for (index = 0; index < length; index++) {
                            output = lt.Controls.Medical.Cursor3DInteractiveMode.get3DPointPosition(item.PointsList[index].Frame, item.PointsList[index].Point);
                            convertedPoint[index] = lt.Controls.Medical.LeadPoint3D.create(output[0], output[1], output[2]);
                        }

                        cells.add(itemID);
                        points.add(convertedPoint);
                    }
                }

                medicalViewer.synchronizeStudies("test", cells, points);
            }


            LinkedOn = !LinkedOn;


        }
    }
}]);



commangular.command('LinkCells', ['seriesManagerService', 'tabService', 'toolbarService', function (seriesManagerService: SeriesManagerService, tabService: TabService,
    toolbarService: ToolbarService) {
    return {
        execute: function () {


            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
            var medicalViewer: lt.Controls.Medical.MedicalViewer = controller.getViewer();

            var cells: any = [];
            var points: any = [];

            var studies: any = [];

            enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {

                if (cell.tickBoxes[0].checked) {
                    var frame: lt.Controls.Medical.Frame = cell.selectedItem.attachedFrame;
                    var position = frame.imagePosition;

                    studies.add(cell.studyInstanceUID);

                    // Here, we are adding only one point, for the crude stack synchronization.
                    var fedutialPoints: any = [];
                    fedutialPoints[0] = lt.Controls.Medical.LeadPoint3D.create(position[0], position[1], position[2]);

                    points.add(fedutialPoints);
                }
            });

            medicalViewer.synchronizeStudies("test", studies, points);
        }

    }
}]);

function CreateDateFormat(now) {
    var date: Date = now;

    var output = date.toLocaleDateString();
    output += "  ";
    output += date.toLocaleTimeString();

    return output;
}


commangular.command('OnSecondaryCapture', ['seriesManagerService', 'tabService', 'optionsService', 'objectStoreService', 'eventService', '$modal', 'dialogs', '$translate', 'toolbarService',
    function (seriesManagerService: SeriesManagerService, tabService: TabService, optionsService: OptionsService, objectStoreService: ObjectStoreService,
        eventService: EventService, $modal, dialogs, $translate, toolbarService : ToolbarService) {
        return {
            execute: function () {

                var tab: Models.Tab = tabService.selectedTab;
                if (!toolbarService.isEnabled("SecondaryCapture" + tab.id))
                    return;

                var derivedInfo: Models.DerivedInfo = new Models.DerivedInfo();
                var metadata = seriesManagerService.get_metaData();
                var cell = seriesManagerService.get_activeCell();

                var derivedText;
                if (cell instanceof lt.Controls.Medical.Cell3D) {
                    derivedText = OptionNames.Derived3DSeriesDescriptionText;
                }
                else if (cell instanceof lt.Controls.Medical.PanoramicCell) {
                    derivedText = OptionNames.DerivedPanoramicSeriesDescriptionText;
                    metadata = cell.frames.get_item(0).JSON;
                }
                else {
                    derivedText = OptionNames.DerivedSeriesDescriptionText;
                }


                if (metadata != null) {
                    var message = "";
                    var title = "";
                    var failedMessage = "";
                    var errorTitle = "";

                    derivedInfo.description = DicomHelper.getDicomTagValue(metadata, DicomTag.SeriesDescription);
                    derivedInfo.protocolName = DicomHelper.getDicomTagValue(metadata, DicomTag.ProtocolName);
                    if (!derivedInfo.description || (derivedInfo.description.length == 0)) {
                        derivedInfo.description = optionsService.get(derivedText);
                    }
                    else {
                        derivedInfo.description += " " + optionsService.get(derivedText);
                    }

                    $translate('NOTIFY_DERIVED_IMAGE_SAVED').then(function (translation) {
                        message = translation;
                    });

                    $translate('NOTIFY_DERIVED_IMAGE_FAILED').then(function (translation) {
                        failedMessage = translation;
                    });

                    $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                        title = translation;
                    });

                    $translate('DIALOGS_ERROR').then(function (translation) {
                        errorTitle = translation;
                    });

                    var modalInstance = $modal.open({
                        templateUrl: 'views/dialogs/SaveAsDerived.html',
                        controller: Controllers.SaveAsDerivedController,
                        backdrop: 'static',
                        resolve: {
                            derivedInfo: function () {
                                return derivedInfo;
                            }
                        }
                    });

                    var __this = this;
                    modalInstance.result.then(function (derivedInfo: Models.DerivedInfo) {
                        var canvasData = seriesManagerService.capture_currentFrame(true);

                        if (canvasData) {
                            var cellFrame = seriesManagerService.get_activeCellFrame();

                            objectStoreService.StoreSecondaryCapture(canvasData, cellFrame.Instance.SOPInstanceUID, derivedInfo.number, derivedInfo.description, derivedInfo.protocolName)
                                .then(function (result) {
                                    if (angular.isDefined(result.data) && angular.isDefined(result.data.Message)) {
                                        dialogs.error(errorTitle, result.data.Message);
                                    }
                                    else {
                                        dialogs.notify(title, message);
                                        result.data.Date = CreateDateFormat(new Date(Date.now()));
                                        eventService.publish(EventNames.DerivedImageCreated, { series: result.data });
                                    }
                                }, function (error) {
                                    dialogs.error(errorTitle, failedMessage);
                                });
                        }
                    });
                }
            }
        }
    }]);


function exportResult(exportManagerService, authenticationService, options, config, title, dialogs)
{
    exportManagerService.Export(options.options, options.source).then(function (result) {
        if (!result)
            return;

        if (!result.data.FaultType) {
            var url: string = result.data;

            url = url.replace(/\"/g, "");
            if (url.indexOf("/Files/") === -1) {
                url = url + "&auth=" + encodeURIComponent(authenticationService.authenticationCode);
            }
            OpenUrl(config.urls.serviceUrl + url, true);
        }
        else {
            dialogs.error(title, result.data.Message);
        }
    }, function (error) {
    });
}


function GetCaptureSize(optionsService) {
    return Math.min(8000, Math.max(100, optionsService.get(OptionNames.CaptureSize)));
}

commangular.command('OnExport', ['seriesManagerService', 'exportManagerService', '$modal', 'app.config', 'dialogs', '$translate', 'objectRetrieveService', 'authenticationService', 'optionsService', function (seriesManagerService: SeriesManagerService,
    exportManagerService: ExportManagerService, $modal, config, dialogs, $translate, objectRetrieveService: ObjectRetrieveService, authenticationService: AuthenticationService, optionsService: OptionsService) {
    return {
        execute: function () {

            if (seriesManagerService.get_activeCell() != null) {
                var seriesInstanceUID = seriesManagerService.activeSeriesInstanceUID;
                var layout = Utils.get_seriesLayout(seriesManagerService.get_activeCell());
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/Export.html',
                    controller: Controllers.ExportController,
                    backdrop: 'static',
                    resolve: {
                        hasLayout: function () {
                            return layout != undefined;
                        }

                    }
                });

                modalInstance.result.then(function (result) {
                    var title: string = "";

                    $translate('DIALOGS_ERROR_EXPORT_TITLE').then(function (translation) {
                        title = translation;
                    });





                     if (result.source == ExportImagesSource.PrintCurrentView)
                        exportManagerService.Export(result.options, result.source);
                     else {
                         result.options.LayoutImageWidth = GetCaptureSize(optionsService);
                        if (result.options.BurnAnnotations) {
                            var cell = seriesManagerService.get_activeCell();
                            if (cell) {
                                var seriesInstanceUID: string = cell.get_seriesInstanceUID();
                                var annotationsData: string = seriesManagerService.get_cellAnnotations(cell);

                                if (annotationsData.length != 0) {
                                    objectRetrieveService.UploadAnnotations(annotationsData).then(function (ret) {
                                            var fileName: string = ret.data.replace(/"/g, "");

                                            result.options.AnnotationsFileName = fileName;
                                            exportResult(exportManagerService, authenticationService, result, config, title, dialogs);
                                    });
                                }
                                else {
                                    exportResult(exportManagerService, authenticationService, result, config, title, dialogs);
                                }
                            }
                        }
                        else {
                            result.options.AnnotationsFileName = "";
                            exportResult(exportManagerService, authenticationService, result, config, title, dialogs);
                        }
                    }
                });
            }
        }
    }
}]);

commangular.command('OnPrint', ['seriesManagerService', 'exportManagerService', '$modal', 'app.config', 'dialogs', '$translate', 'objectRetrieveService', function (seriesManagerService: SeriesManagerService,
    exportManagerService: ExportManagerService, $modal, config, dialogs, $translate, objectRetrieveService: ObjectRetrieveService) {
    return {
        execute: function () {
            if (seriesManagerService.get_activeCell() != null) {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/Print.html',
                    controller: Controllers.PrintController,
                    backdrop: 'static'
                });

                function print(ret) {
                    exportManagerService.Print(ret.options, ret.source).then(function (result) {
                        if (!result.data.FaultType) {
                            var url: string = result.data;

                            url = url.replace(/\"/g, "");
                            OpenUrl(config.urls.serviceUrl + url, true);
                        }
                        else {
                            var title: string = "Printing Error";
                            dialogs.error(title, result.data.Message);
                        }
                    }, function (error) {
                        var title: string = "Printing Error";
                        dialogs.error(title, error);
                    });
                }

                modalInstance.result.then(function (ret) {
                    ret.options.LayoutImageWidth = 1024;
                    if (ret.options.BurnAnnotations) {
                        var cell = seriesManagerService.get_activeCell();
                        if (cell) {
                            var seriesInstanceUID: string = cell.get_seriesInstanceUID();
                            var annotationsData: string = seriesManagerService.get_cellAnnotations(cell);

                            if (annotationsData.length != 0) {
                                objectRetrieveService.UploadAnnotations(annotationsData).then(function (result) {
                                    var fileName: string = result.data.replace(/"/g, "");

                                    ret.options.AnnotationsFileName = fileName;
                                    print(ret);
                                });
                            }
                            else {
                                print(ret);
                            }
                        }
                    }
                    else {
                        ret.options.AnnotationsFileName = "";
                        print(ret);
                    }
                });
            }
        }
    }
}]);

declare var html2canvas;

commangular.command('OnPrintView', ['seriesManagerService', 'exportManagerService', 'tabService', 'app.config', 'dialogs', '$translate', 'objectRetrieveService', function (seriesManagerService: SeriesManagerService,
    exportManagerService: ExportManagerService, tabService: TabService, config, dialogs, $translate, objectRetrieveService: ObjectRetrieveService) {
    return {
        execute: function () {
            var viewer: lt.Controls.Medical.MedicalViewer = tabService.getActiveViewer();
            var element: HTMLElement = document.getElementById(viewer.divId);

            html2canvas(element.parentElement, {
                onrendered: function (canvas) {
                    OpenPrintViewUrl(canvas.toDataURL());
                }
            });
        }
    }
}]);

commangular.command('OnSecondaryCapturePopup', ['seriesManagerService', 'exportManagerService', '$modal', 'app.config', 'dialogs', '$translate', 'authenticationService', 'optionsService', 
    function (seriesManagerService: SeriesManagerService, exportManagerService: ExportManagerService, $modal, config, dialogs, $translate, authenticationService: AuthenticationService, optionsService: OptionsService) {
    return {
        execute: function () {

            // if there is a layout, and "capture layout flag is enabled", then capture the whole layout in a pdf with the size specified in "capture size"
            var layout = Utils.get_seriesLayout(seriesManagerService.get_activeCell());
            if (optionsService.get(OptionNames.CaptureLayout)) {

                var result: any = {};
                result.options = {};

                result.options.LayoutImageWidth = GetCaptureSize(optionsService);
                result.options.AnnotationsFileName = "";
                result.options.Anonymize = false;
                result.options.BurnAnnotations = false;
                result.options.CreateDICOMDIR = false;
                result.options.DczPassword = "";
                result.options.FileFormat = "PDF";
                result.options.ImageCompression = 1;
                result.options.IncludeOverflowImages = false;
                result.options.IncludeViewer = false;
                result.options.PatientInfo = true;
                result.options.ReduceGrayscaleTo8BitsSelected = false;
                result.options.WhiteBackground = false;
                result.source = "Layout";

                exportResult(exportManagerService, authenticationService, result, config, "", dialogs);

            }
            else {
                if (seriesManagerService.get_activeCell() != null) {
                    exportManagerService.PopupCapture();
                }
            }
        }
    }
}]);

commangular.command('OnSort', ['seriesManagerService', 'toolbarService', 'tabService', 'exportManagerService', '$modal', 'app.config', 'dialogs', '$translate', function (seriesManagerService: SeriesManagerService, toolbarService: ToolbarService, tabService: TabService,  exportManagerService: ExportManagerService, $modal, config, dialogs, $translate) {
    return {
        execute: function () {

            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            var cellFrame = seriesManagerService.get_activeCellFrame();
            var metadata = (<any>cellFrame).metadata;
			
            // get the menu item text
            var items = [];

            items[0] = { Text: "Acquisition Time", Info: getSortingOperation(lt.Controls.Medical.SortType.byAcquisitionTime, "") };
            items[1] = { Text: "Axis", Info: getSortingOperation(lt.Controls.Medical.SortType.byAxis, "") };
            items[2] = { Text: "Instance Number", Info: getSortingOperation(lt.Controls.Medical.SortType.none, DicomTag.InstanceNumber) };
            // items[6] = { Text: "Instance Number ↑", Info: getSortingOperation(lt.Controls.Medical.SortType.none, DicomTag.InstanceNumber) };
            // items[7] = { Text: "Instance Number ↓", Info: getSortingOperation(lt.Controls.Medical.SortType.none, DicomTag.InstanceNumber) };


            // get the icon.
            var id = 'SortSeries' + tab.id;
            var icon = document.getElementById(id);
             

            // show the menu.
            ShowMenu(items, icon, sortClick, cellFrame, toolbarService, tabService, seriesManagerService, $modal, tab, currentSelectedSortOrder);
        }
    }
}]);

commangular.command('OnLineProfile', ['seriesManagerService', 'tabService', 'eventService', 'exportManagerService', '$modal', 'app.config', 'dialogs', '$translate', function (seriesManagerService: SeriesManagerService, tabService: TabService, eventService : EventService, exportManagerService: ExportManagerService, $modal, config, dialogs, $translate) {
    return {
        execute: function () {


            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            var frame: lt.Controls.Medical.Frame = seriesManagerService.get_activeCellFrame();


            CommandManager.RunCommand(cell, MedicalViewerAction.LineProfile, "");

            if (!parentDiv) {
                parentDiv = $("<div id='dialog' title='Line Profile' >"+
                   "<canvas id='lineProfileCanvas' z-index='3' style='left:29px; top:10px; position:absolute'></canvas>" +
                   "<canvas id='outerlineProfileCanvas'></canvas>" +
                   "<div align= 'right'>" +
                   "<div style='float: left'> <label><input type='radio' id='radioColor' name='radioButtonGroup' style= 'float: left; display:lock; text-align:left'> Color </input></label></div>" +
                   "<div style='float: right'> <label><input type='radio' id='radioGray' checked='true' name='radioButtonGroup' style= 'float: left; display:lock; text-align:left'> Gray</input></label></div>" +
                   "</div><br/><br/>" +
                   "<label><input id='checkboxRed' checked='true' disabled='true' type='checkbox' value= 'Red' > Red </input> </label><br/>" +
                   "<label><input id='checkboxGreen' checked='true' disabled='true' type='checkbox' value='Green'> Green </input></label> <br/>" +
                   "<label><input id='checkboxBlue' checked='true' disabled='true' type='checkbox' value='Blue'> Blue </input></label><br/>" +
                   "<label  style='float: right'><button type='button' id='closeButton'>Close</button></label><br/>" +
                  "</div>");

                parentDiv.dialog({
                    autoOpen: false
                });

            }



            eventService.subscribe(EventNames.SelectedTabChanged, function (event, data) {
                var tab: Models.Tab = tabService.find_tab(data.args.currentTab.id);
                enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                    CommandManager.RunCommand(cell, MedicalViewerAction.WindowLevel, "");
                    if (cell.lineProfile != null)
                        cell.lineProfile.end();
                }, data.args.previousTab);
                $('#dialog').dialog("close");
            });

            if ($('#dialog').dialog('isOpen'))
              return;

            if (!testDiv) {
                testDiv = $("<div id='dialog2' title='Line Profile' >"+
                   "<canvas id='testCanvas' width = '500' height ='500' z-index='3' style='background-color:red; width:500px; height:500px; position:absolute'></canvas>" +
                   "</div>");

                testDiv.dialog({
                    autoOpen: false
                });

                $('#dialog').on('dialogclose', function (event) {
                    enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                        CommandManager.RunCommand(cell, MedicalViewerAction.WindowLevel, "");
                        if (cell.lineProfile != null)
                            cell.lineProfile.end();
                    });
                });
            }

            $("#dialog").dialog(<any>({
                closeOnEscape: false,
                open: function (event, ui) {
                    $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
                }
            }));

            $("#dialog").dialog("open");


            var mainDiv: any = document.getElementById('dialog');

            var width = mainDiv.clientWidth - 24;
            var height = 220;
            //var left = 29;

            var closeButton: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('closeButton');

            closeButton.addEventListener('click', function (e) { $('#dialog').dialog("close"); }, true);


            var outerlineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('outerlineProfileCanvas');
            var context = outerlineCanvas.getContext('2d');
            var left = context.measureText("65535").width;
            //outerlineCanvas.style.width = width + "px";
            //outerlineCanvas.style.height = height + "px";
            outerlineCanvas.width = width;
            outerlineCanvas.height = height;

            height = 180;


            var innerLineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('lineProfileCanvas');
            var space: number = width / 15;

            width = width - space - left;
            height = height - space;

            //innerLineCanvas.style.width = "300px";//width + "px";
            //innerLineCanvas.style.height = "300px";//height + "px";
            innerLineCanvas.width = width;
            innerLineCanvas.height = height;
            innerLineCanvas.style.left = left + 12 + "px";
            var top = innerLineCanvas.offsetTop - outerlineCanvas.offsetTop;


            var innerLineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('lineProfileCanvas');
            var outerlineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('outerlineProfileCanvas');
            context = outerlineCanvas.getContext('2d');
            context.beginPath();
            context.strokeStyle = 'red';

            context.strokeStyle = "black";
            context.moveTo(left + 0.5, height + top + 1.5);
            context.lineTo(left + width + 0.5, height + top + 1.5);



            context.textAlign = "left";
            context.textBaseline = "top";
            context.fillText("0%", left, top + height);
            context.textAlign = "right";
            context.fillText("100%", left + width - 0.5, top + height);
            if (isGrayScale16())
            {
                context.fillText(frame.information.maxValue <= 0 ? "65556" : frame.information.maxValue.toString(), left - 0.5, 0);
            }
            else
                context.fillText("256", left - 0.5, 0);

            context.textBaseline = "bottom";
            if (isGrayScale16()) {
                context.fillText(frame.information.minValue.toString(), left - 0.5, height + top);
            }
            else {
                context.fillText("0", left - 0.5, height + top);
            }

            context.stroke();

            UpdateSliderPosition(0);


            outerlineCanvas.addEventListener('mousedown', function (e) { outerlineCanvas_mouseDown(outerlineCanvas, e); }, true);
            outerlineCanvas.addEventListener('mousemove', function (e) { outerlineCanvas_mouseMove(outerlineCanvas, e); }, true);
            outerlineCanvas.addEventListener('mouseup', function (e) { outerlineCanvas_mouseUp(outerlineCanvas, e); }, true);
            (<any>outerlineCanvas).onselectstart = function () { return false; };

            innerLineCanvas.addEventListener('mousedown', function (e) { innerLineCanvas_mouseDown(innerLineCanvas, e); }, true);
            innerLineCanvas.addEventListener('mousemove', function (e) { innerLineCanvas_mouseMove(innerLineCanvas, e); }, true);
            innerLineCanvas.addEventListener('mouseup', function (e) { innerLineCanvas_mouseUp(innerLineCanvas, e); }, true);
            (<any>innerLineCanvas).onselectstart = function () { return false; };


            



            var profileColorRadio: any = document.getElementById('radioColor');
            profileColorRadio.addEventListener('click', radioColor);

            var profileGrayRadio: any = document.getElementById('radioGray');
            profileGrayRadio.addEventListener('click', radioGray);


            var redCheckBox: any = document.getElementById('checkboxRed');
            redCheckBox.addEventListener('click', function (e) { checkbox_click("checkboxRed"); });
            var greenCheckBox: any = document.getElementById('checkboxGreen');
            greenCheckBox.addEventListener('click', function (e) { checkbox_click("checkboxGreen"); });
            var blueCheckBox: any = document.getElementById('checkboxBlue');
            blueCheckBox.addEventListener('click', function (e) { checkbox_click("checkboxBlue") });

        }
    }
}]);


commangular.command('OnRunApplication', ['externalApplicationsService', 'exportService', 'seriesManagerService', 'toolbarService', '$modal', function (externalApplicationsService: ExternalApplicationsService,
    exportService: ExportService, seriesManagerService: SeriesManagerService, toolbarService: ToolbarService, $modal) {
    return {
        execute: function () {
            var modalInstance = $modal.open({
                templateUrl: 'views/dialogs/RunApp.html',
                controller: Controllers.RunAppController,
                backdrop: 'static'
            });
        }
    }
}]);

commangular.command('OnAddApplication', ['externalApplicationsService', 'toolbarService', '$modal', function (externalApplicationsService: ExternalApplicationsService, toolbarService: ToolbarService, $modal) {
    return {
        execute: function () {
            var modalInstance = $modal.open({
                templateUrl: 'views/dialogs/AddApp.html',
                controller: Controllers.AddAppController,
                backdrop: 'static'
            });
        }
    }
}]);

commangular.command('OnWaveformBasicAudio', ['seriesManagerService', 'toolbarService', '$modal', function (seriesManagerService: SeriesManagerService,
    toolbarService: ToolbarService, $modal) {
    return {
        execute: function () {
            if (seriesManagerService.get_activeCell() != null) {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/Audio.html',
                    controller: Controllers.AudioController,
                    backdrop: 'static'
                });
            }
        }
    }
}]);

function cinePlayerActive(cell: lt.Controls.Medical.Cell) {
    var index;
    var length = cell.viewer.layout.get_items().get_count();
    for (index = 0; index < length; index++) {
        var currentCell: lt.Controls.Medical.Cell = cell.viewer.layout.get_items().get_item(index);
        if (currentCell.cinePlayer.isPlaying)
            return true;
    }

    return false;
}


commangular.command('OnToggleCine', ['seriesManagerService', 'toolbarService', '$modal', 'cinePlayerService', 'tabService', function (seriesManagerService: SeriesManagerService,
    toolbarService: ToolbarService, $modal, cinePlayerService: CinePlayerService, tabService) {
    return {
        execute: function () {
            var cell = seriesManagerService.get_activeCell();
            var viewer = cell.viewer;
            var checkFound = false;
            var enable = false;

            if (cell != null) {
                var index;
                var length = cell.viewer.layout.get_items().get_count();
                for (index = 0; index < length; index++) {
                    if (viewer.layout.get_items().get_item(index) instanceof lt.Controls.Medical.Cell3D)
                        continue;
                    var currentCell: lt.Controls.Medical.Cell = viewer.layout.get_items().get_item(index);
                    if (currentCell.tickBoxes[0].checked)
                    {
                        checkFound = true;
                        if (!currentCell.cinePlayer.isPlaying) {
                            currentCell.cinePlayer.play();
                            enable = true;
                        }
                        else {
                            currentCell.cinePlayer.stop();
                            enable = false;
                        }
                    }
                }

                if (!checkFound) {
                    if (!cell.cinePlayer.isPlaying)
                        cell.cinePlayer.play();
                    else
                        cell.cinePlayer.stop();

                    enable = !cell.cinePlayer.isPlaying;
                }

                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            
                var menuIcon = "#" + "ToggleCine" + tab.id + "_icon"; 


            }
        }
    }
}]);


commangular.command('CinePlayer', ['seriesManagerService', 'toolbarService', '$modal', 'cinePlayerService', function (seriesManagerService: SeriesManagerService,
    toolbarService: ToolbarService, $modal, cinePlayerService: CinePlayerService) {
    return {
        execute: function () {
            var cell = seriesManagerService.get_activeCell();

            if (cell != null) {
                var modalInstance;

                cinePlayerService.attachCell(cell);
                modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/CinePlayer.html',
                    controller: Controllers.CinePlayerController,
                    backdrop: 'static'
                });
            }
        }
    }
}]);

var _ipInstance: lt.ImageProcessing;

commangular.command('BrightnessContrast', ['seriesManagerService', '$modal', 'toolbarService', 'tabService', function (seriesManagerService: SeriesManagerService, $modal, toolbarService: ToolbarService, tabService: TabService) {
    return {
        execute: function () {
            var cell = seriesManagerService.get_activeCell();

            if (cell != null) {
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

                if (cell && toolbarService.isEnabled("BrightnessContrast" + tab.id)) {
                    var seriesInstanceUID = cell.get_seriesInstanceUID();
                    var modalInstance;

                    modalInstance = $modal.open({
                        templateUrl: 'views/dialogs/BrightnessContrast.html',
                        controller: Controllers.BrightnessContrastController,
                        backdrop: 'static',
                    });

                    modalInstance.result.then(function (ipVals) {
                        var frame: lt.Controls.Medical.Frame = seriesManagerService.get_activeCellFrame();                        
                        var ip: lt.ImageProcessing;                        

                        ip = new lt.ImageProcessing();
                        ip.set_jsFilePath(_jsFileCoreColorPath);
                        ip.set_command("ContrastBrightnessIntensity");
                        ip.get_arguments()["brightness"] = ipVals.brightness * 10;
                        ip.get_arguments()["contrast"] = ipVals.contrast * 10;
                        ip.get_arguments()["intensity"] = 0;

                        frame.imageProcessingList.add(ip);
                        frame.subCell.invalidate();                        
                    });
                }
            }
        }
    }
}]);

commangular.command('HSL', ['seriesManagerService', '$modal', 'toolbarService', 'tabService', function (seriesManagerService: SeriesManagerService, $modal, toolbarService: ToolbarService, tabService: TabService) {
    return {
        execute: function () {
            var cell = seriesManagerService.get_activeCell();
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
           
            if (cell && toolbarService.isEnabled("HSL" + tab.id)) {
                var seriesInstanceUID = cell.get_seriesInstanceUID();
                var modalInstance;

                modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/Hsl.html',
                    controller: Controllers.HSLController,
                    backdrop: 'static',
                });

                modalInstance.result.then(function (ipVals) {
                    var frame = seriesManagerService.get_activeCellFrame();                   
                    var ip: lt.ImageProcessing;

                    ip = new lt.ImageProcessing();
                    ip.set_jsFilePath(_jsFileCoreColorPath);
                    ip.set_command("ChangeHueSaturationIntensity");
                    ip.get_arguments()["hue"] = ipVals.hue * 100;
                    ip.get_arguments()["saturation"] = ipVals.saturation * 10;
                    ip.get_arguments()["intensity"] = ipVals.lightness * 10;  
                    
                    frame.imageProcessingList.add(ip);
                    frame.subCell.invalidate();                  
                });
            }
        }
    }
}]);

commangular.command('StretchHistogram', ['seriesManagerService', '$modal', 'toolbarService', 'tabService', function (seriesManagerService: SeriesManagerService, $modal, toolbarService: ToolbarService, tabService: TabService) {
    return {
        execute: function () {
            var cell = seriesManagerService.get_activeCell();
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
           
            if (cell && toolbarService.isEnabled("StretchHistogram" + tab.id)) {
                var frame = seriesManagerService.get_activeCellFrame();               
                var ip: lt.ImageProcessing;
                
                var canvas = ((frame.lowResImage != null) ? frame.lowResImage.canvas : frame.thumbnailImage.canvas);
                var imageContext = canvas.getContext("2d");
                var imageData = imageContext.getImageData(0, 0, canvas.width, canvas.height);

                var point = lt.Controls.Medical.ImageProcessing.getHistogramPoint(imageData, 10);
                stretchIntensityLow = point.x;
                stretchIntensityHigh = point.y;

                ip = new lt.ImageProcessing();
                ip.set_jsFilePath(_jsFileCoreColorPath);
                ip.set_command("StretchHistogram");
                ip.get_arguments()["low"] = stretchIntensityLow;
                ip.get_arguments()["high"] = stretchIntensityHigh;


                frame.imageProcessingList.add(ip);
                frame.subCell.invalidate(); 
            }
        }
    }
}]);


commangular.command('OnShutterObject', ['seriesManagerService', '$modal', 'toolbarService', 'tabService', function (seriesManagerService: SeriesManagerService, $modal, toolbarService: ToolbarService, tabService: TabService) {
    return {
        execute: function () {
            var cell = seriesManagerService.get_activeCell();
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

            if (cell) {
                var frame = seriesManagerService.get_activeCellFrame();


                var tab = tabService.get_allTabs()[tabService.activeTab];
                var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
                var medicalViewer = controller.getViewer();

                if (medicalViewer == null)
                    return;

                var automation = cell.get_automation();
                if (automation == null)
                    return;

                var editObject = automation.get_currentEditObject();

                if (!editObject) {
                    alert("no selected annotation object found!");
                    return;
                }

                if (!lt.Controls.Medical.ShutterObject.isValid(editObject)) {
                    alert("Cannot create a shutter using the selected annotation object");
                    return;
                }

                frame.get_shutter().get_objects().clear();

                frame.get_shutter().get_objects().add(automation.get_currentEditObject());
                frame.get_shutter().fillStyle = "rgba(0, 0, 0, 1)";

            }
        }
    }
}]);


var _automationFrame;
var _automation;

commangular.command('OnShutterObjectFreeHand', ['seriesManagerService', '$modal', 'toolbarService', 'tabService', function (seriesManagerService: SeriesManagerService, $modal, toolbarService: ToolbarService, tabService: TabService) {
    return {
        execute: function () {
            var cell = seriesManagerService.get_activeCell();
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

            enumerateCell(tabService, function (cell) {
                CommandManager.RunCommand(cell, MedicalViewerAction.ShutterFreeHand, "");
            });
        }
    }
}]);

commangular.command('OnShutterObjectPolygon', ['seriesManagerService', '$modal', 'toolbarService', 'tabService', function (seriesManagerService: SeriesManagerService, $modal, toolbarService: ToolbarService, tabService: TabService) {
    return {
        execute: function () {
            var cell = seriesManagerService.get_activeCell();
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

            enumerateCell(tabService, function (cell) {
                CommandManager.RunCommand(cell, MedicalViewerAction.ShutterPolygon, "");
            });
        }
    }
}]);

commangular.command('OnShutterObjectRectangle', ['seriesManagerService', '$modal', 'toolbarService', 'tabService', function (seriesManagerService: SeriesManagerService, $modal, toolbarService: ToolbarService, tabService: TabService) {
    return {
        execute: function () {
            var cell = seriesManagerService.get_activeCell();
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

            enumerateCell(tabService, function (cell) {
                CommandManager.RunCommand(cell, MedicalViewerAction.ShutterRect, "");
            });
        }
    }
}]);

commangular.command('OnShutterObjectEllipse', ['seriesManagerService', '$modal', 'toolbarService', 'tabService', function (seriesManagerService: SeriesManagerService, $modal, toolbarService: ToolbarService, tabService: TabService) {
    return {
        execute: function () {
            var cell = seriesManagerService.get_activeCell();
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

            enumerateCell(tabService, function (cell) {
                CommandManager.RunCommand(cell, MedicalViewerAction.ShutterEllipse, "");
            });
        }
    }
}]);



commangular.command('OnProbeTool', ['seriesManagerService', '$modal', 'toolbarService', 'tabService', 'buttonId', function (seriesManagerService: SeriesManagerService, $modal, toolbarService: ToolbarService, tabService: TabService, buttonId:string) {
    return {
        execute: function () {
            SetCurrentInteractiveMode(toolbarService, tabService, MedicalViewerAction.ProbeTool, buttonId);
            enumerateCell(tabService, function (cell) {
                //cell.runCommand(MedicalViewerAction.ProbeTool);
                CommandManager.RunCommand(cell, MedicalViewerAction.ProbeTool, buttonId);
            });
        }
    }
}]);

commangular.command('OnCrossHair', ['seriesManagerService', '$modal', 'toolbarService', 'tabService', 'buttonId', function (seriesManagerService: SeriesManagerService, $modal, toolbarService: ToolbarService, tabService: TabService, buttonId:string) {
    return {
        execute: function () {
            enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                cell.drawCrossHairLines = !cell.drawCrossHairLines;
            });
        }
    }
}]);


commangular.command('OnCursor3D', ['seriesManagerService', '$modal', 'toolbarService', 'tabService', 'buttonId', function (seriesManagerService: SeriesManagerService, $modal, toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            SetCurrentInteractiveMode(toolbarService, tabService, MedicalViewerAction.Cursor3D, buttonId, false);
            enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                CommandManager.RunCommand(cell, MedicalViewerAction.Cursor3D, buttonId);
            });
        }
    }
}]);

commangular.command('Compose', ['toolbarService', 'tabService', 'buttonId', 'authenticationService', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string, authenticationService: AuthenticationService) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.selectedTab;
            var controller: Controllers.ViewerController = tabService.get_tabData(tab.id, TabDataKeys.ViewController);

            var canSaveHangingProtocol = authenticationService.hasPermission(PermissionNames.CanSaveHangingProtocol);
            var canSaveStructuredDisplay = authenticationService.hasPermission(PermissionNames.CanSaveStructuredDisplay);

            if (!(canSaveStructuredDisplay && canSaveHangingProtocol))
                return;

            
            toolbarService.enable('DeleteStudyStructuredDisplay' + tab.id, function () {
                return canSaveStructuredDisplay;
            });

            toolbarService.enable('SaveStructuredDisplay' + tab.id, function () {
                return canSaveStructuredDisplay;
            });

           



            toolbarService.enable('HangingProtocol' + tab.id, function () {
                return canSaveHangingProtocol;
            });

            if (controller.isComposing) {
                toolbarService.unpress('LayoutCompose' + tab.id);
                toolbarService.hide(['MergeCells' + tab.id, 'SaveStructuredDisplay' + tab.id, 'DeleteStudyStructuredDisplay' + tab.id, 'HangingProtocol' + tab.id]);
                toolbarService.disable('MergeCells' + tab.id);

                if (!controller['reShowTimeLine'])
                    controller.hideTimeLine();
            }
            else {
                toolbarService.press('LayoutCompose' + tab.id);
                toolbarService.show(['MergeCells' + tab.id, 'SaveStructuredDisplay' + tab.id, 'DeleteStudyStructuredDisplay' + tab.id, 'HangingProtocol' + tab.id]);
                toolbarService.enable("DeleteStudyStructuredDisplay" + tab.id, function () {
                    return controller.hasLayout();
                });
                controller['reShowTimeLine'] = controller.isTimeLineShowing();
                controller.showTimeLine();
            }

            controller.isComposing = !controller.isComposing;
        }
    }
}]);

commangular.command('MergeCells', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.selectedTab;
            var controller: Controllers.ViewerController = tabService.get_tabData(tab.id, TabDataKeys.ViewController);

            controller.mergeSelectedCells();
        }
    }
}]);

commangular.command('DeleteStudyStructuredDisplay', ['toolbarService', 'tabService', 'objectStoreService', '$translate', 'dialogs', function (toolbarService: ToolbarService, tabService: TabService, objectStoreService: ObjectStoreService, $translate, dialogs) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.selectedTab;
            var controller: Controllers.ViewerController = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
            var studyLayout: Models.StudyLayout = controller.getStudyLayout();
            var message: string, failedMessage: string;
            var title: string, errorTitle: string;

            $translate('NOTIFY_DELETE_STUDYLAYOUT_FAILED').then(function (translation) {
                failedMessage = translation;
            });

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                title = translation;
            });

            $translate('DIALOGS_ERROR').then(function (translation) {
                errorTitle = translation;
            });

            objectStoreService.DeleteStudyLayout(studyLayout['studyInstanceUID']).then(function (result) {
                if (angular.isDefined(result.data) && angular.isDefined(result.data.Message)) {
                    dialogs.error(errorTitle, result.data.Message);
                }
                else {
                    $translate('NOTIFY_DELETE_STUDYLAYOUT_SUCCESS').then(function (translation) {
                        dialogs.notify(title, translation);
                    });
                    controller.clearLayout();
                    toolbarService.enable("DeleteStudyStructuredDisplay" + tab.id, function () {
                        return false;
                    });
                }
            },
                function (error) {
                    dialogs.error(errorTitle, error);
                })
        }
    }
}]);

commangular.command('HangingProtocol', ['toolbarService', 'tabService', 'buttonId', '$modal', 'seriesManagerService', 'objectStoreService', '$translate', 'dialogs', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string, $modal, seriesManagerService: SeriesManagerService, objectStoreService: ObjectStoreService, $translate, dialogs) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            var modalInstance;
            var metadata = null;
            var primaryCell = HangingProtocolHelper.get_PrimaryCell(cell.viewer, seriesManagerService);
            var hp: Models.HangingProtocol;
            var viewer: lt.Controls.Medical.MedicalViewer = cell.viewer;
            var title: string;
            var successMessage: string;

            if (primaryCell.frames.count > 0) {
                var frame: lt.Controls.Medical.Frame = primaryCell.frames.item(0);

                metadata = frame['metadata'];
            }

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                title = translation;
            });

            $translate('NOTIFY_SAVE_HP_SUCCESS').then(function (translation) {
                successMessage = translation;
            });

            hp = HangingProtocolHelper.get_HangingProtocol(primaryCell.viewer, primaryCell, metadata);
            modalInstance = $modal.open({
                templateUrl: 'views/dialogs/HangingProtocol.html',
                controller: Controllers.HPDialogControllerScope,
                backdrop: 'static',
                resolve: {
                    dataset: function () {
                        return metadata;
                    },
                    hp: function () {
                        return hp;
                    }
                }
            });

            modalInstance.result.then(function () {
                angular.forEach(hp.DisplaySets, function (displaySet: Models.DisplaySet, index) {
                    delete displaySet['cell'];
                    delete displaySet['metadata'];
                });

                angular.forEach(hp.ImageSetsSequence, function (imageSet: Models.ImageSet, index) {
                    delete imageSet['metadata'];
                });

                viewer.layout.highlightedItems.clear();

                objectStoreService.StoreHangingProtocol(hp).success(function (response) {
                    if (angular.isDefined(response.FaultType)) {
                        alert(response.Message);
                    }
                    else {
                        dialogs.notify(title, successMessage);
                    }
                }).
                    error(function (error) {
                        alert(error);
                    });

            }, function () {
                viewer.layout.highlightedItems.clear();
            });
        }
    }
}]);

commangular.command('SaveStructuredDisplay', ['seriesManagerService', 'eventService', 'tabService', 'objectStoreService', 'dialogs', '$translate', 'toolbarService', function (seriesManagerService: SeriesManagerService, eventService: EventService, tabService: TabService, objectStoreService: ObjectStoreService, dialogs, $translate, toolbarService: ToolbarService) {
    return {
        execute: function () {
            var studyLayout: Models.StudyLayout = new Models.StudyLayout();
            var medicalViewer: lt.Controls.Medical.MedicalViewer = tabService.getActiveViewer();
            var studyInstanceUID = '';
            var title: string = '';
            var message: string = '';
            var number: number = 1;
            var activeStudyInstanceUID = tabService.get_tabData(tabService.selectedTab.id, TabDataKeys.LaunchingStudy);

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                title = translation;
            });

            $translate('NOTIFY_STRUCTUREDDISPLAY_SUCCESS').then(function (translation) {
                message = translation;
            });
            

            if (medicalViewer.cellsArrangement == lt.Controls.Medical.CellsArrangement.grid) {
                studyLayout.Rows = medicalViewer.gridLayout.rows;
                studyLayout.Columns = medicalViewer.gridLayout.columns;
            }

            enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                var seriesItem: Models.SeriesInfo = new Models.SeriesInfo();
                var box: Models.ImageBox = HangingProtocolHelper.get_cellImageBox(cell, number);
                var series = seriesManagerService.get_seriesInfo(cell.seriesInstanceUID);
                var instances: Array<any> = seriesManagerService.get_instances(cell.seriesInstanceUID, cell.divID);

                var activeFrame: lt.Controls.Medical.Frame = HangingProtocolHelper.get_activeFrame(cell);

                // Display Set Horizontal Justification (Optional)
                box.HorizontalJustification = HangingProtocolHelper.ConvertToFrameHorizontalJustication(activeFrame.horizontalAlignment);

                // Display Set Vertical Justification (Optional)        
                box.VerticalJustification = HangingProtocolHelper.ConvertToFrameVerticalJustication(activeFrame.verticalAlignment);

                seriesItem.AnnotationData = seriesManagerService.get_cellAnnotations(cell);
                if (!activeStudyInstanceUID && series) {
                    activeStudyInstanceUID = series.StudyInstanceUID;
                }

                seriesItem.StudyInstanceUID = series.StudyInstanceUID;
                seriesItem.SeriesInstanceUID = cell.seriesInstanceUID;
                if (series.StudyInstanceUID == activeStudyInstanceUID) {
                    studyLayout.SeriesPush(seriesItem);
                }
                else {
                    var otherStudies: Array<Models.OtherStudies> = $.grep(studyLayout.OtherStudies, function (item: Models.OtherStudies) {
                        return item.StudyInstanceUID == series.StudyInstanceUID;
                    });
                    var study: Models.OtherStudies;

                    if (otherStudies.length > 0) {
                        study = otherStudies[0];
                    }
                    else {
                        study = new Models.OtherStudies();
                        study.StudyInstanceUID = series.StudyInstanceUID;
                        studyLayout.OtherStudies.push(study);
                    }

                    study.Series.push(seriesItem);
                }
                seriesItem.ImageBoxNumber = box.ImageBoxNumber;
                studyLayout.Boxes.push(box);

                number++;
            });

            enumerateEmptyCell(tabService, function (cell: lt.Controls.Medical.EmptyCell) {
                var box: Models.ImageBox = new Models.ImageBox();
                var seriesItem: Models.SeriesInfo = new Models.SeriesInfo();

                box.Position = HangingProtocolHelper.get_position(cell.bounds);
                box.ImageBoxNumber = number;
                if (medicalViewer.cellsArrangement == lt.Controls.Medical.CellsArrangement.grid) {
                    box.RowPosition = cell.rowPosition;
                    box.ColumnPosition = cell.columnsPosition;
                    box.NumberOfRows = cell.numberOfRows;
                    box.NumberOfColumns = cell.numberOfColumns;
                }
                studyLayout.Boxes.push(box);
                number++;
            });

            objectStoreService.StoreStudyLayout(activeStudyInstanceUID, studyLayout).success(function (response) {
                if (angular.isDefined(response.FaultType)) {
                    alert(response.Message);
                }
                else {
                    var controller = tabService.get_tabData(tabService.selectedTab.id, TabDataKeys.ViewController);

                    controller.setStudyLayout(studyLayout);
                    dialogs.notify(title, message);
                    toolbarService.enable("DeleteStudyStructuredDisplay" + tabService.selectedTab.id, function () {
                        return true;
                    });
                }
            }).
                error(function (error) {
                    alert(error);
                });
        }
    }
}]);

commangular.command('ImageAlignLeft', ['seriesManagerService', function (seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

            if (cell) {
                var linked = cell.get_linked();

                if (linked) {
                    seriesManagerService.enumerateFrames(cell, function (frame: lt.Controls.Medical.Frame, index) {
                        frame.horizontalAlignment = lt.Controls.Medical.HorizontalAlignmentType.left;
                    });
                }
                else {
                var cellFrame = seriesManagerService.get_activeCellFrame();
                cellFrame.horizontalAlignment = lt.Controls.Medical.HorizontalAlignmentType.left;
            }
        }
    }
    }
}]);

commangular.command('ImageAlignRight', ['seriesManagerService', function (seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

            if (cell) {
                var linked = cell.get_linked();

                if (linked) {
                    seriesManagerService.enumerateFrames(cell, function (frame: lt.Controls.Medical.Frame, index) {
                        frame.horizontalAlignment = lt.Controls.Medical.HorizontalAlignmentType.right;
                    });
                }
                else {
                var cellFrame = seriesManagerService.get_activeCellFrame();

                cellFrame.horizontalAlignment = lt.Controls.Medical.HorizontalAlignmentType.right;
            }
        }
    }
    }
}]);

commangular.command('ImageAlignCenter', ['seriesManagerService', function (seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

            var linked = cell.get_linked();

            if (linked) {
                seriesManagerService.enumerateFrames(cell, function (cellFrame: lt.Controls.Medical.Frame, index) {
                    cellFrame.horizontalAlignment = lt.Controls.Medical.HorizontalAlignmentType.middle;
                });
            }
            else {
                var cellFrame = seriesManagerService.get_activeCellFrame();

                cellFrame.horizontalAlignment = lt.Controls.Medical.HorizontalAlignmentType.middle;
            }
        }
    }
}]);

commangular.command('ImageAlignTop', ['seriesManagerService', function (seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

            var linked = cell.get_linked();
            if (linked) {
                seriesManagerService.enumerateFrames(cell, function (cellFrame: lt.Controls.Medical.Frame, index) {
                    cellFrame.verticalAlignment = lt.Controls.Medical.VerticalAlignmentType.top;
                });
            }
            else {
            if (cell) {
                var cellFrame = seriesManagerService.get_activeCellFrame();

                cellFrame.verticalAlignment = lt.Controls.Medical.VerticalAlignmentType.top;
            }
        }
    }
    }
}]);

commangular.command('ImageAlignBottom', ['seriesManagerService', function (seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

            var linked = cell.get_linked();
            if (linked) {
                seriesManagerService.enumerateFrames(cell, function (cellFrame: lt.Controls.Medical.Frame, index) {
                    cellFrame.verticalAlignment = lt.Controls.Medical.VerticalAlignmentType.bottom;
                });
            }
            else {
            if (cell) {
                var cellFrame = seriesManagerService.get_activeCellFrame();

                cellFrame.verticalAlignment = lt.Controls.Medical.VerticalAlignmentType.bottom;
            }
        }
    }
    }
}]);

commangular.command('ImageAlignMiddle', ['seriesManagerService', function (seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

            var linked = cell.get_linked();
            if (linked) {
                seriesManagerService.enumerateFrames(cell, function (cellFrame: lt.Controls.Medical.Frame, index) {
                    cellFrame.verticalAlignment = lt.Controls.Medical.VerticalAlignmentType.middle;
                });
            }
            else {
            if (cell) {
                var cellFrame = seriesManagerService.get_activeCellFrame();

                cellFrame.verticalAlignment = lt.Controls.Medical.VerticalAlignmentType.middle;
            }
        }
    }
    }
}]);


function copyOverlays(mprCell: lt.Controls.Medical.Cell, cell: lt.Controls.Medical.Cell) {

    var length = cell.get_overlays().get_count();
    var index = 0;
    var overlay: lt.Controls.Medical.OverlayText;
    var newOverlay: lt.Controls.Medical.OverlayText;

    for (index = 0; index < length; index++) {
        overlay = cell.get_overlays().get_item(index);

        newOverlay = new lt.Controls.Medical.OverlayText();

        if (overlay.type == lt.Controls.Medical.OverlayTextType.userData)
            newOverlay.text = overlay.text;

        newOverlay.type = overlay.type;
        newOverlay.positionIndex = overlay.positionIndex;
        newOverlay.weight = overlay.weight;
        newOverlay.color = overlay.color;
        newOverlay.alignment = overlay.alignment;

        mprCell.get_overlays().add(newOverlay);
    }
}

function reArrangeCellBasedOnMPRType(mprCell, mprType) {
    switch (mprType) {
        case lt.Controls.Medical.CellMPRType.sagittal:
            mprCell.rowPosition = 1;
            mprCell.columnsPosition = -1;
            break;
        case lt.Controls.Medical.CellMPRType.coronal:
            mprCell.rowPosition = 1;
            mprCell.columnsPosition = -1;
            break;
        case lt.Controls.Medical.CellMPRType.axial:
            mprCell.rowPosition = 0;
            mprCell.columnsPosition = -1;
            break;
    }
}   

function find3DObject(medicalViewer, cell) {
    var index = 0;
    var length = medicalViewer.layout.get_items().get_count();
    var cell;

    for (index = 0; index < length; index++) {
        var currentCell = medicalViewer.layout.get_items().get_item(index);
        if (currentCell instanceof lt.Controls.Medical. Cell3D) {
            if (((<any>currentCell).stackInstanceUID == cell.stackInstanceUID) && (currentCell.seriesInstanceUID == cell.seriesInstanceUID))
                return currentCell;
        }
    }

    return null;
}

function GetMPRFramePosition(cell: lt.Controls.Medical.Cell, mprType: lt.Controls.Medical.CellMPRType) {

    if (cell.mprType == mprType)
        return cell.currentOffset;
    if (cell.derivatives != null) {

        if (cell.derivatives.get_item(0) != null) {
            if (cell.derivatives.get_item(0).mprType == mprType)
                return cell.derivatives.get_item(0).currentOffset;
        }

        if (cell.derivatives.get_item(1) != null) {
            if (cell.derivatives.get_item(1).mprType == mprType)
                return cell.derivatives.get_item(1).currentOffset;
        }
    }
    return -1;
}

function ConnectMPRWith3DObject(cell, parentCell, viewer, queryArchiveService) {
    if (queryArchiveService != null) {
        cell.add_currentOffsetChanged(function () {

            var cell3D: lt.Controls.Medical.Cell3D = find3DObject(viewer, parentCell);
            if (cell3D == null)
                return;

            cell3D.beginUpdate();
            cell3D.MPR.axialPosition = GetMPRFramePosition(parentCell, lt.Controls.Medical.CellMPRType.axial);
            cell3D.MPR.sagittalPosition = GetMPRFramePosition(parentCell, lt.Controls.Medical.CellMPRType.sagittal);
            cell3D.MPR.coronalPosition = GetMPRFramePosition(parentCell, lt.Controls.Medical.CellMPRType.coronal);
            cell3D.endUpdate();

        });
    }
}

function createMPRCell(objectRetrieveService: ObjectRetrieveService, queryArchiveService: QueryArchiveService, seriesManagerService: SeriesManagerService, viewer: lt.Controls.Medical.MedicalViewer, cell: lt.Controls.Medical.Cell, mprType: lt.Controls.Medical.CellMPRType, eventService: EventService, serverSideRendering : boolean) {
    var cellName = 'MedicalCell' + Date.now();

    var tab1: Models.Tab = seriesManagerService.get_seriesTab(cell.get_seriesInstanceUID());
    var seriesInfo = seriesManagerService.get_seriesInfo(cell.get_seriesInstanceUID());

    var seriesInstanceUID = cell.get_seriesInstanceUID();

    switch (mprType) {
        case lt.Controls.Medical.CellMPRType.sagittal:
            seriesInstanceUID += "_Sagittal";
            cellName = cell.divID + "_Sagittal";
            break;
        case lt.Controls.Medical.CellMPRType.coronal:
            seriesInstanceUID += "_Coronal";
            cellName = cell.divID + "_Coronal";
            break;
        case lt.Controls.Medical.CellMPRType.axial:
            seriesInstanceUID += "_Axial";
            cellName = cell.divID + "_Axial";
            break;
    }

    var newSeriesInfo = jQuery.extend(true, {}, seriesInfo);
    newSeriesInfo.InstanceUID = seriesInstanceUID;

    seriesManagerService.set_seriesTab(seriesInstanceUID, tab1);
    seriesManagerService.set_seriesInfo(seriesInstanceUID, newSeriesInfo);
    seriesManagerService.set_activeCell(seriesInstanceUID);

    var mprCell = new lt.Controls.Medical.MPRCell(cell, mprType, cellName, serverSideRendering);

    mprCell.add_frameRequested(function (sender, args: lt.Controls.Medical.MPRFrameRequestedEventArgs) {

        var cell3D: lt.Controls.Medical.Cell3D = (<any>cell).cell3D;
        if (cell3D.object3D.volumeReady)
            args.image.src = objectRetrieveService.GetMPRFrame(cell3D.object3D.id, args.mprType, args.index);
    });

    mprCell.tickBoxes[0].visible = false;


    reArrangeCellBasedOnMPRType(mprCell, mprType);


    mprCell.frameOfReferenceUID = cell.frameOfReferenceUID;
    ConnectMPRWith3DObject(mprCell, cell, viewer, queryArchiveService);


    mprCell.overlayTextVisible = cell.overlayTextVisible;



    var castViewer: any = viewer;

    var series: MedicalViewerSeries = new MedicalViewerSeries(newSeriesInfo.InstanceUID, "", 1, 1);
    series.seriesInstanceUID = newSeriesInfo.InstanceUID;
    series.link = cell.get_linked();

    castViewer.InitializeCell(mprCell, series);

    CommandManager.RunCommand(mprCell, CommandManager.LastCommand.Action, CommandManager.LastCommand.ButtonID);
    return mprCell;
}


var _seriesManagerService;

function MakeRoomFor(viewer: lt.Controls.Medical.MedicalViewer, roomFor) {
    var desiredNumber = viewer.layout.items.count + roomFor;

    if (roomFor == 0)
        return;

    if (viewer.cellsArrangement == lt.Controls.Medical.CellsArrangement.grid) {
        if (desiredNumber >= viewer.gridLayout.rows * viewer.gridLayout.columns) {
            var rows = Math.floor(Math.sqrt(desiredNumber));
            var col = Math.ceil(desiredNumber / rows);


            viewer.layout.beginUpdate();

            viewer.gridLayout.rows = rows;
            viewer.gridLayout.columns = col;

            viewer.layout.endUpdate();
        }
    }
}


function VolumeWithMPR(seriesManagerService: SeriesManagerService, $modal, toolbarService: ToolbarService, tabService: TabService, eventService: EventService, queryArchiveService: QueryArchiveService, overlayManagerService: OverlayManagerService, optionsService: OptionsService, objectRetrieveService: ObjectRetrieveService, volumeType : lt.Controls.Medical.VolumeType) {
       
    var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
    var currentController = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
    var side: string = <string>(optionsService.get(OptionNames.MPRRenderSide))
    var serverSideRendering: boolean = side.trim() == "Server Side";
    var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();


    if (currentController != null && seriesManagerService.get_activeCell() != null) {

        var viewer: lt.Controls.Medical.MedicalViewer = currentController.getViewer();

        if (alreadyHaveA3Dobject(cell, volumeType))
            return;

        MakeRoomFor(viewer, Math.max(0, 3 - cell.derivatives.count));

        Create3DObject(seriesManagerService, toolbarService, tabService, queryArchiveService, overlayManagerService, optionsService, eventService, volumeType);

        var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

        if (cell instanceof lt.Controls.Medical.Cell3D) {
            cell = (<lt.Controls.Medical.Cell3D>cell).referenceCell;
            if (viewer.layout.items.indexOf(cell) == -1)
                return;
        }

        if (cell.derivatives.count != 0) {
            return;
        }


        var status: lt.Controls.Medical.MPRStatus = lt.Controls.Medical.MPRCell.canDoMPR(cell);

        switch (status) {
            case lt.Controls.Medical.MPRStatus.imageOrientationNotTheSame:
                alert('An MPR cannot be created for this cell, because each frame in the cell has a different orientation.');
                return;
            case lt.Controls.Medical.MPRStatus.ok:
                break;
            case lt.Controls.Medical.MPRStatus.cellNotValid:
                alert('You can\'t create an MPR image out of this cell');
                return;
            case lt.Controls.Medical.MPRStatus.imagePositionNotReady:
                alert('The first and second position of the cell is not present');
                return;
            case lt.Controls.Medical.MPRStatus.notEnoughFrames:
                alert('the cell must have at least 3 frames to generate MPR cell out of it');
                return;
            case lt.Controls.Medical.MPRStatus.allFramesNotReady:
                alert('cell data is not downloaded yet');
                return;
        }

        cell.currentOffset = cell.frames.count >> 1;

        var firstCellMPRType: lt.Controls.Medical.CellMPRType;
        var secondCellMPRType: lt.Controls.Medical.CellMPRType;
        switch (cell.mprType) {

            case lt.Controls.Medical.CellMPRType.axial:
                firstCellMPRType = lt.Controls.Medical.CellMPRType.coronal;
                secondCellMPRType = lt.Controls.Medical.CellMPRType.sagittal;
                break;

            case lt.Controls.Medical.CellMPRType.coronal:
                firstCellMPRType = lt.Controls.Medical.CellMPRType.axial;
                secondCellMPRType = lt.Controls.Medical.CellMPRType.sagittal;
                break;

            case lt.Controls.Medical.CellMPRType.sagittal:
                firstCellMPRType = lt.Controls.Medical.CellMPRType.axial;
                secondCellMPRType = lt.Controls.Medical.CellMPRType.coronal;
                break;
        }

        var loadingDiv: any;


        function generateMPRCells(sender, e) {

            if (cell instanceof lt.Controls.Medical.Cell3D) {
                cell = <any>(cell).referenceCell;
            }

            var mprCell = createMPRCell(objectRetrieveService, queryArchiveService, seriesManagerService, viewer, cell, firstCellMPRType, eventService, serverSideRendering);
            copyOverlays(mprCell, cell);
            mprCell = createMPRCell(objectRetrieveService, queryArchiveService, seriesManagerService, viewer, cell, secondCellMPRType, eventService, serverSideRendering);
            copyOverlays(mprCell, cell);


            toolbarService.enable("CrossHair" + tab.id, function () {
                return cell.derivatives.count > 0;
            });

            enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                cell.drawCrossHairLines = true;
            });


            loadingDiv = cell.div.getElementsByClassName('loader' + cell.div.id)[0];
            if (loadingDiv != null) {
                cell.div.removeChild(loadingDiv);
                loadingDiv.id = '';
            }
            cell.viewer.layout.selectedItem = cell;

        }


        function generateMPRLayout(sender, e) {

            generateMPRCells(sender, e);

        }

        function progressCompleted(sender, e) {

            loadingDiv = document.createElement("div");
            loadingDiv.id = 'loader';
            loadingDiv.className = 'loader' + cell.div.id;

            cell.div.appendChild(loadingDiv);

            if (lt.LTHelper.device == lt.LTDevice.desktop && lt.LTHelper.browser != lt.LTBrowser.internetExplorer && !serverSideRendering) {
                if (cell.frames.count > 200) {
                    cell.create3D = true;
                }
                else
                    generateMPRLayout(null, null);
            }
            else
                generateMPRLayout(null, null);



            cell.add_data3DGenerated(generateMPRLayout);
        }



        if (!cell.fullDownload && (!serverSideRendering)) {
            cell.fullDownload = true;
            cell.add_progressCompleted(progressCompleted);
        }
        else
            progressCompleted(null, null);

        reArrangeCellBasedOnMPRType(cell, cell.mprType);

    }
}

commangular.command('OnMPR', ['seriesManagerService', '$modal', 'toolbarService', 'tabService', 'eventService', 'queryArchiveService', 'overlayManagerService', 'optionsService', 'objectRetrieveService', function (seriesManagerService: SeriesManagerService, $modal, toolbarService: ToolbarService, tabService: TabService, eventService: EventService, queryArchiveService: QueryArchiveService, overlayManagerService: OverlayManagerService, optionsService: OptionsService, objectRetrieveService: ObjectRetrieveService) {
    return {
        execute: function () {

        }
    }
}]);

function toggleImageProcessing(frame: any, ip: lt.ImageProcessing, items: Array<string>): boolean {   
    var ipList: Array<any> = frame.imageProcessingList.toArray();
    var ipItem = $.grep(ipList, function (item) { return item.command == ip.command });    

    removeImageProcessing(frame, items);
    if (ipItem && ipItem.length > 0) {
        frame.imageProcessingList.remove(ipItem[0]);
        return true;
    }
    else {
        frame.imageProcessingList.add(ip);       
    }

    return false; 
}

function removeImageProcessing(frame: lt.Controls.Medical.Frame, items: Array<string>) {
    for (var i = 0; i < items.length; i++) {
        var ipList: Array<any> = frame.imageProcessingList.toArray();
        var ipItem = $.grep(ipList, function (item) { return item.command == items[i] });

        if (ipItem && ipItem.length > 0) {
            frame.imageProcessingList.remove(ipItem[0]);
            return true;
        }
    }
}

function imageProcessingReady(sender: lt.Controls.Medical.Cell, e: lt.Controls.Medical.ImageProcessingReadyEventArgs) {
    sender.imageProcessingReady.remove(imageProcessingReady);

    (<any>sender).ip.toolbarService.enable((<any>sender).ip.buttons, function () {
        return true;
    });
}

commangular.command('OnTogglePerio', ['seriesManagerService', 'tabService', 'toolbarService', '$commangular', function (seriesManagerService: SeriesManagerService, tabService: TabService, toolbarService: ToolbarService, $commangular) {
    return {
        execute: function () {
            var cell = seriesManagerService.get_activeCell();
            var unpress: boolean = false;
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            
            if (cell != null) {
                var linked = cell.get_linked();                                
                var ip: lt.ImageProcessing;

                ip = new lt.ImageProcessing();  
                ip.set_jsFilePath('');              
                ip.set_command("Perio");
                ip.get_arguments()["MultiscaleEnhancement"] = "1000,-1,-1,-1,-1,'Gaussian'=";
                ip.get_arguments()["GammaCorrect"] = "65=";
                ip.get_arguments()["UnsharpMask"] = "150,150,0";               

                if (linked) {
                    var activeFrame = seriesManagerService.get_activeCellFrame();

                    seriesManagerService.enumerateFrames(cell, function (frame: lt.Controls.Medical.Frame, index) {
                        var shouldUnpress = toggleImageProcessing(frame, ip, ["Endo", "Dentin"]);                                                  

                        if (frame == activeFrame && !shouldUnpress) {
                            unpress = true;
                        }                                                
                    });
                }
                else {
                    var frame: lt.Controls.Medical.Frame = seriesManagerService.get_activeCellFrame();
                    var shouldUnpress = toggleImageProcessing(frame, ip, ["Endo", "Dentin"]); 
                    
                    if (!shouldUnpress) {
                        // the code below disables the button during processing  to address the problem that happens when you alternate between Endo, Perio and Dentin
                        //var buttons: Array<string> = ["Endo" + tab.id, "Dentin" + tab.id];

                        //(<any>cell).ip = {
                        //    toolbarService: toolbarService,
                        //    buttons: buttons
                        //}
                        //toolbarService.enable(buttons, function () {
                        //    return false;
                        //});
                        cell.imageProcessingReady.add(imageProcessingReady);
                    }                   

                    unpress = shouldUnpress;                    
                }

                if (!unpress) {
                    toolbarService.press("Perio" + tabService.get_allTabs()[tabService.activeTab].id);
                }
                else {
                    toolbarService.unpress("Perio" + tabService.get_allTabs()[tabService.activeTab].id);
                }
                toolbarService.unpress("Endo" + tabService.get_allTabs()[tabService.activeTab].id);
                toolbarService.unpress("Dentin" + tabService.get_allTabs()[tabService.activeTab].id);
            }
        }
    }
}]);

commangular.command('OnToggleDentin', ['seriesManagerService', 'tabService', 'toolbarService', '$commangular', function (seriesManagerService: SeriesManagerService, tabService: TabService, toolbarService: ToolbarService, $commangular) {
    return {
        execute: function () {
            var cell = seriesManagerService.get_activeCell();
            var unpress: boolean = false;   
             var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];        

            if (cell != null) {
                var linked = cell.get_linked();
                var ip: lt.ImageProcessing;

                ip = new lt.ImageProcessing(); 
                ip.set_jsFilePath('');
                ip.set_command("Dentin"); 
                ip.get_arguments()["MultiscaleEnhancement"] = "1000,-1,-1,-1,-1,'Gaussian'=";
                ip.get_arguments()["GammaCorrect"] = "76=";
                ip.get_arguments()["UnsharpMask"] = "150,150,0";                      

                if (linked) {
                    var activeFrame = seriesManagerService.get_activeCellFrame();

                    seriesManagerService.enumerateFrames(cell, function (frame: lt.Controls.Medical.Frame, index) {
                        var shouldUnpress = toggleImageProcessing(frame, ip, ["Endo", "Perio"]);

                        if (frame == activeFrame && !shouldUnpress) {
                            unpress = true;
                        }                        
                    });
                }
                else {
                    var frame: lt.Controls.Medical.Frame = seriesManagerService.get_activeCellFrame();
                    var shouldUnpress = toggleImageProcessing(frame, ip, ["Endo", "Perio"]);

                    if (!shouldUnpress) {
                        // the code below disables the button during processing  to address the problem that happens when you alternate between Endo, Perio and Dentin
                        //var buttons: Array<string> = ["Endo" + tab.id, "Perio" + tab.id];

                        //(<any>cell).ip = {
                        //    toolbarService: toolbarService,
                        //    buttons: buttons
                        //}
                        //toolbarService.enable(buttons, function () {
                        //    return false;
                        //});
                        cell.imageProcessingReady.add(imageProcessingReady);
                    } 

                    unpress = shouldUnpress;                    
                }
               
                if (!unpress) {
                    toolbarService.press("Dentin" + tabService.get_allTabs()[tabService.activeTab].id);
                }
                else {
                    toolbarService.unpress("Dentin" + tabService.get_allTabs()[tabService.activeTab].id);
                }

                toolbarService.unpress("Perio" + tabService.get_allTabs()[tabService.activeTab].id);
                toolbarService.unpress("Endo" + tabService.get_allTabs()[tabService.activeTab].id);
            }
        }
    }
}]);

commangular.command('OnToggleEndo', ['seriesManagerService', 'tabService', 'toolbarService', '$commangular', function (seriesManagerService: SeriesManagerService, tabService: TabService, toolbarService: ToolbarService, $commangular) {
    return {
        execute: function () {
            var cell = seriesManagerService.get_activeCell();
            var unpress: boolean = false;    
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];       

            if (cell != null) {
                var linked = cell.get_linked();
                var ip: lt.ImageProcessing;

                ip = new lt.ImageProcessing();
                ip.set_jsFilePath('');
                ip.set_command("Endo");
                ip.get_arguments()["MultiscaleEnhancement"] = "1000,-1,-1,-1,-1,'Gaussian'=";
                ip.get_arguments()["GammaCorrect"] = "85=";
                ip.get_arguments()["UnsharpMask"] = "150,150,0";          

                if (linked) {
                    var activeFrame = seriesManagerService.get_activeCellFrame();

                    seriesManagerService.enumerateFrames(cell, function (frame: lt.Controls.Medical.Frame, index) {
                        var shouldUnpress = toggleImageProcessing(frame, ip, ["Perio", "Dentin"]);

                        if (frame == activeFrame && !shouldUnpress) {
                            unpress = true;
                        }

                        frame.subCell.invalidate(); 
                    });
                }
                else {
                    var frame: lt.Controls.Medical.Frame = seriesManagerService.get_activeCellFrame();
                    var shouldUnpress = toggleImageProcessing(frame, ip, ["Perio", "Dentin"]);

                    unpress = shouldUnpress;
                    if (!shouldUnpress) {
                        // the code below disables the button during processing  to address the problem that happens when you alternate between Endo, Perio and Dentin
                        //var buttons: Array<string> = ["Dentin" + tab.id, "Perio" + tab.id];

                        //(<any>cell).ip = {
                        //    toolbarService: toolbarService,
                        //    buttons: buttons
                        //}
                        //toolbarService.enable(buttons, function () {
                        //    return false;
                        //});
                        cell.imageProcessingReady.add(imageProcessingReady);
                    } 
                   
                }
               
                if (!unpress) {
                    toolbarService.press("Endo" + tabService.get_allTabs()[tabService.activeTab].id);
                }
                else {
                    toolbarService.unpress("Endo" + tabService.get_allTabs()[tabService.activeTab].id);
                }

                toolbarService.unpress("Perio" + tabService.get_allTabs()[tabService.activeTab].id);
                toolbarService.unpress("Dentin" + tabService.get_allTabs()[tabService.activeTab].id);
            }
        }
    }
}]);

commangular.command('StudyTimeLine', ['tabService', function (tabService: TabService) {
    return {
        execute: function () {
            if (tabService.activeTab != -1) {
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
                var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);

                ShowStudyTimeLine(tab, controller, !controller.studyTimeLineVisible);
            }
        }
    }
}]);

commangular.command('Compare', ['seriesManagerService', 'tabService', 'series', 'eventService', function (seriesManagerService: SeriesManagerService, tabService: TabService, series: Array<any>, eventService) {
    return {
        execute: function () {
            try {
                eventService.publish(EventNames.SeriesSelected, {
                    study: null,
                    series: series,
                    remote: false,
                    forCompare: true
                });
            }
            catch (e)
            {
                console.log(e);
            }
            finally {
            }
            //$rootScope.$apply();
        }
    }
}]);

commangular.command('OnStudyLayout', ['seriesManagerService', '$modal', 'tabService', function (seriesManagerService: SeriesManagerService, $modal, tabService: TabService) {
    return {
        execute: function () {
            var layout: any = {};
            var modalInstance;
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
            var medicalViewer: lt.Controls.Medical.MedicalViewer = controller.getViewer();

            if (medicalViewer.exploded) {
                medicalViewer.explode(<lt.Controls.Medical.Cell>medicalViewer.explodedCell, false);
            }

            layout.rows = parseInt(<any>medicalViewer.get_gridLayout().get_rows());
            layout.columns = parseInt(<any>medicalViewer.get_gridLayout().get_columns());
            if (angular.isDefined((<any>medicalViewer).customLayout)) {
                layout.custom = (<any>medicalViewer).customLayout;
            }

            modalInstance = $modal.open({
                templateUrl: 'views/dialogs/StudyLayout.html',
                controller: Controllers.StudyLayoutController,
                backdrop: 'static',
                resolve: {
                    layout: function () {
                        return layout;
                    }
                }
            });

            modalInstance.result.then(function (layout) {
                if (layout.custom == null) {
                    medicalViewer.get_gridLayout().set_rows(layout.rows);
                    medicalViewer.get_gridLayout().set_columns(layout.columns);
                    medicalViewer.set_cellsArrangement(0);
                    delete ((<any>medicalViewer).customLayout);
                }
                else {

                    if (layout.custom.Frames == null) {
                        // StudyLevel.xml 
                        (<any>medicalViewer).customLayout = layout.custom.Text;
                        medicalViewer.set_cellsArrangement(1);
                        medicalViewer.layout.beginUpdate();
                        medicalViewer.set_totalCells(layout.custom.length);
                        resetSeriesArrangement(medicalViewer, layout.custom.length);
                        rearrangeSeries(medicalViewer, layout.custom);
                        medicalViewer.layout.endUpdate();
                    }
                    else {
                        // Templates
                        medicalViewer.set_cellsArrangement(1);
                        medicalViewer.layout.beginUpdate();

                        var templateFrameCount : number = layout.custom.Frames.length;

                        medicalViewer.set_totalCells(templateFrameCount);
                        resetSeriesArrangement(medicalViewer, templateFrameCount);
                        rearrangeSeriesTemplate(medicalViewer, layout.custom.Frames);
                        medicalViewer.layout.endUpdate();
                    }
                }
            });

            function resetSeriesArrangement(medicalViewer, layoutLength: number) {
                var cellsWithImagesCount : number = medicalViewer.layout.get_items().get_count();
                var cellLength = Math.min(layoutLength, cellsWithImagesCount);

                for (var index = 0; index < cellLength; index++) {
                    medicalViewer.layout.get_items().get_item(index).set_position(index);
                }

                var emptyDivCount : number = medicalViewer.get_emptyDivs().get_items().get_count();

                for (index = 0; index < emptyDivCount; index++) {
                    var emptyDiv = medicalViewer.get_emptyDivs().get_items().get_item(index);
                    emptyDiv.set_position(index + cellLength);
                }
            }

            function rearrangeSeriesTemplate(medicalViewer, frames: Models.Frame[]) {
                // medicalViewer.layout.beginUpdate();

                var emptyDivs = medicalViewer.get_emptyDivs();

                var emptyDivCount : number = emptyDivs.get_items().get_count();

                for (var index = 0; index < emptyDivCount; index++) {
                    var emptyDiv : lt.Controls.Medical.EmptyCell = emptyDivs.get_items().get_item(index);
                
               
                    var positionIndex = emptyDiv.get_position();
                    // 
                    // Frame Coordinates
                    //
                    //   _
                    //   |
                    //   y
                    //     x --->
                    //   
                    // Convert to
                    //  
                    // Viewer Coordinates
                    // 
                    //     x --->
                    //   y
                    //   |
                    //   -
                    var left: number = frames[positionIndex].Position.leftTop.x;
                    var top: number = 1.0 - frames[positionIndex].Position.leftTop.y;
                    var right: number = frames[positionIndex].Position.rightBottom.x;
                    var bottom: number = 1.0 - frames[positionIndex].Position.rightBottom.y;

                    emptyDiv.set_bounds(Utils.createLeadRect(left, top, right, bottom));
                    // emptyDiv.backgroundColor = 'rgba(30, 30, 30, 1)';
                    emptyDiv.onSizeChanged();
                }

                var cellsWithImagesCount: number = medicalViewer.layout.get_items().get_count();
                var templateFrameCount = frames.length;

                length = Math.min(templateFrameCount, cellsWithImagesCount);
                for (var index = 0; index < length; index++) {
                    var layoutItem = medicalViewer.layout.get_items().get_item(index);
                    var positionIndex : number = layoutItem.get_position();

                    var left: number = frames[positionIndex].Position.leftTop.x;
                    var top: number = 1.0 - frames[positionIndex].Position.leftTop.y;
                    var right: number = frames[positionIndex].Position.rightBottom.x;
                    var bottom: number = 1.0 - frames[positionIndex].Position.rightBottom.y;

                    layoutItem.set_bounds(Utils.createLeadRect(left, top, right, bottom));
                    layoutItem.onSizeChanged();
                }

                var index1 = index;
                for (; index < cellsWithImagesCount; index++) {
                    //medicalViewer.layout.get_items().get_item(index).set_bounds(Utils.createLeadRect(0, 0, 0, 0));
                    medicalViewer.layout.get_items().get_item(index1).dispose();
                }

                // medicalViewer.layout.endUpdate();
            }

            function rearrangeSeries(medicalViewer, layout) {
                medicalViewer.layout.beginUpdate();

                var length = medicalViewer.get_emptyDivs().get_items().get_count();

                for (var index = 0; index < length; index++) {
                    var positionIndex = medicalViewer.get_emptyDivs().get_items().get_item(index).get_position();

                    medicalViewer.get_emptyDivs().get_items().get_item(index).set_bounds(Utils.createLeadRect(layout[positionIndex][0], layout[positionIndex][1], layout[positionIndex][2], layout[positionIndex][3]));
                    medicalViewer.get_emptyDivs().get_items().get_item(index).onSizeChanged();
                }

                length = Math.min(layout.length, medicalViewer.layout.get_items().get_count());
                for (var index = 0; index < length; index++) {
                    var positionIndex = medicalViewer.layout.get_items().get_item(index).get_position();

                    medicalViewer.layout.get_items().get_item(index).set_bounds(Utils.createLeadRect(layout[positionIndex][0], layout[positionIndex][1], layout[positionIndex][2], layout[positionIndex][3]));
                    medicalViewer.layout.get_items().get_item(index).onSizeChanged();
                }


                length = medicalViewer.layout.get_items().get_count();

                for (; index < length; index++) {
                    medicalViewer.layout.get_items().get_item(index).set_bounds(Utils.createLeadRect(0, 0, 0, 0));
                }

                medicalViewer.layout.endUpdate();
            }
        }
    }
}]);

commangular.command('OnSeriesLayout', ['seriesManagerService', '$modal', 'tabService', 'optionsService', 'eventService', 'dicomLoaderService', 'toolbarService', function (seriesManagerService: SeriesManagerService, $modal, tabService: TabService, optionsService: OptionsService, eventService: EventService, dicomLoaderService: DicomLoaderService, toolbarService: ToolbarService) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.selectedTab;
            if (!toolbarService.isEnabled("SeriesLayouts" + tab.id))
                return;

            var layout: any = {};
            var modalInstance;
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
            var overflowManager = controller.getOverflowManager();

            if (cell != null) {
                var medicalViewer: lt.Controls.Medical.MedicalViewer = controller.getViewer();

                if (medicalViewer.exploded) {
                    medicalViewer.explode(<lt.Controls.Medical.Cell>medicalViewer.explodedCell, false);
                }

                layout.rows = cell.get_gridLayout().get_rows();
                layout.columns = cell.get_gridLayout().get_columns();
                layout.custom = (<any>cell).templateId;

                modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/SeriesLayout.html',
                    controller: Controllers.SeriesLayoutController,
                    backdrop: 'static',
                    resolve: {
                        layout: function () {
                            return layout;
                        }
                    }
                });

                function updateMultiFrame(cell: lt.Controls.Medical.Cell) {
                    var maxStack: number = seriesManagerService.get_maxAllowedStackIndex(cell);
                    var enableMultiFrame: boolean = (maxStack > 1);
                    var tabId: string = tab.id;

                    toolbarService.enable(['CinePlayer' + tabId, 'Stack' + tabId], function () {
                        return enableMultiFrame;
                    });
                }

                modalInstance.result.then(function (layout) {
                    var imageViewer: lt.Controls.ImageViewer = cell.get_imageViewer();

                    if (layout.custom == null) {
                        if ((layout.rows > 10) || (layout.rows < 1)) {
                            alert('valid value is between 1 and 10');
                            return false;
                        }

                        if ((layout.columns > 10) || (layout.columns < 1)) {
                            alert('valid value is between 1 and 10');
                            return false;
                        }

                        //cell.frames.clear();
                        cell.framesMappingIndex = null;
                        seriesManagerService.delete_sopMappings(cell.seriesInstanceUID);
                        delete ((<any>cell).templateId);

                        cell.beginUpdate();                        

                        cell.gridLayout.rows = layout.rows;
                        cell.gridLayout.columns = layout.columns;
                        if (cell.arrangement != 0)
                            cell.arrangement = 0;

                        cell.endUpdate();

                        //dicomLoaderService.loadSeries(cell, [], null, false);


                        updateMultiFrame(cell);
                        eventService.publish(EventNames.InstanceOverflowClear, { seriesInstanceUID: cell.seriesInstanceUID });
                    }
                    else {
                        var template: Models.Template = <Models.Template>(layout.custom);                        
                        var overflow: Array<lt.Controls.Medical.Frame> = Array<lt.Controls.Medical.Frame>();

                        Utils.createViewerLayout(cell, template, false);
                        seriesManagerService.set_layout(cell.seriesInstanceUID, cell.divID, undefined, undefined);                                             
                        overflow = seriesManagerService.set_framesMapping(cell, template.Frames);
                        seriesManagerService.clear_seriesOverflow(cell.seriesInstanceUID);
                        eventService.publish(EventNames.InstanceOverflowClear, { seriesInstanceUID: cell.seriesInstanceUID });

                        for (var index = 0; index < overflow.length; index++) {
                            var cellFrame = overflow[index];

                            eventService.publish(EventNames.InstanceOverflow, { instance: (<any>cellFrame).Instance, metadata: (<any>cellFrame).metadata, frame: 0, parentCell: cell });
                        }

                        if (overflow.length == 0) {
                            eventService.publish(EventNames.InstanceOverflowClose, { seriesInstanceUID: cell.seriesInstanceUID });
                        }                       

                        imageViewer.endUpdate();
                        cell.onSizeChanged();
                    }
                });
            }
        }
    }
}]);

commangular.command('DeleteCell', ['seriesManagerService', 'tabService', 'eventService', 'queryArchiveService', function (seriesManagerService: SeriesManagerService, tabService: TabService, eventService: EventService, queryArchiveService: QueryArchiveService) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
            var medicalViewer = controller.getViewer();
            var cell: any = seriesManagerService.get_activeCell();
            var count;

            if (medicalViewer.exploded) {
                medicalViewer.explode(medicalViewer.explodedCell, false);
            }

            if (cell != null) {
                var seriesInstanceUID = cell.seriesInstanceUID;

                medicalViewer.layout.get_items().remove(cell);
                disposeAutomation(cell.get_automation());
                seriesManagerService.remove_cell(cell);
                cell.dispose();



                $("#dialog").dialog('close');

                count = medicalViewer.layout.get_items().get_count();
                if (count > 0) {
                    cell = medicalViewer.layout.get_items().get_item(0);
                    seriesManagerService.set_activeCell(cell.divID);

                    seriesInstanceUID = cell.get_seriesInstanceUID();

                    eventService.publish(EventNames.ActiveSeriesChanged, { seriesInstanceUID: seriesInstanceUID, id: cell.divID });
                }
                else {
                    //
                    // If there are no more cells we will remove the tab
                    //
                    seriesManagerService.set_activeCell(null);
                    eventService.publish(EventNames.DeleteTab, { id: tab.id });
                }
            }
            else
                alert('no cell to delete');

            function disposeAutomation(automation: lt.Annotations.Automation.AnnAutomation) {
                if (automation == null)
                    return;
                automation.get_container().get_children().clear();
                automation.detach();
            }
        }
    }}]);

var cobb: lt.Controls.Medical.CobbAngle;

function AddTag(text: string, index: number) {
    var newOverlay: lt.Controls.Medical.OverlayText = new lt.Controls.Medical.OverlayText();

    newOverlay.text = text;
    newOverlay.type = lt.Controls.Medical.OverlayTextType.userData;
    newOverlay.positionIndex = index;
    newOverlay.weight = 1;
    newOverlay.alignment = lt.Controls.Medical.OverlayAlignment.topLeft;

    return newOverlay;
}


commangular.command('OnSettings3D', ['toolbarService', 'tabService', 'buttonId', '$modal', 'seriesManagerService', 'queryArchiveService', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string, $modal, seriesManagerService: SeriesManagerService, queryArchiveService: QueryArchiveService) {
    return {
        execute: function () {

            var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>seriesManagerService.get_activeItem();// get_activeViewer().attachedFrame;



            var modalInstance = $modal.open({
                templateUrl: 'views/dialogs/Settings3D.html',
                controller: Controllers.Settings3DController,
                backdrop: 'static',
                resolve: {
                    cell : function () {
                        return cell3D;
                    }
                }
            });


            modalInstance.result.then(function (settings) {


                cell3D.beginUpdate();
                cell3D.showVolumeBorder = settings.ShowVolumeBorder;
                cell3D.showRotationCube = settings.ShowRotationCube;

                cell3D.projection = settings.ProjectionMethod;

                cell3D.volume.enableClippingFrame = settings.ShowClippingFrame;
                cell3D.volume.lowResQuality = settings.LowResQuality;

                cell3D.MPR.enableCrossLines = settings.ShowMPRCrossLines;
                cell3D.endUpdate();


            });


        }
    }
}]);





function handle_request3DData(cell3D: lt.Controls.Medical.Cell3D, toolbarService: ToolbarService, tabService: TabService, sender, args: lt.Controls.Medical.Request3DDataEventArgs, queryArchiveService: QueryArchiveService, query, seriesManagerService: SeriesManagerService, volumeType: lt.Controls.Medical.VolumeType, sopInstanceUID: string, renderingMethod: number) {

    switch (args.type) {

        case lt.Controls.Medical.Requested3DDataType.render:
            cell3D.image.src = args.JSON;
            break;

        case lt.Controls.Medical.Requested3DDataType.delete3DObject:
            {
                var cell = cell3D.get_referenceCell();
                if (cell)
                    cell.divID = UUID.genV4().toString();
            }
            break;

        case lt.Controls.Medical.Requested3DDataType.update3DSettings:
            queryArchiveService.Update3DSettings(args.JSON, cell3D.object3D.id).then(function (data) {
                cell3D.refresh();
            });
            break;

        case lt.Controls.Medical.Requested3DDataType.get3DInfo:
            queryArchiveService.Get3DSettings(args.JSON, cell3D.object3D.id).then(function (data) {
                var info: lt.Controls.Medical.WindowLevelInfomation = new lt.Controls.Medical.WindowLevelInfomation();
                try {
                    var json = JSON.parse(data.data);

                        info.windowWidth = json["WindowWidth"];
                        info.windowCenter =  json["WindowCenter"];
                    info.minValue = json["MinimumValue"];
                    info.maxValue = json["MaximumValue"];
                    info.autoScaleSlope = cell3D.information.autoScaleSlope;
                    info.autoScaleIntercept = cell3D.information.autoScaleIntercept;

                    (<any>cell3D).bone = {};
                    (<any>cell3D).bone.width  = json["BoneWindowWidth"];
                    (<any>cell3D).bone.center = json["BoneWindowCenter"];

                    cell3D.information = info;

                    if (DicomHelper.GetTagText(cell3D.JSON[DicomTag.Modality]) == "CT") {
                        info.windowWidth = json["BoneWindowWidth"];
                        info.windowCenter = json["BoneWindowCenter"];
                    }

                    cell3D.information = info;

                }
                catch (e) {
                }
            });
            break;
    }
}


function alreadyHaveA3Dobject(cell : lt.Controls.Medical.Cell, volumeType : lt.Controls.Medical.VolumeType)
{
    var viewer = cell.viewer;
    var index = 0;
    var length  = viewer.layout.items.count;
    var cell3D: lt.Controls.Medical.Cell3D;

    for (index = 0; index < length; index++) {
        if (viewer.layout.items.get_item(index) instanceof lt.Controls.Medical.Cell3D) {
            cell3D = <lt.Controls.Medical.Cell3D>viewer.layout.items.get_item(index);

            if (cell3D.object3D.progress == 100)
                cell3D.volumeType = volumeType;

            if (cell3D.referenceCell == cell) {
                return true;
            }
        }
    }
    return false;
}


function Create3DObject(seriesManagerService, toolbarService, tabService, queryArchiveService, overlayManagerService, optionsService, eventService, volumeType: lt.Controls.Medical.VolumeType) {

    var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
    var query: Models.QueryOptions = new Models.QueryOptions();
    query.SeriesOptions.SeriesInstanceUID = cell.seriesInstanceUID;
    var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
    var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
    var medicalViewer: lt.Controls.Medical.MedicalViewer = controller.getViewer();

    // change the volume type if the volume exist.
    if (cell instanceof lt.Controls.Medical.Cell3D) {
        var cell3D = <lt.Controls.Medical.Cell3D>cell;
        if (cell3D.object3D.progress == 100)
            cell3D.volumeType = volumeType;

        return true;
    }

    // if the cell has a 3d volume, then just return.
    if (alreadyHaveA3Dobject(cell, volumeType))
        return;


    var viewer: lt.Controls.Medical.MedicalViewer = cell.viewer;

    // increase the viewer cell count to show the 3d volume.
    if ((viewer.layout.items.count + viewer.emptyDivs.items.count) < 3) {
        viewer.cellsArrangement = lt.Controls.Medical.CellsArrangement.grid;
        viewer.layout.beginUpdate();
        viewer.gridLayout.rows = 2;
        viewer.gridLayout.columns = 2;
        viewer.layout.endUpdate();
    }



    if (viewer.exploded)
        viewer.exploded = false;


    // TODO: remove this
    (<any>cell).Id3D = cell.divID + "_3D";


    var frame: any = <lt.Controls.Medical.Frame>cell.frames.get_item(0);
    var sopInstanceUID = frame.Instance.SOPInstanceUID

    var cell3D: lt.Controls.Medical.Cell3D = new lt.Controls.Medical.Cell3D(viewer, (<any>cell).Id3D);

    cell3D.object3D = tab.AddnewEngine(cell.divID, queryArchiveService, query, sopInstanceUID, optionsService);
    cell3D.add_volumeTypeChanged(function (sender, args) {
        eventService.publish(EventNames.ActiveSeriesChanged, { seriesInstanceUID: cell.seriesInstanceUID, id: cell.divID });
    });

    cell3D.referenceCell = cell;

    (<any>cell).cell3D = cell3D;

    var renderingMethod = optionsService.get(OptionNames.RenderingMethod);
    var renderingIndex = (renderingMethod.indexOf("Hardware") != -1) ? 0 : 1;
        

    (<any>cell).object3D = cell3D.object3D;

    cell3D.object3D.add_request3DData(function (sender, args) {
        handle_request3DData(cell3D, toolbarService, tabService, sender, args, queryArchiveService, query, seriesManagerService, volumeType, sopInstanceUID, renderingIndex);
    });

    cell3D.object3D.add_statusChanged(function (sender, args) {

        switch (args.status) {
            case lt.Controls.Medical.Object3DStatus.error:
                var medicalViewer: lt.Controls.Medical.MedicalViewer = cell3D.viewer;
                medicalViewer.layout.get_items().remove(cell3D);
                seriesManagerService.remove_cell(cell3D);
                cell3D.dispose();
                alert(args.message);
                break;

            case lt.Controls.Medical.Object3DStatus.ready:
                if (cell3D.object3D.progress == 100) {

                    cell3D.URL = queryArchiveService.Get3DImage();
                    var inputJson = {}
                    inputJson["BoneWindowWidth"] = '';
                    inputJson["BoneWindowCenter"] = '';
                    if (DicomHelper.GetTagText(frame.JSON[DicomTag.Modality]) == "CT") {
                        queryArchiveService.Get3DSettings(inputJson, cell3D.object3D.id).then(function (data) {
                            var info: lt.Controls.Medical.WindowLevelInfomation = new lt.Controls.Medical.WindowLevelInfomation();

                            inputJson = JSON.parse(data.data);
                            var json = {}
                            json["WindowWidth"] = inputJson["BoneWindowWidth"];
                            json["WindowCenter"] = inputJson["BoneWindowCenter"];

                            queryArchiveService.Update3DSettings(json, cell3D.object3D.id).then(function (data) {

                                cell3D.beginUpdate();
                                cell3D.volumeType = volumeType;
                                cell3D.endUpdate();

                                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
                                toolbarService.enable("VolumeType" + tab.id);

                                //var viewer = cell3D.referenceCell.get_viewer();

                                //ConnectMPRWith3DObject(cell3D.referenceCell, cell3D.referenceCell, viewer, queryArchiveService);
                            });
                        });
                    }
                    else {
                        cell3D.beginUpdate();
                        cell3D.volumeType = volumeType;
                        cell3D.endUpdate();

                        var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
                        toolbarService.enable("VolumeType" + tab.id);

                    }
                }
        }
    });


    var frame = cell.frames.get_item(0);

    var metadata = frame.metadata;

    cell3D.JSON = metadata;

    var patientId = DicomHelper.getPatientName(metadata, DicomTag.PatientName);
    var StudyDescription = DicomHelper.GetTagTextValue(metadata, DicomTag.StudyDescription);
    var StudyDate = DicomHelper.parseDicomDate(DicomHelper.GetTagTextValue(metadata, DicomTag.StudyDate));
    var SeriesDate = DicomHelper.parseDicomDate(DicomHelper.GetTagTextValue(metadata, DicomTag.SeriesDate));
    var SeriesDescription = DicomHelper.GetTagTextValue(metadata, DicomTag.SeriesDescription);
     
     overlayManagerService.set_cellOverlays(cell3D, metadata, false);


    (<any>cell3D).stackInstanceUID = (<any>cell).stackInstanceUID;
    cell3D.seriesInstanceUID = cell.seriesInstanceUID;
    cell3D.studyInstanceUID = "3D";

    cell3D.set_unselectedBorderColor(optionsService.get(OptionNames.UnSelectedBorderColor));
    cell3D.set_selectedSubCellBorderColor(optionsService.get(OptionNames.SelectedSubCellBorderColor));
    cell3D.set_selectedBorderColor(optionsService.get(OptionNames.SelectedBorderColor));
    cell3D.set_highlightedSubCellBorderColor(optionsService.get(OptionNames.SelectedBorderColor));
    cell3D.set_showFrameBorder(optionsService.get(OptionNames.ShowFrameBorder));

    var parent = document.getElementById(viewer.divId);

    viewer.layout.get_items().add(cell3D);

    var id: string = cell3D.get_divID();
    seriesManagerService.add_seriesCell(cell3D);
    $("#" + id).attr('seriesInstanceUID', cell3D.get_seriesInstanceUID());


    var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
    toolbarService.disable("VolumeType" + tab.id);

    cell3D.start("");
}

commangular.command('OnVRT', ['seriesManagerService', 'toolbarService', 'tabService', 'dicomLoaderService', 'queryArchiveService', 'overlayManagerService', 'optionsService', 'eventService', 'objectRetrieveService', function (seriesManagerService: SeriesManagerService, toolbarService: ToolbarService, tabService: TabService, dicomLoaderService: DicomLoaderService, queryArchiveService: QueryArchiveService, overlayManagerService: OverlayManagerService, optionsService: OptionsService, eventService: EventService, objectRetrieveService: ObjectRetrieveService) {
    return {
        execute: function () {

            VolumeWithMPR(seriesManagerService, null, toolbarService, tabService, eventService, queryArchiveService, overlayManagerService, optionsService, objectRetrieveService, lt.Controls.Medical.VolumeType.VRT);

        }
    }
}]);

commangular.command('OnMIP', ['seriesManagerService', 'toolbarService', 'tabService', 'dicomLoaderService', 'queryArchiveService', 'overlayManagerService', 'optionsService', 'eventService', 'objectRetrieveService', function (seriesManagerService: SeriesManagerService, toolbarService: ToolbarService, tabService: TabService, dicomLoaderService: DicomLoaderService, queryArchiveService: QueryArchiveService, overlayManagerService: OverlayManagerService, optionsService: OptionsService, eventService: EventService, objectRetrieveService: ObjectRetrieveService) {
    return {
        execute: function () {

            VolumeWithMPR(seriesManagerService, null, toolbarService, tabService, eventService, queryArchiveService, overlayManagerService, optionsService, objectRetrieveService, lt.Controls.Medical.VolumeType.MIP);

        }
    }
}]);

commangular.command('OnSSD', ['seriesManagerService', 'toolbarService', 'tabService', 'dicomLoaderService', 'queryArchiveService', 'overlayManagerService', 'optionsService', 'eventService', 'objectRetrieveService', function (seriesManagerService: SeriesManagerService, toolbarService: ToolbarService, tabService: TabService, dicomLoaderService: DicomLoaderService, queryArchiveService: QueryArchiveService, overlayManagerService: OverlayManagerService, optionsService: OptionsService, eventService: EventService, objectRetrieveService: ObjectRetrieveService) {
    return {
        execute: function () {

            VolumeWithMPR(seriesManagerService, null, toolbarService, tabService, eventService, queryArchiveService, overlayManagerService, optionsService, objectRetrieveService, lt.Controls.Medical.VolumeType.SSD);

        }
    }
}]);

commangular.command('OnMPRVolume', ['seriesManagerService', 'toolbarService', 'tabService', 'dicomLoaderService', 'queryArchiveService', 'overlayManagerService', 'optionsService', 'eventService', 'objectRetrieveService', function (seriesManagerService: SeriesManagerService, toolbarService: ToolbarService, tabService: TabService, dicomLoaderService: DicomLoaderService, queryArchiveService: QueryArchiveService, overlayManagerService: OverlayManagerService, optionsService: OptionsService, eventService: EventService, objectRetrieveService: ObjectRetrieveService) {
    return {
        execute: function () {

            VolumeWithMPR(seriesManagerService, null, toolbarService, tabService, eventService, queryArchiveService, overlayManagerService, optionsService, objectRetrieveService, lt.Controls.Medical.VolumeType.MPR);

        }
    }
}]);

commangular.command('OnRotate3D', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {

            SetCurrentInteractiveMode(toolbarService, tabService, MedicalViewerAction.Rotate3D, buttonId);
            enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {
                CommandManager.RunCommand(cell, MedicalViewerAction.Rotate3D, buttonId);
            });

        }
    }
}]);

commangular.command('ToggleFullScreen', ['seriesManagerService', 'tabService', 'dicomLoaderService', function (seriesManagerService: SeriesManagerService, tabService: TabService, dicomLoaderService: DicomLoaderService) {
    return {
        execute: function () {


            // check if the Enter key has been pressed for the nanotation text.
            var textElement: HTMLTextAreaElement = <HTMLTextAreaElement>document.getElementById("textObject");
            if (textElement != null)
                return;
             

                    if (!isFullscreen()) {

                        if (document.fullscreenEnabled ||
                            (<any>document).webkitFullscreenEnabled ||
                            (<any>document).mozFullScreenEnabled ||
                            (<any>document).msFullscreenEnabled) {

                            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
                            var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
                            if (!controller)
                                return;
                            var medicalViewer: lt.Controls.Medical.MedicalViewer = controller.getViewer();
                            var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
                            var element = document.getElementById(medicalViewer.divId);
                            element = element.parentElement;

                            if (element.requestFullscreen) {
                                element.requestFullscreen();
                            } else if ((<any>element).webkitRequestFullscreen) {
                                (<any>element).webkitRequestFullscreen();
                            } else if ((<any>document).mozRequestFullScreen) {
                                (<any>document).mozRequestFullScreen();
                            } else if ((<any>document).msRequestFullscreen) {
                                (<any>document).msRequestFullscreen();
                            }
                        }
                    }
                    else {
                        if (document.exitFullscreen) {
                            document.exitFullscreen();
                        } else if ((<any>document).webkitExitFullscreen) {
                            (<any>document).webkitExitFullscreen();
                        } else if ((<any>document).mozCancelFullScreen) {
                            (<any>document).mozCancelFullScreen();
                        } else if ((<any>document).msExitFullscreen) {
                            (<any>document).msExitFullscreen();
                        }
                    }



        }
    }
}]);
commangular.command('ToggleReferenceLine', ['seriesManagerService', 'tabService', 'toolbarService', function (seriesManagerService: SeriesManagerService, tabService: TabService, toolbarService: ToolbarService) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
            var medicalViewer: lt.Controls.Medical.MedicalViewer = controller.getViewer();

            if (medicalViewer != null) {
                var value: boolean = !medicalViewer.get_showReferenceLine();

                medicalViewer.set_showReferenceLine(value);
                if (value)
                    toolbarService.press('ReferenceLine' + tab.id);
                else {
                    toolbarService.unpress('ReferenceLine' + tab.id);
                    medicalViewer.invalidate();
                }

                var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
                if (cell == null) {
                    return;
                }
                var referenceStudyID = cell.studyInstanceUID;

                enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {

                    if (cell.studyInstanceUID == referenceStudyID)
                        if (!cell.fullDownload)
                            cell.fullDownload = true;
                });
                medicalViewer.invalidate();
            }
        }
    }
}]);

commangular.command('ShowFirstLastReferenceLine', ['seriesManagerService', 'tabService', 'toolbarService', function (seriesManagerService: SeriesManagerService, tabService: TabService, toolbarService: ToolbarService) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
            var medicalViewer: lt.Controls.Medical.MedicalViewer = controller.getViewer();

            if (medicalViewer != null) {
                var value: boolean = !medicalViewer.get_showFirstAndLastReferenceLine();

                medicalViewer.set_showFirstAndLastReferenceLine(value);
                if (value)
                    toolbarService.press('ShowFirstLast' + tab.id);
                else
                    toolbarService.unpress('ShowFirstLast' + tab.id);


                var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
                if (cell == null) {
                    return;
                }
                var referenceStudyID = cell.studyInstanceUID;

                enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {

                    if (cell.studyInstanceUID == referenceStudyID)
                        if (!cell.fullDownload)
                            cell.fullDownload = true;
                });

                medicalViewer.invalidate();
            }
        }
    }
}]);


function OpenUrl(url: string, newWindow?) {
    var newWindow = newWindow || false;

    if ((lt.LTHelper.OS == lt.LTOS.iOS && !lt.LTDevice.mobile) || newWindow) {
        var newtab = window.open("", "_blank");

        if (newtab) {
        window.focus();
        newtab.location.href = url;
        newtab.focus();
        }
        else {
                //newtab is undefined, most likely b/c of chrome security feature (not allowing a service callback to open a tab)
                //it has to be initiated by a user interaction (clicking on a URL), we show a popup dialog that has the URL
                if (lt.LTHelper.browser === lt.LTBrowser.chrome && newWindow) {
                if ($('#dialogForPrintPdf').length) {
                    $('#dialogForPrintPdf').remove();
                }
                    parentDiv = $("<div id='dialogForPrintPdf' title='File Ready' ><a href='" + url + "'  target='_blank'>Click here to open or download</a></div>");
                    parentDiv.dialog({ autoOpen: false });
                    $('#dialogForPrintPdf').dialog("open");
                }
                else {
            window.location.href = url;
                }
        }
    }
    else {
        window.location.href = url;
    }
}

function OpenPrintViewUrl(url: string) {

    var win = window.open();
    if (win)
        win.document.write('<img onload="document.location=\'#\';" src="' + url + '" ></img>')
}

function SetCurrentInteractiveMode(toolbarService: ToolbarService, tabService: TabService, interactiveMode, commandId, showpressed?: boolean) {
    var tb: any = toolbarService;
    var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

    if (currentInteractiveMode[tab.id] == interactiveMode)
        return;

    currentInteractiveMode[tab.id] = interactiveMode;

    PressButton(toolbarService, tab, commandId, showpressed);
}

function GetCurrentInteractiveMode(tabId: string): number {
    var index = -1;
    if (angular.isDefined(currentInteractiveMode[tabId]))
        index = currentInteractiveMode[tabId];

    if (index == -1)
        return MedicalViewerAction.WindowLevel;

    return index;
}

function enumerateCell(tabService: TabService, cellFunction, myTab?) {
    if (tabService.activeTab != -1) {
        var tab: Models.Tab = myTab ? myTab : tabService.get_allTabs()[tabService.activeTab];
        var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);

        if (controller == null)
            return;

        var medicalViewer = controller.getViewer();

        if (medicalViewer == null)
            return;

        var index = 0;
        var length = medicalViewer.layout.get_items().get_count();
        var cell;

        for (index = 0; index < length; index++) {

            cell = medicalViewer.layout.get_items().get_item(index);
            if (cell != null)
                cellFunction(cell);
        }
    }
}

function enumerateEmptyCell(tabService: TabService, cellFunction) {
    if (tabService.activeTab != -1) {
        var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
        var controller = tabService.get_tabData(tab.id, TabDataKeys.ViewController);
        var medicalViewer: lt.Controls.Medical.MedicalViewer = controller.getViewer();

        if (medicalViewer == null)
            return;

        var index = 0;
        var length = medicalViewer.emptyDivs.items.count;
        var cell;

        for (index = 0; index < length; index++) {

            cell = medicalViewer.emptyDivs.items.item(index);
            if (cell != null)
                cellFunction(cell);
        }
    }
}

function radioColor() {
    var redCheckBox: any = document.getElementById('checkboxRed');
    var greenCheckBox: any = document.getElementById('checkboxGreen');
    var blueCheckBox: any = document.getElementById('checkboxBlue');

    redCheckBox.disabled = false;
    greenCheckBox.disabled = false;
    blueCheckBox.disabled = false;

    var position = currentPosition;

    lineProfileInteractiveMode.histogramColorType = lt.Controls.Medical.ColorType.RGB;

    UpdateSliderPosition(position);
}

function radioGray() {

    var redCheckBox: any = document.getElementById('checkboxRed');
    var greenCheckBox: any = document.getElementById('checkboxGreen');
    var blueCheckBox: any = document.getElementById('checkboxBlue');

    redCheckBox.disabled = true;
    greenCheckBox.disabled = true;
    blueCheckBox.disabled = true;

    var position = currentPosition;

    lineProfileInteractiveMode.histogramColorType = lt.Controls.Medical.ColorType.gray;

    UpdateSliderPosition(position);
}



function checkbox_click(value: string) {
    RenderLineProfileHistogram(0, 0, false);
}



function GetRealRotationAngle(angle, frame) {

    var direction = 1;

    if (frame.get_flipped() ^ frame.get_reversed())
        direction = -1;

    return direction * angle;
}


function isOverLineProfileSlider(e) {
    var targetTouchePageY = e.pageY;
    var targetTouchePageX = e.pageX;

    var innerLineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('lineProfileCanvas');

    return (targetTouchePageY >= innerLineCanvas.height);
}

var mouseDown = false;


var lineProfileHistogram: number[] = null;
var currentLineProfileFrame: lt.Controls.Medical.Frame = null;
var lineProfileInteractiveMode : lt.Controls.Medical.LineProfileInteractiveMode = null;
var colorType: lt.Controls.Medical.ColorType = lt.Controls.Medical.ColorType.auto;


function HistogramUpdated() {
    RenderLineProfileHistogram(0, 0, false);
    //var left = context.measureText("65535").width;
    var innerLineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('lineProfileCanvas');
    if (innerLineCanvas == null)
        return;
    UpdateSliderPosition(innerLineCanvas.clientWidth);
}

function UpdateSliderSize() {
    var componantCount = (colorType == lt.Controls.Medical.ColorType.gray) ? 1 : 3;
    var innerLineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('lineProfileCanvas');
    var sliderSize = 0;
    var pixelCount = (lineProfileHistogram.length / componantCount);
    if (innerLineCanvas.width < pixelCount) {
        var sliderSize = pixelCount - innerLineCanvas.width;
    }
    else {
        sliderSize = 0;
    }

    lineProfileSliderSize = sliderSize;

    //outerLineCanvas.setAttribute("sliderSize", sliderSize.toString());
}

function RenderLineProfileHistogram(x, y, drawLine) {
    var innerLineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('lineProfileCanvas');
    var outerLineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('outerlineProfileCanvas');

    if (innerLineCanvas == null)
        return;
    if (outerLineCanvas == null)
        return;

    if (currentLineProfileFrame == null)
        return;

    var context = innerLineCanvas.getContext("2d");
    var height = innerLineCanvas.height;
    var minMaxDelta = currentLineProfileFrame.information.maxValue - currentLineProfileFrame.information.minValue;
    var normalizedValue = height;


    if (lineProfileHistogram.length == 0)
        return;

    //UpdateSliderPosition(lineProfileSliderSize - 1);

    UpdateSliderSize();



    var componant = 0;
    var componantCount = (colorType == lt.Controls.Medical.ColorType.gray) ? 1 : 3;
    //var colors = componantCount == 3 ? new number[] { 'red', 'green', 'blue'} : new number[] { 'black'};
    var colors: string[] = [];
    var colorEnabled: boolean[] = [];

    if (componantCount == 3) {
        colors[0] = 'red';
        colorEnabled[0] = $("#checkboxRed").is(':checked') ? true : false;
        colors[1] = 'green';
        colorEnabled[1] = $("#checkboxGreen").is(':checked') ? true : false;
        colors[2] = 'blue';
        colorEnabled[2] = $("#checkboxBlue").is(':checked') ? true : false;
    }
    else {
        colors[0] = 'black';
        colorEnabled[0] = true;
    }
    context.clearRect(0, 0, innerLineCanvas.width, innerLineCanvas.height);
    context.save();
    for (componant = 0; componant < componantCount; componant++) {

        if (!colorEnabled[componant])
            continue;

        var index = 0;
        var length = Math.min(lineProfileHistogram.length / componantCount, innerLineCanvas.width);
        var yLine = (height) - ((lineProfileHistogram[lineProfileSliderPosition * componantCount + componant] - currentLineProfileFrame.information.minValue) * (height) / minMaxDelta);
        context.beginPath();
        context.strokeStyle = colors[componant];
        context.moveTo(0, yLine);
        var pixel;
        for (index = 1; index < length; index++) {
            pixel = lineProfileHistogram[(lineProfileSliderPosition + index) * componantCount + componant] - currentLineProfileFrame.information.minValue;
            yLine = height - (pixel * height / minMaxDelta);
            context.lineTo(index, yLine);
        }

        context.stroke();
    }


    var innerLineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('lineProfileCanvas');
    var height = innerLineCanvas.height;

    if (lineProfileHistogram.length == 0)
        return;


    if (drawLine) {
        var context = innerLineCanvas.getContext("2d");
        var left = context.measureText("65535").width;
        var xLine = (x + left);
        var componantCount = (colorType == lt.Controls.Medical.ColorType.gray) ? 1 : 3;
        var yLine = 0;
        var textPosition = xLine;

        var pixelValue = "";
        var pixelPosition;

        for (componant = 0; componant < componantCount; componant++) {

            pixelPosition = (lineProfileSliderPosition + xLine) * componantCount + componant;

            if (pixelPosition >= lineProfileHistogram.length)
                continue;

            xLine = (x + left);
            yLine = (height) - ((lineProfileHistogram[pixelPosition] - currentLineProfileFrame.information.minValue) * (height) / minMaxDelta);

            context.beginPath();

            context.strokeStyle = 'black';
            context.fillStyle = 'rgba(230, 230, 128, 0.5)';
            context.arc(xLine + 0.5, yLine, 4, 0, 2 * Math.PI);
            context.moveTo(xLine + 0.5, yLine);
            context.lineTo(xLine + 0.5, height);

            currentLineProfileFrame.parentCell.lineProfile.histogramMarker = lineProfileSliderPosition + xLine;

            pixelValue += lineProfileHistogram[pixelPosition].toString();
            if (componant < (componantCount - 1)) {
                pixelValue += ',';
            }
            context.fill();
            context.stroke();
        }

        if (xLine < context.measureText(pixelValue).width + 10) {
            context.textAlign = "left";
            // fixed value to push the text away from the mouse/finger
            textPosition += 10;
        }
        else {
            context.textAlign = "right";
            // fixed value to push the text away from the mouse/finger
            textPosition -= 4;
        }


        if (pixelValue) {

            context.beginPath();
            (<any>context).textBaseline = "baseline";
            context.fillStyle = 'black';
            context.fillText(pixelValue, textPosition, y);
            context.fillStyle = 'gray';
            context.strokeText(pixelValue, textPosition, y);


            context.fill();
            context.stroke();
        }

    }
    else
        currentLineProfileFrame.parentCell.lineProfile.histogramMarker = -1;





    context.restore();
}




function isOverGraph(e) {
    var targetTouchePageY = e.pageY;
    var targetTouchePageX = e.pageX;

    var innerLineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('lineProfileCanvas');

    return (targetTouchePageY < innerLineCanvas.height) && (targetTouchePageX < innerLineCanvas.width);
}

var currentPosition: number = 0;
var lineProfileSliderSize : number = 0;
var lineProfileSliderPosition : number= 0;


function UpdateSliderPosition(newPosition) {

    if (!lineProfileHistogram)
        return;
    if (lineProfileHistogram.length == 0)
        return;


    var mainDiv: any = document.getElementById('dialog');

    var width = mainDiv.clientWidth - 24;

    var height = 180;

    var outerlineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('outerlineProfileCanvas');
    var innerLineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('lineProfileCanvas');
    var context = outerlineCanvas.getContext('2d');
    var space: number = width / 15;

    var left = context.measureText("65535").width;
    var top = innerLineCanvas.offsetTop - outerlineCanvas.offsetTop;
    var width = width - space - left;
    var height = innerLineCanvas.clientHeight;

    context.clearRect(0, height + 2 + top, outerlineCanvas.width, outerlineCanvas.height - height);

    if (lineProfileSliderSize == 0)
        return;


    height = 180;

    context.lineWidth = 1;
    context.beginPath();
    context.strokeStyle = "rgba(255, 0, 0, 0.5)";
    context.moveTo(left + 0.5, height + top + 15 + 0.5);
    context.lineTo(left + width + 0.5, height + top + 15 + 0.5);
    context.stroke();

    context.beginPath();
    currentPosition = newPosition;
    currentPosition = Math.min(left + width + 0.5, Math.max(left, left + 0.5 + currentPosition));
    var realPosition: number = currentPosition - left;
    lineProfileSliderPosition = Math.round((realPosition * lineProfileSliderSize / width));

    context.lineWidth = 2;
    context.fillStyle = "rgba(255, 128, 128, 1)";
    context.arc(currentPosition, height + top + 15, 6, 0, 2 * Math.PI);
    context.fill();
    context.stroke();


    context.textAlign = "left";
    context.textBaseline = "top";
    var componantCount = (colorType == lt.Controls.Medical.ColorType.gray) ? 1 : 3;
    
    var height = innerLineCanvas.clientHeight;
    var fromPercentage = Math.round(lineProfileSliderPosition * 100 / (lineProfileHistogram.length / componantCount));
    var toPercentage = Math.round(((lineProfileSliderPosition + width) * 100) / (lineProfileHistogram.length / componantCount));  
    context.fillText(fromPercentage + "%", left, height + top + 1);
    context.textAlign = "right";
    context.fillText(toPercentage + "%", left + width - 0.5, height + top + 1);
}


function getMousePoint(args : MouseEvent, canvas)
{
    var outerlineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('outerlineProfileCanvas');
    var context = outerlineCanvas.getContext('2d');
    var left = context.measureText("65535").width;

    var position = lt.LTHelper.getPosition(canvas, null)
    var targetTouchePageX = args.pageX - parseInt(position.x.toString()) - left;
    var targetTouchePageY = args.pageY - parseInt(position.y.toString());

    return lt.LeadPointD.create(targetTouchePageX, targetTouchePageY);
}

function outerlineCanvas_mouseDown(canvas, e: MouseEvent) {
    mouseDown = false;

    //e.target.setCapture();
    var outerlineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('outerlineProfileCanvas');
    //lineProfileSliderSize = parseInt(outerlineCanvas.getAttribute("sliderSize"));

    if (isOverLineProfileSlider(e)) {
        mouseDown = true;
        var point = getMousePoint(e, canvas);
        UpdateSliderPosition(point.x);
        RenderLineProfileHistogram(0, 0, false);
    }
    e.preventDefault();
    //e.stopImmediatePropagation();
}


function outerlineCanvas_mouseMove(canvas, args : MouseEvent) {
    if (mouseDown) {

        var point = getMousePoint(args, canvas);

        UpdateSliderPosition(point.x);
        RenderLineProfileHistogram(0, 0, false);
    }
    else {

        if (isOverGraph(args)) {
        }
    }

    args.preventDefault();
    args.stopImmediatePropagation();
}

function outerlineCanvas_mouseUp(canvas, args) {

    mouseDown = false;
    args.preventDefault();
    args.stopImmediatePropagation();
}

function isGrayScale16() {
    return true;
}


var histogramMouseDown: boolean = false;

function innerLineCanvas_mouseDown(canvas, e: MouseEvent) {
    histogramMouseDown = false;

    var innerlineCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('lineProfileCanvas');

    histogramMouseDown = true;

    var point = getMousePoint(e, canvas);
    UpdateLineOnHistogram(point.x, point.y, histogramMouseDown);
    e.preventDefault();
}


function innerLineCanvas_mouseMove(canvas, args: MouseEvent) {
    if (histogramMouseDown) {
        var point = getMousePoint(args, canvas);
        UpdateLineOnHistogram(point.x, point.y, histogramMouseDown);
    }
    else {
    }

    args.preventDefault();
    args.stopImmediatePropagation();
}

function innerLineCanvas_mouseUp(canvas, args) {

    histogramMouseDown = false;

    UpdateLineOnHistogram(0, 0, histogramMouseDown);

    args.preventDefault();
    args.stopImmediatePropagation();
}

function UpdateLineOnHistogram(x, y, drawLine) {
    RenderLineProfileHistogram(x, y, drawLine);
}


function ShowMenu(items, icon, functionCallBack, cellFrame, toolbarService, tabService, seriesManagerService, $modal, tab, selectedIndex) {

    var menu = document.getElementById('customWidnowLevel_expandMenu');
    if (menu != null) {
        menu.style.visibility = 'visible';
        return;
    }
    setTimeout(function () {


        window.addEventListener("click", menuClick, true);
        function menuClick(e) {

            window.removeEventListener("click", menuClick);
            var menu = document.getElementById('customWidnowLevel_expandMenu');
            if (menu != null) {
                if (menu.style.visibility == 'visible') {
                    menu.style.visibility = 'hidden';
                    menu.parentNode.removeChild(menu);
                    menu.id = '';
                    menu.innerHTML = '';
                }
            }

        }
    }, 10);



    var leftScroll = document.getElementById('scrollLeft_toolbar_button');


    var left = 0;
    var tabView: HTMLElement = document.getElementById('ltTabWrapper');
    if (tabView) {
        // to scroll the toolbar buttons the left to make room for the MiPACS logo.
        var scrollBarArray = tabView.getElementsByClassName('scroll-body-inner');
        if ((scrollBarArray != null) && (scrollBarArray.length != 0)) {
            var scrollBar: any = scrollBarArray[scrollBarArray.length - 1];
            if (scrollBar)
                left = scrollBar.offsetLeft;
        }
    }

    var parent = tabService.getWindowLayout();

    var _customWindowLevelMenu = document.createElement('div');
    _customWindowLevelMenu.id = 'customWidnowLevel_expandMenu';
    _customWindowLevelMenu.style.position = 'absolute';
    _customWindowLevelMenu.style.visibility = 'visible';
    _customWindowLevelMenu.style.zIndex = '200';
    _customWindowLevelMenu.style.backgroundColor = "#151515"; //'rgba(91, 162, 243, 1)';
    _customWindowLevelMenu.style.width = '250';
    _customWindowLevelMenu.style.top = "84px";
    _customWindowLevelMenu.style.left = leftScroll.offsetLeft + leftScroll.clientWidth + icon.offsetLeft + left + 'px';
    _customWindowLevelMenu.style.display = 'block';
    _customWindowLevelMenu.style.height = '200px';
    parent.appendChild(_customWindowLevelMenu);

    var cell: lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
    var length = items.length;


    var direction = (<any>cell).SortOrderAcsending ? ' \u2193' : ' \u2191';
    var selected;
    

    var counter: number = 0;
    for (var index = 0; index < length; index++) {
        selected = items[index].Text == ((<any>cell).CurrentSelectedSortOrder);
        if (index == 0)
            _customWindowLevelMenu.innerHTML += ("<a class='menuBar' style='display: block;'></a>");
        else
            _customWindowLevelMenu.innerHTML += ("<a class='itemDivider' style='display: block;'></a>");
        _customWindowLevelMenu.innerHTML += ("<a class='menuItemText2' id='dropdownmenuitem" + index + "' style='display: block; cursor: pointer;       text-decoration:none;'>" + (selected ? '\u2713 ' : '') + items[index].Text + (selected ? direction : "") + '</a>');
    }

    var item;
    for (var index = 0; index < length; index++) {
        item = document.getElementById("dropdownmenuitem" + index.toString());

        item.setAttribute("itemIndex", index.toString());

        (<any>item).cellFrame = cellFrame;
        (<any>item).toolbarService = toolbarService;
        (<any>item).seriesManagerService = seriesManagerService;
        (<any>item).model = $modal;
        (<any>item).tab = tab;
        (<any>item).cell = cell;
        (<any>item).sortInfo = items[index].Info;
        (<any>item).item = items[index];

        item.addEventListener('mouseover', emptyFunction, false);
        item.addEventListener('mouseleave', emptyFunction, false);
        item.addEventListener("touchstart", functionCallBack, false);
        if (lt.LTHelper.msPointerEnabled)
            item.addEventListener(lt.Controls.Medical.Tools.pointerup, functionCallBack, false);
        else
            item.addEventListener("mouseup", functionCallBack, false);

        if (lt.LTHelper.msPointerEnabled)
            item.addEventListener(lt.Controls.Medical.Tools.pointerdown, function (e) {
                e.preventDefault();
                e.stopImmediatePropagation();
            }, false);
        else
            item.addEventListener("mousedown", function (e) {
                e.preventDefault();
                e.stopImmediatePropagation();
            }, false);
    }

    _customWindowLevelMenu.style.height = item.offsetTop + item.clientHeight + 1 + "px";

}

var currentSelectedSortOrder: number = -1;

var _sort_timer_event;

function sortClick(e) {
    var index = parseInt(e.currentTarget.getAttribute("itemIndex"));
    var cellFrame = e.currentTarget.cellFrame;

    var seriesManagerService = e.currentTarget.seriesManagerService;
    var model = e.currentTarget.model;
    var toolbarService = e.currentTarget.toolbarService;
    var tab = e.currentTarget.tab;
    var cell = e.currentTarget.cell;
    var info: lt.Controls.Medical.SortingOperation = e.currentTarget.sortInfo;

    if (e.currentTarget.text.indexOf('\u2713') != -1) {
        (<any>cell).SortOrderAcsending = !(<any>cell).SortOrderAcsending;
    }
    else {
        (<any>cell).CurrentSelectedSortOrder = e.currentTarget.text;
    }

    info.order = !(<any>cell).SortOrderAcsending ? lt.Controls.Medical.SortOrder.descending : lt.Controls.Medical.SortOrder.ascending;

    


    currentSelectedSortOrder = index;

    cell.fullDownload = true;

    cell._sort_timer_event = window.setInterval(function (e) {

        seriesManagerService.enumerateFrames(cell, function (frame : lt.Controls.Medical.Frame, index) {
            if (frame.JSON == null)
                return;
        });

    var sortingOp: lt.Controls.Medical.SortingOperation[] = [info]; 
        cell.sortingOperationsSequence = sortingOp;

        window.clearInterval(cell._sort_timer_event);
    }, 500);

    //sortingOp[0] = new lt.Controls.Medical.SortingOperation();
    //sortingOp[0].order = lt.Controls.Medical.SortOrder.descending;
    //sortingOp[0].sortByCategory = lt.Controls.Medical.SortType.byAxis;

    

    //var widthCenter = getWidthAndCenter(cellFrame.metadata, index);
    //if (widthCenter != null)
    //    cellFrame.setWindowLevel(widthCenter.W, widthCenter.C);
    //else {
    //    showCustomWindowlevelDialog(toolbarService, seriesManagerService, tab, model);
    //}
}
