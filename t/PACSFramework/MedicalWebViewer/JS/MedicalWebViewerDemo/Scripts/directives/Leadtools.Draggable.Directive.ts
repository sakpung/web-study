// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

//
// This directive makes the modal dialog window draggable
//
directives.directive('modalWindow', ["$timeout", function ($timeout) {   
  return {
        restrict: 'EA',
      link: function (scope, elem, attr) {

          if (lt.LTHelper.device != lt.LTDevice.mobile) {
              $(elem).children().first().draggable({
                  handle: ".modal-header"
              });
          }

            $timeout(function () {
                var e = elem.find('[autofocus]');

                e.focus();
                if (e.is('input')) {
                    e.click();
                }
            }, 600);
        }
    }
}]);