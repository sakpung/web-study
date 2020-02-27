// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface ITagChooserControllerScope extends ng.IScope {
        gridOptions: any;
                
        ok();                    
        cancel();
    }    

    export class TagChooserController {
        static $inject = ['$scope', '$modalInstance', 'optionsService', '$translate', 'dicom', 'selector', 'currentTags'];

        private _dateFormat: string;
        private _timeFormat: string;
        private _$scope: ITagChooserControllerScope;
        private _unknownString: string = "Unknown";
        private _selector: Models.ImageSetSelector;       

        constructor($scope: ITagChooserControllerScope, $modalInstance, optionsService: OptionsService, $translate, dicom, selector: Models.ImageSetSelector, currentTags:Array<string>) {
            var model = [];
            var self = this;

            this._dateFormat = optionsService.get(OptionNames.DateFormat);
            this._timeFormat = optionsService.get(OptionNames.TimeFormat);
            this._$scope = $scope;
            this._selector = selector;     
            
            // Remove this line if want the Tag Chooser Editor to display tags that have already been selected
            currentTags = [];    

            $scope.gridOptions = {
                columnDefs: [
                    {
                        headerName: "Tag",
                        field: "tag",
                        width: 150,                                              
                        cellRenderer: {
                            renderer: 'group',
                            innerRenderer: this.innerCellRenderer.bind(this),
                            checkbox: true                          
                        }
                    },
                    {
                        headerName: "Name",
                        field: "name",
                        width: 250
                    },
                    {
                        headerName: "Value",
                        field: "value",
                        width: 250                        
                    }
                ],
                rowData: this.buildData(dicom, new Array<Models.DicomTagRow>(), currentTags),
                rowSelection: !selector?'multiple':'single',
                rowsAlreadyGrouped: true,
                suppressRowClickSelection: true,
                enableColResize: true,
                //enableSorting: true,  
                groupSelectsChildren: false,              
                icons: {
                    groupExpanded: '<i class="fa fa-minus-square-o"/>',
                    groupContracted: '<i class="fa fa-plus-square-o"/>'
                },
                onGridReady: function () {
                    $scope.gridOptions.api.hideOverlay();
                    if (selector && selector.WCFSelectorAttribute && selector.WCFSelectorAttribute.length > 0) {
                        setTimeout(function () {
                            self.selectCurrentTag();
                        }, 500);
                    }
                },
                onSelectionChanged: this.selectionChanged.bind(this),
                onRowSelected: this.rowSelected.bind(this)
            }                      
            
            $scope.ok = function () {
                var nodes: Array<any> = $scope.gridOptions.api.getSelectedNodes();                

                if (selector) {                    
                    var newNode = self.sequenceCheck(nodes[0]);
                    $modalInstance.close(newNode.data);
                }
                else {
                    var data: Array<Models.DicomData> = new Array<Models.DicomData>();

                    for (var i = 0; i < nodes.length; i++) {
                        var newNode = self.sequenceCheck(nodes[i]);
                        // data.push(newNode.data);
                        var clonedData = Utils.myclone(newNode.data, ['children']);
                        data.push(clonedData);
                    }
                    $modalInstance.close(data);
                }                
            } 

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }                                        
        } 

        private containsCodeValue(itemNode): boolean {
            if (itemNode == null)
                return false;

            for (var i = 0; i < itemNode.children.length; i++) {
                var tag1 = itemNode.children[i].data.tag;
                tag1 = tag1.replace(":", "");
                if (tag1 == DicomTag.CodeValue)
                    return true;
            }
            return false;
        }

        private isCodeSequence(node, itemNumber: string) {
            var d: Models.DicomData = node.data;
            var result = false;

            if (d.name.indexOf("Code Sequence") != -1)
                return true;

            if (d.vr != "SQ")
                return false;

            if (node.children.length == 0)
                return false;

            if (this.containsCodeValue(node.children[0]))
                return true;

            // If the 0th item has no children, try the selected item: item[itemNumber-1]
            var index: number = parseInt(itemNumber);
            if (isNaN(index))
                return false;

            // index should be 0-based
            index = index - 1;

            // If index is 0, we already checked this
            if (index == 0)
                return false;

            if (node.children.length <= index) 
                return false;

            if (this.containsCodeValue(node.children[index]))
                return true;

            return false;
        }

        private getSelectorSequencePointer(node) : string {
            var s: string = "";
            while (node != null) {
                var d: Models.DicomData = node.data;
                if (d != null && d.tag != DicomTag.Item) {
                    if (s.length == 0) {
                        s = d.tag;
                    }
                    else {
                        s = d.tag + "\\" + s;
                    }
                }
                node = node.parent;
            }
            return s;
        }

        private getSelectorSequencePointerItems(node): string {
            var s: string = "";
            while (node != null) {
                var d: Models.DicomData = node.data;
                if (d != null && d.tag == DicomTag.Item) {
                    var itemNumber: string = d.name.replace("Item ", "");   // "Item 3" --> "3"
                    if (s.length == 0) {
                        s = itemNumber;
                    }
                    else {
                        s = itemNumber + "\\" + s;
                    }
                }
                node = node.parent;
            }
            return s;
        }

        private findNodeSequenceTag(node) {
            if (node == null)
                return null;

            while (node.data.vr != "SQ" && node.parent != null) {
                node = node.parent;
            }
            return node;
        }

        private findNodeItemTag(node) {
            if (node == null)
                return null;

            if (node.data.vr == "SQ") {
                // User selected a sequenceTag so use the first child item
                if (node.children != null && node.children.length > 0) {
                    node = node.children[0];
                }
                else {
                    node = null;
                }
                return node;
            }

            while (node.data.tag != DicomTag.Item && node.parent != null) {
                node = node.parent;
            }
            return node;
        }


        private sequenceCheck(nodeSelected) {
            var dataSelected: Models.DicomData = nodeSelected.data;

            var nodeSequence = null;
            var nodeItem = null;
            var itemNumber = null;
            var nodeReturn = nodeSelected;

            //if (dataSelected.tag == DicomTag.Item) {
            //    // User selected a sequence item, so the parent tag is the sequence tag
            //    nodeSequence = nodeSelected.parent;
            //    nodeItem = nodeSelected;
            //    itemNumber = nodeItem.data.name.replace("Item ", "");
            //}
            //else if (dataSelected.vr == "SQ") {
            //    // User selected a sequenceTag so use the first item
            //    nodeSequence = nodeSelected;
            //    nodeItem = nodeSelected.children[0];
            //}
            //else if (nodeSelected.parent != null) {
            //    // User selected a tag that is not an item or a sequence.
            //    // If the tag has a parent then it is part of an item
            //    nodeSequence = this.findNodeSequenceTag(nodeSelected);
            //    nodeItem = this.findNodeItemTag(nodeSelected);
            //}
            //else {
            //    // User selected a tag that is not part of a sequence or sequence item
            //}

            nodeSequence = this.findNodeSequenceTag(nodeSelected);
            nodeItem = this.findNodeItemTag(nodeSelected);
            if (nodeItem != null) {
                itemNumber = nodeItem.data.name.replace("Item ", "");
            }

            // Check nodeSelected is SQ or Item
            var isCodeSequence: boolean = false; 
            if (nodeSelected.data.vr == "SQ" || nodeSelected.data.tag == DicomTag.Item) {
                isCodeSequence = this.isCodeSequence(nodeSequence, itemNumber);
                nodeReturn = nodeSequence;
            }

            var nodeReturnData: Models.DicomData = nodeReturn.data;


            if (isCodeSequence) {
                nodeReturnData["isCodeSequence"] = true;
                nodeReturnData["children"] = nodeSelected.children;
            }            
            else {
                delete nodeReturnData["isCodeSequence"];
                delete nodeReturnData["children"];
            }
            
            nodeReturnData['itemNumber'] = (itemNumber == null ? null : parseInt(itemNumber));

            if (nodeSequence != null) {
                // d['selectorSequencePointer'] = parent.data.tag;
                nodeReturnData['selectorSequencePointer'] = this.getSelectorSequencePointer(nodeItem);
                nodeReturnData['sequencePointerName'] = nodeSequence.data.name;
                nodeReturnData['selectorSequencePointerItems'] = this.getSelectorSequencePointerItems(nodeItem);
            }

            return nodeReturn;
        }

        private selectCurrentTag() {
            var self = this;

            this._$scope.gridOptions.api.forEachNode(function (node, index) {
                var nodeData: Models.DicomData = node.data;

                if (nodeData.tag == self._selector.WCFSelectorAttribute  && !node.parent) {
                    self._$scope.gridOptions.api.selectNode(node);
                    self._$scope.gridOptions.api.ensureIndexVisible(index);
                }
            });            
        }

        private innerCellRenderer(params): string {           
            if (params.data.vr == 'SQ') {
                return '&nbsp;<span><i class="fa fa-tags" style="color: blue"></i>&nbsp;' + params.data.tag + '</span>';
            }
            
            return '&nbsp;<span><i class="fa fa-tag" style="color: blue"></i>&nbsp;' + params.data.tag + '</span>';
        }      
        
        private isValidSelectorVR(key: string, vr: string): boolean {
            if (key == DicomTag.Item)
                return true;

            var valid: boolean = (
                vr == "AT" ||
                vr == "CS" ||
                vr == "IS" ||
                vr == "LO" ||
                vr == "LT" ||
                vr == "PN" ||
                vr == "SH" ||
                vr == "ST" ||
                vr == "UT" ||
                vr == "DS" ||
                vr == "FD" ||
                vr == "FL" ||
                vr == "UL" ||
                vr == "US" ||
                vr == "SL" ||
                vr == "SS" ||
                vr == "UI" ||
                vr == "SQ"
            );
            return valid;
        }

        private buildData(dicom, data: Array<Models.DicomTagRow>, currentTags:Array<string>): Array<Models.DicomTagRow> {            
            for (var key in dicom) {
                var tag: string = key.substr(0, 4) + ":" + key.substr(4);
                var dcmData = new Models.DicomData(Utils.splitCamelCaseToString(dicom[key].keyword), tag);
                var row = new Models.DicomTagRow(dcmData); 

                if (!this.isValidSelectorVR(key, dicom[key].vr)) {
                    continue;
                }
                
                if (!dcmData.name) {
                    dcmData.name = this._unknownString;
                }                

                dcmData.vr = dicom[key].vr;
                if (dicom[key].vr == 'PN') {
                    dcmData.value = DicomHelper.getPatientNameFromTag(dicom[key]);
                }
                else if (dicom[key].vr != 'SQ') {
                    var value: string = DicomHelper.getConvertValue(dicom[key]);

                    if (dicom[key].vr == 'DA') {
                        if (value) {
                            var DateJS: IDateJS = <any>(new Date(DicomHelper.parseDicomDate(value)));

                            value = DateJS.toString(this._dateFormat);
                        }
                    }

                    if (dicom[key].vr == 'TM') {
                        if (value) {
                            var DateJS: IDateJS = (<any>Date).today().at(DicomHelper.parseDicomTime(value));

                            value = DateJS.toString(this._timeFormat);
                        }
                    }                    

                    dcmData.value = value;
                }
                else {
                    if (dicom[key].Value && dicom[key].Value.length > 0) {
                        var length: number = dicom[key].Value.length;

                        row.group = true;
                        row.expanded = false;
                        for (var index=0; index < length; index++) {
                            var dcmData = new Models.DicomData("Item " + (index + 1).toString(), "FFFEE000");
                            var itemRow = new Models.DicomTagRow(dcmData); 

                            itemRow.group = true;
                            itemRow.expanded = false;
                            row.children.push(itemRow);
                            this.buildData(dicom[key].Value[index], itemRow.children, currentTags);
                        }
                    }                                        
                }               

                if ((currentTags && currentTags.length ==0) || (currentTags && currentTags.length > 0 && currentTags.indexOf(tag)==-1))
                    data.push(row);
            }

            return data;
        }

        private getDateTime(): string {
            var DateJS: IDateJS = <any>(new Date());
            var formattedString: string;

            formattedString = DateJS.toString(this._dateFormat + " " + this._timeFormat);
            return formattedString;
        }  

        private rowSelected(event) {
            //var nodes: Array<any> = this._$scope.gridOptions.api.getSelectedNodes();

            //for (var i = 0; i < nodes.length; i++) {
            //    var node = nodes[i];
            //}
        }

        private selectionChanged() {
            //var nodes: Array<any> = this._$scope.gridOptions.api.getSelectedNodes();

            //for (var i = 0; i < nodes.length; i++) {
            //    var node = nodes[i];
            //}
        }
    }
}