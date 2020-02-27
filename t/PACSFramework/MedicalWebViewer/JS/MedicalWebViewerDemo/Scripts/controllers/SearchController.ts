// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="Scopes.ts" />

class SearchController {
    public _queryArchiveService;
    public _authenticationService: AuthenticationService;
    public _openWith = "Open With";
    public _templateService: TemplateService;
    private _scope;
    private _templates: Array<Models.Template>;
    private _templatesHasAutoMatch: boolean = false;
    private _modalities: Array<Modality>;
    private _structuredDisplay: Array<Models.HangingProtocolQueryResult>;

    static $inject = ["$rootScope", "$scope", "queryArchiveService", "optionsService", "authenticationService", "queryPacsService", "tabService", "eventService", "templateService", "templateEditorService", "$translate"]

    constructor($rootScope, $scope: Controllers.ISearchControllerScope, queryArchiveService: QueryArchiveService, optionsService: OptionsService, authenticationService: AuthenticationService, queryPacsService: QueryPacsService, tabService: TabService, eventService: EventService, templateService: TemplateService, templateEditorService: TemplateEditorService, $translate) {
        var scrollTop;
        this._scope = $scope;
        this._queryArchiveService = queryArchiveService;
        this._authenticationService = authenticationService;
        this._templateService = templateService;
        this._modalities = templateEditorService.getModalities();

        $scope.showPacsQuery = optionsService.get(OptionNames.ShowPacsQuery) && authenticationService.hasPermission(PermissionNames.CanQueryPACS);

        $scope.querySource = {};
        $scope.querySource.name = 'database';
        $scope.querySource.pacs = null;
        $scope.isTabletOrMobile = Utils.isTabletOrMobile();

        $scope.getUrl = function (row) {
            return Utils.get_thumbnailUrl(row.entity);
        }

        queryPacsService.GetConnectionInfo().then(function (result) {
            $scope.pacsClientInfo = result.data[0];
            $scope.storageServerInfo = result.data[1];
        }.bind(this));

        if (authenticationService.hasPermission(PermissionNames.CanViewTemplates)) {

            templateService.GetAllTemplates().then(function (result) {
                if (result && result.data) {
                    this._templates = result.data;
                    this.updateTemplatesHaveAutoMatch();
                }
            }.bind(this));
        }
        
        eventService.subscribe(EventNames.SelectedTabChanged, function (event, data) {
            var tab: Models.Tab = tabService.find_tab(data.args.currentTab.id);

            if (tab.type == TabTypes.Search) {
                if ($scope.onSearchTabSelected) {
                    $scope.onSearchTabSelected();
                }                
            }
        });        

        $translate('OPEN_WITH').then(function (translation) {
            this._openWith = translation;
        }.bind(this));

        $translate('SD_OPEN_WITH').then(function (translation) {
            this._sdOpenWith = translation;
        }.bind(this));

        $scope.$watch('windowDimensions', function (newValue,oldValue) {
            if ($scope.onLayoutChanged) {
                $scope.onLayoutChanged(newValue,oldValue);
            }
        });
    }

    public get_structuredDisplay() {
        return this._structuredDisplay;
    }

    public set_structuredDisplay(value) {
        this._structuredDisplay = value;
    }

    public patientids(patientId) {
        return this._queryArchiveService.AutoComplete("patientid", patientId).then(function (results) {
            var ids: Array<any> = new Array<any>();

            angular.forEach(results.data, function (item) {
                ids.push(item.Word);
            });
            return ids;
        });
    }

    public patientNames(patientName) {
        var term = patientName.replace(" ", "^");

        return this._queryArchiveService.AutoComplete("patientname", term).then(function (results) {
            var ids: Array<any> = new Array<any>();

            angular.forEach(results.data, function (item) {
                ids.push(item.Word);
            });
            return ids;
        });
    }    

    public updateTemplatesHaveAutoMatch(): void{
        
        if (this._templates) {
            for (var i = 0; i < this._templates.length; i++) {
                var template = this._templates[i];

                if (template.AutoMatching) {
                    this._templatesHasAutoMatch = true;
                    return ;
                }
            }            
        }

        this._templatesHasAutoMatch = false;
    }


    public createStructuredDisplayFromTemplate(template: Models.Template)
    {
        var output : any = {};

        var index = 0;
        var length = template.Frames.length;
        var box;
        var frame: Models.Frame;
        output.Boxes = [];


        output.Rows = -1;
        output.Columns = -1;
        output.Name = template.Name;
        output.OtherStudies = [];
        output.Series = [];


        for (index = 0; index < length; index++) {
            frame = template.Frames[index];
            box = {};

            box.ColumnPosition = -1;
            box.FirstFrame = {};
            box.HorizontalJustification = frame.HorizontalJustification;
            box.ImageBoxLargeScrollAmount = null;
            box.ImageBoxLargeScrollType = 0;
            box.ImageBoxLayoutType = 4;
            box.ImageBoxNumber = frame.FrameNumber;
            box.ImageBoxScrollDirection = null;
            box.ImageBoxSmallScrollAmount = null;
            box.ImageBoxSmallScrollType = null;
            box.ImageBoxTileHorizontalDimension = 1;
            box.ImageBoxTileVerticalDimension = 1;
            box.NumberOfColumns = 0;
            box.NumberOfRows = 0;
            box.Position = {
                leftTop: { x: frame.Position.leftTop.x, y: frame.Position.leftTop.y }, rightBottom: { x: frame.Position.rightBottom.x, y: frame.Position.rightBottom.y }
            }
            box.PreferredPlaybackSequencing = null;
            box.RecommendedDisplayFrameRate = null;
            box.ReferencedPresentationStateSOP = "";
            box.RowPosition = -1;
            box.VerticalJustification = frame.VerticalJustification;
            box.WindowCenter = -1;
            box.WindowWidth = -1;
            box.referencedSOPInstanceUID = null;

            output.Boxes[index] = box;
        }

        return output;
    }


    public getTemplateMenu(modality: string){
        var menuItems = {};                

        if (this._templates) {
            var noMatchTemplates: Array<Models.Template> = new Array<Models.Template>();

            for (var i = 0; i < this._templates.length; i++) {
                var template = this._templates[i];

                if (this.isTemplateMatch(modality, template)) {
                    var item = {};

                    menuItems[template.Id] = {
                        name: template.Name
                    };
                }
                else {
                    noMatchTemplates.push(template);
                }
            }

            if (!$.isEmptyObject(menuItems) && noMatchTemplates.length > 0) {
                menuItems["seperator"] = "-----";
            }

            if (noMatchTemplates.length > 0) {
                menuItems["nonmatching"] = {
                    name: "Other Templates",
                    items: {}
                }

                for (var i = 0; i < noMatchTemplates.length; i++) {
                    var template = noMatchTemplates[i];

                    menuItems["nonmatching"]["items"][template.Id] = {
                        name: template.Name
                    };
                }
            }
        }

        return menuItems;
    }

    private isTemplateMatch(modality: string, template: Models.Template):boolean {
        var data: Array<string> = template.Modality.split('|');
        var modalities: Array<Modality>;               

        if (data.length == 0)
            return false;

        if (data.length == 1) {
            modalities = $.grep(this._modalities, function (modality: Modality, index: number) {
                return modality.classType == data[0];
            });
        }
        else {
            modalities = $.grep(this._modalities, function (modality: Modality, index: number) {
                return modality.classType == data[0] && modality.description == data[1];
            });
        }

        if (modalities.length > 0) {
            return modalities[0].name == modality;
        }
        return false;
    }

    public getTemplate(id:string): Models.Template {
        return Utils.findFirst(this._templates, function (template: Models.Template) {
            return id == template.Id;
        });
    }

    public getAutoMatchTemplates(): Models.Template[] {
        return Utils.findAll(this._templates, function (template: Models.Template) {
            return template.AutoMatching;
        });
    }

    public isAnyTemplateAutoMatch(): boolean {
        return this._templatesHasAutoMatch;
    }
} 