Namespace Leadtools.Demos.Workstation.UI
   Partial Class MainForm
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
		 Me.DescriptionPanel = New Leadtools.Medical.Workstation.UI.AutoHidePanel()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.DescriptionPanel.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' DescriptionPanel
		 ' 
		 Me.DescriptionPanel.AutoHide = False
		 Me.DescriptionPanel.BackColor = System.Drawing.Color.Black
		 Me.DescriptionPanel.Controls.Add(Me.label1)
		 Me.DescriptionPanel.Dock = System.Windows.Forms.DockStyle.Left
		 Me.DescriptionPanel.EnableResizing = False
		 Me.DescriptionPanel.Location = New System.Drawing.Point(0, 0)
		 Me.DescriptionPanel.Name = "DescriptionPanel"
		 Me.DescriptionPanel.Size = New System.Drawing.Size(201, 618)
		 Me.DescriptionPanel.State = Leadtools.Medical.Workstation.UI.AutoHidePanelState.Expanded
		 Me.DescriptionPanel.StickPinAttached = (CType(resources.GetObject("DescriptionPanel.StickPinAttached"), System.Drawing.Bitmap))
		 Me.DescriptionPanel.StickPinUnattached = (CType(resources.GetObject("DescriptionPanel.StickPinUnattached"), System.Drawing.Bitmap))
		 Me.DescriptionPanel.TabIndex = 0
		 Me.DescriptionPanel.TopLevel = False
		 ' 
		 ' label1
		 ' 
		 Me.label1.BackColor = System.Drawing.Color.DarkGray
		 Me.label1.Dock = System.Windows.Forms.DockStyle.Top
		 Me.label1.Location = New System.Drawing.Point(0, 0)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(201, 20)
		 Me.label1.TabIndex = 3
		 Me.label1.Text = "Description"
		 Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' MainForm
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(898, 618)
		 Me.Controls.Add(Me.DescriptionPanel)
		 Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		 Me.Name = "MainForm"
		 Me.Text = "Workstation Customization Demo"
		 Me.DescriptionPanel.ResumeLayout(False)
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Public DescriptionPanel As Leadtools.Medical.Workstation.UI.AutoHidePanel
	  Private label1 As System.Windows.Forms.Label

   End Class
End Namespace