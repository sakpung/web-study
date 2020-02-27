// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../controls/OverflowManager.ts" />

module Controllers {
    export interface ICompareViewControllerControllerScope extends ng.IScope {         
        layoutConfig: any; 
        viewerId: string;          
        tabId: string;         

        seriesList: Array<MedicalViewerSeries>;  
        viewerConfig: MedicalViewerConfig;  
        viewerapi: any;    
    }

    export class CompareViewController {
        static $inject = ['$scope', 'toolbarService', 'tabService'];    

        private _scope: ICompareViewControllerControllerScope;    

        constructor($scope: ICompareViewControllerControllerScope, toolbarService:ToolbarService, tabService:TabService) {  
            var spacingSize = Utils.get_spacingSize();
            var deregister = null;
            var __this = this;

            $scope.layoutConfig = {
                autoBindCustomButtons: true,
                scrollToBookmarkOnLoad: false,
                applyDemoStyles: true,
                spacing_closed: spacingSize * 2,
                spacing_open: spacingSize * 2,
                livePaneResizing: false,
                west__size: 0,
                west__resizable: false,
                west__togglerLength_closed: 21,
                south__resizable: false,
                south__initHidden: true,
                south__togglerContent_open: "<span style='vertical-align:top; color:white; vertical-align:middle'>Overflow</span>",
                south__togglerLength_open: 64,
                south__togglerContent_closed: "<span style='vertical-align:top; color:white'>Overflow</span>",
                south__togglerLength_closed: 64,
                east__initHidden: true,
                east__resizable: false,
                east__size: 0,
                north__size: 0,
                north__initHidden: true,
                north__resizable: false,
                north__showOverflowOnHover: true
            }
                        
            $scope.tabId = '';
            $scope.viewerId = UUID.generate();
            $scope.viewerapi = {};

            $scope.seriesList = new Array<MedicalViewerSeries>();
            this._scope = $scope;

            deregister = $scope.$watch('tabId', function (newValue, oldValue) {                
                var series:Array<any> =  tabService.get_tabData(newValue, TabDataKeys.CompareInstances);
                var grid = __this.getGrid(series.length);

                tabService.set_tabData($scope.tabId, TabDataKeys.ViewController, __this);
                tabService.set_tabData($scope.tabId, TabDataKeys.Linked, true);
                $scope.viewerConfig = new MedicalViewerConfig();
                $scope.viewerConfig.rows = grid.rows;
                $scope.viewerConfig.columns = grid.columns;
                $scope.viewerConfig.splitterSize = Utils.get_splitterSize();        
                tabService.set_tabData(newValue, TabDataKeys.CompareInstances, null);

                $.each(series, function (index, value) {
                    var viewerSeries: MedicalViewerSeries = new MedicalViewerSeries(value.InstanceUID, value.Patient.ID);

                    viewerSeries.forCompare = true;
                    $scope.seriesList.push(viewerSeries);
                });
            });                       
        }

        private getGrid(itemCount: number) {
            var rows: number = Math.ceil(Math.sqrt(itemCount));
            var columns: number = Math.round(Math.ceil(itemCount / rows));

            return { columns: columns, rows: rows };
        }

        public getViewer() {
            return this._scope.viewerapi.getMedicalViewer();
        }
    }
}