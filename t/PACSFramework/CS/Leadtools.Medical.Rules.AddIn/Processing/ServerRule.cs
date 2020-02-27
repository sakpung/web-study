// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.Medical.Rules.AddIn
{
   [Serializable]
   public class ServerRule : NotifyPropertyChanged
   {
      private string _Name = string.Empty;

      public string Name
      {
         get { return _Name; }
         set
         {
            SetValue<string>(ref _Name, value, "Name");
         }
      }

      private short _Priority = 0;

      public short Priority
      {
         get { return _Priority; }
         set
         {
            SetValue<short>(ref _Priority, value, "Priority");
         }
      }

      private bool _Active = true;

      public bool Active
      {
         get { return _Active; }
         set
         {
            SetValue<bool>(ref _Active, value, "Active");
         }
      }

      private string _Script = string.Empty;

      public string Script
      {
         get { return _Script; }
         set
         {
            SetValue<string>(ref _Script, value, "Script");
         }
      }

      private ServerEvent _ServerEvent = ServerEvent.None;

      public ServerEvent ServerEvent
      {
         get { return _ServerEvent; }
         set
         {
            SetValue<ServerEvent>(ref _ServerEvent, value, "ServerEvent");
         }
      }

      private List<string> _Namespaces = new List<string>();

      public List<string> Namespaces
      {
         get
         {
            return _Namespaces;
         }
         set
         {
            SetValue(ref _Namespaces, value, "Namespaces");
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
            SetValue(ref _References, value, "References");
         }
      }
   }
}
