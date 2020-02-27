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

namespace DicomAnonymizer
{
   /// <summary>
   /// Summary description for NewDatasetDlg.
   /// </summary>
   public class NewDatasetDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ListBox listBoxClass;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      private DicomDataSet ds;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Button buttonCancel;

      private CheckBox checkBoxAddMandatoryModulesOnly;
      private CheckBox checkBoxAddMandatoryElementsOnly;
      private Hashtable classes = new Hashtable();

      public DicomClassType Class
      {
         get
         {
            DicomIod iod = classes[listBoxClass.SelectedItem.ToString()] as DicomIod;

            return iod.ClassCode;
         }
      }


      public NewDatasetDlg(DicomDataSet ds)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();


         this.ds = ds;
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
         this.listBoxClass = new System.Windows.Forms.ListBox();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.checkBoxAddMandatoryModulesOnly = new System.Windows.Forms.CheckBox();
         this.checkBoxAddMandatoryElementsOnly = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(100, 16);
         this.label1.TabIndex = 0;
         this.label1.Text = "Class:";
         // 
         // listBoxClass
         // 
         this.listBoxClass.Location = new System.Drawing.Point(16, 32);
         this.listBoxClass.Name = "listBoxClass";
         this.listBoxClass.Size = new System.Drawing.Size(364, 186);
         this.listBoxClass.TabIndex = 1;
         this.listBoxClass.DoubleClick += new System.EventHandler(this.listBoxClass_DoubleClick);
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(482, 195);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 6;
         this.buttonCancel.Text = "&Cancel";
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(401, 195);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 7;
         this.buttonOK.Text = "&OK";
         // 
         // checkBoxAddMandatoryModulesOnly
         // 
         this.checkBoxAddMandatoryModulesOnly.AutoSize = true;
         this.checkBoxAddMandatoryModulesOnly.Location = new System.Drawing.Point(401, 32);
         this.checkBoxAddMandatoryModulesOnly.Name = "checkBoxAddMandatoryModulesOnly";
         this.checkBoxAddMandatoryModulesOnly.Size = new System.Drawing.Size(165, 17);
         this.checkBoxAddMandatoryModulesOnly.TabIndex = 5;
         this.checkBoxAddMandatoryModulesOnly.Text = "Add Mandatory Modules Only";
         this.checkBoxAddMandatoryModulesOnly.UseVisualStyleBackColor = true;
         // 
         // checkBoxAddMandatoryElementsOnly
         // 
         this.checkBoxAddMandatoryElementsOnly.AutoSize = true;
         this.checkBoxAddMandatoryElementsOnly.Location = new System.Drawing.Point(401, 55);
         this.checkBoxAddMandatoryElementsOnly.Name = "checkBoxAddMandatoryElementsOnly";
         this.checkBoxAddMandatoryElementsOnly.Size = new System.Drawing.Size(168, 17);
         this.checkBoxAddMandatoryElementsOnly.TabIndex = 4;
         this.checkBoxAddMandatoryElementsOnly.Text = "Add Mandatory Elements Only";
         this.checkBoxAddMandatoryElementsOnly.UseVisualStyleBackColor = true;
         // 
         // NewDatasetDlg
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(576, 234);
         this.Controls.Add(this.checkBoxAddMandatoryElementsOnly);
         this.Controls.Add(this.checkBoxAddMandatoryModulesOnly);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.listBoxClass);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "NewDatasetDlg";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Create New Dataset";
         this.Load += new System.EventHandler(this.NewDatasetDlg_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      private void NewDatasetDlg_Load(object sender, System.EventArgs e)
      {
         DicomIod iod;

         iod = DicomIodTable.Instance.GetFirst(null, true);
         while(iod != null)
         {
            listBoxClass.Items.Add(iod.Name);
            classes.Add(iod.Name, iod);
            iod = DicomIodTable.Instance.GetNext(iod, true);
         }
         if(listBoxClass.Items.Count > 0)
         {
            listBoxClass.SelectedIndex = 0;
         }
      }

      private void listBoxClass_DoubleClick(object sender, System.EventArgs e)
      {
         DialogResult = DialogResult.OK;
         Close();
      }      
   }
}
