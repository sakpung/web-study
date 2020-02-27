using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms
{
   partial class ImagingServiceRequestQuery
   {
      private System.ComponentModel.Container components = null ;
      
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
         this.grpImagingServiceRequest = new System.Windows.Forms.GroupBox();
         this.txtAccessionNumber = new System.Windows.Forms.TextBox();
         this.lblAccessionNumber = new System.Windows.Forms.Label();
         this.grpImagingServiceRequest.SuspendLayout();
         this.SuspendLayout();
         // 
         // grpImagingServiceRequest
         // 
         this.grpImagingServiceRequest.Controls.Add(this.txtAccessionNumber);
         this.grpImagingServiceRequest.Controls.Add(this.lblAccessionNumber);
         this.grpImagingServiceRequest.Location = new System.Drawing.Point(7, 7);
         this.grpImagingServiceRequest.Name = "grpImagingServiceRequest";
         this.grpImagingServiceRequest.Size = new System.Drawing.Size(222, 62);
         this.grpImagingServiceRequest.TabIndex = 0;
         this.grpImagingServiceRequest.TabStop = false;
         this.grpImagingServiceRequest.Text = "Imaging Service Request Query";
         // 
         // txtAccessionNumber
         // 
         this.txtAccessionNumber.Location = new System.Drawing.Point(108, 23);
         this.txtAccessionNumber.Name = "txtAccessionNumber";
         this.txtAccessionNumber.Size = new System.Drawing.Size(103, 20);
         this.txtAccessionNumber.TabIndex = 1;
         this.txtAccessionNumber.Text = "";
         // 
         // lblAccessionNumber
         // 
         this.lblAccessionNumber.Location = new System.Drawing.Point(8, 23);
         this.lblAccessionNumber.Name = "lblAccessionNumber";
         this.lblAccessionNumber.TabIndex = 0;
         this.lblAccessionNumber.Text = "&Accession number:";
         this.lblAccessionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // ImagingServiceRequestQuery
         // 
         this.Controls.Add(this.grpImagingServiceRequest);
         this.Name = "ImagingServiceRequestQuery";
         this.Size = new System.Drawing.Size(237, 77);
         this.grpImagingServiceRequest.ResumeLayout(false);
         this.ResumeLayout(false);

      }
            
      private System.Windows.Forms.GroupBox grpImagingServiceRequest;
      private System.Windows.Forms.Label lblAccessionNumber;
      private System.Windows.Forms.TextBox txtAccessionNumber;
   }
}
