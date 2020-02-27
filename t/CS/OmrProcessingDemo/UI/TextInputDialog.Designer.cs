namespace OmrProcessingDemo
{
   partial class TextInputDialog
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
         this.lblValue = new System.Windows.Forms.Label();
         this.txtValue = new System.Windows.Forms.TextBox();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnOK = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // lblValue
         // 
         this.lblValue.AutoSize = true;
         this.lblValue.Location = new System.Drawing.Point(12, 9);
         this.lblValue.Name = "lblValue";
         this.lblValue.Size = new System.Drawing.Size(37, 13);
         this.lblValue.TabIndex = 0;
         this.lblValue.Text = "Value:";
         // 
         // txtValue
         // 
         this.txtValue.Location = new System.Drawing.Point(55, 6);
         this.txtValue.Name = "txtValue";
         this.txtValue.Size = new System.Drawing.Size(299, 20);
         this.txtValue.TabIndex = 1;
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(279, 32);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 3;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(198, 32);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 2;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         // 
         // TextInputDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(366, 66);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.txtValue);
         this.Controls.Add(this.lblValue);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "TextInputDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Update";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TextInputDialog_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblValue;
      private System.Windows.Forms.TextBox txtValue;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnOK;
   }
}