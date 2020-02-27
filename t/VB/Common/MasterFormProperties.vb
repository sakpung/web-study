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
Imports Leadtools.Forms.Recognition
Imports System.IO

Namespace FormsDemo
   Partial Public Class MasterFormProperties : Inherits Form
   Public Sub New(ByVal masterFormProps As FormRecognitionProperties, ByVal workingDir As String)
   InitializeComponent()

   Me.Text = """" & masterFormProps.Name & """" & " Properties"

   _txtName.Text = masterFormProps.Name
   _txtCreated.Text = masterFormProps.CreationTime.ToLongDateString()
   _txtModified.Text = masterFormProps.LastModificationTime.ToLongDateString()
   _txtAccessed.Text = masterFormProps.LastAccessTime.ToLongDateString()
   Dim fName As String = Path.Combine(workingDir, masterFormProps.Name & ".bin")
   _txtFormAttributes.Text = fName
   fName = Path.Combine(workingDir, masterFormProps.Name & ".xml")
   If File.Exists(fName) Then
    _txtFields.Text = fName
   Else
    _txtFields.Text = "NA"
   End If
   fName = Path.Combine(workingDir, masterFormProps.Name & ".tif")
   If File.Exists(fName) Then
    _txtImage.Text = fName
   Else
    _txtImage.Text = "NA"
   End If
   End Sub
   End Class
End Namespace
