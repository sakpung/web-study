// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom;
using System.IO;
using System.Xml.Serialization;
using Leadtools.Medical.Rules.AddIn.Common;
using Leadtools.Demos;
using Leadtools.Medical.Rules.AddIn.Dialogs;
using System.Windows.Forms;
using Leadtools.Dicom.Common.Extensions;
using System.Reflection;
using Leadtools.Logging;

namespace Leadtools.Medical.Rules.AddIn
{
   public class RuleEditorPresenter
   {
      private IRulesConfigurationDialog _View;
      private AdvancedSettings _Settings;
      private string _ServerDirectory;
      private string _FailureDirectory;

      private RuleProcessorOptions _Options;

      public RuleProcessorOptions Options
      {
         get { return _Options; }
         set { _Options = value; }
      }

      public RuleEditorPresenter(RuleProcessorOptions options, string serverDirectory)
      {
         _Options = options;
         _ServerDirectory = serverDirectory;
      }

      public void RunView(IRulesConfigurationDialog view, AdvancedSettings settings)
      {
         DicomEngine.Startup();
         _View = view;
         _Settings = settings;

         _View.SaveRule += new EventHandler<SaveRuleEventArgs>(View_SaveRule);
         _View.GetStoreFailures += new EventHandler<GetFailuresEventArgs<StoreFailure>>(View_GetStoreFailures);
         _View.GetMoveFailures += new EventHandler<GetFailuresEventArgs<MoveServer>>(View_GetMoveFailures);
         _View.SaveOptions += new EventHandler(_View_SaveOptions);
         LoadRules();
         if (_Options != null)
         {
            _View.AETitle = _Options.AETitle;
         }

         _FailureDirectory = Path.Combine(_ServerDirectory, @"AddIns\rules\Failures\");
      }

      void _View_SaveOptions(object sender, EventArgs e)
      {
         string name = Assembly.GetExecutingAssembly().GetName().Name;

         _Settings.RefreshSettings();
         _Settings.SetAddInCustomData<RuleProcessorOptions>(name, Module.Source, Module._Options);
         _Settings.Save(); 
      }      

      void View_GetStoreFailures(object sender, GetFailuresEventArgs<StoreFailure> e)
      {
         Dictionary<string,StoreFailure> failures = LoadStoreFailures(_FailureDirectory);

         if (failures.Count > 0)
             e.Failures = failures;
      }

      void View_GetMoveFailures(object sender, GetFailuresEventArgs<MoveServer> e)
      {
         Dictionary<string, MoveServer> failures = LoadMoveFailures(_FailureDirectory);

         if (failures.Count > 0)
             e.Failures = failures;
      }

      public bool Save()
      {
         return _View.Save();
      }

      public void UpdateOptions()
      {
         _Options.AETitle = _View.AETitle;
      }

      private void LoadRules()
      {
         if (_Options != null)
         {
            List<RuleItem> rules = new List<RuleItem>();
            List<string> files = (from f in FileSearcher.GetFiles(new DirectoryInfo(_Options.RuleDirectory), "*.rule", SearchOption.AllDirectories)
                                  orderby f.CreationTime descending
                                  select f.FullName).ToList();

            foreach (string file in files)            
            {
               try
               {
                  ServerRule rule = LoadRule<ServerRule>(file);

                  rule.Reset();
                  rules.Add(new RuleItem(rule, file));
               }
               catch (Exception e)
               {
                  Logger.Global.SystemException(string.Empty, e);
               }
            }
            _View.SetRules(rules);
         }
      }     

      private Dictionary<string,StoreFailure> LoadStoreFailures(string failureDirectory)
      {
          Dictionary<string, StoreFailure> failures = new Dictionary<string, StoreFailure>();
         IEnumerable<FileInfo> files = FileSearcher.GetFiles(new DirectoryInfo(failureDirectory), "store*.fail", SearchOption.TopDirectoryOnly);

         foreach (FileInfo file in files.OrderBy(f => f.CreationTime))
         {
            try
            {
               StoreFailure failure = Utils.LoadFromXml<StoreFailure>(file.FullName);
               
               if (!string.IsNullOrEmpty(failure.FileName))
               {                 
                  failure.Dataset = new DicomDataSet();                  
                  failure.Dataset.Load(failure.FileName, DicomDataSetLoadFlags.None);
               }

               failures.Add(file.FullName, failure);
            }
            catch (Exception e)
            {
               Messager.ShowError(_View as Form, e);
            }
         }
         return failures;
      }

      private Dictionary<string, MoveServer> LoadMoveFailures(string failureDirectory)
      {
          Dictionary<string, MoveServer> failures = new Dictionary<string, MoveServer>();
         IEnumerable<FileInfo> files = FileSearcher.GetFiles(new DirectoryInfo(failureDirectory), "move*.fail", SearchOption.TopDirectoryOnly);

         foreach (FileInfo file in files.OrderBy(f => f.CreationTime))
         {
            try
            {
               MoveServer server = Utils.LoadFromXml<MoveServer>(file.FullName);

               server.FileName = file.FullName;
               failures.Add(file.FullName, server);
            }
            catch (Exception e)
            {
               Messager.ShowError(_View as Form, e);
            }
         }

         return failures;
      }

      void View_SaveRule(object sender, SaveRuleEventArgs e)
      {
         string directory = GetRuleDirectory(e.RuleItem.Rule);

         if (!string.IsNullOrEmpty(directory))
         {
            string fileName = Path.Combine(directory, GetValidFileName(e.RuleItem.Rule.Name) + ".rule");

            if (!Directory.Exists(directory))
            {
               Directory.CreateDirectory(directory);
            }

            if (fileName.ToLower() != e.RuleItem.FileName.ToLower())
            {
               //
               // Delete the previous file
               //
               if (File.Exists(e.RuleItem.FileName))
                  File.Delete(e.RuleItem.FileName);
            }
            SaveRule(e.RuleItem.Rule, fileName);
            e.RuleItem.FileName = fileName;
         }
      }

      private string GetValidFileName(string name)
      {
         string fileName = name;

         foreach (char c in Path.GetInvalidFileNameChars())
         {
            fileName = fileName.Replace(c, '_');
         }
         return fileName;
      }

      private string GetRuleDirectory(ServerRule rule)
      {
         string directory = string.Empty;

         if (rule.ServerEvent != ServerEvent.None)
         {
            directory = Path.Combine(Options.RuleDirectory, rule.ServerEvent.ToString());
         }
         return directory;
      }

      public void SaveRule(ServerRule rule, string filename)
      {
         using (Stream file = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
         {
            XmlSerializer s = new XmlSerializer(rule.GetType());

            s.Serialize(file, rule);
            file.Close();
         }
      }

      public static T LoadRule<T>(string filename)
      {
         T obj = default(T);

         using (Stream file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None))
         {
            XmlSerializer s = new XmlSerializer(typeof(T));

            obj = (T)s.Deserialize(file);
            file.Close();
         }
         return obj;
      }
   }
}
