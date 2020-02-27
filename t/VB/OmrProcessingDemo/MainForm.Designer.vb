Partial Class MainForm
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tbcMain = New System.Windows.Forms.TabControl()
      Me.tbTemplate = New System.Windows.Forms.TabPage()
      Me.tbProcess = New System.Windows.Forms.TabPage()
      Me.tbResults = New System.Windows.Forms.TabPage()
      Me.tbcMain.SuspendLayout()
      Me.SuspendLayout()
      Me.statusStrip1.Location = New System.Drawing.Point(0, 522)
      Me.statusStrip1.Name = "statusStrip1"
      Me.statusStrip1.Size = New System.Drawing.Size(1026, 22)
      Me.statusStrip1.TabIndex = 1
      Me.statusStrip1.Text = "statusStrip1"
      Me.tbcMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
      Me.tbcMain.Controls.Add(Me.tbTemplate)
      Me.tbcMain.Controls.Add(Me.tbProcess)
      Me.tbcMain.Controls.Add(Me.tbResults)
      Me.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tbcMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte((0))))
      Me.tbcMain.Location = New System.Drawing.Point(0, 0)
      Me.tbcMain.Name = "tbcMain"
      Me.tbcMain.SelectedIndex = 0
      Me.tbcMain.Size = New System.Drawing.Size(1026, 522)
      Me.tbcMain.TabIndex = 3
      Me.tbTemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte((0))))
      Me.tbTemplate.Location = New System.Drawing.Point(4, 32)
      Me.tbTemplate.Name = "tbTemplate"
      Me.tbTemplate.Padding = New System.Windows.Forms.Padding(3)
      Me.tbTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.tbTemplate.Size = New System.Drawing.Size(1018, 486)
      Me.tbTemplate.TabIndex = 0
      Me.tbTemplate.Text = "   Template Editor  "
      Me.tbTemplate.UseVisualStyleBackColor = True
      Me.tbProcess.BackColor = System.Drawing.SystemColors.ControlDark
      Me.tbProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.tbProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte((0))))
      Me.tbProcess.Location = New System.Drawing.Point(4, 32)
      Me.tbProcess.Name = "tbProcess"
      Me.tbProcess.Padding = New System.Windows.Forms.Padding(3)
      Me.tbProcess.Size = New System.Drawing.Size(1018, 486)
      Me.tbProcess.TabIndex = 1
      Me.tbProcess.Text = "   Process Worksheets   "
      Me.tbResults.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte((0))))
      Me.tbResults.Location = New System.Drawing.Point(4, 32)
      Me.tbResults.Name = "tbResults"
      Me.tbResults.Size = New System.Drawing.Size(1018, 486)
      Me.tbResults.TabIndex = 2
      Me.tbResults.Text = "   Review Results  "
      Me.tbResults.UseVisualStyleBackColor = True
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1026, 544)
      Me.Controls.Add(Me.tbcMain)
      Me.Controls.Add(Me.statusStrip1)
      Me.Icon = (CType((resources.GetObject("$this.Icon")), System.Drawing.Icon))
      Me.Name = "MainForm"
      Me.Text = "LEADTOOLS for .Net VB OMR Processing Demo"
      Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
      AddHandler Me.FormClosing, AddressOf Me.MainForm_FormClosing
      AddHandler Me.Load, AddressOf Me.Form1_Load
      AddHandler Me.Shown, AddressOf Me.MainForm_Shown
      Me.tbcMain.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private statusStrip1 As System.Windows.Forms.StatusStrip
   Private tbcMain As System.Windows.Forms.TabControl
   Private tbTemplate As System.Windows.Forms.TabPage
   Private tbProcess As System.Windows.Forms.TabPage
   Private tbResults As System.Windows.Forms.TabPage
End Class
