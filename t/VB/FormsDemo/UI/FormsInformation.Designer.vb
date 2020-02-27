
Namespace FormsDemo
   Partial Class FormsInformation
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
         Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FormsInformation))
         Me._lblAboutDemo = New System.Windows.Forms.Label()
         Me._lbllink = New System.Windows.Forms.LinkLabel()
         Me._btnOK = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' _lblAboutDemo
         ' 
         Me._lblAboutDemo.Location = New System.Drawing.Point(12, 26)
         Me._lblAboutDemo.Name = "_lblAboutDemo"
         Me._lblAboutDemo.Size = New System.Drawing.Size(420, 85)
         Me._lblAboutDemo.TabIndex = 0
         Me._lblAboutDemo.Text = resources.GetString("_lblAboutDemo.Text")
         ' 
         ' _lbllink
         ' 
         Me._lbllink.AutoSize = True
         Me._lbllink.Location = New System.Drawing.Point(135, 111)
         Me._lbllink.Name = "_lbllink"
         Me._lbllink.Size = New System.Drawing.Size(170, 13)
         Me._lbllink.TabIndex = 1
         Me._lbllink.TabStop = True
         Me._lbllink.Text = "Forms Recognition and Processing"
         ' 
         ' _btnOK
         ' 
         Me._btnOK.Location = New System.Drawing.Point(329, 143)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(100, 23)
         Me._btnOK.TabIndex = 0
         Me._btnOK.Text = "OK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' FormsInformation
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(441, 174)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me._lbllink)
         Me.Controls.Add(Me._lblAboutDemo)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
         Me.Icon = DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MaximizeBox = False
         Me.Name = "FormsInformation"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "Forms Information"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _lblAboutDemo As System.Windows.Forms.Label
      Private WithEvents _lbllink As System.Windows.Forms.LinkLabel
      Private WithEvents _btnOK As System.Windows.Forms.Button
   End Class
End Namespace