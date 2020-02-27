// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms.DatabaseManager
{
   public enum PaginationDisplayOptions
   {
      ShowNever = 0,
      ShowWhenNecessary = 1,
      ShowAlways = 2,
   }

   [Serializable]
   public class DatabaseManagerOptions : ICloneable
   {
      public DatabaseManagerOptions()
      {
         MaxPageNumber = 5000;
         PageSize = 1000;
         PaginationDisplay = PaginationDisplayOptions.ShowWhenNecessary;
      }
      
      public int PageSize { get; set; }
      
      public int MaxPageNumber { get; set;}

      public PaginationDisplayOptions PaginationDisplay { get; set; }

      public object Clone()
      {
         return this.Clone<DatabaseManagerOptions>();
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

   }
   
   public class DatabaseManagerOptionsAppliedEventArgs : EventArgs
   {
      //public DatabaseManagerOptionsAppliedEventArgs(int pageSize, PaginationDisplayOptions options)
      //{
      //   PageSize = pageSize;
      //   PaginationDisplay = options;
      //}
      
      //public int PageSize {get; set;}
      //public PaginationDisplayOptions PaginationDisplay { get; set; }
   }
}
