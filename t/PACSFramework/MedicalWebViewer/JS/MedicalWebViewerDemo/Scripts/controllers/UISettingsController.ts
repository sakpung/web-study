// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
   export interface IUISettingsControllerScope extends ng.IScope {
      edit: any;
      ok();
      cancel();
      isFormValid(): boolean;
      isEnabled();
   }

   export class UISettingsController {
      static $inject = ['$scope', '$modalInstance'];

      constructor($scope: IUISettingsControllerScope , $modalInstance) {
         $scope.edit = {
            
         };

         $scope.isEnabled = function () {
            var currentTheme = window.localStorage.getItem("leadmedicalwebviewertheme");
            var element;
            element = <HTMLInputElement>document.getElementById("darkThemeCheckBox");
            switch (currentTheme) {
               case "dark":
                  element.checked = true;
                  break;
               case "light":
                  element.checked = false;
                  break;
               default:
                  element.checked = !element.checked;

            }
         }

         $scope.ok = function () {
            var element = <HTMLInputElement>document.getElementById("darkThemeCheckBox");
            var isChecked = element.checked;
            if (isChecked) {
               window.localStorage.setItem("leadmedicalwebviewertheme", "dark");
               var themeCSSElement = <HTMLLinkElement>document.getElementById('theme_css');
               themeCSSElement.href = 'css/darktheme.css';
            } else {
               window.localStorage.setItem("leadmedicalwebviewertheme", "light");
               var themeCSSElement = <HTMLLinkElement>document.getElementById('theme_css');
               themeCSSElement.href = 'css/theme-light.css';
            }

            $modalInstance.close('ok');
         }
      }
   }
}