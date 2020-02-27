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
using System.IO;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Codecs;

namespace RasterizeDocumentDemo.UserControls
{
   public partial class DocumentPathControl : UserControl
   {
      public DocumentPathControl()
      {
         InitializeComponent();
      }

      // The LEADTOOLS RastreCodecs object instance used to load raster documents
      private string _documentPath;

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public string DocumentPath
      {
         get { return _documentPath; }
         set { _documentPath = value; }
      }

      /// <summary>
      /// Called by the owner to initialize
      /// </summary>
      public void SetData()
      {
         // Set the state of the controls

         _documentPathTextBox.Text = _documentPath;
      }

      /// <summary>
      /// Called by the owner to get the data
      /// </summary>
      public bool GetData(RasterCodecs rasterCodecsInstance)
      {
         bool ret = true;

         string documentPath = _documentPathTextBox.Text.Trim();

         if(ret)
         {
            if(string.IsNullOrEmpty(documentPath))
            {
               Messager.ShowWarning(this, "Enter the path of the document to load or click the browse button");
               _documentPathTextBox.Focus();
               ret = false;
            }
         }

         if(ret)
         {
            if(!File.Exists(documentPath))
            {
               string message = string.Format(@"File:{0}{0}'{1}'{0}{0}Does not exist.", Environment.NewLine, documentPath);
               Messager.ShowWarning(this, message);
               _documentPathTextBox.Focus();
               ret = false;
            }
         }

         _documentPath = documentPath;

         return ret;
      }

      private void _browseButton_Click(object sender, EventArgs e)
      {
         using(OpenFileDialog dlg = new OpenFileDialog())
         {
            StringBuilder sb = new StringBuilder();

            int count = Tools.DocumentFormats.Formats.Length;

            for(int i = 0; i < count; i++)
            {
               string[] extensions = Tools.DocumentFormats.FormatExtensions[i];

               StringBuilder extension = new StringBuilder();
               extension.AppendFormat("*.{0}", extensions[0]);
               for(int j = 1; j < extensions.Length; j++)
               {
                  extension.AppendFormat(";*.{0}", extensions[j]);
               }

               string friendlyName = Tools.DocumentFormats.FormatFriendlyNames[i];

               sb.AppendFormat("{0} ({1})|{1}|", friendlyName, extension.ToString());
            }

            sb.Append("All Files|*.*");

            dlg.Filter = sb.ToString();

            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _documentPathTextBox.Text = dlg.FileName;
            }
         }
      }
   }
}
