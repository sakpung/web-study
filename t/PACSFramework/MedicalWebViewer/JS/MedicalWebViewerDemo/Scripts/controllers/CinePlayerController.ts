// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

module Controllers {
    export interface ICinePlayerControllerScope extends ng.IScope {                
        enabled: boolean;
        service: CinePlayerService;
        player: any;

        first();
        previous();
        stop();
        play();
        next();
        last();
        close();        
    }

    export class CinePlayerController {

        static $inject = ['$scope', '$modalInstance', 'seriesManagerService', 'cinePlayerService', 'eventService','safeApply'];

        constructor($scope: ICinePlayerControllerScope, $modalInstance, seriesManagerService: SeriesManagerService, cinePlayerService: CinePlayerService,
            eventService: EventService, safeApply) {                                            
            var previousCell: lt.Controls.Medical.Cell = null;

            $scope.enabled = true;  
            $scope.service = cinePlayerService;  
            $scope.player = {};
            $scope.player.currentFrame = cinePlayerService.currentFrame;                       

            $scope.first = function () {
                cinePlayerService.first();
            }

            $scope.previous = function () {
                cinePlayerService.previous();
            }

            $scope.stop = function () {
                cinePlayerService.stop();
            }

            $scope.play = function () {
                previousCell = seriesManagerService.get_activeCell();
                cinePlayerService.start();
            }

            $scope.next = function () {
                cinePlayerService.next();
            }

            $scope.last = function () {
                cinePlayerService.last();
            }
            
            $scope.close = function () {
                $modalInstance.close();
            }            

            eventService.subscribe(EventNames.PlayerStopped, function (event, data) {                
                $scope.player.currentFrame = data.args.frame+1;                 
            });

            cinePlayerService.set_frameChanged(function (frame: number) {
                $scope.player.currentFrame = frame + 1;                 
            });
        }
    }
}