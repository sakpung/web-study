
Partial Class UpdateMasterFormsData
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateMasterFormsData))
      Me._prgbar = New System.Windows.Forms.ProgressBar()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnConvert = New System.Windows.Forms.Button()
      Me._btnBrowseSrcFolder = New System.Windows.Forms.Button()
      Me._txtSrcFolder = New System.Windows.Forms.TextBox()
      Me._lblSrcFolder = New System.Windows.Forms.Label()
      Me._cbUseFullTextSearch = New System.Windows.Forms.CheckBox()
      Me.SuspendLayout()
      ' 
      ' _prgbar
      ' 
      Me._prgbar.Dock = System.Windows.Forms.DockStyle.Bottom
      Me._prgbar.Location = New System.Drawing.Point(0, 122)
      Me._prgbar.Name = "_prgbar"
      Me._prgbar.Size = New System.Drawing.Size(610, 23)
      Me._prgbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me._prgbar.TabIndex = 14
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
      Me._btnCancel.Location = New System.Drawing.Point(450, 63)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(121, 38)
      Me._btnCancel.TabIndex = 13
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnConvert
      ' 
      Me._btnConvert.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
      Me._btnConvert.Location = New System.Drawing.Point(306, 63)
      Me._btnConvert.Name = "_btnConvert"
      Me._btnConvert.Size = New System.Drawing.Size(121, 38)
      Me._btnConvert.TabIndex = 12
      Me._btnConvert.Text = "Convert"
      Me._btnConvert.UseVisualStyleBackColor = True
      ' 
      ' _btnBrowseSrcFolder
      ' 
      Me._btnBrowseSrcFolder.Location = New System.Drawing.Point(578, 25)
      Me._btnBrowseSrcFolder.Name = "_btnBrowseSrcFolder"
      Me._btnBrowseSrcFolder.Size = New System.Drawing.Size(28, 20)
      Me._btnBrowseSrcFolder.TabIndex = 11
      Me._btnBrowseSrcFolder.Text = "..."
      Me._btnBrowseSrcFolder.UseVisualStyleBackColor = True
      ' 
      ' _txtSrcFolder
      ' 
      Me._txtSrcFolder.Location = New System.Drawing.Point(85, 25)
      Me._txtSrcFolder.Name = "_txtSrcFolder"
      Me._txtSrcFolder.Size = New System.Drawing.Size(487, 20)
      Me._txtSrcFolder.TabIndex = 9
      ' 
      ' _lblSrcFolder
      ' 
      Me._lblSrcFolder.AutoSize = True
      Me._lblSrcFolder.Location = New System.Drawing.Point(6, 28)
      Me._lblSrcFolder.Name = "_lblSrcFolder"
      Me._lblSrcFolder.Size = New System.Drawing.Size(73, 13)
      Me._lblSrcFolder.TabIndex = 10
      Me._lblSrcFolder.Text = "Source Folder"
      ' 
      ' _cbUseFullTextSearch
      ' 
      Me._cbUseFullTextSearch.AutoSize = True
      Me._cbUseFullTextSearch.Location = New System.Drawing.Point(85, 75)
      Me._cbUseFullTextSearch.Name = "_cbUseFullTextSearch"
      Me._cbUseFullTextSearch.Size = New System.Drawing.Size(187, 17)
      Me._cbUseFullTextSearch.TabIndex = 15
      Me._cbUseFullTextSearch.Text = "Use/Generate full text search data"
      Me._cbUseFullTextSearch.UseVisualStyleBackColor = True
      Me._cbUseFullTextSearch.Checked = True
      '
      ' UpdateMasterFormsData
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(610, 145)
      Me.Controls.Add(Me._cbUseFullTextSearch)
      Me.Controls.Add(Me._prgbar)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnConvert)
      Me.Controls.Add(Me._btnBrowseSrcFolder)
      Me.Controls.Add(Me._txtSrcFolder)
      Me.Controls.Add(Me._lblSrcFolder)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.Name = "UpdateMasterFormsData"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Update Master Forms Data"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _prgbar As System.Windows.Forms.ProgressBar
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnConvert As System.Windows.Forms.Button
   Private WithEvents _btnBrowseSrcFolder As System.Windows.Forms.Button
   Private WithEvents _txtSrcFolder As System.Windows.Forms.TextBox
   Private _lblSrcFolder As System.Windows.Forms.Label
   Private _cbUseFullTextSearch As System.Windows.Forms.CheckBox
End Class
