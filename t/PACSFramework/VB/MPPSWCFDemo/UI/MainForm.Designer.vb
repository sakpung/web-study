Imports Microsoft.VisualBasic
Imports System
Namespace MPPSWCFDemo.UI
	Public Partial Class MainForm
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

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
			Me.wizardSheet = New Leadtools.Wizard.WizardSheet()
			Me.SuspendLayout()
			' 
			' wizardSheet
			' 
			Me.wizardSheet.Dock = System.Windows.Forms.DockStyle.Fill
			Me.wizardSheet.Font = New System.Drawing.Font("Arial", 8F)
			Me.wizardSheet.Location = New System.Drawing.Point(0, 0)
			Me.wizardSheet.Name = "wizardSheet"
			Me.wizardSheet.Option1Caption = "Option1"
			Me.wizardSheet.Size = New System.Drawing.Size(567, 498)
			Me.wizardSheet.TabIndex = 0
'			Me.wizardSheet.WizardFinished += New System.ComponentModel.CancelEventHandler(Me.wizardSheet_WizardFinished);
'			Me.wizardSheet.About += New System.EventHandler(Me.wizardSheet_About);
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(567, 498)
			Me.Controls.Add(Me.wizardSheet)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "MainForm"
			Me.Text = "MainForm"
'			Me.Load += New System.EventHandler(Me.MainForm_Load);
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents wizardSheet As Leadtools.Wizard.WizardSheet
	End Class
End Namespace