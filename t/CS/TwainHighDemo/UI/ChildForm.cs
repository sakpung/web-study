// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Controls;

namespace TwainHighDemo
{
   /// <summary>
   /// Summary description for ChildForm.
   /// </summary>
   public class ChildForm : System.Windows.Forms.Form
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public ChildForm( )
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
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ChildForm));
         // 
         // ChildForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "ChildForm";
         this.Text = "ChildForm";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.ChildForm_Closing);
         this.Load += new System.EventHandler(this.ChildForm_Load);

      }
      #endregion
      public ImageViewer _viewer;

      private void ChildForm_Load(object sender, System.EventArgs e)
      {
      }

      public void InsertImage(RasterImage img, string imageName)
      {
         // initialize the _viewer object
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();

         _viewer.Image = img;
         Text = imageName;
      }

      private void ChildForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         MainForm parentForm = (MainForm)MdiParent;
         if(parentForm.MdiChildren.Length == 1)
            parentForm.EnableMenuItems(false);
      }
   }
}
