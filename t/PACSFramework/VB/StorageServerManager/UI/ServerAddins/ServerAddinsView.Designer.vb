Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class ServerAddinsView
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
         Me.AddinsTableLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
         Me.NoteLabel = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' AddinsTableLayoutPanel
         ' 
         Me.AddinsTableLayoutPanel.AutoScroll = True
         Me.AddinsTableLayoutPanel.AutoSize = True
         Me.AddinsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me.AddinsTableLayoutPanel.Location = New System.Drawing.Point(0, 13)
         Me.AddinsTableLayoutPanel.Name = "AddinsTableLayoutPanel"
         Me.AddinsTableLayoutPanel.Padding = New System.Windows.Forms.Padding(10)
         Me.AddinsTableLayoutPanel.Size = New System.Drawing.Size(614, 234)
         Me.AddinsTableLayoutPanel.TabIndex = 0
         ' 
         ' NoteLabel
         ' 
         Me.NoteLabel.AutoSize = True
         Me.NoteLabel.Dock = System.Windows.Forms.DockStyle.Top
         Me.NoteLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.NoteLabel.Location = New System.Drawing.Point(0, 0)
         Me.NoteLabel.Name = "NoteLabel"
         Me.NoteLabel.Size = New System.Drawing.Size(41, 13)
         Me.NoteLabel.TabIndex = 0
         Me.NoteLabel.Text = "label1"
         ' 
         ' ServerAddinsView
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.BackColor = System.Drawing.Color.White
         Me.Controls.Add(Me.AddinsTableLayoutPanel)
         Me.Controls.Add(Me.NoteLabel)
         Me.Name = "ServerAddinsView"
         Me.Size = New System.Drawing.Size(614, 247)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private AddinsTableLayoutPanel As System.Windows.Forms.FlowLayoutPanel
      Private NoteLabel As System.Windows.Forms.Label

   End Class
End Namespace
