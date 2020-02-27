// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Dicom;
using Leadtools.DicomDemos;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for DicomInfoDlg.
   /// </summary>
   public class DicomInfoDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TreeView treeViewElements;
      private System.Windows.Forms.Button button1;
      private System.ComponentModel.IContainer components;
      private System.Windows.Forms.ImageList imageList2;

      private DicomDataSet ds = new DicomDataSet();
      private System.Windows.Forms.TextBox textBoxValues;
      private System.Windows.Forms.PropertyGrid propertyGridElement;

      public DicomInfoDlg( )
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
         this.components = new System.ComponentModel.Container();
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DicomInfoDlg));
         this.label1 = new System.Windows.Forms.Label();
         this.treeViewElements = new System.Windows.Forms.TreeView();
         this.propertyGridElement = new System.Windows.Forms.PropertyGrid();
         this.button1 = new System.Windows.Forms.Button();
         this.imageList2 = new System.Windows.Forms.ImageList(this.components);
         this.textBoxValues = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(100, 16);
         this.label1.TabIndex = 0;
         this.label1.Text = "Dicom Tags:";
         // 
         // treeViewElements
         // 
         this.treeViewElements.FullRowSelect = true;
         this.treeViewElements.HideSelection = false;
         this.treeViewElements.ImageList = this.imageList2;
         this.treeViewElements.Location = new System.Drawing.Point(8, 32);
         this.treeViewElements.Name = "treeViewElements";
         this.treeViewElements.Size = new System.Drawing.Size(312, 368);
         this.treeViewElements.TabIndex = 1;
         this.treeViewElements.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewElements_AfterSelect);
         // 
         // propertyGridElement
         // 
         this.propertyGridElement.CommandsVisibleIfAvailable = true;
         this.propertyGridElement.HelpVisible = false;
         this.propertyGridElement.LargeButtons = false;
         this.propertyGridElement.LineColor = System.Drawing.SystemColors.ScrollBar;
         this.propertyGridElement.Location = new System.Drawing.Point(328, 32);
         this.propertyGridElement.Name = "propertyGridElement";
         this.propertyGridElement.Size = new System.Drawing.Size(168, 192);
         this.propertyGridElement.TabIndex = 2;
         this.propertyGridElement.Text = "propertyGrid1";
         this.propertyGridElement.ToolbarVisible = false;
         this.propertyGridElement.ViewBackColor = System.Drawing.SystemColors.Window;
         this.propertyGridElement.ViewForeColor = System.Drawing.SystemColors.WindowText;
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button1.Location = new System.Drawing.Point(421, 408);
         this.button1.Name = "button1";
         this.button1.TabIndex = 4;
         this.button1.Text = "OK";
         // 
         // imageList2
         // 
         this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
         this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
         this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
         // 
         // textBoxValues
         // 
         this.textBoxValues.Location = new System.Drawing.Point(328, 232);
         this.textBoxValues.Multiline = true;
         this.textBoxValues.Name = "textBoxValues";
         this.textBoxValues.ReadOnly = true;
         this.textBoxValues.Size = new System.Drawing.Size(168, 168);
         this.textBoxValues.TabIndex = 5;
         this.textBoxValues.Text = "";
         // 
         // DicomInfoDlg
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(506, 437);
         this.Controls.Add(this.textBoxValues);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.propertyGridElement);
         this.Controls.Add(this.treeViewElements);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "DicomInfoDlg";
         this.Text = "Dicom Information";
         this.Load += new System.EventHandler(this.DicomInfoDlg_Load);
         this.ResumeLayout(false);

      }
      #endregion

      private void DicomInfoDlg_Load(object sender, System.EventArgs e)
      {
      }

      public DicomExceptionCode UpdateTree(string file)
      {

         try
         {
            ds.Load(file, DicomDataSetLoadFlags.LoadAndClose);

            treeViewElements.BeginUpdate();
            FillTree();
            treeViewElements.EndUpdate();
         }
         catch(DicomException de)
         {
            //
            // Just returning and error so we know that we failed
            //
            return de.Code;
         }
         return DicomExceptionCode.Success;
      }

      private void FillTree( )
      {
         DicomElement element;

         element = ds.GetFirstElement(null, false, true);
         if(element == null)
         {
            string err = string.Format("Error reading dicom dataset!");

            MessageBox.Show(err, "Error");
            return;
         }

         FillSubTree(element, null);
      }

      void FillSubTree(DicomElement element, TreeNode ParentNode)
      {
         TreeNode node;
         string name;
         string temp = "";
         DicomTag tag;
         DicomElement tempElement;

#if (LTV15_CONFIG)
         if (element.UserTag != 0)
            tag = DicomTagTable.Instance.Find(element.UserTag);
         else
            tag = DicomTagTable.Instance.Find(element.Tag);
#else
          tag = DicomTagTable.Instance.Find(element.Tag);
#endif
         if(tag != null)
         {
            name = tag.Name;
         }
         else
            name = "Item";

         long tagValue = 0;
#if (LTV15_CONFIG)
         if (element.UserTag != 0)
            tagValue = element.UserTag;
         else
            tagValue = (long)element.Tag;
#else
         tagValue = (long)element.Tag;
#endif
         temp = string.Format("{0:x4}:{1:x4} - ", Utils.GetGroup(tagValue), Utils.GetElement(tagValue));
         temp = temp + name;

         if(ParentNode != null)
         {
            node = ParentNode.Nodes.Add(temp);
         }
         else
         {
            node = treeViewElements.Nodes.Add(temp);
         }

         node.Tag = element;

         if(ds.IsVolatileElement(element))
         {
            node.ForeColor = Color.Red;
         }

         node.ImageIndex = 1;
         node.SelectedImageIndex = 1;

         tempElement = ds.GetChildElement(element, true);
         if(tempElement != null)
         {
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            FillSubTree(tempElement, node);
         }


         tempElement = ds.GetNextElement(element, true, true);
         if(tempElement != null)
         {
            FillSubTree(tempElement, ParentNode);
         }
      }

      private void treeViewElements_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
      {
         if(treeViewElements.SelectedNode == null)
            return;

         textBoxValues.Text = "";

         if(treeViewElements.SelectedNode.Tag != null)
         {
            DicomElement element = treeViewElements.SelectedNode.Tag as DicomElement;

            if(!IsImageElement(element))
            {
               GetElementValues(element);
            }

            propertyGridElement.SelectedObject = element;
         }

      }

      private void GetElementValues(DicomElement element)
      {
         string value = "";

         value = ds.GetConvertValue(element);
         if(value != null && value.Length > 0)
         {
            value = value.Replace(@"\", "\r\n");
         }
         textBoxValues.Text = value;
      }

      private bool IsImageElement(DicomElement element)
      {
         if(element != null)
         {
            DicomTag tag;
#if (LTV15_CONFIG)
            if (element.UserTag != 0)
               tag = DicomTagTable.Instance.Find(element.UserTag);
            else
               tag = DicomTagTable.Instance.Find(element.Tag);
#else
            tag = DicomTagTable.Instance.Find(element.Tag);
#endif

            //
            // Pixel Data tags will not be display in our list box instead we will load
            //  them in the image viewer
            //
            if(tag != null && tag.Name.IndexOf("Pixel Data") == -1)
            {
               element = ds.GetParentElement(element);
               if(element != null)
               {
#if (LTV15_CONFIG)
                  if (element.UserTag != 0)
                     tag = DicomTagTable.Instance.Find(element.UserTag);
                  else
                     tag = DicomTagTable.Instance.Find(element.Tag);
#else
                  tag = DicomTagTable.Instance.Find(element.Tag);
#endif

                  if(tag != null && tag.Name.IndexOf("Pixel Data") != -1)
                  {
                     return true;
                  }
               }
            }
            else
            {
               return true;
            }
         }
         return false;
      }

      private DicomTag FindTag(long dicomTag)
      {
         DicomTag tag = null;

         tag = DicomTagTable.Instance.Find(dicomTag);
         return tag;
      }
   }
}
