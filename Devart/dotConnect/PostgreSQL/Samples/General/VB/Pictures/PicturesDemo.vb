Imports Devart.Data.PostgreSql
Imports System
Imports System.Data

Namespace Samples
  Public Class PicturesDemo
    Inherits Demo

    ' Fields
        Private Shadows Const descriptionFull As String = "This sample project demonstrates using dotConnect for PostgresSQL for working with BLOB objects as graphics. The sample demonstrates how to retrieve binary data from PostgresSQL database and display it at the monitor, load and save pictures into the file and the database."
        Private Shadows Const descriptionShort As String = "This sample project demonstrates using dotConnect for PostgresSQL for working with BLOB objects as graphics. The sample demonstrates how to retrieve binary data from PostgresSQL database and display it at the monitor, load and save pictures into the file and the database. At first, create table pgsqlnet_pictures executing script. Then enter picture name in the first row of table. Click the 'Load from file' button to put the binary data from the bitmap file to the DataSet. PgSqlDataAdapter updates binary data like any other data type.	<P></P>	<P></P> <B>Note:</B> the script to create the table is located in the DDL tab."

    ' Methods
    Public Sub New()
      MyBase.New("Pictures", descriptionShort, descriptionFull)
    End Sub

    Protected Overrides Function CreateDemoControl(ByVal connection As IDbConnection) As BaseDemoControl
      Return New PicturesDemoControl(DirectCast(connection, PgSqlConnection))
    End Function

    ' Properties
    Public Overrides ReadOnly Property CreateSql() As String
      Get
        Return "CREATE TABLE pgsqlnet_pictures (" & ChrW(13) & ChrW(10) & _
        "  UID SERIAL PRIMARY KEY," & ChrW(13) & ChrW(10) & _
        "  NAME VARCHAR(50)," & ChrW(13) & ChrW(10) & _
        "  PICTURE BYTEA" & ChrW(13) & ChrW(10) & _
        ");"
      End Get
    End Property

    Public Overrides ReadOnly Property DropSql() As String
      Get
        Return "DROP TABLE pgsqlnet_pictures;"
      End Get
    End Property
  End Class
End Namespace