// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Mrc;

namespace MrcSegmentationDemo
{
   /// <summary>
   /// Summary description for MrcSegmentType.
   /// </summary>
   public class SegmentTypeDialog : System.Windows.Forms.Form
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public SegmentTypeDialog( )
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //

         _cbSegmentType.Items.Add("Text 1-Bit(B & W)");
         _cbSegmentType.Items.Add("Text 1-Bit(Colored)");
         _cbSegmentType.Items.Add("Text 2-Bit(Colored)");
         _cbSegmentType.Items.Add("Grayscale 2-Bit");
         _cbSegmentType.Items.Add("Grayscale 8-Bit");
         _cbSegmentType.Items.Add("Picture 24-Bit");
         _cbSegmentType.Items.Add("Back Ground segment");
         _cbSegmentType.Items.Add("One Color segment");
         _cbSegmentType.Items.Add("Text segment 2-Bit(B & W)");
         _cbSegmentType.SelectedIndex = 0;
      }

      private System.Windows.Forms.ComboBox _cbSegmentType;
      private System.Windows.Forms.Button _Cancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _groupBox1;

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
         this._cbSegmentType = new System.Windows.Forms.ComboBox();
         this._Cancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._groupBox1 = new System.Windows.Forms.GroupBox();
         this.SuspendLayout();
         // 
         // _cbSegmentType
         // 
         this._cbSegmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbSegmentType.Location = new System.Drawing.Point(15, 20);
         this._cbSegmentType.Name = "_cbSegmentType";
         this._cbSegmentType.Size = new System.Drawing.Size(152, 21);
         this._cbSegmentType.TabIndex = 1;
         this._cbSegmentType.SelectedIndexChanged += new System.EventHandler(this._cbSegmentType_SelectedIndexChanged);
         // 
         // _Cancel
         // 
         this._Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._Cancel.Location = new System.Drawing.Point(184, 40);
         this._Cancel.Name = "_Cancel";
         this._Cancel.TabIndex = 3;
         this._Cancel.Text = "&Cancel";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(184, 6);
         this._btnOk.Name = "_btnOk";
         this._btnOk.TabIndex = 2;
         this._btnOk.Text = "&Ok";
         // 
         // _groupBox1
         // 
         this._groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._groupBox1.Location = new System.Drawing.Point(7, 4);
         this._groupBox1.Name = "_groupBox1";
         this._groupBox1.Size = new System.Drawing.Size(169, 47);
         this._groupBox1.TabIndex = 0;
         this._groupBox1.TabStop = false;
         this._groupBox1.Text = "&Segment Type";
         // 
         // SegmentTypeDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._Cancel;
         this.ClientSize = new System.Drawing.Size(266, 72);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._Cancel);
         this.Controls.Add(this._cbSegmentType);
         this.Controls.Add(this._groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SegmentTypeDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Segment Type";
         this.ResumeLayout(false);

      }
      #endregion

      private MrcSegmentType _segmentType;

      public MrcSegmentType SegmentType
      {
         get
         {
            return _segmentType;
         }
         set
         {
            _segmentType = value;
            switch(_segmentType)
            {
               case MrcSegmentType.Text1BitBw:
                  _cbSegmentType.SelectedIndex = 0;
                  break;
               case MrcSegmentType.Text1BitColor:
                  _cbSegmentType.SelectedIndex = 1;
                  break;
               case MrcSegmentType.Text2BitColor:
                  _cbSegmentType.SelectedIndex = 2;
                  break;
               case MrcSegmentType.Grayscale2Bit:
                  _cbSegmentType.SelectedIndex = 3;
                  break;
               case MrcSegmentType.Grayscale8Bit:
                  _cbSegmentType.SelectedIndex = 4;
                  break;
               case MrcSegmentType.Picture:
                  _cbSegmentType.SelectedIndex = 5;
                  break;
               case MrcSegmentType.Background:
                  _cbSegmentType.SelectedIndex = 6;
                  break;
               case MrcSegmentType.OneColor:
                  _cbSegmentType.SelectedIndex = 7;
                  break;
               case MrcSegmentType.Text2BitBw:
                  _cbSegmentType.SelectedIndex = 8;
                  break;
            }
         }
      }

      private void _cbSegmentType_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         switch(_cbSegmentType.SelectedIndex)
         {
            case 0:
               _segmentType = MrcSegmentType.Text1BitBw;
               break;
            case 1:
               _segmentType = MrcSegmentType.Text1BitColor;
               break;
            case 2:
               _segmentType = MrcSegmentType.Text2BitColor;
               break;
            case 3:
               _segmentType = MrcSegmentType.Grayscale2Bit;
               break;
            case 4:
               _segmentType = MrcSegmentType.Grayscale8Bit;
               break;
            case 5:
               _segmentType = MrcSegmentType.Picture;
               break;
            case 6:
               _segmentType = MrcSegmentType.Background;
               break;
            case 7:
               _segmentType = MrcSegmentType.OneColor;
               break;
            case 8:
               _segmentType = MrcSegmentType.Text2BitBw;
               break;
         }
      }
   }
}
