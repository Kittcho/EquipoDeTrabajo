using System;
using System.Data;

namespace Samples
{
  public class TableDemoControl : BaseDemoControl
  {
    private System.Data.DataSet dataSet;
    private Devart.Data.PostgreSql.PgSqlConnection sqlConnection;
    private System.Windows.Forms.Panel topPanel;
    private System.Windows.Forms.Label lbDatabase;
    private System.Windows.Forms.ComboBox cbDatabase;
    private System.Windows.Forms.Label lbTableName;
    private System.Windows.Forms.ComboBox cbTableName;
    private System.Windows.Forms.Button btUpdate;
    private System.Windows.Forms.Button btClear;
    private System.Windows.Forms.Button btFill;
    private System.Windows.Forms.DataGrid dataGrid;
    private Devart.Data.PostgreSql.PgSqlCommand command;
    private Devart.Data.PostgreSql.PgSqlDataAdapter dataAdapter;
    private Devart.Data.PostgreSql.PgSqlCommandBuilder commandBuilder;
    private System.ComponentModel.IContainer components = null;

    public TableDemoControl() {

      InitializeComponent();
    }

    public TableDemoControl(Devart.Data.PostgreSql.PgSqlConnection connection)
      : this () {

      sqlConnection = connection;
      command.Connection = sqlConnection;

      cbDatabase.Text = command.Connection.Database;
      cbTableName.Text = string.Format("{0}.{1}", sqlConnection.Schema, command.CommandText);
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if (components != null) 
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    #region Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.dataSet = new System.Data.DataSet();
      this.command = new Devart.Data.PostgreSql.PgSqlCommand();
      this.dataAdapter = new Devart.Data.PostgreSql.PgSqlDataAdapter();
      this.commandBuilder = new Devart.Data.PostgreSql.PgSqlCommandBuilder();
      this.topPanel = new System.Windows.Forms.Panel();
      this.lbDatabase = new System.Windows.Forms.Label();
      this.cbDatabase = new System.Windows.Forms.ComboBox();
      this.lbTableName = new System.Windows.Forms.Label();
      this.cbTableName = new System.Windows.Forms.ComboBox();
      this.btUpdate = new System.Windows.Forms.Button();
      this.btClear = new System.Windows.Forms.Button();
      this.btFill = new System.Windows.Forms.Button();
      this.dataGrid = new System.Windows.Forms.DataGrid();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
      this.topPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // dataSet
      // 
      this.dataSet.DataSetName = "NewDataSet";
      this.dataSet.Locale = new System.Globalization.CultureInfo("en-US");
      // 
      // command
      // 
      this.command.CommandType = System.Data.CommandType.TableDirect;
      this.command.CommandText = "Dept";
      this.command.Name = "command";
      this.command.Owner = this;
      // 
      // dataAdapter
      // 
      this.dataAdapter.SelectCommand = this.command;
      // 
      // commandBuilder
      // 
      this.commandBuilder.DataAdapter = this.dataAdapter;
      this.commandBuilder.Quoted = true;
      this.commandBuilder.UpdatingFields = "";
      // 
      // topPanel
      // 
      this.topPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.lbDatabase,
                                                                           this.cbDatabase,
                                                                           this.lbTableName,
                                                                           this.cbTableName,
                                                                           this.btUpdate,
                                                                           this.btClear,
                                                                           this.btFill});
      this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.topPanel.Name = "topPanel";
      this.topPanel.Size = new System.Drawing.Size(477, 64);
      this.topPanel.TabIndex = 2;
      // 
      // lbDatabase
      // 
      this.lbDatabase.Location = new System.Drawing.Point(8, 36);
      this.lbDatabase.Name = "lbDatabase";
      this.lbDatabase.Size = new System.Drawing.Size(56, 16);
      this.lbDatabase.TabIndex = 8;
      this.lbDatabase.Text = "Database";
      // 
      // cbDatabase
      // 
      this.cbDatabase.Location = new System.Drawing.Point(67, 32);
      this.cbDatabase.Name = "cbDatabase";
      this.cbDatabase.Size = new System.Drawing.Size(160, 21);
      this.cbDatabase.Sorted = true;
      this.cbDatabase.TabIndex = 7;
      this.cbDatabase.DropDown += new System.EventHandler(this.cbDatabase_DropDown);
      this.cbDatabase.TextChanged += new System.EventHandler(this.cbDatabase_TextChanged);
      this.cbDatabase.Leave += new System.EventHandler(this.cbDatabase_Leave);
      // 
      // lbTableName
      // 
      this.lbTableName.Location = new System.Drawing.Point(232, 36);
      this.lbTableName.Name = "lbTableName";
      this.lbTableName.Size = new System.Drawing.Size(64, 16);
      this.lbTableName.TabIndex = 6;
      this.lbTableName.Text = "Table name";
      // 
      // cbTableName
      // 
      this.cbTableName.Location = new System.Drawing.Point(296, 32);
      this.cbTableName.Name = "cbTableName";
      this.cbTableName.Size = new System.Drawing.Size(172, 21);
      this.cbTableName.Sorted = true;
      this.cbTableName.TabIndex = 5;
      this.cbTableName.DropDown += new System.EventHandler(this.cbTableName_DropDown);
      this.cbTableName.Leave += new System.EventHandler(this.cbTableName_Leave);
      // 
      // btUpdate
      // 
      this.btUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btUpdate.Location = new System.Drawing.Point(152, 0);
      this.btUpdate.Name = "btUpdate";
      this.btUpdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.btUpdate.TabIndex = 4;
      this.btUpdate.Text = "Update";
      this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
      // 
      // btClear
      // 
      this.btClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btClear.Location = new System.Drawing.Point(76, 0);
      this.btClear.Name = "btClear";
      this.btClear.TabIndex = 3;
      this.btClear.Text = "Clear";
      this.btClear.Click += new System.EventHandler(this.btClear_Click);
      // 
      // btFill
      // 
      this.btFill.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btFill.Name = "btFill";
      this.btFill.TabIndex = 2;
      this.btFill.Text = "Fill";
      this.btFill.Click += new System.EventHandler(this.btFill_Click);
      // 
      // dataGrid
      // 
      this.dataGrid.AllowNavigation = false;
      this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dataGrid.CaptionVisible = false;
      this.dataGrid.DataMember = "";
      this.dataGrid.DataSource = this.dataSet;
      this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGrid.Location = new System.Drawing.Point(0, 64);
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.Size = new System.Drawing.Size(477, 270);
      this.dataGrid.TabIndex = 7;
      // 
      // TableDemoControl
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.dataGrid,
                                                                  this.topPanel});
      this.Name = "TableDemoControl";
      this.Size = new System.Drawing.Size(477, 334);
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
      this.topPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      this.ResumeLayout(false);

    }
    #endregion

    private void cbDatabase_DropDown(object sender, System.EventArgs e) {

      if (sqlConnection.State == System.Data.ConnectionState.Closed) {
        sqlConnection.Schema = "public";
        sqlConnection.Open();
      }

      cbDatabase.Items.Clear();
      DataTable databases = sqlConnection.GetSchema("Databases");
      foreach (DataRow row in databases.Rows)
        cbDatabase.Items.Add(row[0]);
    }

    private void cbDatabase_Leave(object sender, System.EventArgs e) {

        command.Connection.Database = cbDatabase.Text;
      }

    private void cbTableName_DropDown(object sender, System.EventArgs e) {

      if (sqlConnection.State == System.Data.ConnectionState.Closed) {
        sqlConnection.Schema = "public";
        sqlConnection.Open();
      }

      cbTableName.Items.Clear();
        DataTable tables = sqlConnection.GetSchema("Tables", new string[]{ "%" });
        foreach (DataRow row in tables.Rows) {
          string schema = row["schema"].ToString();
          string tname = row["name"].ToString();
          
          //need to be quoted?
          if (tname.Contains(" ") || string.Compare(tname, tname.ToLower(), false) != 0)
            tname = string.Format("{0}.\"{1}\"", schema, tname);
          else
            tname = string.Format("{0}.{1}", schema, tname);
          cbTableName.Items.Add(tname);
        }
    }

    private void cbTableName_Leave(object sender, System.EventArgs e) {

      command.CommandText = commandBuilder.QuoteIdentifier(cbTableName.Text);
      commandBuilder.RefreshSchema();
    }

    private void btFill_Click(object sender, System.EventArgs e) {

      dataAdapter.Fill(dataSet, "Table");
      dataGrid.DataMember = "Table";

      writeStatus1 = dataSet.Tables[0].Rows.Count + " rows in table " + cbTableName.Text;
      OnWriteStatus();
    }

    private void btClear_Click(object sender, System.EventArgs e) {

      dataGrid.DataMember = String.Empty;
      dataSet.Clear();
      foreach (DataTable table in dataSet.Tables)
        table.Columns.Clear();

      writeStatus1 = "";
      OnWriteStatus();
    }

    private void btUpdate_Click(object sender, System.EventArgs e) {

      dataAdapter.Update(dataSet, "Table");
    }

    private void cbDatabase_TextChanged(object sender, System.EventArgs e) {

      cbTableName.Items.Clear();
      cbTableName.Text = "";    
    }
  }
}

