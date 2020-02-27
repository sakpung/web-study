// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom.Scu.Common;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using System.Reflection;

namespace PrintToPACSDemo
{
   #region PropertyGridCheckBox
   class EnumEditorUI : UserControl
   {
      #region GUI
      private System.ComponentModel.IContainer components = null;

      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.chklstEnumValue = new System.Windows.Forms.CheckedListBox();
         this.SuspendLayout();
         // 
         // chklstEnumValue
         // 
         this.chklstEnumValue.CheckOnClick = true;
         this.chklstEnumValue.Dock = System.Windows.Forms.DockStyle.Fill;
         this.chklstEnumValue.FormattingEnabled = true;
         this.chklstEnumValue.HorizontalScrollbar = true;
         this.chklstEnumValue.IntegralHeight = false;
         this.chklstEnumValue.Location = new System.Drawing.Point(0, 0);
         this.chklstEnumValue.Name = "chklstEnumValue";
         this.chklstEnumValue.Size = new System.Drawing.Size(220, 193);
         this.chklstEnumValue.TabIndex = 6;
         this.chklstEnumValue.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstEnumValue_ItemCheck);
         // 
         // EnumEditorUI
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.chklstEnumValue);
         this.Name = "EnumEditorUI";
         this.Size = new System.Drawing.Size(220, 193);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.CheckedListBox chklstEnumValue;
      #endregion

      IWindowsFormsEditorService m_editorService = null;

      private bool m_bNoFire = false;

      public EnumEditorUI()
      {
         InitializeComponent();
      }

      public void SetData(ITypeDescriptorContext context, IWindowsFormsEditorService editorService, string value)
      {
         m_editorService = editorService;

         chklstEnumValue.Visible = true;

         chklstEnumValue.Items.Clear();

         List<string> strList = new List<string>();
         strList.AddRange(Constans.ModalityValues);

         m_bNoFire = true;

         foreach (string strItem in strList)
         {
            string sName = strItem;

            chklstEnumValue.Items.Add(sName);
         }

         if (value == null)
            value = "All";

         string sDelimitedValues = value;
         string[] arrValue = sDelimitedValues.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
         foreach (string sValue in arrValue)
         {
            string sTrimmedValue = sValue.Trim();

            for (int i = 0; i < chklstEnumValue.Items.Count; i++)
            {
               string Name = (string)chklstEnumValue.Items[i];  //objItem;
               if (String.Compare(Name, sTrimmedValue, true) == 0)
               {
                  CheckedListBox chk = (CheckedListBox)chklstEnumValue;
                  chk.SetItemChecked(i, true);
                  chklstEnumValue.SetSelected(i, true);
                  break;
               }
            }
         }
         m_bNoFire = false;
      }

      public object GetValue()
      {
         StringBuilder sb = new StringBuilder(100);
         foreach (object objItem in chklstEnumValue.CheckedItems)
         {
            string data = (string)objItem;
            if (sb.Length > 0)
            {
               sb.Append(", ");
            }
            sb.Append(data);
         }

         if (sb.Length == 0)
            sb.Append("All");

         return sb.ToString();
      }

      private void chklstEnumValue_ItemCheck(object sender, ItemCheckEventArgs e)
      {
         if (m_bNoFire == true)
            return;

         if (e.NewValue == CheckState.Unchecked && chklstEnumValue.CheckedItems.Count == 1 && e.Index != 0)
         {
            chklstEnumValue.SetItemChecked(0, true);
            return;
         }

         if (e.NewValue == CheckState.Unchecked && e.Index == 0 && chklstEnumValue.CheckedItems.Count == 1)
         {
            e.NewValue = CheckState.Checked;
            return;
         }

         if (e.NewValue == CheckState.Checked && e.Index == 0)
         {
            m_bNoFire = true;

            for (int i = 1; i < chklstEnumValue.Items.Count; i++)
               chklstEnumValue.SetItemChecked(i, false);

            m_bNoFire = false;
         }

         if (e.NewValue == CheckState.Checked && chklstEnumValue.CheckedItems.Contains((object)"All"))
         {
            m_bNoFire = true;
            chklstEnumValue.SetItemChecked(0, false);
            m_bNoFire = false;
         }
      }
   }

   public class EnumTypeEditor : UITypeEditor
   {
      private EnumEditorUI m_ui = new EnumEditorUI();
      public EnumTypeEditor()
      {

      }

      public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
      {
         return false;
      }

      public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
      {
         return UITypeEditorEditStyle.DropDown;
      }

      public override bool IsDropDownResizable
      {
         get
         {
            return true;
         }
      }

      public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
      {
         if (provider != null)
         {
            IWindowsFormsEditorService editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            if (editorService == null)
               return value;

            m_ui.SetData(context, editorService, (string)value);

            editorService.DropDownControl(m_ui);

            value = m_ui.GetValue();
         }
         return value;
      }
   }

   public class EnumTypeConverter : EnumConverter
   {
      public EnumTypeConverter(Type type)
         : base(type)
      {
      }

      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
      {
         if (sourceType == typeof(string))
            return true;
         return base.CanConvertFrom(context, sourceType);
      }

      public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
      {
         object objEnumValue = null;
         objEnumValue = value;

         if (objEnumValue == null)
            objEnumValue = "All";

         if (objEnumValue == null)
            throw new Exception("Null is not a valid enumeration value.");

         return objEnumValue.ToString();
      }
   }
   #endregion

   public class Constans
   {
      public static string[] ModalityValues = new string[] {
               "All",
               "CR",
               "CT",
               "MR",
               "NM",
               "US",
               "OT",
               "BI",
               "DG",
               "ES",
               "LS",
               "PT",
               "RG",
               "TG",
               "XA",
               "RF",
               "RTIMAGE",
               "RTDOSE",
               "RTSTRUCT",
               "RTPLAN",
               "RTRECORD",
               "HC",
               "DX",
               "MG",
               "IO",
               "PX",
               "GM",
               "SM",
               "XC",
               "PR",
               "AU",
               "ECG",
               "EPS",
               "HD",
               "SR",
               "IVUS",
               "OP",
               "SMR",
               "AR",
               "KER",
               "VA",
               "SRF",
               "OCT",
               "LEN",
               "OPV",
               "OPM",
               "OAM",
               "RESP",
               "KO",
               "SEG",
               "REG",
               "OPT",
               "BDUS",
               "BMD",
               "DOC",
               "FID",
               "DS",
               "CF",
               "DF",
               "VF",
               "AS",
               "CS",
               "EC",
               "LP",
               "FA",
               "CP",
               "DM",
               "FS",
               "MA",
               "MS",
               "CD",
               "DD",
               "ST",
               "OPR"
             };
   }

   class DicomModalityConvertor : StringConverter
   {
      public override bool
          GetStandardValuesSupported(
          ITypeDescriptorContext context)
      {
         //True - means show a Combobox
         //and False for show a Modal 
         return true;
      }

      public override bool
          GetStandardValuesExclusive(
          ITypeDescriptorContext context)
      {
         //False - a option to edit values 
         //and True - set values to state readonly
         return true;
      }

      public override StandardValuesCollection
          GetStandardValues(
          ITypeDescriptorContext context)
      {
         return new StandardValuesCollection(
             new string[] {
                "",
               "CR",
               "CT",
               "MR",
               "NM",
               "US",
               "OT",
               "BI",
               "DG",
               "ES",
               "LS",
               "PT",
               "RG",
               "TG",
               "XA",
               "RF",
               "RTIMAGE",
               "RTDOSE",
               "RTSTRUCT",
               "RTPLAN",
               "RTRECORD",
               "HC",
               "DX",
               "MG",
               "IO",
               "PX",
               "GM",
               "SM",
               "XC",
               "PR",
               "AU",
               "ECG",
               "EPS",
               "HD",
               "SR",
               "IVUS",
               "OP",
               "SMR",
               "AR",
               "KER",
               "VA",
               "SRF",
               "OCT",
               "LEN",
               "OPV",
               "OPM",
               "OAM",
               "RESP",
               "KO",
               "SEG",
               "REG",
               "OPT",
               "BDUS",
               "BMD",
               "DOC",
               "FID",
               "DS",
               "CF",
               "DF",
               "VF",
               "AS",
               "CS",
               "EC",
               "LP",
               "FA",
               "CP",
               "DM",
               "FS",
               "MA",
               "MS",
               "CD",
               "DD",
               "ST",
               "OPR"
             }
                );
      }
   }

   class DicomFindQuery : FindQuery
   {
      public DicomFindQuery()
      {
         _Modalities = "All";
      }

      private string _Modalities;
      [Browsable(true)]
      [Category("Study")]
      [Description("Modalities in Study")]
      [DisplayName("Modalities in Study")]
      [Editor(typeof(EnumTypeEditor), typeof(UITypeEditor))]
      [TypeConverter(typeof(EnumTypeConverter))]
      public new string Modalities
      {
         get { return _Modalities; }
         set { _Modalities = value; }
      }
   }
}
