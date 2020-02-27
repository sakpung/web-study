/// <reference path="../../../lib/jquery/jquery.d.ts" />
/// <reference path="ServiceProxy.ts" />

class QueryArchiveServiceProxy extends ServiceProxy
{
    public FindPatients(queryParams, errorHandler, successHandler): JQueryXHR {
        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        return super.DoJsonCall("FindPatients", queryParams, errorHandler, successHandler);
    }

    public FindPatientsMax(queryParams, maxQueryResults: number, errorHandler, successHandler): JQueryXHR {
        var extraOptions: any = {};
        extraOptions.UserData = JSON.stringify(maxQueryResults);

        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        queryParams.extraOptions = extraOptions;

        return super.DoJsonCall("FindPatients", queryParams, errorHandler, successHandler);
    }

    public FindStudies(queryParams, errorHandler, successHandler): JQueryXHR {
        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        return super.DoJsonCall("FindStudies", queryParams, errorHandler, successHandler);
    }

    public FindStudiesMax(queryParams, maxQueryResults: number, errorHandler, successHandler): JQueryXHR {
        var extraOptions: any = {};
        extraOptions.UserData = JSON.stringify(maxQueryResults);

        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        queryParams.extraOptions = extraOptions;

        return super.DoJsonCall("FindStudies", queryParams, errorHandler, successHandler);
    }

    public FindSeries(queryParams, errorHandler, successHandler): JQueryXHR {
        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        return super.DoJsonCall("FindSeries", queryParams, errorHandler, successHandler);
    }

    public FindSeriesMax(queryParams, maxQueryResults: number, errorHandler, successHandler): JQueryXHR {
        var extraOptions: any = {};
        extraOptions.UserData = JSON.stringify(maxQueryResults);

        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        queryParams.extraOptions = extraOptions;

        return super.DoJsonCall("FindSeries", queryParams, errorHandler, successHandler);
    }

    public FindInstances(queryParams, errorHandler, successHandler): JQueryXHR {
        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        return super.DoJsonCall("FindInstances", queryParams, errorHandler, successHandler);
   }

    public FindInstancesMax(queryParams, maxQueryResults: number, errorHandler, successHandler): JQueryXHR {
        var extraOptions: any = {};
        extraOptions.UserData = JSON.stringify(maxQueryResults);

        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        queryParams.extraOptions = extraOptions;

        return super.DoJsonCall("FindInstances", queryParams, errorHandler, successHandler);
    }

    public FindPresentationState(referencedSeries, errorHandler, successHandler): JQueryXHR {
      var parameter = "auth=" + encodeURIComponent(this.AuthenticationProxy.GetAuthenticationCookie()) + "&series=" + referencedSeries;      

      return super.DoGetGeneralCall("FindPresentationState", parameter,errorHandler, successHandler);       
   }

    public ElectStudyTimeLineInstances(queryParams, errorHandler, successHandler, userdata): JQueryXHR {
        return super.DoJsonCallUserData("ElectStudyTimeLineInstances", queryParams, errorHandler, successHandler, userdata);
   }

    public GetDicom(queryParams, errorHandler, successHandler): JQueryXHR {
      return super.DoPostXmlCall("GetDicom", queryParams, errorHandler, successHandler);
    }
    
    public AutoComplete(key: string, term: string, errorHandler, successHandler): JQueryXHR {
        var parameter = "auth=" + encodeURIComponent(this.AuthenticationProxy.GetAuthenticationCookie()) + "&key=" + key + "&term=" + term;

        return super.DoGetGeneralCall("AutoComplete", parameter, errorHandler, successHandler);
    }  
};