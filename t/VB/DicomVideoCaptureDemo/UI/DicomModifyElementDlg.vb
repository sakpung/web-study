' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Dicom
Imports System

Namespace DicomVideoCaptureDemo.UI
   Partial Public Class DicomModifyElementDlg
      Inherits Form
      Public m_nVR As DicomVRType
      Public m_strValue As String = ""
      Public m_nCount As Integer
      Public m_pElement As DicomElement
      Public m_pDicomIOD As DicomIod

      Public strDesc As String = ""

      Public Property strHint() As String
         Get
            Return _txtBox_Description.Text
         End Get
         Set(ByVal value As String)
            _txtBox_Description.Text = value
         End Set
      End Property

      Public Property strCode() As String
         Get
            Return _txtBox_Code.Text
         End Get
         Set(ByVal value As String)
            _txtBox_Code.Text = value
         End Set
      End Property

      Public Property strName() As String
         Get
            Return _txtBox_Name.Text
         End Get
         Set(ByVal value As String)
            _txtBox_Name.Text = value
         End Set
      End Property

      Public Property strUsage() As String
         Get
            Return _txtBox_Usage.Text
         End Get
         Set(ByVal value As String)
            _txtBox_Usage.Text = value
         End Set
      End Property

      Public Property strVR() As String
         Get
            Return _txtBox_VR.Text
         End Get
         Set(ByVal value As String)
            _txtBox_VR.Text = value
         End Set
      End Property

      Public Property strVRMultiplicity() As String
         Get
            Return _txtBox_VR_Multiplicity.Text
         End Get
         Set(ByVal value As String)
            _txtBox_VR_Multiplicity.Text = value
         End Set
      End Property

      Public Property strStaticInstructions() As String
         Get
            Return _label_InstructModifyElement.Text
         End Get
         Set(ByVal value As String)
            _label_InstructModifyElement.Text = value
         End Set
      End Property

      Public m_strVRInfo As String = ""
      Public m_bMultipleItems As Boolean


      Public Sub New()
         InitializeComponent()
      End Sub

      ' Determines which buttons will be enabled/disabled
      Private Sub EnableItems(ByVal bEnable As Boolean)
         Dim nListCount As Integer = _lstBox_Value.Items.Count
         _btn_Modify.Enabled = bEnable
         If nListCount = 0 Then
            _btn_Modify.Text = "&Insert"
         Else
            _btn_Modify.Text = "&Modify"
         End If

         ResizeListBox()

         _btn_InsertBefore.Enabled = bEnable AndAlso m_bMultipleItems AndAlso (nListCount >= 1)
         _btn_InsertAfter.Enabled = bEnable AndAlso m_bMultipleItems AndAlso (nListCount >= 1)
         _btn_Delete.Enabled = bEnable AndAlso (nListCount >= 1)
         _lstBox_Value.Focus()
      End Sub

      ' Determines which buttons will be visible/invisible
      Private Sub ShowItems()
         'int nListCount = m_ListValue.GetCount();
         _btn_Modify.Visible = True

         _btn_InsertBefore.Visible = m_bMultipleItems
         _btn_InsertAfter.Visible = m_bMultipleItems
         _btn_Delete.Visible = True
         _lstBox_Value.Focus()
      End Sub

      Private Sub ResizeListBox()
         Dim rcTree As New Rectangle()

         ' if single item and empty, hide the list box and display a disabled text box
         Dim nListCount As Integer = _lstBox_Value.Items.Count
         If nListCount = 0 Then
            If m_bMultipleItems Then
               _txtBox_ValueMulti.Visible = True
            Else
               _txtBox_ValueSingle.Visible = True
            End If
            _lstBox_Value.Visible = False
            Return
         End If


         _txtBox_ValueSingle.Visible = False
         _txtBox_ValueMulti.Visible = False
         If m_bMultipleItems Then
            'IDC_EDIT_VALUE_MULTI is a placeholder
            rcTree.Size = _txtBox_ValueMulti.Size
            rcTree.Location = _txtBox_ValueMulti.Location
         Else
            'IDC_EDIT_VALUE_SINGLE is a placeholder
            rcTree.Size = _txtBox_ValueSingle.Size
            rcTree.Location = _txtBox_ValueSingle.Location
         End If

         ' Reposition and size 
         _lstBox_Value.Location = rcTree.Location
         _lstBox_Value.Size = rcTree.Size
         _lstBox_Value.Visible = True

      End Sub


      Private Sub PopulateListBox()

         Dim strCopy As String = m_strValue
         Dim pszCopy As String = strCopy
         Dim p As String() = pszCopy.Split("\"c)


         Dim i As Integer
         For i = 0 To m_nCount - 1
            If p.Length > i Then
               _lstBox_Value.Items.Add(p(i))
            End If
         Next
      End Sub

      Private Function GetStringTag(ByVal uTag As Long) As String
         Dim strRet As String
         strRet = String.Format("{0:X4}:{1:X4}", CType(CLng(uTag) >> 16, UInt16), CType(CLng(uTag) And &HFFFF, UInt16))
         Return strRet
      End Function

      Private Function GetVRInfo(ByVal nVR As DicomVRType, ByRef strVR As String, ByRef strVRDetail As String) As DicomVRType
         Dim bMulti As Boolean = False
         Dim pVR As DicomVR = DicomVRTable.Instance.Find(nVR)
         If pVR IsNot Nothing Then
            strVR = pVR.Name
            If ((pVR.Restriction And DicomVRRestriction.BinaryFixed) = DicomVRRestriction.BinaryFixed) OrElse ((pVR.Restriction And DicomVRRestriction.StringFixed) = DicomVRRestriction.StringFixed) Then
               bMulti = True
            End If
         Else
            nVR = DicomVRType.UN
            strVR = "Unknown"
            bMulti = True
         End If

         Select Case nVR
            Case DicomVRType.OB, DicomVRType.UN
               strVRDetail = "Hexadecimal"
               Exit Select

            Case DicomVRType.SS, DicomVRType.US, DicomVRType.OW, DicomVRType.SL, DicomVRType.[IS], DicomVRType.UL
               strVRDetail = "Integer"
               Exit Select

            Case DicomVRType.AT
               strVRDetail = "Group:Element" & Environment.NewLine & "(Group and Element should be hexadecimal words)"
               Exit Select

            Case DicomVRType.FD, DicomVRType.FL, DicomVRType.DS
               strVRDetail = "Float"
               Exit Select

            Case DicomVRType.CS, DicomVRType.SH, DicomVRType.LO, DicomVRType.AE, DicomVRType.LT, DicomVRType.ST, _
             DicomVRType.UI, DicomVRType.UT, DicomVRType.PN
               If bMulti <> False Then
                  strVRDetail = "String"
               Else
                  strVRDetail = "Text"
               End If
               Exit Select

            Case DicomVRType.[AS]
               strVRDetail = "Number Reference" & Environment.NewLine & "(Reference = 'days' or 'weeks' or 'months' or 'years')"
               Exit Select

            Case DicomVRType.DA
               If True Then
                  strVRDetail = "MM/DD/YYYY" & Environment.NewLine & "(MM=Month, DD=Day, YYYY=Year)"
                  '
                  '               EnableDateCtrl(TRUE);
                  '               m_Date.SetFormat("MM/dd/yyy");
                  '               m_Date.SetDate(m_strValue);
                  '               

               End If
               Exit Select

            Case DicomVRType.DT
               strVRDetail = "MM/DD/YYYY HH:MM:SS.FFFFFF+OOOO" & Environment.NewLine & "(MM=Month, DD=Day, YYYY=Year)" & Environment.NewLine & "(HH=Hours, MM=Minutes, SS=Seconds, FFFFFF=Fractional Second, OOOO=Offset from Coordinated Universal Time)"
               Exit Select

            Case DicomVRType.TM
               strVRDetail = "HH:MM:SS.FFFF" & Environment.NewLine & "(HH=Hours, MM=Minutes, SS=Seconds, FFFFFF=Fractional Second)"
               Exit Select
            Case Else

               strVRDetail = ""
               Exit Select
         End Select
         Return nVR
      End Function

      Private Function GetUsage(ByVal nUsage As DicomIodUsageType) As String
         Dim strUsage As String = ""
         Select Case nUsage
            Case DicomIodUsageType.MandatoryModule
               strUsage = "Mandatory"
               Exit Select

            Case DicomIodUsageType.ConditionalModule
               strUsage = "Conditional"
               Exit Select

            Case DicomIodUsageType.OptionalModule
               strUsage = "Optional"
               Exit Select

            Case DicomIodUsageType.Type1MandatoryElement
               strUsage = "Mandatory -- Type 1"
               Exit Select

            Case DicomIodUsageType.Type1ConditionalElement
               strUsage = "Conditional -- Type 1"
               Exit Select

            Case DicomIodUsageType.Type2MandatoryElement
               strUsage = "Mandatory -- Type 2"
               Exit Select

            Case DicomIodUsageType.Type2ConditionalElement
               strUsage = "Conditional -- Type 2"
               Exit Select

            Case DicomIodUsageType.OptionalElement
               strUsage = "Mandatory -- Type 3"
               Exit Select
         End Select
         Return strUsage
      End Function

      Private Sub _btn_Modify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_Modify.Click
         Dim dlg As New EditItemDlg()
         dlg.m_nType = EditItemDlg.EditItemDlgEnums.MODIFY_ITEM
         Dim nSelected As Integer = _lstBox_Value.SelectedIndex

         If nSelected >= 0 Then
            dlg.strValue = TryCast(_lstBox_Value.Items(nSelected), String)
         Else
            nSelected = 0
         End If

         dlg.m_nVR = m_nVR
         dlg.strVRInfo = m_strVRInfo
         If dlg.ShowDialog() = DialogResult.OK Then
            If dlg.strValue.Length > 0 Then
               _lstBox_Value.Items.Insert(nSelected, dlg.strValue)
               If _lstBox_Value.Items.Count > (nSelected + 1) Then
                  _lstBox_Value.Items.RemoveAt(nSelected + 1)
               End If
            Else
               If _lstBox_Value.Items.Count > nSelected Then
                  _lstBox_Value.Items.RemoveAt(nSelected)
               End If
            End If

            _lstBox_Value.SelectedIndex = nSelected
         End If

         EnableItems(True)
         ShowItems()
      End Sub

      Private Sub _btn_Delete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_Delete.Click
         Dim nSelected As Integer = _lstBox_Value.SelectedIndex
         If nSelected >= 0 Then
            _lstBox_Value.Items.RemoveAt(nSelected)
            nSelected = If(nSelected <= 0, 0, nSelected - 1)
            If _lstBox_Value.Items.Count > 0 Then
               _lstBox_Value.SelectedIndex = nSelected
            Else
               _lstBox_Value.SelectedIndex = -1
            End If
         End If
         EnableItems(True)
         ShowItems()
      End Sub

      Private Sub _btn_InsertBefore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_InsertBefore.Click
         OnInsert(False)
      End Sub

      Private Sub _btn_InsertAfter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_InsertAfter.Click
         OnInsert(True)
      End Sub

      Private Sub OnInsert(ByVal bAfter As Boolean)
         Dim dlg As New EditItemDlg()
         dlg.m_nType = EditItemDlg.EditItemDlgEnums.INSERT_ITEM
         Dim nSelected As Integer = _lstBox_Value.SelectedIndex
         If nSelected < 0 Then
            nSelected = 0
         End If

         dlg.strValue = ""
         dlg.m_nVR = m_nVR
         dlg.strVRInfo = m_strVRInfo
         If dlg.ShowDialog() = DialogResult.OK Then
            If bAfter Then
               nSelected += 1
            End If
            _lstBox_Value.Items.Insert(nSelected, dlg.strValue)
            _lstBox_Value.SelectedIndex = nSelected
         End If
         EnableItems(True)
      End Sub

      Private Sub _btn_OK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_OK.Click
         Dim i As Integer
         Dim strTmp As String
         m_strValue = ""
         m_nCount = _lstBox_Value.Items.Count
         For i = 0 To m_nCount - 1
            If m_strValue.Length > 0 Then
               m_strValue += "\"
            End If
            strTmp = TryCast(_lstBox_Value.Items(i), String)
            If strTmp.Length > 0 Then
               m_strValue += strTmp
            End If
         Next
      End Sub

      Private Sub ExchangeData()
         _txtBox_Description.Text = strHint
         _txtBox_Code.Text = strCode
         _txtBox_Name.Text = strName
         _txtBox_Usage.Text = strUsage
         _txtBox_VR.Text = strVR
         _txtBox_VR_Multiplicity.Text = strVRMultiplicity
         _label_InstructModifyElement.Text = strStaticInstructions
      End Sub

      Private Sub DicomModifyElementDlg_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         'm_strValue = m_pMyTreeData->m_strValue;
         If m_pDicomIOD IsNot Nothing Then
            strCode = GetStringTag(m_pDicomIOD.TagCode)
            strName = m_pDicomIOD.Name
            strUsage = GetUsage(m_pDicomIOD.Usage)
            strHint = m_pDicomIOD.Description

            Dim pDicomTag As DicomTag = DicomTagTable.Instance.Find(m_pDicomIOD.TagCode)
            If pDicomTag IsNot Nothing Then

               If pDicomTag.MinVM = pDicomTag.MaxVM Then
                  m_bMultipleItems = pDicomTag.MinVM > 1
                  strVRMultiplicity = String.Format("Exactly {0:D} value", pDicomTag.MinVM)
                  If pDicomTag.MinVM > 1 Then
                     strVRMultiplicity += "s"
                  End If

               ElseIf pDicomTag.MaxVM = -1 Then
                  m_bMultipleItems = True
                  strVRMultiplicity = String.Format("At least {0:D} value", pDicomTag.MinVM)
                  If pDicomTag.MinVM > 1 Then
                     strVRMultiplicity += "s"
                  End If
               Else

                  m_bMultipleItems = True
                  strVRMultiplicity = String.Format("{0:D} to {0:D} values", pDicomTag.MinVM)
               End If

               strVRMultiplicity += "."

               If pDicomTag.VMDivider <> 1 Then
                  Dim strTemp As String
                  strTemp = String.Format("Count must be divisible by {0:D}.", pDicomTag.VMDivider)
                  strVRMultiplicity += strTemp
               End If
            End If
         End If
         m_nVR = m_pElement.VR
         Dim tempStrVR As String = strVR
         GetVRInfo(m_nVR, tempStrVR, m_strVRInfo)
         strVR = tempStrVR
         PopulateListBox()


         If m_bMultipleItems Then
            strStaticInstructions = "Select an existing item, and click 'Modify' to change a value, or an 'Insert' button to insert a new value. Double-click an item to modify it."
         Else
            strStaticInstructions = "Click 'Insert' to add a value, 'Delete' to delete the value, or 'Modify' to change a value.  Double-click an item to modify it."
         End If

         _txtBox_ValueMulti.Visible = False
         _txtBox_ValueSingle.Visible = False

         EnableItems(True)
         ShowItems()
         _lstBox_Value.Focus()
         If _lstBox_Value.Items.Count > 0 Then
            _lstBox_Value.SelectedIndex = 0
         End If
      End Sub
   End Class
End Namespace
