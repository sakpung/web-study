// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.Dicom;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for ValueRepresentationDlg.
   /// </summary>
   public class ValueRepresentationDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ColumnHeader columnHeader4;
      private System.Windows.Forms.ColumnHeader columnHeader5;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;
      private System.Windows.Forms.ListView listViewVR;

      private DicomDataSet ds;

      public ValueRepresentationDlg(DicomDataSet ds)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         this.ds = ds;
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
         this.listViewVR = new System.Windows.Forms.ListView();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // listViewVR
         // 
         this.listViewVR.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
         this.listViewVR.FullRowSelect = true;
         this.listViewVR.GridLines = true;
         this.listViewVR.Location = new System.Drawing.Point(8, 8);
         this.listViewVR.Name = "listViewVR";
         this.listViewVR.Size = new System.Drawing.Size(408, 216);
         this.listViewVR.TabIndex = 0;
         this.listViewVR.UseCompatibleStateImageBehavior = false;
         this.listViewVR.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Code";
         this.columnHeader1.Width = 50;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Name";
         this.columnHeader2.Width = 120;
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "Length";
         this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.columnHeader3.Width = 72;
         // 
         // columnHeader4
         // 
         this.columnHeader4.Text = "Unit Size";
         this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.columnHeader4.Width = 72;
         // 
         // columnHeader5
         // 
         this.columnHeader5.Text = "Restriction";
         this.columnHeader5.Width = 72;
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button1.Location = new System.Drawing.Point(176, 232);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 1;
         this.button1.Text = "&Close";
         // 
         // ValueRepresentationDlg
         // 
         this.AcceptButton = this.button1;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.button1;
         this.ClientSize = new System.Drawing.Size(426, 263);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.listViewVR);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ValueRepresentationDlg";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Value Respresentation (VR)";
         this.Load += new System.EventHandler(this.ValueRepresentationDlg_Load);
         this.ResumeLayout(false);

      }
      #endregion

      private void ValueRepresentationDlg_Load(object sender, System.EventArgs e)
      {
         DicomVR vr = null;

         vr = DicomVRTable.Instance.GetFirst();
         while(vr != null)
         {
            ListViewItem item;

            item = listViewVR.Items.Add(vr.Code.ToString());
            item.SubItems.Add(vr.Name);
            item.SubItems.Add(vr.Length.ToString());
            item.SubItems.Add(vr.UnitSize.ToString());
            item.SubItems.Add(vr.Restriction.ToString());
            vr = DicomVRTable.Instance.GetNext(vr);
         }
      }
   }
}
