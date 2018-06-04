Imports System
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace Samples
  Public Class BaseDemoControl
    Inherits UserControl

    ' Fields
    Private components As Container = Nothing
    Protected fieldWriteStatus1 As String = ""
    Protected fieldWriteStatus2 As String = ""

    ' Methods
    Public Sub New()
      Me.InitializeComponent()
    End Sub

    ' Properties
    <Browsable(False)> _
    Public ReadOnly Property WriteStatus1() As String
      Get
        Return Me.fieldWriteStatus1
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property WriteStatus2() As String
      Get
        Return Me.fieldWriteStatus2
      End Get
    End Property

    ' Events
    Public Event WriteStatus As WriteStatusHandler

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          components.Dispose()
        End If
      End If
      MyBase.Dispose(disposing)
    End Sub

    Private Sub InitializeComponent()
      MyBase.Name = "BaseDemoControl"
    End Sub

    ' Methods
    Protected Sub OnWriteStatus()
      If (Not Me.WriteStatusEvent Is Nothing) Then
        RaiseEvent WriteStatus(Me)
      End If
    End Sub

  End Class

  ' Nested
  Public Delegate Sub WriteStatusHandler(ByVal control As BaseDemoControl)

End Namespace