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
using System.Drawing.Printing;

using Leadtools.Printer;

namespace PrinterDemo
{
   public partial class FrmSpecifications : Form
   {
      private List<int> _paperIds = new List<int>();
      private PrintDocument _printDocument;
      private PrinterSpecifications _specifications;

      #region Constructor...
      public FrmSpecifications(PrinterSpecifications specifications, PrintDocument printDocument)
      {
         InitializeComponent();

         _printDocument = printDocument;
         _specifications = specifications;

         if (specifications == null)
            return;

         foreach (PaperSize size in _printDocument.DefaultPageSettings.PrinterSettings.PaperSizes)
         {
            _paperIds.Add(size.RawKind);

            if (size.RawKind == specifications.PaperID)
            {
               _cmbPaperSize.SelectedIndex = _paperIds.IndexOf(size.RawKind);
            }
         }

         string[] installedPrinters = new string[PrinterSettings.InstalledPrinters.Count];
         PrinterSettings.InstalledPrinters.CopyTo(installedPrinters, 0);
         _cmbEmulatePrinter.Items.AddRange(installedPrinters);

         _txtWidth.Text = specifications.PaperWidth.ToString();
         _txtHeight.Text = specifications.PaperHeight.ToString();

         _radioInches.Checked = specifications.DimensionsInInches;
         _radioCentimeters.Checked = !specifications.DimensionsInInches;

         _rdPortrait.Checked = specifications.PortraitOrient;
         _rdLandscape.Checked = !specifications.PortraitOrient;

         _cmbEmulatePrinter.Text = specifications.MarginsPrinter;

         _txtCustomQuality.Text = "50";

         switch (specifications.PrintQuality)
         {
            case -1:
               _cmbPrintQuality.SelectedIndex = 0;
               break;

            case -2:
               _cmbPrintQuality.SelectedIndex = 1;
               break;

            case -3:
               _cmbPrintQuality.SelectedIndex = 2;
               break;

            case -4:
               _cmbPrintQuality.SelectedIndex = 3;
               break;

            default:
               _cmbPrintQuality.SelectedIndex = 4;
               _txtCustomQuality.Text = specifications.PrintQuality.ToString();
               break;
         }
      }
      #endregion

      #region Properties...
      public int PaperID
      {
         get
         {
            return _paperIds[_cmbPaperSize.SelectedIndex];
         }
      }

      public string PaperSizeName
      {
         get { return _cmbPaperSize.Text; }
      }

      public double PaperWidth
      {
         get 
         {
            double value = Convert.ToDouble(_txtWidth.Text);

            if (_radioCentimeters.Checked)
            {
               value = value / 2.54;
            }

            return value;
         }
      }

      public double PaperHeight
      {
         get
         {
            double value = Convert.ToDouble(_txtHeight.Text);

            if (_radioCentimeters.Checked)
            {
               value = value / 2.54;
            }

            return value;
         }
      }

      public bool InInches
      {
         get { return _radioInches.Checked; }
      }

      public bool Portrait
      {
         get { return _rdPortrait.Checked; }
      }

      public string MarginsPrinter
      {
         get { return _cmbEmulatePrinter.Text; }
      }

      public int PrintQuality
      {
         get
         {
            switch (_cmbPrintQuality.SelectedIndex)
            {
               case 0:
                  return -1;

               case 1:
                  return -2;

               case 2:
                  return -3;

               case 3:
                  return -4;

               default:
                  return Convert.ToInt32(_txtCustomQuality.Text);
            }
         }
      }

      #endregion

      private void _cmbPaperSize_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_cmbPaperSize.SelectedIndex < _printDocument.DefaultPageSettings.PrinterSettings.PaperSizes.Count)
         {
            double width = (double)_printDocument.DefaultPageSettings.PrinterSettings.PaperSizes[_cmbPaperSize.SelectedIndex].Width / 100.0;
            double height = (double)_printDocument.DefaultPageSettings.PrinterSettings.PaperSizes[_cmbPaperSize.SelectedIndex].Height / 100.0;
            _lblpaperInfo.Text = width.ToString() + " x " + height.ToString() + " Inches";
         }
      }

      private void _cmbPrintQuality_SelectedIndexChanged(object sender, EventArgs e)
      {
         _txtCustomQuality.Enabled = (_cmbPrintQuality.SelectedIndex == 4);
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.OK;
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
      }

      private void _txtBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            e.Handled = true;
      }

      private void _txtCustomQuality_Leave(object sender, EventArgs e)
      {
         try
         {
            if (_txtCustomQuality.Text.Length == 0)
               _txtCustomQuality.Text = "0";

            int value = Convert.ToInt32(_txtCustomQuality.Text);
            if (value < 50 || value > 1600)
            {
               MessageBox.Show(this, "Custom resolution values should be between 50 and 1600.");
               _txtCustomQuality.Focus();
            }
         }
         catch (OverflowException)
         {
            MessageBox.Show(this, "Custom resolution values should be between 50 and 1600.");
            _txtCustomQuality.Focus();
         }
      }

      private void _txtWidth_Leave(object sender, EventArgs e)
      {
         try
         {
            if (_txtWidth.Text.Length == 0)
               _txtWidth.Text = "0";

            int value = Convert.ToInt32(_txtWidth.Text);
         }
         catch (OverflowException)
         {
            MessageBox.Show(this, "Value is too large.");
            _txtWidth.Focus();
         }
      }

      private void _txtHeight_Leave(object sender, EventArgs e)
      {
         try
         {
            if (_txtHeight.Text.Length == 0)
               _txtHeight.Text = "0";

            int value = Convert.ToInt32(_txtHeight.Text);
         }
         catch (OverflowException)
         {
            MessageBox.Show(this, "Value is too large.");
            _txtHeight.Focus();
         }
      }

      private void _btnRestoreDefault_Click(object sender, EventArgs e)
      {
         foreach (PaperSize size in _printDocument.DefaultPageSettings.PrinterSettings.PaperSizes)
         {
            _paperIds.Add(size.RawKind);

            if (size.RawKind == _specifications.PaperID)
            {
               _cmbPaperSize.SelectedIndex = _paperIds.IndexOf(size.RawKind);
            }
         }

         _txtWidth.Text = _specifications.PaperWidth.ToString();
         _txtHeight.Text = _specifications.PaperHeight.ToString();

         _radioInches.Checked = _specifications.DimensionsInInches;
         _radioCentimeters.Checked = !_specifications.DimensionsInInches;

         _rdPortrait.Checked = _specifications.PortraitOrient;
         _rdLandscape.Checked = !_specifications.PortraitOrient;

         _cmbEmulatePrinter.Text = _specifications.MarginsPrinter;

         _txtCustomQuality.Text = "50";

         switch (_specifications.PrintQuality)
         {
            case -1:
               _cmbPrintQuality.SelectedIndex = 0;
               break;

            case -2:
               _cmbPrintQuality.SelectedIndex = 1;
               break;

            case -3:
               _cmbPrintQuality.SelectedIndex = 2;
               break;

            case -4:
               _cmbPrintQuality.SelectedIndex = 3;
               break;

            default:
               _cmbPrintQuality.SelectedIndex = 4;
               _txtCustomQuality.Text = _specifications.PrintQuality.ToString();
               break;
         }
      }
   }
}
