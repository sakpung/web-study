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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.DICOMPACSGroupBox = New System.Windows.Forms.GroupBox()
            Me.DICOMServersDataGridView = New System.Windows.Forms.DataGridView()
            Me.AeTitleToolStrip = New System.Windows.Forms.ToolStrip()
            Me.AddDicomServerToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.DeleteDicomServerToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.AETitleColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IPAddressColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PortColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TimeoutColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.SecureColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.DefaultQueryRetrieveColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.DefaultStoreServerColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.DICOMPACSGroupBox.SuspendLayout()
            CType(Me.DICOMServersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.AeTitleToolStrip.SuspendLayout()
            Me.SuspendLayout()
            '
            'DICOMPACSGroupBox
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
            'DICOMServersDataGridView
            '
            Me.DICOMServersDataGridView.AllowUserToAddRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.DICOMServersDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DICOMServersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.DICOMServersDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.0!)
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DICOMServersDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            Me.DICOMServersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DICOMServersDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AETitleColumn, Me.IPAddressColumn, Me.PortColumn, Me.TimeoutColumn, Me.SecureColumn, Me.DefaultQueryRetrieveColumn, Me.DefaultStoreServerColumn})
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
            DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSteelBlue
            DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DICOMServersDataGridView.DefaultCellStyle = DataGridViewCellStyle6
            Me.DICOMServersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DICOMServersDataGridView.EnableHeadersVisualStyles = False
            Me.DICOMServersDataGridView.GridColor = System.Drawing.Color.White
            Me.DICOMServersDataGridView.Location = New System.Drawing.Point(3, 55)
            Me.DICOMServersDataGridView.MultiSelect = False
            Me.DICOMServersDataGridView.Name = "DICOMServersDataGridView"
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 8.0!)
            DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightGray
            DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DICOMServersDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSteelBlue
            DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
            Me.DICOMServersDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle8
            Me.DICOMServersDataGridView.RowTemplate.Height = 26
            Me.DICOMServersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.DICOMServersDataGridView.Size = New System.Drawing.Size(953, 431)
            Me.DICOMServersDataGridView.TabIndex = 1
            '
            'AeTitleToolStrip
            '
            Me.AeTitleToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.AeTitleToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
            Me.AeTitleToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddDicomServerToolStripButton, Me.DeleteDicomServerToolStripButton})
            Me.AeTitleToolStrip.Location = New System.Drawing.Point(3, 16)
            Me.AeTitleToolStrip.Name = "AeTitleToolStrip"
            Me.AeTitleToolStrip.Size = New System.Drawing.Size(953, 39)
            Me.AeTitleToolStrip.Stretch = True
            Me.AeTitleToolStrip.TabIndex = 0
            '
            'AddDicomServerToolStripButton
            '
            Me.AddDicomServerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.AddDicomServerToolStripButton.Image = Global.Resources.client_add_32
            Me.AddDicomServerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.AddDicomServerToolStripButton.Name = "AddDicomServerToolStripButton"
            Me.AddDicomServerToolStripButton.Size = New System.Drawing.Size(36, 36)
            Me.AddDicomServerToolStripButton.Text = "Add Remote PACS"
            '
            'DeleteDicomServerToolStripButton
            '
            Me.DeleteDicomServerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.DeleteDicomServerToolStripButton.Image = Global.Resources.client_remove_32
            Me.DeleteDicomServerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.DeleteDicomServerToolStripButton.Name = "DeleteDicomServerToolStripButton"
            Me.DeleteDicomServerToolStripButton.Size = New System.Drawing.Size(36, 36)
            Me.DeleteDicomServerToolStripButton.Text = "Remove Remote PACS"
            '
            'AETitleColumn
            '
            Me.AETitleColumn.FillWeight = 85.5619!
            Me.AETitleColumn.HeaderText = "AE Title"
            Me.AETitleColumn.Name = "AETitleColumn"
            '
            'IPAddressColumn
            '
            DataGridViewCellStyle3.NullValue = Nothing
            Me.IPAddressColumn.DefaultCellStyle = DataGridViewCellStyle3
            Me.IPAddressColumn.FillWeight = 85.5619!
            Me.IPAddressColumn.HeaderText = "Host Name/Address"
            Me.IPAddressColumn.Name = "IPAddressColumn"
            '
            'PortColumn
            '
            DataGridViewCellStyle4.Format = "N0"
            DataGridViewCellStyle4.NullValue = Nothing
            Me.PortColumn.DefaultCellStyle = DataGridViewCellStyle4
            Me.PortColumn.FillWeight = 85.5619!
            Me.PortColumn.HeaderText = "Port"
            Me.PortColumn.Name = "PortColumn"
            '
            'TimeoutColumn
            '
            DataGridViewCellStyle5.Format = "N0"
            DataGridViewCellStyle5.NullValue = "30"
            Me.TimeoutColumn.DefaultCellStyle = DataGridViewCellStyle5
            Me.TimeoutColumn.FillWeight = 126.9036!
            Me.TimeoutColumn.HeaderText = "Communication Timeout"
            Me.TimeoutColumn.Name = "TimeoutColumn"
            '
            'SecureColumn
            '
            Me.SecureColumn.HeaderText = "Server Secure (TLS)"
            Me.SecureColumn.Name = "SecureColumn"
            '
            'DefaultQueryRetrieveColumn
            '
            Me.DefaultQueryRetrieveColumn.HeaderText = "Default Query/Retrieve"
            Me.DefaultQueryRetrieveColumn.Name = "DefaultQueryRetrieveColumn"
            '
            'DefaultStoreServerColumn
            '
            Me.DefaultStoreServerColumn.HeaderText = "Default Storage"
            Me.DefaultStoreServerColumn.Name = "DefaultStoreServerColumn"
            Me.DefaultStoreServerColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DefaultStoreServerColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DICOMServers
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
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
        Friend WithEvents AETitleColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IPAddressColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PortColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TimeoutColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents SecureColumn As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents DefaultQueryRetrieveColumn As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents DefaultStoreServerColumn As Windows.Forms.DataGridViewCheckBoxColumn
    End Class
End Namespace
