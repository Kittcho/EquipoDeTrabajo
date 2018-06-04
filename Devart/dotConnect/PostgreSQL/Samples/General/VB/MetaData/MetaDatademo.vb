Imports Devart.Data.PostgreSql
Imports System
Imports System.Data

Namespace Samples
  Public Class MetaDataDemo
    Inherits Demo

    ' Fields
    Private Shadows Const descriptionFull As String = "<P>This sample project shows how to retrieve information about databases, tables," & ChrW(13) & ChrW(10) & "columns, users, and so on. The only method used for these tasks is <B>GetSchema</B>." & ChrW(13) & ChrW(10) & "<P>At the TreeView the results of calling GetSchema() without parameters are shown." & ChrW(13) & ChrW(10) & "This list represents keywords allowed to be passed to the method as first " & ChrW(13) & ChrW(10) & "parameter, or types of PostgresSQL's objects. After some node is " & ChrW(13) & ChrW(10) & "selected, DataGrid displays the collection returned by GetSchema('selected " & ChrW(13) & ChrW(10) & "node'). In the PropertyGrid there are restrictions list for selected object. You " & ChrW(13) & ChrW(10) & "can assign any restrictions and click the 'Refresh' button. For example, specify " & ChrW(13) & ChrW(10) & "only Owner = sys for Tables and click 'Refresh' to see all tables of the user sys in the DataGrid.</P>"
    Private Shadows Const descriptionShort As String = "This sample project shows how to retrieve information about databases, tables, " & ChrW(13) & ChrW(10) & "columns, users, and so on. The only method used for these tasks is <b>GetSchema</b>."

    ' Methods
    Public Sub New()
      MyBase.New("MetaData", descriptionShort, descriptionFull)
    End Sub

    Protected Overrides Function CreateDemoControl(ByVal connection As IDbConnection) As BaseDemoControl
      Return New MetaDataDemoControl(DirectCast(connection, PgSqlConnection))
    End Function
  End Class
End Namespace