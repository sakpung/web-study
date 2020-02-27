' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.Workstation.Commands


Namespace Leadtools.Demos.Workstation
   Public Class DisplayControlCommand
	   Implements ICommand
	  Public Sub New(ByVal container As Control, ByVal topControl As Control)
		 _container = container
		 _topControl = topControl

		 If (Not _container.Controls.Contains (_topControl)) Then
			_topControl.Visible = False

			_container.Controls.Add (_topControl)
		 End If
	  End Sub

     Public Sub Execute() Implements ICommand.Execute
       If (Not CanExecute()) Then
         Return
       End If

       OnDisplayControlExecuting(Me, New DisplayControlEventArgs(_container, _topControl))

       For Each displayedControl As Control In _container.Controls
         If displayedControl.Visible Then
            displayedControl.Visible = False

            Exit For
         End If
       Next displayedControl

       '_container.Controls.Clear ( ) ;

       _topControl.Dock = DockStyle.Fill

       _container.BackColor = _topControl.BackColor

       _topControl.Visible = True

       If (Not _container.Controls.Contains(_topControl)) Then
         _container.Controls.Add(_topControl)
       End If

       OnDisplayControlExecuted(Me, New DisplayControlEventArgs(_container, _topControl))
     End Sub

     Public Function CanExecute() As Boolean Implements ICommand.CanExecute
       Return Not (_container.Controls.Count = 1 AndAlso _container.Controls(0) Is _topControl)
     End Function

	  Public Event DisplayControlExecuting As EventHandler (Of DisplayControlEventArgs)
	  Public Event DisplayControlExecuted As EventHandler (Of DisplayControlEventArgs)

	  Protected Overridable Sub OnDisplayControlExecuting(ByVal sender As Object, ByVal e As DisplayControlEventArgs)
		 If Nothing IsNot DisplayControlExecutingEvent Then
			RaiseEvent DisplayControlExecuting(sender, e)
		 End If
	  End Sub

	  Protected Overridable Sub OnDisplayControlExecuted(ByVal sender As Object, ByVal e As DisplayControlEventArgs)
		 If Nothing IsNot DisplayControlExecutedEvent Then
			RaiseEvent DisplayControlExecuted(sender, e)
		 End If
	  End Sub

	  Private _container As Control
	  Private _topControl As Control
   End Class

   Public Class DisplayControlEventArgs
	   Inherits EventArgs
	  Public Sub New(ByVal parentControl As Control, ByVal displayControl As Control)
		 Me.ParentControl = parentControl
		 Me.DisplayControl = displayControl
	  End Sub

	  Public Property ParentControl() As Control
		 Get
			Return _parentControl
		 End Get

		 Private Set(ByVal value As Control)
			_parentControl = value
		 End Set
	  End Property

	  Public Property DisplayControl() As Control
		 Get
			Return _displayControl
		 End Get

		 Private Set(ByVal value As Control)
			_displayControl = value
		 End Set
	  End Property

	  Private _parentControl As Control
	  Private _displayControl As Control
   End Class
End Namespace
