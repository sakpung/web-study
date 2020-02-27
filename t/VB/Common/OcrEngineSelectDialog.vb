' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Reflection
Imports Microsoft.Win32

Imports Leadtools
Imports Leadtools.Ocr
Imports Leadtools.Codecs
Imports Leadtools.Document.Writer

Partial Public Class OcrEngineSelectDialog
   Inherits Form
   Private _ocrEngine As IOcrEngine
   Private _selectedOcrEngineType As OcrEngineType
   Private _selectEngineType As String
   Private _autoStart As Boolean
   Private _rasterCodecsInstance As RasterCodecs
   Private _allowNoOcr As Boolean = False

   Private Structure EngineProperty
      Public Name As String
      Public EngineType As OcrEngineType
	  Public RuntimePath As String
      Public RegistryKeyName As String
      Public Installed As Boolean

      Public Overrides Function ToString() As String
         Return Name
      End Function
   End Structure

   Private _engineProperty As EngineProperty
   Private _engineFoundCount As Integer

   Public Sub New(demoName As String, selectEngineType As String, autoStart As Boolean)
      InitializeComponent()

      Text = demoName

      _selectEngineType = selectEngineType
      _autoStart = autoStart
   End Sub

   Public ReadOnly Property OcrEngine() As IOcrEngine
      Get
         Return _ocrEngine
      End Get
   End Property

   Public ReadOnly Property SelectedOcrEngineType() As OcrEngineType
      Get
         Return _selectedOcrEngineType
      End Get
   End Property

   Public Property RasterCodecsInstance() As RasterCodecs
      Get
         Return _rasterCodecsInstance
      End Get
      Set(value As RasterCodecs)
         _rasterCodecsInstance = value
      End Set
   End Property

   Public Property AllowNoOcr() As Boolean
      Get
         Return _allowNoOcr
      End Get
      Set(value As Boolean)
         _allowNoOcr = value
      End Set
   End Property

   Private _allowNoOcrMessage As String
   Public Property AllowNoOcrMessage() As String
      Get
         Return _allowNoOcrMessage
      End Get
      Set(value As String)
         _allowNoOcrMessage = value
      End Set
   End Property

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
    If Not DesignMode Then
         Dim engineProperties As List(Of EngineProperty) = New List(Of EngineProperty)()
        engineProperties.Add(New EngineProperty With {.Name = "LEADTOOLS - LEAD OCR Engine", .EngineType = OcrEngineType.LEAD, .RuntimePath = "LEADTOOLS\OcrLEADRuntime", .RegistryKeyName = "OCRPathLEAD20"})
        If IntPtr.Size = 8 Then
            engineProperties.Add(New EngineProperty With {.Name = "LEADTOOLS - OmniPage OCR Engine", .EngineType = OcrEngineType.OmniPage, .RuntimePath = "LEADTOOLS\OCROmniPageRuntime64", .RegistryKeyName = "OCRPathOmniPage20_64"})
            engineProperties.Add(New EngineProperty With {.Name = "LEADTOOLS - OmniPage Arabic OCR Engine", .EngineType = OcrEngineType.OmniPageArabic, .RuntimePath = "LEADTOOLS\OCROmniPageArabicRuntime64", .RegistryKeyName = "OCRPathOmniPageArabic20_64"})
        Else
            engineProperties.Add(New EngineProperty With {.Name = "LEADTOOLS - OmniPage OCR Engine", .EngineType = OcrEngineType.OmniPage, .RuntimePath = "LEADTOOLS\OCROmniPageRuntime", .RegistryKeyName = "OCRPathOmniPage20"})
            engineProperties.Add(New EngineProperty With {.Name = "LEADTOOLS - OmniPage Arabic OCR Engine", .EngineType = OcrEngineType.OmniPageArabic, .RuntimePath = "LEADTOOLS\OCROmniPageArabicRuntime", .RegistryKeyName = "OCRPathOmniPageArabic20"})
        End If

        If _allowNoOcr AndAlso Not String.IsNullOrEmpty(_allowNoOcrMessage) Then _lblAllowNoOcr.Text = _allowNoOcrMessage
        _engineFoundCount = 0
        For i As Integer = 0 To engineProperties.Count - 1
            Dim engineProperty As EngineProperty = engineProperties(i)
            engineProperty.Installed = IsOcrEngineInstalled(engineProperty.RuntimePath, engineProperty.RegistryKeyName)
            engineProperties(i) = engineProperty
            If engineProperty.Installed Then _engineFoundCount += 1
        Next

        If _allowNoOcr Then
            _btnCancel.Text = "Cancel"
        End If

        If _engineFoundCount = 0 Then
            Dim sb As StringBuilder = New StringBuilder()
            sb.AppendLine("Could not find any LEADTOOLS OCR engine on this machine.")
            sb.AppendLine()
            If Not _allowNoOcr Then
               sb.AppendLine("This demo cannot start without OCR capabilities")
            End If

            sb.AppendLine()
            sb.AppendLine("Consult the LEADTOOLS help or click the link below to download an evaluation version of the LEADTOOLS OCR engines.")
            _lblNoEnginesFound.Text = sb.ToString()
            _tcMain.TabPages.Remove(_tpSelectEngine)
            _tcMain.TabPages.Remove(_tpStartEngine)
            _btnOk.Enabled = False
            _btnOk.Visible = False
        ElseIf _engineFoundCount = 1 AndAlso Not _allowNoOcr Then
            _tcMain.TabPages.Remove(_tpNoEnginesFound)
            _tcMain.TabPages.Remove(_tpSelectEngine)
            For Each engineProperty As EngineProperty In engineProperties
                If engineProperty.Installed Then _engineProperty = engineProperty
            Next

            _btnOk.Enabled = False
            _btnOk.Visible = False
            BeginInvoke(New StartEngineDelegate(AddressOf StartEngine))
        Else
            _tcMain.TabPages.Remove(_tpNoEnginesFound)
            _tcMain.TabPages.Remove(_tpStartEngine)
            For Each engineProperty As EngineProperty In engineProperties
                If engineProperty.Installed Then
                    _cbEngineSelection.Items.Add(engineProperty)
                    If String.Compare(_selectEngineType, engineProperty.EngineType.ToString(), StringComparison.InvariantCultureIgnoreCase) = 0 Then
                        _cbEngineSelection.SelectedItem = engineProperty
                    End If
                End If
            Next

            If _cbEngineSelection.SelectedIndex = -1 Then _cbEngineSelection.SelectedIndex = 0
        End If
    End If

    MyBase.OnLoad(e)
End Sub

   Private Shared Function IsOcrEngineInstalled(ByVal runtimePath As String, ByVal registryKeyName As String) As Boolean
#If LT_CLICKONCE Then
					return true
#Else
      Dim path1 As String = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, runtimePath)
      If Directory.Exists(path1) Then
         Return True
      End If

      'Check the registry. The LEADTOOLS setup adds this
      Dim rk As RegistryKey = OpenSoftwareKey(Convert.ToString("LEAD Technologies, Inc.\") & registryKeyName)
      If rk IsNot Nothing Then
         rk.Close()
         Return True
      Else
         Return False
      End If
#End If
   End Function

   Private Shared Function OpenSoftwareKey(keyName As String) As RegistryKey
      Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey(Convert.ToString("SOFTWARE\Wow6432Node\") & keyName)
      If key Is Nothing Then
         key = Registry.LocalMachine.OpenSubKey(Convert.ToString("SOFTWARE\") & keyName)
         If key Is Nothing Then
            key = Registry.CurrentUser.OpenSubKey(Convert.ToString("SOFTWARE\") & keyName)
         End If
      End If

      Return key
   End Function

   Private Sub _lbDownload_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles _lbDownload.LinkClicked
      System.Diagnostics.Process.Start(_lbDownload.Text)
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      _engineProperty = CType(_cbEngineSelection.SelectedItem, EngineProperty)
      _tcMain.TabPages.Remove(_tpSelectEngine)
      _tcMain.TabPages.Add(_tpStartEngine)

      DialogResult = DialogResult.None

      _btnOk.Enabled = False
      _btnOk.Visible = False

      BeginInvoke(New StartEngineDelegate(AddressOf StartEngine))
   End Sub

   Private Delegate Sub StartEngineDelegate()

   Private Sub StartEngine()
      If _autoStart Then
         _btnCancel.Enabled = False
         _lblDownload.Visible = False
         _lbDownload.Visible = False

         _lblStartEngine.Text = String.Format("Starting up the {0}...", _engineProperty.Name)
         Application.DoEvents()

         Dim ocrEngine As IOcrEngine = Nothing

         Try
#If LEADTOOLS_V18_OR_LATER Then
            If _engineProperty.EngineType = OcrEngineType.OmniPage Then
               ' Check for the existence of .NET Framework 4.0 since Professional V18.0 needs it
               If Not DemosGlobal.IsDotNet4Installed() Then
                  Throw New Exception("This version of OCR Professional engine requires Microsoft .NET framework v4.0, which is not installed on this machine.")
               End If
            End If
#End If

            ocrEngine = OcrEngineManager.CreateEngine(_engineProperty.EngineType, False)

#If LT_CLICKONCE Then
					ocrEngine.Startup(_rasterCodecsInstance, Nothing, Nothing, Application.StartupPath + "\OCR Engine")
#Else
            ocrEngine.Startup(_rasterCodecsInstance, Nothing, Nothing, Nothing)
#End If



            _lblStatus.ForeColor = SystemColors.ControlText

            If _allowNoOcr Then
               _lblStatus.Text = "Success. Continuing with the demo..."
            Else
               _lblStatus.Text = "Success. Starting the demo..."
            End If

            _ocrEngine = ocrEngine
            _selectedOcrEngineType = _engineProperty.EngineType

            ' Set document writer options
            SetDocumentWriterOptions()

            Application.DoEvents()
            System.Threading.Thread.Sleep(1000)
            DialogResult = DialogResult.OK
         Catch ex As Exception
            _lblStatus.ForeColor = Color.Red

            If _allowNoOcr Then
               _lblStatus.Text = String.Format("Error: {0}{1}{1}This demo will continue without OCR capabilities. Consult LEADTOOLS help or support and try again.", ex.Message, Environment.NewLine)
            Else
               _lblStatus.Text = String.Format("Error: {0}{1}{1}This demo cannot start without OCR capabilities. Consult LEADTOOLS help or support and try again.", ex.Message, Environment.NewLine)
            End If

            _lblDownload.Visible = False
            _lbDownload.Visible = False

            If _ocrEngine IsNot Nothing Then
               _ocrEngine.Dispose()
            End If
         Finally
            _btnCancel.Enabled = True
         End Try
      Else
         _ocrEngine = Nothing
         _selectedOcrEngineType = _engineProperty.EngineType
         DialogResult = DialogResult.OK
      End If
   End Sub

   Private Sub SetDocumentWriterOptions()
      Dim docOptions As DocDocumentOptions = TryCast(_ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.Doc), DocDocumentOptions)
      docOptions.TextMode = DocumentTextMode.Framed

      Dim docxOptions As DocxDocumentOptions = TryCast(_ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.Docx), DocxDocumentOptions)
      docxOptions.TextMode = DocumentTextMode.Framed

      Dim rtfOptions As RtfDocumentOptions = TryCast(_ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.Rtf), RtfDocumentOptions)
      rtfOptions.TextMode = DocumentTextMode.Framed

      Dim altoXmlOptions As AltoXmlDocumentOptions = TryCast(_ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.AltoXml), AltoXmlDocumentOptions)
      altoXmlOptions.Formatted = True
   End Sub
End Class
