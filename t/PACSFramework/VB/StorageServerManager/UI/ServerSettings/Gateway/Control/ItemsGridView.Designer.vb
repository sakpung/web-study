Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class ItemsGridView
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemsGridView))
         Me.ContainerGroupBox = New System.Windows.Forms.GroupBox()
         Me.ItemsDataGridView = New System.Windows.Forms.DataGridView()
         Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
         Me.AddItemToolStrip = New System.Windows.Forms.ToolStripButton()
         Me.ModifyToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me.DeleteToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me.ContainerGroupBox.SuspendLayout()
         CType(Me.ItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.MainToolStrip.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' ContainerGroupBox
         ' 
         Me.ContainerGroupBox.Controls.Add(Me.ItemsDataGridView)
         Me.ContainerGroupBox.Controls.Add(Me.MainToolStrip)
         Me.ContainerGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
         Me.ContainerGroupBox.Location = New System.Drawing.Point(0, 0)
         Me.ContainerGroupBox.Name = "ContainerGroupBox"
         Me.ContainerGroupBox.Size = New System.Drawing.Size(581, 504)
         Me.ContainerGroupBox.TabIndex = 0
         Me.ContainerGroupBox.TabStop = False
         Me.ContainerGroupBox.Text = "Title"
         ' 
         ' ItemsDataGridView
         ' 
         Me.ItemsDataGridView.AllowUserToAddRows = False
         Me.ItemsDataGridView.AllowUserToDeleteRows = False
         Me.ItemsDataGridView.AllowUserToResizeColumns = False
         Me.ItemsDataGridView.AllowUserToResizeRows = False
         Me.ItemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
         Me.ItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
         Me.ItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
         Me.ItemsDataGridView.Location = New System.Drawing.Point(3, 55)
         Me.ItemsDataGridView.MultiSelect = False
         Me.ItemsDataGridView.Name = "ItemsDataGridView"
         Me.ItemsDataGridView.ReadOnly = True
         Me.ItemsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
         Me.ItemsDataGridView.RowHeadersVisible = False
         Me.ItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
         Me.ItemsDataGridView.Size = New System.Drawing.Size(575, 446)
         Me.ItemsDataGridView.TabIndex = 1
         ' 
         ' MainToolStrip
         ' 
         Me.MainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
         Me.MainToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
         Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddItemToolStrip, Me.ModifyToolStripButton, Me.DeleteToolStripButton})
         Me.MainToolStrip.Location = New System.Drawing.Point(3, 16)
         Me.MainToolStrip.Name = "MainToolStrip"
         Me.MainToolStrip.Size = New System.Drawing.Size(575, 39)
         Me.MainToolStrip.Stretch = True
         Me.MainToolStrip.TabIndex = 0
         Me.MainToolStrip.Text = "toolStrip1"
         ' 
         ' AddItemToolStrip
         ' 
         Me.AddItemToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.AddItemToolStrip.Image = (CType(resources.GetObject("AddItemToolStrip.Image"), System.Drawing.Image))
         Me.AddItemToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.AddItemToolStrip.Name = "AddItemToolStrip"
         Me.AddItemToolStrip.Size = New System.Drawing.Size(36, 36)
         Me.AddItemToolStrip.Text = "toolStripButton1"
         ' 
         ' ModifyToolStripButton
         ' 
         Me.ModifyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.ModifyToolStripButton.Image = (CType(resources.GetObject("ModifyToolStripButton.Image"), System.Drawing.Image))
         Me.ModifyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.ModifyToolStripButton.Name = "ModifyToolStripButton"
         Me.ModifyToolStripButton.Size = New System.Drawing.Size(36, 36)
         Me.ModifyToolStripButton.Text = "toolStripButton1"
         ' 
         ' DeleteToolStripButton
         ' 
         Me.DeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.DeleteToolStripButton.Image = (CType(resources.GetObject("DeleteToolStripButton.Image"), System.Drawing.Image))
         Me.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.DeleteToolStripButton.Name = "DeleteToolStripButton"
         Me.DeleteToolStripButton.Size = New System.Drawing.Size(36, 36)
         Me.DeleteToolStripButton.Text = "toolStripButton1"
         ' 
         ' ItemsGridView
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.ContainerGroupBox)
         Me.Name = "ItemsGridView"
         Me.Size = New System.Drawing.Size(581, 504)
         Me.ContainerGroupBox.ResumeLayout(False)
         Me.ContainerGroupBox.PerformLayout()
         CType(Me.ItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
         Me.MainToolStrip.ResumeLayout(False)
         Me.MainToolStrip.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private ContainerGroupBox As System.Windows.Forms.GroupBox
      Friend ItemsDataGridView As System.Windows.Forms.DataGridView
      Friend MainToolStrip As System.Windows.Forms.ToolStrip
      Private AddItemToolStrip As System.Windows.Forms.ToolStripButton
      Private ModifyToolStripButton As System.Windows.Forms.ToolStripButton
      Private DeleteToolStripButton As System.Windows.Forms.ToolStripButton
   End Class
End Namespace
