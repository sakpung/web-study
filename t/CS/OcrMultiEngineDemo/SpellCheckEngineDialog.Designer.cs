namespace OcrMultiEngineDemo
{
   partial class SpellCheckEngineDialog
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
         if(disposing && (components != null))
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpellCheckEngineDialog));
          this._cancelButton = new System.Windows.Forms.Button();
          this._okButton = new System.Windows.Forms.Button();
          this._engineComboBox = new System.Windows.Forms.ComboBox();
          this._enginesGroupBox = new System.Windows.Forms.GroupBox();
          this._helpButton = new System.Windows.Forms.Button();
          this._enginesGroupBox.SuspendLayout();
          this.SuspendLayout();
          // 
          // _cancelButton
          // 
          this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._cancelButton, "_cancelButton");
          this._cancelButton.Name = "_cancelButton";
          this._cancelButton.UseVisualStyleBackColor = true;
          // 
          // _okButton
          // 
          this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
          resources.ApplyResources(this._okButton, "_okButton");
          this._okButton.Name = "_okButton";
          this._okButton.UseVisualStyleBackColor = true;
          this._okButton.Click += new System.EventHandler(this._okButton_Click);
          // 
          // _engineComboBox
          // 
          this._engineComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._engineComboBox.FormattingEnabled = true;
          resources.ApplyResources(this._engineComboBox, "_engineComboBox");
          this._engineComboBox.Name = "_engineComboBox";
          // 
          // _enginesGroupBox
          // 
          this._enginesGroupBox.Controls.Add(this._engineComboBox);
          resources.ApplyResources(this._enginesGroupBox, "_enginesGroupBox");
          this._enginesGroupBox.Name = "_enginesGroupBox";
          this._enginesGroupBox.TabStop = false;
          // 
          // _helpButton
          // 
          resources.ApplyResources(this._helpButton, "_helpButton");
          this._helpButton.Name = "_helpButton";
          this._helpButton.UseVisualStyleBackColor = true;
          this._helpButton.Click += new System.EventHandler(this._helpButton_Click);
          // 
          // SpellCheckEngineDialog
          // 
          this.AcceptButton = this._okButton;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._cancelButton;
          this.Controls.Add(this._helpButton);
          this.Controls.Add(this._enginesGroupBox);
          this.Controls.Add(this._okButton);
          this.Controls.Add(this._cancelButton);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "SpellCheckEngineDialog";
          this.ShowInTaskbar = false;
          this._enginesGroupBox.ResumeLayout(false);
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.ComboBox _engineComboBox;
      private System.Windows.Forms.GroupBox _enginesGroupBox;
      private System.Windows.Forms.Button _helpButton;
   }
}