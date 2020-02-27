// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

directives.directive('leadImageProcessing', ["eventService", "$timeout", function (eventService: EventService, $timeout): ng.IDirective {
    return {
        restrict: 'A',
        scope: {
            frame: '=',
            api: '=',
        },
        link: function (scope : any, elem, attr: any) {
            if (angular.isDefined(scope.frame)) {
                var scaleCanvas: HTMLCanvasElement = document.createElement('canvas');
                var oldCanvas = scope.frame.getPreviewCanvas();
                var viewerImg: HTMLImageElement = <HTMLImageElement>document.createElement('img');
                var previewCanvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById('ipPreviewCanvas');
                var previewContext: CanvasRenderingContext2D = previewCanvas.getContext('2d');
                var viewerBackCanvas = document.createElement('canvas');

                scope.api = scope.api || {};

                scope.api.applyIPCommand = function (command, arguments1) {
                    var ip = new lt.ImageProcessing();
                    var context = scaleCanvas.getContext('2d');
                    var imageData = context.getImageData(0, 0, scaleCanvas.width, scaleCanvas.height);

                    ip.set_jsFilePath(_jsFileCoreColorPath);
                    ip.set_command(command);

                    if (arguments1 != null) {
                        for (var key in arguments1) {
                            if (arguments1.hasOwnProperty(key)) {
                                ip.get_arguments()[key] = arguments1[key];
                            }
                        }
                    }

                    ip.set_imageData(imageData);
                    ip.add_completed(function (sender, event) {
                        previewContext.putImageData(event.get_imageData(), 0, 0);
                    });
                    ip.run();
                }              

                scaleCanvas.width = 128;
                scaleCanvas.height = 128;

                viewerBackCanvas.width = oldCanvas.width;
                viewerBackCanvas.height = oldCanvas.height;

                var context = viewerBackCanvas.getContext('2d');
                context.fillStyle = '#0';
                context.fillRect(0, 0, oldCanvas.width, oldCanvas.height);
                context.drawImage(oldCanvas, 0, 0);             

                viewerImg.onload = function () {
                    var scaleContext = scaleCanvas.getContext("2d");
                    var scaleFacor = 1;
                    var xPos = 0;
                    var yPos = 0;

                    scaleContext.fillStyle = "white";
                    scaleContext.fillRect(0, 0, scaleCanvas.width, scaleCanvas.height);
                   
                    if (viewerBackCanvas.width > viewerBackCanvas.height) {
                        scaleFacor = 128 / viewerBackCanvas.width;
                        yPos = (128 - viewerBackCanvas.height * scaleFacor) / 2;
                    } else {
                        scaleFacor = 128 / viewerBackCanvas.height;
                        xPos = (128 - viewerBackCanvas.width * scaleFacor) / 2;
                    }

                    scaleContext.scale(scaleFacor, scaleFacor);
                    scaleContext.drawImage(viewerImg, xPos * (1 / scaleFacor), yPos * (1 / scaleFacor));

                    scaleContext.scale(1 / scaleFacor, 1 / scaleFacor);
                    previewContext.putImageData(scaleContext.getImageData(0, 0, scaleCanvas.width, scaleCanvas.height), 0, 0);
                    viewerImg = null;

                }

                viewerImg.src = viewerBackCanvas.toDataURL("image/png");              
            }             
        }    
    };    
}]);