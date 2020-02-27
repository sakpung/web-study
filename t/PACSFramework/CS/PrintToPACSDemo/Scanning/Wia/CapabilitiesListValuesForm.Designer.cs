namespace PrintToPACSDemo
{
   partial class CapabilitiesListValuesForm
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
         this._tbPropertyName = new System.Windows.Forms.TextBox();
         this._btnClose = new System.Windows.Forms.Button();
         this._lblValues = new System.Windows.Forms.Label();
         this._lbValues = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 15);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(77, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Property Name";
         // 
         // _tbPropertyName
         // 
         this._tbPropertyName.Location = new System.Drawing.Point(118, 12);
         this._tbPropertyName.Name = "_tbPropertyName";
         this._tbPropertyName.ReadOnly = true;
         this._tbPropertyName.Size = new System.Drawing.Size(217, 20);
         this._tbPropertyName.TabIndex = 1;
         // 
         // _btnClose
         // 
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnClose.Location = new System.Drawing.Point(260, 194);
         this._btnClose.Name = "_btnClose";
         this._btnClose.Size = new System.Drawing.Size(75, 23);
         this._btnClose.TabIndex = 4;
         this._btnClose.Text = "&Close";
         this._btnClose.UseVisualStyleBackColor = true;
         // 
         // _lblValues
         // 
         this._lblValues.AutoSize = true;
         this._lblValues.Location = new System.Drawing.Point(12, 45);
         this._lblValues.Name = "_lblValues";
         this._lblValues.Size = new System.Drawing.Size(58, 13);
         this._lblValues.TabIndex = 2;
         this._lblValues.Text = "List Values";
         // 
         // _lbValues
         // 
         this._lbValues.FormattingEnabled = true;
         this._lbValues.Location = new System.Drawing.Point(12, 61);
         this._lbValues.Name = "_lbValues";
         this._lbValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
         this._lbValues.Size = new System.Drawing.Size(323, 121);
         this._lbValues.TabIndex = 3;
         // 
         // CapabilitiesListValuesForm
         // 
         this.AcceptButton = this._btnClose;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnClose;
         this.ClientSize = new System.Drawing.Size(347, 229);
         this.Controls.Add(this._lbValues);
         this.Controls.Add(this._lblValues);
         this.Controls.Add(this._btnClose);
         this.Controls.Add(this._tbPropertyName);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "CapabilitiesListValuesForm";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Load += new System.EventHandler(this.CapabilitiesListValuesForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox _tbPropertyName;
      private System.Windows.Forms.Button _btnClose;
      private System.Windows.Forms.Label _lblValues;
      private System.Windows.Forms.ListBox _lbValues;
   }
}