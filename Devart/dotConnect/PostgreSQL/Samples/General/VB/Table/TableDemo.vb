Imports Devart.Data.PostgreSql
Imports System
Imports System.Data

Namespace Samples
  Public Class TableDemo
    Inherits Demo

    ' Fields
    Private Shadows Const descriptionFull As String = "This sample project demonstrates data mapping from PostgresSQL tables. The sample sets CommandType property of PgSqlCommand to TableDirect to access data from the table."
    Private Shadows Const descriptionShort As String = "This sample project demonstrates data mapping from PostgresSQL tables. The sample sets CommandType property of PgSqlCommand to TableDirect to access data from the table."

    ' Methods
    Public Sub New()
      MyBase.New("Table", descriptionShort, descriptionFull)
    End Sub

    Protected Overrides Function CreateDemoControl(ByVal connection As IDbConnection) As BaseDemoControl
      Return New TableDemoControl(DirectCast(connection, PgSqlConnection))
    End Function
  End Class
End Namespace