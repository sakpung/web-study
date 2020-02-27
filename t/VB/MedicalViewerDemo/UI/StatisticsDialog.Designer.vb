Namespace MedicalViewerDemo
   Partial Class StatisticsDialog
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
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._areaLbl = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me._heightLbl = New System.Windows.Forms.Label()
         Me._widthLbl = New System.Windows.Forms.Label()
         Me._yLbl = New System.Windows.Forms.Label()
         Me._xLbl = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me._hasRegionLbl = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me._btnOK = New System.Windows.Forms.Button()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._areaLbl)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me._heightLbl)
         Me.groupBox1.Controls.Add(Me._widthLbl)
         Me.groupBox1.Controls.Add(Me._yLbl)
         Me.groupBox1.Controls.Add(Me._xLbl)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me._hasRegionLbl)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(7, 5)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(317, 131)
         Me.groupBox1.TabIndex = 15
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Current Region Statistics"
         ' 
         ' _areaLbl
         ' 
         Me._areaLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._areaLbl.Font = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
         Me._areaLbl.Location = New System.Drawing.Point(100, 91)
         Me._areaLbl.Name = "_areaLbl"
         Me._areaLbl.Size = New System.Drawing.Size(97, 23)
         Me._areaLbl.TabIndex = 8
         Me._areaLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(10, 96)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(70, 13)
         Me.label3.TabIndex = 7
         Me.label3.Text = "Region Area:"
         ' 
         ' _heightLbl
         ' 
         Me._heightLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._heightLbl.Font = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
         Me._heightLbl.Location = New System.Drawing.Point(262, 53)
         Me._heightLbl.Name = "_heightLbl"
         Me._heightLbl.Size = New System.Drawing.Size(47, 23)
         Me._heightLbl.TabIndex = 6
         Me._heightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         ' 
         ' _widthLbl
         ' 
         Me._widthLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._widthLbl.Font = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
         Me._widthLbl.Location = New System.Drawing.Point(208, 53)
         Me._widthLbl.Name = "_widthLbl"
         Me._widthLbl.Size = New System.Drawing.Size(47, 23)
         Me._widthLbl.TabIndex = 5
         Me._widthLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         ' 
         ' _yLbl
         ' 
         Me._yLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._yLbl.Font = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
         Me._yLbl.Location = New System.Drawing.Point(154, 53)
         Me._yLbl.Name = "_yLbl"
         Me._yLbl.Size = New System.Drawing.Size(47, 23)
         Me._yLbl.TabIndex = 4
         Me._yLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         ' 
         ' _xLbl
         ' 
         Me._xLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._xLbl.Font = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
         Me._xLbl.Location = New System.Drawing.Point(100, 53)
         Me._xLbl.Name = "_xLbl"
         Me._xLbl.Size = New System.Drawing.Size(47, 23)
         Me._xLbl.TabIndex = 3
         Me._xLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(10, 58)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(82, 13)
         Me.label2.TabIndex = 2
         Me.label2.Text = "Region Bounds:"
         ' 
         ' _hasRegionLbl
         ' 
         Me._hasRegionLbl.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(255)))), (CInt((CByte(128)))), (CInt((CByte(128)))))
         Me._hasRegionLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._hasRegionLbl.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me._hasRegionLbl.Location = New System.Drawing.Point(100, 15)
         Me._hasRegionLbl.Name = "_hasRegionLbl"
         Me._hasRegionLbl.Size = New System.Drawing.Size(40, 23)
         Me._hasRegionLbl.TabIndex = 1
         Me._hasRegionLbl.Text = "False"
         Me._hasRegionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(10, 20)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(65, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Has Region:"
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnOK.Location = New System.Drawing.Point(132, 142)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(72, 29)
         Me._btnOK.TabIndex = 17
         Me._btnOK.Text = "&OK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' StatisticsDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnOK
         Me.ClientSize = New System.Drawing.Size(336, 176)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "StatisticsDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Region Statistics"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _areaLbl As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private _heightLbl As System.Windows.Forms.Label
      Private _widthLbl As System.Windows.Forms.Label
      Private _yLbl As System.Windows.Forms.Label
      Private _xLbl As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private _hasRegionLbl As System.Windows.Forms.Label
      Private label1 As System.Windows.Forms.Label
   End Class
End Namespace
