// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Leadtools.Medical.WebViewer.Jobs
{
   public class JobsPersistence
   {
      static public string Save(Object obj)
      {
         StringBuilder sb = new StringBuilder();
         StringWriter sw = new StringWriter(sb);
         XmlSerializer serializer = new XmlSerializer(obj.GetType(), null, new Type[0], null, null);
         serializer.Serialize(sw, obj);
         return sb.ToString();
      }

      static public T Load<T>(string sObject)
      {
         var byteArray = Encoding.Unicode.GetBytes(sObject);
         XmlSerializer serializer = new XmlSerializer(typeof(T));
         T obj = default(T);

         using (var stream = new MemoryStream(byteArray))
         {
            obj = (T)serializer.Deserialize(stream);
         }

         return obj;
      }
   }
}
