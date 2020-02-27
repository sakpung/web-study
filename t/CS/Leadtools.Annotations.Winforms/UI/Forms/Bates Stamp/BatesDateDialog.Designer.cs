namespace Leadtools.Annotations.WinForms
{
   partial class BatesDateDialog
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
         this._comboDateKind = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._comboDateFormat = new System.Windows.Forms.ComboBox();
         this.SuspendLayout();
         // 
         // _comboDateKind
         // 
         this._comboDateKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboDateKind.FormattingEnabled = true;
         this._comboDateKind.Items.AddRange(new object[] {
            "Utc",
            "Local"});
         this._comboDateKind.Location = new System.Drawing.Point(75, 47);
         this._comboDateKind.Name = "_comboDateKind";
         this._comboDateKind.Size = new System.Drawing.Size(121, 21);
         this._comboDateKind.TabIndex = 11;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(21, 49);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(37, 13);
         this.label2.TabIndex = 10;
         this.label2.Text = "Kind : ";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(21, 15);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(48, 13);
         this.label1.TabIndex = 8;
         this.label1.Text = "Format : ";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(145, 91);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 7;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Location = new System.Drawing.Point(35, 91);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 6;
         this._btnOk.Text = "Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _comboDateFormat
         // 
         this._comboDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboDateFormat.FormattingEnabled = true;
         this._comboDateFormat.Items.AddRange(new object[] {
            "MM/dd/yyyy",
            "M/d/yyyy",
            "M/d/yy",
            "MM/dd/yy",
            "dd MMM HH:mm:ss"});
         this._comboDateFormat.Location = new System.Drawing.Point(75, 14);
         this._comboDateFormat.Name = "_comboDateFormat";
         this._comboDateFormat.Size = new System.Drawing.Size(121, 21);
         this._comboDateFormat.TabIndex = 12;
         // 
         // BateDateDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(241, 128);
         this.Controls.Add(this._comboDateFormat);
         this.Controls.Add(this._comboDateKind);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "BateDateDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Bate Date Properties";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ComboBox _comboDateKind;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.ComboBox _comboDateFormat;

   }
}