using System;

namespace Samples
{
  public class TransactionsDemoControl : BaseDemoControl
  {
    private System.Windows.Forms.Panel topPanel;
    private System.Windows.Forms.Button btRollback;
    private System.Windows.Forms.Button btCommit;
    private System.Windows.Forms.Button btBegin;
    private System.Windows.Forms.Button btUpdate;
    private System.Windows.Forms.Button btClear;
    private System.Windows.Forms.Button btFill;
    private System.ComponentModel.IContainer components = null;
    private System.Data.DataSet dataSet;
    private System.Windows.Forms.DataGrid dataGrid;
    private Devart.Data.PostgreSql.PgSqlCommand selectCommand;
    private Devart.Data.PostgreSql.PgSqlDataAdapter dataAdapter;
    private Devart.Data.PostgreSql.PgSqlCommandBuilder commandBuilder;
    private Devart.Data.PostgreSql.PgSqlTransaction transaction = null;

    public TransactionsDemoControl() {

      InitializeComponent();
    }

    public TransactionsDemoControl(Devart.Data.PostgreSql.PgSqlConnection connection)
      : this () {

      selectCommand.Connection = connection;
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
      this.topPanel = new System.Windows.Forms.Panel();
      this.btRollback = new System.Windows.Forms.Button();
      this.btCommit = new System.Windows.Forms.Button();
      this.btBegin = new System.Windows.Forms.Button();
      this.btUpdate = new System.Windows.Forms.Button();
      this.btClear = new System.Windows.Forms.Button();
      this.btFill = new System.Windows.Forms.Button();
      this.dataSet = new System.Data.DataSet();
      this.selectCommand = new Devart.Data.PostgreSql.PgSqlCommand();
      this.dataAdapter = new Devart.Data.PostgreSql.PgSqlDataAdapter();
      this.commandBuilder = new Devart.Data.PostgreSql.PgSqlCommandBuilder();
      this.dataGrid = new System.Windows.Forms.DataGrid();
      this.topPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // topPanel
      // 
      this.topPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.btRollback,
                                                                           this.btCommit,
                                                                           this.btBegin,
                                                                           this.btUpdate,
                                                                           this.btClear,
                                                                           this.btFill});
      this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.topPanel.Name = "topPanel";
      this.topPanel.Size = new System.Drawing.Size(477, 24);
      this.topPanel.TabIndex = 2;
      // 
      // btRollback
      // 
      this.btRollback.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btRollback.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
      this.btRollback.ForeColor = System.Drawing.Color.Navy;
      this.btRollback.Location = new System.Drawing.Point(392, 0);
      this.btRollback.Name = "btRollback";
      this.btRollback.TabIndex = 7;
      this.btRollback.Text = "Rollback";
      this.btRollback.Click += new System.EventHandler(this.btRollback_Click);
      // 
      // btCommit
      // 
      this.btCommit.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btCommit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
      this.btCommit.ForeColor = System.Drawing.Color.Navy;
      this.btCommit.Location = new System.Drawing.Point(316, 0);
      this.btCommit.Name = "btCommit";
      this.btCommit.TabIndex = 6;
      this.btCommit.Text = "Commit";
      this.btCommit.Click += new System.EventHandler(this.btCommit_Click);
      // 
      // btBegin
      // 
      this.btBegin.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
      this.btBegin.ForeColor = System.Drawing.Color.Navy;
      this.btBegin.Location = new System.Drawing.Point(240, 0);
      this.btBegin.Name = "btBegin";
      this.btBegin.TabIndex = 5;
      this.btBegin.Text = "Begin";
      this.btBegin.Click += new System.EventHandler(this.btBegin_Click);
      // 
      // btUpdate
      // 
      this.btUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btUpdate.Location = new System.Drawing.Point(76, 0);
      this.btUpdate.Name = "btUpdate";
      this.btUpdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.btUpdate.TabIndex = 4;
      this.btUpdate.Text = "Update";
      this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
      // 
      // btClear
      // 
      this.btClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btClear.Location = new System.Drawing.Point(152, 0);
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
      // dataSet
      // 
      this.dataSet.DataSetName = "NewDataSet";
      this.dataSet.Locale = new System.Globalization.CultureInfo("en-US");
      // 
      // selectCommand
      // 
      this.selectCommand.CommandText = "Select * from dept";
      this.selectCommand.Name = "selectCommand";
      this.selectCommand.Owner = this;
      // 
      // dataAdapter
      // 
      this.dataAdapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
      this.dataAdapter.SelectCommand = this.selectCommand;
      // 
      // commandBuilder
      // 
      this.commandBuilder.DataAdapter = this.dataAdapter;
      this.commandBuilder.Quoted = true;
      this.commandBuilder.UpdatingFields = "";
      // 
      // dataGrid
      // 
      this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dataGrid.CaptionVisible = false;
      this.dataGrid.DataMember = "";
      this.dataGrid.DataSource = this.dataSet;
      this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGrid.Location = new System.Drawing.Point(0, 24);
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.Size = new System.Drawing.Size(477, 310);
      this.dataGrid.TabIndex = 3;
      // 
      // TransactionsDemoControl
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.dataGrid,
                                                                  this.topPanel});
      this.Name = "TransactionsDemoControl";
      this.Size = new System.Drawing.Size(477, 334);
      this.topPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      this.ResumeLayout(false);

    }
    #endregion

    private void btFill_Click(object sender, System.EventArgs e) {

      dataAdapter.Fill(dataSet, "Table");
      dataGrid.DataMember = "Table";
    }

    private void btUpdate_Click(object sender, System.EventArgs e) {

      if (dataSet.Tables.Count > 0)
        dataAdapter.Update(dataSet, "Table");
    }

    private void btClear_Click(object sender, System.EventArgs e) {

      dataGrid.DataSource = null;
      dataSet = new System.Data.DataSet();
      dataGrid.DataSource = dataSet;
    }

    private void btBegin_Click(object sender, System.EventArgs e) {

      transaction =  selectCommand.Connection.BeginTransaction();

      writeStatus1 = "Transaction started";
      writeStatus2 = "In transaction";
      OnWriteStatus();
    }

    private void btCommit_Click(object sender, System.EventArgs e) {

      if (transaction == null)
        return;

      transaction.Commit();
      transaction = null;

      writeStatus1 = "Commit complete";
      writeStatus2 = "";
      OnWriteStatus();
    }

    private void btRollback_Click(object sender, System.EventArgs e) {

      if (transaction == null) 
        return;

      transaction.Rollback();
      transaction = null;

      writeStatus1 = "Rollback complete";
      writeStatus2 = "";
      OnWriteStatus();
    }
  }
}
