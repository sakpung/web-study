
Partial Class ViewerForm

   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

#Region "Windows Form Designer generated code"

   Private Sub InitializeComponent()
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(ViewerForm))
      Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
      Me._lblBPP = New System.Windows.Forms.ToolStripStatusLabel()
      Me._lblSigned = New System.Windows.Forms.ToolStripStatusLabel()
      Me._lblImageSize = New System.Windows.Forms.ToolStripStatusLabel()
      Me._lblWidth = New System.Windows.Forms.ToolStripStatusLabel()
      Me._lblLevel = New System.Windows.Forms.ToolStripStatusLabel()
      Me._lblX = New System.Windows.Forms.ToolStripStatusLabel()
      Me._lblY = New System.Windows.Forms.ToolStripStatusLabel()
      Me._lblRGB = New System.Windows.Forms.ToolStripStatusLabel()
      Me._lblPaletteValue = New System.Windows.Forms.ToolStripStatusLabel()
      Me.statusStrip1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' statusStrip1
      ' 
      Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._lblBPP, Me._lblSigned, Me._lblImageSize, Me._lblWidth, Me._lblLevel, Me._lblX, _
       Me._lblY, Me._lblRGB, Me._lblPaletteValue})
      Me.statusStrip1.Location = New System.Drawing.Point(0, 369)
      Me.statusStrip1.Name = "statusStrip1"
      Me.statusStrip1.Size = New System.Drawing.Size(451, 22)
      Me.statusStrip1.TabIndex = 0
      Me.statusStrip1.Text = "statusStrip1"
      ' 
      ' _lblBPP
      ' 
      Me._lblBPP.Name = "_lblBPP"
      Me._lblBPP.Size = New System.Drawing.Size(28, 17)
      Me._lblBPP.Text = "BPP"
      ' 
      ' _lblSigned
      ' 
      Me._lblSigned.Name = "_lblSigned"
      Me._lblSigned.Size = New System.Drawing.Size(43, 17)
      Me._lblSigned.Text = "Signed"
      ' 
      ' _lblImageSize
      ' 
      Me._lblImageSize.Name = "_lblImageSize"
      Me._lblImageSize.Size = New System.Drawing.Size(26, 17)
      Me._lblImageSize.Text = "size"
      ' 
      ' _lblWidth
      ' 
      Me._lblWidth.Name = "_lblWidth"
      Me._lblWidth.Size = New System.Drawing.Size(37, 17)
      Me._lblWidth.Text = "width"
      ' 
      ' _lblLevel
      ' 
      Me._lblLevel.Name = "_lblLevel"
      Me._lblLevel.Size = New System.Drawing.Size(31, 17)
      Me._lblLevel.Text = "level"
      ' 
      ' _lblX
      ' 
      Me._lblX.Name = "_lblX"
      Me._lblX.Size = New System.Drawing.Size(14, 17)
      Me._lblX.Text = "X"
      ' 
      ' _lblY
      ' 
      Me._lblY.Name = "_lblY"
      Me._lblY.Size = New System.Drawing.Size(14, 17)
      Me._lblY.Text = "Y"
      ' 
      ' _lblRGB
      ' 
      Me._lblRGB.Name = "_lblRGB"
      Me._lblRGB.Size = New System.Drawing.Size(29, 17)
      Me._lblRGB.Text = "RGB"
      ' 
      ' _lblPaletteValue
      ' 
      Me._lblPaletteValue.Name = "_lblPaletteValue"
      Me._lblPaletteValue.Size = New System.Drawing.Size(43, 17)
      Me._lblPaletteValue.Text = "Palette"
      ' 
      ' ViewerForm
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(451, 391)
      Me.Controls.Add(Me.statusStrip1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ViewerForm"
      Me.Text = "ViewerForm"
      Me.statusStrip1.ResumeLayout(False)
      Me.statusStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private statusStrip1 As System.Windows.Forms.StatusStrip
   Private _lblWidth As System.Windows.Forms.ToolStripStatusLabel
   Private _lblLevel As System.Windows.Forms.ToolStripStatusLabel
   Private _lblX As System.Windows.Forms.ToolStripStatusLabel
   Private _lblY As System.Windows.Forms.ToolStripStatusLabel
   Private _lblRGB As System.Windows.Forms.ToolStripStatusLabel
   Private _lblPaletteValue As System.Windows.Forms.ToolStripStatusLabel
   Private _lblBPP As System.Windows.Forms.ToolStripStatusLabel
   Private _lblImageSize As System.Windows.Forms.ToolStripStatusLabel
   Private _lblSigned As System.Windows.Forms.ToolStripStatusLabel
End Class