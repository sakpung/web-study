// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.DicomDemos;
using Leadtools.Dicom;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for InformationObjectDefinitionDlg.
   /// </summary>
   public class InformationObjectDefinitionDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.TreeView treeViewIOD;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Label label1;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;
      private System.Windows.Forms.TextBox textBoxDescription;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox textBoxCode;
      private System.Windows.Forms.TextBox textBoxType;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox textBoxUsage;
      private System.Windows.Forms.Label label4;


      public InformationObjectDefinitionDlg()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

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
         this.treeViewIOD = new System.Windows.Forms.TreeView();
         this.textBoxDescription = new System.Windows.Forms.TextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.textBoxCode = new System.Windows.Forms.TextBox();
         this.textBoxType = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.textBoxUsage = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // treeViewIOD
         // 
         this.treeViewIOD.FullRowSelect = true;
         this.treeViewIOD.HideSelection = false;
         this.treeViewIOD.ImageIndex = -1;
         this.treeViewIOD.Location = new System.Drawing.Point(8, 8);
         this.treeViewIOD.Name = "treeViewIOD";
         this.treeViewIOD.SelectedImageIndex = -1;
         this.treeViewIOD.Size = new System.Drawing.Size(488, 216);
         this.treeViewIOD.TabIndex = 0;
         this.treeViewIOD.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewIOD_AfterSelect);
         // 
         // textBoxDescription
         // 
         this.textBoxDescription.Location = new System.Drawing.Point(8, 248);
         this.textBoxDescription.Multiline = true;
         this.textBoxDescription.Name = "textBoxDescription";
         this.textBoxDescription.ReadOnly = true;
         this.textBoxDescription.Size = new System.Drawing.Size(288, 120);
         this.textBoxDescription.TabIndex = 1;
         this.textBoxDescription.Text = "";
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button1.Location = new System.Drawing.Point(215, 376);
         this.button1.Name = "button1";
         this.button1.TabIndex = 2;
         this.button1.Text = "&Close";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 232);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(100, 16);
         this.label1.TabIndex = 3;
         this.label1.Text = "Description:";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(312, 232);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(100, 16);
         this.label2.TabIndex = 4;
         this.label2.Text = "Code:";
         // 
         // textBoxCode
         // 
         this.textBoxCode.Location = new System.Drawing.Point(312, 248);
         this.textBoxCode.Name = "textBoxCode";
         this.textBoxCode.ReadOnly = true;
         this.textBoxCode.Size = new System.Drawing.Size(184, 20);
         this.textBoxCode.TabIndex = 5;
         this.textBoxCode.Text = "";
         // 
         // textBoxType
         // 
         this.textBoxType.Location = new System.Drawing.Point(312, 296);
         this.textBoxType.Name = "textBoxType";
         this.textBoxType.ReadOnly = true;
         this.textBoxType.Size = new System.Drawing.Size(184, 20);
         this.textBoxType.TabIndex = 7;
         this.textBoxType.Text = "";
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(312, 280);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(100, 16);
         this.label3.TabIndex = 6;
         this.label3.Text = "Type:";
         // 
         // textBoxUsage
         // 
         this.textBoxUsage.Location = new System.Drawing.Point(312, 344);
         this.textBoxUsage.Name = "textBoxUsage";
         this.textBoxUsage.ReadOnly = true;
         this.textBoxUsage.Size = new System.Drawing.Size(184, 20);
         this.textBoxUsage.TabIndex = 9;
         this.textBoxUsage.Text = "";
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(312, 328);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(100, 16);
         this.label4.TabIndex = 8;
         this.label4.Text = "Usage:";
         // 
         // InformationObjectDefinitionDlg
         // 
         this.AcceptButton = this.button1;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.button1;
         this.ClientSize = new System.Drawing.Size(504, 407);
         this.Controls.Add(this.textBoxUsage);
         this.Controls.Add(this.textBoxType);
         this.Controls.Add(this.textBoxCode);
         this.Controls.Add(this.textBoxDescription);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.treeViewIOD);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "InformationObjectDefinitionDlg";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Information Object Definition (IOD)";
         this.Load += new System.EventHandler(this.InformationObjectDefinitionDlg_Load);
         this.ResumeLayout(false);

      }
      #endregion

      private void InformationObjectDefinitionDlg_Load(object sender, System.EventArgs e)
      {
         FillTree();
      }

      private void FillTree( )
      {
         DicomIod iod;

         iod = DicomIodTable.Instance.GetFirst(null, false);
         if(iod == null)
         {
            return;
         }
         FillSubTree(iod, null);
      }

      private void FillSubTree(DicomIod iod, TreeNode ParentNode)
      {
         TreeNode node;
         DicomIod tempIOD;

         if(ParentNode != null)
         {
            node = ParentNode.Nodes.Add(iod.Name);
         }
         else
         {
            node = treeViewIOD.Nodes.Add(iod.Name);
         }

         node.Tag = iod;

         tempIOD = DicomIodTable.Instance.GetChild(iod);
         if(tempIOD != null)
         {
            FillSubTree(tempIOD, node);
         }

         tempIOD = DicomIodTable.Instance.GetNext(iod, true);
         if(tempIOD != null)
         {
            FillSubTree(tempIOD, ParentNode);
         }
      }

      private void treeViewIOD_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
      {
         DicomIod iod = treeViewIOD.SelectedNode.Tag as DicomIod;

         if(iod == null)
            return;

         textBoxDescription.Text = iod.Description;
         if (iod.TagCode == DemoDicomTags.Undefined)
            textBoxCode.Text = "";
         else
         {
            textBoxCode.Text = string.Format("{0:x4}:{1:x4}", Utils.GetGroup((long)iod.TagCode),
                                             Utils.GetElement((long)iod.TagCode));
         }
         textBoxUsage.Text = iod.Usage.ToString();
         textBoxType.Text = iod.Type.ToString();
      }
   }
}
