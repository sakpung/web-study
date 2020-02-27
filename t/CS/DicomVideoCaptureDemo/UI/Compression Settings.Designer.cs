namespace DicomVideoCaptureDemo.UI
{
   partial class Compression_Settings
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
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this._combo_CompressionType = new System.Windows.Forms.ComboBox();
         this._combo_QFactor = new System.Windows.Forms.ComboBox();
         this._btn_Audio = new System.Windows.Forms.Button();
         this._btn_Video = new System.Windows.Forms.Button();
         this._btn_Close = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(97, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Compression Type:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 46);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(75, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Quality Factor:";
         // 
         // _combo_CompressionType
         // 
         this._combo_CompressionType.FormattingEnabled = true;
         this._combo_CompressionType.Location = new System.Drawing.Point(116, 12);
         this._combo_CompressionType.Name = "_combo_CompressionType";
         this._combo_CompressionType.Size = new System.Drawing.Size(156, 21);
         this._combo_CompressionType.TabIndex = 2;
         // 
         // _combo_QFactor
         // 
         this._combo_QFactor.FormattingEnabled = true;
         this._combo_QFactor.Location = new System.Drawing.Point(116, 42);
         this._combo_QFactor.Name = "_combo_QFactor";
         this._combo_QFactor.Size = new System.Drawing.Size(156, 21);
         this._combo_QFactor.TabIndex = 3;
         // 
         // _btn_Audio
         // 
         this._btn_Audio.Location = new System.Drawing.Point(296, 42);
         this._btn_Audio.Name = "_btn_Audio";
         this._btn_Audio.Size = new System.Drawing.Size(186, 23);
         this._btn_Audio.TabIndex = 4;
         this._btn_Audio.Text = "MPEG2 Audio Encoder Options";
         this._btn_Audio.UseVisualStyleBackColor = true;
         // 
         // _btn_Video
         // 
         this._btn_Video.Location = new System.Drawing.Point(296, 13);
         this._btn_Video.Name = "_btn_Video";
         this._btn_Video.Size = new System.Drawing.Size(186, 23);
         this._btn_Video.TabIndex = 6;
         this._btn_Video.Text = "MPEG2 Video Encoder Options";
         this._btn_Video.UseVisualStyleBackColor = true;
         // 
         // _btn_Close
         // 
         this._btn_Close.Location = new System.Drawing.Point(210, 117);
         this._btn_Close.Name = "_btn_Close";
         this._btn_Close.Size = new System.Drawing.Size(75, 23);
         this._btn_Close.TabIndex = 8;
         this._btn_Close.Text = "Close";
         this._btn_Close.UseVisualStyleBackColor = true;
         // 
         // Compression_Settings
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(494, 172);
         this.Controls.Add(this._btn_Close);
         this.Controls.Add(this._btn_Video);
         this.Controls.Add(this._btn_Audio);
         this.Controls.Add(this._combo_QFactor);
         this.Controls.Add(this._combo_CompressionType);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Compression_Settings";
         this.Text = "Compression Settings";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ComboBox _combo_CompressionType;
      private System.Windows.Forms.ComboBox _combo_QFactor;
      private System.Windows.Forms.Button _btn_Audio;
      private System.Windows.Forms.Button _btn_Video;
      private System.Windows.Forms.Button _btn_Close;
   }
}