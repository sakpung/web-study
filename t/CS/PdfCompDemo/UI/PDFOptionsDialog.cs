// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.Demos;

namespace PdfCompDemo
{
   /// <summary>
   /// Summary description for PdfOptionsDialog.
   /// </summary>
   public class PdfOptionsDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.TextBox _tbSegmentQuality;
      private System.Windows.Forms.ComboBox _cmboOutputImageQuality;
      private System.Windows.Forms.ComboBox _cmboInputImageQuality;
      private System.Windows.Forms.TextBox _tbColorThreshold;
      private System.Windows.Forms.TextBox _tbPageOrder;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.TextBox _tbCleanSize;
      private System.Windows.Forms.GroupBox _gbOutPutImageQuality;
      private System.Windows.Forms.Label _lblSegmentQuality;
      private System.Windows.Forms.Label _lblColorThreshold;
      private System.Windows.Forms.GroupBox _gbPdfPage;
      private System.Windows.Forms.Label _lblPageOrder;
      private System.Windows.Forms.CheckBox _cbDisableMRC;
      private System.Windows.Forms.GroupBox _gbPdfMRCSettings;
      private System.Windows.Forms.GroupBox _gbInputImageQuality;
      private System.Windows.Forms.TextBox _tbBackgroundThreshold;
      private System.Windows.Forms.Label _lblCleanSize;
      private System.Windows.Forms.Label _lblCombineThreshold;
      private System.Windows.Forms.TextBox _tbCombineThreshold;
      private System.Windows.Forms.Label _lblBackgroundThreshold;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;


      public PdfOptionsDialog( )
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
         this._tbSegmentQuality = new System.Windows.Forms.TextBox();
         this._cmboOutputImageQuality = new System.Windows.Forms.ComboBox();
         this._cmboInputImageQuality = new System.Windows.Forms.ComboBox();
         this._tbColorThreshold = new System.Windows.Forms.TextBox();
         this._tbPageOrder = new System.Windows.Forms.TextBox();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._tbCleanSize = new System.Windows.Forms.TextBox();
         this._gbOutPutImageQuality = new System.Windows.Forms.GroupBox();
         this._lblSegmentQuality = new System.Windows.Forms.Label();
         this._lblColorThreshold = new System.Windows.Forms.Label();
         this._gbPdfPage = new System.Windows.Forms.GroupBox();
         this._lblPageOrder = new System.Windows.Forms.Label();
         this._cbDisableMRC = new System.Windows.Forms.CheckBox();
         this._gbPdfMRCSettings = new System.Windows.Forms.GroupBox();
         this._gbInputImageQuality = new System.Windows.Forms.GroupBox();
         this._tbBackgroundThreshold = new System.Windows.Forms.TextBox();
         this._lblCleanSize = new System.Windows.Forms.Label();
         this._lblCombineThreshold = new System.Windows.Forms.Label();
         this._lblBackgroundThreshold = new System.Windows.Forms.Label();
         this._tbCombineThreshold = new System.Windows.Forms.TextBox();
         this._gbOutPutImageQuality.SuspendLayout();
         this._gbPdfPage.SuspendLayout();
         this._gbInputImageQuality.SuspendLayout();
         this.SuspendLayout();
         // 
         // _tbSegmentQuality
         // 
         this._tbSegmentQuality.Location = new System.Drawing.Point(220, 384);
         this._tbSegmentQuality.Name = "_tbSegmentQuality";
         this._tbSegmentQuality.Size = new System.Drawing.Size(40, 20);
         this._tbSegmentQuality.TabIndex = 8;
         this._tbSegmentQuality.Text = "";
         this._tbSegmentQuality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbPageOrder_KeyPress);
         // 
         // _cmboOutputImageQuality
         // 
         this._cmboOutputImageQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmboOutputImageQuality.Location = new System.Drawing.Point(76, 343);
         this._cmboOutputImageQuality.Name = "_cmboOutputImageQuality";
         this._cmboOutputImageQuality.Size = new System.Drawing.Size(208, 21);
         this._cmboOutputImageQuality.TabIndex = 7;
         this._cmboOutputImageQuality.SelectedIndexChanged += new System.EventHandler(this._cmboOutputImageQuality_SelectedIndexChanged);
         // 
         // _cmboInputImageQuality
         // 
         this._cmboInputImageQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmboInputImageQuality.Location = new System.Drawing.Point(76, 159);
         this._cmboInputImageQuality.Name = "_cmboInputImageQuality";
         this._cmboInputImageQuality.Size = new System.Drawing.Size(208, 21);
         this._cmboInputImageQuality.TabIndex = 4;
         this._cmboInputImageQuality.SelectedIndexChanged += new System.EventHandler(this._cmboInputImageQuality_SelectedIndexChanged);
         // 
         // _tbColorThreshold
         // 
         this._tbColorThreshold.Location = new System.Drawing.Point(220, 416);
         this._tbColorThreshold.Name = "_tbColorThreshold";
         this._tbColorThreshold.Size = new System.Drawing.Size(40, 20);
         this._tbColorThreshold.TabIndex = 9;
         this._tbColorThreshold.Text = "";
         this._tbColorThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbPageOrder_KeyPress);
         // 
         // _tbPageOrder
         // 
         this._tbPageOrder.Location = new System.Drawing.Point(172, 32);
         this._tbPageOrder.Name = "_tbPageOrder";
         this._tbPageOrder.Size = new System.Drawing.Size(40, 20);
         this._tbPageOrder.TabIndex = 1;
         this._tbPageOrder.Text = "";
         this._tbPageOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbPageOrder_KeyPress);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(220, 471);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(112, 24);
         this._btnCancel.TabIndex = 11;
         this._btnCancel.Text = "Cancel";
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(36, 471);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(112, 24);
         this._btnOK.TabIndex = 10;
         this._btnOK.Text = "ADD";
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _tbCleanSize
         // 
         this._tbCleanSize.Location = new System.Drawing.Point(220, 271);
         this._tbCleanSize.Name = "_tbCleanSize";
         this._tbCleanSize.Size = new System.Drawing.Size(40, 20);
         this._tbCleanSize.TabIndex = 5;
         this._tbCleanSize.Text = "";
         this._tbCleanSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbPageOrder_KeyPress);
         // 
         // _gbOutPutImageQuality
         // 
         this._gbOutPutImageQuality.Controls.Add(this._lblSegmentQuality);
         this._gbOutPutImageQuality.Controls.Add(this._lblColorThreshold);
         this._gbOutPutImageQuality.Location = new System.Drawing.Point(36, 311);
         this._gbOutPutImageQuality.Name = "_gbOutPutImageQuality";
         this._gbOutPutImageQuality.Size = new System.Drawing.Size(296, 144);
         this._gbOutPutImageQuality.TabIndex = 6;
         this._gbOutPutImageQuality.TabStop = false;
         this._gbOutPutImageQuality.Text = "O&utput Image Quality";
         // 
         // _lblSegmentQuality
         // 
         this._lblSegmentQuality.Location = new System.Drawing.Point(56, 72);
         this._lblSegmentQuality.Name = "_lblSegmentQuality";
         this._lblSegmentQuality.TabIndex = 0;
         this._lblSegmentQuality.Text = "Segment &Quality";
         // 
         // _lblColorThreshold
         // 
         this._lblColorThreshold.Location = new System.Drawing.Point(56, 104);
         this._lblColorThreshold.Name = "_lblColorThreshold";
         this._lblColorThreshold.Size = new System.Drawing.Size(100, 16);
         this._lblColorThreshold.TabIndex = 1;
         this._lblColorThreshold.Text = "C&olor Threshold";
         // 
         // _gbPdfPage
         // 
         this._gbPdfPage.Controls.Add(this._lblPageOrder);
         this._gbPdfPage.Controls.Add(this._cbDisableMRC);
         this._gbPdfPage.Location = new System.Drawing.Point(20, 7);
         this._gbPdfPage.Name = "_gbPdfPage";
         this._gbPdfPage.Size = new System.Drawing.Size(336, 96);
         this._gbPdfPage.TabIndex = 0;
         this._gbPdfPage.TabStop = false;
         this._gbPdfPage.Text = "Pdf &Page";
         // 
         // _lblPageOrder
         // 
         this._lblPageOrder.Location = new System.Drawing.Point(16, 24);
         this._lblPageOrder.Name = "_lblPageOrder";
         this._lblPageOrder.Size = new System.Drawing.Size(120, 16);
         this._lblPageOrder.TabIndex = 0;
         this._lblPageOrder.Text = "Page &Order in Pdf";
         // 
         // _cbDisableMRC
         // 
         this._cbDisableMRC.Location = new System.Drawing.Point(24, 56);
         this._cbDisableMRC.Name = "_cbDisableMRC";
         this._cbDisableMRC.Size = new System.Drawing.Size(224, 16);
         this._cbDisableMRC.TabIndex = 1;
         this._cbDisableMRC.Text = "&Disable MRC, Save with NO MRC";
         this._cbDisableMRC.CheckedChanged += new System.EventHandler(this._cbDisableMRC_CheckedChanged);
         // 
         // _gbPdfMRCSettings
         // 
         this._gbPdfMRCSettings.Location = new System.Drawing.Point(20, 111);
         this._gbPdfMRCSettings.Name = "_gbPdfMRCSettings";
         this._gbPdfMRCSettings.Size = new System.Drawing.Size(336, 352);
         this._gbPdfMRCSettings.TabIndex = 2;
         this._gbPdfMRCSettings.TabStop = false;
         this._gbPdfMRCSettings.Text = "Pdf &MRC Settings";
         // 
         // _gbInputImageQuality
         // 
         this._gbInputImageQuality.Controls.Add(this._tbBackgroundThreshold);
         this._gbInputImageQuality.Controls.Add(this._lblCleanSize);
         this._gbInputImageQuality.Controls.Add(this._lblCombineThreshold);
         this._gbInputImageQuality.Controls.Add(this._lblBackgroundThreshold);
         this._gbInputImageQuality.Controls.Add(this._tbCombineThreshold);
         this._gbInputImageQuality.Location = new System.Drawing.Point(44, 135);
         this._gbInputImageQuality.Name = "_gbInputImageQuality";
         this._gbInputImageQuality.Size = new System.Drawing.Size(288, 168);
         this._gbInputImageQuality.TabIndex = 3;
         this._gbInputImageQuality.TabStop = false;
         this._gbInputImageQuality.Text = "I&nput Image Quality";
         // 
         // _tbBackgroundThreshold
         // 
         this._tbBackgroundThreshold.Location = new System.Drawing.Point(176, 72);
         this._tbBackgroundThreshold.Name = "_tbBackgroundThreshold";
         this._tbBackgroundThreshold.Size = new System.Drawing.Size(40, 20);
         this._tbBackgroundThreshold.TabIndex = 1;
         this._tbBackgroundThreshold.Text = "";
         this._tbBackgroundThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbPageOrder_KeyPress);
         // 
         // _lblCleanSize
         // 
         this._lblCleanSize.Location = new System.Drawing.Point(32, 136);
         this._lblCleanSize.Name = "_lblCleanSize";
         this._lblCleanSize.Size = new System.Drawing.Size(72, 16);
         this._lblCleanSize.TabIndex = 4;
         this._lblCleanSize.Text = "C&lean Size";
         // 
         // _lblCombineThreshold
         // 
         this._lblCombineThreshold.Location = new System.Drawing.Point(32, 104);
         this._lblCombineThreshold.Name = "_lblCombineThreshold";
         this._lblCombineThreshold.Size = new System.Drawing.Size(112, 16);
         this._lblCombineThreshold.TabIndex = 2;
         this._lblCombineThreshold.Text = "Co&mbine Threshold";
         // 
         // _lblBackgroundThreshold
         // 
         this._lblBackgroundThreshold.Location = new System.Drawing.Point(32, 72);
         this._lblBackgroundThreshold.Name = "_lblBackgroundThreshold";
         this._lblBackgroundThreshold.Size = new System.Drawing.Size(128, 16);
         this._lblBackgroundThreshold.TabIndex = 0;
         this._lblBackgroundThreshold.Text = "Back&ground Threshold";
         // 
         // _tbCombineThreshold
         // 
         this._tbCombineThreshold.Location = new System.Drawing.Point(176, 104);
         this._tbCombineThreshold.Name = "_tbCombineThreshold";
         this._tbCombineThreshold.Size = new System.Drawing.Size(40, 20);
         this._tbCombineThreshold.TabIndex = 3;
         this._tbCombineThreshold.Text = "";
         this._tbCombineThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbPageOrder_KeyPress);
         // 
         // PdfOptionsDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(376, 502);
         this.Controls.Add(this._tbSegmentQuality);
         this.Controls.Add(this._cmboOutputImageQuality);
         this.Controls.Add(this._cmboInputImageQuality);
         this.Controls.Add(this._tbColorThreshold);
         this.Controls.Add(this._tbPageOrder);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._tbCleanSize);
         this.Controls.Add(this._gbOutPutImageQuality);
         this.Controls.Add(this._gbPdfPage);
         this.Controls.Add(this._gbInputImageQuality);
         this.Controls.Add(this._gbPdfMRCSettings);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PdfOptionsDialog";
         this.ShowInTaskbar = false;
         this.Text = "Pdf Options";
         this.Load += new System.EventHandler(this.PdfOptionsDialog_Load);
         this._gbOutPutImageQuality.ResumeLayout(false);
         this._gbPdfPage.ResumeLayout(false);
         this._gbInputImageQuality.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      internal PdfStandardOptions StandardOptions
      {
         get
         {
            return _standardOptions;
         }
         set
         {
            _standardOptions = value;
         }
      }

      private struct ComboBoxItem
      {
         public int Value;
         public string Name;

         public ComboBoxItem(int val, string n)
         {
            Value = val;
            Name = n;
         }

         public override string ToString( )
         {
            return Name;
         }
      }

      private static readonly ComboBoxItem[] _InputImageProfile =
      {
         new ComboBoxItem(0, "Auto Select"),
         new ComboBoxItem(1, "Noisy Image"),
         new ComboBoxItem(2, "Scanned Image"),
         new ComboBoxItem(3, "Printed Image"),
         new ComboBoxItem(4, "Computer Generated Image"),
         new ComboBoxItem(5, "Photo Image"),
         new ComboBoxItem(6, "User Defined"),
      };


      private static readonly ComboBoxItem[] _OutputImageProfile =
      {
         new ComboBoxItem(0, "Auto Select"),
         new ComboBoxItem(1, "Poor Quality"),
         new ComboBoxItem(2, "Average Quality"),
         new ComboBoxItem(3, "Good Quality"),
         new ComboBoxItem(4, "Excellent Quality"),        
         new ComboBoxItem(5, "User Defined"),
      };


      private PdfStandardOptions _standardOptions;

      private void _tbPageOrder_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
         if(!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            e.Handled = true;
      }



      private void UpdateControls( )
      {
         if(_cmboInputImageQuality.SelectedIndex == _InputImageProfile[6].Value && !_cbDisableMRC.Checked)
         {
            _tbBackgroundThreshold.Enabled = true;
            _tbCombineThreshold.Enabled = true;
            _tbCleanSize.Enabled = true;
         }
         else
         {
            _tbBackgroundThreshold.Enabled = false;
            _tbCombineThreshold.Enabled = false;
            _tbCleanSize.Enabled = false;
         }

         if(_cmboOutputImageQuality.SelectedIndex == _OutputImageProfile[5].Value && !_cbDisableMRC.Checked)
         {
            _tbSegmentQuality.Enabled = true;
            _tbColorThreshold.Enabled = true;
         }
         else
         {
            _tbSegmentQuality.Enabled = false;
            _tbColorThreshold.Enabled = false;
         }

         if(_cbDisableMRC.Checked)
         {
            _cmboInputImageQuality.Enabled = false;
            _cmboOutputImageQuality.Enabled = false;
         }
         else
         {
            _cmboInputImageQuality.Enabled = true;
            _cmboOutputImageQuality.Enabled = true;
         }

         SetProfileValues();
      }

      private void SetProfileValues( )
      {
         switch(_cmboInputImageQuality.SelectedIndex)
         {
            case 0:
               _tbCombineThreshold.Text = "100";
               _tbBackgroundThreshold.Text = "15";
               _tbCleanSize.Text = "7";
               break;

            case 1:
               _tbCombineThreshold.Text = "125";
               _tbBackgroundThreshold.Text = "25";
               _tbCleanSize.Text = "10";
               break;

            case 2:
               _tbCombineThreshold.Text = "125";
               _tbBackgroundThreshold.Text = "15";
               _tbCleanSize.Text = "8";
               break;

            case 3:
               _tbCombineThreshold.Text = "100";
               _tbBackgroundThreshold.Text = "10";
               _tbCleanSize.Text = "7";
               break;

            case 4:
               _tbCombineThreshold.Text = "75";
               _tbBackgroundThreshold.Text = "10";
               _tbCleanSize.Text = "3";
               break;

            case 5:
               _tbCombineThreshold.Text = "75";
               _tbBackgroundThreshold.Text = "0";
               _tbCleanSize.Text = "3";
               break;
         }

         switch(_cmboOutputImageQuality.SelectedIndex)
         {
            case 0:
               _tbSegmentQuality.Text = "50";
               _tbColorThreshold.Text = "25";
               break;

            case 1:
               _tbSegmentQuality.Text = "0";
               _tbColorThreshold.Text = "30";
               break;

            case 2:
               _tbSegmentQuality.Text = "50";
               _tbColorThreshold.Text = "25";
               break;

            case 3:
               _tbSegmentQuality.Text = "75";
               _tbColorThreshold.Text = "25";
               break;

            case 4:
               _tbSegmentQuality.Text = "100";
               _tbColorThreshold.Text = "25";
               break;
         }
      }

      private void PdfOptionsDialog_Load(object sender, System.EventArgs e)
      {
         SetDialog();
      }

      private void SetDialog( )
      {
         foreach(ComboBoxItem i in _InputImageProfile)
         {
            _cmboInputImageQuality.Items.Add(i);
            if(StandardOptions.InputImageComboSel == i.Value)
               _cmboInputImageQuality.SelectedItem = i;
         }


         foreach(ComboBoxItem i in _OutputImageProfile)
         {
            _cmboOutputImageQuality.Items.Add(i);
            if(StandardOptions.OutputImageComboSel == i.Value)
               _cmboOutputImageQuality.SelectedItem = i;
         }

         if(StandardOptions.Added)
         {
            _cbDisableMRC.Checked = StandardOptions.NOMRC;
            _tbBackgroundThreshold.Text = StandardOptions.BKThreshold.ToString();
            _tbCleanSize.Text = StandardOptions.CleanSize.ToString();
            _tbColorThreshold.Text = StandardOptions.CLRThreshold.ToString();
            _tbCombineThreshold.Text = StandardOptions.CombThreshold.ToString();
            _tbSegmentQuality.Text = StandardOptions.SegQuality.ToString();
            _tbPageOrder.Text = StandardOptions.PageNumber.ToString();
            _btnOK.Text = "Update";
         }
         else
         {
            _tbPageOrder.Text = string.Format("0");
         }
      }


      private void _cmboInputImageQuality_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }


      private void _cmboOutputImageQuality_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void _cbDisableMRC_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void _btnOK_Click(object sender, System.EventArgs e)
      {
         int nBKThreshold;
         int nCleanSize;
         int nCLRThreshold;
         int nCombThreshold;
         int nSegQuality;
         int nPageOrder;




         if(!DialogUtilities.ParseInteger(_tbBackgroundThreshold, "Background Threshold", 0, true, 100, true, true, out nBKThreshold))
            return;
         else
            StandardOptions.BKThreshold = nBKThreshold;

         if(!DialogUtilities.ParseInteger(_tbCleanSize, "Clean Size", 0, true, 10, true, true, out nCleanSize))
            return;
         else
            StandardOptions.CleanSize = nCleanSize;

         if(!DialogUtilities.ParseInteger(_tbColorThreshold, "Color Threshold", 0, true, 100, true, true, out nCLRThreshold))
            return;
         else
            StandardOptions.CLRThreshold = nCLRThreshold;

         if(!DialogUtilities.ParseInteger(_tbCombineThreshold, "Combined Threshold", 0, true, 300, true, true, out nCombThreshold))
            return;
         else
            StandardOptions.CombThreshold = nCombThreshold;

         if(!DialogUtilities.ParseInteger(_tbSegmentQuality, "Segment Quality", 0, true, 100, true, true, out nSegQuality))
            return;
         else
            StandardOptions.SegQuality = nSegQuality;

         if(!DialogUtilities.ParseInteger(_tbPageOrder, "Page Order", 0, true, this.Owner.MdiChildren.Length - 1, true, true, out nPageOrder))
         {
            return;
         }
         else
         {
            if(CheckPagesOrder())
               SetPageOrder();
            StandardOptions.PageNumber = nPageOrder;
         }
         StandardOptions.Added = true;
         StandardOptions.NOMRC = _cbDisableMRC.Checked;
         StandardOptions.InputImageComboSel = _cmboInputImageQuality.SelectedIndex;
         StandardOptions.OutputImageComboSel = _cmboOutputImageQuality.SelectedIndex;

      }

      private bool CheckPagesOrder( )
      {
         try
         {
            int value;
            value = int.Parse(_tbPageOrder.Text);

            for(int i = 0; i < this.Owner.MdiChildren.Length; i++)
            {
               if(((ViewerForm)this.Owner.ActiveMdiChild) !=
                  ((ViewerForm)this.Owner.MdiChildren[i]))
                  if(((ViewerForm)this.Owner.MdiChildren[i]).StandardOptions.Added &&
                      value == ((ViewerForm)this.Owner.MdiChildren[i]).StandardOptions.PageNumber)
                  {
                     Messager.ShowWarning(this, "Page numbers for other pages were modified since this number already exists");
                     return true;
                  }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }

         return false;

      }

      private void SetPageOrder( )
      {
         int value;
         value = int.Parse(_tbPageOrder.Text);

         for(int i = 0; i < this.Owner.MdiChildren.Length; i++)
         {
            if(!StandardOptions.Added &&
               ((ViewerForm)this.Owner.MdiChildren[i]).StandardOptions.PageNumber >= value)
            {
               ((ViewerForm)this.Owner.MdiChildren[i]).StandardOptions.PageNumber++;
            }
            else if(StandardOptions.Added &&
               ((ViewerForm)this.Owner.MdiChildren[i]).StandardOptions.PageNumber == value)
            {
               ((ViewerForm)this.Owner.MdiChildren[i]).StandardOptions.PageNumber = StandardOptions.PageNumber;
            }
         }
      }



   }
}
