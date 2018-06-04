Imports Devart.Data.PostgreSql
Imports System
Imports System.Data

Namespace Samples
  Public Class RowDataReaderDemo
    Inherits Demo

    ' Fields
    Private Shadows Const descriptionFull As String = "This sample project demonstrates using PgSqlDataReader class to obtain composite type values. The sample executes SQL statement at the PgSqlCommand and gets PgSqlDataReader to retrieve data."
    Private Shadows Const descriptionShort As String = "This sample project demonstrates using PgSqlDataReader class to obtain composite type values. The sample executes SQL statement at the PgSqlCommand and gets PgSqlDataReader to retrieve data."

    ' Methods
    Public Sub New()
      MyBase.New("RowDataReader", descriptionShort, descriptionFull)
    End Sub

    Protected Overrides Function CreateDemoControl(ByVal connection As IDbConnection) As BaseDemoControl
      Return New RowDataReaderDemoControl(DirectCast(connection, PgSqlConnection))
    End Function

    ' Properties
    Public Overrides ReadOnly Property CreateSql() As String
      Get
        Return "CREATE TABLE dept_container(" & ChrW(13) & ChrW(10) & "  id int4," & ChrW(13) & ChrW(10) & "  f_dept dept" & ChrW(13) & ChrW(10) & ");" & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "INSERT INTO test.dept_container VALUES(1, '(10,N a m e,location)')"
      End Get
    End Property

    Public Overrides ReadOnly Property DropSql() As String
      Get
        Return "DROP TABLE dept_container CASCADE"
      End Get
    End Property
  End Class
End Namespace