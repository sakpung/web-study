' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Forms.Processing

Partial Public Class TableRulesForm : Inherits Form
   Private _tableFormField As TableFormField
   Private _oldTableRules As TableRules

   Public Property RulesChanged() As Boolean
      Get
         Return m_RulesChanged
      End Get
      Set(value As Boolean)
         m_RulesChanged = Value
      End Set
   End Property
   Private m_RulesChanged As Boolean

   Public Sub New(ByVal tableFormField As TableFormField)
      InitializeComponent()
      _tableFormField = tableFormField
      _oldTableRules = tableFormField.Rules
      RulesChanged = False
      UpdateUI()
   End Sub

   Private Sub _ch_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _ch_RowsLineSeparator.CheckedChanged, _ch_EqualFixedRowHeight.CheckedChanged, _ch_EqualFixedLineHeight.CheckedChanged, _ch_MultiPageTableHeaderRepeted.CheckedChanged
      Dim rules As TableRules = TableRules.NoRules
      If _ch_RowsLineSeparator.Checked Then
         rules = rules Or TableRules.RowsLineSeparator
      End If
      If _ch_EqualFixedLineHeight.Checked Then
         rules = rules Or TableRules.EqualFixedLineHeight
      End If
      If _ch_EqualFixedRowHeight.Checked Then
         rules = rules Or TableRules.EqualFixedRowHeight
      End If
      If _ch_MultiPageTableHeaderRepeted.Checked Then
         rules = rules Or TableRules.MultiPageTableHeaderRepeted
      End If
      _tableFormField.Rules = rules
   End Sub

   Private Sub UpdateUI()
      Dim rules As TableRules = _tableFormField.Rules

      _ch_RowsLineSeparator.Checked = (rules And TableRules.RowsLineSeparator) = TableRules.RowsLineSeparator
      _ch_EqualFixedLineHeight.Checked = (rules And TableRules.EqualFixedLineHeight) = TableRules.EqualFixedLineHeight
      _ch_EqualFixedRowHeight.Checked = (rules And TableRules.EqualFixedRowHeight) = TableRules.EqualFixedRowHeight
      _ch_MultiPageTableHeaderRepeted.Checked = (rules And TableRules.MultiPageTableHeaderRepeted) = TableRules.MultiPageTableHeaderRepeted
   End Sub

   Private Sub TableRulesForm_FormClosing(sender As Object, e As FormClosingEventArgs)
      If _oldTableRules <> _tableFormField.Rules Then
         RulesChanged = True
      End If
   End Sub
End Class
