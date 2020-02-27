Imports Microsoft.VisualBasic
Imports System
Namespace MPPSWCFDemo.UI.Pages
	Partial Public Class IntroductionPage
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IntroductionPage))
         CType(Me.RightBannerPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.contentPanel.SuspendLayout()
         Me.SuspendLayout()
         '
         'DescriptionLabel
         '
         Me.DescriptionLabel.Text = resources.GetString("DescriptionLabel.Text")
         '
         'HeaderTitleLabel
         '
         Me.HeaderTitleLabel.Text = "Modality Performed Procedure Step WCF Demo Wizard"
         '
         'IntroductionPage
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Name = "IntroductionPage"
         CType(Me.RightBannerPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
         Me.contentPanel.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub

		#End Region
	End Class
End Namespace
