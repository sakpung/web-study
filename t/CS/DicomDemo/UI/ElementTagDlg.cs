// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.DicomDemos;
using Leadtools.Dicom;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for ElementTagDlg.
   /// </summary>
   public class ElementTagDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.ListView listViewTag;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.Button button1;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ColumnHeader columnHeader4;
      private System.Windows.Forms.ColumnHeader columnHeader5;
      private System.Windows.Forms.ColumnHeader columnHeader6;

      public ElementTagDlg()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
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
      private void InitializeComponent()
      {
         this.listViewTag = new System.Windows.Forms.ListView();
         this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // listViewTag
         // 
         this.listViewTag.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                      this.columnHeader6,
                                                                                      this.columnHeader1,
                                                                                      this.columnHeader2,
                                                                                      this.columnHeader3,
                                                                                      this.columnHeader4,
                                                                                      this.columnHeader5});
         this.listViewTag.FullRowSelect = true;
         this.listViewTag.GridLines = true;
         this.listViewTag.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.listViewTag.Location = new System.Drawing.Point(8, 8);
         this.listViewTag.Name = "listViewTag";
         this.listViewTag.Size = new System.Drawing.Size(600, 264);
         this.listViewTag.TabIndex = 0;
         this.listViewTag.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader6
         // 
         this.columnHeader6.Text = "Name";
         this.columnHeader6.Width = 250;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Code";
         this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.columnHeader1.Width = 65;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Mask";
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "MinVM";
         this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // columnHeader4
         // 
         this.columnHeader4.Text = "MaxVM";
         this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // columnHeader5
         // 
         this.columnHeader5.Text = "DivideVM";
         this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button1.Location = new System.Drawing.Point(272, 280);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "&Close";
         // 
         // ElementTagDlg
         // 
         this.AcceptButton = this.button1;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.button1;
         this.ClientSize = new System.Drawing.Size(618, 309);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.listViewTag);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ElementTagDlg";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Element Tags";
         this.Load += new System.EventHandler(this.ElementTagDlg_Load);
         this.ResumeLayout(false);

      }
      #endregion

      private void ElementTagDlg_Load(object sender, System.EventArgs e)
      {
         DicomTag tag = DicomTagTable.Instance.GetFirst();

         while (tag != null)
         {
            ListViewItem item;

            item = listViewTag.Items.Add(tag.Name);
            item.SubItems.Add(String.Format("{0:x4}:{1:x4}", Utils.GetGroup((long)tag.Code),
                              Utils.GetElement((long)tag.Code)));
            item.SubItems.Add(tag.Mask.ToString("X"));
            item.SubItems.Add(tag.MinVM.ToString());
            item.SubItems.Add(tag.MaxVM.ToString());
            item.SubItems.Add(tag.VMDivider.ToString());
            tag = DicomTagTable.Instance.GetNext(tag);
         }
      }
   }
}
