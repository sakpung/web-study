namespace WebViewerConfiguration
{
   partial class ThreeDServiceLocation
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
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.radioButton1 = new System.Windows.Forms.RadioButton();
         this.radioButton2 = new System.Windows.Forms.RadioButton();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button1.Location = new System.Drawing.Point(195, 147);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(86, 24);
         this.button1.TabIndex = 4;
         this.button1.Text = "OK";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // button2
         // 
         this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button2.Location = new System.Drawing.Point(287, 147);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(86, 24);
         this.button2.TabIndex = 0;
         this.button2.Text = "Cancel";
         this.button2.UseVisualStyleBackColor = true;
         // 
         // radioButton1
         // 
         this.radioButton1.AutoSize = true;
         this.radioButton1.Location = new System.Drawing.Point(12, 12);
         this.radioButton1.Name = "radioButton1";
         this.radioButton1.Size = new System.Drawing.Size(207, 17);
         this.radioButton1.TabIndex = 1;
         this.radioButton1.TabStop = true;
         this.radioButton1.Text = "Local/Same as other services (default)";
         this.radioButton1.UseVisualStyleBackColor = true;
         this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
         // 
         // radioButton2
         // 
         this.radioButton2.AutoSize = true;
         this.radioButton2.Location = new System.Drawing.Point(12, 47);
         this.radioButton2.Name = "radioButton2";
         this.radioButton2.Size = new System.Drawing.Size(171, 17);
         this.radioButton2.TabIndex = 1;
         this.radioButton2.TabStop = true;
         this.radioButton2.Text = "Remote service, base address:";
         this.radioButton2.UseVisualStyleBackColor = true;
         this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(12, 70);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(354, 20);
         this.textBox1.TabIndex = 2;
         // 
         // label1
         // 
         this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.label1.Location = new System.Drawing.Point(-9, 135);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(420, 1);
         this.label1.TabIndex = 3;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 97);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(123, 13);
         this.label2.TabIndex = 5;
         this.label2.Text = "example: https://server1";
         // 
         // ThreeDServiceLocation
         // 
         this.AcceptButton = this.button1;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.button2;
         this.ClientSize = new System.Drawing.Size(379, 179);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.radioButton2);
         this.Controls.Add(this.radioButton1);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ThreeDServiceLocation";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.Text = "3D Service Location";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThreeDServiceLocation_FormClosing);
         this.Load += new System.EventHandler(this.ThreeDServiceLocation_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.RadioButton radioButton1;
      private System.Windows.Forms.RadioButton radioButton2;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
   }
}