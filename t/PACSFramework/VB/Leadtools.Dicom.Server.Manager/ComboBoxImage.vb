' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Drawing
Imports System.ComponentModel.Design

Namespace Leadtools.Dicom.Server.Manager
   Public Class ComboBoxImage : Inherits ComboBox
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            MyBase.DrawMode = DrawMode.OwnerDrawVariable
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
            If Not components Is Nothing Then
                    components.Dispose()
                End If
            If Not Me.Items Is Nothing Then
                    For Each o As Object In Me.Items
                        If TypeOf o Is ComboItemImage Then
                            Dim item As ComboItemImage = TryCast(o, ComboItemImage)

                            item.Image = Nothing
                        End If
                    Next o
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Shadows ReadOnly Property DrawMode() As DrawMode
            Get
                Return DrawMode.OwnerDrawFixed
            End Get
        End Property

        <Editor(GetType(ImageComboItemEditor), GetType(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Shadows ReadOnly Property Items() As ObjectCollection
            Get
                Return MyBase.Items
            End Get
        End Property

        Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)
            If e.Index = -1 OrElse e.Index > Me.Items.Count - 1 Then
                Return
            End If

            e.DrawBackground()

         Dim imageRect As Rectangle = New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height)
            Dim textRectF As RectangleF = RectangleF.FromLTRB(imageRect.Right + 2, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom)

            If TypeOf Items(e.Index) Is ComboItemImage Then
                Dim Item As ComboItemImage = CType(Items(e.Index), ComboItemImage)

            If Not Item.Image Is Nothing Then
                    e.Graphics.DrawImage(Item.Image, imageRect)
                End If
            End If

         Dim TextBrush As SolidBrush = New SolidBrush(Me.ForeColor)

            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                TextBrush.Color = SystemColors.HighlightText
            End If

         Dim sf As StringFormat = New StringFormat(StringFormatFlags.NoWrap)

            sf.LineAlignment = StringAlignment.Center
            sf.Trimming = StringTrimming.EllipsisCharacter

            e.Graphics.DrawString(Items(e.Index).ToString(), Me.Font, TextBrush, textRectF, sf)
            TextBrush.Dispose()

            MyBase.OnDrawItem(e)
        End Sub

        Private currentIndex As Integer = -1

        Protected Overrides Sub OnSelectedIndexChanged(ByVal e As EventArgs)
            If Me.SelectedIndex <> currentIndex Then
                currentIndex = Me.SelectedIndex
                MyBase.RefreshItem(Me.SelectedIndex)
            Else
                MyBase.OnSelectedIndexChanged(e)
            End If
        End Sub

      Private Class ImageComboItemEditor : Inherits CollectionEditor
            Public Sub New(ByVal type As Type)
                MyBase.New(type)
            End Sub

            Protected Overrides Function CreateCollectionItemType() As Type
                Return GetType(ComboItemImage)
            End Function
        End Class
    End Class

    <DesignTimeVisible(False)> _
    Public Class ComboItemImage
        Private _item As Object
        Private _image As Image
        Private _tag As Object

        Public Property Item() As Object
            Get
                Return _item
            End Get
            Set(ByVal value As Object)
            _item = Value
            End Set
        End Property

        Public Property Image() As Image
            Get
                Return _image
            End Get
            Set(ByVal value As Image)
            _image = Value
            End Set
        End Property

        Public Property Tag() As Object
            Get
                Return _tag
            End Get
            Set(ByVal value As Object)
            _tag = Value
            End Set
        End Property

        <TypeConverter(GetType(StringConverter))> _
        Public Overrides Function ToString() As String
            If Item Is Nothing Then
                Return String.Empty
            Else
                Return Item.ToString()
            End If
        End Function

      Public Sub New(ByVal item_Renamed As Object)
         Item = item_Renamed
        End Sub
    End Class
End Namespace
