Imports Devart.Data.PostgreSql
Imports System
Imports System.Data

Namespace Samples
  Public Class RefCursorDemo
    Inherits Demo

    ' Fields
    Private Shadows Const descriptionFull As String = "This sample project demonstrates using REF CURSOR type by calling function getDeptCursor(refcursor)." & ChrW(13) & ChrW(10) & "Notice that CURSOR is acessible only in a transaction."
    Private Shadows Const descriptionShort As String = "This sample project demonstrates using REF CURSOR type by calling function getDeptCursor(refcursor)."

    ' Methods
    Public Sub New()
      MyBase.New("RefCursor", descriptionShort, descriptionFull)
    End Sub

    Protected Overrides Function CreateDemoControl(ByVal connection As IDbConnection) As BaseDemoControl
      Return New RefCursorDemoControl(DirectCast(connection, PgSqlConnection))
    End Function

    ' Properties
    Public Overrides ReadOnly Property CreateSql() As String
      Get
        Return "CREATE FUNCTION getDeptCursor(refcursor) RETURNS refcursor" & ChrW(13) & ChrW(10) & "    AS '" & ChrW(13) & ChrW(10) & "BEGIN" & ChrW(13) & ChrW(10) & "  OPEN $1 FOR SELECT * from dept;" & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "  RETURN $1;" & ChrW(13) & ChrW(10) & "END;'" & ChrW(13) & ChrW(10) & "LANGUAGE plpgsql;"
      End Get
    End Property

    Public Overrides ReadOnly Property DropSql() As String
      Get
        Return "DROP FUNCTION getDeptCursor(refcursor);"
      End Get
    End Property
  End Class
End Namespace