' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Dicom.Scu.Common
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Drawing
Imports System.Windows.Forms.Design
Imports System.Windows.Forms
Imports System.Reflection

Namespace PrintToPACSDemo
   #Region "PropertyGridCheckBox"
   Friend Class EnumEditorUI : Inherits UserControl
	  #Region "GUI"
	  Private components As System.ComponentModel.IContainer = Nothing

	  Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
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
		 Me.chklstEnumValue = New System.Windows.Forms.CheckedListBox()
		 Me.SuspendLayout()
		 ' 
		 ' chklstEnumValue
		 ' 
		 Me.chklstEnumValue.CheckOnClick = True
		 Me.chklstEnumValue.Dock = System.Windows.Forms.DockStyle.Fill
		 Me.chklstEnumValue.FormattingEnabled = True
		 Me.chklstEnumValue.HorizontalScrollbar = True
		 Me.chklstEnumValue.IntegralHeight = False
		 Me.chklstEnumValue.Location = New System.Drawing.Point(0, 0)
		 Me.chklstEnumValue.Name = "chklstEnumValue"
		 Me.chklstEnumValue.Size = New System.Drawing.Size(220, 193)
		 Me.chklstEnumValue.TabIndex = 6
'		 Me.chklstEnumValue.ItemCheck += New System.Windows.Forms.ItemCheckEventHandler(Me.chklstEnumValue_ItemCheck);
		 ' 
		 ' EnumEditorUI
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.Controls.Add(Me.chklstEnumValue)
		 Me.Name = "EnumEditorUI"
		 Me.Size = New System.Drawing.Size(220, 193)
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private WithEvents chklstEnumValue As System.Windows.Forms.CheckedListBox
	  #End Region

	  Private m_editorService As IWindowsFormsEditorService = Nothing

	  Private m_bNoFire As Boolean = False

	  Public Sub New()
		 InitializeComponent()
	  End Sub

	  Public Sub SetData(ByVal context As ITypeDescriptorContext, ByVal editorService As IWindowsFormsEditorService, ByVal value As String)
		 m_editorService = editorService

		 chklstEnumValue.Visible = True

		 chklstEnumValue.Items.Clear()

		 Dim strList As List(Of String) = New List(Of String)()
		 strList.AddRange(Constans.ModalityValues)

		 m_bNoFire = True

		 For Each strItem As String In strList
			Dim sName As String = strItem

			chklstEnumValue.Items.Add(sName)
		 Next strItem

		 If value Is Nothing Then
			value = "All"
		 End If

		 Dim sDelimitedValues As String = value
		 Dim arrValue As String() = sDelimitedValues.Split(New Char() { ","c }, StringSplitOptions.RemoveEmptyEntries)
		 For Each sValue As String In arrValue
			Dim sTrimmedValue As String = sValue.Trim()

			Dim i As Integer = 0
			Do While i < chklstEnumValue.Items.Count
			   Dim Name As String = CStr(chklstEnumValue.Items(i)) 'objItem;
			   If String.Compare(Name, sTrimmedValue, True) = 0 Then
				  Dim chk As CheckedListBox = CType(chklstEnumValue, CheckedListBox)
				  chk.SetItemChecked(i, True)
				  chklstEnumValue.SetSelected(i, True)
				  Exit Do
			   End If
				i += 1
			Loop
		 Next sValue
		 m_bNoFire = False
	  End Sub

	  Public Function GetValue() As Object
		 Dim sb As StringBuilder = New StringBuilder(100)
		 For Each objItem As Object In chklstEnumValue.CheckedItems
			Dim data As String = CStr(objItem)
			If sb.Length > 0 Then
			   sb.Append(", ")
			End If
			sb.Append(data)
		 Next objItem

		 If sb.Length = 0 Then
			sb.Append("All")
		 End If

		 Return sb.ToString()
	  End Function

	  Private Sub chklstEnumValue_ItemCheck(ByVal sender As Object, ByVal e As ItemCheckEventArgs) Handles chklstEnumValue.ItemCheck
		 If m_bNoFire = True Then
			Return
		 End If

		 If e.NewValue = CheckState.Unchecked AndAlso chklstEnumValue.CheckedItems.Count = 1 AndAlso e.Index <> 0 Then
			chklstEnumValue.SetItemChecked(0, True)
			Return
		 End If

		 If e.NewValue = CheckState.Unchecked AndAlso e.Index = 0 AndAlso chklstEnumValue.CheckedItems.Count = 1 Then
			e.NewValue = CheckState.Checked
			Return
		 End If

		 If e.NewValue = CheckState.Checked AndAlso e.Index = 0 Then
			m_bNoFire = True

			Dim i As Integer = 1
			Do While i < chklstEnumValue.Items.Count
			   chklstEnumValue.SetItemChecked(i, False)
				i += 1
			Loop

			m_bNoFire = False
		 End If

		 If e.NewValue = CheckState.Checked AndAlso chklstEnumValue.CheckedItems.Contains(CObj("All")) Then
			m_bNoFire = True
			chklstEnumValue.SetItemChecked(0, False)
			m_bNoFire = False
		 End If
	  End Sub
   End Class

   Public Class EnumTypeEditor : Inherits UITypeEditor
	  Private m_ui As EnumEditorUI = New EnumEditorUI()
	  Public Sub New()

	  End Sub

	  Public Overrides Overloads Function GetPaintValueSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
		 Return False
	  End Function

	  Public Overrides Overloads Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As UITypeEditorEditStyle
		 Return UITypeEditorEditStyle.DropDown
	  End Function

	  Public Overrides ReadOnly Property IsDropDownResizable() As Boolean
		 Get
			Return True
		 End Get
	  End Property

	  Public Overrides Overloads Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
		 If Not provider Is Nothing Then
			Dim editorService As IWindowsFormsEditorService = TryCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
			If editorService Is Nothing Then
			   Return value
			End If

			m_ui.SetData(context, editorService, CStr(value))

			editorService.DropDownControl(m_ui)

			value = m_ui.GetValue()
		 End If
		 Return value
	  End Function
   End Class

   Public Class EnumTypeConverter : Inherits EnumConverter
	  Public Sub New(ByVal type As Type)
		  MyBase.New(type)
	  End Sub

	  Public Overrides Overloads Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
		 If sourceType Is GetType(String) Then
			Return True
		 End If
		 Return MyBase.CanConvertFrom(context, sourceType)
	  End Function

	  Public Overrides Overloads Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
		 Dim objEnumValue As Object = Nothing
		 objEnumValue = value

		 If objEnumValue Is Nothing Then
			objEnumValue = "All"
		 End If

		 If objEnumValue Is Nothing Then
			Throw New Exception("Null is not a valid enumeration value.")
		 End If

		 Return objEnumValue.ToString()
	  End Function
   End Class
   #End Region

   Public Class Constans
	  Public Shared ModalityValues As String() = New String() { "All", "CR", "CT", "MR", "NM", "US", "OT", "BI", "DG", "ES", "LS", "PT", "RG", "TG", "XA", "RF", "RTIMAGE", "RTDOSE", "RTSTRUCT", "RTPLAN", "RTRECORD", "HC", "DX", "MG", "IO", "PX", "GM", "SM", "XC", "PR", "AU", "ECG", "EPS", "HD", "SR", "IVUS", "OP", "SMR", "AR", "KER", "VA", "SRF", "OCT", "LEN", "OPV", "OPM", "OAM", "RESP", "KO", "SEG", "REG", "OPT", "BDUS", "BMD", "DOC", "FID", "DS", "CF", "DF", "VF", "AS", "CS", "EC", "LP", "FA", "CP", "DM", "FS", "MA", "MS", "CD", "DD", "ST", "OPR" }
   End Class

   Friend Class DicomModalityConvertor : Inherits StringConverter
	  Public Overrides Overloads Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
		 'True - means show a Combobox
		 'and False for show a Modal 
		 Return True
	  End Function

	  Public Overrides Overloads Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
		 'False - a option to edit values 
		 'and True - set values to state readonly
		 Return True
	  End Function

	  Public Overrides Overloads Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
		 Return New StandardValuesCollection(New String() { "", "CR", "CT", "MR", "NM", "US", "OT", "BI", "DG", "ES", "LS", "PT", "RG", "TG", "XA", "RF", "RTIMAGE", "RTDOSE", "RTSTRUCT", "RTPLAN", "RTRECORD", "HC", "DX", "MG", "IO", "PX", "GM", "SM", "XC", "PR", "AU", "ECG", "EPS", "HD", "SR", "IVUS", "OP", "SMR", "AR", "KER", "VA", "SRF", "OCT", "LEN", "OPV", "OPM", "OAM", "RESP", "KO", "SEG", "REG", "OPT", "BDUS", "BMD", "DOC", "FID", "DS", "CF", "DF", "VF", "AS", "CS", "EC", "LP", "FA", "CP", "DM", "FS", "MA", "MS", "CD", "DD", "ST", "OPR" })
	  End Function
   End Class

   Friend Class DicomFindQuery : Inherits FindQuery
	  Public Sub New()
		 _Modalities = "All"
	  End Sub

	  Private _Modalities As String
	  <Browsable(True), Category("Study"), Description("Modalities in Study"), DisplayName("Modalities in Study"), Editor(GetType(EnumTypeEditor), GetType(UITypeEditor)), TypeConverter(GetType(EnumTypeConverter))> _
	  Public Overloads Property Modalities() As String
		 Get
			 Return _Modalities
		 End Get
		 Set
			 _Modalities = Value
		 End Set
	  End Property
   End Class
End Namespace
