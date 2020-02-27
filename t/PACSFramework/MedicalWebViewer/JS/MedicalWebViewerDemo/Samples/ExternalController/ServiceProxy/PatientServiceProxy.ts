/// <reference path="../../../lib/jquery/jquery.d.ts" />
/// <reference path="ServiceProxy.ts" />

class PatientServiceProxy extends ServiceProxy {

    public AddPatient(patientInfo : PatientInfo, errorHandler, successHandler): JQueryXHR {
        var dataArgs = {
            authenticationCookie: this.AuthenticationProxy.GetAuthenticationCookie(),
            info: patientInfo,
            userData: null
        };

        return super.DoPostGeneralCall("AddPatient", dataArgs, errorHandler, successHandler);
    }

    public UpdatePatient(patientInfo : PatientInfo , errorHandler, successHandler): JQueryXHR {

        var dataArgs = {
            authenticationCookie: this.AuthenticationProxy.GetAuthenticationCookie(),
            info: patientInfo,
            extraOptions: null
        };

        return super.DoPostGeneralCall("UpdatePatient", dataArgs, errorHandler, successHandler);
    }

    public DeletePatient(patientId: string,  errorHandler, successHandler): JQueryXHR {

        var dataArgs = {
            authenticationCookie: this.AuthenticationProxy.GetAuthenticationCookie(),
            patientId: patientId,
            extraOptions: null
        };

        return super.DoPostGeneralCall("DeletePatient", dataArgs, errorHandler, successHandler);
    }
};

class PatientInfo {
    PatientId: string;
    Name: string;
    BirthDate: string;
    Sex: string;
    Comments: string;
    EthnicGroup: string;

    constructor(patientId, name, birthDate, sex, comments, ethnicGroup) {
        this.PatientId = patientId;
        this.Name = name;
        this.BirthDate = birthDate;
        this.Sex = sex;
        this.Comments = comments;
        this.EthnicGroup = ethnicGroup;
    }
}

class PersonName {

    First: string;
    Last: string;
    Middle: string;
    Prefix: string;
    Suffix: string;
    sep: string;

    constructor(...args: any[]) {

        this.First = "";
        this.Last = "";
        this.Middle = "";
        this.Prefix = "";
        this.Suffix = "";

        if (args.length >= 1) 
            this.Last = args[0];

        if (args.length >= 2) 
            this.First = args[1];

        if (args.length >= 3) 
            this.Middle = args[2];

        if (args.length >= 4) 
            this.Prefix = args[3];

        if (args.length >= 5) 
            this.Suffix = args[4];

        this.sep = "^";
    }

    getDicomName()
    {
        var dicomName = this.Last.trim() + this.sep + this.First.trim() + this.sep + this.Middle.trim() + this.sep + this.Prefix.trim() + this.sep + this.Suffix.trim();
        return dicomName;
    }

    static getPersonName(dicomName: string) {
        var personName = new PersonName();
        var nameParts = dicomName.split('^');

        if (nameParts.length >= 1)
            personName.Last = nameParts[0];

        if (nameParts.length >= 2)
            personName.First = nameParts[1];

        if (nameParts.length >= 3)
            personName.Middle = nameParts[2];

        if (nameParts.length >= 4)
            personName.Prefix = nameParts[3];

        if (nameParts.length >= 5)
            personName.Suffix = nameParts[4];

        return personName;
    }
}