// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Leadtools.Medical.Rules.AddIn;
using System.Diagnostics;
using Leadtools.Medical.Winforms;
using System.Reflection;
using System.Reflection.Emit;
using Leadtools.Logging;
using Leadtools.Dicom.AddIn;
using System.Text.RegularExpressions;
using System.CodeDom.Compiler;

namespace Leadtools.Medical.Rules.AddIn.Scripting
{
   /// <summary>
   /// Responsible for create a script engine and building the valid VB.NET code from the user provided script.
   /// </summary>
   public class ScriptProcessor
   {
      private string _RuleDirectory;
      private string _ServerDirectory;      
      private ThreadSafeDictionary<ServerEvent, ThreadSafeDictionary<ServerRule, ScriptObject>> _Delegates = new ThreadSafeDictionary<ServerEvent, ThreadSafeDictionary<ServerRule, ScriptObject>>();
      private Regex _MethodFinder = new Regex(@"^[\s]*(?:(Public|Private)[\s]+(?:[_][\s]*[\n\r]+)?)?(Function|Sub)[\s]+(?:[_][\s]*[\n\r]+)?([a-zA-Z][\w]{0,254})(?:[\s\n\r_]*\((?:[\s\n\r_]*([a-zA-Z][\w]{0,254})[,]?[\s]*)*\))?", RegexOptions.Multiline | RegexOptions.IgnoreCase);

      #region Script Definition

      /// <summary>
      /// The script header.  Defines the namespace and class as well as the beginning definition
      ///   of the process function.
      /// </summary>
      private string _ScriptHeader = @"   Namespace Leadtools.Script
                                          Public class ServerScript
                                             Public Sub Process";
      /// <summary>
      /// The script footer.  Defines the closing sub for the user defined script as well as maintains 
      ///    a place to add additional script functions.
      /// </summary>
      private string _ScriptFooter = @"      End Sub
                                                {0}                                                
                                          End Class
                                      End Namespace";
      /// <summary>
      /// Additional functions added that are available for the script to access.
      /// </summary>
      private string _Additional = @"Public Sub route(dataset as DicomDS, ParamArray aetitles As String())
                                        CommunicationActions.route_dataset_to(dataset.Copy(),aetitles)
                                     End Sub
                                     
                                     Public Sub route(dataset as DicomDS, aetitle as String, ip as String, port as Integer)
                                        CommunicationActions.route_dataset_to(dataset.Copy(),aetitle,ip,port)
                                     End Sub

                                     Public Function route_at(dataset as DicomDS, time as DateTimeOffset, ParamArray aetitles As String()) As Job
                                        Return CommunicationActions.route_dataset_to_at(dataset.Copy(),time,aetitles)
                                     End Function
                                     
                                     Public Function route_at(dataset as DicomDS, time as DateTimeOffset, aetitle as String, ip as String, port as Integer) As Job
                                        Return CommunicationActions.route_dataset_to_at(dataset.Copy(),time,aetitle,ip,port)
                                     End Function

                                     Public Sub route_with_retry(dataset as DicomDS, numRetries as Integer, timeout as Integer, ParamArray aetitles As String())
                                        CommunicationActions.route_dataset_with_retry_to(dataset.Copy(),numRetries, timeout, aetitles)
                                     End Sub                                      

                                     Public Sub route_with_retry(dataset as DicomDS, aetitle as String, ip as String, port as Integer, numRetries as Integer, timeout as Integer)
                                        CommunicationActions.route_dataset_with_retry_to(dataset.Copy(),aetitle,ip, port, numRetries, timeout)
                                     End Sub                                                

                                     Public Function route_at_with_retry(dataset as DicomDS, time as DateTimeOffset, numRetries as Integer, retryTimeout as Integer, ParamArray aetitles As String()) As Job
                                        Return CommunicationActions.route_dataset_with_retry_to_at(dataset.Copy(),time, numRetries, retryTimeout, aetitles)
                                     End Function
                                  
                                     Public Function route_at_with_retry(dataset as DicomDS, aetitle as String, ip as String, port as Integer, time as DateTimeOffset, numRetries as Integer, retryTimeout as Integer) As Job
                                        Return CommunicationActions.route_dataset_with_retry_to_at(dataset.Copy(),aetitle,ip,port, time,numRetries, retryTimeout)
                                     End Function    
                                
                                     Public Sub move(type As MoveType, id As String, ParamArray aetitles As String())
                                        CommunicationActions.move(type, id,aetitles)
                                     End Sub                                                                                                          

                                     Public Function move_at(type As MoveType, id As String, time As DateTimeOffset, ParamArray aetitles As String()) As Job
                                        Return CommunicationActions.move_at(type, id, time, aetitles)
                                     End Function

                                     Public Sub move_with_retry(type As MoveType, id As String, numRetries as Integer, timeout as Integer, ParamArray aetitles As String())
                                        CommunicationActions.move_with_retry(type, id, numRetries, timeout, aetitles)
                                     End Sub

                                     Public Function move_at_with_retry(type As MoveType, id As String, time As DateTimeOffset, numRetries As Integer, retryTimeout As Integer, ParamArray aetitles As String()) As Job
                                       Return CommunicationActions.move_at_with_retry(type,id,time,numRetries,retryTimeout,aetitles)
                                     End Function

                                     Public Function find_job(jobid as string) as Job
                                        Return SchedulerActions.find_job(jobid)
                                     End Function

                                     Public Sub get_dataset(SOPInstanceUID as string, getCallback as Action(of DicomDS, String, String, String))
                                        ScriptUtils.get_dataset(SOPInstanceUID, getCallback, 0, 0)
                                     End Sub 

                                     Public Sub get_dataset(SOPInstanceUID as string, getCallback as Action(of DicomDS, String, String, String), numRetries as Integer, retryInterval as Integer)
                                        ScriptUtils.get_dataset(SOPInstanceUID, getCallback, numRetries, retryInterval)
                                     End Sub                                      

                                     Public Function make_tag(Group As Integer, Element As Integer) As Long
	                                       Return ScriptUtils.MakeTag(Group,Element)
                                     End Function

                                     Public Sub warning_log(message as string)
                                        Logger.Global.SystemMessage(LogType.Warning,message,string.Empty)
                                     End Sub 

                                     Public Sub info_log(message as string)
                                        Logger.Global.SystemMessage(LogType.Information,message,string.Empty)
                                     End Sub

                                     Public Sub audit_log(message as string)
                                        Logger.Global.SystemMessage(LogType.Audit,message,string.Empty)
                                     End Sub

                                     Public Sub debug_log(message as string)
                                        Logger.Global.SystemMessage(LogType.Debug,message,string.Empty)
                                     End Sub

                                     Public Sub error_log(message as string)
                                        Logger.Global.SystemMessage(LogType.Error,message,string.Empty)
                                     End Sub
                                    
                                     Public ReadOnly Property DataCache() as System.Web.Caching.Cache
                                          Get
                                             Return ScriptUtils.Cache
                                          End Get
                                     End Property
                                     Public ReadOnly Property Patient() as MoveType
                                          Get
                                             Return MoveType.Patient
                                          End Get
                                     End Property                                   
                                     Public ReadOnly Property Study() as MoveType
                                          Get
                                             Return MoveType.Study
                                          End Get
                                     End Property
                                     Public ReadOnly Property Series() as MoveType
                                          Get
                                             Return MoveType.Series
                                          End Get
                                     End Property

                                     Public ReadOnly Property Instance() as MoveType
                                          Get
                                             Return MoveType.Instance
                                          End Get
                                     End Property";                                             


      #endregion

      public ScriptProcessor(string ruleDirectory, string serverDirectory)
      {                 
         _RuleDirectory = ruleDirectory;
         _ServerDirectory = serverDirectory;                  
      }

      public ScriptProcessor(string serverDirectory) : this(string.Empty,serverDirectory)
      {         
      }

      public void LoadScripts()
      {
         _Delegates.Clear();
         Logger.Global.SystemMessage(LogType.Information, "Loading scripts", string.Empty);
         if (!string.IsNullOrEmpty(_RuleDirectory))
         {
            foreach (string file in Directory.GetFiles(_RuleDirectory, "*.rule", SearchOption.AllDirectories))
            {
               try
               {
                  ServerRule rule = RuleEditorPresenter.LoadRule<ServerRule>(file);

                  if (rule.Script.Length > 0)
                  {
                     if(!_Delegates.ContainsKey(rule.ServerEvent))
                        _Delegates.Add(rule.ServerEvent, new ThreadSafeDictionary<ServerRule, ScriptObject>());
                     _Delegates[rule.ServerEvent].Add(rule, null);                        
                  }
               }
               catch (Exception e)
               {
                  Logger.Global.SystemException(string.Empty, e);
               }
            }
         }
      }

      public bool HasScripts(ServerEvent serverEvent)
      {         
         return _Delegates.Keys.Contains(serverEvent) && _Delegates[serverEvent].Count > 0;
      }

      /// <summary>
      /// Runs the scripts.
      /// </summary>
      /// <param name="serverEvent">The event to run the associated scripts.</param>
      /// <param name="args">The list of arguments that will be passed to the VB created Process function.</param>
      public void RunScripts(ServerEvent serverEvent, params object[] args)
      {
         try
         {
            if (Module.ScriptProcessor.HasScripts(serverEvent))
            {
               if (_Delegates.ContainsKey(serverEvent))
               {
                  var rules = from r in _Delegates[serverEvent].Keys
                              where r.Active == true
                              orderby r.Priority descending
                              select r;

                  foreach (ServerRule rule in rules)
                  {
                     ScriptObject scriptObject = GetRuleDelegate(rule, serverEvent);

                     if (scriptObject != null)
                     {
                        //
                        // Execute the rule/action.  A new script object is created for each execution
                        //  of the specified rule.
                        //
                        Logger.Global.SystemMessage(LogType.Debug, string.Format("Executing script: {0}", rule.Name), (args[0] as DicomClient).AETitle);
                        scriptObject.Execute(args);
                     }
                  }
               }
            }
         }
         catch (Exception e)
         {            
            Logger.Global.SystemException((args[0] as DicomClient).AETitle, e);
            Logger.Global.SystemMessage(LogType.Error, e.StackTrace, string.Empty);
         }
         finally
         {
            //
            // If a DICOMDS is passed as an argument we need to find it and set it to null.
            //
            for (int i = 0; i < args.Length;i++ )
            {
               if (args[i] is DicomDS)
               {
                  (args[i] as DicomDS).Dataset = null;
                  args[i] = null;
               }
            }
         }
      }

      /// <summary>
      /// Gets the rule delegate for the specified server event.
      /// </summary>
      /// <param name="rule">The rule.</param>
      /// <param name="serverEvent">The server event.</param>
      /// <param name="request">if set to <c>true</c> this is a DICOM request message other wise a response message.</param>      
      /// <returns>The script object associated with the specified rule.</returns>
      private ScriptObject GetRuleDelegate(ServerRule rule, ServerEvent serverEvent)
      {
         if (_Delegates.ContainsKey(serverEvent) && _Delegates[serverEvent].ContainsKey(rule) && _Delegates[serverEvent][rule]!=null)
            return _Delegates[serverEvent][rule];
         else
         {
            int lineCount = 0;
            ScriptEngine engine = GetScriptEngine();
            string script = string.Empty;
            CompilerErrorCollection errors;

            engine.AddAssemblies(GetReferences(rule).ToArray());            
            engine.AddNamespaces(GetNamespaces(rule).ToArray());            
            script = CreateScript(serverEvent,rule.Script, engine, out lineCount);
            errors = new CompilerErrorCollection(); 

            if (engine.CompileAssembly(script, errors))
            {
               object o = engine.CreateInstance();

               if (engine.ErrorMsg != string.Empty)
               {
                  string msg = string.Format("Error processing rule: {0} => {1}", rule.Name, engine.ErrorMsg);

                  Logger.Global.SystemMessage(LogType.Error, msg, string.Empty);
               }
               else
               {
                  MethodInfo mi = o.GetType().GetMethod("Process");

                  //
                  // Create a fast dynamic method deletate to the process function.  This should be much faster than
                  // calling Method.Invoke.
                  //
                  if (mi != null)
                  {
                     DynamicMethodDelegate d = MethodFactory.GetFastMethod(mi);

                     _Delegates[serverEvent][rule] = new ScriptObject(engine, d);
                     return _Delegates[serverEvent][rule];
                  }
               }
            }
            else
            {
               Logger.Global.SystemMessage(LogType.Error, "Error compiling script: " + rule.Name + "\r\n\r\n" + engine.ErrorMsg, string.Empty);
            }
         }
         return null;
      }      

      /// <summary>
      /// Creates the script from all the specified parts.
      /// </summary>
      /// <param name="serverEvent">The server event.</param>
      /// <param name="request">if set to <c>true</c> this is a DICOM request message otherwise it is a response.</param>
      /// <param name="userScript">The user created script.</param>
      /// <param name="se">The ScriptEngine.</param>
      /// <returns>A valid VBScript class file.</returns>
      public string CreateScript(ServerEvent serverEvent, string userScript, ScriptEngine se, out int lineCount)
      {
         StringBuilder sb = new StringBuilder();
         Match match = _MethodFinder.Match(userScript);
         List<string> methods = new List<string>();
         string additionalMethods = string.Empty;         

         while (match.Success)
         {
            string method = ExtractMethod(ref userScript,match);

            if (method.Length > 0)
               methods.Add(method);
            match = _MethodFinder.Match(userScript);
         }
         additionalMethods = string.Join(@"\n", methods.ToArray());
         sb.Append(se.Namespaces);
         sb.Append("\n\n");
         sb.Append(_ScriptHeader);
         sb.Append(ScriptFunctions.GetScript(serverEvent));
         sb.Append("\n\n");
         lineCount = sb.ToString().Count(c => c == '\n');
         sb.Append(userScript);
         sb.Append("\n");
         sb.Append(string.Format(_ScriptFooter, _Additional + @"

                                                               " + additionalMethods));
         return sb.ToString();
      }

      /// <summary>
      /// Extracts VB methods from the user provided script.  The method is extracted in order to create a valid VB.NET class for use as the
      /// the script.
      /// </summary>
      /// <param name="script">The user supplied script.</param>
      /// <param name="match">The regex match for the function.</param>
      /// <returns></returns>
      public string ExtractMethod(ref string script, Match match)
      {
         string function = string.Empty;
         int index = -1;
         int length = -1;

         if (match.Groups[2].Value.ToLower() == "sub")
         {
            index = script.IndexOf("End Sub", match.Index, StringComparison.CurrentCultureIgnoreCase);
            length = "End Sub".Length;
         }
         else
         {
            index = script.IndexOf("End Function", match.Index, StringComparison.CurrentCultureIgnoreCase);
            length = "End Function".Length;
         }

         if (index != -1)
         {
            int total = (length + index) - match.Index;

            function = script.Substring(match.Index, total);
            script = script.Remove(match.Index, total);
         }

         return function;
      }

      /// <summary>
      /// Gets the script engine.
      /// </summary>
      /// <returns>A Script engine for the specfied script.</returns>
      public ScriptEngine GetScriptEngine()
      {
         ScriptEngine se = new ScriptEngine();
         string directory = _ServerDirectory.ToLower().Replace(Module.ServiceName.ToLower(), string.Empty);

         se.AddDefaultAssemblies();
         se.AddAssembly(Path.Combine(directory, @"Leadtools.Dicom.dll"), "Leadtools.Dicom");
         se.AddAssembly(Path.Combine(directory, @"Leadtools.Dicom.Common.dll"), "Leadtools.Dicom.Common");
         se.AddAssembly(Path.Combine(directory, @"Leadtools.Dicom.AddIn.dll"), "Leadtools.Dicom.AddIn");
         se.AddAssembly(Path.Combine(directory, @"Leadtools.Medical.Winforms.dll"), "Leadtools.Medical.Winforms.Forwarder.Scheduling");
         se.AddAssembly(Path.Combine(directory, @"Leadtools.Logging.dll"), "Leadtools.Logging");
         se.AddAssembly(Path.Combine(directory, @"Leadtools.Logging.Medical.dll"), "Leadtools.Logging.Medical");
         se.AddAssembly(Assembly.GetExecutingAssembly().Location, "Leadtools.Medical.Rules.AddIn");
         se.AddAssembly("System.Web.dll", "System.Web.Caching");
         se.AddAssembly("System.Core.dll");
         se.AddNamespace("System.Web");         
         se.AddNamespace("Leadtools.Medical.Rules.AddIn.Scripting");
         se.AddNamespace("Leadtools.Medical.Rules.AddIn.Scripting.Actions");
         se.AddNamespace("Leadtools.Medical.Rules.AddIn.Workers");

         return se;
      }

      private List<string> GetReferences(ServerRule rule)
      {
         List<string> references = new List<string>();

         //
         // Add global references
         //         
         foreach (AssemblyReference reference in Module._Options.GlobalReferences)
         {
            FileInfo info = new FileInfo(reference.Name);
            
            if (info.Extension.ToLower() != ".dll")
               references.Add(reference.Name + ".dll");
            else
               references.Add(reference.Name);
         }

         //
         // Add script references
         //
         foreach (AssemblyReference reference in rule.References)
         {
            FileInfo info = new FileInfo(reference.Name);

            if (info.Extension.ToLower() != ".dll")
               references.Add(reference.Name + ".dll");
            else
               references.Add(reference.Name);
         }

         return references;
      }

      private List<string> GetNamespaces(ServerRule rule)
      {
         List<string> namespaces = Module._Options.GlobalNamespaces.Concat(rule.Namespaces).ToList();

         return namespaces;
      }
   }
}
