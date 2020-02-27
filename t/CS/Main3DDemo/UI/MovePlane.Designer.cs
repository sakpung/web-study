namespace Main3DDemo
{
    partial class MovePlane
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
           this.groupBox1 = new System.Windows.Forms.GroupBox();
           this.label7 = new System.Windows.Forms.Label();
           this._txtMovePlane = new Main3DDemo.NumericTextBox();
           this._btnOK = new System.Windows.Forms.Button();
           this._btnCancel = new System.Windows.Forms.Button();
           _trackBarMovePlane = new System.Windows.Forms.TrackBar();
           this.groupBox1.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(_trackBarMovePlane)).BeginInit();
           this.SuspendLayout();
           // 
           // groupBox1
           // 
           this.groupBox1.Controls.Add(_trackBarMovePlane);
           this.groupBox1.Controls.Add(this.label7);
           this.groupBox1.Controls.Add(this._txtMovePlane);
           this.groupBox1.Location = new System.Drawing.Point(12, 12);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Size = new System.Drawing.Size(292, 78);
           this.groupBox1.TabIndex = 1;
           this.groupBox1.TabStop = false;
           // 
           // _trackBarMovePlane
           // 
           _trackBarMovePlane.Location = new System.Drawing.Point(83, 25);
           _trackBarMovePlane.Maximum = 1000;
           _trackBarMovePlane.Minimum = -1000;
           _trackBarMovePlane.Name = "_trackBarMovePlane";
           _trackBarMovePlane.Size = new System.Drawing.Size(135, 45);
           _trackBarMovePlane.TabIndex = 35;
           _trackBarMovePlane.TickFrequency = 0;
           _trackBarMovePlane.TickStyle = System.Windows.Forms.TickStyle.None;
           _trackBarMovePlane.ValueChanged += new System.EventHandler(this._trackBarMovePlane_Scroll);
           // 
           // label7
           // 
           this.label7.AutoSize = true;
           this.label7.Location = new System.Drawing.Point(13, 32);
           this.label7.Name = "label7";
           this.label7.Size = new System.Drawing.Size(62, 13);
           this.label7.TabIndex = 9;
           this.label7.Text = "&Move Plane";
           // 
           // _txtMovePlane
           // 
           this._txtMovePlane.Location = new System.Drawing.Point(224, 29);
           this._txtMovePlane.MaximumAllowed = 1000;
           this._txtMovePlane.MinimumAllowed = -1000;
           this._txtMovePlane.Name = "_txtMovePlane";
           this._txtMovePlane.Size = new System.Drawing.Size(50, 20);
           this._txtMovePlane.TabIndex = 8;
           this._txtMovePlane.Text = "0";
           this._txtMovePlane.Value = 0;
           this._txtMovePlane.TextChanged += new System.EventHandler(this._txtMovePlane_TextChanged);
           // 
           // _btnOK
           // 
           this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
           this._btnOK.Location = new System.Drawing.Point(60, 105);
           this._btnOK.Name = "_btnOK";
           this._btnOK.Size = new System.Drawing.Size(90, 27);
           this._btnOK.TabIndex = 36;
           this._btnOK.Text = "&OK";
           this._btnOK.UseVisualStyleBackColor = true;
           this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
           // 
           // _btnCancel
           // 
           this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this._btnCancel.Location = new System.Drawing.Point(156, 105);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(90, 27);
           this._btnCancel.TabIndex = 37;
           this._btnCancel.Text = "&Cancel";
           this._btnCancel.UseVisualStyleBackColor = true;
           this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
           // 
           // MovePlane
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(316, 148);
           this.Controls.Add(this._btnOK);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this.groupBox1);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "MovePlane";
           this.Text = "Move Plane";
           this.groupBox1.ResumeLayout(false);
           this.groupBox1.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(_trackBarMovePlane)).EndInit();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label label7;
        System.Windows.Forms.TrackBar _trackBarMovePlane;
        private NumericTextBox _txtMovePlane;
    }
}