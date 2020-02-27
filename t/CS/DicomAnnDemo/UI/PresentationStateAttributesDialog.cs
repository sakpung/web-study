// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.Demos;

namespace DicomAnnDemo
{
   public partial class PresentationStateAttributesDialog : Form
   {
      private System.ComponentModel.IContainer components = null;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Label _lblCreationDate;
      private System.Windows.Forms.TextBox _tbCreationDate;
      private System.Windows.Forms.Label _lblCreationTime;
      private System.Windows.Forms.TextBox _tbCreationTime;
      private System.Windows.Forms.Label _lblInstanceNumber;
      private System.Windows.Forms.TextBox _tbInstanceNumber;
      private System.Windows.Forms.Label _lblPresentationCreator;
      private System.Windows.Forms.TextBox _tbPresentationCreator;
      private System.Windows.Forms.Label _lblPresentationDescription;
      private System.Windows.Forms.TextBox _tbPresentationDescription;
      private System.Windows.Forms.Label _lblPresentationLabel;
      private System.Windows.Forms.TextBox _tbPresentationLabel;

      private PresentationStateAttributes _presentation;
      private PresentationStateAttributes _presentationOriginal;

      public PresentationStateAttributes Presentation
      {
         get { return _presentation; }
         set { _presentation = value; }
      }

      public PresentationStateAttributesDialog()
      {
         InitializeComponent();
         _presentation = new PresentationStateAttributes();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
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
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._lblCreationDate = new System.Windows.Forms.Label();
         this._tbCreationDate = new System.Windows.Forms.TextBox();
         this._lblCreationTime = new System.Windows.Forms.Label();
         this._tbCreationTime = new System.Windows.Forms.TextBox();
         this._lblInstanceNumber = new System.Windows.Forms.Label();
         this._tbInstanceNumber = new System.Windows.Forms.TextBox();
         this._lblPresentationCreator = new System.Windows.Forms.Label();
         this._tbPresentationCreator = new System.Windows.Forms.TextBox();
         this._lblPresentationDescription = new System.Windows.Forms.Label();
         this._tbPresentationDescription = new System.Windows.Forms.TextBox();
         this._lblPresentationLabel = new System.Windows.Forms.Label();
         this._tbPresentationLabel = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(125, 228);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 0;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(253, 228);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 1;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _lblCreationDate
         // 
         this._lblCreationDate.AutoSize = true;
         this._lblCreationDate.Location = new System.Drawing.Point(24, 19);
         this._lblCreationDate.Name = "_lblCreationDate";
         this._lblCreationDate.Size = new System.Drawing.Size(75, 13);
         this._lblCreationDate.TabIndex = 2;
         this._lblCreationDate.Text = "Creation Date:";
         // 
         // _tbCreationDate
         // 
         this._tbCreationDate.Location = new System.Drawing.Point(155, 16);
         this._tbCreationDate.Name = "_tbCreationDate";
         this._tbCreationDate.ReadOnly = true;
         this._tbCreationDate.Size = new System.Drawing.Size(214, 20);
         this._tbCreationDate.TabIndex = 3;
         // 
         // _lblCreationTime
         // 
         this._lblCreationTime.AutoSize = true;
         this._lblCreationTime.Location = new System.Drawing.Point(24, 52);
         this._lblCreationTime.Name = "_lblCreationTime";
         this._lblCreationTime.Size = new System.Drawing.Size(72, 13);
         this._lblCreationTime.TabIndex = 4;
         this._lblCreationTime.Text = "CreationTime:";
         // 
         // _tbCreationTime
         // 
         this._tbCreationTime.Location = new System.Drawing.Point(155, 49);
         this._tbCreationTime.Name = "_tbCreationTime";
         this._tbCreationTime.ReadOnly = true;
         this._tbCreationTime.Size = new System.Drawing.Size(214, 20);
         this._tbCreationTime.TabIndex = 5;
         // 
         // _lblInstanceNumber
         // 
         this._lblInstanceNumber.AutoSize = true;
         this._lblInstanceNumber.Location = new System.Drawing.Point(24, 86);
         this._lblInstanceNumber.Name = "_lblInstanceNumber";
         this._lblInstanceNumber.Size = new System.Drawing.Size(91, 13);
         this._lblInstanceNumber.TabIndex = 6;
         this._lblInstanceNumber.Text = "Instance Number:";
         // 
         // _tbInstanceNumber
         // 
         this._tbInstanceNumber.Location = new System.Drawing.Point(155, 83);
         this._tbInstanceNumber.MaxLength = 10;
         this._tbInstanceNumber.Name = "_tbInstanceNumber";
         this._tbInstanceNumber.Size = new System.Drawing.Size(214, 20);
         this._tbInstanceNumber.TabIndex = 7;
         this._tbInstanceNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbInstanceNumber_KeyPress);
         // 
         // _lblPresentationCreator
         // 
         this._lblPresentationCreator.AutoSize = true;
         this._lblPresentationCreator.Location = new System.Drawing.Point(24, 120);
         this._lblPresentationCreator.Name = "_lblPresentationCreator";
         this._lblPresentationCreator.Size = new System.Drawing.Size(106, 13);
         this._lblPresentationCreator.TabIndex = 8;
         this._lblPresentationCreator.Text = "Presentation Creator:";
         // 
         // _tbPresentationCreator
         // 
         this._tbPresentationCreator.Location = new System.Drawing.Point(155, 117);
         this._tbPresentationCreator.Name = "_tbPresentationCreator";
         this._tbPresentationCreator.Size = new System.Drawing.Size(214, 20);
         this._tbPresentationCreator.TabIndex = 9;
         // 
         // _lblPresentationDescription
         // 
         this._lblPresentationDescription.AutoSize = true;
         this._lblPresentationDescription.Location = new System.Drawing.Point(24, 150);
         this._lblPresentationDescription.Name = "_lblPresentationDescription";
         this._lblPresentationDescription.Size = new System.Drawing.Size(125, 13);
         this._lblPresentationDescription.TabIndex = 10;
         this._lblPresentationDescription.Text = "Presentation Description:";
         // 
         // _tbPresentationDescription
         // 
         this._tbPresentationDescription.Location = new System.Drawing.Point(155, 147);
         this._tbPresentationDescription.Name = "_tbPresentationDescription";
         this._tbPresentationDescription.Size = new System.Drawing.Size(214, 20);
         this._tbPresentationDescription.TabIndex = 11;
         // 
         // _lblPresentationLabel
         // 
         this._lblPresentationLabel.AutoSize = true;
         this._lblPresentationLabel.Location = new System.Drawing.Point(24, 180);
         this._lblPresentationLabel.Name = "_lblPresentationLabel";
         this._lblPresentationLabel.Size = new System.Drawing.Size(98, 13);
         this._lblPresentationLabel.TabIndex = 12;
         this._lblPresentationLabel.Text = "Presentation Label:";
         // 
         // _tbPresentationLabel
         // 
         this._tbPresentationLabel.Location = new System.Drawing.Point(155, 177);
         this._tbPresentationLabel.Name = "_tbPresentationLabel";
         this._tbPresentationLabel.Size = new System.Drawing.Size(214, 20);
         this._tbPresentationLabel.TabIndex = 13;
         // 
         // PresentationStateAttributesDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(397, 275);
         this.Controls.Add(this._tbPresentationLabel);
         this.Controls.Add(this._lblPresentationLabel);
         this.Controls.Add(this._tbPresentationDescription);
         this.Controls.Add(this._lblPresentationDescription);
         this.Controls.Add(this._tbPresentationCreator);
         this.Controls.Add(this._lblPresentationCreator);
         this.Controls.Add(this._tbInstanceNumber);
         this.Controls.Add(this._lblInstanceNumber);
         this.Controls.Add(this._tbCreationTime);
         this.Controls.Add(this._lblCreationTime);
         this.Controls.Add(this._tbCreationDate);
         this.Controls.Add(this._lblCreationDate);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "PresentationStateAttributesDialog";
         this.ShowInTaskbar = false;
         this.Text = "Presentation State Module Attributes";
         this.Load += new System.EventHandler(this.PresentationStateAttributesDialog_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private void _btnOK_Click(object sender, EventArgs e)
      {
         if (CheckIfInstanceValueValid())
         {
            this.DialogResult = DialogResult.OK;
            FillPresentationStateAttributes();
         }
      }

      bool VerifyCodeString(string value)
      {
         int len = value.Length;
         for (int i = 0; i < len; i++)
         {
            bool valid =
               (
                  (value[i] >= 'A' && value[i] <= 'Z') ||
                  (value[i] >= '0' && value[i] <= '9') ||
                  (value[i] == ' ') ||
                  (value[i] == '_')
                  );
            if (!valid)
               return false;
         }
         return true;
      }

      private bool CheckIfInstanceValueValid()
      {
         if (this._tbInstanceNumber.Text.Length < 1)
            return false;

         long instanceNumber = Convert.ToInt64(this._tbInstanceNumber.Text);
         //Check if Valid
         if (instanceNumber < 0 || instanceNumber > 2147483647)
         {
            Messager.ShowError(this, "Enter an integer between 1 and 2147483647");
            return false;
         }

         string label = _tbPresentationLabel.Text;
         if (!VerifyCodeString(label))
         {
            Messager.ShowError(this, "Presentation Label can only contain:\n\nUppercase characters: 'A'-'Z'\nDigits: '0'-'9'\nBlanks (space character)\nUnderscores '_'");
            _tbPresentationLabel.SelectAll();
            _tbPresentationLabel.Focus();
            return false;
         }



         //Valid
         return true;
      }

      private void PresentationStateAttributesDialog_Load(object sender, EventArgs e)
      {
         _presentationOriginal = new PresentationStateAttributes();
         _presentationOriginal.CopyFrom(_presentation);
         FillPresentationStateAttributesControls();
      }

      private void FillPresentationStateAttributes()
      {
         _presentation.CreationDate = Convert.ToDateTime(this._tbCreationDate.Text);
         _presentation.CreationTime = Convert.ToDateTime(this._tbCreationTime.Text);
         _presentation.InstanceNumber = Convert.ToInt32(this._tbInstanceNumber.Text);
         _presentation.PresentationCreator = this._tbPresentationCreator.Text;
         _presentation.PresentationDescription = this._tbPresentationDescription.Text;
         _presentation.PresentationLabel = this._tbPresentationLabel.Text;
      }

      private void FillPresentationStateAttributesControls()
      {
         this._tbCreationDate.Text = _presentation.CreationDate.ToShortDateString();
         this._tbCreationTime.Text = _presentation.CreationTime.ToShortTimeString();
         this._tbInstanceNumber.Text = _presentation.InstanceNumber.ToString();
         this._tbPresentationCreator.Text = _presentation.PresentationCreator.ToString();
         this._tbPresentationDescription.Text = _presentation.PresentationDescription.ToString();
         this._tbPresentationLabel.Text = _presentation.PresentationLabel.ToString();
      }

      private void _tbInstanceNumber_KeyPress(object sender, KeyPressEventArgs e)
      {
         //Accept only Numbers & Backspace
         e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back);
      }
   }

   public class PresentationStateAttributes
   {
      private int _instanceNumber;
      private string _presentationLabel;
      private string _presentationDescription;
      private string _presentationCreator;
      private DateTime _creationDate;
      private DateTime _creationTime;

      public int InstanceNumber
      {
         get { return _instanceNumber; }
         set { _instanceNumber = value; }
      }

      public string PresentationLabel
      {
         get { return _presentationLabel; }
         set { _presentationLabel = value; }
      }

      public string PresentationDescription
      {
         get { return _presentationDescription; }
         set { _presentationDescription = value; }
      }

      public string PresentationCreator
      {
         get { return _presentationCreator; }
         set { _presentationCreator = value; }
      }

      public string CreationDateString
      {
         get { return _creationDate.ToShortDateString(); }
      }


      public string CreationTimeString
      {
         get { return _creationTime.ToShortTimeString(); }
      }


      internal DateTime CreationDate
      {
         get { return _creationDate; }
         set { _creationDate = value; }
      }

      internal DateTime CreationTime
      {
         get { return _creationTime; }
         set { _creationTime = value; }
      }

      public PresentationStateAttributes()
      {
         _instanceNumber = 0;
         _presentationLabel = string.Empty;
         _presentationDescription = string.Empty;
         _presentationCreator = string.Empty;
         _creationDate = DateTime.Now;
         _creationTime = DateTime.Now;
      }

      public void CopyFrom(PresentationStateAttributes src)
      {
         if (src != null)
         {
            _instanceNumber = src.InstanceNumber;
            _presentationLabel = src.PresentationLabel;
            _presentationDescription = src.PresentationDescription;
            _presentationCreator = src.PresentationCreator;
            _creationDate = src.CreationDate;
            _creationTime = src.CreationTime;
         }
      }
   }
}
