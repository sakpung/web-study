' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Text

Imports Leadtools.Pdf
Imports System

Namespace PDFDocumentDemo
   Public Class PDFSignaturesHelper
      Public Shared Function GetSignedByString(subject As String) As String
         If String.IsNullOrEmpty(subject) Then
            Return ""
         End If

         Dim subjcetInfo As String = subject
         If Not subject.EndsWith("/") Then
            subjcetInfo += "/"
         End If

         Dim CN As String = GetSubstring(subjcetInfo, "/CN=", "/")

         Dim emailAddress As String = GetSubstring(subjcetInfo, "/emailAddress=", "/")

         Dim signedBy As String = (Convert.ToString(CN & Convert.ToString(" <")) & emailAddress) + ">"

         Return signedBy
      End Function

      Public Shared Function GetSubjcetOrIssure(descriptionInfo As String) As String
         If String.IsNullOrEmpty(descriptionInfo) Then
            Return ""
         End If

         descriptionInfo += "/"

         Dim CN As String = (Convert.ToString("CN= ") & GetSubstring(descriptionInfo, "/CN=", "/")) + System.Environment.NewLine
         Dim emailAddress As String = (Convert.ToString("emailAddress= ") & GetSubstring(descriptionInfo, "/emailAddress=", "/")) + System.Environment.NewLine
         Dim OU As String = (Convert.ToString("OU= ") & GetSubstring(descriptionInfo, "/OU=", "/")) + System.Environment.NewLine
         Dim O As String = (Convert.ToString("O= ") & GetSubstring(descriptionInfo, "/O=", "/")) + System.Environment.NewLine
         Dim C As String = Convert.ToString("C= ") & GetSubstring(descriptionInfo, "/C=", "/")

         descriptionInfo = Convert.ToString(Convert.ToString(Convert.ToString(CN & emailAddress) & OU) & O) & C

         Return descriptionInfo
      End Function

      Public Shared Function GetKeyUsageString(KeyUsage As Integer) As String
         Dim keyUsageString As String = ""
         Dim dataSeparator As String = ", "

         If (KeyUsage And PDFSignature.KeyUsageCRLSign) = PDFSignature.KeyUsageCRLSign Then
            keyUsageString += Convert.ToString("CRL Sign") & dataSeparator
         End If

         If (KeyUsage And PDFSignature.KeyUsageDataEncipherment) = PDFSignature.KeyUsageDataEncipherment Then
            keyUsageString += Convert.ToString("Data Encipherment") & dataSeparator
         End If

         If (KeyUsage And PDFSignature.KeyUsageDecipherOnly) = PDFSignature.KeyUsageDecipherOnly Then
            keyUsageString += Convert.ToString("Decipher Only") & dataSeparator
         End If

         If (KeyUsage And PDFSignature.KeyUsageDigitalSignature) = PDFSignature.KeyUsageDigitalSignature Then
            keyUsageString += Convert.ToString("Digital Signature") & dataSeparator
         End If

         If (KeyUsage And PDFSignature.KeyUsageEncipherOnly) = PDFSignature.KeyUsageEncipherOnly Then
            keyUsageString += Convert.ToString("Encipher Only") & dataSeparator
         End If

         If (KeyUsage And PDFSignature.KeyUsageKeyAgreement) = PDFSignature.KeyUsageKeyAgreement Then
            keyUsageString += Convert.ToString("Key Agreement") & dataSeparator
         End If

         If (KeyUsage And PDFSignature.KeyUsageKeyCertSign) = PDFSignature.KeyUsageKeyCertSign Then
            keyUsageString += Convert.ToString("Key Certificate Sign") & dataSeparator
         End If

         If (KeyUsage And PDFSignature.KeyUsageKeyEncipherment) = PDFSignature.KeyUsageKeyEncipherment Then
            keyUsageString += Convert.ToString("Key Encipherment") & dataSeparator
         End If

         If (KeyUsage And PDFSignature.KeyUsageNonRepudiation) = PDFSignature.KeyUsageNonRepudiation Then
            keyUsageString += "Non Repudiation"
         End If

         Return keyUsageString
      End Function

      Public Shared Function GetSubstring(original As String, start As String, [end] As String) As String
         If String.IsNullOrEmpty(original) Then
            Return ""
         End If

         Dim substring As String = ""

         Dim startPos As Integer = 0
         Dim length As Integer = 0

         startPos = original.LastIndexOf(start) + start.Length
         length = original.IndexOf([end], startPos) - startPos
         If length > 0 Then
            substring = original.Substring(startPos, length)
         Else
            substring = original.Substring(startPos)
         End If

         Return substring
      End Function

      Public Shared Function InsertWhiteSpaceToString(serialNumber As String) As String
         If String.IsNullOrEmpty(serialNumber) Then
            Return ""
         End If

         Dim count As Integer = CInt(serialNumber.Length / 2 - 1)

         For i As Integer = 0 To count - 1
            Dim index As Integer = (2 * i) + (2 + i)
            serialNumber = serialNumber.Insert(index, " ")
         Next

         Return serialNumber
      End Function

      Public Shared Function GetState(state As Integer) As String
         Select Case state
            Case PDFSignature.StateInvalid
               Return "INVALID"
            Case PDFSignature.StateValid
               Return "VALID"
            Case Else
               Return "UNKNOWN"
         End Select
      End Function
   End Class
End Namespace
