namespace GrayScaleDemo
{
    partial class CopyImageDialog
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
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbDigitalSubtract = new System.Windows.Forms.GroupBox();
         this._cmbDestImage = new System.Windows.Forms.ComboBox();
         this._lblMaskImage = new System.Windows.Forms.Label();
         this._gbDigitalSubtract.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(765, 67);
         this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(68, 22);
         this._btnCancel.TabIndex = 17;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(693, 67);
         this._btnOk.Margin = new System.Windows.Forms.Padding(2);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(68, 22);
         this._btnOk.TabIndex = 16;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _gbDigitalSubtract
         // 
         this._gbDigitalSubtract.Controls.Add(this._cmbDestImage);
         this._gbDigitalSubtract.Controls.Add(this._lblMaskImage);
         this._gbDigitalSubtract.Location = new System.Drawing.Point(6, 4);
         this._gbDigitalSubtract.Name = "_gbDigitalSubtract";
         this._gbDigitalSubtract.Size = new System.Drawing.Size(833, 51);
         this._gbDigitalSubtract.TabIndex = 15;
         this._gbDigitalSubtract.TabStop = false;
         // 
         // _cmbDestImage
         // 
         this._cmbDestImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbDestImage.FormattingEnabled = true;
         this._cmbDestImage.Location = new System.Drawing.Point(107, 19);
         this._cmbDestImage.Name = "_cmbDestImage";
         this._cmbDestImage.Size = new System.Drawing.Size(720, 21);
         this._cmbDestImage.TabIndex = 4;
         // 
         // _lblMaskImage
         // 
         this._lblMaskImage.AutoSize = true;
         this._lblMaskImage.Location = new System.Drawing.Point(6, 22);
         this._lblMaskImage.Name = "_lblMaskImage";
         this._lblMaskImage.Size = new System.Drawing.Size(95, 13);
         this._lblMaskImage.TabIndex = 3;
         this._lblMaskImage.Text = "Destination Image:";
         // 
         // CopyImageDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(851, 100);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbDigitalSubtract);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CopyImageDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Copy Image";
         this.Load += new System.EventHandler(this.CopyImageDialog_Load);
         this._gbDigitalSubtract.ResumeLayout(false);
         this._gbDigitalSubtract.PerformLayout();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.GroupBox _gbDigitalSubtract;
        private System.Windows.Forms.ComboBox _cmbDestImage;
        private System.Windows.Forms.Label _lblMaskImage;
    }
}