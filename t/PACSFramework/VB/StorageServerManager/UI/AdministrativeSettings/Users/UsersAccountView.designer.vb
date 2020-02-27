Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
Namespace Leadtools.Demos.StorageServer.UI
   Partial Public Class UsersAccountView
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
         Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
         Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
         Dim dataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
         Dim dataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
         Dim dataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
         Dim dataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
         Me.ContainerGroupBox = New System.Windows.Forms.GroupBox()
         Me.UsersDataGridView = New System.Windows.Forms.DataGridView()
         Me.UserNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me.NewPasswordDataGridViewButtonColumn = New System.Windows.Forms.DataGridViewLinkColumn()
         Me.ExpiresColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me.Permissions = New System.Windows.Forms.DataGridViewLinkColumn()
         Me.UsersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
         Me.UsersSourceDataset = New Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users.UsersSource()
         Me.UsersToolStrip = New System.Windows.Forms.ToolStrip()
         Me.AddUserToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me.DeleteUserToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me.ContainerGroupBox.SuspendLayout()
         CType(Me.UsersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.UsersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.UsersSourceDataset, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.UsersToolStrip.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' ContainerGroupBox
         ' 
         Me.ContainerGroupBox.Controls.Add(Me.UsersDataGridView)
         Me.ContainerGroupBox.Controls.Add(Me.UsersToolStrip)
         Me.ContainerGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
         Me.ContainerGroupBox.ForeColor = System.Drawing.Color.Gold
         Me.ContainerGroupBox.Location = New System.Drawing.Point(0, 0)
         Me.ContainerGroupBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.ContainerGroupBox.Name = "ContainerGroupBox"
         Me.ContainerGroupBox.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.ContainerGroupBox.Size = New System.Drawing.Size(725, 465)
         Me.ContainerGroupBox.TabIndex = 0
         Me.ContainerGroupBox.TabStop = False
         Me.ContainerGroupBox.Text = "User Accounts"
         ' 
         ' UsersDataGridView
         ' 
         Me.UsersDataGridView.AllowUserToAddRows = False
         dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(224)))), (CInt((CByte(224)))), (CInt((CByte(224)))))
         Me.UsersDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1
         Me.UsersDataGridView.AutoGenerateColumns = False
         Me.UsersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
         Me.UsersDataGridView.BackgroundColor = System.Drawing.Color.FromArgb((CInt((CByte(75)))), (CInt((CByte(75)))), (CInt((CByte(75)))))
         dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
         dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
         dataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.0F)
         dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
         dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray
         dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
         dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True
         Me.UsersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
         Me.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
         Me.UsersDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserNameDataGridViewTextBoxColumn, Me.NewPasswordDataGridViewButtonColumn, Me.ExpiresColumn, Me.Permissions})
         Me.UsersDataGridView.DataSource = Me.UsersBindingSource
         dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
         dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
         dataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gold
         dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
         dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
         dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False
         Me.UsersDataGridView.DefaultCellStyle = dataGridViewCellStyle4
         Me.UsersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
         Me.UsersDataGridView.EnableHeadersVisualStyles = False
         Me.UsersDataGridView.GridColor = System.Drawing.Color.White
         Me.UsersDataGridView.Location = New System.Drawing.Point(3, 54)
         Me.UsersDataGridView.MultiSelect = False
         Me.UsersDataGridView.Name = "UsersDataGridView"
         dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
         dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
         dataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.0F)
         dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
         dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightGray
         dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
         dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True
         Me.UsersDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5
         Me.UsersDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
         dataGridViewCellStyle6.BackColor = System.Drawing.Color.White
         dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
         dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSteelBlue
         dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
         Me.UsersDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle6
         Me.UsersDataGridView.RowTemplate.Height = 26
         Me.UsersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
         Me.UsersDataGridView.Size = New System.Drawing.Size(719, 409)
         Me.UsersDataGridView.TabIndex = 11
         ' 
         ' UserNameDataGridViewTextBoxColumn
         ' 
         Me.UserNameDataGridViewTextBoxColumn.DataPropertyName = "UserName"
         Me.UserNameDataGridViewTextBoxColumn.FillWeight = 127.1574F
         Me.UserNameDataGridViewTextBoxColumn.HeaderText = "User Name"
         Me.UserNameDataGridViewTextBoxColumn.Name = "UserNameDataGridViewTextBoxColumn"
         Me.UserNameDataGridViewTextBoxColumn.ReadOnly = True
         ' 
         ' NewPasswordDataGridViewButtonColumn
         ' 
         Me.NewPasswordDataGridViewButtonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
         Me.NewPasswordDataGridViewButtonColumn.DataPropertyName = "NewPassword"
         dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(224)))), (CInt((CByte(224)))), (CInt((CByte(224)))))
         dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb((CInt((CByte(0)))), (CInt((CByte(0)))), (CInt((CByte(192)))))
         dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray
         dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb((CInt((CByte(0)))), (CInt((CByte(0)))), (CInt((CByte(192)))))
         Me.NewPasswordDataGridViewButtonColumn.DefaultCellStyle = dataGridViewCellStyle3
         Me.NewPasswordDataGridViewButtonColumn.HeaderText = "New Password"
         Me.NewPasswordDataGridViewButtonColumn.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
         Me.NewPasswordDataGridViewButtonColumn.Name = "NewPasswordDataGridViewButtonColumn"
         Me.NewPasswordDataGridViewButtonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True
         Me.NewPasswordDataGridViewButtonColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
         Me.NewPasswordDataGridViewButtonColumn.TrackVisitedState = False
         Me.NewPasswordDataGridViewButtonColumn.Width = 102
         ' 
         ' ExpiresColumn
         ' 
         Me.ExpiresColumn.DataPropertyName = "Expires"
         Me.ExpiresColumn.HeaderText = "Password Expires"
         Me.ExpiresColumn.Name = "ExpiresColumn"
         Me.ExpiresColumn.ReadOnly = True
         ' 
         ' Permissions
         ' 
         Me.Permissions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
         Me.Permissions.HeaderText = "Permissions"
         Me.Permissions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
         Me.Permissions.Name = "Permissions"
         Me.Permissions.Resizable = System.Windows.Forms.DataGridViewTriState.True
         Me.Permissions.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
         Me.Permissions.TrackVisitedState = False
         Me.Permissions.Width = 87
         ' 
         ' UsersBindingSource
         ' 
         Me.UsersBindingSource.DataMember = "Users"
         Me.UsersBindingSource.DataSource = Me.UsersSourceDataset
         ' 
         ' UsersSourceDataset
         ' 
         Me.UsersSourceDataset.DataSetName = "UsersSource"
         Me.UsersSourceDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
         ' 
         ' UsersToolStrip
         ' 
         Me.UsersToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
         Me.UsersToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
         Me.UsersToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddUserToolStripButton, Me.DeleteUserToolStripButton})
         Me.UsersToolStrip.Location = New System.Drawing.Point(3, 15)
         Me.UsersToolStrip.Name = "UsersToolStrip"
         Me.UsersToolStrip.Size = New System.Drawing.Size(719, 39)
         Me.UsersToolStrip.Stretch = True
         Me.UsersToolStrip.TabIndex = 10
         ' 
         ' AddUserToolStripButton
         ' 
         Me.AddUserToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.AddUserToolStripButton.Image = Global.My.Resources.UserAdd
         Me.AddUserToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.AddUserToolStripButton.Name = "AddUserToolStripButton"
         Me.AddUserToolStripButton.Size = New System.Drawing.Size(36, 36)
         Me.AddUserToolStripButton.Text = "Add User"
         ' 
         ' DeleteUserToolStripButton
         ' 
         Me.DeleteUserToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.DeleteUserToolStripButton.Image = Global.My.Resources.UserDelete
         Me.DeleteUserToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.DeleteUserToolStripButton.Name = "DeleteUserToolStripButton"
         Me.DeleteUserToolStripButton.Size = New System.Drawing.Size(36, 36)
         Me.DeleteUserToolStripButton.Text = "Delete User"
         ' 
         ' UsersAccountView
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(75)))), (CInt((CByte(75)))), (CInt((CByte(75)))))
         Me.Controls.Add(Me.ContainerGroupBox)
         Me.ForeColor = System.Drawing.Color.White
         Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.Name = "UsersAccountView"
         Me.Size = New System.Drawing.Size(725, 465)
         Me.ContainerGroupBox.ResumeLayout(False)
         Me.ContainerGroupBox.PerformLayout()
         CType(Me.UsersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.UsersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.UsersSourceDataset, System.ComponentModel.ISupportInitialize).EndInit()
         Me.UsersToolStrip.ResumeLayout(False)
         Me.UsersToolStrip.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Protected UsersBindingSource As System.Windows.Forms.BindingSource
      Protected ContainerGroupBox As System.Windows.Forms.GroupBox
      Protected UsersDataGridView As System.Windows.Forms.DataGridView
      Protected UsersToolStrip As System.Windows.Forms.ToolStrip
      Protected AddUserToolStripButton As System.Windows.Forms.ToolStripButton
      Protected DeleteUserToolStripButton As System.Windows.Forms.ToolStripButton
      Private UsersSourceDataset As UsersSource
      Private UserNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
      Private Permissions As System.Windows.Forms.DataGridViewLinkColumn
      Private NewPasswordDataGridViewButtonColumn As System.Windows.Forms.DataGridViewLinkColumn
      Private ExpiresColumn As System.Windows.Forms.DataGridViewTextBoxColumn

   End Class
End Namespace
