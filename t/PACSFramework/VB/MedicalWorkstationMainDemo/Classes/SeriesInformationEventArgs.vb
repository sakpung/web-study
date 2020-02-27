' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Demos.Workstation.Configuration
'using Leadtools.Demos.Workstation.UI.Search.QueryDataSet;

Namespace Leadtools.Demos.Workstation
   Public Class StoreSeriesEventArgs
	   Inherits ProcessSeriesEventArgs
	  Public Sub New(ByVal server As ScpInfo, ByVal study As ClientQueryDataSet.StudiesRow, ByVal series As ClientQueryDataSet.SeriesRow)
		  MyBase.New(study, series)
		 Me.Server = server
	  End Sub

	  Public Property Server() As ScpInfo
		 Get
			Return _server
		 End Get

		 Private Set(ByVal value As ScpInfo)
			_server = value
		 End Set
	  End Property

	  Private _server As ScpInfo
   End Class

   Public Class ProcessSeriesEventArgs
	   Inherits EventArgs
     Public Sub New(ByVal studyParam As ClientQueryDataSet.StudiesRow, ByVal seriesParam As ClientQueryDataSet.SeriesRow)
       Study = studyParam
       Series = seriesParam
     End Sub


	  Private privateStudy As ClientQueryDataSet.StudiesRow
	  Public Property Study() As ClientQueryDataSet.StudiesRow
		  Get
			  Return privateStudy
		  End Get
		  Private Set(ByVal value As ClientQueryDataSet.StudiesRow)
			  privateStudy = value
		  End Set
	  End Property

	  Private privateSeries As ClientQueryDataSet.SeriesRow
	  Public Property Series() As ClientQueryDataSet.SeriesRow
		  Get
			  Return privateSeries
		  End Get
		  Private Set(ByVal value As ClientQueryDataSet.SeriesRow)
			  privateSeries = value
		  End Set
	  End Property
   End Class
End Namespace
