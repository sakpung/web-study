using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Winforms.Control ;

namespace Leadtools.Medical.Winforms
{
   partial class ScheduledProcedureStepQuery
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
         base.Dispose ( disposing );
      }
      
      private void InitializeComponent ( )
      {
         this.grbScheduledProcedureStepQuery = new System.Windows.Forms.GroupBox();
         this.grpScheduledProcedureStepQueryGeneral = new System.Windows.Forms.GroupBox();
         this.ctlcmbScheduledProcedureStepModality = new Leadtools.Medical.Winforms.Control.CheckedComboBox();
         this.txtScheduledProcedureStepStationAETitle = new System.Windows.Forms.TextBox();
         this.lblScheduledProcedureStepID = new System.Windows.Forms.Label();
         this.lblScheduledProcedureStepStationAE = new System.Windows.Forms.Label();
         this.txtScheduledProcedureStepID = new System.Windows.Forms.TextBox();
         this.lblScheduledProcedureStepModality = new System.Windows.Forms.Label();
         this.grpScheduledProcedureStepQueryStartDateTime = new System.Windows.Forms.GroupBox();
         this.dtpicScheduledProcedureStepStartDateTimeFrom = new System.Windows.Forms.DateTimePicker();
         this.dtpicScheduledProcedureStepStartDateTimeTo = new System.Windows.Forms.DateTimePicker();
         this.lblScheduledProcedureStepStartDate = new System.Windows.Forms.Label();
         this.lblScheduledStartDateTo = new System.Windows.Forms.Label();
         this.grpScheduledProcedureStepQueryPerformainPhysicianName = new System.Windows.Forms.GroupBox();
         this.txtScheduledPerformingPhysicianMiddleName = new System.Windows.Forms.TextBox();
         this.lblScheduledPerformingPhysicianMiddleName = new System.Windows.Forms.Label();
         this.lblScheduledPerformingPhysicianLastName = new System.Windows.Forms.Label();
         this.txtScheduledPerformingPhysicianFirstName = new System.Windows.Forms.TextBox();
         this.lblScheduledPerformingPhysicianFirstName = new System.Windows.Forms.Label();
         this.txtScheduledPerformingPhysicianLastName = new System.Windows.Forms.TextBox();
         this.grbScheduledProcedureStepQuery.SuspendLayout();
         this.grpScheduledProcedureStepQueryGeneral.SuspendLayout();
         this.grpScheduledProcedureStepQueryStartDateTime.SuspendLayout();
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.SuspendLayout();
         this.SuspendLayout();
         // 
         // grbScheduledProcedureStepQuery
         // 
         this.grbScheduledProcedureStepQuery.Controls.Add(this.grpScheduledProcedureStepQueryGeneral);
         this.grbScheduledProcedureStepQuery.Controls.Add(this.grpScheduledProcedureStepQueryStartDateTime);
         this.grbScheduledProcedureStepQuery.Controls.Add(this.grpScheduledProcedureStepQueryPerformainPhysicianName);
         this.grbScheduledProcedureStepQuery.Location = new System.Drawing.Point(7, 7);
         this.grbScheduledProcedureStepQuery.Name = "grbScheduledProcedureStepQuery";
         this.grbScheduledProcedureStepQuery.Size = new System.Drawing.Size(742, 177);
         this.grbScheduledProcedureStepQuery.TabIndex = 0;
         this.grbScheduledProcedureStepQuery.TabStop = false;
         this.grbScheduledProcedureStepQuery.Text = "Scheduled Procedure Step Query";
         // 
         // grpScheduledProcedureStepQueryGeneral
         // 
         this.grpScheduledProcedureStepQueryGeneral.Controls.Add(this.ctlcmbScheduledProcedureStepModality);
         this.grpScheduledProcedureStepQueryGeneral.Controls.Add(this.txtScheduledProcedureStepStationAETitle);
         this.grpScheduledProcedureStepQueryGeneral.Controls.Add(this.lblScheduledProcedureStepID);
         this.grpScheduledProcedureStepQueryGeneral.Controls.Add(this.lblScheduledProcedureStepStationAE);
         this.grpScheduledProcedureStepQueryGeneral.Controls.Add(this.txtScheduledProcedureStepID);
         this.grpScheduledProcedureStepQueryGeneral.Controls.Add(this.lblScheduledProcedureStepModality);
         this.grpScheduledProcedureStepQueryGeneral.Location = new System.Drawing.Point(8, 21);
         this.grpScheduledProcedureStepQueryGeneral.Name = "grpScheduledProcedureStepQueryGeneral";
         this.grpScheduledProcedureStepQueryGeneral.Size = new System.Drawing.Size(461, 83);
         this.grpScheduledProcedureStepQueryGeneral.TabIndex = 0;
         this.grpScheduledProcedureStepQueryGeneral.TabStop = false;
         this.grpScheduledProcedureStepQueryGeneral.Text = "General";
         // 
         // ctlcmbScheduledProcedureStepModality
         // 
         this.ctlcmbScheduledProcedureStepModality.ColumnDelimeter = '\0';
         this.ctlcmbScheduledProcedureStepModality.DisplayView = Leadtools.Medical.Winforms.Control.CheckedComboBox.View.Columns;
         this.ctlcmbScheduledProcedureStepModality.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
         this.ctlcmbScheduledProcedureStepModality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.ctlcmbScheduledProcedureStepModality.FormattingEnabled = true;
         this.ctlcmbScheduledProcedureStepModality.Location = new System.Drawing.Point(60, 55);
         this.ctlcmbScheduledProcedureStepModality.Name = "ctlcmbScheduledProcedureStepModality";
         this.ctlcmbScheduledProcedureStepModality.Size = new System.Drawing.Size(390, 21);
         this.ctlcmbScheduledProcedureStepModality.TabIndex = 5;
         // 
         // txtScheduledProcedureStepStationAETitle
         // 
         this.txtScheduledProcedureStepStationAETitle.Location = new System.Drawing.Point(306, 20);
         this.txtScheduledProcedureStepStationAETitle.Name = "txtScheduledProcedureStepStationAETitle";
         this.txtScheduledProcedureStepStationAETitle.Size = new System.Drawing.Size(144, 20);
         this.txtScheduledProcedureStepStationAETitle.TabIndex = 3;
         // 
         // lblScheduledProcedureStepID
         // 
         this.lblScheduledProcedureStepID.Location = new System.Drawing.Point(9, 20);
         this.lblScheduledProcedureStepID.Name = "lblScheduledProcedureStepID";
         this.lblScheduledProcedureStepID.Size = new System.Drawing.Size(47, 23);
         this.lblScheduledProcedureStepID.TabIndex = 0;
         this.lblScheduledProcedureStepID.Text = "&Step ID:";
         this.lblScheduledProcedureStepID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblScheduledProcedureStepStationAE
         // 
         this.lblScheduledProcedureStepStationAE.Location = new System.Drawing.Point(213, 20);
         this.lblScheduledProcedureStepStationAE.Name = "lblScheduledProcedureStepStationAE";
         this.lblScheduledProcedureStepStationAE.Size = new System.Drawing.Size(87, 23);
         this.lblScheduledProcedureStepStationAE.TabIndex = 2;
         this.lblScheduledProcedureStepStationAE.Text = "Stati&on AE Title:";
         this.lblScheduledProcedureStepStationAE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // txtScheduledProcedureStepID
         // 
         this.txtScheduledProcedureStepID.Location = new System.Drawing.Point(60, 20);
         this.txtScheduledProcedureStepID.Name = "txtScheduledProcedureStepID";
         this.txtScheduledProcedureStepID.Size = new System.Drawing.Size(144, 20);
         this.txtScheduledProcedureStepID.TabIndex = 1;
         // 
         // lblScheduledProcedureStepModality
         // 
         this.lblScheduledProcedureStepModality.Location = new System.Drawing.Point(9, 54);
         this.lblScheduledProcedureStepModality.Name = "lblScheduledProcedureStepModality";
         this.lblScheduledProcedureStepModality.Size = new System.Drawing.Size(55, 23);
         this.lblScheduledProcedureStepModality.TabIndex = 4;
         this.lblScheduledProcedureStepModality.Text = "&Modality:";
         this.lblScheduledProcedureStepModality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // grpScheduledProcedureStepQueryStartDateTime
         // 
         this.grpScheduledProcedureStepQueryStartDateTime.Controls.Add(this.dtpicScheduledProcedureStepStartDateTimeFrom);
         this.grpScheduledProcedureStepQueryStartDateTime.Controls.Add(this.dtpicScheduledProcedureStepStartDateTimeTo);
         this.grpScheduledProcedureStepQueryStartDateTime.Controls.Add(this.lblScheduledProcedureStepStartDate);
         this.grpScheduledProcedureStepQueryStartDateTime.Controls.Add(this.lblScheduledStartDateTo);
         this.grpScheduledProcedureStepQueryStartDateTime.Location = new System.Drawing.Point(8, 112);
         this.grpScheduledProcedureStepQueryStartDateTime.Name = "grpScheduledProcedureStepQueryStartDateTime";
         this.grpScheduledProcedureStepQueryStartDateTime.Size = new System.Drawing.Size(448, 56);
         this.grpScheduledProcedureStepQueryStartDateTime.TabIndex = 1;
         this.grpScheduledProcedureStepQueryStartDateTime.TabStop = false;
         this.grpScheduledProcedureStepQueryStartDateTime.Text = "Start Date/Time";
         // 
         // dtpicScheduledProcedureStepStartDateTimeFrom
         // 
         this.dtpicScheduledProcedureStepStartDateTimeFrom.Checked = false;
         this.dtpicScheduledProcedureStepStartDateTimeFrom.CustomFormat = "dd/MMM/yyyy hh:mm:ss tt";
         this.dtpicScheduledProcedureStepStartDateTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.dtpicScheduledProcedureStepStartDateTimeFrom.Location = new System.Drawing.Point(43, 24);
         this.dtpicScheduledProcedureStepStartDateTimeFrom.MaxDate = new System.DateTime(9998, 12, 30, 0, 0, 0, 0);
         this.dtpicScheduledProcedureStepStartDateTimeFrom.Name = "dtpicScheduledProcedureStepStartDateTimeFrom";
         this.dtpicScheduledProcedureStepStartDateTimeFrom.ShowCheckBox = true;
         this.dtpicScheduledProcedureStepStartDateTimeFrom.Size = new System.Drawing.Size(176, 20);
         this.dtpicScheduledProcedureStepStartDateTimeFrom.TabIndex = 1;
         // 
         // dtpicScheduledProcedureStepStartDateTimeTo
         // 
         this.dtpicScheduledProcedureStepStartDateTimeTo.Checked = false;
         this.dtpicScheduledProcedureStepStartDateTimeTo.CustomFormat = "dd/MMM/yyyy hh:mm:ss tt";
         this.dtpicScheduledProcedureStepStartDateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.dtpicScheduledProcedureStepStartDateTimeTo.Location = new System.Drawing.Point(264, 24);
         this.dtpicScheduledProcedureStepStartDateTimeTo.MinDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
         this.dtpicScheduledProcedureStepStartDateTimeTo.Name = "dtpicScheduledProcedureStepStartDateTimeTo";
         this.dtpicScheduledProcedureStepStartDateTimeTo.ShowCheckBox = true;
         this.dtpicScheduledProcedureStepStartDateTimeTo.Size = new System.Drawing.Size(176, 20);
         this.dtpicScheduledProcedureStepStartDateTimeTo.TabIndex = 3;
         // 
         // lblScheduledProcedureStepStartDate
         // 
         this.lblScheduledProcedureStepStartDate.Location = new System.Drawing.Point(8, 24);
         this.lblScheduledProcedureStepStartDate.Name = "lblScheduledProcedureStepStartDate";
         this.lblScheduledProcedureStepStartDate.Size = new System.Drawing.Size(34, 20);
         this.lblScheduledProcedureStepStartDate.TabIndex = 0;
         this.lblScheduledProcedureStepStartDate.Text = "&From:";
         this.lblScheduledProcedureStepStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblScheduledStartDateTo
         // 
         this.lblScheduledStartDateTo.Location = new System.Drawing.Point(224, 24);
         this.lblScheduledStartDateTo.Name = "lblScheduledStartDateTo";
         this.lblScheduledStartDateTo.Size = new System.Drawing.Size(34, 20);
         this.lblScheduledStartDateTo.TabIndex = 2;
         this.lblScheduledStartDateTo.Text = "&To:";
         this.lblScheduledStartDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // grpScheduledProcedureStepQueryPerformainPhysicianName
         // 
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.Controls.Add(this.txtScheduledPerformingPhysicianMiddleName);
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.Controls.Add(this.lblScheduledPerformingPhysicianMiddleName);
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.Controls.Add(this.lblScheduledPerformingPhysicianLastName);
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.Controls.Add(this.txtScheduledPerformingPhysicianFirstName);
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.Controls.Add(this.lblScheduledPerformingPhysicianFirstName);
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.Controls.Add(this.txtScheduledPerformingPhysicianLastName);
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.Location = new System.Drawing.Point(476, 24);
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.Name = "grpScheduledProcedureStepQueryPerformainPhysicianName";
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.Size = new System.Drawing.Size(256, 144);
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.TabIndex = 2;
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.TabStop = false;
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.Text = "Performing Physician Name";
         // 
         // txtScheduledPerformingPhysicianMiddleName
         // 
         this.txtScheduledPerformingPhysicianMiddleName.Location = new System.Drawing.Point(53, 62);
         this.txtScheduledPerformingPhysicianMiddleName.Name = "txtScheduledPerformingPhysicianMiddleName";
         this.txtScheduledPerformingPhysicianMiddleName.Size = new System.Drawing.Size(195, 20);
         this.txtScheduledPerformingPhysicianMiddleName.TabIndex = 3;
         // 
         // lblScheduledPerformingPhysicianMiddleName
         // 
         this.lblScheduledPerformingPhysicianMiddleName.Location = new System.Drawing.Point(10, 62);
         this.lblScheduledPerformingPhysicianMiddleName.Name = "lblScheduledPerformingPhysicianMiddleName";
         this.lblScheduledPerformingPhysicianMiddleName.Size = new System.Drawing.Size(48, 20);
         this.lblScheduledPerformingPhysicianMiddleName.TabIndex = 2;
         this.lblScheduledPerformingPhysicianMiddleName.Text = "M&iddle:";
         this.lblScheduledPerformingPhysicianMiddleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblScheduledPerformingPhysicianLastName
         // 
         this.lblScheduledPerformingPhysicianLastName.Location = new System.Drawing.Point(10, 104);
         this.lblScheduledPerformingPhysicianLastName.Name = "lblScheduledPerformingPhysicianLastName";
         this.lblScheduledPerformingPhysicianLastName.Size = new System.Drawing.Size(32, 20);
         this.lblScheduledPerformingPhysicianLastName.TabIndex = 4;
         this.lblScheduledPerformingPhysicianLastName.Text = "&Last:";
         this.lblScheduledPerformingPhysicianLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // txtScheduledPerformingPhysicianFirstName
         // 
         this.txtScheduledPerformingPhysicianFirstName.Location = new System.Drawing.Point(53, 20);
         this.txtScheduledPerformingPhysicianFirstName.Name = "txtScheduledPerformingPhysicianFirstName";
         this.txtScheduledPerformingPhysicianFirstName.Size = new System.Drawing.Size(195, 20);
         this.txtScheduledPerformingPhysicianFirstName.TabIndex = 1;
         // 
         // lblScheduledPerformingPhysicianFirstName
         // 
         this.lblScheduledPerformingPhysicianFirstName.Location = new System.Drawing.Point(10, 20);
         this.lblScheduledPerformingPhysicianFirstName.Name = "lblScheduledPerformingPhysicianFirstName";
         this.lblScheduledPerformingPhysicianFirstName.Size = new System.Drawing.Size(32, 20);
         this.lblScheduledPerformingPhysicianFirstName.TabIndex = 0;
         this.lblScheduledPerformingPhysicianFirstName.Text = "Fris&t:";
         this.lblScheduledPerformingPhysicianFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // txtScheduledPerformingPhysicianLastName
         // 
         this.txtScheduledPerformingPhysicianLastName.Location = new System.Drawing.Point(53, 104);
         this.txtScheduledPerformingPhysicianLastName.Name = "txtScheduledPerformingPhysicianLastName";
         this.txtScheduledPerformingPhysicianLastName.Size = new System.Drawing.Size(195, 20);
         this.txtScheduledPerformingPhysicianLastName.TabIndex = 5;
         // 
         // ScheduledProcedureStepQuery
         // 
         this.Controls.Add(this.grbScheduledProcedureStepQuery);
         this.Name = "ScheduledProcedureStepQuery";
         this.Size = new System.Drawing.Size(760, 191);
         this.grbScheduledProcedureStepQuery.ResumeLayout(false);
         this.grpScheduledProcedureStepQueryGeneral.ResumeLayout(false);
         this.grpScheduledProcedureStepQueryGeneral.PerformLayout();
         this.grpScheduledProcedureStepQueryStartDateTime.ResumeLayout(false);
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.ResumeLayout(false);
         this.grpScheduledProcedureStepQueryPerformainPhysicianName.PerformLayout();
         this.ResumeLayout(false);

      }
      
      private System.ComponentModel.Container components = null ;
      private System.Windows.Forms.Label lblScheduledProcedureStepID ;
      private System.Windows.Forms.TextBox txtScheduledProcedureStepID ;
      private System.Windows.Forms.GroupBox grbScheduledProcedureStepQuery ;
      private System.Windows.Forms.Label lblScheduledProcedureStepModality ;
      private System.Windows.Forms.Label lblScheduledProcedureStepStationAE ;
      private System.Windows.Forms.Label lblScheduledProcedureStepStartDate ;
      private System.Windows.Forms.TextBox txtScheduledProcedureStepStationAETitle ;
      private System.Windows.Forms.Label lblScheduledPerformingPhysicianFirstName ;
      private System.Windows.Forms.TextBox txtScheduledPerformingPhysicianMiddleName ;
      private System.Windows.Forms.TextBox txtScheduledPerformingPhysicianLastName ;
      private System.Windows.Forms.TextBox txtScheduledPerformingPhysicianFirstName ; 
      private System.Windows.Forms.Label lblScheduledPerformingPhysicianMiddleName ;
      private System.Windows.Forms.GroupBox grpScheduledProcedureStepQueryGeneral ;
      private System.Windows.Forms.GroupBox grpScheduledProcedureStepQueryStartDateTime ;
      private System.Windows.Forms.GroupBox grpScheduledProcedureStepQueryPerformainPhysicianName ;
      private System.Windows.Forms.Label lblScheduledStartDateTo;
      private System.Windows.Forms.DateTimePicker dtpicScheduledProcedureStepStartDateTimeFrom;
      private System.Windows.Forms.DateTimePicker dtpicScheduledProcedureStepStartDateTimeTo;
      //private CheckedComboBox ctlcmbScheduledProcedureStepModality ;
      private System.Windows.Forms.Label lblScheduledPerformingPhysicianLastName ;
      private CheckedComboBox ctlcmbScheduledProcedureStepModality;
   }
}
