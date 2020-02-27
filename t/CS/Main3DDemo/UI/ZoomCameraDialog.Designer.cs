namespace Main3DDemo
{
    partial class ZoomCameraDialog
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
            this._btnReset = new System.Windows.Forms.Button();
            this._textBoxZoom = new Main3DDemo.NumericTextBox();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            _trackBarZoom = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(_trackBarZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "&Zoom";
            // 
            // _btnReset
            // 
            this._btnReset.Location = new System.Drawing.Point(169, 96);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(66, 33);
            this._btnReset.TabIndex = 36;
            this._btnReset.Text = "&Reset";
            this._btnReset.UseVisualStyleBackColor = true;
            this._btnReset.Click += new System.EventHandler(this._btnReset_Click);
            // 
            // _textBoxZoom
            // 
            this._textBoxZoom.Location = new System.Drawing.Point(177, 23);
            this._textBoxZoom.MaximumAllowed = 100;
            this._textBoxZoom.MinimumAllowed = 1;
            this._textBoxZoom.Name = "_textBoxZoom";
            this._textBoxZoom.Size = new System.Drawing.Size(50, 20);
            this._textBoxZoom.TabIndex = 33;
            this._textBoxZoom.Text = "1";
            this._textBoxZoom.Value = 1;
            this._textBoxZoom.TextChanged += new System.EventHandler(this._textBoxZoom_TextChanged);
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(21, 96);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(66, 33);
            this._btnOK.TabIndex = 34;
            this._btnOK.Text = "&OK";
            this._btnOK.UseVisualStyleBackColor = true;
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(95, 96);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(66, 33);
            this._btnCancel.TabIndex = 35;
            this._btnCancel.Text = "&Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this._textBoxZoom);
            this.groupBox1.Controls.Add(_trackBarZoom);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 68);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Parameter";
            // 
            // _trackBarZoom
            // 
            _trackBarZoom.Location = new System.Drawing.Point(38, 21);
            _trackBarZoom.Maximum = 100;
            _trackBarZoom.Minimum = 1;
            _trackBarZoom.Name = "_trackBarZoom";
            _trackBarZoom.Size = new System.Drawing.Size(135, 45);
            _trackBarZoom.TabIndex = 31;
            _trackBarZoom.TickFrequency = 0;
            _trackBarZoom.TickStyle = System.Windows.Forms.TickStyle.None;
            _trackBarZoom.Value = 100;
            _trackBarZoom.ValueChanged += new System.EventHandler(this._trackBarZoom_Scroll);
            // 
            // ZoomCameraDialog
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(261, 146);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZoomCameraDialog";
            this.Text = "Zoom Dialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(_trackBarZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar _trackBarZoom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _btnReset;
        private NumericTextBox _textBoxZoom;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}