// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
declare var commangular;

commangular.command('OnSpyGlass', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
	return {
        execute: function () {            
            SpyglassEffect = Spyglass.Default;            
            SetCurrentInteractiveMode(toolbarService, tabService, MedicalViewerAction.SpyGlass, buttonId, false);
            enumerateCell(tabService, function (cell) {                
                var command: lt.Controls.Medical.SpyGlassAction = cell.getCommand(MedicalViewerAction.SpyGlass);
                command.tiling = true;
                CommandManager.RunCommand(cell, MedicalViewerAction.SpyGlass, buttonId);
            }); 
        }
    }
}]);

commangular.command('OnSpyGlassInvert', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
	return {
        execute: function () {
            SpyglassEffect = Spyglass.Invert;
            SetCurrentInteractiveMode(toolbarService, tabService, MedicalViewerAction.SpyGlass, buttonId, false);
            enumerateCell(tabService, function (cell) {
                var command: lt.Controls.Medical.SpyGlassAction = cell.getCommand(MedicalViewerAction.SpyGlass);
                command.tiling = true;
                CommandManager.RunCommand(cell, MedicalViewerAction.SpyGlass, buttonId);
            });
        }
    }
}]);

commangular.command('OnSpyGlassEqualization', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
	return {
        execute: function () {
            SpyglassEffect = Spyglass.Equalization;
            SetCurrentInteractiveMode(toolbarService, tabService, MedicalViewerAction.SpyGlass, buttonId, false);
            enumerateCell(tabService, function (cell) {
                var command: lt.Controls.Medical.SpyGlassAction = cell.getCommand(MedicalViewerAction.SpyGlass);
                command.tiling = true;
                CommandManager.RunCommand(cell, MedicalViewerAction.SpyGlass, buttonId);
            });
        }
    }
}]);


commangular.command('OnSpyGlassCLAHE', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
	return {
        execute: function () {
            SpyglassEffect = Spyglass.CLAHE;
            SetCurrentInteractiveMode(toolbarService, tabService, MedicalViewerAction.SpyGlass, buttonId, false);
            enumerateCell(tabService, function (cell) {
                var command: lt.Controls.Medical.SpyGlassAction = cell.getCommand(MedicalViewerAction.SpyGlass);
                command.tiling = true;
                CommandManager.RunCommand(cell, MedicalViewerAction.SpyGlass, buttonId);
            });
        }
    }
}]);

