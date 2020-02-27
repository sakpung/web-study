namespace PrintToPACSDemo
{
   partial class WiaDeviceItemsForm
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
         this._tvWiaDeviceItems = new System.Windows.Forms.TreeView();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _tvWiaDeviceItems
         // 
         this._tvWiaDeviceItems.Location = new System.Drawing.Point(12, 12);
         this._tvWiaDeviceItems.Name = "_tvWiaDeviceItems";
         this._tvWiaDeviceItems.Size = new System.Drawing.Size(239, 213);
         this._tvWiaDeviceItems.TabIndex = 0;
         this._tvWiaDeviceItems.DoubleClick += new System.EventHandler(this._tvWiaDeviceItems_DoubleClick);
         this._tvWiaDeviceItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._tvWiaDeviceItems_AfterSelect);
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(53, 231);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "&OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(134, 231);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // WiaDeviceItemsForm
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(263, 266);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._tvWiaDeviceItems);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "WiaDeviceItemsForm";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Select Item";
         this.Load += new System.EventHandler(this.WiaDeviceItemsForm_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TreeView _tvWiaDeviceItems;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}