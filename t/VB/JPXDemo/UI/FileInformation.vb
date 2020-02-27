' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Drawing.Drawing2D

Imports Leadtools.Jpeg2000


Public Class FileInformation

   Public Sub New(ByVal mainForm As MainForm)
      _mainForm = mainForm

      InitializeComponent()

      InitClass()
   End Sub

   Private _mainForm As MainForm
   Private _dialogJPXFileInformation As JPXFileInfoStructure

   Private _colors() As Color = { _
                     Color.FromArgb(255, 0, 0), _
                     Color.FromArgb(255, 128, 0), _
                     Color.FromArgb(255, 0, 128), _
                     Color.FromArgb(128, 0, 0), _
                     Color.FromArgb(0, 255, 0), _
                     Color.FromArgb(128, 128, 0), _
                     Color.FromArgb(0, 0, 128), _
                     Color.FromArgb(0, 128, 0), _
                     Color.FromArgb(0, 0, 255), _
                     Color.FromArgb(0, 128, 255), _
                     Color.FromArgb(128, 0, 255), _
                     Color.FromArgb(0, 0, 128), _
                     Color.FromArgb(255, 0, 255), _
                     Color.FromArgb(255, 255, 0), _
                     Color.FromArgb(128, 0, 128), _
                     Color.FromArgb(128, 128, 0), _
                     Color.FromArgb(0, 255, 255), _
                     Color.FromArgb(128, 255, 255)}

   Private _colorsText() As String = { _
                           "Association", _
                           "BinaryFilter", _
                           "CodeStream", _
                           "Composition", _
                           "Data Reference", _
                           "DesiredReproduction", _
                           "DigitalSignature", _
                           "Free", _
                           "Header", _
                           "IPR", _
                           "MPEG7", _
                           "UUID", _
                           "UUIDInfo", _
                           "XML", _
                           "Media Data"}

   Private Const _paintMinimumHeight As Integer = 20
      private const _boxCount as Integer = 15
   Private Const _textToFrameHollow As Integer = 5
   Private Const _textAdditionalHeight As Integer = 5

   Private Sub InitClass()

      _dialogJPXFileInformation.prepared = False
      _dialogJPXFileInformation.boxesNumber = 0
      _dialogJPXFileInformation.boxesNumber = 0

      _btnGetInfo.Enabled = False
   End Sub

   Private Sub _btnJPEG2000Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnJPEG2000Browse.Click
      Dim ofd As New OpenFileDialog()

      ofd.Title = "Open a File"
      ofd.Filter = "JPX Files(*.jpx)|*.jpx|JP2 Files(*.jp2)|*.jp2"

      If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtJPEG2000FileName.Text = ofd.FileName
         _btnGetInfo.Enabled = True
      End If
   End Sub

   Private Sub _btnGetInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGetInfo.Click
      If (_txtJPEG2000FileName.Text = "") Then

         Messager.ShowError(Me, "Please select a file")
         Return
      End If

      FileInformationProcess()
      _grpFileMemoryOrganization.Invalidate(True)
   End Sub

   Private Function GetTextRectangle(ByVal drawText As String, ByVal textFont As Font, ByVal box As Rectangle) As Rectangle
      Dim textRectangle As Rectangle
      Dim graphicsPath As New GraphicsPath()

      graphicsPath.AddString(drawText, textFont.FontFamily, Convert.ToInt32(FontStyle.Regular), textFont.Size, New Point(0), Nothing)

      textRectangle = Rectangle.Round(graphicsPath.GetBounds())

      Return (New Rectangle((Convert.ToInt32(box.Width / 2) - Convert.ToInt32(textRectangle.Width / 2)), box.Y + _textToFrameHollow, textRectangle.Width, textRectangle.Height + _textAdditionalHeight))
   End Function

   Private Function FileInformationProcess() As Boolean
      _dialogJPXFileInformation.fileInformation = New Jpeg2000FileInformation()
      _dialogJPXFileInformation.fileName = _txtJPEG2000FileName.Text

      Try
         _dialogJPXFileInformation.fileInformation = CType(_mainForm.Jpeg2000Eng.GetFileInformation(_dialogJPXFileInformation.fileName), Jpeg2000FileInformation)

         FileInformationPrepareData()

         _txtNOFrames.Text = _dialogJPXFileInformation.fileInformation.Frame.Length.ToString()

         If (_dialogJPXFileInformation.fileInformation.Format = Jpeg2000FileFormat.LeadJpx) Then
            _txtFormat.Text = "JPX"
         Else
            : _txtFormat.Text = "JP2"
         End If

         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Association)) Then
            _txtAssociation.Text = (_dialogJPXFileInformation.fileInformation.Association.Length).ToString()
         Else
            _txtAssociation.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.BinaryFilter)) Then
            _txtBinaryFilter.Text = (_dialogJPXFileInformation.fileInformation.BinaryFilter.Length).ToString()
         Else
            _txtBinaryFilter.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.CodeStream)) Then
            _txtCodeStream.Text = (_dialogJPXFileInformation.fileInformation.CodeStream.Length).ToString()
         Else
            _txtCodeStream.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Composition)) Then
            _txtComposition.Text = (_dialogJPXFileInformation.fileInformation.Composition.Length).ToString()
         Else
            _txtComposition.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.DataReference)) Then
            _txtDataReference.Text = (_dialogJPXFileInformation.fileInformation.DataReference.Length).ToString()
         Else
            _txtDataReference.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.DesiredReproduction)) Then
            _txtDesiredReproduction.Text = (_dialogJPXFileInformation.fileInformation.DesiredReproduction.Length).ToString()
         Else
            _txtDesiredReproduction.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.DigitalSignature)) Then
            _txtDigitalSignature.Text = (_dialogJPXFileInformation.fileInformation.DigitalSignature.Length).ToString()
         Else
            _txtDigitalSignature.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Free)) Then
            _txtFree.Text = (_dialogJPXFileInformation.fileInformation.Free.Length).ToString()
         Else
            _txtFree.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Header)) Then
            _txtHeader.Text = (_dialogJPXFileInformation.fileInformation.Header.Length).ToString()
         Else
            _txtHeader.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.IntellectualPropertyRights)) Then
            _txtIPR.Text = (_dialogJPXFileInformation.fileInformation.IntellectualPropertyRights.Length).ToString()
         Else
            _txtIPR.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Mpeg7)) Then
            _txtMPEG7.Text = (_dialogJPXFileInformation.fileInformation.Mpeg7.Length).ToString()
         Else
            _txtMPEG7.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Uuid)) Then
            _txtUUID.Text = (_dialogJPXFileInformation.fileInformation.Uuid.Length).ToString()
         Else
            _txtUUID.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.UuidInformation)) Then
            _txtUUIDInfo.Text = (_dialogJPXFileInformation.fileInformation.UuidInformation.Length).ToString()
         Else
            _txtUUIDInfo.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Xml)) Then
            _txtXML.Text = (_dialogJPXFileInformation.fileInformation.Xml.Length).ToString()
         Else
            _txtXML.Text = "0"
         End If
         If (Not IsNothing(_dialogJPXFileInformation.fileInformation.MediaData)) Then
            _txtMediaData.Text = (_dialogJPXFileInformation.fileInformation.MediaData.Length).ToString()
         Else
            _txtMediaData.Text = "0"
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      End Try
      Return True
   End Function

   Public Sub FileInformationPrepareData()

      Dim numberOfBoxes, groupCount As Integer
      Dim index As Integer
      Dim counter As Integer

      numberOfBoxes = 0
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.Association))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.Association.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.BinaryFilter))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.BinaryFilter.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.CodeStream))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.CodeStream.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.Composition))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.Composition.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.DataReference))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.DataReference.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.DesiredReproduction))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.DesiredReproduction.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.DigitalSignature))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.DigitalSignature.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.Free))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.Free.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.Header))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.Header.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.IntellectualPropertyRights))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.IntellectualPropertyRights.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.Mpeg7))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.Mpeg7.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.Uuid))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.Uuid.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.UuidInformation))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.UuidInformation.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.Xml))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.Xml.Length
      End If
      if(Not IsNothing(_dialogJPXFileInformation.fileInformation.MediaData))
         numberOfBoxes = numberOfBoxes + _dialogJPXFileInformation.fileInformation.MediaData.Length
      End If

      ReDim _dialogJPXFileInformation.boxes(Convert.ToInt32(numberOfBoxes) - 1)
      _dialogJPXFileInformation.boxesNumber = numberOfBoxes

      index = 0
      _dialogJPXFileInformation.totalSize = 0

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Association) AndAlso _dialogJPXFileInformation.fileInformation.Association.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.Association.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 0
            _dialogJPXFileInformation.boxes(index).offset = Convert.Toint32(_dialogJPXFileInformation.fileInformation.Association(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.Association(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.BinaryFilter) AndAlso _dialogJPXFileInformation.fileInformation.BinaryFilter.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.BinaryFilter.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 1
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.BinaryFilter(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.BinaryFilter(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.CodeStream) AndAlso _dialogJPXFileInformation.fileInformation.CodeStream.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.CodeStream.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 2
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.CodeStream(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.CodeStream(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Composition) AndAlso _dialogJPXFileInformation.fileInformation.Composition.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.Composition.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 3
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.Composition(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.Composition(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.DataReference) AndAlso _dialogJPXFileInformation.fileInformation.DataReference.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.DataReference.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 4
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.DataReference(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.DataReference(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.DesiredReproduction) AndAlso _dialogJPXFileInformation.fileInformation.DesiredReproduction.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.DesiredReproduction.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 5
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.DesiredReproduction(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.DesiredReproduction(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.DigitalSignature) AndAlso _dialogJPXFileInformation.fileInformation.DigitalSignature.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.DigitalSignature.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 6
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.DigitalSignature(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.DigitalSignature(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Free) AndAlso _dialogJPXFileInformation.fileInformation.Free.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.Free.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 7
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.Free(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.Free(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Header) AndAlso _dialogJPXFileInformation.fileInformation.Header.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.Header.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 8
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.Header(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.Header(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.IntellectualPropertyRights) AndAlso _dialogJPXFileInformation.fileInformation.IntellectualPropertyRights.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.IntellectualPropertyRights.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 9
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.IntellectualPropertyRights(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.IntellectualPropertyRights(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If


      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Mpeg7) AndAlso _dialogJPXFileInformation.fileInformation.Mpeg7.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.Mpeg7.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 10
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.Mpeg7(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.Mpeg7(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Uuid) AndAlso _dialogJPXFileInformation.fileInformation.Uuid.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.Uuid.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 11
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.Uuid(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.Uuid(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.UuidInformation) AndAlso _dialogJPXFileInformation.fileInformation.UuidInformation.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.UuidInformation.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 12
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.UuidInformation(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.UuidInformation(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.Xml) AndAlso _dialogJPXFileInformation.fileInformation.Xml.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.Xml.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 13
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.Xml(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.Xml(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      If (Not IsNothing(_dialogJPXFileInformation.fileInformation.MediaData) AndAlso _dialogJPXFileInformation.fileInformation.MediaData.Length <> 0) Then
         For counter = 0 To _dialogJPXFileInformation.fileInformation.MediaData.Length - 1
            _dialogJPXFileInformation.boxes(index).type = 14
            _dialogJPXFileInformation.boxes(index).offset = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.MediaData(counter).BoxOffset)
            _dialogJPXFileInformation.boxes(index).size = Convert.ToInt32(_dialogJPXFileInformation.fileInformation.MediaData(counter).BoxSize)
            _dialogJPXFileInformation.totalSize = _dialogJPXFileInformation.totalSize + _dialogJPXFileInformation.boxes(index).size
            index = index + 1
         Next counter
      End If

      Dim comparer As New MyComaprer()
      Array.Sort(_dialogJPXFileInformation.boxes, comparer)

      groupCount = 1
      For counter = 1 To Convert.ToInt32(_dialogJPXFileInformation.boxesNumber - 1)
         If (_dialogJPXFileInformation.boxes(counter).type <> _dialogJPXFileInformation.boxes(counter - 1).type) Then
            groupCount = groupCount + 1
         End If
      Next counter

      ReDim _dialogJPXFileInformation.groups(Convert.ToInt32(groupCount) - 1)
      _dialogJPXFileInformation.groupsNumber = groupCount

      _dialogJPXFileInformation.groups(0).type = _dialogJPXFileInformation.boxes(0).type
      _dialogJPXFileInformation.groups(0).offset = _dialogJPXFileInformation.boxes(0).offset
      _dialogJPXFileInformation.groups(0).size = _dialogJPXFileInformation.boxes(0).size

      index = 0
      For counter = 1 To Convert.ToInt32(_dialogJPXFileInformation.boxesNumber - 1)
         If (_dialogJPXFileInformation.groups(index).type <> _dialogJPXFileInformation.boxes(counter).type) Then
            index = index + 1
            _dialogJPXFileInformation.groups(index).type = _dialogJPXFileInformation.boxes(counter).type
            _dialogJPXFileInformation.groups(index).offset = _dialogJPXFileInformation.boxes(counter).offset
            _dialogJPXFileInformation.groups(index).size = _dialogJPXFileInformation.boxes(counter).size
         Else
            _dialogJPXFileInformation.groups(index).size += _dialogJPXFileInformation.boxes(counter).size
         End If
      Next counter
      _dialogJPXFileInformation.prepared = True
   End Sub

   Private Sub _lblFileMemoryOrganization_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles _lblFileMemoryOrganization.Paint
      Dim index As Integer
      Dim textRectangle As Rectangle
      Dim textFont As New Font("Arial", 7)

      e.Graphics.FillRectangle(Brushes.White, New Rectangle(New Point(0, 0), _lblFileMemoryOrganization.Size))

      If (_dialogJPXFileInformation.prepared) Then
         Dim box As New Rectangle(0, 0, _lblFileMemoryOrganization.Width, 0)

         Dim cyClientBoxes As Integer = Convert.ToInt32(_lblFileMemoryOrganization.Height - (_dialogJPXFileInformation.groupsNumber) * _paintMinimumHeight)

         For index = 0 To _dialogJPXFileInformation.groupsNumber - 1
            box = New Rectangle(New Point(0, box.Y), New Size(box.Width, Convert.ToInt32(((_dialogJPXFileInformation.groups(index).offset + _dialogJPXFileInformation.groups(index).size) * _
                                                                       Convert.ToDouble(cyClientBoxes) / _dialogJPXFileInformation.totalSize + _
                                                                       (index + 1) * _paintMinimumHeight - box.Y))))

            Dim groupBrush As New SolidBrush(_colors(_dialogJPXFileInformation.groups(index).type))
            e.Graphics.FillRectangle(groupBrush, box)
            e.Graphics.DrawRectangle(Pens.Black, box)
            Dim text As String = String.Format(", {0} Bytes", _dialogJPXFileInformation.groups(index).size)

            Dim drawText As String = String.Concat(_colorsText(_dialogJPXFileInformation.groups(index).type), text)
            Dim textSize As Size = Size.Round(e.Graphics.MeasureString(drawText, textFont))

            textRectangle = GetCenteredTextRectangle(box, textSize)

            e.Graphics.FillRectangle(Brushes.White, textRectangle)
            e.Graphics.DrawString(drawText, textFont, Brushes.Black, textRectangle)

            box = New Rectangle(New Point(box.X, box.Bottom), box.Size)
         Next index
      End If
   End Sub

   Private Function GetCenteredTextRectangle(ByVal box As Rectangle, ByVal textSize As Size) As Rectangle
      Dim differnceWidth As Integer = box.Width - textSize.Width
      Dim differenceHeight As Integer = box.Height - textSize.Height

      Dim locationY As Integer = Convert.ToInt32(box.Y + differenceHeight / 2)
      Dim locationX As Integer = Convert.ToInt32(box.X + differnceWidth / 2)

      Return (New Rectangle(locationX, _
                            locationY, _
                            textSize.Width, _
                            textSize.Height))
   End Function

   Private Sub _lbl_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles _lblXMLColor.Paint, _lblUUIDInfoColor.Paint, _lblUUIDColor.Paint, _lblMPEG7Color.Paint, _lblMediaDataColor.Paint, _lblIPRColor.Paint, _lblHeaderColor.Paint, _lblFreeColor.Paint, _lblDigitalSignatureColor.Paint, _lblDesiredReproductionColor.Paint, _lblDataReferenceColor.Paint, _lblCompositionColor.Paint, _lblCodeStreamColor.Paint, _lblBinaryFilterColor.Paint, _lblAssociationColor.Paint
      Dim control As Label = CType(sender, Label)
      e.Graphics.FillRectangle(New SolidBrush(_colors(control.TabIndex)), New Rectangle(New Point(0, 0), control.Size))
   End Sub

   Public Class MyComaprer
      Implements IComparer

      Function Compare(ByVal string1 As Object, ByVal string2 As Object) As Integer _
      Implements IComparer.Compare
         Dim fileInformationSort1, fileInformationSort2 As FileInformationSortStructure

         fileInformationSort1 = CType(string1, FileInformationSortStructure)
         fileInformationSort2 = CType(string2, FileInformationSortStructure)

         Return Convert.ToInt32(fileInformationSort1.offset) - Convert.ToInt32(fileInformationSort2.offset)
      End Function
   End Class
End Class


