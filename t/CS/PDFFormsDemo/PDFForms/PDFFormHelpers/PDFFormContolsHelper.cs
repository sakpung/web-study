// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Controls;
using Leadtools.Pdf;

namespace PDFFormsDemo
{
   public class PDFFormContolsHelper
   {
      public static List<FormFieldControl> FormFieldsToControls(IList<PDFFormField> formFields, int docResolution)
      {
         List<FormFieldControl> formControls = new List<FormFieldControl>();

         foreach (PDFFormField field in formFields)
         {
            formControls.Add(CreateFieldControl(field, docResolution));
         }

         return formControls;
      }

      public static void SetPageControlsToCanvas(PDFPageItem page, ImageViewer imageViewer)
      {
         imageViewer.Controls.Clear();

         foreach (FormFieldControl formFieldControl in page.FormControls)
         {
            imageViewer.Controls.Add(formFieldControl);
         }
      }

      public static void UpdateFormFieldsFromControls(IList<PDFFormField> formFields, IList<FormFieldControl> controls)
      {
         for (int i = 0; i < controls.Count; i++)
         {
            controls[i].UpdateFormField(formFields[i]);
         }
      }

      private static FormFieldControl CreateRadioButton(PDFFormField field)
      {
         RadioFormField formFieldControl = new RadioFormField();

         List<PDFRadioButton> groupPanel;

         if (!PDFRadioButton.RadioButtonGroups.TryGetValue(field.GroupId.ToString(), out groupPanel))
         {
            PDFRadioButton.RadioButtonGroups[field.GroupId.ToString()] = new List<PDFRadioButton>();
         }

         PDFRadioButton.RadioButtonGroups[field.GroupId.ToString()].Add((formFieldControl as RadioFormField).PDFRadioButton);
         return formFieldControl;
      }

      private static FormFieldControl CreateFieldControl(PDFFormField field, int docResolution)
      {
         FormFieldControl formFieldControl = null;
         switch (field.FieldType)
         {
            case PDFFormField.FieldTypeCheckBox:
               if (((field.FieldFlags & PDFFormField.FieldFlagsButtonRadio) == PDFFormField.FieldFlagsButtonRadio) ||
                    ((field.FieldFlags & PDFFormField.FieldFlagsButtonRadioInUnison) == PDFFormField.FieldFlagsButtonRadioInUnison) ||
                    field.GroupId > 0)
               {
                  formFieldControl = CreateRadioButton(field);
               }
               else
               {
                  formFieldControl = new CheckFormField();
               }
               break;
            case PDFFormField.FieldTypeRadioButton:
               formFieldControl = CreateRadioButton(field);
               break;

            case PDFFormField.FieldTypeComboBox:
               formFieldControl = new ComboFormField();
               break;

            case PDFFormField.FieldTypeListBox:
               formFieldControl = new ListFormField();
               break;

            case PDFFormField.FieldTypeTextBox:
               formFieldControl = new TextFormField();
               break;
         }

         formFieldControl.DocResolution = docResolution;
         formFieldControl.InitControl(field);

         return formFieldControl;
      }
   }
}
