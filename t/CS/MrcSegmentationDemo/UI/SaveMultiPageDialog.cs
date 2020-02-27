// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;

using Leadtools;
using Leadtools.Mrc;

namespace MrcSegmentationDemo
{
   /// <summary>
   /// Summary description for SaveMultiPageDialog.
   /// </summary>
   public class SaveMultiPageDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnSave;
      private System.Windows.Forms.ComboBox _cbSaveFormat;
      private System.Windows.Forms.ListBox _lstFilesName;
      private System.Windows.Forms.Button _btnUp;
      private System.Windows.Forms.Button _btnDown;
      private System.Windows.Forms.Label _lblSaveFormat;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public SaveMultiPageDialog(MainForm mainForm)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         _mainForm = mainForm;
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
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SaveMultiPageDialog));
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnSave = new System.Windows.Forms.Button();
         this._cbSaveFormat = new System.Windows.Forms.ComboBox();
         this._lstFilesName = new System.Windows.Forms.ListBox();
         this._btnUp = new System.Windows.Forms.Button();
         this._btnDown = new System.Windows.Forms.Button();
         this._lblSaveFormat = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(96, 144);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 6;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _btnSave
         // 
         this._btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnSave.Location = new System.Drawing.Point(8, 144);
         this._btnSave.Name = "_btnSave";
         this._btnSave.TabIndex = 5;
         this._btnSave.Text = "&Save";
         this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
         // 
         // _cbSaveFormat
         // 
         this._cbSaveFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbSaveFormat.Location = new System.Drawing.Point(84, 109);
         this._cbSaveFormat.Name = "_cbSaveFormat";
         this._cbSaveFormat.Size = new System.Drawing.Size(100, 21);
         this._cbSaveFormat.TabIndex = 4;
         // 
         // _lstFilesName
         // 
         this._lstFilesName.HorizontalScrollbar = true;
         this._lstFilesName.Location = new System.Drawing.Point(8, 8);
         this._lstFilesName.Name = "_lstFilesName";
         this._lstFilesName.Size = new System.Drawing.Size(128, 95);
         this._lstFilesName.TabIndex = 0;
         // 
         // _btnUp
         // 
         this._btnUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_btnUp.BackgroundImage")));
         this._btnUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnUp.Location = new System.Drawing.Point(144, 24);
         this._btnUp.Name = "_btnUp";
         this._btnUp.Size = new System.Drawing.Size(48, 24);
         this._btnUp.TabIndex = 1;
         this._btnUp.Text = "&Up";
         this._btnUp.Click += new System.EventHandler(this._btnUp_Click);
         // 
         // _btnDown
         // 
         this._btnDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnDown.Location = new System.Drawing.Point(144, 64);
         this._btnDown.Name = "_btnDown";
         this._btnDown.Size = new System.Drawing.Size(48, 24);
         this._btnDown.TabIndex = 2;
         this._btnDown.Text = "&Down";
         this._btnDown.Click += new System.EventHandler(this._btnDown_Click);
         // 
         // _lblSaveFormat
         // 
         this._lblSaveFormat.Location = new System.Drawing.Point(8, 112);
         this._lblSaveFormat.Name = "_lblSaveFormat";
         this._lblSaveFormat.Size = new System.Drawing.Size(72, 16);
         this._lblSaveFormat.TabIndex = 3;
         this._lblSaveFormat.Text = "Save &Format";
         // 
         // SaveMultiPageDialog
         // 
         this.AcceptButton = this._btnSave;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(202, 175);
         this.Controls.Add(this._lblSaveFormat);
         this.Controls.Add(this._btnDown);
         this.Controls.Add(this._btnUp);
         this.Controls.Add(this._lstFilesName);
         this.Controls.Add(this._cbSaveFormat);
         this.Controls.Add(this._btnSave);
         this.Controls.Add(this._btnCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SaveMultiPageDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Save Multi Page";
         this.ResumeLayout(false);

      }
      #endregion

      private MainForm _mainForm;
      private ViewerForm[] _mdiChildren;
      private List<RasterImage> _imageCollection;

      private List<MrcSegmenter> _mrcSegmenterCollection;

      public List<MrcSegmenter> SegmenterCollection
      {
         get
         {
            return _mrcSegmenterCollection;
         }
      }

      public List<RasterImage> ImageCollection
      {
         get
         {
            return _imageCollection;
         }
      }

      public int SaveType
      {
         get
         {
            return _cbSaveFormat.SelectedIndex;
         }
      }

      private void InitClass( )
      {
         _mdiChildren = new ViewerForm[_mainForm.MdiChildren.Length];
         int index;
         for(index = 0; index < _mainForm.MdiChildren.Length; index++)
         {
            _mdiChildren[index] = (ViewerForm)_mainForm.MdiChildren[index];
            _lstFilesName.Items.Add(_mdiChildren[index].Text);
         }

         _cbSaveFormat.Items.Add("Standard Mrc");
         _cbSaveFormat.Items.Add("LEAD Mrc");
         _cbSaveFormat.Items.Add("PDF");
         _cbSaveFormat.SelectedIndex = 0;
         _lstFilesName.SelectedIndex = index - 1;
         _imageCollection = new List<RasterImage>();
         _mrcSegmenterCollection = new List<MrcSegmenter>();
      }

      private void _btnUp_Click(object sender, System.EventArgs e)
      {
         int currentIndex = _lstFilesName.SelectedIndex;

         if(currentIndex == 0)
            return;

         string tempString = _lstFilesName.Items[_lstFilesName.SelectedIndex].ToString();

         _lstFilesName.Items.RemoveAt(currentIndex);
         _lstFilesName.Items.Insert(currentIndex - 1, tempString);
         _lstFilesName.SelectedIndex = currentIndex - 1;

         RearrangeFormsArray(currentIndex, currentIndex - 1);
      }

      private void _btnDown_Click(object sender, System.EventArgs e)
      {
         int currentIndex = _lstFilesName.SelectedIndex;

         if(currentIndex == _lstFilesName.Items.Count - 1)
            return;

         string tempString = _lstFilesName.Items[_lstFilesName.SelectedIndex].ToString();

         _lstFilesName.Items.RemoveAt(currentIndex);
         _lstFilesName.Items.Insert(currentIndex + 1, tempString);
         _lstFilesName.SelectedIndex = currentIndex + 1;
      }

      private void _btnSave_Click(object sender, System.EventArgs e)
      {
         int index;
         for(index = 0; index < _lstFilesName.Items.Count; index++)
         {
            _imageCollection.Add(_mdiChildren[index].Image);
            if(_mdiChildren[index].ViewerSegmenter == null)
               _mrcSegmenterCollection.Add(_mdiChildren[index].GetNewSegmenter());
            else
               _mrcSegmenterCollection.Add(_mdiChildren[index].ViewerSegmenter);
         }
      }

      private void RearrangeFormsArray(int firstIndex, int secondIndex)
      {
         ViewerForm tempViwerForm = _mdiChildren[secondIndex];

         _mdiChildren[secondIndex] = _mdiChildren[firstIndex];

         _mdiChildren[firstIndex] = tempViwerForm;
      }

      private void _btnCancel_Click(object sender, System.EventArgs e)
      {
         Close();
      }
   }
}
