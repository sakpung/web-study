Imports Microsoft.VisualBasic
Imports System
Namespace PrintToPACSDemo
   Public Partial Class CapabilitiesRangeValuesForm
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
		 Me._btnClose = New System.Windows.Forms.Button()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me.label3 = New System.Windows.Forms.Label()
		 Me.label4 = New System.Windows.Forms.Label()
		 Me.label5 = New System.Windows.Forms.Label()
		 Me._tbPropertyName = New System.Windows.Forms.TextBox()
		 Me._tbMinimumValue = New System.Windows.Forms.TextBox()
		 Me._tbNominalValue = New System.Windows.Forms.TextBox()
		 Me._tbMaximumValue = New System.Windows.Forms.TextBox()
		 Me._tbIncrementValue = New System.Windows.Forms.TextBox()
		 Me.SuspendLayout()
		 ' 
		 ' _btnClose
		 ' 
		 Me._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnClose.Location = New System.Drawing.Point(260, 145)
		 Me._btnClose.Name = "_btnClose"
		 Me._btnClose.Size = New System.Drawing.Size(75, 23)
		 Me._btnClose.TabIndex = 10
		 Me._btnClose.Text = "&Close"
		 Me._btnClose.UseVisualStyleBackColor = True
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(12, 9)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(77, 13)
		 Me.label1.TabIndex = 0
		 Me.label1.Text = "Property Name"
		 ' 
		 ' label2
		 ' 
		 Me.label2.AutoSize = True
		 Me.label2.Location = New System.Drawing.Point(12, 35)
		 Me.label2.Name = "label2"
		 Me.label2.Size = New System.Drawing.Size(78, 13)
		 Me.label2.TabIndex = 2
		 Me.label2.Text = "Minimum Value"
		 ' 
		 ' label3
		 ' 
		 Me.label3.AutoSize = True
		 Me.label3.Location = New System.Drawing.Point(12, 61)
		 Me.label3.Name = "label3"
		 Me.label3.Size = New System.Drawing.Size(81, 13)
		 Me.label3.TabIndex = 4
		 Me.label3.Text = "Maximum Value"
		 ' 
		 ' label4
		 ' 
		 Me.label4.AutoSize = True
		 Me.label4.Location = New System.Drawing.Point(12, 87)
		 Me.label4.Name = "label4"
		 Me.label4.Size = New System.Drawing.Size(75, 13)
		 Me.label4.TabIndex = 6
		 Me.label4.Text = "Nominal Value"
		 ' 
		 ' label5
		 ' 
		 Me.label5.AutoSize = True
		 Me.label5.Location = New System.Drawing.Point(12, 113)
		 Me.label5.Name = "label5"
		 Me.label5.Size = New System.Drawing.Size(84, 13)
		 Me.label5.TabIndex = 8
		 Me.label5.Text = "Increment Value"
		 ' 
		 ' _tbPropertyName
		 ' 
		 Me._tbPropertyName.Location = New System.Drawing.Point(118, 6)
		 Me._tbPropertyName.Name = "_tbPropertyName"
		 Me._tbPropertyName.ReadOnly = True
		 Me._tbPropertyName.Size = New System.Drawing.Size(217, 20)
		 Me._tbPropertyName.TabIndex = 1
		 ' 
		 ' _tbMinimumValue
		 ' 
		 Me._tbMinimumValue.Location = New System.Drawing.Point(118, 32)
		 Me._tbMinimumValue.Name = "_tbMinimumValue"
		 Me._tbMinimumValue.ReadOnly = True
		 Me._tbMinimumValue.Size = New System.Drawing.Size(217, 20)
		 Me._tbMinimumValue.TabIndex = 3
		 ' 
		 ' _tbNominalValue
		 ' 
		 Me._tbNominalValue.Location = New System.Drawing.Point(118, 84)
		 Me._tbNominalValue.Name = "_tbNominalValue"
		 Me._tbNominalValue.ReadOnly = True
		 Me._tbNominalValue.Size = New System.Drawing.Size(217, 20)
		 Me._tbNominalValue.TabIndex = 7
		 ' 
		 ' _tbMaximumValue
		 ' 
		 Me._tbMaximumValue.Location = New System.Drawing.Point(118, 58)
		 Me._tbMaximumValue.Name = "_tbMaximumValue"
		 Me._tbMaximumValue.ReadOnly = True
		 Me._tbMaximumValue.Size = New System.Drawing.Size(217, 20)
		 Me._tbMaximumValue.TabIndex = 5
		 ' 
		 ' _tbIncrementValue
		 ' 
		 Me._tbIncrementValue.Location = New System.Drawing.Point(118, 110)
		 Me._tbIncrementValue.Name = "_tbIncrementValue"
		 Me._tbIncrementValue.ReadOnly = True
		 Me._tbIncrementValue.Size = New System.Drawing.Size(217, 20)
		 Me._tbIncrementValue.TabIndex = 9
		 ' 
		 ' CapabilitiesRangeValuesForm
		 ' 
		 Me.AcceptButton = Me._btnClose
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnClose
		 Me.ClientSize = New System.Drawing.Size(347, 180)
		 Me.Controls.Add(Me._tbIncrementValue)
		 Me.Controls.Add(Me._tbNominalValue)
		 Me.Controls.Add(Me._tbMaximumValue)
		 Me.Controls.Add(Me._tbMinimumValue)
		 Me.Controls.Add(Me._tbPropertyName)
		 Me.Controls.Add(Me.label5)
		 Me.Controls.Add(Me.label4)
		 Me.Controls.Add(Me.label3)
		 Me.Controls.Add(Me.label2)
		 Me.Controls.Add(Me.label1)
		 Me.Controls.Add(Me._btnClose)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		 Me.Name = "CapabilitiesRangeValuesForm"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "WIA Range Property Values"
'		 Me.Load += New System.EventHandler(Me.CapabilitiesRangeValuesForm_Load);
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _btnClose As System.Windows.Forms.Button
	  Private label1 As System.Windows.Forms.Label
	  Private label2 As System.Windows.Forms.Label
	  Private label3 As System.Windows.Forms.Label
	  Private label4 As System.Windows.Forms.Label
	  Private label5 As System.Windows.Forms.Label
	  Private _tbPropertyName As System.Windows.Forms.TextBox
	  Private _tbMinimumValue As System.Windows.Forms.TextBox
	  Private _tbNominalValue As System.Windows.Forms.TextBox
	  Private _tbMaximumValue As System.Windows.Forms.TextBox
	  Private _tbIncrementValue As System.Windows.Forms.TextBox
   End Class
End Namespace