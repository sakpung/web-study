// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using Leadtools.Dicom;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.IO;

namespace CSDicomDirLinqDemo.Utils
{
    public class LinqCompiler
    {
        public static string Directory = string.Empty;
        public static int DefaultLines = 13;
        private static string _Class = @" using System;
                                          using System.Linq;
                                          using Leadtools.Dicom;
                                          using Leadtools.Dicom.Common.DataTypes;
                                          using Leadtools.Dicom.Common.Linq.BasicDirectory;

                                          namespace LinqScript
                                          {
                                              public class LinqCompiler
                                              {
                                                 public object GetResults(DicomDataSet ds)
                                                 {
                                                    var result = <code>;

                                                    return result;
                                                 }
                                              }
                                          }";
        private static string _StyleSheet = @"<style type = ""text/css""> .tableStyle{border: solid 2 black;} 
                                       th.header{ background-color:#FF3300} tr.rowStyle { background-color:#eee; 
                                       border: solid 1 black; } tr.alternate { background-color:#fff; 
                                       border: solid 1 black;}</style>";

        private static CodeDomProvider _Compiler = null;
        private static CompilerParameters _Parameters = new CompilerParameters();

        static LinqCompiler()
        {
           string dir = new FileInfo(Assembly.GetEntryAssembly().Location).DirectoryName + @"\";
#if FOR_DOTNET4
           Dictionary<string, string> options = new Dictionary<string, string>
            { 
                { "CompilerVersion", "v4.0" }
            };
#else
           Dictionary<string, string> options = new Dictionary<string, string>
            { 
                { "CompilerVersion", "v3.5" }
            };
#endif

            _Compiler = new CSharpCodeProvider(options);
            _Parameters.ReferencedAssemblies.Add("System.dll");
            _Parameters.ReferencedAssemblies.Add("System.Core.dll"); 
            _Parameters.ReferencedAssemblies.Add(dir + "Leadtools.dll");
            _Parameters.ReferencedAssemblies.Add(dir + "Leadtools.Dicom.dll");
            _Parameters.ReferencedAssemblies.Add(dir + "Leadtools.Dicom.Common.dll");            
            _Parameters.GenerateInMemory = true;
        }

        public static string Execute(DicomDataSet ds, string code,string directory, out bool hasErrors,out int count)
        {
            string script = _Class.Replace("<code>", code);
            CompilerResults results = _Compiler.CompileAssemblyFromSource(_Parameters, script);
            Assembly assembly = null;

            count = 0;
            hasErrors = false;
            Directory = directory;
            if (results.Errors.HasErrors)
            {
                foreach (CompilerError error in results.Errors)
                {
                    string message = string.Format("{0} ({1},{2})", error.ErrorText,error.Line - DefaultLines + 1, error.Column);

                    MessageBox.Show(message);
                }
                hasErrors = true;
                return null;
            }

            assembly = results.CompiledAssembly;
            object o = assembly.CreateInstance("LinqScript.LinqCompiler");

            try
            {
                IQueryable query = o.GetType().InvokeMember("GetResults", BindingFlags.InvokeMethod, null, o, new object[] { ds }) as IQueryable;

                return ConvertToHtml(query,out count);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        private static string ConvertToHtml(IQueryable query,out int count)
        {
            StringWriter sw = new StringWriter();

            count = 0;
            if (query != null)
            {
                foreach (object item in query)
                {
                    count++;
                    Application.DoEvents();
                    sw.Write(item.ToHtml("tableStyle", string.Empty, "rowStyle", "alternate"));
                    sw.Write("<BR>");
                }                
            }

            return _StyleSheet + sw.ToString();
        }
    }
}
