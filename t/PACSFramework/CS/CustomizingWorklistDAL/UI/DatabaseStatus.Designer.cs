namespace CSCustomizingWorklistDAL.UI
{
   partial class DatabaseStatus
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.label1 = new System.Windows.Forms.Label();
         this.ConnectionStringTextBox = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.ProviderTextBox = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(5, 7);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(94, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Connection String:";
         // 
         // ConnectionStringTextBox
         // 
         this.ConnectionStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.ConnectionStringTextBox.Location = new System.Drawing.Point(105, 4);
         this.ConnectionStringTextBox.Name = "ConnectionStringTextBox";
         this.ConnectionStringTextBox.ReadOnly = true;
         this.ConnectionStringTextBox.Size = new System.Drawing.Size(313, 20);
         this.ConnectionStringTextBox.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(5, 33);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(49, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Provider:";
         // 
         // ProviderTextBox
         // 
         this.ProviderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.ProviderTextBox.Location = new System.Drawing.Point(105, 30);
         this.ProviderTextBox.Name = "ProviderTextBox";
         this.ProviderTextBox.ReadOnly = true;
         this.ProviderTextBox.Size = new System.Drawing.Size(313, 20);
         this.ProviderTextBox.TabIndex = 3;
         // 
         // DatabaseStatus
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.ProviderTextBox);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.ConnectionStringTextBox);
         this.Controls.Add(this.label1);
         this.Name = "DatabaseStatus";
         this.Size = new System.Drawing.Size(426, 52);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox ConnectionStringTextBox;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox ProviderTextBox;
   }
}
