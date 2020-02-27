
#If LEADTOOLS_V20_OR_LATER Then
Namespace MainDemo
	Partial Public Class WienerFilterDialog
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(WienerFilterDialog))
			Me._btnApply = New System.Windows.Forms.Button()
			Me._btnOK = New System.Windows.Forms.Button()
			Me._btnReset = New System.Windows.Forms.Button()
			Me._btnCancel = New System.Windows.Forms.Button()
			Me.labelP1 = New System.Windows.Forms.Label()
			Me.labelP2 = New System.Windows.Forms.Label()
			Me._gbPolygonPoints = New System.Windows.Forms.GroupBox()
			Me._cbP3 = New System.Windows.Forms.ComboBox()
			Me.labelP3 = New System.Windows.Forms.Label()
			Me._numSecondP = New System.Windows.Forms.TextBox()
			Me._numFirstP = New System.Windows.Forms.TextBox()
			Me._numNSR = New System.Windows.Forms.TextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me._gbPolygonPoints.SuspendLayout()
			Me.SuspendLayout()
			' 
			' _btnApply
			' 
			resources.ApplyResources(Me._btnApply, "_btnApply")
			Me._btnApply.Name = "_btnApply"
			Me._btnApply.UseVisualStyleBackColor = True
			' 
			' _btnOK
			' 
			Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
			resources.ApplyResources(Me._btnOK, "_btnOK")
			Me._btnOK.Name = "_btnOK"
			Me._btnOK.UseVisualStyleBackColor = True
			' 
			' _btnReset
			' 
			resources.ApplyResources(Me._btnReset, "_btnReset")
			Me._btnReset.Name = "_btnReset"
			Me._btnReset.UseVisualStyleBackColor = True
			' 
			' _btnCancel
			' 
			resources.ApplyResources(Me._btnCancel, "_btnCancel")
			Me._btnCancel.Name = "_btnCancel"
			Me._btnCancel.UseVisualStyleBackColor = True
			' 
			' labelP1
			' 
			resources.ApplyResources(Me.labelP1, "labelP1")
			Me.labelP1.Name = "labelP1"
			' 
			' labelP2
			' 
			resources.ApplyResources(Me.labelP2, "labelP2")
			Me.labelP2.Name = "labelP2"
			' 
			' _gbPolygonPoints
			' 
			Me._gbPolygonPoints.Controls.Add(Me._cbP3)
			Me._gbPolygonPoints.Controls.Add(Me.labelP3)
			Me._gbPolygonPoints.Controls.Add(Me._numSecondP)
			Me._gbPolygonPoints.Controls.Add(Me._numFirstP)
			Me._gbPolygonPoints.Controls.Add(Me.labelP1)
			Me._gbPolygonPoints.Controls.Add(Me.labelP2)
			resources.ApplyResources(Me._gbPolygonPoints, "_gbPolygonPoints")
			Me._gbPolygonPoints.Name = "_gbPolygonPoints"
			Me._gbPolygonPoints.TabStop = False
			' 
			' _cbP3
			' 
			Me._cbP3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			resources.ApplyResources(Me._cbP3, "_cbP3")
			Me._cbP3.Name = "_cbP3"
			' 
			' labelP3
			' 
			resources.ApplyResources(Me.labelP3, "labelP3")
			Me.labelP3.Name = "labelP3"
			' 
			' _numSecondP
			' 
			resources.ApplyResources(Me._numSecondP, "_numSecondP")
			Me._numSecondP.Name = "_numSecondP"
			' 
			' _numFirstP
			' 
			resources.ApplyResources(Me._numFirstP, "_numFirstP")
			Me._numFirstP.Name = "_numFirstP"
			' 
			' _numNSR
			' 
			resources.ApplyResources(Me._numNSR, "_numNSR")
			Me._numNSR.Name = "_numNSR"
			' 
			' label4
			' 
			resources.ApplyResources(Me.label4, "label4")
			Me.label4.Name = "label4"
			' 
			' WienerFilterDialog
			' 
			resources.ApplyResources(Me, "$this")
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me._numNSR)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me._gbPolygonPoints)
			Me.Controls.Add(Me._btnCancel)
			Me.Controls.Add(Me._btnReset)
			Me.Controls.Add(Me._btnOK)
			Me.Controls.Add(Me._btnApply)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "WienerFilterDialog"
			Me.TopMost = True
			Me._gbPolygonPoints.ResumeLayout(False)
			Me._gbPolygonPoints.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

      Private WithEvents _btnApply As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private WithEvents _btnReset As System.Windows.Forms.Button
      Private WithEvents _btnCancel As System.Windows.Forms.Button
		Private labelP1 As System.Windows.Forms.Label
		Private labelP2 As System.Windows.Forms.Label
		Private _gbPolygonPoints As System.Windows.Forms.GroupBox
		Private _numSecondP As System.Windows.Forms.TextBox
		Private _numFirstP As System.Windows.Forms.TextBox
		Private _numNSR As System.Windows.Forms.TextBox
		Private label4 As System.Windows.Forms.Label
      Private WithEvents _cbP3 As System.Windows.Forms.ComboBox
		Private labelP3 As System.Windows.Forms.Label
	End Class
End Namespace
#End If '#if LEADTOOLS_V20_OR_LATER