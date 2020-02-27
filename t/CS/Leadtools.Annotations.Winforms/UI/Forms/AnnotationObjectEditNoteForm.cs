// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Annotations.Core;

namespace Leadtools.Annotations.WinForms
{
   public partial class AnnotationObjectEditNoteForm : Form
   {
      private AnnObject _annObject;
      public AnnotationObjectEditNoteForm(AnnObject annObject)
      {
         InitializeComponent();

         _annObject = annObject;
         _noteTextBox.Text = _annObject.Note;
         Text = string.Format("{0}, {1}", Environment.UserName, _annObject.FriendlyName);
      
         FormClosed += new FormClosedEventHandler(AnnotationObjectEditNoteForm_FormClosed);
      }

      private void AnnotationObjectEditNoteForm_FormClosed(object sender, FormClosedEventArgs e)
      {
         _annObject.Note = _noteTextBox.Text;
         FormClosed -= new FormClosedEventHandler(AnnotationObjectEditNoteForm_FormClosed);
      }
   }
}
