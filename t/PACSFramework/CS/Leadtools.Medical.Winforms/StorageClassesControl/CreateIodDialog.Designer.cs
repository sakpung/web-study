namespace Leadtools.Medical.Winforms
{
   partial class CreateIodDialog
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
         this.textBoxUid = new System.Windows.Forms.TextBox();
         this.labelCreateIod = new System.Windows.Forms.Label();
         this.textBoxUidDescription = new System.Windows.Forms.TextBox();
         this.labelUid = new System.Windows.Forms.Label();
         this.labelDescription = new System.Windows.Forms.Label();
         this.textBoxInstructions = new System.Windows.Forms.TextBox();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOk = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // textBoxUid
         // 
         this.textBoxUid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxUid.Location = new System.Drawing.Point(88, 133);
         this.textBoxUid.Name = "textBoxUid";
         this.textBoxUid.Size = new System.Drawing.Size(496, 20);
         this.textBoxUid.TabIndex = 1;
         // 
         // labelCreateIod
         // 
         this.labelCreateIod.AutoSize = true;
         this.labelCreateIod.Location = new System.Drawing.Point(24, 16);
         this.labelCreateIod.Name = "labelCreateIod";
         this.labelCreateIod.Size = new System.Drawing.Size(10, 13);
         this.labelCreateIod.TabIndex = 5;
         this.labelCreateIod.Text = ".";
         // 
         // textBoxUidDescription
         // 
         this.textBoxUidDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxUidDescription.Location = new System.Drawing.Point(88, 157);
         this.textBoxUidDescription.Multiline = true;
         this.textBoxUidDescription.Name = "textBoxUidDescription";
         this.textBoxUidDescription.Size = new System.Drawing.Size(496, 90);
         this.textBoxUidDescription.TabIndex = 3;
         // 
         // labelUid
         // 
         this.labelUid.AutoSize = true;
         this.labelUid.Location = new System.Drawing.Point(16, 137);
         this.labelUid.Name = "labelUid";
         this.labelUid.Size = new System.Drawing.Size(29, 13);
         this.labelUid.TabIndex = 0;
         this.labelUid.Text = "UID:";
         // 
         // labelDescription
         // 
         this.labelDescription.AutoSize = true;
         this.labelDescription.Location = new System.Drawing.Point(16, 161);
         this.labelDescription.Name = "labelDescription";
         this.labelDescription.Size = new System.Drawing.Size(63, 13);
         this.labelDescription.TabIndex = 2;
         this.labelDescription.Text = "Description:";
         // 
         // textBoxInstructions
         // 
         this.textBoxInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.textBoxInstructions.Location = new System.Drawing.Point(16, 16);
         this.textBoxInstructions.Multiline = true;
         this.textBoxInstructions.Name = "textBoxInstructions";
         this.textBoxInstructions.ReadOnly = true;
         this.textBoxInstructions.Size = new System.Drawing.Size(568, 102);
         this.textBoxInstructions.TabIndex = 4;
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(509, 255);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 6;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
         // 
         // buttonOk
         // 
         this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOk.Location = new System.Drawing.Point(432, 255);
         this.buttonOk.Name = "buttonOk";
         this.buttonOk.Size = new System.Drawing.Size(75, 23);
         this.buttonOk.TabIndex = 7;
         this.buttonOk.Text = "OK";
         this.buttonOk.UseVisualStyleBackColor = true;
         this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
         // 
         // CreateIodDialog
         // 
         this.AcceptButton = this.buttonOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(601, 285);
         this.Controls.Add(this.buttonOk);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.textBoxInstructions);
         this.Controls.Add(this.labelDescription);
         this.Controls.Add(this.labelUid);
         this.Controls.Add(this.textBoxUidDescription);
         this.Controls.Add(this.labelCreateIod);
         this.Controls.Add(this.textBoxUid);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CreateIodDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "CreateIod";
         this.Load += new System.EventHandler(this.CreateIod_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBoxUid;
      private System.Windows.Forms.Label labelCreateIod;
      private System.Windows.Forms.TextBox textBoxUidDescription;
      private System.Windows.Forms.Label labelUid;
      private System.Windows.Forms.Label labelDescription;
      private System.Windows.Forms.TextBox textBoxInstructions;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOk;
   }
}