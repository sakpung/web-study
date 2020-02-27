interface JQuery {
    jqGrid: any;
    toolbarButtonAdd: Function;
    toolbarLabelAdd: Function;
    tmplParse: Function;
    live: Function;
    fancytree: Function; 
    contextMenu: Function;   
} 

interface JQueryStatic {   
    tmplParse(format: string, data: any): string;
    template(format: string): string; 
    contextMenu: Function;
}

declare module ng {
    interface IRootScopeService {
        $$listeners: any;
    }
}

interface Window {
    _webkitRequestAnimationFrame: any;
    mozRequestAnimationFrame: any;
    oRequestAnimationFrame: any;
    _webkitCancelRequestAnimationFrame: any;
    _webkitCancelAnimationFrame: any;
    mozCancelAnimationFrame: any;
    mozCancelRequestAnimationFrame: any;
    oCancelRequestAnimationFrame: any;
    oCancelAnimationFrame: any;
}

declare module lt.Controls.Medical {
    //function MedicalViewer(div): void;
    //function Cell(viewer, divid, cellRows, cellColumns): void;

    //var OffsetAction: any;
   // var ScaleAction: any;
    //var MagnifyAction: any;
    //var WindowLevelAction: any;
    //var StackAction: any;    
    //var SpyGlassAction: any;
    var _tools: any;
    var _orientationLetters: any;    
}