// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using Leadtools.Dicom;
using Leadtools.Logging.Medical;
using Leadtools.Logging;

namespace Leadtools.Medical.PatientUpdater.AddIn
{
    public static class Extensions
    {
       public static void Check(this ListView listview, bool check)
       {
          if(listview == null)
             return;

          foreach(ListViewItem item in listview.Items)
          {
             item.Checked = check;
          }
       }

       public static string ToXml(this object value, params Type[] extraTypes)
       {
          XmlSerializer s = new XmlSerializer(value.GetType(), extraTypes);

          using (StringWriter writer = new StringWriter())
          {
             s.Serialize(writer, value);
             return writer.ToString();
          }
       }

       public static T FromXml<T>(this string value, params Type[] extraTypes)
       {
          XmlSerializer s = new XmlSerializer(typeof(T), extraTypes);

          using (StringReader reader = new StringReader(value))
          {
             object obj = s.Deserialize(reader);
             return (T)obj;
          }
       }

       public static void SystemMessage(this Logger logger, LogType type, string description, string aetitle)
       {
          try
          {
             logger.Log(Module.Source, aetitle, string.Empty, -1, string.Empty, string.Empty,
                        -1, DicomCommandType.Undefined, DateTime.Now, type,
                        MessageDirection.None, description, null, null);
          }
          catch (Exception exception)
          {
             logger.Exception(Module.Source, exception);
          }
       } 
    }
}
