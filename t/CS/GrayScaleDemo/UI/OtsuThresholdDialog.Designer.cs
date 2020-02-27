namespace GrayScaleDemo
{
   partial class OtsuThresholdDialog
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
         this.label1 = new System.Windows.Forms.Label();
         this._numClusters = new System.Windows.Forms.NumericUpDown();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this.panel1 = new System.Windows.Forms.Panel();
         ((System.ComponentModel.ISupportInitialize)(this._numClusters)).BeginInit();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 15);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(44, 13);
         this.label1.TabIndex = 7;
         this.label1.Text = "Clusters";
         // 
         // _numClusters
         // 
         this._numClusters.Location = new System.Drawing.Point(80, 13);
         this._numClusters.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
         this._numClusters.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this._numClusters.Name = "_numClusters";
         this._numClusters.Size = new System.Drawing.Size(120, 20);
         this._numClusters.TabIndex = 6;
         this._numClusters.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(122, 65);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 5;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Location = new System.Drawing.Point(41, 65);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 4;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.label1);
         this.panel1.Controls.Add(this._numClusters);
         this.panel1.Location = new System.Drawing.Point(16, 12);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(207, 47);
         this.panel1.TabIndex = 8;
         // 
         // OtsuThresholdDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(238, 105);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "OtsuThresholdDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Otsu Threshold";
         this.Load += new System.EventHandler(this.OtsuThresholdDialog_Load);
         ((System.ComponentModel.ISupportInitialize)(this._numClusters)).EndInit();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.NumericUpDown _numClusters;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Panel panel1;
   }
}