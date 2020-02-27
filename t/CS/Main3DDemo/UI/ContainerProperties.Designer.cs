namespace Main3DDemo
{
    partial class ContainerProperties
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContainerProperties));
         this._btnReset = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._btnApply = new System.Windows.Forms.Button();
         this._tabCamera = new System.Windows.Forms.TabPage();
            this._txtCameraFar = new Main3DDemo.NumericTextBox();
            this._txtCameraNear = new Main3DDemo.NumericTextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this._comboBoxProjectionMethod = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this._tabMPR = new System.Windows.Forms.TabPage();
         this._chkRemoveBackground = new System.Windows.Forms.CheckBox();
         this._chkIntersectionLine = new System.Windows.Forms.CheckBox();
         this._btnIntersectionLineColor = new System.Windows.Forms.Button();
         this._chkFrameBoundary = new System.Windows.Forms.CheckBox();
         this._btnFrameBoundaryColor = new System.Windows.Forms.Button();
            this._lblIntersectionLineColor = new Main3DDemo.ColorBox();
            this._lblFrameBoundaryColor = new Main3DDemo.ColorBox();
         this._tabGeneral = new System.Windows.Forms.TabPage();
            this._lblBackgroundColor = new Main3DDemo.ColorBox();
         this._btnBackgroundColor = new System.Windows.Forms.Button();
         this._chkBoundaryBox = new System.Windows.Forms.CheckBox();
            this._lblBoundaryBoxColor = new Main3DDemo.ColorBox();
         this._btnBoundaryBoxColor = new System.Windows.Forms.Button();
         this._tabControl = new System.Windows.Forms.TabControl();
         this._tabCamera.SuspendLayout();
         this._tabMPR.SuspendLayout();
         this._tabGeneral.SuspendLayout();
         this._tabControl.SuspendLayout();
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
         // _btnApply
         // 
         resources.ApplyResources(this._btnApply, "_btnApply");
         this._btnApply.Name = "_btnApply";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // _tabCamera
         // 
            this._tabCamera.Controls.Add(this._txtCameraFar);
            this._tabCamera.Controls.Add(this._txtCameraNear);
         this._tabCamera.Controls.Add(this.label2);
         this._tabCamera.Controls.Add(this.label5);
         this._tabCamera.Controls.Add(this._comboBoxProjectionMethod);
         this._tabCamera.Controls.Add(this.label1);
         resources.ApplyResources(this._tabCamera, "_tabCamera");
         this._tabCamera.Name = "_tabCamera";
         this._tabCamera.UseVisualStyleBackColor = true;
         // 
            // _txtCameraFar
            // 
            resources.ApplyResources(this._txtCameraFar, "_txtCameraFar");
            this._txtCameraFar.MaximumAllowed = 1000;
            this._txtCameraFar.MinimumAllowed = -1000;
            this._txtCameraFar.Name = "_txtCameraFar";
            this._txtCameraFar.Value = 0;
            // 
            // _txtCameraNear
            // 
            resources.ApplyResources(this._txtCameraNear, "_txtCameraNear");
            this._txtCameraNear.MaximumAllowed = 1000;
            this._txtCameraNear.MinimumAllowed = -1000;
            this._txtCameraNear.Name = "_txtCameraNear";
            this._txtCameraNear.Value = 0;
            // 
         // label2
         // 
         resources.ApplyResources(this.label2, "label2");
         this.label2.Name = "label2";
         // 
         // label5
         // 
         resources.ApplyResources(this.label5, "label5");
         this.label5.Name = "label5";
         // 
         // _comboBoxProjectionMethod
         // 
         this._comboBoxProjectionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboBoxProjectionMethod.FormattingEnabled = true;
         this._comboBoxProjectionMethod.Items.AddRange(new object[] {
            resources.GetString("_comboBoxProjectionMethod.Items"),
            resources.GetString("_comboBoxProjectionMethod.Items1")});
         resources.ApplyResources(this._comboBoxProjectionMethod, "_comboBoxProjectionMethod");
         this._comboBoxProjectionMethod.Name = "_comboBoxProjectionMethod";
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.Name = "label1";
         // 
         // _tabMPR
         // 
         this._tabMPR.Controls.Add(this._chkRemoveBackground);
         this._tabMPR.Controls.Add(this._chkIntersectionLine);
         this._tabMPR.Controls.Add(this._btnIntersectionLineColor);
         this._tabMPR.Controls.Add(this._chkFrameBoundary);
         this._tabMPR.Controls.Add(this._btnFrameBoundaryColor);
            this._tabMPR.Controls.Add(this._lblIntersectionLineColor);
            this._tabMPR.Controls.Add(this._lblFrameBoundaryColor);
         resources.ApplyResources(this._tabMPR, "_tabMPR");
         this._tabMPR.Name = "_tabMPR";
         this._tabMPR.UseVisualStyleBackColor = true;
         // 
         // _chkRemoveBackground
         // 
         resources.ApplyResources(this._chkRemoveBackground, "_chkRemoveBackground");
         this._chkRemoveBackground.Name = "_chkRemoveBackground";
         this._chkRemoveBackground.UseVisualStyleBackColor = true;
         // 
         // _chkIntersectionLine
         // 
         resources.ApplyResources(this._chkIntersectionLine, "_chkIntersectionLine");
         this._chkIntersectionLine.Name = "_chkIntersectionLine";
         this._chkIntersectionLine.UseVisualStyleBackColor = true;
         this._chkIntersectionLine.CheckedChanged += new System.EventHandler(this._chkIntersectionLine_CheckedChanged);
         // 
         // _btnIntersectionLineColor
         // 
         resources.ApplyResources(this._btnIntersectionLineColor, "_btnIntersectionLineColor");
         this._btnIntersectionLineColor.Name = "_btnIntersectionLineColor";
         this._btnIntersectionLineColor.UseVisualStyleBackColor = true;
         this._btnIntersectionLineColor.Click += new System.EventHandler(this._btnIntersectionLineColor_Click);
         // 
         // _chkFrameBoundary
         // 
         resources.ApplyResources(this._chkFrameBoundary, "_chkFrameBoundary");
         this._chkFrameBoundary.Name = "_chkFrameBoundary";
         this._chkFrameBoundary.UseVisualStyleBackColor = true;
         this._chkFrameBoundary.CheckedChanged += new System.EventHandler(this._chkFrameBoundary_CheckedChanged);
         // 
         // _btnFrameBoundaryColor
         // 
         resources.ApplyResources(this._btnFrameBoundaryColor, "_btnFrameBoundaryColor");
         this._btnFrameBoundaryColor.Name = "_btnFrameBoundaryColor";
         this._btnFrameBoundaryColor.UseVisualStyleBackColor = true;
         this._btnFrameBoundaryColor.Click += new System.EventHandler(this._btnFrameBoundaryColor_Click);
         // 
            // _lblIntersectionLineColor
            // 
            this._lblIntersectionLineColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._lblIntersectionLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblIntersectionLineColor.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this._lblIntersectionLineColor, "_lblIntersectionLineColor");
            this._lblIntersectionLineColor.Name = "_lblIntersectionLineColor";
            // 
            // _lblFrameBoundaryColor
            // 
            this._lblFrameBoundaryColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._lblFrameBoundaryColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblFrameBoundaryColor.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this._lblFrameBoundaryColor, "_lblFrameBoundaryColor");
            this._lblFrameBoundaryColor.Name = "_lblFrameBoundaryColor";
            // 
         // _tabGeneral
         // 
            this._tabGeneral.Controls.Add(this._lblBackgroundColor);
         this._tabGeneral.Controls.Add(this._btnBackgroundColor);
         this._tabGeneral.Controls.Add(this._chkBoundaryBox);
            this._tabGeneral.Controls.Add(this._lblBoundaryBoxColor);
         this._tabGeneral.Controls.Add(this._btnBoundaryBoxColor);
         resources.ApplyResources(this._tabGeneral, "_tabGeneral");
         this._tabGeneral.Name = "_tabGeneral";
         this._tabGeneral.UseVisualStyleBackColor = true;
         // 
            // _lblBackgroundColor
            // 
            this._lblBackgroundColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._lblBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblBackgroundColor.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this._lblBackgroundColor, "_lblBackgroundColor");
            this._lblBackgroundColor.Name = "_lblBackgroundColor";
            // 
         // _btnBackgroundColor
         // 
         resources.ApplyResources(this._btnBackgroundColor, "_btnBackgroundColor");
         this._btnBackgroundColor.Name = "_btnBackgroundColor";
         this._btnBackgroundColor.UseVisualStyleBackColor = true;
         this._btnBackgroundColor.Click += new System.EventHandler(this._btnBackgroundColor_Click);
         // 
         // _chkBoundaryBox
         // 
         resources.ApplyResources(this._chkBoundaryBox, "_chkBoundaryBox");
         this._chkBoundaryBox.Name = "_chkBoundaryBox";
         this._chkBoundaryBox.UseVisualStyleBackColor = true;
         this._chkBoundaryBox.CheckedChanged += new System.EventHandler(this._chkBoundaryBox_CheckedChanged);
         // 
            // _lblBoundaryBoxColor
            // 
            this._lblBoundaryBoxColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._lblBoundaryBoxColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblBoundaryBoxColor.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this._lblBoundaryBoxColor, "_lblBoundaryBoxColor");
            this._lblBoundaryBoxColor.Name = "_lblBoundaryBoxColor";
            // 
         // _btnBoundaryBoxColor
         // 
         resources.ApplyResources(this._btnBoundaryBoxColor, "_btnBoundaryBoxColor");
         this._btnBoundaryBoxColor.Name = "_btnBoundaryBoxColor";
         this._btnBoundaryBoxColor.UseVisualStyleBackColor = true;
         this._btnBoundaryBoxColor.Click += new System.EventHandler(this._btnBoundaryBoxColor_Click);
         // 
         // _tabControl
         // 
         this._tabControl.Controls.Add(this._tabGeneral);
         this._tabControl.Controls.Add(this._tabMPR);
         this._tabControl.Controls.Add(this._tabCamera);
         resources.ApplyResources(this._tabControl, "_tabControl");
         this._tabControl.Name = "_tabControl";
         this._tabControl.SelectedIndex = 0;
         // 
         // ContainerProperties
         // 
         this.AcceptButton = this._btnOK;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._btnReset);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._tabControl);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ContainerProperties";
         this._tabCamera.ResumeLayout(false);
         this._tabCamera.PerformLayout();
         this._tabMPR.ResumeLayout(false);
         this._tabMPR.PerformLayout();
         this._tabGeneral.ResumeLayout(false);
         this._tabGeneral.PerformLayout();
         this._tabControl.ResumeLayout(false);
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnReset;
        private System.Windows.Forms.Button _btnCancel;
       private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnApply;
       private System.Windows.Forms.TabPage _tabCamera;
       private NumericTextBox _txtCameraFar;
       private NumericTextBox _txtCameraNear;
       private System.Windows.Forms.Label label2;
       private System.Windows.Forms.Label label5;
       private System.Windows.Forms.ComboBox _comboBoxProjectionMethod;
       private System.Windows.Forms.Label label1;
       private System.Windows.Forms.TabPage _tabMPR;
       private System.Windows.Forms.CheckBox _chkRemoveBackground;
       private System.Windows.Forms.CheckBox _chkIntersectionLine;
       private System.Windows.Forms.Button _btnIntersectionLineColor;
       private System.Windows.Forms.CheckBox _chkFrameBoundary;
       private System.Windows.Forms.Button _btnFrameBoundaryColor;
       private ColorBox _lblIntersectionLineColor;
        private ColorBox _lblFrameBoundaryColor;
       private System.Windows.Forms.TabPage _tabGeneral;
       private ColorBox _lblBackgroundColor;
       private System.Windows.Forms.Button _btnBackgroundColor;
       private System.Windows.Forms.CheckBox _chkBoundaryBox;
       private ColorBox _lblBoundaryBoxColor;
       private System.Windows.Forms.Button _btnBoundaryBoxColor;
       private System.Windows.Forms.TabControl _tabControl;
    }
}