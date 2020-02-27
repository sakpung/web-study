declare module lt.Annotations.JavaScript {
    class AnnPropertyInfo {
        valueChanged: AnnObjectEditorValueChangedHandler;
        constructor(propertyName: string, readOnly: boolean, value: any, category: string, description: string, displayName: string, visible: boolean, editorType: any);
        private editorType_OnValueChanged;
        private _editorType;
        readonly editorType: IAnnEditor;
        private _isReadOnly;
        readonly isReadOnly: boolean;
        private _isVisible;
        readonly isVisible: boolean;
        private _value;
        value: any;
        private _displayName;
        displayName: string;
        private _values;
        readonly values: {
            [key: string]: any;
        };
        private _type;
        readonly type: any;
        private _hasValues;
        readonly hasValues: boolean;
        private _category;
        category: string;
        private _description;
        description: string;
    }
    function isNullOrEmptyString(str: string): boolean;
}
declare module lt.Annotations.JavaScript {
    class AudioPlayerDialog {
        private _source;
        private _audioElement;
        private _sourceElement1;
        private _sourceElement2;
        private _sourceElement3;
        private dialogUI;
        private _OkClick;
        constructor();
        private Init;
        show(source1: string, source2: string, source3: string): void;
        readonly audioElement: HTMLAudioElement;
        OkClick: {
            (): void;
        };
        private OkBtn_Click;
    }
}
declare module lt.Annotations.JavaScript {
    class AutomationUpdateObjectDialog {
        private _initialPage;
        initialPage: AutomationUpdateObjectDlgTab;
        private _targetObject;
        targetObject: lt.Annotations.Engine.AnnObject;
        private _automation;
        automation: lt.Annotations.Automation.AnnAutomation;
        private _userName;
        userName: string;
        private _onHide;
        private _tabVisible;
        tabVisible: boolean[];
        private dialogUI;
        private _propertiesPage;
        private _contentPage;
        private _reviewsPage;
        constructor();
        onHide: {
            (): void;
        };
        private automationUpdateObjectDialog_Hide;
        show: () => void;
        private generateDialogTabs;
        private initPropertiestab;
        private initContenttab;
        private initReviewstab;
        setTabVisible(tab: AutomationUpdateObjectDlgTab, value: boolean): void;
    }
    enum AutomationUpdateObjectDlgTab {
        Properties = 0,
        Content = 1,
        Reviews = 2
    }
}
declare module lt.Annotations.JavaScript {
    class ContentPage {
        private _outputDivId;
        outputDivId: string;
        _targetObject: lt.Annotations.Engine.AnnObject;
        targetObject: lt.Annotations.Engine.AnnObject;
        private _onContentChange;
        onContentChange: {
            (): void;
        };
        private _contentText;
        contentText: string;
        initialize: () => void;
        empty: () => void;
        private createUIElement;
    }
}
declare module lt.Annotations.JavaScript {
    class ListTreeNode {
        private _childNodes;
        childNodes: Array<ListTreeNode>;
        private _isExpanded;
        isExpanded: boolean;
        constructor();
        private _parentDiv;
        readonly parentDiv: HTMLDivElement;
        private _headingDiv;
        readonly headingDiv: HTMLDivElement;
        private _headingLabel;
        readonly headingLabel: HTMLLabelElement;
        private _collapseExpandBtn;
        readonly collapseExpandBtn: HTMLAnchorElement;
        private _contentDiv;
        readonly contentDiv: HTMLDivElement;
        private _contextMenu;
        contextMenu: HTMLDivElement;
        private _contextMenu_collapseExpandBtn;
        contextMenu_collapseExpandBtn: HTMLButtonElement;
        createTreeNode(): void;
        clearContent(): void;
        private collapseExpandBtn_Click;
        updateNodeExpansion(): void;
        updateObjectInfoVisibility(): void;
        private showContextMenu;
        onShowContextMenu(): void;
        private contextMenu_collapseExpandBtn_Click;
        private _isTouchHold;
        private _touchHoldTimeOutHandler;
        private _currentTouchPoint;
        private _touchMoveTolerance;
        private hideContextMenu;
        private contextmenu;
        private touchstart;
        private touchmove;
        private touchend;
        static BtnChecked(btn: JQuery, check: boolean): any;
    }
}
declare module lt.Annotations.JavaScript {
    class AnnObjectTreeNode extends ListTreeNode {
        private _owner;
        private _automation;
        private _imageViewer;
        private _annContainer;
        private _annObject;
        readonly annObject: lt.Annotations.Engine.AnnObject;
        private _contentTextArea;
        private _contextMenu_replyBtn;
        private _contextMenu_deleteBtn;
        private _contextMenu_propertiesBtn;
        constructor(owner: AutomationObjectsListControl, automation: lt.Annotations.Automation.AnnAutomation, imageViewer: lt.Controls.ImageViewer, annContainer: lt.Annotations.Engine.AnnContainer, annObject: lt.Annotations.Engine.AnnObject);
        static createContextMenu(): void;
        customizeTreeNode(): void;
        static toLocalTimeString(utcString: string): string;
        updateMetadata(): void;
        updateContent(): void;
        hookEvents(): void;
        private parentDiv_MouseDown;
        private contentTextArea_Change;
        selectNode(select: boolean): void;
        onShowContextMenu(): void;
        private contextMenu_replyBtn_Click;
        private contextMenu_deleteBtn_Click;
        private contextMenu_propertiesBtn_Click;
    }
}
declare module lt.Annotations.JavaScript {
    class AutomationObjectsListControl {
        private _automation;
        automation: lt.Annotations.Automation.AnnAutomation;
        private _imageViewer;
        imageViewer: lt.Controls.ImageViewer;
        static userName: string;
        private _listContainerDiv;
        listContainerDiv: HTMLDivElement;
        private _pages;
        constructor();
        private _automation_AfterObjectChanged;
        private _automationContainers_CollectionChanged;
        private _automation_CurrentDesignerChanged;
        private _automation_AfterUndoRedo;
        private hookEvents;
        private automationContainers_CollectionChanged;
        private automation_AfterUndoRedo;
        private _ignoreChangedCounter;
        beginIgnoreChanged(): void;
        endIgnoreChanged(): void;
        private automation_AfterObjectChanged;
        private updateAllMetadata;
        private automation_CurrentDesignerChanged;
        private updateSelection;
        private getSelectedItems;
        private clear;
        populate(): void;
        populateContainer(annContainer: lt.Annotations.Engine.AnnContainer): void;
    }
}
declare module lt.Annotations.JavaScript {
    class PageTreeNode extends ListTreeNode {
        private _owner;
        private _automation;
        private _imageViewer;
        private _annContainer;
        readonly annContainer: lt.Annotations.Engine.AnnContainer;
        constructor(owner: AutomationObjectsListControl, automation: lt.Annotations.Automation.AnnAutomation, imageViewer: lt.Controls.ImageViewer, annContainer: lt.Annotations.Engine.AnnContainer);
        updateContent(): boolean;
    }
}
declare module lt.Annotations.JavaScript {
    class ReviewTreeNode extends ListTreeNode {
        private _automation;
        private _annObject;
        private _annReview;
        readonly annReview: lt.Annotations.Engine.AnnReview;
        private _parentTreeNode;
        private _dateTimeLabel;
        private _commentTextArea;
        private _checkedCheckbox;
        private _contextMenu_replyBtn;
        private _contextMenu_checkBtn;
        private _contextMenu_addBtn;
        private _contextMenu_deleteBtn;
        private _statusBtns;
        static undoImageUrl: string;
        constructor(automation: lt.Annotations.Automation.AnnAutomation, annObject: lt.Annotations.Engine.AnnObject, annReview: lt.Annotations.Engine.AnnReview, parentTreeNode: ListTreeNode);
        static createContextMenu(): void;
        customizeTreeNode(): void;
        updateContent(): void;
        hookEvents(): void;
        private checkedCheckbox_Change;
        private commentTextArea_Change;
        onShowContextMenu(): void;
        private contextMenu_replyBtn_Click;
        private contextMenu_checkBtn_Click;
        private contextMenu_addBtn_Click;
        private contextMenu_deleteBtn_Click;
        private statusBtns_BtnClicked;
    }
}
declare module lt.Annotations.JavaScript {
    class AutomationTextArea {
        private _textAreaElement;
        private _removeAction;
        private _automation;
        textObject: lt.Annotations.Engine.AnnTextObject;
        constructor(parent: HTMLDivElement, automation: lt.Annotations.Automation.AnnAutomation, editTextEvent: lt.Annotations.Engine.AnnEditTextEventArgs, removeAction: {
            (update: boolean): void;
        });
        remove(update: boolean): void;
        updateTextObject(): void;
        private tryInternalRemove;
        private textAreaElement_StopPropagation;
        private textAreaElement_FocusOut;
        private viewer_GotFocus;
        private textAreaElement_KeyDown;
    }
}
declare module lt.Annotations.JavaScript {
    class TreeView implements ITree {
        onSelectionChanged: {
            (event: Event): void;
        };
        mainDiv: HTMLDivElement;
        childNodesDiv: HTMLDivElement;
        parentDiv: HTMLDivElement;
        private _selectedNode;
        selectedNode: TreeNode;
        private _nodes;
        nodes: TreeNode[];
        constructor(divID: string);
        addNode(node: TreeNode): void;
        deleteNode(node: TreeNode): void;
        private updateUIElements;
    }
    class TreeNode implements ITree {
        treeView: TreeView;
        parent: TreeNode;
        parentDiv: HTMLDivElement;
        childNodesDiv: HTMLDivElement;
        contentDiv: HTMLDivElement;
        mainDiv: HTMLDivElement;
        private collapseLabel;
        private isCollapsed;
        private _isSelected;
        isSelected: boolean;
        private _nodes;
        nodes: TreeNode[];
        private _tag;
        tag: any;
        private _content;
        content: HTMLElement;
        constructor(treeView: TreeView);
        private mainDiv_Click;
        private collapseLabel_Click;
        addNode(node: TreeNode): void;
        deleteNode(node: TreeNode): void;
    }
    interface ITree {
        mainDiv: HTMLDivElement;
        childNodesDiv: HTMLDivElement;
        addNode(node: TreeNode): any;
        deleteNode(node: TreeNode): any;
    }
}
declare module lt.Annotations.JavaScript {
    class MediaPlayerDialog {
        private _source;
        private _videoElement;
        private _sourceElement1;
        private _sourceElement2;
        private _sourceElement3;
        private dialogUI;
        private _OkClick;
        constructor();
        private Init;
        show(source1: string, source2: string, source3: string): void;
        readonly videoElement: HTMLVideoElement;
        OkClick: {
            (): void;
        };
        private OkBtn_Click;
    }
}
declare module lt.Annotations.JavaScript {
    interface AnnObjectEditorValueChangedHandler {
        (oldValue: any, newValue: any): void;
    }
    interface IAnnEditor {
        category: string;
        properties: {
            [key: string]: lt.Annotations.JavaScript.AnnPropertyInfo;
        };
        onValueChanged: lt.Annotations.JavaScript.AnnObjectEditorValueChangedHandler;
    }
    class AnnColorEditor implements IAnnEditor {
        onValueChanged: lt.Annotations.JavaScript.AnnObjectEditorValueChangedHandler;
        private _category;
        readonly category: string;
        private _properties;
        readonly properties: {
            [key: string]: lt.Annotations.JavaScript.AnnPropertyInfo;
        };
        constructor(color: string, category: string);
        private _color;
        value: any;
    }
    class AnnBooleanEditor implements IAnnEditor {
        onValueChanged: lt.Annotations.JavaScript.AnnObjectEditorValueChangedHandler;
        private _category;
        readonly category: string;
        private _properties;
        readonly properties: {
            [key: string]: lt.Annotations.JavaScript.AnnPropertyInfo;
        };
        constructor(value: boolean, category: string);
        private _value;
        value: boolean;
    }
    class AnnLengthEditor implements IAnnEditor {
        onValueChanged: lt.Annotations.JavaScript.AnnObjectEditorValueChangedHandler;
        private _category;
        readonly category: string;
        private _properties;
        readonly properties: {
            [key: string]: lt.Annotations.JavaScript.AnnPropertyInfo;
        };
        constructor(annLength: lt.LeadLengthD, category: string, propertyName: string, displayName: string);
        private _annLength;
        private info_ValueChanged;
    }
    class AnnSolidColorBrushEditor implements IAnnEditor {
        onValueChanged: lt.Annotations.JavaScript.AnnObjectEditorValueChangedHandler;
        private _category;
        readonly category: string;
        private _properties;
        readonly properties: {
            [key: string]: lt.Annotations.JavaScript.AnnPropertyInfo;
        };
        constructor(annSolidColorBrush: lt.Annotations.Engine.AnnSolidColorBrush, category: string, propertyName: string, displayName: string);
        private _annSolidColorBrush;
        info_ValueChanged: (oldValue: any, newValue: any) => void;
    }
    class AnnDoubleEditor implements IAnnEditor {
        onValueChanged: lt.Annotations.JavaScript.AnnObjectEditorValueChangedHandler;
        private _category;
        readonly category: string;
        private _properties;
        readonly properties: {
            [key: string]: lt.Annotations.JavaScript.AnnPropertyInfo;
        };
        constructor(value: number, category: string);
        private _value;
        value: number;
    }
    class AnnStringEditor implements IAnnEditor {
        onValueChanged: lt.Annotations.JavaScript.AnnObjectEditorValueChangedHandler;
        private _category;
        readonly category: string;
        private _properties;
        readonly properties: {
            [key: string]: lt.Annotations.JavaScript.AnnPropertyInfo;
        };
        constructor(value: string, category: string);
        private _value;
        value: string;
    }
    class AnnPictureEditor implements IAnnEditor {
        onValueChanged: lt.Annotations.JavaScript.AnnObjectEditorValueChangedHandler;
        private _category;
        readonly category: string;
        private _properties;
        readonly properties: {
            [key: string]: lt.Annotations.JavaScript.AnnPropertyInfo;
        };
        constructor(value: lt.Annotations.Engine.AnnPicture, category: string);
        private _value;
        value: lt.Annotations.Engine.AnnPicture;
    }
    class AnnMediaEditor implements IAnnEditor {
        onValueChanged: lt.Annotations.JavaScript.AnnObjectEditorValueChangedHandler;
        private _category;
        readonly category: string;
        private _properties;
        readonly properties: {
            [key: string]: lt.Annotations.JavaScript.AnnPropertyInfo;
        };
        constructor(value: lt.Annotations.Engine.AnnMedia, category: string);
        private _value;
        value: lt.Annotations.Engine.AnnMedia;
    }
    class AnnIntegerEditor implements IAnnEditor {
        onValueChanged: lt.Annotations.JavaScript.AnnObjectEditorValueChangedHandler;
        private _category;
        readonly category: string;
        private _properties;
        readonly properties: {
            [key: string]: lt.Annotations.JavaScript.AnnPropertyInfo;
        };
        constructor(value: number, category: string);
        private _value;
        value: number;
    }
    class AnnStrokeEditor implements IAnnEditor {
        onValueChanged: lt.Annotations.JavaScript.AnnObjectEditorValueChangedHandler;
        private _category;
        readonly category: string;
        private _properties;
        readonly properties: {
            [key: string]: lt.Annotations.JavaScript.AnnPropertyInfo;
        };
        constructor(annStroke: lt.Annotations.Engine.AnnStroke, category: string);
        private strokePropertyInfo_ValueChanged;
    }
    class AnnFontEditor implements IAnnEditor {
        onValueChanged: lt.Annotations.JavaScript.AnnObjectEditorValueChangedHandler;
        private _category;
        readonly category: string;
        private _properties;
        readonly properties: {
            [key: string]: lt.Annotations.JavaScript.AnnPropertyInfo;
        };
        constructor(annFont: lt.Annotations.Engine.AnnFont, category: string);
        private _annFont;
        private fontSize_ValueChanged;
        private fontFamilyName_ValueChanged;
    }
    class AnnObjectEditor {
        private _properties;
        readonly properties: {
            [key: string]: lt.Annotations.JavaScript.AnnPropertyInfo;
        };
        private _annObject;
        constructor(annObject: lt.Annotations.Engine.AnnObject);
        private wordWrapInfo_ValueChanged;
        private pictureInfo_ValueChanged;
        private hyperlink_ValueChanged;
        private showPictureInfo_ValueChanged;
        private expandedInfo_ValueChanged;
        private fillPropertyInfo_ValueChanged;
        private strokePropertyInfo_ValueChanged;
        private ruberStampTypeinfo_ValueChanged;
        private acuteInfo_ValueChanged;
        private fixedPointerInfo_ValueChanged;
        private anglePrecisionInfo_ValueChanged;
        private precisionInfo_ValueChanged;
        private angularUnitInfo_ValueChanged;
        private showTickMarksInfo_ValueChanged;
        private measurementUnitInfo_ValueChanged;
        private showGauge_ValueChanged;
        private tensionInfo_ValueChanged;
        private horizontalAlignment_ValueChanged;
        private verticalAlignment_ValueChanged;
        private text_ValueChanged;
        private media_ValueChanged;
        private encryptKey_ValueChanged;
        private encryptor_ValueChanged;
        private RubberStampTypeToString;
        private fillEnumValue;
    }
}
declare module lt.Annotations.JavaScript {
    class ObjectsAlignmentDialog {
        private _onHide;
        onHide: {
            (actionId: number): void;
        };
        private _automation;
        automation: lt.Annotations.Automation.AnnAutomation;
        private dialogUI;
        constructor();
        private Init;
        show(): void;
        private enableObjectsAlignment_Change;
        private objectsAlignmentButtons_Click;
        private okButton_Click;
        static ToLeftActionId: number;
        static ToCenterActionId: number;
        static ToRightActionId: number;
        static ToTopActionId: number;
        static ToMiddleActionId: number;
        static ToBottomActionId: number;
        static SameWidthtActionId: number;
        static SameHeightActionId: number;
        static SameSizeActionId: number;
    }
}
declare module lt.Annotations.JavaScript {
    class PasswordDialog {
        private _lock;
        private _password;
        private dialogUI;
        private _OkClick;
        constructor();
        private Init;
        show(lock: boolean): void;
        readonly password: string;
        OkClick: {
            (): void;
        };
        private OkBtn_Click;
    }
}
declare module lt.Annotations.JavaScript {
    class PropertiesPage {
        private _outputDivId;
        outputDivId: string;
        private _automation;
        automation: lt.Annotations.Automation.AnnAutomation;
        private dialogUI;
        static onPropertiesChanged: {
            (value: string, userData: any): void;
        };
        private _groupCount;
        readonly groupCount: number;
        private _properties;
        private _subGroupCount;
        private _cssItem;
        static _editorsLookup: Array<IAnnEditor>;
        static _propertiesLookup: Array<any>;
        initialize(): void;
        private createItem;
        private createUIElement;
        private createObjectPropertiesTabs;
        private createPropertiestabs;
        private appendToGroup;
        private renderGridInput;
        static validateNumbericalKey(event: Event): void;
        static UpdateStyleInnerNum(cssId: string, divId: string, value: any): void;
        static UpdateStyleInnerMedia(cssId: string, divId: string, id: string, value: any): void;
        static UpdateStyleInner(cssId: string, divId: string, value: any): void;
        static Expand(id: string, sub: string): void;
        private clearValues;
        private empty;
        private hideItems;
        private fillCss2;
        private enumEditObject;
        private editObject;
        private canDeleteObject;
    }
}
declare module lt.Annotations.JavaScript {
    class ReviewsPage {
        private _userName;
        userName: string;
        private treeView;
        private date;
        pageUI: {
            page: string;
            header: string;
            contnet: string;
            details: string;
            author: string;
            day: string;
            month: string;
            year: string;
            status: string;
            checked: string;
            comment: string;
            replay: string;
            add: string;
            deleteBtn: string;
            treeView: string;
        };
        initialize(): void;
        private empty;
        private addUIEventHandler;
        private createUIElement;
        private treeView_SelectionChanged;
        copyReviewsFrom(annObject: lt.Annotations.Engine.AnnObject): void;
        updateContent(annObject: lt.Annotations.Engine.AnnObject): void;
        replacesReviewsIn(annObject: lt.Annotations.Engine.AnnObject): void;
        private static getNode;
        private static addNode;
        private static getReviewNodeText;
        private updateUIState;
        private replayNode_Click;
        private addNode_Click;
        private deleteNode_Click;
        private deleteReview;
        private addOrReply;
        private detailsTextBox_TextChanged;
        private checkedCheckBox_ValueChanged;
        private dateTimePicker_ValueChanged;
        private reviewToDetails;
        private detailsToReview;
        private getStatusSelectIndex;
        cleanUp(): void;
    }
}
declare module lt.Annotations.JavaScript {
    class SnapToGridPropertiesDialog {
        private _onHide;
        private dialogUI;
        private _automation;
        automation: lt.Annotations.Automation.AnnAutomation;
        private _snapToGridOptions;
        constructor();
        private Init;
        show(): void;
        private getLineStyleFromStrok;
        private getSelectedColorFromStroke;
        onHide: {
            (): void;
        };
        private okBtn_Click;
    }
}
declare module lt.Annotations.JavaScript {
    enum AnnCursorType {
        selectObject = 0,
        selectedObject = 1,
        controlPoint = 2,
        controlPointNWSE = 3,
        controlPointNS = 4,
        controlPointNESW = 5,
        controlPointWE = 6,
        selectRectangle = 7,
        run = 8,
        rotateCenterControlPoint = 9,
        rotateGripperControlPoint = 10,
        Default = 11,
        count = 12
    }
    class AutomationManagerHelper {
        private _manager;
        readonly automationManager: lt.Annotations.Automation.AnnAutomationManager;
        private _resourcesPath;
        static _resourcesTamplate: string;
        private static _drawCursorsTemplate;
        private static _objectsImagesTemplate;
        private _drawCursors;
        readonly drawCursors: {
            [objectId: string]: string;
        };
        private _objectsImages;
        private static _undoImageUrlTemplate;
        private static _automationCursors;
        readonly automationCursors: {
            [key: number]: string;
        };
        constructor(manager: lt.Annotations.Automation.AnnAutomationManager, resourcesPath: string);
        private updateResourcePaths;
        updateAutomationObjects(): void;
        private static updateAutomationObject;
        getAutomationObjectCursor(objectId: number): any;
        getAutomationObjectImage(objectId: number): any;
        private static checkModifierKey;
        LoadPackage(annPackage: lt.Annotations.Automation.IAnnPackage): void;
    }
}
declare module lt.Annotations.JavaScript {
    class AutomationImageViewer extends lt.Controls.ImageViewer implements lt.Annotations.Engine.IAnnAutomationControl {
        constructor(createOptions: lt.Controls.ImageViewerCreateOptions);
        private handleGotFocus;
        automationObject: lt.Annotations.Automation.AnnAutomation;
        get_automationObject(): Automation.AnnAutomation;
        set_automationObject(value: lt.Annotations.Automation.AnnAutomation): void;
        automationPointerDown: lt.Annotations.Engine.AnnPointerEventType;
        add_automationPointerDown(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        remove_automationPointerDown(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        automationPointerMove: lt.Annotations.Engine.AnnPointerEventType;
        add_automationPointerMove(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        remove_automationPointerMove(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        automationPointerUp: lt.Annotations.Engine.AnnPointerEventType;
        add_automationPointerUp(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        remove_automationPointerUp(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        automationDoubleClick: lt.Annotations.Engine.AnnPointerEventType;
        add_automationDoubleClick(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        remove_automationDoubleClick(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        onAutomationPointerDown(args: lt.Annotations.Engine.AnnPointerEventArgs): void;
        onAutomationPointerMove(args: lt.Annotations.Engine.AnnPointerEventArgs): void;
        onAutomationPointerUp(args: lt.Annotations.Engine.AnnPointerEventArgs): void;
        onAutomationDoubleClick(args: lt.Annotations.Engine.AnnPointerEventArgs): void;
        automationDpiX: number;
        automationDpiY: number;
        get_automationDpiX(): number;
        get_automationDpiY(): number;
        automationEnabled: boolean;
        get_automationEnabled(): boolean;
        automationEnabledChanged: lt.LeadEventType;
        add_automationEnabledChanged(value: lt.LeadEventHandler): void;
        remove_automationEnabledChanged(value: lt.LeadEventHandler): void;
        onEnabledChanged(e: lt.LeadEventArgs): void;
        automationLostFocus: lt.LeadEventType;
        add_automationLostFocus(value: lt.LeadEventHandler): void;
        remove_automationLostFocus(value: lt.LeadEventHandler): void;
        automationGotFocus: lt.LeadEventType;
        add_automationGotFocus(value: lt.LeadEventHandler): void;
        remove_automationGotFocus(value: lt.LeadEventHandler): void;
        automationSizeChanged: lt.LeadEventType;
        add_automationSizeChanged(value: lt.LeadEventHandler): void;
        remove_automationSizeChanged(value: lt.LeadEventHandler): void;
        onItemChanged(e: lt.Controls.ImageViewerItemChangedEventArgs): void;
        automationTransform: lt.LeadMatrix;
        get_automationTransform(): lt.LeadMatrix;
        automationTransformChanged: lt.LeadEventType;
        add_automationTransformChanged(value: lt.LeadEventHandler): void;
        remove_automationTransformChanged(value: lt.LeadEventHandler): void;
        onTransformChanged(e: lt.LeadEventArgs): void;
        automationUseDpi: boolean;
        get_automationUseDpi(): boolean;
        automationUseDpiChanged: lt.LeadEventType;
        add_automationUseDpiChanged(value: lt.LeadEventHandler): void;
        remove_automationUseDpiChanged(value: lt.LeadEventHandler): void;
        get_useDpi(): boolean;
        set_useDpi(value: boolean): void;
        automationXResolution: number;
        automationYResolution: number;
        get_automationXResolution(): number;
        get_automationYResolution(): number;
        automationInvalidate(rc: lt.LeadRectD): void;
        automationAntiAlias: boolean;
        get_automationAntiAlias(): boolean;
        set_automationAntiAlias(value: boolean): void;
        renderingEngine: lt.Annotations.Engine.AnnRenderingEngine;
        get_renderingEngine(): lt.Annotations.Engine.AnnRenderingEngine;
        set_renderingEngine(value: lt.Annotations.Engine.AnnRenderingEngine): void;
        onPostRender(e: lt.Controls.ImageViewerRenderEventArgs): void;
        private static renderContainer;
        automationGetContainersCallback: lt.Annotations.Engine.AnnAutomationControlGetContainersCallback;
        get_automationGetContainersCallback(): lt.Annotations.Engine.AnnAutomationControlGetContainersCallback;
        set_automationGetContainersCallback(value: lt.Annotations.Engine.AnnAutomationControlGetContainersCallback): void;
        automationContainerIndex: number;
        get_automationContainerIndex(): number;
        set_automationContainerIndex(value: number): void;
        container: lt.Annotations.Engine.AnnContainer;
        automationAttach(container: lt.Annotations.Engine.AnnContainer): void;
        automationDetach(): void;
        get_automationContainer(): lt.Annotations.Engine.AnnContainer;
        isAutomationAttached(): boolean;
        automationDataProvider: lt.Annotations.Engine.AnnDataProvider;
        get_automationDataProvider(): lt.Annotations.Engine.AnnDataProvider;
        set_automationDataProvider(value: lt.Annotations.Engine.AnnDataProvider): void;
        automationScrollOffset: lt.LeadPointD;
        get_automationScrollOffset(): lt.LeadPointD;
        automationRotateAngle: number;
        get_automationRotateAngle(): number;
        automationScaleFactor: number;
        get_automationScaleFactor(): number;
        isAutomationEventsHooked: boolean;
        get_isAutomationEventsHooked(): boolean;
        set_isAutomationEventsHooked(value: boolean): void;
    }
}
declare module lt.Annotations.JavaScript {
    class AutomationInteractiveMode extends lt.Controls.ImageViewerInteractiveMode {
        automationId: number;
        constructor();
        private _id;
        get_id(): number;
        setId(value: number): void;
        private _automationControl;
        automationControl: lt.Annotations.Engine.IAnnAutomationControl;
        private readonly workAutomationControl;
        get_name(): string;
        canStartWork(e: lt.Controls.InteractiveEventArgs): boolean;
        private _dragStartedHandler;
        private _dragDeltaHandler;
        private _dragCompletedHandler;
        private _tapHandler;
        private _doubleTapHandler;
        private _moveHandler;
        start(imageViewer: lt.Controls.ImageViewer): void;
        stop(imageViewer: lt.Controls.ImageViewer): void;
        private static convertPointerEventArgs;
        private interactiveService_DragStarted;
        private interactiveService_DragDelta;
        private interactiveService_DragCompleted;
        private interactiveService_Tap;
        private interactiveService_DoubleTap;
        private interactiveService_Move;
    }
}
declare module lt.Annotations.JavaScript {
    class DocumentPackDialog {
        private _lock;
        private _objectID;
        private dialogUI;
        private _onHide;
        constructor();
        private Init;
        show(): void;
        readonly objectID: number;
        onHide: {
            (objectID: number): void;
        };
        private documentPackDialog_Hide;
        private documentObjectBtns_BtnClicked;
        private CancelBtn_Click;
    }
}
declare module lt.Annotations.JavaScript {
    class CanvasDataProvider extends lt.Annotations.Engine.AnnDataProvider {
        private _acitveCanvas;
        private _orginalImageData;
        constructor(acitveCanvas: HTMLCanvasElement);
        private applyEncryptDecrypt;
        decrypt(container: lt.Annotations.Engine.AnnContainer, bounds: LeadRectD, key: number): void;
        encrypt(container: lt.Annotations.Engine.AnnContainer, bounds: LeadRectD, key: number): void;
        fill(container: lt.Annotations.Engine.AnnContainer, bounds: lt.LeadRectD, color: string): void;
        getImageData(container: lt.Annotations.Engine.AnnContainer, bounds: lt.LeadRectD): number[];
        setImageData(container: lt.Annotations.Engine.AnnContainer, bounds: lt.LeadRectD, data: any): void;
    }
}
declare module lt.Annotations.JavaScript {
    enum AutomationControlMultiContainerMode {
        SinglePage = 0,
        MultiPage = 1
    }
    class ImageViewerAutomationControl implements lt.Annotations.Engine.IAnnAutomationControl {
        constructor();
        private _multiContainerMode;
        multiContainerMode: AutomationControlMultiContainerMode;
        dispose(): void;
        private _imageViewer;
        imageViewer: lt.Controls.ImageViewer;
        private handleGotFocus;
        private hook;
        private unHook;
        automationObject: lt.Annotations.Automation.AnnAutomation;
        get_automationObject(): Automation.AnnAutomation;
        set_automationObject(value: lt.Annotations.Automation.AnnAutomation): void;
        automationPointerDown: lt.Annotations.Engine.AnnPointerEventType;
        add_automationPointerDown(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        remove_automationPointerDown(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        automationPointerMove: lt.Annotations.Engine.AnnPointerEventType;
        add_automationPointerMove(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        remove_automationPointerMove(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        automationPointerUp: lt.Annotations.Engine.AnnPointerEventType;
        add_automationPointerUp(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        remove_automationPointerUp(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        automationDoubleClick: lt.Annotations.Engine.AnnPointerEventType;
        add_automationDoubleClick(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        remove_automationDoubleClick(value: lt.Annotations.Engine.AnnPointerEventHandler): void;
        onAutomationPointerDown(args: lt.Annotations.Engine.AnnPointerEventArgs): void;
        onAutomationPointerMove(args: lt.Annotations.Engine.AnnPointerEventArgs): void;
        onAutomationPointerUp(args: lt.Annotations.Engine.AnnPointerEventArgs): void;
        onAutomationDoubleClick(args: lt.Annotations.Engine.AnnPointerEventArgs): void;
        automationDpiX: number;
        automationDpiY: number;
        get_automationDpiX(): number;
        get_automationDpiY(): number;
        automationEnabled: boolean;
        get_automationEnabled(): boolean;
        automationEnabledChanged: lt.LeadEventType;
        add_automationEnabledChanged(value: lt.LeadEventHandler): void;
        remove_automationEnabledChanged(value: lt.LeadEventHandler): void;
        onEnabledChanged(e: lt.LeadEventArgs): void;
        automationLostFocus: lt.LeadEventType;
        add_automationLostFocus(value: lt.LeadEventHandler): void;
        remove_automationLostFocus(value: lt.LeadEventHandler): void;
        automationGotFocus: lt.LeadEventType;
        add_automationGotFocus(value: lt.LeadEventHandler): void;
        remove_automationGotFocus(value: lt.LeadEventHandler): void;
        automationSizeChanged: lt.LeadEventType;
        add_automationSizeChanged(value: lt.LeadEventHandler): void;
        remove_automationSizeChanged(value: lt.LeadEventHandler): void;
        private imageViewer_ItemChanged;
        private imageViewer_ActiveItemChanged;
        private automationObject_ActiveContainerChanged;
        private syncActiveItemContainer;
        private getItemForCurrentContainer;
        private getCurrentContainer;
        automationTransform: lt.LeadMatrix;
        get_automationTransform(): lt.LeadMatrix;
        automationTransformChanged: lt.LeadEventType;
        add_automationTransformChanged(value: lt.LeadEventHandler): void;
        remove_automationTransformChanged(value: lt.LeadEventHandler): void;
        private imageViewer_TransformChanged;
        automationUseDpi: boolean;
        get_automationUseDpi(): boolean;
        automationUseDpiChanged: lt.LeadEventType;
        add_automationUseDpiChanged(value: lt.LeadEventHandler): void;
        remove_automationUseDpiChanged(value: lt.LeadEventHandler): void;
        imageViewer_PropertyChanged: (sender: any, e: Controls.PropertyChangedEventArgs) => void;
        automationXResolution: number;
        automationYResolution: number;
        get_automationXResolution(): number;
        get_automationYResolution(): number;
        automationInvalidate(rc: lt.LeadRectD): void;
        automationAntiAlias: boolean;
        get_automationAntiAlias(): boolean;
        set_automationAntiAlias(value: boolean): void;
        renderingEngine: lt.Annotations.Engine.AnnRenderingEngine;
        get_renderingEngine(): lt.Annotations.Engine.AnnRenderingEngine;
        set_renderingEngine(value: lt.Annotations.Engine.AnnRenderingEngine): void;
        private imageViewer_PostRender;
        private static renderContainer;
        automationGetContainersCallback: lt.Annotations.Engine.AnnAutomationControlGetContainersCallback;
        get_automationGetContainersCallback(): lt.Annotations.Engine.AnnAutomationControlGetContainersCallback;
        set_automationGetContainersCallback(value: lt.Annotations.Engine.AnnAutomationControlGetContainersCallback): void;
        automationContainerIndex: number;
        get_automationContainerIndex(): number;
        set_automationContainerIndex(value: number): void;
        _container: lt.Annotations.Engine.AnnContainer;
        automationAttach(container: lt.Annotations.Engine.AnnContainer): void;
        automationDetach(): void;
        automationDataProvider: lt.Annotations.Engine.AnnDataProvider;
        get_automationDataProvider(): lt.Annotations.Engine.AnnDataProvider;
        set_automationDataProvider(value: lt.Annotations.Engine.AnnDataProvider): void;
        automationScrollOffset: lt.LeadPointD;
        get_automationScrollOffset(): lt.LeadPointD;
        automationRotateAngle: number;
        get_automationRotateAngle(): number;
        automationScaleFactor: number;
        get_automationScaleFactor(): number;
        isAutomationEventsHooked: boolean;
        get_isAutomationEventsHooked(): boolean;
        set_isAutomationEventsHooked(value: boolean): void;
    }
}
declare module lt.Annotations.JavaScript {
    class MedicalPackDialog {
        private _lock;
        private _objectID;
        private dialogUI;
        private _onHide;
        constructor();
        private Init;
        show(): void;
        readonly objectID: number;
        onHide: {
            (objectID: number): void;
        };
        private medicalPackDialog_Hide;
        private medicalObjectBtns_BtnClicked;
        private CancelBtn_Click;
    }
}
declare module lt.Annotations.JavaScript {
    class RightClickInteractiveMode extends lt.Controls.ImageViewerInteractiveMode {
        onRightClick: {
            (x: number, y: number): void;
        };
        _automation: lt.Annotations.Automation.AnnAutomation;
        automation: lt.Annotations.Automation.AnnAutomation;
        constructor();
        toString(): string;
        start(viewer: lt.Controls.ImageViewer): void;
        stop(viewer: lt.Controls.ImageViewer): void;
        private RightClickInteractiveMode_ServiceTap;
    }
}
