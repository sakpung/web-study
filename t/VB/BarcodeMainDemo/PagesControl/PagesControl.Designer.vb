Imports Leadtools.Controls
Imports Leadtools

Partial Class PagesControl
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PagesControl))
      Me._titleLabel = New System.Windows.Forms.Label()
      Me._rasterImageList = New ImageViewer(New ImageViewerVerticalViewLayout() With {.Columns = 1})
      Me._toolStrip = New System.Windows.Forms.ToolStrip()
      Me.SuspendLayout()
      ' 
      ' _titleLabel
      ' 
      resources.ApplyResources(Me._titleLabel, "_titleLabel")
      Me._titleLabel.Name = "_titleLabel"
      ' 
      ' _rasterImageList
      ' 
      Me._rasterImageList.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me._rasterImageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      resources.ApplyResources(Me._rasterImageList, "_rasterImageList")
      Me._rasterImageList.ItemSizeMode = ControlSizeMode.Fit
      Me._rasterImageList.ItemSize = New LeadSize(180, 200)
      Me._rasterImageList.Name = "_rasterImageList"
      Me._rasterImageList.UseDpi = True
      Me._rasterImageList.ViewHorizontalAlignment = ControlAlignment.Center
      Me._rasterImageList.ItemSpacing = New LeadSize(20, 20)
      Me._rasterImageList.ItemBorderThickness = 2
      Me._rasterImageList.SelectedItemBorderColor = System.Drawing.Color.Blue
      Me._rasterImageList.Dock = System.Windows.Forms.DockStyle.Left
      Me._rasterImageList.Location = New System.Drawing.Point(0, 93)
      Me._rasterImageList.Size = New System.Drawing.Size(197, 475)
      Me._rasterImageList.InteractiveModes.Add(New ImageViewerSelectItemsInteractiveMode() With {.SelectionMode = ImageViewerSelectionMode.Single})
      ' 
      ' _toolStrip
      ' 
      resources.ApplyResources(Me._toolStrip, "_toolStrip")
      Me._toolStrip.Name = "_toolStrip"
      ' 
      ' PagesControl
      ' 
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._rasterImageList)
      Me.Controls.Add(Me._toolStrip)
      Me.Controls.Add(Me._titleLabel)
      Me.Name = "PagesControl"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _titleLabel As System.Windows.Forms.Label
   Private WithEvents _rasterImageList As ImageViewer
   Private _toolStrip As System.Windows.Forms.ToolStrip
End Class
