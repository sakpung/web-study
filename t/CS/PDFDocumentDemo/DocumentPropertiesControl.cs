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

using Leadtools.Pdf;

namespace PDFDocumentDemo
{
   public partial class DocumentPropertiesControl : UserControl
   {
      public DocumentPropertiesControl()
      {
         InitializeComponent();
      }

      private static DateTime FixDate(DateTimePicker picker, DateTime dt)
      {
         if (dt < picker.MinDate) return picker.MinDate;
         if (dt > picker.MaxDate) return picker.MaxDate;
         return dt;
      }

      public void SetDocumentProperties(PDFDocumentProperties pdfDocproperties, bool readOnly)
      {
         _titleTextBox.Text = pdfDocproperties.Title;
         _authorTextBox.Text = pdfDocproperties.Author;
         _subjectTextBox.Text = pdfDocproperties.Subject;
         _keywordsTextBox.Text = pdfDocproperties.Keywords;
         _creatorTextBox.Text = pdfDocproperties.Creator;
         _producerTextBox.Text = pdfDocproperties.Producer;
         _createdDateTimePicker.Value = FixDate(_createdDateTimePicker, pdfDocproperties.Created);
         _createdTextBox.Text = _createdDateTimePicker.Value.ToString(_createdDateTimePicker.CustomFormat);
         _modifiedDateTimePicker.Value = FixDate(_modifiedDateTimePicker, pdfDocproperties.Modified);
         _modifiedTextBox.Text = _modifiedDateTimePicker.Value.ToString(_modifiedDateTimePicker.CustomFormat);

         if (readOnly)
         {
            _titleTextBox.ReadOnly = true;
            _authorTextBox.ReadOnly = true;
            _subjectTextBox.ReadOnly = true;
            _keywordsTextBox.ReadOnly = true;
            _creatorTextBox.ReadOnly = true;
            _producerTextBox.ReadOnly = true;
            _createdTextBox.ReadOnly = true;
            _createdDateTimePicker.Visible = false;
            _modifiedTextBox.ReadOnly = true;
            _modifiedDateTimePicker.Visible = false;
         }
         else
         {
            _createdTextBox.Visible = false;
            _modifiedTextBox.Visible = false;
         }
      }

      public void UpdateDocumentProperties(PDFDocumentProperties pdfDocproperties)
      {
         pdfDocproperties.Title = _titleTextBox.Text;
         pdfDocproperties.Author = _authorTextBox.Text;
         pdfDocproperties.Subject = _subjectTextBox.Text;
         pdfDocproperties.Keywords = _keywordsTextBox.Text;
         pdfDocproperties.Creator = _creatorTextBox.Text;
         pdfDocproperties.Producer = _producerTextBox.Text;
         pdfDocproperties.Created = _createdDateTimePicker.Value;
         pdfDocproperties.Modified = _modifiedDateTimePicker.Value;
      }
   }
}
