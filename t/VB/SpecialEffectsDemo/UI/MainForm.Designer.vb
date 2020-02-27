Namespace SpecialEffectsDemo
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
         Me._btnEffect = New System.Windows.Forms.Button()
         Me._btnShape = New System.Windows.Forms.Button()
         Me._btnTransition = New System.Windows.Forms.Button()
         Me._btnShow = New System.Windows.Forms.Button()
         Me._btnText = New System.Windows.Forms.Button()
         Me._ckShowTransition = New System.Windows.Forms.CheckBox()
         Me._ckShowShape = New System.Windows.Forms.CheckBox()
         Me._ckShowText = New System.Windows.Forms.CheckBox()
         Me._pnlOptions = New System.Windows.Forms.Panel()
         Me._pnlViewer = New System.Windows.Forms.Panel()
         Me._pnlOptions.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _btnEffect
         ' 
         Me._btnEffect.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnEffect.Location = New System.Drawing.Point(9, 12)
         Me._btnEffect.Name = "_btnEffect"
         Me._btnEffect.Size = New System.Drawing.Size(90, 23)
         Me._btnEffect.TabIndex = 1
         Me._btnEffect.Text = "&Effect"
         Me._btnEffect.UseVisualStyleBackColor = True
         ' 
         ' _btnShape
         ' 
         Me._btnShape.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnShape.Location = New System.Drawing.Point(9, 92)
         Me._btnShape.Name = "_btnShape"
         Me._btnShape.Size = New System.Drawing.Size(90, 23)
         Me._btnShape.TabIndex = 2
         Me._btnShape.Text = "&Shape"
         Me._btnShape.UseVisualStyleBackColor = True
         ' 
         ' _btnTransition
         ' 
         Me._btnTransition.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnTransition.Location = New System.Drawing.Point(9, 52)
         Me._btnTransition.Name = "_btnTransition"
         Me._btnTransition.Size = New System.Drawing.Size(90, 23)
         Me._btnTransition.TabIndex = 3
         Me._btnTransition.Text = "&Transition"
         Me._btnTransition.UseVisualStyleBackColor = True
         ' 
         ' _btnShow
         ' 
         Me._btnShow.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnShow.Location = New System.Drawing.Point(9, 172)
         Me._btnShow.Name = "_btnShow"
         Me._btnShow.Size = New System.Drawing.Size(90, 23)
         Me._btnShow.TabIndex = 4
         Me._btnShow.Text = "Sho&w"
         Me._btnShow.UseVisualStyleBackColor = True
         ' 
         ' _btnText
         ' 
         Me._btnText.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnText.Location = New System.Drawing.Point(9, 132)
         Me._btnText.Name = "_btnText"
         Me._btnText.Size = New System.Drawing.Size(90, 23)
         Me._btnText.TabIndex = 5
         Me._btnText.Text = "Te&xt"
         Me._btnText.UseVisualStyleBackColor = True
         ' 
         ' _ckShowTransition
         ' 
         Me._ckShowTransition.AutoSize = True
         Me._ckShowTransition.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._ckShowTransition.Location = New System.Drawing.Point(9, 367)
         Me._ckShowTransition.Name = "_ckShowTransition"
         Me._ckShowTransition.Size = New System.Drawing.Size(108, 18)
         Me._ckShowTransition.TabIndex = 6
         Me._ckShowTransition.Text = "Show Transition"
         Me._ckShowTransition.UseVisualStyleBackColor = True
         ' 
         ' _ckShowShape
         ' 
         Me._ckShowShape.AutoSize = True
         Me._ckShowShape.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._ckShowShape.Location = New System.Drawing.Point(9, 384)
         Me._ckShowShape.Name = "_ckShowShape"
         Me._ckShowShape.Size = New System.Drawing.Size(93, 31)
         Me._ckShowShape.TabIndex = 7
         Me._ckShowShape.Text = "Show Shape" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
         Me._ckShowShape.UseVisualStyleBackColor = True
         ' 
         ' _ckShowText
         ' 
         Me._ckShowText.AutoSize = True
         Me._ckShowText.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._ckShowText.Location = New System.Drawing.Point(9, 413)
         Me._ckShowText.Name = "_ckShowText"
         Me._ckShowText.Size = New System.Drawing.Size(83, 18)
         Me._ckShowText.TabIndex = 8
         Me._ckShowText.Text = "Show Text"
         Me._ckShowText.UseVisualStyleBackColor = True
         ' 
         ' _pnlOptions
         ' 
         Me._pnlOptions.Controls.Add(Me._btnEffect)
         Me._pnlOptions.Controls.Add(Me._ckShowText)
         Me._pnlOptions.Controls.Add(Me._btnShape)
         Me._pnlOptions.Controls.Add(Me._ckShowShape)
         Me._pnlOptions.Controls.Add(Me._btnTransition)
         Me._pnlOptions.Controls.Add(Me._ckShowTransition)
         Me._pnlOptions.Controls.Add(Me._btnShow)
         Me._pnlOptions.Controls.Add(Me._btnText)
         Me._pnlOptions.Dock = System.Windows.Forms.DockStyle.Right
         Me._pnlOptions.Location = New System.Drawing.Point(770, 0)
         Me._pnlOptions.Name = "_pnlOptions"
         Me._pnlOptions.Size = New System.Drawing.Size(109, 440)
         Me._pnlOptions.TabIndex = 9
         ' 
         ' _pnlViewer
         ' 
         Me._pnlViewer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._pnlViewer.Location = New System.Drawing.Point(0, 0)
         Me._pnlViewer.Name = "_pnlViewer"
         Me._pnlViewer.Size = New System.Drawing.Size(770, 440)
         Me._pnlViewer.TabIndex = 10
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(879, 440)
         Me.Controls.Add(Me._pnlViewer)
         Me.Controls.Add(Me._pnlOptions)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MaximizeBox = False
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "MainForm"
         Me._pnlOptions.ResumeLayout(False)
         Me._pnlOptions.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _btnEffect As System.Windows.Forms.Button
      Private WithEvents _btnShape As System.Windows.Forms.Button
      Private WithEvents _btnTransition As System.Windows.Forms.Button
      Private WithEvents _btnShow As System.Windows.Forms.Button
      Private WithEvents _btnText As System.Windows.Forms.Button
      Private _ckShowTransition As System.Windows.Forms.CheckBox
      Private _ckShowShape As System.Windows.Forms.CheckBox
      Private _ckShowText As System.Windows.Forms.CheckBox
      Private _pnlOptions As System.Windows.Forms.Panel
      Private WithEvents _pnlViewer As System.Windows.Forms.Panel
   End Class
End Namespace

