// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;
using Leadtools.Logging.Medical;
using Leadtools.Logging;
using System.Reflection.Emit;
using System.Reflection;
using System.IO;
using ScintillaNET;
using System.CodeDom.Compiler;
using Leadtools.Medical.Rules.AddIn.Scripting;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Leadtools.Dicom.AddIn;
using System.Threading;

namespace Leadtools.Medical.Rules.AddIn
{
   public static class Extensions
   {
      /// <summary>
      /// Sends a system message.
      /// </summary>
      /// <param name="logger">The logger.</param>
      /// <param name="type">The type.</param>
      /// <param name="description">The description.</param>
      /// <param name="aetitle">The aetitle.</param>
      /// <param name="dataset">The dataset.</param>
      /// <param name="customInformation">The custom information.</param>
      public static void SystemMessage(this Logger logger, LogType type, string description, string aetitle, DicomDataSet dataset, SerializableDictionary<string, object> customInformation)
      {
         try
         {
            string message = string.Format("[{0}] {1}", Module.Source, description);

            logger.Log(Module.Source, aetitle, string.Empty, -1, string.Empty, string.Empty,
                       -1, DicomCommandType.Undefined, DateTime.Now, type,
                       MessageDirection.None, message, dataset, customInformation);
         }
         catch (Exception exception)
         {
            logger.Exception(Module.Source, exception);
         }
      }

      /// <summary>
      /// Sends a system message.
      /// </summary>
      /// <param name="logger">The logger.</param>
      /// <param name="type">The type.</param>
      /// <param name="description">The description.</param>
      /// <param name="aetitle">The aetitle.</param>
      public static void SystemMessage(this Logger logger, LogType type, string description, string aetitle)
      {
         try
         {
            string message = string.Format("[{0}] {1}", Module.Source, description);

            logger.Log(Module.Source, aetitle, string.Empty, -1, string.Empty, string.Empty,
                       -1, DicomCommandType.Undefined, DateTime.Now, type,
                       MessageDirection.None, message, null, null);
         }
         catch (Exception exception)
         {
            logger.Exception(Module.Source, exception);
         }
      }

      public static void SystemException(this Logger logger, string aetitle, Exception e)
      {
         try
         {
            string message = string.Format("[{0}] {1}",Module.Source, string.Concat(e.GetAllMessages().Select(ex => ex.Message + @"\r\n")));

            logger.Log(Module.Source, aetitle, string.Empty, -1, string.Empty, string.Empty,
                       -1, DicomCommandType.Undefined, DateTime.Now, LogType.Error,
                       MessageDirection.None, message, null, null);
         }
         catch (Exception exception)
         {
            logger.Exception(Module.Source, exception);
         }
      }

      /// <summary>
      /// Creates a dynamic method from a MethodInfo object.
      /// </summary>
      /// <param name="method">The method to create a dynamic method for.</param>
      /// <returns>A DynamicMethod that can be used to invoke the method.</returns>
      /// <remarks>Using a DynamicMethod gives use faster invocation than using MethodInfo.Invoke.</remarks>
      public static DynamicMethod CreateDynamicMethod(this MethodInfo method)
      {
         int offset = (method.IsStatic ? 0 : 1);
         var parameters = method.GetParameters();
         int size = parameters.Length + offset;
         Type[] types = new Type[size];
         if (offset > 0) types[0] = method.DeclaringType;

         for (int i = offset; i < size; i++)
         {
            types[i] = parameters[i - offset].ParameterType;
         }

         DynamicMethod dynamicMethod = new DynamicMethod("NonVirtualInvoker_" + method.Name, method.ReturnType, types, method.DeclaringType);
         ILGenerator il = dynamicMethod.GetILGenerator();

         for (int i = 0; i < types.Length; i++) 
            il.Emit(OpCodes.Ldarg, i);

         il.EmitCall(OpCodes.Call, method, null);
         il.Emit(OpCodes.Ret);
         return dynamicMethod;
      }
     
      public static IEnumerable<Exception> GetAllMessages(this Exception exception)
      {
         Exception ex = exception;

         while (ex != null)
         {
            yield return ex;
            ex = ex.InnerException;
         }
      }

      public static string FormatWith(this string format, params object[] args)
      {
          if (format == null)
              throw new ArgumentNullException("format");

          return string.Format(format, args);
      }
   }

   /// <summary>
   /// Extension methods that make calling the *_at functions easier.  For instance you can schedule a move with the following
   /// syntax: move_at(patient,"PatientId", 3.Minutes().FromNow(),"ServerAE")
   /// </summary>
   public static class TimeExtensions
   {
      public static TimeSpan Minutes(this int minutes)
      {
         return new TimeSpan(0, minutes, 0);
      }

      public static TimeSpan Minute(this int minutes)
      {
         return Minutes(minutes);
      }

      public static TimeSpan Seconds(this int seconds)
      {
         return new TimeSpan(0, 0, seconds);
      }

      public static TimeSpan Second(this int seconds)
      {
         return Seconds(seconds);
      }

      public static TimeSpan Milliseconds(this int milliseconds)
      {
         return TimeSpan.FromMilliseconds(milliseconds);
      }

      public static TimeSpan Hours(this int hours)
      {
         return new TimeSpan(hours, 0, 0);
      }

      public static TimeSpan Hour(this int hours)
      {
         return Hours(hours);
      }

      public static DateTimeOffset FromNow(this TimeSpan span)
      {
         return DateTime.Now + span;
      }

       public static string ToReadableString(this TimeSpan span)
       {
          return string.Join(", ", span.GetReadableStringElements().Where(str => !string.IsNullOrEmpty(str)).ToArray());
       }

       public static string ToReadableString(this DateTimeOffset offset)
       {
           TimeSpan span = TimeSpan.FromTicks(offset.Ticks);

           return span.ToReadableString();
       }

       private static IEnumerable<string> GetReadableStringElements(this TimeSpan span)
       {
          yield return GetDaysString((int)Math.Floor(span.TotalDays));
          yield return GetHoursString(span.Hours);
          yield return GetMinutesString(span.Minutes);
          yield return GetSecondsString(span.Seconds);
          yield return GetMilliSecondsString(span.Milliseconds);
       }

       private static string GetDaysString(int days)
       {
          if (days == 0)
             return string.Empty;

          if (days == 1)
             return "1 day";

          return string.Format("{0:0} days", days);
       }

       private static string GetHoursString(int hours)
       {
          if (hours == 0)
             return string.Empty;

          if (hours == 1)
             return "1 hour";

          return string.Format("{0:0} hours", hours);
       }

       private static string GetMinutesString(int minutes)
       {
          if (minutes == 0)
             return string.Empty;

          if (minutes == 1)
             return "1 minute";

          return string.Format("{0:0} minutes", minutes);
       }

       private static string GetSecondsString(int seconds)
       {
          if (seconds == 0)
             return string.Empty;

          if (seconds == 1)
             return "1 second";

          return string.Format("{0:0} seconds", seconds);
       }
       private static string GetMilliSecondsString(int ms)
       {
          if (ms == 0)
             return string.Empty;

          if (ms == 1)
             return "1 ms";

          return string.Format("{0:0} ms", ms);
       }

       public static string ToTitleCase(this string s)
       {
          return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
       }        
   }

   public static class DataSetExtensions
   {
      private static ThreadSafeDictionary<long, DicomTag> Tags = new ThreadSafeDictionary<long, DicomTag>();

      public static DicomDataSet Copy(this DicomDataSet dataset,string tempDirectory)
      {
         DicomDataSet copy = null;

         if (dataset == null)
            return copy;

         copy = new DicomDataSet(tempDirectory);
         copy.Copy(dataset, null, null);         
         return copy;
      }

      public static object GetElementValue(this DicomDataSet ds, long tag, bool list)
      {
         DicomVRType vr = DicomVRType.UN;

         if (Tags.ContainsKey(tag))
         {
            vr = Tags[tag].VR;
         }
         else
         {
            DicomTag dt = DicomTagTable.Instance.Find(tag);

            if (dt != null)
            {
               vr = dt.VR;
               Tags.Add(tag, dt);
            }
         }

         switch (vr)
         {
            case DicomVRType.AE:
            case DicomVRType.CS:
            case DicomVRType.LO:
            case DicomVRType.LT:
            case DicomVRType.SH:
            case DicomVRType.ST:
            case DicomVRType.UI:
            case DicomVRType.UT:
            case DicomVRType.PN:
               if (list && ds.GetCount(tag) > 0)
                  return ds.GetValue<List<string>>(tag, null);
               return ds.GetValue<string>(tag, string.Empty);
            case DicomVRType.FL:
               if (list && ds.GetCount(tag) > 0)
                  return ds.GetValue<List<float>>(tag, null);
               return ds.GetValue<float?>(tag, null);
            case DicomVRType.OW:
            case DicomVRType.SS:
            case DicomVRType.US:
               if (list && ds.GetCount(tag) > 0)
                  return ds.GetValue<List<short>>(tag, null);
               return ds.GetValue<short?>(tag, null);
            case DicomVRType.DS:
            case DicomVRType.FD:
               if (list && ds.GetCount(tag) > 0)
                  return ds.GetValue<List<double>>(tag, null);
               return ds.GetValue<double?>(tag, null);
            case DicomVRType.AT:
            case DicomVRType.IS:
               if (list && ds.GetCount(tag) > 0)
                  return ds.GetValue<List<int>>(tag, null);
               return ds.GetValue<int?>(tag, null);
            case DicomVRType.SL:
            case DicomVRType.UL:
               if (list && ds.GetCount(tag) > 0)
                  return ds.GetValue<List<long>>(tag, null);
               return ds.GetValue<long?>(tag, null);
            case DicomVRType.DA:
               if (list && ds.GetCount(tag) > 0)
                  return ds.GetValue<List<DateTime>>(tag, null);
               return ds.GetValue<DateTime?>(tag, null);
         }

         return null;
      }

      public static int GetCount(this DicomDataSet ds, long tag)
      {
         DicomElement element = ds.FindFirstElement(null, tag, false);

         if (element != null)
         {
            return ds.GetElementValueCount(element);
         }

         return 0;
      }

      public static string ToDisplay(this string[] array)
      {
          //
          // Use string Join to concatenate the string elements.
          //
          string result = string.Join(".", array);

          return result;
      }
   }      
}
