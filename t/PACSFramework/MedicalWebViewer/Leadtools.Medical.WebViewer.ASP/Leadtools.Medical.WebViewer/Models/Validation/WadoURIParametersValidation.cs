// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WadoServices.Errors;
using WadoServices.Models.URI;

namespace WadoServices.Models.Validation
{
   public class WadoURIParametersValidation
   {
      public WadoURIParameters param { get; set; }

      //[SelfValidation(Ruleset = "Initial")]
      public void Initial(/*ValidationResults results*/)
      {
         try
         {
            if (string.IsNullOrEmpty(param.http_Accept))
            {
               throw new WadoInvalidParamException("http_Accept");
            }

            {
               List<Mime.Types> accept_mimes = Mime.ReadMimeList(param.http_Accept, true);

               if (!accept_mimes.Contains(Mime.Types.wildcard) &&
               !accept_mimes.Contains(Mime.Types.application_dicom) &&
               !accept_mimes.Contains(Mime.Types.image_jpeg) &&
               !accept_mimes.Contains(Mime.Types.application_text) &&
               !accept_mimes.Contains(Mime.Types.application_html))
               {
                  throw new WadoInvalidParamException("http_Accept");
               }
            }

            //check object query parameters
            if (string.IsNullOrEmpty(param.studyUID))
               throw new WadoMissingParamException("studyUID");
            if (string.IsNullOrEmpty(param.seriesUID))
               throw new WadoMissingParamException("seriesUID");
            if (string.IsNullOrEmpty(param.objectUID))
               throw new WadoMissingParamException("objectUID");
         }
         catch (System.Exception ex)
         {
            //results.AddResult(new ValidationResult(ex.Message, this, "Wado_URI_Params_Validation", "", null));
            throw;
         }
      }

      //[SelfValidation(Ruleset = "DicomResponse")]
      public void DicomResponse(/*ValidationResults results*/)
      {
         try
         {
            if (param.rows.HasValue)
            {
               throw new WadoInvalidParamException("rows");
            }

            if (param.columns.HasValue)
            {
               throw new WadoInvalidParamException("columns");
            }

            if (param.region.HasValue)
            {
               throw new WadoInvalidParamException("region");
            }

            if (param.frameNumber.HasValue)
            {
               throw new WadoInvalidParamException("frameNumber");
            }

            if (param.windowWidth.HasValue || param.windowWidth.HasValue)//both should be null
            {
               throw new WadoInvalidParamException("windowCenter-windowWidth");
            }

            if (!string.IsNullOrEmpty(param.annotation))
            {
               throw new WadoInvalidParamException("annotation");
            }

            if (!string.IsNullOrEmpty(param.presentationUID) && !string.IsNullOrEmpty(param.presentationSeriesUID))
            {
               throw new WadoInvalidParamException("presentationUID-presentationSeriesUID");
            }
         }
         catch (Exception ex)
         {
            //results.AddResult(new ValidationResult(ex.Message, this, "Wado_URI_Params_Validation", "", null));
            throw;
         }
      }

      //[SelfValidation(Ruleset = "ImageResponse")]
      public void ImageResponse(/*ValidationResults results*/)
      {
         try
         {
            if (param.anonymize.HasValue)
            {
               throw new WadoInvalidParamException("anonymize");
            }

            if (param.windowWidth.HasValue && param.windowWidth.HasValue)
            {
               if (!string.IsNullOrEmpty(param.presentationUID))
               {
                  throw new WadoInvalidParamException("windowCenter-windowWidth-presentationUID");
               }
            }
            else if (param.windowWidth.HasValue || param.windowWidth.HasValue)//both should be null
            {
               throw new WadoInvalidParamException("windowCenter-windowWidth");
            }

            if ((!string.IsNullOrEmpty(param.presentationUID) && string.IsNullOrEmpty(param.presentationSeriesUID)) ||
                (string.IsNullOrEmpty(param.presentationUID) && !string.IsNullOrEmpty(param.presentationSeriesUID)))
            {
               throw new WadoInvalidParamException("presentationUID-presentationSeriesUID");
            }
         }
         catch (Exception ex)
         {
            //results.AddResult(new ValidationResult(ex.Message, this, "Wado_URI_Params_Validation", "", null));
            throw;
         }
      }
   }
}
