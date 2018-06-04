Imports Devart.Data.PostgreSql
Imports System.Web
Imports System.Data

Partial Class WebForm
  Inherits System.Web.UI.Page
  Protected WithEvents connection As Devart.Data.PostgreSql.PgSqlConnection
  Protected WithEvents command As Devart.Data.PostgreSql.PgSqlCommand
  Protected WithEvents dataAdapter As Devart.Data.PostgreSql.PgSqlDataAdapter
  Protected WithEvents commandBuilder As Devart.Data.PostgreSql.PgSqlCommandBuilder
  Protected WithEvents myDataSet As System.Data.DataSet

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.connection = New Devart.Data.PostgreSql.PgSqlConnection()
    Me.command = New Devart.Data.PostgreSql.PgSqlCommand()
    Me.dataAdapter = New Devart.Data.PostgreSql.PgSqlDataAdapter()
    Me.commandBuilder = New Devart.Data.PostgreSql.PgSqlCommandBuilder()
    Me.myDataSet = New System.Data.DataSet()
    CType(Me.myDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
    '
    'connection
    '
    Me.connection.ConnectionString = "User Id=postgres;Host=localhost;Database=testdb;Schema=test;"
    Me.connection.Name = "SqlConnection"
    '
    'command
    '
    Me.command.CommandText = "SELECT * FROM Dept"
    Me.command.Connection = Me.connection
    Me.command.Name = "Command"
    '
    'dataAdapter
    '
    Me.dataAdapter.SelectCommand = Me.command
    '
    'commandBuilder
    '
    Me.commandBuilder.DataAdapter = Me.dataAdapter
    '
    'DataSet
    '
    Me.myDataSet.DataSetName = "NewDataSet"
    CType(Me.myDataSet, System.ComponentModel.ISupportInitialize).EndInit()
  End Sub

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()

    'MyBase.OnInit(e)
    tbUsername.Text = connection.UserId
    tbPassword.Text = connection.Password
    tbPort.Text = connection.Port.ToString()
    tbServer.Text = connection.Host
    tbDatabase.Text = connection.Database
    tbSQL.Text = command.CommandText
  End Sub


  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myDataSet = CType(HttpContext.Current.Session("dataset"), DataSet)
  End Sub

  Private Sub btTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTest.Click
    Try
      FillConnectionString()
      connection.Open()
      lbState.Text = "Success"
      lbState.ForeColor = System.Drawing.Color.Blue()
      connection.Close()
    Catch exception As Exception
      lbState.Text = "Failed"
      lbState.ForeColor = System.Drawing.Color.Red
      lbError.Text = exception.Message
    End Try
  End Sub

  Private Sub btFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFill.Click
    Try
      FillConnectionString()
      Me.command.CommandText = tbSQL.Text
      Me.myDataSet = New System.Data.DataSet()
      Me.dataAdapter.Fill(myDataSet, "Table")
      HttpContext.Current.Session("dataset") = myDataSet
      lbInfo.Text = "Filled"
    Catch exception As Exception
      lbError.Text = exception.Message
    Finally
      BindGrid()
    End Try
  End Sub

  Private Sub btUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUpdate.Click
    If myDataSet.Tables("Table") IsNot Nothing Then
      Try
        FillConnectionString()
        If Not (connection.State = ConnectionState.Open) Then
            connection.Open()
        End If
        Me.command.CommandText = tbSQL.Text
        Me.dataAdapter.Update(myDataSet, "Table")
        lbInfo.Text = "Updated"
      Catch exception As Exception
        lbError.Text = exception.Message
      Finally
        BindGrid()
      End Try
    End If
  End Sub

  Private Sub btInsertRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInsertRecord.Click
    Dim row As DataRow = myDataSet.Tables("Table").NewRow()
    myDataSet.Tables("Table").Rows.Add(row)
    dataGrid.EditItemIndex = myDataSet.Tables("Table").Rows.Count - 1
    BindGrid()
  End Sub

  Private Sub dataGrid_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dataGrid.EditCommand
    dataGrid.EditItemIndex = e.Item.ItemIndex
    BindGrid()
  End Sub

  Private Sub dataGrid_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dataGrid.UpdateCommand
    Dim I As Integer
    For I = 2 To e.Item.Cells.Count - 1
      Dim ColValue As String = CType(e.Item.Cells.Item(I).Controls.Item(0), TextBox).Text
      If String.IsNullOrEmpty(ColValue) And myDataSet.Tables("Table").Columns(I - 2).DataType IsNot GetType(String) Then
          myDataSet.Tables("Table").Rows(e.Item.ItemIndex)(I - 2) = DBNull.Value
      Else
          myDataSet.Tables("Table").Rows(e.Item.ItemIndex)(I - 2) = ColValue
      End If
    Next I
    dataGrid.EditItemIndex = -1
    BindGrid()
  End Sub

  Private Sub dataGrid_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dataGrid.CancelCommand
    dataGrid.EditItemIndex = -1
    BindGrid()
  End Sub

  Private Sub dataGrid_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dataGrid.DeleteCommand
    Dim view As DataView = New DataView(myDataSet.Tables("Table"))
    view.Delete(e.Item.ItemIndex)
    BindGrid()
  End Sub

  Private Sub BindGrid()
    If myDataSet.Tables("Table") IsNot Nothing Then
      dataGrid.DataSource = myDataSet.Tables("Table").DefaultView
      lbResult.Visible = True
      btInsertRecord.Visible = True
      If myDataSet.Tables("Table").GetChanges() IsNot Nothing Then
        lbInfo.Text = "Changed"
      End If
    Else
      dataGrid.DataSource = Nothing
      lbResult.Visible = False
      btInsertRecord.Visible = False
    End If

    dataGrid.DataBind()
  End Sub

  Private Sub FillConnectionString()
    connection.UserId = tbUsername.Text
    connection.Password = tbPassword.Text
    connection.Database = tbDatabase.Text
    connection.Host = tbServer.Text
    connection.Port = Convert.ToInt32(tbPort.Text)
  End Sub
End Class
