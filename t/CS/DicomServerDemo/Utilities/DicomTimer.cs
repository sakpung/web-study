// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for DicomTimer.
   /// </summary>
   public class DicomTimer : Timer
   {
      private Client _Client;

      public Client Client
      {
         get
         {
            return _Client;
         }
      }

      public DicomTimer(Client client, int time)
      {
         _Client = client;
         Interval = (time * 1000);
      }
   }
}
