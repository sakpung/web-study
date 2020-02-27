// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/datejs.d.ts" />

module Controllers {
    export interface IMonitorCalibrationControllerScope extends ng.IScope {       
        gridOptions: any;              
        calibrations: Array<any>;        
        selectedCalibration: any;
        showDialog: boolean;

        close();
        calibrate();
        canCalibrate: boolean;
    }

    export class MonitorCalibrationController {
        static $inject = ['$scope', '$modalInstance', 'optionsService', 'calibrations', '$modal', 'authenticationService', 'monitorCalibrationService', 'dialogs', '$translate', 'uiGridConstants'];

        private _modal;
        private _calibrationSuccessMsg: string;
        private _calibrationFailureMsg: string;
        private _notificationTitle: string;   
        private _scope;     

        constructor($scope: IMonitorCalibrationControllerScope, $modalInstance, optionsService: OptionsService, calibrations, $modal, authenticationService: AuthenticationService,
            monitorCalibrationService: MonitorCalibrationService, dialogs, $translate, uiGridConstants) {            
            var __this = this;

            this._modal = $modal;
            this._scope = $scope;
           
            $scope.calibrations = calibrations;
            $scope.selectedCalibration = null;
            $scope.canCalibrate = true;
            $scope.showDialog = true;

            $scope.gridOptions = {
                enableSorting: true,
                enableRowSelection: true,
                enableRowHeaderSelection: lt.LTHelper.device == lt.LTDevice.mobile || lt.LTHelper.device == lt.LTDevice.tablet,
                noUnselect: true,
                multiSelect: false,
                onRegisterApi: function (gridApi) {

                    gridApi.selection.on.rowSelectionChanged($scope, function (selectedRow) {
                        $scope.selectedCalibration = selectedRow.entity;
                    });                    
                },
                columnDefs: [
                    { name: "Calibration Time", field: "CalibrationTime", enableHiding: false, sort: { direction: uiGridConstants.DESC, priority: 0 } },
                    { name: "Workstation", field: "Workstation", enableHiding: false },
                    { name: "Username", field: "Username", enableHiding: false },
                    { name: "Comments", field: "Comments", enableHiding: false },
                ],
                data: calibrations
            };        

            $scope.calibrate = function () {
                __this.showCalibrationImage("images/calibration.png", function (data) {
                    var DateJS: IDateJS = <any>new Date();
                    var calibration = {
                        CalibrationTime: DateJS.toString("M/d/yyyy hh:mm:ss tt"),
                        Workstation: data.workstation,
                        Username: authenticationService.user,
                        Comments: data.comments
                    }
                    monitorCalibrationService.AddCalibration(calibration).success(function () {
                        $scope.canCalibrate = false;
                        $scope.calibrations.push(calibration);
                        dialogs.notify(__this._notificationTitle, __this._calibrationSuccessMsg);
                    }).error(function (error, status) {
                        dialogs.error(__this._calibrationFailureMsg +  ": " + status);
                        });                    
                });
            };

            $scope.close = function () {
                $('.modal-backdrop').remove();
                $modalInstance.close();
            };

            $translate('DIALOGS_CALIBRATION_SUCCESS').then(function (translation) {
                __this._calibrationSuccessMsg = translation;
            });

            $translate('DIALOGS_CALIBRATION_FAILURE').then(function (translation) {
                __this._calibrationFailureMsg = translation;
            });

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                __this._notificationTitle = translation;
            });
        }

        public showCalibrationImage(imageUrl, callback) {
            var __this = this;

            if ($('#lightbox').length > 0) { // #lightbox exists

                //place href as img src value
                $('#content').html('<img src="' + imageUrl + '" />');

                //show lightbox window - you could use .show('fast') for a transition
                //$("#calibrationDialog").dialog("close");
                __this._modal("hide");
                $('#lightbox').show();
            }
            else {
                __this._scope.showDialog = false;
                //create HTML markup for lightbox window
                var lightbox =
                    '<div id="lightbox" style="z-index:3000; position:fixed; top:0; right:0; left:0">' +
                    '<div id="content">' + //insert clicked link's href into img src
                    '<img src="' + imageUrl + '" />' +
                    '</div>' +
                    '</div>';
               
                $('body').append(lightbox);                

                $('#lightbox').on('click', function () { //must use live, as the lightbox element is inserted into the DOM
                    $('#lightbox').hide(); 
                    $('#lightBox').remove();
                    __this._scope.showDialog = true;               
                __this.getWorkstation(callback);
                });
            }
        }

        private getWorkstation(callback) {
            var modalInstance = this._modal.open({
                templateUrl: 'views/dialogs/GetWorkstation.html',
                controller: GetWorkstationController,
                backdrop: 'static'                
            });

            modalInstance.result.then(function (calibrationInfo) {
                if (callback) {
                    callback(calibrationInfo);
                }
            }, function (error)
            {
            });
        }
    }
}