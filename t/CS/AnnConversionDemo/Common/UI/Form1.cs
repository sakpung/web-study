// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Leadtools.Annotations.Engine;
using Leadtools.Codecs;


namespace AnnConversionDemo
{
   public partial class MainForm : Form
   {
      enum ConversionResult
      {
         Undefined = 0,
         Failed = 1,
         Success = 2
      }

      struct ConversionInfo
      {
         public string SourcePath;
         public string DestinationPath;
         public int Page;
         public ConversionResult Result;
      }

      bool _converting = false;

      public MainForm()
      {
         InitializeComponent();

         StringBuilder info = new StringBuilder();
         info.AppendLine("This demo enables you to convert old annotations formats");
         info.AppendLine("to the new format(Annotations.Engine).\n");
         info.AppendLine("The old formats include:\n");
         info.AppendLine("-Old DotNet: xml, serialized, tiff tags, Wang tags.\n");
         info.AppendLine( "-Old WPF: xml, serialized, tiff tags, Wang tags.\n" );
         info.AppendLine( "-Old CDLL: xml, serialized, tiff tags, Wang tags.\n" );
         info.AppendLine("Also you can convert from annotations saved as tags inside tiff");
         info.AppendLine("files and embedded annotations inside pdf file into");
         info.AppendLine("an annotations xml file.");

         using (UserInfoDialog dlg = new UserInfoDialog(info.ToString()))
         {
            dlg.Text = "Annotations Conversion Information";
            dlg.ShowDialog();
         }
      }

      private void _btnBrowseSource_Click(object sender, EventArgs e)
      {
         using (FolderBrowserDialog fbd = new FolderBrowserDialog())
         {
            if (fbd.ShowDialog() == DialogResult.OK)
               _txtSourceDirectory.Text = fbd.SelectedPath;
         }

         UpdateButtons();
      }

      private void _btnBrowseDestination_Click(object sender, EventArgs e)
      {
         using (FolderBrowserDialog fbd = new FolderBrowserDialog())
         {
            if (fbd.ShowDialog() == DialogResult.OK)
               _txtDestinationDirectory.Text = fbd.SelectedPath;
         }

         UpdateButtons();
      }

      void UpdateButtons()
      {
         _btnStart.Enabled = !_converting && !String.IsNullOrEmpty(_txtSourceDirectory.Text) && !String.IsNullOrEmpty(_txtDestinationDirectory.Text);
         _btnExportResults.Enabled = !_converting && _lvResults.Items.Count > 0;
      }

      private void _btnStart_Click(object sender, EventArgs e)
      {
         bool sourceHasAnnFiles = false;

         try
         {

            //check if source exist.
            if (!Directory.Exists(_txtSourceDirectory.Text))
            {
               MessageBox.Show("The source directory is not existing", "Incorrect source directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return;
            }

            //check if destination exist.
            if (!Directory.Exists(_txtDestinationDirectory.Text))
               Directory.CreateDirectory(_txtDestinationDirectory.Text);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }

         _converting = true;
         _lvResults.Items.Clear();
         UpdateButtons();

         int index = 0;

         string[] srcFolderFiles = Directory.GetFiles(_txtSourceDirectory.Text, "*.*", SearchOption.TopDirectoryOnly);

         foreach (string srcAnnotationFile in srcFolderFiles.Where(ext => ext.ToLower().EndsWith(".ann")
         || ext.ToLower().EndsWith(".xml") || ext.ToLower().EndsWith(".tif") || ext.ToLower().EndsWith(".pdf")))
         {
            Application.DoEvents();

            ConversionInfo conversionInfo = new ConversionInfo();
            conversionInfo.SourcePath = srcAnnotationFile;
            string destAnnotationFile = string.Format("{0}.xml", Path.Combine(_txtDestinationDirectory.Text, Path.GetFileNameWithoutExtension(srcAnnotationFile)));
            conversionInfo.DestinationPath = destAnnotationFile;

            try
            {
               AnnContainer[] containers = null;
               double dpiX = 96.0;
               double dpiY = 96.0;

               //try to get the relative image for this annotations file assuming it is located behind the annotations file , if it is not exist then take the default dpi 96*96
               string relativeImageFile = string.Empty;
               string fileExt = Path.GetExtension(srcAnnotationFile);
               if (fileExt.ToLower() == ".tif" || fileExt.ToLower() == ".pdf")
               {
                  //the annotations is embedded inside the file
                  relativeImageFile = srcAnnotationFile;
               }
               else
               {
                  foreach (string file in srcFolderFiles)
                  {
                     if (Path.GetFileNameWithoutExtension(file) == Path.GetFileNameWithoutExtension(srcAnnotationFile)
                        && Path.GetExtension(file).ToLower() != ".xml"
                        && Path.GetExtension(file).ToLower() != ".ann")
                     {
                        relativeImageFile = file;
                     }
                  }
               }

               try
               {
                  if (relativeImageFile != string.Empty)
                  {
                     using (RasterCodecs codecs = new RasterCodecs())
                     {
                        CodecsImageInfo imageInfo = codecs.GetInformation(relativeImageFile, false);
                        dpiX = imageInfo.XResolution;
                        dpiY = imageInfo.YResolution;
                     }
                  }
               }
               catch (Exception ex)
               {
                  MessageBox.Show(ex.Message);
               }

               AnnCodecs annCodecs = new AnnCodecs();
               containers = annCodecs.LoadAll(srcAnnotationFile, dpiX, dpiY);

               conversionInfo.Result = ConversionResult.Success;

               using (Stream stream = File.OpenWrite(destAnnotationFile))
               {
                  annCodecs.SaveAll(stream, containers, AnnFormat.Annotations);
               }

               conversionInfo.Page = index + 1;
               index++;

               AddConversionUpdate(conversionInfo);

               sourceHasAnnFiles = true;
            }
            catch (Exception)
            {
               conversionInfo.Result = ConversionResult.Failed;
               AddConversionUpdate(conversionInfo);
               continue;
            }
         }

         _converting = false;
         UpdateButtons();

         if (sourceHasAnnFiles)
            MessageBox.Show("Conversion Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         else
            MessageBox.Show("There is no valid annotation file in source directory", "No source annotations", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      void AddConversionUpdate(ConversionInfo conversionInfo)
      {
         ListViewItem newItem = new ListViewItem();
         newItem.Text = Path.GetFileName(conversionInfo.SourcePath);
         newItem.SubItems.Add(Path.GetFileName(conversionInfo.DestinationPath));
         newItem.SubItems.Add(conversionInfo.Page > 0 ? conversionInfo.Page.ToString() : "NA");
         newItem.SubItems.Add(conversionInfo.Result.ToString());

         _lvResults.Items.Add(newItem);
         Application.DoEvents();
      }

      private void _btnStop_Click(object sender, EventArgs e)
      {
         Application.DoEvents();
      }

      private void _btnExportResults_Click(object sender, EventArgs e)
      {
         //Save results to csv file
         try
         {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
               sfd.Title = "Select a file to save the results";
               sfd.Filter = "Comma Separated Value Files (*.csv)|*.csv|All files (*.*)|*.*";
               if (sfd.ShowDialog() != DialogResult.OK)
                  return;

               //Setup header
               string csvString = String.Format("{0},{1},{2},{3}", _chSource.Text, _chDestination.Text, _chPage.Text, _chResult.Text);

               //Add line between header and data
               csvString = csvString + Environment.NewLine;

               //Add data
               foreach (ListViewItem conversionItem in _lvResults.Items)
                  csvString = String.Format("{0}{1}{2},{3},{4},{5}", csvString, Environment.NewLine, conversionItem.Text, conversionItem.SubItems[1].Text, conversionItem.SubItems[2].Text, conversionItem.SubItems[3].Text);

               File.WriteAllText(sfd.FileName, csvString);
               MessageBox.Show("Export Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         }
         catch
         {
            MessageBox.Show("Error exporting results", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         UpdateButtons();
      }

      private void _txt_TextChanged(object sender, EventArgs e)
      {
         UpdateButtons();
      }

   }
}
