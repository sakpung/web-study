namespace OmrProcessingDemo.UI.ViewerControl
{
   partial class FormSpecificDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSpecificDialog));
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.txtValue = new System.Windows.Forms.TextBox();
         this.lblValue = new System.Windows.Forms.Label();
         this.chkChooseIdentifier = new System.Windows.Forms.CheckedListBox();
         this.lblIdentifierDefinition = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(197, 192);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 0;
         this.btnOK.Text = "&OK";
         this.btnOK.UseVisualStyleBackColor = true;
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(278, 192);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 1;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // txtValue
         // 
         this.txtValue.Location = new System.Drawing.Point(102, 12);
         this.txtValue.Name = "txtValue";
         this.txtValue.Size = new System.Drawing.Size(251, 20);
         this.txtValue.TabIndex = 3;
         // 
         // lblValue
         // 
         this.lblValue.AutoSize = true;
         this.lblValue.Location = new System.Drawing.Point(11, 15);
         this.lblValue.Name = "lblValue";
         this.lblValue.Size = new System.Drawing.Size(85, 13);
         this.lblValue.TabIndex = 2;
         this.lblValue.Text = "Template Name:";
         // 
         // chkChooseIdentifier
         // 
         this.chkChooseIdentifier.CheckOnClick = true;
         this.chkChooseIdentifier.FormattingEnabled = true;
         this.chkChooseIdentifier.Location = new System.Drawing.Point(14, 92);
         this.chkChooseIdentifier.Name = "chkChooseIdentifier";
         this.chkChooseIdentifier.Size = new System.Drawing.Size(339, 94);
         this.chkChooseIdentifier.TabIndex = 4;
         this.chkChooseIdentifier.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkChooseIdentifier_ItemCheck);
         // 
         // lblIdentifierDefinition
         // 
         this.lblIdentifierDefinition.Location = new System.Drawing.Point(13, 41);
         this.lblIdentifierDefinition.Name = "lblIdentifierDefinition";
         this.lblIdentifierDefinition.Size = new System.Drawing.Size(341, 48);
         this.lblIdentifierDefinition.TabIndex = 6;
         this.lblIdentifierDefinition.Text = resources.GetString("lblIdentifierDefinition.Text");
         // 
         // FormSpecificDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(366, 227);
         this.Controls.Add(this.lblIdentifierDefinition);
         this.Controls.Add(this.chkChooseIdentifier);
         this.Controls.Add(this.txtValue);
         this.Controls.Add(this.lblValue);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FormSpecificDialog";
         this.Text = "Template";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSpecificDialog_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.TextBox txtValue;
      private System.Windows.Forms.Label lblValue;
      private System.Windows.Forms.CheckedListBox chkChooseIdentifier;
      private System.Windows.Forms.Label lblIdentifierDefinition;
   }
}