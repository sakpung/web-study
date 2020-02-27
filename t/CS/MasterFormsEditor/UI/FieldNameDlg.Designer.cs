namespace CSMasterFormsEditor.UI
{
   partial class FieldNameDlg
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
         this._btn_cancel = new System.Windows.Forms.Button();
         this._btn_ok = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this._txtBox_FieldName = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // _btn_cancel
         // 
         this._btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btn_cancel.Location = new System.Drawing.Point(28, 63);
         this._btn_cancel.Name = "_btn_cancel";
         this._btn_cancel.Size = new System.Drawing.Size(105, 23);
         this._btn_cancel.TabIndex = 0;
         this._btn_cancel.Text = "Cancel";
         this._btn_cancel.UseVisualStyleBackColor = true;
         // 
         // _btn_ok
         // 
         this._btn_ok.Location = new System.Drawing.Point(151, 63);
         this._btn_ok.Name = "_btn_ok";
         this._btn_ok.Size = new System.Drawing.Size(105, 23);
         this._btn_ok.TabIndex = 1;
         this._btn_ok.Text = "OK";
         this._btn_ok.UseVisualStyleBackColor = true;
         this._btn_ok.Click += new System.EventHandler(this._btn_ok_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 18);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(66, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "Field Name :";
         // 
         // _txtBox_FieldName
         // 
         this._txtBox_FieldName.Location = new System.Drawing.Point(84, 18);
         this._txtBox_FieldName.Name = "_txtBox_FieldName";
         this._txtBox_FieldName.Size = new System.Drawing.Size(188, 20);
         this._txtBox_FieldName.TabIndex = 3;
         // 
         // FieldNameDlg
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 102);
         this.Controls.Add(this._txtBox_FieldName);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._btn_ok);
         this.Controls.Add(this._btn_cancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "FieldNameDlg";
         this.Text = "Field Name";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btn_cancel;
      private System.Windows.Forms.Button _btn_ok;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox _txtBox_FieldName;
   }
}