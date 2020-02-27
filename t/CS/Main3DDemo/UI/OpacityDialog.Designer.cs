namespace Main3DDemo
{
    partial class OpacityDialog
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
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._trackBarOpacity = new System.Windows.Forms.TrackBar();
            this._textBoxOpacity = new Main3DDemo.NumericTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "&Opacity";
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
            this.groupBox1.Controls.Add(this._textBoxOpacity);
            this.groupBox1.Controls.Add(this._trackBarOpacity);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 68);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Parameter";
            // 
            // _trackBarOpacity
            // 
            this._trackBarOpacity.Location = new System.Drawing.Point(45, 22);
            this._trackBarOpacity.Maximum = 100 ;
            this._trackBarOpacity.Minimum = 0;
            this._trackBarOpacity.Name = "_trackBarOpacity";
            this._trackBarOpacity.Size = new System.Drawing.Size(135, 45);
            this._trackBarOpacity.TabIndex = 31;
            this._trackBarOpacity.TickFrequency = 0;
            this._trackBarOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this._trackBarOpacity.Value = 100;
            this._trackBarOpacity.ValueChanged += new System.EventHandler(this._trackBarOpacity_Scroll);
            // 
            // _textBoxOpacity
            // 
            this._textBoxOpacity.Location = new System.Drawing.Point(184, 24);
            this._textBoxOpacity.MaximumAllowed = 100;
            this._textBoxOpacity.MinimumAllowed = 0;
            this._textBoxOpacity.Name = "_textBoxOpacity";
            this._textBoxOpacity.Size = new System.Drawing.Size(44, 20);
            this._textBoxOpacity.TabIndex = 33;
            this._textBoxOpacity.Text = "1";
            this._textBoxOpacity.Value = 1;
            this._textBoxOpacity.TextChanged += new System.EventHandler(this._textBoxOpacity_TextChanged);
            // 
            // OpacityDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 146);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpacityDialog";
            this.Text = "Opacity Dialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar _trackBarOpacity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _btnReset;
        private NumericTextBox _textBoxOpacity;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}