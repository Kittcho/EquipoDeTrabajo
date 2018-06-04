Imports Devart.Data.PostgreSql
Imports System
Imports System.Data

Namespace Samples
  Public Class TransactionsDemo
    Inherits Demo

    ' Fields
    Private Shadows Const descriptionFull As String = "This sample project demonstrates working with PostgresSQL transactions in dotConnect for PostgresSQL. The sample demonstrates how to get a PgSqlTransaction object from a PgSqlConnection object, how to commit or rollback a transaction."
    Private Shadows Const descriptionShort As String = "This sample project demonstrates working with PostgresSQL transactions in dotConnect for PostgresSQL. The sample demonstrates how to get a PgSqlTransaction object from a PgSqlConnection object, how to commit or rollback a transaction."

    ' Methods
    Public Sub New()
      MyBase.New("Transactions", descriptionShort, descriptionFull)
    End Sub

    Protected Overrides Function CreateDemoControl(ByVal connection As IDbConnection) As BaseDemoControl
      Return New TransactionsDemoControl(DirectCast(connection, PgSqlConnection))
    End Function
  End Class
End Namespace