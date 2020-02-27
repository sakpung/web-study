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
using Leadtools.Dicom.AddIn.Interfaces;

namespace Leadtools.Medical.Winforms
{

   [Serializable]
   [XmlRoot("RoleSelectionItem")]
   public class RoleSelectionItem
   {
      public RoleSelectionItem()
      {
         Enabled =true;
         UserRoleProposal = 1;
         ProviderRoleProposal = 1;
      }

      public RoleSelectionFlags ToRoleSelectionFlags()
      {
         RoleSelectionFlags flags = RoleSelectionFlags.None;
         if (Enabled)
         {
            flags |= RoleSelectionFlags.Enabled;
            if (UserRoleProposal == 1)
            {
               flags |= RoleSelectionFlags.AcceptUserRoleProposed;
            }

            if (ProviderRoleProposal == 1)
            {
               flags |= RoleSelectionFlags.AcceptProviderRoleProposed;
            }
         }
         else
         {
            flags = RoleSelectionFlags.Disabled;
         }
         return flags;
      }

      public bool IsEqual(RoleSelectionItem r)
      {
         if (r.Enabled != Enabled)
            return false;

         if (r.UserRoleProposal != UserRoleProposal)
            return false;

         if (r.ProviderRoleProposal != ProviderRoleProposal)
            return false;

         return true;
      }

      [XmlElement(ElementName = "Enabled")] 
      public bool Enabled { get;set;}

      [XmlElement(ElementName = "UserRoleProposal")]
      public int UserRoleProposal { get;set;}

      [XmlElement(ElementName = "ProviderRoleProposal")]
      public int ProviderRoleProposal { get;set;}
   }

   [Serializable]
   [XmlRoot("PresentationContextList")]
   public class PresentationContextEntry : IEquatable<PresentationContextEntry>
   {
      public PresentationContextEntry()
      {
         _abstractSyntax = "";
         _name = "";
         _userDefined = false;
         _supported = false;
         _pcList = new List<string>();
         _roleSelectionItem = new RoleSelectionItem();
      }

      public PresentationContextEntry(PresentationContextEntry src)
      {
         _abstractSyntax = src._abstractSyntax;
         _name = src._name;
         _userDefined = src._userDefined;
         _supported = src._supported;
         _pcList = new List<string>();

         foreach (string transferSyntax in src._pcList)
         {
            _pcList.Add(transferSyntax);
         }
      }

      public PresentationContextEntry( string abstractSyntax, string name, bool userDefined, bool supported)
      {
         _abstractSyntax = abstractSyntax;
         _name = name;
         _userDefined = userDefined;
         _supported = supported;
         _pcList = new List<string>();
      }

      [XmlElement(ElementName = "abstractSyntax")]
      public string _abstractSyntax;

      [XmlElement(ElementName = "name")]
      public string _name;

      [XmlElement(ElementName = "userDefined")]
      public bool _userDefined;

      [XmlElement(ElementName = "supported")]
      public bool _supported;

      [XmlElement(ElementName = "transferSyntax")]
      public List<string> _pcList;

      [XmlElement(ElementName = "RoleSelectItem")]
      public RoleSelectionItem _roleSelectionItem;

      public bool Equals(PresentationContextEntry pcEntry)
      {
         if (pcEntry._abstractSyntax != _abstractSyntax)
            return false;

         if (pcEntry._name != _name)
            return false;

         if (pcEntry._userDefined != _userDefined)
            return false;

         if (pcEntry._supported != _supported)
            return false;

         if (!pcEntry._pcList.SequenceEqual(_pcList))
            return false;

         if (pcEntry._roleSelectionItem.IsEqual(_roleSelectionItem) == false)
            return false;

         return true;
      }
   }

   [Serializable]
   public class PresentationContextList
   {
      public bool Equals(PresentationContextList pcList)
      {
         if (!pcList.Items.SequenceEqual(Items))
            return false;

         if (!pcList._masterTransferSyntaxList.Equals(this._masterTransferSyntaxList))
            return false;

         return true;
      }

      [XmlElement("masterTransferSyntaxList")]
      public TransferSyntaxList MasterTransferSyntaxList
      {
         get { return _masterTransferSyntaxList; }
         set { _masterTransferSyntaxList = value; }
      } 

      [XmlElement("presentationContext")]
      public PresentationContextEntry[] Items
      {
         get
         {
            PresentationContextEntry[] items = new PresentationContextEntry[_pcList.Count];
            _pcList.Values.CopyTo(items, 0);
            return items;
         }
         set
         {
            if (value == null) return;
            PresentationContextEntry[] items = value;
            _pcList.Clear();
            foreach (PresentationContextEntry item in items)
               _pcList.Add(item._abstractSyntax, item);
         }
      }

      [XmlIgnore] 
      public Dictionary<string, PresentationContextEntry> _pcList;
      
      [XmlIgnore]
      public TransferSyntaxList _masterTransferSyntaxList;


      public PresentationContextList()
      {
         _pcList = new Dictionary<string, PresentationContextEntry>();
      }

      // Copy constructor
      public PresentationContextList(PresentationContextList src)
      {
         _pcList = new Dictionary<string, PresentationContextEntry>();
         foreach (KeyValuePair<string, PresentationContextEntry> kvp in src._pcList)
         {
            string uid = kvp.Key;
            PresentationContextEntry pcEntry = null;
            if (kvp.Value != null)
            {
               pcEntry = new PresentationContextEntry(kvp.Value);
            }
            _pcList.Add(uid, pcEntry);
         }
      }

      public void AddDefaultSupported(string abstractSyntax, string[]transferSyntaxes)
      {
         ClearAllTransferSyntax(abstractSyntax);
         AddTransferSyntax(abstractSyntax, transferSyntaxes);
         ChangePresentationContextSupport(abstractSyntax, true);
     }

      public void Default()
      {
         _masterTransferSyntaxList = new TransferSyntaxList();
         _masterTransferSyntaxList.Default();

         DicomUid uid = DicomUidTable.Instance.GetFirst();
         while (uid != null)
         {
            if (uid.Type == DicomUIDCategory.Class)
            {
               bool storageClass =
                     uid.Name.EndsWith("Storage") ||
                     uid.Name.EndsWith("Storage (Retired)") ||
                     uid.Name.EndsWith("Storage - For Presentation") ||
                     uid.Name.EndsWith("Storage - For Processing");
               if (storageClass)
               {
                  //ListViewItem item = _listViewMaster.Items.Add(uid.Code, 1);
                  //item.SubItems.Add(uid.Name);
                  AddPresentationContextWithDefaultTransferSyntax(uid.Code, uid.Name, false, false);
               }
            }
            uid = DicomUidTable.Instance.GetNext(uid);
         }

             AddDefaultSupported(DicomUidType.CTImageStorage,  new string[]{
                                                               DicomUidType.ImplicitVRLittleEndian, 
                                                               DicomUidType.JPEG2000,
                                                               DicomUidType.JPEG2000LosslessOnly,
                                                               DicomUidType.JPEGBaseline1,
                                                               DicomUidType.JPEGExtended2_4,
                                                               DicomUidType.ExplicitVRBigEndian,
                                                               DicomUidType.ExplicitVRLittleEndian,
                                                               DicomUidType.JPEGLosslessNonhier14,
                                                               DicomUidType.RLELossless,
                                                               DicomUidType.JPEGLosslessNonhier14B});

#if LEADTOOLS_V20_OR_LATER
         AddDefaultSupported(DicomUidType.BasicStructuredDisplayStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
#endif

         AddDefaultSupported(DicomUidType.StandaloneOverlayStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.StandaloneCurveStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.StandaloneModalityLutStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.CardiacElectrophysiologyWaveformStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.StandaloneVoiLutStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.StandalonePETCurveStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.StereometricRelationshipStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.BasicTextSR, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.EnhancedSR, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.ComprehensiveSR, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.GrayscaleSoftcopyPresentationStateStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.BasicVoiceAudioWaveformStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.TwleveLeadECGWaveformStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.GeneralECGWaveformStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.AmbulatoryECGWaveformStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.RawDataStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.MammographyCadSR, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.ChestCadSR, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.KeyObjectSelectionDocument, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.RTDoseStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.RTPlanStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.RTStructureStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.RTBeamsTreatmentRecordStorageClass, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.RTBrachyTreatmentRecordStorageClass, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.RTTreatmentSummaryRecordStorageClass, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.PseudoColorSoftcopyPresentationStateStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.BlendingSoftcopyPresentationStateStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.XRayRadiationDoseSRStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.SpatialRegistrationStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.DeformableSpatialRegistrationStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.SpatialFiducialsStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.EncapsulatedPdfStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.EncapsulatedCdaStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.RealWorldValueMappingStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.RTIonPlanStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.RTIonBeamsTreatmentRecordStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.SegmentationStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.LensometryMeasurementsStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.AutorefractionMeasurementsStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.KeratometryMeasurementsStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.SubjectiveRefractionMeasurementsStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.VisualAcuityMeasurementsStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.SpectaclePrescriptionReportStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.XABiplaneImageStorageRetired, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.RLELossless,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.RTImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.PETImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.HardcopyColorImageStorageClass, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.HardcopyGrayscaleImageStorageClass, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});

           AddDefaultSupported(DicomUidType.NMImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});

           AddDefaultSupported(DicomUidType.NMImageStorageRetired, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.DXImageStoragePresentation, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.RLELossless,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.DXImageStorageProcessing, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.DXMammographyImageStoragePresentation, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.RLELossless,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.DXMammographyImageStorageProcessing, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.DXIntraoralImageStoragePresentation, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.RLELossless,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.DXIntraoralImageStorageProcessing, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.VLEndoscopicImageStorageClass, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.VLMicroscopicImageStorageClass, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.VLPhotographicImageStorageClass, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.MRImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.EnhancedMRImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});

           AddDefaultSupported(DicomUidType.HemodynamicWaveformStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.XAImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.XRayRadiofluoroscopicImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.SCMultiFrameGrayscaleByteImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.SCMultiFrameGrayscaleWordImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.SCMultiFrameTrueColorImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.RLELossless,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.SCMultiFrameSingleBitImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian});
           AddDefaultSupported(DicomUidType.Ophthalmic16BitPhotographyImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.Ophthalmic8BitPhotographyImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                    DicomUidType.JPEG2000,
                                                    DicomUidType.JPEG2000LosslessOnly,
                                                    DicomUidType.JPEGBaseline1,
                                                    DicomUidType.JPEGExtended2_4,
                                                    DicomUidType.ExplicitVRBigEndian,
                                                    DicomUidType.ExplicitVRLittleEndian,
                                                    DicomUidType.JPEGLosslessNonhier14,
                                                    DicomUidType.JPEGLosslessNonhier14B});


           AddDefaultSupported(DicomUidType.CRImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.USImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.RLELossless,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.USImageStorageRetired, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.RLELossless,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.USMultiframeImageStorageRetired, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.RLELossless,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.SCImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.USMultiframeImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.RLELossless,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.VideoEndoscopicImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.VideoMicroscopicImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.VideoPhotographicImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.EnhancedCTImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.RLELossless,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.EnhancedXAImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.RLELossless,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.EnhancedXrfImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.RLELossless,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.OphthalmicTomographyImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.RLELossless,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.XRay3dAngiographicImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.RLELossless,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.XRay3dCraniofacialImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.RLELossless,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
           AddDefaultSupported(DicomUidType.EnhancedPETImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.RLELossless,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});

           AddDefaultSupported(DicomUidType.XRayRadiofluoroscopicImageStorage, new string[]{
                                                            DicomUidType.ImplicitVRLittleEndian,
                                                            DicomUidType.JPEG2000,
                                                            DicomUidType.JPEG2000LosslessOnly,
                                                            DicomUidType.JPEGBaseline1,
                                                            DicomUidType.JPEGExtended2_4,
                                                            DicomUidType.ExplicitVRBigEndian,
                                                            DicomUidType.ExplicitVRLittleEndian,
                                                            DicomUidType.JPEGLosslessNonhier14,
                                                            DicomUidType.JPEGLosslessNonhier14B});
         
      }

      public void Clear()
      {
         foreach (KeyValuePair<string, PresentationContextEntry> kvp in _pcList)
         {
            PresentationContextEntry pcEntry = kvp.Value;
            if (pcEntry != null)
            {
               pcEntry._pcList.Clear();
            }
         }
         _pcList.Clear();
      }

      public bool PresentationContextExists(string abstractSyntax)
      {
         PresentationContextEntry pcEntry;
         return (_pcList.TryGetValue(abstractSyntax, out pcEntry));
      }

      public RoleSelectionFlags GetRoleSelection(string abstractSyntax)
      {
         RoleSelectionFlags flags = RoleSelectionFlags.None;
         PresentationContextEntry pcEntry;
         if (_pcList.TryGetValue(abstractSyntax, out pcEntry))
         {
            flags = pcEntry._roleSelectionItem.ToRoleSelectionFlags();
         }
         return flags;
      }

      public bool IsAbstractSyntaxSupported(string abstractSyntax)
      {
         bool supported = false;
         PresentationContextEntry pcEntry;
         if (_pcList.TryGetValue(abstractSyntax, out pcEntry))
         {
            supported = pcEntry._supported;
         }
         return supported;
      }

      public bool IsTransferSyntaxSupported(string abstractSyntax, string transferSyntax)
      {
         bool supported = false;
         PresentationContextEntry pcEntry;
         if (_pcList.TryGetValue(abstractSyntax, out pcEntry))
         {
            supported = pcEntry._pcList.Contains(transferSyntax) && _masterTransferSyntaxList.TransferSyntaxSupported(transferSyntax);
         }
         return supported;
      }


      public bool AddPresentationContext(string abstractSyntax, string name, bool userDefined, bool supported)
      {
         PresentationContextEntry pcEntry;
         if (_pcList.TryGetValue(abstractSyntax, out pcEntry))
         {
            pcEntry._supported = true;
         }
         else
         {
            _pcList.Add(abstractSyntax, new PresentationContextEntry(abstractSyntax, name, userDefined, supported));
         }
         return true;
      }
      
      public bool UpdateUserDefinedIod(string abstractSyntax, string description)
      {
         bool ret = false;
         PresentationContextEntry pcEntry;
         if (_pcList.TryGetValue(abstractSyntax, out pcEntry))
         {
            pcEntry._name = description;
            ret = true;
         }
         return ret;
      }

      public bool AddPresentationContextWithDefaultTransferSyntax(string abstractSyntax, string name, bool userDefined, bool supported)
      {
         PresentationContextEntry pcEntry;
         if (_pcList.TryGetValue(abstractSyntax, out pcEntry))
         {
            pcEntry._supported = supported;
         }
         else
         {
            _pcList.Add(abstractSyntax, new PresentationContextEntry(abstractSyntax, name, userDefined, supported));
         }

         AddTransferSyntax(abstractSyntax, DicomUidType.ImplicitVRLittleEndian);
         AddTransferSyntax(abstractSyntax, DicomUidType.ExplicitVRLittleEndian);
         AddTransferSyntax(abstractSyntax, DicomUidType.ExplicitVRBigEndian);

         return true;
      }

      public PresentationContextEntry ChangePresentationContextSupport(string abstractSyntax, bool supported)
      {
         PresentationContextEntry pcEntry = null;
         if (_pcList.TryGetValue(abstractSyntax, out pcEntry))
         {
            pcEntry._supported = supported;
         }
         return pcEntry;
      }

      public PresentationContextEntry RemoveUserDefinedPresentationContext(string uid)
      {
         PresentationContextEntry pcEntry = null;
         if (_pcList.TryGetValue(uid, out pcEntry))
         {
            if (pcEntry._userDefined)
            {
               _pcList.Remove(uid);
            }
         }
         return pcEntry;
      }

      public bool AddTransferSyntax(string abstractSyntax, string transferSyntax)
      {
         PresentationContextEntry pcEntry;
         bool found = _pcList.TryGetValue(abstractSyntax, out pcEntry);
         if (!found)
         {
            return false;
         }
         
         if (_masterTransferSyntaxList.TransferSyntaxExists(transferSyntax))
         {
            if (!pcEntry._pcList.Contains(transferSyntax))
            {
               pcEntry._pcList.Add(transferSyntax);
            }
         }
         return true;
      }

      public bool AddTransferSyntax(string abstractSyntax, string []transferSyntaxes)
      {
         PresentationContextEntry pcEntry;
         bool found = _pcList.TryGetValue(abstractSyntax, out pcEntry);
         if (!found)
         {
            return false;
         }

         foreach (string transferSyntax in transferSyntaxes)
         {
            if (_masterTransferSyntaxList.TransferSyntaxExists(transferSyntax))
            {
               if (!pcEntry._pcList.Contains(transferSyntax))
               {
                  pcEntry._pcList.Add(transferSyntax);
               }
            }
         }
         return true;
      }

      public bool RemoveTransferSyntax(string abstractSyntax, string transferSyntax)
      {
         PresentationContextEntry pcEntry;
         bool found = _pcList.TryGetValue(abstractSyntax, out pcEntry);
         if (found)
         {
            if (!pcEntry._pcList.Contains(transferSyntax))
            {
               pcEntry._pcList.Remove(transferSyntax);
            }
         }
         return true;
      }

      public void ClearAllTransferSyntax(string abstractSyntax)
      {
         PresentationContextEntry pcEntry;
         bool found = _pcList.TryGetValue(abstractSyntax, out pcEntry);
         if (found)
         {
            pcEntry._pcList.Clear();
         }
      }
   }
}
