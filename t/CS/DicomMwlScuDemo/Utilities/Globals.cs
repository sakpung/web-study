// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;

using Leadtools.Dicom;
using Leadtools.DicomDemos;

namespace DicomDemo
{
    /*
     * Object that contains objects and properties that needs to be shared between multiple pages.
     */
    public class Globals
    {
       static public bool _closing = false;
        // Page 0
        public int m_nTimerMax;

        // Page 1
        public DicomServer m_MWLServer;
        public string m_strMWLClientAE;
        public bool bMWLServerValid;

        // Page 2
        public int m_nQueryType; // 1 = Broad, 2 = Patient
        // Broad
        public bool m_bCheckScheduledDate;
        public bool m_bCheckModality;
        public DateTime m_ScheduledDate;
        public string m_strModality;
        // Patient
        public string m_strAccessionNumber;
        public string m_strPatientID;
        public string m_strPatientName;
        public string m_strRequestedProcedureID;

        // Modality Table
        public ModalityItem[] m_ModalityTable = new ModalityItem[] {
            //IF YOU ADD NEW ITEMS TO THIS LIST, MAKE SURE THEY ARE SORTED BY THE CLASS (1st parameter)
            new ModalityItem("CR", "Computed Radiography", DicomClassType.CRImageStorage),
            new ModalityItem("CT", "Computed Tomography", DicomClassType.CTImageStorage),
            new ModalityItem("DX", "Digital Radiography", DicomClassType.DXImageStoragePresentation),
            new ModalityItem("ES", "Endoscopy", DicomClassType.VLEndoscopicImageStorage),
            new ModalityItem("GM", "General Microscopy", DicomClassType.VLMicroscopicImageStorage),
            new ModalityItem("IO", "Intra-oral Radiography", DicomClassType.DXIntraoralImageStoragePresentation),
            new ModalityItem("MG", "Mammography", DicomClassType.DXMammographyImageStoragePresentation),
            new ModalityItem("MR", "Magnetic Resonance", DicomClassType.MRImageStorage),
            new ModalityItem("NM", "Nuclear Medicine", DicomClassType.NMImageStorage),
            new ModalityItem("PX", "Panoramic X-Ray", DicomClassType.DXImageStoragePresentation),
            new ModalityItem("RF", "Radio Fluoroscopy", DicomClassType.XRFImageStorage),
            new ModalityItem("RTDOSE", "Radiotherapy Dose", DicomClassType.RTDoseStorage),
            new ModalityItem("RTIMAGE", "Radiotherapy Image", DicomClassType.RTImageStorage),
            new ModalityItem("RTPLAN", "Radiotherapy Plan", DicomClassType.RTPlanStorage),
            new ModalityItem("RTSTRUCT", "Radiotherapy Structure Set", DicomClassType.RTStructureSetStorage),
            new ModalityItem("SC", "Secondary Capture Image", DicomClassType.SCImageStorage),
            new ModalityItem("SM", "Slide Microscopy", DicomClassType.VLSlideCoordinatesMicroscopicImageStorage),
            new ModalityItem("US", "Ultrasound", DicomClassType.USImageStorage),
            new ModalityItem("XA", "X-Ray Angiography", DicomClassType.XAImageStorage),
            new ModalityItem("XC", "External-camera Photography", DicomClassType.VLPhotographicImageStorage)
            };

        // Page 3 and 4
        public MyTreeView m_TreeResult;
        public ImageList m_IconImageList;
        public DicomClassType m_nClass;

        // Page 5
        public MyDicomDataSet m_DS;
        public bool m_bMandatoryElementsFilled;

        // Page 6
        public DicomServer m_StorageServer;
        public string m_strStorageClientAE;
        public bool m_bStoreOnServer;

        public Globals()
        {
            // Set default values and initialize objects
            // PAGE 0
            m_nTimerMax = 15;

            // PAGE 1
            m_MWLServer = new DicomServer();
            m_MWLServer.AETitle = "LEAD_SERVER";
            m_MWLServer.Address = IPAddress.Parse("127.0.0.1");
            m_MWLServer.Port = 104;

            m_strMWLClientAE = "LEAD_CLIENT";

            // PAGE 2
            m_nQueryType = 1;

            m_bCheckScheduledDate = false;
            m_bCheckModality = false;
            m_ScheduledDate = DateTime.Today;
            m_strModality = m_ModalityTable[0].m_strValue;

            m_strAccessionNumber = "";
            m_strPatientID = "";
            m_strPatientName = "";
            m_strRequestedProcedureID = "";

            // PAGE 3 & 4
            m_TreeResult = new MyTreeView();
            m_TreeResult.Dock = DockStyle.Fill;

            // Build the icon image list
            m_IconImageList = new ImageList();
            m_IconImageList.Images.Add(
                new System.Drawing.Icon(typeof(Globals), "Resources.icoElement.ico"));
            m_IconImageList.Images.Add(
                new System.Drawing.Icon(typeof(Globals), "Resources.icoFolder.ico"));
            m_IconImageList.Images.Add(
                new System.Drawing.Icon(typeof(Globals), "Resources.icoMissing.ico"));
            m_IconImageList.Images.Add(
                new System.Drawing.Icon(typeof(Globals), "Resources.icoSequence.ico"));
            m_IconImageList.Images.Add(
                new System.Drawing.Icon(typeof(Globals), "Resources.icoWorklist.ico"));

            m_TreeResult.ImageList = m_IconImageList;

            // PAGE 5
            m_DS = new MyDicomDataSet();

            // Page 6
            m_StorageServer = new DicomServer();
            m_StorageServer.AETitle = "LEAD_SERVER";
            m_StorageServer.Address = IPAddress.Parse("127.0.0.1");
            m_StorageServer.Port = 104;
            m_strStorageClientAE = "LEAD_CLIENT";
            m_bStoreOnServer = true;
        }
    }


    /* 
     * Class used for populating and using the Modalities on Page2
     */
    public class ModalityItem
    {
        public string m_strValue;
        public string m_strDescription;
        public DicomClassType m_DicomClassType;

        public ModalityItem()
        {
            m_strValue = "";
            m_strDescription = "";
            m_DicomClassType = (DicomClassType)0;
        }

        public ModalityItem(string Value, string Description, DicomClassType ClassType)
        {
            m_strValue = Value;
            m_strDescription = Description;
            m_DicomClassType = ClassType;
        }

        public override string ToString()
        {
            return m_strValue + " - " + m_strDescription;
        }
    }

    /*
     * Enumeration type for the icons used by the MyTreeView and MyListView classes
     */
    public enum MyIconIndex : int
    {
        Element,
        Folder,
        Missing,
        Sequence,
        Worklist
    }
}
