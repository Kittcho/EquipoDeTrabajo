using System;

namespace Samples
{
  /// <summary>
  /// Summary description for DataReaderDemoControl.
  /// </summary>
  public class DataReaderDemoControl : BaseDemoControl
  {
    private System.Windows.Forms.Button btExecute;
    private System.Windows.Forms.Button btClear;
    private System.Windows.Forms.TextBox tbSql;
    private System.Windows.Forms.Panel pnTop;
    private System.Windows.Forms.Splitter splitter;
    private System.Windows.Forms.TextBox tbResult;
    private Devart.Data.PostgreSql.PgSqlCommand command;

    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public DataReaderDemoControl(){
      InitializeComponent();
    }

    public DataReaderDemoControl(Devart.Data.PostgreSql.PgSqlConnection connection) 
    : this () {

      this.command.Connection = connection;
      this.tbSql.Text = command.CommandText;
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing ){
      if( disposing )
      {
        if(components != null)
        {
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
      this.btClear = new System.Windows.Forms.Button();
      this.btExecute = new System.Windows.Forms.Button();
      this.tbSql = new System.Windows.Forms.TextBox();
      this.splitter = new System.Windows.Forms.Splitter();
      this.command = new Devart.Data.PostgreSql.PgSqlCommand();
      this.tbResult = new System.Windows.Forms.TextBox();
      this.pnTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnTop
      // 
      this.pnTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                        this.btClear,
                                                                        this.btExecute});
      this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnTop.Name = "pnTop";
      this.pnTop.Size = new System.Drawing.Size(376, 24);
      this.pnTop.TabIndex = 0;
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
      // btExecute
      // 
      this.btExecute.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btExecute.Name = "btExecute";
      this.btExecute.TabIndex = 0;
      this.btExecute.Text = "Execute";
      this.btExecute.Click += new System.EventHandler(this.btExecute_Click);
      // 
      // tbSql
      // 
      this.tbSql.Dock = System.Windows.Forms.DockStyle.Top;
      this.tbSql.Location = new System.Drawing.Point(0, 24);
      this.tbSql.Multiline = true;
      this.tbSql.Name = "tbSql";
      this.tbSql.Size = new System.Drawing.Size(376, 64);
      this.tbSql.TabIndex = 1;
      this.tbSql.Text = "";
      this.tbSql.Leave += new System.EventHandler(this.tbSql_Leave);
      // 
      // splitter
      // 
      this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
      this.splitter.Location = new System.Drawing.Point(0, 88);
      this.splitter.MinExtra = 50;
      this.splitter.Name = "splitter";
      this.splitter.Size = new System.Drawing.Size(376, 3);
      this.splitter.TabIndex = 2;
      this.splitter.TabStop = false;
      // 
      // command
      // 
      this.command.CommandText = "SELECT * FROM Dept";
      this.command.Name = "command";
      this.command.Owner = this;
      // 
      // tbResult
      // 
      this.tbResult.BackColor = System.Drawing.SystemColors.Window;
      this.tbResult.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbResult.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
      this.tbResult.Location = new System.Drawing.Point(0, 91);
      this.tbResult.Multiline = true;
      this.tbResult.Name = "tbResult";
      this.tbResult.ReadOnly = true;
      this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbResult.Size = new System.Drawing.Size(376, 147);
      this.tbResult.TabIndex = 3;
      this.tbResult.Text = "";
      this.tbResult.WordWrap = false;
      // 
      // DataReaderDemoControl
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.tbResult,
                                                                  this.splitter,
                                                                  this.tbSql,
                                                                  this.pnTop});
      this.Name = "DataReaderDemoControl";
      this.Size = new System.Drawing.Size(376, 238);
      this.pnTop.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    #endregion

    private void tbSql_Leave(object sender, System.EventArgs e) {

      command.CommandText = tbSql.Text;
    }

    private void btExecute_Click(object sender, System.EventArgs e) {

      const int len = 11;
      int recCount = 0;

      Devart.Data.PostgreSql.PgSqlDataReader dataReader = null;
      try {
        dataReader = command.ExecuteReader();
        if (dataReader.FieldCount > 0) {
          for (int i = 0; i < dataReader.FieldCount; i++)
            tbResult.AppendText(dataReader.GetName(i).PadRight(len).Substring(0, len) + "\t");
          tbResult.AppendText("\r\n");

          for (int i = 0; i < dataReader.FieldCount; i++)
            tbResult.AppendText(String.Empty.PadRight(len, '-').Substring(0, len) + "\t");
          tbResult.AppendText("\r\n");

          while (dataReader.Read()) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(100);
            for (int i = 0; i < dataReader.FieldCount; i++){
              if (dataReader.IsDBNull(i))
                sb.Append("(null)".PadRight(len).Substring(0, len) + "\t");
              else
              sb.Append(dataReader.GetValue(i).ToString().PadRight(len).Substring(0, len) + "\t");
            }
            sb.Append("\r\n");
            recCount++;
            tbResult.AppendText(sb.ToString());
          }

          writeStatus1 = recCount.ToString() + " rows selected";
        }
        else
          writeStatus1 = "Statement executed";

        tbResult.AppendText("\r\n");
        OnWriteStatus();
      }
      catch (Devart.Data.PostgreSql.PgSqlException exception) {
        tbResult.AppendText(exception.Message + "\r\n\r\n");
        throw;
      }
      finally {
        if (dataReader != null)
          dataReader.Close();
      }
    }

    private void btClear_Click(object sender, System.EventArgs e) {

      tbResult.Clear();
      writeStatus1 = "Result is cleared";
      OnWriteStatus();
    }
  }
}
