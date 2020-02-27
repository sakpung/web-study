namespace MedicalViewerLayoutDemo
{
   partial class PrintCellDialog
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._chkTags = new System.Windows.Forms.CheckBox();
         this._chkRulers = new System.Windows.Forms.CheckBox();
         this._chkBorders = new System.Windows.Forms.CheckBox();
         this._chkRegion = new System.Windows.Forms.CheckBox();
         this._chkAnnotation = new System.Windows.Forms.CheckBox();
         this._chkAll = new System.Windows.Forms.CheckBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this._chkPrintAll = new System.Windows.Forms.CheckBox();
         this._chkExploded = new System.Windows.Forms.CheckBox();
         this._lblIndex = new System.Windows.Forms.Label();
         this._btnPrint = new System.Windows.Forms.Button();
         this._btnSave = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._cellImage = new System.Windows.Forms.PictureBox();
         this._txtIndex = new MedicalViewerLayoutDemo.NumericTextBox();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._cellImage)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._chkTags);
         this.groupBox1.Controls.Add(this._chkRulers);
         this.groupBox1.Controls.Add(this._chkBorders);
         this.groupBox1.Controls.Add(this._chkRegion);
         this.groupBox1.Controls.Add(this._chkAnnotation);
         this.groupBox1.Controls.Add(this._chkAll);
         this.groupBox1.Location = new System.Drawing.Point(9, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(140, 319);
         this.groupBox1.TabIndex = 3;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "&Options";
         // 
         // _chkTags
         // 
         this._chkTags.AutoSize = true;
         this._chkTags.Checked = true;
         this._chkTags.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkTags.Location = new System.Drawing.Point(13, 266);
         this._chkTags.Name = "_chkTags";
         this._chkTags.Size = new System.Drawing.Size(50, 17);
         this._chkTags.TabIndex = 11;
         this._chkTags.Text = "&Tags";
         this._chkTags.UseVisualStyleBackColor = true;
         this._chkTags.CheckedChanged += new System.EventHandler(this._chkTags_CheckedChanged);
         // 
         // _chkRulers
         // 
         this._chkRulers.AutoSize = true;
         this._chkRulers.Checked = true;
         this._chkRulers.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkRulers.Location = new System.Drawing.Point(13, 219);
         this._chkRulers.Name = "_chkRulers";
         this._chkRulers.Size = new System.Drawing.Size(56, 17);
         this._chkRulers.TabIndex = 10;
         this._chkRulers.Text = "&Rulers";
         this._chkRulers.UseVisualStyleBackColor = true;
         this._chkRulers.CheckedChanged += new System.EventHandler(this._chkRulers_CheckedChanged);
         // 
         // _chkBorders
         // 
         this._chkBorders.AutoSize = true;
         this._chkBorders.Checked = true;
         this._chkBorders.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkBorders.Location = new System.Drawing.Point(13, 172);
         this._chkBorders.Name = "_chkBorders";
         this._chkBorders.Size = new System.Drawing.Size(62, 17);
         this._chkBorders.TabIndex = 9;
         this._chkBorders.Text = "&Borders";
         this._chkBorders.UseVisualStyleBackColor = true;
         this._chkBorders.CheckedChanged += new System.EventHandler(this._chkBorders_CheckedChanged);
         // 
         // _chkRegion
         // 
         this._chkRegion.AutoSize = true;
         this._chkRegion.Checked = true;
         this._chkRegion.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkRegion.Location = new System.Drawing.Point(13, 125);
         this._chkRegion.Name = "_chkRegion";
         this._chkRegion.Size = new System.Drawing.Size(65, 17);
         this._chkRegion.TabIndex = 8;
         this._chkRegion.Text = "&Regions";
         this._chkRegion.UseVisualStyleBackColor = true;
         this._chkRegion.CheckedChanged += new System.EventHandler(this._chkRegion_CheckedChanged);
         // 
         // _chkAnnotation
         // 
         this._chkAnnotation.AutoSize = true;
         this._chkAnnotation.Checked = true;
         this._chkAnnotation.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkAnnotation.Location = new System.Drawing.Point(13, 78);
         this._chkAnnotation.Name = "_chkAnnotation";
         this._chkAnnotation.Size = new System.Drawing.Size(77, 17);
         this._chkAnnotation.TabIndex = 7;
         this._chkAnnotation.Text = "&Annotation";
         this._chkAnnotation.UseVisualStyleBackColor = true;
         this._chkAnnotation.CheckedChanged += new System.EventHandler(this._chkAnnotation_CheckedChanged);
         // 
         // _chkAll
         // 
         this._chkAll.AutoSize = true;
         this._chkAll.Location = new System.Drawing.Point(13, 31);
         this._chkAll.Name = "_chkAll";
         this._chkAll.Size = new System.Drawing.Size(37, 17);
         this._chkAll.TabIndex = 6;
         this._chkAll.Text = "&All";
         this._chkAll.UseVisualStyleBackColor = true;
         this._chkAll.CheckedChanged += new System.EventHandler(this._chkAll_CheckedChanged);
         // 
         // groupBox2
         // 
         this.groupBox2.BackColor = System.Drawing.Color.Transparent;
         this.groupBox2.Controls.Add(this._chkPrintAll);
         this.groupBox2.Controls.Add(this._txtIndex);
         this.groupBox2.Controls.Add(this._chkExploded);
         this.groupBox2.Controls.Add(this._lblIndex);
         this.groupBox2.Location = new System.Drawing.Point(9, 337);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(140, 121);
         this.groupBox2.TabIndex = 4;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "&Additional Options";
         // 
         // _chkPrintAll
         // 
         this._chkPrintAll.AutoSize = true;
         this._chkPrintAll.Location = new System.Drawing.Point(13, 20);
         this._chkPrintAll.Name = "_chkPrintAll";
         this._chkPrintAll.Size = new System.Drawing.Size(105, 17);
         this._chkPrintAll.TabIndex = 9;
         this._chkPrintAll.Text = "&Print All sub-cells";
         this._chkPrintAll.UseVisualStyleBackColor = true;
         this._chkPrintAll.CheckedChanged += new System.EventHandler(this._chkPrintAll_CheckedChanged);
         // 
         // _chkExploded
         // 
         this._chkExploded.AutoSize = true;
         this._chkExploded.Location = new System.Drawing.Point(13, 98);
         this._chkExploded.Name = "_chkExploded";
         this._chkExploded.Size = new System.Drawing.Size(70, 17);
         this._chkExploded.TabIndex = 7;
         this._chkExploded.Text = "&Exploded";
         this._chkExploded.UseVisualStyleBackColor = true;
         this._chkExploded.CheckedChanged += new System.EventHandler(this._chkExploded_CheckedChanged);
         // 
         // _lblIndex
         // 
         this._lblIndex.AutoSize = true;
         this._lblIndex.Location = new System.Drawing.Point(21, 65);
         this._lblIndex.Name = "_lblIndex";
         this._lblIndex.Size = new System.Drawing.Size(33, 13);
         this._lblIndex.TabIndex = 6;
         this._lblIndex.Text = "&Index";
         // 
         // _btnPrint
         // 
         this._btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnPrint.Location = new System.Drawing.Point(169, 473);
         this._btnPrint.Name = "_btnPrint";
         this._btnPrint.Size = new System.Drawing.Size(70, 29);
         this._btnPrint.TabIndex = 6;
         this._btnPrint.Text = "&Print";
         this._btnPrint.UseVisualStyleBackColor = true;
         this._btnPrint.Click += new System.EventHandler(this._btnPrint_Click);
         // 
         // _btnSave
         // 
         this._btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnSave.Location = new System.Drawing.Point(245, 473);
         this._btnSave.Name = "_btnSave";
         this._btnSave.Size = new System.Drawing.Size(70, 29);
         this._btnSave.TabIndex = 7;
         this._btnSave.Text = "&Save";
         this._btnSave.UseVisualStyleBackColor = true;
         this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(322, 473);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(70, 29);
         this._btnCancel.TabIndex = 8;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _cellImage
         // 
         this._cellImage.Location = new System.Drawing.Point(155, 14);
         this._cellImage.Name = "_cellImage";
         this._cellImage.Size = new System.Drawing.Size(437, 444);
         this._cellImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this._cellImage.TabIndex = 9;
         this._cellImage.TabStop = false;
         // 
         // _txtIndex
         // 
         this._txtIndex.Location = new System.Drawing.Point(78, 62);
         this._txtIndex.MaximumAllowed = 10000;
         this._txtIndex.MaxLength = 3;
         this._txtIndex.MinimumAllowed = 1;
         this._txtIndex.Name = "_txtIndex";
         this._txtIndex.Size = new System.Drawing.Size(40, 20);
         this._txtIndex.TabIndex = 8;
         this._txtIndex.Text = "1";
         this._txtIndex.Value = 1;
         this._txtIndex.TextChanged += new System.EventHandler(this._txtIndex_TextChanged);
         // 
         // PrintCellDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(604, 513);
         this.Controls.Add(this._cellImage);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnSave);
         this.Controls.Add(this._btnPrint);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PrintCellDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Print Cell Dialog";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._cellImage)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Button _btnPrint;
      private System.Windows.Forms.Button _btnSave;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.CheckBox _chkTags;
      private System.Windows.Forms.CheckBox _chkRulers;
      private System.Windows.Forms.CheckBox _chkBorders;
      private System.Windows.Forms.CheckBox _chkRegion;
      private System.Windows.Forms.CheckBox _chkAnnotation;
      private System.Windows.Forms.CheckBox _chkAll;
      private System.Windows.Forms.CheckBox _chkPrintAll;
      private NumericTextBox _txtIndex;
      private System.Windows.Forms.CheckBox _chkExploded;
      private System.Windows.Forms.Label _lblIndex;
      private System.Windows.Forms.PictureBox _cellImage;
   }
}