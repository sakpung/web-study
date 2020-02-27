#if LEADTOOLS_V20_OR_LATER
namespace MainDemo
{
   partial class WienerFilterDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WienerFilterDialog));
         this._btnApply = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._btnReset = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.labelP1 = new System.Windows.Forms.Label();
         this.labelP2 = new System.Windows.Forms.Label();
         this._gbPolygonPoints = new System.Windows.Forms.GroupBox();
         this._cbP3 = new System.Windows.Forms.ComboBox();
         this.labelP3 = new System.Windows.Forms.Label();
         this._numSecondP = new System.Windows.Forms.TextBox();
         this._numFirstP = new System.Windows.Forms.TextBox();
         this._numNSR = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this._gbPolygonPoints.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnApply
         // 
         resources.ApplyResources(this._btnApply, "_btnApply");
         this._btnApply.Name = "_btnApply";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._bntApply_Click);
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOK, "_btnOK");
         this._btnOK.Name = "_btnOK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
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
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // labelP1
         // 
         resources.ApplyResources(this.labelP1, "labelP1");
         this.labelP1.Name = "labelP1";
         // 
         // labelP2
         // 
         resources.ApplyResources(this.labelP2, "labelP2");
         this.labelP2.Name = "labelP2";
         // 
         // _gbPolygonPoints
         // 
         this._gbPolygonPoints.Controls.Add(this._cbP3);
         this._gbPolygonPoints.Controls.Add(this.labelP3);
         this._gbPolygonPoints.Controls.Add(this._numSecondP);
         this._gbPolygonPoints.Controls.Add(this._numFirstP);
         this._gbPolygonPoints.Controls.Add(this.labelP1);
         this._gbPolygonPoints.Controls.Add(this.labelP2);
         resources.ApplyResources(this._gbPolygonPoints, "_gbPolygonPoints");
         this._gbPolygonPoints.Name = "_gbPolygonPoints";
         this._gbPolygonPoints.TabStop = false;
         // 
         // _cbP3
         // 
         this._cbP3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cbP3, "_cbP3");
         this._cbP3.Name = "_cbP3";
         this._cbP3.SelectedIndexChanged += new System.EventHandler(this.WienerFilter_ChangeLabels);
         // 
         // labelP3
         // 
         resources.ApplyResources(this.labelP3, "labelP3");
         this.labelP3.Name = "labelP3";
         // 
         // _numSecondP
         // 
         resources.ApplyResources(this._numSecondP, "_numSecondP");
         this._numSecondP.Name = "_numSecondP";
         // 
         // _numFirstP
         // 
         resources.ApplyResources(this._numFirstP, "_numFirstP");
         this._numFirstP.Name = "_numFirstP";
         // 
         // _numNSR
         // 
         resources.ApplyResources(this._numNSR, "_numNSR");
         this._numNSR.Name = "_numNSR";
         // 
         // label4
         // 
         resources.ApplyResources(this.label4, "label4");
         this.label4.Name = "label4";
         // 
         // WienerFilterDialog
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._numNSR);
         this.Controls.Add(this.label4);
         this.Controls.Add(this._gbPolygonPoints);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnReset);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._btnApply);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "WienerFilterDialog";
         this.TopMost = true;
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WienerFilterDialog_FormClosing);
         this.Load += new System.EventHandler(this.WienerFilterDialog_Load);
         this._gbPolygonPoints.ResumeLayout(false);
         this._gbPolygonPoints.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnApply;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnReset;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label labelP1;
        private System.Windows.Forms.Label labelP2;
        private System.Windows.Forms.GroupBox _gbPolygonPoints;
        private System.Windows.Forms.TextBox _numSecondP;
        private System.Windows.Forms.TextBox _numFirstP;
        private System.Windows.Forms.TextBox _numNSR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _cbP3;
        private System.Windows.Forms.Label labelP3;
    }
}
#endif //#if LEADTOOLS_V20_OR_LATER