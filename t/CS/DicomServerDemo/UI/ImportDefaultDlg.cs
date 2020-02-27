// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for ImportDefaultDlg.
   /// </summary>
   public class ImportDefaultDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ListBox listBoxLEAD;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox textBoxDir;
      private System.Windows.Forms.Button buttonDir;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public string AdditionalDir = "";

      public ImportDefaultDlg( )
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportDefaultDlg));
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.listBoxLEAD = new System.Windows.Forms.ListBox();
         this.label3 = new System.Windows.Forms.Label();
         this.textBoxDir = new System.Windows.Forms.TextBox();
         this.buttonDir = new System.Windows.Forms.Button();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(453, 64);
         this.label1.TabIndex = 0;
         this.label1.Text = resources.GetString("label1.Text");
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(8, 80);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(184, 16);
         this.label2.TabIndex = 1;
         this.label2.Text = "LEAD Installed Images:";
         // 
         // listBoxLEAD
         // 
         this.listBoxLEAD.Location = new System.Drawing.Point(8, 96);
         this.listBoxLEAD.Name = "listBoxLEAD";
         this.listBoxLEAD.Size = new System.Drawing.Size(453, 95);
         this.listBoxLEAD.TabIndex = 2;
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(8, 200);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(344, 16);
         this.label3.TabIndex = 3;
         this.label3.Text = "Additional directory of images to import:";
         // 
         // textBoxDir
         // 
         this.textBoxDir.Location = new System.Drawing.Point(8, 216);
         this.textBoxDir.Name = "textBoxDir";
         this.textBoxDir.Size = new System.Drawing.Size(423, 20);
         this.textBoxDir.TabIndex = 4;
         // 
         // buttonDir
         // 
         this.buttonDir.Location = new System.Drawing.Point(437, 216);
         this.buttonDir.Name = "buttonDir";
         this.buttonDir.Size = new System.Drawing.Size(24, 20);
         this.buttonDir.TabIndex = 5;
         this.buttonDir.Text = "...";
         this.buttonDir.Click += new System.EventHandler(this.buttonDir_Click);
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button1.Location = new System.Drawing.Point(377, 256);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 6;
         this.button1.Text = "Cancel";
         // 
         // button2
         // 
         this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button2.Location = new System.Drawing.Point(296, 256);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 7;
         this.button2.Text = "OK";
         // 
         // ImportDefaultDlg
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(485, 285);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.buttonDir);
         this.Controls.Add(this.textBoxDir);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.listBoxLEAD);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ImportDefaultDlg";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Import Files";
         this.Closed += new System.EventHandler(this.ImportDefaultDlg_Closed);
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      public void FillFileList(StringCollection files)
      {
         foreach(string file in files)
         {
            listBoxLEAD.Items.Add(file);
         }
      }

      private void buttonDir_Click(object sender, System.EventArgs e)
      {
         if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
         {
            textBoxDir.Text = folderBrowserDialog1.SelectedPath;
         }
      }

      private void ImportDefaultDlg_Closed(object sender, System.EventArgs e)
      {
         AdditionalDir = textBoxDir.Text;
      }
   }
}
