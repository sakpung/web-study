namespace Main3DDemo
{
    partial class Histogram3DDialog
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
            this.components = new System.ComponentModel.Container();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._graident = new System.Windows.Forms.Label();
            this._txtYPos = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._txtXPos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._radMoveHist = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this._radMove = new System.Windows.Forms.RadioButton();
            this._radZoom = new System.Windows.Forms.RadioButton();
            this._maxHistogram = new System.Windows.Forms.Label();
            this._minHistogram = new System.Windows.Forms.Label();
            this._maxValue = new System.Windows.Forms.Label();
            this._minValue = new System.Windows.Forms.Label();
            this._histogramMap = new System.Windows.Forms.Label();
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._save = new System.Windows.Forms.Button();
            this._cmbPalette = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._btnExport = new System.Windows.Forms.Button();
            this._btnImport = new System.Windows.Forms.Button();
            this._rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._menuChangeColor = new System.Windows.Forms.ToolStripMenuItem();
            this._menuDeletePoint = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this._groupBox.SuspendLayout();
            this._rightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnReset
            // 
            this._btnReset.Location = new System.Drawing.Point(314, 417);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(90, 33);
            this._btnReset.TabIndex = 18;
            this._btnReset.Text = "&Reset";
            this._btnReset.UseVisualStyleBackColor = true;
            this._btnReset.Click += new System.EventHandler(this._btnReset_Click);
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(215, 417);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(90, 33);
            this._btnOK.TabIndex = 16;
            this._btnOK.Text = "&Close";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this._graident);
            this.panel1.Controls.Add(this._txtYPos);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this._txtXPos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._radMoveHist);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this._radMove);
            this.panel1.Controls.Add(this._radZoom);
            this.panel1.Controls.Add(this._maxHistogram);
            this.panel1.Controls.Add(this._minHistogram);
            this.panel1.Controls.Add(this._maxValue);
            this.panel1.Controls.Add(this._minValue);
            this.panel1.Controls.Add(this._histogramMap);
            this.panel1.Location = new System.Drawing.Point(9, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 326);
            this.panel1.TabIndex = 25;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // _graident
            // 
            this._graident.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._graident.Location = new System.Drawing.Point(35, 259);
            this._graident.Name = "_graident";
            this._graident.Size = new System.Drawing.Size(355, 20);
            this._graident.TabIndex = 39;
            this._graident.Paint += new System.Windows.Forms.PaintEventHandler(this._graident_Paint);
            // 
            // _txtYPos
            // 
            this._txtYPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtYPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._txtYPos.Location = new System.Drawing.Point(124, 296);
            this._txtYPos.Name = "_txtYPos";
            this._txtYPos.Size = new System.Drawing.Size(49, 16);
            this._txtYPos.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Y";
            // 
            // _txtXPos
            // 
            this._txtXPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtXPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._txtXPos.Location = new System.Drawing.Point(55, 296);
            this._txtXPos.Name = "_txtXPos";
            this._txtXPos.Size = new System.Drawing.Size(46, 16);
            this._txtXPos.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "X";
            // 
            // _radMoveHist
            // 
            this._radMoveHist.Appearance = System.Windows.Forms.Appearance.Button;
            this._radMoveHist.AutoSize = true;
            this._radMoveHist.Location = new System.Drawing.Point(242, 292);
            this._radMoveHist.Name = "_radMoveHist";
            this._radMoveHist.Size = new System.Drawing.Size(44, 23);
            this._radMoveHist.TabIndex = 35;
            this._radMoveHist.TabStop = true;
            this._radMoveHist.Text = "Move";
            this._radMoveHist.UseVisualStyleBackColor = true;
            this._radMoveHist.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 25);
            this.button1.TabIndex = 34;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _radMove
            // 
            this._radMove.Appearance = System.Windows.Forms.Appearance.Button;
            this._radMove.AutoSize = true;
            this._radMove.Location = new System.Drawing.Point(190, 292);
            this._radMove.Name = "_radMove";
            this._radMove.Size = new System.Drawing.Size(46, 23);
            this._radMove.TabIndex = 32;
            this._radMove.TabStop = true;
            this._radMove.Text = "Adjust";
            this._radMove.UseVisualStyleBackColor = true;
            this._radMove.CheckedChanged += new System.EventHandler(this._radMove_CheckedChanged);
            // 
            // _radZoom
            // 
            this._radZoom.Appearance = System.Windows.Forms.Appearance.Button;
            this._radZoom.AutoSize = true;
            this._radZoom.Location = new System.Drawing.Point(292, 292);
            this._radZoom.Name = "_radZoom";
            this._radZoom.Size = new System.Drawing.Size(44, 23);
            this._radZoom.TabIndex = 31;
            this._radZoom.TabStop = true;
            this._radZoom.Text = "Zoom";
            this._radZoom.UseVisualStyleBackColor = true;
            this._radZoom.CheckedChanged += new System.EventHandler(this._radZoom_CheckedChanged);
            // 
            // _maxHistogram
            // 
            this._maxHistogram.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._maxHistogram.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this._maxHistogram.Location = new System.Drawing.Point(360, 245);
            this._maxHistogram.Name = "_maxHistogram";
            this._maxHistogram.Size = new System.Drawing.Size(30, 10);
            this._maxHistogram.TabIndex = 29;
            this._maxHistogram.Text = "32332";
            this._maxHistogram.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _minHistogram
            // 
            this._minHistogram.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._minHistogram.Location = new System.Drawing.Point(34, 245);
            this._minHistogram.Name = "_minHistogram";
            this._minHistogram.Size = new System.Drawing.Size(30, 10);
            this._minHistogram.TabIndex = 28;
            this._minHistogram.Text = "32332";
            // 
            // _maxValue
            // 
            this._maxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._maxValue.Location = new System.Drawing.Point(9, 18);
            this._maxValue.Name = "_maxValue";
            this._maxValue.Size = new System.Drawing.Size(25, 10);
            this._maxValue.TabIndex = 27;
            this._maxValue.Text = "32332";
            this._maxValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _minValue
            // 
            this._minValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._minValue.Location = new System.Drawing.Point(5, 224);
            this._minValue.Name = "_minValue";
            this._minValue.Size = new System.Drawing.Size(25, 10);
            this._minValue.TabIndex = 26;
            this._minValue.Text = "32332";
            this._minValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _histogramMap
            // 
            this._histogramMap.BackColor = System.Drawing.SystemColors.ScrollBar;
            this._histogramMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._histogramMap.Location = new System.Drawing.Point(36, 14);
            this._histogramMap.Name = "_histogramMap";
            this._histogramMap.Size = new System.Drawing.Size(354, 224);
            this._histogramMap.TabIndex = 25;
            this._histogramMap.Paint += new System.Windows.Forms.PaintEventHandler(this._histogramMap_Paint);
            this._histogramMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this._histogramMap_MouseDown);
            this._histogramMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this._histogramMap_MouseMove);
            this._histogramMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this._histogramMap_MouseUp);
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._save);
            this._groupBox.Controls.Add(this._cmbPalette);
            this._groupBox.Controls.Add(this.label1);
            this._groupBox.Location = new System.Drawing.Point(10, 351);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(400, 52);
            this._groupBox.TabIndex = 26;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "Palette Type";
            // 
            // _save
            // 
            this._save.Location = new System.Drawing.Point(314, 21);
            this._save.Name = "_save";
            this._save.Size = new System.Drawing.Size(57, 26);
            this._save.TabIndex = 27;
            this._save.Text = "&Save";
            this._save.UseVisualStyleBackColor = true;
            this._save.Click += new System.EventHandler(this._save_Click);
            // 
            // _cmbPalette
            // 
            this._cmbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbPalette.FormattingEnabled = true;
            this._cmbPalette.Location = new System.Drawing.Point(167, 23);
            this._cmbPalette.Name = "_cmbPalette";
            this._cmbPalette.Size = new System.Drawing.Size(132, 21);
            this._cmbPalette.TabIndex = 1;
            this._cmbPalette.SelectedIndexChanged += new System.EventHandler(this._cmbPalette_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Preset Palette";
            // 
            // _btnExport
            // 
            this._btnExport.Location = new System.Drawing.Point(20, 417);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(90, 33);
            this._btnExport.TabIndex = 27;
            this._btnExport.Text = "&Export";
            this._btnExport.UseVisualStyleBackColor = true;
            this._btnExport.Click += new System.EventHandler(this._btnExport_Click);
            // 
            // _btnImport
            // 
            this._btnImport.Location = new System.Drawing.Point(116, 417);
            this._btnImport.Name = "_btnImport";
            this._btnImport.Size = new System.Drawing.Size(90, 33);
            this._btnImport.TabIndex = 28;
            this._btnImport.Text = "&Import";
            this._btnImport.UseVisualStyleBackColor = true;
            this._btnImport.Click += new System.EventHandler(this._btnImport_Click);
            // 
            // _rightClickMenu
            // 
            this._rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuChangeColor,
            this._menuDeletePoint});
            this._rightClickMenu.Name = "_panoramicRightClickMenu";
            this._rightClickMenu.Size = new System.Drawing.Size(148, 48);
            // 
            // _menuChangeColor
            // 
            this._menuChangeColor.Name = "_menuChangeColor";
            this._menuChangeColor.Size = new System.Drawing.Size(147, 22);
            this._menuChangeColor.Text = "&Change Color";
            this._menuChangeColor.Click += new System.EventHandler(this._menuChangeColor_Click);
            // 
            // _menuDeletePoint
            // 
            this._menuDeletePoint.Name = "_menuDeletePoint";
            this._menuDeletePoint.Size = new System.Drawing.Size(147, 22);
            this._menuDeletePoint.Text = "&Delete Point";
            this._menuDeletePoint.Click += new System.EventHandler(this._menuDeletePoint_Click);
            // 
            // Histogram3DDialog
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 460);
            this.Controls.Add(this._btnImport);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._groupBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Histogram3DDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Color Map";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Histogram3DDialog_FormClosed);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Histogram3DDialog_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            this._rightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnReset;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _maxHistogram;
        private System.Windows.Forms.Label _minHistogram;
        private System.Windows.Forms.Label _maxValue;
        private System.Windows.Forms.Label _minValue;
        private System.Windows.Forms.Label _histogramMap;
        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _cmbPalette;
        private System.Windows.Forms.RadioButton _radMove;
        private System.Windows.Forms.RadioButton _radZoom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button _save;
        private System.Windows.Forms.Button _btnExport;
        private System.Windows.Forms.Button _btnImport;
        private System.Windows.Forms.RadioButton _radMoveHist;
        private System.Windows.Forms.Label _txtYPos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _txtXPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip _rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem _menuChangeColor;
        private System.Windows.Forms.ToolStripMenuItem _menuDeletePoint;
        private System.Windows.Forms.Label _graident;
    }
}