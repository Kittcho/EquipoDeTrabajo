using System;
using System.Data;

namespace Samples
{
	public class RowStoredProcDemoControl : Samples.BaseDemoControl
	{
    private System.Windows.Forms.Panel pnTop;
    private System.Windows.Forms.Button btClear;
    private System.Windows.Forms.Button btFill;
    private System.Windows.Forms.TextBox edParamValue;
    private System.Windows.Forms.Label lbStoredProcName;
    private System.Windows.Forms.DataGrid dataGrid;
    private Devart.Data.PostgreSql.PgSqlCommand pgSqlCommand;
    private Devart.Data.PostgreSql.PgSqlDataAdapter pgSqlDataAdapter;
    private Devart.Data.PostgreSql.PgSqlCommandBuilder pgSqlCommandBuilder;
    private System.Data.DataSet dataSet;
		private System.ComponentModel.IContainer components = null;

		public RowStoredProcDemoControl()
		{
			InitializeComponent();
		}

    public RowStoredProcDemoControl(Devart.Data.PostgreSql.PgSqlConnection connection) 
      : this() {

      this.pgSqlCommand.Connection = connection;
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
      this.pnTop = new System.Windows.Forms.Panel();
      this.btClear = new System.Windows.Forms.Button();
      this.btFill = new System.Windows.Forms.Button();
      this.edParamValue = new System.Windows.Forms.TextBox();
      this.lbStoredProcName = new System.Windows.Forms.Label();
      this.dataGrid = new System.Windows.Forms.DataGrid();
      this.pgSqlCommand = new Devart.Data.PostgreSql.PgSqlCommand();
      this.pgSqlDataAdapter = new Devart.Data.PostgreSql.PgSqlDataAdapter();
      this.pgSqlCommandBuilder = new Devart.Data.PostgreSql.PgSqlCommandBuilder();
      this.dataSet = new System.Data.DataSet();
      this.pnTop.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
      this.SuspendLayout();
      // 
      // pnTop
      // 
      this.pnTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                        this.btClear,
                                                                        this.btFill,
                                                                        this.edParamValue,
                                                                        this.lbStoredProcName});
      this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnTop.Name = "pnTop";
      this.pnTop.Size = new System.Drawing.Size(456, 43);
      this.pnTop.TabIndex = 2;
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
      // edParamValue
      // 
      this.edParamValue.Location = new System.Drawing.Point(264, 12);
      this.edParamValue.Name = "edParamValue";
      this.edParamValue.Size = new System.Drawing.Size(176, 20);
      this.edParamValue.TabIndex = 10;
      this.edParamValue.Text = "(1, \'(1, N a m e , location)\' )";
      // 
      // lbStoredProcName
      // 
      this.lbStoredProcName.Location = new System.Drawing.Point(160, 16);
      this.lbStoredProcName.Name = "lbStoredProcName";
      this.lbStoredProcName.Size = new System.Drawing.Size(88, 16);
      this.lbStoredProcName.TabIndex = 9;
      this.lbStoredProcName.Text = "Parameter value";
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
      this.dataGrid.Location = new System.Drawing.Point(0, 43);
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.Size = new System.Drawing.Size(456, 195);
      this.dataGrid.TabIndex = 5;
      // 
      // pgSqlCommand
      // 
      this.pgSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
      this.pgSqlCommand.CommandText = "getdept";
      this.pgSqlCommand.Name = "pgSqlCommand";
      this.pgSqlCommand.Parameters.Add(new Devart.Data.PostgreSql.PgSqlParameter("p1", "dept_container", System.Data.ParameterDirection.Input, false, "", System.Data.DataRowVersion.Current, "1, \'(1, N a m e , location)\' "));
      this.pgSqlCommand.Owner = this;
      // 
      // pgSqlDataAdapter
      // 
      this.pgSqlDataAdapter.SelectCommand = this.pgSqlCommand;
      // 
      // pgSqlCommandBuilder
      // 
      this.pgSqlCommandBuilder.DataAdapter = this.pgSqlDataAdapter;
      this.pgSqlCommandBuilder.UpdatingFields = "";
      // 
      // dataSet
      // 
      this.dataSet.DataSetName = "NewDataSet";
      this.dataSet.EnforceConstraints = false;
       // 
      // RowStoredProcDemoControl
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.dataGrid,
                                                                  this.pnTop});
      this.Name = "RowStoredProcDemoControl";
      this.Size = new System.Drawing.Size(456, 238);
      this.pnTop.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion

    private void btFill_Click(object sender, System.EventArgs e) {
    
      pgSqlCommand.Parameters[0].Value = edParamValue.Text;
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
	}
}

