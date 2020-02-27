Imports Leadtools.Annotations.WinForms

Namespace PDFDocumentDemo.Annotations
   Partial Class AnnotationsControl
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnnotationsControl))
         Me._annotationsLabel = New System.Windows.Forms.Label()
         Me._commentsListBox = New System.Windows.Forms.ListBox()
         Me._automationListControl = New AutomationObjectsListControl()
         Me._contextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me._propertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._contentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._deleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._toolbarPanel = New System.Windows.Forms.Panel()
         Me._commentsListLabel = New System.Windows.Forms.Label()
         Me._contextMenuStrip.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _annotationsLabel
         ' 
         resources.ApplyResources(Me._annotationsLabel, "_annotationsLabel")
         Me._annotationsLabel.Name = "_annotationsLabel"
         '
         '_automationListControl
         '
         Me._automationListControl.ContextMenuStrip = Me._contextMenuStrip
         Me._automationListControl.Dock = System.Windows.Forms.DockStyle.Fill
         Me._automationListControl.Name = "_automationListControl"
         ' 
         ' _contextMenuStrip
         ' 
         Me._contextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._propertiesToolStripMenuItem, Me._contentToolStripMenuItem, Me._deleteToolStripMenuItem})
         Me._contextMenuStrip.Name = "_contextMenuStrip"
         resources.ApplyResources(Me._contextMenuStrip, "_contextMenuStrip")
         ' 
         ' _propertiesToolStripMenuItem
         ' 
         Me._propertiesToolStripMenuItem.Name = "_propertiesToolStripMenuItem"
         resources.ApplyResources(Me._propertiesToolStripMenuItem, "_propertiesToolStripMenuItem")
         '
         ' _contentToolStripMenuItem
         ' 
         Me._contentToolStripMenuItem.Name = "_contentToolStripMenuItem"
         resources.ApplyResources(Me._contentToolStripMenuItem, "_contentToolStripMenuItem")
         ' 
         ' _deleteToolStripMenuItem
         ' 
         Me._deleteToolStripMenuItem.Name = "_deleteToolStripMenuItem"
         resources.ApplyResources(Me._deleteToolStripMenuItem, "_deleteToolStripMenuItem")
         ' 
         ' _toolbarPanel
         ' 
         resources.ApplyResources(Me._toolbarPanel, "_toolbarPanel")
         Me._toolbarPanel.Name = "_toolbarPanel"
         ' 
         ' _commentsListLabel
         ' 
         resources.ApplyResources(Me._commentsListLabel, "_commentsListLabel")
         Me._commentsListLabel.Name = "_commentsListLabel"
         ' 
         ' AnnotationsControl
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         'this.Controls.Add(this._commentsListBox);
         Me.Controls.Add(Me._automationListControl)
         Me.Controls.Add(Me._commentsListLabel)
         Me.Controls.Add(Me._toolbarPanel)
         Me.Controls.Add(Me._annotationsLabel)
         Me.Name = "AnnotationsControl"
         Me._contextMenuStrip.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _annotationsLabel As System.Windows.Forms.Label
      Private _automationListControl As AutomationObjectsListControl
      Private _commentsListBox As System.Windows.Forms.ListBox
      Private _toolbarPanel As System.Windows.Forms.Panel
      Private _commentsListLabel As System.Windows.Forms.Label
      Private _contextMenuStrip As System.Windows.Forms.ContextMenuStrip
      Private WithEvents _propertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _deleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _contentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   End Class
End Namespace
