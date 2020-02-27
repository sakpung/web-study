namespace OmrProcessingDemo.UI
{
   partial class RowNumberDialog
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
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnOK = new System.Windows.Forms.Button();
         this.txtValue = new System.Windows.Forms.TextBox();
         this.lblValue = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.nudStart = new System.Windows.Forms.NumericUpDown();
         ((System.ComponentModel.ISupportInitialize)(this.nudStart)).BeginInit();
         this.SuspendLayout();
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(350, 36);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 7;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(269, 36);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 6;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         // 
         // txtValue
         // 
         this.txtValue.Location = new System.Drawing.Point(67, 9);
         this.txtValue.Name = "txtValue";
         this.txtValue.Size = new System.Drawing.Size(180, 20);
         this.txtValue.TabIndex = 5;
         this.txtValue.Enter += new System.EventHandler(this.txtValue_Enter);
         // 
         // lblValue
         // 
         this.lblValue.AutoSize = true;
         this.lblValue.Location = new System.Drawing.Point(12, 12);
         this.lblValue.Name = "lblValue";
         this.lblValue.Size = new System.Drawing.Size(54, 13);
         this.lblValue.TabIndex = 4;
         this.lblValue.Text = "Template:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(253, 12);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(99, 13);
         this.label1.TabIndex = 8;
         this.label1.Text = "Start Numbering At:";
         // 
         // nudStart
         // 
         this.nudStart.Location = new System.Drawing.Point(358, 10);
         this.nudStart.Name = "nudStart";
         this.nudStart.Size = new System.Drawing.Size(67, 20);
         this.nudStart.TabIndex = 9;
         // 
         // RowNumberDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(440, 66);
         this.Controls.Add(this.nudStart);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.txtValue);
         this.Controls.Add(this.lblValue);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "RowNumberDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Update";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RowNumberDialog_FormClosing);
         ((System.ComponentModel.ISupportInitialize)(this.nudStart)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.TextBox txtValue;
      private System.Windows.Forms.Label lblValue;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.NumericUpDown nudStart;
   }
}