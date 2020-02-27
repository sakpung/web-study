' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Jpeg2000

Public Class SaveAnimation
   Public Sub New(ByVal parentMainForm As MainForm)
      InitializeComponent()

      _parentMainForm = parentMainForm
      _btnSave.Enabled = False
   End Sub

   Private _parentMainForm As MainForm

   Public Property ParentMainForm() As MainForm
      Get
         Return _parentMainForm
      End Get
      Set(ByVal value As MainForm)
         _parentMainForm = value
      End Set
   End Property

   Private Sub _btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnBrowse.Click
      Dim ofd As New OpenFileDialog()

      ofd.Filter = "JPX Files(*.jpx)|*.jpx"
      ofd.Title = "Save Animation"

      If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtFileName.Text = ofd.FileName
         _btnSave.Enabled = True
      End If
   End Sub

   Private Sub _btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnSave.Click
      If (_txtFileName.Text = "") Then
         Messager.ShowError(Me, "Please select a file")
         Return
      End If

      Dim _fileInformation As Jpeg2000FileInformation
      Dim _compositionBox As CompositionBox
      Dim _compositionBoxOptionsNode As CompositionBoxOptions
      Dim _instructionSetNode As InstructionSet
      Dim _instructionSetParameterNode As InstructionSetParameter

      _fileInformation = CType(ParentMainForm.Jpeg2000Eng.GetFileInformation(_txtFileName.Text), Jpeg2000FileInformation)
      If (Not IsNothing(_fileInformation.Composition)) Then
         Messager.ShowError(Me, "This file already has animation information!")
         Return
      End If

      _compositionBox = New CompositionBox()
      _compositionBoxOptionsNode = New CompositionBoxOptions()
      _compositionBoxOptionsNode.Height = ParentMainForm.ActiveViewerForm.RenderHeight
      _compositionBoxOptionsNode.Width = ParentMainForm.ActiveViewerForm.RenderWidth

      If (ParentMainForm.ActiveViewerForm.LoopAnimation) Then
         _compositionBoxOptionsNode.Loop = 255
      Else
         _compositionBoxOptionsNode.Loop = 0
      End If
      _compositionBox.CompositionOptions = _compositionBoxOptionsNode

      _instructionSetNode = New InstructionSet()
      _instructionSetNode.Type = Convert.ToInt32(Val("0x4"))  'Life Persis, N
      _instructionSetNode.Repetition = _fileInformation.Frame.Length
      _instructionSetNode.Tick = 1

      _instructionSetParameterNode = New InstructionSetParameter()
      _instructionSetParameterNode.Life = ParentMainForm.ActiveViewerForm.AnimationDelay
      _instructionSetParameterNode.Persist = 0
      _instructionSetParameterNode.NextUse = 0
      _instructionSetNode.Instructions.Add(_instructionSetParameterNode)

      _compositionBox.Instructions.Add(_instructionSetNode)

      Try
         ParentMainForm.Jpeg2000Eng.AppendBox(_txtFileName.Text, _compositionBox)

         Messager.ShowInformation(Me, "Animation settings was saved successfully!")

      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return
      End Try

      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub
End Class
