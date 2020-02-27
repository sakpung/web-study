// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.Dicom;
using Leadtools.DicomDemos;
using Leadtools.Demos;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for InsertElementDlg.
   /// </summary>
   public class InsertElementDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;
      private System.Windows.Forms.CheckBox checkBoxChild;
      private System.Windows.Forms.CheckBox checkBoxFolder;

      private DicomDataSet ds;
      private DicomElement element;
      private bool _Sequence = false;
      private bool _Child = true;
      private System.Windows.Forms.TreeView treeViewTags;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOK;
      private DicomTag _Tag;

      public bool Sequence
      {
         get
         {
            return _Sequence;
         }
      }

      public bool Child
      {
         get
         {
            return _Child;
         }
      }

      public new DicomTag Tag
      {
         get
         {
            return _Tag;
         }
      }

      public InsertElementDlg(DicomDataSet ds, DicomElement element)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         this.ds = ds;
         this.element = element;
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
         this.label1 = new System.Windows.Forms.Label();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.checkBoxChild = new System.Windows.Forms.CheckBox();
         this.checkBoxFolder = new System.Windows.Forms.CheckBox();
         this.treeViewTags = new System.Windows.Forms.TreeView();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 8);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(100, 16);
         this.label1.TabIndex = 0;
         this.label1.Text = "Tag:";
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(376, 432);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.TabIndex = 2;
         this.buttonCancel.Text = "&Cancel";
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(296, 432);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.TabIndex = 3;
         this.buttonOK.Text = "&OK";
         // 
         // checkBoxChild
         // 
         this.checkBoxChild.Checked = true;
         this.checkBoxChild.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBoxChild.Location = new System.Drawing.Point(200, 376);
         this.checkBoxChild.Name = "checkBoxChild";
         this.checkBoxChild.TabIndex = 4;
         this.checkBoxChild.Text = "Insert as child";
         this.checkBoxChild.CheckedChanged += new System.EventHandler(this.checkBoxChild_CheckedChanged);
         // 
         // checkBoxFolder
         // 
         this.checkBoxFolder.Location = new System.Drawing.Point(320, 376);
         this.checkBoxFolder.Name = "checkBoxFolder";
         this.checkBoxFolder.Size = new System.Drawing.Size(128, 24);
         this.checkBoxFolder.TabIndex = 5;
         this.checkBoxFolder.Text = "Element is a folder";
         this.checkBoxFolder.CheckedChanged += new System.EventHandler(this.checkBoxFolder_CheckedChanged);
         // 
         // treeViewTags
         // 
         this.treeViewTags.ImageIndex = -1;
         this.treeViewTags.Location = new System.Drawing.Point(8, 24);
         this.treeViewTags.Name = "treeViewTags";
         this.treeViewTags.SelectedImageIndex = -1;
         this.treeViewTags.Size = new System.Drawing.Size(456, 336);
         this.treeViewTags.TabIndex = 6;
         this.treeViewTags.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTags_AfterSelect);
         // 
         // InsertElementDlg
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(474, 463);
         this.Controls.Add(this.treeViewTags);
         this.Controls.Add(this.checkBoxFolder);
         this.Controls.Add(this.checkBoxChild);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "InsertElementDlg";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Insert Element";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.InsertElementDlg_Closing);
         this.Load += new System.EventHandler(this.InsertElementDlg_Load);
         this.ResumeLayout(false);

      }
      #endregion

      private void InsertElementDlg_Load(object sender, System.EventArgs e)
      {
         TreeNode node;
         TreeNode groupNode = null;
         int nGroup = 0xFFFF;
         DicomTag tag;

         tag = DicomTagTable.Instance.GetFirst();
         while(tag != null)
         {
            if (tag.Code != DemoDicomTags.DataSetTrailingPadding &&
               tag.Code != DemoDicomTags.ItemDelimitationItem &&
               tag.Code != DemoDicomTags.SequenceDelimitationItem)
            {
               int group = Utils.GetGroup((long)tag.Code);

               if(group != nGroup)
               {
                  nGroup = group;
                  groupNode = treeViewTags.Nodes.Add(String.Format("{0:X4}", Utils.GetGroup((long)tag.Code)));
               }

               node = groupNode.Nodes.Add(String.Format("{0:x4}:{1:x4} - {2}",
                                                        Utils.GetGroup((long)tag.Code),
                                                        Utils.GetElement((long)tag.Code), tag.Name));
               node.Tag = tag.Code;
            }
            tag = DicomTagTable.Instance.GetNext(tag);
         }
      }

      private void checkBoxChild_CheckedChanged(object sender, System.EventArgs e)
      {
         _Child = checkBoxChild.Checked;
      }

      private void checkBoxFolder_CheckedChanged(object sender, System.EventArgs e)
      {
         _Sequence = checkBoxFolder.Checked;
      }

      private void treeViewTags_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
      {
         if(treeViewTags.SelectedNode != null)
         {
            if(treeViewTags.SelectedNode.Tag != null)
            {
               long dt = (long)treeViewTags.SelectedNode.Tag;

               _Tag = DicomTagTable.Instance.Find(dt);
            }
            else
            {
               _Tag = null;
            }
         }
      }

      private void InsertElementDlg_Closing(object sender, CancelEventArgs e)
      {
         if(_Tag == null)
         {
            DialogResult = DialogResult.Cancel;
         }
         else
         {
            if(DialogResult != DialogResult.Cancel)
            {
               if(!IsStateApproved())
               {
                  e.Cancel = true;
               }
            }
         }
      }


      private bool IsStateApproved( )
      {
         if (element == null)
            return false;
         if(_Child && DicomVRType.SQ != element.VR)
         {
            if(DialogResult.No == Messager.ShowQuestion(this, "You are trying to insert an element as a child to non sequence element. Are you sure?", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo))
            {
               return false;
            }
         }


         if(!_Sequence && DicomVRType.SQ == _Tag.VR)
         {
            if(DialogResult.No == Messager.ShowQuestion(this, "You are trying to insert an sequence element as a primitive element. Are you sure?", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo))
            {
               return false;
            }
         }

         if(_Sequence && DicomVRType.SQ != _Tag.VR)
         {
            if(DialogResult.No == Messager.ShowQuestion(this, "You are trying to insert a primitive element as an sequence element. Are you sure?", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo))
            {
               return false;
            }
         }

         return true;
      }
   }
}
