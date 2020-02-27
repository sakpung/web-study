// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Media.AddIns
{
   public class MediaAutoCreationConfiguration
   {
      public MediaAutoCreationConfiguration ( )
      {
         CloseDisc        = true ;
         RejectIfNotBlank = true ;
         LabelImage       = string.Empty ;
         Labels           = new List<LabelPrinting> ( ) ;
      }
      
      public bool EnableAutoMediaCreation
      {
         get ;
         set ;
      }
      
      public bool ManualLoadUnload
      {
         get ;
         set ;
      }
      
      public bool VerifyDisc
      {
         get ;
         set ;
      }
      
      public bool CloseDisc
      {
         get ;
         set ;
      }
      
      public bool RejectIfNotBlank
      {
         get ;
         set ;
      }
      
      public bool TestRecording
      {
         get ;
         set ;
      }
      
      public bool EnableLabeling
      {
         get ;
         set ;
      }
      
      public string LabelImage
      {
         get ;
         set ;
      }
      
      public List <LabelPrinting> Labels
      {
         get ;
         set ;
      }
   }
}
