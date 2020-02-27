Namespace Leadtools.Demos.StorageServer
   Partial Public Class ServerNetworkingView
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
         Me.groupBox6 = New System.Windows.Forms.GroupBox()
         Me.NoDelayCheckBox = New System.Windows.Forms.CheckBox()
         Me.SendBufferNumericUpDown = New System.Windows.Forms.NumericUpDown()
         Me.label9 = New System.Windows.Forms.Label()
         Me.ReceiveBufferNumericUpDown = New System.Windows.Forms.NumericUpDown()
         Me.label8 = New System.Windows.Forms.Label()
         Me.PDUMaxLengthNumericUpDown = New System.Windows.Forms.NumericUpDown()
         Me.PDUMaxLengthCheckBox = New System.Windows.Forms.CheckBox()
         Me.groupBox6.SuspendLayout()
         CType(Me.SendBufferNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.ReceiveBufferNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.PDUMaxLengthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' groupBox6
         ' 
         Me.groupBox6.Controls.Add(Me.NoDelayCheckBox)
         Me.groupBox6.Controls.Add(Me.SendBufferNumericUpDown)
         Me.groupBox6.Controls.Add(Me.label9)
         Me.groupBox6.Controls.Add(Me.ReceiveBufferNumericUpDown)
         Me.groupBox6.Controls.Add(Me.label8)
         Me.groupBox6.Location = New System.Drawing.Point(8, 33)
         Me.groupBox6.Name = "groupBox6"
         Me.groupBox6.Size = New System.Drawing.Size(203, 109)
         Me.groupBox6.TabIndex = 5
         Me.groupBox6.TabStop = False
         Me.groupBox6.Text = "Socket Options:"
         ' 
         ' NoDelayCheckBox
         ' 
         Me.NoDelayCheckBox.AutoSize = True
         Me.NoDelayCheckBox.Location = New System.Drawing.Point(12, 81)
         Me.NoDelayCheckBox.Name = "NoDelayCheckBox"
         Me.NoDelayCheckBox.Size = New System.Drawing.Size(73, 17)
         Me.NoDelayCheckBox.TabIndex = 6
         Me.NoDelayCheckBox.Text = "No Delay:"
         Me.NoDelayCheckBox.UseVisualStyleBackColor = True
         ' 
         ' SendBufferNumericUpDown
         ' 
         Me.SendBufferNumericUpDown.Location = New System.Drawing.Point(112, 50)
         Me.SendBufferNumericUpDown.Maximum = New Decimal(New Integer() {1048576, 0, 0, 0})
         Me.SendBufferNumericUpDown.Name = "SendBufferNumericUpDown"
         Me.SendBufferNumericUpDown.Size = New System.Drawing.Size(86, 20)
         Me.SendBufferNumericUpDown.TabIndex = 5
         ' 
         ' label9
         ' 
         Me.label9.AutoSize = True
         Me.label9.Location = New System.Drawing.Point(9, 50)
         Me.label9.Name = "label9"
         Me.label9.Size = New System.Drawing.Size(66, 13)
         Me.label9.TabIndex = 4
         Me.label9.Text = "Send Buffer:"
         ' 
         ' ReceiveBufferNumericUpDown
         ' 
         Me.ReceiveBufferNumericUpDown.Location = New System.Drawing.Point(112, 24)
         Me.ReceiveBufferNumericUpDown.Maximum = New Decimal(New Integer() {1048576, 0, 0, 0})
         Me.ReceiveBufferNumericUpDown.Name = "ReceiveBufferNumericUpDown"
         Me.ReceiveBufferNumericUpDown.Size = New System.Drawing.Size(86, 20)
         Me.ReceiveBufferNumericUpDown.TabIndex = 3
         ' 
         ' label8
         ' 
         Me.label8.AutoSize = True
         Me.label8.Location = New System.Drawing.Point(9, 26)
         Me.label8.Name = "label8"
         Me.label8.Size = New System.Drawing.Size(81, 13)
         Me.label8.TabIndex = 2
         Me.label8.Text = "Receive Buffer:"
         ' 
         ' PDUMaxLengthNumericUpDown
         ' 
         Me.PDUMaxLengthNumericUpDown.Location = New System.Drawing.Point(126, 9)
         Me.PDUMaxLengthNumericUpDown.Maximum = New Decimal(New Integer() {1048576, 0, 0, 0})
         Me.PDUMaxLengthNumericUpDown.Name = "PDUMaxLengthNumericUpDown"
         Me.PDUMaxLengthNumericUpDown.Size = New System.Drawing.Size(80, 20)
         Me.PDUMaxLengthNumericUpDown.TabIndex = 4
         ' 
         ' PDUMaxLengthCheckBox
         ' 
         Me.PDUMaxLengthCheckBox.AutoSize = True
         Me.PDUMaxLengthCheckBox.Location = New System.Drawing.Point(8, 9)
         Me.PDUMaxLengthCheckBox.Name = "PDUMaxLengthCheckBox"
         Me.PDUMaxLengthCheckBox.Size = New System.Drawing.Size(111, 17)
         Me.PDUMaxLengthCheckBox.TabIndex = 3
         Me.PDUMaxLengthCheckBox.Text = "PDU Max Length:"
         Me.PDUMaxLengthCheckBox.UseVisualStyleBackColor = True
         ' 
         ' ServerNetworkingView
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.groupBox6)
         Me.Controls.Add(Me.PDUMaxLengthNumericUpDown)
         Me.Controls.Add(Me.PDUMaxLengthCheckBox)
         Me.Name = "ServerNetworkingView"
         Me.Size = New System.Drawing.Size(217, 148)
         Me.groupBox6.ResumeLayout(False)
         Me.groupBox6.PerformLayout()
         CType(Me.SendBufferNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.ReceiveBufferNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.PDUMaxLengthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private groupBox6 As System.Windows.Forms.GroupBox
      Private NoDelayCheckBox As System.Windows.Forms.CheckBox
      Private SendBufferNumericUpDown As System.Windows.Forms.NumericUpDown
      Private label9 As System.Windows.Forms.Label
      Private ReceiveBufferNumericUpDown As System.Windows.Forms.NumericUpDown
      Private label8 As System.Windows.Forms.Label
      Private PDUMaxLengthNumericUpDown As System.Windows.Forms.NumericUpDown
      Private PDUMaxLengthCheckBox As System.Windows.Forms.CheckBox
   End Class
End Namespace
