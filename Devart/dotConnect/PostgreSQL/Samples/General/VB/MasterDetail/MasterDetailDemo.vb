Imports Devart.Data.PostgreSql
Imports System
Imports System.Data

Namespace Samples
  Public Class MasterDetailDemo
    Inherits Demo

    ' Fields
    Private Shadows Const descriptionFull As String = "This sample project demonstrates setting master-detail relation in an untyped dataset. The sample fills two tables in a dataset using two PgSqlDataAdapters and sets master-detail relation between them. For successfull Select/Update commands PgSqlDataAdapter requires PgSqlCommandBuilder and PgSqlCommand with a valid PgSqlConnection. After DataSet is filled, you can navigate in the top DataGrid, which shows the parent table Dept, and see rows of the child table Emp in the bottom DataGrid."
    Private Shadows Const descriptionShort As String = "This sample project demonstrates setting master-detail relation in an untyped dataset. The sample fills two tables in a dataset using PgSqlDataAdapter and sets master-detail relation between them."

    ' Methods
    Public Sub New()
      MyBase.New("MasterDetail", descriptionShort, descriptionFull, "MasterDetail.bmp")
    End Sub

    Protected Overrides Function CreateDemoControl(ByVal connection As IDbConnection) As BaseDemoControl
      Return New MasterDetailDemoControl(DirectCast(connection, PgSqlConnection))
    End Function
  End Class
End Namespace