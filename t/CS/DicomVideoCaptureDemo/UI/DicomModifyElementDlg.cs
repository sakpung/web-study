// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.Dicom;

namespace DicomVideoCaptureDemo.UI
{
   public partial class DicomModifyElementDlg : Form
   {
      public DicomVRType m_nVR;
      public String m_strValue = "";
      public int m_nCount;
      public DicomElement m_pElement;
      public DicomIod m_pDicomIOD;

      public String strDesc = "";

      public String strHint 
      {
         get{return _txtBox_Description.Text;}
         set{_txtBox_Description.Text = value;}
      }

      public String strCode 
      {
         get{return _txtBox_Code.Text;}
         set{_txtBox_Code.Text = value;}
      }

      public String strName 
      {
         get{return _txtBox_Name.Text;}
         set{_txtBox_Name.Text = value;}
      }

      public String strUsage 
      {
         get{return _txtBox_Usage.Text;}
         set{_txtBox_Usage.Text = value;}
      }

      public String strVR 
      {
         get{return _txtBox_VR.Text;}
         set{_txtBox_VR.Text = value;}
      }

      public String strVRMultiplicity 
      {
         get{return _txtBox_VR_Multiplicity.Text;}
         set{_txtBox_VR_Multiplicity.Text = value;}
      }

      public String strStaticInstructions 
      {
         get{return _label_InstructModifyElement.Text;}
         set{_label_InstructModifyElement.Text = value;}
      }

      public String m_strVRInfo = "";
      public bool m_bMultipleItems;


      public DicomModifyElementDlg()
      {
         InitializeComponent();
      }

      // Determines which buttons will be enabled/disabled
      void EnableItems(bool bEnable)
      {
         int nListCount = _lstBox_Value.Items.Count;
         _btn_Modify.Enabled = bEnable;
         if (nListCount == 0)
         {
            _btn_Modify.Text = "&Insert";
         }
         else
         {
            _btn_Modify.Text = "&Modify";
         }

         ResizeListBox();

         _btn_InsertBefore.Enabled = bEnable && m_bMultipleItems && (nListCount >= 1);
         _btn_InsertAfter.Enabled = bEnable && m_bMultipleItems && (nListCount >= 1);
         _btn_Delete.Enabled = bEnable && (nListCount >= 1);
         _lstBox_Value.Focus();
      }

      // Determines which buttons will be visible/invisible
      void ShowItems()
      {
         //int nListCount = m_ListValue.GetCount();
         _btn_Modify.Visible = true;

         _btn_InsertBefore.Visible = m_bMultipleItems;
         _btn_InsertAfter.Visible = m_bMultipleItems;
         _btn_Delete.Visible = true;
         _lstBox_Value.Focus();
      }

      void ResizeListBox()
      {
         Rectangle rcTree = new Rectangle();

         // if single item and empty, hide the list box and display a disabled text box
         int nListCount = _lstBox_Value.Items.Count;
         if (nListCount == 0)
         {
            if (m_bMultipleItems)
               _txtBox_ValueMulti.Visible = true;
            else
               _txtBox_ValueSingle.Visible = true;
            _lstBox_Value.Visible = false;
            return;
         }


         _txtBox_ValueSingle.Visible=false;
         _txtBox_ValueMulti.Visible = false;
         if (m_bMultipleItems)
         {
            //IDC_EDIT_VALUE_MULTI is a placeholder
            rcTree.Size = _txtBox_ValueMulti.Size;
            rcTree.Location = _txtBox_ValueMulti.Location;
         }
         else
         {
            //IDC_EDIT_VALUE_SINGLE is a placeholder
            rcTree.Size = _txtBox_ValueSingle.Size;
            rcTree.Location = _txtBox_ValueSingle.Location;
         }

         // Reposition and size 
         _lstBox_Value.Location = rcTree.Location;
         _lstBox_Value.Size = rcTree.Size;
         _lstBox_Value.Visible = true;
         
      }


      void PopulateListBox()
      {

         String strCopy = m_strValue;
         string pszCopy = strCopy;
         string[] p = pszCopy.Split('\\');


         int i;
         for (i = 0; i < m_nCount; i++)
         {
            if (p.Length > i)
               _lstBox_Value.Items.Add(p[i]);
         }
      }

      String GetStringTag(long uTag)
      {
         String strRet;
         strRet = String.Format("{0:X4}:{1:X4}",(UInt16) ((long)uTag>>16), (UInt16)((long)uTag&0xFFFF));
         return strRet;
      }

      DicomVRType GetVRInfo(DicomVRType nVR, ref String strVR, ref String strVRDetail)
      {
         bool bMulti = false;
         DicomVR pVR = DicomVRTable.Instance.Find(nVR);
         if (pVR!=null)
         {
            strVR = pVR.Name;
            if (((pVR.Restriction & DicomVRRestriction.BinaryFixed)==DicomVRRestriction.BinaryFixed) || 
               ((pVR.Restriction & DicomVRRestriction.StringFixed)==DicomVRRestriction.StringFixed))
            {
               bMulti = true;
            }
         }
         else
         {
            nVR  = DicomVRType.UN;
            strVR = "Unknown";
            bMulti = true;
         }

         switch (nVR)
         {
         case DicomVRType.OB:
         case DicomVRType.UN:
            strVRDetail = "Hexadecimal";
            break;

         case DicomVRType.SS:
         case DicomVRType.US:
         case DicomVRType.OW:
         case DicomVRType.SL:
         case DicomVRType.IS:
         case DicomVRType.UL:
            strVRDetail = "Integer";
            break;

         case DicomVRType.AT:
            strVRDetail = "Group:Element\r\n(Group and Element should be hexadecimal words)";
            break;

         case DicomVRType.FD:
         case DicomVRType.FL:
         case DicomVRType.DS:
            strVRDetail = "Float";
            break;

         case DicomVRType.CS:
         case DicomVRType.SH:
         case DicomVRType.LO:
         case DicomVRType.AE:
         case DicomVRType.LT:
         case DicomVRType.ST:
         case DicomVRType.UI:
         case DicomVRType.UT:
         case DicomVRType.PN:
            if (bMulti != false)
            {
               strVRDetail = "String";
            }
            else
            {
               strVRDetail = "Text";
            }
            break;

         case DicomVRType.AS:
            strVRDetail = "Number Reference\r\n(Reference = 'days' or 'weeks' or 'months' or 'years')";
            break;

         case DicomVRType.DA:
            {
               strVRDetail = "MM/DD/YYYY\r\n(MM=Month, DD=Day, YYYY=Year)";
               /*
               EnableDateCtrl(TRUE);
               m_Date.SetFormat("MM/dd/yyy");
               m_Date.SetDate(m_strValue);
               */
            }
            break;

         case DicomVRType.DT:
               strVRDetail = "MM/DD/YYYY HH:MM:SS.FFFFFF+OOOO\r\n(MM=Month, DD=Day, YYYY=Year)\r\n(HH=Hours, MM=Minutes, SS=Seconds, FFFFFF=Fractional Second, OOOO=Offset from Coordinated Universal Time)";
            break;

         case DicomVRType.TM:
            strVRDetail = "HH:MM:SS.FFFF\r\n(HH=Hours, MM=Minutes, SS=Seconds, FFFFFF=Fractional Second)";
            break;

         default:
            strVRDetail = "";
            break;
         }
         return nVR;
      }

      String GetUsage(DicomIodUsageType nUsage)
      {
         String strUsage = "";
         switch(nUsage)
         {
         case DicomIodUsageType.MandatoryModule:
            strUsage = "Mandatory";
            break;

         case DicomIodUsageType.ConditionalModule:
            strUsage = "Conditional";
            break;

         case DicomIodUsageType.OptionalModule:
            strUsage = "Optional";
            break;

         case DicomIodUsageType.Type1MandatoryElement:
            strUsage = "Mandatory -- Type 1";
            break;

         case DicomIodUsageType.Type1ConditionalElement:
            strUsage = "Conditional -- Type 1";
            break;

         case DicomIodUsageType.Type2MandatoryElement:
            strUsage = "Mandatory -- Type 2";
            break;

         case DicomIodUsageType.Type2ConditionalElement:
            strUsage = "Conditional -- Type 2";
            break;

         case DicomIodUsageType.OptionalElement:
            strUsage = "Mandatory -- Type 3";
            break;
         }
         return strUsage;
      }

      private void _btn_Modify_Click(object sender, EventArgs e)
      {
         EditItemDlg dlg=new EditItemDlg();
         dlg.m_nType = EditItemDlg.EditItemDlgEnums.MODIFY_ITEM;
         int nSelected = _lstBox_Value.SelectedIndex;

         if (nSelected >= 0)
            dlg.strValue = _lstBox_Value.Items[nSelected] as string;
         else
            nSelected = 0;

         dlg.m_nVR = m_nVR;
         dlg.strVRInfo = m_strVRInfo;
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            if (dlg.strValue.Length>0)
            {
               _lstBox_Value.Items.Insert(nSelected, dlg.strValue);
               if (_lstBox_Value.Items.Count > (nSelected+1))
                  _lstBox_Value.Items.RemoveAt(nSelected + 1);
            }
            else
            {
               if (_lstBox_Value.Items.Count > nSelected)
                  _lstBox_Value.Items.RemoveAt(nSelected);
            }

            _lstBox_Value.SelectedIndex = nSelected;
         }
         
         EnableItems(true);
         ShowItems();
      }

      private void _btn_Delete_Click(object sender, EventArgs e)
      {
         int nSelected = _lstBox_Value.SelectedIndex;
         if (nSelected >= 0)
         {
            _lstBox_Value.Items.RemoveAt(nSelected);
            nSelected = nSelected <= 0 ? 0 : nSelected - 1;
            if (_lstBox_Value.Items.Count > 0)
               _lstBox_Value.SelectedIndex = nSelected;
            else
               _lstBox_Value.SelectedIndex = -1;
         }
         EnableItems(true);
         ShowItems();
      }

      private void _btn_InsertBefore_Click(object sender, EventArgs e)
      {
         OnInsert(false);
      }

      private void _btn_InsertAfter_Click(object sender, EventArgs e)
      {
         OnInsert(true);
      }

      void OnInsert(bool bAfter)
      {
         EditItemDlg dlg=new EditItemDlg();
         dlg.m_nType = EditItemDlg.EditItemDlgEnums.INSERT_ITEM;
         int nSelected = _lstBox_Value.SelectedIndex;
         if (nSelected < 0)
            nSelected = 0;
         
         dlg.strValue = "";
         dlg.m_nVR = m_nVR;
         dlg.strVRInfo = m_strVRInfo;
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            if (bAfter)
               nSelected++;
            _lstBox_Value.Items.Insert(nSelected, dlg.strValue);
            _lstBox_Value.SelectedIndex = nSelected;
         }
         EnableItems(true);
      }

      private void _btn_OK_Click(object sender, EventArgs e)
      {
         int i;
         String strTmp;
         m_strValue = "";
         m_nCount = _lstBox_Value.Items.Count;
         for (i = 0; i < m_nCount; i++)
         {
            if (m_strValue.Length > 0)
               m_strValue += "\\";
            strTmp = _lstBox_Value.Items[i] as string;
            if (strTmp.Length>0)
               m_strValue += strTmp;
         }
      }

      void ExchangeData() 
      {
         _txtBox_Description.Text = strHint;
         _txtBox_Code.Text = strCode;
         _txtBox_Name.Text = strName;
         _txtBox_Usage.Text = strUsage;
         _txtBox_VR.Text = strVR;
         _txtBox_VR_Multiplicity.Text = strVRMultiplicity;
         _label_InstructModifyElement.Text = strStaticInstructions;
      }

      private void DicomModifyElementDlg_Load(object sender, EventArgs e)
      {
         //m_strValue = m_pMyTreeData->m_strValue;
         if (m_pDicomIOD != null)
         {
            strCode = GetStringTag(m_pDicomIOD.TagCode);
            strName = m_pDicomIOD.Name;
            strUsage = GetUsage(m_pDicomIOD.Usage);
            strHint = m_pDicomIOD.Description;

            DicomTag pDicomTag = DicomTagTable.Instance.Find(m_pDicomIOD.TagCode);
            if (pDicomTag != null)
            {

               if (pDicomTag.MinVM == pDicomTag.MaxVM)
               {
                  m_bMultipleItems = pDicomTag.MinVM > 1;
                  strVRMultiplicity = string.Format("Exactly {0:D} value", pDicomTag.MinVM);
                  if (pDicomTag.MinVM > 1)
                     strVRMultiplicity += "s";
               }

               else if (pDicomTag.MaxVM == -1)
               {
                  m_bMultipleItems = true;
                  strVRMultiplicity = string.Format("At least {0:D} value", pDicomTag.MinVM);
                  if (pDicomTag.MinVM > 1)
                     strVRMultiplicity += "s";
               }

               else
               {
                  m_bMultipleItems = true;
                  strVRMultiplicity = string.Format("{0:D} to {0:D} values", pDicomTag.MinVM);
               }

               strVRMultiplicity += ".";

               if (pDicomTag.VMDivider != 1)
               {
                  String strTemp;
                  strTemp = string.Format("Count must be divisible by {0:D}.", pDicomTag.VMDivider);
                  strVRMultiplicity += strTemp;
               }
            }
         }
         m_nVR = m_pElement.VR;
         string tempStrVR = strVR;
         GetVRInfo(m_nVR, ref tempStrVR, ref m_strVRInfo);
         strVR = tempStrVR;
         PopulateListBox();


         if (m_bMultipleItems)
         {
            strStaticInstructions = "Select an existing item, and click 'Modify' to change a value, or an 'Insert' button to insert a new value. Double-click an item to modify it.";
         }
         else
         {
            strStaticInstructions = "Click 'Insert' to add a value, 'Delete' to delete the value, or 'Modify' to change a value.  Double-click an item to modify it.";
         }

         _txtBox_ValueMulti.Visible = false;
         _txtBox_ValueSingle.Visible = false;

         EnableItems(true);
         ShowItems();
         _lstBox_Value.Focus();
         if (_lstBox_Value.Items.Count > 0)
             _lstBox_Value.SelectedIndex = 0;
      }
   }
}
