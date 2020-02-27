namespace MainDemo
{
    partial class ShrinkWrapDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShrinkWrapDialog));
            this._btnCancel = new System.Windows.Forms.Button();
            this._gbParameters = new System.Windows.Forms.GroupBox();
            this._cbCombine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._cbType = new System.Windows.Forms.ComboBox();
            this._numThreshold = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._btnApply = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._gbParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnCancel
            // 
            resources.ApplyResources(this._btnCancel, "_btnCancel");
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _gbParameters
            // 
            this._gbParameters.Controls.Add(this._cbCombine);
            this._gbParameters.Controls.Add(this.label3);
            this._gbParameters.Controls.Add(this._cbType);
            this._gbParameters.Controls.Add(this._numThreshold);
            this._gbParameters.Controls.Add(this.label1);
            this._gbParameters.Controls.Add(this.label2);
            resources.ApplyResources(this._gbParameters, "_gbParameters");
            this._gbParameters.Name = "_gbParameters";
            this._gbParameters.TabStop = false;
            // 
            // _cbCombine
            // 
            this._cbCombine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbCombine.FormattingEnabled = true;
            this._cbCombine.Items.AddRange(new object[] {
            resources.GetString("_cbCombine.Items"),
            resources.GetString("_cbCombine.Items1"),
            resources.GetString("_cbCombine.Items2"),
            resources.GetString("_cbCombine.Items3"),
            resources.GetString("_cbCombine.Items4"),
            resources.GetString("_cbCombine.Items5"),
            resources.GetString("_cbCombine.Items6")});
            resources.ApplyResources(this._cbCombine, "_cbCombine");
            this._cbCombine.Name = "_cbCombine";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _cbType
            // 
            this._cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbType.FormattingEnabled = true;
            this._cbType.Items.AddRange(new object[] {
            resources.GetString("_cbType.Items"),
            resources.GetString("_cbType.Items1")});
            resources.ApplyResources(this._cbType, "_cbType");
            this._cbType.Name = "_cbType";
            // 
            // _numThreshold
            // 
            resources.ApplyResources(this._numThreshold, "_numThreshold");
            this._numThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numThreshold.Name = "_numThreshold";
            this._numThreshold.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _btnApply
            // 
            resources.ApplyResources(this._btnApply, "_btnApply");
            this._btnApply.Name = "_btnApply";
            this._btnApply.UseVisualStyleBackColor = true;
            this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
            // 
            // textBox1
 	         //
 	         resources.ApplyResources(this.textBox1, "textBox1");
 	         this.textBox1.Name = "textBox1";
 	         this.textBox1.ReadOnly = true;
 	         //
            // ShrinkWrapDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this._btnApply);
            this.Controls.Add(this._gbParameters);
            this.Controls.Add(this._btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShrinkWrapDialog";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShrinkWrapDialog_FormClosing);
            this._gbParameters.ResumeLayout(false);
            this._gbParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.GroupBox _gbParameters;
        private System.Windows.Forms.ComboBox _cbType;
        private System.Windows.Forms.NumericUpDown _numThreshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btnApply;
        private System.Windows.Forms.ComboBox _cbCombine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}