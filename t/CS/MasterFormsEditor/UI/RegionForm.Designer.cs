namespace CSMasterFormsEditor
{
   partial class RegionForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegionForm));
         this._chkRegionsOfInterest = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this._chkIncludeRegions = new System.Windows.Forms.CheckBox();
         this.label3 = new System.Windows.Forms.Label();
         this._chkExcludeRegions = new System.Windows.Forms.CheckBox();
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.label4 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _chkRegionsOfInterest
         // 
         this._chkRegionsOfInterest.AutoSize = true;
         this._chkRegionsOfInterest.Checked = true;
         this._chkRegionsOfInterest.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkRegionsOfInterest.Location = new System.Drawing.Point(16, 54);
         this._chkRegionsOfInterest.Name = "_chkRegionsOfInterest";
         this._chkRegionsOfInterest.Size = new System.Drawing.Size(150, 17);
         this._chkRegionsOfInterest.TabIndex = 0;
         this._chkRegionsOfInterest.Text = "Select Regions Of Interest";
         this._chkRegionsOfInterest.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(33, 85);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(299, 47);
         this.label1.TabIndex = 1;
         this.label1.Text = "Use this option to specify areas of the image which contain important features of" +
             " the form. These areas will be given more weight when the forms unique attribute" +
             "s are generated.";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(33, 176);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(299, 64);
         this.label2.TabIndex = 3;
         this.label2.Text = resources.GetString("label2.Text");
         // 
         // _chkIncludeRegions
         // 
         this._chkIncludeRegions.AutoSize = true;
         this._chkIncludeRegions.Location = new System.Drawing.Point(16, 145);
         this._chkIncludeRegions.Name = "_chkIncludeRegions";
         this._chkIncludeRegions.Size = new System.Drawing.Size(136, 17);
         this._chkIncludeRegions.TabIndex = 2;
         this._chkIncludeRegions.Text = "Select Include Regions";
         this._chkIncludeRegions.UseVisualStyleBackColor = true;
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(33, 282);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(299, 79);
         this.label3.TabIndex = 5;
         this.label3.Text = resources.GetString("label3.Text");
         // 
         // _chkExcludeRegions
         // 
         this._chkExcludeRegions.AutoSize = true;
         this._chkExcludeRegions.Location = new System.Drawing.Point(16, 251);
         this._chkExcludeRegions.Name = "_chkExcludeRegions";
         this._chkExcludeRegions.Size = new System.Drawing.Size(139, 17);
         this._chkExcludeRegions.TabIndex = 4;
         this._chkExcludeRegions.Text = "Select Exclude Regions";
         this._chkExcludeRegions.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(92, 378);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(86, 39);
         this._btnOK.TabIndex = 6;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.Location = new System.Drawing.Point(184, 378);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(86, 39);
         this._btnCancel.TabIndex = 7;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(55, 22);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(249, 24);
         this.label4.TabIndex = 8;
         this.label4.Text = "Check the type of regions you would like to select.";
         // 
         // RegionForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(364, 433);
         this.Controls.Add(this.label4);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this.label3);
         this.Controls.Add(this._chkExcludeRegions);
         this.Controls.Add(this.label2);
         this.Controls.Add(this._chkIncludeRegions);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._chkRegionsOfInterest);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "RegionForm";
         this.Text = "Select Regions";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.CheckBox _chkRegionsOfInterest;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.CheckBox _chkIncludeRegions;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.CheckBox _chkExcludeRegions;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Label label4;
   }
}