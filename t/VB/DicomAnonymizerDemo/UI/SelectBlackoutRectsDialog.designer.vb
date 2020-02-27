Namespace DicomAnonymizer
   Partial Friend Class SelectBlackoutRectsDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectBlackoutRectsDialog))
         Me.panel2 = New System.Windows.Forms.Panel()
         Me.buttonCancel = New System.Windows.Forms.Button()
         Me.progressBarLoad = New System.Windows.Forms.ProgressBar()
         Me.labelLoadInfo = New System.Windows.Forms.Label()
         Me.button1 = New System.Windows.Forms.Button()
         Me.panelView = New System.Windows.Forms.Panel()
         Me.panel2.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' panel2
         ' 
         Me.panel2.Controls.Add(Me.buttonCancel)
         Me.panel2.Controls.Add(Me.progressBarLoad)
         Me.panel2.Controls.Add(Me.labelLoadInfo)
         Me.panel2.Controls.Add(Me.button1)
         Me.panel2.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.panel2.Location = New System.Drawing.Point(0, 479)
         Me.panel2.Name = "panel2"
         Me.panel2.Size = New System.Drawing.Size(563, 49)
         Me.panel2.TabIndex = 1
         ' 
         ' buttonCancel
         ' 
         Me.buttonCancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.buttonCancel.Location = New System.Drawing.Point(476, 14)
         Me.buttonCancel.Name = "buttonCancel"
         Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
         Me.buttonCancel.TabIndex = 3
         Me.buttonCancel.Text = "Cancel"
         Me.buttonCancel.UseVisualStyleBackColor = True
         ' 
         ' progressBarLoad
         ' 
         Me.progressBarLoad.Location = New System.Drawing.Point(95, 13)
         Me.progressBarLoad.Name = "progressBarLoad"
         Me.progressBarLoad.Size = New System.Drawing.Size(294, 23)
         Me.progressBarLoad.TabIndex = 2
         Me.progressBarLoad.Visible = False
         ' 
         ' labelLoadInfo
         ' 
         Me.labelLoadInfo.AutoSize = True
         Me.labelLoadInfo.Location = New System.Drawing.Point(4, 23)
         Me.labelLoadInfo.Name = "labelLoadInfo"
         Me.labelLoadInfo.Size = New System.Drawing.Size(85, 13)
         Me.labelLoadInfo.TabIndex = 1
         Me.labelLoadInfo.Text = "Loading Images:"
         Me.labelLoadInfo.Visible = False
         ' 
         ' button1
         ' 
         Me.button1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.button1.Location = New System.Drawing.Point(395, 14)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(75, 23)
         Me.button1.TabIndex = 0
         Me.button1.Text = "OK"
         Me.button1.UseVisualStyleBackColor = True
         ' 
         ' panelView
         ' 
         Me.panelView.Dock = System.Windows.Forms.DockStyle.Fill
         Me.panelView.Location = New System.Drawing.Point(0, 0)
         Me.panelView.Name = "panelView"
         Me.panelView.Size = New System.Drawing.Size(563, 479)
         Me.panelView.TabIndex = 2
         ' 
         ' SelectBlackoutRectsDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(563, 528)
         Me.Controls.Add(Me.panelView)
         Me.Controls.Add(Me.panel2)
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "SelectBlackoutRectsDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Draw Blackout Rectangles"
         Me.panel2.ResumeLayout(False)
         Me.panel2.PerformLayout()
         Me.ResumeLayout(False)
      End Sub

#End Region

      Private panel2 As System.Windows.Forms.Panel
      Private button1 As System.Windows.Forms.Button
      Private progressBarLoad As System.Windows.Forms.ProgressBar
      Private labelLoadInfo As System.Windows.Forms.Label
      Private buttonCancel As System.Windows.Forms.Button
      Private panelView As System.Windows.Forms.Panel

   End Class
End Namespace