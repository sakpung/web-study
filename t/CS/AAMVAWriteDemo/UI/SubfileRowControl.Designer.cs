namespace AAMVAWriteDemo
{
   partial class SubfileRowControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._textBoxSubfileType = new System.Windows.Forms.TextBox();
         this._btnDelete = new System.Windows.Forms.Button();
         this._btnEdit = new System.Windows.Forms.Button();
         this._labelSubfileType = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _textBoxSubfileType
         // 
         this._textBoxSubfileType.Enabled = false;
         this._textBoxSubfileType.Location = new System.Drawing.Point(3, 13);
         this._textBoxSubfileType.Name = "_textBoxSubfileType";
         this._textBoxSubfileType.Size = new System.Drawing.Size(42, 20);
         this._textBoxSubfileType.TabIndex = 0;
         // 
         // _btnDelete
         // 
         this._btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._btnDelete.Location = new System.Drawing.Point(564, 6);
         this._btnDelete.Name = "_btnDelete";
         this._btnDelete.Size = new System.Drawing.Size(75, 33);
         this._btnDelete.TabIndex = 1;
         this._btnDelete.Text = "Delete";
         this._btnDelete.UseVisualStyleBackColor = true;
         this._btnDelete.Click += new System.EventHandler(this._btnDelete_Click);
         // 
         // _btnEdit
         // 
         this._btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._btnEdit.Location = new System.Drawing.Point(473, 6);
         this._btnEdit.Name = "_btnEdit";
         this._btnEdit.Size = new System.Drawing.Size(75, 33);
         this._btnEdit.TabIndex = 2;
         this._btnEdit.Text = "Edit";
         this._btnEdit.UseVisualStyleBackColor = true;
         this._btnEdit.Click += new System.EventHandler(this._btnEdit_Click);
         // 
         // _labelSubfileType
         // 
         this._labelSubfileType.AutoSize = true;
         this._labelSubfileType.Location = new System.Drawing.Point(62, 16);
         this._labelSubfileType.Name = "_labelSubfileType";
         this._labelSubfileType.Size = new System.Drawing.Size(0, 13);
         this._labelSubfileType.TabIndex = 3;
         // 
         // SubfileRowControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.Controls.Add(this._labelSubfileType);
         this.Controls.Add(this._btnEdit);
         this.Controls.Add(this._btnDelete);
         this.Controls.Add(this._textBoxSubfileType);
         this.Name = "SubfileRowControl";
         this.Size = new System.Drawing.Size(664, 45);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox _textBoxSubfileType;
      private System.Windows.Forms.Button _btnDelete;
      private System.Windows.Forms.Button _btnEdit;
      private System.Windows.Forms.Label _labelSubfileType;
   }
}
