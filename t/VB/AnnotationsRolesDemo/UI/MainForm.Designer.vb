Namespace AnnotationsRolesDemo
   Partial Class MainForm
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
         If disposing AndAlso (components IsNot Nothing) Then
            CleanUp(disposing)
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me.tabControl1 = New System.Windows.Forms.TabControl()
         Me._tbAdminPage = New System.Windows.Forms.TabPage()
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         Me._btnDeleteUser = New System.Windows.Forms.Button()
         Me._btnSave = New System.Windows.Forms.Button()
         Me._btnLoad = New System.Windows.Forms.Button()
         Me._chkLstGroups = New System.Windows.Forms.CheckedListBox()
         Me._btnAddUser = New System.Windows.Forms.Button()
         Me._lstUsers = New System.Windows.Forms.ListBox()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me._btnDeleteGroup = New System.Windows.Forms.Button()
         Me._chkLstRoles = New System.Windows.Forms.CheckedListBox()
         Me._btnAddGroup = New System.Windows.Forms.Button()
         Me._lstGroups = New System.Windows.Forms.ListBox()
         Me._tbAnnotationsPage = New System.Windows.Forms.TabPage()
         Me.panel1 = New System.Windows.Forms.Panel()
         Me._btnLoadAnnotations = New System.Windows.Forms.Button()
         Me._btnSaveAnnotations = New System.Windows.Forms.Button()
         Me._cmbUsers = New System.Windows.Forms.ComboBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.tabControl1.SuspendLayout()
         Me._tbAdminPage.SuspendLayout()
         Me.groupBox3.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me._tbAnnotationsPage.SuspendLayout()
         Me.panel1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' tabControl1
         ' 
         Me.tabControl1.Controls.Add(Me._tbAdminPage)
         Me.tabControl1.Controls.Add(Me._tbAnnotationsPage)
         Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.tabControl1.Location = New System.Drawing.Point(0, 0)
         Me.tabControl1.Name = "tabControl1"
         Me.tabControl1.SelectedIndex = 0
         Me.tabControl1.Size = New System.Drawing.Size(850, 521)
         Me.tabControl1.TabIndex = 0
         ' 
         ' _tbAdminPage
         ' 
         Me._tbAdminPage.Controls.Add(Me.groupBox3)
         Me._tbAdminPage.Controls.Add(Me.groupBox2)
         Me._tbAdminPage.Location = New System.Drawing.Point(4, 22)
         Me._tbAdminPage.Name = "_tbAdminPage"
         Me._tbAdminPage.Padding = New System.Windows.Forms.Padding(3)
         Me._tbAdminPage.Size = New System.Drawing.Size(842, 495)
         Me._tbAdminPage.TabIndex = 0
         Me._tbAdminPage.Text = "Administrator"
         Me._tbAdminPage.UseVisualStyleBackColor = True
         ' 
         ' groupBox3
         ' 
         Me.groupBox3.Controls.Add(Me._btnDeleteUser)
         Me.groupBox3.Controls.Add(Me._btnSave)
         Me.groupBox3.Controls.Add(Me._btnLoad)
         Me.groupBox3.Controls.Add(Me._chkLstGroups)
         Me.groupBox3.Controls.Add(Me._btnAddUser)
         Me.groupBox3.Controls.Add(Me._lstUsers)
         Me.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill
         Me.groupBox3.Location = New System.Drawing.Point(424, 3)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(415, 489)
         Me.groupBox3.TabIndex = 4
         Me.groupBox3.TabStop = False
         Me.groupBox3.Text = "Users"
         ' 
         ' _btnDeleteUser
         ' 
         Me._btnDeleteUser.Location = New System.Drawing.Point(87, 198)
         Me._btnDeleteUser.Name = "_btnDeleteUser"
         Me._btnDeleteUser.Size = New System.Drawing.Size(80, 20)
         Me._btnDeleteUser.TabIndex = 9
         Me._btnDeleteUser.Text = "Delete U&ser"
         Me._btnDeleteUser.UseVisualStyleBackColor = True
         ' 
         ' _btnSave
         ' 
         Me._btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._btnSave.Location = New System.Drawing.Point(326, 461)
         Me._btnSave.Name = "_btnSave"
         Me._btnSave.Size = New System.Drawing.Size(75, 23)
         Me._btnSave.TabIndex = 8
         Me._btnSave.Text = "&Save"
         Me._btnSave.UseVisualStyleBackColor = True
         ' 
         ' _btnLoad
         ' 
         Me._btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._btnLoad.Location = New System.Drawing.Point(245, 461)
         Me._btnLoad.Name = "_btnLoad"
         Me._btnLoad.Size = New System.Drawing.Size(75, 23)
         Me._btnLoad.TabIndex = 7
         Me._btnLoad.Text = "&Load"
         Me._btnLoad.UseVisualStyleBackColor = True
         ' 
         ' _chkLstGroups
         ' 
         Me._chkLstGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._chkLstGroups.FormattingEnabled = True
         Me._chkLstGroups.Location = New System.Drawing.Point(14, 229)
         Me._chkLstGroups.Name = "_chkLstGroups"
         Me._chkLstGroups.Size = New System.Drawing.Size(387, 214)
         Me._chkLstGroups.TabIndex = 6
         ' 
         ' _btnAddUser
         ' 
         Me._btnAddUser.Location = New System.Drawing.Point(14, 198)
         Me._btnAddUser.Name = "_btnAddUser"
         Me._btnAddUser.Size = New System.Drawing.Size(67, 20)
         Me._btnAddUser.TabIndex = 5
         Me._btnAddUser.Text = "Add &User"
         Me._btnAddUser.UseVisualStyleBackColor = True
         ' 
         ' _lstUsers
         ' 
         Me._lstUsers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._lstUsers.FormattingEnabled = True
         Me._lstUsers.Location = New System.Drawing.Point(14, 19)
         Me._lstUsers.Name = "_lstUsers"
         Me._lstUsers.Size = New System.Drawing.Size(387, 173)
         Me._lstUsers.TabIndex = 4
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.Controls.Add(Me._btnDeleteGroup)
         Me.groupBox2.Controls.Add(Me._chkLstRoles)
         Me.groupBox2.Controls.Add(Me._btnAddGroup)
         Me.groupBox2.Controls.Add(Me._lstGroups)
         Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Left
         Me.groupBox2.Location = New System.Drawing.Point(3, 3)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(421, 489)
         Me.groupBox2.TabIndex = 3
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "Groups"
         ' 
         ' _btnDeleteGroup
         ' 
         Me._btnDeleteGroup.Location = New System.Drawing.Point(129, 198)
         Me._btnDeleteGroup.Name = "_btnDeleteGroup"
         Me._btnDeleteGroup.Size = New System.Drawing.Size(105, 20)
         Me._btnDeleteGroup.TabIndex = 6
         Me._btnDeleteGroup.Text = "Delete G&roup"
         Me._btnDeleteGroup.UseVisualStyleBackColor = True
         ' 
         ' _chkLstRoles
         ' 
         Me._chkLstRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._chkLstRoles.FormattingEnabled = True
         Me._chkLstRoles.Location = New System.Drawing.Point(10, 229)
         Me._chkLstRoles.Name = "_chkLstRoles"
         Me._chkLstRoles.Size = New System.Drawing.Size(403, 214)
         Me._chkLstRoles.TabIndex = 5
         ' 
         ' _btnAddGroup
         ' 
         Me._btnAddGroup.Location = New System.Drawing.Point(10, 198)
         Me._btnAddGroup.Name = "_btnAddGroup"
         Me._btnAddGroup.Size = New System.Drawing.Size(67, 20)
         Me._btnAddGroup.TabIndex = 4
         Me._btnAddGroup.Text = "Add &Group"
         Me._btnAddGroup.UseVisualStyleBackColor = True
         ' 
         ' _lstGroups
         ' 
         Me._lstGroups.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._lstGroups.FormattingEnabled = True
         Me._lstGroups.Location = New System.Drawing.Point(10, 19)
         Me._lstGroups.Name = "_lstGroups"
         Me._lstGroups.Size = New System.Drawing.Size(403, 173)
         Me._lstGroups.TabIndex = 3
         ' 
         ' _tbAnnotationsPage
         ' 
         Me._tbAnnotationsPage.Controls.Add(Me.panel1)
         Me._tbAnnotationsPage.Location = New System.Drawing.Point(4, 22)
         Me._tbAnnotationsPage.Name = "_tbAnnotationsPage"
         Me._tbAnnotationsPage.Padding = New System.Windows.Forms.Padding(3)
         Me._tbAnnotationsPage.Size = New System.Drawing.Size(842, 495)
         Me._tbAnnotationsPage.TabIndex = 1
         Me._tbAnnotationsPage.Text = "Annotations"
         Me._tbAnnotationsPage.UseVisualStyleBackColor = True
         ' 
         ' panel1
         ' 
         Me.panel1.Controls.Add(Me._btnLoadAnnotations)
         Me.panel1.Controls.Add(Me._btnSaveAnnotations)
         Me.panel1.Controls.Add(Me._cmbUsers)
         Me.panel1.Controls.Add(Me.label1)
         Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
         Me.panel1.Location = New System.Drawing.Point(3, 3)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(836, 51)
         Me.panel1.TabIndex = 0
         ' 
         ' _btnLoadAnnotations
         ' 
         Me._btnLoadAnnotations.Location = New System.Drawing.Point(315, 16)
         Me._btnLoadAnnotations.Name = "_btnLoadAnnotations"
         Me._btnLoadAnnotations.Size = New System.Drawing.Size(75, 23)
         Me._btnLoadAnnotations.TabIndex = 2
         Me._btnLoadAnnotations.Text = "&Load"
         Me._btnLoadAnnotations.UseVisualStyleBackColor = True
         ' 
         ' _btnSaveAnnotations
         ' 
         Me._btnSaveAnnotations.Location = New System.Drawing.Point(224, 16)
         Me._btnSaveAnnotations.Name = "_btnSaveAnnotations"
         Me._btnSaveAnnotations.Size = New System.Drawing.Size(75, 23)
         Me._btnSaveAnnotations.TabIndex = 1
         Me._btnSaveAnnotations.Text = "&Save"
         Me._btnSaveAnnotations.UseVisualStyleBackColor = True
         ' 
         ' _cmbUsers
         ' 
         Me._cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbUsers.FormattingEnabled = True
         Me._cmbUsers.Location = New System.Drawing.Point(83, 16)
         Me._cmbUsers.Name = "_cmbUsers"
         Me._cmbUsers.Size = New System.Drawing.Size(121, 21)
         Me._cmbUsers.TabIndex = 1
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(10, 19)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(67, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Current user:"
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(850, 521)
         Me.Controls.Add(Me.tabControl1)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "Form1"
         Me.tabControl1.ResumeLayout(False)
         Me._tbAdminPage.ResumeLayout(False)
         Me.groupBox3.ResumeLayout(False)
         Me.groupBox2.ResumeLayout(False)
         Me._tbAnnotationsPage.ResumeLayout(False)
         Me.panel1.ResumeLayout(False)
         Me.panel1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private tabControl1 As System.Windows.Forms.TabControl
      Private _tbAdminPage As System.Windows.Forms.TabPage
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private WithEvents _tbAnnotationsPage As System.Windows.Forms.TabPage
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private WithEvents _btnAddUser As System.Windows.Forms.Button
      Private _lstUsers As System.Windows.Forms.ListBox
      Private WithEvents _btnAddGroup As System.Windows.Forms.Button
      Private _lstGroups As System.Windows.Forms.ListBox
      Private panel1 As System.Windows.Forms.Panel
      Private WithEvents _cmbUsers As System.Windows.Forms.ComboBox
      Private label1 As System.Windows.Forms.Label
      Private _chkLstRoles As System.Windows.Forms.CheckedListBox
      Private _chkLstGroups As System.Windows.Forms.CheckedListBox
      Private WithEvents _btnSave As System.Windows.Forms.Button
      Private WithEvents _btnLoad As System.Windows.Forms.Button
      Private WithEvents _btnDeleteUser As System.Windows.Forms.Button
      Private WithEvents _btnDeleteGroup As System.Windows.Forms.Button
      Private WithEvents _btnSaveAnnotations As System.Windows.Forms.Button
      Private WithEvents _btnLoadAnnotations As System.Windows.Forms.Button
   End Class
End Namespace
