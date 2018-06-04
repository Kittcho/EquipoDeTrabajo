using System;
using System.Data;

using System.Windows.Forms;


namespace Samples
{
	public class RowDataSetDemoControl : Samples.BaseDemoControl
	{
    private System.Windows.Forms.Splitter splitter;
    private System.Windows.Forms.DataGrid dataGrid;
    private System.Windows.Forms.TextBox tbSql;
    private System.Windows.Forms.Panel pnTop;
    private System.Windows.Forms.Button btUpdate;
    private System.Windows.Forms.Button btClear;
    private System.Windows.Forms.Button btFill;
    private Devart.Data.PostgreSql.PgSqlCommand command;
    private Devart.Data.PostgreSql.PgSqlDataAdapter pgSqlDataAdapter;
    private Devart.Data.PostgreSql.PgSqlCommandBuilder pgSqlCommandBuilder;
    private System.Data.DataSet dataSet;
		private System.ComponentModel.IContainer components = null;

		public RowDataSetDemoControl()
		{
			InitializeComponent();
  	}

    public RowDataSetDemoControl(Devart.Data.PostgreSql.PgSqlConnection connection) 
      : this() {

    this.command.Connection = connection;
    this.tbSql.Text = this.command.CommandText;
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
      this.splitter = new System.Windows.Forms.Splitter();
      this.dataGrid = new System.Windows.Forms.DataGrid();
      this.dataSet = new System.Data.DataSet();
      this.tbSql = new System.Windows.Forms.TextBox();
      this.pnTop = new System.Windows.Forms.Panel();
      this.btUpdate = new System.Windows.Forms.Button();
      this.btClear = new System.Windows.Forms.Button();
      this.btFill = new System.Windows.Forms.Button();
      this.command = new Devart.Data.PostgreSql.PgSqlCommand();
      this.pgSqlDataAdapter = new Devart.Data.PostgreSql.PgSqlDataAdapter();
      this.pgSqlCommandBuilder = new Devart.Data.PostgreSql.PgSqlCommandBuilder();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
      this.pnTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitter
      // 
      this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
      this.splitter.Location = new System.Drawing.Point(0, 88);
      this.splitter.MinExtra = 50;
      this.splitter.Name = "splitter";
      this.splitter.Size = new System.Drawing.Size(376, 3);
      this.splitter.TabIndex = 7;
      this.splitter.TabStop = false;
      // 
      // dataGrid
      // 
      this.dataGrid.AllowNavigation = false;
      this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dataGrid.CaptionVisible = false;
      this.dataGrid.DataMember = "";
      this.dataGrid.DataSource = this.dataSet;
      this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGrid.GridLineColor = System.Drawing.SystemColors.ActiveBorder;
      this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGrid.Location = new System.Drawing.Point(0, 88);
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.Size = new System.Drawing.Size(376, 150);
      this.dataGrid.TabIndex = 8;
      // 
      // dataSet
      // 
      this.dataSet.DataSetName = "NewDataSet";
      this.dataSet.Locale = new System.Globalization.CultureInfo("en-US");
      // 
      // tbSql
      // 
      this.tbSql.Dock = System.Windows.Forms.DockStyle.Top;
      this.tbSql.Location = new System.Drawing.Point(0, 24);
      this.tbSql.Multiline = true;
      this.tbSql.Name = "tbSql";
      this.tbSql.Size = new System.Drawing.Size(376, 64);
      this.tbSql.TabIndex = 6;
      this.tbSql.Text = "";
      this.tbSql.Leave += new System.EventHandler(this.tbSql_Leave);
      // 
      // pnTop
      // 
      this.pnTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                        this.btUpdate,
                                                                        this.btClear,
                                                                        this.btFill});
      this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnTop.Name = "pnTop";
      this.pnTop.Size = new System.Drawing.Size(376, 24);
      this.pnTop.TabIndex = 5;
      // 
      // btUpdate
      // 
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
      // command
      // 
      this.command.CommandText = "SELECT * FROM Dept_Container";
      this.command.Name = "command";
      this.command.Owner = this;
      // 
      // pgSqlDataAdapter
      // 
      this.pgSqlDataAdapter.SelectCommand = this.command;
      // 
      // pgSqlCommandBuilder
      // 
      this.pgSqlCommandBuilder.DataAdapter = this.pgSqlDataAdapter;
      this.pgSqlCommandBuilder.UpdatingFields = "";
      // 
      // RowDataSetDemoControl
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.splitter,
                                                                  this.dataGrid,
                                                                  this.tbSql,
                                                                  this.pnTop});
      this.Name = "RowDataSetDemoControl";
      this.Size = new System.Drawing.Size(376, 238);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
      this.pnTop.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion

    private void tbSql_Leave(object sender, System.EventArgs e) {
    
      command.CommandText = tbSql.Text;
      pgSqlCommandBuilder.RefreshSchema();
    }

    private void btFill_Click(object sender, System.EventArgs e) {
    
      pgSqlDataAdapter.Fill(dataSet, "Table");
      dataGrid.DataMember = "Table";
    }

    private void btClear_Click(object sender, System.EventArgs e) {
    
      dataGrid.DataMember = String.Empty;
      dataSet.Clear();
      foreach (DataTable table in dataSet.Tables) {
        table.Constraints.Clear();
        table.Columns.Clear();
      }
    }

    private void btUpdate_Click(object sender, System.EventArgs e) {
    
      if (dataSet.Tables.Count > 0)
        pgSqlDataAdapter.Update(dataSet, "Table");
    }
	}
}

