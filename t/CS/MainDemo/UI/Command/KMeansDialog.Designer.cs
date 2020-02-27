namespace MainDemo
{
    partial class KMeansDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KMeansDialog));
            this.label1 = new System.Windows.Forms.Label();
            this._numClusters = new System.Windows.Forms.NumericUpDown();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._cbType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._numClusters)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _numClusters
            // 
            resources.ApplyResources(this._numClusters, "_numClusters");
            this._numClusters.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numClusters.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._numClusters.Name = "_numClusters";
            this._numClusters.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._btnCancel, "_btnCancel");
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this._btnOk, "_btnOk");
            this._btnOk.Name = "_btnOk";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
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
            // KMeansDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._cbType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._numClusters);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KMeansDialog";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this._numClusters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _numClusters;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cbType;
    }
}