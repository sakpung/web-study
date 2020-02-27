// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {

   export interface IAddAppScope extends ng.IScope {
      name: string;
      path: string;
      args: string;

      add(): void;
      cancel(): void;
   }

   export class AddAppController {
      private $scope: IAddAppScope;
      private externalApplicationsService: ExternalApplicationsService;

      static $inject = ["$scope", "$modalInstance", "externalApplicationsService"];
      constructor($scope: IAddAppScope, $modalInstance, externalApplicationsService: ExternalApplicationsService) {

         $scope.add = () => {
            try {
               var externalApp: ExternalApp = new ExternalApp();
               externalApp.name = this.$scope.name;
               externalApp.args = this.$scope.args;
               externalApp.path = this.$scope.path;
               this.externalApplicationsService.addApp(externalApp);

               $modalInstance.dismiss("");
            }
            catch (e) {
               alert(e);
            }
         };

         $scope.cancel = () => {
            $modalInstance.dismiss("cancel");
         };

         this.externalApplicationsService = externalApplicationsService;
         this.$scope = $scope;
      }
   }   
}