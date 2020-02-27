' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Module _Module
   Public _errorList As ArrayList
   Public Sub AddErrorToErrorList(ByVal errorMsg As String)
      _errorList.Add(errorMsg)
   End Sub
End Module
