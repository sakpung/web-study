// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Engine;


namespace Leadtools.Annotations.WinForms
{
   public partial class SnapToGridPropertiesDialog : Form
   {
      private AnnAutomation _automation;
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public AnnAutomation Automation
      {
         get { return _automation; }
         set { _automation = value; }
      }

      private AnnSnapToGridOptions _snapToGridOptions;
      private bool IsSnaptoGridDirty
      {
         get
         {
            if (!_snapToGridOptions.Equals(_automation.Manager.SnapToGridOptions))
            {
               return true;
            }

            return false;
         }
      }

      public SnapToGridPropertiesDialog()
      {
         InitializeComponent();
         this.Load += SnapToGridPropertiesDialog_Load;
      }

      private void SnapToGridPropertiesDialog_Load(object sender, EventArgs e)
      {
         _snapToGridTabPage.Text = StringManager.GetString(StringManager.Id.SnapToGridCaption);
         _showGridCheckBox.Text = StringManager.GetString(StringManager.Id.SnapToGridShowGridCheckBox);
         _gridColorLabel.Text = StringManager.GetString(StringManager.Id.SnapToGridGridColorLabel);
         _gridLengthLabel.Text = StringManager.GetString(StringManager.Id.SnapToGridGridLengthLabel);
         _lineSpacingLabel.Text = StringManager.GetString(StringManager.Id.SnapToGridLineSpacingLabel);
         _behaviorGroupBox.Text = StringManager.GetString(StringManager.Id.SnapToGridBehaviorGroupBox);
         _enableSnapCheckBox.Text = StringManager.GetString(StringManager.Id.SnapToGridEnableSnapCheckBox);
         _dashStyleLabel.Text = StringManager.GetString(StringManager.Id.SnapToGridLineStyleLabel);

         _snapToGridOptions = _automation.Manager.SnapToGridOptions.Clone() as AnnSnapToGridOptions;

         _showGridCheckBox.Checked = _snapToGridOptions.ShowGrid;
         _lineSpacingTextBox.Text = _snapToGridOptions.LineSpacing.ToString();
         _gridLengthTextBox.Text = _snapToGridOptions.GridLength.ToString();
         _gridColorColorPicker.Color = ColorTranslator.FromHtml((_snapToGridOptions.GridStroke.Stroke as AnnSolidColorBrush).Color);
         _lineStyleComboBox.SelectedIndex = GetLineStyleFromStrok(_snapToGridOptions.GridStroke);
         _enableSnapCheckBox.Checked = _snapToGridOptions.EnableSnap;
      }

      private int GetLineStyleFromStrok(AnnStroke annStroke)
      {
         if (annStroke.StrokeDashArray == null)
         {
            return 0;
         }
         else
         {
            return 1;
         }
      }

      private void _snapToGridTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
         if (!Char.IsDigit(e.KeyChar))
            e.Handled = true;
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         if (IsSnaptoGridDirty)
         {
            // Set Stoke Color Value
            _snapToGridOptions.GridStroke.Stroke = AnnSolidColorBrush.Create(ColorTranslator.ToHtml(_gridColorColorPicker.Color));

            // Set Stoke Style Value
            if (_lineStyleComboBox.SelectedIndex == 0)
               _snapToGridOptions.GridStroke.StrokeDashArray = null;
            else
               _snapToGridOptions.GridStroke.StrokeDashArray = new double[] { 4, 4 };

            // Set Show Grid Value
            _snapToGridOptions.ShowGrid = _showGridCheckBox.Checked;

            // Set Enable Snap Value
            _snapToGridOptions.EnableSnap = _enableSnapCheckBox.Checked;

            // Set Line Spacing Value.
            int gridLength = _snapToGridOptions.GridLength;
            int.TryParse(_gridLengthTextBox.Text, out gridLength);
            if (gridLength < 5 || gridLength > 999)
            {
               MessageBox.Show("Grid Length must be between 5 and 999.");
               _gridLengthTextBox.Text = _snapToGridOptions.GridLength.ToString();
               return;
            }
            _snapToGridOptions.GridLength = gridLength;

            // Set Line Spacing Value.
            int lineSpacing = _snapToGridOptions.LineSpacing;
            int.TryParse(_lineSpacingTextBox.Text, out lineSpacing);
            if (lineSpacing < 1 || lineSpacing > 100)
            {
               MessageBox.Show("Line Spacing must be between 1 and 100.");
               _lineSpacingTextBox.Text = _snapToGridOptions.LineSpacing.ToString();
               return;
            }
            _snapToGridOptions.LineSpacing = lineSpacing;

            _automation.Manager.SnapToGridOptions = _snapToGridOptions.Clone() as AnnSnapToGridOptions;
         }

         this.Close();
      }
   }
}
