namespace PrintToPACSDemo.UI
{
   partial class LogWindow
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
         this._btnClearLog = new System.Windows.Forms.Button();
         this._rctxtLog = new System.Windows.Forms.RichTextBox();
         this._ckbtnLowLevel = new System.Windows.Forms.CheckBox();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this._btnSaveToText = new System.Windows.Forms.Button();
         this._labelLogLowLevel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _btnClearLog
         // 
         this._btnClearLog.Enabled = false;
         this._btnClearLog.Location = new System.Drawing.Point(12, 12);
         this._btnClearLog.Name = "_btnClearLog";
         this._btnClearLog.Size = new System.Drawing.Size(41, 23);
         this._btnClearLog.TabIndex = 0;
         this._btnClearLog.Text = "Clear";
         this._btnClearLog.UseVisualStyleBackColor = true;
         this._btnClearLog.Click += new System.EventHandler(this._btnClearLog_Click);
         // 
         // _rctxtLog
         // 
         this._rctxtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._rctxtLog.Location = new System.Drawing.Point(12, 41);
         this._rctxtLog.Name = "_rctxtLog";
         this._rctxtLog.Size = new System.Drawing.Size(334, 233);
         this._rctxtLog.TabIndex = 1;
         this._rctxtLog.Text = "";
         this._rctxtLog.TextChanged += new System.EventHandler(this._rctxtLog_TextChanged);
         // 
         // _ckbtnLowLevel
         // 
         this._ckbtnLowLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this._ckbtnLowLevel.AutoSize = true;
         this._ckbtnLowLevel.Location = new System.Drawing.Point(12, 280);
         this._ckbtnLowLevel.Name = "_ckbtnLowLevel";
         this._ckbtnLowLevel.Size = new System.Drawing.Size(116, 17);
         this._ckbtnLowLevel.TabIndex = 2;
         this._ckbtnLowLevel.Text = "Low Level Logging";
         this._ckbtnLowLevel.UseVisualStyleBackColor = true;
         this._ckbtnLowLevel.CheckedChanged += new System.EventHandler(this._ckbtnLowLevel_CheckedChanged);
         // 
         // checkBox1
         // 
         this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.checkBox1.AutoSize = true;
         this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.checkBox1.Location = new System.Drawing.Point(264, 2);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(92, 17);
         this.checkBox1.TabIndex = 3;
         this.checkBox1.Text = "Always on top";
         this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.checkBox1.UseVisualStyleBackColor = true;
         this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
         // 
         // _btnSaveToText
         // 
         this._btnSaveToText.Location = new System.Drawing.Point(59, 12);
         this._btnSaveToText.Name = "_btnSaveToText";
         this._btnSaveToText.Size = new System.Drawing.Size(78, 23);
         this._btnSaveToText.TabIndex = 4;
         this._btnSaveToText.Text = "Export to file";
         this._btnSaveToText.UseVisualStyleBackColor = true;
         this._btnSaveToText.Click += new System.EventHandler(this._btnSaveToText_Click);
         // 
         // _labelLogLowLevel
         // 
         this._labelLogLowLevel.AutoSize = true;
         this._labelLogLowLevel.ForeColor = System.Drawing.Color.Green;
         this._labelLogLowLevel.Location = new System.Drawing.Point(143, 281);
         this._labelLogLowLevel.Name = "_labelLogLowLevel";
         this._labelLogLowLevel.Size = new System.Drawing.Size(189, 13);
         this._labelLogLowLevel.TabIndex = 5;
         this._labelLogLowLevel.Text = "<== Displayed green in the log window";
         // 
         // LogWindow
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(358, 305);
         this.Controls.Add(this._labelLogLowLevel);
         this.Controls.Add(this._btnSaveToText);
         this.Controls.Add(this.checkBox1);
         this.Controls.Add(this._ckbtnLowLevel);
         this.Controls.Add(this._rctxtLog);
         this.Controls.Add(this._btnClearLog);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.MinimumSize = new System.Drawing.Size(357, 264);
         this.Name = "LogWindow";
         this.Text = "LogWindow";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogWindow_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btnClearLog;
      private System.Windows.Forms.RichTextBox _rctxtLog;
      private System.Windows.Forms.CheckBox _ckbtnLowLevel;
      private System.Windows.Forms.CheckBox checkBox1;
      private System.Windows.Forms.Button _btnSaveToText;
      private System.Windows.Forms.Label _labelLogLowLevel;
   }
}