Namespace Leadtools.Demos.StorageServer.UI
   Partial Public Class ServerSettingsDialog
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

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
            Me.panel1 = New System.Windows.Forms.Panel()
            Me.treeView1 = New System.Windows.Forms.TreeView()
            Me.PagesContainerPanel = New System.Windows.Forms.Panel()
            Me.panel2 = New System.Windows.Forms.Panel()
            Me.panel4 = New System.Windows.Forms.Panel()
            Me.ApplyChangesButton = New System.Windows.Forms.Button()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.OKButton = New System.Windows.Forms.Button()
            Me.CancelChangesButton = New System.Windows.Forms.Button()
            Me.panel1.SuspendLayout()
            Me.panel2.SuspendLayout()
            Me.panel4.SuspendLayout()
            Me.SuspendLayout()
            '
            'panel1
            '
            Me.panel1.Controls.Add(Me.treeView1)
            Me.panel1.Dock = System.Windows.Forms.DockStyle.Left
            Me.panel1.Location = New System.Drawing.Point(0, 0)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(250, 524)
            Me.panel1.TabIndex = 2
            '
            'treeView1
            '
            Me.treeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.treeView1.HideSelection = False
            Me.treeView1.Location = New System.Drawing.Point(8, 12)
            Me.treeView1.Name = "treeView1"
            Me.treeView1.Size = New System.Drawing.Size(230, 470)
            Me.treeView1.TabIndex = 0
            '
            'PagesContainerPanel
            '
            Me.PagesContainerPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PagesContainerPanel.Location = New System.Drawing.Point(3, 12)
            Me.PagesContainerPanel.Name = "PagesContainerPanel"
            Me.PagesContainerPanel.Size = New System.Drawing.Size(920, 465)
            Me.PagesContainerPanel.TabIndex = 0
            '
            'panel2
            '
            Me.panel2.Controls.Add(Me.PagesContainerPanel)
            Me.panel2.Controls.Add(Me.panel4)
            Me.panel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.panel2.Location = New System.Drawing.Point(250, 0)
            Me.panel2.Name = "panel2"
            Me.panel2.Size = New System.Drawing.Size(934, 524)
            Me.panel2.TabIndex = 3
            '
            'panel4
            '
            Me.panel4.Controls.Add(Me.ApplyChangesButton)
            Me.panel4.Controls.Add(Me.groupBox1)
            Me.panel4.Controls.Add(Me.OKButton)
            Me.panel4.Controls.Add(Me.CancelChangesButton)
            Me.panel4.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.panel4.Location = New System.Drawing.Point(0, 482)
            Me.panel4.Name = "panel4"
            Me.panel4.Size = New System.Drawing.Size(934, 42)
            Me.panel4.TabIndex = 1
            '
            'ApplyChangesButton
            '
            Me.ApplyChangesButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ApplyChangesButton.Location = New System.Drawing.Point(848, 10)
            Me.ApplyChangesButton.Name = "ApplyChangesButton"
            Me.ApplyChangesButton.Size = New System.Drawing.Size(75, 23)
            Me.ApplyChangesButton.TabIndex = 11
            Me.ApplyChangesButton.Text = "Apply"
            Me.ApplyChangesButton.UseVisualStyleBackColor = True
            '
            'groupBox1
            '
            Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
            Me.groupBox1.Location = New System.Drawing.Point(0, 0)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(934, 2)
            Me.groupBox1.TabIndex = 10
            Me.groupBox1.TabStop = False
            '
            'OKButton
            '
            Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.OKButton.Location = New System.Drawing.Point(688, 10)
            Me.OKButton.Name = "OKButton"
            Me.OKButton.Size = New System.Drawing.Size(75, 23)
            Me.OKButton.TabIndex = 8
            Me.OKButton.Text = "OK"
            Me.OKButton.UseVisualStyleBackColor = True
            '
            'CancelChangesButton
            '
            Me.CancelChangesButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CancelChangesButton.CausesValidation = False
            Me.CancelChangesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.CancelChangesButton.Location = New System.Drawing.Point(768, 10)
            Me.CancelChangesButton.Name = "CancelChangesButton"
            Me.CancelChangesButton.Size = New System.Drawing.Size(75, 23)
            Me.CancelChangesButton.TabIndex = 7
            Me.CancelChangesButton.Text = "Cancel"
            Me.CancelChangesButton.UseVisualStyleBackColor = True
            '
            'ServerSettingsDialog
            '
            Me.AcceptButton = Me.OKButton
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
            Me.CancelButton = Me.CancelChangesButton
            Me.ClientSize = New System.Drawing.Size(1184, 524)
            Me.Controls.Add(Me.panel2)
            Me.Controls.Add(Me.panel1)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ServerSettingsDialog"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Server Settings Dialog"
            Me.panel1.ResumeLayout(False)
            Me.panel2.ResumeLayout(False)
            Me.panel4.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private panel1 As System.Windows.Forms.Panel
      Private treeView1 As System.Windows.Forms.TreeView
      Private PagesContainerPanel As System.Windows.Forms.Panel
      Private panel2 As System.Windows.Forms.Panel
      Private panel4 As System.Windows.Forms.Panel
      Private OKButton As System.Windows.Forms.Button
      Private CancelChangesButton As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private ApplyChangesButton As System.Windows.Forms.Button
   End Class
End Namespace