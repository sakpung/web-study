using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms
{
   partial class RequestedProcedureQuery
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
         this.grpRequestedProcedure = new System.Windows.Forms.GroupBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.chkLow = new System.Windows.Forms.CheckBox();
         this.chkHight = new System.Windows.Forms.CheckBox();
         this.chkMedium = new System.Windows.Forms.CheckBox();
         this.chkRoutine = new System.Windows.Forms.CheckBox();
         this.chkStat = new System.Windows.Forms.CheckBox();
         this.txtStudyInstanceUID = new System.Windows.Forms.TextBox();
         this.txtRequestedProcedureID = new System.Windows.Forms.TextBox();
         this.lblStudyInstanceUID = new System.Windows.Forms.Label();
         this.lblRequestedProcedureID = new System.Windows.Forms.Label();
         this.grpRequestedProcedure.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // grpRequestedProcedure
         // 
         this.grpRequestedProcedure.Controls.Add(this.groupBox1);
         this.grpRequestedProcedure.Controls.Add(this.txtStudyInstanceUID);
         this.grpRequestedProcedure.Controls.Add(this.txtRequestedProcedureID);
         this.grpRequestedProcedure.Controls.Add(this.lblStudyInstanceUID);
         this.grpRequestedProcedure.Controls.Add(this.lblRequestedProcedureID);
         this.grpRequestedProcedure.Location = new System.Drawing.Point(7, 7);
         this.grpRequestedProcedure.Name = "grpRequestedProcedure";
         this.grpRequestedProcedure.Size = new System.Drawing.Size(511, 99);
         this.grpRequestedProcedure.TabIndex = 0;
         this.grpRequestedProcedure.TabStop = false;
         this.grpRequestedProcedure.Text = "Requested Procedure Query";
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.chkLow);
         this.groupBox1.Controls.Add(this.chkHight);
         this.groupBox1.Controls.Add(this.chkMedium);
         this.groupBox1.Controls.Add(this.chkRoutine);
         this.groupBox1.Controls.Add(this.chkStat);
         this.groupBox1.Location = new System.Drawing.Point(289, 14);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(213, 76);
         this.groupBox1.TabIndex = 4;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Requested &Procedure Priority:";
         // 
         // chkLow
         // 
         this.chkLow.Location = new System.Drawing.Point(150, 22);
         this.chkLow.Name = "chkLow";
         this.chkLow.Size = new System.Drawing.Size(57, 24);
         this.chkLow.TabIndex = 2;
         this.chkLow.Tag = "LOW";
         this.chkLow.Text = "&LOW";
         // 
         // chkHight
         // 
         this.chkHight.Location = new System.Drawing.Point(9, 48);
         this.chkHight.Name = "chkHight";
         this.chkHight.Size = new System.Drawing.Size(51, 24);
         this.chkHight.TabIndex = 3;
         this.chkHight.Tag = "HIGH";
         this.chkHight.Text = "&HIGH";
         // 
         // chkMedium
         // 
         this.chkMedium.Location = new System.Drawing.Point(69, 48);
         this.chkMedium.Name = "chkMedium";
         this.chkMedium.Size = new System.Drawing.Size(80, 24);
         this.chkMedium.TabIndex = 4;
         this.chkMedium.Tag = "MEDIUM";
         this.chkMedium.Text = "&MEDIUM";
         // 
         // chkRoutine
         // 
         this.chkRoutine.Location = new System.Drawing.Point(69, 22);
         this.chkRoutine.Name = "chkRoutine";
         this.chkRoutine.Size = new System.Drawing.Size(74, 24);
         this.chkRoutine.TabIndex = 1;
         this.chkRoutine.Tag = "ROUTINE";
         this.chkRoutine.Text = "R&OUTINE";
         // 
         // chkStat
         // 
         this.chkStat.Location = new System.Drawing.Point(9, 22);
         this.chkStat.Name = "chkStat";
         this.chkStat.Size = new System.Drawing.Size(53, 24);
         this.chkStat.TabIndex = 0;
         this.chkStat.Tag = "STAT";
         this.chkStat.Text = "S&TAT";
         // 
         // txtStudyInstanceUID
         // 
         this.txtStudyInstanceUID.Location = new System.Drawing.Point(160, 64);
         this.txtStudyInstanceUID.Name = "txtStudyInstanceUID";
         this.txtStudyInstanceUID.Size = new System.Drawing.Size(120, 20);
         this.txtStudyInstanceUID.TabIndex = 3;
         this.txtStudyInstanceUID.Text = "";
         // 
         // txtRequestedProcedureID
         // 
         this.txtRequestedProcedureID.Location = new System.Drawing.Point(160, 24);
         this.txtRequestedProcedureID.Name = "txtRequestedProcedureID";
         this.txtRequestedProcedureID.Size = new System.Drawing.Size(120, 20);
         this.txtRequestedProcedureID.TabIndex = 1;
         this.txtRequestedProcedureID.Text = "";
         // 
         // lblStudyInstanceUID
         // 
         this.lblStudyInstanceUID.Location = new System.Drawing.Point(9, 64);
         this.lblStudyInstanceUID.Name = "lblStudyInstanceUID";
         this.lblStudyInstanceUID.Size = new System.Drawing.Size(105, 20);
         this.lblStudyInstanceUID.TabIndex = 2;
         this.lblStudyInstanceUID.Text = "&Study Instance UID:";
         this.lblStudyInstanceUID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblRequestedProcedureID
         // 
         this.lblRequestedProcedureID.Location = new System.Drawing.Point(9, 24);
         this.lblRequestedProcedureID.Name = "lblRequestedProcedureID";
         this.lblRequestedProcedureID.Size = new System.Drawing.Size(132, 20);
         this.lblRequestedProcedureID.TabIndex = 0;
         this.lblRequestedProcedureID.Text = "Requested &Procedure ID:";
         this.lblRequestedProcedureID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // RequestedProcedureQuery
         // 
         this.Controls.Add(this.grpRequestedProcedure);
         this.Name = "RequestedProcedureQuery";
         this.Size = new System.Drawing.Size(525, 115);
         this.grpRequestedProcedure.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);
      }
      
      private System.ComponentModel.Container components = null ;
      private System.Windows.Forms.GroupBox grpRequestedProcedure;
      private System.Windows.Forms.Label lblRequestedProcedureID;
      private System.Windows.Forms.Label lblStudyInstanceUID;
      private System.Windows.Forms.TextBox txtRequestedProcedureID;
      private System.Windows.Forms.TextBox txtStudyInstanceUID;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.CheckBox chkLow;
      private System.Windows.Forms.CheckBox chkHight;
      private System.Windows.Forms.CheckBox chkMedium;
      private System.Windows.Forms.CheckBox chkRoutine;
      private System.Windows.Forms.CheckBox chkStat;
   }
}
