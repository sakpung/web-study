namespace AAMVAWriteDemo
{
   partial class EditSubfileDialog
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
         this._tabControl = new System.Windows.Forms.TabControl();
         this._tabPageMandatory = new System.Windows.Forms.TabPage();
         this._tabPageOptional = new System.Windows.Forms.TabPage();
         this._btnSubmit = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._tabControl.SuspendLayout();
         this.SuspendLayout();
         // 
         // _tabControl
         // 
         this._tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._tabControl.Controls.Add(this._tabPageMandatory);
         this._tabControl.Controls.Add(this._tabPageOptional);
         this._tabControl.Location = new System.Drawing.Point(12, 12);
         this._tabControl.Name = "_tabControl";
         this._tabControl.SelectedIndex = 0;
         this._tabControl.Size = new System.Drawing.Size(951, 458);
         this._tabControl.TabIndex = 0;
         // 
         // _tabPageMandatory
         // 
         this._tabPageMandatory.AutoScroll = true;
         this._tabPageMandatory.Location = new System.Drawing.Point(4, 22);
         this._tabPageMandatory.Name = "_tabPageMandatory";
         this._tabPageMandatory.Padding = new System.Windows.Forms.Padding(3);
         this._tabPageMandatory.Size = new System.Drawing.Size(943, 432);
         this._tabPageMandatory.TabIndex = 0;
         this._tabPageMandatory.Text = "Mandatory Data Elements";
         this._tabPageMandatory.UseVisualStyleBackColor = true;
         // 
         // _tabPageOptional
         // 
         this._tabPageOptional.AutoScroll = true;
         this._tabPageOptional.Location = new System.Drawing.Point(4, 22);
         this._tabPageOptional.Name = "_tabPageOptional";
         this._tabPageOptional.Padding = new System.Windows.Forms.Padding(3);
         this._tabPageOptional.Size = new System.Drawing.Size(943, 432);
         this._tabPageOptional.TabIndex = 1;
         this._tabPageOptional.Text = "Optional Data Elements";
         this._tabPageOptional.UseVisualStyleBackColor = true;
         // 
         // _btnSubmit
         // 
         this._btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnSubmit.Location = new System.Drawing.Point(799, 476);
         this._btnSubmit.Name = "_btnSubmit";
         this._btnSubmit.Size = new System.Drawing.Size(75, 23);
         this._btnSubmit.TabIndex = 1;
         this._btnSubmit.Text = "Submit";
         this._btnSubmit.UseVisualStyleBackColor = true;
         this._btnSubmit.Click += new System.EventHandler(this._btnSubmit_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnCancel.Location = new System.Drawing.Point(880, 476);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // EditSubfileDialog
         // 
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(967, 505);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnSubmit);
         this.Controls.Add(this._tabControl);
         this.Name = "EditSubfileDialog";
         this.Text = "EditSubfileDialog";
         this._tabControl.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl _tabControl;
      private System.Windows.Forms.TabPage _tabPageMandatory;
      private System.Windows.Forms.TabPage _tabPageOptional;
      private System.Windows.Forms.Button _btnSubmit;
      private System.Windows.Forms.Button _btnCancel;
   }
}