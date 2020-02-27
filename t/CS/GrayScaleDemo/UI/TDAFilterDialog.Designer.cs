namespace GrayScaleDemo
{
   partial class TDAFilterDialog
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label4 = new System.Windows.Forms.Label();
         this._numIterations = new System.Windows.Forms.NumericUpDown();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._numLambda = new System.Windows.Forms.NumericUpDown();
         this._numKappa = new System.Windows.Forms.NumericUpDown();
         this._cbFlux = new System.Windows.Forms.ComboBox();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numIterations)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLambda)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numKappa)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this._numIterations);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this._numLambda);
         this.groupBox1.Controls.Add(this._numKappa);
         this.groupBox1.Controls.Add(this._cbFlux);
         this.groupBox1.Location = new System.Drawing.Point(14, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(271, 148);
         this.groupBox1.TabIndex = 5;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Parameters";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(31, 26);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(50, 13);
         this.label4.TabIndex = 10;
         this.label4.Text = "Iterations";
         // 
         // _numIterations
         // 
         this._numIterations.Location = new System.Drawing.Point(119, 19);
         this._numIterations.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
         this._numIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numIterations.Name = "_numIterations";
         this._numIterations.Size = new System.Drawing.Size(120, 20);
         this._numIterations.TabIndex = 9;
         this._numIterations.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(31, 111);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(26, 13);
         this.label3.TabIndex = 8;
         this.label3.Text = "Flux";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(31, 82);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(38, 13);
         this.label2.TabIndex = 7;
         this.label2.Text = "Kappa";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(31, 53);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(45, 13);
         this.label1.TabIndex = 6;
         this.label1.Text = "Lambda";
         // 
         // _numLambda
         // 
         this._numLambda.Location = new System.Drawing.Point(119, 46);
         this._numLambda.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
         this._numLambda.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numLambda.Name = "_numLambda";
         this._numLambda.Size = new System.Drawing.Size(120, 20);
         this._numLambda.TabIndex = 3;
         this._numLambda.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
         // 
         // _numKappa
         // 
         this._numKappa.Location = new System.Drawing.Point(119, 75);
         this._numKappa.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numKappa.Name = "_numKappa";
         this._numKappa.Size = new System.Drawing.Size(120, 20);
         this._numKappa.TabIndex = 4;
         this._numKappa.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
         // 
         // _cbFlux
         // 
         this._cbFlux.FormattingEnabled = true;
         this._cbFlux.Items.AddRange(new object[] {
            "Exponetial",
            "Quadratic"});
         this._cbFlux.Location = new System.Drawing.Point(119, 108);
         this._cbFlux.Name = "_cbFlux";
         this._cbFlux.Size = new System.Drawing.Size(120, 21);
         this._cbFlux.TabIndex = 5;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(152, 166);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 4;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(71, 166);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 3;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // TDAFilterDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(298, 205);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "TDAFilterDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "TAD Anistropic";
         this.Load += new System.EventHandler(this.TDAFilter_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numIterations)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLambda)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numKappa)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.NumericUpDown _numIterations;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.NumericUpDown _numLambda;
      private System.Windows.Forms.NumericUpDown _numKappa;
      private System.Windows.Forms.ComboBox _cbFlux;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
   }
}