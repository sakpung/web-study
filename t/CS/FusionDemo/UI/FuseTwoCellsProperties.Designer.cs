namespace FusionDemo
{
   partial class FuseTwoCellsProperties
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
         this._btnOK = new System.Windows.Forms.Button();
         this._numStart = new System.Windows.Forms.NumericUpDown();
         this._numEnd = new System.Windows.Forms.NumericUpDown();
         this._chkBestAligned = new System.Windows.Forms.CheckBox();
         ((System.ComponentModel.ISupportInitialize)(this._numStart)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numEnd)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(40, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(48, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Strat at:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(40, 50);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(42, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "End at:";
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(69, 97);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 2;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _numStart
         // 
         this._numStart.Location = new System.Drawing.Point(94, 22);
         this._numStart.Name = "_numStart";
         this._numStart.Size = new System.Drawing.Size(78, 20);
         this._numStart.TabIndex = 3;
         // 
         // _numEnd
         // 
         this._numEnd.Location = new System.Drawing.Point(94, 48);
         this._numEnd.Name = "_numEnd";
         this._numEnd.Size = new System.Drawing.Size(78, 20);
         this._numEnd.TabIndex = 4;
         // 
         // _chkBestAligned
         // 
         this._chkBestAligned.AutoSize = true;
         this._chkBestAligned.Checked = true;
         this._chkBestAligned.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkBestAligned.Location = new System.Drawing.Point(43, 74);
         this._chkBestAligned.Name = "_chkBestAligned";
         this._chkBestAligned.Size = new System.Drawing.Size(106, 17);
         this._chkBestAligned.TabIndex = 5;
         this._chkBestAligned.Text = "Use Best Aligned";
         this._chkBestAligned.UseVisualStyleBackColor = true;
         // 
         // FuseTwoCellsProperties
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(212, 134);
         this.ControlBox = false;
         this.Controls.Add(this._chkBestAligned);
         this.Controls.Add(this._numEnd);
         this.Controls.Add(this._numStart);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "FuseTwoCellsProperties";
         this.Text = "FuseTwoCellsProperties";
         ((System.ComponentModel.ISupportInitialize)(this._numStart)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numEnd)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.NumericUpDown _numStart;
      private System.Windows.Forms.NumericUpDown _numEnd;
      private System.Windows.Forms.CheckBox _chkBestAligned;
   }
}