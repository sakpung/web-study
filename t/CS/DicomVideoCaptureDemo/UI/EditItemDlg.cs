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
   public partial class EditItemDlg : Form
   {
      public String strValue 
      {
         get { return _txtBox_Value.Text; }
         set { _txtBox_Value.Text = value; }
      }

      public String strVRInfo
      {
         get { return _txtBox_VR_Info.Text; }
         set { _txtBox_VR_Info.Text = value; }
      }

      public EditItemDlgEnums m_nType;
      public DicomVRType m_nVR;
      public int m_nSelected;

      public enum EditItemDlgEnums
      {
         INSERT_ITEM,
         MODIFY_ITEM,
      };

      

      public EditItemDlg()
      {
         InitializeComponent();
      }

      void EnableDateCtrl(bool bEnable)
      {
         _txtBox_Value.Visible = !bEnable;
         _dateTimePicker.Visible = bEnable;
      }

      private void _btn_OK_Click(object sender, EventArgs e)
      {
         if (m_nVR == DicomVRType.DA)
         {
            strValue = GetDate();
         }
         else
         {
            strValue = _txtBox_Value.Text;
         }

         strValue.TrimStart();
         strValue.TrimEnd();
      }


      bool SetDate(String strDate)
      {
         strDate.TrimStart();
         strDate.TrimEnd();
         if (strDate.Length != 10)
            return false;

         
         char[] szDate=strDate.ToCharArray();

         if ((szDate[2] != '/') || (szDate[5] != '/'))
            return false;

         int mm,dd,yyyy;
         mm = Convert.ToInt32(szDate[0])<<1+Convert.ToInt32(szDate[1]);
         dd = Convert.ToInt32(szDate[3])<<1+Convert.ToInt32(szDate[4]);
         yyyy = Convert.ToInt32(szDate[6])<<3 + 
            Convert.ToInt32(szDate[7])<<2+
            Convert.ToInt32(szDate[8])<<1+
            Convert.ToInt32(szDate[9]);

         _dateTimePicker.Value = new DateTime(yyyy, mm, dd);

         return true;
      }

      string GetDate()
      {
         int mm,dd,yyyy;
         mm = _dateTimePicker.Value.Month;
         dd = _dateTimePicker.Value.Day;
         yyyy = _dateTimePicker.Value.Year;
         return string.Format("{0:D2}/{1:D2}/{2:D4}", mm, dd, yyyy);
      }

      private void EditItemDlg_Load(object sender, EventArgs e)
      {
         switch (m_nType)
         {
            case EditItemDlgEnums.INSERT_ITEM:
               this.Text = "Insert Item";
               break;

            case EditItemDlgEnums.MODIFY_ITEM:
               this.Text = "Modify Item";
               break;
         }

         if (m_nVR == DicomVRType.DA)
         {
            EnableDateCtrl(true);
            _dateTimePicker.Format = DateTimePickerFormat.Custom;
            _dateTimePicker.CustomFormat = "MM/dd/yyy";
            SetDate(strValue);
            _dateTimePicker.Focus();
         }
         else
         {
            EnableDateCtrl(false);
            _txtBox_Value.SelectionStart = 0;
            _txtBox_Value.SelectionLength = _txtBox_Value.Text.Length;
            _txtBox_Value.Focus();
         }
      }
   }
}
