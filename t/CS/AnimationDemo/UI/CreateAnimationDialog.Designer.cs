namespace AnimationDemo
{
   partial class CreateAnimationDialog
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
         this._btnRemove = new System.Windows.Forms.Button();
         this._btnAdd = new System.Windows.Forms.Button();
         this._lstSourceImages = new System.Windows.Forms.ListBox();
         this._lstAnimationImages = new System.Windows.Forms.ListBox();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _btnRemove
         // 
         this._btnRemove.Location = new System.Drawing.Point(165, 88);
         this._btnRemove.Name = "_btnRemove";
         this._btnRemove.Size = new System.Drawing.Size(45, 24);
         this._btnRemove.TabIndex = 12;
         this._btnRemove.Text = "<--";
         this._btnRemove.UseVisualStyleBackColor = true;
         this._btnRemove.Click += new System.EventHandler(this._btnRemove_Click);
         // 
         // _btnAdd
         // 
         this._btnAdd.Location = new System.Drawing.Point(165, 58);
         this._btnAdd.Name = "_btnAdd";
         this._btnAdd.Size = new System.Drawing.Size(45, 24);
         this._btnAdd.TabIndex = 11;
         this._btnAdd.Text = "-->";
         this._btnAdd.UseVisualStyleBackColor = true;
         this._btnAdd.Click += new System.EventHandler(this._btnAdd_Click);
         // 
         // _lstSourceImages
         // 
         this._lstSourceImages.FormattingEnabled = true;
         this._lstSourceImages.HorizontalScrollbar = true;
         this._lstSourceImages.Location = new System.Drawing.Point(11, 18);
         this._lstSourceImages.Name = "_lstSourceImages";
         this._lstSourceImages.Size = new System.Drawing.Size(148, 173);
         this._lstSourceImages.TabIndex = 10;
         // 
         // _lstAnimationImages
         // 
         this._lstAnimationImages.FormattingEnabled = true;
         this._lstAnimationImages.HorizontalScrollbar = true;
         this._lstAnimationImages.Location = new System.Drawing.Point(216, 18);
         this._lstAnimationImages.Name = "_lstAnimationImages";
         this._lstAnimationImages.Size = new System.Drawing.Size(148, 173);
         this._lstAnimationImages.TabIndex = 9;
         this._lstAnimationImages.SelectedIndexChanged += new System.EventHandler(this._lstAnimationImages_SelectedIndexChanged);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(383, 41);
         this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(68, 22);
         this._btnCancel.TabIndex = 8;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Enabled = false;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(383, 11);
         this._btnOk.Margin = new System.Windows.Forms.Padding(2);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(68, 22);
         this._btnOk.TabIndex = 7;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // CreateAnimationDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(458, 206);
         this.Controls.Add(this._btnRemove);
         this.Controls.Add(this._btnAdd);
         this.Controls.Add(this._lstSourceImages);
         this.Controls.Add(this._lstAnimationImages);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CreateAnimationDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "CreateAnimationDialog";
         this.Load += new System.EventHandler(this.CreateAnimationDialog_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnRemove;
      private System.Windows.Forms.Button _btnAdd;
      private System.Windows.Forms.ListBox _lstSourceImages;
      private System.Windows.Forms.ListBox _lstAnimationImages;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}