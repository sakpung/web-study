Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Wizard.Pages
   Partial Public Class WelcomeTemplatePage
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
		 Me.contentPanel = New System.Windows.Forms.Panel()
		 Me.DescriptionLabel = New System.Windows.Forms.Label()
		 Me.HeaderTitleLabel = New System.Windows.Forms.Label()
		 Me.sidePanel = New System.Windows.Forms.Panel()
		 Me.RightBannerPictureBox = New System.Windows.Forms.PictureBox()
		 Me.contentPanel.SuspendLayout()
		 Me.sidePanel.SuspendLayout()
		 CType(Me.RightBannerPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' contentPanel
		 ' 
		 Me.contentPanel.Controls.Add(Me.DescriptionLabel)
		 Me.contentPanel.Controls.Add(Me.HeaderTitleLabel)
		 Me.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill
		 Me.contentPanel.Location = New System.Drawing.Point(190, 0)
		 Me.contentPanel.Name = "contentPanel"
		 Me.contentPanel.Size = New System.Drawing.Size(581, 502)
		 Me.contentPanel.TabIndex = 2
		 ' 
		 ' DescriptionLabel
		 ' 
		 Me.DescriptionLabel.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.DescriptionLabel.AutoEllipsis = True
		 Me.DescriptionLabel.Location = New System.Drawing.Point(39, 157)
		 Me.DescriptionLabel.Name = "DescriptionLabel"
		 Me.DescriptionLabel.Size = New System.Drawing.Size(508, 121)
		 Me.DescriptionLabel.TabIndex = 1
		 Me.DescriptionLabel.Text = "Descriptions..."
		 ' 
		 ' HeaderTitleLabel
		 ' 
		 Me.HeaderTitleLabel.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.HeaderTitleLabel.AutoEllipsis = True
		 Me.HeaderTitleLabel.Font = New System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold)
		 Me.HeaderTitleLabel.Location = New System.Drawing.Point(38, 43)
		 Me.HeaderTitleLabel.Name = "HeaderTitleLabel"
		 Me.HeaderTitleLabel.Size = New System.Drawing.Size(509, 92)
		 Me.HeaderTitleLabel.TabIndex = 0
		 Me.HeaderTitleLabel.Text = "Enter Title Here..."
		 ' 
		 ' sidePanel
		 ' 
		 Me.sidePanel.Controls.Add(Me.RightBannerPictureBox)
		 Me.sidePanel.Dock = System.Windows.Forms.DockStyle.Left
		 Me.sidePanel.Location = New System.Drawing.Point(0, 0)
		 Me.sidePanel.Name = "sidePanel"
		 Me.sidePanel.Size = New System.Drawing.Size(190, 502)
		 Me.sidePanel.TabIndex = 1
		 ' 
		 ' RightBannerPictureBox
		 ' 
		 Me.RightBannerPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
		 Me.RightBannerPictureBox.Location = New System.Drawing.Point(0, 0)
		 Me.RightBannerPictureBox.Name = "RightBannerPictureBox"
		 Me.RightBannerPictureBox.Size = New System.Drawing.Size(190, 502)
		 Me.RightBannerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		 Me.RightBannerPictureBox.TabIndex = 1
		 Me.RightBannerPictureBox.TabStop = False
		 ' 
		 ' WelcomeTemplatePage
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(7F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.Controls.Add(Me.contentPanel)
		 Me.Controls.Add(Me.sidePanel)
		 Me.Name = "WelcomeTemplatePage"
		 Me.Size = New System.Drawing.Size(771, 502)
		 Me.contentPanel.ResumeLayout(False)
		 Me.sidePanel.ResumeLayout(False)
		 CType(Me.RightBannerPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private sidePanel As System.Windows.Forms.Panel
	  Protected RightBannerPictureBox As System.Windows.Forms.PictureBox
	  Public DescriptionLabel As System.Windows.Forms.Label
	  Public HeaderTitleLabel As System.Windows.Forms.Label
	  Protected contentPanel As System.Windows.Forms.Panel
   End Class
End Namespace
