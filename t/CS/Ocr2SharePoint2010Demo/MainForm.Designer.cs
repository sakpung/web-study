namespace Ocr2SharePointDemo
{
   partial class MainForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._aboutButton = new System.Windows.Forms.Button();
         this._previousButton = new System.Windows.Forms.Button();
         this._nextButton = new System.Windows.Forms.Button();
         this._exitButton = new System.Windows.Forms.Button();
         this._operationPanel = new System.Windows.Forms.Panel();
         this._operationLabel = new System.Windows.Forms.Label();
         this._operationProgressBar = new System.Windows.Forms.ProgressBar();
         this._mainWizardControl = new Ocr2SharePointDemo.WizardControl();
         this._serverPropertiesTabPage = new System.Windows.Forms.TabPage();
         this._sharePointServerSettingsControl = new Ocr2SharePointDemo.SharePointServerSettingsControl();
         this._sharePointBrowserTabPage = new System.Windows.Forms.TabPage();
         this._sharePointBrowserControl = new Ocr2SharePointDemo.SharePointBrowserControl();
         this._selectImageDocumentFileTabPage = new System.Windows.Forms.TabPage();
         this._selectImageDocumentFileControl = new Ocr2SharePointDemo.SelectImageDocumentControl();
         this._recognizeAndUploadTabPage = new System.Windows.Forms.TabPage();
         this._recognizeAndUploadControl = new Ocr2SharePointDemo.RecognizeAndUploadControl();
         this._operationPanel.SuspendLayout();
         this._mainWizardControl.SuspendLayout();
         this._serverPropertiesTabPage.SuspendLayout();
         this._sharePointBrowserTabPage.SuspendLayout();
         this._selectImageDocumentFileTabPage.SuspendLayout();
         this._recognizeAndUploadTabPage.SuspendLayout();
         this.SuspendLayout();
         // 
         // _aboutButton
         // 
         this._aboutButton.Location = new System.Drawing.Point(13, 441);
         this._aboutButton.Name = "_aboutButton";
         this._aboutButton.Size = new System.Drawing.Size(75, 23);
         this._aboutButton.TabIndex = 1;
         this._aboutButton.Text = "&About...";
         this._aboutButton.UseVisualStyleBackColor = true;
         this._aboutButton.Click += new System.EventHandler(this._aboutButton_Click);
         // 
         // _previousButton
         // 
         this._previousButton.Location = new System.Drawing.Point(518, 441);
         this._previousButton.Name = "_previousButton";
         this._previousButton.Size = new System.Drawing.Size(75, 23);
         this._previousButton.TabIndex = 2;
         this._previousButton.Text = "&Previous";
         this._previousButton.UseVisualStyleBackColor = true;
         this._previousButton.Click += new System.EventHandler(this._previousButton_Click);
         // 
         // _nextButton
         // 
         this._nextButton.Location = new System.Drawing.Point(599, 441);
         this._nextButton.Name = "_nextButton";
         this._nextButton.Size = new System.Drawing.Size(75, 23);
         this._nextButton.TabIndex = 3;
         this._nextButton.Text = "&Next";
         this._nextButton.UseVisualStyleBackColor = true;
         this._nextButton.Click += new System.EventHandler(this._nextButton_Click);
         // 
         // _exitButton
         // 
         this._exitButton.Location = new System.Drawing.Point(692, 441);
         this._exitButton.Name = "_exitButton";
         this._exitButton.Size = new System.Drawing.Size(75, 23);
         this._exitButton.TabIndex = 4;
         this._exitButton.Text = "E&xit";
         this._exitButton.UseVisualStyleBackColor = true;
         this._exitButton.Click += new System.EventHandler(this._exitButton_Click);
         // 
         // _operationPanel
         // 
         this._operationPanel.Controls.Add(this._operationLabel);
         this._operationPanel.Controls.Add(this._operationProgressBar);
         this._operationPanel.Location = new System.Drawing.Point(13, 364);
         this._operationPanel.Name = "_operationPanel";
         this._operationPanel.Size = new System.Drawing.Size(758, 71);
         this._operationPanel.TabIndex = 5;
         // 
         // _operationLabel
         // 
         this._operationLabel.Location = new System.Drawing.Point(4, 7);
         this._operationLabel.Name = "_operationLabel";
         this._operationLabel.Size = new System.Drawing.Size(748, 23);
         this._operationLabel.TabIndex = 1;
         this._operationLabel.Text = "_operationLabel";
         this._operationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _operationProgressBar
         // 
         this._operationProgressBar.Location = new System.Drawing.Point(212, 33);
         this._operationProgressBar.Name = "_operationProgressBar";
         this._operationProgressBar.Size = new System.Drawing.Size(335, 23);
         this._operationProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
         this._operationProgressBar.TabIndex = 0;
         // 
         // _mainWizardControl
         // 
         this._mainWizardControl.Controls.Add(this._serverPropertiesTabPage);
         this._mainWizardControl.Controls.Add(this._sharePointBrowserTabPage);
         this._mainWizardControl.Controls.Add(this._selectImageDocumentFileTabPage);
         this._mainWizardControl.Controls.Add(this._recognizeAndUploadTabPage);
         this._mainWizardControl.Location = new System.Drawing.Point(13, 13);
         this._mainWizardControl.Name = "_mainWizardControl";
         this._mainWizardControl.SelectedIndex = 0;
         this._mainWizardControl.Size = new System.Drawing.Size(758, 345);
         this._mainWizardControl.TabIndex = 0;
         // 
         // _serverPropertiesTabPage
         // 
         this._serverPropertiesTabPage.Controls.Add(this._sharePointServerSettingsControl);
         this._serverPropertiesTabPage.Location = new System.Drawing.Point(4, 22);
         this._serverPropertiesTabPage.Name = "_serverPropertiesTabPage";
         this._serverPropertiesTabPage.Size = new System.Drawing.Size(750, 319);
         this._serverPropertiesTabPage.TabIndex = 0;
         this._serverPropertiesTabPage.Text = "ServerProperties";
         this._serverPropertiesTabPage.UseVisualStyleBackColor = true;
         // 
         // _sharePointServerSettingsControl
         // 
         this._sharePointServerSettingsControl.Location = new System.Drawing.Point(0, 0);
         this._sharePointServerSettingsControl.Name = "_sharePointServerSettingsControl";
         this._sharePointServerSettingsControl.Size = new System.Drawing.Size(740, 330);
         this._sharePointServerSettingsControl.TabIndex = 0;
         // 
         // _sharePointBrowserTabPage
         // 
         this._sharePointBrowserTabPage.Controls.Add(this._sharePointBrowserControl);
         this._sharePointBrowserTabPage.Location = new System.Drawing.Point(4, 22);
         this._sharePointBrowserTabPage.Name = "_sharePointBrowserTabPage";
         this._sharePointBrowserTabPage.Size = new System.Drawing.Size(750, 319);
         this._sharePointBrowserTabPage.TabIndex = 2;
         this._sharePointBrowserTabPage.Text = "SharePointBrowser";
         this._sharePointBrowserTabPage.UseVisualStyleBackColor = true;
         // 
         // _sharePointBrowserControl
         // 
         this._sharePointBrowserControl.Location = new System.Drawing.Point(0, 0);
         this._sharePointBrowserControl.Name = "_sharePointBrowserControl";
         this._sharePointBrowserControl.Size = new System.Drawing.Size(740, 330);
         this._sharePointBrowserControl.TabIndex = 0;
         // 
         // _selectImageDocumentFileTabPage
         // 
         this._selectImageDocumentFileTabPage.Controls.Add(this._selectImageDocumentFileControl);
         this._selectImageDocumentFileTabPage.Location = new System.Drawing.Point(4, 22);
         this._selectImageDocumentFileTabPage.Name = "_selectImageDocumentFileTabPage";
         this._selectImageDocumentFileTabPage.Size = new System.Drawing.Size(750, 319);
         this._selectImageDocumentFileTabPage.TabIndex = 1;
         this._selectImageDocumentFileTabPage.Text = "ImageDocumentFile";
         this._selectImageDocumentFileTabPage.UseVisualStyleBackColor = true;
         // 
         // _selectImageDocumentFileControl
         // 
         this._selectImageDocumentFileControl.Location = new System.Drawing.Point(0, 0);
         this._selectImageDocumentFileControl.Name = "_selectImageDocumentFileControl";
         this._selectImageDocumentFileControl.Size = new System.Drawing.Size(740, 330);
         this._selectImageDocumentFileControl.TabIndex = 0;
         // 
         // _recognizeAndUploadTabPage
         // 
         this._recognizeAndUploadTabPage.Controls.Add(this._recognizeAndUploadControl);
         this._recognizeAndUploadTabPage.Location = new System.Drawing.Point(4, 22);
         this._recognizeAndUploadTabPage.Name = "_recognizeAndUploadTabPage";
         this._recognizeAndUploadTabPage.Size = new System.Drawing.Size(750, 319);
         this._recognizeAndUploadTabPage.TabIndex = 4;
         this._recognizeAndUploadTabPage.Text = "RecognizeAndUpload";
         this._recognizeAndUploadTabPage.UseVisualStyleBackColor = true;
         // 
         // _recognizeAndUploadControl
         // 
         this._recognizeAndUploadControl.Location = new System.Drawing.Point(0, 0);
         this._recognizeAndUploadControl.Name = "_recognizeAndUploadControl";
         this._recognizeAndUploadControl.Size = new System.Drawing.Size(740, 330);
         this._recognizeAndUploadControl.TabIndex = 0;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(777, 474);
         this.Controls.Add(this._operationPanel);
         this.Controls.Add(this._previousButton);
         this.Controls.Add(this._nextButton);
         this.Controls.Add(this._exitButton);
         this.Controls.Add(this._aboutButton);
         this.Controls.Add(this._mainWizardControl);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.Text = "MainForm";
         this._operationPanel.ResumeLayout(false);
         this._mainWizardControl.ResumeLayout(false);
         this._serverPropertiesTabPage.ResumeLayout(false);
         this._sharePointBrowserTabPage.ResumeLayout(false);
         this._selectImageDocumentFileTabPage.ResumeLayout(false);
         this._recognizeAndUploadTabPage.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private WizardControl _mainWizardControl;
      private System.Windows.Forms.Button _aboutButton;
      private System.Windows.Forms.Button _previousButton;
      private System.Windows.Forms.Button _nextButton;
      private System.Windows.Forms.Button _exitButton;
      private System.Windows.Forms.TabPage _serverPropertiesTabPage;
      private SharePointServerSettingsControl _sharePointServerSettingsControl;
      private System.Windows.Forms.Panel _operationPanel;
      private System.Windows.Forms.Label _operationLabel;
      private System.Windows.Forms.ProgressBar _operationProgressBar;
      private System.Windows.Forms.TabPage _selectImageDocumentFileTabPage;
      private SelectImageDocumentControl _selectImageDocumentFileControl;
      private System.Windows.Forms.TabPage _sharePointBrowserTabPage;
      private SharePointBrowserControl _sharePointBrowserControl;
      private System.Windows.Forms.TabPage _recognizeAndUploadTabPage;
      private RecognizeAndUploadControl _recognizeAndUploadControl;
   }
}