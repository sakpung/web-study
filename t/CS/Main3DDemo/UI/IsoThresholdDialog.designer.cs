namespace Main3DDemo
{
    partial class IsoThresholdDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IsoThresholdDialog));
            this.label4 = new System.Windows.Forms.Label();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._textBoxThreshold = new Main3DDemo.NumericTextBox();
            this._trackThreshold = new System.Windows.Forms.TrackBar();
            this._btnApply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trackThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // _btnReset
            // 
            resources.ApplyResources(this._btnReset, "_btnReset");
            this._btnReset.Name = "_btnReset";
            this._btnReset.UseVisualStyleBackColor = true;
            this._btnReset.Click += new System.EventHandler(this._btnReset_Click);
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this._btnOK, "_btnOK");
            this._btnOK.Name = "_btnOK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._btnCancel, "_btnCancel");
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this._textBoxThreshold);
            this.groupBox1.Controls.Add(this._trackThreshold);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // _textBoxThreshold
            // 
            resources.ApplyResources(this._textBoxThreshold, "_textBoxThreshold");
            this._textBoxThreshold.MaximumAllowed = 255;
            this._textBoxThreshold.MinimumAllowed = 1;
            this._textBoxThreshold.Name = "_textBoxThreshold";
            this._textBoxThreshold.Value = 1;
            this._textBoxThreshold.TextChanged += new System.EventHandler(this._textBoxOpacity_TextChanged);
            // 
            // _trackThreshold
            // 
            resources.ApplyResources(this._trackThreshold, "_trackThreshold");
            this._trackThreshold.Maximum = 255;
            this._trackThreshold.Minimum = 1;
            this._trackThreshold.Name = "_trackThreshold";
            this._trackThreshold.TickFrequency = 0;
            this._trackThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this._trackThreshold.Value = 100;
            this._trackThreshold.ValueChanged += new System.EventHandler(this._trackBarOpacity_Scroll);
            // 
            // _btnApply
            // 
            resources.ApplyResources(this._btnApply, "_btnApply");
            this._btnApply.Name = "_btnApply";
            this._btnApply.UseVisualStyleBackColor = true;
            this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
            // 
            // IsoThresholdDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._btnApply);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IsoThresholdDialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trackThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar _trackThreshold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _btnReset;
        private NumericTextBox _textBoxThreshold;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnApply;
    }
}