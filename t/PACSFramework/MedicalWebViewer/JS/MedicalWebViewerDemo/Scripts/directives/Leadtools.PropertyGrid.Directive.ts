// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

directives.directive('propertygrid', ["eventService", "$rootScope", function (eventService: EventService, $rootScope): ng.IDirective {
        return {
        restrict: 'A',
        scope: {
            items: "=",
            onPropertyChanged: "&",
            onPropertyClicked: "&"
        },
        link: function (scope : any, elem, attr: any) {
            var id = elem.attr('id');
            var propertyGrid = new PropertyGrid(id, 'px');            
                        
            function addProperty(property: PropertyGridItem) {
                propertyGrid.addProperty(property.groupName, property.rowType, property.cssName, property.dropFields, property.isSubGroup, property.value, property.propertyName, property.enabled);
            }

            scope.$watch('items', function (newValue) {
                propertyGrid.clearGrid();
                if (newValue) {
                    angular.forEach(newValue, function (value, key) {
                        addProperty(value);
                    });
                }

                propertyGrid.renderGrid();
            }, true);                                               

            propertyGrid.PropertyChanged = function (name, value) {
                scope.onPropertyChanged({ name: name, value: value });
            }

            propertyGrid.PropertyClicked= function (name, value) {
                scope.onPropertyClicked({ name: name, value: value });
            }
        }
    }
}]);