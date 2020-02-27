// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
class DataService {
    static $inject = ['app.config','eventService'];

    private _series: Array<any> = new Array<any>();
    private _patients: Array<any> = new Array<any>();    
    private _eventService: EventService;    

    constructor(config, eventService: EventService) {
        this._eventService = eventService;       
    }

    public set_Series(series: Array<any>) {
        this._series = series;
        this._patients = new Array<any>();
        if (series && series.length > 0) {
            this.filterPresentationState();
            this.extractPatients();
        }
        else
            this._patients.length = 0;
    }

    public add_series(series) {
        if (!this._series) {
            this._series = [];
        }

        if (series.Patient == null) {
            if (this._patients != null && this._patients.length > 0) {
                series.Patient = this._patients[0];
            }
        }

        this._series.push(series);
    }  

    public get_Series(instanceUid) {
        if (this._series && this._series.length > 0) {
            var series = $.grep(this._series, function (e) {
                return e.InstanceUID == instanceUid;
            });

            if (series.length > 0)
                return series[0];
        }

        return null;
    }

    public get_allSeries(): Array<any> {
        return this._series;
    }

    private filterPresentationState() {
        var length = this._series.length;

        while (length--) {
            if (this._series[length].Modality == "PR" || this._series[length].Modality == "SD") {
                this._series.splice(length, 1);
            }
        }
    }    

    private extractPatients() {        
        var unique = {};
        var length: number = this._series.length;

        for (var i = 0; i < length; i++) {
            if (!unique[this._series[i].Patient.ID]) {
                var item: any = {};

                item.ID = this._series[i].Patient.ID;
                item.Sex = this._series[i].Patient.Sex;

                if(this._series[i].Patient.Name)
                    item.Name = this._series[i].Patient.Name.replace('^', ', ').replace(/\^/g, ' ');
                
                item.BirthDate = this._series[i].Patient.BirthDate;
                item.Series = [];
                item.Series.push(this._series[i]);

                this._patients.push(item);
                unique[this._series[i].Patient.ID] = item;
            }
            else {
                unique[this._series[i].Patient.ID].Series.push(this._series[i]);
            }
        }
    }
}

services.service('dataService', DataService); 