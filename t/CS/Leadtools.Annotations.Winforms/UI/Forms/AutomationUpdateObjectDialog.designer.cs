namespace Leadtools.Annotations.WinForms
{
   partial class AutomationUpdateObjectDialog
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
         this._okButton = new System.Windows.Forms.Button();
         this._tabControl = new System.Windows.Forms.TabControl();
         this._propertiesTabPage = new System.Windows.Forms.TabPage();
         this._tabControlObjectProperties = new System.Windows.Forms.TabControl();
         this._commonPropertiesTabPage = new System.Windows.Forms.TabPage();
         this._rulerTabPage = new System.Windows.Forms.TabPage();
         this._textTabPage = new System.Windows.Forms.TabPage();
         this._noteTabPage = new System.Windows.Forms.TabPage();
         this._textRollUpTabPage = new System.Windows.Forms.TabPage();
         this._polyLineTabPage = new System.Windows.Forms.TabPage();
         this._curveTabPage = new System.Windows.Forms.TabPage();
         this._rubberStampTabPage = new System.Windows.Forms.TabPage();
         this._stampTabPage = new System.Windows.Forms.TabPage();
         this._hotSpotTabPage = new System.Windows.Forms.TabPage();
         this._freeHandHotSpotTabPage = new System.Windows.Forms.TabPage();
         this._pointerTabPage = new System.Windows.Forms.TabPage();
         this._mediaTabPage = new System.Windows.Forms.TabPage();
         this._encryptTabPage = new System.Windows.Forms.TabPage();
         this._pointTabPage = new System.Windows.Forms.TabPage();
         this._protractorTabPage = new System.Windows.Forms.TabPage();
         this._textPointerTabPage = new System.Windows.Forms.TabPage();
         this._crossProductTabPage = new System.Windows.Forms.TabPage();
         this._contentTabPage = new System.Windows.Forms.TabPage();
         this._contentTextBox = new System.Windows.Forms.TextBox();
         this._reviewsTabPage = new System.Windows.Forms.TabPage();
         this._objectPropertyGrid = new System.Windows.Forms.PropertyGrid();
         this._stickyNoteTabPage = new System.Windows.Forms.TabPage();
         this._automationReviewControl = new Leadtools.Annotations.WinForms.AutomationReviewControl();
         this._tabControl.SuspendLayout();
         this._propertiesTabPage.SuspendLayout();
         this._tabControlObjectProperties.SuspendLayout();
         this._contentTabPage.SuspendLayout();
         this._reviewsTabPage.SuspendLayout();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(250, 389);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 1;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _tabControl
         // 
         this._tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._tabControl.Controls.Add(this._propertiesTabPage);
         this._tabControl.Controls.Add(this._contentTabPage);
         this._tabControl.Controls.Add(this._reviewsTabPage);
         this._tabControl.Location = new System.Drawing.Point(13, 13);
         this._tabControl.Name = "_tabControl";
         this._tabControl.SelectedIndex = 0;
         this._tabControl.Size = new System.Drawing.Size(558, 370);
         this._tabControl.TabIndex = 0;
         // 
         // _propertiesTabPage
         // 
         this._propertiesTabPage.Controls.Add(this._tabControlObjectProperties);
         this._propertiesTabPage.Location = new System.Drawing.Point(4, 22);
         this._propertiesTabPage.Name = "_propertiesTabPage";
         this._propertiesTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._propertiesTabPage.Size = new System.Drawing.Size(550, 344);
         this._propertiesTabPage.TabIndex = 0;
         this._propertiesTabPage.Text = "Properties";
         this._propertiesTabPage.UseVisualStyleBackColor = true;
         // 
         // _tabControlObjectProperties
         // 
         this._tabControlObjectProperties.Controls.Add(this._commonPropertiesTabPage);
         this._tabControlObjectProperties.Controls.Add(this._rulerTabPage);
         this._tabControlObjectProperties.Controls.Add(this._textTabPage);
         this._tabControlObjectProperties.Controls.Add(this._noteTabPage);
         this._tabControlObjectProperties.Controls.Add(this._textRollUpTabPage);
         this._tabControlObjectProperties.Controls.Add(this._polyLineTabPage);
         this._tabControlObjectProperties.Controls.Add(this._curveTabPage);
         this._tabControlObjectProperties.Controls.Add(this._rubberStampTabPage);
         this._tabControlObjectProperties.Controls.Add(this._stampTabPage);
         this._tabControlObjectProperties.Controls.Add(this._hotSpotTabPage);
         this._tabControlObjectProperties.Controls.Add(this._freeHandHotSpotTabPage);
         this._tabControlObjectProperties.Controls.Add(this._pointerTabPage);
         this._tabControlObjectProperties.Controls.Add(this._mediaTabPage);
         this._tabControlObjectProperties.Controls.Add(this._encryptTabPage);
         this._tabControlObjectProperties.Controls.Add(this._pointTabPage);
         this._tabControlObjectProperties.Controls.Add(this._protractorTabPage);
         this._tabControlObjectProperties.Controls.Add(this._textPointerTabPage);
         this._tabControlObjectProperties.Controls.Add(this._crossProductTabPage);
         this._tabControlObjectProperties.Controls.Add(this._stickyNoteTabPage);
         this._tabControlObjectProperties.Location = new System.Drawing.Point(5, 3);
         this._tabControlObjectProperties.Name = "_tabControlObjectProperties";
         this._tabControlObjectProperties.SelectedIndex = 0;
         this._tabControlObjectProperties.Size = new System.Drawing.Size(539, 335);
         this._tabControlObjectProperties.TabIndex = 0;
         this._tabControlObjectProperties.Tag = "";
         // 
         // _commonPropertiesTabPage
         // 
         this._commonPropertiesTabPage.Location = new System.Drawing.Point(4, 22);
         this._commonPropertiesTabPage.Name = "_commonPropertiesTabPage";
         this._commonPropertiesTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._commonPropertiesTabPage.Size = new System.Drawing.Size(531, 309);
         this._commonPropertiesTabPage.TabIndex = 0;
         this._commonPropertiesTabPage.Tag = "-3";
         this._commonPropertiesTabPage.Text = "Common";
         this._commonPropertiesTabPage.UseVisualStyleBackColor = true;
         // 
         // _rulerTabPage
         // 
         this._rulerTabPage.Location = new System.Drawing.Point(4, 22);
         this._rulerTabPage.Name = "_rulerTabPage";
         this._rulerTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._rulerTabPage.Size = new System.Drawing.Size(531, 309);
         this._rulerTabPage.TabIndex = 1;
         this._rulerTabPage.Tag = "-24";
         this._rulerTabPage.Text = "Ruler";
         this._rulerTabPage.UseVisualStyleBackColor = true;
         // 
         // _textTabPage
         // 
         this._textTabPage.Location = new System.Drawing.Point(4, 22);
         this._textTabPage.Name = "_textTabPage";
         this._textTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._textTabPage.Size = new System.Drawing.Size(531, 309);
         this._textTabPage.TabIndex = 2;
         this._textTabPage.Tag = "-12";
         this._textTabPage.Text = "Text";
         this._textTabPage.UseVisualStyleBackColor = true;
         // 
         // _noteTabPage
         // 
         this._noteTabPage.Location = new System.Drawing.Point(4, 22);
         this._noteTabPage.Name = "_noteTabPage";
         this._noteTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._noteTabPage.Size = new System.Drawing.Size(531, 309);
         this._noteTabPage.TabIndex = 3;
         this._noteTabPage.Tag = "-15";
         this._noteTabPage.Text = "Note";
         this._noteTabPage.UseVisualStyleBackColor = true;
         // 
         // _textRollUpTabPage
         // 
         this._textRollUpTabPage.Location = new System.Drawing.Point(4, 22);
         this._textRollUpTabPage.Name = "_textRollUpTabPage";
         this._textRollUpTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._textRollUpTabPage.Size = new System.Drawing.Size(531, 309);
         this._textRollUpTabPage.TabIndex = 4;
         this._textRollUpTabPage.Tag = "-13";
         this._textRollUpTabPage.Text = "Text Rollup";
         this._textRollUpTabPage.UseVisualStyleBackColor = true;
         // 
         // _polyLineTabPage
         // 
         this._polyLineTabPage.Location = new System.Drawing.Point(4, 22);
         this._polyLineTabPage.Name = "_polyLineTabPage";
         this._polyLineTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._polyLineTabPage.Size = new System.Drawing.Size(531, 309);
         this._polyLineTabPage.TabIndex = 5;
         this._polyLineTabPage.Tag = "-5";
         this._polyLineTabPage.Text = "Polyline";
         this._polyLineTabPage.UseVisualStyleBackColor = true;
         // 
         // _curveTabPage
         // 
         this._curveTabPage.Location = new System.Drawing.Point(4, 22);
         this._curveTabPage.Name = "_curveTabPage";
         this._curveTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._curveTabPage.Size = new System.Drawing.Size(531, 309);
         this._curveTabPage.TabIndex = 6;
         this._curveTabPage.Tag = "-7";
         this._curveTabPage.Text = "Curve";
         this._curveTabPage.UseVisualStyleBackColor = true;
         // 
         // _rubberStampTabPage
         // 
         this._rubberStampTabPage.Location = new System.Drawing.Point(4, 22);
         this._rubberStampTabPage.Name = "_rubberStampTabPage";
         this._rubberStampTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._rubberStampTabPage.Size = new System.Drawing.Size(531, 309);
         this._rubberStampTabPage.TabIndex = 7;
         this._rubberStampTabPage.Tag = "-17";
         this._rubberStampTabPage.Text = "Rubber Stamp";
         this._rubberStampTabPage.UseVisualStyleBackColor = true;
         // 
         // _stampTabPage
         // 
         this._stampTabPage.Location = new System.Drawing.Point(4, 22);
         this._stampTabPage.Name = "_stampTabPage";
         this._stampTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._stampTabPage.Size = new System.Drawing.Size(531, 309);
         this._stampTabPage.TabIndex = 8;
         this._stampTabPage.Tag = "-16";
         this._stampTabPage.Text = "Stamp";
         this._stampTabPage.UseVisualStyleBackColor = true;
         // 
         // _hotSpotTabPage
         // 
         this._hotSpotTabPage.Location = new System.Drawing.Point(4, 22);
         this._hotSpotTabPage.Name = "_hotSpotTabPage";
         this._hotSpotTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._hotSpotTabPage.Size = new System.Drawing.Size(531, 309);
         this._hotSpotTabPage.TabIndex = 9;
         this._hotSpotTabPage.Tag = "-18";
         this._hotSpotTabPage.Text = "HotSpot";
         this._hotSpotTabPage.UseVisualStyleBackColor = true;
         // 
         // _freeHandHotSpotTabPage
         // 
         this._freeHandHotSpotTabPage.Location = new System.Drawing.Point(4, 22);
         this._freeHandHotSpotTabPage.Name = "_freeHandHotSpotTabPage";
         this._freeHandHotSpotTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._freeHandHotSpotTabPage.Size = new System.Drawing.Size(531, 309);
         this._freeHandHotSpotTabPage.TabIndex = 10;
         this._freeHandHotSpotTabPage.Tag = "-19";
         this._freeHandHotSpotTabPage.Text = "Free Hand Hot Spot";
         this._freeHandHotSpotTabPage.UseVisualStyleBackColor = true;
         // 
         // _pointerTabPage
         // 
         this._pointerTabPage.Location = new System.Drawing.Point(4, 22);
         this._pointerTabPage.Name = "_pointerTabPage";
         this._pointerTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._pointerTabPage.Size = new System.Drawing.Size(531, 309);
         this._pointerTabPage.TabIndex = 11;
         this._pointerTabPage.Tag = "-9";
         this._pointerTabPage.Text = "Pointer";
         this._pointerTabPage.UseVisualStyleBackColor = true;
         // 
         // _mediaTabPage
         // 
         this._mediaTabPage.Location = new System.Drawing.Point(4, 22);
         this._mediaTabPage.Name = "_mediaTabPage";
         this._mediaTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._mediaTabPage.Size = new System.Drawing.Size(531, 309);
         this._mediaTabPage.TabIndex = 12;
         this._mediaTabPage.Tag = "-30";
         this._mediaTabPage.Text = "Media";
         this._mediaTabPage.UseVisualStyleBackColor = true;
         // 
         // _encryptTabPage
         // 
         this._encryptTabPage.Location = new System.Drawing.Point(4, 22);
         this._encryptTabPage.Name = "_encryptTabPage";
         this._encryptTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._encryptTabPage.Size = new System.Drawing.Size(531, 309);
         this._encryptTabPage.TabIndex = 13;
         this._encryptTabPage.Tag = "-27";
         this._encryptTabPage.Text = "Encrypt";
         this._encryptTabPage.UseVisualStyleBackColor = true;
         // 
         // _pointTabPage
         // 
         this._pointTabPage.Location = new System.Drawing.Point(4, 22);
         this._pointTabPage.Name = "_pointTabPage";
         this._pointTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._pointTabPage.Size = new System.Drawing.Size(531, 309);
         this._pointTabPage.TabIndex = 14;
         this._pointTabPage.Tag = "-21";
         this._pointTabPage.Text = "Point";
         this._pointTabPage.UseVisualStyleBackColor = true;
         // 
         // _protractorTabPage
         // 
         this._protractorTabPage.Location = new System.Drawing.Point(4, 22);
         this._protractorTabPage.Name = "_protractorTabPage";
         this._protractorTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._protractorTabPage.Size = new System.Drawing.Size(531, 309);
         this._protractorTabPage.TabIndex = 15;
         this._protractorTabPage.Tag = "-25";
         this._protractorTabPage.Text = "Protractor";
         this._protractorTabPage.UseVisualStyleBackColor = true;
         // 
         // _textPointerTabPage
         // 
         this._textPointerTabPage.Location = new System.Drawing.Point(4, 22);
         this._textPointerTabPage.Name = "_textPointerTabPage";
         this._textPointerTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._textPointerTabPage.Size = new System.Drawing.Size(531, 309);
         this._textPointerTabPage.TabIndex = 16;
         this._textPointerTabPage.Tag = "-14";
         this._textPointerTabPage.Text = "Text Pointer";
         this._textPointerTabPage.UseVisualStyleBackColor = true;
         // 
         // _crossProductTabPage
         // 
         this._crossProductTabPage.Location = new System.Drawing.Point(4, 22);
         this._crossProductTabPage.Name = "_crossProductTabPage";
         this._crossProductTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._crossProductTabPage.Size = new System.Drawing.Size(531, 309);
         this._crossProductTabPage.TabIndex = 17;
         this._crossProductTabPage.Tag = "-26";
         this._crossProductTabPage.Text = "Cross Product";
         this._crossProductTabPage.UseVisualStyleBackColor = true;
         // 
         // _contentTabPage
         // 
         this._contentTabPage.Controls.Add(this._contentTextBox);
         this._contentTabPage.Location = new System.Drawing.Point(4, 22);
         this._contentTabPage.Name = "_contentTabPage";
         this._contentTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._contentTabPage.Size = new System.Drawing.Size(550, 344);
         this._contentTabPage.TabIndex = 1;
         this._contentTabPage.Text = "Content";
         this._contentTabPage.UseVisualStyleBackColor = true;
         // 
         // _contentTextBox
         // 
         this._contentTextBox.AcceptsReturn = true;
         this._contentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._contentTextBox.Location = new System.Drawing.Point(3, 3);
         this._contentTextBox.Multiline = true;
         this._contentTextBox.Name = "_contentTextBox";
         this._contentTextBox.Size = new System.Drawing.Size(544, 338);
         this._contentTextBox.TabIndex = 0;
         // 
         // _reviewsTabPage
         // 
         this._reviewsTabPage.Controls.Add(this._automationReviewControl);
         this._reviewsTabPage.Location = new System.Drawing.Point(4, 22);
         this._reviewsTabPage.Name = "_reviewsTabPage";
         this._reviewsTabPage.Size = new System.Drawing.Size(550, 344);
         this._reviewsTabPage.TabIndex = 2;
         this._reviewsTabPage.Text = "Reviews";
         this._reviewsTabPage.UseVisualStyleBackColor = true;
         // 
         // _objectPropertyGrid
         // 
         this._objectPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
         this._objectPropertyGrid.Location = new System.Drawing.Point(3, 3);
         this._objectPropertyGrid.Name = "_objectPropertyGrid";
         this._objectPropertyGrid.Size = new System.Drawing.Size(544, 276);
         this._objectPropertyGrid.TabIndex = 0;
         this._objectPropertyGrid.ToolbarVisible = false;
         this._objectPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this._objectPropertyGrid_PropertyValueChanged);
         // 
         // _stickyNoteTabPage
         // 
         this._stickyNoteTabPage.Location = new System.Drawing.Point(4, 22);
         this._stickyNoteTabPage.Name = "_stickyNoteTabPage";
         this._stickyNoteTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._stickyNoteTabPage.Size = new System.Drawing.Size(531, 309);
         this._stickyNoteTabPage.TabIndex = 18;
         this._stickyNoteTabPage.Tag = "-32";
         this._stickyNoteTabPage.Text = "Sticky Note";
         this._stickyNoteTabPage.UseVisualStyleBackColor = true;
         // 
         // _automationReviewControl
         // 
         this._automationReviewControl.Location = new System.Drawing.Point(3, -1);
         this._automationReviewControl.Name = "_automationReviewControl";
         this._automationReviewControl.Size = new System.Drawing.Size(544, 342);
         this._automationReviewControl.TabIndex = 0;
         // 
         // AutomationUpdateObjectDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(583, 424);
         this.Controls.Add(this._tabControl);
         this.Controls.Add(this._okButton);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AutomationUpdateObjectDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Object Properties";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutomationUpdateObjectDialog_FormClosing);
         this._tabControl.ResumeLayout(false);
         this._propertiesTabPage.ResumeLayout(false);
         this._tabControlObjectProperties.ResumeLayout(false);
         this._contentTabPage.ResumeLayout(false);
         this._contentTabPage.PerformLayout();
         this._reviewsTabPage.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.TabControl _tabControl;
      private System.Windows.Forms.TabPage _propertiesTabPage;
      private System.Windows.Forms.TabPage _contentTabPage;
      private System.Windows.Forms.TabPage _reviewsTabPage;
      private System.Windows.Forms.PropertyGrid _objectPropertyGrid;
      private System.Windows.Forms.TextBox _contentTextBox;
      private System.Windows.Forms.TabControl _tabControlObjectProperties;
      private System.Windows.Forms.TabPage _commonPropertiesTabPage;
      private System.Windows.Forms.TabPage _rulerTabPage;
      private System.Windows.Forms.TabPage _textTabPage;
      private System.Windows.Forms.TabPage _noteTabPage;
      private System.Windows.Forms.TabPage _textRollUpTabPage;
      private System.Windows.Forms.TabPage _polyLineTabPage;
      private System.Windows.Forms.TabPage _curveTabPage;
      private System.Windows.Forms.TabPage _rubberStampTabPage;
      private System.Windows.Forms.TabPage _stampTabPage;
      private System.Windows.Forms.TabPage _hotSpotTabPage;
      private System.Windows.Forms.TabPage _freeHandHotSpotTabPage;
      private System.Windows.Forms.TabPage _pointerTabPage;
      private System.Windows.Forms.TabPage _mediaTabPage;
      private System.Windows.Forms.TabPage _encryptTabPage;
      private System.Windows.Forms.TabPage _pointTabPage;
      private System.Windows.Forms.TabPage _protractorTabPage;
      private System.Windows.Forms.TabPage _textPointerTabPage;
      private AutomationReviewControl _automationReviewControl;
      private System.Windows.Forms.TabPage _crossProductTabPage;
      private System.Windows.Forms.TabPage _stickyNoteTabPage;
   }
}