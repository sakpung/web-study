' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.ImageProcessing

Namespace MrcSegmentationDemo
   ''' <summary>
   ''' Summary description for ColorResolutionDialog.
   ''' </summary>
   Public Class ColorResolutionDialog : Inherits System.Windows.Forms.Form
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private _grbOptions As System.Windows.Forms.GroupBox
      Private _cbDither As System.Windows.Forms.ComboBox
      Private _lblDither As System.Windows.Forms.Label
      Private WithEvents _cbBitsPerPixel As System.Windows.Forms.ComboBox
      Private _lblBitsPerPixel As System.Windows.Forms.Label
      Private _cbOrder As System.Windows.Forms.ComboBox
      Private _lblOrder As System.Windows.Forms.Label
      Private _cbPalette As System.Windows.Forms.ComboBox
      Private _lblPalette As System.Windows.Forms.Label
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not components Is Nothing Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"
      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._grbOptions = New System.Windows.Forms.GroupBox()
         Me._cbOrder = New System.Windows.Forms.ComboBox()
         Me._lblOrder = New System.Windows.Forms.Label()
         Me._cbDither = New System.Windows.Forms.ComboBox()
         Me._lblDither = New System.Windows.Forms.Label()
         Me._cbPalette = New System.Windows.Forms.ComboBox()
         Me._lblPalette = New System.Windows.Forms.Label()
         Me._cbBitsPerPixel = New System.Windows.Forms.ComboBox()
         Me._lblBitsPerPixel = New System.Windows.Forms.Label()
         Me._grbOptions.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(344, 16)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.TabIndex = 1
         Me._btnOk.Text = "&OK"
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(344, 48)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "&Cancel"
         ' 
         ' _grbOptions
         ' 
         Me._grbOptions.Controls.Add(Me._cbOrder)
         Me._grbOptions.Controls.Add(Me._lblOrder)
         Me._grbOptions.Controls.Add(Me._cbDither)
         Me._grbOptions.Controls.Add(Me._lblDither)
         Me._grbOptions.Controls.Add(Me._cbPalette)
         Me._grbOptions.Controls.Add(Me._lblPalette)
         Me._grbOptions.Controls.Add(Me._cbBitsPerPixel)
         Me._grbOptions.Controls.Add(Me._lblBitsPerPixel)
         Me._grbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._grbOptions.Location = New System.Drawing.Point(8, 8)
         Me._grbOptions.Name = "_grbOptions"
         Me._grbOptions.Size = New System.Drawing.Size(320, 160)
         Me._grbOptions.TabIndex = 0
         Me._grbOptions.TabStop = False
         ' 
         ' _cbOrder
         ' 
         Me._cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbOrder.Location = New System.Drawing.Point(120, 56)
         Me._cbOrder.Name = "_cbOrder"
         Me._cbOrder.Size = New System.Drawing.Size(184, 21)
         Me._cbOrder.TabIndex = 3
         ' 
         ' _lblOrder
         ' 
         Me._lblOrder.Location = New System.Drawing.Point(16, 56)
         Me._lblOrder.Name = "_lblOrder"
         Me._lblOrder.Size = New System.Drawing.Size(96, 24)
         Me._lblOrder.TabIndex = 2
         Me._lblOrder.Text = "&Order:"
         Me._lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _cbDither
         ' 
         Me._cbDither.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbDither.Location = New System.Drawing.Point(120, 120)
         Me._cbDither.Name = "_cbDither"
         Me._cbDither.Size = New System.Drawing.Size(184, 21)
         Me._cbDither.TabIndex = 8
         ' 
         ' _lblDither
         ' 
         Me._lblDither.Location = New System.Drawing.Point(16, 120)
         Me._lblDither.Name = "_lblDither"
         Me._lblDither.Size = New System.Drawing.Size(96, 24)
         Me._lblDither.TabIndex = 7
         Me._lblDither.Text = "&Dither:"
         Me._lblDither.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _cbPalette
         ' 
         Me._cbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbPalette.ItemHeight = 13
         Me._cbPalette.Location = New System.Drawing.Point(120, 88)
         Me._cbPalette.Name = "_cbPalette"
         Me._cbPalette.Size = New System.Drawing.Size(184, 21)
         Me._cbPalette.TabIndex = 5
         ' 
         ' _lblPalette
         ' 
         Me._lblPalette.Location = New System.Drawing.Point(16, 88)
         Me._lblPalette.Name = "_lblPalette"
         Me._lblPalette.Size = New System.Drawing.Size(96, 24)
         Me._lblPalette.TabIndex = 4
         Me._lblPalette.Text = "&Palette:"
         Me._lblPalette.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _cbBitsPerPixel
         ' 
         Me._cbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbBitsPerPixel.Location = New System.Drawing.Point(120, 24)
         Me._cbBitsPerPixel.Name = "_cbBitsPerPixel"
         Me._cbBitsPerPixel.Size = New System.Drawing.Size(184, 21)
         Me._cbBitsPerPixel.TabIndex = 1
         ' 
         ' _lblBitsPerPixel
         ' 
         Me._lblBitsPerPixel.Location = New System.Drawing.Point(16, 24)
         Me._lblBitsPerPixel.Name = "_lblBitsPerPixel"
         Me._lblBitsPerPixel.Size = New System.Drawing.Size(96, 24)
         Me._lblBitsPerPixel.TabIndex = 0
         Me._lblBitsPerPixel.Text = "&Bits Per Pixel:"
         Me._lblBitsPerPixel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' ColorResolutionDialog
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(426, 176)
         Me.Controls.Add(Me._grbOptions)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ColorResolutionDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Color Resolution"
         Me._grbOptions.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Shared _initialBitsPerPixel As Integer = 24
      Private Shared _initialOrder As RasterByteOrder = RasterByteOrder.Bgr
      Private Shared _initialPaletteFlags As ColorResolutionCommandPaletteFlags = ColorResolutionCommandPaletteFlags.Optimized
      Private Shared _initialDitheringMethod As RasterDitheringMethod = RasterDitheringMethod.None

      Public BitsPerPixel As Integer = -1
      Public Order As RasterByteOrder
      Public PaletteFlags As ColorResolutionCommandPaletteFlags
      Public DitheringMethod As RasterDitheringMethod

      Private Enum MyPaletteType
         Fixed = ColorResolutionCommandPaletteFlags.Fixed
         Optimized = ColorResolutionCommandPaletteFlags.Optimized
         Identity = ColorResolutionCommandPaletteFlags.Identity
         Netscape = ColorResolutionCommandPaletteFlags.Netscape
      End Enum

      Private Sub ColorResolutionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If BitsPerPixel = -1 Then
            BitsPerPixel = _initialBitsPerPixel
         End If

         PaletteFlags = _initialPaletteFlags
         DitheringMethod = _initialDitheringMethod

         Dim bitsPerPixel_Renamed As Integer() = {1, 2, 3, 4, 5, 6, 7, 8, 12, 16, 24, 32, 48, 64}
         For Each i As Integer In bitsPerPixel_Renamed
            _cbBitsPerPixel.Items.Add(i)
            If BitsPerPixel = i Then
               _cbBitsPerPixel.SelectedItem = i
            End If
         Next i

         Dim a As Array = System.Enum.GetValues(GetType(MyPaletteType))
         For Each i As MyPaletteType In a
            _cbPalette.Items.Add(i)
            If CInt(PaletteFlags) = CInt(i) Then
               _cbPalette.SelectedItem = i
            End If
         Next i

         If _cbPalette.SelectedItem Is Nothing Then
            _cbPalette.SelectedIndex = 0
         End If

         Tools.FillComboBoxWithEnum(_cbDither, GetType(RasterDitheringMethod), DitheringMethod)

         UpdateMyControls()
      End Sub

      Private Sub UpdateMyControls()
         Dim bitsPerPixel_Renamed As Integer = CInt(_cbBitsPerPixel.SelectedItem)
         _cbPalette.Enabled = bitsPerPixel_Renamed <= 8
         _cbDither.Enabled = bitsPerPixel_Renamed <= 8

         If bitsPerPixel_Renamed <= 8 Then
            _cbOrder.Items.Clear()
            _cbOrder.Items.Add(Constants.GetNameFromValue(GetType(RasterByteOrder), RasterByteOrder.Rgb))
            _cbOrder.SelectedIndex = 0
            _cbOrder.Enabled = False

            If _cbPalette.Enabled Then
               Dim selectedPalette As MyPaletteType
               If Not _cbPalette.SelectedItem Is Nothing Then
                  selectedPalette = CType(_cbPalette.SelectedItem, MyPaletteType)
               Else
                  selectedPalette = MyPaletteType.Fixed
               End If

               _cbPalette.Items.Clear()

               Dim a As Array = System.Enum.GetValues(GetType(MyPaletteType))
               For Each i As MyPaletteType In a
                  If bitsPerPixel_Renamed = 8 OrElse i <> MyPaletteType.Netscape Then
                     _cbPalette.Items.Add(i)
                     If i = selectedPalette Then
                        _cbPalette.SelectedItem = i
                     End If
                  End If
               Next i

               If _cbPalette.SelectedItem Is Nothing Then
                  _cbPalette.SelectedIndex = 0
               End If
            End If
         ElseIf bitsPerPixel_Renamed = 12 Then
            _cbOrder.Items.Clear()
            _cbOrder.Items.Add(Constants.GetNameFromValue(GetType(RasterByteOrder), RasterByteOrder.Gray))
            _cbOrder.SelectedIndex = 0
            _cbOrder.Enabled = False
         ElseIf bitsPerPixel_Renamed = 16 Then
            _cbOrder.Items.Clear()
            Tools.FillComboBoxWithEnum(_cbOrder, GetType(RasterByteOrder), Order, New Object() {RasterByteOrder.Romm})
            If _cbOrder.SelectedItem Is Nothing Then
               _cbOrder.SelectedItem = RasterByteOrder.Bgr
            End If
            _cbOrder.Enabled = True
         Else
            _cbOrder.Items.Clear()
            Tools.FillComboBoxWithEnum(_cbOrder, GetType(RasterByteOrder), Order, New Object() {RasterByteOrder.Gray, RasterByteOrder.Romm})
            If _cbOrder.SelectedItem Is Nothing Then
               _cbOrder.SelectedItem = RasterByteOrder.Bgr
            End If
            _cbOrder.Enabled = True

         End If
      End Sub

      Private Sub _cbBitsPerPixel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbBitsPerPixel.SelectedIndexChanged
         UpdateMyControls()
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         BitsPerPixel = CInt(_cbBitsPerPixel.SelectedItem)
         Order = CType(Constants.GetValueFromName(GetType(RasterByteOrder), CStr(_cbOrder.SelectedItem), _initialOrder), RasterByteOrder)
         PaletteFlags = ColorResolutionCommandPaletteFlags.None
         Dim myPalette As MyPaletteType = CType(_cbPalette.SelectedItem, MyPaletteType)
         Select Case myPalette
            Case MyPaletteType.Fixed
               PaletteFlags = PaletteFlags Or ColorResolutionCommandPaletteFlags.Fixed
            Case MyPaletteType.Optimized
               PaletteFlags = PaletteFlags Or ColorResolutionCommandPaletteFlags.Optimized
            Case MyPaletteType.Identity
               PaletteFlags = PaletteFlags Or ColorResolutionCommandPaletteFlags.Identity
            Case MyPaletteType.Netscape
               PaletteFlags = PaletteFlags Or ColorResolutionCommandPaletteFlags.Netscape
         End Select

         DitheringMethod = CType(Constants.GetValueFromName(GetType(RasterDitheringMethod), CStr(_cbDither.SelectedItem), _initialDitheringMethod), RasterDitheringMethod)

         _initialBitsPerPixel = BitsPerPixel
         _initialOrder = Order
         _initialPaletteFlags = PaletteFlags
         _initialDitheringMethod = DitheringMethod
      End Sub
   End Class
End Namespace
