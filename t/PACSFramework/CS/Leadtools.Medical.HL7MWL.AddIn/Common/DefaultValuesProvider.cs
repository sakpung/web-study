// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   internal static class DefaultValuesProvider
   {
      private static readonly Dictionary<string, string> _defaults = new Dictionary<string, string>()
      {
         { "StudyInstanceUID", "%UniqueDicom" },
         { "IssuerOfPatientID", "Demo" },
         { "PlacerField2", "%Unique" },
         { "RequestedProcedureID", "%Unique" },
         { "ScheduledProcedureStepID", "%Unique" },
         { "RequestingPhysicianFamilyName", "N/A" },
         { "ReferringPhysicianFamilyName", "N/A" },
         { "RequestingPhysicianGivenName", "N/A" },
         { "CurrentPatientLocation", "Medical" },
         { "RequestedProcedureDescription", "MEDICAL" },
         { "RequestedProcedurePriority", "MED" },
         { "ScheduledProcedureStepLocation", "MEDICAL"},
         { "ScheduledProcedureStepStartDate_Time", "%DateRange.Now"},
         { "ScheduledPerformingPhysicianNameFamilyName", "ReferDrLastName"},
         { "ScheduledPerformingPhysicianNameGivenName", "ReferDrFirstName"},
         { "ScheduledProcedureStepDescription", "MEDICAL"},
         { "MPPSSOPInstanceUID", "%Unique" },
         { "PerformedProcedureStepID", "%Unique" },
         { "PerformedStationAETitle", "MED" },
         { "ScheduledStationAETitle", "MED" },
         { "ScheduledStationAE", "MED" },
         { "PerformedProcedureStepStartDate", "%DicomDateRangeValue.Now" },
         { "PerformedProcedureStepStatus", "IN PROGRESS" },
         { "Modality", "OT" },
         { "PatientSex", "O" },
         { "AdmissionID", "%Unique"}
      };

      static private string resolve(string name)
      {
         if (_defaults.ContainsKey(name))
         {
            var def = _defaults[name];
            if (def[0] != '%')
            {
               return def;
            }
            else if (def == "%Unique")
            {
               return UniqueIdProvider.NewUnique16BytesId();
            }
            else if ( def == "%UniqueDicom")
            {
               return UniqueIdProvider.GenerateDicomUniqueIdentifier();
            }
            else
            {
               System.Diagnostics.Debug.Assert(false);
            }
         }
         return string.Empty;
      }

      static private List<string> resolveListString(string name)
      {
         var resolved = resolve(name);

         if (!string.IsNullOrEmpty(resolved))
         {
            return new List<string> { resolved };
         }
         return null;
      }      

      static private DateTime? resolveDateTime(string name)
      {
         if (_defaults.ContainsKey(name))
         {
            var def = _defaults[name];
            if (def == "%DateTime.Now")
            {
               return DateTime.Now;
            }
            else
            {
               System.Diagnostics.Debug.Assert(false);
            }
         }

         return null;
      }

      static private Leadtools.Dicom.Common.DataTypes.DateRange resolveDateRange(string name)
      {
         if (_defaults.ContainsKey(name))
         {
            var def = _defaults[name];
            if (def == "%DateRange.Now")
            {
               var dr = new Leadtools.Dicom.Common.DataTypes.DateRange();
               dr.StartDate = DateTime.Now;
               dr.EndDate = DateTime.Now;
               return dr;
            }
            else
            {
               System.Diagnostics.Debug.Assert(false);
            }
         }

         return null;
      }

      static private Leadtools.Dicom.DicomDateRangeValue? resolveDicomDateRange(string name)
      {
         if (_defaults.ContainsKey(name))
         {
            var def = _defaults[name];
            if (def == "%DicomDateRangeValue.Now")
            {
               var now = DateTime.Now;
               var dv = new Leadtools.Dicom.DicomDateValue(now.Year, now.Month, now.Day);
               var dr = new Leadtools.Dicom.DicomDateRangeValue(Dicom.DicomRangeType.None, dv, dv);
               
               return dr;
            }
            else
            {
               System.Diagnostics.Debug.Assert(false);
            }
         }

         return null;
      }

      static public void Visit(object obj)
      {
         var prps = obj.GetType().GetProperties();

         foreach (var prp in prps)
         {
            if (prp.PropertyType == typeof(string))
            {
               if (string.IsNullOrEmpty((string)prp.GetValue(obj, null)))
               {
                  var def = resolve(prp.Name);
                  if (!string.IsNullOrEmpty(def))
                  {
                     prp.SetValue(obj, def);
                  }
               }
            }
            else if (prp.PropertyType == typeof(DateTime?))
            {               
               if (null==prp.GetValue(obj, null))
               {
                  var def = resolveDateTime(prp.Name);
                  if (def.HasValue)
                  {
                     prp.SetValue(obj, def.Value);
                  }
               }
            }
            else if(prp.PropertyType == typeof(Leadtools.Dicom.Common.DataTypes.DateRange))
            {
               var dr = prp.GetValue(obj, null) as Leadtools.Dicom.Common.DataTypes.DateRange;
               if (null == dr)
               {
                  var def = resolveDateRange(prp.Name);
                  if (def!=null)
                  {
                     prp.SetValue(obj, def);
                  }
               }
            }
            else if (prp.PropertyType == typeof(Leadtools.Dicom.DicomDateRangeValue?))
            {
               if (null == prp.GetValue(obj, null))
               {
                  var def = resolveDicomDateRange(prp.Name);
                  if (def.HasValue)
                  {
                     prp.SetValue(obj, def.Value);
                  }
               }
            }    
            else if(prp.PropertyType == typeof(List<string>))
            {
               if (null == prp.GetValue(obj, null))
               {
                  var def = resolveListString(prp.Name);
                  if (def!=null)
                  {
                     prp.SetValue(obj, def);
                  }
               }
            }
         }
      }
   }

   internal static class UniqueIdProvider
   {
      //public static UInt64 GetUInt64HashCode()
      //{
      //   byte[] byteContents = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString());
      //   SHA256 hash = SHA256.Create();
      //   byte[] hashText = hash.ComputeHash(byteContents);
      //   var hashCodeStart = BitConverter.ToUInt64(hashText, 0);
      //   var hashCodeMedium = BitConverter.ToUInt64(hashText, 8);
      //   var hashCodeEnd = BitConverter.ToUInt64(hashText, 24);
      //   var hashCode = hashCodeStart ^ hashCodeMedium ^ hashCodeEnd;
      //   return (hashCode);
      //}

      public static UInt64 GetUInt64HashCode()
      {
         var guid = Guid.NewGuid().ToString().Replace("-", "");
         byte[] buf = Encoding.ASCII.GetBytes(guid);
         var hashCodeStart = BitConverter.ToUInt64(buf, 0);
         var hashCodeMedium = BitConverter.ToUInt64(buf, 8);
         var hashCodeEnd = BitConverter.ToUInt64(buf, 24);
         var hashCode = hashCodeStart ^ hashCodeMedium ^ hashCodeEnd;
         return (hashCode);
      }
      public static string NewUnique16BytesId()
      {
         return GetUInt64HashCode().ToString("X2");
      }

      private static String _prevTime;
      private static String _leadRoot = null;
      private static Object _lock = new object();
      private static int _count = 0;
      private const int _maxCount = int.MaxValue;

      // UID is comprised of the following components
      // {LEAD Root}.{ProcessID}.{date}.{time}.{fraction seconds}.{counter}
      // {18 +      1 + 10 +    1 + 8 +1 + 6+ 1 + 7              + 10}
      // Total max length is 63 characters
      public static string GenerateDicomUniqueIdentifier()
      {
         try
         {
            lock (_lock)
            {
               // yyyy     four digit year
               // MM       month from 01 to 12
               // dd       01 to 31
               // HH       hours using a 24-hour clock form 00 to 23
               // mm       minute 00 to 59
               // ss       second 00 to 59
               // fffffff  ten millionths of a second
               const string dateFormatString = "yyyyMMdd.HHmmss.fffffff";

               string sUidRet = "";
               if (_leadRoot == null)
               {
                  StringBuilder sb = new StringBuilder();

                  sb.Append("1.2.840.114257.1.1");

                  // Process Id
                  sb.AppendFormat(".{0}", (uint)Process.GetCurrentProcess().Id);

                  _leadRoot = sb.ToString();

                  _prevTime = DateTime.UtcNow.ToString(dateFormatString);
               }

               StringBuilder uid = new StringBuilder();
               uid.Append(_leadRoot);

               String time = DateTime.UtcNow.ToString(dateFormatString);
               if (time.Equals(_prevTime))
               {
                  if (_count == _maxCount)
                     throw new Exception("GenerateDicomUniqueIdentifier error -- max count reached.");

                  _count++;
               }
               else
               {
                  _count = 1;
                  _prevTime = time;
               }

               uid.AppendFormat(".{0}.{1}", time, _count);

               sUidRet = uid.ToString();

               // This should not happen
               if (sUidRet.Length > 64)
                  sUidRet = sUidRet.Substring(0, 64);

               return sUidRet;
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
   }
}
