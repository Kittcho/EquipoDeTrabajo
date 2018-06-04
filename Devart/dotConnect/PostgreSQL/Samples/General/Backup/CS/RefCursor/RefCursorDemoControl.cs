using System;
using Devart.Data.PostgreSql;


namespace Samples
{
	public class RefCursorDemoControl : Samples.BaseDemoControl
	{
    private System.Windows.Forms.Panel pnTop;
    private System.Windows.Forms.Button btClear;
    private System.Windows.Forms.Button btExecute;
    private System.Windows.Forms.TextBox tbResult;
    private Devart.Data.PostgreSql.PgSqlCommand pgSqlCommand;
		private System.ComponentModel.IContainer components = null;

		public RefCursorDemoControl()
		{
			InitializeComponent();
		}

    public RefCursorDemoControl(Devart.Data.PostgreSql.PgSqlConnection connection) {

      InitializeComponent();

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
      this.btExecute = new System.Windows.Forms.Button();
      this.tbResult = new System.Windows.Forms.TextBox();
      this.pgSqlCommand = new Devart.Data.PostgreSql.PgSqlCommand();
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
      this.pnTop.TabIndex = 1;
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
      // tbResult
      // 
      this.tbResult.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbResult.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
      this.tbResult.Location = new System.Drawing.Point(0, 24);
      this.tbResult.Multiline = true;
      this.tbResult.Name = "tbResult";
      this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbResult.Size = new System.Drawing.Size(376, 214);
      this.tbResult.TabIndex = 7;
      this.tbResult.Text = "";
      this.tbResult.WordWrap = false;
      // 
      // pgSqlCommand
      // 
      this.pgSqlCommand.CommandText = "SELECT * FROM getdeptCursor(\'dept\')";
      this.pgSqlCommand.Name = "pgSqlCommand";
      this.pgSqlCommand.Owner = this;
      // 
      // RefCursorDemoControl
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.tbResult,
                                                                  this.pnTop});
      this.Name = "RefCursorDemoControl";
      this.Size = new System.Drawing.Size(376, 238);
      this.pnTop.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion

    private void btExecute_Click(object sender, System.EventArgs e) {

      const int len = 10;
      int recCount = 0;
      PgSqlCommand cursorCmd = new PgSqlCommand("fetch all in \"dept\"", pgSqlCommand.Connection);
      //  need to start transaction, because cursor is accessible only in transaction
      PgSqlTransaction tr = pgSqlCommand.Connection.BeginTransaction();
      try {

        //  executes stored procedure that opens cursor
        pgSqlCommand.ExecuteScalar();

        //  fetch data from named cursor
        PgSqlDataReader dataReader = cursorCmd.ExecuteReader();

        if (dataReader.FieldCount > 0) {
          for (int i = 0; i < dataReader.FieldCount; i++)
            tbResult.AppendText(dataReader.GetName(i).PadRight(len).Substring(0, len) + " ");
          tbResult.AppendText("\r\n");
          for (int i = 0; i < dataReader.FieldCount; i++)
            tbResult.AppendText(String.Empty.PadRight(len, '-').Substring(0, len) + " ");

          tbResult.AppendText("\r\n");

          while (dataReader.Read()) {
            for (int i = 0; i < dataReader.FieldCount; i++)
              tbResult.AppendText(dataReader.GetValue(i).ToString().PadRight(len).Substring(0, len) + " ");
            tbResult.AppendText("\r\n");

            recCount++;
          }

          tbResult.AppendText("\r\n");

          tbResult.AppendText(recCount.ToString() + " rows selected.\r\n");
        }
        else
          tbResult.AppendText("Statement executed.\r\n");

        tbResult.AppendText("\r\n");

        dataReader.Close();

        //  commit transaction
        tr.Commit();
      }
      catch (PgSqlException exception) {
        //  rollback transaction on error
        tr.Rollback();
        tbResult.AppendText(exception.Message + "\r\n\r\n");
        throw;
      }
    }

    private void btClear_Click(object sender, System.EventArgs e) {
    
      tbResult.Clear();
    }
	}
}

