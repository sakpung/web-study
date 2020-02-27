Imports Microsoft.VisualBasic
Imports System

   Partial Public Class RequestsHandling
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
Me.label1 = New System.Windows.Forms.Label
Me.mtxtIpAddress = New System.Windows.Forms.MaskedTextBox
Me.btnAdd = New System.Windows.Forms.Button
Me.btnRemove = New System.Windows.Forms.Button
Me.lstAddresses = New System.Windows.Forms.ListBox
Me.btnOK = New System.Windows.Forms.Button
Me.btnCancel = New System.Windows.Forms.Button
Me.groupBox1 = New System.Windows.Forms.GroupBox
Me.SuspendLayout()
'
'label1
'
Me.label1.AutoSize = True
Me.label1.Location = New System.Drawing.Point(6, 8)
Me.label1.Name = "label1"
Me.label1.Size = New System.Drawing.Size(313, 17)
Me.label1.TabIndex = 0
Me.label1.Text = "Deny client requests with the following IP address:"
'
'mtxtIpAddress
'
Me.mtxtIpAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.mtxtIpAddress.Location = New System.Drawing.Point(6, 28)
Me.mtxtIpAddress.Name = "mtxtIpAddress"
Me.mtxtIpAddress.Size = New System.Drawing.Size(224, 24)
Me.mtxtIpAddress.TabIndex = 1
'
'btnAdd
'
Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnAdd.Location = New System.Drawing.Point(236, 28)
Me.btnAdd.Name = "btnAdd"
Me.btnAdd.Size = New System.Drawing.Size(80, 27)
Me.btnAdd.TabIndex = 2
Me.btnAdd.Text = "Add"
Me.btnAdd.UseVisualStyleBackColor = True
'
'btnRemove
'
Me.btnRemove.Location = New System.Drawing.Point(6, 72)
Me.btnRemove.Name = "btnRemove"
Me.btnRemove.Size = New System.Drawing.Size(80, 27)
Me.btnRemove.TabIndex = 3
Me.btnRemove.Text = "Remove"
Me.btnRemove.UseVisualStyleBackColor = True
'
'lstAddresses
'
Me.lstAddresses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.lstAddresses.FormattingEnabled = True
Me.lstAddresses.ItemHeight = 16
Me.lstAddresses.Location = New System.Drawing.Point(96, 72)
Me.lstAddresses.Name = "lstAddresses"
Me.lstAddresses.Size = New System.Drawing.Size(229, 148)
Me.lstAddresses.TabIndex = 4
'
'btnOK
'
Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
Me.btnOK.Location = New System.Drawing.Point(166, 240)
Me.btnOK.Name = "btnOK"
Me.btnOK.Size = New System.Drawing.Size(80, 27)
Me.btnOK.TabIndex = 5
Me.btnOK.Text = "OK"
Me.btnOK.UseVisualStyleBackColor = True
'
'btnCancel
'
Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
Me.btnCancel.Location = New System.Drawing.Point(247, 240)
Me.btnCancel.Name = "btnCancel"
Me.btnCancel.Size = New System.Drawing.Size(80, 27)
Me.btnCancel.TabIndex = 6
Me.btnCancel.Text = "Cancel"
Me.btnCancel.UseVisualStyleBackColor = True
'
'groupBox1
'
Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.groupBox1.Location = New System.Drawing.Point(-26, 230)
Me.groupBox1.Name = "groupBox1"
Me.groupBox1.Size = New System.Drawing.Size(371, 3)
Me.groupBox1.TabIndex = 7
Me.groupBox1.TabStop = False
'
'RequestsHandling
'
Me.AcceptButton = Me.btnOK
Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.CancelButton = Me.btnCancel
Me.ClientSize = New System.Drawing.Size(337, 274)
Me.Controls.Add(Me.groupBox1)
Me.Controls.Add(Me.btnCancel)
Me.Controls.Add(Me.btnOK)
Me.Controls.Add(Me.lstAddresses)
Me.Controls.Add(Me.btnRemove)
Me.Controls.Add(Me.btnAdd)
Me.Controls.Add(Me.mtxtIpAddress)
Me.Controls.Add(Me.label1)
Me.MinimizeBox = False
Me.Name = "RequestsHandling"
Me.ShowIcon = False
Me.ShowInTaskbar = False
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Requests Handling"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

      Private label1 As System.Windows.Forms.Label
      Private mtxtIpAddress As System.Windows.Forms.MaskedTextBox
      Private WithEvents btnAdd As System.Windows.Forms.Button
      Private WithEvents btnRemove As System.Windows.Forms.Button
      Private lstAddresses As System.Windows.Forms.ListBox
      Private WithEvents btnOK As System.Windows.Forms.Button
      Private btnCancel As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
   End Class
