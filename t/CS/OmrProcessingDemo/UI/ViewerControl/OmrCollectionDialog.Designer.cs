namespace OmrProcessingDemo.UI.ViewerControl
{
   partial class OmrCollectionDialog
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
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnOK = new System.Windows.Forms.Button();
         this.txtName = new System.Windows.Forms.TextBox();
         this.lblValue = new System.Windows.Forms.Label();
         this.grpGradingOptions = new System.Windows.Forms.GroupBox();
         this.label10 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this._numNoResponse = new System.Windows.Forms.NumericUpDown();
         this._numIncorrect = new System.Windows.Forms.NumericUpDown();
         this._numCorrect = new System.Windows.Forms.NumericUpDown();
         this.txtNote = new System.Windows.Forms.TextBox();
         this.lblNotes = new System.Windows.Forms.Label();
         this.grpGradingOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numNoResponse)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numIncorrect)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numCorrect)).BeginInit();
         this.SuspendLayout();
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(279, 167);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 7;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(198, 167);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 6;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         // 
         // txtName
         // 
         this.txtName.Location = new System.Drawing.Point(55, 9);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(299, 20);
         this.txtName.TabIndex = 5;
         // 
         // lblValue
         // 
         this.lblValue.AutoSize = true;
         this.lblValue.Location = new System.Drawing.Point(12, 12);
         this.lblValue.Name = "lblValue";
         this.lblValue.Size = new System.Drawing.Size(37, 13);
         this.lblValue.TabIndex = 4;
         this.lblValue.Text = "Value:";
         // 
         // grpGradingOptions
         // 
         this.grpGradingOptions.Controls.Add(this.label10);
         this.grpGradingOptions.Controls.Add(this.label9);
         this.grpGradingOptions.Controls.Add(this.label8);
         this.grpGradingOptions.Controls.Add(this._numNoResponse);
         this.grpGradingOptions.Controls.Add(this._numIncorrect);
         this.grpGradingOptions.Controls.Add(this._numCorrect);
         this.grpGradingOptions.Location = new System.Drawing.Point(15, 61);
         this.grpGradingOptions.Name = "grpGradingOptions";
         this.grpGradingOptions.Size = new System.Drawing.Size(339, 100);
         this.grpGradingOptions.TabIndex = 27;
         this.grpGradingOptions.TabStop = false;
         this.grpGradingOptions.Text = "Grading Options";
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(12, 73);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(72, 13);
         this.label10.TabIndex = 34;
         this.label10.Text = "No Response";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(12, 47);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(49, 13);
         this.label9.TabIndex = 33;
         this.label9.Text = "Incorrect";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(12, 21);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(41, 13);
         this.label8.TabIndex = 32;
         this.label8.Text = "Correct";
         // 
         // _numNoResponse
         // 
         this._numNoResponse.DecimalPlaces = 2;
         this._numNoResponse.Location = new System.Drawing.Point(98, 71);
         this._numNoResponse.Name = "_numNoResponse";
         this._numNoResponse.Size = new System.Drawing.Size(76, 20);
         this._numNoResponse.TabIndex = 31;
         // 
         // _numIncorrect
         // 
         this._numIncorrect.DecimalPlaces = 2;
         this._numIncorrect.Location = new System.Drawing.Point(97, 45);
         this._numIncorrect.Name = "_numIncorrect";
         this._numIncorrect.Size = new System.Drawing.Size(76, 20);
         this._numIncorrect.TabIndex = 30;
         // 
         // _numCorrect
         // 
         this._numCorrect.DecimalPlaces = 2;
         this._numCorrect.Location = new System.Drawing.Point(97, 19);
         this._numCorrect.Name = "_numCorrect";
         this._numCorrect.Size = new System.Drawing.Size(76, 20);
         this._numCorrect.TabIndex = 29;
         this._numCorrect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // txtNote
         // 
         this.txtNote.Location = new System.Drawing.Point(55, 35);
         this.txtNote.Name = "txtNote";
         this.txtNote.Size = new System.Drawing.Size(299, 20);
         this.txtNote.TabIndex = 29;
         // 
         // lblNotes
         // 
         this.lblNotes.AutoSize = true;
         this.lblNotes.Location = new System.Drawing.Point(12, 38);
         this.lblNotes.Name = "lblNotes";
         this.lblNotes.Size = new System.Drawing.Size(38, 13);
         this.lblNotes.TabIndex = 28;
         this.lblNotes.Text = "Notes:";
         // 
         // OmrCollectionDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(366, 200);
         this.Controls.Add(this.txtNote);
         this.Controls.Add(this.lblNotes);
         this.Controls.Add(this.grpGradingOptions);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.lblValue);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "OmrCollectionDialog";
         this.Text = "Update";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OmrCollectionDialog_FormClosing);
         this.grpGradingOptions.ResumeLayout(false);
         this.grpGradingOptions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numNoResponse)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numIncorrect)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numCorrect)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.TextBox txtName;
      private System.Windows.Forms.Label lblValue;
      private System.Windows.Forms.GroupBox grpGradingOptions;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.NumericUpDown _numNoResponse;
      private System.Windows.Forms.NumericUpDown _numIncorrect;
      private System.Windows.Forms.NumericUpDown _numCorrect;
      private System.Windows.Forms.TextBox txtNote;
      private System.Windows.Forms.Label lblNotes;
   }
}