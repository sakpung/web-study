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
Imports Leadtools.Medical.Worklist.DataAccessLayer
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.Worklist.DataAccessLayer.BusinessEntity
Imports VBCustomizingWorklistDAL.DataTypes
Imports Leadtools.Demos

Namespace VBCustomizingWorklistDAL.UI
   Partial Public Class WorklistUpdate : Inherits UserControl
      Private _source As List(Of DatabaseDicomTags)
      Private _queryResult As MWLDataset


      Public Sub New()
         InitializeComponent()

         _queryResult = Nothing
      End Sub

      Public Sub SetSource(ByVal source As List(Of DatabaseDicomTags))
         _source = source

         AddHandler QueryButton.Click, AddressOf QueryButton_Click
         AddHandler UpdateButton.Click, AddressOf UpdateButton_Click
      End Sub

      Private Sub UpdateButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is _queryResult Then
               Dim worklistAgent As IWorklistDataAccessAgent


               worklistAgent = DataAccessServices.GetDataAccessService(Of IWorklistDataAccessAgent)()

               worklistAgent.UpdateMWL(_queryResult)
            End If
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub QueryButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            Dim worklistAgent As IWorklistDataAccessAgent


            worklistAgent = DataAccessServices.GetDataAccessService(Of IWorklistDataAccessAgent)()

            _queryResult = worklistAgent.QueryModalityWorklists(New MatchingParameterCollection(), New System.Collections.Specialized.StringCollection())
            Dim tables As List(Of String) = New List(Of String)()

            tableLayoutPanel1.Controls.Clear()

            For Each dbTag As DatabaseDicomTags In _source
               If tables.Contains(dbTag.TableName) Then
                  Continue For
               End If

               Dim queryResultsDataGridView As DataGridView = New DataGridView()
               queryResultsDataGridView.AllowUserToAddRows = False

               AddHandler queryResultsDataGridView.ColumnAdded, AddressOf queryResultsDataGridView_ColumnAdded

               queryResultsDataGridView.DataSource = _queryResult
               queryResultsDataGridView.DataMember = dbTag.TableName
               queryResultsDataGridView.Dock = DockStyle.Fill

               queryResultsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize

               tables.Add(dbTag.TableName)

               tableLayoutPanel1.Controls.Add(queryResultsDataGridView)
            Next dbTag
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

     Private Sub queryResultsDataGridView_ColumnAdded(ByVal sender As Object, ByVal e As DataGridViewColumnEventArgs)
       Dim gridView As DataGridView = CType(sender, DataGridView)

       Dim source As DataSet = CType(gridView.DataSource, DataSet)
       Dim tableName As String = gridView.DataMember


       If source.Tables(tableName).PrimaryKey.Contains(source.Tables(tableName).Columns(e.Column.DataPropertyName)) Then
         e.Column.ReadOnly = True
       Else
         For Each relation As DataRelation In source.Tables(tableName).ParentRelations
            For Each column As DataColumn In relation.ChildColumns
              If source.Tables(tableName).Columns(e.Column.DataPropertyName) Is column Then
                e.Column.ReadOnly = True

                Exit For
              End If
            Next column

            If e.Column.ReadOnly Then
              Exit For
            End If
         Next relation
       End If

       For Each dbTag As DatabaseDicomTags In _source
         If e.Column.DataPropertyName = dbTag.ColumnName Then
            e.Column.CellTemplate.Style.BackColor = Color.Blue
            e.Column.CellTemplate.Style.ForeColor = Color.Red

            Exit For
         End If
       Next dbTag
     End Sub
   End Class
End Namespace
