// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

using Leadtools.Demos;
using Leadtools;
using Leadtools.WinForms;

using Leadtools.Drawing;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Engine;
using System.Collections.Generic;
using System.Reflection;
using Leadtools.Annotations.WinForms;
using Leadtools.Annotations.Rendering;
using Leadtools.Annotations.Designers;
using Leadtools.Controls;

namespace AnnotationsBatesStampComposer
{
   /// <summary>
   /// Summary description for AnnotationsForm.
   /// </summary>
   public class AnnotationsForm : System.Windows.Forms.Form
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public AnnotationsForm( )
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnnotationsForm));
         this.SuspendLayout();
         // 
         // AnnotationsForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(292, 271);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "AnnotationsForm";
         this.Text = "w4";
         this.TransparencyKey = System.Drawing.Color.White;
         this.Closing += new System.ComponentModel.CancelEventHandler(this.AnnotationsForm_Closing);
         this.ResumeLayout(false);

      }
      #endregion

      private ImageViewerAutomationControl _automationControl;
      private ImageViewer _viewer;
      private void InitClass( )
      {
         _viewer = new ImageViewer();
         _automationControl = new ImageViewerAutomationControl();
         _automationControl.ImageViewer = _viewer;

         _viewer.Dock = DockStyle.Fill;
         _viewer.BorderStyle = BorderStyle.None;
         Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.MouseMove += new MouseEventHandler(_viewer_MouseMove);
         _viewer.KeyDown += new KeyEventHandler(_viewer_KeyDown);
         _viewer.UseDpi = false;
         _viewer.Focus();
      }

      public MainForm MainForm
      {
         get
         {
            return MdiParent as MainForm;
         }
      }

      public ImageViewer Viewer
      {
         get
         {
            return _viewer;
         }
      }

      public AnnAutomation Automation
      {
         get
         {
            if (_automationControl != null)
               return _automationControl.AutomationObject as AnnAutomation;
            else
               return null;
         }
      }

      public void Initialize(RasterPaintProperties paintProperties , RasterImage image, string fileName)
      {
         InitClass();
         Text = fileName;
         _viewer.Image = image;
         UpdatePaintProperties(paintProperties);

         AnnAutomation automation = new AnnAutomation(MainForm.AutomationManager, _automationControl);

         // Update the container size
         automation.Container.Size = automation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(_viewer.Image.ImageWidth, _viewer.Image.ImageHeight));

         automation.Container.Children.CollectionChanged += new EventHandler<AnnNotifyCollectionChangedEventArgs>(Children_CollectionChanged);
         automation.Container.Mapper.FontRelativeToDevice = false;
         automation.DeserializeObjectError += new EventHandler<AnnSerializeObjectEventArgs>(automation_DeserializeObjectError);

         MainForm.UpdateControls();
      }

      void automation_DeserializeObjectError(object sender, AnnSerializeObjectEventArgs e)
      {
         // In case you need to skip objects or create them yourself
         System.Diagnostics.Debug.WriteLine("Object could not be de-serialized: {0}", e.TypeName);
         e.SkipObject = true;
      }

      private void AnnotationsForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         AnnAutomation automation = Automation;
         if(automation != null)
         {
            automation.Container.Children.CollectionChanged -= new EventHandler<AnnNotifyCollectionChangedEventArgs>(Children_CollectionChanged);
            automation.Container.Mapper.FontRelativeToDevice = false;
            automation.DeserializeObjectError -= new EventHandler<AnnSerializeObjectEventArgs>(automation_DeserializeObjectError);

            if(!e.Cancel)
            {
               MainForm.AutomationManager.Automations.Remove(automation);
            }
         }
      }


      public void UpdatePaintProperties(RasterPaintProperties paintProperties)
      {
         //_viewer.PaintProperties = paintProperties;
      }

      void Children_CollectionChanged(object sender, AnnNotifyCollectionChangedEventArgs e)
      {
         MainForm.UpdateControls();
      }

      private void _viewer_MouseMove(object sender, MouseEventArgs e)
      {
         if(Automation != null && Automation.Container != null)
         {
            LeadPointD physical = new LeadPointD(e.X, e.Y);
            LeadPointD logical = Automation.Container.Mapper.PointToContainerCoordinates(physical);
            MainForm.SetStatusBarText(string.Format("{0}, {1} ({2}, {3})", physical.X, physical.Y, logical.X, logical.Y));
         }
         else
            MainForm.SetStatusBarText(string.Format("{0}, {1}", e.X, e.Y));
      }

      private void automation_ImageDirtyChanged(object sender, EventArgs e)
      {
         MainForm.UpdateControls();
      }

      private void _viewer_KeyDown(object sender, KeyEventArgs e)
      {
         if(!e.Handled)
         {
            if(e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
               e.Handled = true;

               MainForm.Zoom(e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus);
            }
         }
      }
   }
}
