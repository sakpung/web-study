Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Wizard
   Partial Public Class WizardSheet
	  ''' <summary> 
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.IContainer = Nothing

	  ''' <summary> 
	  ''' Clean up any resources being used.
	  ''' </summary>
	  ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		 If disposing AndAlso (components IsNot Nothing) Then
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
            Me.pnlButtons = New System.Windows.Forms.Panel
            Me.etchedLine1 = New Leadtools.Wizard.EtchedLine
            Me.btnFinish = New System.Windows.Forms.Button
            Me.btnCancel = New System.Windows.Forms.Button
            Me.btnNext = New System.Windows.Forms.Button
            Me.btnBack = New System.Windows.Forms.Button
            Me.pnlPages = New System.Windows.Forms.Panel
            Me.buttonAbout = New System.Windows.Forms.Button
            Me.buttonOption1 = New System.Windows.Forms.Button
            Me.buttonShowHelp = New System.Windows.Forms.Button
            Me.pnlButtons.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlButtons
            '
            Me.pnlButtons.BackColor = System.Drawing.SystemColors.Control
            Me.pnlButtons.Controls.Add(Me.buttonShowHelp)
            Me.pnlButtons.Controls.Add(Me.buttonOption1)
            Me.pnlButtons.Controls.Add(Me.buttonAbout)
            Me.pnlButtons.Controls.Add(Me.etchedLine1)
            Me.pnlButtons.Controls.Add(Me.btnFinish)
            Me.pnlButtons.Controls.Add(Me.btnCancel)
            Me.pnlButtons.Controls.Add(Me.btnNext)
            Me.pnlButtons.Controls.Add(Me.btnBack)
            Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlButtons.Location = New System.Drawing.Point(0, 513)
            Me.pnlButtons.Name = "pnlButtons"
            Me.pnlButtons.Size = New System.Drawing.Size(796, 46)
            Me.pnlButtons.TabIndex = 0
            '
            'etchedLine1
            '
            Me.etchedLine1.BackColor = System.Drawing.SystemColors.Control
            Me.etchedLine1.DarkColor = System.Drawing.SystemColors.ControlDark
            Me.etchedLine1.Dock = System.Windows.Forms.DockStyle.Top
            Me.etchedLine1.LightColor = System.Drawing.SystemColors.ControlLightLight
            Me.etchedLine1.Location = New System.Drawing.Point(0, 0)
            Me.etchedLine1.Name = "etchedLine1"
            Me.etchedLine1.Size = New System.Drawing.Size(796, 9)
            Me.etchedLine1.TabIndex = 4
            Me.etchedLine1.TabStop = False
            '
            'btnFinish
            '
            Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnFinish.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnFinish.Location = New System.Drawing.Point(575, 11)
            Me.btnFinish.Name = "btnFinish"
            Me.btnFinish.Size = New System.Drawing.Size(83, 29)
            Me.btnFinish.TabIndex = 3
            Me.btnFinish.Text = "Finish"
            Me.btnFinish.UseVisualStyleBackColor = True
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Location = New System.Drawing.Point(707, 11)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(83, 29)
            Me.btnCancel.TabIndex = 2
            Me.btnCancel.Text = "Cancel"
            Me.btnCancel.UseVisualStyleBackColor = True
            '
            'btnNext
            '
            Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnNext.Location = New System.Drawing.Point(575, 11)
            Me.btnNext.Name = "btnNext"
            Me.btnNext.Size = New System.Drawing.Size(83, 29)
            Me.btnNext.TabIndex = 1
            Me.btnNext.Text = "&Next >"
            Me.btnNext.UseVisualStyleBackColor = True
            '
            'btnBack
            '
            Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnBack.Location = New System.Drawing.Point(488, 11)
            Me.btnBack.Name = "btnBack"
            Me.btnBack.Size = New System.Drawing.Size(83, 29)
            Me.btnBack.TabIndex = 0
            Me.btnBack.Text = "< &Back"
            Me.btnBack.UseVisualStyleBackColor = True
            '
            'pnlPages
            '
            Me.pnlPages.BackColor = System.Drawing.SystemColors.Control
            Me.pnlPages.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlPages.ForeColor = System.Drawing.SystemColors.ControlText
            Me.pnlPages.Location = New System.Drawing.Point(0, 0)
            Me.pnlPages.Name = "pnlPages"
            Me.pnlPages.Size = New System.Drawing.Size(796, 513)
            Me.pnlPages.TabIndex = 1
            '
            'buttonAbout
            '
            Me.buttonAbout.Location = New System.Drawing.Point(12, 11)
            Me.buttonAbout.Name = "buttonAbout"
            Me.buttonAbout.Size = New System.Drawing.Size(83, 29)
            Me.buttonAbout.TabIndex = 7
            Me.buttonAbout.Text = "About"
            Me.buttonAbout.UseVisualStyleBackColor = True
            '
            'buttonOption1
            '
            Me.buttonOption1.Location = New System.Drawing.Point(178, 11)
            Me.buttonOption1.Name = "buttonOption1"
            Me.buttonOption1.Size = New System.Drawing.Size(83, 29)
            Me.buttonOption1.TabIndex = 8
            Me.buttonOption1.Text = "Option1"
            Me.buttonOption1.UseVisualStyleBackColor = True
            '
            'buttonShowHelp
            '
            Me.buttonShowHelp.Location = New System.Drawing.Point(95, 11)
            Me.buttonShowHelp.Name = "buttonShowHelp"
            Me.buttonShowHelp.Size = New System.Drawing.Size(83, 29)
            Me.buttonShowHelp.TabIndex = 10
            Me.buttonShowHelp.Text = "Show Help"
            Me.buttonShowHelp.UseVisualStyleBackColor = True
            '
            'WizardSheet
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlPages)
            Me.Controls.Add(Me.pnlButtons)
            Me.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Name = "WizardSheet"
            Me.Size = New System.Drawing.Size(796, 559)
            Me.pnlButtons.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private pnlButtons As System.Windows.Forms.Panel
	  Private btnCancel As System.Windows.Forms.Button
	  Private btnNext As System.Windows.Forms.Button
	  Private btnBack As System.Windows.Forms.Button
	  Private btnFinish As System.Windows.Forms.Button
	  Private etchedLine1 As EtchedLine
	  Private pnlPages As System.Windows.Forms.Panel
   Private WithEvents buttonShowHelp As System.Windows.Forms.Button
   Private WithEvents buttonOption1 As System.Windows.Forms.Button
   Private WithEvents buttonAbout As System.Windows.Forms.Button
   End Class
End Namespace
