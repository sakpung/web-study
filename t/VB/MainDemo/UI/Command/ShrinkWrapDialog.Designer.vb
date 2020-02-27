Namespace MainDemo
   Partial Public Class ShrinkWrapDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShrinkWrapDialog))
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._gbParameters = New System.Windows.Forms.GroupBox()
         Me._cbCombine = New System.Windows.Forms.ComboBox()
         Me.label3 = New System.Windows.Forms.Label()
         Me._cbType = New System.Windows.Forms.ComboBox()
         Me._numThreshold = New System.Windows.Forms.NumericUpDown()
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me._btnApply = New System.Windows.Forms.Button()
         Me._gbParameters.SuspendLayout()
         CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnCancel
         ' 
         resources.ApplyResources(Me._btnCancel, "_btnCancel")
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _gbParameters
         ' 
         Me._gbParameters.Controls.Add(Me._cbCombine)
         Me._gbParameters.Controls.Add(Me.label3)
         Me._gbParameters.Controls.Add(Me._cbType)
         Me._gbParameters.Controls.Add(Me._numThreshold)
         Me._gbParameters.Controls.Add(Me.label1)
         Me._gbParameters.Controls.Add(Me.label2)
         resources.ApplyResources(Me._gbParameters, "_gbParameters")
         Me._gbParameters.Name = "_gbParameters"
         Me._gbParameters.TabStop = False
         ' 
         ' _cbCombine
         ' 
         Me._cbCombine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbCombine.FormattingEnabled = True
         Me._cbCombine.Items.AddRange(New Object() {resources.GetString("_cbCombine.Items"), resources.GetString("_cbCombine.Items1"), resources.GetString("_cbCombine.Items2"), resources.GetString("_cbCombine.Items3"), resources.GetString("_cbCombine.Items4"), resources.GetString("_cbCombine.Items5"), resources.GetString("_cbCombine.Items6")})
         resources.ApplyResources(Me._cbCombine, "_cbCombine")
         Me._cbCombine.Name = "_cbCombine"
         ' 
         ' label3
         ' 
         resources.ApplyResources(Me.label3, "label3")
         Me.label3.Name = "label3"
         ' 
         ' _cbType
         ' 
         Me._cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbType.FormattingEnabled = True
         Me._cbType.Items.AddRange(New Object() {resources.GetString("_cbType.Items"), resources.GetString("_cbType.Items1")})
         resources.ApplyResources(Me._cbType, "_cbType")
         Me._cbType.Name = "_cbType"
         ' 
         ' _numThreshold
         ' 
         resources.ApplyResources(Me._numThreshold, "_numThreshold")
         Me._numThreshold.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
         Me._numThreshold.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._numThreshold.Name = "_numThreshold"
         Me._numThreshold.Value = New Decimal(New Integer() {30, 0, 0, 0})
         ' 
         ' label1
         ' 
         resources.ApplyResources(Me.label1, "label1")
         Me.label1.Name = "label1"
         ' 
         ' label2
         ' 
         resources.ApplyResources(Me.label2, "label2")
         Me.label2.Name = "label2"
         ' 
         ' _btnApply
         ' 
         resources.ApplyResources(Me._btnApply, "_btnApply")
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' ShrinkWrapDialog
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._btnApply)
         Me.Controls.Add(Me._gbParameters)
         Me.Controls.Add(Me._btnCancel)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ShrinkWrapDialog"
         Me.ShowInTaskbar = False
         Me.TopMost = True
         Me._gbParameters.ResumeLayout(False)
         Me._gbParameters.PerformLayout()
         CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private _gbParameters As System.Windows.Forms.GroupBox
      Private _cbType As System.Windows.Forms.ComboBox
      Private _numThreshold As System.Windows.Forms.NumericUpDown
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private WithEvents _btnApply As System.Windows.Forms.Button
      Private _cbCombine As System.Windows.Forms.ComboBox
      Private label3 As System.Windows.Forms.Label
   End Class
End Namespace