Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
   Partial Public Class EventLogViewerDialog
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
		 Me.eventLogViewer1 = New Leadtools.Medical.Winforms.EventLogViewer()
		 Me.SuspendLayout()
		 ' 
		 ' eventLogViewer1
		 ' 
		 Me.eventLogViewer1.Dock = System.Windows.Forms.DockStyle.Fill
		 Me.eventLogViewer1.Location = New System.Drawing.Point(0, 0)
		 Me.eventLogViewer1.Name = "eventLogViewer1"
		 Me.eventLogViewer1.Size = New System.Drawing.Size(708, 625)
		 Me.eventLogViewer1.TabIndex = 0
		 ' 
		 ' EventLogViewerDialog
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(708, 625)
		 Me.Controls.Add(Me.eventLogViewer1)
		 Me.Name = "EventLogViewerDialog"
		 Me.Text = "Event Log Viewer "
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private eventLogViewer1 As Leadtools.Medical.Winforms.EventLogViewer
   End Class
End Namespace