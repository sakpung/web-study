' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Namespace Leadtools.Demos.Workstation
   Public Interface IDicomInstancesSelectionView
	  Sub SetState(ByVal burningImages As IList(Of ClientQueryDataSet.ImagesRow))
	  Sub AddSeries(ByVal studyInformation As ClientQueryDataSet.StudiesRow, ByVal series As ClientQueryDataSet.SeriesRow, ByVal images() As ClientQueryDataSet.ImagesRow)
	  Sub ClearItems()

   End Interface
End Namespace
