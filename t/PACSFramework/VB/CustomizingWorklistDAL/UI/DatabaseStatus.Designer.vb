Namespace VBCustomizingWorklistDAL.UI
   Partial Class DatabaseStatus
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

#Region "Component Designer generated code"

      ''' <summary> 
      ''' Required method for Designer support - do not modify 
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me.label1 = New System.Windows.Forms.Label()
         Me.ConnectionStringTextBox = New System.Windows.Forms.TextBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me.ProviderTextBox = New System.Windows.Forms.TextBox()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(5, 7)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(94, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Connection String:"
         ' 
         ' ConnectionStringTextBox
         ' 
         Me.ConnectionStringTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.ConnectionStringTextBox.Location = New System.Drawing.Point(105, 4)
         Me.ConnectionStringTextBox.Name = "ConnectionStringTextBox"
         Me.ConnectionStringTextBox.ReadOnly = True
         Me.ConnectionStringTextBox.Size = New System.Drawing.Size(313, 20)
         Me.ConnectionStringTextBox.TabIndex = 1
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(5, 33)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(49, 13)
         Me.label2.TabIndex = 2
         Me.label2.Text = "Provider:"
         ' 
         ' ProviderTextBox
         ' 
         Me.ProviderTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.ProviderTextBox.Location = New System.Drawing.Point(105, 30)
         Me.ProviderTextBox.Name = "ProviderTextBox"
         Me.ProviderTextBox.ReadOnly = True
         Me.ProviderTextBox.Size = New System.Drawing.Size(313, 20)
         Me.ProviderTextBox.TabIndex = 3
         ' 
         ' DatabaseStatus
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.ProviderTextBox)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.ConnectionStringTextBox)
         Me.Controls.Add(Me.label1)
         Me.Name = "DatabaseStatus"
         Me.Size = New System.Drawing.Size(426, 52)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private label1 As System.Windows.Forms.Label
      Private ConnectionStringTextBox As System.Windows.Forms.TextBox
      Private label2 As System.Windows.Forms.Label
      Private ProviderTextBox As System.Windows.Forms.TextBox
   End Class
End Namespace
