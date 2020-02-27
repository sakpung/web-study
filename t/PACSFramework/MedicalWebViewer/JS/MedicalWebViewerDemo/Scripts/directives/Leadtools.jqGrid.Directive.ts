// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

directives.directive('ltGrid', ['$rootScope', '$timeout', function ($rootScope, $timeout:ng.ITimeoutService) {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            config: '=',
            data: '=?',
            insert: '=?',
            api: '=',
            vapi: '=',
            topToolbarButtons: '=',
            activeKey: '=',
            activeKeyName: '=', 
            onSelectRow: '&'                                       
        },
        link: function (scope, element, attrs) {
            var table;
            var div;
            var totalRows = 0;
            var currentRow = -1;
            var scrollToTop = false;

            scope.$watch('config', function (value) {
                var selectRow = value.onSelectRow;
                var loadComplete = value.loadComplete;
                var autoHeight = value.autoSetHeight || false;
                var autoSizeToWindow = value.autoSizeToWindow || false;                 
                var previousId = null;
                var nextId = null;   

                scrollToTop = value.scrollToTop || false;             
                element.children().empty();
                table = angular.element('<table id="' + attrs.gridId + '"></table>');
                element.append(table);
                if (attrs.pagerId) {
                    value.pager = '#' + attrs.pagerId;
                    var pager = angular.element(value.pager);
                    if (pager.length == 0) {
                        div = angular.element('<div id="' + attrs.pagerId + '"></div>');
                        element.append(div);
                    }
                }                               

                value.onSelectRow = function (rowid) {
                    var data = table.jqGrid("getRowData", rowid);

                    currentRow = parseInt(rowid);
                    scope.onSelectRow({ rowid: rowid, data: data });
                    if (selectRow) {
                        selectRow(rowid);
                    }
                }

                value.loadComplete = function (data) {
                    if (value.contextMenu) {
                        $("tr.jqgrow", this).contextMenu(value.contextMenu.id, value.contextMenu.config);
                    }

                    if (loadComplete)
                        loadComplete();
                    if (previousId != null) {
                        totalRows = data.records;
                        $("#" + previousId).attr('disabled', 'disabled');
                    }

                    if (nextId) {
                        var data = table.jqGrid('getDataIDs');

                        if (data.length < totalRows) {
                            $("#" + nextId).attr('disabled', 'disabled');
                        }
                        else
                            $("#" + nextId).removeAttr('disabled');
                    }
                    currentRow == null;
                    updateButtons();
                }

                table.jqGrid(value);
                var htable = jQuery("table.ui-jqgrid-htable", jQuery("#gview_list"));

                scope.vapi = scope.vapi || {};
                // Variadic API – usage:
                //   view:  <ng-jqgrid … vapi="apicall">
                //   ctrl:  $scope.apicall('method', 'arg1', …);
                scope.vapi.call = function () {
                    var args = Array.prototype.slice.call(arguments, 0);
                    return table.jqGrid.apply(table, args);
                }; 

                 // allow to insert(), clear(), refresh() the grid from 
                // outside (e.g. from a controller). Usage:
                //   view:  <ng-jqgrid … api="gridapi">
                //   ctrl:  $scope.gridapi.clear();
                
                scope.api = scope.api || {};

                scope.api.collapseAll = function () {
                    var rowIds = table.getDataIDs();

                    $.each(rowIds, function (index, rowId) {
                        table.collapseSubGridRow(rowId);
                    });
                };

                scope.api.collapseRow = function (rowid) {
                    table.collapseSubGridRow(rowid);
                };

                scope.api.insert = function (rows) {
                    if (rows) {
                        for (var i = 0; i < rows.length; i++) {
                            scope.data.push(rows[i]);
                        }
                        table.jqGrid('setGridParam', { data: scope.data })
                            .trigger('reloadGrid');
                    }
                }; 

                scope.api.clear = function () {
                    scope.data.length = 0;
                    table.jqGrid('clearGridData', { data: scope.data })
                        .trigger('reloadGrid');
                }; 

                scope.api.refresh = function () {
                    table
                        .jqGrid('clearGridData')
                        .jqGrid('setGridParam', { data: scope.data })
                        .trigger('reloadGrid');
                }; 

                scope.api.get_selectedRowId = function () {
                    return table.jqGrid('getGridParam', 'selrow');
                };  

                scope.api.select_Row = function (rowid) {
                    table.jqGrid('setSelection', rowid); 
                };   

                scope.api.toggleSubGridRow = function (rowid) {
                    table.jqGrid("toggleSubGridRow", rowid);
                }; 

                scope.api.get_RowData = function (rowid) {
                    return table.jqGrid("getRowData", rowid); 
                }                 

                scope.api.deleteRow = function (rowId: number) {
                    table.jqGrid("delRowData", rowId);
                }

                scope.api.hideColumn = function (column: string) {
                    table.hideCol(column);
                }

                scope.api.get_SelectedRows = function () {
                    return table.jqGrid("getGridParam", "selarrrow");
                }               

                if (scope.topToolbarButtons) {
                    var tableId = $(table).attr('id');
                    var length = scope.topToolbarButtons.length;

                    for (var i = 0; i < length; i++) {
                        var item = scope.topToolbarButtons[i];

                        if (angular.isDefined(item.previousButton) && item.previousButton) {
                            item.onClickButton = previousItem;
                            item.enabled = false;
                            previousId = item.id;
                        }

                        if (angular.isDefined(item.nextButton) && item.nextButton) {
                            item.onClickButton = nextItem;
                            item.enabled = false;
                            nextId = item.id;
                        }

                        if (item.isLabel) {
                            $("#" + tableId).toolbarLabelAdd("#t_" + tableId, item);
                        }
                        else {
                            $("#" + tableId).toolbarButtonAdd("#t_" + tableId, item);
                        }
                    }

                    $("#t_" + tableId).css('height', '40px');
                }

                if (autoHeight || autoSizeToWindow) {
                    $rootScope.$watch('windowDimensions', function (value) {
                        if (angular.isDefined(value)) {
                            if(autoSizeToWindow)
                                $timeout(autoSetHeightToWindow, 500);
                            else
                                $timeout(autoSetHeight, 250);
                        }
                    }, true);
                }

                if (autoHeight && !autoSizeToWindow) {
                    scope.$watch(function () {
                        return $(table).is(":visible");
                    }, function (value) {
                            if (value) {
                                autoSetHeight();
                            }
                        });
                }

                function autoSetHeight() {
                    if (autoHeight) {
                        var headerHeight = $("#gbox_" + attrs.gridId).height() - $("#gbox_" + attrs.gridId + " .ui-jqgrid-bdiv").height();
                        var position = $(element).position();
                        var parentWidth = $(element).parent().width();

                        table.jqGrid('setGridWidth', parentWidth - 2);
                        table.jqGrid('setGridHeight', $(window).height() - (position.top + headerHeight));
                    }
                } 

                function getdims() {
                    var winW = 630, winH = 460;

                    if (document.body && document.body.offsetWidth) {
                        winW = document.body.offsetWidth;
                        winH = document.body.offsetHeight;
                    }
                    if (document.compatMode == 'CSS1Compat' &&
                        document.documentElement &&
                        document.documentElement.offsetWidth) {
                        winW = document.documentElement.offsetWidth;
                        winH = document.documentElement.offsetHeight;
                    }
                    if (window.innerWidth && window.innerHeight) {
                        winW = window.innerWidth;
                        winH = window.innerHeight;
                    }

                    return { width: winW, height: winH };
                }

                function autoSetHeightToWindow() {
                    if (autoSizeToWindow) {
                        var dim = getdims();                        
                        var position = $(element).position(); 
                        var height = $("#gbox_" + attrs.gridId).height() - $("#gbox_" + attrs.gridId + " .ui-jqgrid-bdiv").height(); 

                        height = dim.height - (position.top + height);                                                                    
                        table.jqGrid('setGridWidth', dim.width - 2);                                              
                        if (height < 0 || (lt.LTHelper.device == lt.LTDevice.mobile && lt.LTHelper.OS == lt.LTOS.iOS)) {
                            table.jqGrid('setGridHeight', 'auto');
                        }
                        else {
                            table.jqGrid('setGridHeight', height);
                        }  
                    }
                } 

                function previousItem() {
                    currentRow = scope.api.get_selectedRowId();

                    currentRow--;
                    updateButtons();
                    table.setSelection(currentRow, false);
                }

                function nextItem() {
                    currentRow = scope.api.get_selectedRowId();

                    if (currentRow == null)
                        currentRow = 1;
                    else
                        currentRow++;

                    updateButtons();
                    table.setSelection(currentRow,false);
                }

                function updateButtons() {
                    if (currentRow != 1)
                        $("#" + previousId).removeAttr('disabled');
                    else
                        $("#" + previousId).attr('disabled', 'disabled');
                }  
            });                                 
            
            scope.$watch('data', function (value) {
                table.jqGrid('clearGridData');
                if (value.length > 0) {                    
                    table.jqGrid('setGridParam', { data: value }).trigger('reloadGrid');
                    if (angular.isDefined(scope.activeKey)) {
                        set_activeItem(scope.activeKey);
                    }
                } 
                totalRows = value.length; 
                if (lt.LTHelper.device == lt.LTDevice.mobile && totalRows > 0) {
                    $('html, body').animate({
                        scrollTop: table.offset().top
                    }, 1000);
                }                        
            }, true); 
                                  

            scope.$watch('activeKey', function (value) {
                if (angular.isDefined(value)) {
                    set_activeItem(value);
                }
            });

            function set_activeItem(key) {
                var rowIds: Array<string> = table.getDataIDs();

                for (var i = 0; i < rowIds.length; i++) {
                    var data = table.jqGrid('getRowData', rowIds[i]);

                    if (data[scope.activeKeyName] == key) {
                        var selectedRowId = table.jqGrid('getGridParam', 'selrow');

                        if (selectedRowId != rowIds[i]) {
                            table.jqGrid('setSelection', rowIds[i]);
                            break;
                        }
                    }
                }
            }                                        
        }
    }
}]); 