Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class ControlPanelView
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
         Me.panel1 = New System.Windows.Forms.Panel()
         Me.NotesRichTextBox = New System.Windows.Forms.RichTextBox()
         Me.panel1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' AddinsTableLayoutPanel
         ' 
         Me.AddinsTableLayoutPanel.AutoScroll = True
         Me.AddinsTableLayoutPanel.AutoSize = True
         Me.AddinsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me.AddinsTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
         Me.AddinsTableLayoutPanel.Name = "AddinsTableLayoutPanel"
         Me.AddinsTableLayoutPanel.Padding = New System.Windows.Forms.Padding(10)
         Me.AddinsTableLayoutPanel.Size = New System.Drawing.Size(614, 101)
         Me.AddinsTableLayoutPanel.TabIndex = 0
         ' 
         ' panel1
         ' 
         Me.panel1.Controls.Add(Me.NotesRichTextBox)
         Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.panel1.Location = New System.Drawing.Point(0, 101)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(614, 261)
         Me.panel1.TabIndex = 1
         ' 
         ' NotesRichTextBox
         ' 
         Me.NotesRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill
         Me.NotesRichTextBox.Location = New System.Drawing.Point(0, 0)
         Me.NotesRichTextBox.Name = "NotesRichTextBox"
         Me.NotesRichTextBox.ReadOnly = True
         Me.NotesRichTextBox.Size = New System.Drawing.Size(614, 261)
         Me.NotesRichTextBox.TabIndex = 0
         Me.NotesRichTextBox.Text = ""
         ' 
         ' ControlPanelView
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.BackColor = System.Drawing.Color.White
         Me.Controls.Add(Me.AddinsTableLayoutPanel)
         Me.Controls.Add(Me.panel1)
         Me.Name = "ControlPanelView"
         Me.Size = New System.Drawing.Size(614, 362)
         Me.panel1.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private AddinsTableLayoutPanel As System.Windows.Forms.FlowLayoutPanel
      Private panel1 As System.Windows.Forms.Panel
      Private NotesRichTextBox As System.Windows.Forms.RichTextBox

   End Class
End Namespace
