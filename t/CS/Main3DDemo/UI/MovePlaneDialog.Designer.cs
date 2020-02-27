namespace Main3DDemo
{
    partial class MovePlaneDialog
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
            this.label4 = new System.Windows.Forms.Label();
            this._textBoxY = new Main3DDemo.NumericTextBox();
            this._btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnReset = new System.Windows.Forms.Button();
            _trackBarY = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(_trackBarY)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "&Position";
            // 
            // _textBoxY
            // 
            this._textBoxY.Location = new System.Drawing.Point(192, 22);
            this._textBoxY.MaximumAllowed = 1000;
            this._textBoxY.MinimumAllowed = -1000;
            this._textBoxY.Name = "_textBoxY";
            this._textBoxY.Size = new System.Drawing.Size(50, 20);
            this._textBoxY.TabIndex = 33;
            this._textBoxY.Text = "0";
            this._textBoxY.Value = 0;
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(107, 91);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(66, 26);
            this._btnCancel.TabIndex = 39;
            this._btnCancel.Text = "&Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this._textBoxY);
            this.groupBox1.Controls.Add(_trackBarY);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 70);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Transform Parameters";
            // 
            // _trackBarY
            // 
            _trackBarY.Location = new System.Drawing.Point(53, 22);
            _trackBarY.Maximum = 1000;
            _trackBarY.Minimum = -1000;
            _trackBarY.Name = "_trackBarY";
            _trackBarY.Size = new System.Drawing.Size(135, 45);
            _trackBarY.TabIndex = 31;
            _trackBarY.TickFrequency = 0;
            _trackBarY.TickStyle = System.Windows.Forms.TickStyle.None;
            _trackBarY.Value = -1000;
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(33, 91);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(66, 26);
            this._btnOK.TabIndex = 38;
            this._btnOK.Text = "&OK";
            this._btnOK.UseVisualStyleBackColor = true;
            // 
            // _btnReset
            // 
            this._btnReset.Location = new System.Drawing.Point(181, 91);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(66, 26);
            this._btnReset.TabIndex = 40;
            this._btnReset.Text = "&Reset";
            this._btnReset.UseVisualStyleBackColor = true;
            // 
            // MovePlaneDialog
            // 
            this.AcceptButton = this._btnOK;
            this.CancelButton = this._btnCancel;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 131);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnReset);
            this.Name = "MovePlaneDialog";
            this.Text = "Move Plane Dialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(_trackBarY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        System.Windows.Forms.TrackBar _trackBarY;
        private NumericTextBox _textBoxY;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnReset;
    }
}