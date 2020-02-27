namespace DicomVideoCaptureDemo.UI
{
   partial class Edit_Item
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
         this._btn_OK = new System.Windows.Forms.Button();
         this._btn_Cancel = new System.Windows.Forms.Button();
         this._txtBox_DateTimePicker = new System.Windows.Forms.TextBox();
         this._txtBox_VR_Info = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _btn_OK
         // 
         this._btn_OK.Location = new System.Drawing.Point(115, 125);
         this._btn_OK.Name = "_btn_OK";
         this._btn_OK.Size = new System.Drawing.Size(75, 23);
         this._btn_OK.TabIndex = 11;
         this._btn_OK.Text = "OK";
         this._btn_OK.UseVisualStyleBackColor = true;
         // 
         // _btn_Cancel
         // 
         this._btn_Cancel.Location = new System.Drawing.Point(196, 125);
         this._btn_Cancel.Name = "_btn_Cancel";
         this._btn_Cancel.Size = new System.Drawing.Size(75, 23);
         this._btn_Cancel.TabIndex = 10;
         this._btn_Cancel.Text = "Cancel";
         this._btn_Cancel.UseVisualStyleBackColor = true;
         // 
         // _txtBox_DateTimePicker
         // 
         this._txtBox_DateTimePicker.Location = new System.Drawing.Point(53, 97);
         this._txtBox_DateTimePicker.Name = "_txtBox_DateTimePicker";
         this._txtBox_DateTimePicker.Size = new System.Drawing.Size(219, 20);
         this._txtBox_DateTimePicker.TabIndex = 9;
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
         // Edit_Item
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 162);
         this.Controls.Add(this._btn_OK);
         this.Controls.Add(this._btn_Cancel);
         this.Controls.Add(this._txtBox_DateTimePicker);
         this.Controls.Add(this._txtBox_VR_Info);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Name = "Edit_Item";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btn_OK;
      private System.Windows.Forms.Button _btn_Cancel;
      private System.Windows.Forms.TextBox _txtBox_DateTimePicker;
      private System.Windows.Forms.TextBox _txtBox_VR_Info;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
   }
}