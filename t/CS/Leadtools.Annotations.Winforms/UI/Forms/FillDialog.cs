// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;

namespace Leadtools.Annotations.WinForms
{
   public enum AnnotationFillType
   {
      Solid,
      Hatch,
   }

   class FillDialog : Form
   {
      private ComboBox comboBox1;
      private Button _btn_Cancel;
      private System.Windows.Forms.PropertyGrid propertyGrid1;
      private Button _btn_OK;
      private AnnBrush _brush = new AnnSolidColorBrush();

      public FillDialog(AnnBrush brush)
      {
         InitializeComponent();

         if (brush != null)
            _brush = brush.Clone();

         var annBurshConverter = TypeDescriptor.GetConverter(typeof(AnnBrush));

         propertyGrid1.SelectedObject = new FillDescriptor(_brush, "Fill");

         comboBox1.DataSource = Enum.GetValues(typeof(AnnotationFillType));

         if (_brush is AnnSolidColorBrush)
            comboBox1.SelectedIndex = (int)AnnotationFillType.Solid;
         if (_brush is AnnHatchBrush)
            comboBox1.SelectedIndex = (int)AnnotationFillType.Hatch;

         comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
      }

      private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
      {
         AnnotationFillType annotationFillType = AnnotationFillType.Solid;
         if (comboBox1.SelectedIndex != -1)
            annotationFillType = (AnnotationFillType)comboBox1.SelectedIndex;

         switch (annotationFillType)
         {
            case AnnotationFillType.Solid:
               _brush = new AnnSolidColorBrush();
               break;

            case AnnotationFillType.Hatch:
               _brush = new AnnHatchBrush();
               break;
         }

         propertyGrid1.SelectedObject = null;
         propertyGrid1.SelectedObject = new FillDescriptor(_brush, "Fill");
      }

      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FillDialog));
         this._btn_OK = new System.Windows.Forms.Button();
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this._btn_Cancel = new System.Windows.Forms.Button();
         this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
         this.SuspendLayout();
         // 
         // _btn_OK
         // 
         this._btn_OK.Location = new System.Drawing.Point(197, 231);
         this._btn_OK.Name = "_btn_OK";
         this._btn_OK.Size = new System.Drawing.Size(75, 23);
         this._btn_OK.TabIndex = 0;
         this._btn_OK.Text = "OK";
         this._btn_OK.UseVisualStyleBackColor = true;
         this._btn_OK.Click += new System.EventHandler(this._btn_OK_Click);
         // 
         // comboBox1
         // 
         this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Location = new System.Drawing.Point(12, 12);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(260, 21);
         this.comboBox1.TabIndex = 1;
         // 
         // _btn_Cancel
         // 
         this._btn_Cancel.Location = new System.Drawing.Point(116, 231);
         this._btn_Cancel.Name = "_btn_Cancel";
         this._btn_Cancel.Size = new System.Drawing.Size(75, 23);
         this._btn_Cancel.TabIndex = 3;
         this._btn_Cancel.Text = "Cancel";
         this._btn_Cancel.UseVisualStyleBackColor = true;
         this._btn_Cancel.Click += new System.EventHandler(this._btn_Cancel_Click);
         // 
         // propertyGrid1
         // 
         this.propertyGrid1.Location = new System.Drawing.Point(12, 40);
         this.propertyGrid1.Name = "propertyGrid1";
         this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
         this.propertyGrid1.Size = new System.Drawing.Size(260, 185);
         this.propertyGrid1.TabIndex = 4;
         this.propertyGrid1.ToolbarVisible = false;
         // 
         // FillDialog
         // 
         this.ClientSize = new System.Drawing.Size(284, 266);
         this.Controls.Add(this.propertyGrid1);
         this.Controls.Add(this._btn_Cancel);
         this.Controls.Add(this.comboBox1);
         this.Controls.Add(this._btn_OK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FillDialog";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.Text = "Select Fill";
         this.ResumeLayout(false);
      }

      public AnnBrush Fill
      {
         get { return (propertyGrid1.SelectedObject as FillDescriptor).Brush; }
      }

      private void _btn_OK_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btn_Cancel_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
         this.Close();
      }
   }
}
