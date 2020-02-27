// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.Anonymization;

namespace Leadtools.Medical.Winforms.Anonymize
{
 [Serializable]
   public class AnonymizeScript
   {
      public AnonymizeScript()
      {
         Anonymizer = null;
         FriendlyName = string.Empty;
      }

      public AnonymizeScript(string friendlyName, AnonymizeScript previousScript)
      {
         Anonymizer = new Anonymizer(false);
         FriendlyName = friendlyName;
         foreach(TagMacro tagMacro in previousScript.Anonymizer.TagMacros)
         {
            Anonymizer.TagMacros.Add(tagMacro);
         }
      }

      public AnonymizeScript(string friendlyName, bool addDefaults)
      {
         Anonymizer = new Anonymizer(addDefaults);
         FriendlyName = friendlyName;
      }

      public Anonymizer Anonymizer { get; set;}
      public string FriendlyName { get; set;}

      public override string ToString()
      {
         return FriendlyName;
      }
   }

   [Serializable]
   public class AnonymizeScripts
   {
      private readonly List<AnonymizeScript> _scripts;

      public AnonymizeScripts()
      {
         _scripts = new List<AnonymizeScript>();
      }

      public AnonymizeScripts(bool defaultScript)
      {
         _scripts = new List<AnonymizeScript>();
         if (defaultScript)
         {
            AnonymizeScript scriptDefault = new AnonymizeScript("Default Script", true);
            _scripts.Add(scriptDefault);
            SetActive(scriptDefault);
         }
      }

      public AnonymizeScript[] Scripts
      {
         get
         {
            return _scripts.ToArray();
         }

         set
         {
            _scripts.Clear();
            foreach(AnonymizeScript script in value)
            {
               _scripts.Add(script);
            }
         }
      }

      private string _activeScriptName;
      public string ActiveScriptName
      {
         get { return _activeScriptName; }
         set { _activeScriptName = value; }
      }

      private string GetNextScriptSuffix()
      {
         for (int i = 1; i < 1000; i++)
         {
            string suffix = string.Format(" {0}", i);
            bool found = false;

            foreach (AnonymizeScript script in _scripts)
            {
               if (script.FriendlyName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
               {
                  found = true;
                  break;
               }
            }
            if (!found)
            {
               return suffix;
            }
         }
         return string.Empty;
      }

      public string GetNewScriptName(ScriptNameEnum scriptType)
      {
         string rootName = "Script";
         switch (scriptType)
         {
            case ScriptNameEnum.New:
               rootName = "New";
               break;
            case ScriptNameEnum.Default:
               rootName = "Default";
               break;
            case ScriptNameEnum.Copy:
               rootName = "Copy";
               break;
         }

         string suffix = GetNextScriptSuffix();

         string friendlyName = string.Format("{0}{1}", rootName, suffix);
         AnonymizeScript script = _scripts.Find(x => x.FriendlyName.Equals(friendlyName, StringComparison.OrdinalIgnoreCase));
         if (script == null)
         {
            return friendlyName;
         }

         return string.Empty;
      }

      public bool ScriptExists(string newScriptName)
      {
         AnonymizeScript s = _scripts.Find(x => x.FriendlyName.Equals(newScriptName, StringComparison.OrdinalIgnoreCase));
         return (s != null);
      }

      public void Add(AnonymizeScript script)
      {
         _scripts.Add(script);
         if (string.IsNullOrEmpty(_activeScriptName))
         {
            _activeScriptName = script.FriendlyName;
         }
      }

      public void Delete(string deleteScriptName)
      {
         AnonymizeScript s = _scripts.Find(x => x.FriendlyName.Equals(deleteScriptName, StringComparison.OrdinalIgnoreCase));
         if (s != null)
         {
            Delete(s);
         }
      }

      public void Delete(AnonymizeScript script)
      {
         string removedScriptName = script.FriendlyName;
         _scripts.Remove(script);
         if (string.Equals(removedScriptName, _activeScriptName, StringComparison.OrdinalIgnoreCase))
         {
            _activeScriptName = string.Empty;
            if (_scripts.Count > 0)
            {
               _activeScriptName = _scripts[0].FriendlyName;
            }
         }
      }

      public void RenameScript(AnonymizeScript script, string newFriendlyName)
      {
         RenameScript(script.FriendlyName, newFriendlyName);
      }

      public void RenameScript(string oldFriendlyName, string newFriendlyName)
      {
         string exceptionMessage;

         if (ScriptExists(oldFriendlyName))
         {
            exceptionMessage = string.Format("Script does not exist: '{0}'", oldFriendlyName);
            throw new Exception(exceptionMessage);
         }

         if (ScriptExists(newFriendlyName))
         {
            exceptionMessage = string.Format("Script name already used: '{0}'", newFriendlyName);
            throw new Exception(exceptionMessage);
         }

         AnonymizeScript s = _scripts.Find(x => x.FriendlyName.Equals(oldFriendlyName, StringComparison.OrdinalIgnoreCase));
         if (s != null)
         {
            s.FriendlyName = newFriendlyName;
            if (string.Equals(_activeScriptName, oldFriendlyName, StringComparison.InvariantCultureIgnoreCase))
            {
               _activeScriptName = s.FriendlyName;
            }
         }
      }

      public AnonymizeScript SetActive(string friendlyName)
      {
         AnonymizeScript script = _scripts.Find(x => x.FriendlyName.Equals(friendlyName, StringComparison.OrdinalIgnoreCase));
         if (script != null)
         {
            _activeScriptName = script.FriendlyName;
         }
         else
         {
            string exceptionMessage = string.Format("Script not found: '{0}'", friendlyName);
            throw new Exception(exceptionMessage);
         }
         return script;
      }

      public void SetActive(AnonymizeScript s)
      {
         SetActive(s.FriendlyName);
      }

      public AnonymizeScript ActiveScript()
      {
         AnonymizeScript script = _scripts.Find(x => x.FriendlyName.Equals(_activeScriptName, StringComparison.OrdinalIgnoreCase));
         return script;
      }

      public Anonymizer ActiveAnonymizer()
      {
         AnonymizeScript activeScript = ActiveScript();
         if(activeScript != null)
         {
            return activeScript.Anonymizer;
         }
         return null;
      }

      public enum ScriptNameEnum
      {
         New = 0,
         Default = 1,
         Copy = 2, 
      }
   }
}
