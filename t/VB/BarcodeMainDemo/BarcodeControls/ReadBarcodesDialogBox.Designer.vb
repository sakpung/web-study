
Partial Class ReadBarcodesDialogBox
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadBarcodesDialogBox))
      Me._stopButton = New System.Windows.Forms.Button()
      Me._messageLabel = New System.Windows.Forms.Label()
      Me._infoLabel = New System.Windows.Forms.Label()
      Me._showReadOptionsDialogCheckBox = New System.Windows.Forms.CheckBox()
      Me._barcodesGroupBox = New System.Windows.Forms.GroupBox()
      Me._barcodesListView = New System.Windows.Forms.ListView()
      Me._pageColumnHeader = New System.Windows.Forms.ColumnHeader()
      Me._symbologyColumnHeader = New System.Windows.Forms.ColumnHeader()
      Me._valueColumnHeader = New System.Windows.Forms.ColumnHeader()
      Me._locationColumnHeader = New System.Windows.Forms.ColumnHeader()
      Me._retryLinkLabel = New System.Windows.Forms.LinkLabel()
      Me._barcodesGroupBox.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _stopButton
      ' 
      resources.ApplyResources(Me._stopButton, "_stopButton")
      Me._stopButton.Name = "_stopButton"
      Me._stopButton.UseVisualStyleBackColor = True
      ' 
      ' _messageLabel
      ' 
      resources.ApplyResources(Me._messageLabel, "_messageLabel")
      Me._messageLabel.Name = "_messageLabel"
      ' 
      ' _infoLabel
      ' 
      resources.ApplyResources(Me._infoLabel, "_infoLabel")
      Me._infoLabel.Name = "_infoLabel"
      ' 
      ' _showReadOptionsDialogCheckBox
      ' 
      resources.ApplyResources(Me._showReadOptionsDialogCheckBox, "_showReadOptionsDialogCheckBox")
      Me._showReadOptionsDialogCheckBox.Checked = True
      Me._showReadOptionsDialogCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
      Me._showReadOptionsDialogCheckBox.Name = "_showReadOptionsDialogCheckBox"
      Me._showReadOptionsDialogCheckBox.UseVisualStyleBackColor = True
      ' 
      ' _barcodesGroupBox
      ' 
      resources.ApplyResources(Me._barcodesGroupBox, "_barcodesGroupBox")
      Me._barcodesGroupBox.BackColor = System.Drawing.SystemColors.Control
      Me._barcodesGroupBox.Controls.Add(Me._barcodesListView)
      Me._barcodesGroupBox.Name = "_barcodesGroupBox"
      Me._barcodesGroupBox.TabStop = False
      ' 
      ' _barcodesListView
      ' 
      Me._barcodesListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._pageColumnHeader, Me._symbologyColumnHeader, Me._valueColumnHeader, Me._locationColumnHeader})
      resources.ApplyResources(Me._barcodesListView, "_barcodesListView")
      Me._barcodesListView.FullRowSelect = True
      Me._barcodesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
      Me._barcodesListView.Name = "_barcodesListView"
      Me._barcodesListView.UseCompatibleStateImageBehavior = False
      Me._barcodesListView.View = System.Windows.Forms.View.Details
      ' 
      ' _pageColumnHeader
      ' 
      resources.ApplyResources(Me._pageColumnHeader, "_pageColumnHeader")
      ' 
      ' _symbologyColumnHeader
      ' 
      resources.ApplyResources(Me._symbologyColumnHeader, "_symbologyColumnHeader")
      ' 
      ' _valueColumnHeader
      ' 
      resources.ApplyResources(Me._valueColumnHeader, "_valueColumnHeader")
      ' 
      ' _locationColumnHeader
      ' 
      resources.ApplyResources(Me._locationColumnHeader, "_locationColumnHeader")
      ' 
      ' _retryLinkLabel
      ' 
      resources.ApplyResources(Me._retryLinkLabel, "_retryLinkLabel")
      Me._retryLinkLabel.Name = "_retryLinkLabel"
      Me._retryLinkLabel.TabStop = True
      ' 
      ' ReadBarcodesDialogBox
      ' 
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._retryLinkLabel)
      Me.Controls.Add(Me._barcodesGroupBox)
      Me.Controls.Add(Me._showReadOptionsDialogCheckBox)
      Me.Controls.Add(Me._infoLabel)
      Me.Controls.Add(Me._messageLabel)
      Me.Controls.Add(Me._stopButton)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ReadBarcodesDialogBox"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me._barcodesGroupBox.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private WithEvents _stopButton As System.Windows.Forms.Button
   Private _messageLabel As System.Windows.Forms.Label
   Private _infoLabel As System.Windows.Forms.Label
   Private _showReadOptionsDialogCheckBox As System.Windows.Forms.CheckBox
   Private _barcodesGroupBox As System.Windows.Forms.GroupBox
   Private _barcodesListView As System.Windows.Forms.ListView
   Private _pageColumnHeader As System.Windows.Forms.ColumnHeader
   Private _symbologyColumnHeader As System.Windows.Forms.ColumnHeader
   Private _valueColumnHeader As System.Windows.Forms.ColumnHeader
   Private _locationColumnHeader As System.Windows.Forms.ColumnHeader
   Private WithEvents _retryLinkLabel As System.Windows.Forms.LinkLabel
End Class
