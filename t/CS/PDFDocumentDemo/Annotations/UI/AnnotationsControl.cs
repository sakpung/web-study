// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Leadtools.Annotations.Engine;
using Leadtools.Pdf.Annotations;

using Leadtools.Annotations.Automation;

namespace PDFDocumentDemo.Annotations
{
   public partial class AnnotationsControl : UserControl
   {
      private DocumentAnnotations _documentAnnotations;
      public DocumentAnnotations DocumentAnnotations
      {
         get { return _documentAnnotations; }
         set { _documentAnnotations = value; }
      }

      public AnnotationsControl()
      {
         InitializeComponent();
      }

      public void CreateToolBar()
      {

         // Create the toolbar
         _documentAnnotations.AutomationManagerHelper.CreateToolBar();

         // Set its properties
         ToolBar toolBar = _documentAnnotations.AutomationManagerHelper.ToolBar;
         toolBar.Dock = DockStyle.Top;
         toolBar.BringToFront();
         toolBar.Appearance = ToolBarAppearance.Flat;
         toolBar.BringToFront();
         this._toolbarPanel.Controls.Add(toolBar);

         Populate();
      }

      public AnnAutomation Automation
      {
         get { return _automationListControl.Automation; }
         set
         {
            if (_automationListControl.Automation != null)
            {
               _automationListControl.Automation.Detach();
               _automationListControl.Automation = null;
            }
            _automationListControl.Automation = value; 
         }
      }

      public void Populate()
      {
         _automationListControl.Populate();
      }

      private void _propertiesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _documentAnnotations.Automation.ShowObjectProperties();
      }

      private void _contentToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _documentAnnotations.ShowObjectContent(_documentAnnotations.Automation.CurrentEditObject);
      }

      private void _deleteToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _documentAnnotations.DeleteSelectedObject();
      }
   }
}
