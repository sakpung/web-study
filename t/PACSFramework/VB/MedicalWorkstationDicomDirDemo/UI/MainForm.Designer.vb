Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
   Partial Public Class MainForm
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
		 Me.workStationContainerControl_Renamed = New Leadtools.Demos.Workstation.WorkStationContainer()
		 Me.SuspendLayout()
		 ' 
		 ' workStationContainerControl
		 ' 
		 Me.workStationContainerControl_Renamed.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
		 Me.workStationContainerControl_Renamed.Dock = System.Windows.Forms.DockStyle.Fill
		 Me.workStationContainerControl_Renamed.ForeColor = System.Drawing.Color.White
		 Me.workStationContainerControl_Renamed.Location = New System.Drawing.Point(0, 0)
		 Me.workStationContainerControl_Renamed.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		 Me.workStationContainerControl_Renamed.Name = "workStationContainerControl"
		 Me.workStationContainerControl_Renamed.Size = New System.Drawing.Size(773, 570)
		 Me.workStationContainerControl_Renamed.TabIndex = 0
		 ' 
		 ' MainForm
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(773, 570)
		 Me.Controls.Add(Me.workStationContainerControl_Renamed)
		 Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		 Me.Name = "MainForm"
		 Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private workStationContainerControl_Renamed As Leadtools.Demos.Workstation.WorkStationContainer
   End Class
End Namespace