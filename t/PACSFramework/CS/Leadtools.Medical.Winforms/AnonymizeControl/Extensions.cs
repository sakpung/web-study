// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Leadtools.Medical.Winforms.Anonymize
{
   internal static class Extensions
   {
      public static void SerializeToXml(this object o, string filename)
      {
         using (Stream file = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
         {
            XmlSerializer s = new XmlSerializer(o.GetType());

            s.Serialize(file, o);
            file.Close();
         }
      }

      public static T DeserializeFromXml<T>(string filename)
      {
         T obj = default(T);

         using (Stream file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None))
         {
            XmlSerializer s = new XmlSerializer(typeof(T));

            obj = (T) s.Deserialize(file);
            file.Close();
         }
         return obj;
      }

      public static AnonymizeScript GetSelectedScript(this ListView listView)
      {
         if (listView.SelectedItems.Count > 0)
         {
            ListViewItem lvi = listView.SelectedItems[0];
            return lvi.Tag as AnonymizeScript;
         }
         return null;
      }

      public static bool CaseInsensitiveContains(this string text, string value, StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
      {
         return text.IndexOf(value, stringComparison) >= 0;
      }
   }
}
