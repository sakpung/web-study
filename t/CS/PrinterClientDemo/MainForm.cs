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

namespace ManagedPrinterClientDemo
{
   public partial class MainForm : Form
   {
      private PrinterSettings _printerSettings;
      private string _PrinterName;

      public string GetData()
      {
         return _cmbFileFormats.SelectedItem.ToString() + "---" + _txtSavePath.Text + "\\" + _txtSaveName.Text;
      }

      private bool Is64Bit()
      {
         return IntPtr.Size == 8;
      }

      public MainForm(string printerName, byte[] bytes)
      {
         _PrinterName = printerName;
         InitializeComponent();
         _printerSettings = new PrinterSettings(bytes);
         _txtPrinterName.Text = _PrinterName;

         if (Is64Bit())
            Text = "LEADTOOLS C# Printer Client Demo 64-bit";
         else
            Text = "LEADTOOLS C# Printer Client Demo 32-bit";

         ApplyPrinterSettings();
      }

      private void ApplyPrinterSettings()
      {
         _txtPrinterDescription.Text = _printerSettings._strDescreption;
         _cmbFileFormats.Items.Clear();

         foreach (PrinterFileFormat fileFormat in _printerSettings._lstFormats)
         {
            _cmbFileFormats.Items.Add(fileFormat._strFileFormat);
         }

         if (_cmbFileFormats.Items.Count > 0)
            _cmbFileFormats.SelectedIndex = 0;

      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(_txtSaveName.Text))
         {
            MessageBox.Show(this, "Please enter a valid file name", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
         }

         DialogResult = DialogResult.OK;
         return;
      }

      private void _cmbFileFormats_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            PrinterFileFormat fileFormat = _printerSettings._lstFormats[_cmbFileFormats.SelectedIndex];
            _txtSavePath.Text = fileFormat._strSaveLocation;
         }
         catch { }
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         Activate();
      }
   }

   class PrinterSettings
   {
      public string _strDescreption;
      public List<PrinterFileFormat> _lstFormats;

      public PrinterSettings(string strDescreption, List<PrinterFileFormat> lstFormats)
      {
         _strDescreption = strDescreption;
         _lstFormats = lstFormats;
      }

      public PrinterSettings(byte[] bytes)
      {
         _lstFormats = new List<PrinterFileFormat>();
         SetBytes(bytes);
      }

      public PrinterSettings()
      {
         _strDescreption = "Insert actual printer description here. This description will be sent to the user client demo as initialization data.";

         _lstFormats = new List<PrinterFileFormat>();

         String PersonalFolder =
         Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

         PrinterFileFormat fileFormat = new PrinterFileFormat("PDF", PersonalFolder);
         _lstFormats.Add(fileFormat);
         fileFormat = new PrinterFileFormat("XPS", PersonalFolder);
         _lstFormats.Add(fileFormat);
         fileFormat = new PrinterFileFormat("DOC", PersonalFolder);
         _lstFormats.Add(fileFormat);
         fileFormat = new PrinterFileFormat("DOCX", PersonalFolder);
         _lstFormats.Add(fileFormat);

      }

      public PrinterSettings(string strDescreption)
         : this()
      {

         _strDescreption = strDescreption;
      }

      public void AddFileFormat(PrinterFileFormat fileFormat)
      {
         _lstFormats.Add(fileFormat);
      }

      public byte[] GetBytes()
      {
         string strReturn = "";
         strReturn += _strDescreption;
         strReturn += "---";

         foreach (PrinterFileFormat fileFormat in _lstFormats)
         {
            strReturn += fileFormat._strFileFormat;
            strReturn += "---";
            strReturn += fileFormat._strSaveLocation;
            strReturn += "---";
         }

         Encoding unicode = Encoding.Unicode;

         return unicode.GetBytes(strReturn.ToCharArray());
      }

      public void SetBytes(byte[] bytes)
      {
         Encoding unicode = Encoding.Unicode;

         if (_lstFormats != null)
            _lstFormats.Clear();

         string strBytes = new string(unicode.GetChars(bytes));
         int nIndex;
         nIndex = strBytes.IndexOf("---");

         _strDescreption = strBytes.Substring(0, nIndex);
         strBytes = strBytes.Substring(nIndex + 3);

         string strFormat = "", strLocation = "";
         while (true)
         {
            try
            {
               nIndex = strBytes.IndexOf("---");
               strFormat = strBytes.Substring(0, nIndex);
               strBytes = strBytes.Substring(nIndex + 3);

               nIndex = strBytes.IndexOf("---");
               strLocation = strBytes.Substring(0, nIndex);
               strBytes = strBytes.Substring(nIndex + 3);

               PrinterFileFormat fileFormat = new PrinterFileFormat(strFormat, strLocation);
               _lstFormats.Add(fileFormat);

            }
            catch (System.Exception)
            {
               break;
            }

         }
      }

   }

   class PrinterFileFormat
   {
      public string _strFileFormat;
      public string _strSaveLocation;

      public PrinterFileFormat(string strFileFormat, string strSaveLocation)
      {
         _strSaveLocation = strSaveLocation;
         _strFileFormat = strFileFormat;
      }
   }
}
