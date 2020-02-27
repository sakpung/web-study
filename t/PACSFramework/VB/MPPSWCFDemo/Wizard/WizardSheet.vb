' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Diagnostics
Imports Leadtools.Demos

Namespace Leadtools.Wizard
   Partial Public Class WizardSheet
      Inherits UserControl
#Region "Public"

#Region "Methods"

      Public Sub New()
         Try
            InitializeComponent()

            Init()

            RegisterEvents()
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub

      Public Sub SetActivePage(ByVal pageIndex As Integer)
         Try
            Dim page As WizardPage

            If pageIndex < 0 OrElse pageIndex >= Pages.Count Then
               Throw New ArgumentOutOfRangeException("pageIndex")
            End If

            page = Pages(pageIndex)

            SetActivePage(page)
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub

      Public Sub Reset()
         For Each page As WizardPage In Pages
            page.OnReset()
         Next page
      End Sub

#End Region

#Region "Properties"

      Public Property Pages() As WizardPagesCollection
         Get
            Return m_pages
         End Get

         Private Set(ByVal value As WizardPagesCollection)
            m_pages = value
         End Set
      End Property

      Public ReadOnly Property NextButton() As Button
         Get
            Return btnNext
         End Get
      End Property

#End Region

      Private _Option1Caption As String = String.Empty

      Public Property Option1Caption() As String
         Get
            Return buttonOption1.Text
         End Get
         Set(ByVal value As String)
            buttonOption1.Text = value
         End Set
      End Property


#Region "Events"

      Public Event NextPage As EventHandler(Of WizardPageEventArgs)
      Public Event PreviousPage As EventHandler(Of WizardPageEventArgs)
      Public Event WizardInstalling As EventHandler(Of WizardPageEventArgs)
      Public Event WizardUninstalling As EventHandler(Of WizardPageEventArgs)
      Public Event WizardFinished As CancelEventHandler
      Public Event WizardCanceled As CancelEventHandler
      Public Event About As EventHandler

#End Region

#Region "Data Types Definition"

      <Flags()>
      Public Enum WizardButtons
         None = 0
         Back = 1
         [Next] = 2
         Finish = 4
         Cancel = 8
         About = 16
         Option1 = 32
      End Enum

#End Region

#Region "Callbacks"

#End Region

#End Region

#Region "Protected"

#Region "Methods"

      Protected Sub OnNextPage(ByVal wnea As WizardPageEventArgs)
         If Nothing IsNot NextPageEvent Then
            RaiseEvent NextPage(Me, wnea)
         End If
      End Sub

      Protected Sub OnPrevioustPage(ByVal wnea As WizardPageEventArgs)
         If Nothing IsNot PreviousPageEvent Then
            RaiseEvent PreviousPage(Me, wnea)
         End If
      End Sub

      Protected Sub OnWizardFinished(ByVal sender As Object, ByVal e As CancelEventArgs)
         Try
            If Nothing IsNot WizardFinishedEvent Then
               RaiseEvent WizardFinished(sender, e)
            End If
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub

      Protected Sub OnWizardCanceled(ByVal sender As Object, ByVal e As CancelEventArgs)
         Try
            If Nothing IsNot WizardCanceledEvent Then
               RaiseEvent WizardCanceled(sender, e)
            End If
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub

      Protected Sub OnWizardInstalling(ByVal sender As Object, ByVal e As WizardPageEventArgs)
         Try
            If Nothing IsNot WizardInstallingEvent Then
               RaiseEvent WizardInstalling(sender, e)
            End If
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub

      Protected Sub OnWizardUninstalling(ByVal sender As Object, ByVal e As WizardPageEventArgs)
         Try
            If Nothing IsNot WizardUninstallingEvent Then
               RaiseEvent WizardUninstalling(sender, e)
            End If
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub

      Protected Overrides Sub OnParentChanged(ByVal e As EventArgs)
         Try
            If Parent IsNot Nothing AndAlso ParentForm IsNot Nothing Then
               ParentForm.AcceptButton = btnNext
               ParentForm.CancelButton = btnCancel
            End If

            MyBase.OnParentChanged(e)
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

      Private Sub Init()
         Try
            Pages = New WizardPagesCollection(Me)
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub

      Private Sub RegisterEvents()
         Try
            AddHandler Load, AddressOf WizardSheet_Load
            AddHandler btnNext.Click, AddressOf btnNext_Click
            AddHandler btnBack.Click, AddressOf btnBack_Click
            AddHandler btnFinish.Click, AddressOf btnFinish_Click
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            AddHandler buttonOption1.Click, AddressOf buttonOption1_Click
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub

      Private Sub ResizeToFit()
         Try
            Dim maxPageSize As Size
            Dim extraSize As Size
            Dim newSize As Size


            maxPageSize = New Size(pnlButtons.Width, 0)

            For Each page As WizardPage In Pages
               If page.Width > maxPageSize.Width Then
                  maxPageSize.Width = page.Width
               End If

               If page.Height > maxPageSize.Height Then
                  maxPageSize.Height = page.Height
               End If
            Next page

            For Each page As WizardPage In Pages
               page.Size = maxPageSize
               page.Dock = DockStyle.Fill
            Next page

            extraSize = Me.Size

            extraSize -= pnlPages.Size

            newSize = maxPageSize + extraSize

            Me.Size = newSize
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub

      Private Sub SetActivePage(ByVal newPage As WizardPage)
         Try
            Dim oldActivePage As WizardPage
            Dim e As WizardCancelEventArgs


            oldActivePage = __ActivePage

            If (Not pnlPages.Controls.Contains(newPage)) Then
               pnlPages.Controls.Add(newPage)
            End If

            newPage.Visible = True
            newPage.Dock = DockStyle.Fill

            If oldActivePage IsNot Nothing Then
               oldActivePage.Visible = False
            End If

            __ActivePage = newPage

            e = New WizardCancelEventArgs()
            e.PreviousPage = oldActivePage

            newPage.OnSetActive(Me, e)

            If e.Cancel Then
               newPage.Visible = False

               __ActivePage = oldActivePage
            End If

            For Each page As WizardPage In Pages
               If page IsNot __ActivePage Then
                  page.Visible = False
               End If
            Next page
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try

      End Sub

#End Region

#Region "Properties"


      Private __ActivePage As WizardPage

      Public ReadOnly Property ActivePage() As WizardPage
         Get
            Return __ActivePage
         End Get
      End Property

#End Region

#Region "Events"

      Private Sub WizardSheet_Load(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Pages.Count <> 0 Then
               ResizeToFit()

               SetActivePage(0)
            Else
               SetWizardButtons(WizardButtons.None)
            End If

            If Me.ParentForm IsNot Nothing Then
               Me.ParentForm.Activate()
            End If
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub

      Private Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            Dim wnea As WizardPageEventArgs

            wnea = New WizardPageEventArgs(__ActivePage)
            If __ActivePage IsNot Nothing Then
               Dim index As Integer = Pages.IndexOf(__ActivePage)

               If index < Pages.Count - 1 Then
                  wnea.NewPage = Pages(index + 1)
               End If
            End If

            OnNextPage(wnea)

            If (Not wnea.Cancel) Then
               __ActivePage.OnWizardNext(Me, wnea)

               If (Not wnea.Cancel) Then
                  If Nothing IsNot wnea.NewPage Then
                     wnea.NewPage.ParentWizard = Me
                     wnea.NewPage.PreviousPage = __ActivePage

                     SetActivePage(wnea.NewPage)
                  End If
               End If
            End If
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub

      Private Sub btnBack_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            Dim wnea As WizardPageEventArgs


            wnea = New WizardPageEventArgs(__ActivePage)

            wnea.NewPage = __ActivePage.PreviousPage

            OnPrevioustPage(wnea)

            If (Not wnea.Cancel) Then
               __ActivePage.OnWizardBack(Me, wnea)

               If (Not wnea.Cancel) Then
                  If Nothing IsNot wnea.NewPage Then
                     wnea.NewPage.ParentWizard = Me

                     SetActivePage(wnea.NewPage)
                  End If
               End If
            End If
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub


      Private Sub btnFinish_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            Dim cea As CancelEventArgs


            cea = New CancelEventArgs(False)

            __ActivePage.OnWizardFinish(Me, cea)

            If (Not cea.Cancel) Then
               OnWizardFinished(Me, cea)
            End If

            If (Not cea.Cancel) Then
               Application.Exit(cea)
            End If
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Sub

      Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            Dim cea As CancelEventArgs


            cea = New CancelEventArgs(False)

            __ActivePage.OnWizardCancel(Me, cea)

            OnWizardCanceled(Me, cea)

            If (Not cea.Cancel) Then
               Application.Exit(cea)

               Return

            End If
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         Finally
         End Try
      End Sub

      Private Sub buttonOption1_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            __ActivePage.OnOptionButton1(sender, e)
         Catch exception As Exception
            Debug.Assert(False, exception.Message)
            Throw
         End Try
      End Sub

#End Region

#Region "Data Members"

      Private m_pages As WizardPagesCollection

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "internal"

#Region "Methods"

      Friend Sub SetWizardButtons(ByVal buttons As WizardButtons)
         ' The Back button is simple.
         btnBack.Enabled = ((buttons And WizardButtons.Back) <> 0)
         btnCancel.Enabled = ((buttons And WizardButtons.Cancel) <> 0)

         btnFinish.Visible = ((buttons And WizardButtons.Finish) <> 0)
         btnFinish.Enabled = ((buttons And WizardButtons.Finish) <> 0)

         btnNext.Visible = True
         btnNext.Enabled = ((buttons And WizardButtons.Next) <> 0)

         buttonAbout.Visible = ((buttons And WizardButtons.About) <> 0)
         buttonAbout.Enabled = ((buttons And WizardButtons.About) <> 0)

         buttonOption1.Visible = ((buttons And WizardButtons.Option1) <> 0)
         buttonOption1.Enabled = ((buttons And WizardButtons.Option1) <> 0)

         btnNext.NotifyDefault(True)
      End Sub

#End Region

      Private Sub buttonAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAbout.Click
         RaiseEvent About(Me, EventArgs.Empty)
      End Sub

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region


      Private Sub buttonShowHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonShowHelp.Click
         Dim bHelpFound As Boolean = True
         Try
            Process.Start("https://www.leadtools.com/help/leadtools/v20/dh/to/leadtools-modality-worklist-wcf-and-mpps-wcf.html")
            'DemosGlobal.LaunchHelp2("WCF.Topics.LEADTOOLSModalityWorklistWCFandMPPSWCF")
         Catch e1 As Exception
            bHelpFound = False
         Finally
            If (Not bHelpFound) Then
               Messager.ShowWarning(Me, "Help failed to load.")
            End If
         End Try
      End Sub
   End Class
End Namespace
