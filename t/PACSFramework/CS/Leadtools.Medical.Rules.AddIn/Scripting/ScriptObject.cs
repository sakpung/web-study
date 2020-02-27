// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Rules.AddIn.Scripting
{
   public class ScriptObject
   {      
      public DynamicMethodDelegate ScriptDelegate { get; set; }
      [CLSCompliant(false)]
      public ScriptEngine _ScriptEngine { get; set; }

      public ScriptObject(ScriptEngine se, DynamicMethodDelegate scriptDelegate)
      {
         _ScriptEngine = se;
         ScriptDelegate = scriptDelegate;
      }

      public void Execute(params object[] args)
      {         
         if (_ScriptEngine != null && ScriptDelegate != null)
         {
            object scriptObject = _ScriptEngine.CreateInstance();

            ScriptDelegate(scriptObject, args);
         }
      }
   }
}
