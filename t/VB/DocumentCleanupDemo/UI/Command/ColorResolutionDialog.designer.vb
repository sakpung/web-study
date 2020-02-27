Imports Microsoft.VisualBasic
Imports System
Namespace DocumentCleanupDemo
   Public Partial Class ColorResolutionDialog
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
		  Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ColorResolutionDialog))
		  Me._btnOk = New System.Windows.Forms.Button()
		  Me._btnCancel = New System.Windows.Forms.Button()
		  Me._lblBitsPerPixel = New System.Windows.Forms.Label()
		  Me._lblDitherMethod = New System.Windows.Forms.Label()
		  Me._lblPalette = New System.Windows.Forms.Label()
		  Me._lblColorOrder = New System.Windows.Forms.Label()
		  Me._cmbBitsPerPixel = New System.Windows.Forms.ComboBox()
		  Me._cmbDitherMethod = New System.Windows.Forms.ComboBox()
		  Me._cmbPalette = New System.Windows.Forms.ComboBox()
		  Me._cmbColorOrder = New System.Windows.Forms.ComboBox()
		  Me.SuspendLayout()
		  ' 
		  ' _btnOk
		  ' 
		  Me._btnOk.Location = New System.Drawing.Point(279, 10)
		  Me._btnOk.Name = "_btnOk"
		  Me._btnOk.Size = New System.Drawing.Size(75, 23)
		  Me._btnOk.TabIndex = 0
		  Me._btnOk.Text = "OK"
		  Me._btnOk.UseVisualStyleBackColor = True
'		  Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		  ' 
		  ' _btnCancel
		  ' 
		  Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		  Me._btnCancel.Location = New System.Drawing.Point(279, 39)
		  Me._btnCancel.Name = "_btnCancel"
		  Me._btnCancel.Size = New System.Drawing.Size(75, 23)
		  Me._btnCancel.TabIndex = 1
		  Me._btnCancel.Text = "Cancel"
		  Me._btnCancel.UseVisualStyleBackColor = True
'		  Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
		  ' 
		  ' _lblBitsPerPixel
		  ' 
		  Me._lblBitsPerPixel.AutoSize = True
		  Me._lblBitsPerPixel.Location = New System.Drawing.Point(18, 20)
		  Me._lblBitsPerPixel.Name = "_lblBitsPerPixel"
		  Me._lblBitsPerPixel.Size = New System.Drawing.Size(68, 13)
		  Me._lblBitsPerPixel.TabIndex = 2
		  Me._lblBitsPerPixel.Text = "Bits Per Pixel"
		  ' 
		  ' _lblDitherMethod
		  ' 
		  Me._lblDitherMethod.AutoSize = True
		  Me._lblDitherMethod.Location = New System.Drawing.Point(18, 48)
		  Me._lblDitherMethod.Name = "_lblDitherMethod"
		  Me._lblDitherMethod.Size = New System.Drawing.Size(74, 13)
		  Me._lblDitherMethod.TabIndex = 3
		  Me._lblDitherMethod.Text = "Dither Method"
		  ' 
		  ' _lblPalette
		  ' 
		  Me._lblPalette.AutoSize = True
		  Me._lblPalette.Location = New System.Drawing.Point(18, 74)
		  Me._lblPalette.Name = "_lblPalette"
		  Me._lblPalette.Size = New System.Drawing.Size(40, 13)
		  Me._lblPalette.TabIndex = 5
		  Me._lblPalette.Text = "Palette"
		  ' 
		  ' _lblColorOrder
		  ' 
		  Me._lblColorOrder.AutoSize = True
		  Me._lblColorOrder.Location = New System.Drawing.Point(18, 101)
		  Me._lblColorOrder.Name = "_lblColorOrder"
		  Me._lblColorOrder.Size = New System.Drawing.Size(60, 13)
		  Me._lblColorOrder.TabIndex = 4
		  Me._lblColorOrder.Text = "Color Order"
		  ' 
		  ' _cmbBitsPerPixel
		  ' 
		  Me._cmbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		  Me._cmbBitsPerPixel.FormattingEnabled = True
		  Me._cmbBitsPerPixel.Location = New System.Drawing.Point(92, 12)
		  Me._cmbBitsPerPixel.Name = "_cmbBitsPerPixel"
		  Me._cmbBitsPerPixel.Size = New System.Drawing.Size(181, 21)
		  Me._cmbBitsPerPixel.TabIndex = 6
		  ' 
		  ' _cmbDitherMethod
		  ' 
		  Me._cmbDitherMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		  Me._cmbDitherMethod.FormattingEnabled = True
		  Me._cmbDitherMethod.Location = New System.Drawing.Point(92, 39)
		  Me._cmbDitherMethod.Name = "_cmbDitherMethod"
		  Me._cmbDitherMethod.Size = New System.Drawing.Size(181, 21)
		  Me._cmbDitherMethod.TabIndex = 7
		  ' 
		  ' _cmbPalette
		  ' 
		  Me._cmbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		  Me._cmbPalette.FormattingEnabled = True
		  Me._cmbPalette.Location = New System.Drawing.Point(92, 66)
		  Me._cmbPalette.Name = "_cmbPalette"
		  Me._cmbPalette.Size = New System.Drawing.Size(181, 21)
		  Me._cmbPalette.TabIndex = 8
		  ' 
		  ' _cmbColorOrder
		  ' 
		  Me._cmbColorOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		  Me._cmbColorOrder.FormattingEnabled = True
		  Me._cmbColorOrder.Location = New System.Drawing.Point(92, 93)
		  Me._cmbColorOrder.Name = "_cmbColorOrder"
		  Me._cmbColorOrder.Size = New System.Drawing.Size(181, 21)
		  Me._cmbColorOrder.TabIndex = 9
		  ' 
		  ' ColorResolutionDialog
		  ' 
		  Me.AcceptButton = Me._btnOk
		  Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		  Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		  Me.CancelButton = Me._btnCancel
		  Me.ClientSize = New System.Drawing.Size(361, 124)
		  Me.Controls.Add(Me._cmbColorOrder)
		  Me.Controls.Add(Me._cmbPalette)
		  Me.Controls.Add(Me._cmbDitherMethod)
		  Me.Controls.Add(Me._cmbBitsPerPixel)
		  Me.Controls.Add(Me._lblPalette)
		  Me.Controls.Add(Me._lblColorOrder)
		  Me.Controls.Add(Me._lblDitherMethod)
		  Me.Controls.Add(Me._lblBitsPerPixel)
		  Me.Controls.Add(Me._btnCancel)
		  Me.Controls.Add(Me._btnOk)
		  Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		  Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		  Me.MaximizeBox = False
		  Me.MinimizeBox = False
		  Me.Name = "ColorResolutionDialog"
		  Me.Text = "Color Resolution"
		  Me.ResumeLayout(False)
		  Me.PerformLayout()

	  End Sub

	  #End Region

	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private _lblBitsPerPixel As System.Windows.Forms.Label
	  Private _lblDitherMethod As System.Windows.Forms.Label
	  Private _lblPalette As System.Windows.Forms.Label
	  Private _lblColorOrder As System.Windows.Forms.Label
	  Private _cmbBitsPerPixel As System.Windows.Forms.ComboBox
	  Private _cmbDitherMethod As System.Windows.Forms.ComboBox
	  Public _cmbPalette As System.Windows.Forms.ComboBox
	  Private _cmbColorOrder As System.Windows.Forms.ComboBox
   End Class
End Namespace