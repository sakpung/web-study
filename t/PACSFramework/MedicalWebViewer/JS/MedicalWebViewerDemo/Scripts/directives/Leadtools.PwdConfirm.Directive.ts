// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

directives.directive('pwdConfirm', function () {   
  return {
      restrict: 'A',
      require: 'ngModel',
        link: function (scope, elem, attrs, ctrl) {
            var firstPassword = '#' + attrs.pwdConfirm;

            elem.add(firstPassword).on('keyup', function () {
                scope.$apply(function () {
                    var v = elem.val() === $(firstPassword).val();

                    ctrl.$setValidity('pwmatch', v);
                });
            });
        }
    }
});