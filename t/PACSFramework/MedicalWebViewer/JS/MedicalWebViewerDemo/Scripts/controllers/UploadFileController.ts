// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

module Controllers {
    export interface IUploadFileControllerScope extends ng.IScope {                
        enabled: boolean;
        player: any;
        progress: any;
        text: any;
        progresscurrent: any;
        totalProgressValue: any;
        countFrom: number;
        countTo: number;
        totalCountTo: number;
        progressBarVisiblity: boolean;
        cancelVisiblity: boolean;
        browseDisabled: boolean;
        subProgressForTotal: number;
        currentTotalProgress: number;
        fileCount: number;
        previous(files);
        close();
        cancel();
    }

    export class UploadFileController {

        static $inject = ['$scope', '$modalInstance', 'seriesManagerService', 'eventService', 'safeApply', 'objectStoreService'];

        constructor($scope: IUploadFileControllerScope, $modalInstance, seriesManagerService: SeriesManagerService,
            eventService: EventService, safeApply, objectStoreService: ObjectStoreService) {                                            
            var previousCell: lt.Controls.Medical.Cell = null;

            $scope.enabled = true; 
            //$scope.service = uploadFileService;  
            $scope.player = {};
            $scope.cancelVisiblity = false;
            $scope.progresscurrent = 0
            $scope.totalProgressValue = 0
            $scope.countTo = 0; 
            $scope.countFrom = 0; 
            $scope.totalCountTo = 0;
            $scope.text = { current: "", total: "" };
            $scope.progressBarVisiblity = false;
            $scope.browseDisabled = false;
            $scope.subProgressForTotal = 0;
            $scope.currentTotalProgress = 0;
            $scope.fileCount = 0;


            var closePending: boolean;


            var base64ArrayBuffer = function (arrayBuffer) {
                var base64 = ''
                var encodings = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/'

                var bytes = new Uint8Array(arrayBuffer)
                var byteLength = bytes.byteLength
                var byteRemainder = byteLength % 3
                var mainLength = byteLength - byteRemainder

                var a, b, c, d
                var chunk

                // Main loop deals with bytes in chunks of 3
                for (var i = 0; i < mainLength; i = i + 3) {
                    // Combine the three bytes into a single integer
                    chunk = (bytes[i] << 16) | (bytes[i + 1] << 8) | bytes[i + 2]

                    // Use bitmasks to extract 6-bit segments from the triplet
                    a = (chunk & 16515072) >> 18 // 16515072 = (2^6 - 1) << 18
                    b = (chunk & 258048) >> 12 // 258048   = (2^6 - 1) << 12
                    c = (chunk & 4032) >> 6 // 4032     = (2^6 - 1) << 6
                    d = chunk & 63               // 63       = 2^6 - 1

                    // Convert the raw binary segments to the appropriate ASCII encoding
                    base64 += encodings[a] + encodings[b] + encodings[c] + encodings[d]
                }

                // Deal with the remaining bytes and padding
                if (byteRemainder == 1) {
                    chunk = bytes[mainLength]

                    a = (chunk & 252) >> 2 // 252 = (2^6 - 1) << 2

                    // Set the 4 least significant bits to zero
                    b = (chunk & 3) << 4 // 3   = 2^2 - 1

                    base64 += encodings[a] + encodings[b] + '=='
                } else if (byteRemainder == 2) {
                    chunk = (bytes[mainLength] << 8) | bytes[mainLength + 1]

                    a = (chunk & 64512) >> 10 // 64512 = (2^6 - 1) << 10
                    b = (chunk & 1008) >> 4 // 1008  = (2^6 - 1) << 4

                    // Set the 2 least significant bits to zero
                    c = (chunk & 15) << 2 // 15    = 2^4 - 1

                    base64 += encodings[a] + encodings[b] + encodings[c] + '='
                }

                return base64
            }

            var EventDispatcher = (function () {
                function EventDispatcher() {
                    this._eventHandlers = {};
                }
                EventDispatcher.prototype.addEventListener = function (theEvent, theHandler) {
                    this._eventHandlers[theEvent] = this._eventHandlers[theEvent] || [];
                    this._eventHandlers[theEvent].push(theHandler);
                };

                EventDispatcher.prototype.clearEventListener = function (theEvent) {
                    this._eventHandlers[theEvent].clear();
                }

                EventDispatcher.prototype.checkEventListener = function (theEvent) {
                    return this._eventHandlers[theEvent].length > 0;
                }



                EventDispatcher.prototype.dispatchEvent = function (theEvent, eventData, theHandler) {
                    theHandler(theEvent, eventData);
                };
                EventDispatcher.prototype.dispatchAll = function (theEvent, eventData) {
                    var theHandlers = this._eventHandlers[theEvent];
                    if (theHandlers) {
                        for (var i = 0; i < theHandlers.length; i += 1) {
                            this.dispatchEvent(theEvent, eventData, theHandlers[i]);
                        }
                    }
                };
                return EventDispatcher;
            })();


            var uploadingFilePosition = 0;
            var uploadingFileChunkSize = 200 * 200;
            var uploadEvent = new EventDispatcher();
            var uploadFileName;

            var StartDicomUpload = function (file) {
                var reader = new FileReader();
                var __this = this;
                var d = $.Deferred();
                uploadingFilePosition = 0;
                reader.onloadend = function (evt: any) {
                    if (evt.target.readyState === 2) {
                        var base64String = base64ArrayBuffer(evt.target.result);
                        objectStoreService.UploadDicomImage(base64String, "start", "").then(function (data) {
                            uploadFileName = data.data;
                            uploadingFilePosition = uploadingFilePosition + uploadingFileChunkSize;
                            $scope.countTo = 
                            $scope.progresscurrent = (uploadingFilePosition >= file.size) ? 100 : (100 * uploadingFilePosition / file.size) >> 0;
                            $scope.subProgressForTotal = $scope.progresscurrent / $scope.fileCount;
                            $scope.totalCountTo =
                            $scope.totalProgressValue = $scope.currentTotalProgress + Math.ceil($scope.subProgressForTotal);
                            if (uploadingFilePosition >= file.size)
                            {
                                d.resolve("success_done");
                            }
                            else
                                d.resolve("success_more");
                        });
                    }
                };

                var endByte = uploadingFilePosition + uploadingFileChunkSize;
                if (endByte > file.size) {
                    endByte = file.size;
                }
                var blob = file.slice(uploadingFilePosition, endByte);
                reader.readAsArrayBuffer(blob);

                return d.promise();
            }

            var ResumeDicomUpload = function (file) {
                var reader = new FileReader();
                var __this = this;
                var d = $.Deferred();
                reader.onloadend = function (evt: any) {
                    if (evt.target.readyState === 2) {
                        var base64String = base64ArrayBuffer(evt.target.result);
                        objectStoreService.UploadDicomImage(base64String, "append", uploadFileName).then(function (data) {
                            uploadingFilePosition = uploadingFilePosition + uploadingFileChunkSize;
                            $scope.countTo = 
                            $scope.progresscurrent = (uploadingFilePosition >= file.size) ? 100 : (100 * uploadingFilePosition / file.size) >> 0;
                            $scope.subProgressForTotal = $scope.progresscurrent / $scope.fileCount;
                            $scope.totalCountTo =
                                $scope.totalProgressValue = $scope.currentTotalProgress + Math.ceil($scope.subProgressForTotal);

                            if (uploadingFilePosition >= file.size)
                            {
                                d.resolve("success_done");
                            }
                            else
                                d.resolve("success_more");
                        });
                    }
                };
                var endByte = uploadingFilePosition + uploadingFileChunkSize;
                if (endByte > file.size) {
                    endByte = file.size;
                }
                var blob = file.slice(uploadingFilePosition, endByte);
                reader.readAsArrayBuffer(blob);

                return d.promise();
            }


            var UploadFile = function (files, index) {
                var file: File = files[index];
                var uploadError = "";
                $scope.fileCount = files.length;
                $scope.progressBarVisiblity = true;
                $scope.cancelVisiblity = true;
                $scope.browseDisabled = true;

                $scope.text.current = file.name;
                var d = $.Deferred();

                uploadEvent.addEventListener("onStateChanged", function (theEvent, eventData) {
                    if (closePending) {
                        uploadEvent.clearEventListener("FileUploaded");
                        return;
                    }
                    switch (eventData) {
                        case "success_more":
                            ResumeDicomUpload(file).done(function (data) {
                                if (data === "success_more")
                                    uploadEvent.dispatchAll("onStateChanged", "success_more");
                                else
                                    uploadEvent.dispatchAll("onStateChanged", "success_done");
                            }).fail(function () {
                                alert("couldn\'t upload the file");
                            });
                            break;
                        case "success_done":
                            objectStoreService.UploadDicomImage(null, "done", uploadFileName).then(function (data) {

                                uploadEvent.clearEventListener("onStateChanged");
                                if (data.data.hasOwnProperty('FaultType') && data.data.FaultType == 'Exception') {
                                    uploadError = data.data.Message;
                                }
                                d.resolve("file uploaded", uploadError);
                            }); 
                            break;
                        case "error_fail":
                            alert('Error uploading file!');
                            break;
                    }
                });

                $scope.currentTotalProgress = (100 * (index) / files.length) >> 0;
                $scope.totalCountTo =
                    $scope.totalProgressValue = $scope.currentTotalProgress + Math.ceil($scope.subProgressForTotal );
                $scope.text.total = "Uploading " + (index + 1) + " / " + files.length;

                StartDicomUpload(file).done(function (data) {
                    if (data === "success_more")
                        uploadEvent.dispatchAll("onStateChanged", "success_more");
                    else
                        uploadEvent.dispatchAll("onStateChanged", "success_done");
                });;

                return d.promise();
            }


            var fileCounter;
            var startUploading = false;
            var uploadErrorMessage = "";
            var uploadErrorCount = 0;


            


            $scope.previous = function (files) {
                fileCounter = 0;
                closePending = false;
                startUploading = true;
                uploadErrorCount = 0;
                uploadErrorMessage = "";
                if (files.length != 0) {

                    uploadEvent.addEventListener("FileUploaded", function (theEvent, eventError) {

                        if (eventError != "") {
                            if (uploadErrorCount == 0) {
                                uploadErrorMessage = "File [" + files[fileCounter].name + "] " + eventError;
                            }
                            uploadErrorCount++;
                        }

                        fileCounter++;

                        if (closePending) {
                            uploadEvent.clearEventListener("FileUploaded");
                            return;
                        }

                        if (fileCounter >= files.length) {
                            startUploading = false;
                            uploadEvent.clearEventListener("FileUploaded");
                            $scope.progressBarVisiblity = false;
                            $scope.cancelVisiblity = false;
                            $scope.browseDisabled = false;

                            var message = "";
                            if (uploadErrorCount > 0) {
                                message = "Total Files Uploaded: " + (fileCounter - uploadErrorCount) + " of " + fileCounter + '\n' + uploadErrorMessage;
                            }
                            else {
                                message = "Total Files Uploaded: " + fileCounter;
                            }
                            alert(message);

                        }
                        else {
                            UploadFile(files, fileCounter).then(function (name, eventError) {
                                uploadEvent.dispatchAll("FileUploaded", eventError);
                            });
                        }

                    });
                    UploadFile(files, fileCounter).then(function (name, eventError) {
                        uploadEvent.dispatchAll("FileUploaded", eventError);
                    });
                }
            }

            $scope.close = function () {
                closePending = true;
                if (!startUploading)
                    $modalInstance.dismiss('cancel');
            }

            $scope.cancel = function () {
                closePending = true;
                $scope.progressBarVisiblity = false;
                $scope.cancelVisiblity = false;
                $scope.browseDisabled = false;
                startUploading = false;

                var inputFile: HTMLInputElement = <HTMLInputElement>document.getElementById("inputFile");
                inputFile.value = null;

                objectStoreService.UploadDicomImage("", "cancel", "").then(function (data) {

                    alert('Canceled');
                });
            }


            eventService.subscribe(EventNames.ActiveSeriesChanged, function (event, data) {
            });
        }
    }
}