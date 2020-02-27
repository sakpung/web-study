Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Wizard.Pages
   Partial Public Class InternalTemplatePage
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

	  #Region "Windows Form Designer generated code"

	  ''' <summary>
	  ''' Required method for Designer support - do not modify
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
		 Me.TopBannerPanel = New System.Windows.Forms.Panel()
		 Me.IconPictureBox = New System.Windows.Forms.PictureBox()
		 Me.TitleDescriptionLabel = New System.Windows.Forms.Label()
		 Me.TitleLabel = New System.Windows.Forms.Label()
		 Me.TopBannerPanel.SuspendLayout()
		 CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' TopBannerPanel
		 ' 
		 Me.TopBannerPanel.BackColor = System.Drawing.Color.White
		 Me.TopBannerPanel.Controls.Add(Me.IconPictureBox)
		 Me.TopBannerPanel.Controls.Add(Me.TitleDescriptionLabel)
		 Me.TopBannerPanel.Controls.Add(Me.TitleLabel)
		 Me.TopBannerPanel.Dock = System.Windows.Forms.DockStyle.Top
		 Me.TopBannerPanel.Location = New System.Drawing.Point(0, 0)
		 Me.TopBannerPanel.Name = "TopBannerPanel"
		 Me.TopBannerPanel.Size = New System.Drawing.Size(666, 107)
		 Me.TopBannerPanel.TabIndex = 0
		 ' 
		 ' IconPictureBox
		 ' 
		 Me.IconPictureBox.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.IconPictureBox.Location = New System.Drawing.Point(552, 16)
		 Me.IconPictureBox.Name = "IconPictureBox"
		 Me.IconPictureBox.Size = New System.Drawing.Size(105, 60)
		 Me.IconPictureBox.TabIndex = 2
		 Me.IconPictureBox.TabStop = False
		 ' 
		 ' TitleDescriptionLabel
		 ' 
		 Me.TitleDescriptionLabel.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.TitleDescriptionLabel.AutoEllipsis = True
		 Me.TitleDescriptionLabel.Location = New System.Drawing.Point(44, 61)
		 Me.TitleDescriptionLabel.Name = "TitleDescriptionLabel"
		 Me.TitleDescriptionLabel.Size = New System.Drawing.Size(463, 39)
		 Me.TitleDescriptionLabel.TabIndex = 1
		 Me.TitleDescriptionLabel.Text = "Enter Description Here..."
		 ' 
		 ' TitleLabel
		 ' 
		 Me.TitleLabel.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.TitleLabel.AutoEllipsis = True
		 Me.TitleLabel.Font = New System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold)
		 Me.TitleLabel.Location = New System.Drawing.Point(22, 16)
		 Me.TitleLabel.Name = "TitleLabel"
		 Me.TitleLabel.Size = New System.Drawing.Size(485, 38)
		 Me.TitleLabel.TabIndex = 0
		 Me.TitleLabel.Text = "Enter Title Here"
		 ' 
		 ' InternalTemplatePage
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(7F, 16F)
		 Me.Controls.Add(Me.TopBannerPanel)
		 Me.Name = "InternalTemplatePage"
		 Me.Size = New System.Drawing.Size(666, 494)
		 Me.TopBannerPanel.ResumeLayout(False)
		 CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Protected TopBannerPanel As System.Windows.Forms.Panel
	  Protected TitleDescriptionLabel As System.Windows.Forms.Label
	  Protected TitleLabel As System.Windows.Forms.Label
	  Protected IconPictureBox As System.Windows.Forms.PictureBox
   End Class
End Namespace
