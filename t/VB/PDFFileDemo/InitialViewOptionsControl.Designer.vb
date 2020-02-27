Imports Microsoft.VisualBasic
Imports System
Namespace PDFFileDemo
   Public Partial Class InitialViewOptionsControl
	  ''' <summary> 
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.IContainer = Nothing

	  ''' <summary> 
	  ''' Clean up any resources being used.
	  ''' </summary>
	  ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		 If disposing AndAlso (Not components Is Nothing) Then
			components.Dispose()
		 End If
		 MyBase.Dispose(disposing)
	  End Sub

	  #Region "Component Designer generated code"

	  ''' <summary> 
	  ''' Required method for Designer support - do not modify 
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
         Me.groupBox5 = New System.Windows.Forms.GroupBox()
         Me._hideWindowControlsCheckBox = New System.Windows.Forms.CheckBox()
         Me._hideToolBarCheckBox = New System.Windows.Forms.CheckBox()
         Me._hideMenuBarCheckBox = New System.Windows.Forms.CheckBox()
         Me.groupBox4 = New System.Windows.Forms.GroupBox()
         Me._showDocumentTitleComboBox = New System.Windows.Forms.ComboBox()
         Me.label10 = New System.Windows.Forms.Label()
         Me._centerWindowCheckBox = New System.Windows.Forms.CheckBox()
         Me._resizeWindowCheckBox = New System.Windows.Forms.CheckBox()
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         Me._numberOfPagesLabel = New System.Windows.Forms.Label()
         Me._initialPageNumberEditBox = New System.Windows.Forms.TextBox()
         Me.label8 = New System.Windows.Forms.Label()
         Me._pageFitTypeComboBox = New System.Windows.Forms.ComboBox()
         Me.label7 = New System.Windows.Forms.Label()
         Me._pageLayoutComboBox = New System.Windows.Forms.ComboBox()
         Me.label6 = New System.Windows.Forms.Label()
         Me._pageModeComboBox = New System.Windows.Forms.ComboBox()
         Me.label5 = New System.Windows.Forms.Label()
         Me.groupBox5.SuspendLayout()
         Me.groupBox4.SuspendLayout()
         Me.groupBox3.SuspendLayout()
         Me.SuspendLayout()
         '
         'groupBox5
         '
         Me.groupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.groupBox5.Controls.Add(Me._hideWindowControlsCheckBox)
         Me.groupBox5.Controls.Add(Me._hideToolBarCheckBox)
         Me.groupBox5.Controls.Add(Me._hideMenuBarCheckBox)
         Me.groupBox5.Location = New System.Drawing.Point(3, 239)
         Me.groupBox5.Name = "groupBox5"
         Me.groupBox5.Size = New System.Drawing.Size(384, 89)
         Me.groupBox5.TabIndex = 5
         Me.groupBox5.TabStop = False
         Me.groupBox5.Text = "User Interface Options"
         '
         '_hideWindowControlsCheckBox
         '
         Me._hideWindowControlsCheckBox.AutoSize = True
         Me._hideWindowControlsCheckBox.Location = New System.Drawing.Point(23, 65)
         Me._hideWindowControlsCheckBox.Name = "_hideWindowControlsCheckBox"
         Me._hideWindowControlsCheckBox.Size = New System.Drawing.Size(132, 17)
         Me._hideWindowControlsCheckBox.TabIndex = 13
         Me._hideWindowControlsCheckBox.Text = "Hide windows co&ntrols"
         Me._hideWindowControlsCheckBox.UseVisualStyleBackColor = True
         '
         '_hideToolBarCheckBox
         '
         Me._hideToolBarCheckBox.AutoSize = True
         Me._hideToolBarCheckBox.Location = New System.Drawing.Point(23, 42)
         Me._hideToolBarCheckBox.Name = "_hideToolBarCheckBox"
         Me._hideToolBarCheckBox.Size = New System.Drawing.Size(83, 17)
         Me._hideToolBarCheckBox.TabIndex = 12
         Me._hideToolBarCheckBox.Text = "Hide tool&bar"
         Me._hideToolBarCheckBox.UseVisualStyleBackColor = True
         '
         '_hideMenuBarCheckBox
         '
         Me._hideMenuBarCheckBox.AutoSize = True
         Me._hideMenuBarCheckBox.Location = New System.Drawing.Point(23, 19)
         Me._hideMenuBarCheckBox.Name = "_hideMenuBarCheckBox"
         Me._hideMenuBarCheckBox.Size = New System.Drawing.Size(95, 17)
         Me._hideMenuBarCheckBox.TabIndex = 11
         Me._hideMenuBarCheckBox.Text = "Hide men&u bar"
         Me._hideMenuBarCheckBox.UseVisualStyleBackColor = True
         '
         'groupBox4
         '
         Me.groupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.groupBox4.Controls.Add(Me._showDocumentTitleComboBox)
         Me.groupBox4.Controls.Add(Me.label10)
         Me.groupBox4.Controls.Add(Me._centerWindowCheckBox)
         Me.groupBox4.Controls.Add(Me._resizeWindowCheckBox)
         Me.groupBox4.Location = New System.Drawing.Point(6, 137)
         Me.groupBox4.Name = "groupBox4"
         Me.groupBox4.Size = New System.Drawing.Size(381, 96)
         Me.groupBox4.TabIndex = 4
         Me.groupBox4.TabStop = False
         Me.groupBox4.Text = "Window Options"
         '
         '_showDocumentTitleComboBox
         '
         Me._showDocumentTitleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._showDocumentTitleComboBox.FormattingEnabled = True
         Me._showDocumentTitleComboBox.Location = New System.Drawing.Point(97, 65)
         Me._showDocumentTitleComboBox.Name = "_showDocumentTitleComboBox"
         Me._showDocumentTitleComboBox.Size = New System.Drawing.Size(162, 21)
         Me._showDocumentTitleComboBox.TabIndex = 10
         '
         'label10
         '
         Me.label10.AutoSize = True
         Me.label10.Location = New System.Drawing.Point(35, 68)
         Me.label10.Name = "label10"
         Me.label10.Size = New System.Drawing.Size(37, 13)
         Me.label10.TabIndex = 9
         Me.label10.Text = "Sho&w:"
         '
         '_centerWindowCheckBox
         '
         Me._centerWindowCheckBox.AutoSize = True
         Me._centerWindowCheckBox.Location = New System.Drawing.Point(20, 42)
         Me._centerWindowCheckBox.Name = "_centerWindowCheckBox"
         Me._centerWindowCheckBox.Size = New System.Drawing.Size(146, 17)
         Me._centerWindowCheckBox.TabIndex = 9
         Me._centerWindowCheckBox.Text = "&Center window on screen"
         Me._centerWindowCheckBox.UseVisualStyleBackColor = True
         '
         '_resizeWindowCheckBox
         '
         Me._resizeWindowCheckBox.AutoSize = True
         Me._resizeWindowCheckBox.Location = New System.Drawing.Point(20, 19)
         Me._resizeWindowCheckBox.Name = "_resizeWindowCheckBox"
         Me._resizeWindowCheckBox.Size = New System.Drawing.Size(162, 17)
         Me._resizeWindowCheckBox.TabIndex = 8
         Me._resizeWindowCheckBox.Text = "&Resize window to initial page"
         Me._resizeWindowCheckBox.UseVisualStyleBackColor = True
         '
         'groupBox3
         '
         Me.groupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.groupBox3.Controls.Add(Me._numberOfPagesLabel)
         Me.groupBox3.Controls.Add(Me._initialPageNumberEditBox)
         Me.groupBox3.Controls.Add(Me.label8)
         Me.groupBox3.Controls.Add(Me._pageFitTypeComboBox)
         Me.groupBox3.Controls.Add(Me.label7)
         Me.groupBox3.Controls.Add(Me._pageLayoutComboBox)
         Me.groupBox3.Controls.Add(Me.label6)
         Me.groupBox3.Controls.Add(Me._pageModeComboBox)
         Me.groupBox3.Controls.Add(Me.label5)
         Me.groupBox3.Location = New System.Drawing.Point(3, 3)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(384, 128)
         Me.groupBox3.TabIndex = 3
         Me.groupBox3.TabStop = False
         Me.groupBox3.Text = "Layout and Page Mode"
         '
         '_numberOfPagesLabel
         '
         Me._numberOfPagesLabel.AutoSize = True
         Me._numberOfPagesLabel.Location = New System.Drawing.Point(182, 103)
         Me._numberOfPagesLabel.Name = "_numberOfPagesLabel"
         Me._numberOfPagesLabel.Size = New System.Drawing.Size(25, 13)
         Me._numberOfPagesLabel.TabIndex = 8
         Me._numberOfPagesLabel.Text = "of 0"
         '
         '_initialPageNumberEditBox
         '
         Me._initialPageNumberEditBox.Location = New System.Drawing.Point(100, 100)
         Me._initialPageNumberEditBox.Name = "_initialPageNumberEditBox"
         Me._initialPageNumberEditBox.Size = New System.Drawing.Size(76, 20)
         Me._initialPageNumberEditBox.TabIndex = 7
         '
         'label8
         '
         Me.label8.AutoSize = True
         Me.label8.Location = New System.Drawing.Point(20, 103)
         Me.label8.Name = "label8"
         Me.label8.Size = New System.Drawing.Size(72, 13)
         Me.label8.TabIndex = 6
         Me.label8.Text = "&Open to page"
         '
         '_pageFitTypeComboBox
         '
         Me._pageFitTypeComboBox.FormattingEnabled = True
         Me._pageFitTypeComboBox.Location = New System.Drawing.Point(100, 73)
         Me._pageFitTypeComboBox.Name = "_pageFitTypeComboBox"
         Me._pageFitTypeComboBox.Size = New System.Drawing.Size(255, 21)
         Me._pageFitTypeComboBox.TabIndex = 5
         '
         'label7
         '
         Me.label7.AutoSize = True
         Me.label7.Location = New System.Drawing.Point(20, 76)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(69, 13)
         Me.label7.TabIndex = 4
         Me.label7.Text = "Page &fit type:"
         '
         '_pageLayoutComboBox
         '
         Me._pageLayoutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._pageLayoutComboBox.FormattingEnabled = True
         Me._pageLayoutComboBox.Location = New System.Drawing.Point(100, 46)
         Me._pageLayoutComboBox.Name = "_pageLayoutComboBox"
         Me._pageLayoutComboBox.Size = New System.Drawing.Size(255, 21)
         Me._pageLayoutComboBox.TabIndex = 3
         '
         'label6
         '
         Me.label6.AutoSize = True
         Me.label6.Location = New System.Drawing.Point(20, 49)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(66, 13)
         Me.label6.TabIndex = 2
         Me.label6.Text = "Page &layout:"
         '
         '_pageModeComboBox
         '
         Me._pageModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._pageModeComboBox.FormattingEnabled = True
         Me._pageModeComboBox.Location = New System.Drawing.Point(100, 19)
         Me._pageModeComboBox.Name = "_pageModeComboBox"
         Me._pageModeComboBox.Size = New System.Drawing.Size(255, 21)
         Me._pageModeComboBox.TabIndex = 1
         '
         'label5
         '
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(20, 22)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(64, 13)
         Me.label5.TabIndex = 0
         Me.label5.Text = "Page &mode:"
         '
         'InitialViewOptionsControl
         '
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.groupBox5)
         Me.Controls.Add(Me.groupBox4)
         Me.Controls.Add(Me.groupBox3)
         Me.Name = "InitialViewOptionsControl"
         Me.Size = New System.Drawing.Size(395, 336)
         Me.groupBox5.ResumeLayout(False)
         Me.groupBox5.PerformLayout()
         Me.groupBox4.ResumeLayout(False)
         Me.groupBox4.PerformLayout()
         Me.groupBox3.ResumeLayout(False)
         Me.groupBox3.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

	  #End Region

	  Private groupBox5 As System.Windows.Forms.GroupBox
      Private WithEvents _hideWindowControlsCheckBox As System.Windows.Forms.CheckBox
	  Private _hideToolBarCheckBox As System.Windows.Forms.CheckBox
      Private WithEvents _hideMenuBarCheckBox As System.Windows.Forms.CheckBox
	  Private groupBox4 As System.Windows.Forms.GroupBox
	  Private _showDocumentTitleComboBox As System.Windows.Forms.ComboBox
	  Private label10 As System.Windows.Forms.Label
	  Private _centerWindowCheckBox As System.Windows.Forms.CheckBox
	  Private _resizeWindowCheckBox As System.Windows.Forms.CheckBox
	  Private groupBox3 As System.Windows.Forms.GroupBox
	  Private _numberOfPagesLabel As System.Windows.Forms.Label
	  Private _initialPageNumberEditBox As System.Windows.Forms.TextBox
	  Private label8 As System.Windows.Forms.Label
	  Private _pageFitTypeComboBox As System.Windows.Forms.ComboBox
	  Private label7 As System.Windows.Forms.Label
	  Private _pageLayoutComboBox As System.Windows.Forms.ComboBox
	  Private label6 As System.Windows.Forms.Label
	  Private _pageModeComboBox As System.Windows.Forms.ComboBox
	  Private label5 As System.Windows.Forms.Label
   End Class
End Namespace
