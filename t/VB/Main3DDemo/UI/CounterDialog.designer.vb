Namespace Main3DDemo
   Partial Class CounterDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CounterDialog))
         Me._progress = New System.Windows.Forms.ProgressBar()
         Me._lblCounter = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' _progress
         ' 
         resources.ApplyResources(Me._progress, "_progress")
         Me._progress.Name = "_progress"
         ' 
         ' _lblCounter
         ' 
         resources.ApplyResources(Me._lblCounter, "_lblCounter")
         Me._lblCounter.Name = "_lblCounter"
         ' 
         ' CounterDialog
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._lblCounter)
         Me.Controls.Add(Me._progress)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
         Me.Name = "CounterDialog"
         Me.ShowInTaskbar = False
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _progress As System.Windows.Forms.ProgressBar
      Private _lblCounter As System.Windows.Forms.Label
   End Class
End Namespace