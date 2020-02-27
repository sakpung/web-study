namespace MedicalViewerDemo
{
   partial class AnnotationPropertiesDialog
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
         this._tabAnnProperties = new System.Windows.Forms.TabControl();
         this._penTab = new System.Windows.Forms.TabPage();
         this._penGroup = new System.Windows.Forms.GroupBox();
         this._lblPenColor = new System.Windows.Forms.Label();
         this._btnColor = new System.Windows.Forms.Button();
         this._penWidth = new System.Windows.Forms.NumericUpDown();
         this.label1 = new System.Windows.Forms.Label();
         this._chkUsePen = new System.Windows.Forms.CheckBox();
         this._brushTab = new System.Windows.Forms.TabPage();
         this._brushGroup = new System.Windows.Forms.GroupBox();
         this._lblBrushColor = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this._chkUseBrush = new System.Windows.Forms.CheckBox();
         this._fontTab = new System.Windows.Forms.TabPage();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this._lblSample = new System.Windows.Forms.Label();
         this._lblFont = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this._btnChange = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._btnApply = new System.Windows.Forms.Button();
         this._tabAnnProperties.SuspendLayout();
         this._penTab.SuspendLayout();
         this._penGroup.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._penWidth)).BeginInit();
         this._brushTab.SuspendLayout();
         this._brushGroup.SuspendLayout();
         this._fontTab.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // _tabAnnProperties
         // 
         this._tabAnnProperties.Controls.Add(this._penTab);
         this._tabAnnProperties.Controls.Add(this._brushTab);
         this._tabAnnProperties.Controls.Add(this._fontTab);
         this._tabAnnProperties.Location = new System.Drawing.Point(0, 0);
         this._tabAnnProperties.Name = "_tabAnnProperties";
         this._tabAnnProperties.SelectedIndex = 0;
         this._tabAnnProperties.Size = new System.Drawing.Size(203, 198);
         this._tabAnnProperties.TabIndex = 0;
         // 
         // _penTab
         // 
         this._penTab.Controls.Add(this._penGroup);
         this._penTab.Controls.Add(this._chkUsePen);
         this._penTab.Location = new System.Drawing.Point(4, 22);
         this._penTab.Name = "_penTab";
         this._penTab.Padding = new System.Windows.Forms.Padding(3);
         this._penTab.Size = new System.Drawing.Size(195, 172);
         this._penTab.TabIndex = 0;
         this._penTab.Text = "Pen";
         this._penTab.UseVisualStyleBackColor = true;
         // 
         // _penGroup
         // 
         this._penGroup.Controls.Add(this._lblPenColor);
         this._penGroup.Controls.Add(this._btnColor);
         this._penGroup.Controls.Add(this._penWidth);
         this._penGroup.Controls.Add(this.label1);
         this._penGroup.Location = new System.Drawing.Point(8, 30);
         this._penGroup.Name = "_penGroup";
         this._penGroup.Size = new System.Drawing.Size(178, 134);
         this._penGroup.TabIndex = 1;
         this._penGroup.TabStop = false;
         // 
         // _lblPenColor
         // 
         this._lblPenColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblPenColor.Location = new System.Drawing.Point(82, 52);
         this._lblPenColor.Name = "_lblPenColor";
         this._lblPenColor.Size = new System.Drawing.Size(90, 31);
         this._lblPenColor.TabIndex = 5;
         this._lblPenColor.Paint += new System.Windows.Forms.PaintEventHandler(this._lblPenColor_Paint);
         // 
         // _btnColor
         // 
         this._btnColor.Location = new System.Drawing.Point(6, 52);
         this._btnColor.Name = "_btnColor";
         this._btnColor.Size = new System.Drawing.Size(58, 31);
         this._btnColor.TabIndex = 4;
         this._btnColor.Text = "C&olor";
         this._btnColor.UseVisualStyleBackColor = true;
         this._btnColor.Click += new System.EventHandler(this._btnColor_Click);
         // 
         // _penWidth
         // 
         this._penWidth.Location = new System.Drawing.Point(82, 18);
         this._penWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._penWidth.Name = "_penWidth";
         this._penWidth.Size = new System.Drawing.Size(90, 20);
         this._penWidth.TabIndex = 1;
         this._penWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(7, 20);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(59, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Thickness:";
         // 
         // _chkUsePen
         // 
         this._chkUsePen.AutoSize = true;
         this._chkUsePen.Checked = true;
         this._chkUsePen.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkUsePen.Location = new System.Drawing.Point(8, 6);
         this._chkUsePen.Name = "_chkUsePen";
         this._chkUsePen.Size = new System.Drawing.Size(67, 17);
         this._chkUsePen.TabIndex = 0;
         this._chkUsePen.Text = "Use Pen";
         this._chkUsePen.UseVisualStyleBackColor = true;
         this._chkUsePen.CheckedChanged += new System.EventHandler(this._chkUsePen_CheckedChanged);
         // 
         // _brushTab
         // 
         this._brushTab.Controls.Add(this._brushGroup);
         this._brushTab.Controls.Add(this._chkUseBrush);
         this._brushTab.Location = new System.Drawing.Point(4, 22);
         this._brushTab.Name = "_brushTab";
         this._brushTab.Padding = new System.Windows.Forms.Padding(3);
         this._brushTab.Size = new System.Drawing.Size(195, 172);
         this._brushTab.TabIndex = 1;
         this._brushTab.Text = "Brush";
         this._brushTab.UseVisualStyleBackColor = true;
         // 
         // _brushGroup
         // 
         this._brushGroup.Controls.Add(this._lblBrushColor);
         this._brushGroup.Controls.Add(this.button1);
         this._brushGroup.Location = new System.Drawing.Point(8, 30);
         this._brushGroup.Name = "_brushGroup";
         this._brushGroup.Size = new System.Drawing.Size(178, 134);
         this._brushGroup.TabIndex = 2;
         this._brushGroup.TabStop = false;
         // 
         // _lblBrushColor
         // 
         this._lblBrushColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblBrushColor.Location = new System.Drawing.Point(82, 52);
         this._lblBrushColor.Name = "_lblBrushColor";
         this._lblBrushColor.Size = new System.Drawing.Size(90, 31);
         this._lblBrushColor.TabIndex = 5;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(6, 52);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(58, 31);
         this.button1.TabIndex = 4;
         this.button1.Text = "C&olor";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this._btnColor_Click);
         // 
         // _chkUseBrush
         // 
         this._chkUseBrush.AutoSize = true;
         this._chkUseBrush.Checked = true;
         this._chkUseBrush.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkUseBrush.Location = new System.Drawing.Point(8, 6);
         this._chkUseBrush.Name = "_chkUseBrush";
         this._chkUseBrush.Size = new System.Drawing.Size(75, 17);
         this._chkUseBrush.TabIndex = 0;
         this._chkUseBrush.Text = "Use Brush";
         this._chkUseBrush.UseVisualStyleBackColor = true;
         this._chkUseBrush.CheckedChanged += new System.EventHandler(this._chkUseBrush_CheckedChanged);
         // 
         // _fontTab
         // 
         this._fontTab.Controls.Add(this.groupBox3);
         this._fontTab.Controls.Add(this._lblFont);
         this._fontTab.Controls.Add(this.label3);
         this._fontTab.Controls.Add(this._btnChange);
         this._fontTab.Location = new System.Drawing.Point(4, 22);
         this._fontTab.Name = "_fontTab";
         this._fontTab.Size = new System.Drawing.Size(195, 172);
         this._fontTab.TabIndex = 2;
         this._fontTab.Text = "Font";
         this._fontTab.UseVisualStyleBackColor = true;
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this._lblSample);
         this.groupBox3.Location = new System.Drawing.Point(9, 50);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(176, 67);
         this.groupBox3.TabIndex = 3;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Sample";
         // 
         // _lblSample
         // 
         this._lblSample.Location = new System.Drawing.Point(6, 16);
         this._lblSample.Name = "_lblSample";
         this._lblSample.Size = new System.Drawing.Size(164, 48);
         this._lblSample.TabIndex = 0;
         this._lblSample.Text = "AaBbZz";
         this._lblSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _lblFont
         // 
         this._lblFont.AutoSize = true;
         this._lblFont.Location = new System.Drawing.Point(57, 17);
         this._lblFont.Name = "_lblFont";
         this._lblFont.Size = new System.Drawing.Size(0, 13);
         this._lblFont.TabIndex = 2;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(9, 17);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(31, 13);
         this.label3.TabIndex = 1;
         this.label3.Text = "Font:";
         // 
         // _btnChange
         // 
         this._btnChange.Location = new System.Drawing.Point(60, 141);
         this._btnChange.Name = "_btnChange";
         this._btnChange.Size = new System.Drawing.Size(75, 23);
         this._btnChange.TabIndex = 0;
         this._btnChange.Text = "Change...";
         this._btnChange.UseVisualStyleBackColor = true;
         this._btnChange.Click += new System.EventHandler(this._btnChange_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(73, 204);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(58, 29);
         this._btnCancel.TabIndex = 17;
         this._btnCancel.Text = "Canc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(7, 204);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(58, 29);
         this._btnOK.TabIndex = 16;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(138, 204);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(58, 29);
         this._btnApply.TabIndex = 18;
         this._btnApply.Text = "App&ly";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // AnnotationPropertiesDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(203, 237);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._tabAnnProperties);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AnnotationPropertiesDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Annotation Properties";
         this._tabAnnProperties.ResumeLayout(false);
         this._penTab.ResumeLayout(false);
         this._penTab.PerformLayout();
         this._penGroup.ResumeLayout(false);
         this._penGroup.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._penWidth)).EndInit();
         this._brushTab.ResumeLayout(false);
         this._brushTab.PerformLayout();
         this._brushGroup.ResumeLayout(false);
         this._fontTab.ResumeLayout(false);
         this._fontTab.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl _tabAnnProperties;
      private System.Windows.Forms.TabPage _penTab;
      private System.Windows.Forms.TabPage _brushTab;
      private System.Windows.Forms.TabPage _fontTab;
      private System.Windows.Forms.GroupBox _penGroup;
      private System.Windows.Forms.NumericUpDown _penWidth;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.CheckBox _chkUsePen;
      private System.Windows.Forms.Label _lblPenColor;
      private System.Windows.Forms.Button _btnColor;
      private System.Windows.Forms.CheckBox _chkUseBrush;
      private System.Windows.Forms.GroupBox _brushGroup;
      private System.Windows.Forms.Label _lblBrushColor;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button _btnChange;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Label _lblSample;
      private System.Windows.Forms.Label _lblFont;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnApply;

   }
}