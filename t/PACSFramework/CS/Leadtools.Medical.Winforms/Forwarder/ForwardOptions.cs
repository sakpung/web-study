// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Winforms.Forwarder.Scheduling;
using Leadtools.Medical.Winforms.Forwarder.Controls;
using System.Xml;
using System.Xml.Serialization;

namespace Leadtools.Medical.Winforms.Forwarder
{
   [Serializable]   
   [XmlRoot(Namespace="")]
   public class ForwardOptions
   {      
      public Job Forward { get; set; }
      public Job Clean { get; set; }
      public string ForwardTo { get; set; }
      public int? ImageHold { get; set; }
      public HoldInterval HoldInterval { get; set; }
      public bool Verify { get; set; }
      public bool UseCustomAE { get; set; }
      public string CustomAE { get; set; }

      public ForwardOptions()
      {
         Forward = null;
         Clean = null;
         Verify = false;
         ImageHold = null;        
      }
   }
}
