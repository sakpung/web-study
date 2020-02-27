using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms
{
   partial class VisitQuery
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
         this.grpVisitQuery = new System.Windows.Forms.GroupBox();
         this.txtAdmissionID = new System.Windows.Forms.TextBox();
         this.lblAdmissionID = new System.Windows.Forms.Label();
         this.grpVisitQuery.SuspendLayout();
         this.SuspendLayout();
         // 
         // grpVisitQuery
         // 
         this.grpVisitQuery.Controls.Add(this.txtAdmissionID);
         this.grpVisitQuery.Controls.Add(this.lblAdmissionID);
         this.grpVisitQuery.Location = new System.Drawing.Point(7, 7);
         this.grpVisitQuery.Name = "grpVisitQuery";
         this.grpVisitQuery.Size = new System.Drawing.Size(192, 57);
         this.grpVisitQuery.TabIndex = 0;
         this.grpVisitQuery.TabStop = false;
         this.grpVisitQuery.Text = "Visit Query";
         // 
         // txtAdmissionID
         // 
         this.txtAdmissionID.Location = new System.Drawing.Point(83, 24);
         this.txtAdmissionID.Name = "txtAdmissionID";
         this.txtAdmissionID.TabIndex = 1;
         this.txtAdmissionID.Text = "";
         // 
         // lblAdmissionID
         // 
         this.lblAdmissionID.Location = new System.Drawing.Point(9, 24);
         this.lblAdmissionID.Name = "lblAdmissionID";
         this.lblAdmissionID.Size = new System.Drawing.Size(75, 20);
         this.lblAdmissionID.TabIndex = 0;
         this.lblAdmissionID.Text = "&Admission ID:";
         this.lblAdmissionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // VisitQuery
         // 
         this.Controls.Add(this.grpVisitQuery);
         this.Name = "VisitQuery";
         this.Size = new System.Drawing.Size(207, 71);
         this.grpVisitQuery.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      
      private System.Windows.Forms.GroupBox grpVisitQuery ;
      private System.Windows.Forms.Label lblAdmissionID ;
      private System.Windows.Forms.TextBox txtAdmissionID ; 
      private System.ComponentModel.Container components = null ;
   }
}
