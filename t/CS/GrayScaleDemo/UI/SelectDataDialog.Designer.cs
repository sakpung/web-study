namespace GrayScaleDemo
{
    partial class SelectDataDialog
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
           this._gbSelectData = new System.Windows.Forms.GroupBox();
           this._cbCombine = new System.Windows.Forms.CheckBox();
           this._numThreshold = new System.Windows.Forms.NumericUpDown();
           this._numSourceHighBit = new System.Windows.Forms.NumericUpDown();
           this._numSourceLowBit = new System.Windows.Forms.NumericUpDown();
           this._lblThreshold = new System.Windows.Forms.Label();
           this._lblSourceHighBit = new System.Windows.Forms.Label();
           this._lblSourceLowBit = new System.Windows.Forms.Label();
           this._lblColor = new System.Windows.Forms.Label();
           this._btnCancel = new System.Windows.Forms.Button();
           this._btnOk = new System.Windows.Forms.Button();
           this._btnColor = new System.Windows.Forms.Button();
           this._pnlColor = new System.Windows.Forms.Panel();
           this._gbSelectData.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._numSourceHighBit)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._numSourceLowBit)).BeginInit();
           this.SuspendLayout();
           // 
           // _gbSelectData
           // 
           this._gbSelectData.Controls.Add(this._pnlColor);
           this._gbSelectData.Controls.Add(this._btnColor);
           this._gbSelectData.Controls.Add(this._cbCombine);
           this._gbSelectData.Controls.Add(this._numThreshold);
           this._gbSelectData.Controls.Add(this._numSourceHighBit);
           this._gbSelectData.Controls.Add(this._numSourceLowBit);
           this._gbSelectData.Controls.Add(this._lblThreshold);
           this._gbSelectData.Controls.Add(this._lblSourceHighBit);
           this._gbSelectData.Controls.Add(this._lblSourceLowBit);
           this._gbSelectData.Controls.Add(this._lblColor);
           this._gbSelectData.Location = new System.Drawing.Point(9, 3);
           this._gbSelectData.Name = "_gbSelectData";
           this._gbSelectData.Size = new System.Drawing.Size(251, 164);
           this._gbSelectData.TabIndex = 0;
           this._gbSelectData.TabStop = false;
           // 
           // _cbCombine
           // 
           this._cbCombine.AutoSize = true;
           this._cbCombine.Location = new System.Drawing.Point(18, 50);
           this._cbCombine.Name = "_cbCombine";
           this._cbCombine.Size = new System.Drawing.Size(67, 17);
           this._cbCombine.TabIndex = 10;
           this._cbCombine.Text = "Combine";
           this._cbCombine.UseVisualStyleBackColor = true;
           // 
           // _numThreshold
           // 
           this._numThreshold.Location = new System.Drawing.Point(122, 131);
           this._numThreshold.Name = "_numThreshold";
           this._numThreshold.Size = new System.Drawing.Size(120, 20);
           this._numThreshold.TabIndex = 9;
           // 
           // _numSourceHighBit
           // 
           this._numSourceHighBit.Location = new System.Drawing.Point(122, 104);
           this._numSourceHighBit.Name = "_numSourceHighBit";
           this._numSourceHighBit.Size = new System.Drawing.Size(120, 20);
           this._numSourceHighBit.TabIndex = 8;
           // 
           // _numSourceLowBit
           // 
           this._numSourceLowBit.Location = new System.Drawing.Point(122, 77);
           this._numSourceLowBit.Name = "_numSourceLowBit";
           this._numSourceLowBit.Size = new System.Drawing.Size(120, 20);
           this._numSourceLowBit.TabIndex = 7;
           // 
           // _lblThreshold
           // 
           this._lblThreshold.AutoSize = true;
           this._lblThreshold.Location = new System.Drawing.Point(15, 133);
           this._lblThreshold.Name = "_lblThreshold";
           this._lblThreshold.Size = new System.Drawing.Size(60, 13);
           this._lblThreshold.TabIndex = 4;
           this._lblThreshold.Text = "Threshold :";
           // 
           // _lblSourceHighBit
           // 
           this._lblSourceHighBit.AutoSize = true;
           this._lblSourceHighBit.Location = new System.Drawing.Point(15, 106);
           this._lblSourceHighBit.Name = "_lblSourceHighBit";
           this._lblSourceHighBit.Size = new System.Drawing.Size(87, 13);
           this._lblSourceHighBit.TabIndex = 3;
           this._lblSourceHighBit.Text = "Source High Bit :";
           // 
           // _lblSourceLowBit
           // 
           this._lblSourceLowBit.AutoSize = true;
           this._lblSourceLowBit.Location = new System.Drawing.Point(15, 79);
           this._lblSourceLowBit.Name = "_lblSourceLowBit";
           this._lblSourceLowBit.Size = new System.Drawing.Size(85, 13);
           this._lblSourceLowBit.TabIndex = 2;
           this._lblSourceLowBit.Text = "Source Low Bit :";
           // 
           // _lblColor
           // 
           this._lblColor.AutoSize = true;
           this._lblColor.Location = new System.Drawing.Point(15, 25);
           this._lblColor.Name = "_lblColor";
           this._lblColor.Size = new System.Drawing.Size(40, 13);
           this._lblColor.TabIndex = 0;
           this._lblColor.Text = "Color : ";
           // 
           // _btnCancel
           // 
           this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._btnCancel.Location = new System.Drawing.Point(143, 172);
           this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(68, 22);
           this._btnCancel.TabIndex = 19;
           this._btnCancel.Text = "Cancel";
           this._btnCancel.UseVisualStyleBackColor = true;
           // 
           // _btnOk
           // 
           this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
           this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._btnOk.Location = new System.Drawing.Point(58, 172);
           this._btnOk.Margin = new System.Windows.Forms.Padding(2);
           this._btnOk.Name = "_btnOk";
           this._btnOk.Size = new System.Drawing.Size(68, 22);
           this._btnOk.TabIndex = 18;
           this._btnOk.Text = "OK";
           this._btnOk.UseVisualStyleBackColor = true;
           this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
           // 
           // _btnColor
           // 
           this._btnColor.Location = new System.Drawing.Point(122, 19);
           this._btnColor.Name = "_btnColor";
           this._btnColor.Size = new System.Drawing.Size(37, 24);
           this._btnColor.TabIndex = 11;
           this._btnColor.Text = "...";
           this._btnColor.UseVisualStyleBackColor = true;
           this._btnColor.Click += new System.EventHandler(this._btnColor_Click);
           // 
           // _pnlColor
           // 
           this._pnlColor.Location = new System.Drawing.Point(170, 19);
           this._pnlColor.Name = "_pnlColor";
           this._pnlColor.Size = new System.Drawing.Size(72, 24);
           this._pnlColor.TabIndex = 12;
           // 
           // SelectDataDialog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(269, 209);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this._btnOk);
           this.Controls.Add(this._gbSelectData);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "SelectDataDialog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Select Data";
           this.Load += new System.EventHandler(this.SelectDataDialog_Load);
           this._gbSelectData.ResumeLayout(false);
           this._gbSelectData.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._numSourceHighBit)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._numSourceLowBit)).EndInit();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbSelectData;
        private System.Windows.Forms.Label _lblThreshold;
        private System.Windows.Forms.Label _lblSourceHighBit;
        private System.Windows.Forms.Label _lblSourceLowBit;
        private System.Windows.Forms.Label _lblColor;
        private System.Windows.Forms.NumericUpDown _numThreshold;
        private System.Windows.Forms.NumericUpDown _numSourceHighBit;
        private System.Windows.Forms.NumericUpDown _numSourceLowBit;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.CheckBox _cbCombine;
        private System.Windows.Forms.Panel _pnlColor;
        private System.Windows.Forms.Button _btnColor;
    }
}