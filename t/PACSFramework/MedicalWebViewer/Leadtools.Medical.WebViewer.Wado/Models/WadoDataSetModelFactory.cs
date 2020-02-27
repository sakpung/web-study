// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Leadtools.Medical.WebViewer.Wado
{
   internal class WadoDataSetModelFactory
   {
      internal static WadoDataSetModel FromProperties(Dictionary<string, string> prp)
      {
         var model = new WadoDataSetModel();

         foreach (var propertyInfo in model.GetType().GetProperties())
         {
            if (prp.ContainsKey(propertyInfo.Name))
            {
               propertyInfo.SetValue(model, FormatProperty(propertyInfo.Name, prp));
            }
         }

         return model;
      }

      public static string FormatProperty(string prpname, Dictionary<string, string> prp)
      {
         var textprpvalue = string.Empty;

         try
         {
            textprpvalue = prp[prpname];

            if (prpname.Contains("Date"))
            {
               var dt = DateTime.Now;
               if (DateTime.TryParseExact(textprpvalue, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
               {
                  textprpvalue = dt.ToString("MM/dd/yyyy");
               }

               //most likely has time part as well
               var prptime = prpname.Replace("Date", "Time");
               if (prp.ContainsKey(prptime))
               {
                  var timevalue = DateTime.Now;
                  var timetextvalue = prp[prptime].Split('.')[0];
                  if (DateTime.TryParseExact(timetextvalue, "HHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timevalue))
                  {
                     textprpvalue += timevalue.ToString(" hh:mm tt");
                  }
               }
            }
         }
         catch { }

         return textprpvalue;
      }

      public static List<WadoDataSetModel> ReadJsonObjects(Stream stm)
      {
         var tables = JsonObjectReader.ReadJsonObjects(stm, _prp);
         var models = new List<WadoDataSetModel>();

         foreach (var table in tables)
         {
            var model = WadoDataSetModelFactory.FromProperties(table);
            models.Add(model);
         }

         return models;
      }

      const long PatientID = 1048608;
      const long PatientName = 1048592;
      const long PatientSex = 1048640;
      const long PatientBirthDate = 1048624;
      const long StudyDate = 524320;
      const long StudyTime = 524336;
      const long AccessionNumber = 524368;
      const long StudyInstanceUID = 2097165;
      const long StudyDescription = 528432;
      const long NumberOfStudyRelatedSeries = 2101766;
      const long NumberOfStudyRelatedInstances = 2101768;
      const long SeriesDate = 524321;
      const long SeriesTime = 524337;
      const long Modality = 524384;
      const long SeriesNumber = 2097169;
      const long SeriesDescription = 528446;
      const long TransferSyntaxUID = 131088;
      const long SOPClassUID = 524310;
      const long SOPInstanceUID = 524312;
      const long StationName = 528400;
      const long SeriesInstanceUID = 2097166;
      const long InstanceNumber = 2097171;
      const long NumberOfFrames = 2621448;
      const long NumberOfSeriesRelatedInstances = 2101769;

      static Dictionary<string, string> _prp = new Dictionary<string, string>{
         {PatientID.ToString("X8"),                      "PatientID"},
         {PatientName.ToString("X8")                   , "PatientName"},
         {PatientSex.ToString("X8")                    , "PatientSex"},
         {PatientBirthDate.ToString("X8")              , "PatientBirthDate"},
         {StudyDate.ToString("X8")                     , "StudyDate"},
         {StudyTime.ToString("X8")                     , "StudyTime"},
         {AccessionNumber.ToString("X8")               , "AccessionNumber"},
         {StudyInstanceUID.ToString("X8")              , "StudyInstanceUID"},
         {StudyDescription.ToString("X8")              , "StudyDescription"},
         {NumberOfStudyRelatedSeries.ToString("X8")    , "NumberOfStudyRelatedSeries"},
         {NumberOfStudyRelatedInstances.ToString("X8") , "NumberOfStudyRelatedInstances"},
         {SeriesDate.ToString("X8")                    , "SeriesDate"},
         {SeriesTime.ToString("X8")                    , "SeriesTime"},
         {Modality.ToString("X8")                      , "Modality"},
         {SeriesNumber.ToString("X8")                  , "SeriesNumber"},
         {SeriesDescription.ToString("X8")             , "SeriesDescription"},
         {TransferSyntaxUID.ToString("X8")             , "TransferSyntaxUID"},
         {SOPClassUID.ToString("X8")                   , "SOPClassUID"},
         {SOPInstanceUID.ToString("X8")                , "SOPInstanceUID"},
         {StationName.ToString("X8")                   , "StationName"},
         {SeriesInstanceUID.ToString("X8")             , "SeriesInstanceUID"},
         {InstanceNumber.ToString("X8")                , "InstanceNumber"},
         {NumberOfFrames.ToString("X8")                , "NumberOfFrames"},
         {NumberOfSeriesRelatedInstances.ToString("X8"), "NumberOfInstances"}};
   }
}
