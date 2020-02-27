using Leadtools.Barcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AAMVAWriteDemo
{
   public partial class WriteBarcodeOptionsDialog : Form
   {
      PDF417BarcodeWriteOptions _options;
      WriteBarcodeForm _parent;

      public class ComboBoxIntDatum
      {
         public ComboBoxIntDatum(int value, string display)
         {
            Value = value;
            Display = display;
         }

         public int Value { get; set; }
         public string Display { get; set; }

      }

      public WriteBarcodeOptionsDialog(WriteBarcodeForm parent, PDF417BarcodeWriteOptions options)
      {
         _parent = parent;
         _options = options;
         InitializeComponent();
         PopulateValues();
      }

      private void PopulateValues()
      {
         ComboBoxIntDatum[] xmodData =
         {
            new ComboBoxIntDatum(7, "7 (0.007 inch)"),
            new ComboBoxIntDatum(8, "8 (0.008 inch)"),
            new ComboBoxIntDatum(9, "9 (0.009 inch)"),
            new ComboBoxIntDatum(10, "10 (0.010 inch)"),
            new ComboBoxIntDatum(11, "11 (0.011 inch)"),
            new ComboBoxIntDatum(12, "12 (0.012 inch)"),
            new ComboBoxIntDatum(13, "13 (0.013 inch)"),
            new ComboBoxIntDatum(14, "14 (0.014 inch)"),
            new ComboBoxIntDatum(15, "15 (0.015 inch)"),
         };

         _comboBoxXModule.DataSource = xmodData;
         _comboBoxXModule.ValueMember = "Value";
         _comboBoxXModule.DisplayMember = "Display";
         _comboBoxXModule.SelectedValue = _options.XModule;

         ComboBoxIntDatum[] xmodARData =
         {
            new ComboBoxIntDatum(3, "3:1"),
            new ComboBoxIntDatum(4, "4:1"),
            new ComboBoxIntDatum(5, "5:1"),

         };

         _comboBoxXModuleAR.DataSource = xmodARData;
         _comboBoxXModuleAR.ValueMember = "Value";
         _comboBoxXModuleAR.DisplayMember = "Display";
         _comboBoxXModuleAR.SelectedValue = _options.XModuleAspectRatio;

         ComboBoxIntDatum[] eccData =
         {
            new ComboBoxIntDatum((int)PDF417BarcodeECCLevel.Level3, "Level 3"),
            new ComboBoxIntDatum((int)PDF417BarcodeECCLevel.Level4, "Level 4"),
            new ComboBoxIntDatum((int)PDF417BarcodeECCLevel.Level5, "Level 5 (recommended)"),
            new ComboBoxIntDatum((int)PDF417BarcodeECCLevel.Level6, "Level 6"),
            new ComboBoxIntDatum((int)PDF417BarcodeECCLevel.Level7, "Level 7"),
            new ComboBoxIntDatum((int)PDF417BarcodeECCLevel.Level8, "Level 8")
         };

         _comboBoxECC.DataSource = eccData;
         _comboBoxECC.ValueMember = "Value";
         _comboBoxECC.DisplayMember = "Display";
         _comboBoxECC.SelectedValue = (int)_options.ECCLevel;

         ComboBoxIntDatum[] symWidthData =
         {
            new ComboBoxIntDatum(2, "1:2"),
            new ComboBoxIntDatum(3, "1:3"),
            new ComboBoxIntDatum(4, "1:4"),
            new ComboBoxIntDatum(5, "1:5"),

         };

         _comboBoxSymbolWidth.DataSource = symWidthData;
         _comboBoxSymbolWidth.ValueMember = "Value";
         _comboBoxSymbolWidth.DisplayMember = "Display";
         _comboBoxSymbolWidth.SelectedValue = _options.SymbolWidthAspectRatio;

      }

      private void _btnSubmit_Click(object sender, EventArgs e)
      {
         _options.XModule = (int)_comboBoxXModule.SelectedValue;
         _options.XModuleAspectRatio = (int)_comboBoxXModuleAR.SelectedValue;
         _options.ECCLevel = (PDF417BarcodeECCLevel)_comboBoxECC.SelectedValue;
         _options.SymbolWidthAspectRatio = (int)_comboBoxSymbolWidth.SelectedValue;
         _parent.UpdateOptions(_options);
         Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
