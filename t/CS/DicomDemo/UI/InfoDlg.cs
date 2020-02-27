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
   /// Summary description for InfoDialog.
   /// </summary>
   public class InfoDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.TextBox textBoxMetaHeader;
      private System.Windows.Forms.TextBox textBoxTransfer;
      private System.Windows.Forms.TextBox textBoxVR;
      private System.Windows.Forms.TextBox textBoxClass;
      private System.Windows.Forms.TextBox textBoxPreamble;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      private DicomDataSet ds;

      public InfoDlg(DicomDataSet ds)
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
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.textBoxMetaHeader = new System.Windows.Forms.TextBox();
         this.textBoxTransfer = new System.Windows.Forms.TextBox();
         this.textBoxVR = new System.Windows.Forms.TextBox();
         this.textBoxClass = new System.Windows.Forms.TextBox();
         this.textBoxPreamble = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 16);
         this.label1.Name = "label1";
         this.label1.TabIndex = 0;
         this.label1.Text = "Meta-Header:";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(16, 48);
         this.label2.Name = "label2";
         this.label2.TabIndex = 1;
         this.label2.Text = "Transfer Syntax:";
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(16, 80);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(120, 23);
         this.label3.TabIndex = 2;
         this.label3.Text = "Value Representation:";
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(16, 112);
         this.label4.Name = "label4";
         this.label4.TabIndex = 3;
         this.label4.Text = "Class:";
         // 
         // label5
         // 
         this.label5.Location = new System.Drawing.Point(16, 144);
         this.label5.Name = "label5";
         this.label5.TabIndex = 4;
         this.label5.Text = "Preamble:";
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button1.Location = new System.Drawing.Point(204, 256);
         this.button1.Name = "button1";
         this.button1.TabIndex = 5;
         this.button1.Text = "&Close";
         // 
         // textBoxMetaHeader
         // 
         this.textBoxMetaHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.textBoxMetaHeader.Location = new System.Drawing.Point(136, 16);
         this.textBoxMetaHeader.Name = "textBoxMetaHeader";
         this.textBoxMetaHeader.ReadOnly = true;
         this.textBoxMetaHeader.Size = new System.Drawing.Size(336, 20);
         this.textBoxMetaHeader.TabIndex = 6;
         this.textBoxMetaHeader.Text = "";
         // 
         // textBoxTransfer
         // 
         this.textBoxTransfer.Location = new System.Drawing.Point(136, 48);
         this.textBoxTransfer.Name = "textBoxTransfer";
         this.textBoxTransfer.ReadOnly = true;
         this.textBoxTransfer.Size = new System.Drawing.Size(336, 20);
         this.textBoxTransfer.TabIndex = 7;
         this.textBoxTransfer.Text = "";
         // 
         // textBoxVR
         // 
         this.textBoxVR.Location = new System.Drawing.Point(136, 80);
         this.textBoxVR.Name = "textBoxVR";
         this.textBoxVR.ReadOnly = true;
         this.textBoxVR.Size = new System.Drawing.Size(336, 20);
         this.textBoxVR.TabIndex = 8;
         this.textBoxVR.Text = "";
         // 
         // textBoxClass
         // 
         this.textBoxClass.Location = new System.Drawing.Point(136, 112);
         this.textBoxClass.Name = "textBoxClass";
         this.textBoxClass.ReadOnly = true;
         this.textBoxClass.Size = new System.Drawing.Size(336, 20);
         this.textBoxClass.TabIndex = 9;
         this.textBoxClass.Text = "";
         // 
         // textBoxPreamble
         // 
         this.textBoxPreamble.Location = new System.Drawing.Point(136, 144);
         this.textBoxPreamble.Multiline = true;
         this.textBoxPreamble.Name = "textBoxPreamble";
         this.textBoxPreamble.ReadOnly = true;
         this.textBoxPreamble.Size = new System.Drawing.Size(336, 104);
         this.textBoxPreamble.TabIndex = 10;
         this.textBoxPreamble.Text = "";
         // 
         // InfoDlg
         // 
         this.AcceptButton = this.button1;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.button1;
         this.ClientSize = new System.Drawing.Size(482, 287);
         this.Controls.Add(this.textBoxPreamble);
         this.Controls.Add(this.textBoxClass);
         this.Controls.Add(this.textBoxVR);
         this.Controls.Add(this.textBoxTransfer);
         this.Controls.Add(this.textBoxMetaHeader);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "InfoDlg";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Dataset Info";
         this.Load += new System.EventHandler(this.InfoDlg_Load);
         this.ResumeLayout(false);

      }
      #endregion

      private void InfoDlg_Load(object sender, System.EventArgs e)
      {
         DicomIod iod;

         textBoxTransfer.Text = (ds.InformationFlags & DicomDataSetFlags.LittleEndian) == DicomDataSetFlags.LittleEndian ? "Little-Endian" : "Big-Endian";
         textBoxVR.Text = (ds.InformationFlags & DicomDataSetFlags.ExplicitVR) == DicomDataSetFlags.ExplicitVR ? "Explicit" : "Implicit";

         iod = DicomIodTable.Instance.FindClass(ds.InformationClass);
         if(iod == null)
         {
            textBoxClass.Text = string.Format("Unknown class {0}", ds.InformationClass);
         }
         else
         {
            textBoxClass.Text = iod.Name;
         }

         if((ds.InformationFlags & DicomDataSetFlags.MetaHeaderPresent) == DicomDataSetFlags.MetaHeaderPresent)
         {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();

            textBoxMetaHeader.Text = "Present";
            byte[] preamble = ds.GetPreamble(255);
            textBoxPreamble.Text = enc.GetString(preamble);
         }
         else
         {
            textBoxMetaHeader.Text = "Absent";
         }
      }
   }
}
