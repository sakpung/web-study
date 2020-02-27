using System;
using System.Windows.Forms;

using Leadtools;
using Leadtools.WinForms;
using Leadtools.Demos;

namespace ScreenCaptureDemo
{
   partial class CapturedImageForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapturedImageForm));
          this.SuspendLayout();
          // 
          // CapturedImageForm
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Name = "CapturedImageForm";
          this.Load += new System.EventHandler(this.CapturedImageForm_Load);
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CapturedImageForm_FormClosing);
          this.ResumeLayout(false);

      }

      #endregion
   }
}
