Imports Microsoft.VisualBasic
Imports System
Namespace SharePointDemo
   Partial Public Class ServerControl
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
         Me.components = New System.ComponentModel.Container()
         Me._titleLabel = New System.Windows.Forms.Label()
         Me._toolStrip = New System.Windows.Forms.ToolStrip()
         Me._serverToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._refreshToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._downloadToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._listView = New System.Windows.Forms.ListView()
         Me._nameColumnHeader = New System.Windows.Forms.ColumnHeader()
         Me._typeColumnHeader = New System.Windows.Forms.ColumnHeader()
         Me._imageList = New System.Windows.Forms.ImageList(Me.components)
         Me._toolStrip.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _titleLabel
         ' 
         Me._titleLabel.AutoEllipsis = True
         Me._titleLabel.Dock = System.Windows.Forms.DockStyle.Top
         Me._titleLabel.Location = New System.Drawing.Point(0, 0)
         Me._titleLabel.Name = "_titleLabel"
         Me._titleLabel.Size = New System.Drawing.Size(465, 23)
         Me._titleLabel.TabIndex = 0
         Me._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _toolStrip
         ' 
         Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._serverToolStripButton, Me._refreshToolStripButton, Me._toolStripSeparator1, Me._downloadToolStripButton})
         Me._toolStrip.Location = New System.Drawing.Point(0, 23)
         Me._toolStrip.Name = "_toolStrip"
         Me._toolStrip.Size = New System.Drawing.Size(465, 25)
         Me._toolStrip.TabIndex = 1
         ' 
         ' _serverToolStripButton
         ' 
         Me._serverToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._serverToolStripButton.Image = Global.SharePointDemo.My.Resources.Server
         Me._serverToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._serverToolStripButton.Name = "_serverToolStripButton"
         Me._serverToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._serverToolStripButton.ToolTipText = "Select the SharePoint server address"
         '		 Me._serverToolStripButton.Click += New System.EventHandler(Me._serverToolStripButton_Click);
         ' 
         ' _refreshToolStripButton
         ' 
         Me._refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._refreshToolStripButton.Image = Global.SharePointDemo.My.Resources.Refresh
         Me._refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._refreshToolStripButton.Name = "_refreshToolStripButton"
         Me._refreshToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._refreshToolStripButton.ToolTipText = "Refresh the documents list"
         '		 Me._refreshToolStripButton.Click += New System.EventHandler(Me._refreshToolStripButton_Click);
         ' 
         ' _toolStripSeparator1
         ' 
         Me._toolStripSeparator1.Name = "_toolStripSeparator1"
         Me._toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _downloadToolStripButton
         ' 
         Me._downloadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._downloadToolStripButton.Image = Global.SharePointDemo.My.Resources.Download
         Me._downloadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._downloadToolStripButton.Name = "_downloadToolStripButton"
         Me._downloadToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._downloadToolStripButton.ToolTipText = "Download and view the selected image"
         '		 Me._downloadToolStripButton.Click += New System.EventHandler(Me._downloadToolStripButton_Click);
         ' 
         ' _listView
         ' 
         Me._listView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._nameColumnHeader, Me._typeColumnHeader})
         Me._listView.Dock = System.Windows.Forms.DockStyle.Fill
         Me._listView.FullRowSelect = True
         Me._listView.HideSelection = False
         Me._listView.Location = New System.Drawing.Point(0, 48)
         Me._listView.MultiSelect = False
         Me._listView.Name = "_listView"
         Me._listView.Size = New System.Drawing.Size(465, 384)
         Me._listView.SmallImageList = Me._imageList
         Me._listView.TabIndex = 2
         Me._listView.UseCompatibleStateImageBehavior = False
         Me._listView.View = System.Windows.Forms.View.Details
         '		 Me._listView.MouseDoubleClick += New System.Windows.Forms.MouseEventHandler(Me._listView_MouseDoubleClick);
         '		 Me._listView.SelectedIndexChanged += New System.EventHandler(Me._listView_SelectedIndexChanged);
         '		 Me._listView.ColumnClick += New System.Windows.Forms.ColumnClickEventHandler(Me._listView_ColumnClick);
         '		 Me._listView.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._listView_KeyPress);
         ' 
         ' _nameColumnHeader
         ' 
         Me._nameColumnHeader.Text = "Name"
         Me._nameColumnHeader.Width = 151
         ' 
         ' _typeColumnHeader
         ' 
         Me._typeColumnHeader.Text = "Type"
         Me._typeColumnHeader.Width = 200
         ' 
         ' _imageList
         ' 
         Me._imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
         Me._imageList.ImageSize = New System.Drawing.Size(16, 16)
         Me._imageList.TransparentColor = System.Drawing.Color.Transparent
         ' 
         ' ServerControl
         ' 
         Me.Controls.Add(Me._listView)
         Me.Controls.Add(Me._toolStrip)
         Me.Controls.Add(Me._titleLabel)
         Me.Name = "ServerControl"
         Me.Size = New System.Drawing.Size(465, 432)
         Me._toolStrip.ResumeLayout(False)
         Me._toolStrip.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _titleLabel As System.Windows.Forms.Label
      Private _toolStrip As System.Windows.Forms.ToolStrip
      Private WithEvents _serverToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _refreshToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _listView As System.Windows.Forms.ListView
      Private _typeColumnHeader As System.Windows.Forms.ColumnHeader
      Private _nameColumnHeader As System.Windows.Forms.ColumnHeader
      Private _imageList As System.Windows.Forms.ImageList
      Private _toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _downloadToolStripButton As System.Windows.Forms.ToolStripButton
   End Class
End Namespace
