namespace WiaDemo
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapabilitiesRangeValuesForm));
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
         resources.ApplyResources(this._btnClose, "_btnClose");
         this._btnClose.Name = "_btnClose";
         this._btnClose.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.Name = "label1";
         // 
         // label2
         // 
         resources.ApplyResources(this.label2, "label2");
         this.label2.Name = "label2";
         // 
         // label3
         // 
         resources.ApplyResources(this.label3, "label3");
         this.label3.Name = "label3";
         // 
         // label4
         // 
         resources.ApplyResources(this.label4, "label4");
         this.label4.Name = "label4";
         // 
         // label5
         // 
         resources.ApplyResources(this.label5, "label5");
         this.label5.Name = "label5";
         // 
         // _tbPropertyName
         // 
         resources.ApplyResources(this._tbPropertyName, "_tbPropertyName");
         this._tbPropertyName.Name = "_tbPropertyName";
         this._tbPropertyName.ReadOnly = true;
         // 
         // _tbMinimumValue
         // 
         resources.ApplyResources(this._tbMinimumValue, "_tbMinimumValue");
         this._tbMinimumValue.Name = "_tbMinimumValue";
         this._tbMinimumValue.ReadOnly = true;
         // 
         // _tbNominalValue
         // 
         resources.ApplyResources(this._tbNominalValue, "_tbNominalValue");
         this._tbNominalValue.Name = "_tbNominalValue";
         this._tbNominalValue.ReadOnly = true;
         // 
         // _tbMaximumValue
         // 
         resources.ApplyResources(this._tbMaximumValue, "_tbMaximumValue");
         this._tbMaximumValue.Name = "_tbMaximumValue";
         this._tbMaximumValue.ReadOnly = true;
         // 
         // _tbIncrementValue
         // 
         resources.ApplyResources(this._tbIncrementValue, "_tbIncrementValue");
         this._tbIncrementValue.Name = "_tbIncrementValue";
         this._tbIncrementValue.ReadOnly = true;
         // 
         // CapabilitiesRangeValuesForm
         // 
         this.AcceptButton = this._btnClose;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnClose;
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