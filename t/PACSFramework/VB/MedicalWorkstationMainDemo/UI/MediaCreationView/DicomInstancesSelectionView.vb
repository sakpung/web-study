' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.Workstation

Namespace Leadtools.Demos.Workstation
   Partial Public Class DicomInstancesSelectionView
	   Inherits UserControl
	   Implements IDicomInstancesSelectionView
	  Public Sub New()
		 InitializeComponent ()

		 __CheckedInstances = New List(Of ClientQueryDataSet.ImagesRow) ()

		 _patientsNodes = New Dictionary(Of String,TreeNode)()
		 _studiesNodes = New Dictionary(Of String,TreeNode) ()
		 _seriesNodes = New Dictionary(Of String,TreeNode) ()
		 _imagesNodes = New Dictionary(Of String,TreeNode) ()


		 StudyNodesTreeView.ExpandAll ()

		 AddAllButton.Tag = New Action (Of TreeNode) (AddressOf CheckNode)
		 RemoveAllButton.Tag = New Action (Of TreeNode) (AddressOf UncheckNode)
		 EveryOtherImageButton.Tag = New Action (Of TreeNode) (AddressOf CheckEveryOther)

		 AddHandler StudyNodesTreeView.AfterCheck, AddressOf StudyNodesTreeView_AfterCheck

		 AddHandler AddAllButton.Click, AddressOf CheckActionAllButton_Click
		 AddHandler RemoveAllButton.Click, AddressOf CheckActionAllButton_Click
		 AddHandler EveryOtherImageButton.Click, AddressOf CheckActionSelectedButton_Click
		 AddHandler ClearButton.Click, AddressOf ClearButton_Click

	  End Sub

	  Public Sub ClearItems() Implements IDicomInstancesSelectionView.ClearItems
		 StudyNodesTreeView.Nodes.Clear ()
		 __CheckedInstances.Clear ()

		 _patientsNodes.Clear ()
		 _studiesNodes.Clear ()
		 _seriesNodes.Clear ()
		 _imagesNodes.Clear ()
	  End Sub

	  Private Sub CheckActionAllButton_Click(ByVal sender As Object, ByVal e As EventArgs)
		 Try
			For Each node As TreeNode In StudyNodesTreeView.Nodes
			   ApplyAction (node, CType((CType(sender, Button)).Tag, Action (Of TreeNode)))
			Next node
		 Catch exception As Exception
			ThreadSafeMessager.ShowError (exception.Message)
		 End Try
	  End Sub

	  Private Sub CheckActionSelectedButton_Click(ByVal sender As Object, ByVal e As EventArgs)
		 Try
			If Nothing IsNot StudyNodesTreeView.SelectedNode Then
			   ApplyAction (StudyNodesTreeView.SelectedNode, CType((CType(sender, Button)).Tag, Action (Of TreeNode)))
			End If
		 Catch exception As Exception
			ThreadSafeMessager.ShowError (exception.Message)
		 End Try
	  End Sub

	  Private Sub ClearButton_Click(ByVal sender As Object, ByVal e As EventArgs)
		 Try
			ClearItems ()
		 Catch exception As Exception
			ThreadSafeMessager.ShowError (exception.Message)
		 End Try
	  End Sub

	  Private Sub CheckNode(ByVal node As TreeNode)
		 If node.Checked <> True Then
			node.Checked = True
		 End If
	  End Sub

	  Private Sub UncheckNode(ByVal node As TreeNode)
		 If node.Checked <> False Then
			node.Checked = False
		 End If
	  End Sub

	  Private Sub CheckEveryOther(ByVal node As TreeNode)
		 Dim check As Boolean


		 check = node.Index Mod 2 = 0

		 If node.Checked <> check Then
			node.Checked = check
		 End If
	  End Sub

     Private Sub ApplyAction(ByVal selectedNode As TreeNode, ByVal action As Action(Of TreeNode))
       If selectedNode.Nodes.Count = 0 Then
         action(selectedNode)
       Else
         For Each node As TreeNode In selectedNode.Nodes
            ApplyAction(node, action)
         Next node
       End If
     End Sub

	  Private Sub StudyNodesTreeView_AfterCheck(ByVal sender As Object, ByVal e As TreeViewEventArgs)
		 Try
			VerifyInstanceCheckState (e.Node)

			If isUpdating Then
			   Return
			End If

			isUpdating = True

			Try
			   ApplyCheckToChilds (e.Node)

			   ApplyCheckToParents (e.Node)
			Finally
			   isUpdating = False
			End Try
		 Catch exception As Exception
			ThreadSafeMessager.ShowError (exception.Message)
		 End Try
	  End Sub

	  Private Sub VerifyInstanceCheckState(ByVal treeNode As TreeNode)
		 If TypeOf treeNode.Tag Is ClientQueryDataSet.ImagesRow Then
			If treeNode.Checked Then
			   Dim image As ClientQueryDataSet.ImagesRow


			   image = CType(treeNode.Tag, ClientQueryDataSet.ImagesRow)

			   If (Not __CheckedInstances.Contains (image)) Then
				  __CheckedInstances.Add (CType(treeNode.Tag, ClientQueryDataSet.ImagesRow))
			   End If
			Else
			   __CheckedInstances.Remove (CType(treeNode.Tag, ClientQueryDataSet.ImagesRow))
			End If
		 End If
	  End Sub

	  Private Sub ApplyCheckToParents(ByVal treeNode As TreeNode)
		 If treeNode.Parent IsNot Nothing Then
			If (Not treeNode.Checked) Then
			   If treeNode.Parent.Checked <> treeNode.Checked Then
				  treeNode.Parent.Checked = treeNode.Checked
			   End If

			   ApplyCheckToParents (treeNode.Parent)
			Else
			   If IsAllSiblingsChecked (treeNode) Then
				  If treeNode.Parent.Checked <> treeNode.Checked Then
					 treeNode.Parent.Checked = treeNode.Checked
				  End If

				  ApplyCheckToParents (treeNode.Parent)
			   End If
			End If
		 End If
	  End Sub

	  Private Function IsAllSiblingsChecked(ByVal treeNode As TreeNode) As Boolean
		 For Each node As TreeNode In treeNode.Parent.Nodes
			If (Not node.Checked) Then
			   Return False
			End If
		 Next node

		 Return True
	  End Function

	  Private Sub ApplyCheckToChilds(ByVal treeNode As TreeNode)
		 For Each childNode As TreeNode In treeNode.Nodes
			If childNode.Checked <> treeNode.Checked Then
			   childNode.Checked = treeNode.Checked
			End If

			ApplyCheckToChilds (childNode)
		 Next childNode
	  End Sub

	  Public Sub AddSeries(ByVal studyInformation As ClientQueryDataSet.StudiesRow, ByVal series As ClientQueryDataSet.SeriesRow, ByVal images() As ClientQueryDataSet.ImagesRow) Implements IDicomInstancesSelectionView.AddSeries
		 Dim patientNode As TreeNode


		 patientNode = FindPatientNode (studyInformation)

		 If Nothing IsNot patientNode Then
			Dim studyNode As TreeNode = FindStudyNode (studyInformation, patientNode)

			If studyNode IsNot Nothing Then
			   Dim seriesNode As TreeNode = FindSeriesNode (series, studyNode)

			   If Nothing IsNot seriesNode Then
				  For Each instanceInfo As ClientQueryDataSet.ImagesRow In images
					 Dim instanceNode As TreeNode = FindInstanceNode (instanceInfo, seriesNode)

					 If Nothing Is instanceNode Then
						CreateInstanceNode (instanceInfo, seriesNode)
					 End If
				  Next instanceInfo
			   Else
				  CreateSeriesNode (series, images, studyNode)
			   End If
			Else
			   CreateStudyNode (studyInformation, series, images, patientNode)
			End If
		 Else
			CreatePatientNode (studyInformation, series, images)
		 End If
	  End Sub

	  Private Sub CreatePatientNode(ByVal studyInformation As ClientQueryDataSet.StudiesRow, ByVal series As ClientQueryDataSet.SeriesRow, ByVal images() As ClientQueryDataSet.ImagesRow)
		 Dim patientText As String


		 If (Not studyInformation.IsPatientNameNull ()) AndAlso (Not String.IsNullOrEmpty (studyInformation.PatientName)) Then
			patientText = studyInformation.PatientName
		 ElseIf (Not studyInformation.IsPatientIDNull ()) AndAlso (Not String.IsNullOrEmpty (studyInformation.PatientID)) Then
			patientText = studyInformation.PatientID
		 Else
			patientText = "Unknown"
		 End If

		 Dim patientNode As TreeNode = StudyNodesTreeView.Nodes.Add (If(studyInformation.IsPatientNameNull (), "Unknown", studyInformation.PatientName))


		 patientNode.Tag = studyInformation

		 _patientsNodes.Add (If(studyInformation.IsPatientIDNull (), "Unknown", studyInformation.PatientID), patientNode)

		 CreateStudyNode (studyInformation, series, images, patientNode)
	  End Sub

	  Private Sub CreateStudyNode(ByVal studyInformation As ClientQueryDataSet.StudiesRow, ByVal series As ClientQueryDataSet.SeriesRow, ByVal images() As ClientQueryDataSet.ImagesRow, ByVal parentNode As TreeNode)
		 Dim studyText As String = String.Empty


		 If (Not studyInformation.IsStudyDescriptionNull ()) AndAlso (Not String.IsNullOrEmpty (studyInformation.StudyDescription)) Then
			studyText = studyInformation.StudyDescription
		 Else
			studyText = studyInformation.StudyInstanceUID
		 End If

		 Dim studyNode As TreeNode = parentNode.Nodes.Add (studyText)


		 studyNode.Tag = studyInformation

		 _studiesNodes.Add (studyInformation.StudyInstanceUID, studyNode)

		 CreateSeriesNode (series, images, studyNode)

	  End Sub

	  Private Sub CreateSeriesNode(ByVal series As ClientQueryDataSet.SeriesRow, ByVal instances() As ClientQueryDataSet.ImagesRow, ByVal studyNode As TreeNode)
		 Dim seriesText As String = String.Empty
		 Dim seriesNode As TreeNode

		 If (Not series.IsSeriesNumberNull ()) OrElse (Not String.IsNullOrEmpty (series.SeriesNumber)) Then
			seriesText &= "#" & series.SeriesNumber & ": "
		 End If

		 If (Not series.IsSeriesDescriptionNull ()) AndAlso (Not String.IsNullOrEmpty (series.SeriesDescription)) Then
			seriesText &= series.SeriesDescription
		 End If

		 If String.IsNullOrEmpty (seriesText) Then
			seriesText = series.SeriesInstanceUID
		 End If

		 seriesNode = studyNode.Nodes.Add (seriesText)

		 seriesNode.Tag = series

		 _seriesNodes.Add (series.SeriesInstanceUID, seriesNode)

		 For Each instance As ClientQueryDataSet.ImagesRow In instances
			CreateInstanceNode (instance, seriesNode)
		 Next instance
	  End Sub

	  Private Sub CreateInstanceNode(ByVal instanceInfo As ClientQueryDataSet.ImagesRow, ByVal seriesNode As TreeNode)
		 Dim instanceText As String
		 Dim instanceNode As TreeNode


		 If instanceInfo.IsInstanceNumberNull () OrElse String.IsNullOrEmpty (instanceInfo.InstanceNumber) Then
			instanceText = instanceInfo.SOPInstanceUID
		 Else
			instanceText = instanceInfo.InstanceNumber
		 End If

		 instanceNode = New TreeNode (instanceText)

		 instanceNode.Tag = instanceInfo

		 _imagesNodes.Add (instanceInfo.SOPInstanceUID, instanceNode)

		 seriesNode.Nodes.Add (instanceNode)

		 instanceNode.Checked = __CheckedInstances.Contains (instanceInfo)
	  End Sub

	  Private Function FindInstanceNode(ByVal instanceInfo As ClientQueryDataSet.ImagesRow, ByVal seriesNode As TreeNode) As TreeNode
		 If _imagesNodes.ContainsKey (instanceInfo.SOPInstanceUID) Then
			Return _imagesNodes (instanceInfo.SOPInstanceUID)
		 Else
			Return Nothing
		 End If
	  End Function

	  Private Function FindSeriesNode(ByVal series As ClientQueryDataSet.SeriesRow, ByVal studyNode As TreeNode) As TreeNode
		 If _seriesNodes.ContainsKey (series.SeriesInstanceUID) Then
			Return _seriesNodes (series.SeriesInstanceUID)
		 Else
			Return Nothing
		 End If
	  End Function

	  Private Function FindStudyNode(ByVal studyRow As ClientQueryDataSet.StudiesRow, ByVal patientNode As TreeNode) As TreeNode
		 If _studiesNodes.ContainsKey (studyRow.StudyInstanceUID) Then
			Return _studiesNodes (studyRow.StudyInstanceUID)
		 Else
			Return Nothing
		 End If
	  End Function

	  Private Function FindPatientNode(ByVal studyRow As ClientQueryDataSet.StudiesRow) As TreeNode
		 Dim patientID As String


		 patientID = If(studyRow.IsPatientIDNull (), "Unknown", studyRow.PatientID)

		 If _patientsNodes.ContainsKey (patientID) Then
			Return _patientsNodes (patientID)
		 Else
			Return Nothing
		 End If
	  End Function

	  Private isUpdating As Boolean = False

	  Private private__CheckedInstances As IList(Of ClientQueryDataSet.ImagesRow)
	  Private Property __CheckedInstances() As IList(Of ClientQueryDataSet.ImagesRow)
		  Get
			  Return private__CheckedInstances
		  End Get
		  Set(ByVal value As IList(Of ClientQueryDataSet.ImagesRow))
			  private__CheckedInstances = value
		  End Set
	  End Property

	  Private _patientsNodes As Dictionary(Of String, TreeNode)
	  Private _studiesNodes As Dictionary(Of String, TreeNode)
	  Private _seriesNodes As Dictionary(Of String, TreeNode)
	  Private _imagesNodes As Dictionary(Of String, TreeNode)

	  Public Sub SetState(ByVal burningImages As IList(Of ClientQueryDataSet.ImagesRow)) Implements IDicomInstancesSelectionView.SetState
		 __CheckedInstances = burningImages
	  End Sub
   End Class

   Public Class StudyNodeInformation
	   Inherits StudyInformation
	  Public Sub New(ByVal studyInfo As StudyInformation)
		  MyBase.New(studyInfo.PatientID, studyInfo.StudyInstanceUID)
	  End Sub


	  Private privateSeries As SeriesNodeInformation()
	  Public Property Series() As SeriesNodeInformation()
		  Get
			  Return privateSeries
		  End Get
		  Set(ByVal value As SeriesNodeInformation())
			  privateSeries = value
		  End Set
	  End Property
   End Class

   Public Class SeriesNodeInformation
	   Inherits SeriesInformation
	  Public Sub New(ByVal seriesInfo As SeriesInformation)
		  MyBase.New(seriesInfo.PatientId, seriesInfo.StudyInstanceUID, seriesInfo.SeriesInstanceUID, seriesInfo.Description)
	  End Sub

	  Private privateInstances As InstanceInformation()
	  Public Property Instances() As InstanceInformation()
		  Get
			  Return privateInstances
		  End Get
		  Set(ByVal value As InstanceInformation())
			  privateInstances = value
		  End Set
	  End Property
   End Class


	Public Class MyTreeView
		Inherits TreeView
		#Region "Constructors"
		Public Sub New()
		End Sub
		#End Region

		Protected Overrides Sub WndProc(ByRef m As Message)
			' Suppress WM_LBUTTONDBLCLK on checkbox
			If m.Msg = &H0203 AndAlso CheckBoxes AndAlso IsOnCheckBox(m) Then
				m.Result = IntPtr.Zero
			Else
				MyBase.WndProc(m)
			End If
		End Sub

		#Region "Double-click check"
		Private Function GetXLParam(ByVal lParam As IntPtr) As Integer
			Return lParam.ToInt32() And &Hffff
		End Function

		Private Function GetYLParam(ByVal lParam As IntPtr) As Integer
			Return lParam.ToInt32() >> 16
		End Function

		Private Function IsOnCheckBox(ByVal m As Message) As Boolean
			Dim x As Integer = GetXLParam(m.LParam)
			Dim y As Integer = GetYLParam(m.LParam)
			Dim node As TreeNode = GetNodeAt(x, y)
			If node Is Nothing Then
				Return False
			End If
			Dim iconWidth As Integer = If(ImageList Is Nothing, 0, ImageList.ImageSize.Width)
			Dim right As Integer = node.Bounds.Left - iconWidth
			Dim left As Integer = right - CHECKBOX_WIDTH
			Return left <= x AndAlso x <= right
		End Function

		Private Const CHECKBOX_WIDTH As Integer = 16
		#End Region
	End Class
End Namespace
