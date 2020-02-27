Namespace Leadtools.Demos.StorageServer
   Partial Friend Class SplashForm
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
         Me.progressBar = New System.Windows.Forms.ProgressBar()
         Me.pictureBoxBitmap = New System.Windows.Forms.PictureBox()
         CType(Me.pictureBoxBitmap, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' progressBar
         ' 
         Me.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.progressBar.Location = New System.Drawing.Point(0, 358)
         Me.progressBar.Name = "progressBar"
         Me.progressBar.Size = New System.Drawing.Size(532, 23)
         Me.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
         Me.progressBar.TabIndex = 0
         ' 
         ' pictureBoxBitmap
         ' 
         Me.pictureBoxBitmap.Dock = System.Windows.Forms.DockStyle.Fill
         Me.pictureBoxBitmap.Image = Global.My.Resources.splash_screen
         Me.pictureBoxBitmap.Location = New System.Drawing.Point(0, 0)
         Me.pictureBoxBitmap.Name = "pictureBoxBitmap"
         Me.pictureBoxBitmap.Size = New System.Drawing.Size(532, 358)
         Me.pictureBoxBitmap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
         Me.pictureBoxBitmap.TabIndex = 1
         Me.pictureBoxBitmap.TabStop = False
         ' 
         ' SplashForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(532, 381)
         Me.Controls.Add(Me.pictureBoxBitmap)
         Me.Controls.Add(Me.progressBar)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
         Me.Name = "SplashForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "SplashForm"
         CType(Me.pictureBoxBitmap, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private progressBar As System.Windows.Forms.ProgressBar
      Private pictureBoxBitmap As System.Windows.Forms.PictureBox
   End Class
End Namespace
