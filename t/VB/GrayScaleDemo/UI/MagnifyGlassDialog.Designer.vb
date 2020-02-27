
Partial Class MagnifyGlassDialog
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
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MagnifyGlassDialog))
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbOptions = New System.Windows.Forms.GroupBox()
      Me._txtInterSectionColor = New System.Windows.Forms.TextBox()
      Me._txtBorderColor = New System.Windows.Forms.TextBox()
      Me._btnIntersectionColor = New System.Windows.Forms.Button()
      Me.label2 = New System.Windows.Forms.Label()
      Me._btnBorderColor = New System.Windows.Forms.Button()
      Me.label1 = New System.Windows.Forms.Label()
      Me._lblScaleFactor = New System.Windows.Forms.Label()
      Me._numScaleFactor = New System.Windows.Forms.NumericUpDown()
      Me._lblBorderSize = New System.Windows.Forms.Label()
      Me._numBorderSize = New System.Windows.Forms.NumericUpDown()
      Me._cmbShape = New System.Windows.Forms.ComboBox()
      Me._lblShape = New System.Windows.Forms.Label()
      Me._lblHeight = New System.Windows.Forms.Label()
      Me._lblWidth = New System.Windows.Forms.Label()
      Me._numHeight = New System.Windows.Forms.NumericUpDown()
      Me._numWidth = New System.Windows.Forms.NumericUpDown()
      Me._gbOptions.SuspendLayout()
      CType(Me._numScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numBorderSize, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      resources.ApplyResources(Me._btnCancel, "_btnCancel")
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      resources.ApplyResources(Me._btnOk, "_btnOk")
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me._txtInterSectionColor)
      Me._gbOptions.Controls.Add(Me._txtBorderColor)
      Me._gbOptions.Controls.Add(Me._btnIntersectionColor)
      Me._gbOptions.Controls.Add(Me.label2)
      Me._gbOptions.Controls.Add(Me._btnBorderColor)
      Me._gbOptions.Controls.Add(Me.label1)
      Me._gbOptions.Controls.Add(Me._lblScaleFactor)
      Me._gbOptions.Controls.Add(Me._numScaleFactor)
      Me._gbOptions.Controls.Add(Me._lblBorderSize)
      Me._gbOptions.Controls.Add(Me._numBorderSize)
      Me._gbOptions.Controls.Add(Me._cmbShape)
      Me._gbOptions.Controls.Add(Me._lblShape)
      Me._gbOptions.Controls.Add(Me._lblHeight)
      Me._gbOptions.Controls.Add(Me._lblWidth)
      Me._gbOptions.Controls.Add(Me._numHeight)
      Me._gbOptions.Controls.Add(Me._numWidth)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      resources.ApplyResources(Me._gbOptions, "_gbOptions")
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.TabStop = False
      ' 
      ' _txtInterSectionColor
      ' 
      resources.ApplyResources(Me._txtInterSectionColor, "_txtInterSectionColor")
      Me._txtInterSectionColor.Name = "_txtInterSectionColor"
      Me._txtInterSectionColor.[ReadOnly] = True
      ' 
      ' _txtBorderColor
      ' 
      resources.ApplyResources(Me._txtBorderColor, "_txtBorderColor")
      Me._txtBorderColor.Name = "_txtBorderColor"
      Me._txtBorderColor.[ReadOnly] = True
      ' 
      ' _btnIntersectionColor
      ' 
      resources.ApplyResources(Me._btnIntersectionColor, "_btnIntersectionColor")
      Me._btnIntersectionColor.Name = "_btnIntersectionColor"
      Me._btnIntersectionColor.UseVisualStyleBackColor = True
      ' 
      ' label2
      ' 
      resources.ApplyResources(Me.label2, "label2")
      Me.label2.Name = "label2"
      ' 
      ' _btnBorderColor
      ' 
      resources.ApplyResources(Me._btnBorderColor, "_btnBorderColor")
      Me._btnBorderColor.Name = "_btnBorderColor"
      Me._btnBorderColor.UseVisualStyleBackColor = True
      ' 
      ' label1
      ' 
      resources.ApplyResources(Me.label1, "label1")
      Me.label1.Name = "label1"
      ' 
      ' _lblScaleFactor
      ' 
      resources.ApplyResources(Me._lblScaleFactor, "_lblScaleFactor")
      Me._lblScaleFactor.Name = "_lblScaleFactor"
      ' 
      ' _numScaleFactor
      ' 
      resources.ApplyResources(Me._numScaleFactor, "_numScaleFactor")
      Me._numScaleFactor.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
      Me._numScaleFactor.Name = "_numScaleFactor"
      Me._numScaleFactor.Value = New Decimal(New Integer() {2, 0, 0, 0})
      ' 
      ' _lblBorderSize
      ' 
      resources.ApplyResources(Me._lblBorderSize, "_lblBorderSize")
      Me._lblBorderSize.Name = "_lblBorderSize"
      ' 
      ' _numBorderSize
      ' 
      resources.ApplyResources(Me._numBorderSize, "_numBorderSize")
      Me._numBorderSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numBorderSize.Name = "_numBorderSize"
      Me._numBorderSize.Value = New Decimal(New Integer() {2, 0, 0, 0})
      ' 
      ' _cmbShape
      ' 
      Me._cmbShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbShape.FormattingEnabled = True
      Me._cmbShape.Items.AddRange(New Object() {resources.GetString("_cmbShape.Items"), resources.GetString("_cmbShape.Items1"), resources.GetString("_cmbShape.Items2"), resources.GetString("_cmbShape.Items3")})
      resources.ApplyResources(Me._cmbShape, "_cmbShape")
      Me._cmbShape.Name = "_cmbShape"
      ' 
      ' _lblShape
      ' 
      Me._lblShape.FlatStyle = System.Windows.Forms.FlatStyle.System
      resources.ApplyResources(Me._lblShape, "_lblShape")
      Me._lblShape.Name = "_lblShape"
      ' 
      ' _lblHeight
      ' 
      resources.ApplyResources(Me._lblHeight, "_lblHeight")
      Me._lblHeight.Name = "_lblHeight"
      ' 
      ' _lblWidth
      ' 
      resources.ApplyResources(Me._lblWidth, "_lblWidth")
      Me._lblWidth.Name = "_lblWidth"
      ' 
      ' _numHeight
      ' 
      resources.ApplyResources(Me._numHeight, "_numHeight")
      Me._numHeight.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
      Me._numHeight.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
      Me._numHeight.Name = "_numHeight"
      Me._numHeight.Value = New Decimal(New Integer() {100, 0, 0, 0})
      ' 
      ' _numWidth
      ' 
      resources.ApplyResources(Me._numWidth, "_numWidth")
      Me._numWidth.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
      Me._numWidth.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
      Me._numWidth.Name = "_numWidth"
      Me._numWidth.Value = New Decimal(New Integer() {100, 0, 0, 0})
      ' 
      ' MagnifyGlassDialog
      ' 
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._gbOptions)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "MagnifyGlassDialog"
      Me._gbOptions.ResumeLayout(False)
      Me._gbOptions.PerformLayout()
      CType(Me._numScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numBorderSize, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _gbOptions As System.Windows.Forms.GroupBox
   Private _cmbShape As System.Windows.Forms.ComboBox
   Private _lblShape As System.Windows.Forms.Label
   Private _lblHeight As System.Windows.Forms.Label
   Private _lblWidth As System.Windows.Forms.Label
   Private _numHeight As System.Windows.Forms.NumericUpDown
   Private _numWidth As System.Windows.Forms.NumericUpDown
   Private _lblScaleFactor As System.Windows.Forms.Label
   Private _numScaleFactor As System.Windows.Forms.NumericUpDown
   Private _lblBorderSize As System.Windows.Forms.Label
   Private _numBorderSize As System.Windows.Forms.NumericUpDown
   Private WithEvents _btnIntersectionColor As System.Windows.Forms.Button
   Private label2 As System.Windows.Forms.Label
   Private WithEvents _btnBorderColor As System.Windows.Forms.Button
   Private label1 As System.Windows.Forms.Label
   Private _txtInterSectionColor As System.Windows.Forms.TextBox
   Private _txtBorderColor As System.Windows.Forms.TextBox
End Class