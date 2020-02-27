// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using Leadtools.Dicom;
using Leadtools;
using Leadtools.Codecs;
using System.IO;
using Leadtools.ImageProcessing;
using CSDicomDirLinqDemo.UI;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSDicomDirLinqDemo.Utils
{
    public static class Extensions
    {
        public static string ToHtml(this object list, string tableSyle, string headerStyle, string rowStyle, string alternateRowStyle)
        {
            var result = new StringBuilder();
            Type type = list.GetType();

            if (String.IsNullOrEmpty(tableSyle))
            {
                result.Append("<table id=\"" + type.Name + "\" >");
            }
            else
            {
                result.Append("<table id=\"" + type.Name + "Table\" class=\"" + tableSyle + "\">");
            }

            int i = 0;
          
            foreach (PropertyInfo p in type.GetProperties())
            {
                object value = p.GetValue(list, null);
                IEnumerable enumerable = value as IEnumerable;


                if (!String.IsNullOrEmpty(rowStyle) && !String.IsNullOrEmpty(alternateRowStyle))
                {
                    result.AppendFormat("<tr class=\"{0}\">", i % 2 == 0 ? rowStyle : alternateRowStyle);
                }
                else
                    result.AppendFormat("<tr>");
                result.AppendFormat("<td><b>{0}</b></td>", p.Name);

                if (enumerable != null && p.PropertyType!=typeof(string))
                {
                    StringBuilder strList = new StringBuilder();

                    foreach (object o in enumerable)
                    {
                        bool isString = o.GetType() == typeof(string);

                        if (isString && o.ToString().Length>0)
                        {
                            if (strList.Length == 0)
                                strList.Append(o.ToString());
                            else
                                strList.AppendFormat(",{0}", o);
                        }
                        else
                        {
                            if (strList.Length > 0)
                            {
                                result.Append("<td>");
                                result.Append(strList.ToString());
                                result.Append("</td>");
                                strList.Length = 0;
                            }

                            if (!isString)
                            {
                                result.Append("<td>");
                                result.AppendFormat("{0}", ToHtml(o, tableSyle, headerStyle, rowStyle, alternateRowStyle));
                                result.Append("</td>");
                            }
                        }                        
                    }
                }
                else
                {
                    if (value != null && value.GetType().IsClass && value.GetType() != typeof(string))
                    {
                        result.AppendFormat("<td>{0}</td>", ToHtml(value, tableSyle, headerStyle, rowStyle, alternateRowStyle));
                    }
                    else
                    {
                        if (p.Name.ToLower() == "patientid")
                        {
                            result.AppendFormat("<td><a href=\"patientid={0}\">{0}</a></td>", value ?? String.Empty);
                        }
                        else if (p.Name.ToLower() == "studyinstanceuid")
                        {
                            result.AppendFormat("<td><a href=\"studyinstanceuid={0}\">{0}</a></td>", value ?? String.Empty);
                        }
                        else if (p.Name.ToLower() == "seriesinstanceuid")
                        {
                            result.AppendFormat("<td><a href=\"seriesinstanceuid={0}\">{0}</a></td>", value ?? String.Empty);
                        }
                        else if (p.Name.ToLower() == "sopinstanceuid")
                        {
                            result.AppendFormat("<td><a href=\"sopinstanceuid={0}\">{0}</a></td>", value ?? String.Empty);
                        }
                        else if (p.Name.ToLower() == "referencedsopinstanceuidinfile")
                        {
                            result.AppendFormat("<td><a href=\"referencedsopinstanceuidinfile={0}\">{0}</a></td>", value ?? String.Empty);
                        }
                        else if (p.Name.ToLower() == "referencedfileid")
                        {
                            string img = EmbedImage(LinqCompiler.Directory + value);

                            if (!string.IsNullOrEmpty(img) && MainForm.ViewThumbnails)
                            {
                                result.AppendFormat("<td><a href=\"referencedfileid={0}\">{1}&nbsp;&nbsp;<em>{2}</emp></a></td>", LinqCompiler.Directory + value, img, value);
                            }
                            else
                                result.AppendFormat("<td><a href=\"referencedfileid={0}\">{0}</a></td>", value ?? String.Empty);
                        }
                        else
                            result.AppendFormat("<td>{0}</td>", value ?? String.Empty);
                    }
                }
                result.AppendFormat("</tr>");
                i++;
            }            
            result.Append("</table>");
            return result.ToString();
        }

        private static string EmbedImage(string file)
        {            
            return "<img src=\"http://localhost:" + MainForm.Port + "/?file=" + file + "\"/></br>";
        }

        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();

            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

    }
}
