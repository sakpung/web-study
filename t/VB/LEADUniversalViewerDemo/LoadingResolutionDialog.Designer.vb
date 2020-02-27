Namespace VBLEADUniversalViewer
   Partial Class LoadingResolutionDialog
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
         Me.txtInfo = New System.Windows.Forms.TextBox()
         Me.cmbResolutions = New System.Windows.Forms.ComboBox()
         Me.chkChangeResolution = New System.Windows.Forms.CheckBox()
         Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
         Me.btnOK = New System.Windows.Forms.Button()
         Me.tableLayoutPanel1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' txtInfo
         ' 
         Me.txtInfo.Location = New System.Drawing.Point(5, 3)
         Me.txtInfo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
         Me.txtInfo.Multiline = True
         Me.txtInfo.Name = "txtInfo"
         Me.txtInfo.ReadOnly = True
         Me.txtInfo.Size = New System.Drawing.Size(442, 189)
         Me.txtInfo.TabIndex = 0
         ' 
         ' cmbResolutions
         ' 
         Me.cmbResolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.cmbResolutions.Enabled = False
         Me.cmbResolutions.Font = New System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.cmbResolutions.FormattingEnabled = True
         Me.cmbResolutions.Items.AddRange(New Object() {"72", "96", "100", "150", "200", "250", "300", "400", "600"})
         Me.cmbResolutions.Location = New System.Drawing.Point(256, 3)
         Me.cmbResolutions.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
         Me.cmbResolutions.Name = "cmbResolutions"
         Me.cmbResolutions.Size = New System.Drawing.Size(56, 26)
         Me.cmbResolutions.TabIndex = 1
         ' 
         ' chkChangeResolution
         ' 
         Me.chkChangeResolution.AutoSize = True
         Me.chkChangeResolution.Dock = System.Windows.Forms.DockStyle.Fill
         Me.chkChangeResolution.Location = New System.Drawing.Point(4, 3)
         Me.chkChangeResolution.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
         Me.chkChangeResolution.Name = "chkChangeResolution"
         Me.chkChangeResolution.Size = New System.Drawing.Size(244, 20)
         Me.chkChangeResolution.TabIndex = 2
         Me.chkChangeResolution.Text = "Change documents loading resolution"
         Me.chkChangeResolution.UseVisualStyleBackColor = True
         ' 
         ' tableLayoutPanel1
         ' 
         Me.tableLayoutPanel1.ColumnCount = 2
         Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0F))
         Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0F))
         Me.tableLayoutPanel1.Controls.Add(Me.chkChangeResolution, 0, 0)
         Me.tableLayoutPanel1.Controls.Add(Me.cmbResolutions, 1, 0)
         Me.tableLayoutPanel1.Location = New System.Drawing.Point(5, 197)
         Me.tableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
         Me.tableLayoutPanel1.RowCount = 1
         Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
         Me.tableLayoutPanel1.Size = New System.Drawing.Size(316, 26)
         Me.tableLayoutPanel1.TabIndex = 3
         ' 
         ' btnOK
         ' 
         Me.btnOK.Location = New System.Drawing.Point(386, 197)
         Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.btnOK.Name = "btnOK"
         Me.btnOK.Size = New System.Drawing.Size(61, 26)
         Me.btnOK.TabIndex = 4
         Me.btnOK.Text = "OK"
         Me.btnOK.UseVisualStyleBackColor = True
         ' 
         ' LoadingResolutionDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0F, 15.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(458, 228)
         Me.Controls.Add(Me.btnOK)
         Me.Controls.Add(Me.tableLayoutPanel1)
         Me.Controls.Add(Me.txtInfo)
         Me.Font = New System.Drawing.Font("Segoe UI", 9.0F)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
         Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
         Me.Name = "LoadingResolutionDialog"
         Me.Text = "Loading resolution"
         Me.tableLayoutPanel1.ResumeLayout(False)
         Me.tableLayoutPanel1.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private txtInfo As System.Windows.Forms.TextBox
      Private WithEvents cmbResolutions As System.Windows.Forms.ComboBox
      Private WithEvents chkChangeResolution As System.Windows.Forms.CheckBox
      Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
      Private WithEvents btnOK As System.Windows.Forms.Button
   End Class
End Namespace
