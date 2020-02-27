// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
class JobDownloadInfo {
    public Server;
    public Client;
    public Series;
    public SeriesInformation;

    constructor() {
        this.Server = null;
        this.Client = null;
        this.Series = null;
        this.SeriesInformation = null;
    }
}
class SeriesDownloadQueueService {
    static $inject = ['app.config', 'eventService', 'pacsRetrieveService','$timeout'];

    private _eventService: EventService;
    private _loadingJobs: boolean = false;
    private _pendingDownloads: Array<JobDownloadInfo>;
    private _pacsRetrieveService: PacsRetrieveService;
    private _userJobs: Array<Models.DownloadInfo>;
    private _unfinishedJobs: Array<Models.DownloadInfo>;
    private _timeout: ng.ITimeoutService;
    private _refreshTimer: ng.IPromise<any>;
    private _jobsUpdater: JobStatusUpdater;

    constructor(config, eventService: EventService, pacsRetrieveService: PacsRetrieveService, $timeout: ng.ITimeoutService) {
        var __this = this;

        this._eventService = eventService;
        this._pendingDownloads = new Array<JobDownloadInfo>();
        this._pacsRetrieveService = pacsRetrieveService;
        this._timeout = $timeout;
        this._userJobs = null;
        this._unfinishedJobs = new Array<Models.DownloadInfo>();
        this._jobsUpdater = new JobStatusUpdater(pacsRetrieveService, eventService);

        eventService.subscribe(EventNames.JobUpdated, function (event, data) {
            if (data.args.job.Status != DownloadStatus.Idle && data.args.job.Status != DownloadStatus.Started) {
                __this._unfinishedJobs.splice(data.args.index, 1);
            }
        });
    }

    public loadUserQueue(): ng.IHttpPromise<any> {
        var __this = this;

        if (this._loadingJobs) {
            return;
        }

        this._loadingJobs = true;
        return this._pacsRetrieveService.loadQueue().success(function (result) {
            __this._userJobs = result;
            __this._loadingJobs = false;
            __this.fillUncompletedJobs();
            __this.processDownloadQueue();
        }).error(function () {
            __this._loadingJobs = false;
            __this.processDownloadQueue();
            });
    }

    public downloadSeries(server, client, series, seriesInformation) {
        if (this._loadingJobs) {
            var downloadInfo: JobDownloadInfo = new JobDownloadInfo();

            downloadInfo.Server = server;
            downloadInfo.Client = client;
            downloadInfo.Series = series;
            downloadInfo.SeriesInformation = seriesInformation;

            this._pendingDownloads.push(downloadInfo);
        }
        else {
            var extraData = null;
            var __this = this;

            if (seriesInformation != null) {
                var userData = JSON.stringify(seriesInformation);
                extraData = {};
                extraData.UserData = userData;
            }

            this._pacsRetrieveService.DownloadImages(server, client, series.PatientID, series.StudyInstanceUID, series.InstanceUID, null, extraData)
                .success(function (jobInfo:Models.DownloadInfo) {
                    if (__this._userJobs == null) {
                        __this.loadJobs([jobInfo]);
                    }
                    else {
                        __this.updateJobSeriesInfo(jobInfo);
                        __this._userJobs.push(jobInfo);

                        if (jobInfo.Status == DownloadStatus.Idle || jobInfo.Status == DownloadStatus.Started) {
                            __this.markUnfinishedJob(jobInfo);
                        }
                    }
                    __this._eventService.publish(EventNames.JobCreated, { job: jobInfo });
                })
                .error(function (error) {
                });
        }
    }

    public deleteJobs(jobIds: Array<number>): ng.IHttpPromise<any> {
        return this._pacsRetrieveService.DeleteDownloadInfos(jobIds);
    }

    public autoRefresh(refresh: boolean) {
        if (refresh) {
            if (this._refreshTimer == null) {
                this.onRefreshQueue();
            }
        }
        else {
            if (this._refreshTimer != null) {
                this._timeout.cancel(this._refreshTimer);                
            }
        }
    }

    private onRefreshQueue() {
        if (this._refreshTimer != null) {
            this._timeout.cancel(this._refreshTimer);
            this._refreshTimer = null;
        }

        this.refreshQueueStatus();
        this._refreshTimer = this._timeout($.proxy(this.onRefreshQueue,this), 1000);
    }

    private refreshQueueStatus() {
        if (this._jobsUpdater.isBusy || this._userJobs == null || this._unfinishedJobs.length == 0) {
            return;
        }

        this._jobsUpdater.updateJobs(this._unfinishedJobs.slice(0));
    }

    private loadJobs(userJobs: Array<Models.DownloadInfo>) {
        this._loadingJobs = false;
        this._userJobs = userJobs;
    }

    private fillUncompletedJobs() {
        for (var jobIndex = 0; jobIndex < this._userJobs.length; jobIndex++) {
            var job:Models.DownloadInfo = this._userJobs[jobIndex];

            this.updateJobSeriesInfo(job);
            if (job.Status === DownloadStatus.Idle ||
                job.Status === DownloadStatus.Started) {
                this.markUnfinishedJob(job);
            }
        }
    }

    private processDownloadQueue() {
        if (this._pendingDownloads.length > 0) {
            var length = this._pendingDownloads.length;

            while (length--) {
                var downloadInfo:JobDownloadInfo = this._pendingDownloads.pop();

                this.downloadSeries(downloadInfo.Server, downloadInfo.Client, downloadInfo.Series, downloadInfo.SeriesInformation);
            }
        }
    }

    private updateJobSeriesInfo(jobInfo) {
        if (jobInfo.UserData) {
            try {
                jobInfo.SeriesInfo = JSON.parse(jobInfo.UserData);
            }
            catch (e) { }
        }
    }

    private markUnfinishedJob(job: Models.DownloadInfo) {
        this._unfinishedJobs.push(job);
    }
}

services.service('seriesDownloadQueueService', SeriesDownloadQueueService); 

class JobStatusUpdater {
    private _pacsRetrieveService: PacsRetrieveService;
    private _eventService: EventService;
    private _jobs: Array<Models.DownloadInfo>;

    private _isBusy: boolean;

    public get isBusy(): boolean {
        return this._isBusy;
    }

    constructor(pacsRetrieveService: PacsRetrieveService, eventService:EventService) {
        this._pacsRetrieveService = pacsRetrieveService;
        this._eventService = eventService;
        this._isBusy = false;
    }

    public updateJobs(jobs: Array<Models.DownloadInfo>) {
        this._jobs = jobs;
        this._isBusy = true;
        this.updateNextJob();
    }

    private updateNextJob() {
        var job: Models.DownloadInfo;
        var __this = this;

        if (this._jobs.length === 0) {
            this._isBusy = false;
            return;
        }

        job = this._jobs.pop();
        this._pacsRetrieveService.UpdateDownloadInfoStatus(job).success(function (jobInfo) {
            __this._eventService.publish(EventNames.JobUpdated, { job: jobInfo, index: __this._jobs.length });
            __this.updateNextJob();
        }).
        error(function (error) {
        });
    }
}