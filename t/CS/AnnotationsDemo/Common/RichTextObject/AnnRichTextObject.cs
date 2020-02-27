// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Xml;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Design;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Leadtools.Annotations.Engine
{
   public class AnnRichTextObject : AnnRectangleObject
   {
      public override string FriendlyName { get { return "RichText"; } }

      public override bool SupportsFont
      {
         get
         {
            return true;
         }
      }

      public override bool SupportsFill
      {
         get
         {
            return true;
         }
      }

      public override bool CanRotate
      {
         get
         {
            return false;
         }
      }

      public AnnRichTextObject()
      {
         SetId(AnnObject.RichTextObjectId);
         Fill = null;
      }

      string _rtfText = @"{\rtf1\fbidis\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Arial;}}{\colortbl ;\red255\green0\blue0;\red255\green255\blue255;\red0\green128\blue0;\red0\green0\blue255;\red0\green0\blue0;}\viewkind4\uc1\pard\ltrpar\cf1\highlight2\fs20 Aa\cf3 Bb\cf4 Yy\cf5 Zz\par}";
      public string Rtf
      {
         get { return _rtfText; }
         set
         {
            if (_rtfText != value)
            {
               AnnPropertyChangedEventArgs args = new AnnPropertyChangedEventArgs("RtfText", PropertyChangedStatus.Before, _rtfText, value);
               OnPropertyChanged(args);
               if (!args.Cancel)
               {
                  args.Status = PropertyChangedStatus.After;
                  _rtfText = value;
                  OnPropertyChanged(args);
               }
            }
         }
      }

      public override AnnObject Clone()
      {
         AnnRichTextObject annTextObject = base.Clone() as AnnRichTextObject;

         if (annTextObject != null)
         {
            annTextObject.Rtf = _rtfText;
         }

         return annTextObject;
      }

      public override void Serialize(AnnSerializeOptions options, XmlNode parentNode, XmlDocument document)
      {
         base.Serialize(options, parentNode, document);

         XmlNode element = document.CreateElement("Rtf");;
         if (element != null)
         {
            element.InnerText = _rtfText;
            parentNode.AppendChild(element);
         }
      }

      public override void Deserialize(AnnDeserializeOptions options, XmlNode element, XmlDocument document)
      {
         base.Deserialize(options, element, document);

         XmlElement xmlElement = element as XmlElement;

         _rtfText = ReadStringElement(document, "Rtf", element);
      }

      public static string ReadStringElement(XmlDocument document, string elementName, XmlNode node)
      {
         XmlElement xmlElement = node as XmlElement;
         string data = string.Empty;

         if (xmlElement != null)
         {
            foreach (XmlNode childNode in xmlElement.GetElementsByTagName(elementName))
            {
               if (childNode.ParentNode == node)
               {
                  if (childNode != null && childNode.HasChildNodes)
                  {
                     data = childNode.FirstChild.Value.Trim();
                  }

                  break;
               }
            }
         }

         return data;
      }

      protected override AnnObject Create()
      {
         return new AnnRichTextObject();
      }

      public override string ToString()
      {
         string text = _rtfText;
         using (RichTextBox rtf = new RichTextBox())
         {
            rtf.Rtf = _rtfText;
            text = rtf.Text;
         }

         return text;
      }
   }
}
