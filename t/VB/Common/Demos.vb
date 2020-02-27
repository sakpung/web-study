' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.IO
Imports Microsoft.Win32
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Security.Principal
Imports System.Reflection
Imports Microsoft.VisualBasic

Imports Leadtools
Imports Leadtools.Codecs

Public NotInheritable Class DemosGlobal

    Public Shared ReadOnly Property IsOnXP() As Boolean
        Get
            Return Environment.OSVersion.Version.Major = 5
        End Get
    End Property

    Public Shared ReadOnly Property IsOnVista() As Boolean
        Get
            Return Environment.OSVersion.Version.Major >= 6
        End Get
    End Property

    Public Shared ReadOnly Property IsOnWindows7() As Boolean
        Get
            Return (Environment.OSVersion.Version.Major > 6) OrElse (Environment.OSVersion.Version.Major = 6 AndAlso Environment.OSVersion.Version.Minor >= 1)
        End Get
    End Property

    Public Shared ReadOnly Property IsOnWindows2003() As Boolean
        Get
            Return (Environment.OSVersion.Version.Major = 5 AndAlso Environment.OSVersion.Version.Minor = 2)
        End Get
    End Property

    Public Shared ReadOnly Property IsOnWindows2000() As Boolean
        Get
            Return (Environment.OSVersion.Version.Major = 5 AndAlso Environment.OSVersion.Version.Minor = 0)
        End Get
    End Property

    Public Shared ReadOnly Property IsOnVistaOrLater() As Boolean
        Get
            Dim OS As OperatingSystem = Environment.OSVersion
            Return (OS.Platform = PlatformID.Win32NT) AndAlso (OS.Version.Major >= 6)
        End Get
    End Property

    Public Shared Function Is64Process() As Boolean
        Return IntPtr.Size = 8
    End Function

    Public Shared Function NeedUAC() As Boolean
        Dim system As OperatingSystem = Environment.OSVersion

        If system.Platform = PlatformID.Win32NT AndAlso system.Version.Major >= 6 Then
            Return True
        End If

        Return False
    End Function

    Public Shared Function IsAdmin() As Boolean
        Dim id As WindowsIdentity = WindowsIdentity.GetCurrent()
        Dim p As New WindowsPrincipal(id)

        Return p.IsInRole(WindowsBuiltInRole.Administrator)
    End Function

    Public Shared Sub RestartElevated(ByVal args() As String)
        Dim startInfo As New ProcessStartInfo()

        If (System.Diagnostics.Debugger.IsAttached) Then ' Warn Then the user that we need To restart And that debugging will End.
            Dim msg As String = String.Format("{0}: {1}{2}{3}.", Leadtools.Demos.DemosGlobalization.AdminPrivilege, Process.GetCurrentProcess().ProcessName, Environment.NewLine, Leadtools.Demos.DemosGlobalization.DebuggerWarning)
            MessageBox.Show(msg, Leadtools.Demos.DemosGlobalization.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        startInfo.UseShellExecute = True
        startInfo.WorkingDirectory = Environment.CurrentDirectory
        startInfo.FileName = Application.ExecutablePath
        startInfo.Verb = "runas"
        startInfo.Arguments = String.Join(" ", args)
        Try
            Dim p As Process = Process.Start(startInfo)
        Catch e1 As System.ComponentModel.Win32Exception
            Return
        End Try
    End Sub

    Public Shared Function MustRestartElevated() As Boolean
        Return DemosGlobal.NeedUAC() AndAlso Not DemosGlobal.IsAdmin()
    End Function

    Public Shared Sub TryRestartElevated(ByVal args() As String)
        For Each s As String In args
            If String.Compare("/restartElevated", s) = 0 Then
                Dim msg As String = String.Format("{0}: {1}", Leadtools.Demos.DemosGlobalization.AdminPrivilege, Process.GetCurrentProcess().ProcessName)
                MessageBox.Show(msg, Leadtools.Demos.DemosGlobalization.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next s
        Dim argsNew(args.Length) As String
        Array.Copy(args, argsNew, args.Length)
        argsNew(args.Length) = "/restartElevated"

        DemosGlobal.RestartElevated(argsNew)
    End Sub

    <System.Runtime.InteropServices.DllImport("shell32.dll")>
    Private Shared Function SHGetFolderPath(ByVal hwndOwner As IntPtr, ByVal nFolder As Integer, ByVal hToken As IntPtr, ByVal dwFlags As UInteger, <System.Runtime.InteropServices.Out()> ByVal pszPath As System.Text.StringBuilder) As String
   End Function

   Private Shared Function GetCommonDocumentsFolder() As String
      Dim SIDL_COMMON_DOCUMENTS As Integer = &H2E
      Dim sb As New System.Text.StringBuilder(1024)
      SHGetFolderPath(IntPtr.Zero, SIDL_COMMON_DOCUMENTS, IntPtr.Zero, 0, sb)
      Return sb.ToString()
   End Function

   Public Shared ReadOnly Property ImagesFolder() As String
      Get
         Dim imagesPath As String

         ' Check if %PUBLIC%\Documents\LEADTOOLS Images exits first
         Try
            imagesPath = Path.Combine(GetCommonDocumentsFolder(), "LEADTOOLS Images")
            If Directory.Exists(imagesPath) Then
               Return imagesPath
            End If
         Catch
         End Try

         ' Try registry next
#If LTV19_CONFIG Then
         imagesPath = "Software\LEAD Technologies, Inc.\19\Images"
         Dim unicodeImagesPath As String = "Software\LEAD Technologies, Inc.\19\UnicodeImages"
#End If ' #If LTV19_CONFIG Then

#If LTV20_CONFIG Then
         imagesPath = "Software\LEAD Technologies, Inc.\20\Images"
         Dim unicodeImagesPath As String = "Software\LEAD Technologies, Inc.\20\UnicodeImages"
#End If ' #If LTV20_CONFIG Then

         Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey(imagesPath)
         If rk Is Nothing Then
            rk = Registry.LocalMachine.OpenSubKey(unicodeImagesPath)
         End If

         If rk Is Nothing Then
            rk = Registry.LocalMachine.OpenSubKey(imagesPath)
         End If
         If rk Is Nothing Then
            rk = Registry.LocalMachine.OpenSubKey(unicodeImagesPath)
         End If

         If rk IsNot Nothing Then
            Dim value As String = TryCast(rk.GetValue(Nothing), String)
            rk.Close()
            Return value
         End If

         ' Finally, use the current EXE path
         Return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
      End Get
   End Property

   Public Shared Function OpenSoftwareKey(ByVal keyName As String) As RegistryKey
      Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\" & keyName)

      If key Is Nothing Then
         key = Registry.LocalMachine.OpenSubKey("SOFTWARE\" & keyName)
         If key Is Nothing Then
            key = Registry.CurrentUser.OpenSubKey("SOFTWARE\" & keyName)
         End If
      End If

      Return key
   End Function

   Public Shared Function IsDotNet35Installed() As Boolean
      Dim ret As Boolean = False
      Dim rk As RegistryKey = OpenSoftwareKey("\Microsoft\NET Framework Setup\NDP\v3.5")
      If rk IsNot Nothing Then
         ret = True
         rk.Close()

      Else
         ret = False
      End If
      Return ret
   End Function

   Public Shared Function IsDotNet4Installed() As Boolean
      Dim ret As Boolean = False
      Dim rk As RegistryKey = OpenSoftwareKey("\Microsoft\NET Framework Setup\NDP\v4")
      If rk IsNot Nothing Then
         ret = True
         rk.Close()

      Else
         ret = False
      End If
      Return ret
   End Function

    Public Shared Function IsDotNet45OrLaterInstalled() As Boolean
        Const subkey As String = "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"
        Dim dotNet45Installed As Boolean = False
        Using ndpKey As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey)
            If ndpKey IsNot Nothing AndAlso ndpKey.GetValue("Release") IsNot Nothing Then
                dotNet45Installed = True
            Else
                dotNet45Installed = False
            End If
        End Using
        Return dotNet45Installed
    End Function

    Public Shared Function CheckKnown3rdPartyTwainIssues(ByVal window As System.Windows.Forms.IWin32Window, ByVal sourceName As String) As Boolean
      Dim thirdPartyTwainWithKnownProblem As Boolean = False
      Dim continueScan As Boolean = True

      ' The TWAIN2 FreeImage Software Scanner 64-bit has a problem when running under .NET 4.5 or later, check
      Const twain2FreeImageSourceName As String = "TWAIN2 FreeImage Software Scanner"
      If sourceName = twain2FreeImageSourceName AndAlso System.IntPtr.Size = 8 Then
         ' Check if we are running under .NET 4.5 or later
         Dim targetFrameworks As Object() = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(GetType(System.Runtime.Versioning.TargetFrameworkAttribute), False)
         If Not targetFrameworks Is Nothing AndAlso Not targetFrameworks(0) Is Nothing Then
            Dim attr As System.Runtime.Versioning.TargetFrameworkAttribute = TryCast(targetFrameworks(0), System.Runtime.Versioning.TargetFrameworkAttribute)
            If Not attr Is Nothing AndAlso (Not attr.FrameworkName.Contains("v4.0")) Then
               thirdPartyTwainWithKnownProblem = True
            End If
         End If
      End If

      If thirdPartyTwainWithKnownProblem Then
         Dim message As String = "The 64-bit TWAIN Free Image Scanner virtual TWAIN driver has known compatibility issues with .NET 4.5 and above.\n" +
                                 "If you are using this TWAIN driver as a source with our LEADTOOLS TWAIN SDK and are having any issues, you will need to upgrade the FreeImagex64.dll that is included with the driver to v3.18.0.\n" +
                                 "Another option is to change the target .NET Framework from 4.5 to 4.0 or lower.\n" +
                                 "For more information see: https://www.leadtools.com/support/forum/posts/t12411-"
         Dim ret As DialogResult = MessageBox.Show(window, message, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
         If ret = DialogResult.Cancel Then
            continueScan = False
         End If
      End If

      Return continueScan
   End Function

   Public Shared Function GetBoundingRectangle(ByVal pts As PointF()) As RectangleF
      If pts.Length = 2 Then
         Return RectangleF.FromLTRB(Math.Min(pts(0).X, pts(1).X), Math.Min(pts(0).Y, pts(1).Y), Math.Max(pts(0).X, pts(1).X), Math.Max(pts(0).Y, pts(1).Y))
      ElseIf pts.Length = 4 Then
         Return RectangleF.FromLTRB(Math.Min(pts(0).X, Math.Min(pts(1).X, Math.Min(pts(2).X, pts(3).X))), Math.Min(pts(0).Y, Math.Min(pts(1).Y, Math.Min(pts(2).Y, pts(3).Y))), Math.Max(pts(0).X, Math.Max(pts(1).X, Math.Max(pts(2).X, pts(3).X))), Math.Max(pts(0).Y, Math.Max(pts(1).Y, Math.Max(pts(2).Y, pts(3).Y))))
      Else
         Dim xMin As Single = pts(0).X
         Dim yMin As Single = pts(0).Y
         Dim xMax As Single = xMin
         Dim yMax As Single = yMin

         Dim i As Integer = 1
         Do While i < pts.Length
            xMin = Math.Min(xMin, pts(i).X)
            yMin = Math.Min(yMin, pts(i).Y)
            xMax = Math.Max(xMax, pts(i).X)
            yMax = Math.Max(yMax, pts(i).Y)
            i += 1
         Loop

         Return FixRectangle(RectangleF.FromLTRB(xMin, yMin, xMax, yMax))
      End If
   End Function

   Public Shared Function GetBoundingPoints(ByVal rc As RectangleF) As PointF()
      Return New PointF() {New PointF(rc.Left, rc.Top), New PointF(rc.Right, rc.Top), New PointF(rc.Right, rc.Bottom), New PointF(rc.Left, rc.Bottom)}
   End Function

   Public Shared Function GetBoundingRectangle(ByVal center As Point, ByVal size As Size) As Rectangle
      Return New Rectangle(CInt(center.X - size.Width / 2), CInt(center.Y - size.Height / 2), size.Width, size.Height)
   End Function

   Public Shared Function GetBoundingRectangle(ByVal center As PointF, ByVal size As SizeF) As RectangleF
      Return New RectangleF(center.X - size.Width / 2.0F, center.Y - size.Height / 2.0F, size.Width, size.Height)
   End Function

   Public Shared Function GetBoundingRectangle(ByVal rc As RectangleF) As Rectangle
      Return FixRectangle(New Rectangle(CInt(rc.Left), CInt(rc.Top), CInt(Math.Ceiling(rc.Width)) + 1, CInt(Math.Ceiling(rc.Height)) + 1))
   End Function

   Public Shared Function GetBoundingRectangle(ByVal pt1 As PointF, ByVal pt2 As PointF) As RectangleF
      Return RectangleF.FromLTRB(Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y), Math.Max(pt1.X, pt2.X), Math.Max(pt1.Y, pt2.Y))
   End Function

   Public Shared Function FixRectangle(ByVal rc As RectangleF) As RectangleF
      If rc.Left > rc.Right OrElse rc.Top > rc.Bottom Then
         Return RectangleF.FromLTRB(Math.Min(rc.Left, rc.Right), Math.Min(rc.Top, rc.Bottom), Math.Max(rc.Left, rc.Right), Math.Max(rc.Top, rc.Bottom))
      Else
         Return rc
      End If
   End Function

   Public Shared Function FixRectangle(ByVal rc As Rectangle) As Rectangle
      If rc.Left > rc.Right OrElse rc.Top > rc.Bottom Then
         Return Rectangle.FromLTRB(Math.Min(rc.Left, rc.Right), Math.Min(rc.Top, rc.Bottom), Math.Max(rc.Left, rc.Right), Math.Max(rc.Top, rc.Bottom))
      Else
         Return rc
      End If
   End Function

   Public Shared Sub SetDefaultComments(ByVal rasterImage As RasterImage, ByVal rasterCodecs As RasterCodecs)
      rasterCodecs.Options.Save.Comments = True

      Dim commentSoftware As RasterCommentMetadata = New RasterCommentMetadata()
      commentSoftware.Type = RasterCommentMetadataType.Software
      If (Not Is64Process()) Then
         commentSoftware.FromAscii("LEADTOOLS For .NET 32 bit")
      Else
         commentSoftware.FromAscii("LEADTOOLS For .NET 64 bit")
      End If

      Dim commentCopyright As RasterCommentMetadata = New RasterCommentMetadata()
      commentCopyright.Type = RasterCommentMetadataType.Copyright
      commentCopyright.FromAscii("Copyright (c) 1991-2019 LEAD Technologies, Inc.  All Rights Reserved.")

      rasterImage.Comments.Add(commentSoftware)
      rasterImage.Comments.Add(commentCopyright)
   End Sub

   Public Shared Function GetOcrOutputFileName(ByVal owner As IWin32Window, ByVal filter As String) As String
      Dim outFileName As String = String.Empty
      Using saveFileDlg As New SaveFileDialog()
         saveFileDlg.Filter = filter
         saveFileDlg.FilterIndex = 1

         If saveFileDlg.ShowDialog(owner) = DialogResult.OK Then
            outFileName = saveFileDlg.FileName
         End If
      End Using

      Return outFileName
   End Function

   Public Shared Function GetOcrOutputPath(ByVal owner As IWin32Window) As String
      Dim outPath As String = String.Empty
      Using browseDlg As New FolderBrowserDialog()
         browseDlg.ShowNewFolderButton = False
         browseDlg.Description = "Select Output Folder:"
         If browseDlg.ShowDialog(owner) = DialogResult.OK Then
            outPath = browseDlg.SelectedPath
         End If
      End Using

      Return outPath
   End Function

   Public Shared Sub LaunchHowTo(ByVal topicName As String)
      Dim helpPath As String = Application.ExecutablePath
      Dim index As Integer = helpPath.ToLower().IndexOf("bin")
      helpPath = helpPath.Remove(index)
      helpPath &= "Help\HowTo.chm"

      Dim startInfo As ProcessStartInfo = New ProcessStartInfo()
      startInfo.FileName = "hh.exe"
      startInfo.Arguments = String.Format("""mk:@MSITStore:{0}::/{1}""", helpPath, topicName)
      Using process As Process = New Process()
         process.StartInfo = startInfo
         process.Start()
         process.Close()
      End Using
   End Sub

   Public Shared Sub LaunchHelp2(ByVal topicName As String)
      Dim helpPath As String = "C:\Program Files (x86)\Common Files\LEADTOOLS\Help\"

      Dim startInfo As New ProcessStartInfo()
      startInfo.FileName = helpPath & "LeadtoolsHelp2Utilities.exe"

#If LTV20_CONFIG Then
      Dim ver As Integer = 20
#End If

#If LTV19_CONFIG Then
      Dim ver As Integer = 19
#End If

#If LTV18_CONFIG Then
      Dim ver As Integer = 18
#End If

      startInfo.Arguments = String.Format("/viewalt:{0} {1} ", topicName, ver)

      Using process As New Process()
         process.StartInfo = startInfo
         process.Start()
         process.Close()
      End Using
   End Sub

   '''
   ''' Convert any possible string-Value of a given enumeration
   ''' type to its internal representation.
   '''
   Public Shared Function StringToEnum(ByVal t As Type, ByVal Value As String) As Object
      For Each fi As FieldInfo In t.GetFields()
         If fi.Name = Value Then
            Return fi.GetValue(Nothing) ' We use null because
         End If
      Next fi
      ' enumeration values
      ' are static

      Throw New Exception(String.Format("Can not convert {0} to {1}", Value, t.ToString()))
   End Function

   ' Trims off the % of an IPv6 address
   ' Sets to lower case
   ' Ipv4 addresses are returned unchanged
   ' If IpV6 address is of form: ::ffff:192.168.0.xxx, then it strips off the ::ffff:
   Public Shared Function CleanIp(ByVal ipAddress As String) As String
      Dim prefix As String = "::ffff:"
      Dim ipParts() As String = ipAddress.Split(New Char() {"%"c}, StringSplitOptions.RemoveEmptyEntries)
      If ipParts.Length > 0 Then
         ipAddress = ipParts(0)
      End If

      If ipAddress.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) Then
         ipAddress = ipAddress.Substring(prefix.Length)
      End If

      ipAddress = ipAddress.ToLower()
      Return ipAddress
   End Function

End Class
