// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Rules.AddIn
{
   public class RuleProcessorOptions
   {
      public string RuleDirectory { get; set; }
      public string AETitle { get; set; }

      private List<AssemblyReference> _GlobalReferences = new List<AssemblyReference>();

      public List<AssemblyReference> GlobalReferences
      {
         get
         {
            return _GlobalReferences;
         }
         set
         {
            _GlobalReferences = value;
         }
      }

      private List<AssemblyReference> _References = new List<AssemblyReference>();

      public List<AssemblyReference> References
      {
         get
         {
            return _References;
         }
         set
         {
            _References = value;
         }
      }

      private List<string> _GlobalNamespaces = new List<string>();

      public List<string> GlobalNamespaces
      {
         get
         {
            return _GlobalNamespaces;
         }
         set
         {
            _GlobalNamespaces = value;
         }
      }

      public RuleProcessorOptions()
      {
         AETitle = string.Empty;
      }      
   }

   [Serializable]
   public class AssemblyReference
   {
      public string Name { get; set; }
      public string Version { get; set; }
   }
}
