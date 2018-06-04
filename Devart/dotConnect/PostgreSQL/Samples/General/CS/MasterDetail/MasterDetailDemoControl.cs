using System;

namespace Samples
{
  public class MasterDetailDemoControl : Samples.BaseDemoControl
  {
    private Devart.Data.PostgreSql.PgSqlCommand masterCommand;
    private Devart.Data.PostgreSql.PgSqlCommand detailCommand;
    private Devart.Data.PostgreSql.PgSqlDataAdapter masterDataAdapter;
    private Devart.Data.PostgreSql.PgSqlDataAdapter detailDataAdapter;
    private Devart.Data.PostgreSql.PgSqlCommandBuilder masterCommandBuilder;
    private Devart.Data.PostgreSql.PgSqlCommandBuilder detailCommandBuilder;
    private System.Data.DataSet dataSet;
    private System.Windows.Forms.Splitter splitter;
    private System.Windows.Forms.DataGrid detailGrid;
    private System.Windows.Forms.DataGrid masterGrid;
    private System.Windows.Forms.Panel topPanel;
    private System.Windows.Forms.Button btUpdate;
    private System.Windows.Forms.Button btClear;
    private System.Windows.Forms.Button btFill;
    private System.ComponentModel.IContainer components = null;

    public MasterDetailDemoControl() {

      InitializeComponent();
    }

    public MasterDetailDemoControl(Devart.Data.PostgreSql.PgSqlConnection connection)
    : this() {

      this.masterCommand.Connection = connection;
      this.detailCommand.Connection = connection;
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
      this.masterCommand = new Devart.Data.PostgreSql.PgSqlCommand();
      this.detailCommand = new Devart.Data.PostgreSql.PgSqlCommand();
      this.masterDataAdapter = new Devart.Data.PostgreSql.PgSqlDataAdapter();
      this.detailDataAdapter = new Devart.Data.PostgreSql.PgSqlDataAdapter();
      this.masterCommandBuilder = new Devart.Data.PostgreSql.PgSqlCommandBuilder();
      this.detailCommandBuilder = new Devart.Data.PostgreSql.PgSqlCommandBuilder();
      this.dataSet = new System.Data.DataSet();
      this.splitter = new System.Windows.Forms.Splitter();
      this.detailGrid = new System.Windows.Forms.DataGrid();
      this.masterGrid = new System.Windows.Forms.DataGrid();
      this.topPanel = new System.Windows.Forms.Panel();
      this.btUpdate = new System.Windows.Forms.Button();
      this.btClear = new System.Windows.Forms.Button();
      this.btFill = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).BeginInit();
      this.topPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // masterCommand
      // 
      this.masterCommand.CommandText = "SELECT * FROM Dept";
      this.masterCommand.Name = "masterCommand";
      this.masterCommand.Owner = this;
      // 
      // detailCommand
      // 
      this.detailCommand.CommandText = "SELECT EMPNO,ENAME,JOB,MGR,HIREDATE,DEPTNO FROM Emp";
      this.detailCommand.Name = "detailCommand";
      this.detailCommand.Owner = this;
      // 
      // masterDataAdapter
      // 
      this.masterDataAdapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
      this.masterDataAdapter.SelectCommand = this.masterCommand;
      // 
      // detailDataAdapter
      // 
      this.detailDataAdapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
      this.detailDataAdapter.SelectCommand = this.detailCommand;
      // 
      // masterCommandBuilder
      // 
      this.masterCommandBuilder.DataAdapter = this.masterDataAdapter;
      this.masterCommandBuilder.Quoted = true;
      this.masterCommandBuilder.UpdatingFields = "";
      // 
      // detailCommandBuilder
      // 
      this.detailCommandBuilder.DataAdapter = this.detailDataAdapter;
      this.detailCommandBuilder.Quoted = true;
      this.detailCommandBuilder.ConflictOption = System.Data.ConflictOption.OverwriteChanges;
      this.detailCommandBuilder.UpdatingFields = "";
      // 
      // dataSet
      // 
      this.dataSet.DataSetName = "NewDataSet";
      this.dataSet.Locale = new System.Globalization.CultureInfo("en");
      // 
      // splitter
      // 
      this.splitter.Cursor = System.Windows.Forms.Cursors.HSplit;
      this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splitter.Location = new System.Drawing.Point(0, 149);
      this.splitter.MinExtra = 50;
      this.splitter.MinSize = 50;
      this.splitter.Name = "splitter";
      this.splitter.Size = new System.Drawing.Size(400, 3);
      this.splitter.TabIndex = 13;
      this.splitter.TabStop = false;
      // 
      // detailGrid
      // 
      this.detailGrid.AllowNavigation = false;
      this.detailGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.detailGrid.CaptionVisible = false;
      this.detailGrid.DataMember = "";
      this.detailGrid.DataSource = this.dataSet;
      this.detailGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.detailGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.detailGrid.Location = new System.Drawing.Point(0, 152);
      this.detailGrid.Name = "detailGrid";
      this.detailGrid.Size = new System.Drawing.Size(400, 128);
      this.detailGrid.TabIndex = 12;
      // 
      // masterGrid
      // 
      this.masterGrid.AllowNavigation = false;
      this.masterGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.masterGrid.CaptionVisible = false;
      this.masterGrid.DataMember = "";
      this.masterGrid.DataSource = this.dataSet;
      this.masterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.masterGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.masterGrid.Location = new System.Drawing.Point(0, 24);
      this.masterGrid.Name = "masterGrid";
      this.masterGrid.Size = new System.Drawing.Size(400, 125);
      this.masterGrid.TabIndex = 11;
      // 
      // topPanel
      // 
      this.topPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.btUpdate,
                                                                           this.btClear,
                                                                           this.btFill});
      this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.topPanel.Name = "topPanel";
      this.topPanel.Size = new System.Drawing.Size(400, 24);
      this.topPanel.TabIndex = 9;
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
      // MasterDetailDemoControl
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.masterGrid,
                                                                  this.splitter,
                                                                  this.detailGrid,
                                                                  this.topPanel});
      this.Name = "MasterDetailDemoControl";
      this.Size = new System.Drawing.Size(400, 280);
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).EndInit();
      this.topPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    #endregion

    private void btFill_Click(object sender, System.EventArgs e) {

      dataSet.Relations.Clear();

      masterDataAdapter.Fill(dataSet, "Master");
      detailDataAdapter.Fill(dataSet, "Detail");

      dataSet.Relations.Add("Relation", dataSet.Tables["Master"].Columns["DEPTNO"], 
      dataSet.Tables["Detail"].Columns["DEPTNO"]);

      masterGrid.DataMember = "Master";
      detailGrid.DataMember = "Master.Relation";
      writeStatus1 = "Change department to see its employees";
      OnWriteStatus();
    }

    private void btClear_Click(object sender, System.EventArgs e) {

      dataSet.Clear();

      writeStatus1 = "";
      OnWriteStatus();
    }

    private void btUpdate_Click(object sender, System.EventArgs e) {

      masterDataAdapter.Update(dataSet, "Master");
      detailDataAdapter.Update(dataSet, "Detail");
    }
  }
}

