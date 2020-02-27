Namespace OcrMultiThreadingDemo
   Partial Class ConversionControl
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

#Region "Component Designer generated code"

      ''' <summary> 
      ''' Required method for Designer support - do not modify 
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me._pbProgress = New System.Windows.Forms.ProgressBar()
         Me._lblSuccess = New System.Windows.Forms.Label()
         Me._lbSuccess = New System.Windows.Forms.ListBox()
         Me._lbError = New System.Windows.Forms.ListBox()
         Me._lblError = New System.Windows.Forms.Label()
         Me._lblInformation = New System.Windows.Forms.Label()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnConvertMoreFiles = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' _pbProgress
         ' 
         Me._pbProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._pbProgress.Location = New System.Drawing.Point(16, 49)
         Me._pbProgress.Name = "_pbProgress"
         Me._pbProgress.Size = New System.Drawing.Size(718, 23)
         Me._pbProgress.TabIndex = 1
         ' 
         ' _lblSuccess
         ' 
         Me._lblSuccess.AutoSize = True
         Me._lblSuccess.Location = New System.Drawing.Point(16, 97)
         Me._lblSuccess.Name = "_lblSuccess"
         Me._lblSuccess.Size = New System.Drawing.Size(175, 13)
         Me._lblSuccess.TabIndex = 3
         Me._lblSuccess.Text = "Documents converted successfully:"
         ' 
         ' _lbSuccess
         ' 
         Me._lbSuccess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._lbSuccess.FormattingEnabled = True
         Me._lbSuccess.HorizontalScrollbar = True
         Me._lbSuccess.Location = New System.Drawing.Point(19, 114)
         Me._lbSuccess.Name = "_lbSuccess"
         Me._lbSuccess.Size = New System.Drawing.Size(798, 95)
         Me._lbSuccess.TabIndex = 4
         ' 
         ' _lbError
         ' 
         Me._lbError.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._lbError.FormattingEnabled = True
         Me._lbError.HorizontalScrollbar = True
         Me._lbError.Location = New System.Drawing.Point(19, 254)
         Me._lbError.Name = "_lbError"
         Me._lbError.Size = New System.Drawing.Size(798, 95)
         Me._lbError.TabIndex = 6
         ' 
         ' _lblError
         ' 
         Me._lblError.AutoSize = True
         Me._lblError.Location = New System.Drawing.Point(16, 237)
         Me._lblError.Name = "_lblError"
         Me._lblError.Size = New System.Drawing.Size(37, 13)
         Me._lblError.TabIndex = 5
         Me._lblError.Text = "Errors:"
         ' 
         ' _lblInformation
         ' 
         Me._lblInformation.AutoSize = True
         Me._lblInformation.Location = New System.Drawing.Point(16, 22)
         Me._lblInformation.Name = "_lblInformation"
         Me._lblInformation.Size = New System.Drawing.Size(250, 13)
         Me._lblInformation.TabIndex = 0
         Me._lblInformation.Text = "Total number of documents, total number of threads"
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._btnCancel.Location = New System.Drawing.Point(740, 49)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnConvertMoreFiles
         ' 
         Me._btnConvertMoreFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
         Me._btnConvertMoreFiles.Location = New System.Drawing.Point(19, 366)
         Me._btnConvertMoreFiles.Name = "_btnConvertMoreFiles"
         Me._btnConvertMoreFiles.Size = New System.Drawing.Size(158, 23)
         Me._btnConvertMoreFiles.TabIndex = 7
         Me._btnConvertMoreFiles.Text = "Convert more files"
         Me._btnConvertMoreFiles.UseVisualStyleBackColor = True
         ' 
         ' ConversionControl
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._btnConvertMoreFiles)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._lblInformation)
         Me.Controls.Add(Me._lbError)
         Me.Controls.Add(Me._lblError)
         Me.Controls.Add(Me._lbSuccess)
         Me.Controls.Add(Me._lblSuccess)
         Me.Controls.Add(Me._pbProgress)
         Me.Name = "ConversionControl"
         Me.Size = New System.Drawing.Size(833, 404)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _pbProgress As System.Windows.Forms.ProgressBar
      Private _lblSuccess As System.Windows.Forms.Label
      Private _lbSuccess As System.Windows.Forms.ListBox
      Private _lbError As System.Windows.Forms.ListBox
      Private _lblError As System.Windows.Forms.Label
      Private _lblInformation As System.Windows.Forms.Label
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnConvertMoreFiles As System.Windows.Forms.Button
   End Class
End Namespace
