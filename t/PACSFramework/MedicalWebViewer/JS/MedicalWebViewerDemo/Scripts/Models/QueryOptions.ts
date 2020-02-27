// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Models {
    export class PatientQueryOptions {
        PatientName: string;
        PatientID: string;
        Sex: string;
        BirthDate: Date;
    }

    export class StudyQueryOptions {
        StudyID: string;
        ModalitiesInStudy: Array<string>;
        AccessionNumber: string;
        ReferDoctorName: string;
        StudyStartDate: Date;
        StudyEndDate: Date;
        StudyTimeStart: Date;
        StudyTimeEnd: Date;
        StudyInstanceUID: string;
    }

    export class SeriesQueryOptions {
        SeriesDescription: string;
        SeriesDateStart: Date;
        SeriesDateEnd: Date;
        SeriesInstanceUID: string;
    } 

    export class QueryOptions {
        PatientsOptions: PatientQueryOptions;
        StudiesOptions: StudyQueryOptions;
        SeriesOptions: SeriesQueryOptions;

        constructor() {
            this.PatientsOptions = new PatientQueryOptions();
            this.StudiesOptions = new StudyQueryOptions();
            this.SeriesOptions = new SeriesQueryOptions();
        }
    }     
}