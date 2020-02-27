Namespace OcrMultiThreadingDemo
   Partial Class GatherInformationControl
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GatherInformationControl))
         Me._lblTitle = New System.Windows.Forms.Label()
         Me._btnDestinationDirectoryBrowse = New System.Windows.Forms.Button()
         Me._tbDestinationDirectory = New System.Windows.Forms.TextBox()
         Me._tbFilter = New System.Windows.Forms.TextBox()
         Me._btnSourceDirectoryBrowse = New System.Windows.Forms.Button()
         Me._tbSourceDirectory = New System.Windows.Forms.TextBox()
         Me._lblSourceDirectory = New System.Windows.Forms.Label()
         Me._lblFilter = New System.Windows.Forms.Label()
         Me._lblDestinationDirectory = New System.Windows.Forms.Label()
         Me._lblFormat = New System.Windows.Forms.Label()
         Me._btnGo = New System.Windows.Forms.Button()
         Me._pnlSep1 = New System.Windows.Forms.Panel()
         Me._cbLoopContinuously = New System.Windows.Forms.CheckBox()
         Me._documentFormatSelector = New DocumentFormatSelector()
         Me.SuspendLayout()
         ' 
         ' _lblTitle
         ' 
         Me._lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._lblTitle.Location = New System.Drawing.Point(16, 23)
         Me._lblTitle.Name = "_lblTitle"
         Me._lblTitle.Size = New System.Drawing.Size(797, 141)
         Me._lblTitle.TabIndex = 0
         Me._lblTitle.Text = resources.GetString("_lblTitle.Text")
         ' 
         ' _btnDestinationDirectoryBrowse
         ' 
         Me._btnDestinationDirectoryBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._btnDestinationDirectoryBrowse.Location = New System.Drawing.Point(788, 232)
         Me._btnDestinationDirectoryBrowse.Name = "_btnDestinationDirectoryBrowse"
         Me._btnDestinationDirectoryBrowse.Size = New System.Drawing.Size(25, 23)
         Me._btnDestinationDirectoryBrowse.TabIndex = 8
         Me._btnDestinationDirectoryBrowse.Text = "..."
         Me._btnDestinationDirectoryBrowse.UseVisualStyleBackColor = True
         ' 
         ' _tbDestinationDirectory
         ' 
         Me._tbDestinationDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._tbDestinationDirectory.Location = New System.Drawing.Point(194, 234)
         Me._tbDestinationDirectory.Name = "_tbDestinationDirectory"
         Me._tbDestinationDirectory.Size = New System.Drawing.Size(589, 20)
         Me._tbDestinationDirectory.TabIndex = 7
         ' 
         ' _tbFilter
         ' 
         Me._tbFilter.Location = New System.Drawing.Point(194, 208)
         Me._tbFilter.Name = "_tbFilter"
         Me._tbFilter.Size = New System.Drawing.Size(198, 20)
         Me._tbFilter.TabIndex = 5
         ' 
         ' _btnSourceDirectoryBrowse
         ' 
         Me._btnSourceDirectoryBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._btnSourceDirectoryBrowse.Location = New System.Drawing.Point(788, 180)
         Me._btnSourceDirectoryBrowse.Name = "_btnSourceDirectoryBrowse"
         Me._btnSourceDirectoryBrowse.Size = New System.Drawing.Size(25, 23)
         Me._btnSourceDirectoryBrowse.TabIndex = 3
         Me._btnSourceDirectoryBrowse.Text = "..."
         Me._btnSourceDirectoryBrowse.UseVisualStyleBackColor = True
         ' 
         ' _tbSourceDirectory
         ' 
         Me._tbSourceDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._tbSourceDirectory.Location = New System.Drawing.Point(194, 182)
         Me._tbSourceDirectory.Name = "_tbSourceDirectory"
         Me._tbSourceDirectory.Size = New System.Drawing.Size(589, 20)
         Me._tbSourceDirectory.TabIndex = 2
         ' 
         ' _lblSourceDirectory
         ' 
         Me._lblSourceDirectory.Location = New System.Drawing.Point(3, 180)
         Me._lblSourceDirectory.Name = "_lblSourceDirectory"
         Me._lblSourceDirectory.Size = New System.Drawing.Size(164, 23)
         Me._lblSourceDirectory.TabIndex = 1
         Me._lblSourceDirectory.Text = "&Source directory:"
         Me._lblSourceDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         ' 
         ' _lblFilter
         ' 
         Me._lblFilter.Location = New System.Drawing.Point(3, 206)
         Me._lblFilter.Name = "_lblFilter"
         Me._lblFilter.Size = New System.Drawing.Size(164, 23)
         Me._lblFilter.TabIndex = 4
         Me._lblFilter.Text = "Source &files filter:"
         Me._lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         ' 
         ' _lblDestinationDirectory
         ' 
         Me._lblDestinationDirectory.Location = New System.Drawing.Point(3, 232)
         Me._lblDestinationDirectory.Name = "_lblDestinationDirectory"
         Me._lblDestinationDirectory.Size = New System.Drawing.Size(164, 23)
         Me._lblDestinationDirectory.TabIndex = 6
         Me._lblDestinationDirectory.Text = "&Destination directory:"
         Me._lblDestinationDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         ' 
         ' _lblFormat
         ' 
         Me._lblFormat.Location = New System.Drawing.Point(3, 258)
         Me._lblFormat.Name = "_lblFormat"
         Me._lblFormat.Size = New System.Drawing.Size(164, 23)
         Me._lblFormat.TabIndex = 9
         Me._lblFormat.Text = "Destination d&ocument format:"
         Me._lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         ' 
         ' _btnGo
         ' 
         Me._btnGo.Location = New System.Drawing.Point(193, 355)
         Me._btnGo.Name = "_btnGo"
         Me._btnGo.Size = New System.Drawing.Size(75, 23)
         Me._btnGo.TabIndex = 16
         Me._btnGo.Text = "&Go"
         Me._btnGo.UseVisualStyleBackColor = True
         ' 
         ' _pnlSep1
         ' 
         Me._pnlSep1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._pnlSep1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._pnlSep1.Location = New System.Drawing.Point(193, 341)
         Me._pnlSep1.Name = "_pnlSep1"
         Me._pnlSep1.Size = New System.Drawing.Size(620, 4)
         Me._pnlSep1.TabIndex = 15
         ' 
         ' _cbLoopContinuously
         ' 
         Me._cbLoopContinuously.AutoSize = True
         Me._cbLoopContinuously.Location = New System.Drawing.Point(194, 314)
         Me._cbLoopContinuously.Name = "_cbLoopContinuously"
         Me._cbLoopContinuously.Size = New System.Drawing.Size(112, 17)
         Me._cbLoopContinuously.TabIndex = 14
         Me._cbLoopContinuously.Text = "Loo&p continuously"
         Me._cbLoopContinuously.UseVisualStyleBackColor = True
         ' 
         ' _documentFormatSelector
         ' 
         Me._documentFormatSelector.FormatHasOptions = True
         Me._documentFormatSelector.Location = New System.Drawing.Point(194, 258)
         Me._documentFormatSelector.Name = "_documentFormatSelector"
         Me._documentFormatSelector.Size = New System.Drawing.Size(257, 23)
         Me._documentFormatSelector.TabIndex = 10
         Me._documentFormatSelector.TotalPages = 0
         ' 
         ' GatherInformationControl
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._cbLoopContinuously)
         Me.Controls.Add(Me._documentFormatSelector)
         Me.Controls.Add(Me._pnlSep1)
         Me.Controls.Add(Me._btnGo)
         Me.Controls.Add(Me._lblFormat)
         Me.Controls.Add(Me._lblDestinationDirectory)
         Me.Controls.Add(Me._lblFilter)
         Me.Controls.Add(Me._lblSourceDirectory)
         Me.Controls.Add(Me._btnDestinationDirectoryBrowse)
         Me.Controls.Add(Me._tbDestinationDirectory)
         Me.Controls.Add(Me._tbFilter)
         Me.Controls.Add(Me._btnSourceDirectoryBrowse)
         Me.Controls.Add(Me._tbSourceDirectory)
         Me.Controls.Add(Me._lblTitle)
         Me.Name = "GatherInformationControl"
         Me.Size = New System.Drawing.Size(830, 401)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _lblTitle As System.Windows.Forms.Label
      Private WithEvents _btnDestinationDirectoryBrowse As System.Windows.Forms.Button
      Private WithEvents _tbDestinationDirectory As System.Windows.Forms.TextBox
      Private WithEvents _tbFilter As System.Windows.Forms.TextBox
      Private WithEvents _btnSourceDirectoryBrowse As System.Windows.Forms.Button
      Private WithEvents _tbSourceDirectory As System.Windows.Forms.TextBox
      Private _lblSourceDirectory As System.Windows.Forms.Label
      Private _lblFilter As System.Windows.Forms.Label
      Private _lblDestinationDirectory As System.Windows.Forms.Label
      Private _lblFormat As System.Windows.Forms.Label
      Private WithEvents _btnGo As System.Windows.Forms.Button
      Private _pnlSep1 As System.Windows.Forms.Panel
      Private WithEvents _documentFormatSelector As DocumentFormatSelector
      Private _cbLoopContinuously As System.Windows.Forms.CheckBox
   End Class
End Namespace
