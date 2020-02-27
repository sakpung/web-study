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

namespace DicomEditorDemo
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
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.RadioButton radioButtonLE;
      private System.Windows.Forms.RadioButton radioButtonBE;
      private System.Windows.Forms.RadioButton radioButtonExplicit;
      private System.Windows.Forms.RadioButton Implicit;

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


#if (LTV16_CONFIG )
      public DicomDataSetInitializeFlags InitializeFlags
      {
         get
         {
            DicomDataSetInitializeFlags flags = DicomDataSetInitializeFlags.None;
            if (radioButtonLE.Checked)
               flags |= DicomDataSetInitializeFlags.LittleEndian;
            else if (radioButtonBE.Checked)
               flags |= DicomDataSetInitializeFlags.BigEndian;

            if (radioButtonExplicit.Checked)
               flags |= DicomDataSetInitializeFlags.ExplicitVR;
            else if (Implicit.Checked)
               flags |= DicomDataSetInitializeFlags.ImplicitVR;

            if (checkBoxAddMandatoryElementsOnly.Checked)
               flags |= DicomDataSetInitializeFlags.AddMandatoryElementsOnly;

            if (checkBoxAddMandatoryModulesOnly.Checked)
               flags |= DicomDataSetInitializeFlags.AddMandatoryModulesOnly;
            return flags;
         }
      }
#else
      public DicomDataSetInitializeFlags Flags
      {
         get
         {
            DicomDataSetInitializeFlags flags = DicomDataSetInitializeFlags.None;

            if(radioButtonLE.Checked)
            {
               if(radioButtonExplicit.Checked)
                  flags |= DicomDataSetInitializeFlags.ExplicitVR | DicomDataSetInitializeFlags.LittleEndian;
               else
                  flags |= DicomDataSetInitializeFlags.ImplicitVR | DicomDataSetInitializeFlags.LittleEndian;
            }
            else
            {
               flags |= DicomDataSetInitializeFlags.ExplicitVR | DicomDataSetInitializeFlags.BigEndian;
            }

            if (checkBoxAddMandatoryElementsOnly.Checked)
               flags |= DicomDataSetInitializeFlags.AddMandatoryElementsOnly;
            if (checkBoxAddMandatoryModulesOnly.Checked)
               flags |= DicomDataSetInitializeFlags.AddMandatoryModulesOnly;

            return flags;
         }
      }
#endif

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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDatasetDlg));
         this.label1 = new System.Windows.Forms.Label();
         this.listBoxClass = new System.Windows.Forms.ListBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.radioButtonBE = new System.Windows.Forms.RadioButton();
         this.radioButtonLE = new System.Windows.Forms.RadioButton();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.Implicit = new System.Windows.Forms.RadioButton();
         this.radioButtonExplicit = new System.Windows.Forms.RadioButton();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.checkBoxAddMandatoryModulesOnly = new System.Windows.Forms.CheckBox();
         this.checkBoxAddMandatoryElementsOnly = new System.Windows.Forms.CheckBox();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
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
         this.listBoxClass.Size = new System.Drawing.Size(344, 251);
         this.listBoxClass.TabIndex = 1;
         this.listBoxClass.DoubleClick += new System.EventHandler(this.listBoxClass_DoubleClick);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.radioButtonBE);
         this.groupBox1.Controls.Add(this.radioButtonLE);
         this.groupBox1.Location = new System.Drawing.Point(368, 32);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(189, 75);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Transfer Syntax";
         // 
         // radioButtonBE
         // 
         this.radioButtonBE.Location = new System.Drawing.Point(16, 40);
         this.radioButtonBE.Name = "radioButtonBE";
         this.radioButtonBE.Size = new System.Drawing.Size(104, 24);
         this.radioButtonBE.TabIndex = 1;
         this.radioButtonBE.Text = "Big-Endian";
         this.radioButtonBE.Click += new System.EventHandler(this.radioButtonBE_Click);
         this.radioButtonBE.CheckedChanged += new System.EventHandler(this.radioButtonBE_CheckedChanged);
         // 
         // radioButtonLE
         // 
         this.radioButtonLE.Checked = true;
         this.radioButtonLE.Location = new System.Drawing.Point(16, 16);
         this.radioButtonLE.Name = "radioButtonLE";
         this.radioButtonLE.Size = new System.Drawing.Size(104, 24);
         this.radioButtonLE.TabIndex = 0;
         this.radioButtonLE.TabStop = true;
         this.radioButtonLE.Text = "Little-Endian";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.Implicit);
         this.groupBox2.Controls.Add(this.radioButtonExplicit);
         this.groupBox2.Location = new System.Drawing.Point(368, 125);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(189, 75);
         this.groupBox2.TabIndex = 3;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Value Representation";
         // 
         // Implicit
         // 
         this.Implicit.Location = new System.Drawing.Point(16, 42);
         this.Implicit.Name = "Implicit";
         this.Implicit.Size = new System.Drawing.Size(104, 24);
         this.Implicit.TabIndex = 1;
         this.Implicit.Text = "Implicit";
         this.Implicit.Click += new System.EventHandler(this.Implicit_Click);
         // 
         // radioButtonExplicit
         // 
         this.radioButtonExplicit.Checked = true;
         this.radioButtonExplicit.Location = new System.Drawing.Point(16, 16);
         this.radioButtonExplicit.Name = "radioButtonExplicit";
         this.radioButtonExplicit.Size = new System.Drawing.Size(104, 24);
         this.radioButtonExplicit.TabIndex = 0;
         this.radioButtonExplicit.TabStop = true;
         this.radioButtonExplicit.Text = "Explicit";
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(482, 292);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 6;
         this.buttonCancel.Text = "&Cancel";
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(384, 292);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 7;
         this.buttonOK.Text = "&OK";
         // 
         // checkBoxAddMandatoryModulesOnly
         // 
         this.checkBoxAddMandatoryModulesOnly.AutoSize = true;
         this.checkBoxAddMandatoryModulesOnly.Location = new System.Drawing.Point(384, 246);
         this.checkBoxAddMandatoryModulesOnly.Name = "checkBoxAddMandatoryModulesOnly";
         this.checkBoxAddMandatoryModulesOnly.Size = new System.Drawing.Size(165, 17);
         this.checkBoxAddMandatoryModulesOnly.TabIndex = 5;
         this.checkBoxAddMandatoryModulesOnly.Text = "Add Mandatory Modules Only";
         this.checkBoxAddMandatoryModulesOnly.UseVisualStyleBackColor = true;
         // 
         // checkBoxAddMandatoryElementsOnly
         // 
         this.checkBoxAddMandatoryElementsOnly.AutoSize = true;
         this.checkBoxAddMandatoryElementsOnly.Location = new System.Drawing.Point(384, 218);
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
         this.ClientSize = new System.Drawing.Size(569, 327);
         this.Controls.Add(this.checkBoxAddMandatoryElementsOnly);
         this.Controls.Add(this.checkBoxAddMandatoryModulesOnly);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.listBoxClass);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "NewDatasetDlg";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Create New Dataset";
         this.Load += new System.EventHandler(this.NewDatasetDlg_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
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

      private void radioButtonBE_Click(object sender, System.EventArgs e)
      {
         radioButtonExplicit.Checked = true;
      }

      private void Implicit_Click(object sender, System.EventArgs e)
      {
         radioButtonLE.Checked = true;
      }

      private void radioButtonBE_CheckedChanged(object sender, EventArgs e)
      {
         Implicit.Enabled = !radioButtonBE.Checked;
      }
   }
}
