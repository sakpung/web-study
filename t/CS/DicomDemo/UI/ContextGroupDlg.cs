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

namespace DicomDemo
{
   /// <summary>
   /// Summary description for ContextGroupDlg.
   /// </summary>
   public class ContextGroupDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox comboBoxID;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ColumnHeader columnHeader4;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;
      private System.Windows.Forms.ListView listViewConcepts;
      private System.Windows.Forms.TextBox textBoxType;
      private System.Windows.Forms.TextBox textBoxVersion;
      private System.Windows.Forms.TextBox textBoxName;

      public ContextGroupDlg()
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
         if (disposing)
         {
            if (components != null)
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
      private void InitializeComponent()
      {
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ContextGroupDlg));
         this.label1 = new System.Windows.Forms.Label();
         this.comboBoxID = new System.Windows.Forms.ComboBox();
         this.textBoxName = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.textBoxType = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.textBoxVersion = new System.Windows.Forms.TextBox();
         this.listViewConcepts = new System.Windows.Forms.ListView();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(24, 16);
         this.label1.TabIndex = 0;
         this.label1.Text = "Id:";
         // 
         // comboBoxID
         // 
         this.comboBoxID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxID.Location = new System.Drawing.Point(8, 32);
         this.comboBoxID.Name = "comboBoxID";
         this.comboBoxID.Size = new System.Drawing.Size(184, 21);
         this.comboBoxID.TabIndex = 1;
         this.comboBoxID.SelectedIndexChanged += new System.EventHandler(this.comboBoxID_SelectedIndexChanged);
         // 
         // textBoxName
         // 
         this.textBoxName.Location = new System.Drawing.Point(208, 32);
         this.textBoxName.Name = "textBoxName";
         this.textBoxName.ReadOnly = true;
         this.textBoxName.Size = new System.Drawing.Size(320, 20);
         this.textBoxName.TabIndex = 2;
         this.textBoxName.Text = "";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(216, 8);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(100, 16);
         this.label2.TabIndex = 3;
         this.label2.Text = "Name:";
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(8, 64);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(100, 16);
         this.label3.TabIndex = 4;
         this.label3.Text = "Type:";
         // 
         // textBoxType
         // 
         this.textBoxType.Location = new System.Drawing.Point(8, 80);
         this.textBoxType.Name = "textBoxType";
         this.textBoxType.ReadOnly = true;
         this.textBoxType.Size = new System.Drawing.Size(184, 20);
         this.textBoxType.TabIndex = 5;
         this.textBoxType.Text = "";
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(208, 64);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(100, 16);
         this.label4.TabIndex = 6;
         this.label4.Text = "Version:";
         // 
         // textBoxVersion
         // 
         this.textBoxVersion.Location = new System.Drawing.Point(208, 80);
         this.textBoxVersion.Name = "textBoxVersion";
         this.textBoxVersion.ReadOnly = true;
         this.textBoxVersion.Size = new System.Drawing.Size(320, 20);
         this.textBoxVersion.TabIndex = 7;
         this.textBoxVersion.Text = "";
         // 
         // listViewConcepts
         // 
         this.listViewConcepts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                           this.columnHeader1,
                                                                                           this.columnHeader3,
                                                                                           this.columnHeader4,
                                                                                           this.columnHeader2});
         this.listViewConcepts.FullRowSelect = true;
         this.listViewConcepts.GridLines = true;
         this.listViewConcepts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.listViewConcepts.Location = new System.Drawing.Point(8, 112);
         this.listViewConcepts.Name = "listViewConcepts";
         this.listViewConcepts.Size = new System.Drawing.Size(536, 200);
         this.listViewConcepts.TabIndex = 8;
         this.listViewConcepts.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Coding Scheme Designator";
         this.columnHeader1.Width = 150;
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "Code Value";
         this.columnHeader3.Width = 80;
         // 
         // columnHeader4
         // 
         this.columnHeader4.Text = "Code Meaning";
         this.columnHeader4.Width = 150;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Coding Scheme Version";
         this.columnHeader2.Width = 125;
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button1.Location = new System.Drawing.Point(244, 320);
         this.button1.Name = "button1";
         this.button1.TabIndex = 9;
         this.button1.Text = "&Close";
         // 
         // ContextGroupDlg
         // 
         this.AcceptButton = this.button1;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.button1;
         this.ClientSize = new System.Drawing.Size(562, 349);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.listViewConcepts);
         this.Controls.Add(this.textBoxVersion);
         this.Controls.Add(this.textBoxType);
         this.Controls.Add(this.textBoxName);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.comboBoxID);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ContextGroupDlg";
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Context Groups";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.ContextGroupDlg_Closing);
         this.Load += new System.EventHandler(this.ContextGroupDlg_Load);
         this.ResumeLayout(false);

      }
      #endregion

      private void ContextGroupDlg_Load(object sender, System.EventArgs e)
      {
         DicomContextGroup group;

         //DicomContextGroupTable.Instance.Reset();
         //DicomContextGroupTable.Instance.Load(null);

         group = DicomContextGroupTable.Instance.GetFirst();
         while (group != null)
         {
            comboBoxID.Items.Add(group.ContextIdentifier);
            group = DicomContextGroupTable.Instance.GetNext(group);
         }
         if (comboBoxID.Items.Count > 0)
            comboBoxID.SelectedIndex = 0;
      }

      private void ContextGroupDlg_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         // DicomContextGroupTable.Instance.Reset();
      }

      private void comboBoxID_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         if (comboBoxID.SelectedIndex != -1)
         {
            DicomContextGroup group;
            DicomCodedConcept concept;
            DicomContextIdentifierType cid = (DicomContextIdentifierType)comboBoxID.SelectedItem;

            group = DicomContextGroupTable.Instance.Find(cid);
            listViewConcepts.Items.Clear();

            if (group.ContextGroupVersion.GetType() == typeof(DicomDateTimeValue))
            {
               DicomDateTimeValue date = (DicomDateTimeValue)group.ContextGroupVersion;

               textBoxVersion.Text = date.Year.ToString("0000") + date.Month.ToString("00") +
                                     date.Day.ToString();
            }
            else
            {
               textBoxVersion.Text = "";
            }

            textBoxType.Text = group.IsExtensible ? "Extensible" : "Non Extensible";
            textBoxName.Text = group.Name;

            concept = DicomContextGroupTable.Instance.GetFirstCodedConcept(group);
            while (concept != null)
            {
               ListViewItem item;

               item = listViewConcepts.Items.Add(concept.CodingSchemeDesignator);
               item.SubItems.Add(concept.CodeValue);
               item.SubItems.Add(concept.CodeMeaning);
               item.SubItems.Add(concept.CodingSchemeVersion);
               concept = DicomContextGroupTable.Instance.GetNextCodedConcept(concept);
            }
         }
      }
   }
}
