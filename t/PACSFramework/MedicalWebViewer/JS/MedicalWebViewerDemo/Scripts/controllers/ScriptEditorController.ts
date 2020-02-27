// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IScriptEditorControllerScope extends ng.IScope {
        data: any;
        label: string;
        editorOptions: any;
        readOnly: boolean;
        cancel();
        ok();
        codemirrorLoaded(editor: CodeMirror.Editor);
        gridOptions: any;
        hasErrors(): boolean;
    }

    class LineError {
        public line: number;
        public column: number;
        public message: string;

        constructor(line: number, column:number, message: string) {
            this.line = line;
            this.column = column;
            this.message = message;
        }
    }

    export class ScriptEditorController {
        static $inject = ['$scope', '$modalInstance', 'label', 'text', 'readOnly'];

        private _editor: CodeMirror.Editor;
        private _interval: number = undefined;  
        private _errorLines: Array<LineError> = new Array<LineError>();
        private _gridApi: ag.grid.GridApi; 
        private _firstChange: boolean = true;

        constructor($scope: IScriptEditorControllerScope, $modalInstance, label:string, text:string, readOnly: boolean) {  
            var self = this;

            $scope.label = label;
            $scope.data = {}
            $scope.data.text = text;
            $scope.readOnly = readOnly;

            $scope.editorOptions = {
                lineWrapping: false,                
                mode: 'javascript',
                autofocus: true,
                lineNumbers: true, 
                extraKeys: { "Ctrl-Q": function (cm) { cm.foldCode(cm.getCursor()); } },
                foldGutter: {
                    rangeFinder: new (<any>CodeMirror).fold.combine((<any>CodeMirror).fold.brace, (<any>CodeMirror).fold.comment)
                },
                gutters: ["CodeMirror-linenumbers", "CodeMirror-foldgutter"],
                readOnly: readOnly                       
            };

            $scope.gridOptions = {
                rowSelection: 'single',
                suppressNoRowsOverlay: true,
                groupHeaders: true,
                columnDefs: [
                    {
                        headerName: "Errors",
                        children: [
                            {
                                headerName: "",
                                cellRenderer: Utils.countRenderer,
                                width: 29,
                                suppressSizeToFit: true,
                            },
                            {
                                headerName: "Line",
                                field: "line"
                            },
                            {
                                headerName: "Column",
                                field: "column",
                            },
                            {
                                headerName: "Description",
                                field: "message"
                            },                            
                        ]
                    }
                ],
                onRowSelected: function (data) {
                    this.jumpToLine(data.node.data.line-1, data.node.data.column-1);
                }.bind(this),
                rowData: null,
                onGridReady: function () {
                    self._gridApi = $scope.gridOptions.api;

                    self._gridApi.hideOverlay();
                    self._gridApi.sizeColumnsToFit();
                }                
            }
                     
            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }

            $scope.ok = function () {
                $modalInstance.close($scope.data.text);
            } 

            $scope.hasErrors = function () {
                if (angular.isArray($scope.gridOptions.rowData)) {
                    return $scope.gridOptions.rowData.length > 0;
                }

                return $scope.gridOptions.rowData != null;
            };

            $scope.codemirrorLoaded = this.codeMirrorLoaded.bind(this);                          
        }

        private codeMirrorLoaded(editor: CodeMirror.Editor) {            
            this._editor = editor;

            this._editor.refresh();
            this._editor.focus();
            this._editor.getDoc().setCursor({ line: this._editor.getDoc().lineCount(), ch: 0 });
            this._editor.on('change', this.onChange.bind(this));
        }       

        private onChange(instance: CodeMirror.Editor, changeObj: any) {
            if (this._firstChange) {
                this._firstChange = false;
                instance.getDoc().markClean();
                instance.getDoc().clearHistory();
            }

            if (this._interval)
                clearTimeout(this._interval);

            this._interval = setTimeout(this.update.bind(this), 500);
        }

        private update() {
            var text: string = this._editor.getDoc().getValue();            

            while (this._errorLines.length > 0) {
                this._editor.removeLineClass(this._errorLines.shift().line-1, 'background', 'errorLine')
            }            

            this._gridApi.setRowData(null);

            try {
                var result:any = esprima.parse(text, { tolerant: true, loc: true });

                for (var i = 0; i < result.length; i++) {
                    var error = result[i]
                    var lineNumber = error.lineNumber
                   
                    this._errorLines.push(new LineError(lineNumber, result.column, error.message));
                    this._editor.addLineClass(lineNumber-1, 'background', 'errorLine')
                }

            } catch (error) {
                var lineNumber = error.lineNumber;
                
                this._errorLines.push(new LineError(lineNumber, error.column, error.message));
                this._editor.addLineClass(lineNumber-1, 'background', 'errorLine')
            }

            this._gridApi.setRowData(this._errorLines);
        }
        
        private jumpToLine(line: number, column:number) {
            var t = this._editor.charCoords({ line: line, ch: column}, "local").top;
            var middleHeight = this._editor.getScrollerElement().offsetHeight / 2;

            this._editor.scrollTo(null, t - middleHeight - 5);
            this._editor.getDoc().setCursor({ line: line, ch: column });
            this._editor.focus();
        }              
    }
} 