
Namespace CcowWebParticipantServiceHost
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
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me._txtAddress = New System.Windows.Forms.TextBox()
         Me._lblAddress = New System.Windows.Forms.Label()
         Me._btnClose = New System.Windows.Forms.Button()
         Me.groupBox2.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.Controls.Add(Me._txtAddress)
         Me.groupBox2.Controls.Add(Me._lblAddress)
         Me.groupBox2.Location = New System.Drawing.Point(12, 12)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(394, 69)
         Me.groupBox2.TabIndex = 8
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "Settings:"
         ' 
         ' _txtAddress
         ' 
         Me._txtAddress.Enabled = False
         Me._txtAddress.Location = New System.Drawing.Point(14, 35)
         Me._txtAddress.Name = "_txtAddress"
         Me._txtAddress.Size = New System.Drawing.Size(374, 20)
         Me._txtAddress.TabIndex = 12
         ' 
         ' _lblAddress
         ' 
         Me._lblAddress.AutoSize = True
         Me._lblAddress.Location = New System.Drawing.Point(11, 19)
         Me._lblAddress.Name = "_lblAddress"
         Me._lblAddress.Size = New System.Drawing.Size(57, 13)
         Me._lblAddress.TabIndex = 8
         Me._lblAddress.Text = "Participant"
         ' 
         ' _btnClose
         ' 
         Me._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnClose.Location = New System.Drawing.Point(331, 102)
         Me._btnClose.Name = "_btnClose"
         Me._btnClose.Size = New System.Drawing.Size(75, 23)
         Me._btnClose.TabIndex = 7
         Me._btnClose.Text = "&Close"
         Me._btnClose.UseVisualStyleBackColor = True
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(427, 137)
         Me.Controls.Add(Me.groupBox2)
         Me.Controls.Add(Me._btnClose)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MaximizeBox = False
         Me.Name = "MainForm"
         Me.Text = "LEADTOOLS CCOW Web Participant Service"
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private groupBox2 As System.Windows.Forms.GroupBox
      Private _txtAddress As System.Windows.Forms.TextBox
      Private _lblAddress As System.Windows.Forms.Label
      Private WithEvents _btnClose As System.Windows.Forms.Button
   End Class
End Namespace
