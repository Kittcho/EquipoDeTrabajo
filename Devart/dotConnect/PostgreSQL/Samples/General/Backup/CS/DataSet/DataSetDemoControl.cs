using System;

namespace Samples
{
  /// <summary>
  /// Summary description for DataSetDemoControl.
  /// </summary>
  public class DataSetDemoControl : BaseDemoControl {
    private System.Windows.Forms.Panel pnTop;
    private System.Windows.Forms.Button btClear;
    private System.Windows.Forms.Button btFill;
    private System.Windows.Forms.Button btUpdate;
    private System.Windows.Forms.TextBox tbSql;
    private System.Windows.Forms.Splitter splitter;
    private System.Windows.Forms.DataGrid dataGrid;
    private System.Data.DataSet myDataSet;
    private Devart.Data.PostgreSql.PgSqlCommand command;
    private Devart.Data.PostgreSql.PgSqlDataAdapter dataAdapter;
    private Devart.Data.PostgreSql.PgSqlCommandBuilder commandBuilder;

    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public DataSetDemoControl() {

      InitializeComponent();
    }

    public DataSetDemoControl(Devart.Data.PostgreSql.PgSqlConnection connection) 
    : this() {

      this.command.Connection = connection;
      this.tbSql.Text = this.command.CommandText;
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing ) {
        if( disposing ) {
            if(components != null) {
                components.Dispose();
            }
        }
        base.Dispose( disposing );
    }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.pnTop = new System.Windows.Forms.Panel();
          this.btUpdate = new System.Windows.Forms.Button();
          this.btClear = new System.Windows.Forms.Button();
          this.btFill = new System.Windows.Forms.Button();
          this.tbSql = new System.Windows.Forms.TextBox();
          this.splitter = new System.Windows.Forms.Splitter();
          this.dataGrid = new System.Windows.Forms.DataGrid();
          this.myDataSet = new System.Data.DataSet();
          this.command = new Devart.Data.PostgreSql.PgSqlCommand();
          this.dataAdapter = new Devart.Data.PostgreSql.PgSqlDataAdapter();
          this.commandBuilder = new Devart.Data.PostgreSql.PgSqlCommandBuilder();
          this.pnTop.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
          this.SuspendLayout();
          // 
          // pnTop
          // 
          this.pnTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.btUpdate,
                                                                            this.btClear,
                                                                            this.btFill});
          this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
          this.pnTop.Name = "pnTop";
          this.pnTop.Size = new System.Drawing.Size(400, 24);
          this.pnTop.TabIndex = 1;
          // 
          // btUpdate
          // 
          this.btUpdate.Enabled = false;
          this.btUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this.btUpdate.Location = new System.Drawing.Point(152, 0);
          this.btUpdate.Name = "btUpdate";
          this.btUpdate.TabIndex = 2;
          this.btUpdate.Text = "Update";
          this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
          // 
          // btClear
          // 
          this.btClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this.btClear.Location = new System.Drawing.Point(76, 0);
          this.btClear.Name = "btClear";
          this.btClear.TabIndex = 1;
          this.btClear.Text = "Clear";
          this.btClear.Click += new System.EventHandler(this.btClear_Click);
          // 
          // btFill
          // 
          this.btFill.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this.btFill.Name = "btFill";
          this.btFill.TabIndex = 0;
          this.btFill.Text = "Fill";
          this.btFill.Click += new System.EventHandler(this.btFill_Click);
          // 
          // tbSql
          // 
          this.tbSql.Dock = System.Windows.Forms.DockStyle.Top;
          this.tbSql.Location = new System.Drawing.Point(0, 24);
          this.tbSql.Multiline = true;
          this.tbSql.Name = "tbSql";
          this.tbSql.Size = new System.Drawing.Size(400, 64);
          this.tbSql.TabIndex = 2;
          this.tbSql.Text = "";
          this.tbSql.Leave += new System.EventHandler(this.tbSql_Leave);
          // 
          // splitter
          // 
          this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
          this.splitter.Location = new System.Drawing.Point(0, 88);
          this.splitter.MinExtra = 50;
          this.splitter.Name = "splitter";
          this.splitter.Size = new System.Drawing.Size(400, 3);
          this.splitter.TabIndex = 3;
          this.splitter.TabStop = false;
          // 
          // dataGrid
          // 
          this.dataGrid.AllowNavigation = false;
          this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
          this.dataGrid.CaptionVisible = false;
          this.dataGrid.DataMember = "";
          this.dataGrid.DataSource = this.myDataSet;
          this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
          this.dataGrid.GridLineColor = System.Drawing.SystemColors.ActiveBorder;
          this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
          this.dataGrid.Location = new System.Drawing.Point(0, 91);
          this.dataGrid.Name = "dataGrid";
          this.dataGrid.Size = new System.Drawing.Size(400, 189);
          this.dataGrid.TabIndex = 4;
          this.dataGrid.CurrentCellChanged += new System.EventHandler(this.dataGrid_CurrentCellChanged);
          // 
          // myDataSet
          // 
          this.myDataSet.DataSetName = "NewDataSet";
          this.myDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
          // 
          // command
          // 
          this.command.CommandText = "SELECT * FROM Dept";
          this.command.Name = "command";
          this.command.Owner = this;
          // 
          // dataAdapter
          // 
          this.dataAdapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
          this.dataAdapter.SelectCommand = this.command;
          // 
          // commandBuilder
          // 
          this.commandBuilder.DataAdapter = this.dataAdapter;
          this.commandBuilder.Quoted = true;
          this.commandBuilder.UpdatingFields = "";
          // 
          // DataSetDemoControl
          // 
          this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.dataGrid,
                                                                      this.splitter,
                                                                      this.tbSql,
                                                                      this.pnTop});
          this.Name = "DataSetDemoControl";
          this.Size = new System.Drawing.Size(400, 280);
          this.pnTop.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
          this.ResumeLayout(false);

        }
    #endregion

    private void tbSql_Leave(object sender, System.EventArgs e) {

      command.CommandText = tbSql.Text;
      commandBuilder.RefreshSchema();
    }

    private void btFill_Click(object sender, System.EventArgs e) {

      command.CommandText = tbSql.Text;
      dataAdapter.Fill(myDataSet, "Table");
      dataGrid.DataSource = this.myDataSet;
      dataGrid.DataMember = "Table";
      this.btUpdate.Enabled = true;

      writeStatus1 = this.myDataSet.Tables[0].Rows.Count + " rows in DataSet";
      OnWriteStatus();
    }

    private void btClear_Click(object sender, System.EventArgs e) {

      this.myDataSet = new System.Data.DataSet();
      dataGrid.DataMember = String.Empty;
      this.btUpdate.Enabled = false;

      writeStatus1 = writeStatus2 = "";
      OnWriteStatus();
    }

    private void btUpdate_Click(object sender, System.EventArgs e) {

      dataAdapter.Update(myDataSet, "Table");
    }

    private void dataGrid_CurrentCellChanged(object sender, System.EventArgs e) {

      writeStatus2 = "Record number: " + dataGrid.CurrentCell.RowNumber;
      OnWriteStatus();
    }
  }
}
