// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
   
   export interface IRunAppScope extends ng.IScope {
      externalApplications: string[];
      selectedApp: string;

      run(): void;
      cancel(): void;
      deleteapp(): void;
   }

   export class RunAppController {
      private $scope: IRunAppScope;
      private externalApplicationsService: ExternalApplicationsService;

      static $inject = ["$scope", "$modalInstance", "externalApplicationsService", "exportService", "seriesManagerService"];
      constructor($scope: IRunAppScope, $modalInstance, externalApplicationsService: ExternalApplicationsService, exportService: ExportService, seriesManagerService: SeriesManagerService) {

         var instanceUID: string = "";
         var cell = seriesManagerService.get_activeCell();
         if (cell) {
            instanceUID = cell.get_seriesInstanceUID();
         }
         
         $scope.externalApplications = [];
         var appList: StringToExternalApp = externalApplicationsService.getAppList();
         for (var x in appList) {
            $scope.externalApplications.push(appList[x].name);
         }

         $scope.selectedApp = "";

         $scope.run = () => {

            var xtrnal: StringToExternalApp = this.externalApplicationsService.getAppList();
            var app: ExternalApp = xtrnal[this.$scope.selectedApp];

            if (app.args.indexOf("%pathname%") >= 0) {
               if (instanceUID === "") {
                  alert("No active cell, please select one before you launch selected application");
               }
               else {
                  var prom: ng.IHttpPromise<any> = exportService.GetInstanceLocalPathName(instanceUID);
                  prom.success((pathname: string): void => {
                     app.args = app.args.replace("%pathname%", pathname);
                     this.externalApplicationsService.runApp(app);
                  });
                  prom.error((err: string): void => {
                     alert(err);
                  });
               }
            }
            else {
               this.externalApplicationsService.runApp(app);
            }
            
            $modalInstance.dismiss("");
         };

         $scope.cancel = () => {
            $modalInstance.dismiss("cancel");
         };

         $scope.deleteapp = () => {
            this.externalApplicationsService.deleteApp(this.$scope.selectedApp);
            $modalInstance.dismiss("");
         }

         this.externalApplicationsService = externalApplicationsService;
         this.$scope = $scope;
      }
   }   
}