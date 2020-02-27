namespace Leadtools.Medical.Storage.AddIns.Controls
{
   partial class AddInsConfigurationDialog
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
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.panel1 = new System.Windows.Forms.Panel();
         this.AddInsConfiguration = new Leadtools.Medical.Storage.AddIns.AddInsConfiguration();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnOK
         // 
         this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(471, 6);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 33);
         this.btnOK.TabIndex = 1;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.CausesValidation = false;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(549, 6);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 33);
         this.btnCancel.TabIndex = 3;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.btnOK);
         this.panel1.Controls.Add(this.btnCancel);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 452);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(628, 42);
         this.panel1.TabIndex = 5;
         // 
         // AddInsConfiguration
         // 
         this.AddInsConfiguration.CanViewIodClasses = true;
         this.AddInsConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
         this.AddInsConfiguration.Location = new System.Drawing.Point(0, 0);
         this.AddInsConfiguration.Name = "AddInsConfiguration";
         this.AddInsConfiguration.Size = new System.Drawing.Size(628, 452);
         this.AddInsConfiguration.TabIndex = 2;
         // 
         // AddInsConfigurationDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(628, 494);
         this.Controls.Add(this.AddInsConfiguration);
         this.Controls.Add(this.panel1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AddInsConfigurationDialog";
         this.ShowIcon = false;
         this.Text = "Options";
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Panel panel1;
      public AddInsConfiguration AddInsConfiguration;
   }
}