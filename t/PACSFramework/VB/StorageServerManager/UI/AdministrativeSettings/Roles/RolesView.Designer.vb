Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.StorageServer.UI
   Partial Public Class RolesView
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
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me.comboBoxRoles = New System.Windows.Forms.ComboBox()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me.listViewPermissions = New System.Windows.Forms.ListView()
		 Me.buttonAdd = New System.Windows.Forms.Button()
		 Me.buttonDelete = New System.Windows.Forms.Button()
		 Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
		 Me.groupBox1.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me.buttonDelete)
		 Me.groupBox1.Controls.Add(Me.buttonAdd)
		 Me.groupBox1.Controls.Add(Me.listViewPermissions)
		 Me.groupBox1.Controls.Add(Me.label2)
		 Me.groupBox1.Controls.Add(Me.label1)
		 Me.groupBox1.Controls.Add(Me.comboBoxRoles)
		 Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		 Me.groupBox1.Location = New System.Drawing.Point(0, 0)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
		 Me.groupBox1.Size = New System.Drawing.Size(514, 537)
		 Me.groupBox1.TabIndex = 0
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "Roles"
		 ' 
		 ' comboBoxRoles
		 ' 
		 Me.comboBoxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me.comboBoxRoles.FormattingEnabled = True
		 Me.comboBoxRoles.Location = New System.Drawing.Point(10, 44)
		 Me.comboBoxRoles.Name = "comboBoxRoles"
		 Me.comboBoxRoles.Size = New System.Drawing.Size(221, 21)
		 Me.comboBoxRoles.TabIndex = 0
'		 Me.comboBoxRoles.SelectionChangeCommitted += New System.EventHandler(Me.comboBoxRoles_SelectionChangeCommitted);
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(7, 28)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(32, 13)
		 Me.label1.TabIndex = 1
		 Me.label1.Text = "Role:"
		 ' 
		 ' label2
		 ' 
		 Me.label2.AutoSize = True
		 Me.label2.Location = New System.Drawing.Point(7, 73)
		 Me.label2.Name = "label2"
		 Me.label2.Size = New System.Drawing.Size(65, 13)
		 Me.label2.TabIndex = 2
		 Me.label2.Text = "Permissions:"
		 ' 
		 ' listViewPermissions
		 ' 
		 Me.listViewPermissions.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
		 Me.listViewPermissions.CheckBoxes = True
		 Me.listViewPermissions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.columnHeader1})
		 Me.listViewPermissions.FullRowSelect = True
		 Me.listViewPermissions.Location = New System.Drawing.Point(10, 89)
		 Me.listViewPermissions.MultiSelect = False
		 Me.listViewPermissions.Name = "listViewPermissions"
		 Me.listViewPermissions.Size = New System.Drawing.Size(284, 443)
		 Me.listViewPermissions.TabIndex = 3
		 Me.listViewPermissions.UseCompatibleStateImageBehavior = False
		 Me.listViewPermissions.View = System.Windows.Forms.View.Details
'		 Me.listViewPermissions.ItemChecked += New System.Windows.Forms.ItemCheckedEventHandler(Me.listViewPermissions_ItemChecked);
		 ' 
		 ' buttonAdd
		 ' 
         Me.buttonAdd.Image = My.Resources.Add_16x16
		 Me.buttonAdd.Location = New System.Drawing.Point(231, 42)
		 Me.buttonAdd.Name = "buttonAdd"
		 Me.buttonAdd.Size = New System.Drawing.Size(32, 23)
		 Me.buttonAdd.TabIndex = 4
		 Me.buttonAdd.UseVisualStyleBackColor = True
'		 Me.buttonAdd.Click += New System.EventHandler(Me.buttonAdd_Click);
		 ' 
		 ' buttonDelete
		 ' 
		 Me.buttonDelete.Image = My.Resources.Remove_16x16
		 Me.buttonDelete.Location = New System.Drawing.Point(262, 42)
		 Me.buttonDelete.Name = "buttonDelete"
		 Me.buttonDelete.Size = New System.Drawing.Size(32, 23)
		 Me.buttonDelete.TabIndex = 5
		 Me.buttonDelete.UseVisualStyleBackColor = True
'		 Me.buttonDelete.Click += New System.EventHandler(Me.buttonDelete_Click);
		 ' 
		 ' columnHeader1
		 ' 
		 Me.columnHeader1.Text = "Permission"
		 ' 
		 ' RolesView
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.Controls.Add(Me.groupBox1)
		 Me.Name = "RolesView"
		 Me.Size = New System.Drawing.Size(514, 537)
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private WithEvents listViewPermissions As System.Windows.Forms.ListView
	  Private label2 As System.Windows.Forms.Label
	  Private label1 As System.Windows.Forms.Label
	  Private WithEvents comboBoxRoles As System.Windows.Forms.ComboBox
	  Private WithEvents buttonDelete As System.Windows.Forms.Button
	  Private WithEvents buttonAdd As System.Windows.Forms.Button
	  Private columnHeader1 As System.Windows.Forms.ColumnHeader
   End Class
End Namespace
