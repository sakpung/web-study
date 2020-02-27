﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Autoplay() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Autoplay", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        '''&lt;ArrayOfLinqQuery xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        '''  &lt;LinqQuery&gt;
        '''    &lt;Name&gt;Patient Query&lt;/Name&gt;
        '''    &lt;Description&gt;Query All Patients&lt;/Description&gt;
        '''    &lt;Query&gt;from patient in ds.DirectoryRecord&amp;lt;PatientBase&amp;gt;()
        '''select patient&lt;/Query&gt;
        '''  &lt;/LinqQuery&gt;
        '''  &lt;LinqQuery&gt;
        '''    &lt;Name&gt;Study Query&lt;/Name&gt;
        '''    &lt;Description&gt;Query All Studies&lt;/Description&gt;
        '''    &lt;Query&gt;from study in ds.DirectoryRecord&amp;lt;StudyB [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property DefaultQueries() As String
            Get
                Return ResourceManager.GetString("DefaultQueries", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Folder_Open() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Folder_Open", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property generic_picture() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("generic_picture", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to from image in _Dataset.DirectoryRecord&lt;ImageBase&gt;()
        '''select image.
        '''</summary>
        Friend ReadOnly Property ImageQuery() As String
            Get
                Return ResourceManager.GetString("ImageQuery", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property images() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("images", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to {\rtf1\adeflang1025\ansi\ansicpg1252\uc1\adeff0\deff0\stshfdbch0\stshfloch0\stshfhich0\stshfbi0\deflang1033\deflangfe1033{\fonttbl{\f0\froman\fcharset0\fprq2{\*\panose 02020603050405020304}Times New Roman{\*\falt Times New Roman};}{\f2\fmodern\fcharset0\fprq1{\*\panose 02070309020205020404}Courier New;}
        '''{\f3\froman\fcharset2\fprq2{\*\panose 05050102010706020507}Symbol;}{\f38\fswiss\fcharset0\fprq2{\*\panose 020f0502020204030204}Calibri{\*\falt Calibri};}{\f228\froman\fcharset238\fprq2 Times New Roman CE{\* [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property LinqInfo() As String
            Get
                Return ResourceManager.GetString("LinqInfo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Logo() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Logo", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        '''</summary>
        Friend ReadOnly Property LvSample() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("LvSample", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to from patient in _Dataset.DirectoryRecord&lt;PatientBase&gt;()
        '''select patient.
        '''</summary>
        Friend ReadOnly Property PatientQuery() As String
            Get
                Return ResourceManager.GetString("PatientQuery", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property PlayHS() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("PlayHS", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to from study in _Dataset.DirectoryRecord&lt;StudyBase&gt;()
        '''select study.
        '''</summary>
        Friend ReadOnly Property StudyQuery() As String
            Get
                Return ResourceManager.GetString("StudyQuery", resourceCulture)
            End Get
        End Property
    End Module
End Namespace