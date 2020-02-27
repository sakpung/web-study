Imports Leadtools
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms

Module Program
   <STAThread()>
   Public Sub Main()
      If Support.SetLicense(False) = False Then
         Return
      End If

      If RasterSupport.IsLocked(RasterSupportType.Omr) Then
         MessageBox.Show("OMR support must be unlocked.  Application will exit.")
         Return
      End If

      Try
         MainForm.GetOmrEngine()
      Catch __unusedException1__ As Exception
         MessageBox.Show("Unable to initialize OMR engine.  Application will exit.")
         Return
      End Try

      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New MainForm())
   End Sub
End Module
