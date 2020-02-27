using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms
{
   partial class PeformedProcedureStepQuery
   {
      protected override void Dispose ( bool disposing )
      {
         if ( disposing )
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }
      
      private void InitializeComponent()
      {
         this.grpPPSQuery = new System.Windows.Forms.GroupBox();
         this.grpMPPSStartDateTime = new System.Windows.Forms.GroupBox();
         this.dtpicMPPSStartDateTimeFrom = new System.Windows.Forms.DateTimePicker();
         this.dtpicMPPSStartDateTimeTo = new System.Windows.Forms.DateTimePicker();
         this.lblScheduledProcedureStepStartDate = new System.Windows.Forms.Label();
         this.lblScheduledStartDateTo = new System.Windows.Forms.Label();
         this.grpMPPSStatus = new System.Windows.Forms.GroupBox();
         this.chkStatusDiscontinued = new System.Windows.Forms.CheckBox();
         this.chkStatusCompleted = new System.Windows.Forms.CheckBox();
         this.chkStatusInProgress = new System.Windows.Forms.CheckBox();
         this.grpPPSQuery.SuspendLayout();
         this.grpMPPSStartDateTime.SuspendLayout();
         this.grpMPPSStatus.SuspendLayout();
         this.SuspendLayout();
         // 
         // grpPPSQuery
         // 
         this.grpPPSQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpPPSQuery.Controls.Add(this.grpMPPSStartDateTime);
         this.grpPPSQuery.Controls.Add(this.grpMPPSStatus);
         this.grpPPSQuery.Location = new System.Drawing.Point(7, 7);
         this.grpPPSQuery.Name = "grpPPSQuery";
         this.grpPPSQuery.Size = new System.Drawing.Size(944, 168);
         this.grpPPSQuery.TabIndex = 0;
         this.grpPPSQuery.TabStop = false;
         this.grpPPSQuery.Text = "Performed Procedure Step Query";
         // 
         // grpMPPSStartDateTime
         // 
         this.grpMPPSStartDateTime.Controls.Add(this.dtpicMPPSStartDateTimeFrom);
         this.grpMPPSStartDateTime.Controls.Add(this.dtpicMPPSStartDateTimeTo);
         this.grpMPPSStartDateTime.Controls.Add(this.lblScheduledProcedureStepStartDate);
         this.grpMPPSStartDateTime.Controls.Add(this.lblScheduledStartDateTo);
         this.grpMPPSStartDateTime.Location = new System.Drawing.Point(591, 72);
         this.grpMPPSStartDateTime.Name = "grpMPPSStartDateTime";
         this.grpMPPSStartDateTime.Size = new System.Drawing.Size(342, 86);
         this.grpMPPSStartDateTime.TabIndex = 3;
         this.grpMPPSStartDateTime.TabStop = false;
         this.grpMPPSStartDateTime.Text = "Start Date/Time";
         // 
         // dtpicMPPSStartDateTimeFrom
         // 
         this.dtpicMPPSStartDateTimeFrom.Checked = false;
         this.dtpicMPPSStartDateTimeFrom.CustomFormat = "dd/MMM/yyyy hh:mm:ss tt";
         this.dtpicMPPSStartDateTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.dtpicMPPSStartDateTimeFrom.Location = new System.Drawing.Point(43, 24);
         this.dtpicMPPSStartDateTimeFrom.MaxDate = new System.DateTime(9998, 12, 30, 0, 0, 0, 0);
         this.dtpicMPPSStartDateTimeFrom.Name = "dtpicMPPSStartDateTimeFrom";
         this.dtpicMPPSStartDateTimeFrom.ShowCheckBox = true;
         this.dtpicMPPSStartDateTimeFrom.Size = new System.Drawing.Size(205, 20);
         this.dtpicMPPSStartDateTimeFrom.TabIndex = 1;
         // 
         // dtpicMPPSStartDateTimeTo
         // 
         this.dtpicMPPSStartDateTimeTo.Checked = false;
         this.dtpicMPPSStartDateTimeTo.CustomFormat = "dd/MMM/yyyy hh:mm:ss tt";
         this.dtpicMPPSStartDateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.dtpicMPPSStartDateTimeTo.Location = new System.Drawing.Point(43, 53);
         this.dtpicMPPSStartDateTimeTo.MinDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
         this.dtpicMPPSStartDateTimeTo.Name = "dtpicMPPSStartDateTimeTo";
         this.dtpicMPPSStartDateTimeTo.ShowCheckBox = true;
         this.dtpicMPPSStartDateTimeTo.Size = new System.Drawing.Size(205, 20);
         this.dtpicMPPSStartDateTimeTo.TabIndex = 3;
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
         this.lblScheduledStartDateTo.Location = new System.Drawing.Point(8, 53);
         this.lblScheduledStartDateTo.Name = "lblScheduledStartDateTo";
         this.lblScheduledStartDateTo.Size = new System.Drawing.Size(34, 20);
         this.lblScheduledStartDateTo.TabIndex = 2;
         this.lblScheduledStartDateTo.Text = "&To:";
         this.lblScheduledStartDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // grpMPPSStatus
         // 
         this.grpMPPSStatus.Controls.Add(this.chkStatusDiscontinued);
         this.grpMPPSStatus.Controls.Add(this.chkStatusCompleted);
         this.grpMPPSStatus.Controls.Add(this.chkStatusInProgress);
         this.grpMPPSStatus.Location = new System.Drawing.Point(591, 21);
         this.grpMPPSStatus.Name = "grpMPPSStatus";
         this.grpMPPSStatus.Size = new System.Drawing.Size(344, 44);
         this.grpMPPSStatus.TabIndex = 2;
         this.grpMPPSStatus.TabStop = false;
         this.grpMPPSStatus.Text = "MPPS Status";
         // 
         // chkStatusDiscontinued
         // 
         this.chkStatusDiscontinued.Location = new System.Drawing.Point(227, 16);
         this.chkStatusDiscontinued.Name = "chkStatusDiscontinued";
         this.chkStatusDiscontinued.Size = new System.Drawing.Size(112, 24);
         this.chkStatusDiscontinued.TabIndex = 2;
         this.chkStatusDiscontinued.Tag = "DISCONTINUED";
         this.chkStatusDiscontinued.Text = "DISCONTIN&UED";
         // 
         // chkStatusCompleted
         // 
         this.chkStatusCompleted.Location = new System.Drawing.Point(125, 16);
         this.chkStatusCompleted.Name = "chkStatusCompleted";
         this.chkStatusCompleted.TabIndex = 1;
         this.chkStatusCompleted.Tag = "COMPLETED";
         this.chkStatusCompleted.Text = "C&OMPLETED";
         // 
         // chkStatusInProgress
         // 
         this.chkStatusInProgress.Location = new System.Drawing.Point(16, 16);
         this.chkStatusInProgress.Name = "chkStatusInProgress";
         this.chkStatusInProgress.Size = new System.Drawing.Size(112, 24);
         this.chkStatusInProgress.TabIndex = 0;
         this.chkStatusInProgress.Tag = "IN PROGRESS";
         this.chkStatusInProgress.Text = "&IN PROGRESS";
         // 
         // PeformedProcedureStepQuery
         // 
         this.Controls.Add(this.grpPPSQuery);
         this.Name = "PeformedProcedureStepQuery";
         this.Size = new System.Drawing.Size(960, 184);
         this.grpPPSQuery.ResumeLayout(false);
         this.grpMPPSStartDateTime.ResumeLayout(false);
         this.grpMPPSStatus.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      
      private System.ComponentModel.Container components = null ;
      private System.Windows.Forms.GroupBox grpMPPSStatus ;
      private System.Windows.Forms.Label lblScheduledProcedureStepStartDate ;
      private System.Windows.Forms.Label lblScheduledStartDateTo ;
      private System.Windows.Forms.CheckBox chkStatusInProgress ;
      private System.Windows.Forms.CheckBox chkStatusCompleted ;
      private System.Windows.Forms.CheckBox chkStatusDiscontinued ;
      private System.Windows.Forms.GroupBox grpMPPSStartDateTime ;
      private System.Windows.Forms.DateTimePicker dtpicMPPSStartDateTimeFrom ;
      private System.Windows.Forms.DateTimePicker dtpicMPPSStartDateTimeTo ;
      
      private System.Windows.Forms.GroupBox grpPPSQuery ;
      
      private InstanceUIDController ctlMPPSSOPInstanceUIDView ;
      private InstanceUIDController ctlStudySOPInstanceUIDView ;
   }
}
