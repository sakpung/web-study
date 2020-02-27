Imports Microsoft.VisualBasic
Imports System
Namespace PrintToPACSDemo
   Public Partial Class CapabilitiesListValuesForm
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
		 Me.label1 = New System.Windows.Forms.Label()
		 Me._tbPropertyName = New System.Windows.Forms.TextBox()
		 Me._btnClose = New System.Windows.Forms.Button()
		 Me._lblValues = New System.Windows.Forms.Label()
		 Me._lbValues = New System.Windows.Forms.ListBox()
		 Me.SuspendLayout()
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(12, 15)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(77, 13)
		 Me.label1.TabIndex = 0
		 Me.label1.Text = "Property Name"
		 ' 
		 ' _tbPropertyName
		 ' 
		 Me._tbPropertyName.Location = New System.Drawing.Point(118, 12)
		 Me._tbPropertyName.Name = "_tbPropertyName"
		 Me._tbPropertyName.ReadOnly = True
		 Me._tbPropertyName.Size = New System.Drawing.Size(217, 20)
		 Me._tbPropertyName.TabIndex = 1
		 ' 
		 ' _btnClose
		 ' 
		 Me._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnClose.Location = New System.Drawing.Point(260, 194)
		 Me._btnClose.Name = "_btnClose"
		 Me._btnClose.Size = New System.Drawing.Size(75, 23)
		 Me._btnClose.TabIndex = 4
		 Me._btnClose.Text = "&Close"
		 Me._btnClose.UseVisualStyleBackColor = True
		 ' 
		 ' _lblValues
		 ' 
		 Me._lblValues.AutoSize = True
		 Me._lblValues.Location = New System.Drawing.Point(12, 45)
		 Me._lblValues.Name = "_lblValues"
		 Me._lblValues.Size = New System.Drawing.Size(58, 13)
		 Me._lblValues.TabIndex = 2
		 Me._lblValues.Text = "List Values"
		 ' 
		 ' _lbValues
		 ' 
		 Me._lbValues.FormattingEnabled = True
		 Me._lbValues.Location = New System.Drawing.Point(12, 61)
		 Me._lbValues.Name = "_lbValues"
		 Me._lbValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
		 Me._lbValues.Size = New System.Drawing.Size(323, 121)
		 Me._lbValues.TabIndex = 3
		 ' 
		 ' CapabilitiesListValuesForm
		 ' 
		 Me.AcceptButton = Me._btnClose
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnClose
		 Me.ClientSize = New System.Drawing.Size(347, 229)
		 Me.Controls.Add(Me._lbValues)
		 Me.Controls.Add(Me._lblValues)
		 Me.Controls.Add(Me._btnClose)
		 Me.Controls.Add(Me._tbPropertyName)
		 Me.Controls.Add(Me.label1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		 Me.Name = "CapabilitiesListValuesForm"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
'		 Me.Load += New System.EventHandler(Me.CapabilitiesListValuesForm_Load);
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private label1 As System.Windows.Forms.Label
	  Private _tbPropertyName As System.Windows.Forms.TextBox
	  Private _btnClose As System.Windows.Forms.Button
	  Private _lblValues As System.Windows.Forms.Label
	  Private _lbValues As System.Windows.Forms.ListBox
   End Class
End Namespace