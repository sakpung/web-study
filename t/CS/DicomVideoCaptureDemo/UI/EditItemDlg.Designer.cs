namespace DicomVideoCaptureDemo.UI
{
   partial class EditItemDlg
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditItemDlg));
         this._btn_OK = new System.Windows.Forms.Button();
         this._btn_Cancel = new System.Windows.Forms.Button();
         this._txtBox_Value = new System.Windows.Forms.TextBox();
         this._txtBox_VR_Info = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._dateTimePicker = new System.Windows.Forms.DateTimePicker();
         this.SuspendLayout();
         // 
         // _btn_OK
         // 
         this._btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btn_OK.Location = new System.Drawing.Point(115, 125);
         this._btn_OK.Name = "_btn_OK";
         this._btn_OK.Size = new System.Drawing.Size(75, 23);
         this._btn_OK.TabIndex = 11;
         this._btn_OK.Text = "OK";
         this._btn_OK.UseVisualStyleBackColor = true;
         this._btn_OK.Click += new System.EventHandler(this._btn_OK_Click);
         // 
         // _btn_Cancel
         // 
         this._btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btn_Cancel.Location = new System.Drawing.Point(196, 125);
         this._btn_Cancel.Name = "_btn_Cancel";
         this._btn_Cancel.Size = new System.Drawing.Size(75, 23);
         this._btn_Cancel.TabIndex = 10;
         this._btn_Cancel.Text = "Cancel";
         this._btn_Cancel.UseVisualStyleBackColor = true;
         // 
         // _txtBox_Value
         // 
         this._txtBox_Value.Location = new System.Drawing.Point(54, 97);
         this._txtBox_Value.Name = "_txtBox_Value";
         this._txtBox_Value.Size = new System.Drawing.Size(219, 20);
         this._txtBox_Value.TabIndex = 9;
         // 
         // _txtBox_VR_Info
         // 
         this._txtBox_VR_Info.Location = new System.Drawing.Point(55, 22);
         this._txtBox_VR_Info.Multiline = true;
         this._txtBox_VR_Info.Name = "_txtBox_VR_Info";
         this._txtBox_VR_Info.ReadOnly = true;
         this._txtBox_VR_Info.Size = new System.Drawing.Size(217, 61);
         this._txtBox_VR_Info.TabIndex = 8;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 97);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(34, 13);
         this.label2.TabIndex = 7;
         this.label2.Text = "Value";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 22);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(35, 13);
         this.label1.TabIndex = 6;
         this.label1.Text = "Notes";
         // 
         // _dateTimePicker
         // 
         this._dateTimePicker.Location = new System.Drawing.Point(54, 97);
         this._dateTimePicker.Name = "_dateTimePicker";
         this._dateTimePicker.Size = new System.Drawing.Size(218, 20);
         this._dateTimePicker.TabIndex = 12;
         // 
         // EditItemDlg
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 162);
         this.Controls.Add(this._btn_OK);
         this.Controls.Add(this._btn_Cancel);
         this.Controls.Add(this._txtBox_Value);
         this.Controls.Add(this._txtBox_VR_Info);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._dateTimePicker);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "EditItemDlg";
         this.Load += new System.EventHandler(this.EditItemDlg_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btn_OK;
      private System.Windows.Forms.Button _btn_Cancel;
      private System.Windows.Forms.TextBox _txtBox_Value;
      private System.Windows.Forms.TextBox _txtBox_VR_Info;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.DateTimePicker _dateTimePicker;
   }
}