namespace MainDemo
{
    partial class LambdaConnectednessDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LambdaConnectednessDialog));
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._numLambda = new System.Windows.Forms.NumericUpDown();
         this.label1 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this._numLambda)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _numLambda
         // 
         resources.ApplyResources(this._numLambda, "_numLambda");
         this._numLambda.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this._numLambda.Name = "_numLambda";
         this._numLambda.Value = new decimal(new int[] {
            950,
            0,
            0,
            0});
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.Name = "label1";
         // 
         // LambdaConnectednessDialog
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.label1);
         this.Controls.Add(this._numLambda);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LambdaConnectednessDialog";
         this.ShowIcon = false;
         this.Load += new System.EventHandler(this.LambdaConnectednessDialog_Load);
         ((System.ComponentModel.ISupportInitialize)(this._numLambda)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.NumericUpDown _numLambda;
        private System.Windows.Forms.Label label1;
    }
}