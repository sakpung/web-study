
Namespace HL7Messaging
   Partial Class CreateMessageView
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
         Me.treeView1 = New System.Windows.Forms.TreeView()
         Me.button1 = New System.Windows.Forms.Button()
         Me.button2 = New System.Windows.Forms.Button()
         Me.comboBox1 = New System.Windows.Forms.ComboBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' treeView1
         ' 
         Me.treeView1.FullRowSelect = True
         Me.treeView1.Location = New System.Drawing.Point(5, 6)
         Me.treeView1.Name = "treeView1"
         Me.treeView1.Size = New System.Drawing.Size(388, 495)
         Me.treeView1.TabIndex = 3
         ' 
         ' button1
         ' 
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.button1.Location = New System.Drawing.Point(318, 508)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(75, 23)
         Me.button1.TabIndex = 4
         Me.button1.Text = "Clo&se"
         Me.button1.UseVisualStyleBackColor = True
         ' 
         ' button2
         ' 
         Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.button2.Location = New System.Drawing.Point(237, 508)
         Me.button2.Name = "button2"
         Me.button2.Size = New System.Drawing.Size(75, 23)
         Me.button2.TabIndex = 4
         Me.button2.Text = "&Create"
         Me.button2.UseVisualStyleBackColor = True
         ' 
         ' comboBox1
         ' 
         Me.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.comboBox1.FormattingEnabled = True
         Me.comboBox1.Location = New System.Drawing.Point(53, 510)
         Me.comboBox1.Name = "comboBox1"
         Me.comboBox1.Size = New System.Drawing.Size(121, 21)
         Me.comboBox1.TabIndex = 5
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(2, 513)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(45, 13)
         Me.label1.TabIndex = 6
         Me.label1.Text = "&Version:"
         ' 
         ' CreateMessageView
         ' 
         Me.AcceptButton = Me.button2
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me.button1
         Me.ClientSize = New System.Drawing.Size(399, 543)
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me.comboBox1)
         Me.Controls.Add(Me.button2)
         Me.Controls.Add(Me.button1)
         Me.Controls.Add(Me.treeView1)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "CreateMessageView"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         Me.Text = "Messages"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private treeView1 As System.Windows.Forms.TreeView
      Private WithEvents button1 As System.Windows.Forms.Button
      Private WithEvents button2 As System.Windows.Forms.Button
      Private WithEvents comboBox1 As System.Windows.Forms.ComboBox
      Private label1 As System.Windows.Forms.Label
   End Class
End Namespace

