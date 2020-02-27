// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface ISearchControllerScope extends ng.IScope {  
        showPacsQuery: boolean;        
        querySource: any;
        pacsConnections: Array<Models.RemoteConnection>;
        selectedConnection: Models.RemoteConnection;
        isTabletOrMobile: boolean; 
        pacsClientInfo: any;
        storageServerInfo: any;
        gridApi: any;
        expandedApi: any;
        getUrl(row: any);
        doSearch: Function;        
        clear: Function;
        queryOptions: Models.QueryOptions;
        OnSeriesSearchError: Function;
        OnSeriesSearchSuccess: Function;
        OnSeriesSelected: Function;
        queryModeChanged();
        canStore(): boolean;
        onLayoutChanged(newValue: any, oldValue: any);
        onSearchTabSelected();
    }
}    