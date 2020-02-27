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

namespace MrcSegmentationDemo
{
   /// <summary>
   /// Summary description for SegmentInformation.
   /// </summary>
   public class SegmentInformationDialog : System.Windows.Forms.Form
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public SegmentInformationDialog(String segmentType, int ImageWidth, int ImageHeight)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         _txtSegmentType.Text = segmentType;
         _imageWidth = ImageWidth;
         _imageHeight = ImageHeight;
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
         this._lblLeft = new System.Windows.Forms.Label();
         this._txtLeft = new System.Windows.Forms.TextBox();
         this._txtTop = new System.Windows.Forms.TextBox();
         this._lblTop = new System.Windows.Forms.Label();
         this._txtRight = new System.Windows.Forms.TextBox();
         this._lblRight = new System.Windows.Forms.Label();
         this._txtBottom = new System.Windows.Forms.TextBox();
         this._lblBottom = new System.Windows.Forms.Label();
         this._txtSegmentType = new System.Windows.Forms.TextBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _lblLeft
         // 
         this._lblLeft.Location = new System.Drawing.Point(14, 24);
         this._lblLeft.Name = "_lblLeft";
         this._lblLeft.Size = new System.Drawing.Size(26, 16);
         this._lblLeft.TabIndex = 1;
         this._lblLeft.Text = "&Left";
         // 
         // _txtLeft
         // 
         this._txtLeft.Location = new System.Drawing.Point(48, 21);
         this._txtLeft.Name = "_txtLeft";
         this._txtLeft.Size = new System.Drawing.Size(42, 20);
         this._txtLeft.TabIndex = 2;
         this._txtLeft.Text = "";
         this._txtLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         this._txtLeft.TextChanged += new System.EventHandler(this._txtLeft_TextChanged);
         // 
         // _txtTop
         // 
         this._txtTop.Location = new System.Drawing.Point(150, 21);
         this._txtTop.Name = "_txtTop";
         this._txtTop.Size = new System.Drawing.Size(42, 20);
         this._txtTop.TabIndex = 4;
         this._txtTop.Text = "";
         this._txtTop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         this._txtTop.TextChanged += new System.EventHandler(this._txtTop_TextChanged);
         // 
         // _lblTop
         // 
         this._lblTop.Location = new System.Drawing.Point(108, 24);
         this._lblTop.Name = "_lblTop";
         this._lblTop.Size = new System.Drawing.Size(37, 16);
         this._lblTop.TabIndex = 3;
         this._lblTop.Text = "&Top";
         // 
         // _txtRight
         // 
         this._txtRight.Location = new System.Drawing.Point(48, 51);
         this._txtRight.Name = "_txtRight";
         this._txtRight.Size = new System.Drawing.Size(42, 20);
         this._txtRight.TabIndex = 6;
         this._txtRight.Text = "";
         this._txtRight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         this._txtRight.TextChanged += new System.EventHandler(this._txtRight_TextChanged);
         // 
         // _lblRight
         // 
         this._lblRight.Location = new System.Drawing.Point(15, 53);
         this._lblRight.Name = "_lblRight";
         this._lblRight.Size = new System.Drawing.Size(32, 16);
         this._lblRight.TabIndex = 5;
         this._lblRight.Text = "&Right";
         // 
         // _txtBottom
         // 
         this._txtBottom.Location = new System.Drawing.Point(150, 50);
         this._txtBottom.Name = "_txtBottom";
         this._txtBottom.Size = new System.Drawing.Size(42, 20);
         this._txtBottom.TabIndex = 8;
         this._txtBottom.Text = "";
         this._txtBottom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         this._txtBottom.TextChanged += new System.EventHandler(this._txtBottom_TextChanged);
         // 
         // _lblBottom
         // 
         this._lblBottom.Location = new System.Drawing.Point(108, 54);
         this._lblBottom.Name = "_lblBottom";
         this._lblBottom.Size = new System.Drawing.Size(45, 16);
         this._lblBottom.TabIndex = 7;
         this._lblBottom.Text = "&Bottom";
         // 
         // _txtSegmentType
         // 
         this._txtSegmentType.Location = new System.Drawing.Point(18, 103);
         this._txtSegmentType.Name = "_txtSegmentType";
         this._txtSegmentType.ReadOnly = true;
         this._txtSegmentType.TabIndex = 12;
         this._txtSegmentType.Text = "";
         this._txtSegmentType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // groupBox2
         // 
         this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.groupBox2.Location = new System.Drawing.Point(11, 0);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(197, 80);
         this.groupBox2.TabIndex = 0;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Segment Rectangle";
         // 
         // groupBox1
         // 
         this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.groupBox1.Location = new System.Drawing.Point(11, 82);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(117, 54);
         this.groupBox1.TabIndex = 11;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Segment Type";
         // 
         // _btnOk
         // 
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(133, 88);
         this._btnOk.Name = "_btnOk";
         this._btnOk.TabIndex = 9;
         this._btnOk.Text = "&Ok";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(133, 114);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 10;
         this._btnCancel.Text = "&Cancel";
         // 
         // SegmentInformationDialog
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(218, 143);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._txtSegmentType);
         this.Controls.Add(this._txtBottom);
         this.Controls.Add(this._txtRight);
         this.Controls.Add(this._txtTop);
         this.Controls.Add(this._txtLeft);
         this.Controls.Add(this._lblBottom);
         this.Controls.Add(this._lblRight);
         this.Controls.Add(this._lblTop);
         this.Controls.Add(this._lblLeft);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.groupBox2);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SegmentInformationDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Segment Information";
         this.ResumeLayout(false);

      }
      #endregion

      private System.Windows.Forms.Label _lblLeft;
      private System.Windows.Forms.TextBox _txtLeft;
      private System.Windows.Forms.TextBox _txtTop;
      private System.Windows.Forms.Label _lblTop;
      private System.Windows.Forms.TextBox _txtRight;
      private System.Windows.Forms.Label _lblRight;
      private System.Windows.Forms.TextBox _txtBottom;
      private System.Windows.Forms.Label _lblBottom;
      private System.Windows.Forms.TextBox _txtSegmentType;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;

      private int _left;
      private int _right;
      private int _top;
      private int _bottom;
      private int _imageWidth;
      private int _imageHeight;

      public int NewLeft
      {
         get
         {
            return _left;
         }
         set
         {
            _left = value;
            _txtLeft.Text = _left.ToString();
         }
      }
      public int NewRight
      {
         get
         {
            return _right;
         }
         set
         {
            _right = value;
            _txtRight.Text = _right.ToString();
         }
      }
      public int NewTop
      {
         get
         {
            return _top;
         }
         set
         {
            _top = value;
            _txtTop.Text = _top.ToString();
         }
      }
      public int NewBottom
      {
         get
         {
            return _bottom;
         }
         set
         {
            _bottom = value;
            _txtBottom.Text = _bottom.ToString();
         }
      }

      private void _txtLeft_TextChanged(object sender, System.EventArgs e)
      {
         if(_txtLeft.Text.Length == 0)
            _txtLeft.Text = "0";

         if ((Convert.ToInt32(_txtLeft.Text)) > _imageWidth)
            _txtLeft.Text = Convert.ToString(_imageWidth);

         _left = Int32.Parse(_txtLeft.Text);
      }

      private void _txtRight_TextChanged(object sender, System.EventArgs e)
      {
         if(_txtRight.Text.Length == 0)
            _txtRight.Text = "0";

         if ((Convert.ToInt32(_txtRight.Text)) > _imageWidth)
            _txtRight.Text = Convert.ToString(_imageWidth);

         _right = Int32.Parse(_txtRight.Text);
      }

      private void _txtTop_TextChanged(object sender, System.EventArgs e)
      {
         if(_txtTop.Text.Length == 0)
            _txtTop.Text = "0";

         if ((Convert.ToInt32(_txtTop.Text)) > _imageHeight)
            _txtTop.Text = Convert.ToString(_imageHeight);

         _top = Int32.Parse(_txtTop.Text);
      }

      private void _txtBottom_TextChanged(object sender, System.EventArgs e)
      {
         if(_txtBottom.Text.Length == 0)
            _txtBottom.Text = "0";

         if ((Convert.ToInt32(_txtBottom.Text)) > _imageHeight)
            _txtBottom.Text = Convert.ToString(_imageHeight);

         _bottom = Int32.Parse(_txtBottom.Text);
      }

      private void _txt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
         if(!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            e.Handled = true;
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         if(_left < 0)
            Messager.ShowError(this, "Invalid y-coordinate of the rectangle's upper-left corner");
         else if(_top < 0)
            Messager.ShowError(this, "Invalid y-coordinate of the rectangle's upper-left corner");
         else if(_right > _imageWidth)
            Messager.ShowError(this, "Invalid x-coordinate of the rectangle's lower-right corner");
         else if(_bottom > _imageHeight)
            Messager.ShowError(this, "Invalid y-coordinate of the rectangle's lower-right corner.");
         else if((_right - _left) < 15)
            Messager.ShowError(this, "Invalid rectangle width.");
         else if((_bottom - _top) < 15)
            Messager.ShowError(this, "Invalid rectangle height.");
         else
         {
            this.DialogResult = DialogResult.OK;
            Close();
         }
      }
   }


   /// <summary>
   /// Summary description for PdfDPIOptions.
   /// </summary>
   public class PdfDPIOptions : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TextBox _txtXResolution;
      private System.Windows.Forms.Label _lblYResolution;
      private System.Windows.Forms.Label _lblXResolution;
      private System.Windows.Forms.TextBox _txtYResolution;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public PdfDPIOptions(MainForm mainForm, int initXResolution, int initYResolution)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         _mainForm = mainForm;
         _xResolution = initXResolution;
         _yResolution = initYResolution;
         InitClass();
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
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._txtYResolution = new System.Windows.Forms.TextBox();
         this._txtXResolution = new System.Windows.Forms.TextBox();
         this._lblYResolution = new System.Windows.Forms.Label();
         this._lblXResolution = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(136, 72);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 6;
         this._btnCancel.Text = "&Cancel";
         // 
         // _btnOk
         // 
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(40, 72);
         this._btnOk.Name = "_btnOk";
         this._btnOk.TabIndex = 5;
         this._btnOk.Text = "&Ok";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _txtYResolution
         // 
         this._txtYResolution.Location = new System.Drawing.Point(200, 32);
         this._txtYResolution.Name = "_txtYResolution";
         this._txtYResolution.Size = new System.Drawing.Size(42, 20);
         this._txtYResolution.TabIndex = 4;
         this._txtYResolution.Text = "";
         this._txtYResolution.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         this._txtYResolution.TextChanged += new System.EventHandler(this._txtYResolution_TextChanged);
         // 
         // _txtXResolution
         // 
         this._txtXResolution.Location = new System.Drawing.Point(80, 32);
         this._txtXResolution.Name = "_txtXResolution";
         this._txtXResolution.Size = new System.Drawing.Size(42, 20);
         this._txtXResolution.TabIndex = 2;
         this._txtXResolution.Text = "";
         this._txtXResolution.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         this._txtXResolution.TextChanged += new System.EventHandler(this._txtXResolution_TextChanged);
         // 
         // _lblYResolution
         // 
         this._lblYResolution.Location = new System.Drawing.Point(136, 32);
         this._lblYResolution.Name = "_lblYResolution";
         this._lblYResolution.Size = new System.Drawing.Size(72, 16);
         this._lblYResolution.TabIndex = 3;
         this._lblYResolution.Text = "&YResolution";
         // 
         // _lblXResolution
         // 
         this._lblXResolution.Location = new System.Drawing.Point(16, 32);
         this._lblXResolution.Name = "_lblXResolution";
         this._lblXResolution.Size = new System.Drawing.Size(72, 16);
         this._lblXResolution.TabIndex = 1;
         this._lblXResolution.Text = "&XResolution";
         // 
         // groupBox2
         // 
         this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.groupBox2.Location = new System.Drawing.Point(8, 8);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(248, 56);
         this.groupBox2.TabIndex = 7;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "PDF Resolution";
         // 
         // PdfDPIOptions
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(264, 101);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._txtXResolution);
         this.Controls.Add(this._txtYResolution);
         this.Controls.Add(this._lblYResolution);
         this.Controls.Add(this._lblXResolution);
         this.Controls.Add(this.groupBox2);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PdfDPIOptions";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "PdfDPIOptions";
         this.groupBox2.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      private MainForm _mainForm;
      private int _xResolution;
      private int _yResolution;

      public int XResolution
      {
         get
         {
            return _xResolution;
         }
      }

      public int YResolution
      {
         get
         {
            return _yResolution;
         }
      }

      private void InitClass( )
      {
         _txtXResolution.Text = _xResolution.ToString();
         _txtYResolution.Text = _yResolution.ToString();
      }

      private void _txtXResolution_TextChanged(object sender, System.EventArgs e)
      {
         if(_txtXResolution.Text.Length == 0)
            _txtXResolution.Text = "10";

         _xResolution = Int32.Parse(_txtXResolution.Text);
      }

      private void _txtYResolution_TextChanged(object sender, System.EventArgs e)
      {
         if(_txtYResolution.Text.Length == 0)
            _txtYResolution.Text = "10";

         _yResolution = Int32.Parse(_txtYResolution.Text);
      }

      private void _txt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
         if(!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            e.Handled = true;
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         if(_xResolution < 10 || _xResolution > 1000)
            Messager.ShowError(this, "Invalid x-resolution. The x-resolution value should be between 10 and 1000");
         else if(_yResolution < 10 || _yResolution > 1000)
            Messager.ShowError(this, "Invalid y-resolution. The y-resolution value should be between 10 and 1000");
         else
         {
            _xResolution = Int32.Parse(_txtXResolution.Text);
            _yResolution = Int32.Parse(_txtYResolution.Text);

            this.DialogResult = DialogResult.OK;
            Close();
         }
      }
   }
}
