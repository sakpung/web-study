namespace MainDemo
{
    partial class GWireDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GWireDialog));
         this._btnOk = new System.Windows.Forms.Button();
         this._numExternal = new System.Windows.Forms.NumericUpDown();
         this._bntApply = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.textBox1 = new System.Windows.Forms.TextBox();
         ((System.ComponentModel.ISupportInitialize)(this._numExternal)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _numExternal
         // 
         resources.ApplyResources(this._numExternal, "_numExternal");
         this._numExternal.Name = "_numExternal";
         this._numExternal.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
         // 
         // _bntApply
         // 
         resources.ApplyResources(this._bntApply, "_bntApply");
         this._bntApply.Name = "_bntApply";
         this._bntApply.UseVisualStyleBackColor = true;
         this._bntApply.Click += new System.EventHandler(this._bntApply_Click);
         // 
         // label2
         // 
         resources.ApplyResources(this.label2, "label2");
         this.label2.Name = "label2";
         //
         // textBox1
 	      //
 	      resources.ApplyResources(this.textBox1, "textBox1");
 	      this.textBox1.Name = "textBox1";
 	      this.textBox1.ReadOnly = true;
         // 
         // GWireDialog
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this._bntApply);
         this.Controls.Add(this._numExternal);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "GWireDialog";
         this.ShowIcon = false;
         this.TopMost = true;
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GWireDialog_FormClosing);
         ((System.ComponentModel.ISupportInitialize)(this._numExternal)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.NumericUpDown _numExternal;
        private System.Windows.Forms.Button _bntApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}