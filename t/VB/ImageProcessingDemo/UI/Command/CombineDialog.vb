' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.ImageProcessing.Effects


Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the CombineCommand

   Partial Public Class CombineDialog : Inherits Form
      Private _CombineCommand As CombineCommand
      Private _X, _Y, _Width, _Height As Integer

      Public Sub New(ByVal TempImage As RasterImage)
         InitializeComponent()
         _CombineCommand = New CombineCommand()
         _X = CType(TempImage.Width / 8, Integer)
         _Y = CType(TempImage.Height / 8, Integer)
         _Width = TempImage.Width
         _Height = TempImage.Height

         'Set command default values
         InitializeUI()
      End Sub

      Public Property CombineCommand() As CombineCommand
         Get
            'Update command values
            UpdateCommand()
            Return _CombineCommand
         End Get
         Set(ByVal value As CombineCommand)
            _CombineCommand = value
            InitializeUI()
         End Set
      End Property
      Private Sub InitializeUI()

         Dim names As String()

         _cmbSourceRectangle.Items.Add("SourceNop")
         _cmbSourceRectangle.Items.Add("SourceNot")
         _cmbSourceRectangle.Items.Add("Source0")
         _cmbSourceRectangle.Items.Add("Source1")
         _cmbSourceRectangle.SelectedIndex = _cmbSourceRectangle.Items.IndexOf("SourceNop")

         _cmbDestinationRectangle.Items.Add("DestinationNop")
         _cmbDestinationRectangle.Items.Add("DestinationNot")
         _cmbDestinationRectangle.Items.Add("Destination0")
         _cmbDestinationRectangle.Items.Add("Destination1")
         _cmbDestinationRectangle.SelectedIndex = _cmbDestinationRectangle.Items.IndexOf("DestinationNop")

         names = System.Enum.GetNames(GetType(CombineCommandFlags))
         Dim str As String = "Operation"
         Dim str1 As String = "Absolute"
         For Each name As String In names
            Dim index As Integer = name.IndexOf(str)
            If index <> -1 Then
               _cmbOperation.Items.Add(name)
            End If
            index = name.IndexOf(str1)
            If index <> -1 Then
               _cmbOperation.Items.Add(name)
            End If

         Next name
         _cmbOperation.SelectedIndex = _cmbOperation.Items.IndexOf("OperationAnd")

         _cmbResultImageRectangle.Items.Add("ResultNop")
         _cmbResultImageRectangle.Items.Add("ResultNot")
         _cmbResultImageRectangle.Items.Add("Result0")
         _cmbResultImageRectangle.Items.Add("Result1")
         _cmbResultImageRectangle.SelectedIndex = _cmbResultImageRectangle.Items.IndexOf("ResultNop")

         _cmbSourceImageRectangle.Items.Add("SourceMaster")
         _cmbSourceImageRectangle.Items.Add("SourceRed")
         _cmbSourceImageRectangle.Items.Add("SourceGreen")
         _cmbSourceImageRectangle.Items.Add("SourceBlue")
         _cmbSourceImageRectangle.SelectedIndex = _cmbSourceImageRectangle.Items.IndexOf("SourceMaster")

         _cmbDestinationImageRectangle.Items.Add("DestinationMaster")
         _cmbDestinationImageRectangle.Items.Add("DestinationRed")
         _cmbDestinationImageRectangle.Items.Add("DestinationGreen")
         _cmbDestinationImageRectangle.Items.Add("DestinationBlue")
         _cmbDestinationImageRectangle.SelectedIndex = _cmbDestinationImageRectangle.Items.IndexOf("DestinationMaster")

         _cmbChannelResultImageRectangle.Items.Add("ResultMaster")
         _cmbChannelResultImageRectangle.Items.Add("ResultRed")
         _cmbChannelResultImageRectangle.Items.Add("ResultGreen")
         _cmbChannelResultImageRectangle.Items.Add("ResultBlue")
         _cmbChannelResultImageRectangle.SelectedIndex = _cmbChannelResultImageRectangle.Items.IndexOf("ResultMaster")

         _numX.Maximum = _Width
         _numX.Value = _X

         _numY.Maximum = _Height
         _numY.Value = _Y

         _numWidth.Maximum = _Width
         _numWidth.Value = CInt(_Width / 2)

         _numHeight.Maximum = _Height
         _numHeight.Value = CInt(_Height / 2)

         _numPointX.Maximum = _Width

         _numPointY.Maximum = _Height

      End Sub

      Private Sub UpdateCommand()
         _CombineCommand.Flags = CType(0, CombineCommandFlags)

         _CombineCommand.Flags = _CombineCommand.Flags Or TranslateSourceRectangle()
         _CombineCommand.Flags = _CombineCommand.Flags Or TranslateDestinationRectangle()
         _CombineCommand.Flags = _CombineCommand.Flags Or TranslateOperation()
         _CombineCommand.Flags = _CombineCommand.Flags Or TranslateResultImageRectangle()
         _CombineCommand.Flags = _CombineCommand.Flags Or TranslateDestinationImageRectangle()
         _CombineCommand.Flags = _CombineCommand.Flags Or TranslateSourceImageRectangle()
         _CombineCommand.Flags = _CombineCommand.Flags Or TranslateChannelResultImageRectangle()

         _CombineCommand.DestinationRectangle = New LeadRect(CInt(_numX.Value), CInt(_numY.Value), CInt(_numWidth.Value), CInt(_numHeight.Value))

         _CombineCommand.SourcePoint = New LeadPoint(CInt(_numPointX.Value), CInt(_numPointY.Value))
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub

      Public Function TranslateSourceRectangle() As CombineCommandFlags
         Select Case _cmbSourceRectangle.SelectedIndex
            Case 0
               Return CombineCommandFlags.SourceNop
            Case 1
               Return CombineCommandFlags.SourceNot
            Case 2
               Return CombineCommandFlags.Source0
            Case 3
               Return CombineCommandFlags.Source1
            Case Else
               Return CombineCommandFlags.SourceNop

         End Select
      End Function
      Public Function TranslateDestinationRectangle() As CombineCommandFlags
         Select Case _cmbDestinationRectangle.SelectedIndex
            Case 0
               Return CombineCommandFlags.DestinationNop
            Case 1
               Return CombineCommandFlags.DestinationNot
            Case 2
               Return CombineCommandFlags.Destination0
            Case 3
               Return CombineCommandFlags.Destination1
            Case Else
               Return CombineCommandFlags.DestinationNop
         End Select
      End Function

      Public Function TranslateOperation() As CombineCommandFlags
         Select Case _cmbOperation.SelectedIndex
            Case 0
               Return CombineCommandFlags.OperationAnd
            Case 1
               Return CombineCommandFlags.OperationOr
            Case 2
               Return CombineCommandFlags.OperationXor
            Case 3
               Return CombineCommandFlags.OperationAdd
            Case 4
               Return CombineCommandFlags.OperationSubtractSource
            Case 5
               Return CombineCommandFlags.OperationSubtractDestination
            Case 6
               Return CombineCommandFlags.OperationMultiply
            Case 7
               Return CombineCommandFlags.OperationDivideSource
            Case 8
               Return CombineCommandFlags.OperationDivideDestination
            Case 9
               Return CombineCommandFlags.OperationAverage
            Case 10
               Return CombineCommandFlags.OperationMinimum
            Case 11
               Return CombineCommandFlags.OperationMaximum
            Case 12
               Return CombineCommandFlags.AbsoluteDifference
            Case Else
               Return CombineCommandFlags.OperationAnd
         End Select
      End Function

      Public Function TranslateResultImageRectangle() As CombineCommandFlags
         Select Case _cmbSourceRectangle.SelectedIndex
            Case 0
               Return CombineCommandFlags.ResultNop
            Case 1
               Return CombineCommandFlags.ResultNot
            Case 2
               Return CombineCommandFlags.Result0
            Case 3
               Return CombineCommandFlags.Result1
            Case Else
               Return CombineCommandFlags.ResultNop
         End Select
      End Function

      Public Function TranslateDestinationImageRectangle() As CombineCommandFlags
         Select Case _cmbSourceRectangle.SelectedIndex
            Case 0
               Return CombineCommandFlags.DestinationMaster
            Case 1
               Return CombineCommandFlags.DestinationRed
            Case 2
               Return CombineCommandFlags.DestinationGreen
            Case 3
               Return CombineCommandFlags.DestinationBlue
            Case Else
               Return CombineCommandFlags.DestinationMaster
         End Select
      End Function

      Public Function TranslateSourceImageRectangle() As CombineCommandFlags
         Select Case _cmbSourceRectangle.SelectedIndex
            Case 0
               Return CombineCommandFlags.SourceMaster
            Case 1
               Return CombineCommandFlags.SourceRed
            Case 2
               Return CombineCommandFlags.SourceGreen
            Case 3
               Return CombineCommandFlags.SourceBlue
            Case Else
               Return CombineCommandFlags.SourceMaster
         End Select
      End Function

      Public Function TranslateChannelResultImageRectangle() As CombineCommandFlags
         Select Case _cmbSourceRectangle.SelectedIndex
            Case 0
               Return CombineCommandFlags.ResultMaster
            Case 1
               Return CombineCommandFlags.ResultRed
            Case 2
               Return CombineCommandFlags.ResultGreen
            Case 3
               Return CombineCommandFlags.ResultBlue
            Case Else
               Return CombineCommandFlags.ResultMaster
         End Select
      End Function

      Private Sub _numX_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numX.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numWidth_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numWidth.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numY_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numY.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numHeight_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numHeight.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numPointX_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numPointX.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numPointY_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numPointY.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub
   End Class
End Namespace
