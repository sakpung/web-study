namespace GrayScaleDemo
{
    partial class TissueEqualizeDialog
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
            this._gbTissueEqualize = new System.Windows.Forms.GroupBox();
            this._lblFlags = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._rbUseIntensifyOption = new System.Windows.Forms.RadioButton();
            this._rbUseSimplifyOption = new System.Windows.Forms.RadioButton();
            this._gbTissueEqualize.SuspendLayout();
            this.SuspendLayout();
            // 
            // _gbTissueEqualize
            // 
            this._gbTissueEqualize.Controls.Add(this._rbUseSimplifyOption);
            this._gbTissueEqualize.Controls.Add(this._rbUseIntensifyOption);
            this._gbTissueEqualize.Controls.Add(this._lblFlags);
            this._gbTissueEqualize.Location = new System.Drawing.Point(7, 6);
            this._gbTissueEqualize.Name = "_gbTissueEqualize";
            this._gbTissueEqualize.Size = new System.Drawing.Size(196, 65);
            this._gbTissueEqualize.TabIndex = 0;
            this._gbTissueEqualize.TabStop = false;
            // 
            // _lblFlags
            // 
            this._lblFlags.AutoSize = true;
            this._lblFlags.Location = new System.Drawing.Point(14, 32);
            this._lblFlags.Name = "_lblFlags";
            this._lblFlags.Size = new System.Drawing.Size(38, 13);
            this._lblFlags.TabIndex = 2;
            this._lblFlags.Text = "Flags :";
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnCancel.Location = new System.Drawing.Point(114, 76);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(68, 22);
            this._btnCancel.TabIndex = 15;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnOk.Location = new System.Drawing.Point(29, 76);
            this._btnOk.Margin = new System.Windows.Forms.Padding(2);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(68, 22);
            this._btnOk.TabIndex = 14;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _rbUseIntensifyOption
            // 
            this._rbUseIntensifyOption.AutoSize = true;
            this._rbUseIntensifyOption.Location = new System.Drawing.Point(70, 19);
            this._rbUseIntensifyOption.Name = "_rbUseIntensifyOption";
            this._rbUseIntensifyOption.Size = new System.Drawing.Size(120, 17);
            this._rbUseIntensifyOption.TabIndex = 3;
            this._rbUseIntensifyOption.TabStop = true;
            this._rbUseIntensifyOption.Text = "Use Intensify Option";
            this._rbUseIntensifyOption.UseVisualStyleBackColor = true;
            // 
            // _rbUseSimplifyOption
            // 
            this._rbUseSimplifyOption.AutoSize = true;
            this._rbUseSimplifyOption.Location = new System.Drawing.Point(70, 42);
            this._rbUseSimplifyOption.Name = "_rbUseSimplifyOption";
            this._rbUseSimplifyOption.Size = new System.Drawing.Size(116, 17);
            this._rbUseSimplifyOption.TabIndex = 4;
            this._rbUseSimplifyOption.TabStop = true;
            this._rbUseSimplifyOption.Text = "Use Simplify Option";
            this._rbUseSimplifyOption.UseVisualStyleBackColor = true;
            // 
            // TissueEqualizeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 108);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._gbTissueEqualize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TissueEqualizeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TissueEqualize";
            this.Load += new System.EventHandler(this.TissueEqualizeDialog_Load);
            this._gbTissueEqualize.ResumeLayout(false);
            this._gbTissueEqualize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbTissueEqualize;
        private System.Windows.Forms.Label _lblFlags;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.RadioButton _rbUseSimplifyOption;
        private System.Windows.Forms.RadioButton _rbUseIntensifyOption;
    }
}