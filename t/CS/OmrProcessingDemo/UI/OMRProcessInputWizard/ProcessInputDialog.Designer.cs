namespace OmrProcessingDemo.UI.ViewerControl
{
   partial class ProcessInputDialog
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
         this.btnPrevious = new System.Windows.Forms.Button();
         this.btnNext = new System.Windows.Forms.Button();
         this.btnOK = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(551, 207);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 2;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // btnPrevious
         // 
         this.btnPrevious.Location = new System.Drawing.Point(389, 207);
         this.btnPrevious.Name = "btnPrevious";
         this.btnPrevious.Size = new System.Drawing.Size(75, 23);
         this.btnPrevious.TabIndex = 3;
         this.btnPrevious.Text = "< Previous";
         this.btnPrevious.UseVisualStyleBackColor = true;
         this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
         // 
         // btnNext
         // 
         this.btnNext.Location = new System.Drawing.Point(464, 207);
         this.btnNext.Name = "btnNext";
         this.btnNext.Size = new System.Drawing.Size(75, 23);
         this.btnNext.TabIndex = 4;
         this.btnNext.Text = "Next >";
         this.btnNext.UseVisualStyleBackColor = true;
         this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
         // 
         // btnOK
         // 
         this.btnOK.AutoSize = true;
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(464, 207);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 5;
         this.btnOK.Text = "Run";
         this.btnOK.UseVisualStyleBackColor = true;
         // 
         // ProcessInputDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(638, 241);
         this.Controls.Add(this.btnPrevious);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.btnNext);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ProcessInputDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Template Selection";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnPrevious;
      private System.Windows.Forms.Button btnNext;
      private System.Windows.Forms.Button btnOK;
   }
}