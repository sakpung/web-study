// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms.ClientManager
{
   public enum PaginationDisplayOptions
   {
      ShowNever = 0,
      ShowWhenNecessary = 1,
      ShowAlways = 2,
   }

   public enum LastAccessDateDisplayOptions
   {
      ShowDateOnly = 0,
      ShowDateTime = 1,
   }

   [Serializable]
   public class ClientConfigurationOptions : ICloneable
   {
      public ClientConfigurationOptions()
      {
         MaxPageNumber = 5000;
         PageSize = 10;
         PaginationDisplay = PaginationDisplayOptions.ShowWhenNecessary;
      }
      
      public int PageSize { get; set; }
      
      public int MaxPageNumber { get; set;}

      public PaginationDisplayOptions PaginationDisplay { get; set; }

      public LastAccessDateDisplayOptions LastAccessDateDisplay { get;set;}

      public object Clone()
      {
         return this.Clone<ClientConfigurationOptions>();
      }

      public string GetDisplayOptionString()
      {
         string ret = string.Empty;
         switch (PaginationDisplay)
         {
            case PaginationDisplayOptions.ShowNever:
               ret = "Never Show";
               break;

            case PaginationDisplayOptions.ShowWhenNecessary:
               ret = "Show When Necessary";
               break;

            case PaginationDisplayOptions.ShowAlways:
               ret = "Always Show";
               break;
         }
         return ret;
      }

      public string GetLastAccessDateString()
      {
         string ret = string.Empty;

         switch(LastAccessDateDisplay)
         {
            case LastAccessDateDisplayOptions.ShowDateOnly:
               ret = "Show Date Only";
               break;

            case LastAccessDateDisplayOptions.ShowDateTime:
               ret = "Show Date and Time";
               break;
         }

         return ret;
      }

   }
   
   public class ClientConfigurationOptionsAppliedEventArgs : EventArgs
   {
   }
}
