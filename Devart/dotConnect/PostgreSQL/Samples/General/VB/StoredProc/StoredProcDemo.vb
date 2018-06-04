Imports Devart.Data.PostgreSql
Imports System
Imports System.Data

Namespace Samples
  Public Class StoredProcDemo
    Inherits Demo

    ' Fields
    Private Shadows Const descriptionFull As String = "This sample project demonstrates how to execute a stored procedure and view modified data. Before running the sample, create two procedures by clicking the 'Execute' button from 'Create SQL' tab page. When procedures are ready, you can insert or update data in the 'Dept' table. The demo contains two PgSqlCommand objects. One PgSqlCommand has CommandType set to StoredProcedure and serves for adding and editing rows in the table. Another PgSqlCommand object is used to retrieve data from the table. After you finish with the sample you can remove procedures from the database on the 'Drop SQL' tab. <P></P>	<P></P><B>Note:</B> the script to create the stored procedures is located in the DDL tab."
    Private Shadows Const descriptionShort As String = "This sample project demonstrates how to execute a stored procedure and view modified data."

    ' Methods
    Public Sub New()
      MyBase.New("StoredProc", descriptionShort, descriptionFull, "StoredProc.bmp")
    End Sub

    Protected Overrides Function CreateDemoControl(ByVal connection As IDbConnection) As BaseDemoControl
      Return New StoredProcDemoControl(DirectCast(connection, PgSqlConnection))
    End Function

    ' Properties
    Public Overrides ReadOnly Property CreateSql() As String
      Get
        Return "CREATE FUNCTION Dept_Insert(IN INT,IN VARCHAR(14),IN VARCHAR(13))" & ChrW(13) & ChrW(10) & _
        "RETURNS VOID AS $$ " & ChrW(13) & ChrW(10) & _
        "INSERT INTO Dept(DeptNo, DName, Loc) VALUES($1, $2, $3); " & ChrW(13) & ChrW(10) & _
        "$$ LANGUAGE SQL;" & ChrW(13) & ChrW(10) & _
        "/" & ChrW(13) & ChrW(10) & _
        "CREATE FUNCTION Dept_Update(IN INT,IN VARCHAR(14),IN VARCHAR(13))" & ChrW(13) & ChrW(10) & _
        "RETURNS VOID AS $$ " & ChrW(13) & ChrW(10) & _
        "UPDATE Dept SET DName = $2, Loc = $3 WHERE DeptNo = $1;" & ChrW(13) & ChrW(10) & _
        "$$ LANGUAGE SQL;"
      End Get
    End Property

    Public Overrides ReadOnly Property DropSql() As String
      Get
        Return "DROP FUNCTION Dept_Insert(IN INT,IN VARCHAR(14),IN VARCHAR(13));" & ChrW(13) & ChrW(10) & _
        "DROP FUNCTION Dept_Update(IN INT,IN VARCHAR(14),IN VARCHAR(13));"
      End Get
    End Property
  End Class
End Namespace