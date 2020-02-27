// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Pdf;
using Leadtools.Svg;

namespace PDFFormsDemo
{
   public class PDFDocumentHelper
   {
      public static bool _hasForms = false;
      public static bool HasForms
      {
         get { return _hasForms; }
      }

      public static void LoadPDFDocument(RasterCodecs codecs, PDFDocument document, ImageViewer imageList)
      {
         _hasForms = false;

         imageList.BeginUpdate();

         imageList.Items.Clear();

         document.ParsePages(PDFParsePagesOptions.FormFields, 1, -1);

         for (int i = 0; i < document.Pages.Count; i++)
         {
            PDFPageItem page = new PDFPageItem();
            // Set page image to use as thumb image 
            page.Image = document.GetPageImage(codecs, i + 1);
            // Set page SVG document.
            page.PageSVG = document.GetPageSvg(codecs, i + 1, new CodecsLoadSvgOptions()) as SvgDocument;
            page.PageSVG.OptimizeView();
            // Set page Raster image.
            page.PageImage = document.GetPageImage(codecs, i + 1);
            // Set page number.
            page.PageNumber = i + 1;
            // Set Form Field Associated with this page
            page.FormFields = document.Pages[i].FormFields;

            // Check if the document has forms.
            if (!_hasForms && document.Pages[i].FormFields != null && document.Pages[i].FormFields.Count > 0)
               _hasForms = true;

            page.FormControls = PDFFormContolsHelper.FormFieldsToControls(document.Pages[i].FormFields, document.Resolution);

            imageList.Items.Add(page);
         }

         imageList.EndUpdate();
      }

      public static void LoadFormsFieldsFromXML(string xmlFileName, PDFDocument document, ImageViewer imageList)
      {
         FormFieldControl.FormFieldsToolTip.RemoveAll();

         List<XMLDocumentPage> pages = PDFFormsSerializationManager.LoadXML(xmlFileName);

         for (int i = 0; i < pages.Count; i++)
         {
            PDFPageItem page = imageList.Items[i] as PDFPageItem;

            page.FormFields = pages[i].FormFields;

            // Check if the document has forms.
            if (!HasForms && pages[i].FormFields != null && pages[i].FormFields.Count > 0)
               _hasForms = true;

            page.FormControls = ToFormControls(pages[i].FormFields, document.Resolution);
         }
      }

      private static List<FormFieldControl> ToFormControls(IList<PDFFormField> pdfFormFields, int docResolution)
      {
         return PDFFormContolsHelper.FormFieldsToControls(pdfFormFields, docResolution);
      }
   }

   public class XMLDocumentPage
   {
      public XMLDocumentPage()
      {
         this.PageNumber = -1;

         this.FormFields = null;
      }

      public int PageNumber
      {
         get;
         set;
      }

      public IList<PDFFormField> FormFields
      {
         get;
         set;
      }
   }
}
