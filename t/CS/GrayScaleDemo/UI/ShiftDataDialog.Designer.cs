namespace GrayScaleDemo
{
    partial class ShiftDataDialog
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
            this._gbShiftData = new System.Windows.Forms.GroupBox();
            this._numSourceHighBit = new System.Windows.Forms.NumericUpDown();
            this._numSourceLowBit = new System.Windows.Forms.NumericUpDown();
            this._numDestLowBit = new System.Windows.Forms.NumericUpDown();
            this._cmbDestBPP = new System.Windows.Forms.ComboBox();
            this._lblSourceHighBit = new System.Windows.Forms.Label();
            this._lblSourceLowBit = new System.Windows.Forms.Label();
            this._lblDestinationLowBit = new System.Windows.Forms.Label();
            this._lblDestinationBitsPerPixel = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._lblMsg = new System.Windows.Forms.Label();
            this._gbShiftData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numSourceHighBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSourceLowBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDestLowBit)).BeginInit();
            this.SuspendLayout();
            // 
            // _gbShiftData
            // 
            this._gbShiftData.Controls.Add(this._numSourceHighBit);
            this._gbShiftData.Controls.Add(this._numSourceLowBit);
            this._gbShiftData.Controls.Add(this._numDestLowBit);
            this._gbShiftData.Controls.Add(this._cmbDestBPP);
            this._gbShiftData.Controls.Add(this._lblSourceHighBit);
            this._gbShiftData.Controls.Add(this._lblSourceLowBit);
            this._gbShiftData.Controls.Add(this._lblDestinationLowBit);
            this._gbShiftData.Controls.Add(this._lblDestinationBitsPerPixel);
            this._gbShiftData.Location = new System.Drawing.Point(10, 3);
            this._gbShiftData.Name = "_gbShiftData";
            this._gbShiftData.Size = new System.Drawing.Size(264, 159);
            this._gbShiftData.TabIndex = 0;
            this._gbShiftData.TabStop = false;
            // 
            // _numSourceHighBit
            // 
            this._numSourceHighBit.Location = new System.Drawing.Point(163, 119);
            this._numSourceHighBit.Name = "_numSourceHighBit";
            this._numSourceHighBit.Size = new System.Drawing.Size(85, 20);
            this._numSourceHighBit.TabIndex = 7;
            // 
            // _numSourceLowBit
            // 
            this._numSourceLowBit.Location = new System.Drawing.Point(163, 86);
            this._numSourceLowBit.Name = "_numSourceLowBit";
            this._numSourceLowBit.Size = new System.Drawing.Size(85, 20);
            this._numSourceLowBit.TabIndex = 6;
            // 
            // _numDestLowBit
            // 
            this._numDestLowBit.Location = new System.Drawing.Point(163, 56);
            this._numDestLowBit.Name = "_numDestLowBit";
            this._numDestLowBit.Size = new System.Drawing.Size(85, 20);
            this._numDestLowBit.TabIndex = 5;
            // 
            // _cmbDestBPP
            // 
            this._cmbDestBPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbDestBPP.FormattingEnabled = true;
            this._cmbDestBPP.Location = new System.Drawing.Point(162, 22);
            this._cmbDestBPP.Name = "_cmbDestBPP";
            this._cmbDestBPP.Size = new System.Drawing.Size(86, 21);
            this._cmbDestBPP.TabIndex = 4;
            this._cmbDestBPP.SelectedIndexChanged += new System.EventHandler(this._cmbDestBPP_SelectedIndexChanged);
            // 
            // _lblSourceHighBit
            // 
            this._lblSourceHighBit.AutoSize = true;
            this._lblSourceHighBit.Location = new System.Drawing.Point(15, 121);
            this._lblSourceHighBit.Name = "_lblSourceHighBit";
            this._lblSourceHighBit.Size = new System.Drawing.Size(87, 13);
            this._lblSourceHighBit.TabIndex = 3;
            this._lblSourceHighBit.Text = "Source High Bit :";
            // 
            // _lblSourceLowBit
            // 
            this._lblSourceLowBit.AutoSize = true;
            this._lblSourceLowBit.Location = new System.Drawing.Point(15, 88);
            this._lblSourceLowBit.Name = "_lblSourceLowBit";
            this._lblSourceLowBit.Size = new System.Drawing.Size(85, 13);
            this._lblSourceLowBit.TabIndex = 2;
            this._lblSourceLowBit.Text = "Source Low Bit :";
            // 
            // _lblDestinationLowBit
            // 
            this._lblDestinationLowBit.AutoSize = true;
            this._lblDestinationLowBit.Location = new System.Drawing.Point(15, 58);
            this._lblDestinationLowBit.Name = "_lblDestinationLowBit";
            this._lblDestinationLowBit.Size = new System.Drawing.Size(104, 13);
            this._lblDestinationLowBit.TabIndex = 1;
            this._lblDestinationLowBit.Text = "Destination Low Bit :";
            // 
            // _lblDestinationBitsPerPixel
            // 
            this._lblDestinationBitsPerPixel.AutoSize = true;
            this._lblDestinationBitsPerPixel.Location = new System.Drawing.Point(15, 25);
            this._lblDestinationBitsPerPixel.Name = "_lblDestinationBitsPerPixel";
            this._lblDestinationBitsPerPixel.Size = new System.Drawing.Size(130, 13);
            this._lblDestinationBitsPerPixel.TabIndex = 0;
            this._lblDestinationBitsPerPixel.Text = "Destination Bits Per Pixel :";
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnCancel.Location = new System.Drawing.Point(150, 167);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(68, 22);
            this._btnCancel.TabIndex = 9;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnOk.Location = new System.Drawing.Point(66, 167);
            this._btnOk.Margin = new System.Windows.Forms.Padding(2);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(68, 22);
            this._btnOk.TabIndex = 8;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _lblMsg
            // 
            this._lblMsg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblMsg.Location = new System.Drawing.Point(11, 199);
            this._lblMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lblMsg.Name = "_lblMsg";
            this._lblMsg.Size = new System.Drawing.Size(208, 33);
            this._lblMsg.TabIndex = 10;
            this._lblMsg.Text = "Source Low Bit must be less than\r\nSource High Bit.\r\n";
            // 
            // ShiftDataDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 240);
            this.Controls.Add(this._lblMsg);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._gbShiftData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShiftDataDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shift Data";
            this.Load += new System.EventHandler(this.ShiftDataDialog_Load);
            this._gbShiftData.ResumeLayout(false);
            this._gbShiftData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numSourceHighBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSourceLowBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDestLowBit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbShiftData;
        private System.Windows.Forms.Label _lblSourceHighBit;
        private System.Windows.Forms.Label _lblSourceLowBit;
        private System.Windows.Forms.Label _lblDestinationLowBit;
        private System.Windows.Forms.Label _lblDestinationBitsPerPixel;
        private System.Windows.Forms.NumericUpDown _numSourceHighBit;
        private System.Windows.Forms.NumericUpDown _numSourceLowBit;
        private System.Windows.Forms.NumericUpDown _numDestLowBit;
        private System.Windows.Forms.ComboBox _cmbDestBPP;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Label _lblMsg;
    }
}