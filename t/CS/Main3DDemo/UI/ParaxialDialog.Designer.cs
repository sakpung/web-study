namespace Main3DDemo
{
   partial class ParaxialDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParaxialDialog));
            this._btnReset = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._lengthLbl = new System.Windows.Forms.Label();
            this._distanceLbl = new System.Windows.Forms.Label();
            this._textBoxLength = new Main3DDemo.NumericTextBox();
            this._textBoxDistance = new Main3DDemo.NumericTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnReset
            // 
            resources.ApplyResources(this._btnReset, "_btnReset");
            this._btnReset.Name = "_btnReset";
            this._btnReset.UseVisualStyleBackColor = true;
            this._btnReset.Click += new System.EventHandler(this._btnReset_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._btnCancel, "_btnCancel");
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this._btnOK, "_btnOK");
            this._btnOK.Name = "_btnOK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._lengthLbl);
            this.groupBox1.Controls.Add(this._distanceLbl);
            this.groupBox1.Controls.Add(this._textBoxLength);
            this.groupBox1.Controls.Add(this._textBoxDistance);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // _lengthLbl
            // 
            resources.ApplyResources(this._lengthLbl, "_lengthLbl");
            this._lengthLbl.Name = "_lengthLbl";
            // 
            // _distanceLbl
            // 
            resources.ApplyResources(this._distanceLbl, "_distanceLbl");
            this._distanceLbl.Name = "_distanceLbl";
            // 
            // _textBoxLength
            // 
            resources.ApplyResources(this._textBoxLength, "_textBoxLength");
            this._textBoxLength.MaximumAllowed = 1000;
            this._textBoxLength.MinimumAllowed = 1;
            this._textBoxLength.Name = "_textBoxLength";
            this._textBoxLength.Value = 1;
            // 
            // _textBoxDistance
            // 
            resources.ApplyResources(this._textBoxDistance, "_textBoxDistance");
            this._textBoxDistance.MaximumAllowed = 1000;
            this._textBoxDistance.MinimumAllowed = 1;
            this._textBoxDistance.Name = "_textBoxDistance";
            this._textBoxDistance.Value = 1;
            // 
            // ParaxialDialog
            // 
            this.AcceptButton = this._btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParaxialDialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnReset;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private NumericTextBox _textBoxLength;
        private NumericTextBox _textBoxDistance;
        private System.Windows.Forms.Label _lengthLbl;
        private System.Windows.Forms.Label _distanceLbl;
    }
}