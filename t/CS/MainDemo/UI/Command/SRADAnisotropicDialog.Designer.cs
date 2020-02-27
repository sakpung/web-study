namespace MainDemo
{
    partial class SRADAnisotropicDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SRADAnisotropicDialog));
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label4 = new System.Windows.Forms.Label();
         this._numIterations = new System.Windows.Forms.NumericUpDown();
         this.label1 = new System.Windows.Forms.Label();
         this._numLambda = new System.Windows.Forms.NumericUpDown();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numIterations)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLambda)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnOK
         // 
         resources.ApplyResources(this._btnOK, "_btnOK");
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Name = "_btnOK";
         this._btnOK.UseVisualStyleBackColor = true;
         // 
         // _btnCancel
         // 
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         resources.ApplyResources(this.groupBox1, "groupBox1");
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this._numIterations);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this._numLambda);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.TabStop = false;
         // 
         // label4
         // 
         resources.ApplyResources(this.label4, "label4");
         this.label4.Name = "label4";
         // 
         // _numIterations
         // 
         resources.ApplyResources(this._numIterations, "_numIterations");
         this._numIterations.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
         this._numIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numIterations.Name = "_numIterations";
         this._numIterations.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.Name = "label1";
         // 
         // _numLambda
         // 
         resources.ApplyResources(this._numLambda, "_numLambda");
         this._numLambda.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numLambda.Name = "_numLambda";
         this._numLambda.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
         // 
         // SRADAnisotropicDialog
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SRADAnisotropicDialog";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SRADAnisotropicDialog_FormClosing);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numIterations)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLambda)).EndInit();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _numLambda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown _numIterations;
    }
}