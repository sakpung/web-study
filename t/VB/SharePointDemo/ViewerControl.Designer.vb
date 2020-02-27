Imports Microsoft.VisualBasic
Imports System
Imports Leadtools.Controls

Namespace SharePointDemo
   Partial Public Class ViewerControl
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

#Region "Component Designer generated code"

      ''' <summary> 
      ''' Required method for Designer support - do not modify 
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me._titleLabel = New System.Windows.Forms.Label()
         Me._toolStrip = New System.Windows.Forms.ToolStrip()
         Me._openFileToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._uploadToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._previousPageToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._nextPageToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._pageToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
         Me._pageToolStripLabel = New System.Windows.Forms.ToolStripLabel()
         Me._toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me._zoomOutToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._zoomInToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._zoomToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
         Me._fitPageWidthToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._fitPageToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me._selectModeToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._panModeToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._zoomToSelectionToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._ImageViewer = New ImageViewer()
         Me._toolStrip.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _titleLabel
         ' 
         Me._titleLabel.AutoEllipsis = True
         Me._titleLabel.Dock = System.Windows.Forms.DockStyle.Top
         Me._titleLabel.Location = New System.Drawing.Point(0, 0)
         Me._titleLabel.Name = "_titleLabel"
         Me._titleLabel.Size = New System.Drawing.Size(468, 23)
         Me._titleLabel.TabIndex = 0
         Me._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _toolStrip
         ' 
         Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._openFileToolStripButton, Me._uploadToolStripButton, Me._toolStripSeparator1, Me._previousPageToolStripButton, Me._nextPageToolStripButton, Me._pageToolStripTextBox, Me._pageToolStripLabel, Me._toolStripSeparator2, Me._zoomOutToolStripButton, Me._zoomInToolStripButton, Me._zoomToolStripComboBox, Me._fitPageWidthToolStripButton, Me._fitPageToolStripButton, Me._toolStripSeparator3, Me._selectModeToolStripButton, Me._panModeToolStripButton, Me._zoomToSelectionToolStripButton})
         Me._toolStrip.Location = New System.Drawing.Point(0, 23)
         Me._toolStrip.Name = "_toolStrip"
         Me._toolStrip.Size = New System.Drawing.Size(468, 25)
         Me._toolStrip.TabIndex = 3
         Me._toolStrip.Text = "toolStrip1"
         ' 
         ' _openFileToolStripButton
         ' 
         Me._openFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._openFileToolStripButton.Image = Global.SharePointDemo.My.Resources.OpenFile
         Me._openFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._openFileToolStripButton.Name = "_openFileToolStripButton"
         Me._openFileToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._openFileToolStripButton.ToolTipText = "Open image from disk file"
         '		 Me._openFileToolStripButton.Click += New System.EventHandler(Me._openFileToolStripButton_Click);
         ' 
         ' _uploadToolStripButton
         ' 
         Me._uploadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._uploadToolStripButton.Image = Global.SharePointDemo.My.Resources.Upload
         Me._uploadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._uploadToolStripButton.Name = "_uploadToolStripButton"
         Me._uploadToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._uploadToolStripButton.ToolTipText = "Upload current image to the server"
         '		 Me._uploadToolStripButton.Click += New System.EventHandler(Me._uploadToolStripButton_Click);
         ' 
         ' _toolStripSeparator1
         ' 
         Me._toolStripSeparator1.Name = "_toolStripSeparator1"
         Me._toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _previousPageToolStripButton
         ' 
         Me._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._previousPageToolStripButton.Image = Global.SharePointDemo.My.Resources.PreviousPage
         Me._previousPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._previousPageToolStripButton.Name = "_previousPageToolStripButton"
         Me._previousPageToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._previousPageToolStripButton.ToolTipText = "Go to previous page in the document"
         '		 Me._previousPageToolStripButton.Click += New System.EventHandler(Me._previousPageToolStripButton_Click);
         ' 
         ' _nextPageToolStripButton
         ' 
         Me._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._nextPageToolStripButton.Image = Global.SharePointDemo.My.Resources.NextPage
         Me._nextPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._nextPageToolStripButton.Name = "_nextPageToolStripButton"
         Me._nextPageToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._nextPageToolStripButton.ToolTipText = "Go to next page in the document"
         '		 Me._nextPageToolStripButton.Click += New System.EventHandler(Me._nextPageToolStripButton_Click);
         ' 
         ' _pageToolStripTextBox
         ' 
         Me._pageToolStripTextBox.AutoSize = False
         Me._pageToolStripTextBox.Name = "_pageToolStripTextBox"
         Me._pageToolStripTextBox.Size = New System.Drawing.Size(40, 25)
         Me._pageToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
         Me._pageToolStripTextBox.ToolTipText = "Current page number in the document"
         '		 Me._pageToolStripTextBox.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._pageToolStripTextBox_KeyPress);
         ' 
         ' _pageToolStripLabel
         ' 
         Me._pageToolStripLabel.AutoSize = False
         Me._pageToolStripLabel.Name = "_pageToolStripLabel"
         Me._pageToolStripLabel.Size = New System.Drawing.Size(40, 22)
         Me._pageToolStripLabel.Text = "/ WWW"
         ' 
         ' _toolStripSeparator2
         ' 
         Me._toolStripSeparator2.Name = "_toolStripSeparator2"
         Me._toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _zoomOutToolStripButton
         ' 
         Me._zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._zoomOutToolStripButton.Image = Global.SharePointDemo.My.Resources.ZoomOut
         Me._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._zoomOutToolStripButton.Name = "_zoomOutToolStripButton"
         Me._zoomOutToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._zoomOutToolStripButton.ToolTipText = "Zoom out"
         '		 Me._zoomOutToolStripButton.Click += New System.EventHandler(Me._zoomOutToolStripButton_Click);
         ' 
         ' _zoomInToolStripButton
         ' 
         Me._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._zoomInToolStripButton.Image = Global.SharePointDemo.My.Resources.ZoomIn
         Me._zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._zoomInToolStripButton.Name = "_zoomInToolStripButton"
         Me._zoomInToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._zoomInToolStripButton.ToolTipText = "Zoom in"
         '		 Me._zoomInToolStripButton.Click += New System.EventHandler(Me._zoomInToolStripButton_Click);
         ' 
         ' _zoomToolStripComboBox
         ' 
         Me._zoomToolStripComboBox.Items.AddRange(New Object() {"10%", "25%", "50%", "75%", "100%", "125%", "200%", "400%", "800%", "1600%", "2400%", "3200%", "6400%", "Actual Size", "Fit Page", "Fit Width"})
         Me._zoomToolStripComboBox.Name = "_zoomToolStripComboBox"
         Me._zoomToolStripComboBox.Size = New System.Drawing.Size(80, 25)
         '		 Me._zoomToolStripComboBox.SelectedIndexChanged += New System.EventHandler(Me._zoomToolStripComboBox_SelectedIndexChanged);
         '		 Me._zoomToolStripComboBox.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._zoomToolStripComboBox_KeyPress);
         ' 
         ' _fitPageWidthToolStripButton
         ' 
         Me._fitPageWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._fitPageWidthToolStripButton.Image = Global.SharePointDemo.My.Resources.FitPageWidth
         Me._fitPageWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton"
         Me._fitPageWidthToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._fitPageWidthToolStripButton.ToolTipText = "Fit page width in window"
         '		 Me._fitPageWidthToolStripButton.Click += New System.EventHandler(Me._fitPageWidthToolStripButton_Click);
         ' 
         ' _fitPageToolStripButton
         ' 
         Me._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._fitPageToolStripButton.Image = Global.SharePointDemo.My.Resources.FitPage
         Me._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._fitPageToolStripButton.Name = "_fitPageToolStripButton"
         Me._fitPageToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._fitPageToolStripButton.ToolTipText = "Fit entire page in window"
         '		 Me._fitPageToolStripButton.Click += New System.EventHandler(Me._fitPageToolStripButton_Click);
         ' 
         ' _toolStripSeparator3
         ' 
         Me._toolStripSeparator3.Name = "_toolStripSeparator3"
         Me._toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _selectModeToolStripButton
         ' 
         Me._selectModeToolStripButton.CheckOnClick = True
         Me._selectModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._selectModeToolStripButton.Image = Global.SharePointDemo.My.Resources.SelectMode
         Me._selectModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._selectModeToolStripButton.Name = "_selectModeToolStripButton"
         Me._selectModeToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._selectModeToolStripButton.ToolTipText = "Select mode"
         '		 Me._selectModeToolStripButton.Click += New System.EventHandler(Me._selectModeToolStripButton_Click);
         ' 
         ' _panModeToolStripButton
         ' 
         Me._panModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._panModeToolStripButton.Image = Global.SharePointDemo.My.Resources.PanMode
         Me._panModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._panModeToolStripButton.Name = "_panModeToolStripButton"
         Me._panModeToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._panModeToolStripButton.ToolTipText = "Pan mode"
         '		 Me._panModeToolStripButton.Click += New System.EventHandler(Me._panModeToolStripButton_Click);
         ' 
         ' _zoomToSelectionToolStripButton
         ' 
         Me._zoomToSelectionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._zoomToSelectionToolStripButton.Image = Global.SharePointDemo.My.Resources.ZoomSelectionMode
         Me._zoomToSelectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._zoomToSelectionToolStripButton.Name = "_zoomToSelectionToolStripButton"
         Me._zoomToSelectionToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._zoomToSelectionToolStripButton.ToolTipText = "Zoom to selection mode"
         ' 
         ' ViewerControl
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._ImageViewer)
         Me.Controls.Add(Me._toolStrip)
         Me.Controls.Add(Me._titleLabel)
         Me.Name = "ViewerControl"
         Me.Size = New System.Drawing.Size(468, 448)
         Me._toolStrip.ResumeLayout(False)
         Me._toolStrip.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _titleLabel As System.Windows.Forms.Label
      Private _toolStrip As System.Windows.Forms.ToolStrip
      Private WithEvents _previousPageToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _nextPageToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _pageToolStripTextBox As System.Windows.Forms.ToolStripTextBox
      Private _pageToolStripLabel As System.Windows.Forms.ToolStripLabel
      Private _toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _zoomOutToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _zoomInToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _zoomToolStripComboBox As System.Windows.Forms.ToolStripComboBox
      Private WithEvents _fitPageWidthToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _fitPageToolStripButton As System.Windows.Forms.ToolStripButton
      Private _toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _selectModeToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _panModeToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _zoomToSelectionToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _ImageViewer As ImageViewer
      Private WithEvents _openFileToolStripButton As System.Windows.Forms.ToolStripButton
      Private _toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _uploadToolStripButton As System.Windows.Forms.ToolStripButton
   End Class
End Namespace
