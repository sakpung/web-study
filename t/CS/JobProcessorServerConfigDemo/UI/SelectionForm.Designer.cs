namespace JobProcessorServerConfigDemo
{
   partial class Selection
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Selection));
         this._lblToolkits = new System.Windows.Forms.Label();
         this._btnOK = new System.Windows.Forms.Button();
         this._cmbToolkits = new System.Windows.Forms.ComboBox();
         this.SuspendLayout();
         // 
         // _lblToolkits
         // 
         this._lblToolkits.Location = new System.Drawing.Point(22, 9);
         this._lblToolkits.Name = "_lblToolkits";
         this._lblToolkits.Size = new System.Drawing.Size(280, 38);
         this._lblToolkits.TabIndex = 0;
         this._lblToolkits.Text = "We have detected more than one JobProcessor installation on this machine. Which setup wo" +
             "uld you like to configure?";
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(59, 102);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(187, 23);
         this._btnOK.TabIndex = 3;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this.button1_Click);
         // 
         // _cmbToolkits
         // 
         this._cmbToolkits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbToolkits.FormattingEnabled = true;
         this._cmbToolkits.Location = new System.Drawing.Point(25, 60);
         this._cmbToolkits.Name = "_cmbToolkits";
         this._cmbToolkits.Size = new System.Drawing.Size(262, 21);
         this._cmbToolkits.TabIndex = 4;
         // 
         // Selection
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(314, 161);
         this.Controls.Add(this._cmbToolkits);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._lblToolkits);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Selection";
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Selection";
         this.TopMost = true;
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _lblToolkits;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.ComboBox _cmbToolkits;
   }
}