namespace ImageProcessingDemo
{
   partial class DeinterlaceDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeinterlaceDialog));
          this._gbDeinterlaceImage = new System.Windows.Forms.GroupBox();
          this._rbNormal = new System.Windows.Forms.RadioButton();
          this._rbSmooth = new System.Windows.Forms.RadioButton();
          this._gbRemoveLines = new System.Windows.Forms.GroupBox();
          this._rbEvenLines = new System.Windows.Forms.RadioButton();
          this._rbOddLines = new System.Windows.Forms.RadioButton();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbDeinterlaceImage.SuspendLayout();
          this._gbRemoveLines.SuspendLayout();
          this.SuspendLayout();
          // 
          // _gbDeinterlaceImage
          // 
          this._gbDeinterlaceImage.Controls.Add(this._rbNormal);
          this._gbDeinterlaceImage.Controls.Add(this._rbSmooth);
          this._gbDeinterlaceImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbDeinterlaceImage, "_gbDeinterlaceImage");
          this._gbDeinterlaceImage.Name = "_gbDeinterlaceImage";
          this._gbDeinterlaceImage.TabStop = false;
          // 
          // _rbNormal
          // 
          resources.ApplyResources(this._rbNormal, "_rbNormal");
          this._rbNormal.Name = "_rbNormal";
          this._rbNormal.TabStop = true;
          this._rbNormal.UseVisualStyleBackColor = true;
          // 
          // _rbSmooth
          // 
          resources.ApplyResources(this._rbSmooth, "_rbSmooth");
          this._rbSmooth.Name = "_rbSmooth";
          this._rbSmooth.TabStop = true;
          this._rbSmooth.UseVisualStyleBackColor = true;
          // 
          // _gbRemoveLines
          // 
          this._gbRemoveLines.Controls.Add(this._rbEvenLines);
          this._gbRemoveLines.Controls.Add(this._rbOddLines);
          this._gbRemoveLines.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbRemoveLines, "_gbRemoveLines");
          this._gbRemoveLines.Name = "_gbRemoveLines";
          this._gbRemoveLines.TabStop = false;
          // 
          // _rbEvenLines
          // 
          resources.ApplyResources(this._rbEvenLines, "_rbEvenLines");
          this._rbEvenLines.Name = "_rbEvenLines";
          this._rbEvenLines.UseVisualStyleBackColor = true;
          // 
          // _rbOddLines
          // 
          resources.ApplyResources(this._rbOddLines, "_rbOddLines");
          this._rbOddLines.Checked = true;
          this._rbOddLines.Name = "_rbOddLines";
          this._rbOddLines.TabStop = true;
          this._rbOddLines.UseVisualStyleBackColor = true;
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // _btnOk
          // 
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // DeinterlaceDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gbRemoveLines);
          this.Controls.Add(this._gbDeinterlaceImage);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "DeinterlaceDialog";
          this.ShowIcon = false;
          this._gbDeinterlaceImage.ResumeLayout(false);
          this._gbDeinterlaceImage.PerformLayout();
          this._gbRemoveLines.ResumeLayout(false);
          this._gbRemoveLines.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbDeinterlaceImage;
      private System.Windows.Forms.RadioButton _rbNormal;
      private System.Windows.Forms.RadioButton _rbSmooth;
      private System.Windows.Forms.GroupBox _gbRemoveLines;
      private System.Windows.Forms.RadioButton _rbEvenLines;
      private System.Windows.Forms.RadioButton _rbOddLines;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}