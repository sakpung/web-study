// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using System.Collections.ObjectModel;
using Leadtools.Dicom.AddIn.Common;

namespace Leadtools.Medical.Winforms
{
   public class ClientAddedEventArgs : EventArgs
   {
      private AeInfo _NewClient;

      public AeInfo NewClient
      {
         get 
         {
            return _NewClient;
         }         
      }

      public ClientAddedEventArgs(AeInfo newClient)
      {
         _NewClient = newClient;
      }
   }

   public class ClientRemovedEventArgs : EventArgs
   {
      private string _Ae;

      public string Ae
      {
         get { return _Ae; }
         set { _Ae = value; }
      }

      public ClientRemovedEventArgs(string ae)
      {
         _Ae = ae;
      }
   }

   public class ClientUpdatedEventArgs : EventArgs
   {
      private string _OldAe;

      public string OldAe
      {
         get { return _OldAe; }        
      }

      private AeInfo _Client;

      public AeInfo Client
      {
         get
         {
            return _Client;
         }
      }

      public ClientUpdatedEventArgs(string oldae, AeInfo client)
      {
         _OldAe = oldae;
         _Client = client;
      }
   }
}
