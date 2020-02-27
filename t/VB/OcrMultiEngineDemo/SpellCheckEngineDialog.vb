' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO
Imports System.Diagnostics
Imports Leadtools.Ocr

Public Class SpellCheckEngineDialog
   Private _ocrEngine As IOcrEngine

   Public Sub New(ByVal ocrEngine As IOcrEngine)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      _ocrEngine = ocrEngine
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      If Not DesignMode Then
         Dim ocrSpellCheckManager As IOcrSpellCheckManager = _ocrEngine.SpellCheckManager

         Dim engines() As OcrSpellCheckEngine = ocrSpellCheckManager.GetSupportedSpellCheckEngines()
         For Each engine As OcrSpellCheckEngine In engines
            _engineComboBox.Items.Add(engine)
         Next

         _engineComboBox.SelectedItem = ocrSpellCheckManager.SpellCheckEngine

         _helpButton.Visible = (_ocrEngine.EngineType = OcrEngineType.LEAD)
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _okButton.Click
      Dim ocrSpellCheckManager As IOcrSpellCheckManager = _ocrEngine.SpellCheckManager

      Try
         Dim spellCheckEngine As OcrSpellCheckEngine = CType(_engineComboBox.SelectedItem, OcrSpellCheckEngine)
         ocrSpellCheckManager.SpellCheckEngine = spellCheckEngine
      Catch ex As Exception
         Dim msg As String = String.Format("{0}{1}Spell check engine will be set to 'None' now.", ex.Message, Environment.NewLine)
         MessageBox.Show(Me, msg, "OCR Spell Check Engine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         ocrSpellCheckManager.SpellCheckEngine = OcrSpellCheckEngine.None
         _engineComboBox.SelectedItem = ocrSpellCheckManager.SpellCheckEngine
         Me.DialogResult = System.Windows.Forms.DialogResult.None
      End Try
   End Sub

   Private Sub _helpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _helpButton.Click
      Try
         Dim helpFile As String = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "OCRSpellCheckEngines.html")
         Process.Start(helpFile)
      Catch ex As Exception
         MessageBox.Show(Me, ex.Message, "Help", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub
End Class
