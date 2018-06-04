Imports Devart.Data.PostgreSql
Imports System
Imports System.Data

Namespace Samples
  Public Class RowDataSetDemo
    Inherits Demo

    ' Fields
    Private Shadows Const descriptionFull As String = "This sample project demonstrates using dataset with dotConnect for PostgreSQL to review and update composite type values. The sample uses PgSqlDataAdapter to fill a dataset and post updated data to PostrgeSQL database. PgSqlDataAdapter uses PgSqlCommandBuilder class to automatically generate SQL for INSERT/UPDATE/DELETE operations."
    Private Shadows Const descriptionShort As String = "This sample project demonstrates using dataset with dotConnect for PostgreSQL to review and update composite type values. The sample uses PgSqlDataAdapter to fill a dataset and post updated data to PostrgeSQL database. PgSqlDataAdapter uses PgSqlCommandBuilder class to automatically generate SQL for INSERT/UPDATE/DELETE operations."

    ' Methods
    Public Sub New()
      MyBase.New("RowDataSet", descriptionShort, descriptionFull)
    End Sub

    Protected Overrides Function CreateDemoControl(ByVal connection As IDbConnection) As BaseDemoControl
      Return New RowDataSetDemoControl(DirectCast(connection, PgSqlConnection))
    End Function

    ' Properties
    Public Overrides ReadOnly Property CreateSql() As String
      Get
        Return "CREATE TABLE dept_container (" & ChrW(13) & ChrW(10) & "  id INT4," & ChrW(13) & ChrW(10) & "  f_dept DEPT" & ChrW(13) & ChrW(10) & ");" & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "INSERT INTO test.dept_container VALUES (1, '(10,N a m e,location)')"
      End Get
    End Property

    Public Overrides ReadOnly Property DropSql() As String
      Get
        Return "DROP TABLE dept_container CASCADE"
      End Get
    End Property
  End Class
End Namespace