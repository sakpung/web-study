using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms
{
   partial class PatientQuery
   {
   
      protected override void Dispose ( bool disposing )
      {
         if ( disposing )
         {
            if ( components != null )
            {
               components.Dispose ( ) ;
            }
         }
         base.Dispose ( disposing ) ;
      }
      private void InitializeComponent ( )
      {
         this.grpPatientQuery = new System.Windows.Forms.GroupBox();
         this.grpPatientBirthDate = new System.Windows.Forms.GroupBox();
         this.dtpicBirthDateFrom = new System.Windows.Forms.DateTimePicker();
         this.dtpicBirthDateTo = new System.Windows.Forms.DateTimePicker();
         this.lblPatientBirthDateFrom = new System.Windows.Forms.Label();
         this.lblPatientBirthDateTo = new System.Windows.Forms.Label();
         this.grpPatientQueryGeneral = new System.Windows.Forms.GroupBox();
         this.txtPatientQueryIssuerOfID = new System.Windows.Forms.TextBox();
         this.lblPatientQueryIssuerOfPatientID = new System.Windows.Forms.Label();
         this.lblPatientQueryID = new System.Windows.Forms.Label();
         this.txtPatientQueryID = new System.Windows.Forms.TextBox();
         this.grpPatientQueryName = new System.Windows.Forms.GroupBox();
         this.lblPatientQueryMiddleName = new System.Windows.Forms.Label();
         this.lblPatientQueryFirstName = new System.Windows.Forms.Label();
         this.lblPatientQueryLastName = new System.Windows.Forms.Label();
         this.txtPatientQueryMiddleName = new System.Windows.Forms.TextBox();
         this.txtPatientQueryFirstName = new System.Windows.Forms.TextBox();
         this.txtPatientQueryLastName = new System.Windows.Forms.TextBox();
         this.grpPatientQuery.SuspendLayout();
         this.grpPatientBirthDate.SuspendLayout();
         this.grpPatientQueryGeneral.SuspendLayout();
         this.grpPatientQueryName.SuspendLayout();
         this.SuspendLayout();
         // 
         // grpPatientQuery
         // 
         this.grpPatientQuery.Controls.Add(this.grpPatientBirthDate);
         this.grpPatientQuery.Controls.Add(this.grpPatientQueryGeneral);
         this.grpPatientQuery.Controls.Add(this.grpPatientQueryName);
         this.grpPatientQuery.Location = new System.Drawing.Point(7, 7);
         this.grpPatientQuery.Name = "grpPatientQuery";
         this.grpPatientQuery.Size = new System.Drawing.Size(746, 126);
         this.grpPatientQuery.TabIndex = 0;
         this.grpPatientQuery.TabStop = false;
         this.grpPatientQuery.Text = "Patient Query";
         // 
         // grpPatientBirthDate
         // 
         this.grpPatientBirthDate.Controls.Add(this.dtpicBirthDateFrom);
         this.grpPatientBirthDate.Controls.Add(this.dtpicBirthDateTo);
         this.grpPatientBirthDate.Controls.Add(this.lblPatientBirthDateFrom);
         this.grpPatientBirthDate.Controls.Add(this.lblPatientBirthDateTo);
         this.grpPatientBirthDate.Location = new System.Drawing.Point(568, 20);
         this.grpPatientBirthDate.Name = "grpPatientBirthDate";
         this.grpPatientBirthDate.Size = new System.Drawing.Size(169, 97);
         this.grpPatientBirthDate.TabIndex = 2;
         this.grpPatientBirthDate.TabStop = false;
         this.grpPatientBirthDate.Text = "Birth Date";
         // 
         // dtpicBirthDateFrom
         // 
         this.dtpicBirthDateFrom.Checked = false;
         this.dtpicBirthDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dtpicBirthDateFrom.Location = new System.Drawing.Point(44, 26);
         this.dtpicBirthDateFrom.Name = "dtpicBirthDateFrom";
         this.dtpicBirthDateFrom.ShowCheckBox = true;
         this.dtpicBirthDateFrom.Size = new System.Drawing.Size(115, 20);
         this.dtpicBirthDateFrom.TabIndex = 1;
         // 
         // dtpicBirthDateTo
         // 
         this.dtpicBirthDateTo.Checked = false;
         this.dtpicBirthDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dtpicBirthDateTo.Location = new System.Drawing.Point(44, 60);
         this.dtpicBirthDateTo.Name = "dtpicBirthDateTo";
         this.dtpicBirthDateTo.ShowCheckBox = true;
         this.dtpicBirthDateTo.Size = new System.Drawing.Size(115, 20);
         this.dtpicBirthDateTo.TabIndex = 3;
         // 
         // lblPatientBirthDateFrom
         // 
         this.lblPatientBirthDateFrom.Location = new System.Drawing.Point(8, 26);
         this.lblPatientBirthDateFrom.Name = "lblPatientBirthDateFrom";
         this.lblPatientBirthDateFrom.Size = new System.Drawing.Size(40, 20);
         this.lblPatientBirthDateFrom.TabIndex = 0;
         this.lblPatientBirthDateFrom.Text = "&From:";
         this.lblPatientBirthDateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblPatientBirthDateTo
         // 
         this.lblPatientBirthDateTo.Location = new System.Drawing.Point(8, 60);
         this.lblPatientBirthDateTo.Name = "lblPatientBirthDateTo";
         this.lblPatientBirthDateTo.Size = new System.Drawing.Size(21, 20);
         this.lblPatientBirthDateTo.TabIndex = 2;
         this.lblPatientBirthDateTo.Text = "&To:";
         this.lblPatientBirthDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // grpPatientQueryGeneral
         // 
         this.grpPatientQueryGeneral.Controls.Add(this.txtPatientQueryIssuerOfID);
         this.grpPatientQueryGeneral.Controls.Add(this.lblPatientQueryIssuerOfPatientID);
         this.grpPatientQueryGeneral.Controls.Add(this.lblPatientQueryID);
         this.grpPatientQueryGeneral.Controls.Add(this.txtPatientQueryID);
         this.grpPatientQueryGeneral.Location = new System.Drawing.Point(8, 20);
         this.grpPatientQueryGeneral.Name = "grpPatientQueryGeneral";
         this.grpPatientQueryGeneral.Size = new System.Drawing.Size(304, 97);
         this.grpPatientQueryGeneral.TabIndex = 0;
         this.grpPatientQueryGeneral.TabStop = false;
         this.grpPatientQueryGeneral.Text = "General";
         // 
         // txtPatientQueryIssuerOfID
         // 
         this.txtPatientQueryIssuerOfID.Location = new System.Drawing.Point(112, 60);
         this.txtPatientQueryIssuerOfID.Name = "txtPatientQueryIssuerOfID";
         this.txtPatientQueryIssuerOfID.Size = new System.Drawing.Size(181, 20);
         this.txtPatientQueryIssuerOfID.TabIndex = 3;
         this.txtPatientQueryIssuerOfID.Text = "";
         // 
         // lblPatientQueryIssuerOfPatientID
         // 
         this.lblPatientQueryIssuerOfPatientID.Location = new System.Drawing.Point(10, 60);
         this.lblPatientQueryIssuerOfPatientID.Name = "lblPatientQueryIssuerOfPatientID";
         this.lblPatientQueryIssuerOfPatientID.Size = new System.Drawing.Size(102, 20);
         this.lblPatientQueryIssuerOfPatientID.TabIndex = 2;
         this.lblPatientQueryIssuerOfPatientID.Text = "&Issuer of patient ID:";
         this.lblPatientQueryIssuerOfPatientID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblPatientQueryID
         // 
         this.lblPatientQueryID.Location = new System.Drawing.Point(10, 26);
         this.lblPatientQueryID.Name = "lblPatientQueryID";
         this.lblPatientQueryID.Size = new System.Drawing.Size(57, 23);
         this.lblPatientQueryID.TabIndex = 0;
         this.lblPatientQueryID.Text = "&Patient ID:";
         this.lblPatientQueryID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // txtPatientQueryID
         // 
         this.txtPatientQueryID.Location = new System.Drawing.Point(112, 26);
         this.txtPatientQueryID.Name = "txtPatientQueryID";
         this.txtPatientQueryID.Size = new System.Drawing.Size(181, 20);
         this.txtPatientQueryID.TabIndex = 1;
         this.txtPatientQueryID.Text = "";
         // 
         // grpPatientQueryName
         // 
         this.grpPatientQueryName.Controls.Add(this.lblPatientQueryMiddleName);
         this.grpPatientQueryName.Controls.Add(this.lblPatientQueryFirstName);
         this.grpPatientQueryName.Controls.Add(this.lblPatientQueryLastName);
         this.grpPatientQueryName.Controls.Add(this.txtPatientQueryMiddleName);
         this.grpPatientQueryName.Controls.Add(this.txtPatientQueryFirstName);
         this.grpPatientQueryName.Controls.Add(this.txtPatientQueryLastName);
         this.grpPatientQueryName.Location = new System.Drawing.Point(319, 20);
         this.grpPatientQueryName.Name = "grpPatientQueryName";
         this.grpPatientQueryName.Size = new System.Drawing.Size(242, 97);
         this.grpPatientQueryName.TabIndex = 1;
         this.grpPatientQueryName.TabStop = false;
         this.grpPatientQueryName.Text = "Name";
         // 
         // lblPatientQueryMiddleName
         // 
         this.lblPatientQueryMiddleName.Location = new System.Drawing.Point(9, 45);
         this.lblPatientQueryMiddleName.Name = "lblPatientQueryMiddleName";
         this.lblPatientQueryMiddleName.Size = new System.Drawing.Size(41, 20);
         this.lblPatientQueryMiddleName.TabIndex = 2;
         this.lblPatientQueryMiddleName.Text = "M&iddle:";
         this.lblPatientQueryMiddleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblPatientQueryFirstName
         // 
         this.lblPatientQueryFirstName.Location = new System.Drawing.Point(9, 21);
         this.lblPatientQueryFirstName.Name = "lblPatientQueryFirstName";
         this.lblPatientQueryFirstName.Size = new System.Drawing.Size(29, 20);
         this.lblPatientQueryFirstName.TabIndex = 0;
         this.lblPatientQueryFirstName.Text = "Firs&t:";
         this.lblPatientQueryFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblPatientQueryLastName
         // 
         this.lblPatientQueryLastName.Location = new System.Drawing.Point(9, 69);
         this.lblPatientQueryLastName.Name = "lblPatientQueryLastName";
         this.lblPatientQueryLastName.Size = new System.Drawing.Size(31, 20);
         this.lblPatientQueryLastName.TabIndex = 4;
         this.lblPatientQueryLastName.Text = "&Last:";
         this.lblPatientQueryLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // txtPatientQueryMiddleName
         // 
         this.txtPatientQueryMiddleName.Location = new System.Drawing.Point(52, 45);
         this.txtPatientQueryMiddleName.Name = "txtPatientQueryMiddleName";
         this.txtPatientQueryMiddleName.Size = new System.Drawing.Size(174, 20);
         this.txtPatientQueryMiddleName.TabIndex = 3;
         this.txtPatientQueryMiddleName.Text = "";
         // 
         // txtPatientQueryFirstName
         // 
         this.txtPatientQueryFirstName.Location = new System.Drawing.Point(52, 21);
         this.txtPatientQueryFirstName.Name = "txtPatientQueryFirstName";
         this.txtPatientQueryFirstName.Size = new System.Drawing.Size(174, 20);
         this.txtPatientQueryFirstName.TabIndex = 1;
         this.txtPatientQueryFirstName.Text = "";
         // 
         // txtPatientQueryLastName
         // 
         this.txtPatientQueryLastName.Location = new System.Drawing.Point(52, 69);
         this.txtPatientQueryLastName.Name = "txtPatientQueryLastName";
         this.txtPatientQueryLastName.Size = new System.Drawing.Size(174, 20);
         this.txtPatientQueryLastName.TabIndex = 5;
         this.txtPatientQueryLastName.Text = "";
         // 
         // PatientQuery
         // 
         this.Controls.Add(this.grpPatientQuery);
         this.Name = "PatientQuery";
         this.Size = new System.Drawing.Size(760, 141);
         this.grpPatientQuery.ResumeLayout(false);
         this.grpPatientBirthDate.ResumeLayout(false);
         this.grpPatientQueryGeneral.ResumeLayout(false);
         this.grpPatientQueryName.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      
      private System.ComponentModel.Container components = null ;
      private System.Windows.Forms.GroupBox grpPatientQuery;
      private System.Windows.Forms.Label lblPatientQueryMiddleName;
      private System.Windows.Forms.Label lblPatientQueryFirstName;
      private System.Windows.Forms.Label lblPatientQueryIssuerOfPatientID;
      private System.Windows.Forms.Label lblPatientQueryID;
      private System.Windows.Forms.Label lblPatientQueryLastName;
      private System.Windows.Forms.TextBox txtPatientQueryID;
      private System.Windows.Forms.TextBox txtPatientQueryIssuerOfID;
      private System.Windows.Forms.TextBox txtPatientQueryFirstName;
      private System.Windows.Forms.TextBox txtPatientQueryMiddleName;
      private System.Windows.Forms.TextBox txtPatientQueryLastName;
      private System.Windows.Forms.GroupBox grpPatientBirthDate;
      private System.Windows.Forms.Label lblPatientBirthDateFrom;
      private System.Windows.Forms.Label lblPatientBirthDateTo;
      private System.Windows.Forms.GroupBox grpPatientQueryName;
      private System.Windows.Forms.DateTimePicker dtpicBirthDateFrom;
      private System.Windows.Forms.DateTimePicker dtpicBirthDateTo;
      private System.Windows.Forms.GroupBox grpPatientQueryGeneral;
   }
}
