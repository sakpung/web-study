' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Demos.StorageServer.DataTypes.Options

Namespace Leadtools.Demos.StorageServer.UI
   Partial Public Class PasswordOptionsView : Inherits UserControl
      Private _Options As PasswordOptions

      Public Property Options() As PasswordOptions
         Get
            Return _Options
         End Get
         Set(ByVal value As PasswordOptions)
            _Options = TryCast(Value.Clone(), PasswordOptions)
            ConfigureView()
         End Set
      End Property

      Public Sub New()
         InitializeComponent()
         checkBoxLowercase.Tag = Complexity.Lowercase
         checkBoxUppercase.Tag = Complexity.Uppercase
         checkBoxSymbol.Tag = Complexity.Symbol
         checkBoxNumber.Tag = Complexity.Numbers
      End Sub

      Public Sub ConfigureView()
         checkBoxLowercase.Checked = (Complexity.Lowercase And Options.Complexity) = Complexity.Lowercase
         checkBoxUppercase.Checked = (Complexity.Uppercase And Options.Complexity) = Complexity.Uppercase
         checkBoxSymbol.Checked = (Complexity.Symbol And Options.Complexity) = Complexity.Symbol
         checkBoxNumber.Checked = (Complexity.Numbers And Options.Complexity) = Complexity.Numbers

         numericUpDownMinLength.Value = Convert.ToDecimal(Options.MinimumLength)
         numericUpDownExpire.Value = Convert.ToDecimal(Options.DaysToExpire)
         numericUpDownMax.Value = Convert.ToDecimal(Options.MaxPasswordHistory)

         checkBoxIdleTimeout.Checked = Options.EnableIdleTimeout
         numericUpDownIdleTimeout.Value = Convert.ToDecimal(Options.IdleTimeOut)
      End Sub

      Private Sub ComplexityChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxNumber.CheckedChanged, checkBoxSymbol.CheckedChanged, checkBoxUppercase.CheckedChanged, checkBoxLowercase.CheckedChanged
         Dim checkBox As CheckBox = TryCast(sender, CheckBox)
         Dim complexity As Complexity = CType(checkBox.Tag, Complexity)

         If checkBox.Checked Then
            Options.Complexity = Options.Complexity Or complexity
         Else
            Options.Complexity = Options.Complexity And Not complexity
         End If
      End Sub

      Private Sub numericUpDownMinLength_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles numericUpDownMinLength.ValueChanged
         Options.MinimumLength = Convert.ToInt32(numericUpDownMinLength.Value)
      End Sub

      Private Sub numericUpDownExpire_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles numericUpDownExpire.ValueChanged
         Options.DaysToExpire = Convert.ToInt32(numericUpDownExpire.Value)
      End Sub

      Private Sub numericUpDownMax_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles numericUpDownMax.ValueChanged
         Options.MaxPasswordHistory = Convert.ToInt32(numericUpDownMax.Value)
      End Sub

      Private Sub checkBoxIdleTimeout_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxIdleTimeout.CheckedChanged
         Options.EnableIdleTimeout = checkBoxIdleTimeout.Checked
         numericUpDownIdleTimeout.Enabled = Options.EnableIdleTimeout
      End Sub

      Private Sub numericUpDownIdleTimeout_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles numericUpDownIdleTimeout.ValueChanged
         Options.IdleTimeOut = Convert.ToInt32(numericUpDownIdleTimeout.Value)
      End Sub
   End Class
End Namespace
