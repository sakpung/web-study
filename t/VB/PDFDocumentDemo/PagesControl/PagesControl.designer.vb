Imports Leadtools.Controls
Imports Leadtools

Namespace PDFDocumentDemo.PagesControl
   Partial Class PagesControl
      ''' <summary> 
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary> 
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
         Cleanup(disposing)

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
         Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(PagesControl))
         Dim _imageViewerVerticalViewLayout As ImageViewerVerticalViewLayout = New ImageViewerVerticalViewLayout()
         _imageViewerVerticalViewLayout.Columns = 1
         Me._rasterImageList = New ImageViewer(_imageViewerVerticalViewLayout)
         Me._titleLabel = New System.Windows.Forms.Label()
         Me._toolStrip = New System.Windows.Forms.ToolStrip()
         Me._thumbnailsToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._bookmarksToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._signaturesToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._bookmarksTreeView = New System.Windows.Forms.TreeView()
         Me._noBookmarksLabel = New System.Windows.Forms.Label()
         Me._signaturesTreeView = New System.Windows.Forms.TreeView()
         Me._noSignaturesLabel = New System.Windows.Forms.Label()
         Me._toolStrip.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _rasterImageList
         ' 

         Me._rasterImageList.BackColor = System.Drawing.SystemColors.AppWorkspace
         Me._rasterImageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._rasterImageList.Dock = System.Windows.Forms.DockStyle.Fill
         Me._rasterImageList.ItemSize = New LeadSize(160, 160)
         Me._rasterImageList.ViewHorizontalAlignment = ControlAlignment.Center
         Me._rasterImageList.Location = New System.Drawing.Point(0, 25)
         Me._rasterImageList.ItemSpacing = New LeadSize(20, 20)
         Me._rasterImageList.ItemBorderThickness = 2
         Me._rasterImageList.SelectedItemBorderColor = System.Drawing.Color.Blue
         Me._rasterImageList.ItemSizeMode = ControlSizeMode.Fit
         Me._rasterImageList.Name = "_rasterImageList"
         Me._rasterImageList.Size = New System.Drawing.Size(164, 322)
         Me._rasterImageList.TabIndex = 11
         Dim _imageViewerSelectItemsInteractiveMode As New ImageViewerSelectItemsInteractiveMode()
         _imageViewerSelectItemsInteractiveMode.SelectionMode = ImageViewerSelectionMode.Single
         Me._rasterImageList.InteractiveModes.Add(_imageViewerSelectItemsInteractiveMode)
         resources.ApplyResources(Me._rasterImageList, "_rasterImageList")
         Me._rasterImageList.ItemSize = New LeadSize(140, 160)
         Me._rasterImageList.UseDpi = True
         ' 
         ' _titleLabel
         ' 
         resources.ApplyResources(Me._titleLabel, "_titleLabel")
         Me._titleLabel.Name = "_titleLabel"
         ' 
         ' _toolStrip
         ' 
         Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._thumbnailsToolStripButton, Me._bookmarksToolStripButton, Me._signaturesToolStripButton})
         resources.ApplyResources(Me._toolStrip, "_toolStrip")
         Me._toolStrip.Name = "_toolStrip"
         ' 
         ' _thumbnailsToolStripButton
         ' 
         Me._thumbnailsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._thumbnailsToolStripButton.Image = Global.PDFDocumentDemo.Resources.Thumbnails
         resources.ApplyResources(Me._thumbnailsToolStripButton, "_thumbnailsToolStripButton")
         Me._thumbnailsToolStripButton.Name = "_thumbnailsToolStripButton"
         ' 
         ' _bookmarksToolStripButton
         ' 
         Me._bookmarksToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._bookmarksToolStripButton.Image = Global.PDFDocumentDemo.Resources.Bookmarks
         resources.ApplyResources(Me._bookmarksToolStripButton, "_bookmarksToolStripButton")
         Me._bookmarksToolStripButton.Name = "_bookmarksToolStripButton"
         ' 
         ' _signaturesToolStripButton
         ' 
         Me._signaturesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._signaturesToolStripButton.Image = Global.PDFDocumentDemo.Resources.Signature
         Me._signaturesToolStripButton.Name = "_signaturesToolStripButton"
         resources.ApplyResources(Me._signaturesToolStripButton, "_signaturesToolStripButton")
         ' 
         ' _bookmarksTreeView
         ' 
         resources.ApplyResources(Me._bookmarksTreeView, "_bookmarksTreeView")
         Me._bookmarksTreeView.Name = "_bookmarksTreeView"
         Me._bookmarksTreeView.ShowNodeToolTips = True
         ' 
         ' _noBookmarksLabel
         ' 
         resources.ApplyResources(Me._noBookmarksLabel, "_noBookmarksLabel")
         Me._noBookmarksLabel.Name = "_noBookmarksLabel"
         ' 
         ' _signaturesTreeView
         ' 
         resources.ApplyResources(Me._signaturesTreeView, "_signaturesTreeView")
         Me._signaturesTreeView.Name = "_signaturesTreeView"
         Me._signaturesTreeView.ShowNodeToolTips = True
         ' 
         ' _noSignaturesLabel
         ' 
         resources.ApplyResources(Me._noSignaturesLabel, "_noSignaturesLabel")
         Me._noSignaturesLabel.Name = "_noSignaturesLabel"
         ' 
         ' PagesControl
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._signaturesTreeView)
         Me.Controls.Add(Me._noSignaturesLabel)
         Me.Controls.Add(Me._noBookmarksLabel)
         Me.Controls.Add(Me._bookmarksTreeView)
         Me.Controls.Add(Me._rasterImageList)
         Me.Controls.Add(Me._toolStrip)
         Me.Controls.Add(Me._titleLabel)
         Me.Name = "PagesControl"
         Me._toolStrip.ResumeLayout(False)
         Me._toolStrip.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private WithEvents _rasterImageList As ImageViewer
      Private _titleLabel As System.Windows.Forms.Label
      Private _toolStrip As System.Windows.Forms.ToolStrip
      Private WithEvents _thumbnailsToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _bookmarksToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _signaturesToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _bookmarksTreeView As System.Windows.Forms.TreeView
      Private _noBookmarksLabel As System.Windows.Forms.Label
      Private WithEvents _signaturesTreeView As System.Windows.Forms.TreeView
      Private _noSignaturesLabel As System.Windows.Forms.Label

   End Class
End Namespace