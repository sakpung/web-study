' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms


''' <summary>
''' Summary description for PdfOptionsDialog.
''' </summary>
Public Class PdfOptionsDialog : Inherits System.Windows.Forms.Form
   Private WithEvents _tbSegmentQuality As System.Windows.Forms.TextBox
   Private WithEvents _cmboOutputImageQuality As System.Windows.Forms.ComboBox
   Private WithEvents _cmboInputImageQuality As System.Windows.Forms.ComboBox
   Private WithEvents _tbColorThreshold As System.Windows.Forms.TextBox
   Private WithEvents _tbPageOrder As System.Windows.Forms.TextBox
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOK As System.Windows.Forms.Button
   Private WithEvents _tbCleanSize As System.Windows.Forms.TextBox
   Private _gbOutPutImageQuality As System.Windows.Forms.GroupBox
   Private _lblSegmentQuality As System.Windows.Forms.Label
   Private _lblColorThreshold As System.Windows.Forms.Label
   Private _gbPdfPage As System.Windows.Forms.GroupBox
   Private _lblPageOrder As System.Windows.Forms.Label
   Private WithEvents _cbDisableMRC As System.Windows.Forms.CheckBox
   Private _gbPdfMRCSettings As System.Windows.Forms.GroupBox
   Private _gbInputImageQuality As System.Windows.Forms.GroupBox
   Private WithEvents _tbBackgroundThreshold As System.Windows.Forms.TextBox
   Private _lblCleanSize As System.Windows.Forms.Label
   Private _lblCombineThreshold As System.Windows.Forms.Label
   Private WithEvents _tbCombineThreshold As System.Windows.Forms.TextBox
   Private _lblBackgroundThreshold As System.Windows.Forms.Label
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
      Me._tbSegmentQuality = New System.Windows.Forms.TextBox()
      Me._cmboOutputImageQuality = New System.Windows.Forms.ComboBox()
      Me._cmboInputImageQuality = New System.Windows.Forms.ComboBox()
      Me._tbColorThreshold = New System.Windows.Forms.TextBox()
      Me._tbPageOrder = New System.Windows.Forms.TextBox()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOK = New System.Windows.Forms.Button()
      Me._tbCleanSize = New System.Windows.Forms.TextBox()
      Me._gbOutPutImageQuality = New System.Windows.Forms.GroupBox()
      Me._lblSegmentQuality = New System.Windows.Forms.Label()
      Me._lblColorThreshold = New System.Windows.Forms.Label()
      Me._gbPdfPage = New System.Windows.Forms.GroupBox()
      Me._lblPageOrder = New System.Windows.Forms.Label()
      Me._cbDisableMRC = New System.Windows.Forms.CheckBox()
      Me._gbPdfMRCSettings = New System.Windows.Forms.GroupBox()
      Me._gbInputImageQuality = New System.Windows.Forms.GroupBox()
      Me._tbBackgroundThreshold = New System.Windows.Forms.TextBox()
      Me._lblCleanSize = New System.Windows.Forms.Label()
      Me._lblCombineThreshold = New System.Windows.Forms.Label()
      Me._lblBackgroundThreshold = New System.Windows.Forms.Label()
      Me._tbCombineThreshold = New System.Windows.Forms.TextBox()
      Me._gbOutPutImageQuality.SuspendLayout()
      Me._gbPdfPage.SuspendLayout()
      Me._gbInputImageQuality.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _tbSegmentQuality
      ' 
      Me._tbSegmentQuality.Location = New System.Drawing.Point(220, 384)
      Me._tbSegmentQuality.Name = "_tbSegmentQuality"
      Me._tbSegmentQuality.Size = New System.Drawing.Size(40, 20)
      Me._tbSegmentQuality.TabIndex = 8
      Me._tbSegmentQuality.Text = ""
      '		 Me._tbSegmentQuality.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._tbPageOrder_KeyPress);
      ' 
      ' _cmboOutputImageQuality
      ' 
      Me._cmboOutputImageQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmboOutputImageQuality.Location = New System.Drawing.Point(76, 343)
      Me._cmboOutputImageQuality.Name = "_cmboOutputImageQuality"
      Me._cmboOutputImageQuality.Size = New System.Drawing.Size(208, 21)
      Me._cmboOutputImageQuality.TabIndex = 7
      '		 Me._cmboOutputImageQuality.SelectedIndexChanged += New System.EventHandler(Me._cmboOutputImageQuality_SelectedIndexChanged);
      ' 
      ' _cmboInputImageQuality
      ' 
      Me._cmboInputImageQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmboInputImageQuality.Location = New System.Drawing.Point(76, 159)
      Me._cmboInputImageQuality.Name = "_cmboInputImageQuality"
      Me._cmboInputImageQuality.Size = New System.Drawing.Size(208, 21)
      Me._cmboInputImageQuality.TabIndex = 4
      '		 Me._cmboInputImageQuality.SelectedIndexChanged += New System.EventHandler(Me._cmboInputImageQuality_SelectedIndexChanged);
      ' 
      ' _tbColorThreshold
      ' 
      Me._tbColorThreshold.Location = New System.Drawing.Point(220, 416)
      Me._tbColorThreshold.Name = "_tbColorThreshold"
      Me._tbColorThreshold.Size = New System.Drawing.Size(40, 20)
      Me._tbColorThreshold.TabIndex = 9
      Me._tbColorThreshold.Text = ""
      '		 Me._tbColorThreshold.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._tbPageOrder_KeyPress);
      ' 
      ' _tbPageOrder
      ' 
      Me._tbPageOrder.Location = New System.Drawing.Point(172, 32)
      Me._tbPageOrder.Name = "_tbPageOrder"
      Me._tbPageOrder.Size = New System.Drawing.Size(40, 20)
      Me._tbPageOrder.TabIndex = 1
      Me._tbPageOrder.Text = ""
      '		 Me._tbPageOrder.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._tbPageOrder_KeyPress);
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(220, 471)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(112, 24)
      Me._btnCancel.TabIndex = 11
      Me._btnCancel.Text = "Cancel"
      ' 
      ' _btnOK
      ' 
      Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOK.Location = New System.Drawing.Point(36, 471)
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.Size = New System.Drawing.Size(112, 24)
      Me._btnOK.TabIndex = 10
      Me._btnOK.Text = "ADD"
      '		 Me._btnOK.Click += New System.EventHandler(Me._btnOK_Click);
      ' 
      ' _tbCleanSize
      ' 
      Me._tbCleanSize.Location = New System.Drawing.Point(220, 271)
      Me._tbCleanSize.Name = "_tbCleanSize"
      Me._tbCleanSize.Size = New System.Drawing.Size(40, 20)
      Me._tbCleanSize.TabIndex = 5
      Me._tbCleanSize.Text = ""
      '		 Me._tbCleanSize.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._tbPageOrder_KeyPress);
      ' 
      ' _gbOutPutImageQuality
      ' 
      Me._gbOutPutImageQuality.Controls.Add(Me._lblSegmentQuality)
      Me._gbOutPutImageQuality.Controls.Add(Me._lblColorThreshold)
      Me._gbOutPutImageQuality.Location = New System.Drawing.Point(36, 311)
      Me._gbOutPutImageQuality.Name = "_gbOutPutImageQuality"
      Me._gbOutPutImageQuality.Size = New System.Drawing.Size(296, 144)
      Me._gbOutPutImageQuality.TabIndex = 6
      Me._gbOutPutImageQuality.TabStop = False
      Me._gbOutPutImageQuality.Text = "O&utput Image Quality"
      ' 
      ' _lblSegmentQuality
      ' 
      Me._lblSegmentQuality.Location = New System.Drawing.Point(56, 72)
      Me._lblSegmentQuality.Name = "_lblSegmentQuality"
      Me._lblSegmentQuality.TabIndex = 0
      Me._lblSegmentQuality.Text = "Segment &Quality"
      ' 
      ' _lblColorThreshold
      ' 
      Me._lblColorThreshold.Location = New System.Drawing.Point(56, 104)
      Me._lblColorThreshold.Name = "_lblColorThreshold"
      Me._lblColorThreshold.Size = New System.Drawing.Size(100, 16)
      Me._lblColorThreshold.TabIndex = 1
      Me._lblColorThreshold.Text = "C&olor Threshold"
      ' 
      ' _gbPdfPage
      ' 
      Me._gbPdfPage.Controls.Add(Me._lblPageOrder)
      Me._gbPdfPage.Controls.Add(Me._cbDisableMRC)
      Me._gbPdfPage.Location = New System.Drawing.Point(20, 7)
      Me._gbPdfPage.Name = "_gbPdfPage"
      Me._gbPdfPage.Size = New System.Drawing.Size(336, 96)
      Me._gbPdfPage.TabIndex = 0
      Me._gbPdfPage.TabStop = False
      Me._gbPdfPage.Text = "Pdf &Page"
      ' 
      ' _lblPageOrder
      ' 
      Me._lblPageOrder.Location = New System.Drawing.Point(16, 24)
      Me._lblPageOrder.Name = "_lblPageOrder"
      Me._lblPageOrder.Size = New System.Drawing.Size(120, 16)
      Me._lblPageOrder.TabIndex = 0
      Me._lblPageOrder.Text = "Page &Order in Pdf"
      ' 
      ' _cbDisableMRC
      ' 
      Me._cbDisableMRC.Location = New System.Drawing.Point(24, 56)
      Me._cbDisableMRC.Name = "_cbDisableMRC"
      Me._cbDisableMRC.Size = New System.Drawing.Size(224, 16)
      Me._cbDisableMRC.TabIndex = 1
      Me._cbDisableMRC.Text = "&Disable MRC, Save with NO MRC"
      '		 Me._cbDisableMRC.CheckedChanged += New System.EventHandler(Me._cbDisableMRC_CheckedChanged);
      ' 
      ' _gbPdfMRCSettings
      ' 
      Me._gbPdfMRCSettings.Location = New System.Drawing.Point(20, 111)
      Me._gbPdfMRCSettings.Name = "_gbPdfMRCSettings"
      Me._gbPdfMRCSettings.Size = New System.Drawing.Size(336, 352)
      Me._gbPdfMRCSettings.TabIndex = 2
      Me._gbPdfMRCSettings.TabStop = False
      Me._gbPdfMRCSettings.Text = "Pdf &MRC Settings"
      ' 
      ' _gbInputImageQuality
      ' 
      Me._gbInputImageQuality.Controls.Add(Me._tbBackgroundThreshold)
      Me._gbInputImageQuality.Controls.Add(Me._lblCleanSize)
      Me._gbInputImageQuality.Controls.Add(Me._lblCombineThreshold)
      Me._gbInputImageQuality.Controls.Add(Me._lblBackgroundThreshold)
      Me._gbInputImageQuality.Controls.Add(Me._tbCombineThreshold)
      Me._gbInputImageQuality.Location = New System.Drawing.Point(44, 135)
      Me._gbInputImageQuality.Name = "_gbInputImageQuality"
      Me._gbInputImageQuality.Size = New System.Drawing.Size(288, 168)
      Me._gbInputImageQuality.TabIndex = 3
      Me._gbInputImageQuality.TabStop = False
      Me._gbInputImageQuality.Text = "I&nput Image Quality"
      ' 
      ' _tbBackgroundThreshold
      ' 
      Me._tbBackgroundThreshold.Location = New System.Drawing.Point(176, 72)
      Me._tbBackgroundThreshold.Name = "_tbBackgroundThreshold"
      Me._tbBackgroundThreshold.Size = New System.Drawing.Size(40, 20)
      Me._tbBackgroundThreshold.TabIndex = 1
      Me._tbBackgroundThreshold.Text = ""
      '		 Me._tbBackgroundThreshold.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._tbPageOrder_KeyPress);
      ' 
      ' _lblCleanSize
      ' 
      Me._lblCleanSize.Location = New System.Drawing.Point(32, 136)
      Me._lblCleanSize.Name = "_lblCleanSize"
      Me._lblCleanSize.Size = New System.Drawing.Size(72, 16)
      Me._lblCleanSize.TabIndex = 4
      Me._lblCleanSize.Text = "C&lean Size"
      ' 
      ' _lblCombineThreshold
      ' 
      Me._lblCombineThreshold.Location = New System.Drawing.Point(32, 104)
      Me._lblCombineThreshold.Name = "_lblCombineThreshold"
      Me._lblCombineThreshold.Size = New System.Drawing.Size(112, 16)
      Me._lblCombineThreshold.TabIndex = 2
      Me._lblCombineThreshold.Text = "Co&mbine Threshold"
      ' 
      ' _lblBackgroundThreshold
      ' 
      Me._lblBackgroundThreshold.Location = New System.Drawing.Point(32, 72)
      Me._lblBackgroundThreshold.Name = "_lblBackgroundThreshold"
      Me._lblBackgroundThreshold.Size = New System.Drawing.Size(128, 16)
      Me._lblBackgroundThreshold.TabIndex = 0
      Me._lblBackgroundThreshold.Text = "Back&ground Threshold"
      ' 
      ' _tbCombineThreshold
      ' 
      Me._tbCombineThreshold.Location = New System.Drawing.Point(176, 104)
      Me._tbCombineThreshold.Name = "_tbCombineThreshold"
      Me._tbCombineThreshold.Size = New System.Drawing.Size(40, 20)
      Me._tbCombineThreshold.TabIndex = 3
      Me._tbCombineThreshold.Text = ""
      '		 Me._tbCombineThreshold.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._tbPageOrder_KeyPress);
      ' 
      ' PdfOptionsDialog
      ' 
      Me.AcceptButton = Me._btnOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(376, 502)
      Me.Controls.Add(Me._tbSegmentQuality)
      Me.Controls.Add(Me._cmboOutputImageQuality)
      Me.Controls.Add(Me._cmboInputImageQuality)
      Me.Controls.Add(Me._tbColorThreshold)
      Me.Controls.Add(Me._tbPageOrder)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOK)
      Me.Controls.Add(Me._tbCleanSize)
      Me.Controls.Add(Me._gbOutPutImageQuality)
      Me.Controls.Add(Me._gbPdfPage)
      Me.Controls.Add(Me._gbInputImageQuality)
      Me.Controls.Add(Me._gbPdfMRCSettings)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PdfOptionsDialog"
      Me.ShowInTaskbar = False
      Me.Text = "Pdf Options"
      '		 Me.Load += New System.EventHandler(Me.PdfOptionsDialog_Load);
      Me._gbOutPutImageQuality.ResumeLayout(False)
      Me._gbPdfPage.ResumeLayout(False)
      Me._gbInputImageQuality.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
#End Region

   Friend Property StandardOptions() As PdfStandardOptions
      Get
         Return _standardOptions
      End Get
      Set(value As PdfStandardOptions)
         _standardOptions = value
      End Set
   End Property

   Private Structure ComboBoxItem
      Public Value As Integer
      Public Name As String

      Public Sub New(ByVal val As Integer, ByVal n As String)
         Value = val
         Name = n
      End Sub

      Public Overrides Function ToString() As String
         Return Name
      End Function
   End Structure

   Private Shared ReadOnly _InputImageProfile As ComboBoxItem() = {New ComboBoxItem(0, "Auto Select"), New ComboBoxItem(1, "Noisy Image"), New ComboBoxItem(2, "Scanned Image"), New ComboBoxItem(3, "Printed Image"), New ComboBoxItem(4, "Computer Generated Image"), New ComboBoxItem(5, "Photo Image"), New ComboBoxItem(6, "User Defined")}


   Private Shared ReadOnly _OutputImageProfile As ComboBoxItem() = {New ComboBoxItem(0, "Auto Select"), New ComboBoxItem(1, "Poor Quality"), New ComboBoxItem(2, "Average Quality"), New ComboBoxItem(3, "Good Quality"), New ComboBoxItem(4, "Excellent Quality"), New ComboBoxItem(5, "User Defined")}


   Private _standardOptions As PdfStandardOptions

   Private Sub _tbPageOrder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _tbSegmentQuality.KeyPress, _tbColorThreshold.KeyPress, _tbPageOrder.KeyPress, _tbCleanSize.KeyPress, _tbBackgroundThreshold.KeyPress, _tbCombineThreshold.KeyPress
      If (Not Char.IsNumber(e.KeyChar)) AndAlso (Not Char.IsControl(e.KeyChar)) Then
         e.Handled = True
      End If
   End Sub



   Private Sub UpdateControls()
      If _cmboInputImageQuality.SelectedIndex = _InputImageProfile(6).Value AndAlso (Not _cbDisableMRC.Checked) Then
         _tbBackgroundThreshold.Enabled = True
         _tbCombineThreshold.Enabled = True
         _tbCleanSize.Enabled = True
      Else
         _tbBackgroundThreshold.Enabled = False
         _tbCombineThreshold.Enabled = False
         _tbCleanSize.Enabled = False
      End If

      If _cmboOutputImageQuality.SelectedIndex = _OutputImageProfile(5).Value AndAlso (Not _cbDisableMRC.Checked) Then
         _tbSegmentQuality.Enabled = True
         _tbColorThreshold.Enabled = True
      Else
         _tbSegmentQuality.Enabled = False
         _tbColorThreshold.Enabled = False
      End If

      If _cbDisableMRC.Checked Then
         _cmboInputImageQuality.Enabled = False
         _cmboOutputImageQuality.Enabled = False
      Else
         _cmboInputImageQuality.Enabled = True
         _cmboOutputImageQuality.Enabled = True
      End If

      SetProfileValues()
   End Sub

   Private Sub SetProfileValues()
      Select Case _cmboInputImageQuality.SelectedIndex
         Case 0
            _tbCombineThreshold.Text = "100"
            _tbBackgroundThreshold.Text = "15"
            _tbCleanSize.Text = "7"

         Case 1
            _tbCombineThreshold.Text = "125"
            _tbBackgroundThreshold.Text = "25"
            _tbCleanSize.Text = "10"

         Case 2
            _tbCombineThreshold.Text = "125"
            _tbBackgroundThreshold.Text = "15"
            _tbCleanSize.Text = "8"

         Case 3
            _tbCombineThreshold.Text = "100"
            _tbBackgroundThreshold.Text = "10"
            _tbCleanSize.Text = "7"

         Case 4
            _tbCombineThreshold.Text = "75"
            _tbBackgroundThreshold.Text = "10"
            _tbCleanSize.Text = "3"

         Case 5
            _tbCombineThreshold.Text = "75"
            _tbBackgroundThreshold.Text = "0"
            _tbCleanSize.Text = "3"
      End Select

      Select Case _cmboOutputImageQuality.SelectedIndex
         Case 0
            _tbSegmentQuality.Text = "50"
            _tbColorThreshold.Text = "25"

         Case 1
            _tbSegmentQuality.Text = "0"
            _tbColorThreshold.Text = "30"

         Case 2
            _tbSegmentQuality.Text = "50"
            _tbColorThreshold.Text = "25"

         Case 3
            _tbSegmentQuality.Text = "75"
            _tbColorThreshold.Text = "25"

         Case 4
            _tbSegmentQuality.Text = "100"
            _tbColorThreshold.Text = "25"
      End Select
   End Sub

   Private Sub PdfOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      SetDialog()
   End Sub

   Private Sub SetDialog()
      For Each i As ComboBoxItem In _InputImageProfile
         _cmboInputImageQuality.Items.Add(i)
         If StandardOptions.InputImageComboSel = i.Value Then
            _cmboInputImageQuality.SelectedItem = i
         End If
      Next i


      For Each i As ComboBoxItem In _OutputImageProfile
         _cmboOutputImageQuality.Items.Add(i)
         If StandardOptions.OutputImageComboSel = i.Value Then
            _cmboOutputImageQuality.SelectedItem = i
         End If
      Next i

      If StandardOptions.Added Then
         _cbDisableMRC.Checked = StandardOptions.NOMRC
         _tbBackgroundThreshold.Text = StandardOptions.BKThreshold.ToString()
         _tbCleanSize.Text = StandardOptions.CleanSize.ToString()
         _tbColorThreshold.Text = StandardOptions.CLRThreshold.ToString()
         _tbCombineThreshold.Text = StandardOptions.CombThreshold.ToString()
         _tbSegmentQuality.Text = StandardOptions.SegQuality.ToString()
         _tbPageOrder.Text = StandardOptions.PageNumber.ToString()
         _btnOK.Text = "Update"
      Else
         _tbPageOrder.Text = String.Format("0")
      End If
   End Sub


   Private Sub _cmboInputImageQuality_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmboInputImageQuality.SelectedIndexChanged
      UpdateControls()
   End Sub


   Private Sub _cmboOutputImageQuality_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmboOutputImageQuality.SelectedIndexChanged
      UpdateControls()
   End Sub

   Private Sub _cbDisableMRC_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbDisableMRC.CheckedChanged
      UpdateControls()
   End Sub

   Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOK.Click
      Dim nBKThreshold As Integer
      Dim nCleanSize As Integer
      Dim nCLRThreshold As Integer
      Dim nCombThreshold As Integer
      Dim nSegQuality As Integer
      Dim nPageOrder As Integer




      If (Not DialogUtilities.ParseInteger(_tbBackgroundThreshold, "Background Threshold", 0, True, 100, True, True, nBKThreshold)) Then
         Return
      Else
         StandardOptions.BKThreshold = nBKThreshold
      End If

      If (Not DialogUtilities.ParseInteger(_tbCleanSize, "Clean Size", 0, True, 10, True, True, nCleanSize)) Then
         Return
      Else
         StandardOptions.CleanSize = nCleanSize
      End If

      If (Not DialogUtilities.ParseInteger(_tbColorThreshold, "Color Threshold", 0, True, 100, True, True, nCLRThreshold)) Then
         Return
      Else
         StandardOptions.CLRThreshold = nCLRThreshold
      End If

      If (Not DialogUtilities.ParseInteger(_tbCombineThreshold, "Combined Threshold", 0, True, 300, True, True, nCombThreshold)) Then
         Return
      Else
         StandardOptions.CombThreshold = nCombThreshold
      End If

      If (Not DialogUtilities.ParseInteger(_tbSegmentQuality, "Segment Quality", 0, True, 100, True, True, nSegQuality)) Then
         Return
      Else
         StandardOptions.SegQuality = nSegQuality
      End If

      If (Not DialogUtilities.ParseInteger(_tbPageOrder, "Page Order", 0, True, Me.Owner.MdiChildren.Length - 1, True, True, nPageOrder)) Then
         Return
      Else
         If CheckPagesOrder() Then
            SetPageOrder()
         End If
         StandardOptions.PageNumber = nPageOrder
      End If
      StandardOptions.Added = True
      StandardOptions.NOMRC = _cbDisableMRC.Checked
      StandardOptions.InputImageComboSel = _cmboInputImageQuality.SelectedIndex
      StandardOptions.OutputImageComboSel = _cmboOutputImageQuality.SelectedIndex

   End Sub

   Private Function CheckPagesOrder() As Boolean
      Try
         Dim value As Integer
         value = Integer.Parse(_tbPageOrder.Text)

         Dim i As Integer = 0
         Do While i < Me.Owner.MdiChildren.Length
            If (CType(Me.Owner.ActiveMdiChild, ViewerForm)) IsNot (CType(Me.Owner.MdiChildren(i), ViewerForm)) Then
               If (CType(Me.Owner.MdiChildren(i), ViewerForm)).StandardOptions.Added AndAlso value = (CType(Me.Owner.MdiChildren(i), ViewerForm)).StandardOptions.PageNumber Then
                  Messager.ShowWarning(Me, "Page numbers for other pages were modified since this number already exists")
                  Return True
               End If
            End If
            i += 1
         Loop
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try

      Return False

   End Function

   Private Sub SetPageOrder()
      Dim value As Integer
      value = Integer.Parse(_tbPageOrder.Text)

      Dim i As Integer = 0
      Do While i < Me.Owner.MdiChildren.Length
         If (Not StandardOptions.Added) AndAlso (CType(Me.Owner.MdiChildren(i), ViewerForm)).StandardOptions.PageNumber >= value Then
            CType(Me.Owner.MdiChildren(i), ViewerForm).StandardOptions.PageNumber += 1
         ElseIf StandardOptions.Added AndAlso (CType(Me.Owner.MdiChildren(i), ViewerForm)).StandardOptions.PageNumber = value Then
            CType(Me.Owner.MdiChildren(i), ViewerForm).StandardOptions.PageNumber = StandardOptions.PageNumber
         End If
         i += 1
      Loop
   End Sub



End Class

