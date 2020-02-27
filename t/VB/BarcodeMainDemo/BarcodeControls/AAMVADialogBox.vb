' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports Leadtools
Imports Leadtools.Barcode
Imports System.Collections.Generic
Imports System
Imports System.Windows.Forms

Public Class AAMVADialogBox : Inherits Form

   Dim _id As AAMVAID
   Dim _infoDictionary As Dictionary(Of String, AAMVADataElementInfo)
   Sub New(ByRef id As AAMVAID)
      InitializeComponent()
      _id = id
      _infoDictionary = CType(AAMVADataElementInfo.RetrieveAll(id.Version), Dictionary(Of String, AAMVADataElementInfo))
      Populate()
   End Sub


   Private Sub Populate()
      _listViewRawDataElements.View = View.Details
      _listViewRawDataElements.Columns.Add("ElementID", -2, HorizontalAlignment.Left)
      _listViewRawDataElements.Columns.Add("Friendly Name", -2, HorizontalAlignment.Left)
      _listViewRawDataElements.Columns.Add("Subfile Code", -2, HorizontalAlignment.Left)
      _listViewRawDataElements.Columns.Add("Value", -2, HorizontalAlignment.Left)
      _listViewRawDataElements.Columns.Add("Definition", -2, HorizontalAlignment.Left)
      _listViewRawDataElements.FullRowSelect = True

      _listViewCommonFields.View = View.Details
      _listViewCommonFields.Columns.Add("Field", -2, HorizontalAlignment.Left)
      _listViewCommonFields.Columns.Add("Value", -2, HorizontalAlignment.Left)
      _listViewCommonFields.FullRowSelect = True

      PopulateCommon()
      PopulateRaw()
   End Sub

   Private Sub PopulateCommon()

      _listViewCommonFields.Items.Clear()

      'First Name
      Dim firstNameItem As New ListViewItem()
      firstNameItem.Text = "First Name"
      Dim firstNameRes As AAMVANameResult = _id.FirstName
      firstNameItem.SubItems.Add(If(firstNameRes Is Nothing, "", firstNameRes.Value))
      _listViewCommonFields.Items.Add(firstNameItem)

      'LastName
      Dim lastNameItem As New ListViewItem()
      lastNameItem.Text = "Last Name"
      Dim lastNameRes As AAMVANameResult = _id.LastName
      lastNameItem.SubItems.Add(If(lastNameRes Is Nothing, "", lastNameRes.Value))
      _listViewCommonFields.Items.Add(lastNameItem)

      'DOB
      Dim dobItem As New ListViewItem()
      dobItem.Text = "Date Of Birth (YYYYMMDD)"
      Dim dob As String = _id.DateOfBirth
      dobItem.SubItems.Add(If(dob Is Nothing, "", dob))
      _listViewCommonFields.Items.Add(dobItem)


      Dim region As AAMVARegion = _id.AddressRegion
      'OverXX depending on region
      If _id.Over18Available Then
         Dim item18 As New ListViewItem()
         item18.Text = "Over 18?"
         item18.SubItems.Add(_id.Over18.ToString())
         _listViewCommonFields.Items.Add(item18)
      End If

      If (region = AAMVARegion.Canada AndAlso _id.Over19Available) OrElse (region = AAMVARegion.Unknown AndAlso _id.Over19Available) Then
         Dim item19 As New ListViewItem()
         item19.Text = "Over 19?"
         item19.SubItems.Add(_id.Over19.ToString())
         _listViewCommonFields.Items.Add(item19)
      End If

      If (region = AAMVARegion.UnitedStates AndAlso _id.Over21Available) OrElse (region = AAMVARegion.Unknown AndAlso _id.Over21Available) Then
         Dim item21 As New ListViewItem()
         item21.Text = "Over 21?"
         item21.SubItems.Add(_id.Over21.ToString())
         _listViewCommonFields.Items.Add(item21)
      End If

      'ID Number
      Dim numberItem As New ListViewItem()
      numberItem.Text = "ID Number"
      Dim number As String = _id.Number
      numberItem.SubItems.Add(If(number Is Nothing, "", number))
      _listViewCommonFields.Items.Add(numberItem)

      'Address Street 1
      Dim addressStreet1Item As New ListViewItem()
      addressStreet1Item.Text = "Address Street 1"
      Dim addressStreet1 As String = _id.AddressStreet1
      addressStreet1Item.SubItems.Add(If(addressStreet1 Is Nothing, "", addressStreet1))
      _listViewCommonFields.Items.Add(addressStreet1Item)

      'Address Street 2
      Dim addressStreet2Item As New ListViewItem()
      addressStreet2Item.Text = "Address Street 2"
      Dim addressStreet2 As String = _id.AddressStreet2
      addressStreet2Item.SubItems.Add(If(addressStreet2 Is Nothing, "", addressStreet2))
      _listViewCommonFields.Items.Add(addressStreet2Item)

      'Address City
      Dim addressCityItem As New ListViewItem()
      addressCityItem.Text = "Address City"
      Dim addressCity As String = _id.AddressCity
      addressCityItem.SubItems.Add(If(addressCity Is Nothing, "", addressCity))
      _listViewCommonFields.Items.Add(addressCityItem)

      'Address State Abbreviation
      Dim addressStateAbbrItem As New ListViewItem()
      addressStateAbbrItem.Text = "Address State Abbreviation"
      Dim addressStateAbbr As String = _id.AddressStateAbbreviation
      addressStateAbbrItem.SubItems.Add(If(addressStateAbbr Is Nothing, "", addressStateAbbr))
      _listViewCommonFields.Items.Add(addressStateAbbrItem)

      'Address Postal Code
      Dim addressPostalCodeItem As New ListViewItem()
      addressPostalCodeItem.Text = "Address Postal Code"
      Dim addressPostalCode As String = _id.AddressPostalCode
      addressPostalCodeItem.SubItems.Add(If(addressPostalCode Is Nothing, "", addressPostalCode))
      _listViewCommonFields.Items.Add(addressPostalCodeItem)

      'Region
      Dim addressRegionItem As New ListViewItem()
      addressRegionItem.Text = "Address Region"
      addressRegionItem.SubItems.Add(region.ToString())
      _listViewCommonFields.Items.Add(addressRegionItem)

      'Expiration Date
      Dim expirationDateItem As New ListViewItem()
      expirationDateItem.Text = "Expiration Date (YYYYMMDD)"
      Dim expirationDate As String = _id.ExpirationDate
      expirationDateItem.SubItems.Add(If(expirationDate Is Nothing, "", expirationDate))
      _listViewCommonFields.Items.Add(expirationDateItem)

      'Issue Date
      Dim issueDateitem As New ListViewItem()
      issueDateitem.Text = "Issue Date (YYYYMMDD)"
      Dim issueDate As String = _id.IssueDate
      issueDateitem.SubItems.Add(If(issueDate Is Nothing, "", issueDate))
      _listViewCommonFields.Items.Add(issueDateitem)

      'Expired
      If _id.ExpirationAvailable Then
         Dim itemExpired As New ListViewItem()
         itemExpired.Text = "Expired?"
         itemExpired.SubItems.Add(_id.Expired.ToString())
         _listViewCommonFields.Items.Add(itemExpired)
      End If

      'EyeColor
      Dim eyeColorItem As New ListViewItem()
      eyeColorItem.Text = "Eye Color"
      Dim eyeColor As AAMVAEyeColor = _id.EyeColor
      eyeColorItem.SubItems.Add(eyeColor.ToString())
      _listViewCommonFields.Items.Add(eyeColorItem)

      'HairColor
      Dim hairColorItem As New ListViewItem()
      hairColorItem.Text = "Hair Color"
      Dim hairColor As AAMVAHairColor = _id.HairColor
      hairColorItem.SubItems.Add(hairColor.ToString())
      _listViewCommonFields.Items.Add(hairColorItem)

      'Sex
      Dim sexItem As New ListViewItem()
      sexItem.Text = "Sex"
      Dim sex As AAMVASex = _id.Sex
      sexItem.SubItems.Add(sex.ToString())
      _listViewCommonFields.Items.Add(sexItem)
   End Sub

   Private Sub PopulateRaw()
      _listViewRawDataElements.Items.Clear()

      For i As Integer = 0 To _id.NumberOfEntries - 1
         Dim dictionary As IDictionary(Of String, AAMVADataElement) = _id.Subfiles(i).DataElements
         For Each kvp As KeyValuePair(Of String, AAMVADataElement) In dictionary
            Dim containsKey As Boolean = _infoDictionary.ContainsKey(kvp.Key)
            Dim info As AAMVADataElementInfo = If(containsKey, _infoDictionary(kvp.Key), Nothing)

            Dim arr As String() = New String(4) {}
            arr(0) = kvp.Key
            arr(1) = If(containsKey, info.FriendlyName, "")
            arr(2) = _id.Subfiles(i).SubfileTypeCode
            arr(3) = kvp.Value.Value
            arr(4) = If(containsKey, info.Definition, "")
            Dim item As New ListViewItem(arr)
            _listViewRawDataElements.Items.Add(item)
         Next
      Next
   End Sub

   Private Sub HandleClose(sender As Object, e As EventArgs) Handles Me.FormClosed
      If _id IsNot Nothing Then
         _id.Dispose()
         _id = Nothing
      End If
   End Sub

   Private Sub _btnCloseAAMVA_Click(sender As Object, e As EventArgs) Handles _btnCloseAAMVA.Click
      Close()
   End Sub


End Class
