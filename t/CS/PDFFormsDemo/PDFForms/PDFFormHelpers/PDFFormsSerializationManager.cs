// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools;
using Leadtools.Pdf;
using System.Xml;

namespace PDFFormsDemo
{
   public class PDFFormsSerializationManager
   {
      #region Save Fields As XML

      public static void SaveXML(List<PDFPageItem> pages, string fileName)
      {
         XmlDocument document = new XmlDocument();
         XmlNode pdfDocumentNode = document.CreateElement("PDFDocument");

         foreach (PDFPageItem page in pages)
         {
            XmlNode pageNode = document.CreateElement("PDFDocumentPage");

            XmlNode formFieldsNode = document.CreateElement("PDFFormFields");

            // Create new copy for page form fields
            List<PDFFormField> formFieldsList = new List<PDFFormField>();
            foreach (PDFFormField field in page.FormFields)
               formFieldsList.Add(field);

            PDFFormContolsHelper.UpdateFormFieldsFromControls(formFieldsList, page.FormControls);

            foreach (PDFFormField field in formFieldsList)
            {
               XmlNode fieldNode = CreateFieldNode(document, field);
               formFieldsNode.AppendChild(fieldNode);
            }

            XmlNode pageNumber = document.CreateElement("PageNumber");
            pageNumber.InnerText = page.PageNumber.ToString();

            pageNode.AppendChild(pageNumber);
            pageNode.AppendChild(formFieldsNode);

            pdfDocumentNode.AppendChild(pageNode);
         }

         document.AppendChild(pdfDocumentNode);
         document.Save(fileName);
      }

      private static XmlNode CreateFieldNode(XmlDocument document, PDFFormField formField)
      {
         XmlNode fieldNode = document.CreateElement("PDFField");

         XmlNode typeNode = document.CreateElement("FieldType");
         typeNode.InnerText = formField.FieldType.ToString();
         fieldNode.AppendChild(typeNode);

         XmlNode nameNode = document.CreateElement("Name");
         nameNode.InnerText = formField.Name;
         fieldNode.AppendChild(nameNode);

         XmlNode mappingNameNode = document.CreateElement("MappingName");
         mappingNameNode.InnerText = formField.MappingName;
         fieldNode.AppendChild(mappingNameNode);

         XmlNode alternateNameNode = document.CreateElement("AlternateName");
         alternateNameNode.InnerText = formField.AlternateName;
         fieldNode.AppendChild(alternateNameNode);

         XmlNode optionalNameNode = document.CreateElement("OptionalName");
         optionalNameNode.InnerText = formField.OptionalName;
         fieldNode.AppendChild(optionalNameNode);

         XmlNode pageNumberNode = document.CreateElement("PageNumber");
         pageNumberNode.InnerText = formField.PageNumber.ToString();
         fieldNode.AppendChild(pageNumberNode);

         XmlNode boundsNode = document.CreateElement("Bounds");
         SetBoundsNodeValue(document, boundsNode, formField.Bounds);
         fieldNode.AppendChild(boundsNode);

         XmlNode contentTypeNode = document.CreateElement("ContentType");
         contentTypeNode.InnerText = formField.ContentType.ToString();
         fieldNode.AppendChild(contentTypeNode);

         XmlNode contentsNode = document.CreateElement("Contents");
         SetContentsNodeValue(document, contentsNode, formField.Contents);
         fieldNode.AppendChild(contentsNode);

         XmlNode contentValuesNode = document.CreateElement("ContentValues");
         SetContentsNodeValue(document, contentValuesNode, formField.ContentValues);
         fieldNode.AppendChild(contentValuesNode);

         XmlNode fieldFlagsNode = document.CreateElement("FieldFlags");
         fieldFlagsNode.InnerText = formField.FieldFlags.ToString();
         fieldNode.AppendChild(fieldFlagsNode);

         XmlNode groupIdNode = document.CreateElement("GroupId");
         groupIdNode.InnerText = formField.GroupId.ToString();
         fieldNode.AppendChild(groupIdNode);

         XmlNode maxLengthNode = document.CreateElement("MaxLength");
         maxLengthNode.InnerText = formField.MaxLength.ToString();
         fieldNode.AppendChild(maxLengthNode);

         XmlNode SelectedContentsNode = document.CreateElement("SelectedContents");
         SetIndexesNodeValue(document, SelectedContentsNode, formField.SelectedContents);
         fieldNode.AppendChild(SelectedContentsNode);

         XmlNode stateNode = document.CreateElement("State");
         stateNode.InnerText = formField.State.ToString();
         fieldNode.AppendChild(stateNode);

         XmlNode viewFlagsNode = document.CreateElement("ViewFlags");
         viewFlagsNode.InnerText = formField.ViewFlags.ToString();
         fieldNode.AppendChild(viewFlagsNode);

         XmlNode borderColorNode = document.CreateElement("BorderColor");
         SetColorNoderValue(document, borderColorNode, formField.BorderColor);
         fieldNode.AppendChild(borderColorNode);

         XmlNode borderStyleNode = document.CreateElement("BorderStyle");
         borderStyleNode.InnerText = formField.BorderStyle.ToString();
         fieldNode.AppendChild(borderStyleNode);

         XmlNode borderWidthNode = document.CreateElement("BorderWidth");
         borderWidthNode.InnerText = formField.BorderWidth.ToString();
         fieldNode.AppendChild(borderWidthNode);

         XmlNode fillColorNode = document.CreateElement("FillColor");
         SetColorNoderValue(document, fillColorNode, formField.FillColor);
         fieldNode.AppendChild(fillColorNode);

         XmlNode fillModeNode = document.CreateElement("FillMode");
         fillModeNode.InnerText = formField.FillMode.ToString();
         fieldNode.AppendChild(fillModeNode);

         XmlNode fontNameNode = document.CreateElement("FontName");
         fontNameNode.InnerText = formField.FontName.ToString();
         fieldNode.AppendChild(fontNameNode);

         XmlNode fontSizeNode = document.CreateElement("FontSize");
         fontSizeNode.InnerText = formField.FontSize.ToString();
         fieldNode.AppendChild(fontSizeNode);

         XmlNode textColorNode = document.CreateElement("TextColor");
         SetColorNoderValue(document, textColorNode, formField.TextColor);
         fieldNode.AppendChild(textColorNode);

         XmlNode textJustificationNode = document.CreateElement("TextJustification");
         textJustificationNode.InnerText = formField.TextJustification.ToString();
         fieldNode.AppendChild(textJustificationNode);

         XmlNode rotateNode = document.CreateElement("Rotate");
         rotateNode.InnerText = formField.Rotation.ToString();
         fieldNode.AppendChild(rotateNode);

         return fieldNode;
      }

      private static void SetBoundsNodeValue(XmlDocument document, XmlNode boundsNode, PDFRect rect)
      {
         XmlNode bottomNode = document.CreateElement("Bottom");
         bottomNode.InnerText = rect.Bottom.ToString();
         boundsNode.AppendChild(bottomNode);

         XmlNode leftNode = document.CreateElement("Left");
         leftNode.InnerText = rect.Left.ToString();
         boundsNode.AppendChild(leftNode);

         XmlNode topNode = document.CreateElement("Right");
         topNode.InnerText = rect.Right.ToString();
         boundsNode.AppendChild(topNode);

         XmlNode rightNode = document.CreateElement("Top");
         rightNode.InnerText = rect.Top.ToString();
         boundsNode.AppendChild(rightNode);
      }

      private static void SetContentsNodeValue(XmlDocument document, XmlNode contentsNode, IList<string> contents)
      {
         foreach (string item in contents)
         {
            XmlNode itemNode = document.CreateElement("Content");
            itemNode.InnerText = item;
            contentsNode.AppendChild(itemNode);
         }
      }

      private static void SetIndexesNodeValue(XmlDocument document, XmlNode contentsNode, IList<string> contents)
      {
         foreach (string item in contents)
         {
            XmlNode itemNode = document.CreateElement("index");
            itemNode.InnerText = item;
            contentsNode.AppendChild(itemNode);
         }
      }

      private static void SetColorNoderValue(XmlDocument document, XmlNode colorNode, RasterColor color)
      {
         XmlNode alphaNode = document.CreateElement("A");
         alphaNode.InnerText = color.A.ToString();
         colorNode.AppendChild(alphaNode);

         XmlNode redNode = document.CreateElement("R");
         redNode.InnerText = color.R.ToString();
         colorNode.AppendChild(redNode);

         XmlNode greenNode = document.CreateElement("G");
         greenNode.InnerText = color.G.ToString();
         colorNode.AppendChild(greenNode);

         XmlNode blueNode = document.CreateElement("B");
         blueNode.InnerText = color.B.ToString();
         colorNode.AppendChild(blueNode);
      }

      #endregion

      #region Load Fields From XML

      public static List<XMLDocumentPage> LoadXML(string fileName)
      {
         XmlDocument document = new XmlDocument();
         document.Load(fileName);

         XmlNodeList pages = document.GetElementsByTagName("PDFDocumentPage");

         var pdfPages = new List<XMLDocumentPage>();

         foreach (XmlNode page in pages)
         {
            if (page.ChildNodes.Count > 1)
            {
               int pageNumber = int.Parse(page.ChildNodes[0].InnerText);
               XmlNode formFields = page.ChildNodes[1];

               XMLDocumentPage xmlPage = new XMLDocumentPage();
               xmlPage.PageNumber = pageNumber;
               xmlPage.FormFields = GetPDFFormFields(formFields);

               pdfPages.Add(xmlPage);
            }
         }

         return pdfPages;
      }

      private static List<PDFFormField> GetPDFFormFields(XmlNode formFields)
      {
         List<PDFFormField> pdfFormField = new List<PDFFormField>();

         // Get the Pdf Fileds listed in "PDFFormFields" node.
         XmlNodeList fieldsList = formFields.ChildNodes;

         foreach (XmlNode fieldNode in fieldsList)
         {
            XmlNodeList fieldProperties = fieldNode.ChildNodes;

            PDFFormField formField = GetPDFFormField(fieldProperties);

            pdfFormField.Add(formField);
         }

         return pdfFormField;
      }

      private static PDFFormField GetPDFFormField(XmlNodeList fieldProperties)
      {
         PDFFormField formField = new PDFFormField();
         // Get form field Type
         formField.FieldType = int.Parse(fieldProperties[0].InnerText);

         // Get form field Name
         formField.Name = fieldProperties[1].InnerText;

         // Get form field MappingName
         formField.MappingName = fieldProperties[2].InnerText;

         // Get form field AlternateName
         formField.AlternateName = fieldProperties[3].InnerText;

         // Get form field OptionalName
         formField.OptionalName = fieldProperties[4].InnerText;

         // Get form field PageNumber
         formField.PageNumber = int.Parse(fieldProperties[5].InnerText);

         // Get form field Bounds
         formField.Bounds = GetBoundsFromNode(fieldProperties[6]);

         // Get form field ContentType
         formField.ContentType = int.Parse(fieldProperties[7].InnerText);

         // Get form field Contents
         SetContentsFromNode(formField.Contents, fieldProperties[8]);

         // Get form field ContentValues
         SetContentsFromNode(formField.ContentValues, fieldProperties[9]);

         // Get form field Flags
         formField.FieldFlags = long.Parse(fieldProperties[10].InnerText);

         // Get form field GroupId
         formField.GroupId = int.Parse(fieldProperties[11].InnerText);

         // Get form field MaxLength
         formField.MaxLength = int.Parse(fieldProperties[12].InnerText);

         // Get form field SelectedContents
         SetSelectedContentsFromNode(formField.SelectedContents, fieldProperties[13]);

         // Get form field State
         formField.State = int.Parse(fieldProperties[14].InnerText);

         // Get form view flags
         formField.ViewFlags = long.Parse(fieldProperties[15].InnerText);

         // Get form border color
         formField.BorderColor = GetRasterColorFromNode(fieldProperties[16]);

         // Get form border style
         formField.BorderStyle = int.Parse(fieldProperties[17].InnerText);

         // Get form border width
         formField.BorderWidth = int.Parse(fieldProperties[18].InnerText);

         // Get form fill color
         formField.FillColor = GetRasterColorFromNode(fieldProperties[19]);

         // Get form fill mode
         formField.FillMode = int.Parse(fieldProperties[20].InnerText);

         // Get form font name
         formField.FontName = fieldProperties[21].InnerText;

         // Get form font size
         formField.FontSize = int.Parse(fieldProperties[22].InnerText);

         // Get form text color
         formField.TextColor = GetRasterColorFromNode(fieldProperties[23]);

         // Get form text justification
         formField.TextJustification = int.Parse(fieldProperties[24].InnerText);

         formField.Rotation = int.Parse(fieldProperties[25].InnerText);

         return formField;
      }

      private static PDFRect GetBoundsFromNode(XmlNode boundsNode)
      {
         XmlNodeList boundsNodeChildren = boundsNode.ChildNodes;

         double bottom = double.Parse(boundsNodeChildren[0].InnerText);
         double left = double.Parse(boundsNodeChildren[1].InnerText);
         double right = double.Parse(boundsNodeChildren[2].InnerText);
         double top = double.Parse(boundsNodeChildren[3].InnerText);

         return new PDFRect(left, top, right, bottom);
      }

      private static void SetContentsFromNode(IList<string> contents, XmlNode contentsNode)
      {
         XmlNodeList contentsNodeChildren = contentsNode.ChildNodes;

         foreach (XmlNode node in contentsNodeChildren)
         {
            contents.Add(node.InnerText);
         }
      }

      private static void SetSelectedContentsFromNode(IList<string> SelectedContents, XmlNode SelectedContentsNode)
      {
         XmlNodeList contentsNodeChildren = SelectedContentsNode.ChildNodes;

         foreach (XmlNode node in contentsNodeChildren)
         {
            SelectedContents.Add(node.InnerText);
         }
      }

      private static RasterColor GetRasterColorFromNode(XmlNode colorNode)
      {
         XmlNodeList colorNodeChildren = colorNode.ChildNodes;

         int a = int.Parse(colorNodeChildren[0].InnerText);
         int r = int.Parse(colorNodeChildren[1].InnerText);
         int g = int.Parse(colorNodeChildren[2].InnerText);
         int b = int.Parse(colorNodeChildren[3].InnerText);

         return new RasterColor(a, r, g, b);
      }

      #endregion
   }
}
