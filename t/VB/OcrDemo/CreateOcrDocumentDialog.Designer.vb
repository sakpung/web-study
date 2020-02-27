Namespace OcrDemo
   Partial Class CreateOcrDocumentDialog
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
         If disposing AndAlso (components IsNot Nothing) Then
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
         Me.label1 = New System.Windows.Forms.Label()
         Me._lblOcrDocumentFile = New System.Windows.Forms.Label()
         Me._cmbDocumentMode = New System.Windows.Forms.ComboBox()
         Me._tbOcrDocumentFile = New System.Windows.Forms.TextBox()
         Me._btnBrowse = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._lblHints = New System.Windows.Forms.Label()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         '
         ' label1
         '
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(12, 19)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(129, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Document creation mode:"
         '
         ' _lblOcrDocumentFile
         '
         Me._lblOcrDocumentFile.AutoSize = True
         Me._lblOcrDocumentFile.Location = New System.Drawing.Point(12, 47)
         Me._lblOcrDocumentFile.Name = "_lblOcrDocumentFile"
         Me._lblOcrDocumentFile.Size = New System.Drawing.Size(104, 13)
         Me._lblOcrDocumentFile.TabIndex = 1
         Me._lblOcrDocumentFile.Text = "OCR Document File:"
         '
         ' _cmbDocumentMode
         '
         Me._cmbDocumentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbDocumentMode.FormattingEnabled = True
         Me._cmbDocumentMode.Items.AddRange(New Object() {"File", "Memory"})
         Me._cmbDocumentMode.Location = New System.Drawing.Point(148, 16)
         Me._cmbDocumentMode.Name = "_cmbDocumentMode"
         Me._cmbDocumentMode.Size = New System.Drawing.Size(177, 21)
         Me._cmbDocumentMode.TabIndex = 2
         '
         ' _tbOcrDocumentFile
         '
         Me._tbOcrDocumentFile.Location = New System.Drawing.Point(148, 44)
         Me._tbOcrDocumentFile.Name = "_tbOcrDocumentFile"
         Me._tbOcrDocumentFile.Size = New System.Drawing.Size(249, 20)
         Me._tbOcrDocumentFile.TabIndex = 3
         '
         ' _btnBrowse
         '
         Me._btnBrowse.Location = New System.Drawing.Point(403, 42)
         Me._btnBrowse.Name = "_btnBrowse"
         Me._btnBrowse.Size = New System.Drawing.Size(38, 23)
         Me._btnBrowse.TabIndex = 4
         Me._btnBrowse.Text = "&..."
         Me._btnBrowse.UseVisualStyleBackColor = True
         '
         ' groupBox1
         '
         Me.groupBox1.Controls.Add(Me._lblHints)
         Me.groupBox1.Location = New System.Drawing.Point(15, 81)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(426, 133)
         Me.groupBox1.TabIndex = 5
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Hints"
         '
         ' _lblHints
         '
         Me._lblHints.Location = New System.Drawing.Point(16, 25)
         Me._lblHints.Name = "_lblHints"
         Me._lblHints.Size = New System.Drawing.Size(395, 95)
         Me._lblHints.TabIndex = 0
         Me._lblHints.Text = "Document creation mode hints"
         '
         ' _btnCancel
         '
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(366, 220)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 6
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         '
         ' _btnOK
         '
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOK.Location = New System.Drawing.Point(285, 220)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(75, 23)
         Me._btnOK.TabIndex = 7
         Me._btnOK.Text = "OK"
         Me._btnOK.UseVisualStyleBackColor = True
         '
         ' CreateOcrDocumentDialog
         '
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(454, 253)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me._btnBrowse)
         Me.Controls.Add(Me._tbOcrDocumentFile)
         Me.Controls.Add(Me._cmbDocumentMode)
         Me.Controls.Add(Me._lblOcrDocumentFile)
         Me.Controls.Add(Me.label1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
         Me.Name = "CreateOcrDocumentDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Create OCR Document"
         Me.groupBox1.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private label1 As System.Windows.Forms.Label
      Private _lblOcrDocumentFile As System.Windows.Forms.Label
      Private WithEvents _cmbDocumentMode As System.Windows.Forms.ComboBox
      Private _tbOcrDocumentFile As System.Windows.Forms.TextBox
      Private WithEvents _btnBrowse As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private _lblHints As System.Windows.Forms.Label
      Private _btnCancel As System.Windows.Forms.Button
      Private _btnOK As System.Windows.Forms.Button
   End Class
End Namespace
