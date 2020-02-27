using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms
{
   partial class InstanceUIDController
   {

      private void InitializeComponent()
      {
         this.grpSSOPInstanceUID = new System.Windows.Forms.GroupBox();
         this.btnSOPInstanceUIDRemove = new System.Windows.Forms.Button();
         this.lstSOPInstanceUID = new System.Windows.Forms.ListBox();
         this.txtSOPInstanceUID = new System.Windows.Forms.TextBox();
         this.btnSOPInstanceUIDAdd = new System.Windows.Forms.Button();
         this.grpSSOPInstanceUID.SuspendLayout();
         this.SuspendLayout();
         // 
         // grpSSOPInstanceUID
         // 
         this.grpSSOPInstanceUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.grpSSOPInstanceUID.Controls.Add(this.btnSOPInstanceUIDRemove);
         this.grpSSOPInstanceUID.Controls.Add(this.lstSOPInstanceUID);
         this.grpSSOPInstanceUID.Controls.Add(this.txtSOPInstanceUID);
         this.grpSSOPInstanceUID.Controls.Add(this.btnSOPInstanceUIDAdd);
         this.grpSSOPInstanceUID.Location = new System.Drawing.Point(0, 0);
         this.grpSSOPInstanceUID.Name = "grpSSOPInstanceUID";
         this.grpSSOPInstanceUID.Size = new System.Drawing.Size(284, 144);
         this.grpSSOPInstanceUID.TabIndex = 0;
         this.grpSSOPInstanceUID.TabStop = false;
         this.grpSSOPInstanceUID.Text = "&SOP Instance UID:";
         // 
         // btnSOPInstanceUIDRemove
         // 
         this.btnSOPInstanceUIDRemove.Enabled = false;
         this.btnSOPInstanceUIDRemove.Location = new System.Drawing.Point(199, 46);
         this.btnSOPInstanceUIDRemove.Name = "btnSOPInstanceUIDRemove";
         this.btnSOPInstanceUIDRemove.TabIndex = 3;
         this.btnSOPInstanceUIDRemove.Text = "Remo&ve";
         // 
         // lstSOPInstanceUID
         // 
         this.lstSOPInstanceUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.lstSOPInstanceUID.HorizontalScrollbar = true;
         this.lstSOPInstanceUID.Location = new System.Drawing.Point(10, 46);
         this.lstSOPInstanceUID.Name = "lstSOPInstanceUID";
         this.lstSOPInstanceUID.Size = new System.Drawing.Size(182, 82);
         this.lstSOPInstanceUID.TabIndex = 2;
         // 
         // txtSOPInstanceUID
         // 
         this.txtSOPInstanceUID.Location = new System.Drawing.Point(10, 22);
         this.txtSOPInstanceUID.Name = "txtSOPInstanceUID";
         this.txtSOPInstanceUID.Size = new System.Drawing.Size(182, 20);
         this.txtSOPInstanceUID.TabIndex = 0;
         this.txtSOPInstanceUID.Text = "";
         // 
         // btnSOPInstanceUIDAdd
         // 
         this.btnSOPInstanceUIDAdd.Location = new System.Drawing.Point(199, 22);
         this.btnSOPInstanceUIDAdd.Name = "btnSOPInstanceUIDAdd";
         this.btnSOPInstanceUIDAdd.TabIndex = 1;
         this.btnSOPInstanceUIDAdd.Text = "&Add";
         // 
         // InstanceUIDController
         // 
         this.Controls.Add(this.grpSSOPInstanceUID);
         this.Name = "InstanceUIDController";
         this.Size = new System.Drawing.Size(285, 144);
         this.grpSSOPInstanceUID.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      
      protected override void Dispose ( bool disposing )
      {
         if( disposing )
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }      
      
      private System.Windows.Forms.Button btnSOPInstanceUIDRemove;
      private System.Windows.Forms.ListBox lstSOPInstanceUID;
      private System.Windows.Forms.TextBox txtSOPInstanceUID;
      private System.Windows.Forms.Button btnSOPInstanceUIDAdd;
      private System.Windows.Forms.GroupBox grpSSOPInstanceUID;

      private System.ComponentModel.Container components = null ;


   }
}
