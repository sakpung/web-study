// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;


using Leadtools.Demos;
using Leadtools.Dicom;
using Leadtools.DicomDemos;

namespace DicomDemo
{
    public class MyDicomDataSet : DicomDataSet
    {
        private const long ELEMENT_LENGTH_MAX = (long)0xFFFFFFFFUL;
        private const Int32 ELEMENT_INDEX_MAX = -1;

        public MyDicomDataSet()
            : base()
        {
            // nothing extra
        }

        /*
         * Copies the elements of an MWL dataset (from Step4 (page3.cs) into a newly initialized dataset
         */
        public void MapMWLtoDS(DicomDataSet MWL_DS)
        {
            if (MWL_DS == null)
            {
                return;
            }

            try
            {
                DicomElement element;
                element = MWL_DS.GetFirstElement(null, true, true);
                while (element != null)
                {
                    if (!ReservedElement(element))
                    {
                       if (element.Tag == DemoDicomTags.ScheduledProcedureStepSequence)
                        {
                            DicomElement TmpElement;
                            TmpElement = MWL_DS.FindFirstElement(element, DemoDicomTags.ScheduledProcedureStepID, false);
                            if (TmpElement != null)
                                MapElement(MWL_DS, TmpElement);

                             TmpElement = MWL_DS.FindFirstElement(element, DemoDicomTags.ScheduledProcedureStepDescription, false);
                            if (TmpElement != null)
                                MapElement(MWL_DS, TmpElement);
                        }
                        else if (!MapElement(MWL_DS, element))
                        {
                            CopyElement(MWL_DS, element, null);
                        }
                    }

                    // Traverse as tree
                    element = MWL_DS.GetNextElement(element, true, true);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Determines whether an emlement is reserved (and thus not be changed) or not.
         */
        private bool ReservedElement(DicomElement element)
        {
            bool bRet = false;

            if (element == null)
                return bRet;

            try
            {
                switch (element.Tag)
                {
                   case DemoDicomTags.MediaStorageSOPClassUID:
                   case DemoDicomTags.TransferSyntaxUID:
                   case DemoDicomTags.SOPClassUID:
                   case DemoDicomTags.SeriesInstanceUID:
                   case DemoDicomTags.SOPInstanceUID:
                        bRet = true;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            return bRet;
        }

        /*
         * Finds the element that matches the element from the MWL dataset and copies the data
         */
        private bool MapElement(DicomDataSet MWL_DS, DicomElement element)
        {
            if ((MWL_DS) == null || (element == null))
                return false;

            try
            {
                DicomElement DstElement;

                switch (element.Tag)
                {
                    // This group is put under the sequence TAG_REQUESTED_PROCEDURE_ID
                   case DemoDicomTags.RequestedProcedureID:
                   case DemoDicomTags.ScheduledProcedureStepID:
                   case DemoDicomTags.ScheduledProcedureStepDescription:
                   case DemoDicomTags.ScheduledProtocolCodeSequence:
                        DicomElement ReqProcIDElement;
                        ReqProcIDElement = FindFirstElement(null, DemoDicomTags.RequestAttributesSequence, true);
                        if (ReqProcIDElement != null)
                        {
                            //Get grandchild
                            DstElement = GetChildElement(ReqProcIDElement, true);
                            if (DstElement == null)
                                return false;

                            DstElement = GetChildElement(DstElement, true);
                            if (DstElement == null)
                                return false;

                            DstElement = FindFirstElement(DstElement, element.Tag, true);
                            if (DstElement == null)
                                return false;

                            CopyElementData(DstElement, element, MWL_DS);
                        }
                        break;

                    //This group maps one tag to a different tag
                     case DemoDicomTags.NamesOfIntendedRecipientsOfResults:
                        DstElement = FindFirstElement(null, DemoDicomTags.PhysicianOfRecord, true);
                        if (DstElement != null)
                            CopyElementData(DstElement, element, MWL_DS);
                        break;

                     case DemoDicomTags.ScheduledPerformingPhysicianName:
                        DstElement = FindFirstElement(null, DemoDicomTags.OperatorName, true);
                        if (DstElement != null)
                            CopyElementData(DstElement, element, MWL_DS);
                        break;

                     case DemoDicomTags.ScheduledProcedureStepLocation:
                        DstElement = FindFirstElement(null, DemoDicomTags.PerformedProcedureStepID, true);
                        if (DstElement != null)
                            CopyElementData(DstElement, element, MWL_DS);
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            return false;
        }

        /*
         * Checks to make sure the element is a sequence or regular element and copies the data accordingly
         */
        private void CopyElement(DicomDataSet MWL_DS, DicomElement MWLElement, DicomElement ParentElement)
        {
            try
            {
                if ((MWL_DS == null) || (MWLElement == null))
                    return;

                DicomElement DstElement = FindFirstElement(ParentElement, MWLElement.Tag, true);
                if (DstElement == null)
                    return;

                if (MWLElement.Length == 0)
                    return;

                // element is a sequence
                if (MWLElement.Length == ELEMENT_LENGTH_MAX)
                {
                    CopySequence(MWL_DS, MWLElement, ParentElement);
                    return;
                }

                CopyElementData(DstElement, MWLElement, MWL_DS);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Copies the data from one element to another.
         */
        bool CopyElementData(DicomElement DstElement, DicomElement SrcElement, DicomDataSet SrcDS)
        {
            try
            {
                if ((DstElement == null) || (SrcElement == null) || (SrcDS == null))
                    return false;

                if ((SrcElement.Length == 0) || (SrcElement.Length == ELEMENT_LENGTH_MAX) || (DstElement.Length == ELEMENT_LENGTH_MAX))
                    return false;

                byte[] BinaryValue = SrcDS.GetBinaryValue(SrcElement, (int)SrcElement.Length);
                SrcDS.SetBinaryValue(DstElement, BinaryValue, (int)SrcElement.Length);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            return true;
        }

        /*
         * Copies the data in one sequence element to another.
         */
        private void CopySequence(DicomDataSet MWL_DS, DicomElement MWLSequenceElement, DicomElement ParentElement)
        {
            try
            {
                DicomElement newElement = null;
                DicomElement deleteElement = FindFirstElement(ParentElement, MWLSequenceElement.Tag, true);
                if (deleteElement != null)
                {
                    DeleteElement(deleteElement);
                    newElement = InsertElement(
                        ParentElement,
                        false,
                        MWLSequenceElement.Tag,
                        MWLSequenceElement.VR,
                        MWLSequenceElement.Length == ELEMENT_LENGTH_MAX,
                        ELEMENT_INDEX_MAX
                        );
                    if (newElement != null)
                        Copy(MWL_DS, newElement, MWLSequenceElement);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Sets the SpecificCharacterSet tag
         */
        public void SetTagSpecificCharacterSet()
        {
            try
            {
               DicomElement element = FindFirstElement(null, DemoDicomTags.SpecificCharacterSet, false);
                if (element != null)
                    SetStringValue(element, "ISO_IR 100", DicomCharacterSetType.Default);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Sets the InstanceNumber tag.
         */
        public void SetTagInstanceNumber(int nInstance)
        {
            try
            {
               DicomElement element = FindFirstElement(null, DemoDicomTags.InstanceNumber, false);
                if ((element != null) && (element.Length == 0))
                {
                    int[] nValue = new int[] { nInstance };
                    SetIntValue(element, nValue, 1);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Traverse dataset as a list, and for each empty element do the following:
         * Type 3 sequence:  if entire sequence empty, delete the sequence
         * Type 3 element:   delete element
         */
        public void DeleteEmptyElementsType3(DicomClassType nClass)
        {
            try
            {
                DicomElement PrevElement = null;
                DicomElement element;
                DicomIod IODClass = DicomIodTable.Instance.FindClass(nClass);

                if (IODClass != null)
                {
                    DicomIod IOD;

                    element = GetFirstElement(null, false, true);
                    PrevElement = null;
                    while (element != null)
                    {
                       // Get the IOD class of the element.
#if (LTV15_CONFIG)
                       if (element.Tag != DemoDicomTags.Undefined)
                        {
                            IOD = DicomIodTable.Instance.Find(IODClass, element.Tag, DicomIodType.Element, false);
                        }
                        else
                        {
                           IOD = DicomIodTable.Instance.Find(IODClass, (DicomTagType)element.UserTag, DicomIodType.Element, false);
                        }
#else
                       IOD = DicomIodTable.Instance.Find(IODClass, element.Tag, DicomIodType.Element, false);
#endif

                       if ((IOD != null) && (IOD.Usage == DicomIodUsageType.OptionalElement))
                        {
                            
                            if (element.Length == ELEMENT_LENGTH_MAX) // Sequence
                            {
                                bool bEmptySequence = IsEmptySequence(element);
                                if (bEmptySequence)
                                {
                                    DeleteElement(element);
                                    element = PrevElement;
                                    
                                    // if deleting the first element, PrevElement is null,
                                    // therefore we must call GetFirstElement
                                    if (element == null)
                                        element = GetFirstElement(null, false, true);
                                }
                            }
                            else if (element.Length == 0) // Empty element
                            {
                                DeleteElement(element);
                                element = PrevElement;

                                // if deleting the first element, PrevElement is null,
                                // therefore we must call GetFirstElement
                                if (element == null)
                                    element = GetFirstElement(null, false, true);
                            }
                        }

                        PrevElement = element;
                        element = GetNextElement(element, false, true);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Deletes any empty, optional modules.
         */
        public void DeleteEmptyModulesOptional(DicomClassType nClass)
        {
            try
            {
                DicomIod IOD;
                int i = 0;
                do
                {
                    IOD = DicomIodTable.Instance.FindModuleByIndex(nClass, i);
                    if ((IOD != null) && (IOD.Usage == DicomIodUsageType.OptionalModule))
                    {
                        DicomModule module = FindModule(IOD.ModuleCode);
                        if ((module != null) && IsEmptyModule(module))
                            DeleteModule(IOD.ModuleCode);
                    }
                    i++;
                } while (IOD != null);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Determines whether or not a module is empty based on the module type.
         */
        public bool IsEmptyModule(DicomModuleType moduleType)
        {
            bool bEmpty = true;

            try
            {
                DicomModule module;

                module = FindModule(moduleType);
                if (module != null)
                    bEmpty = IsEmptyModule(module);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            return bEmpty;
        }

        /*
         * Determines whether or not a module is empty based on the module.
         */
        public bool IsEmptyModule(DicomModule module)
        {
            if (module == null)
                return true;
            
            bool bEmpty = true;

            try
            {
                for (int i = 0; i < module.Elements.Length; i++)
                {
                    if (module.Elements[i].Length == ELEMENT_LENGTH_MAX)
                    {
                        bEmpty = bEmpty && IsEmptySequence(module.Elements[i]);
                    }
                    else if (module.Elements[i].Length != 0)
                    {
                        bEmpty = false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            
            return bEmpty;
        }

        /*
         * Inserts a UID if not already present
         */
#if (LTV15_CONFIG)
       public void InsertUID(DicomTagType nUID)
       {
          InsertUID((long)nUID);
       }
#endif
        public void InsertUID(long nUID)
        {
            try
            {
                DicomElement element;
                string strUID;
                element = FindFirstElement(null, nUID, false);
                if ((element != null) && (element.Length == 0))
                {
                    strUID = Utils.GenerateDicomUniqueIdentifier();
                    SetStringValue(element, strUID, DicomCharacterSetType.UnicodeInUtf8);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Genenerates a study instance UID if not already present
         */
        public void GenerateStudyInstanceUID()
        {
            try
            {
                DicomElement element;
                element = FindFirstElement(null, DemoDicomTags.StudyInstanceUID, false);
                if ((element != null) && (element.Length == 0))
                   InsertUID(DemoDicomTags.StudyInstanceUID);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Determines whether or not a sequence element is empty.
         */
        private bool IsEmptySequence(DicomElement SequenceElement)
        {
            DicomElement ItemElement;
            DicomElement element;
            bool bEmpty;

            bEmpty = true;
            try
            {
                ItemElement = GetChildElement(SequenceElement, true);

                while (ItemElement != null)
                {
                    element = GetChildElement(ItemElement, true);
                    while (element != null)
                    {
                        // If a sequence, make a recursive call
                        if (element.Length == ELEMENT_LENGTH_MAX)
                        {
                            bEmpty = (bEmpty && IsEmptySequence(element));
                        }
                        else if (element.Length != 0)
                        {
                            bEmpty = false;
                        }
                        element = GetNextElement(element, true, true);
                    }
                    ItemElement = GetNextElement(ItemElement, true, true);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            return bEmpty;
        }

        /*
         * Returns the first empty type 1 mandatory element in the dataset
         */
        public DicomElement GetFirstEmptyElementType1(DicomClassType nClass, ref string strTag, ref string strDesc)
        {
            DicomElement element = null;

            try
            {
                DicomIod IODClass = DicomIodTable.Instance.FindClass(nClass);
                if (IODClass != null)
                {
                    DicomIod IOD;
                    element = GetFirstElement(null, false, true);
                    long tagValue;
                    while (element != null)
                    {
                        // Get the IOD class of the element
#if (LTV15_CONFIG)
                       if (element.Tag != DemoDicomTags.Undefined)
                        {
                            IOD = DicomIodTable.Instance.Find(IODClass, element.Tag, DicomIodType.Element, false);
                            tagValue = (long)element.Tag;
                        }
                        else
                        {
                           IOD = DicomIodTable.Instance.Find(IODClass, (DicomTagType)element.UserTag, DicomIodType.Element, false);
                            tagValue = element.UserTag;
                        }
#else
                       IOD = DicomIodTable.Instance.Find(IODClass, element.Tag, DicomIodType.Element, false);
                       tagValue = (long)element.Tag;
#endif
                        
                        // if the element is an empty type 1 mandatory element, update the tag string and return
                        // the element
                        if ((IOD != null) && (IOD.Usage == DicomIodUsageType.Type1MandatoryElement) && (element.Length == 0) && (element.Length != ELEMENT_LENGTH_MAX))
                        {
                            strTag = String.Format("{0:X4}:{1:X4}",
                                Utils.GetGroup(tagValue),
                                Utils.GetElement(tagValue));
                            strDesc = IOD.Name;
                            return element;
                        }

                        element = GetNextElement(element, false, true);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            return element;
        }

        /*
         * Returns the next empty type 1 mandatory element in the dataset
         */
        public DicomElement GetNextEmptyElementType1(DicomElement element, DicomClassType nClass, ref string strTag, ref string strDesc)
        {
            if (element == null)
                return null;

            try
            {
                DicomIod IODClass = DicomIodTable.Instance.FindClass(nClass);
                if (IODClass != null)
                {
                    DicomIod IOD;
                    element = GetNextElement(element, false, true);
                    long tagValue;
                    while (element != null)
                    {
                       // Get the IOD class of the element
#if (LTV15_CONFIG)
                       if (element.Tag != DemoDicomTags.Undefined)
                        {
                            IOD = DicomIodTable.Instance.Find(IODClass, element.Tag, DicomIodType.Element, false);
                            tagValue = (long)element.Tag;
                        }
                        else
                        {
                           IOD = DicomIodTable.Instance.Find(IODClass, (DicomTagType)element.UserTag, DicomIodType.Element, false);
                            tagValue = element.UserTag;
                        }
#else
                       IOD = DicomIodTable.Instance.Find(IODClass, element.Tag, DicomIodType.Element, false);
                       tagValue = (long)element.Tag;
#endif

                       // if the element is an empty type 1 mandatory element, update the tag string and return
                        // the element
                        if ((IOD != null) && (IOD.Usage == DicomIodUsageType.Type1MandatoryElement) && (element.Length == 0) && (element.Length != ELEMENT_LENGTH_MAX))
                        {
                            strTag = String.Format("{0:X4}:{1:X4}",
                                Utils.GetGroup(tagValue),
                                Utils.GetElement(tagValue));
                            strDesc = IOD.Name;
                            return element;
                        }

                        element = GetNextElement(element, false, true);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            return element;
        }
    }
}
