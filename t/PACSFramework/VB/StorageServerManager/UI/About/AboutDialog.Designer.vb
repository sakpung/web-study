Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class AboutDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutDialog))
         Me._gbHelp = New System.Windows.Forms.GroupBox()
         Me._pb1 = New System.Windows.Forms.PictureBox()
         Me.button1 = New System.Windows.Forms.Button()
         Me._gbHelp.SuspendLayout()
         CType(Me._pb1, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _gbHelp
         ' 
         Me._gbHelp.Controls.Add(Me._pb1)
         Me._gbHelp.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbHelp.Location = New System.Drawing.Point(12, 12)
         Me._gbHelp.Name = "_gbHelp"
         Me._gbHelp.Size = New System.Drawing.Size(398, 134)
         Me._gbHelp.TabIndex = 2
         Me._gbHelp.TabStop = False
         ' 
         ' _pb1
         ' 
         Me._pb1.Image = (CType(resources.GetObject("_pb1.Image"), System.Drawing.Image))
         Me._pb1.Location = New System.Drawing.Point(31, 16)
         Me._pb1.Name = "_pb1"
         Me._pb1.Size = New System.Drawing.Size(337, 82)
         Me._pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
         Me._pb1.TabIndex = 7
         Me._pb1.TabStop = False
         ' 
         ' button1
         ' 
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.button1.Location = New System.Drawing.Point(174, 152)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(75, 23)
         Me.button1.TabIndex = 3
         Me.button1.Text = "OK"
         Me.button1.UseVisualStyleBackColor = True
         ' 
         ' AboutDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(422, 179)
         Me.Controls.Add(Me.button1)
         Me.Controls.Add(Me._gbHelp)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "AboutDialog"
         Me.Text = "About"
         Me._gbHelp.ResumeLayout(False)
         Me._gbHelp.PerformLayout()
         CType(Me._pb1, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _gbHelp As System.Windows.Forms.GroupBox
      Private _pb1 As System.Windows.Forms.PictureBox
      Private button1 As System.Windows.Forms.Button
   End Class
End Namespace
