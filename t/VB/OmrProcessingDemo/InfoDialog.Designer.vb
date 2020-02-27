Partial Class InfoDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfoDialog))
      Me.btnClose = New System.Windows.Forms.Button()
      Me.chkShowOnStartup = New System.Windows.Forms.CheckBox()
      Me.label1 = New System.Windows.Forms.Label()
      Me.label2 = New System.Windows.Forms.Label()
      Me.label3 = New System.Windows.Forms.Label()
      Me.label4 = New System.Windows.Forms.Label()
      Me.label5 = New System.Windows.Forms.Label()
      Me.label6 = New System.Windows.Forms.Label()
      Me.label7 = New System.Windows.Forms.Label()
      Me.label8 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnClose.Location = New System.Drawing.Point(223, 308)
      Me.btnClose.Name = "btnClose"
      Me.btnClose.Size = New System.Drawing.Size(75, 23)
      Me.btnClose.TabIndex = 0
      Me.btnClose.Text = "&Close"
      Me.btnClose.UseVisualStyleBackColor = True
      AddHandler Me.btnClose.Click, AddressOf Me.btnClose_Click
      Me.chkShowOnStartup.AutoSize = True
      Me.chkShowOnStartup.Location = New System.Drawing.Point(93, 312)
      Me.chkShowOnStartup.Name = "chkShowOnStartup"
      Me.chkShowOnStartup.Size = New System.Drawing.Size(124, 17)
      Me.chkShowOnStartup.TabIndex = 1
      Me.chkShowOnStartup.Text = "Show this on Startup"
      Me.chkShowOnStartup.UseVisualStyleBackColor = True
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(33, 281)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(334, 13)
      Me.label1.TabIndex = 2
      Me.label1.Text = "This dialog can be found via Template Editor -> Help -> Information"
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(85, 9)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(249, 13)
      Me.label2.TabIndex = 3
      Me.label2.Text = "This demo is used for processing OMR worksheets."
      Me.label3.AutoSize = True
      Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte((0))))
      Me.label3.Location = New System.Drawing.Point(12, 36)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(119, 16)
      Me.label3.TabIndex = 4
      Me.label3.Text = "Template Editor"
      Me.label4.Location = New System.Drawing.Point(39, 63)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(342, 56)
      Me.label4.TabIndex = 5
      Me.label4.Text = "The Template Editor allows construction of a template to use when recognizing OMR" & " worksheets highlighting regions of interest.  Different OMR regions can be sele" & "cted for processing."
      Me.label5.AutoSize = True
      Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte((0))))
      Me.label5.Location = New System.Drawing.Point(12, 119)
      Me.label5.Name = "label5"
      Me.label5.Size = New System.Drawing.Size(151, 16)
      Me.label5.TabIndex = 6
      Me.label5.Text = "Process Worksheets"
      Me.label6.Location = New System.Drawing.Point(39, 144)
      Me.label6.Name = "label6"
      Me.label6.Size = New System.Drawing.Size(342, 43)
      Me.label6.TabIndex = 7
      Me.label6.Text = "This allows the selection of worksheets to be processed using the loaded template" & ".  An Answer Key can also be included."
      Me.label7.AutoSize = True
      Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte((0))))
      Me.label7.Location = New System.Drawing.Point(12, 187)
      Me.label7.Name = "label7"
      Me.label7.Size = New System.Drawing.Size(115, 16)
      Me.label7.TabIndex = 8
      Me.label7.Text = "Review Results"
      Me.label8.Location = New System.Drawing.Point(39, 214)
      Me.label8.Name = "label8"
      Me.label8.Size = New System.Drawing.Size(339, 46)
      Me.label8.TabIndex = 9
      Me.label8.Text = "Review Results presents the processed OMR marks for review.  Values can be verifi" & "ed, modified, filtered, and exported.  Results can also be saved into workspace " & "files for future use."
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnClose
      Me.ClientSize = New System.Drawing.Size(400, 343)
      Me.Controls.Add(Me.label8)
      Me.Controls.Add(Me.label7)
      Me.Controls.Add(Me.label6)
      Me.Controls.Add(Me.label5)
      Me.Controls.Add(Me.label4)
      Me.Controls.Add(Me.label3)
      Me.Controls.Add(Me.label2)
      Me.Controls.Add(Me.label1)
      Me.Controls.Add(Me.chkShowOnStartup)
      Me.Controls.Add(Me.btnClose)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = (CType((resources.GetObject("$this.Icon")), System.Drawing.Icon))
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "InfoDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "LEADTOOLS for .Net VB OMR Processing Demo"
      AddHandler Me.FormClosing, AddressOf Me.InfoDialog_FormClosing
      AddHandler Me.Load, AddressOf Me.InfoDialog_Load
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private btnClose As System.Windows.Forms.Button
   Private chkShowOnStartup As System.Windows.Forms.CheckBox
   Private label1 As System.Windows.Forms.Label
   Private label2 As System.Windows.Forms.Label
   Private label3 As System.Windows.Forms.Label
   Private label4 As System.Windows.Forms.Label
   Private label5 As System.Windows.Forms.Label
   Private label6 As System.Windows.Forms.Label
   Private label7 As System.Windows.Forms.Label
   Private label8 As System.Windows.Forms.Label
End Class
