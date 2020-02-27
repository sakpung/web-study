namespace Main3DDemo
{
   partial class LoadAs3D
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
         this._btnOK = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._radioMultiFrames = new System.Windows.Forms.RadioButton();
         this._radio3DObject = new System.Windows.Forms.RadioButton();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(126, 168);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(66, 29);
         this._btnCancel.TabIndex = 35;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(52, 168);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(66, 28);
         this._btnOK.TabIndex = 34;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._radioMultiFrames);
         this.groupBox1.Controls.Add(this._radio3DObject);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(236, 146);
         this.groupBox1.TabIndex = 33;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "&Loading the &Series";
         // 
         // _radioMultiFrames
         // 
         this._radioMultiFrames.AutoSize = true;
         this._radioMultiFrames.Location = new System.Drawing.Point(13, 109);
         this._radioMultiFrames.Name = "_radioMultiFrames";
         this._radioMultiFrames.Size = new System.Drawing.Size(160, 17);
         this._radioMultiFrames.TabIndex = 2;
         this._radioMultiFrames.TabStop = true;
         this._radioMultiFrames.Text = "Load as a multi-frame &Series";
         this._radioMultiFrames.UseVisualStyleBackColor = true;
         // 
         // _radio3DObject
         // 
         this._radio3DObject.AutoSize = true;
         this._radio3DObject.Checked = true;
         this._radio3DObject.Location = new System.Drawing.Point(13, 80);
         this._radio3DObject.Name = "_radio3DObject";
         this._radio3DObject.Size = new System.Drawing.Size(120, 17);
         this._radio3DObject.TabIndex = 1;
         this._radio3DObject.TabStop = true;
         this._radio3DObject.Text = "Load as a &3D object";
         this._radio3DObject.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(10, 17);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(212, 39);
         this.label1.TabIndex = 0;
         this.label1.Text = "Do you want the series to be added as a 3D object or load it as a regular frames";
         // 
         // LoadAs3D
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(260, 207);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoadAs3D";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Loading the Series";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.RadioButton _radioMultiFrames;
      private System.Windows.Forms.RadioButton _radio3DObject;
      private System.Windows.Forms.Label label1;
   }
}