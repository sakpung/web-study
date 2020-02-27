Partial Class ColorCodeLegend
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.flowPanel = New System.Windows.Forms.FlowLayoutPanel()
      Me.lblCorrect = New System.Windows.Forms.Label()
      Me.lblIncorrect = New System.Windows.Forms.Label()
      Me.lblReview = New System.Windows.Forms.Label()
      Me.lblModCorrect = New System.Windows.Forms.Label()
      Me.lblModIncorrect = New System.Windows.Forms.Label()
      Me.lblAnswers = New System.Windows.Forms.Label()
      Me.flowPanel.SuspendLayout()
      Me.SuspendLayout()
      Me.flowPanel.Controls.Add(Me.lblCorrect)
      Me.flowPanel.Controls.Add(Me.lblIncorrect)
      Me.flowPanel.Controls.Add(Me.lblReview)
      Me.flowPanel.Controls.Add(Me.lblModCorrect)
      Me.flowPanel.Controls.Add(Me.lblModIncorrect)
      Me.flowPanel.Controls.Add(Me.lblAnswers)
      Me.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
      Me.flowPanel.Location = New System.Drawing.Point(0, 0)
      Me.flowPanel.Margin = New System.Windows.Forms.Padding(0)
      Me.flowPanel.Name = "flowPanel"
      Me.flowPanel.Size = New System.Drawing.Size(100, 138)
      Me.flowPanel.TabIndex = 1
      Me.lblCorrect.Location = New System.Drawing.Point(3, 0)
      Me.lblCorrect.Name = "lblCorrect"
      Me.lblCorrect.Size = New System.Drawing.Size(100, 23)
      Me.lblCorrect.TabIndex = 0
      Me.lblCorrect.Text = "Correct"
      Me.lblCorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.lblIncorrect.Location = New System.Drawing.Point(3, 23)
      Me.lblIncorrect.Name = "lblIncorrect"
      Me.lblIncorrect.Size = New System.Drawing.Size(100, 23)
      Me.lblIncorrect.TabIndex = 1
      Me.lblIncorrect.Text = "Incorrect"
      Me.lblIncorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.lblReview.Location = New System.Drawing.Point(3, 46)
      Me.lblReview.Name = "lblReview"
      Me.lblReview.Size = New System.Drawing.Size(100, 23)
      Me.lblReview.TabIndex = 2
      Me.lblReview.Text = "Needs Review"
      Me.lblReview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.lblModCorrect.Location = New System.Drawing.Point(3, 69)
      Me.lblModCorrect.Name = "lblModCorrect"
      Me.lblModCorrect.Size = New System.Drawing.Size(100, 23)
      Me.lblModCorrect.TabIndex = 3
      Me.lblModCorrect.Text = "Reviewed Correct"
      Me.lblModCorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.lblModIncorrect.Location = New System.Drawing.Point(3, 92)
      Me.lblModIncorrect.Name = "lblModIncorrect"
      Me.lblModIncorrect.Size = New System.Drawing.Size(100, 23)
      Me.lblModIncorrect.TabIndex = 4
      Me.lblModIncorrect.Text = "Reviewed Incorrect"
      Me.lblModIncorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.lblAnswers.Location = New System.Drawing.Point(3, 115)
      Me.lblAnswers.Name = "lblAnswers"
      Me.lblAnswers.Size = New System.Drawing.Size(100, 23)
      Me.lblAnswers.TabIndex = 5
      Me.lblAnswers.Text = "Answer Key"
      Me.lblAnswers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(100, 138)
      Me.Controls.Add(Me.flowPanel)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ColorCodeLegend"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.Text = "Color Code"
      AddHandler Me.FormClosing, AddressOf Me.ColorCodeLegend_FormClosing
      Me.flowPanel.ResumeLayout(False)
      Me.ResumeLayout(False)
   End Sub

   Private flowPanel As System.Windows.Forms.FlowLayoutPanel
   Private lblCorrect As System.Windows.Forms.Label
   Private lblIncorrect As System.Windows.Forms.Label
   Private lblReview As System.Windows.Forms.Label
   Private lblModCorrect As System.Windows.Forms.Label
   Private lblModIncorrect As System.Windows.Forms.Label
   Private lblAnswers As System.Windows.Forms.Label
End Class
