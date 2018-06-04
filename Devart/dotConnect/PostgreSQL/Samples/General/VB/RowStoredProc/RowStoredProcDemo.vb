Imports Devart.Data.PostgreSql
Imports System
Imports System.Data

Namespace Samples
  Public Class RowStoredProcDemo
    Inherits Demo

    ' Fields
    Private Shadows Const descriptionFull As String = "This sample project demonstrates execution of stored procedure that uses a composite type value."
    Private Shadows Const descriptionShort As String = "This sample project demonstrates execution of stored procedure that uses a composite type value."

    ' Methods
    Public Sub New()
      MyBase.New("RowStoredProc", descriptionShort, descriptionFull)
    End Sub

    Protected Overrides Function CreateDemoControl(ByVal connection As IDbConnection) As BaseDemoControl
      Return New RowStoredProcDemoControl(DirectCast(connection, PgSqlConnection))
    End Function

    ' Properties
    Public Overrides ReadOnly Property CreateSql() As String
      Get
        Return "CREATE OR REPLACE FUNCTION getdept(dept_container)" & ChrW(13) & ChrW(10) & "  RETURNS dept AS" & ChrW(13) & ChrW(10) & "'DECLARE" & ChrW(13) & ChrW(10) & "  dept_container Alias for $1;" & ChrW(13) & ChrW(10) & "  rc dept%ROWTYPE;" & ChrW(13) & ChrW(10) & "  BEGIN" & ChrW(13) & ChrW(10) & "  rc := $1.f_dept;" & ChrW(13) & ChrW(10) & "  return rc;" & ChrW(13) & ChrW(10) & "  END;" & ChrW(13) & ChrW(10) & "' LANGUAGE 'plpgsql' VOLATILE;"
      End Get
    End Property

    Public Overrides ReadOnly Property DropSql() As String
      Get
        Return "DROP FUNCTION getdept(dept_container)"
      End Get
    End Property
  End Class
End Namespace