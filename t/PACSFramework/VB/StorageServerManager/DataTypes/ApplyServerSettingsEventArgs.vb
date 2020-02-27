' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Leadtools.Demos.StorageServer.DataTypes
    Friend Class ApplyServerSettingsEventArgs
        Inherits EventArgs
    End Class

    Friend Class ServerSettingsSecureChangedEventArgs
        Inherits EventArgs

        Public Sub New(ByVal secureServer As Boolean)
            Me.SecureServer = secureServer
        End Sub
        Public SecureServer As Boolean = False


    End Class
End Namespace