' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Threading

Namespace PDFDocumentDemo.Workers
   Friend Class ThreadedPageWorkerPageProcessedEventArgs : Inherits EventArgs
      Private Sub New()
      End Sub

      Public Sub New(ByVal pageNumber_Renamed As Integer, ByVal data_Renamed As Object, ByVal error_Renamed As Exception)
         _pageNumber = pageNumber_Renamed
         _data = data_Renamed
         _error = error_Renamed
      End Sub

      Private _pageNumber As Integer
      Public ReadOnly Property PageNumber() As Integer
         Get
            Return _pageNumber
         End Get
      End Property

      Private _data As Object
      Public ReadOnly Property Data() As Object
         Get
            Return _data
         End Get
      End Property

      Private _error As Exception
      Public ReadOnly Property [Error]() As Exception
         Get
            Return _error
         End Get
      End Property
   End Class

   ' Base class for a threaded helper that works on pages
   Friend MustInherit Class ThreadedPageWorker : Implements IDisposable
      Protected Sub New()
      End Sub

      Protected Overrides Sub Finalize()
         Dispose(False)
      End Sub

      Public Sub Dispose() Implements IDisposable.Dispose
         Dispose(True)
         GC.SuppressFinalize(Me)
      End Sub

      Protected Overridable Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            ' Stop first
            StopWork()
         End If
      End Sub

      ' Our thread
      Private _thread As Thread
      ' Synchronization object
      Private Shared _threadLockObject As Object = New Object()
      ' Fires when loading all threads is finished or when aborted
      Private _finishedEvent As AutoResetEvent
      ' Indicates the pages that have been visited, when all is true, we are done
      Private _visited As Boolean()

      Private _isWorking As Boolean
      Private _IsAbortPending As Boolean

      ' Are we working?
      Public ReadOnly Property IsWorking() As Boolean
         Get
            SyncLock _threadLockObject
               Return _isWorking
            End SyncLock
         End Get
      End Property

      ' Are we aborting?
      Public Property IsAbortPending() As Boolean
         Get
            SyncLock _threadLockObject
               Return _IsAbortPending
            End SyncLock
         End Get
         Set(value As Boolean)
            SyncLock _threadLockObject
               _IsAbortPending = Value
            End SyncLock
         End Set
      End Property

      Private _nextPageNumber As Integer

      ' Next page number to work, start at 1. Can be changed for example if this is a thumbnail generator and the UI changes
      ' this value when the image list scrolls
      Public Property NextPageNumber() As Integer
         Get
            SyncLock _threadLockObject
               Return _nextPageNumber
            End SyncLock
         End Get
         Set(value As Integer)
            SyncLock _threadLockObject
               _nextPageNumber = Value
            End SyncLock
         End Set
      End Property

      ' Start working
      Protected Sub StartWork(ByVal pageCount As Integer)
         ' Stop before we start again
         StopWork()

         ' Create the thread
         _thread = New Thread(New ParameterizedThreadStart(AddressOf ThreadProc))
         _thread.IsBackground = True

         ' Create the events
         _finishedEvent = New AutoResetEvent(False)
         ' Reset the visited pages
         _visited = New Boolean(pageCount - 1) {}

         ' Next page is first page
         NextPageNumber = 1

         ' Start working
         _isWorking = True
         _IsAbortPending = False
         _thread.Start(pageCount)
      End Sub

      Protected Sub StopWork()
         If Not _thread Is Nothing AndAlso IsWorking Then
            ' Abort
            IsAbortPending = True
            _finishedEvent.WaitOne()

            _thread = Nothing

            _finishedEvent.Close()
            _finishedEvent = Nothing
            _isWorking = False
         End If
      End Sub

      Protected MustOverride Function ProcessPage(ByVal pageNumber As Integer) As ThreadedPageWorkerPageProcessedEventArgs

      ' Fires everytime a page is processed (before and after)
      Public Event PrePageProcessed As EventHandler(Of ThreadedPageWorkerPageProcessedEventArgs)
      Public Event PostPageProcessed As EventHandler(Of ThreadedPageWorkerPageProcessedEventArgs)
      Public Event ProcessFinished As EventHandler(Of EventArgs)

      ' Get the next page to work on
      Private Function GetNextPageNumber(ByVal pageCount As Integer) As Integer
         ' Find the next page to process
         Dim pageNumber As Integer = NextPageNumber
         If pageNumber < 1 Then
            pageNumber = 1
         End If

         Do While pageNumber <= pageCount AndAlso _visited(pageNumber - 1)
            pageNumber += 1
         Loop

         If pageNumber > pageCount Then
            pageNumber = 1
            Do While pageNumber <= pageCount AndAlso _visited(pageNumber - 1)
               pageNumber += 1
            Loop
         End If

         Return pageNumber
      End Function

      Private Sub ThreadProc(ByVal state As Object)
         Dim pageCount As Integer = CInt(state)
         Try
            Dim done As Boolean = False
            Dim visitedCount As Integer = 0
            Do While Not done
               ' Check if we need to abort
               If IsAbortPending Then
                  Return
               End If

               ' Get next page number
               Dim pageNumber As Integer = GetNextPageNumber(pageCount)

               If pageNumber > pageCount Then
                  ' We are done
                  Return
               End If

               ' We worked on this
               _visited(pageNumber - 1) = True

               If Not PrePageProcessedEvent Is Nothing Then
                  Dim e As ThreadedPageWorkerPageProcessedEventArgs = New ThreadedPageWorkerPageProcessedEventArgs(pageNumber, Nothing, Nothing)
                  RaiseEvent PrePageProcessed(Me, e)
               End If

               visitedCount += 1

               ' Report it
               If Not PostPageProcessedEvent Is Nothing Then
                  Dim e As ThreadedPageWorkerPageProcessedEventArgs = ProcessPage(pageNumber)
                  RaiseEvent PostPageProcessed(Me, e)
               End If

               If visitedCount >= pageCount Then
                  done = True
               End If
            Loop
         Finally
            If Not ProcessFinishedEvent Is Nothing Then
               RaiseEvent ProcessFinished(Me, EventArgs.Empty)
            End If

            _finishedEvent.Set()
         End Try
      End Sub
   End Class
End Namespace
