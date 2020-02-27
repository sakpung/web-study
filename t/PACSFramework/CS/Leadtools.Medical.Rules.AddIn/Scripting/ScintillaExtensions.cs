// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScintillaNET;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.Reflection;

namespace Leadtools.Medical.Rules.AddIn.Scripting
{
   public enum AnnotationVisible : int
   {
      Hidden,
      Standard,
      Boxed
   }

   public static class ScintillaExtensions
   {
      public const int SCI_ANNOTATIONSETTEXT = 2540;
      public const int SCI_ANNOTATIONSETSTYLE = 2542;
      public const int SCI_ANNOTATIONSETVISIBLE = 2548;
      public const int SCI_ANNOTATIONCLEARALL = 2547;

      public const string VBNetKeywords = @"addhandler addressof andalso alias and ansi as assembly attribute auto begin boolean byref byte byval call case catch
				                                       cbool cbyte cchar cdate cdec cdbl char cint class clng cobj compare const continue cshort csng cstr ctype currency date
				                                       decimal declare default delegate dim do double each else elseif end enum erase error event exit explicit false finally
				                                       for friend function get gettype global gosub goto handles if implement implements imports in inherits integer interface
				                                       is let lib like load long loop lset me mid mod module mustinherit mustoverride mybase myclass namespace new next not
				                                       nothing notinheritable notoverridable object on option optional or orelse overloads overridable overrides paramarray
				                                       preserve private property protected public raiseevent readonly redim rem removehandler rset resume return select set
				                                       shadows shared short single static step stop string structure sub synclock then throw to true try type typeof unload
				                                       unicode until variant wend when while with withevents writeonly xor";
      public static readonly List<string> CustomKeywords = new List<string>() {"route", "route_at" ,"route_with_retry","route_at_with_retry","move", 
                                                                               "move_at", "move_with_retry", "move_at_with_retry", "find_job",
                                                                               "get_dataset", "make_tag","audit_log", "warning_log","error_log","debug_log","info_log"};
      public static readonly List<string> ScriptVars = new List<string>() { "client", "presentationID", "messageID", "affectedClass", "priority",
                                                                            "instanceuid", "status", "attributes", "dicomEvent", "moveAE", "action", 
                                                                            "moveMessageID", "response", "remaining", "completed", "failed","warning",
                                                                            "result", "source", "reason", "association", "associate", "request" };

      [CLSCompliant(false)]
      public static void AddAnnotation(this Scintilla editor, int line, string text)
      {
         if(line >=0)
            editor.NativeInterface.SendMessageDirect(SCI_ANNOTATIONSETTEXT, line, text);
      }

      [CLSCompliant(false)]
      public static void SetAnnotationVisible(this Scintilla editor, AnnotationVisible visible)
      {
         editor.NativeInterface.SendMessageDirect(SCI_ANNOTATIONSETVISIBLE, (int)visible);
      }

      [CLSCompliant(false)]
      public static void ClearAllAnnotations(this Scintilla editor)
      {
         editor.NativeInterface.SendMessageDirect(SCI_ANNOTATIONCLEARALL);
      }

      [CLSCompliant(false)]
      public static void ClearAnnotation(this Scintilla editor, int line)
      {
         if (line > 0)
            editor.NativeInterface.SendMessageDirect(SCI_ANNOTATIONSETTEXT, new IntPtr(line), IntPtr.Zero);
      }

      [CLSCompliant(false)]
      public static void SetAnnotationStyle(this Scintilla editor, int line, int style)
      {
         if(line > 0)
            editor.NativeInterface.SendMessageDirect(SCI_ANNOTATIONSETSTYLE, line, style);
      }

      [CLSCompliant(false)]
      public static void DisplayErrors(this Scintilla editor, Dictionary<int, List<string>> errors)
      {
         //
         // Add error annotations to the line.  For more info on annotations in the scintilla editor check
         // http://www.scintilla.org/ScintillaDoc.html#Annotations
         //
         foreach (int line in errors.Keys)
         {
            //
            // Join all the errors on one line with a \n.  The editor will display each annotation on
            // a seperate line.
            //
            editor.AddAnnotation(line, string.Join("\n", errors[line].ToArray()));
            editor.SetAnnotationStyle(line, 12);
         }
         editor.SetAnnotationVisible(AnnotationVisible.Boxed);
      }

      /// <summary>
      /// Compiles the specified editor.
      /// </summary>
      /// <param name="editor">The editor.</param>
      /// <param name="serverEvent">The server event.</param>
      /// <param name="errors">The errors.</param>
      /// <param name="lineCount">The line count of the glue code that is provided for the script engine.  This code
      /// allows the user to write scripts without having to include class an import declarations.
      /// </param>
      /// <returns>A valid VB class that inludes the script code.</returns>
      [CLSCompliant(false)]
      public static bool Compile(this Scintilla editor, Described<ServerEvent> serverEvent, List<string> references, List<string> namespaces,
                                 CompilerErrorCollection errors, out int lineCount)
      {
         ScriptProcessor scriptProcessor = new ScriptProcessor(Module.ServiceDirectory);
         ScriptEngine scriptEngine = scriptProcessor.GetScriptEngine();
         string script = string.Empty;

         scriptEngine.AddAssemblies(references.ToArray());
         scriptEngine.AddNamespaces(namespaces.ToArray());
         script = scriptProcessor.CreateScript(serverEvent, editor.Text, scriptEngine, out lineCount);
         return scriptEngine.CompileAssembly(script, errors);
      }

      [CLSCompliant(false)]
      public static void Initialize(this Scintilla editor)
      {
         int LINE_NUMBERS_MARGIN_WIDTH = 35;

         editor.ConfigurationManager.Language = "vbscript";
         editor.ConfigurationManager.Configure();
         editor.SetVBNetKeywords();
         editor.SetCustomKeywords();
         editor.Margins.Margin0.Width = LINE_NUMBERS_MARGIN_WIDTH;
         editor.Folding.IsEnabled = true;
         editor.Indentation.SmartIndentType = SmartIndent.Simple;

         //
         // Scintilla requires the list of words to be seperated by spaces.  The regex below removes all whitespace characters and
         // replaces them with one spaces.
         //
         editor.AutoComplete.ListString = Regex.Replace(VBNetKeywords, @"\s+", " ") + " " +
                                          string.Join(" ", CustomKeywords.ToArray());
         editor.CharAdded += new EventHandler<CharAddedEventArgs>(editor_CharAdded);
         editor.AutoComplete.List.Sort();
      }
      
      static void editor_CharAdded(object sender, CharAddedEventArgs e)
      {
         ScintillaNET.Scintilla editor = sender as ScintillaNET.Scintilla;
         int pos = editor.NativeInterface.GetCurrentPos();
         string word = editor.GetWordFromPosition(pos);         

         if (e.Ch == '.')
         {
            word = editor.GetWordFromPosition(pos-1);

            //
            // This is a quick and dirty way to populate an autocomplete list.  For a more through implementation you would want to
            // support caching of this information.  This will eliminate the reflection hit each time.
            //
            Type foundType = (from a in AppDomain.CurrentDomain.GetAssemblies()
                              from type in GetTypes(a)
                              where type != null && type.Name.ToLower() == word.ToLower()
                              select type).FirstOrDefault();

            if (foundType != null)
            {               
               List<string> acList = (from m in foundType.GetMembers()
                                      where !m.Name.Contains("ctor")
                                      orderby m.Name ascending
                                      select m.Name).ToList();

               if (acList.Count > 0)
               {
                  Timer t = new Timer();
                  t.Interval = 10;
                  t.Tag = editor;
                  t.Tick += new EventHandler((obj, ev) =>
                  {
                     editor.AutoComplete.Show(acList);

                     t.Stop();
                     t.Enabled = false;
                     t.Dispose();
                  });
                  t.Start();
               }
            }
         }         
      }

      private static List<Type> GetTypes(Assembly assembly)
      {          
          try
          {
              return assembly.GetTypes().ToList();
          }
          catch (Exception )
          {
          }
          return new List<Type>();
      }

      [CLSCompliant(false)]
      public static void SetVBNetKeywords(this Scintilla editor)
      {
         editor.Lexing.SetKeywords(0, VBNetKeywords);
      }

      [CLSCompliant(false)]
      public static void SetCustomKeywords(this Scintilla editor)
      {
         //
         // Set custom keywords defined by the scripting
         //
         editor.Lexing.SetKeywords(1, string.Join(" ", CustomKeywords.ToArray()));

         //
         // Set variables passed to the script
         //
         editor.Lexing.SetKeywords(2, string.Join(" ", ScriptVars.ToArray()));
      }
   }
}
