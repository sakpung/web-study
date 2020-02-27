// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/LEADTOOLS/jquery/jquery.d.ts" />
/// <reference path="../../lib/custom.d.ts" />
/// <reference path="Scopes.ts" />
/// <reference path="../Models/DataModels.ts" />

module Controllers {
    export interface IUserQueueControllerScope extends ng.IScope {
        downloads: Array<Models.DownloadInfo>;
        tabId: string;
        canViewJob: boolean;
        canDeleteJob: boolean;
        filterQuery: any;
        auto: any;

        getJobHeader(job: Models.DownloadInfo);
        statusChanged(status: any);
        refreshedChanged(refresh: boolean);
        deleteView();
        viewSeries();
    }

    export class UserQueueController {
        static $inject = ['$scope', 'eventService', 'optionsService', 'seriesDownloadQueueService', 'tabService','$timeout','$filter','dialogs', '$translate','authenticationService'];

        private _seriesDownloadQueueService: SeriesDownloadQueueService;
        private _isLoaded: boolean;
        private _openedJob: Models.DownloadInfo;

        constructor($scope: IUserQueueControllerScope, eventService: EventService, optionsService: OptionsService, seriesDownloadQueueService: SeriesDownloadQueueService, tabService: TabService,$timeout: ng.ITimeoutService, $filter:ng.IFilterService, dialogs, $translate,authenticationService:AuthenticationService) {
            var __this = this;
            var confirmation: string;
            var confirmationMessage: string;

            $translate('DIALOGS_CONFIRMATION_TITLE').then(function (translation) {
                confirmation = translation;
            });

            $translate('DELETE_QUEUE_VIEW_CONFIRMATION').then(function (translation) {
                confirmationMessage = translation;
            });

            $scope.tabId = '';
            $scope.filterQuery = {}; 
            $scope.filterQuery.status = DownloadStatus.All;  
            $scope.filterQuery.name = ''; 
            $scope.filterQuery.server = ''; 
            $scope.auto = {};
            $scope.auto.refresh = true;                             

            $scope.getJobHeader = function (job: Models.DownloadInfo) {
                var header: Array<string> = new Array<string>();

                header.push("Status: " + __this.get_statusString(job.Status));
                if ((<any>job).SeriesInfo) {
                    header.push("Name: " + (<any>job).SeriesInfo.PatientName);
                    header.push("Series #: " + (<any>job).SeriesInfo.SeriesNumber);
                    header.push("Desc: " + (<any>job).SeriesInfo.SeriesDescription);
                }

                if (job.Server) {
                    header.push("Server: " + job.Server.AETitle);
                }
                return header.join(", ");
            }

            var deregister = $scope.$watch('tabId', function (newValue, oldValue) {
                tabService.set_tabData($scope.tabId, TabDataKeys.ViewController, __this);
                tabService.set_tabData($scope.tabId, TabDataKeys.Linked, true);
                deregister();               
            });

            eventService.subscribe(EventNames.DownloadSeries, $.proxy(this.DownloadSeries, this));
            eventService.subscribe(EventNames.SelectedTabChanged, function (event, data) {
                if (data.args.currentTab.id == $scope.tabId) {
                    if (!__this._isLoaded) {
                        __this._isLoaded = true;
                        seriesDownloadQueueService.loadUserQueue().success(function (result) {
                            $scope.downloads = result;
                        }).error(function (error) {
                            });
                    }
                }
            });

            eventService.subscribe(EventNames.JobCreated, function (event, data) {                
                data.args.job.open = true;
            });

            eventService.subscribe(EventNames.JobUpdated, function (event, data) {
                var index = $scope.downloads.map(x => x.Id).indexOf(data.args.job.Id);

                if (index != -1) {
                    var job: Models.DownloadInfo = $scope.downloads[index];

                    job.Status = data.args.job.Status;
                    job.ErrorMessage = data.args.job.ErrorMessage;
                }
            });

            $scope.$watch('downloads', function (newValue: Array<Models.DownloadInfo>, oldValue: Array<Models.DownloadInfo>) {
                if (angular.isDefined(newValue)) {
                    var openedJobs = $.grep(newValue, function (e, index: number) {
                        return e.Open;
                    });

                    if (openedJobs.length > 0) {
                        if (openedJobs[0] != __this._openedJob) {
                            __this._openedJob = openedJobs[0];
                            __this.selectedJobChanged($scope, __this._openedJob);
                        }
                    }
                    else
                        __this._openedJob = null;
                }
            }, true);

            $scope.statusChanged = function (status:any) {
                var statusNum: number = parseInt(status);

                switch(statusNum)
                {
                    case DownloadStatus.Idle:
                    case DownloadStatus.Started:
                    case DownloadStatus.All:
                        $scope.canDeleteJob = false;
                        break;
                    default:
                        $scope.canDeleteJob = authenticationService.hasPermission(PermissionNames.CanDeleteDownloadInfo);
                        break;
                }                
            }

            $scope.refreshedChanged = function (refresh: boolean) {
                seriesDownloadQueueService.autoRefresh(refresh);
            }

            $scope.deleteView = function () {
                var items: Array<Models.DownloadInfo> = $filter('byJobInfo')($scope.downloads, $scope.filterQuery);

                if (items.length > 0) {
                    var dlg = dialogs.confirm(confirmation,confirmationMessage);

                    dlg.result.then(function (btn) {
                        var itemsToDelete: Array<number> = new Array<number>();
                        var length: number = items.length;

                        for (var i = 0; i < length; i++) {
                            itemsToDelete.push(parseInt(items[i].Id));
                        }

                        seriesDownloadQueueService.deleteJobs(itemsToDelete).success(function () {
                            var length: number = itemsToDelete.length;

                            while (length--) {
                                var index = $scope.downloads.map(x => x.Id).indexOf(itemsToDelete[length].toString());

                                if (index != -1) {
                                    $scope.downloads.splice(index, 1);
                                }
                            }
                        }).
                        error(function (error) {
                        });
                    });
                }
            }

            $scope.viewSeries = function () {
                if (__this._openedJob) {
                    if (__this._openedJob.Status == DownloadStatus.Completed) {
                        var study = {
                            StudyInstanceUID: __this._openedJob.StudyInstanceUID,
                            PatientID: (<any>(__this._openedJob)).SeriesInfo.PatientId
                        };
                        var series = {
                            InstanceUID: __this._openedJob.SeriesInstanceUID,
                            StudyInstanceUID: study.StudyInstanceUID,
                            Patient: {
                                ID: (<any>(__this._openedJob)).SeriesInfo.PatientId,
                                Name: (<any>(__this._openedJob)).SeriesInfo.PatientName
                            }
                        };
                        
                        eventService.publish(EventNames.SeriesSelected, { study: study, series: series, remote: false });
                    }
                }
            }
            
            $scope.statusChanged($scope.filterQuery.status);
            $scope.refreshedChanged($scope.auto.refresh); 
            this._seriesDownloadQueueService = seriesDownloadQueueService;
        }

        public get_statusString(status: number) {
            if (status == null) {
                return "Unknown";
            }

            switch (status) {
                case DownloadStatus.Idle:
                    return "Idle";
                case DownloadStatus.Started:
                    return "Started";
                case DownloadStatus.Completed:
                    return "Completed";
                case DownloadStatus.Error:
                    return "Error";
                case DownloadStatus.Aborted:
                    return "Aborted";
            }
            return "Unknown";
        }

        public DownloadSeries(event, data) {
            var extraInfo: Models.SeriesExtraInformation = new Models.SeriesExtraInformation();

            if (data.args.studyInfo) {
                if (data.args.studyInfo.Patient) {
                    extraInfo.PatientId = data.args.studyInfo.Patient.ID;
                    extraInfo.PatientName = data.args.studyInfo.Patient.Name;
                    data.args.seriesInfo.Patient = data.args.studyInfo.Patient;
                }

                extraInfo.StudyDescription = data.args.studyInfo.Description;
            }

            extraInfo.SeriesNumber = data.args.seriesInfo.Number;
            extraInfo.SeriesDescription = data.args.seriesInfo.Description;
            extraInfo.Modality = data.args.seriesInfo.Modality;

            this._seriesDownloadQueueService.downloadSeries(data.args.pacsClientInfo, data.args.clientAe, data.args.seriesInfo, extraInfo);
        }

        public selectedJobChanged($scope:IUserQueueControllerScope, job: Models.DownloadInfo) {
            if (job == null || job.Status != DownloadStatus.Completed) {
                $scope.canViewJob = false;
            }
            else
                $scope.canViewJob = true;
        }        
    }
}

filters.filter('byJobInfo', function () {
    return function (jobs: Array<Models.DownloadInfo>, query) {
        if (angular.isDefined(jobs)) {
            var matches: Array<Models.DownloadInfo> = $.grep(jobs, function (e: Models.DownloadInfo, index: number) {
                return ((e.Status == query.status) || query.status == DownloadStatus.All) &&
                    (query.name.length == 0 || ((<any>e).SeriesInfo && angular.isDefined((<any>e).SeriesInfo.PatientName) && (<any>e).SeriesInfo.PatientName.search(new RegExp(query.name, 'i')) != -1)) &&
                    (query.server.length == 0 || (angular.isDefined(e.Server) && e.Server.AETitle.search(new RegExp(query.server, 'i')) != -1))
            });

            return matches;
        }
    }
});