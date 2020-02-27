namespace MedicalViewerDemo
{
   partial class RemoveCellDialog
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
         this._btnCancel = new System.Windows.Forms.Button();
         this.removeSelectedRadio = new System.Windows.Forms.RadioButton();
         this.cellIndexLabel = new System.Windows.Forms.Label();
         this._btnOK = new System.Windows.Forms.Button();
         this.removeSpecificRadio = new System.Windows.Forms.RadioButton();
         this.removeAllRadio = new System.Windows.Forms.RadioButton();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.cellIndexText = new MedicalViewerDemo.NumericTextBox();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(108, 141);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 29);
         this._btnCancel.TabIndex = 18;
         this._btnCancel.Text = "Canc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // removeSelectedRadio
         // 
         this.removeSelectedRadio.AutoSize = true;
         this.removeSelectedRadio.Location = new System.Drawing.Point(16, 41);
         this.removeSelectedRadio.Name = "removeSelectedRadio";
         this.removeSelectedRadio.Size = new System.Drawing.Size(138, 17);
         this.removeSelectedRadio.TabIndex = 1;
         this.removeSelectedRadio.TabStop = true;
         this.removeSelectedRadio.Text = "R&emove selected cell(s)";
         this.removeSelectedRadio.UseVisualStyleBackColor = true;
         // 
         // cellIndexLabel
         // 
         this.cellIndexLabel.AutoSize = true;
         this.cellIndexLabel.Enabled = false;
         this.cellIndexLabel.Location = new System.Drawing.Point(13, 97);
         this.cellIndexLabel.Name = "cellIndexLabel";
         this.cellIndexLabel.Size = new System.Drawing.Size(52, 13);
         this.cellIndexLabel.TabIndex = 3;
         this.cellIndexLabel.Text = "&Cell index";
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(18, 141);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 29);
         this._btnOK.TabIndex = 17;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this.okButton_Click);
         // 
         // removeSpecificRadio
         // 
         this.removeSpecificRadio.AutoSize = true;
         this.removeSpecificRadio.Location = new System.Drawing.Point(16, 65);
         this.removeSpecificRadio.Name = "removeSpecificRadio";
         this.removeSpecificRadio.Size = new System.Drawing.Size(123, 17);
         this.removeSpecificRadio.TabIndex = 2;
         this.removeSpecificRadio.TabStop = true;
         this.removeSpecificRadio.Text = "Re&move specific cell";
         this.removeSpecificRadio.UseVisualStyleBackColor = true;
         this.removeSpecificRadio.CheckedChanged += new System.EventHandler(this.removeSpecificRadio_CheckedChanged);
         // 
         // removeAllRadio
         // 
         this.removeAllRadio.AutoSize = true;
         this.removeAllRadio.Location = new System.Drawing.Point(16, 19);
         this.removeAllRadio.Name = "removeAllRadio";
         this.removeAllRadio.Size = new System.Drawing.Size(102, 17);
         this.removeAllRadio.TabIndex = 0;
         this.removeAllRadio.TabStop = true;
         this.removeAllRadio.Text = "&Remove all cells";
         this.removeAllRadio.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.cellIndexText);
         this.groupBox1.Controls.Add(this.cellIndexLabel);
         this.groupBox1.Controls.Add(this.removeSpecificRadio);
         this.groupBox1.Controls.Add(this.removeSelectedRadio);
         this.groupBox1.Controls.Add(this.removeAllRadio);
         this.groupBox1.Location = new System.Drawing.Point(7, 6);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(189, 129);
         this.groupBox1.TabIndex = 15;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Remo&ve cell(s)";
         // 
         // cellIndexText
         // 
         this.cellIndexText.Enabled = false;
         this.cellIndexText.Location = new System.Drawing.Point(71, 94);
         this.cellIndexText.MaximumAllowed = 1000;
         this.cellIndexText.MinimumAllowed = -1000;
         this.cellIndexText.Name = "cellIndexText";
         this.cellIndexText.Size = new System.Drawing.Size(47, 20);
         this.cellIndexText.TabIndex = 4;
         this.cellIndexText.Text = "0";
         this.cellIndexText.Value = 0;
         // 
         // RemoveCellDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(203, 177);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "RemoveCellDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Remove Cell ";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.RadioButton removeSelectedRadio;
      private NumericTextBox cellIndexText;
      private System.Windows.Forms.Label cellIndexLabel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.RadioButton removeSpecificRadio;
      private System.Windows.Forms.RadioButton removeAllRadio;
      private System.Windows.Forms.GroupBox groupBox1;
   }
}