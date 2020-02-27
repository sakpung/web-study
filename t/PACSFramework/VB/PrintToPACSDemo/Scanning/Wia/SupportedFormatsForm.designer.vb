Imports Microsoft.VisualBasic
Imports System
Namespace PrintToPACSDemo
   Public Partial Class SupportedFormatsForm
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
		 Me._btnCLose = New System.Windows.Forms.Button()
		 Me._lvFormats = New System.Windows.Forms.ListView()
		 Me.SuspendLayout()
		 ' 
		 ' _btnCLose
		 ' 
		 Me._btnCLose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCLose.Location = New System.Drawing.Point(362, 196)
		 Me._btnCLose.Name = "_btnCLose"
		 Me._btnCLose.Size = New System.Drawing.Size(75, 23)
		 Me._btnCLose.TabIndex = 1
		 Me._btnCLose.Text = "&Close"
		 Me._btnCLose.UseVisualStyleBackColor = True
		 ' 
		 ' _lvFormats
		 ' 
		 Me._lvFormats.FullRowSelect = True
		 Me._lvFormats.GridLines = True
		 Me._lvFormats.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
		 Me._lvFormats.Location = New System.Drawing.Point(12, 12)
		 Me._lvFormats.Name = "_lvFormats"
		 Me._lvFormats.Size = New System.Drawing.Size(425, 178)
		 Me._lvFormats.TabIndex = 0
		 Me._lvFormats.UseCompatibleStateImageBehavior = False
		 Me._lvFormats.View = System.Windows.Forms.View.Details
		 ' 
		 ' SupportedFormatsForm
		 ' 
		 Me.AcceptButton = Me._btnCLose
		 Me.CancelButton = Me._btnCLose
		 Me.ClientSize = New System.Drawing.Size(449, 230)
		 Me.Controls.Add(Me._btnCLose)
		 Me.Controls.Add(Me._lvFormats)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		 Me.Name = "SupportedFormatsForm"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "WIA Supported Formats"
'		 Me.Load += New System.EventHandler(Me.SupportedFormatsForm_Load);
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _btnCLose As System.Windows.Forms.Button
	  Private _lvFormats As System.Windows.Forms.ListView
   End Class
End Namespace