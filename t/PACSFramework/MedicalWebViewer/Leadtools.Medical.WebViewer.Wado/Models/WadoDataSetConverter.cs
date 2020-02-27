// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Leadtools.Medical.WebViewer.Wado
{
   internal class WadoDataSetConverter
   {
      private static string BuildQueryParams(WadoDataSetModel model, List<string> execluded)
      {
         string query = "?";

         foreach (var propertyInfo in model.GetType().GetProperties())
         {
            if (null != execluded)
            {
               if (execluded.Exists(x => (x == propertyInfo.Name)))
               {
                  continue;
               }
            }

            var value = propertyInfo.GetValue(model) as string;

            if (string.IsNullOrEmpty(value))
            {
               continue;
            }

            query += propertyInfo.Name + "=" + value + "&";
         }
         query = query.TrimEnd('&').TrimEnd('?');
         return query;
      }

      internal static string ToQidoQueryUrl(WadoDataSetModel model, string queryRetrieveLevel)
      {
         var url = string.Empty;

         if (string.IsNullOrEmpty(queryRetrieveLevel))
         {
            if (!string.IsNullOrEmpty(model.StudyInstanceUID))
            {
               if (!string.IsNullOrEmpty(model.SeriesInstanceUID))
               {
                  queryRetrieveLevel = "instance";
               }
               else
               {
                  queryRetrieveLevel = "series";
               }
            }
            else
            {
               queryRetrieveLevel = "study";
            }
         }

         switch (queryRetrieveLevel.ToLower())
         {
            case "patient":
               //this is not a standard qido-rs query
               //throw new Exception("Patient level query is not a standard qido-rs query");
               {
                  url = "patients"
                      + BuildQueryParams(model, null);
               }
               break;

            case "study":
               {
                  url = "studies"
                      + BuildQueryParams(model, null);
               }
               break;

            case "series":
               {
                  if (!string.IsNullOrEmpty(model.StudyInstanceUID))
                  {
                     var execludeList = new List<string>();
                     execludeList.Add("StudyInstanceUID");

                     url = string.Format("studies/{0}/series", model.StudyInstanceUID)
                         + BuildQueryParams(model, execludeList);
                  }
                  else
                  {
                     Debug.WriteLine("Warning: building query string for a relational series query (optional for qido services)");
                     url = "series" + BuildQueryParams(model, null);
                     //throw new Exception("Series level query requires study instance uid to be present");
                  }
               }
               break;

            case "instance":
               {
                  var execludeList = new List<string>();
                  execludeList.Add("StudyInstanceUID");
                  execludeList.Add("SeriesInstanceUID");

                  url = string.Format("studies/{0}/series/{1}/instances", model.StudyInstanceUID, model.SeriesInstanceUID)
                      + BuildQueryParams(model, execludeList);
               }
               break;

            default:
               {
                  throw new ArgumentException();
               }
         }

         return url;
      }

      internal static string ToWadoRsQueryUrl(WadoDataSetModel model)
      {
         if (string.IsNullOrEmpty(model.StudyInstanceUID) || string.IsNullOrEmpty(model.SeriesInstanceUID) || string.IsNullOrEmpty(model.SOPInstanceUID))
         {
            throw new ArgumentNullException("StudyInstanceUID, SeriesInstanceUID or SOPInstanceUID");
         }

         string url = string.Format("studies/{0}/series/{1}/instances/{2}/", model.StudyInstanceUID, model.SeriesInstanceUID, model.SOPInstanceUID);

         return url;
      }

      internal static string ToWadoRenderedRsQueryUrl(WadoDataSetModel model)
      {
         var url = new StringBuilder();

         if (!string.IsNullOrEmpty(model.StudyInstanceUID))
         {
            url.Append("studies/").Append(model.StudyInstanceUID).Append("/");
            if (!string.IsNullOrEmpty(model.SeriesInstanceUID))
            {
               url.Append("series/").Append(model.SeriesInstanceUID).Append("/");
               if (!string.IsNullOrEmpty(model.SOPInstanceUID))
               {
                  url.Append("instances/").Append(model.SOPInstanceUID).Append("/");
               }
            }
         }
         else
         {
            throw new ArgumentNullException();
         }

         url.Append("Rendered");
         
         return url.ToString();
      }
   }
}
