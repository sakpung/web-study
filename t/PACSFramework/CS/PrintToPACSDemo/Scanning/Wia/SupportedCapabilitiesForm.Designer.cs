namespace PrintToPACSDemo
{
   partial class SupportedCapabilitiesForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

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
         this._btnClose = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this._lvCapabilities = new System.Windows.Forms.ListView();
         this._lblCapabilitiesCount = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _btnClose
         // 
         this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnClose.Location = new System.Drawing.Point(588, 454);
         this._btnClose.Name = "_btnClose";
         this._btnClose.Size = new System.Drawing.Size(75, 23);
         this._btnClose.TabIndex = 0;
         this._btnClose.Text = "&Close";
         this._btnClose.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 459);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(118, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "WIA Capabilities Count:";
         // 
         // _lvCapabilities
         // 
         this._lvCapabilities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._lvCapabilities.FullRowSelect = true;
         this._lvCapabilities.GridLines = true;
         this._lvCapabilities.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this._lvCapabilities.Location = new System.Drawing.Point(15, 12);
         this._lvCapabilities.MultiSelect = false;
         this._lvCapabilities.Name = "_lvCapabilities";
         this._lvCapabilities.Size = new System.Drawing.Size(648, 436);
         this._lvCapabilities.TabIndex = 2;
         this._lvCapabilities.UseCompatibleStateImageBehavior = false;
         this._lvCapabilities.View = System.Windows.Forms.View.Details;
         this._lvCapabilities.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._lvCapabilities_MouseDoubleClick);
         // 
         // _lblCapabilitiesCount
         // 
         this._lblCapabilitiesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this._lblCapabilitiesCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblCapabilitiesCount.Location = new System.Drawing.Point(136, 458);
         this._lblCapabilitiesCount.Name = "_lblCapabilitiesCount";
         this._lblCapabilitiesCount.Size = new System.Drawing.Size(47, 18);
         this._lblCapabilitiesCount.TabIndex = 3;
         this._lblCapabilitiesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // SupportedCapabilitiesForm
         // 
         this.AcceptButton = this._btnClose;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnClose;
         this.ClientSize = new System.Drawing.Size(675, 489);
         this.Controls.Add(this._lblCapabilitiesCount);
         this.Controls.Add(this._lvCapabilities);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._btnClose);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(338, 315);
         this.Name = "SupportedCapabilitiesForm";
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "WIA Supported Capabilities";
         this.Load += new System.EventHandler(this.SupportedCapabilitiesForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btnClose;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ListView _lvCapabilities;
      private System.Windows.Forms.Label _lblCapabilitiesCount;
   }
}