using Leadtools.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDFDocumentDemo
{
   public partial class PDFFontsDialog : Form
   {
      private PDFDocument _document;

      public PDFFontsDialog(PDFDocument document)
      {
         InitializeComponent();

         _document = document;
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            if (_document.Fonts != null && _document.Fonts.Count > 0)
            {
               foreach (PDFFont font in _document.Fonts)
               {
                  string faceName = GetPDFFontFaceName(font);
                  string type = GetPDFFontTypeName(font);
                  string encoding = GetPDFFontEncodingName(font);

                  var item = new ListViewItem();
                  item.Text = faceName;
                  item.SubItems.Add(type);
                  item.SubItems.Add(encoding);
                  _fontsListView.Items.Add(item);
               }
            }
         }

         base.OnLoad(e);
      }

      private static string GetPDFFontFaceName(PDFFont font)
      {
         if (string.IsNullOrEmpty(font.FaceName))
            return string.Empty;

         string faceName = font.FaceName;

         // Stripe out everything between + and -
         char[] separator = { '+', '-' };
         int index = faceName.IndexOfAny(separator);
         if (index != -1)
         {
            faceName = faceName.Substring(index + 1);
            index = faceName.IndexOfAny(separator);
            if (index != -1)
               faceName = faceName.Substring(0, index);
         }

         switch (font.EmbeddingType)
         {
            case PDFFontEmbeddingType.Embedded:
               faceName += " (Embedded)";
               break;

            case PDFFontEmbeddingType.EmbeddedSubset:
               faceName += " (Embedded Subset)";
               break;

            case PDFFontEmbeddingType.None:
            default:
               break;
         }

         return faceName;
      }

      private static string GetPDFFontTypeName(PDFFont font)
      {
         if (string.IsNullOrEmpty(font.FontType))
            return string.Empty;

         if (string.Compare(PDFFont.TypeType0, font.FontType, true) == 0)
         {
            if (string.Compare(PDFFont.TypeCIDFontType2, font.DescendantCID, true) == 0)
               return "TrueType (CID) ";
            else
               return "Type 2 (CID) ";
         }

         if (string.Compare(PDFFont.TypeType1, font.FontType, true) == 0)
            return "Type 1";

         if (string.Compare(PDFFont.TypeType3, font.FontType, true) == 0)
            return "Type 3";

         return font.FontType;
      }

      private static string GetPDFFontEncodingName(PDFFont font)
      {
         if (string.IsNullOrEmpty(font.Encoding))
            return "Custom";

         if (string.Compare(PDFFont.EncodingWinAnsiEncoding, font.Encoding, true) == 0)
            return "Ansi";

         if (string.Compare(PDFFont.EncodingStandardEncoding, font.Encoding, true) == 0)
            return "Standard";

         if (string.Compare(PDFFont.EncodingPDFDocEncoding, font.Encoding, true) == 0)
            return "PDF";

         if (string.Compare(PDFFont.EncodingMacExpertEncoding, font.Encoding, true) == 0)
            return "MAC Expert";

         if (string.Compare(PDFFont.EncodingMacRomanEncoding, font.Encoding, true) == 0)
            return "MAC Roman";

         return font.Encoding;
      }
   }
}
