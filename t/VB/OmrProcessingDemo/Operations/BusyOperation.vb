Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

Class BusyOperation
   Protected useWaitWindow As Boolean = True
   Private thread As Thread
   Shared ww As WaitWindow
   Private autoReset As AutoResetEvent = New AutoResetEvent(False)

   Public Sub New()
      thread = New Thread(New ThreadStart(AddressOf StartThread))
      ww = New WaitWindow()
   End Sub

   Public Sub Start()
      thread.Start()

      If thread.IsAlive AndAlso useWaitWindow Then
         ww.ShowDialog()
      End If

      WaitHandle.WaitAny(New WaitHandle() {Me.autoReset})
   End Sub

   Protected Overridable Sub Run()
   End Sub

   Protected Overridable Sub StartThread()
      Try
         Run()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Complete()
      End Try
   End Sub

   Protected Sub Progress(ByVal percentage As Integer, ByVal message As String)
      Dim p As Action = New Action(Sub()
                                      ww.lblDisplay.Text = If(String.IsNullOrWhiteSpace(message), ww.lblDisplay.Text, message)

                                      If percentage > ww.pbar.Maximum Then
                                         ww.pbar.Style = ProgressBarStyle.Marquee
                                      Else
                                         ww.pbar.Style = ProgressBarStyle.Continuous
                                         ww.pbar.Value = percentage
                                      End If
                                   End Sub)
      Migrate(p)
   End Sub

   Protected Sub Complete()
      Dim p As Action = New Action(Sub()

                                      If ww.Visible Then
                                         ww.Close()
                                      End If
                                   End Sub)
      Migrate(p)
      autoReset.Set()
   End Sub

   Private Sub ShowError(ByVal ex As Exception)
      Dim p As Action = New Action(Sub()
                                      ww.lblDisplay.Text = ex.Message
                                      MessageBox.Show(ex.Message)
                                   End Sub)
      Migrate(p)
   End Sub

   Private Sub Migrate(ByVal p As Action)
      If ww.InvokeRequired Then
         ww.Invoke(p)
      ElseIf ww.IsHandleCreated Then
         p()
      End If
   End Sub
End Class
