Imports System
Imports Microsoft.VisualBasic

Partial Class IntroDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IntroDialog))
      Me.rdbtnCreateNewTemplate = New System.Windows.Forms.RadioButton()
      Me.rdbtnLoadTemplate = New System.Windows.Forms.RadioButton()
      Me.rdbtnLoadWorkspace = New System.Windows.Forms.RadioButton()
      Me.grpTask = New System.Windows.Forms.GroupBox()
      Me.rdbtnLoadAutosave = New System.Windows.Forms.RadioButton()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.lblDescCreateNewTemplate = New System.Windows.Forms.Label()
      Me.lblDescLoadSavedTemplate = New System.Windows.Forms.Label()
      Me.lblDescLoadSavedWorkspace = New System.Windows.Forms.Label()
      Me.lblDescAutoRecover = New System.Windows.Forms.Label()
      Me.grpTask.SuspendLayout()
      Me.SuspendLayout()
      Me.rdbtnCreateNewTemplate.AutoSize = True
      Me.rdbtnCreateNewTemplate.Location = New System.Drawing.Point(6, 19)
      Me.rdbtnCreateNewTemplate.Name = "rdbtnCreateNewTemplate"
      Me.rdbtnCreateNewTemplate.Size = New System.Drawing.Size(128, 17)
      Me.rdbtnCreateNewTemplate.TabIndex = 0
      Me.rdbtnCreateNewTemplate.TabStop = True
      Me.rdbtnCreateNewTemplate.Text = "&Create New Template"
      Me.rdbtnCreateNewTemplate.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnCreateNewTemplate.CheckedChanged, AddressOf Me.rdbtnCreateNewTemplate_CheckedChanged
      Me.rdbtnLoadTemplate.AutoSize = True
      Me.rdbtnLoadTemplate.Location = New System.Drawing.Point(6, 83)
      Me.rdbtnLoadTemplate.Name = "rdbtnLoadTemplate"
      Me.rdbtnLoadTemplate.Size = New System.Drawing.Size(130, 17)
      Me.rdbtnLoadTemplate.TabIndex = 1
      Me.rdbtnLoadTemplate.TabStop = True
      Me.rdbtnLoadTemplate.Text = "Load Saved &Template"
      Me.rdbtnLoadTemplate.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnLoadTemplate.CheckedChanged, AddressOf Me.rdbtnLoadTemplate_CheckedChanged
      Me.rdbtnLoadWorkspace.AutoSize = True
      Me.rdbtnLoadWorkspace.Location = New System.Drawing.Point(6, 132)
      Me.rdbtnLoadWorkspace.Name = "rdbtnLoadWorkspace"
      Me.rdbtnLoadWorkspace.Size = New System.Drawing.Size(141, 17)
      Me.rdbtnLoadWorkspace.TabIndex = 2
      Me.rdbtnLoadWorkspace.TabStop = True
      Me.rdbtnLoadWorkspace.Text = "Load Saved &Workspace"
      Me.rdbtnLoadWorkspace.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnLoadWorkspace.CheckedChanged, AddressOf Me.rdbtnLoadWorkspace_CheckedChanged
      Me.grpTask.Controls.Add(Me.lblDescAutoRecover)
      Me.grpTask.Controls.Add(Me.lblDescLoadSavedWorkspace)
      Me.grpTask.Controls.Add(Me.lblDescLoadSavedTemplate)
      Me.grpTask.Controls.Add(Me.lblDescCreateNewTemplate)
      Me.grpTask.Controls.Add(Me.rdbtnLoadAutosave)
      Me.grpTask.Controls.Add(Me.rdbtnCreateNewTemplate)
      Me.grpTask.Controls.Add(Me.rdbtnLoadWorkspace)
      Me.grpTask.Controls.Add(Me.rdbtnLoadTemplate)
      Me.grpTask.Location = New System.Drawing.Point(12, 12)
      Me.grpTask.Name = "grpTask"
      Me.grpTask.Size = New System.Drawing.Size(401, 278)
      Me.grpTask.TabIndex = 3
      Me.grpTask.TabStop = False
      Me.grpTask.Text = "Choose a Task"
      Me.rdbtnLoadAutosave.AutoSize = True
      Me.rdbtnLoadAutosave.Location = New System.Drawing.Point(6, 207)
      Me.rdbtnLoadAutosave.Name = "rdbtnLoadAutosave"
      Me.rdbtnLoadAutosave.Size = New System.Drawing.Size(152, 17)
      Me.rdbtnLoadAutosave.TabIndex = 4
      Me.rdbtnLoadAutosave.TabStop = True
      Me.rdbtnLoadAutosave.Text = "Load &Recovered Template"
      Me.rdbtnLoadAutosave.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnLoadAutosave.CheckedChanged, AddressOf Me.rdbtnLoadAutosave_CheckedChanged
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(257, 296)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 4
      Me.btnOK.Text = "&OK"
      Me.btnOK.UseVisualStyleBackColor = True
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(338, 296)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 5
      Me.btnCancel.Text = "&Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      Me.lblDescCreateNewTemplate.AutoSize = True
      Me.lblDescCreateNewTemplate.Location = New System.Drawing.Point(68, 39)
      Me.lblDescCreateNewTemplate.Name = "lblDescCreateNewTemplate"
      Me.lblDescCreateNewTemplate.Size = New System.Drawing.Size(315, 39)
      Me.lblDescCreateNewTemplate.TabIndex = 5
      Me.lblDescCreateNewTemplate.Text = "Select to create a new template in the Template Editor from an" & Constants.vbLf & " existing image. " & " The next step will be choosing the existing image" & Constants.vbLf & " to use as a base for the te" & "mplate."
      Me.lblDescLoadSavedTemplate.AutoSize = True
      Me.lblDescLoadSavedTemplate.Location = New System.Drawing.Point(68, 103)
      Me.lblDescLoadSavedTemplate.Name = "lblDescLoadSavedTemplate"
      Me.lblDescLoadSavedTemplate.Size = New System.Drawing.Size(324, 26)
      Me.lblDescLoadSavedTemplate.TabIndex = 6
      Me.lblDescLoadSavedTemplate.Text = "Select to load a previously-saved template into the Template Editor." & Constants.vbLf & "The next st" & "ep will be choosing the template to load."
      Me.lblDescLoadSavedWorkspace.AutoSize = True
      Me.lblDescLoadSavedWorkspace.Location = New System.Drawing.Point(68, 152)
      Me.lblDescLoadSavedWorkspace.Name = "lblDescLoadSavedWorkspace"
      Me.lblDescLoadSavedWorkspace.Size = New System.Drawing.Size(324, 52)
      Me.lblDescLoadSavedWorkspace.TabIndex = 7
      Me.lblDescLoadSavedWorkspace.Text = resources.GetString("lblDescLoadSavedWorkspace.Text")
      Me.lblDescAutoRecover.AutoSize = True
      Me.lblDescAutoRecover.Location = New System.Drawing.Point(68, 227)
      Me.lblDescAutoRecover.Name = "lblDescAutoRecover"
      Me.lblDescAutoRecover.Size = New System.Drawing.Size(317, 39)
      Me.lblDescAutoRecover.TabIndex = 8
      Me.lblDescAutoRecover.Text = "The application did not shut down correctly.  The template in" & Constants.vbLf & "the template edito" & "r has been recovered.  Select this option to load" & Constants.vbLf & "the recovered template into t" & "he Template Editor."
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(422, 328)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.grpTask)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "IntroDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Welcome"
      AddHandler Me.FormClosed, AddressOf Me.IntroDialog_FormClosed
      Me.grpTask.ResumeLayout(False)
      Me.grpTask.PerformLayout()
      Me.ResumeLayout(False)
   End Sub

   Private rdbtnCreateNewTemplate As System.Windows.Forms.RadioButton
   Private rdbtnLoadTemplate As System.Windows.Forms.RadioButton
   Private rdbtnLoadWorkspace As System.Windows.Forms.RadioButton
   Private grpTask As System.Windows.Forms.GroupBox
   Private btnOK As System.Windows.Forms.Button
   Private btnCancel As System.Windows.Forms.Button
   Private rdbtnLoadAutosave As System.Windows.Forms.RadioButton
   Private lblDescAutoRecover As System.Windows.Forms.Label
   Private lblDescLoadSavedWorkspace As System.Windows.Forms.Label
   Private lblDescLoadSavedTemplate As System.Windows.Forms.Label
   Private lblDescCreateNewTemplate As System.Windows.Forms.Label
End Class
