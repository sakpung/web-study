// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.Medical.Winforms.Forwarder.Scheduling;
using Leadtools.Medical.Winforms.Forwarder.Controls;
using System.Xml.Serialization;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.DataAccessLayer;



namespace Leadtools.Medical.Winforms.ExternalStore
{
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
   [Serializable]   
   [XmlRoot(Namespace="")]
   public class ExternalStoreItem: IEquatable<ExternalStoreItem>
   {      
      public Job ExternalStoreJob { get; set; }
      public Job CleanJob { get; set; }
      public int? ImageHold { get; set; }
      public HoldInterval HoldInterval { get; set; }
      public bool Verify { get; set; }

      public ExternalStoreAddinConfigAbstract ExternalStoreAddinConfig {get;set;}
      
      public ExternalStoreItem(ExternalStoreAddinConfigAbstract externalStoreAddinConfig)
      {
        Initialize();
        ExternalStoreAddinConfig = externalStoreAddinConfig;
      }

      public ExternalStoreItem()
      {
        Initialize();
      }

      private void Initialize()
      {
         ExternalStoreJob = null;
         CleanJob = null;
         Verify = false;
         ImageHold = 0;
         ExternalStoreAddinConfig = null;
      }

      #region IEquatable<ExternalStoreAddinConfigAbstract> Members

      public bool Equals(ExternalStoreItem other)
      {
         return this.ExternalStoreAddinConfig.Equals(other.ExternalStoreAddinConfig);
      }

      #endregion
   }


   [Serializable]   
   [XmlRoot(Namespace="")]
   public class ExternalStoreOptions
   {
      private List<ExternalStoreItem> _items;

      int _externalStoreIndex;

      public int ExternalStoreIndex
      {
         get 
         { 
            return _externalStoreIndex;
         }
         set 
         { 
            _externalStoreIndex = value;
         }
      }


      public ExternalStoreItem[] Items
      {
         get
         {
            return _items.ToArray();
         }

         set
         {
            _items.Clear();
            foreach(ExternalStoreItem item in value)
            {
               _items.Add(item);
            }
         }
      }

      public ExternalStoreItem GetCurrentOption()
      {
         int totalCount = _items.Count;
         if (totalCount > 0)
         {
            if (ExternalStoreIndex == -1)
            {
               return null;
            }

            if (ExternalStoreIndex < 0 || ExternalStoreIndex >= totalCount)
            {
               ExternalStoreIndex = 0;
            }
            return _items[ExternalStoreIndex];
         }
         return null;
      }

      public void SetCurrentOption(ExternalStoreAddinConfigAbstract c)
      {
         if (c == null)
         {
            ExternalStoreIndex = -1;
         }
         else
         {
            int index;
            for (index = 0; index < _items.Count; index++)
            {
               if (_items[index].ExternalStoreAddinConfig.Equals(c))
               {
                  ExternalStoreIndex = index;
                  return;
               }
            }
            ExternalStoreIndex = -1;
         }
      }

      public void Clear()
      {
         _items.Clear();
      }

      public ExternalStoreItem Exists(ExternalStoreItem item)
      {
         return Exists(_items, item);
      }

      private static ExternalStoreItem Exists( List<ExternalStoreItem> tempItems, ExternalStoreItem item)
      {
         foreach(ExternalStoreItem esi in tempItems)
         {
            if (esi.Equals(item))
               return esi;
         }
         return null;
      }

      public void Add(ExternalStoreItem item)
      {
         _items.Add(item);
      }

      // If item already exists, do nothing
      // If item doesn't exist, add it
      // Remove all other existing items
      public void SynchronizeOptionsList(ExternalStoreItem []items)
      {
         List<ExternalStoreItem> tempItems = _items;
         _items = new List<ExternalStoreItem>();

         foreach(ExternalStoreItem item in items)
         {
            ExternalStoreItem existingItem = Exists(tempItems, item);
            if (existingItem == null)
            {
             // doesn't exist so add it to the new list
               _items.Add(item);
            }
            else
            {
               // already exists -- add already existing item to the new list
               _items.Add(existingItem);
            }
         }
      }

      public string GetFriendlyName(string guid)
      {
         foreach (ExternalStoreItem item in _items)
         {
            if (string.Compare(item.ExternalStoreAddinConfig.Guid, guid, true) == 0)
            {
               return item.ExternalStoreAddinConfig.FriendlyName;
            }
         }
         return guid;
      }

      public ExternalStoreItem GetExternalStoreItem(string guid)
      {
         foreach (ExternalStoreItem item in _items)
         {
            if (string.Compare(item.ExternalStoreAddinConfig.Guid, guid, true) == 0)
            {
               return item;
            }
         }
         return null;
      }

      public ICrud GetCrud(string guid)
      {
         ExternalStoreItem item = GetExternalStoreItem(guid);
         if (item != null)
         {
            return item.ExternalStoreAddinConfig.GetCrudInterface();
         }
         return null;
      }

      public void RegisterAllExternalStoreAddins()
      {
         foreach(ExternalStoreItem item in _items)
         {
             DataAccessServiceLocator.Register<ICrud>(item.ExternalStoreAddinConfig.GetCrudInterface(), item.ExternalStoreAddinConfig.Guid);
         }
      }

      public ExternalStoreOptions()
      {
         _items = new List<ExternalStoreItem>();
         ExternalStoreIndex = -1;
      }
   }
#endif // #if LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE
}

