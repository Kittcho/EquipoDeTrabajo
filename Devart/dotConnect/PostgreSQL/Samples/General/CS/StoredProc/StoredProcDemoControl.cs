using System;

namespace Samples {
  public class StoredProcDemoControl : BaseDemoControl {

    private System.Windows.Forms.DataGrid dataGrid;
    private System.Windows.Forms.Panel topPanel;
    private System.Windows.Forms.TextBox tbLoc;
    private System.Windows.Forms.TextBox tbDname;
    private System.Windows.Forms.TextBox tbDeptno;
    private System.Windows.Forms.Button btClear;
    private System.Windows.Forms.Button btFill;
    private System.Windows.Forms.Button btExecute;
    private System.Windows.Forms.ComboBox edStoredProcName;
    private System.Windows.Forms.Label lbStoredProc;
    private Devart.Data.PostgreSql.PgSqlCommand procedureCommand;
    private Devart.Data.PostgreSql.PgSqlCommand selectCommand;
    private Devart.Data.PostgreSql.PgSqlDataAdapter dataAdapter;
    private System.Windows.Forms.Label lbParams;
    private System.Windows.Forms.Label lbParam3;
    private System.Windows.Forms.Label lbParam2;
    private System.Windows.Forms.Label lbParam1;

    private System.ComponentModel.IContainer components = null;

    public StoredProcDemoControl() {

      InitializeComponent();
    }
    
    public StoredProcDemoControl(Devart.Data.PostgreSql.PgSqlConnection connection) 
      : this () {

      Devart.Data.PostgreSql.PgSqlConnection locConnection = connection;
      procedureCommand.Connection = locConnection;
      selectCommand.Connection = locConnection;
      edStoredProcName.Text = procedureCommand.CommandText;
      tbDeptno.Text = procedureCommand.Parameters["@pdeptno"].Value.ToString();
      tbDname.Text = procedureCommand.Parameters["@pdname"].Value.ToString();
      tbLoc.Text = procedureCommand.Parameters["@ploc"].Value.ToString();
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing ) {
      if( disposing ) {
        if (components != null) {
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
    private void InitializeComponent() {
      this.procedureCommand = new Devart.Data.PostgreSql.PgSqlCommand();
      this.selectCommand = new Devart.Data.PostgreSql.PgSqlCommand();
      this.dataAdapter = new Devart.Data.PostgreSql.PgSqlDataAdapter();
      this.dataGrid = new System.Windows.Forms.DataGrid();
      this.topPanel = new System.Windows.Forms.Panel();
      this.lbParams = new System.Windows.Forms.Label();
      this.tbLoc = new System.Windows.Forms.TextBox();
      this.tbDname = new System.Windows.Forms.TextBox();
      this.tbDeptno = new System.Windows.Forms.TextBox();
      this.lbParam3 = new System.Windows.Forms.Label();
      this.lbParam2 = new System.Windows.Forms.Label();
      this.lbParam1 = new System.Windows.Forms.Label();
      this.btClear = new System.Windows.Forms.Button();
      this.btFill = new System.Windows.Forms.Button();
      this.btExecute = new System.Windows.Forms.Button();
      this.edStoredProcName = new System.Windows.Forms.ComboBox();
      this.lbStoredProc = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      this.topPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // procedureCommand
      // 
      this.procedureCommand.CommandType = System.Data.CommandType.StoredProcedure;
      this.procedureCommand.CommandText = "Dept_Insert";
      this.procedureCommand.Name = "procedureCommand";
      this.procedureCommand.Parameters.Add(new Devart.Data.PostgreSql.PgSqlParameter("@pdeptno", Devart.Data.PostgreSql.PgSqlType.Int, 3, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, "50"));
      this.procedureCommand.Parameters.Add(new Devart.Data.PostgreSql.PgSqlParameter("@pdname", Devart.Data.PostgreSql.PgSqlType.VarChar, 10, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, "RESEARCH"));
      this.procedureCommand.Parameters.Add(new Devart.Data.PostgreSql.PgSqlParameter("@ploc", Devart.Data.PostgreSql.PgSqlType.VarChar, 10, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, "NEW YORK"));
      this.procedureCommand.Owner = this;
      // 
      // selectCommand
      // 
      this.selectCommand.CommandText = "SELECT * FROM DEPT";
      this.selectCommand.Name = "selectCommand";
      this.selectCommand.Owner = this;
      // 
      // dataAdapter
      // 
      this.dataAdapter.SelectCommand = this.selectCommand;
      // 
      // dataGrid
      // 
      this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dataGrid.CaptionVisible = false;
      this.dataGrid.DataMember = "";
      this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGrid.Location = new System.Drawing.Point(0, 88);
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.Size = new System.Drawing.Size(477, 246);
      this.dataGrid.TabIndex = 10;
      // 
      // topPanel
      // 
      this.topPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.lbParams,
                                                                           this.tbLoc,
                                                                           this.tbDname,
                                                                           this.tbDeptno,
                                                                           this.lbParam3,
                                                                           this.lbParam2,
                                                                           this.lbParam1,
                                                                           this.btClear,
                                                                           this.btFill,
                                                                           this.btExecute,
                                                                           this.edStoredProcName,
                                                                           this.lbStoredProc});
      this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.topPanel.Name = "topPanel";
      this.topPanel.Size = new System.Drawing.Size(477, 88);
      this.topPanel.TabIndex = 8;
      // 
      // lbParams
      // 
      this.lbParams.AutoSize = true;
      this.lbParams.Location = new System.Drawing.Point(8, 32);
      this.lbParams.Name = "lbParams";
      this.lbParams.Size = new System.Drawing.Size(155, 13);
      this.lbParams.TabIndex = 18;
      this.lbParams.Text = "Stored procedure parameters:";
      // 
      // tbLoc
      // 
      this.tbLoc.Location = new System.Drawing.Point(338, 52);
      this.tbLoc.Name = "tbLoc";
      this.tbLoc.Size = new System.Drawing.Size(127, 20);
      this.tbLoc.TabIndex = 17;
      this.tbLoc.Text = "";
      // 
      // tbDname
      // 
      this.tbDname.Location = new System.Drawing.Point(171, 52);
      this.tbDname.Name = "tbDname";
      this.tbDname.Size = new System.Drawing.Size(119, 20);
      this.tbDname.TabIndex = 16;
      this.tbDname.Text = "";
      // 
      // tbDeptno
      // 
      this.tbDeptno.Location = new System.Drawing.Point(47, 52);
      this.tbDeptno.Name = "tbDeptno";
      this.tbDeptno.Size = new System.Drawing.Size(65, 20);
      this.tbDeptno.TabIndex = 15;
      this.tbDeptno.Text = "";
      // 
      // lbParam3
      // 
      this.lbParam3.AutoSize = true;
      this.lbParam3.Location = new System.Drawing.Point(311, 56);
      this.lbParam3.Name = "lbParam3";
      this.lbParam3.Size = new System.Drawing.Size(22, 13);
      this.lbParam3.TabIndex = 14;
      this.lbParam3.Text = "Loc";
      // 
      // lbParam2
      // 
      this.lbParam2.AutoSize = true;
      this.lbParam2.Location = new System.Drawing.Point(128, 55);
      this.lbParam2.Name = "lbParam2";
      this.lbParam2.Size = new System.Drawing.Size(41, 13);
      this.lbParam2.TabIndex = 13;
      this.lbParam2.Text = "Dname";
      // 
      // lbParam1
      // 
      this.lbParam1.AutoSize = true;
      this.lbParam1.Location = new System.Drawing.Point(3, 54);
      this.lbParam1.Name = "lbParam1";
      this.lbParam1.Size = new System.Drawing.Size(41, 13);
      this.lbParam1.TabIndex = 12;
      this.lbParam1.Text = "Deptno";
      // 
      // btClear
      // 
      this.btClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btClear.Location = new System.Drawing.Point(152, 0);
      this.btClear.Name = "btClear";
      this.btClear.TabIndex = 11;
      this.btClear.Text = "Clear";
      this.btClear.Click += new System.EventHandler(this.btClear_Click);
      // 
      // btFill
      // 
      this.btFill.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btFill.Location = new System.Drawing.Point(76, 0);
      this.btFill.Name = "btFill";
      this.btFill.TabIndex = 10;
      this.btFill.Text = "Fill";
      this.btFill.Click += new System.EventHandler(this.btFill_Click);
      // 
      // btExecute
      // 
      this.btExecute.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btExecute.Name = "btExecute";
      this.btExecute.TabIndex = 9;
      this.btExecute.Text = "Execute";
      this.btExecute.Click += new System.EventHandler(this.btExecute_Click);
      // 
      // edStoredProcName
      // 
      this.edStoredProcName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.edStoredProcName.Items.AddRange(new object[] {
                                                          "Dept_Insert",
                                                          "Dept_Update"});
      this.edStoredProcName.Location = new System.Drawing.Point(328, 6);
      this.edStoredProcName.Name = "edStoredProcName";
      this.edStoredProcName.Size = new System.Drawing.Size(144, 21);
      this.edStoredProcName.TabIndex = 8;
      // 
      // lbStoredProc
      // 
      this.lbStoredProc.AutoSize = true;
      this.lbStoredProc.Location = new System.Drawing.Point(232, 8);
      this.lbStoredProc.Name = "lbStoredProc";
      this.lbStoredProc.Size = new System.Drawing.Size(92, 13);
      this.lbStoredProc.TabIndex = 7;
      this.lbStoredProc.Text = "Stored procedure";
      // 
      // StoredProcDemoControl
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.dataGrid,
                                                                  this.topPanel});
      this.Name = "StoredProcDemoControl";
      this.Size = new System.Drawing.Size(477, 334);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      this.topPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    #endregion

    private void btExecute_Click(object sender, System.EventArgs e) {

      procedureCommand.CommandText = edStoredProcName.Text;
      procedureCommand.Parameters["@pdeptno"].Value = Convert.ToInt32(tbDeptno.Text);
      procedureCommand.Parameters["@pdname"].Value = tbDname.Text;
      procedureCommand.Parameters["@ploc"].Value = tbLoc.Text;
      procedureCommand.ExecuteNonQuery();
      writeStatus1 = "Procedure executed successfully";
      OnWriteStatus();
    }

    private void btFill_Click(object sender, System.EventArgs e) {

      System.Data.DataSet ds = new System.Data.DataSet();
      dataAdapter.Fill(ds);
      dataGrid.DataSource = ds.Tables[0];
    }

    private void btClear_Click(object sender, System.EventArgs e) {

      dataGrid.DataSource = null;
      writeStatus1 = "";
      OnWriteStatus();
    }
  }
}

