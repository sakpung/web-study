// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export class SeriesListController {
        static $inject = ['$rootScope', '$scope', 'uiGridConstants', 'eventService', 'optionsService', 'dataService', 'seriesManagerService', '$commangular', 'templateService', 'objectRetrieveService', 'tabService', 'authenticationService'];

        doCheckAll: Function;
        private _scope;
        private _dataService: DataService;
        private _seriesManagerService: SeriesManagerService;
        private _eventService: EventService;
        private _$commangular;
        private _compareButton;
        private _exportButton;
        private _seriesTemplate;
        private _templates: Array<Models.Template>;
        private _templatesHasAutoMatch: boolean = false;
        private _objectRetrieveService: ObjectRetrieveService;
        private _list: HTMLTableElement;
        private _span: HTMLSpanElement;
        private _sturctureDisplayList: Array<any>;
        private _options: OptionsService;
        private _selectedRow: HTMLTableRowElement;
        private _tabService: TabService;
        private _currentSelectedSeries;
        private _authenticationService;
        private seriesListTable;

        constructor($rootScope, $scope: any, uiGridConstants, eventService: EventService, optionsService: OptionsService, dataService: DataService, seriesManagerService: SeriesManagerService, $commangular, templateService: TemplateService, objectRetrieveService: ObjectRetrieveService, tabService: TabService, authenticationService: AuthenticationService) {
            var dateFormat = optionsService.get(OptionNames.DateFormat);
            var timeFormat = optionsService.get(OptionNames.TimeFormat);
            var patientId = seriesManagerService.currentLoadingSeries.Patient.ID;
            var __this = this;


            var seriesGroup = "Series List";
            var compareButton: JQuery;
            this._options = optionsService;
            this._objectRetrieveService = objectRetrieveService;
            this._tabService = tabService;
            $scope.setListController(this);
            $scope.activeSeriesInstanceUID = seriesManagerService.currentLoadingSeries.InstanceUID;

            if (authenticationService.hasPermission(PermissionNames.CanViewTemplates)) {

                templateService.GetAllTemplates().then(function (result) {
                    if (result && result.data) {
                        this._templates = result.data;
                        this.updateTemplatesHaveAutoMatch();
                    }
                }.bind(this));
            }



            this._scope = $scope;
            this._seriesManagerService = seriesManagerService;
            this._eventService = eventService;
            this._$commangular = $commangular;
            this._seriesTemplate = {};
            this._authenticationService = authenticationService;
            this._objectRetrieveService = objectRetrieveService;
            var searchResultID: JQuery = $("div.seriesList");
            var div = searchResultID[searchResultID.length - 1];
            div.id = patientId;

            this.refreshContent(objectRetrieveService, seriesManagerService, patientId);

            this._dataService = dataService;            

            eventService.subscribe(EventNames.ActiveSeriesChanged, function (event, data) {
                var tab = seriesManagerService.get_seriesTab(data.args.seriesInstanceUID);

                if (tab != null) {
                    if (tab.id == $scope.tabId) {
                        $scope.activeSeriesInstanceUID = data.args.series;                         

                        // don't change selection if the selected is structured display, 
                        // because the user might click on one of the structured display images,
                        // and make the list swtich to that image on the series.
                        if (!__this._seriesManagerService.currentStructuredDisplay)
                            __this.selectSeries($scope.activeSeriesInstanceUID);                       
                    }
                }
            }); 

            eventService.subscribe(EventNames.DerivedImageCreated, function (event, data) {


                if ($.grep(__this._seriesManagerService.currentPatientSeries, function (item) { return item.InstanceUID == data.args.series.InstanceUID }).length == 0) {

                    seriesManagerService.currentPatientSeries[seriesManagerService.currentPatientSeries.length] = data.args.series;
                    seriesManagerService.currentLoadingSeries = data.args.series;

                    __this.refreshContent(objectRetrieveService, seriesManagerService, patientId);
                }
            });



            eventService.subscribe(EventNames.SelectedTabChanged, function (event, data) {

                //setTimeout(function () {

                //    $scope.gridOptions.api.refreshView();

                //}, 250);

            });        


            //eventService.subscribe(EventNames.MrtiInfoReady, function (event, data) {
            //    Utils.clearMrti($scope.gridOptions.api, $scope.gridOptions.rowData, data.args.seriesInstanceUID);
            //}.bind(this));

            $scope.all = { checked: false }; 
            $scope.doCheckAll = function (checkAll: boolean) {

                var list = this.getListController();
                list.Deselect();

                if (checkAll) {
                    var index = 1;
                    var length = list._list.rows.length;

                    for (index = 1; index < length; index += 2) {
                        if ((<any>list._list.rows[index]).data) {
                            list._list.rows[index].setAttribute("Selected", "1");
                        }
                    }

                }

                var nodes: Array<any> = list.getSelectedSeries();
                list._compareButton.disabled = (nodes.length < 2);

                list.RefreshList();
            };                                               
        }

        private ClearList(patientId) {
            var list: HTMLTableElement = this._list;

            if (!list)
                return;

            list.parentElement.id = patientId;

            var index = 0;
            var length = list.rows.length;

            for (index = 1; index < length; index++) {
                list.deleteRow(1);
            }
        }

        public refreshContent(objectRetrieveService, seriesManagerService, patientId) {
            var __this = this;


            objectRetrieveService.GetPatientStructuredDisplay(patientId).then(function (result) {


                __this.ClearList(seriesManagerService.currentLoadingSeries.Patient.ID);

                // remove structured display that doesn't contain in value in Boxes, which is where you supposed to load the image.
                var data: any = __this.filterBadStructuredDisplay(result.data);

                seriesManagerService.structuredDisplayList = data;

                __this._sturctureDisplayList = data;

                var searchResultID: JQuery = $("div.seriesList");
                var myTable: any = __this.getTableDiv(searchResultID, seriesManagerService.currentLoadingSeries.Patient.ID);

                __this._span = myTable.children[0];
                __this._list = myTable.children[1];

                __this._list.parentElement.id = patientId;

                __this.fillTable(seriesManagerService.currentPatientSeries, seriesManagerService.structuredDisplayList);

                __this.prepareButtons();

                __this.registerEvents();

                __this.selectSeries(seriesManagerService.currentLoadingSeries.InstanceUID);

            });

        }


        private getTableDiv(searchResultID : JQuery, id) {
            var index = 0;
            var length = searchResultID.length;

            for (index = 0; index < length; index++) {
                if (searchResultID[index].id == id)
                    return searchResultID[index];
            }
        }


        private filterBadStructuredDisplay(data : any)
        {
            var index = 0;
            var length = data.length;
            var output = [];
            var counter = 0;

            for (index = 0; index < length; index++) {
                if (data[index]) {
                    if (data[index].Boxes) {
                        if (data[index].Boxes.length > 0) {
                            output[counter] = data[index];
                            counter++;
                        }
                    }
                }

            }

            return output;
        }


        public prepareButtons() {
            var headers1: JQuery = $("div.seriesList");
            var headers: JQuery = $("span.ag-header-group-text");

            // this._span has 3 children, the first, is the label, the second is the export button, and the 3rd is the compare button.
            this._exportButton = this._span.children[1];
            this._compareButton = this._span.children[2];

            $(this._exportButton).click(this.onExport.bind(this));
            $(this._compareButton).click(this.onCompare.bind(this));

            this.canDoExport();
        }

        public fillTable(currentPatientSeries: Array<any>, structuredDisplayList : Array<any>): void {

            var index;
            var length;
            var counter = 1;

            if (structuredDisplayList != null) {
                index = 0;
                length = structuredDisplayList.length;

                for (index = 0; index < length; index++) {
                    this.AddRow(this._list, structuredDisplayList[index], 'images/SD.jpg', structuredDisplayList[index].Name, "Structured Display", counter, true, parseInt(this._options.get(OptionNames.SeriesThumbnailHeight)));


                    counter++;
                }
            }

            index = 0;
            length = currentPatientSeries.length;

            for (index = 0; index < length; index++) {
                this.AddRow(this._list, currentPatientSeries[index], Utils.get_thumbnailUrl(currentPatientSeries[index]), currentPatientSeries[index].Date, currentPatientSeries[index].Description, counter, true, parseInt(this._options.get(OptionNames.SeriesThumbnailHeight)));
                counter++;
            }


        }

        public tableCellClicked

        public UpdateSelection(row: HTMLTableRowElement, column: number) {
            if (this.selectRow(row, column)) {

                if (!this.IsRowSelected(row)) {
                    // this is when you click on the row to deselect it.
                    return;
                }
                    var tab: Models.Tab = this._tabService.get_allTabs()[this._tabService.activeTab];
                    var searchController: DentalSearchViewController = this._tabService.get_tabData(this._tabService.tabs[0].id, TabDataKeys.searchViewerController);

                    // check if the it's a structured display root, load the structured display with all the series.
                    var rowData = (<any>row).data;
                    if (rowData.Boxes) {

                        searchController.loadselectedStructureDisplay(rowData);

                        this._eventService.publish(EventNames.StructuredDisplaySelected, {
                            structureDisplay: (<any>row).data,
                        });
                    }
                    else {
                        // just a normal series.
                        var data: any = {};
                        data.node = {}
                        data.node.data = rowData;
                        searchController._templateService.currentStudyLayout = null;

                        this.seriesSelected(data);
                    }
                }
        }

        // if the user click on the row that has sub-tree, then recheck everything.
        public RecheckAllSubTree(row: HTMLTableRowElement)
        {
            // this is the next item on the list, which is the sub-tree.
            var tree: HTMLTableRowElement = <HTMLTableRowElement>row.nextElementSibling;
            if (tree.children.length == 0)
                return;

            if (tree.children[0].children.length == 0)
                return;

            var table: HTMLTableElement = <HTMLTableElement>tree.children[0].children[0];

            var index = 0;
            var length = table.rows.length;

            for (index = 0; index < length; index++) {
                table.rows[index].setAttribute("Selected", "1");
            }

            this.refreshSubtreeSelection(table);

            this.RefreshList();
        }

        public registerEvents() {
            var index;
            var _this = this;
            var rows = this._list.rows.length;
            var j;
            var columns = this._list.rows[0].children.length;
            var rowCounter = -1;

            for (index = 1; index < rows; index++) {

                if (!(<any>_this._list.rows[index]).data)
                    continue;

                 rowCounter++

                for (j = 0; j < columns; j++) {

                    this._list.rows[index].children[j].setAttribute("rowPosition", index.toString());
                    this._list.rows[index].children[j].setAttribute("colPosition", j)


                    this._list.rows[index].children[j].addEventListener("click", function(e) {

                        var td: HTMLTableCellElement = <HTMLTableCellElement>e.currentTarget;
                        var column = parseInt(td.getAttribute("colPosition"));

                        if (_this.IsRowSelected(<HTMLTableRowElement>td.parentElement) && !_this.IsMultipleSelection()) {

                            // if the user clicks on the tree parent again, then you will reselect everything on the sub-tree in case some are unselected, and you will remove the indetermine if it's not.
                            _this.RecheckAllSubTree(<HTMLTableRowElement>td.parentElement);

                            return;
                        }

                        _this.UpdateSelection(<HTMLTableRowElement>td.parentElement, column);

                        var nodes: Array<any> = _this.getSelectedSeries();
                        _this._compareButton.disabled = (nodes.length < 2);

                        _this.canDoExport();
                    });
                }
            }
        }

        private canDoExport() {
            this._exportButton.disabled = !(this._authenticationService.hasPermission(PermissionNames.CanStore));
        }

        public unregisterEvents() {
            var index;
            var rows = this._list.rows.length;
            var j;
            var columns = this._list.rows[0].children.length;
            ;
            for (index = 1; index < rows; index++) {

                for (j = 0; j < columns; j++) {

                    this._list.rows[index].children[j].removeAttribute("rowPosition");
                    this._list.rows[index].children[j].removeAttribute("colPosition")
                }
            }
        }


        private GetSubtreeTable(parent: HTMLTableRowElement): HTMLTableElement
        {
            return <HTMLTableElement>parent.cells[0].children[0];
        }


        public Deselect(includingSubTree?: boolean) {
            var index;
            var length = this._list.rows.length;
            var input: HTMLInputElement;
            var row: HTMLTableRowElement;

            // set all rows to false.
            for (index = 1; index < length; index++) {

                if ((<any>this._list.rows[index]).data) {
                    this._list.rows[index].setAttribute("Selected", "0");
                }
                else
                    if ((<any>this._list.rows[index])) {

                    // that is the sub-tree row.
                        if (includingSubTree) {
                            // get the sub tree
                            var table: HTMLTableElement = this.GetSubtreeTable(this._list.rows[index]);

                            var subIndex = 0;
                            var sublength = table.rows.length;

                            // loop through all the subtree items and set them to false.
                            for (subIndex = 0; subIndex < sublength; subIndex++) {
                                row = table.rows[subIndex];
                                row.setAttribute("Selected", "0");
                            }
                        }
                }
            }
        }


        public IsMultipleSelection() {
            var index;
            var length = this._list.rows.length;
            var input: HTMLInputElement;
            var row: HTMLTableRowElement;
            var selectionCounter = 0;

            // set all rows to false.
            for (index = 1; index < length; index++) {

                if ((<any>this._list.rows[index]).data) {
                    selectionCounter += parseInt(this._list.rows[index].getAttribute("Selected"));
                }
            }

            return (selectionCounter > 1);
        }


        private getDataFromSeries(parent, seriesID) {

            var series :any = ($.grep(this._seriesManagerService.currentPatientSeries, function (item) { return item.InstanceUID == seriesID }))[0];

            var row: HTMLTableRowElement = this.AddRow(parent, series, Utils.get_thumbnailUrl(series), series.Date, series.Description, 0, false, parseInt(this._options.get(OptionNames.SeriesThumbnailHeight)) * 6 >> 3);
            row.setAttribute("Selected", "1");
        }


        public refreshSubtreeSelection(table: HTMLTableElement) {
            var instanceUIDs = {};

            // this is the sub tree row that belong to a structured display.
            // go in and send the instances that are visible and the one that arent.
            var index = 0;
            var length = table.rows.length;

            // nothing to update, get out of here.
            if (length == 0)
                return;

            // create an array of instances that contains whether the series is visible or not.
            for (index = 0; index < length; index++) {
                instanceUIDs[(<any>table.rows[index]).data.InstanceUID] = (table.rows[index].getAttribute("Selected") == "1");
            }

            // send it.
            this._eventService.publish(EventNames.StructuredDisplayUpdated, {
                InstanceUIDs: instanceUIDs
            });


        }

        private findSeriesUsedInStructureDisplay(parent, data: any)
        {
            var index = 0;
            var length = data.Series.length;
            var list = {};

            for (index = 0; index < length; index++) {
                list[data.Series[index].SeriesInstanceUID] = data.Series[index].SeriesInstanceUID;
            }

            for (var item in list) {
                if (list.hasOwnProperty(item)) {

                    this.getDataFromSeries(parent, item);
                }
            }


            var _this = this;
            var index = 0;
            //var rows = this._seriesManagerService.currentPatientSeries.length;
            var columns = 4;
            var j = 0;
            var _table = parent;

            for (var item in list) {
                if (list.hasOwnProperty(item)) {

                    for (j = 0; j < columns; j++) {

                        parent.rows[index].children[j].setAttribute("colPosition", j)
                        parent.rows[index].children[j].addEventListener("click", function (e) {

                            var td: HTMLTableCellElement = <HTMLTableCellElement>e.currentTarget;
                            var row: HTMLTableRowElement = <HTMLTableRowElement>td.parentElement;
                            var parentRow = _table.parent;
                            var column = parseInt(td.getAttribute("colPosition"));



                            // make sure that the parent structured display is selected
                            _this.UpdateSelection(parentRow, 1);
                            _this.selectSubRow(row, column);


                            _this.refreshSubtreeSelection(<HTMLTableElement>row.parentElement);
                        });

                    }
                    index++;
                }
            }

            //for (this.AddRow()

        }

        //public selectSubRow(table: HTMLTableElement, index, column) {

        //    var input: HTMLInputElement = <HTMLInputElement>table.rows[index].children[0].children[0];

        //    // manually check the check box if the user clicked on the row
        //    if (column != 0)
        //        input.checked = true;

        //    table.rows[index].style.background = input.checked ? "rgba(128, 128, 128, 0.5)" : "rgba(128, 128, 128, 0)";
        //    table.rows[index].setAttribute("Selected", "1");
        //}

        // check whether the row is selected or not.
        private IsRowSelected(row: HTMLTableRowElement) {
            return row.getAttribute("Selected") == "1";
        }


        public DeselectSubRows(table: HTMLTableElement) {

            if (!table)
                return;

            if (!table.rows)
                return;

            var index = 0;
            var length = table.rows.length;

            for (index = 0; index < length; index++) {
                table.rows[index].setAttribute("Selected", "0");
            }

        }

        // check if all the sub-tree are selected or not, and if they are all not selected, then just mark the check box as indetermined.
        public UpdateParentCheckBox(table: HTMLTableElement)
        {
            var parentRow: HTMLTableRowElement = <HTMLTableRowElement>(<any>table).parentRow;
            if (parentRow) {
                var input = <HTMLInputElement>parentRow.cells[0].children[0];

                if (!input)
                    return;

                if (!this.isAllSelected(table)) {
                    input.indeterminate = true;
                }
                else {
                    input.indeterminate = false;
                    input.checked = true;
                }
            }
        }


        // check if all the rows in the tree is selected.
        public isAllSelected(table: HTMLTableElement)
        {
            if (!table)
                return false;

            if (!table.rows)
                return false;

            var index = 0;
            var length = table.rows.length;

            for (index = 0; index < length; index++) {
                if (table.rows[index].getAttribute("Selected") == "0")
                    return false;
            }

            return true;
        }

        public selectSubRow(row: HTMLTableRowElement, column: number): void {

            try {
                if (column == 0)
                    row.setAttribute("Selected", this.IsRowSelected(row) ? "0" : "1");
                else {
                    this.DeselectSubRows(<HTMLTableElement>row.parentElement);
                    row.setAttribute("Selected", "1");
                }

                this.RefreshList();

                // make the check box indetermined in case not all sub-tree is selected.
                this.UpdateParentCheckBox(<HTMLTableElement>row.parentElement);
            }
            catch (e) {
                console.log(e);
            }
        }



        public selectRow(row : HTMLTableRowElement, column): boolean{

            var input: HTMLInputElement = <HTMLInputElement>row.children[0].children[0];

            // unselect all the other rows only if the user doesn't click on the check box.
            if (column != 0) {
                this.Deselect();
            }

            var newSelection = this._selectedRow != row;

            // invert status if the user clicked on the check box.
            if (column == 0)
                row.setAttribute("Selected", this.IsRowSelected(row) ? "0" : "1");
            else {
                row.setAttribute("Selected", "1");
            }

            if (this.IsRowSelected(row))
            if (newSelection) {
                var selected: boolean = row.getAttribute("Selected") == "1";
                this._selectedRow = row;

                if (selected) {
                    // if it's a structured display then expand... otherwise, stay.
                    if ((<any>row).data.Boxes) {

                        // set this as the current structured display.
                        this._seriesManagerService.currentStructuredDisplay = (<any>row).data;

                        // this is the next item on the list, which is the sub-tree.
                        var tree: HTMLTableRowElement = <HTMLTableRowElement>row.nextElementSibling;
                        tree.style.height = "100px";

                        //if there are not children, then find them and create teh sub tree
                        if (tree.children[0].children[0].innerHTML == "") {
							// set the parent of the sub-tree.
                            (<any>tree.cells[0].children[0]).parentRow = row;
                            // find the series that contained in the structured display.
                            this.findSeriesUsedInStructureDisplay(tree.cells[0].children[0], (<any>row).data);
                        }

                    }
                    else
                        this._seriesManagerService.currentStructuredDisplay = null;

                }
            }

            // update the list by highlighting / de-highlighting / removing sub-tree.
            if (!this.RefreshList())
                this.selectRow(this._selectedRow ? this._selectedRow : this._list.rows[1], column);

            return newSelection;
        }

        // refresh the look of the row based on the "Selected" value, and return the selection status.
        private RefreshRow(row: HTMLTableRowElement): boolean {
            var input: HTMLInputElement;
            var selected: boolean = row.getAttribute("Selected") == "1";

            if (selected) {
                // set the row color to transparent.
                row.style.background = "rgba(128, 128, 128, 0.5)";

                // get the input box that represents the check box.
                input = <HTMLInputElement>row.children[0].children[0];
                input.checked = true;
            }
            else {
                // set the row color to transparent.
                row.style.background = "rgba(0, 0, 0, 0)";

                // get the input box that represents the check box.
                input = <HTMLInputElement>row.children[0].children[0];
                input.checked = false;
            }

            // in case the indetermine is checked, then uncheck it.
            input.indeterminate = false;

            return selected
        }

        // loop throw all children and find if there is a selected sub row there.
        private isSubTreeSelected(table : HTMLTableElement) : boolean {
            var index = 0;
            var length = table.rows.length;
            var row: HTMLTableRowElement;
            var found = false;

            // find if one of the rows is selected
            for (index = 0; index < length; index++) {

                // we wont break here, because we want to refresh all sub tree item first.
                if (this.RefreshRow(table.rows[index]))
                    found = true;
            }

            return found;

        }

        // update the look of the list, if any is selected, then highlight it and check the check box, if not, then clear the highlight, and if there is subtree then remove it.
        // it returns that at least one item is selected from the list.
        private RefreshList() : boolean{
            var index;
            var length = this._list.rows.length;
            var input: HTMLInputElement;
            var previousRowSelected = false;
            var somethingSelected = false;

            // get through each row.
            for (index = 1; index < length; index++) {

                // if the row is a simple series, then just refresh the row.
                if ((<any>this._list.rows[index]).data) {

                    previousRowSelected = this.RefreshRow(this._list.rows[index]);
                }
                else {
                    // this is the sub-tree row, go through all the children.
                    var table: HTMLTableElement = <HTMLTableElement>this._list.rows[index].cells[0].children[0];

                    // loop through the sub-tree item, refresh the look and return whether at least one is selected so you don't hide the tree.
                    var oneSelected = this.isSubTreeSelected(table)

                    // if the parent (which is the previous row is not selected), then go in and check all the treee items are not selected to remove it from the view.
                    if (!previousRowSelected) {
                        this._list.rows[index].style.height = "0px";
                        table.innerHTML = "";
                    }
                }

                // this is to ensure that the list has one item selected.
                if (previousRowSelected) {
                    somethingSelected = true;
                }
            }

            return somethingSelected;
        }

        public AddRow(parent : HTMLElement, data: any, imageUrl: string, date: string, description: string, rowIndex: number, root: boolean, height: number): HTMLTableRowElement {

            if (parent != null) {

                var tr: HTMLTableRowElement = <HTMLTableRowElement>document.createElement("TR");

                tr.setAttribute("Selected", "0");
                tr.style.height = height + "px";
                tr.id = "row" + rowIndex;
                if (!root)
                    tr.style.fontSize = "10px";

                parent.appendChild(tr);

                (<any>tr).data = data;

                // Add the radio button
                var cell: HTMLTableDataCellElement = <HTMLTableDataCellElement>document.createElement("TD");

                //if (rowIndex == 2) {
                //    cell.colSpan = 2;
                //    tr.style.height = "100px";

                //}
                //else {

                var input: HTMLInputElement = <HTMLInputElement>document.createElement("input");
                input.type = "checkbox"
                cell.appendChild(input);
                cell.style.width = "5%";
                tr.appendChild(cell);

                cell = <HTMLTableDataCellElement>document.createElement("TD");
                var image: HTMLImageElement = <HTMLImageElement>document.createElement("img");
                image.style.height = height + "px";
                image.style.width = height + "px";
                cell.appendChild(image);
                image.src = imageUrl;
                tr.appendChild(cell);

                cell = <HTMLTableDataCellElement>document.createElement("TD");
                var dateNode: Text = document.createTextNode(date ? date : "N/A");
                cell.style.width = "20%";
                cell.style.textAlign = "center";
                cell.style.cursor = "default";
                cell.appendChild(dateNode);
                tr.appendChild(cell);

                cell = <HTMLTableDataCellElement>document.createElement("TD");
                var descriptionNode = document.createTextNode(description ? description : "N/A");
                cell.style.width = "100%";
                cell.style.textAlign = "center";
                cell.style.cursor = "default";
                cell.appendChild(descriptionNode);
                tr.appendChild(cell);

                //}

                if (root) {
                    var trChildSpace: HTMLTableRowElement = <HTMLTableRowElement>document.createElement("TR");
                    trChildSpace.style.height = "0px";
                    trChildSpace.style.columnSpan = "3";


                    cell = <HTMLTableDataCellElement>document.createElement("TD");
                    cell.colSpan = 4;
                    trChildSpace.appendChild(cell);

                    var treeTable: HTMLTableElement = <HTMLTableElement>document.createElement("TABLE");
                    treeTable.style.left = "10%";
                    treeTable.border = "1px";
                    treeTable.style.position = "relative";
                    treeTable.cellPadding = "4px";
                    treeTable.id = "subTree" + rowIndex;
                    (<any>treeTable).parent = tr;



                    parent.appendChild(trChildSpace);
                    cell.appendChild(treeTable);
                }


                return tr;
            }

            return null;

        }

        public updateTemplatesHaveAutoMatch(): void {

            if (this._templates) {
                for (var i = 0; i < this._templates.length; i++) {
                    var template = this._templates[i];

                    if (template.AutoMatching) {
                        this._templatesHasAutoMatch = true;
                        return;
                    }
                }
            }

            this._templatesHasAutoMatch = false;
        }

        public isAnyTemplateAutoMatch(): boolean {
            return this._templatesHasAutoMatch;
        }

        public getAutoMatchTemplates(): Models.Template[] {
            return Utils.findAll(this._templates, function (template: Models.Template) {
                return template.AutoMatching;
            });
        }

        private checkBoxRenderer(): string {
            return '<input type="checkbox" ng-model="all.checked" ng-change="doCheckAll(all.checked)" >';
        }

        public loadSeriesList(patientId: string, seriesInstanceUID: string, fromList: boolean) {
            this.selectSeries(seriesInstanceUID,fromList);
        }

        public selectSeries(seriesInstanceUID?: string, fromList?: boolean) {

            this._currentSelectedSeries = seriesInstanceUID;

            if (!this._currentSelectedSeries || this._currentSelectedSeries == "")
                this._currentSelectedSeries = this._seriesManagerService.get_allSeries()[0];


            if (!this._list)
                return;

            var index = 0;
            var length = this._list.rows.length;
            var row;

            for (index = 0; index < length; index++) {

                row = (<any>this._list.rows[index]);
                if (!row.data)
                    continue;
                
                // this is  a structured display
                if (row.data.Boxes) {

                    if (this._seriesManagerService.currentStructuredDisplay) {
                        if (this._seriesManagerService.currentStructuredDisplay.Name == (<any>this._list.rows[index]).data.Name) {
                            // if the row is already selected, then just get out, nothing to do here.
                            if (this.IsRowSelected(row))
                                return;

                            this.selectRow(row, 1);
                            return;
                        }
                    }
                }
                else {
                    if (row.data)
                    {
                        var data = row.data;

                        if (data.InstanceUID == this._currentSelectedSeries) {

                            // if the row is already selected, then just get out, nothing to do here.
                            if (this.IsRowSelected(row))
                                return;

                            this.selectRow(row, 1);
                            return;
                        }
                    }

                }

            }

            //var instanceUID: string = seriesInstanceUID || this._scope.activeSeriesInstanceUID;

            //if (instanceUID == undefined)
            //    return;

            //fromList = fromList || false;
            //if (angular.isArray(this._seriesManagerService.currentPatientSeries)) {
            //    var data: Array<any> = this._seriesManagerService.currentPatientSeries;
            //    var index = data.map(function (item, index: number) { 
            //        return item.InstanceUID;
            //    }).indexOf(instanceUID);

            //    if (index != -1) {
            //        index += (this._sturctureDisplayList ? this._sturctureDisplayList.length : 0);
            //        this.selectRow(index * 2 + 1, 1);
            //    }
            //    else {
            //        if (angular.isArray(this._seriesManagerService.structuredDisplayList)) {
            //            var data: Array<any> = this._seriesManagerService.structuredDisplayList;
            //            var index = data.map(function (item, index: number) {
            //                return item.InstanceUID;
            //            }).indexOf(instanceUID);

            //            if (index != -1) {
            //                this.selectRow(index * 2 + 1, 1);
            //            }
            //        }
            //    }
            
                //if (index != -1) {
                //    this._scope.gridOptions.api.selectIndex(index, fromList ? true : false, true);                   
                //}
            //}
        }

        private matchTemplateForSeries(data, study: any, series: any) {
            var StudyInstanceUID = data.node.data.StudyInstanceUID;
            var SeriesInstanceUID = data.node.data.InstanceUID;

            if (StudyInstanceUID && SeriesInstanceUID) {

                //read first instance's json
                var promise = this._objectRetrieveService.GetDicomJSON(StudyInstanceUID, SeriesInstanceUID, '');

                //on success
                promise.success(function (json) {

                    var _template = null;

                    this.getAutoMatchTemplates().some((template: Models.Template) => {

                        //parse the json and see if we have a match
                        try {
                            if (!_template) {
                                if (Utils.executeScript(template.AutoMatching, json)) {
                                    console.log('template auto-match found');
                                    _template = template;
                                    return true;//break;
                                }
                            }
                        }
                        catch (e) {
                            console.log(e);
                        }
                        return false;//continue
                    });

                    //use template (if any) to view
                    this._eventService.publish(EventNames.SeriesSelected, {
                        study: study,
                        series: series,
                        fromList: true,
                        template: _template
                    });

                }.bind(this));

                //on error - default to no template - continue loading
                promise.error(function (e) {
                    console.log(e);

                    this._eventService.publish(EventNames.SeriesSelected, {
                        study: study,
                        series: series,
                        fromList: true,
                        template: undefined
                    });                    
                });

            }
            else {
                console.log('failed to read study/series id');

                //default to no template - continue loading
                this._eventService.publish(EventNames.SeriesSelected, {
                    study: study,
                    series: series,
                    fromList: true,
                    template: undefined
                });
            }
        }

        private seriesSelected(data) {
            var cell = this._seriesManagerService.get_activeCell();
            var seriesInstanceUID = cell == null ? "" : cell.get_seriesInstanceUID();
            
            if (cell && (<any>cell).templateId) {                
                if (seriesInstanceUID.length > 0) {
                    var template: Models.Template = Utils.findFirst(this._templates, function (template: Models.Template) {
                        return template.Id == (<any>cell).templateId;
                    });

                    if (template) {
                        this._seriesTemplate[seriesInstanceUID] = template;
                    }
                    else {
                        delete this._seriesTemplate[seriesInstanceUID];
                    }
                }
            }

            /*if (seriesInstanceUID != data.node.data.InstanceUID) */{
                var newSeries = data.node.data;

                if (newSeries) {
                    var study = { InstanceUID: newSeries.StudyInstanceUID, Patient: newSeries.Patient };
                    var __this = this;
                    var template: Models.Template = undefined;

                    this._scope.activeSeriesInstanceUID = data.node.data.InstanceUID;

                    //if(this._scope.all.checked)
                    //    this._scope.all.checked = false;  
                    
                    if (this._seriesTemplate[newSeries.InstanceUID]) {
                        template = this._seriesTemplate[newSeries.InstanceUID];
                    }        

                    if (!template && cell && this.isAnyTemplateAutoMatch()) {
                        this.matchTemplateForSeries(data, study, newSeries);
                    }
                    else {
                        this._eventService.publish(EventNames.SeriesSelected, {
                            study: study,
                            series: newSeries,
                            fromList: true,
                            template: template,
                            resetLayout: true
                        });
                    }
                }
            }
        }        
        
        private onExport() {
            this._$commangular.dispatch('OnSecondaryCapture');
        }


        // get a list of the data of the selected rows
        private getSelectedSeries() {

            var index;
            var length = this._list.rows.length;
            var row: HTMLTableRowElement;
            var selected = [];

            for (index = 1; index < length; index++) {

                // add this row if it's selected.
                if (this._list.rows[index].getAttribute("Selected") == "1")

                    // make sure we have the series data avaiable
                    if ((<any>this._list.rows[index]).data) {

                        // not compare for structured display
                        if (!(<any>this._list.rows[index]).data.Boxes)
                            selected.push((<any>this._list.rows[index]).data);
                    } 
            }

            return selected;
        }

        
        private onCompare() {             
            var nodes: Array<any> = this.getSelectedSeries();

            if (nodes.length < 2) {
                alert("structure display comparison is not avaiable yet");
            }
            else
                this._$commangular.dispatch('Compare', { series: nodes });
        }        
    }
} 