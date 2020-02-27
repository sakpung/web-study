// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

directives.directive('checkList', function () {   
    return {
        scope: {
            list: '=checkList',
            value: '@'
        },
        link: function (scope, elem, attrs) {
            var handler = function (setup) {
                var checked = elem.prop('checked');
                var index = scope.list.indexOf(scope.value);

                if (checked && index == -1) {
                    if (setup) elem.prop('checked', false);
                    else scope.list.push(scope.value);
                } else if (!checked && index != -1) {
                    if (setup) elem.prop('checked', true);
                    else scope.list.splice(index, 1);
                }
            };

            var setupHandler = handler.bind(null, true);
            var changeHandler = handler.bind(null, false);

            elem.bind('change', function () {
                scope.$apply(changeHandler);
            });

            scope.$watch('list', setupHandler, true);
        }
    };
});

directives.directive('ngEnter', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                scope.$apply(function () {
                    scope.$eval(attrs.ngEnter);
                });

                event.preventDefault();
            }
        });
    };
});

function processInput(ctrl, val, regex) {
    var digits = val.replace(regex, '');

    if (digits !== val) {
        ctrl.$setViewValue(digits);
        ctrl.$render();
    }
    return digits;
}

//
// Directive that only allows digits and a decimal
//
directives.directive('onlyDigitsd', function () {
    return {
        require: 'ngModel',
        restrict: 'A',
        link: function (scope, element, attr, ctrl) {
            function inputValue(val) {
                if (val) {
                    return processInput(ctrl, val, /[^0-9.]/g);
                }
                return undefined;
            }
            ctrl.$parsers.push(inputValue);
        }
    }
});

//
// Directive that only allows digits and a decimal
//
directives.directive('onlyDigits', function () {
    return {
        require: 'ngModel',
        restrict: 'A',
        link: function (scope, element, attr, ctrl) {
            function inputValue(val) {
                if (val) {
                    return processInput(ctrl, val, /[^0-9]/g);
                }
                return undefined;
            }
            ctrl.$parsers.push(inputValue);
        }
    }
});

//
// Forces a blur when value changes.  Android chrome <select> requires this.
//
directives.directive('forceBlur', function () {
    return {
        require: 'ngModel',
        restrict: 'A',
        link: function (scope, element, attr, ctrl) {
            if (ctrl && ctrl.$viewChangeListeners) {
                ctrl.$viewChangeListeners.push(function () {
                    $(element).blur();
                    });
            }
        }
    }
});

app.directive('ngDebounce', ["$timeout", function ($timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        priority: 99,
        link: function (scope, elm, attr, ngModelCtrl) {
            if (attr.type === 'radio' || attr.type === 'checkbox') {
                return;
            }

            var delay = parseInt(attr.ngDebounce, 10);
            if (isNaN(delay)) {
                delay = 1000;
            }

            elm.unbind('input');

            var debounce;
            elm.bind('input', function () {
                $timeout.cancel(debounce);
                debounce = $timeout(function () {
                    scope.$apply(function () {
                        ngModelCtrl.$setViewValue(elm.val());
                    });
                }, delay);
            });
            elm.bind('blur', function () {
                scope.$apply(function () {
                    ngModelCtrl.$setViewValue(elm.val());
                });
            });
        }
    };
}]);

app.directive("modalShow", function () {
    return {
        restrict: "A",
        scope: {
            modalVisible: "="
        },
        link: function (scope, element, attrs) {

            //Hide or show the modal
            scope.showModal = function (visible) {
                if (visible) {
                    element.modal("show");
                }
                else {
                    element.modal("hide");
                }
            }

            //Check to see if the modal-visible attribute exists
            if (!attrs.modalVisible) {

                //The attribute isn't defined, show the modal by default
                scope.showModal(true);

            }
            else {

                //Watch for changes to the modal-visible attribute
                scope.$watch("modalVisible", function (newValue, oldValue) {
                    scope.showModal(newValue);
                });

                //Update the visible value when the dialog is closed through UI actions (Ok, cancel, etc.)
                element.bind("hide.bs.modal", function () {
                    scope.modalVisible = false;
                    if (!scope.$$phase && !scope.$root.$$phase)
                        scope.$apply();
                });

            }

        }
    };    
});

app.directive('elheightresize', ['$window','$parse', function ($window, $parse) {
    return {        
        link: function (scope, elem: JQuery, attrs) {
            var doResize = Utils.debounce(function () {
                scope.onResize();
                scope.$apply();
            }, 150);

            scope.onResize = function () {                               
                var pos = elem.position();                
                
                $(elem).height($window.innerHeight - (pos.top + 5)); 
                if (angular.isDefined(attrs.resize)) {
                    scope.$apply(function () {
                        var method = $parse(attrs.resize);

                        method(scope, {});
                    });
                }
            }

            doResize();           

            angular.element($window).bind('resize', function () {   
                setTimeout(function () {
                    doResize();
                }, 350);                               
            })
        }
    }
}]);
