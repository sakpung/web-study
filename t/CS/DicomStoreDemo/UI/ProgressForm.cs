// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for ProgressForm.
   /// </summary>
   public class ProgressForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button CancelBtn;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public ProgressForm( )
      {
         Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
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
         this.CancelBtn = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // CancelBtn
         // 
         this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.CancelBtn.Location = new System.Drawing.Point(143, 72);
         this.CancelBtn.Name = "CancelBtn";
         this.CancelBtn.TabIndex = 1;
         this.CancelBtn.Text = "Cancel";
         // 
         // ProgressForm
         // 
         this.AcceptButton = this.CancelBtn;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.CancelBtn;
         this.ClientSize = new System.Drawing.Size(360, 109);
         this.Controls.Add(this.CancelBtn);
         this.Name = "ProgressForm";
         this.ShowInTaskbar = false;
         this.Text = "Storing Images";
         this.Load += new System.EventHandler(this.ProgressForm_Load);
         this.Activated += new System.EventHandler(this.ProgressForm_Activated);
         this.ResumeLayout(false);

      }
      #endregion

      private void ProgressForm_Load(object sender, System.EventArgs e)
      {
      }

      private void ProgressForm_Activated(object sender, System.EventArgs e)
      {
      }
   }
}
