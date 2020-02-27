' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Management
Imports System.Collections
Imports System.Globalization
Imports System.ComponentModel.Design.Serialization
Imports System.Reflection
Namespace Leadtools.Dicom.Server.Manager


   ' Functions ShouldSerialize<PropertyName> are functions used by VS property browser to check if a particular property has to be serialized. These functions are added for all ValueType properties ( properties of type Int32, BOOL etc.. which cannot be set to null). These functions use Is<PropertyName>Null function. These functions are also used in the TypeConverter implementation for the properties to check for NULL value of property so that an empty value can be shown in Property browser in case of Drag and Drop in Visual studio.
   ' Functions Is<PropertyName>Null() are used to check if a property is NULL.
   ' Functions Reset<PropertyName> are added for Nullable Read/Write properties. These functions are used by VS designer in property browser to set a property to NULL.
   ' Every property added to the class for WMI property has attributes set to define its behavior in Visual Studio designer and also to define a TypeConverter to be used.
   ' Datetime conversion functions ToDateTime and ToDmtfDateTime are added to the class to convert DMTF datetime to System.DateTime and vice-versa.
   ' An Early Bound class generated for the WMI class.Win32_Service
   Public Class Service : Inherits System.ComponentModel.Component

      ' Private property to hold the WMI namespace in which the class resides.
      Private Shared CreatedWmiNamespace As String = "ROOT\CIMV2"

      ' Private property to hold the name of WMI class which created this class.
      Private Shared CreatedClassName As String = "Win32_Service"

      ' Private member variable to hold the ManagementScope which is used by the various methods.
      Private Shared statMgmtScope As System.Management.ManagementScope = Nothing

      Private PrivateSystemProperties As ManagementSystemProperties

      ' Underlying lateBound WMI object.
      Private PrivateLateBoundObject As System.Management.ManagementObject

      ' Member variable to store the 'automatic commit' behavior for the class.
      Private AutoCommitProp As Boolean

      ' Private variable to hold the embedded property representing the instance.
      Private embeddedObj As System.Management.ManagementBaseObject

      ' The current WMI object used
      Private curObj As System.Management.ManagementBaseObject

      ' Flag to indicate if the instance is an embedded object.
      Private isEmbedded As Boolean

      ' Below are different overloads of constructors to initialize an instance of the class with a WMI object.
      Public Sub New()
         Me.InitializeObject(Nothing, Nothing, Nothing)
      End Sub

      Public Sub New(ByVal keyName As String)
         Me.InitializeObject(Nothing, New System.Management.ManagementPath(Service.ConstructPath(keyName)), Nothing)
      End Sub

      Public Sub New(ByVal mgmtScope As System.Management.ManagementScope, ByVal keyName As String)
         Me.InitializeObject((CType(mgmtScope, System.Management.ManagementScope)), New System.Management.ManagementPath(Service.ConstructPath(keyName)), Nothing)
      End Sub

      Public Sub New(ByVal path_Renamed As System.Management.ManagementPath, ByVal getOptions As System.Management.ObjectGetOptions)
         Me.InitializeObject(Nothing, path_Renamed, getOptions)
      End Sub

      Public Sub New(ByVal mgmtScope As System.Management.ManagementScope, ByVal path_Renamed As System.Management.ManagementPath)
         Me.InitializeObject(mgmtScope, path_Renamed, Nothing)
      End Sub

      Public Sub New(ByVal path_Renamed As System.Management.ManagementPath)
         Me.InitializeObject(Nothing, path_Renamed, Nothing)
      End Sub

      Public Sub New(ByVal mgmtScope As System.Management.ManagementScope, ByVal path_Renamed As System.Management.ManagementPath, ByVal getOptions As System.Management.ObjectGetOptions)
         Me.InitializeObject(mgmtScope, path_Renamed, getOptions)
      End Sub

      Public Sub New(ByVal theObject As System.Management.ManagementObject)
         Initialize()
         If (CheckIfProperClass(theObject) = True) Then
            PrivateLateBoundObject = theObject
            PrivateSystemProperties = New ManagementSystemProperties(PrivateLateBoundObject)
            curObj = PrivateLateBoundObject
         Else
            Throw New System.ArgumentException("Class name does not match.")
         End If
      End Sub

      Public Sub New(ByVal theObject As System.Management.ManagementBaseObject)
         Initialize()
         If (CheckIfProperClass(theObject) = True) Then
            embeddedObj = theObject
            PrivateSystemProperties = New ManagementSystemProperties(theObject)
            curObj = embeddedObj
            isEmbedded = True
         Else
            Throw New System.ArgumentException("Class name does not match.")
         End If
      End Sub

      ' Property returns the namespace of the WMI class.
      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property OriginatingNamespace() As String
         Get
            Return "ROOT\CIMV2"
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property ManagementClassName() As String
         Get
            Dim strRet As String = CreatedClassName
            If (Not curObj Is Nothing) Then
               If (Not curObj.ClassPath Is Nothing) Then
                  strRet = (CStr(curObj("__CLASS")))
                  If ((strRet Is Nothing) OrElse (strRet = String.Empty)) Then
                     strRet = CreatedClassName
                  End If
               End If
            End If
            Return strRet
         End Get
      End Property

      ' Property pointing to an embedded object to get System properties of the WMI object.
      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property SystemProperties() As ManagementSystemProperties
         Get
            Return PrivateSystemProperties
         End Get
      End Property

      ' Property returning the underlying lateBound object.
      <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property LateBoundObject() As System.Management.ManagementBaseObject
         Get
            Return curObj
         End Get
      End Property

      ' ManagementScope of the object.
      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public Property Scope() As System.Management.ManagementScope
         Get
            If (isEmbedded = False) Then
               Return PrivateLateBoundObject.Scope
            Else
               Return Nothing
            End If
         End Get
         Set(ByVal value As System.Management.ManagementScope)
            If (isEmbedded = False) Then
               PrivateLateBoundObject.Scope = Value
            End If
         End Set
      End Property

      ' Property to show the commit behavior for the WMI object. If true, WMI object will be automatically saved after each property modification.(ie. Put() is called after modification of a property).
      <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public Property AutoCommit() As Boolean
         Get
            Return AutoCommitProp
         End Get
         Set(ByVal value As Boolean)
            AutoCommitProp = Value
         End Set
      End Property

      ' The ManagementPath of the underlying WMI object.
      <Browsable(True)> _
      Public Property Path() As System.Management.ManagementPath
         Get
            If (isEmbedded = False) Then
               Return PrivateLateBoundObject.Path
            Else
               Return Nothing
            End If
         End Get
         Set(ByVal value As System.Management.ManagementPath)
            If (isEmbedded = False) Then
               If (CheckIfProperClass(Nothing, Value, Nothing) <> True) Then
                  Throw New System.ArgumentException("Class name does not match.")
               End If
               PrivateLateBoundObject.Path = Value
            End If
         End Set
      End Property

      ' Public static scope property which is used by the various methods.
      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public Shared Property StaticScope() As System.Management.ManagementScope
         Get
            Return statMgmtScope
         End Get
         Set(ByVal value As System.Management.ManagementScope)
            statMgmtScope = Value
         End Set
      End Property

      <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property IsAcceptPauseNull() As Boolean
         Get
            If (curObj("AcceptPause") Is Nothing) Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The AcceptPause property indicates whether the service can be paused." & Constants.vbLf & "Values: TRU" & "E or FALSE. A value of TRUE indicates the service can be paused."), TypeConverter(GetType(WMIValueTypeConverter))> _
      Public ReadOnly Property AcceptPause() As Boolean
         Get
            If (curObj("AcceptPause") Is Nothing) Then
               Return System.Convert.ToBoolean(0)
            End If
            Return (CBool(curObj("AcceptPause")))
         End Get
      End Property

      <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property IsAcceptStopNull() As Boolean
         Get
            If (curObj("AcceptStop") Is Nothing) Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The AcceptStop property indicates whether the service can be stopped." & Constants.vbLf & "Values: TRU" & "E or FALSE. A value of TRUE indicates the service can be stopped."), TypeConverter(GetType(WMIValueTypeConverter))> _
      Public ReadOnly Property AcceptStop() As Boolean
         Get
            If (curObj("AcceptStop") Is Nothing) Then
               Return System.Convert.ToBoolean(0)
            End If
            Return (CBool(curObj("AcceptStop")))
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The Caption property is a short textual description (one-line string) of the obje" & "ct.")> _
      Public ReadOnly Property Caption() As String
         Get
            Return (CStr(curObj("Caption")))
         End Get
      End Property

      <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property IsCheckPointNull() As Boolean
         Get
            If (curObj("CheckPoint") Is Nothing) Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The CheckPoint property specifies a value that the service increments periodically to report its progress during a lengthy start, stop, pause, or continue operation. For example, the service should increment this value as it completes each step of its initialization when it is starting up. The user interface program that invoked the operation on the service uses this value to track the progress of the service during a lengthy operation. This value is not valid and should be zero when the service does not have a start, stop, pause, or continue operation pending."), TypeConverter(GetType(WMIValueTypeConverter))> _
      Public ReadOnly Property CheckPoint() As UInteger
         Get
            If (curObj("CheckPoint") Is Nothing) Then
               Return System.Convert.ToUInt32(0)
            End If
            Return (CUInt(curObj("CheckPoint")))
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("CreationClassName indicates the name of the class or the subclass used in the cre" & "ation of an instance. When used with the other key properties of this class, thi" & "s property allows all instances of this class and its subclasses to be uniquely " & "identified.")> _
      Public ReadOnly Property CreationClassName() As String
         Get
            Return (CStr(curObj("CreationClassName")))
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The Description property provides a textual description of the object. ")> _
      Public ReadOnly Property Description() As String
         Get
            Return (CStr(curObj("Description")))
         End Get
      End Property

      <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property IsDesktopInteractNull() As Boolean
         Get
            If (curObj("DesktopInteract") Is Nothing) Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The DesktopInteract property indicates whether the service can create or communic" & "ate with windows on the desktop." & Constants.vbLf & "Values: TRUE or FALSE. A value of TRUE indicate" & "s the service can create or communicate with windows on the desktop."), TypeConverter(GetType(WMIValueTypeConverter))> _
      Public ReadOnly Property DesktopInteract() As Boolean
         Get
            If (curObj("DesktopInteract") Is Nothing) Then
               Return System.Convert.ToBoolean(0)
            End If
            Return (CBool(curObj("DesktopInteract")))
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The DisplayName property indicates the display name of the service. This string has a maximum length of 256 characters. The name is case-preserved in the Service Control Manager. DisplayName comparisons are always case-insensitive. " & ControlChars.CrLf & "Constraints: Accepts the same value as the Name property." & ControlChars.CrLf & "Example: Atdisk.")> _
      Public ReadOnly Property DisplayName() As String
         Get
            Return (CStr(curObj("DisplayName")))
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("If this service fails to start during startup, the ErrorControl property specifies the severity of the error. The value indicates the action taken by the startup program if failure occurs. All errors are logged by the computer system. The computer system does not notify the user of ""Ignore"" errors. With ""Normal"" errors the user is notified. With ""Severe"" errors, the system is restarted with the last-known-good configuration. Finally, on""Critical"" errors the system attempts to restart with a good configuration.")> _
      Public ReadOnly Property ErrorControl() As String
         Get
            Return (CStr(curObj("ErrorControl")))
         End Get
      End Property

      <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property IsExitCodeNull() As Boolean
         Get
            If (curObj("ExitCode") Is Nothing) Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The ExitCode property specifies a Win32 error code defining any problems encountered in starting or stopping the service. This property is set to ERROR_SERVICE_SPECIFIC_ERROR (1066) when the error is unique to the service represented by this class, and information about the error is available in the ServiceSpecificExitCode member. The service sets this value to NO_ERROR when running, and again upon normal termination."), TypeConverter(GetType(WMIValueTypeConverter))> _
      Public ReadOnly Property ExitCode() As UInteger
         Get
            If (curObj("ExitCode") Is Nothing) Then
               Return System.Convert.ToUInt32(0)
            End If
            Return (CUInt(curObj("ExitCode")))
         End Get
      End Property

      <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property IsInstallDateNull() As Boolean
         Get
            If (curObj("InstallDate") Is Nothing) Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The InstallDate property is datetime value indicating when the object was install" & "ed. A lack of a value does not indicate that the object is not installed."), TypeConverter(GetType(WMIValueTypeConverter))> _
      Public ReadOnly Property InstallDate() As System.DateTime
         Get
            If (Not curObj("InstallDate") Is Nothing) Then
               Return ToDateTime((CStr(curObj("InstallDate"))))
            Else
               Return System.DateTime.MinValue
            End If
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The Name property uniquely identifies the service and provides an indication of t" & "he functionality that is managed. This functionality is described in more detail" & " in the object's Description property. ")> _
      Public ReadOnly Property Name() As String
         Get
            Return (CStr(curObj("Name")))
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The PathName property contains the fully qualified path to the service binary fil" & "e that implements the service." & Constants.vbLf & "Example: \SystemRoot\System32\drivers\afd.sys")> _
      Public ReadOnly Property PathName() As String
         Get
            Return (CStr(curObj("PathName")))
         End Get
      End Property

      <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property IsProcessIdNull() As Boolean
         Get
            If (curObj("ProcessId") Is Nothing) Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The ProcessId property specifies the process identifier of the service." & Constants.vbLf & "Example: " & "324"), TypeConverter(GetType(WMIValueTypeConverter))> _
      Public ReadOnly Property ProcessId() As UInteger
         Get
            If (curObj("ProcessId") Is Nothing) Then
               Return System.Convert.ToUInt32(0)
            End If
            Return (CUInt(curObj("ProcessId")))
         End Get
      End Property

      <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property IsServiceSpecificExitCodeNull() As Boolean
         Get
            If (curObj("ServiceSpecificExitCode") Is Nothing) Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The ServiceSpecificExitCode property specifies a service-specific error code for errors that occur while the service is either starting or stopping. The exit codes are defined by the service represented by this class. This value is only set when the ExitCodeproperty value is ERROR_SERVICE_SPECIFIC_ERROR, 1066."), TypeConverter(GetType(WMIValueTypeConverter))> _
      Public ReadOnly Property ServiceSpecificExitCode() As UInteger
         Get
            If (curObj("ServiceSpecificExitCode") Is Nothing) Then
               Return System.Convert.ToUInt32(0)
            End If
            Return (CUInt(curObj("ServiceSpecificExitCode")))
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The ServiceType property supplies the type of service provided to calling process" & "es.")> _
      Public ReadOnly Property ServiceType() As String
         Get
            Return (CStr(curObj("ServiceType")))
         End Get
      End Property

      <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property IsStartedNull() As Boolean
         Get
            If (curObj("Started") Is Nothing) Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("Started is a boolean indicating whether the service has been started (TRUE), or s" & "topped (FALSE)."), TypeConverter(GetType(WMIValueTypeConverter))> _
      Public ReadOnly Property Started() As Boolean
         Get
            If (curObj("Started") Is Nothing) Then
               Return System.Convert.ToBoolean(0)
            End If
            Return (CBool(curObj("Started")))
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The StartMode property indicates the start mode of the Win32 base service. ""Boot"" specifies a device driver started by the operating system loader. This value is valid only for driver services. ""System"" specifies a device driver started by the IoInitSystem function. This value is valid only for driver services. ""Automatic"" specifies a service to be started automatically by the service control manager during system startup. ""Manual"" specifies a service to be started by the service control manager when a process calls the StartService function. ""Disabled"" specifies a service that can no longer be started.")> _
      Public ReadOnly Property StartMode() As String
         Get
            Return (CStr(curObj("StartMode")))
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The StartName property indicates the account name under which the service runs. Depending on the service type, the account name may be in the form of ""DomainName\Username"".  The service process will be logged using one of these two forms when it runs. If the account belongs to the built-in domain, "".\Username"" can be specified. If NULL is specified, the service will be logged on as the LocalSystem account. For kernel or system level drivers, StartName contains the driver object name (that is, \FileSystem\Rdr or \Driver\Xns) which the input and output (I/O) system uses to load the device driver. Additionally, if NULL is specified, the driver runs with a default object name created by the I/O system based on the service name." & ControlChars.CrLf & "Example: DWDOM\Admin.")> _
      Public ReadOnly Property StartName() As String
         Get
            Return (CStr(curObj("StartName")))
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The State property indicates the current state of the base service.")> _
      Public ReadOnly Property State() As String
         Get
            Return (CStr(curObj("State")))
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The Status property is a string indicating the current status of the object. Various operational and non-operational statuses can be defined. Operational statuses are ""OK"", ""Degraded"" and ""Pred Fail"". ""Pred Fail"" indicates that an element may be functioning properly but predicting a failure in the near future. An example is a SMART-enabled hard drive. Non-operational statuses can also be specified. These are ""Error"", ""Starting"", ""Stopping"" and ""Service"". The latter, ""Service"", could apply during mirror-resilvering of a disk, reload of a user permissions list, or other administrative work. Not all such work is on-line, yet the managed element is neither ""OK"" nor in one of the other states.")> _
      Public ReadOnly Property Status() As String
         Get
            Return (CStr(curObj("Status")))
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The scoping System's CreationClassName. ")> _
      Public ReadOnly Property SystemCreationClassName() As String
         Get
            Return (CStr(curObj("SystemCreationClassName")))
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The name of the system that hosts this service")> _
      Public ReadOnly Property SystemName() As String
         Get
            Return (CStr(curObj("SystemName")))
         End Get
      End Property

      <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property IsTagIdNull() As Boolean
         Get
            If (curObj("TagId") Is Nothing) Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The TagId property specifies a unique tag value for this service in the group. A value of 0 indicates that the service has not been assigned a tag. A tag can be used for ordering service startup within a load order group by specifying a tag order vector in the registry located at: HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\GroupOrderList. Tags are only evaluated for Kernel Driver and File System Driver start type services that have ""Boot"" or ""System"" start modes."), TypeConverter(GetType(WMIValueTypeConverter))> _
      Public ReadOnly Property TagId() As UInteger
         Get
            If (curObj("TagId") Is Nothing) Then
               Return System.Convert.ToUInt32(0)
            End If
            Return (CUInt(curObj("TagId")))
         End Get
      End Property

      <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property IsWaitHintNull() As Boolean
         Get
            If (curObj("WaitHint") Is Nothing) Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("The WaitHint property specifies the estimated time required (in milliseconds) for a pending start, stop, pause, or continue operation. After the specified amount of time has elapsed, the service makes its next call to the SetServiceStatus function with either an incremented CheckPoint value or a change in Current State. If the amount of time specified by WaitHint passes, and CheckPoint has not been incremented, or the Current State has not changed, the service control manager or service control program assumes that an error has occurred."), TypeConverter(GetType(WMIValueTypeConverter))> _
      Public ReadOnly Property WaitHint() As UInteger
         Get
            If (curObj("WaitHint") Is Nothing) Then
               Return System.Convert.ToUInt32(0)
            End If
            Return (CUInt(curObj("WaitHint")))
         End Get
      End Property

      Private Function CheckIfProperClass(ByVal mgmtScope As System.Management.ManagementScope, ByVal path_Renamed As System.Management.ManagementPath, ByVal OptionsParam As System.Management.ObjectGetOptions) As Boolean
         If ((Not path_Renamed Is Nothing) AndAlso (String.Compare(path_Renamed.ClassName, Me.ManagementClassName, True, System.Globalization.CultureInfo.InvariantCulture) = 0)) Then
            Return True
         Else
            Return CheckIfProperClass(New System.Management.ManagementObject(mgmtScope, path_Renamed, OptionsParam))
         End If
      End Function

      Private Function CheckIfProperClass(ByVal theObj As System.Management.ManagementBaseObject) As Boolean
         If ((Not theObj Is Nothing) AndAlso (String.Compare((CStr(theObj("__CLASS"))), Me.ManagementClassName, True, System.Globalization.CultureInfo.InvariantCulture) = 0)) Then
            Return True
         Else
            Dim parentClasses As System.Array = (CType(theObj("__DERIVATION"), System.Array))
            If (Not parentClasses Is Nothing) Then
               Dim count As Integer = 0
               count = 0
               Do While (count < parentClasses.Length)
                  If (String.Compare((CStr(parentClasses.GetValue(count))), Me.ManagementClassName, True, System.Globalization.CultureInfo.InvariantCulture) = 0) Then
                     Return True
                  End If
                  count = (count + 1)
               Loop
            End If
         End If
         Return False
      End Function

      Private Function ShouldSerializeAcceptPause() As Boolean
         If (Me.IsAcceptPauseNull = False) Then
            Return True
         End If
         Return False
      End Function

      Private Function ShouldSerializeAcceptStop() As Boolean
         If (Me.IsAcceptStopNull = False) Then
            Return True
         End If
         Return False
      End Function

      Private Function ShouldSerializeCheckPoint() As Boolean
         If (Me.IsCheckPointNull = False) Then
            Return True
         End If
         Return False
      End Function

      Private Function ShouldSerializeDesktopInteract() As Boolean
         If (Me.IsDesktopInteractNull = False) Then
            Return True
         End If
         Return False
      End Function

      Private Function ShouldSerializeExitCode() As Boolean
         If (Me.IsExitCodeNull = False) Then
            Return True
         End If
         Return False
      End Function

      ' Converts a given datetime in DMTF format to System.DateTime object.
      Private Shared Function ToDateTime(ByVal dmtfDate As String) As System.DateTime
         Dim initializer As System.DateTime = System.DateTime.MinValue
         Dim year As Integer = initializer.Year
         Dim month As Integer = initializer.Month
         Dim day As Integer = initializer.Day
         Dim hour As Integer = initializer.Hour
         Dim minute As Integer = initializer.Minute
         Dim second As Integer = initializer.Second
         Dim ticks As Long = 0
         Dim dmtf As String = dmtfDate
         Dim datetime As System.DateTime = System.DateTime.MinValue
         Dim tempString As String = String.Empty
         If (dmtf Is Nothing) Then
            Throw New System.ArgumentOutOfRangeException()
         End If
         If (dmtf.Length = 0) Then
            Throw New System.ArgumentOutOfRangeException()
         End If
         If (dmtf.Length <> 25) Then
            Throw New System.ArgumentOutOfRangeException()
         End If
         Try
            tempString = dmtf.Substring(0, 4)
            If ("****" <> tempString) Then
               year = Integer.Parse(tempString)
            End If
            tempString = dmtf.Substring(4, 2)
            If ("**" <> tempString) Then
               month = Integer.Parse(tempString)
            End If
            tempString = dmtf.Substring(6, 2)
            If ("**" <> tempString) Then
               day = Integer.Parse(tempString)
            End If
            tempString = dmtf.Substring(8, 2)
            If ("**" <> tempString) Then
               hour = Integer.Parse(tempString)
            End If
            tempString = dmtf.Substring(10, 2)
            If ("**" <> tempString) Then
               minute = Integer.Parse(tempString)
            End If
            tempString = dmtf.Substring(12, 2)
            If ("**" <> tempString) Then
               second = Integer.Parse(tempString)
            End If
            tempString = dmtf.Substring(15, 6)
            If ("******" <> tempString) Then
               ticks = (Long.Parse(tempString) * (CLng((System.TimeSpan.TicksPerMillisecond / 1000))))
            End If
            If ((((((((year < 0) OrElse (month < 0)) OrElse (day < 0)) OrElse (hour < 0)) OrElse (minute < 0)) OrElse (minute < 0)) OrElse (second < 0)) OrElse (ticks < 0)) Then
               Throw New System.ArgumentOutOfRangeException()
            End If
         Catch e As System.Exception
            Throw New System.ArgumentOutOfRangeException(Nothing, e.Message)
         End Try
         datetime = New System.DateTime(year, month, day, hour, minute, second, 0)
         datetime = datetime.AddTicks(ticks)
         Dim tickOffset As System.TimeSpan = System.TimeZone.CurrentTimeZone.GetUtcOffset(datetime)
         Dim UTCOffset As Integer = 0
         Dim OffsetToBeAdjusted As Integer = 0
         Dim OffsetMins As Long = (CLng((tickOffset.Ticks / System.TimeSpan.TicksPerMinute)))
         tempString = dmtf.Substring(22, 3)
         If (tempString <> "******") Then
            tempString = dmtf.Substring(21, 4)
            Try
               UTCOffset = Integer.Parse(tempString)
            Catch e As System.Exception
               Throw New System.ArgumentOutOfRangeException(Nothing, e.Message)
            End Try
            OffsetToBeAdjusted = (CInt((OffsetMins - UTCOffset)))
            datetime = datetime.AddMinutes((CDbl(OffsetToBeAdjusted)))
         End If
         Return datetime
      End Function

      ' Converts a given System.DateTime object to DMTF datetime format.
      Private Shared Function ToDmtfDateTime(ByVal [date] As System.DateTime) As String
         Dim utcString As String = String.Empty
         Dim tickOffset As System.TimeSpan = System.TimeZone.CurrentTimeZone.GetUtcOffset([date])
         Dim OffsetMins As Long = (CLng((tickOffset.Ticks / System.TimeSpan.TicksPerMinute)))
         If (System.Math.Abs(OffsetMins) > 999) Then
            [date] = [date].ToUniversalTime()
            utcString = "+000"
         Else
            If (tickOffset.Ticks >= 0) Then
               utcString = String.Concat("+", (CLng((tickOffset.Ticks / System.TimeSpan.TicksPerMinute))).ToString().PadLeft(3, "0"c))
            Else
               Dim strTemp As String = (CLng(OffsetMins)).ToString()
               utcString = String.Concat("-", strTemp.Substring(1, (strTemp.Length - 1)).PadLeft(3, "0"c))
            End If
         End If
         Dim dmtfDateTime As String = (CInt([date].Year)).ToString().PadLeft(4, "0"c)
         dmtfDateTime = String.Concat(dmtfDateTime, (CInt([date].Month)).ToString().PadLeft(2, "0"c))
         dmtfDateTime = String.Concat(dmtfDateTime, (CInt([date].Day)).ToString().PadLeft(2, "0"c))
         dmtfDateTime = String.Concat(dmtfDateTime, (CInt([date].Hour)).ToString().PadLeft(2, "0"c))
         dmtfDateTime = String.Concat(dmtfDateTime, (CInt([date].Minute)).ToString().PadLeft(2, "0"c))
         dmtfDateTime = String.Concat(dmtfDateTime, (CInt([date].Second)).ToString().PadLeft(2, "0"c))
         dmtfDateTime = String.Concat(dmtfDateTime, ".")
         Dim dtTemp As System.DateTime = New System.DateTime([date].Year, [date].Month, [date].Day, [date].Hour, [date].Minute, [date].Second, 0)
         Dim microsec As Long = (CLng(((([date].Ticks - dtTemp.Ticks) * 1000) / System.TimeSpan.TicksPerMillisecond)))
         Dim strMicrosec As String = (CLng(microsec)).ToString()
         If (strMicrosec.Length > 6) Then
            strMicrosec = strMicrosec.Substring(0, 6)
         End If
         dmtfDateTime = String.Concat(dmtfDateTime, strMicrosec.PadLeft(6, "0"c))
         dmtfDateTime = String.Concat(dmtfDateTime, utcString)
         Return dmtfDateTime
      End Function

      Private Function ShouldSerializeInstallDate() As Boolean
         If (Me.IsInstallDateNull = False) Then
            Return True
         End If
         Return False
      End Function

      Private Function ShouldSerializeProcessId() As Boolean
         If (Me.IsProcessIdNull = False) Then
            Return True
         End If
         Return False
      End Function

      Private Function ShouldSerializeServiceSpecificExitCode() As Boolean
         If (Me.IsServiceSpecificExitCodeNull = False) Then
            Return True
         End If
         Return False
      End Function

      Private Function ShouldSerializeStarted() As Boolean
         If (Me.IsStartedNull = False) Then
            Return True
         End If
         Return False
      End Function

      Private Function ShouldSerializeTagId() As Boolean
         If (Me.IsTagIdNull = False) Then
            Return True
         End If
         Return False
      End Function

      Private Function ShouldSerializeWaitHint() As Boolean
         If (Me.IsWaitHintNull = False) Then
            Return True
         End If
         Return False
      End Function

      <Browsable(True)> _
      Public Sub CommitObject()
         If (isEmbedded = False) Then
            PrivateLateBoundObject.Put()
         End If
      End Sub

      <Browsable(True)> _
      Public Sub CommitObject(ByVal putOptions As System.Management.PutOptions)
         If (isEmbedded = False) Then
            PrivateLateBoundObject.Put(putOptions)
         End If
      End Sub

      Private Sub Initialize()
         AutoCommitProp = True
         isEmbedded = False
      End Sub

      Private Shared Function ConstructPath(ByVal keyName As String) As String
         Dim strPath As String = "ROOT\CIMV2:Win32_Service"
         strPath = String.Concat(strPath, String.Concat(".Name=", String.Concat("""", String.Concat(keyName, """"))))
         Return strPath
      End Function

      Private Sub InitializeObject(ByVal mgmtScope As System.Management.ManagementScope, ByVal path_Renamed As System.Management.ManagementPath, ByVal getOptions As System.Management.ObjectGetOptions)
         Initialize()
         If (Not path_Renamed Is Nothing) Then
            If (CheckIfProperClass(mgmtScope, path_Renamed, getOptions) <> True) Then
               Throw New System.ArgumentException("Class name does not match.")
            End If
         End If
         PrivateLateBoundObject = New System.Management.ManagementObject(mgmtScope, path_Renamed, getOptions)
         PrivateSystemProperties = New ManagementSystemProperties(PrivateLateBoundObject)
         curObj = PrivateLateBoundObject
      End Sub

      ' Different overloads of GetInstances() help in enumerating instances of the WMI class.
      Public Shared Function GetInstances() As ServiceCollection
         Return GetInstances(Nothing, Nothing, Nothing)
      End Function

      Public Shared Function GetInstances(ByVal condition As String) As ServiceCollection
         Return GetInstances(Nothing, condition, Nothing)
      End Function

      Public Shared Function GetInstances(ByVal selectedProperties As System.String()) As ServiceCollection
         Return GetInstances(Nothing, Nothing, selectedProperties)
      End Function

      Public Shared Function GetInstances(ByVal condition As String, ByVal selectedProperties As System.String()) As ServiceCollection
         Return GetInstances(Nothing, condition, selectedProperties)
      End Function

      Public Shared Function GetInstances(ByVal mgmtScope As System.Management.ManagementScope, ByVal enumOptions As System.Management.EnumerationOptions) As ServiceCollection
         If (mgmtScope Is Nothing) Then
            If (statMgmtScope Is Nothing) Then
               mgmtScope = New System.Management.ManagementScope()
               mgmtScope.Path.NamespacePath = "root\CIMV2"
            Else
               mgmtScope = statMgmtScope
            End If
         End If
         Dim pathObj As System.Management.ManagementPath = New System.Management.ManagementPath()
         pathObj.ClassName = "Win32_Service"
         pathObj.NamespacePath = "root\CIMV2"
         Dim clsObject As System.Management.ManagementClass = New System.Management.ManagementClass(mgmtScope, pathObj, Nothing)
         If (enumOptions Is Nothing) Then
            enumOptions = New System.Management.EnumerationOptions()
            enumOptions.EnsureLocatable = True
         End If
         Return New ServiceCollection(clsObject.GetInstances(enumOptions))
      End Function

      Public Shared Function GetInstances(ByVal mgmtScope As System.Management.ManagementScope, ByVal condition As String) As ServiceCollection
         Return GetInstances(mgmtScope, condition, Nothing)
      End Function

      Public Shared Function GetInstances(ByVal mgmtScope As System.Management.ManagementScope, ByVal selectedProperties As System.String()) As ServiceCollection
         Return GetInstances(mgmtScope, Nothing, selectedProperties)
      End Function

      Public Shared Function GetInstances(ByVal mgmtScope As System.Management.ManagementScope, ByVal condition As String, ByVal selectedProperties As System.String()) As ServiceCollection
         If (mgmtScope Is Nothing) Then
            If (statMgmtScope Is Nothing) Then
               mgmtScope = New System.Management.ManagementScope()
               mgmtScope.Path.NamespacePath = "root\CIMV2"
            Else
               mgmtScope = statMgmtScope
            End If
         End If
         Dim ObjectSearcher As System.Management.ManagementObjectSearcher = New System.Management.ManagementObjectSearcher(mgmtScope, New SelectQuery("Win32_Service", condition, selectedProperties))
         Dim enumOptions As System.Management.EnumerationOptions = New System.Management.EnumerationOptions()
         enumOptions.EnsureLocatable = True
         ObjectSearcher.Options = enumOptions
         Return New ServiceCollection(ObjectSearcher.Get())
      End Function

      <Browsable(True)> _
      Public Shared Function CreateInstance() As Service
         Dim mgmtScope As System.Management.ManagementScope = Nothing
         If (statMgmtScope Is Nothing) Then
            mgmtScope = New System.Management.ManagementScope()
            mgmtScope.Path.NamespacePath = CreatedWmiNamespace
         Else
            mgmtScope = statMgmtScope
         End If
         Dim mgmtPath As System.Management.ManagementPath = New System.Management.ManagementPath(CreatedClassName)
         Dim tmpMgmtClass As System.Management.ManagementClass = New System.Management.ManagementClass(mgmtScope, mgmtPath, Nothing)
         Return New Service(tmpMgmtClass.CreateInstance())
      End Function

      <Browsable(True)> _
      Public Sub Delete()
         PrivateLateBoundObject.Delete()
      End Sub

      Public Function Change(ByVal DesktopInteract As Boolean, ByVal DisplayName As String, ByVal ErrorControl As Byte, ByVal LoadOrderGroup As String, ByVal LoadOrderGroupDependencies As String(), ByVal PathName As String, ByVal ServiceDependencies As String(), ByVal ServiceType As Byte, ByVal StartMode As String, ByVal StartName As String, ByVal StartPassword As String) As UInteger
         If (isEmbedded = False) Then
            Dim inParams As System.Management.ManagementBaseObject = Nothing
            inParams = PrivateLateBoundObject.GetMethodParameters("Change")
            inParams("DesktopInteract") = (CBool(DesktopInteract))
            inParams("DisplayName") = (CStr(DisplayName))
            inParams("ErrorControl") = (CByte(ErrorControl))
            inParams("LoadOrderGroup") = (CStr(LoadOrderGroup))
            inParams("LoadOrderGroupDependencies") = (CType(LoadOrderGroupDependencies, String()))
            inParams("PathName") = (CStr(PathName))
            inParams("ServiceDependencies") = (CType(ServiceDependencies, String()))
            inParams("ServiceType") = (CByte(ServiceType))
            inParams("StartMode") = (CStr(StartMode))
            inParams("StartName") = (CStr(StartName))
            inParams("StartPassword") = (CStr(StartPassword))
            Dim outParams As System.Management.ManagementBaseObject = PrivateLateBoundObject.InvokeMethod("Change", inParams, Nothing)
            Return System.Convert.ToUInt32(outParams.Properties("ReturnValue").Value)
         Else
            Return System.Convert.ToUInt32(0)
         End If
      End Function

      Public Function ChangeDisplayName(ByVal DisplayName As String) As UInteger
         If (isEmbedded = False) Then
            Dim inParams As System.Management.ManagementBaseObject = Nothing

            inParams = PrivateLateBoundObject.GetMethodParameters("Change")
            inParams("DisplayName") = (CStr(DisplayName))
            Dim outParams As System.Management.ManagementBaseObject = PrivateLateBoundObject.InvokeMethod("Change", inParams, Nothing)
            Return System.Convert.ToUInt32(outParams.Properties("ReturnValue").Value)
         Else
            Return System.Convert.ToUInt32(0)
         End If
      End Function

      Public Function ChangeStartMode(ByVal StartMode As String) As UInteger
         If (isEmbedded = False) Then
            Dim inParams As System.Management.ManagementBaseObject = Nothing
            inParams = PrivateLateBoundObject.GetMethodParameters("ChangeStartMode")
            inParams("StartMode") = (CStr(StartMode))
            Dim outParams As System.Management.ManagementBaseObject = PrivateLateBoundObject.InvokeMethod("ChangeStartMode", inParams, Nothing)
            Return System.Convert.ToUInt32(outParams.Properties("ReturnValue").Value)
         Else
            Return System.Convert.ToUInt32(0)
         End If
      End Function

      Public Function Create(ByVal DesktopInteract As Boolean, ByVal DisplayName As String, ByVal ErrorControl As Byte, ByVal LoadOrderGroup As String, ByVal LoadOrderGroupDependencies As String(), ByVal Name As String, ByVal PathName As String, ByVal ServiceDependencies As String(), ByVal ServiceType As Byte, ByVal StartMode As String, ByVal StartName As String, ByVal StartPassword As String) As UInteger
         If (isEmbedded = False) Then
            Dim inParams As System.Management.ManagementBaseObject = Nothing
            inParams = PrivateLateBoundObject.GetMethodParameters("Create")
            inParams("DesktopInteract") = (CBool(DesktopInteract))
            inParams("DisplayName") = (CStr(DisplayName))
            inParams("ErrorControl") = (CByte(ErrorControl))
            inParams("LoadOrderGroup") = (CStr(LoadOrderGroup))
            inParams("LoadOrderGroupDependencies") = (CType(LoadOrderGroupDependencies, String()))
            inParams("Name") = (CStr(Name))
            inParams("PathName") = (CStr(PathName))
            inParams("ServiceDependencies") = (CType(ServiceDependencies, String()))
            inParams("ServiceType") = (CByte(ServiceType))
            inParams("StartMode") = (CStr(StartMode))
            inParams("StartName") = (CStr(StartName))
            inParams("StartPassword") = (CStr(StartPassword))
            Dim outParams As System.Management.ManagementBaseObject = PrivateLateBoundObject.InvokeMethod("Create", inParams, Nothing)
            Return System.Convert.ToUInt32(outParams.Properties("ReturnValue").Value)
         Else
            Return System.Convert.ToUInt32(0)
         End If
      End Function

      Public Function Delete0() As UInteger
         If (isEmbedded = False) Then
            Dim inParams As System.Management.ManagementBaseObject = Nothing
            Dim outParams As System.Management.ManagementBaseObject = PrivateLateBoundObject.InvokeMethod("Delete", inParams, Nothing)
            Return System.Convert.ToUInt32(outParams.Properties("ReturnValue").Value)
         Else
            Return System.Convert.ToUInt32(0)
         End If
      End Function

      Public Function InterrogateService() As UInteger
         If (isEmbedded = False) Then
            Dim inParams As System.Management.ManagementBaseObject = Nothing
            Dim outParams As System.Management.ManagementBaseObject = PrivateLateBoundObject.InvokeMethod("InterrogateService", inParams, Nothing)
            Return System.Convert.ToUInt32(outParams.Properties("ReturnValue").Value)
         Else
            Return System.Convert.ToUInt32(0)
         End If
      End Function

      Public Function PauseService() As UInteger
         If (isEmbedded = False) Then
            Dim inParams As System.Management.ManagementBaseObject = Nothing
            Dim outParams As System.Management.ManagementBaseObject = PrivateLateBoundObject.InvokeMethod("PauseService", inParams, Nothing)
            Return System.Convert.ToUInt32(outParams.Properties("ReturnValue").Value)
         Else
            Return System.Convert.ToUInt32(0)
         End If
      End Function

      Public Function ResumeService() As UInteger
         If (isEmbedded = False) Then
            Dim inParams As System.Management.ManagementBaseObject = Nothing
            Dim outParams As System.Management.ManagementBaseObject = PrivateLateBoundObject.InvokeMethod("ResumeService", inParams, Nothing)
            Return System.Convert.ToUInt32(outParams.Properties("ReturnValue").Value)
         Else
            Return System.Convert.ToUInt32(0)
         End If
      End Function

      Public Function StartService() As UInteger
         If (isEmbedded = False) Then
            Dim inParams As System.Management.ManagementBaseObject = Nothing
            Dim outParams As System.Management.ManagementBaseObject = PrivateLateBoundObject.InvokeMethod("StartService", inParams, Nothing)
            Return System.Convert.ToUInt32(outParams.Properties("ReturnValue").Value)
         Else
            Return System.Convert.ToUInt32(0)
         End If
      End Function

      Public Function StopService() As UInteger
         If (isEmbedded = False) Then
            Dim inParams As System.Management.ManagementBaseObject = Nothing
            Dim outParams As System.Management.ManagementBaseObject = PrivateLateBoundObject.InvokeMethod("StopService", inParams, Nothing)
            Return System.Convert.ToUInt32(outParams.Properties("ReturnValue").Value)
         Else
            Return System.Convert.ToUInt32(0)
         End If
      End Function

      Public Function UserControlService(ByVal ControlCode As Byte) As UInteger
         If (isEmbedded = False) Then
            Dim inParams As System.Management.ManagementBaseObject = Nothing
            inParams = PrivateLateBoundObject.GetMethodParameters("UserControlService")
            inParams("ControlCode") = (CByte(ControlCode))
            Dim outParams As System.Management.ManagementBaseObject = PrivateLateBoundObject.InvokeMethod("UserControlService", inParams, Nothing)
            Return System.Convert.ToUInt32(outParams.Properties("ReturnValue").Value)
         Else
            Return System.Convert.ToUInt32(0)
         End If
      End Function

      ' Enumerator implementation for enumerating instances of the class.
      Public Class ServiceCollection : Inherits Object : Implements ICollection

         Private privColObj As ManagementObjectCollection

         Public Sub New(ByVal objCollection As ManagementObjectCollection)
            privColObj = objCollection
         End Sub

         Public Overridable ReadOnly Property Count() As Integer Implements ICollection.Count
            Get
               Return privColObj.Count
            End Get
         End Property

         Public Overridable ReadOnly Property IsSynchronized() As Boolean Implements ICollection.IsSynchronized
            Get
               Return privColObj.IsSynchronized
            End Get
         End Property

         Public Overridable ReadOnly Property SyncRoot() As Object Implements ICollection.SyncRoot
            Get
               Return Me
            End Get
         End Property

         Public Overridable Sub CopyTo(ByVal array As System.Array, ByVal index As Integer) Implements ICollection.CopyTo
            privColObj.CopyTo(array, index)
            Dim nCtr As Integer
            nCtr = 0
            Do While (nCtr < array.Length)
               array.SetValue(New Service((CType(array.GetValue(nCtr), System.Management.ManagementObject))), nCtr)
               nCtr = (nCtr + 1)
            Loop
         End Sub

         Public Overridable Function GetEnumerator() As System.Collections.IEnumerator Implements ICollection.GetEnumerator
            Return New ServiceEnumerator(privColObj.GetEnumerator())
         End Function

         Public Class ServiceEnumerator : Inherits Object : Implements System.Collections.IEnumerator

            Private privObjEnum As ManagementObjectCollection.ManagementObjectEnumerator

            Public Sub New(ByVal objEnum As ManagementObjectCollection.ManagementObjectEnumerator)
               privObjEnum = objEnum
            End Sub

            Public Overridable ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
               Get
                  Return New Service((CType(privObjEnum.Current, System.Management.ManagementObject)))
               End Get
            End Property

            Public Overridable Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
               Return privObjEnum.MoveNext()
            End Function

            Public Overridable Sub Reset() Implements System.Collections.IEnumerator.Reset
               privObjEnum.Reset()
            End Sub
         End Class
      End Class

      ' TypeConverter to handle null values for ValueType properties
      Public Class WMIValueTypeConverter : Inherits TypeConverter

         Private baseConverter As TypeConverter

         Private baseType As System.Type

         Public Sub New(ByVal inBaseType As System.Type)
            baseConverter = TypeDescriptor.GetConverter(inBaseType)
            baseType = inBaseType
         End Sub

         Public Overloads Overrides Function CanConvertFrom(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal srcType As System.Type) As Boolean
            Return baseConverter.CanConvertFrom(context, srcType)
         End Function

         Public Overloads Overrides Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean
            Return baseConverter.CanConvertTo(context, destinationType)
         End Function

         Public Overloads Overrides Function ConvertFrom(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object) As Object
            Return baseConverter.ConvertFrom(context, culture, value)
         End Function

         Public Overloads Overrides Function CreateInstance(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal dictionary As System.Collections.IDictionary) As Object
            Return baseConverter.CreateInstance(context, dictionary)
         End Function

         Public Overloads Overrides Function GetCreateInstanceSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
            Return baseConverter.GetCreateInstanceSupported(context)
         End Function

         Public Overloads Overrides Function GetProperties(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal attributeVar As System.Attribute()) As PropertyDescriptorCollection
            Return baseConverter.GetProperties(context, value, attributeVar)
         End Function

         Public Overloads Overrides Function GetPropertiesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
            Return baseConverter.GetPropertiesSupported(context)
         End Function

         Public Overloads Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
            Return baseConverter.GetStandardValues(context)
         End Function

         Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
            Return baseConverter.GetStandardValuesExclusive(context)
         End Function

         Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
            Return baseConverter.GetStandardValuesSupported(context)
         End Function

         Public Overloads Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            If (baseType.BaseType Is GetType(System.Enum)) Then
               If (value.GetType() Is destinationType) Then
                  Return value
               End If
               If (((value Is Nothing) AndAlso (Not context Is Nothing)) AndAlso (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) = False)) Then
                  Return "NULL_ENUM_VALUE"
               End If
               Return baseConverter.ConvertTo(context, culture, value, destinationType)
            End If
            If ((baseType Is GetType(Boolean)) AndAlso (baseType.BaseType Is GetType(System.ValueType))) Then
               If (((value Is Nothing) AndAlso (Not context Is Nothing)) AndAlso (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) = False)) Then
                  Return ""
               End If
               Return baseConverter.ConvertTo(context, culture, value, destinationType)
            End If
            If ((Not context Is Nothing) AndAlso (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) = False)) Then
               Return ""
            End If
            Return baseConverter.ConvertTo(context, culture, value, destinationType)
         End Function
      End Class

      ' Embedded class to represent WMI system Properties.
      <TypeConverter(GetType(System.ComponentModel.ExpandableObjectConverter))> _
      Public Class ManagementSystemProperties

         Private PrivateLateBoundObject As System.Management.ManagementBaseObject

         Public Sub New(ByVal ManagedObject As System.Management.ManagementBaseObject)
            PrivateLateBoundObject = ManagedObject
         End Sub

         <Browsable(True)> _
         Public ReadOnly Property GENUS() As Integer
            Get
               Return (CInt(PrivateLateBoundObject("__GENUS")))
            End Get
         End Property

         <Browsable(True)> _
         Public ReadOnly Property [CLASS]() As String
            Get
               Return (CStr(PrivateLateBoundObject("__CLASS")))
            End Get
         End Property

         <Browsable(True)> _
         Public ReadOnly Property SUPERCLASS() As String
            Get
               Return (CStr(PrivateLateBoundObject("__SUPERCLASS")))
            End Get
         End Property

         <Browsable(True)> _
         Public ReadOnly Property DYNASTY() As String
            Get
               Return (CStr(PrivateLateBoundObject("__DYNASTY")))
            End Get
         End Property

         <Browsable(True)> _
         Public ReadOnly Property RELPATH() As String
            Get
               Return (CStr(PrivateLateBoundObject("__RELPATH")))
            End Get
         End Property

         <Browsable(True)> _
         Public ReadOnly Property PROPERTY_COUNT() As Integer
            Get
               Return (CInt(PrivateLateBoundObject("__PROPERTY_COUNT")))
            End Get
         End Property

         <Browsable(True)> _
         Public ReadOnly Property DERIVATION() As String()
            Get
               Return (CType(PrivateLateBoundObject("__DERIVATION"), String()))
            End Get
         End Property

         <Browsable(True)> _
         Public ReadOnly Property SERVER() As String
            Get
               Return (CStr(PrivateLateBoundObject("__SERVER")))
            End Get
         End Property

         <Browsable(True)> _
         Public ReadOnly Property [NAMESPACE]() As String
            Get
               Return (CStr(PrivateLateBoundObject("__NAMESPACE")))
            End Get
         End Property

         <Browsable(True)> _
         Public ReadOnly Property PATH() As String
            Get
               Return (CStr(PrivateLateBoundObject("__PATH")))
            End Get
         End Property
      End Class
   End Class
End Namespace
