// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom;

namespace DicomDemo.UI
{
   public enum SaveOptionsEnum
   {
      NativeDicomModel,
      JsonModel
   }
   public partial class SaveDlg : Form
   {
      public SaveDlg(SaveOptionsEnum saveOptionsType)
      {
         _saveOptionsType = saveOptionsType;
         InitializeComponent();
      }

      private SaveOptionsEnum _saveOptionsType;

      public DicomDataSet DicomDS
      {
         get;
         set;
      }

      private void SaveDlg_Load(object sender, EventArgs e)
      {
         if (_saveOptionsType == SaveOptionsEnum.NativeDicomModel)
         {
            this.Text = "'Native DICOM Model' Save Options";
            textBoxDescription.Text = "The 'Native DICOM Model' xml format is described in PS3.19.A.1 of the DICOM Specification.";
            radioButtonBulkDataUuid.Visible = true;
            checkBoxFullEndStatement.Visible = true;
            checkBoxWriteKeyword.Visible = false;
            checkBoxMinify.Visible = false;
         }
         else
         {
            this.Text = "'DICOM Json Model' Save Options";
            textBoxDescription.Text = "The 'DICOM Json Model' json format is described in PS3.18.F.2 of the DICOM Specification.";
            radioButtonBulkDataUuid.Visible = false;
            checkBoxFullEndStatement.Visible = false;
            checkBoxWriteKeyword.Visible = true;
            checkBoxMinify.Visible = true;
         }
      }

      public DicomDataSetSaveXmlFlags GetXmlFlags()
      {
         DicomDataSetSaveXmlFlags flags =
            DicomDataSetSaveXmlFlags.NativeDicomModel | // always include this one
            (radioButtonInlineBinary.Checked ? DicomDataSetSaveXmlFlags.InlineBinary : DicomDataSetSaveXmlFlags.None) |
            (radioButtonBulkDataUri.Checked ? DicomDataSetSaveXmlFlags.BulkDataUri : DicomDataSetSaveXmlFlags.None) |
            (radioButtonBulkDataUuid.Checked ? DicomDataSetSaveXmlFlags.BulkDataUuid : DicomDataSetSaveXmlFlags.None) |
            (radioButtonIgnorePixelData.Checked ? DicomDataSetSaveXmlFlags.IgnorePixelData : DicomDataSetSaveXmlFlags.None) |
            (radioButtonIgnoreBinaryData.Checked ? DicomDataSetSaveXmlFlags.IgnoreBinaryData : DicomDataSetSaveXmlFlags.None) |
            (radioButtonIgnoreAllData.Checked ? DicomDataSetSaveXmlFlags.IgnoreAllData : DicomDataSetSaveXmlFlags.None) |
            (checkBoxTrimWhiteSpace.Checked ? DicomDataSetSaveXmlFlags.TrimWhiteSpace : DicomDataSetSaveXmlFlags.None) |
            (checkBoxFullEndStatement.Checked ? DicomDataSetSaveXmlFlags.WriteFullEndElement : DicomDataSetSaveXmlFlags.None);

         return flags;
      }

      public void SetXmlFlags(DicomDataSetSaveXmlFlags flags)
      {
         // Binary Data Options
         if (flags.IsFlagged(DicomDataSetSaveXmlFlags.InlineBinary))
            radioButtonInlineBinary.Checked = true;
         else if (flags.IsFlagged(DicomDataSetSaveXmlFlags.BulkDataUri))
            radioButtonBulkDataUri.Checked = true;
         else
            radioButtonBulkDataUuid.Checked = true;

         // Data Options
         if (flags.IsFlagged(DicomDataSetSaveXmlFlags.IgnorePixelData))
            radioButtonIgnorePixelData.Checked = true;
         else if (flags.IsFlagged(DicomDataSetSaveXmlFlags.IgnoreBinaryData))
            radioButtonIgnoreBinaryData.Checked = true;
         else if (flags.IsFlagged(DicomDataSetSaveXmlFlags.IgnoreAllData))
            radioButtonIgnoreAllData.Checked = true;
         else
            radioButtonIncludeAllData.Checked = true;

         // Misc Options
         if (flags.IsFlagged(DicomDataSetSaveXmlFlags.TrimWhiteSpace))
            checkBoxTrimWhiteSpace.Checked = true;
         if (flags.IsFlagged(DicomDataSetSaveXmlFlags.WriteFullEndElement))
            checkBoxFullEndStatement.Checked = true;
      }

      public DicomDataSetSaveJsonFlags GetJsonFlags()
      {
         DicomDataSetSaveJsonFlags flags =
            (radioButtonInlineBinary.Checked ? DicomDataSetSaveJsonFlags.InlineBinary : DicomDataSetSaveJsonFlags.None) |
            (radioButtonBulkDataUri.Checked ? DicomDataSetSaveJsonFlags.BulkDataUri : DicomDataSetSaveJsonFlags.None) |
            (radioButtonIgnorePixelData.Checked ? DicomDataSetSaveJsonFlags.IgnorePixelData : DicomDataSetSaveJsonFlags.None) |
            (radioButtonIgnoreBinaryData.Checked ? DicomDataSetSaveJsonFlags.IgnoreBinaryData : DicomDataSetSaveJsonFlags.None) |
            (radioButtonIgnoreAllData.Checked ? DicomDataSetSaveJsonFlags.IgnoreAllData : DicomDataSetSaveJsonFlags.None) |
            (checkBoxTrimWhiteSpace.Checked ? DicomDataSetSaveJsonFlags.TrimWhiteSpace : DicomDataSetSaveJsonFlags.None) |
            (checkBoxWriteKeyword.Checked ? DicomDataSetSaveJsonFlags.WriteKeyword : DicomDataSetSaveJsonFlags.None) |
            (checkBoxMinify.Checked ? DicomDataSetSaveJsonFlags.Minify: DicomDataSetSaveJsonFlags.None) 
            ;

         return flags;
      }

      public void SetJsonFlags(DicomDataSetSaveJsonFlags flags)
      {
         // Binary Data Options
         if (flags.IsFlagged(DicomDataSetSaveJsonFlags.InlineBinary))
            radioButtonInlineBinary.Checked = true;
         else 
            radioButtonBulkDataUri.Checked = true;


         // Data Options
         if (flags.IsFlagged(DicomDataSetSaveJsonFlags.IgnorePixelData))
            radioButtonIgnorePixelData.Checked = true;
         else if (flags.IsFlagged(DicomDataSetSaveJsonFlags.IgnoreBinaryData))
            radioButtonIgnoreBinaryData.Checked = true;
         else if (flags.IsFlagged(DicomDataSetSaveJsonFlags.IgnoreAllData))
            radioButtonIgnoreAllData.Checked = true;
         else
            radioButtonIncludeAllData.Checked = true;

         // Misc Options
         if (flags.IsFlagged(DicomDataSetSaveJsonFlags.TrimWhiteSpace))
            checkBoxTrimWhiteSpace.Checked = true;
      }

      public static void SaveXmlFile(DicomDataSet ds, DicomDataSetSaveXmlFlags xmlFlags)
      {
         using (SaveFileDialog saveFileDialog = new SaveFileDialog())
         {
            saveFileDialog.Filter = "XML File(*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Title = "Save 'Native DICOM Model' File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
               try
               {
                  ds.SaveXml(saveFileDialog.FileName, xmlFlags);
               }
               catch (DicomException de)
               {
                  string err = string.Format("Error saving dicom dataset!\r\n\r\n{0}", de.Code.ToString());

                  MessageBox.Show(err, "Error");
                  return;
               }
            }
         }
      }

      public static void SaveJsonFile(DicomDataSet ds, DicomDataSetSaveJsonFlags jsonFlags)
      {
         using (SaveFileDialog saveFileDialog = new SaveFileDialog())
         {
            saveFileDialog.Filter = "JSON File(*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Title = "Save 'DICOM JSON Model' File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
               try
               {
                  ds.SaveJson(saveFileDialog.FileName, jsonFlags);
               }
               catch (DicomException de)
               {
                  string err = string.Format("Error saving dicom dataset!\r\n\r\n{0}", de.Code.ToString());

                  MessageBox.Show(err, "Error");
                  return;
               }
            }
         }
      }

      private void buttonSave_Click(object sender, EventArgs e)
      {
         if (this._saveOptionsType == SaveOptionsEnum.NativeDicomModel)
         {
            SaveXmlFile(DicomDS, GetXmlFlags());
         }
         else
         {
            SaveJsonFile(DicomDS, GetJsonFlags());
         }
      }
   }
}
