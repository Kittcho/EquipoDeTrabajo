Imports System
Imports System.Collections
Imports System.Runtime.CompilerServices

Namespace Samples
  Public Class History

    ' Fields
    Private historyList As ArrayList
    Private position As Integer = -1
    Private ReadOnly size As Integer

    ' Methods
    Public Sub New(ByVal visibleSize As Integer)
      Me.size = visibleSize
      Me.historyList = New ArrayList(visibleSize)
    End Sub

    ' Properties
    Public ReadOnly Property BackList() As ICollection
      Get
        Dim result As Object()
        If (Me.position < Me.size) Then
          result = New Object(Me.position - 1) {}
          Me.historyList.CopyTo(0, result, 0, Me.position)
          Return result
        End If
        result = New Object(Me.size - 1) {}
        Me.historyList.CopyTo((Me.position - Me.size), result, 0, Me.size)
        Return result
      End Get
    End Property

    Public ReadOnly Property Current() As Object
      Get
        Return Me.historyList.Item(Me.position)
      End Get
    End Property

    Public ReadOnly Property ForwardList() As ICollection
      Get
        Dim forwardSize As Integer = ((Me.historyList.Count - Me.position) - 1)
        If (forwardSize = 0) Then
          Return New Object(0 - 1) {}
        End If
        If (forwardSize > Me.size) Then
          forwardSize = Me.size
        End If
        Dim result As Object() = New Object(forwardSize - 1) {}
        Me.historyList.CopyTo((Me.position + 1), result, 0, forwardSize)
        Array.Reverse(result)
        Return result
      End Get
    End Property

    ' Events
    Public Event HistoryChanged As HistoryChangedHandler

    ' Methods
    Public Sub Add(ByVal item As Object)
      If (Me.position < (Me.historyList.Count - 1)) Then
        Dim indexRemove As Integer = (Me.position + 1)
        Me.historyList.RemoveRange(indexRemove, (Me.historyList.Count - indexRemove))
      End If
      Me.historyList.Add(item)
      Me.position += 1
      Me.OnHistoryChanged(Me)
    End Sub

    Public Sub Back()
      Me.BackTo(1)
    End Sub

    Public Sub BackTo(ByVal offset As Integer)
      Me.Navigate(-offset)
    End Sub

    Public Sub Forward()
      Me.ForwardTo(1)
    End Sub

    Public Sub ForwardTo(ByVal offset As Integer)
      Me.Navigate(offset)
    End Sub

    Private Sub Navigate(ByVal i As Integer)
      Me.position = (Me.position + i)
      Me.OnHistoryChanged(Me)
    End Sub

    Private Sub OnHistoryChanged(ByVal sender As History)
      If (Not HistoryChangedEvent Is Nothing) Then
        RaiseEvent HistoryChanged(Me)
      End If
    End Sub

  End Class
  ' Nested
  Public Delegate Sub HistoryChangedHandler(ByVal sender As History)

End Namespace