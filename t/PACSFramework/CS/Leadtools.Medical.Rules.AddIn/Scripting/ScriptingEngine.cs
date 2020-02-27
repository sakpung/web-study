// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Text;
//using System.Collections.Specialized;
//using System.Collections;

using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Runtime.Remoting;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace Leadtools.Medical.Rules.AddIn.Scripting
{
   /// <summary>
   /// Deletgate for the Completed Event
   /// </summary>
   public delegate void DelegateCompleted(object sender, EventArgs e);

   /// <summary>
   /// Class that enables running of code dynamcially created at runtime.
   /// Provides functionality for evaluating and executing compiled code.
   /// </summary>
   public class ScriptEngine
   {
      /// <summary>
      /// Compiler object used to compile our code
      /// </summary>
      
      protected CodeDomProvider _Compiler = null;

      /// <summary>
      /// Reference to the Compiler Parameter object
      /// </summary>
      private CompilerParameters _Parameters = null;

      public CompilerParameters Parameters
      {
         get { return _Parameters; }
         set { _Parameters = value; }
      }

      /// <summary>
      /// Reference to the final assembly
      /// </summary>
      private Assembly _OutputAssembly = null;

      public Assembly OutputAssembly
      {
         get { return _OutputAssembly; }
         set { _OutputAssembly = value; }
      }

      /// <summary>
      /// The compiler results object used to figure out errors.
      /// </summary>
      protected CompilerResults oCompiled = null;
      protected string cOutputAssembly = null;
      private string _Namespaces = "";

      public string Namespaces
      {
         get { return _Namespaces; }
         set { _Namespaces = value; }
      }

      public StringCollection ReferencedAssemblies
      {
         get
         {
            return Parameters.ReferencedAssemblies;
         }
      }

      private List<string> _ImportedNamespaces = new List<string>();

      public ReadOnlyCollection<string> ImportedNamespaces
      {
         get
         {
            return _ImportedNamespaces.AsReadOnly();
         }
      }

      protected bool lFirstLoad = true;



      /// <summary>
      /// The object reference to the compiled object available after the first method call.
      /// You can use this method to call additional methods on the object.
      /// For example, you can use CallMethod and pass multiple methods of code each of
      /// which can be executed indirectly by using CallMethod() on this object reference.
      /// </summary>
      public object oObjRef = null;

      /// <summary>
      /// If true saves source code before compiling to the cSourceCode property.
      /// </summary>
      public bool lSaveSourceCode = false;

      /// <summary>
      /// Contains the source code of the entired compiled assembly code.
      /// Note: this is not the code passed in, but the full fixed assembly code.
      /// Only set if lSaveSourceCode=true.
      /// </summary>
      public string cSourceCode = "";

      /// <summary>
      /// Line where the code that runs starts
      /// </summary>
      protected int nStartCodeLine = 0;

      /// <summary>
      /// Namespace of the assembly created by the script processor. Determines
      /// how the class will be referenced and loaded.
      /// </summary>
      public string cAssemblyNamespace = "Leadtools.Script";

      /// <summary>
      /// Name of the class created by the script processor. Script code becomes methods in the class.
      /// </summary>
      public string cClassName = "ServerScript";

      /// <summary>
      /// Determines if default assemblies are added. System, System.IO, System.Reflection
      /// </summary>
      public bool lDefaultAssemblies = true;

      protected AppDomain oAppDomain = null;

      private string _ErrorMsg = "";

      public string ErrorMsg
      {
         get { return _ErrorMsg; }
         set { _ErrorMsg = value; }
      }

      public bool bError = false;

      /// <summary>
      /// Path for the support assemblies wwScripting and RemoteLoader.
      /// By default this can be blank but if you're using this functionality
      /// under ASP.Net specify the bin path explicitly. Should include trailing
      /// dash.
      /// </summary>
      //[Description("Path for the support assemblies wwScripting and RemoteLoader. Blank by default. Include trailing dash.")]
      public string cSupportAssemblyPath = "";

      /// <summary>
      /// The scripting language used. CSharp, VB, JScript
      /// </summary>
      public string cScriptingLanguage = "VB";

      /// <summary>
      /// The language to be used by this scripting class. Currently only C# is supported 
      /// with VB syntax available but not tested.
      /// </summary>
      /// <param name="lcLanguage">CSharp or VB</param>
      public ScriptEngine(string lcLanguage)
      {
         SetLanguage(lcLanguage);
      }
      public ScriptEngine()
      {
         SetLanguage("VB");
      }



      /// <summary>
      /// Specifies the language that is used. Supported languages include
      /// CSHARP C# VB
      /// </summary>
      /// <param name="lcLanguage"></param>
      public void SetLanguage(string lcLanguage)
      {
         var providerOptions = new Dictionary<string, string>();
#if (FOR_DOTNET4)
         providerOptions.Add("CompilerVersion", "v4.0");
#else
         providerOptions.Add("CompilerVersion", "v3.5");
#endif
         cScriptingLanguage = lcLanguage;
         if (cScriptingLanguage == "CSharp" || cScriptingLanguage == "C#")
         {
            _Compiler = new CSharpCodeProvider(providerOptions);
            cScriptingLanguage = "CSharp";
         }
         else if (cScriptingLanguage == "VB")
         {
            _Compiler = new VBCodeProvider(providerOptions);
         }
         // else throw(Exception ex);

         _Parameters = new CompilerParameters();
         if (cScriptingLanguage == "VB")
         {
            _Parameters.CompilerOptions = "/optioninfer+";
         }
      }


      /// <summary>
      /// Adds an assembly to the compiled code
      /// </summary>
      /// <param name="lcAssemblyDll">DLL assembly file name</param>
      /// <param name="lcNamespace">Namespace to add if any. Pass null if no namespace is to be added</param>
      public void AddAssembly(string assembly, string nameSpace)
      {
         if (assembly == null && nameSpace == null)
         {
            // *** clear out assemblies and namespaces
            _Parameters.ReferencedAssemblies.Clear();
            _Namespaces = "";
            _ImportedNamespaces.Clear();
            return;
         }

         if (assembly != null)
         {
            if(!_Parameters.ReferencedAssemblies.Contains(assembly.ToLower()))
               _Parameters.ReferencedAssemblies.Add(assembly.ToLower());
         }

         if (nameSpace != null)
         {
            if (!_ImportedNamespaces.Contains(nameSpace.ToLower()))
            {
               if (cScriptingLanguage == "CSharp")
                  _Namespaces = _Namespaces + "using " + nameSpace + ";\r\n";
               else
                  _Namespaces = _Namespaces + "imports " + nameSpace + "\r\n";
               _ImportedNamespaces.Add(nameSpace.ToLower());
            }
         }
      }

      /// <summary>
      /// Adds an assembly to the compiled code.
      /// </summary>
      /// <param name="lcAssemblyDll">DLL assembly file name</param>
      public void AddAssembly(string assembly)
      {
         AddAssembly(assembly, null);
      }

      public void AddAssemblies(params string[] assemblies)
      {
         foreach (string assembly in assemblies)
         {
            AddAssembly(assembly, null);
         }
      }

      public void AddNamespace(string lcNamespace)
      {
         AddAssembly(null, lcNamespace);
      }

      public void AddNamespaces(params string[] namespaces)
      {
         foreach (string n in namespaces)
         {
            AddAssembly(null, n);
         }
      }

      public void AddDefaultAssemblies()
      {
         AddAssembly("System.dll", "System");
         AddNamespace("System.Reflection");
         AddNamespace("System.IO");
      }


      /// <summary>
      /// Executes a complete method by wrapping it into a class.
      /// </summary>
      /// <param name="lcCode">One or more complete methods.</param>
      /// <param name="lcMethodName">Name of the method to call.</param>
      /// <param name="loParameters">any number of variable parameters</param>
      /// <returns></returns>
      public object ExecuteMethod(string lcCode, string lcMethodName, params object[] loParameters)
      {

         if (oObjRef == null)
         {
            if (lFirstLoad)
            {
               if (lDefaultAssemblies)
               {
                  AddDefaultAssemblies();
               }
               //AddAssembly(cSupportAssemblyPath + "RemoteLoader.dll","Westwind.RemoteLoader");
               //AddAssembly(cSupportAssemblyPath + "wwScripting.dll","Westwind.wwScripting");
               lFirstLoad = false;
            }

            StringBuilder sb = new StringBuilder("");

            //*** Program lead in and class header
            sb.Append(_Namespaces);
            sb.Append("\r\n");

            if (cScriptingLanguage == "CSharp")
            {
               // *** Namespace headers and class definition
               sb.Append("namespace " + cAssemblyNamespace + "{\r\npublic class " + cClassName + ":MarshalByRefObject,IRemoteInterface {\r\n");

               // *** Generic Invoke method required for the remote call interface
               sb.Append(
                  "public object Invoke(string lcMethod,object[] parms) {\r\n" +
                  "return GetType().InvokeMember(lcMethod,BindingFlags.InvokeMethod,null,this,parms );\r\n" +
                  "}\r\n\r\n");

               //*** The actual code to run in the form of a full method definition.
               sb.Append(lcCode);

               sb.Append("\r\n} }");  // Class and namespace closed
            }
            else if (cScriptingLanguage == "VB")
            {
               // *** Namespace headers and class definition
               sb.Append("Namespace " + cAssemblyNamespace + "\r\npublic class " + cClassName + "\r\n");
               sb.Append("Inherits MarshalByRefObject\r\nImplements IRemoteInterface\r\n\r\n");

               // *** Generic Invoke method required for the remote call interface
               sb.Append(
                  "Public Overridable Overloads Function Invoke(ByVal lcMethod As String, ByVal Parameters() As Object) As Object _\r\n" +
                  "Implements IRemoteInterface.Invoke\r\n" +
                  "return me.GetType().InvokeMember(lcMethod,BindingFlags.InvokeMethod,nothing,me,Parameters)\r\n" +
                  "End Function\r\n\r\n");

               //*** The actual code to run in the form of a full method definition.
               sb.Append(lcCode);

               sb.Append("\r\n\r\nEnd Class\r\nEnd Namespace\r\n");  // Class and namespace closed
            }

            if (lSaveSourceCode)
            {
               cSourceCode = sb.ToString();
               //MessageBox.Show(cSourceCode);
            }
            CompilerErrorCollection errors = new CompilerErrorCollection();

            if (!CompileAssembly(sb.ToString(),errors))
               return null;

            object loTemp = CreateInstance();
            if (loTemp == null)
               return null;
         }

         return CallMethod(oObjRef, lcMethodName, loParameters);
      }

      /// <summary>
      ///  Executes a snippet of code. Pass in a variable number of parameters
      ///  (accessible via the loParameters[0..n] array) and return an object parameter.
      ///  Code should include:  return (object) SomeValue as the last line or return null
      /// </summary>
      /// <param name="lcCode">The code to execute</param>
      /// <param name="loParameters">The parameters to pass the code</param>
      /// <returns></returns>
      public object ExecuteCode(string lcCode, params object[] loParameters)
      {
         if (cScriptingLanguage == "CSharp")
            return ExecuteMethod("public object ExecuteCode(params object[] Parameters) {" +
                  lcCode +
                  "}",
                  "ExecuteCode", loParameters);
         else if (cScriptingLanguage == "VB")
            return ExecuteMethod("public function ExecuteCode(ParamArray Parameters() As Object) as object\r\n" +
               lcCode +
               "\r\nend function\r\n",
               "ExecuteCode", loParameters);

         return null;
      }

      /// <summary>
      /// Compiles and runs the source code for a complete assembly.
      /// </summary>
      /// <param name="lcSource"></param>
      /// <returns></returns>
      public bool CompileAssembly(string lcSource, CompilerErrorCollection errors)
      {
         //oParameters.GenerateExecutable = false;

         if (oAppDomain == null && cOutputAssembly == null)
            _Parameters.GenerateInMemory = true;
         else if (oAppDomain != null && cOutputAssembly == null)
         {
            // *** Generate an assembly of the same name as the domain
            cOutputAssembly = "lead_" + Guid.NewGuid().ToString() + ".dll";
            _Parameters.OutputAssembly = cOutputAssembly;
         }
         else
         {
            _Parameters.OutputAssembly = cOutputAssembly;
         }

         oCompiled = _Compiler.CompileAssemblyFromSource(_Parameters, lcSource);

         if (oCompiled.Errors.HasErrors)
         {
            bError = true;

            errors.AddRange(oCompiled.Errors);
            // *** Create Error String
            _ErrorMsg = oCompiled.Errors.Count.ToString() + " Errors:";
            for (int x = 0; x < oCompiled.Errors.Count; x++)
               _ErrorMsg = _ErrorMsg + "\r\nLine: " + oCompiled.Errors[x].Line.ToString() + " - " +
                                                 oCompiled.Errors[x].ErrorText;
            return false;
         }

         if (oAppDomain == null)
            _OutputAssembly = oCompiled.CompiledAssembly;

         return true;
      }

      public object CreateInstance()
      {
         if (oObjRef != null)
         {
            return oObjRef;
         }

         // *** Create an instance of the new object
         try
         {
            if (oAppDomain == null)
               try
               {
                  oObjRef = _OutputAssembly.CreateInstance(cAssemblyNamespace + "." + cClassName);
                  return oObjRef;
               }
               catch (Exception ex)
               {
                  bError = true;
                  _ErrorMsg = ex.Message;
                  return null;
               }
            else
            {
               // create the factory class in the secondary app-domain
               RemoteLoaderFactory factory = (RemoteLoaderFactory)oAppDomain.CreateInstance("RemoteLoader", "Leadtools.RemoteLoader.RemoteLoaderFactory").Unwrap();

               // with the help of this factory, we can now create a real 'LiveClass' instance
               oObjRef = factory.Create(cOutputAssembly, cAssemblyNamespace + "." + cClassName, null);

               return oObjRef;
            }
         }
         catch (Exception ex)
         {
            bError = true;
            _ErrorMsg = ex.Message;
            return null;
         }
      }

      public object CallMethod(object loObject, string lcMethod, params object[] loParameters)
      {
         _ErrorMsg = string.Empty;
         try
         {
            if (oAppDomain == null)
               // *** Just invoke the method directly through Reflection
               return loObject.GetType().InvokeMember(lcMethod, BindingFlags.InvokeMethod, null, loObject, loParameters);
            else
            {
               // *** Invoke the method through the Remote interface and the Invoke method
               object loResult;
               try
               {
                  // *** Cast the object to the remote interface to avoid loading type info
                  IRemoteInterface loRemote = (IRemoteInterface)loObject;

                  // *** Indirectly call the remote interface
                  loResult = loRemote.Invoke(lcMethod, loParameters);
               }
               catch (Exception ex)
               {
                  bError = true;
                  _ErrorMsg = ex.Message;
                  return null;
               }
               return loResult;
            }
         }
         catch (Exception ex)
         {
            bError = true;
            _ErrorMsg = ex.Message;
         }
         return null;
      }

      public bool CreateAppDomain(string lcAppDomain)
      {
         if (lcAppDomain == null)
            lcAppDomain = "wwscript";

         AppDomainSetup loSetup = new AppDomainSetup();
         loSetup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;

         oAppDomain = AppDomain.CreateDomain(lcAppDomain, null, loSetup);
         return true;
      }

      public bool UnloadAppDomain()
      {
         if (oAppDomain != null)
            AppDomain.Unload(oAppDomain);

         oAppDomain = null;

         if (cOutputAssembly != null)
         {
            try
            {
               File.Delete(cOutputAssembly);
            }
            catch (Exception) { ;}
         }

         return true;
      }
      public void Release()
      {
         oObjRef = null;
      }

      public void Dispose()
      {
         Release();
         UnloadAppDomain();
      }

      ~ScriptEngine()
      {
         Dispose();
      }
   }
}
