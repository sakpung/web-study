' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Pdf
Imports System

Namespace PDFFormsDemo
   Public MustInherit Class FormFieldControl
      Inherits Control
      Public Shared FormFieldsContextMenu As ContextMenuStrip = Nothing
      Public Shared FormFieldsToolTip As ToolTip = Nothing
      Public Shared MaxFontSize As Integer = 18

      Public Sub New()
         AddHandler Me.SizeChanged, AddressOf FormFieldControl_SizeChanged
         AddHandler Me.Invalidated, AddressOf FormFieldControl_Invalidated
      End Sub

      Private Sub FormFieldControl_SizeChanged(sender As Object, e As EventArgs)
         DoFontResize()

         Me.Invalidate()
      End Sub

      Private Sub FormFieldControl_Invalidated(sender As Object, e As InvalidateEventArgs)
         If _childControl IsNot Nothing Then
            _childControl.Refresh()
         End If
      End Sub

      Protected Sub SetChildControl(childControl As Control)
         _childControl = childControl
         _childControl.Dock = DockStyle.Fill

         Me.Controls.Add(_childControl)
      End Sub

      Public Overridable Sub InitControl(formField As PDFFormField)
         Me.PDFFormField = formField

         ' Set common form field controls properties
         Me._fieldName = formField.Name
         Me._alternateName = formField.AlternateName
         Me._optionalName = formField.OptionalName
         Me._mappingName = formField.MappingName
         Me._FillMode = formField.FillMode

         ' Set Form Field Control Bounds.
         PDFFormControlsPropertiesHelper.SetControlBounds(Me, formField.Bounds, DocResolution)

         ' Set Form Field Control Font size, family name, and color.
         PDFFormControlsPropertiesHelper.SetControlFont(Me, formField.FontName, formField.FontSize, formField.TextColor)

         ' Set Form Field Control Border width, color, and style.
         PDFFormControlsPropertiesHelper.SetControlBorder(Me, formField.BorderColor, formField.BorderWidth, formField.BorderStyle)

         ' Set Form Field Control Background brush.
         PDFFormControlsPropertiesHelper.SetControlBackground(Me, formField.FillColor, formField.FillMode)

         ' Set Form Field Control Visibility flag.
         PDFFormControlsPropertiesHelper.SetControlFlagsProperties(Me, formField.ViewFlags, formField.FieldFlags)

         ' Set Form Field Control Rotate Angle.
         Me.RotateAngle = formField.Rotation

         ' Set Form Field Control Tooltip.
         Me.SetToolTip(formField.AlternateName)

         ' Set Form Field Control Tooltip.
         Me.SetContextMenuStrip()
      End Sub

      Public Overridable Sub SetToolTip(toolTip As String)
         Me._alternateName = toolTip
      End Sub

      Public Overridable Sub SetContextMenuStrip()
         If FormFieldControl.FormFieldsContextMenu IsNot Nothing Then
            Me.ContextMenuStrip = FormFieldControl.FormFieldsContextMenu
            Me.Tag = Me
         End If
      End Sub


      Protected Function CalculateFontSize(text As String, multiLine As Boolean) As Single
         Dim fontSize As Single = _font.Size

         If Not _autoFontResize Then
            If Me.Height <> 0 AndAlso Me.FiedlBounds.Height <> 0 Then
               fontSize = fontSize * (CSng(Me.Height) / CSng(Me.FiedlBounds.Height))
            End If
         Else
            Dim stringSize As Size = TextRenderer.MeasureText(text, _font)
            Dim wRatio As Single = CSng(Me.Width) / CSng(stringSize.Width)
            Dim hRatio As Single = CSng(Me.Height) / CSng(stringSize.Height)

            Dim ratio As Single = If(multiLine, hRatio, Math.Min(hRatio, wRatio))

            If ratio <> 0 AndAlso Not Single.IsInfinity(ratio) AndAlso Not Single.IsNaN(ratio) Then
               fontSize = fontSize * ratio

               If fontSize > 24 Then
                  fontSize = 24
               End If
            End If
         End If

         Return fontSize
      End Function

      Public Overridable Sub UpdateFormField(formField As PDFFormField)
         ' Set Names Properties
         formField.Name = _fieldName
         formField.AlternateName = _alternateName

         ' Set View Flags Property
         formField.ViewFlags = 0
         If Not _isFieldVisible AndAlso Not _isFieldPrintable Then
            formField.ViewFlags = formField.ViewFlags Or PDFFormField.ViewFlagsHidden
         Else
            If _isFieldPrintable Then
               formField.ViewFlags = formField.ViewFlags Or PDFFormField.ViewFlagsPrint
            End If

            If Not _isFieldVisible Then
               formField.ViewFlags = formField.ViewFlags Or PDFFormField.ViewFlagsNoView
            End If
         End If

         If _isFieldLocked Then
            formField.ViewFlags = formField.ViewFlags Or PDFFormField.ViewFlagsLocked
         End If

         If Not _isFieldRotatable Then
            formField.ViewFlags = formField.ViewFlags Or PDFFormField.ViewFlagsNoRotate
         End If

         ' Set Rotation Properties
         formField.Rotation = _rotateAngle

         ' Set Border Properties
         Dim borderColor As Color = _borderColor
         formField.BorderColor = New RasterColor(borderColor.A, borderColor.R, borderColor.G, borderColor.B)
         formField.BorderWidth = _borderThickness
         formField.BorderStyle = CInt(_fieldBorderStyle)

         ' Set background Property
         Dim fillColor As Color = BackgroundColor
         formField.FillColor = New RasterColor(fillColor.A, fillColor.R, fillColor.G, fillColor.B)
         formField.FillMode = _FillMode

         ' Set font Properties
         Dim textColor As Color = Me.ForeColor
         formField.TextColor = New RasterColor(textColor.A, textColor.R, textColor.G, textColor.B)
         formField.FontSize = CInt(Me.Font.Size)
         formField.FontName = Me.Font.FontFamily.Name

         ' Set ReadOnly Property
         formField.FieldFlags = 0
         If Me.IsReadOnly Then
            formField.FieldFlags = formField.FieldFlags Or PDFFormField.FieldFlagsReadOnly
         End If

         Me.PDFFormField = formField
      End Sub

      Protected Overridable Sub DoFontResize()
         Dim fontSize As Single = CalculateFontSize("Mg", False)

         If Me.Font.Size <> fontSize Then
            _childControl.Font = New Font(_font.FontFamily, fontSize)
         End If
      End Sub

      Protected Overridable Sub OnPropertyChange()
         If _childControl IsNot Nothing Then
            _childControl.ForeColor = Me.ForeColor
            _childControl.BackColor = Me.BackColor

            CType(_childControl, IFormFieldControl).BackgroundColor = Me.BackgroundColor
            CType(_childControl, IFormFieldControl).BorderColor = Me.BorderColor
            CType(_childControl, IFormFieldControl).BorderThickness = Me.BorderThickness
            CType(_childControl, IFormFieldControl).FieldBorderStyle = Me.FieldBorderStyle
            CType(_childControl, IFormFieldControl).IsFieldVisible = Me.IsFieldVisible

            DoFontResize()
         End If

         Me.Invalidate()
      End Sub

#Region "Properties"

#Region "ChildControl"

      Protected _childControl As Control
      Public ReadOnly Property ChildControl() As Control
         Get
            Return _childControl
         End Get
      End Property

#End Region

#Region "FieldName"

      Private _fieldName As String = ""
      Public Property FieldName() As String
         Get
            Return _fieldName
         End Get
         Set(value As String)
            _fieldName = value
         End Set
      End Property

#End Region

#Region "AlternateName"

      Private _alternateName As String = ""
      Public ReadOnly Property AlternateName() As String
         Get
            Return _alternateName
         End Get
      End Property

#End Region

#Region "OptionalName"

      Private _optionalName As String = ""
      Public ReadOnly Property OptionalName() As String
         Get
            Return _optionalName
         End Get
      End Property

#End Region

#Region "MappingName"

      Private _mappingName As String = ""
      Public ReadOnly Property MappingName() As String
         Get
            Return _mappingName
         End Get
      End Property

#End Region

#Region "FiedlBounds"

      Protected _fiedlBounds As LeadRect = LeadRect.Empty
      Public Overridable Property FiedlBounds() As LeadRect
         Get
            Return _fiedlBounds
         End Get
         Set(value As LeadRect)
            If _fiedlBounds <> value Then
               _fiedlBounds = value

               Me.Left = value.Left
               Me.Top = value.Top
               Me.Width = value.Width
               Me.Height = value.Height

               OnPropertyChange()
            End If
         End Set
      End Property

#End Region

#Region "DocResolution"

      Public Property DocResolution() As Integer
         Get
            Return m_DocResolution
         End Get
         Set(value As Integer)
            m_DocResolution = value
         End Set
      End Property
      Private m_DocResolution As Integer

#End Region

#Region "IsFieldVisible"

      Private _isFieldVisible As Boolean = True
      Public Property IsFieldVisible() As Boolean
         Get
            Return _isFieldVisible
         End Get
         Set(value As Boolean)
            If _isFieldVisible <> value Then
               _isFieldVisible = value
               OnPropertyChange()
            End If
         End Set
      End Property

#End Region

#Region "IsFieldPrintable"

      Private _isFieldPrintable As Boolean = True
      Public Property IsFieldPrintable() As Boolean
         Get
            Return _isFieldPrintable
         End Get
         Set(value As Boolean)
            _isFieldPrintable = value
         End Set
      End Property

#End Region

#Region "IsFieldLocked"

      Private _isFieldLocked As Boolean = True
      Public Property IsFieldLocked() As Boolean
         Get
            Return _isFieldLocked
         End Get
         Set(value As Boolean)
            _isFieldLocked = value
         End Set
      End Property

#End Region

#Region "IsReadOnly"

      Protected _isReadOnly As Boolean = True
      Public Property IsReadOnly() As Boolean
         Get
            Return _isReadOnly
         End Get
         Set(value As Boolean)
            _isReadOnly = value
            OnPropertyChange()
         End Set
      End Property

#End Region

#Region "IsFieldRotatable"

      Private _isFieldRotatable As Boolean = True
      Public Property IsFieldRotatable() As Boolean
         Get
            Return _isFieldRotatable
         End Get
         Set(value As Boolean)
            _isFieldRotatable = value
         End Set
      End Property

#End Region

#Region "RotateAngle"

      Private _rotateAngle As Integer = 0
      Public Property RotateAngle() As Integer
         Get
            Return _rotateAngle
         End Get
         Set(value As Integer)
            If _rotateAngle <> value Then
               _rotateAngle = value
               OnPropertyChange()
            End If
         End Set
      End Property

#End Region

#Region "Font"

      Protected _font As New Font("Arial", FormFieldControl.MaxFontSize)
      Public Overrides Property Font() As Font
         Get
            Return _font
         End Get
         Set(value As Font)
            If _font IsNot value Then
               _font = value
               OnPropertyChange()
            End If
         End Set
      End Property

#End Region

#Region "AutoFontResize"

      Protected _autoFontResize As Boolean = False
      Public Property AutoFontResize() As Boolean
         Get
            Return _autoFontResize
         End Get
         Set(value As Boolean)
            If _autoFontResize <> value Then
               _autoFontResize = value
               OnPropertyChange()
            End If
         End Set
      End Property

#End Region

#Region "BackgroundColor"

      Protected _backgroundColor As Color = SystemColors.Control
      Public Property BackgroundColor() As Color
         Get
            Return _backgroundColor
         End Get
         Set(value As Color)
            If _backgroundColor <> value Then
               _backgroundColor = value
               OnPropertyChange()
            End If
         End Set
      End Property

#End Region

#Region "BorderColor"

      Protected _borderColor As Color = Color.Black
      Public Property BorderColor() As Color
         Get
            Return _borderColor
         End Get
         Set(value As Color)
            If _borderColor <> value Then
               _borderColor = value
               OnPropertyChange()
            End If
         End Set
      End Property

#End Region

#Region "BorderThickness"

      Protected _borderThickness As Integer = 1
      Public Property BorderThickness() As Integer
         Get
            Return _borderThickness
         End Get
         Set(value As Integer)
            If _borderThickness <> value Then
               _borderThickness = value
               OnPropertyChange()
            End If
         End Set
      End Property

#End Region

#Region "FieldBorderStyle"

      Protected _fieldBorderStyle As FieldBorderStyle = FieldBorderStyle.Solid
      Public Property FieldBorderStyle() As FieldBorderStyle
         Get
            Return _fieldBorderStyle
         End Get
         Set(value As FieldBorderStyle)
            If _fieldBorderStyle <> value Then
               _fieldBorderStyle = value
               OnPropertyChange()
            End If
         End Set
      End Property

#End Region

#Region "PDFFormField"

      Public Property PDFFormField() As PDFFormField
         Get
            Return m_PDFFormField
         End Get
         Set(value As PDFFormField)
            m_PDFFormField = value
         End Set
      End Property
      Private m_PDFFormField As PDFFormField

#End Region

#Region "ForeColor"

      Public Overrides Property ForeColor() As Color
         Get
            Return MyBase.ForeColor
         End Get
         Set(value As Color)
            MyBase.ForeColor = value
            OnPropertyChange()
         End Set
      End Property

#End Region

#Region "FillMode"

      Private _fillMode As Integer
      Public Property FillMode As Integer
         Get
            Return _fillMode
         End Get
         Set(value As Integer)
            _fillMode = value
         End Set
      End Property

#End Region

#End Region

      Public Shared Sub DrawBorder(graphics As Graphics, formFieldChild As IFormFieldControl, clientSize As Size, focus As Boolean)
         If formFieldChild Is Nothing OrElse Not formFieldChild.IsFieldVisible Then
            Return
         End If

         Dim borderRect As New Rectangle(0, 0, clientSize.Width, clientSize.Height)

         Dim innerRect As New Rectangle(formFieldChild.BorderThickness, formFieldChild.BorderThickness, clientSize.Width - (formFieldChild.BorderThickness * 2), clientSize.Height - (formFieldChild.BorderThickness * 2))

         Dim mainBoderStyle As ButtonBorderStyle = ButtonBorderStyle.Solid

         Dim innerBoderTopLeftStyle As ButtonBorderStyle = ButtonBorderStyle.Solid
         Dim innerBoderBottomRightStyle As ButtonBorderStyle = ButtonBorderStyle.Solid

         Dim innerBoderTopLeftColor As Color = Color.DarkGray
         Dim innerBoderBottomRightColor As Color = Color.LightGray

         Select Case formFieldChild.FieldBorderStyle
            Case FieldBorderStyle.Solid
               mainBoderStyle = ButtonBorderStyle.Solid
               innerBoderTopLeftStyle = ButtonBorderStyle.None
               innerBoderBottomRightStyle = ButtonBorderStyle.None
               Exit Select
            Case FieldBorderStyle.Dashed
               mainBoderStyle = ButtonBorderStyle.Dotted
               innerBoderTopLeftStyle = ButtonBorderStyle.None
               innerBoderBottomRightStyle = ButtonBorderStyle.None
               Exit Select
            Case FieldBorderStyle.Beveled
               mainBoderStyle = ButtonBorderStyle.Solid
               innerBoderTopLeftStyle = ButtonBorderStyle.Solid
               innerBoderBottomRightStyle = ButtonBorderStyle.Solid

               innerBoderTopLeftColor = Color.White
               innerBoderBottomRightColor = Color.FromArgb(formFieldChild.BackgroundColor.A, CInt(formFieldChild.BackgroundColor.R * 0.9), CInt(formFieldChild.BackgroundColor.G * 0.9), CInt(formFieldChild.BackgroundColor.B * 0.9))
               Exit Select
            Case FieldBorderStyle.Inset
               mainBoderStyle = ButtonBorderStyle.Solid
               innerBoderTopLeftStyle = ButtonBorderStyle.Solid
               innerBoderBottomRightStyle = ButtonBorderStyle.Inset
               Exit Select
            Case FieldBorderStyle.Underlined
               mainBoderStyle = ButtonBorderStyle.Solid
               innerBoderTopLeftStyle = ButtonBorderStyle.None
               innerBoderBottomRightStyle = ButtonBorderStyle.None
               Exit Select
         End Select

         'Left
         'Top
         'Right
         'Bottom
         ControlPaint.DrawBorder(graphics, borderRect, If(focus, formFieldChild.FocusedBorderColor, formFieldChild.BorderColor), formFieldChild.BorderThickness, mainBoderStyle, If(focus, formFieldChild.FocusedBorderColor, formFieldChild.BorderColor), _
          formFieldChild.BorderThickness, mainBoderStyle, If(focus, formFieldChild.FocusedBorderColor, formFieldChild.BorderColor), formFieldChild.BorderThickness, mainBoderStyle, If(focus, formFieldChild.FocusedBorderColor, formFieldChild.BorderColor), _
          formFieldChild.BorderThickness, mainBoderStyle)

         'Left
         'Top
         'Right
         'Bottom
         ControlPaint.DrawBorder(graphics, innerRect, innerBoderTopLeftColor, formFieldChild.BorderThickness, innerBoderTopLeftStyle, innerBoderTopLeftColor, _
          formFieldChild.BorderThickness, innerBoderTopLeftStyle, innerBoderBottomRightColor, formFieldChild.BorderThickness, innerBoderBottomRightStyle, innerBoderBottomRightColor, _
          formFieldChild.BorderThickness, innerBoderBottomRightStyle)
      End Sub
   End Class

   Public Enum FieldBorderStyle
      Solid
      Dashed
      Beveled
      Inset
      Underlined
   End Enum

   Public Interface IFormFieldControl
      Property BackgroundColor() As Color
      Property BorderColor() As Color
      Property BorderThickness() As Integer
      ReadOnly Property FocusedBorderColor() As Color
      Property FieldBorderStyle() As FieldBorderStyle
      Property IsFieldVisible() As Boolean
   End Interface

   Public Interface IFormFieldList
      Property Items() As List(Of String)
      Property SelectedIndex() As Integer
      Property SelectedIndices() As List(Of Integer)
      Property IsSorted() As Boolean
      Sub Sort()
   End Interface
End Namespace
