using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Web
{
  /// <summary>
  /// Summary description for WebForm1.
  /// </summary>
  public partial class WebForm : System.Web.UI.Page
  {
    protected Devart.Data.PostgreSql.PgSqlConnection connection;
    protected Devart.Data.PostgreSql.PgSqlDataAdapter sqlDataAdapter;
    protected Devart.Data.PostgreSql.PgSqlCommandBuilder sqlCommandBuilder;
    protected Devart.Data.PostgreSql.PgSqlCommand command;
    protected System.Data.DataSet dataSet;

    private void Page_Load(object sender, System.EventArgs e) {

      dataSet = (DataSet)HttpContext.Current.Session["dataset"];
    }

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
      //
      // CODEGEN: This call is required by the ASP.NET Web Form Designer.
      //
      InitializeComponent();
      base.OnInit(e);
      tbUsername.Text = connection.UserId;
      tbPassword.Text = connection.Password;

      tbPort.Text = connection.Port.ToString();
      tbServer.Text = connection.Host;

      tbDatabase.Text = connection.Database;
      tbSQL.Text = command.CommandText;
    }
    
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {    
      this.connection = new Devart.Data.PostgreSql.PgSqlConnection();
      this.command = new Devart.Data.PostgreSql.PgSqlCommand();
      this.sqlDataAdapter = new Devart.Data.PostgreSql.PgSqlDataAdapter();
      this.sqlCommandBuilder = new Devart.Data.PostgreSql.PgSqlCommandBuilder();
      this.btInsertRecord.Click += new System.EventHandler(this.btInsertRecord_Click);
      this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
      this.btFill.Click += new System.EventHandler(this.btFill_Click);
      this.btTest.Click += new System.EventHandler(this.btTest_Click);
      this.dataGrid.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dataGrid_CancelCommand);
      this.dataGrid.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dataGrid_EditCommand);
      this.dataGrid.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dataGrid_UpdateCommand);
      this.dataGrid.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dataGrid_DeleteCommand);
      // 
      // connection
      // 
      this.connection.ConnectionString = "User Id=postgres;Host=localhost;Database=testdb;Schema=test;";
      this.connection.Name = "connection";
      this.connection.Owner = this;
      // 
      // sqlCommand
      // 
      this.command.CommandText = "Select * from Dept";
      this.command.Name = "sqlCommand";
      this.command.Connection = this.connection;
  //    this.command.Owner = this;
      // 
      // sqlDataAdapter
      // 
      this.sqlDataAdapter.SelectCommand = this.command;
      // 
      // sqlCommandBuilder
      // 
      this.sqlCommandBuilder.DataAdapter = this.sqlDataAdapter;
      this.sqlCommandBuilder.Quoted = true;
      this.sqlCommandBuilder.UpdatingFields = "";
      this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    private void BindGrid() {

      if (dataSet.Tables["Table"] != null) {
        dataGrid.DataSource = dataSet.Tables["Table"].DefaultView;
        lbResult.Visible = true;
        btInsertRecord.Visible = true;
        if (dataSet.Tables["Table"].GetChanges() != null)
          lbInfo.Text = "Changed";
      }
      else {
        dataGrid.DataSource = null;
        lbResult.Visible = false;
        btInsertRecord.Visible = false;
      }

      dataGrid.DataBind();
    }

    private void btTest_Click(object sender, System.EventArgs e) {

      try {
        FillConnectionString();

        connection.Open();
        lbState.Text = "Success";
        lbState.ForeColor = Color.Blue;
        connection.Close();
      }
      catch (Exception exception) {
        lbState.Text = "Failed";
        lbState.ForeColor = Color.Red;
        lbError.Text = exception.Message;
      }
    }

    private void btFill_Click(object sender, System.EventArgs e) {

      try {
        FillConnectionString();

        command.CommandText = tbSQL.Text;

        dataSet = new System.Data.DataSet();
        sqlDataAdapter.Fill(dataSet, "Table");
        HttpContext.Current.Session["dataset"] = dataSet;

        lbInfo.Text = "Filled";
      }
      catch (Exception exception) {
        lbError.Text = exception.Message;
      }
      finally {
        BindGrid();
      }
    }

    private void btUpdate_Click(object sender, System.EventArgs e) {

      if (dataSet.Tables["Table"] != null)
        try {
          FillConnectionString();

          if (connection.State != ConnectionState.Open)
            connection.Open();

          command.CommandText = tbSQL.Text;
          sqlDataAdapter.Update(dataSet, "Table");
          lbInfo.Text = "Updated";
        }
        catch (Exception exception) {
          lbError.Text = exception.Message;
        }
        finally {
          BindGrid();
        }
    }

    private void btInsertRecord_Click(object sender, System.EventArgs e) {

      DataRow row = dataSet.Tables["Table"].NewRow();
      dataSet.Tables["Table"].Rows.Add(row);
      dataGrid.EditItemIndex = dataSet.Tables["Table"].Rows.Count - 1;
      BindGrid();
    }

    private void dataGrid_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e) {

      dataGrid.EditItemIndex = -1;
      BindGrid();
    }

    private void dataGrid_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e) {

      DataView view = new DataView(dataSet.Tables["Table"]);
      view.Delete(e.Item.ItemIndex);
      BindGrid();
    }

    private void dataGrid_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e) {

      dataGrid.EditItemIndex = (int)e.Item.ItemIndex;
      BindGrid();
    }

    private void dataGrid_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e) {

      for (int i = 2; i < e.Item.Cells.Count; i++) {
        string colValue =((TextBox)e.Item.Cells[i].Controls[0]).Text;

        if (string.IsNullOrEmpty(colValue) && dataSet.Tables["Table"].Columns[i - 2].DataType != typeof(String))
          dataSet.Tables["Table"].Rows[e.Item.ItemIndex][i - 2] = DBNull.Value;
        else
        dataSet.Tables["Table"].Rows[e.Item.ItemIndex][i - 2] = colValue;
      }

      dataGrid.EditItemIndex = -1;
      BindGrid();
    }

    private void FillConnectionString() {

      connection.UserId = tbUsername.Text;
      connection.Password = tbPassword.Text;
      connection.Database = tbDatabase.Text;
      connection.Host = tbServer.Text;
      connection.Port = Convert.ToInt32(tbPort.Text);
    }
  }
}
