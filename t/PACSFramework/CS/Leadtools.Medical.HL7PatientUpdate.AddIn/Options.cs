// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Design;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom;
using System.ComponentModel;

using System.Windows.Forms;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.IO;


namespace Leadtools.Medical.HL7PatientUpdate.AddIn
{
   [Serializable]
   public class HL7Options
   {
      private string _HL7IPAddress;
      private int _HL7Port;
      private bool _Autostart;
      
      [Category("HL7Server")]
      [DisplayName("HL7 Server Address")]
      [Description("HL7 Server Address")]
      [Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
      public string HL7IPAddress
      {
         get { return _HL7IPAddress; }
         set { _HL7IPAddress = value; }
      }
      
      [Category("HL7Server")]
      [DisplayName("HL7 Server Port")]
      [Description("HL7 Server Port")]
      public int HL7Port
      {
         get { return _HL7Port; }
         set { _HL7Port = value; }
      }

      [Category("HL7Server")]
      [DisplayName("HL7 Server Autostart")]
      [Description("HL7 Server Autostart")]
      public bool Autostart
      {
         get { return _Autostart; }
         set { _Autostart = value; }
      }
      
      public HL7Options()
      {
         _HL7IPAddress = "127.0.0.1";
         _HL7Port = 6787;
         _Autostart = true;
      }
   }
}
