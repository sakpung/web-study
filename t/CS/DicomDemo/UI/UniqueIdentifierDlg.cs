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
   /// Summary description for UniqueIdentifierDlg.
   /// </summary>
   public class UniqueIdentifierDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;
      private System.Windows.Forms.ListView listViewUID;

      public UniqueIdentifierDlg()
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
         this.button1 = new System.Windows.Forms.Button();
         this.listViewUID = new System.Windows.Forms.ListView();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button1.Location = new System.Drawing.Point(289, 272);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(72, 24);
         this.button1.TabIndex = 1;
         this.button1.Text = "&Close";
         // 
         // listViewUID
         // 
         this.listViewUID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                      this.columnHeader1,
                                                                                      this.columnHeader2,
                                                                                      this.columnHeader3});
         this.listViewUID.FullRowSelect = true;
         this.listViewUID.GridLines = true;
         this.listViewUID.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.listViewUID.Location = new System.Drawing.Point(12, 8);
         this.listViewUID.Name = "listViewUID";
         this.listViewUID.Size = new System.Drawing.Size(628, 256);
         this.listViewUID.TabIndex = 2;
         this.listViewUID.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Code";
         this.columnHeader1.Width = 180;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Name";
         this.columnHeader2.Width = 320;
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "Type";
         this.columnHeader3.Width = 100;
         // 
         // UniqueIdentifierDlg
         // 
         this.AcceptButton = this.button1;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.button1;
         this.ClientSize = new System.Drawing.Size(650, 301);
         this.Controls.Add(this.listViewUID);
         this.Controls.Add(this.button1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "UniqueIdentifierDlg";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Unique IdentifierDlg (UID)";
         this.Load += new System.EventHandler(this.UniqueIdentifierDlg_Load);
         this.ResumeLayout(false);

      }
      #endregion

      private void UniqueIdentifierDlg_Load(object sender, System.EventArgs e)
      {
         DicomUid uid = null;

         uid = DicomUidTable.Instance.GetFirst();
         while (uid != null)
         {
            ListViewItem item;

            item = listViewUID.Items.Add(uid.Code);
            item.SubItems.Add(uid.Name);
            item.SubItems.Add(uid.Type.ToString());
            uid = DicomUidTable.Instance.GetNext(uid);
         }
      }

      private string GetUIDType(int type)
      {
         //DicomUIDTypes uid = (DicomUIDTypes)type;
         //string t;

         //t = uid.ToString();
         //t = t.Remove(0,t.LastIndexOf("_")+1);

         //return t;
         return "";
      }
   }
}
