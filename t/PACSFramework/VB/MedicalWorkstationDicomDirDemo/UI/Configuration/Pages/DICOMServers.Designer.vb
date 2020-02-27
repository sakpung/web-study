Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
   Partial Public Class DICOMServers
	  ''' <summary> 
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.IContainer = Nothing

	  ''' <summary> 
	  ''' Clean up any resources being used.
	  ''' </summary>
	  ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
		 Dim dataGridViewCellStyle9 As New System.Windows.Forms.DataGridViewCellStyle()
		 Dim dataGridViewCellStyle10 As New System.Windows.Forms.DataGridViewCellStyle()
		 Dim dataGridViewCellStyle14 As New System.Windows.Forms.DataGridViewCellStyle()
		 Dim dataGridViewCellStyle15 As New System.Windows.Forms.DataGridViewCellStyle()
		 Dim dataGridViewCellStyle16 As New System.Windows.Forms.DataGridViewCellStyle()
		 Dim dataGridViewCellStyle11 As New System.Windows.Forms.DataGridViewCellStyle()
		 Dim dataGridViewCellStyle12 As New System.Windows.Forms.DataGridViewCellStyle()
		 Dim dataGridViewCellStyle13 As New System.Windows.Forms.DataGridViewCellStyle()
		 Me.DICOMPACSGroupBox = New System.Windows.Forms.GroupBox()
		 Me.DICOMServersDataGridView = New System.Windows.Forms.DataGridView()
		 Me.AETitleColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.IPAddressColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.PortColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.TimeoutColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.DefaultQueryRetrieveColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
		 Me.DefaultStoreServerColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
		 Me.AeTitleToolStrip = New System.Windows.Forms.ToolStrip()
		 Me.AddDicomServerToolStripButton = New System.Windows.Forms.ToolStripButton()
		 Me.DeleteDicomServerToolStripButton = New System.Windows.Forms.ToolStripButton()
		 Me.DICOMPACSGroupBox.SuspendLayout()
		 CType(Me.DICOMServersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.AeTitleToolStrip.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' DICOMPACSGroupBox
		 ' 
		 Me.DICOMPACSGroupBox.Controls.Add(Me.DICOMServersDataGridView)
		 Me.DICOMPACSGroupBox.Controls.Add(Me.AeTitleToolStrip)
		 Me.DICOMPACSGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
		 Me.DICOMPACSGroupBox.ForeColor = System.Drawing.Color.White
		 Me.DICOMPACSGroupBox.Location = New System.Drawing.Point(0, 0)
		 Me.DICOMPACSGroupBox.Name = "DICOMPACSGroupBox"
		 Me.DICOMPACSGroupBox.Size = New System.Drawing.Size(959, 489)
		 Me.DICOMPACSGroupBox.TabIndex = 0
		 Me.DICOMPACSGroupBox.TabStop = False
		 Me.DICOMPACSGroupBox.Text = "Remote PACS"
		 ' 
		 ' DICOMServersDataGridView
		 ' 
		 Me.DICOMServersDataGridView.AllowUserToAddRows = False
		 dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(224))))), (CInt(Fix((CByte(224))))), (CInt(Fix((CByte(224))))))
		 Me.DICOMServersDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9
		 Me.DICOMServersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		 Me.DICOMServersDataGridView.BackgroundColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
		 dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		 dataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke
		 dataGridViewCellStyle10.Font = New System.Drawing.Font("Tahoma", 8F)
		 dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
		 dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightGray
		 dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		 dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True
		 Me.DICOMServersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10
		 Me.DICOMServersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		 Me.DICOMServersDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() { Me.AETitleColumn, Me.IPAddressColumn, Me.PortColumn, Me.TimeoutColumn, Me.DefaultQueryRetrieveColumn, Me.DefaultStoreServerColumn})
		 dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		 dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
		 dataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
		 dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
		 dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.LightSteelBlue
		 dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		 dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False
		 Me.DICOMServersDataGridView.DefaultCellStyle = dataGridViewCellStyle14
		 Me.DICOMServersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
		 Me.DICOMServersDataGridView.EnableHeadersVisualStyles = False
		 Me.DICOMServersDataGridView.GridColor = System.Drawing.Color.White
		 Me.DICOMServersDataGridView.Location = New System.Drawing.Point(3, 55)
		 Me.DICOMServersDataGridView.MultiSelect = False
		 Me.DICOMServersDataGridView.Name = "DICOMServersDataGridView"
		 dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		 dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
		 dataGridViewCellStyle15.Font = New System.Drawing.Font("Tahoma", 8F)
		 dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
		 dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightGray
		 dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		 dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True
		 Me.DICOMServersDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle15
		 dataGridViewCellStyle16.BackColor = System.Drawing.Color.White
		 dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
		 dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.LightSteelBlue
		 dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
		 Me.DICOMServersDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle16
		 Me.DICOMServersDataGridView.RowTemplate.Height = 26
		 Me.DICOMServersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		 Me.DICOMServersDataGridView.Size = New System.Drawing.Size(953, 431)
		 Me.DICOMServersDataGridView.TabIndex = 1
		 ' 
		 ' AETitleColumn
		 ' 
		 Me.AETitleColumn.FillWeight = 85.5619F
		 Me.AETitleColumn.HeaderText = "AE Title"
		 Me.AETitleColumn.Name = "AETitleColumn"
		 ' 
		 ' IPAddressColumn
		 ' 
		 dataGridViewCellStyle11.NullValue = Nothing
		 Me.IPAddressColumn.DefaultCellStyle = dataGridViewCellStyle11
		 Me.IPAddressColumn.FillWeight = 85.5619F
		 Me.IPAddressColumn.HeaderText = "Host Name/Address"
		 Me.IPAddressColumn.Name = "IPAddressColumn"
		 ' 
		 ' PortColumn
		 ' 
		 dataGridViewCellStyle12.Format = "N0"
		 dataGridViewCellStyle12.NullValue = Nothing
		 Me.PortColumn.DefaultCellStyle = dataGridViewCellStyle12
		 Me.PortColumn.FillWeight = 85.5619F
		 Me.PortColumn.HeaderText = "Port"
		 Me.PortColumn.Name = "PortColumn"
		 ' 
		 ' TimeoutColumn
		 ' 
		 dataGridViewCellStyle13.Format = "N0"
		 dataGridViewCellStyle13.NullValue = "30"
		 Me.TimeoutColumn.DefaultCellStyle = dataGridViewCellStyle13
		 Me.TimeoutColumn.FillWeight = 126.9036F
		 Me.TimeoutColumn.HeaderText = "Communication Timeout"
		 Me.TimeoutColumn.Name = "TimeoutColumn"
		 ' 
		 ' DefaultQueryRetrieveColumn
		 ' 
		 Me.DefaultQueryRetrieveColumn.HeaderText = "Default Query/Retrieve"
		 Me.DefaultQueryRetrieveColumn.Name = "DefaultQueryRetrieveColumn"
		 ' 
		 ' DefaultStoreServerColumn
		 ' 
		 Me.DefaultStoreServerColumn.HeaderText = "Default Storage"
		 Me.DefaultStoreServerColumn.Name = "DefaultStoreServerColumn"
		 Me.DefaultStoreServerColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True
		 Me.DefaultStoreServerColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
		 ' 
		 ' AeTitleToolStrip
		 ' 
		 Me.AeTitleToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		 Me.AeTitleToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
		 Me.AeTitleToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.AddDicomServerToolStripButton, Me.DeleteDicomServerToolStripButton})
		 Me.AeTitleToolStrip.Location = New System.Drawing.Point(3, 16)
		 Me.AeTitleToolStrip.Name = "AeTitleToolStrip"
		 Me.AeTitleToolStrip.Size = New System.Drawing.Size(953, 39)
		 Me.AeTitleToolStrip.Stretch = True
		 Me.AeTitleToolStrip.TabIndex = 0
		 ' 
		 ' AddDicomServerToolStripButton
		 ' 
		 Me.AddDicomServerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.AddDicomServerToolStripButton.Image = Resources.client_add_32
       Me.AddDicomServerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
       Me.AddDicomServerToolStripButton.Name = "AddDicomServerToolStripButton"
       Me.AddDicomServerToolStripButton.Size = New System.Drawing.Size(36, 36)
       Me.AddDicomServerToolStripButton.Text = "Add Remote PACS"
       ' 
       ' DeleteDicomServerToolStripButton
       ' 
       Me.DeleteDicomServerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.DeleteDicomServerToolStripButton.Image = Resources.client_remove_32
		 Me.DeleteDicomServerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		 Me.DeleteDicomServerToolStripButton.Name = "DeleteDicomServerToolStripButton"
		 Me.DeleteDicomServerToolStripButton.Size = New System.Drawing.Size(36, 36)
		 Me.DeleteDicomServerToolStripButton.Text = "Remove Remote PACS"
		 ' 
		 ' DICOMServers
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
		 Me.Controls.Add(Me.DICOMPACSGroupBox)
		 Me.ForeColor = System.Drawing.Color.White
		 Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		 Me.Name = "DICOMServers"
		 Me.Size = New System.Drawing.Size(959, 489)
		 Me.DICOMPACSGroupBox.ResumeLayout(False)
		 Me.DICOMPACSGroupBox.PerformLayout()
		 CType(Me.DICOMServersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.AeTitleToolStrip.ResumeLayout(False)
		 Me.AeTitleToolStrip.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Protected DICOMPACSGroupBox As System.Windows.Forms.GroupBox
	  Protected DICOMServersDataGridView As System.Windows.Forms.DataGridView
	  Protected AeTitleToolStrip As System.Windows.Forms.ToolStrip
	  Protected AddDicomServerToolStripButton As System.Windows.Forms.ToolStripButton
	  Protected DeleteDicomServerToolStripButton As System.Windows.Forms.ToolStripButton
	  Private AETitleColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Private IPAddressColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Private PortColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Private TimeoutColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Private DefaultQueryRetrieveColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
	  Private DefaultStoreServerColumn As System.Windows.Forms.DataGridViewCheckBoxColumn

   End Class
End Namespace
