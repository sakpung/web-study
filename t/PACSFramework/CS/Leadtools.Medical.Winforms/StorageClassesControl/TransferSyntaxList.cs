// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Leadtools.Dicom;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

namespace Leadtools.Medical.Winforms
{
   [Serializable]
   [XmlRoot("TransferSyntaxList")]
   public class TransferSyntaxEntry: IEquatable<TransferSyntaxEntry>
{
      public TransferSyntaxEntry()
      {
         _transferSyntax = "";
         _name = "";
         _userDefined = false;
         _supported = false;
      }

      public TransferSyntaxEntry(TransferSyntaxEntry src)
      {
         _transferSyntax = src._transferSyntax;
         _name = src._name;
         _userDefined = src._userDefined;
         _supported = src._supported;
      }

      public TransferSyntaxEntry( string abstractSyntax, string name, bool userDefined, bool supported)
      {
         _transferSyntax = abstractSyntax;
         _name = name;
         _userDefined = userDefined;
         _supported = supported;
      }

      [XmlElement(ElementName = "transferSyntax")]
      public string _transferSyntax;

      [XmlElement(ElementName = "name")]
      public string _name;

      [XmlElement(ElementName = "userDefined")]
      public bool _userDefined;

      [XmlElement(ElementName = "supported")]
      public bool _supported;

      public bool Equals(TransferSyntaxEntry pcEntry)
      {
         if (pcEntry._transferSyntax != _transferSyntax)
            return false;

         if (pcEntry._name != _name)
            return false;

         if (pcEntry._userDefined != _userDefined)
            return false;

         if (pcEntry._supported != _supported)
            return false;

         return true;
      }
   }
   
   
   
   
   [Serializable]
   public class TransferSyntaxList
   {
      public bool Equals(TransferSyntaxList pcList)
      {
         if (!pcList.Items.SequenceEqual(Items))
            return false;

         return true;
      }

      [XmlElement("TransferSyntax")]
      public TransferSyntaxEntry[] Items
      {
         get
         {
            TransferSyntaxEntry[] items = new TransferSyntaxEntry[_tsList.Count];
            _tsList.Values.CopyTo(items, 0);
            return items;
         }
         set
         {
            if (value == null) return;
            TransferSyntaxEntry[] items = value;
            _tsList.Clear();
            foreach (TransferSyntaxEntry item in items)
               _tsList.Add(item._transferSyntax, item);
         }
      }

      [XmlIgnore] 
      public Dictionary<string, TransferSyntaxEntry> _tsList;

      public TransferSyntaxList()
      {
         _tsList = new Dictionary<string, TransferSyntaxEntry>();
      }

      // Copy constructor
      public TransferSyntaxList(TransferSyntaxList src)
      {
         _tsList = new Dictionary<string, TransferSyntaxEntry>();
         foreach (KeyValuePair<string, TransferSyntaxEntry> kvp in src._tsList)
         {
            string uid = kvp.Key;
            TransferSyntaxEntry pcEntry = null;
            if (kvp.Value != null)
            {
               pcEntry = new TransferSyntaxEntry(kvp.Value);
            }
            _tsList.Add(uid, pcEntry);
         }
      }

      public void AddDefaultSupported(string transferSyntax, bool supported)
      {
         TransferSyntaxEntry pcEntry;
         if (_tsList.TryGetValue(transferSyntax, out pcEntry))
         {
            pcEntry._supported = supported;
         }
      }
     
      public bool AddTransferSyntax(string transferSyntax, string name, bool userDefined, bool supported)
      {
         TransferSyntaxEntry pcEntry;
         if (_tsList.TryGetValue(transferSyntax, out pcEntry))
         {
            pcEntry._supported = supported;
         }
         else
         {
            _tsList.Add(transferSyntax, new TransferSyntaxEntry(transferSyntax, name, userDefined, supported));
         }
         
         return true;
      }

      public bool UpdateUserDefinedTransferSyntax(string transferSyntax, string description)
      {
         bool ret = false;
         TransferSyntaxEntry pcEntry;
         if (_tsList.TryGetValue(transferSyntax, out pcEntry))
         {
            pcEntry._name = description;
            ret = true;
         }
         return ret;
      }

      private string[] _defaultSupported = 
      {
         DicomUidType.ExplicitVRBigEndian,
         DicomUidType.ImplicitVRLittleEndian,
         DicomUidType.ExplicitVRLittleEndian,
         DicomUidType.JPEGBaseline1,
         DicomUidType.JPEGExtended2_4,
         DicomUidType.JPEGLosslessNonhier14,
         DicomUidType.JPEGLosslessNonhier14B,
         DicomUidType.JPEG2000,
         DicomUidType.JPEG2000LosslessOnly,
         DicomUidType.RLELossless,
      };

      public void Default()
      {
         DicomUid uid = DicomUidTable.Instance.GetFirst();
         while (uid != null)
         {
            if (uid.Type == DicomUIDCategory.Transfer1 || uid.Type == DicomUIDCategory.Transfer2)
            {
               AddTransferSyntax(uid.Code, uid.Name, false, false);
            }
            uid = DicomUidTable.Instance.GetNext(uid);
         }

         foreach (string transferSyntax in _defaultSupported)
         {
            AddDefaultSupported(transferSyntax, true);

         }
      }

      public void Clear()
      {
         _tsList.Clear();
      }

      public TransferSyntaxEntry ChangeTransferSyntaxSupport(string transferSyntax, bool supported)
      {
         TransferSyntaxEntry pcEntry;
         if (_tsList.TryGetValue(transferSyntax, out pcEntry))
         {
            pcEntry._supported = supported;
         }
         return pcEntry;
      }

      public TransferSyntaxEntry RemoveUserDefinedTransferSyntax(string uid)
      {
         TransferSyntaxEntry pcEntry;
         if (_tsList.TryGetValue(uid, out pcEntry))
         {
            if (pcEntry._userDefined)
               _tsList.Remove(uid);
         }
         return pcEntry;
      }

      public bool TransferSyntaxExists(string transferSyntax)
      {
         TransferSyntaxEntry pcEntry;
         return (_tsList.TryGetValue(transferSyntax, out pcEntry));
      }
      
      public bool TransferSyntaxSupported(string transferSyntax)
      {
         bool supported = false;
         TransferSyntaxEntry pcEntry;
         bool exists = _tsList.TryGetValue(transferSyntax, out pcEntry);
         if (exists)
         {
            supported = pcEntry._supported;
         }
         return supported;
      }
      
     }
}
