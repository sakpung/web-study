// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Pdf;


namespace PDFFormsDemo
{
   public class PDFFormControlsPropertiesHelper
   {
      public static double PDFDocumentDefaultResolution = 72.0;

      public static void SetControlBounds(FormFieldControl fieldControl, PDFRect bounds, int docResolution)
      {
         double pdfResolutionFactor = docResolution / 72.0;

         LeadRect rect = new LeadRect(
                     (int)(bounds.Left * pdfResolutionFactor),
                     (int)(bounds.Top * pdfResolutionFactor),
                     (int)(bounds.Width * pdfResolutionFactor),
                     (int)(bounds.Height * pdfResolutionFactor));

         fieldControl.FiedlBounds = rect;
      }

      public static void SetControlFont(FormFieldControl fieldControl, string fontName, int fontSize, RasterColor textColor)
      {
         fontName = string.IsNullOrEmpty(fontName) ? "Arial" : fontName;

         fieldControl.AutoFontResize = (fontSize == -1 || fontSize == 0);

         fieldControl.Font = new Font(fontName, fieldControl.AutoFontResize ? FormFieldControl.MaxFontSize : fontSize);

         fieldControl.ForeColor = Color.FromArgb(textColor.A, textColor.R, textColor.G, textColor.B);
      }

      public static void SetControlFlagsProperties(FormFieldControl fieldControl, long viewFlags, long fieldFlags)
      {
         bool Hidden = (viewFlags & PDFFormField.ViewFlagsHidden) == PDFFormField.ViewFlagsHidden;
         bool NoView = (viewFlags & PDFFormField.ViewFlagsNoView) == PDFFormField.ViewFlagsNoView;
         bool Print = (viewFlags & PDFFormField.ViewFlagsPrint) == PDFFormField.ViewFlagsPrint;
         bool Locked = (viewFlags & PDFFormField.ViewFlagsLocked) == PDFFormField.ViewFlagsLocked;
         bool NoRotate = (viewFlags & PDFFormField.ViewFlagsNoRotate) == PDFFormField.ViewFlagsNoRotate;
         bool ReadOnly = (fieldFlags & PDFFormField.FieldFlagsReadOnly) == PDFFormField.FieldFlagsReadOnly;

         if (Hidden)
         {
            fieldControl.IsFieldVisible = false;
            fieldControl.IsFieldPrintable = false;
         }
         else
         {
            if (NoView)
               fieldControl.IsFieldVisible = false;
            else
               fieldControl.IsFieldVisible = true;

            if (Print)
               fieldControl.IsFieldPrintable = true;
            else
               fieldControl.IsFieldPrintable = false;
         }

         if (Locked)
            fieldControl.IsFieldLocked = true;
         else
            fieldControl.IsFieldLocked = false;

         if (ReadOnly)
            fieldControl.IsReadOnly = true;
         else
            fieldControl.IsReadOnly = false;

         if (NoRotate)
            fieldControl.IsFieldRotatable = false;
         else
            fieldControl.IsFieldRotatable = true;
      }

      public static void SetControlBorder(FormFieldControl fieldControl, RasterColor borderColor, int borderWidth, int borderStyle)
      {
         fieldControl.BorderThickness = borderWidth;
         fieldControl.BorderColor = Color.FromArgb(borderColor.A, borderColor.R, borderColor.G, borderColor.B);

         switch (borderStyle)
         {
            case PDFFormField.BorderStyleSolid:
               fieldControl.FieldBorderStyle = FieldBorderStyle.Solid;
               break;

            case PDFFormField.BorderStyleDashed:
               fieldControl.FieldBorderStyle = FieldBorderStyle.Dashed;
               break;

            case PDFFormField.BorderStyleBeveled:
               fieldControl.FieldBorderStyle = FieldBorderStyle.Beveled;
               break;

            case PDFFormField.BorderStyleInset:
               fieldControl.FieldBorderStyle = FieldBorderStyle.Inset;
               break;

            case PDFFormField.BorderStyleUnderline:
               fieldControl.FieldBorderStyle = FieldBorderStyle.Underlined;
               break;
         }
      }

      public static void SetControlBackground(FormFieldControl fieldControl, RasterColor fillColor, int fillMode)
      {
         if (fillMode == PDFFormField.FillModeFilled)
         {
            fieldControl.BackgroundColor = Color.FromArgb(fillColor.A, fillColor.R, fillColor.G, fillColor.B);
         }
         else
         {
            fieldControl.BackgroundColor = Color.White;
         }

         fieldControl.BackColor = Color.White;
      }
   }
}
