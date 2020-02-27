Namespace MainDemo
   Partial Public Class TADAnisotropicDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TADAnisotropicDialog))
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.label4 = New System.Windows.Forms.Label()
         Me._numIterations = New System.Windows.Forms.NumericUpDown()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me._numLambda = New System.Windows.Forms.NumericUpDown()
         Me._numKappa = New System.Windows.Forms.NumericUpDown()
         Me._cbFlux = New System.Windows.Forms.ComboBox()
         Me.groupBox1.SuspendLayout()
         CType(Me._numIterations, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numLambda, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numKappa, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         resources.ApplyResources(Me._btnOK, "_btnOK")
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         resources.ApplyResources(Me._btnCancel, "_btnCancel")
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me.label4)
         Me.groupBox1.Controls.Add(Me._numIterations)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Controls.Add(Me._numLambda)
         Me.groupBox1.Controls.Add(Me._numKappa)
         Me.groupBox1.Controls.Add(Me._cbFlux)
         resources.ApplyResources(Me.groupBox1, "groupBox1")
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.TabStop = False
         ' 
         ' label4
         ' 
         resources.ApplyResources(Me.label4, "label4")
         Me.label4.Name = "label4"
         ' 
         ' _numIterations
         ' 
         resources.ApplyResources(Me._numIterations, "_numIterations")
         Me._numIterations.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
         Me._numIterations.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._numIterations.Name = "_numIterations"
         Me._numIterations.Value = New Decimal(New Integer() {10, 0, 0, 0})
         ' 
         ' label3
         ' 
         resources.ApplyResources(Me.label3, "label3")
         Me.label3.Name = "label3"
         ' 
         ' label2
         ' 
         resources.ApplyResources(Me.label2, "label2")
         Me.label2.Name = "label2"
         ' 
         ' label1
         ' 
         resources.ApplyResources(Me.label1, "label1")
         Me.label1.Name = "label1"
         ' 
         ' _numLambda
         ' 
         resources.ApplyResources(Me._numLambda, "_numLambda")
         Me._numLambda.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
         Me._numLambda.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._numLambda.Name = "_numLambda"
         Me._numLambda.Value = New Decimal(New Integer() {14, 0, 0, 0})
         ' 
         ' _numKappa
         ' 
         resources.ApplyResources(Me._numKappa, "_numKappa")
         Me._numKappa.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._numKappa.Name = "_numKappa"
         Me._numKappa.Value = New Decimal(New Integer() {30, 0, 0, 0})
         ' 
         ' _cbFlux
         ' 
         Me._cbFlux.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbFlux.FormattingEnabled = True
         Me._cbFlux.Items.AddRange(New Object() {resources.GetString("_cbFlux.Items"), resources.GetString("_cbFlux.Items1")})
         resources.ApplyResources(Me._cbFlux, "_cbFlux")
         Me._cbFlux.Name = "_cbFlux"
         ' 
         ' TADAnisotropicDialog
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "TADAnisotropicDialog"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         CType(Me._numIterations, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numLambda, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numKappa, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _btnOK As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label3 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label1 As System.Windows.Forms.Label
      Private _numLambda As System.Windows.Forms.NumericUpDown
      Private _numKappa As System.Windows.Forms.NumericUpDown
      Private _cbFlux As System.Windows.Forms.ComboBox
      Private label4 As System.Windows.Forms.Label
      Private _numIterations As System.Windows.Forms.NumericUpDown
   End Class
End Namespace