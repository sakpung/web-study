namespace Leadtools.Demos
{
   partial class EnableLanguagesDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnableLanguagesDialog));
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._btnMoveTop = new System.Windows.Forms.Button();
         this._btnMoveLeft = new System.Windows.Forms.Button();
         this._btnMoveRight = new System.Windows.Forms.Button();
         this._enabledLanguagesListBox = new System.Windows.Forms.ListBox();
         this._mainLanguageLabel = new System.Windows.Forms.Label();
         this._additionalLabel = new System.Windows.Forms.Label();
         this._languagesListBox = new System.Windows.Forms.ListBox();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._okButton, "_okButton");
         this._okButton.Name = "_okButton";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._cancelButton, "_cancelButton");
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this._btnMoveTop);
         this.groupBox1.Controls.Add(this._btnMoveLeft);
         this.groupBox1.Controls.Add(this._btnMoveRight);
         this.groupBox1.Controls.Add(this._enabledLanguagesListBox);
         this.groupBox1.Controls.Add(this._mainLanguageLabel);
         this.groupBox1.Controls.Add(this._additionalLabel);
         this.groupBox1.Controls.Add(this._languagesListBox);
         resources.ApplyResources(this.groupBox1, "groupBox1");
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.TabStop = false;
         // 
         // label2
         // 
         resources.ApplyResources(this.label2, "label2");
         this.label2.Name = "label2";
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.Name = "label1";
         // 
         // _btnMoveTop
         // 
         resources.ApplyResources(this._btnMoveTop, "_btnMoveTop");
         this._btnMoveTop.Name = "_btnMoveTop";
         this._btnMoveTop.UseVisualStyleBackColor = true;
         this._btnMoveTop.Click += new System.EventHandler(this._btnMoveTop_Click);
         // 
         // _btnMoveLeft
         // 
         resources.ApplyResources(this._btnMoveLeft, "_btnMoveLeft");
         this._btnMoveLeft.Name = "_btnMoveLeft";
         this._btnMoveLeft.UseVisualStyleBackColor = true;
         this._btnMoveLeft.Click += new System.EventHandler(this._btnMoveLeft_Click);
         // 
         // _btnMoveRight
         // 
         resources.ApplyResources(this._btnMoveRight, "_btnMoveRight");
         this._btnMoveRight.Name = "_btnMoveRight";
         this._btnMoveRight.UseVisualStyleBackColor = true;
         this._btnMoveRight.Click += new System.EventHandler(this._btnMoveRight_Click);
         // 
         // _enabledLanguagesListBox
         // 
         this._enabledLanguagesListBox.FormattingEnabled = true;
         resources.ApplyResources(this._enabledLanguagesListBox, "_enabledLanguagesListBox");
         this._enabledLanguagesListBox.Name = "_enabledLanguagesListBox";
         this._enabledLanguagesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
         this._enabledLanguagesListBox.SelectedIndexChanged += new System.EventHandler(this._enabledLanguagesListBox_SelectedIndexChanged);
         // 
         // _mainLanguageLabel
         // 
         resources.ApplyResources(this._mainLanguageLabel, "_mainLanguageLabel");
         this._mainLanguageLabel.Name = "_mainLanguageLabel";
         // 
         // _additionalLabel
         // 
         resources.ApplyResources(this._additionalLabel, "_additionalLabel");
         this._additionalLabel.Name = "_additionalLabel";
         // 
         // _languagesListBox
         // 
         this._languagesListBox.FormattingEnabled = true;
         resources.ApplyResources(this._languagesListBox, "_languagesListBox");
         this._languagesListBox.Name = "_languagesListBox";
         this._languagesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
         this._languagesListBox.SelectedIndexChanged += new System.EventHandler(this._languagesListBox_SelectedIndexChanged);
         // 
         // EnableLanguagesDialog
         // 
         this.AcceptButton = this._okButton;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "EnableLanguagesDialog";
         this.ShowInTaskbar = false;
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button _btnMoveTop;
      private System.Windows.Forms.Button _btnMoveLeft;
      private System.Windows.Forms.Button _btnMoveRight;
      private System.Windows.Forms.ListBox _enabledLanguagesListBox;
      private System.Windows.Forms.Label _mainLanguageLabel;
      private System.Windows.Forms.Label _additionalLabel;
      private System.Windows.Forms.ListBox _languagesListBox;
   }
}