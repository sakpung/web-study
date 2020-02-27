namespace MedicalViewerLayoutDemo
{
   partial class DefaultImagesDialog
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.dontRadio = new System.Windows.Forms.RadioButton();
         this.loadRadio = new System.Windows.Forms.RadioButton();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.okButton = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.dontRadio);
         this.groupBox1.Controls.Add(this.loadRadio);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(7, 1);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(274, 161);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         // 
         // dontRadio
         // 
         this.dontRadio.AutoSize = true;
         this.dontRadio.Location = new System.Drawing.Point(11, 137);
         this.dontRadio.Name = "dontRadio";
         this.dontRadio.Size = new System.Drawing.Size(145, 17);
         this.dontRadio.TabIndex = 3;
         this.dontRadio.Text = "Don\'t load sample images";
         this.dontRadio.UseVisualStyleBackColor = true;
         // 
         // loadRadio
         // 
         this.loadRadio.AutoSize = true;
         this.loadRadio.Checked = true;
         this.loadRadio.Location = new System.Drawing.Point(11, 111);
         this.loadRadio.Name = "loadRadio";
         this.loadRadio.Size = new System.Drawing.Size(121, 17);
         this.loadRadio.TabIndex = 2;
         this.loadRadio.TabStop = true;
         this.loadRadio.Text = "&Load sample images";
         this.loadRadio.UseVisualStyleBackColor = true;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(8, 84);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(206, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Would you like to load these images now?";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(6, 14);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(262, 59);
         this.label1.TabIndex = 0;
         this.label1.Text = "The \"Image Viewer Demo\" can load sample DICOM images to demonstrate the capabilit" +
             "ies of the \"LEADTOOLS Image Viewer Control\"";
         // 
         // okButton
         // 
         this.okButton.Location = new System.Drawing.Point(103, 170);
         this.okButton.Name = "okButton";
         this.okButton.Size = new System.Drawing.Size(79, 28);
         this.okButton.TabIndex = 1;
         this.okButton.Text = "OK";
         this.okButton.UseVisualStyleBackColor = true;
         this.okButton.Click += new System.EventHandler(this.okButton_Click);
         // 
         // DefaultImagesDialog
         // 
         this.AcceptButton = this.okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(288, 206);
         this.Controls.Add(this.okButton);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "DefaultImagesDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Load sample images";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.RadioButton dontRadio;
      private System.Windows.Forms.RadioButton loadRadio;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button okButton;
   }
}