namespace PrintToPACSDemo
{
   partial class CapabilitiesRangeValuesForm
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
         this._btnClose = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this._tbPropertyName = new System.Windows.Forms.TextBox();
         this._tbMinimumValue = new System.Windows.Forms.TextBox();
         this._tbNominalValue = new System.Windows.Forms.TextBox();
         this._tbMaximumValue = new System.Windows.Forms.TextBox();
         this._tbIncrementValue = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // _btnClose
         // 
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnClose.Location = new System.Drawing.Point(260, 145);
         this._btnClose.Name = "_btnClose";
         this._btnClose.Size = new System.Drawing.Size(75, 23);
         this._btnClose.TabIndex = 10;
         this._btnClose.Text = "&Close";
         this._btnClose.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(77, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Property Name";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 35);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(78, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Minimum Value";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(12, 61);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(81, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Maximum Value";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(12, 87);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(75, 13);
         this.label4.TabIndex = 6;
         this.label4.Text = "Nominal Value";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(12, 113);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(84, 13);
         this.label5.TabIndex = 8;
         this.label5.Text = "Increment Value";
         // 
         // _tbPropertyName
         // 
         this._tbPropertyName.Location = new System.Drawing.Point(118, 6);
         this._tbPropertyName.Name = "_tbPropertyName";
         this._tbPropertyName.ReadOnly = true;
         this._tbPropertyName.Size = new System.Drawing.Size(217, 20);
         this._tbPropertyName.TabIndex = 1;
         // 
         // _tbMinimumValue
         // 
         this._tbMinimumValue.Location = new System.Drawing.Point(118, 32);
         this._tbMinimumValue.Name = "_tbMinimumValue";
         this._tbMinimumValue.ReadOnly = true;
         this._tbMinimumValue.Size = new System.Drawing.Size(217, 20);
         this._tbMinimumValue.TabIndex = 3;
         // 
         // _tbNominalValue
         // 
         this._tbNominalValue.Location = new System.Drawing.Point(118, 84);
         this._tbNominalValue.Name = "_tbNominalValue";
         this._tbNominalValue.ReadOnly = true;
         this._tbNominalValue.Size = new System.Drawing.Size(217, 20);
         this._tbNominalValue.TabIndex = 7;
         // 
         // _tbMaximumValue
         // 
         this._tbMaximumValue.Location = new System.Drawing.Point(118, 58);
         this._tbMaximumValue.Name = "_tbMaximumValue";
         this._tbMaximumValue.ReadOnly = true;
         this._tbMaximumValue.Size = new System.Drawing.Size(217, 20);
         this._tbMaximumValue.TabIndex = 5;
         // 
         // _tbIncrementValue
         // 
         this._tbIncrementValue.Location = new System.Drawing.Point(118, 110);
         this._tbIncrementValue.Name = "_tbIncrementValue";
         this._tbIncrementValue.ReadOnly = true;
         this._tbIncrementValue.Size = new System.Drawing.Size(217, 20);
         this._tbIncrementValue.TabIndex = 9;
         // 
         // CapabilitiesRangeValuesForm
         // 
         this.AcceptButton = this._btnClose;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnClose;
         this.ClientSize = new System.Drawing.Size(347, 180);
         this.Controls.Add(this._tbIncrementValue);
         this.Controls.Add(this._tbNominalValue);
         this.Controls.Add(this._tbMaximumValue);
         this.Controls.Add(this._tbMinimumValue);
         this.Controls.Add(this._tbPropertyName);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._btnClose);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "CapabilitiesRangeValuesForm";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "WIA Range Property Values";
         this.Load += new System.EventHandler(this.CapabilitiesRangeValuesForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btnClose;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox _tbPropertyName;
      private System.Windows.Forms.TextBox _tbMinimumValue;
      private System.Windows.Forms.TextBox _tbNominalValue;
      private System.Windows.Forms.TextBox _tbMaximumValue;
      private System.Windows.Forms.TextBox _tbIncrementValue;
   }
}