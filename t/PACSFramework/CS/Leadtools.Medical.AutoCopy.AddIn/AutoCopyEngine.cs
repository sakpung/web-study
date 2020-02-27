// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn;
using Leadtools.Medical.AutoCopy.AddIn.Queue;
using Leadtools.Dicom;

namespace Leadtools.Medical.AutoCopy.AddIn
{
   /// <summary>
   /// Maintains the list of datasets that need to be copied.
   /// </summary>
   public class AutoCopyEngine
   {
      private static ThreadSafeDictionary<string, AutoCopyItem> _Datasets = new ThreadSafeDictionary<string, AutoCopyItem>();

      public static void AddAeTitle(string aeTitle, string clientae)
      {
         if(!_Datasets.ContainsKey(aeTitle))
         {
            _Datasets[aeTitle] = new AutoCopyItem(aeTitle) { ClientAE = clientae };
         }
      }

      private static ThreadSafeDictionary<string, string> _MoveRequests = new ThreadSafeDictionary<string, string>();

      public static ThreadSafeDictionary<string, string> MoveRequests
      {
         get { return _MoveRequests; }         
      }

      /// <summary>
      /// Adds a dataset for a specific ae title.
      /// </summary>
      /// <param name="aeTitle">The ae title.</param>
      /// <param name="instance">The SOP instance of the dataset.</param>
      public static void AddDataset(string aeTitle, string instance)
      {
         if(_Datasets.ContainsKey(aeTitle))
         {
            AutoCopyItem item = _Datasets[aeTitle];

            if (!item.Datasets.Contains(instance))
               item.Datasets.Add(instance);            
         }
      }

      /// <summary>
      /// Removes the dataset.
      /// </summary>
      /// <param name="aeTitle">The ae title.</param>
      /// <param name="instance">The SOP instance to remove.</param>
      /// <remarks> A dataset will be removed if the store operation failed.</remarks>
      public static void RemoveDataset(string aeTitle, string instance)
      {
         if (_Datasets.ContainsKey(aeTitle))
         {
            AutoCopyItem item = _Datasets[aeTitle];

            if (item.Datasets.Contains(instance))
            {
               item.Datasets.Remove(instance);
            }
         }
      }

      /// <summary>
      /// Adds a dataset to the autocopy queue.
      /// </summary>
      /// <param name="aeTitle">The ae title.</param>
      public static void QueueDatasets(string aeTitle)
      {
         if (_Datasets.ContainsKey(aeTitle) && null != Module.CopyQueue )
         {
            Module.CopyQueue.AddItem(_Datasets[aeTitle]);
         }
      }
   }
}
