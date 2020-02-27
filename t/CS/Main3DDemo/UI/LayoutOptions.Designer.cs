namespace Main3DDemo
{
   partial class LayoutOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutOptions));
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._interpolateAlwaysImage = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this._txtColumns = new Main3DDemo.NumericTextBox();
            this._txtRows = new Main3DDemo.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // _btnApply
            // 
            resources.ApplyResources(this._btnApply, "_btnApply");
            this._btnApply.Name = "_btnApply";
            this._btnApply.UseVisualStyleBackColor = true;
            this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._interpolateAlwaysImage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._txtColumns);
            this.groupBox1.Controls.Add(this._txtRows);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // _interpolateAlwaysImage
            // 
            resources.ApplyResources(this._interpolateAlwaysImage, "_interpolateAlwaysImage");
            this._interpolateAlwaysImage.Name = "_interpolateAlwaysImage";
            this._interpolateAlwaysImage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _txtColumns
            // 
            resources.ApplyResources(this._txtColumns, "_txtColumns");
            this._txtColumns.MaximumAllowed = 8;
            this._txtColumns.MinimumAllowed = 1;
            this._txtColumns.Name = "_txtColumns";
            this._txtColumns.Value = 1;
            // 
            // _txtRows
            // 
            resources.ApplyResources(this._txtRows, "_txtRows");
            this._txtRows.MaximumAllowed = 8;
            this._txtRows.MinimumAllowed = 1;
            this._txtRows.Name = "_txtRows";
            this._txtRows.Value = 1;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // LayoutOptions
            // 
            this.AcceptButton = this._btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._btnApply);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayoutOptions";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
       private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label3;
      private NumericTextBox _txtColumns;
       private NumericTextBox _txtRows;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.CheckBox _interpolateAlwaysImage;
    }
}