namespace FormsDemo
{
   partial class NewElement
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewElement));
         this._txtName = new System.Windows.Forms.TextBox();
         this._lblName = new System.Windows.Forms.Label();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _txtName
         // 
         this._txtName.Location = new System.Drawing.Point(190, 6);
         this._txtName.Name = "_txtName";
         this._txtName.Size = new System.Drawing.Size(165, 20);
         this._txtName.TabIndex = 0;
         // 
         // _lblName
         // 
         this._lblName.AutoSize = true;
         this._lblName.Location = new System.Drawing.Point(12, 9);
         this._lblName.Name = "_lblName";
         this._lblName.Size = new System.Drawing.Size(25, 13);
         this._lblName.TabIndex = 1;
         this._lblName.Text = "$$$";
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(190, 32);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(79, 24);
         this._btnOk.TabIndex = 2;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(275, 32);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(79, 24);
         this._btnCancel.TabIndex = 3;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // NewElement
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(367, 65);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._lblName);
         this.Controls.Add(this._txtName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "NewElement";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "###";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox _txtName;
      private System.Windows.Forms.Label _lblName;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}