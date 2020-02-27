' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Leadtools.Demos.StorageServer.DataTypes.Options
   <Flags()> _
   Public Enum Complexity
      None = 0
      Lowercase = 1
      Uppercase = 2
      Symbol = 4
      Numbers = 8
   End Enum

   <Serializable()> _
   Public Class PasswordOptions : Implements ICloneable
      Public Property Complexity() As Complexity
         Get
         Set
         End Set
         End Get
      public Integer MinimumLength
         Get
         Set
         End Set
         End Get
      public Integer DaysToExpire
         Get
         Set
         End Set
         End Get
      public Integer MaxPasswordHistory
         Get
         Set
         End Set
         End Get
      public Integer IdleTimeOut
         Get
         Set
         End Set
         End Get
      public Boolean EnableIdleTimeout
         Get
         Set
         End Set
         End Get

      Public PasswordOptions()
         IdleTimeOut = 60
         EnableIdleTimeout = True

      public Object Clone()
         Return Me.Clone(Of PasswordOptions)()

