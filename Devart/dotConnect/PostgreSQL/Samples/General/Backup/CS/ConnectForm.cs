
//////////////////////////////////////////////////
//  dotConnect for PostgreSQL
//  Copyright © 2002 Devart. All rights reserved.
//  ConnectForm
//  Last modified:      
//////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.Common;
using Devart.Common;
using Devart.Data.PostgreSql;
using System.Data;

namespace Samples {
  /// <summary>
  /// Summary description for ConnectForm.
  /// </summary>
  public class ConnectForm : System.Windows.Forms.Form {

    private System.Windows.Forms.Button btConnect;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lbPassword;
    private System.Windows.Forms.TextBox edPassword;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;
    private PgSqlConnection connection = null;
    private System.Windows.Forms.Label lbHost;
    private System.Windows.Forms.Label lbUser;
    private System.Windows.Forms.TextBox edUser;
    private System.Windows.Forms.Label lbPort;
    private System.Windows.Forms.NumericUpDown edPort;
    private System.Windows.Forms.Label lbDatabase;
    private System.Windows.Forms.ComboBox cbDatabase;
    private System.Windows.Forms.ComboBox cbSchema;
    private System.Windows.Forms.Label lbSchema;
    private System.Windows.Forms.ComboBox cbHost;
    private int retries = 3;
    private System.Threading.Thread fillHostsThread;

    public ConnectForm(DbConnection connection) {

      InitializeComponent();

      this.connection = (PgSqlConnection)connection;
      edUser.Text = this.connection.UserId;
      edPassword.Text = this.connection.Password;
      cbHost.Text = this.connection.Host;
      edPort.Text = this.connection.Port.ToString();
      cbDatabase.Text = this.connection.Database;
      cbSchema.Text = this.connection.Schema;
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing) {

      if (disposing) {
        if (components != null) {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.panel1 = new System.Windows.Forms.Panel();
      this.cbSchema = new System.Windows.Forms.ComboBox();
      this.lbSchema = new System.Windows.Forms.Label();
      this.cbDatabase = new System.Windows.Forms.ComboBox();
      this.lbDatabase = new System.Windows.Forms.Label();
      this.edPort = new System.Windows.Forms.NumericUpDown();
      this.lbPort = new System.Windows.Forms.Label();
      this.lbHost = new System.Windows.Forms.Label();
      this.edPassword = new System.Windows.Forms.TextBox();
      this.lbPassword = new System.Windows.Forms.Label();
      this.edUser = new System.Windows.Forms.TextBox();
      this.lbUser = new System.Windows.Forms.Label();
      this.btConnect = new System.Windows.Forms.Button();
      this.btCancel = new System.Windows.Forms.Button();
      this.cbHost = new System.Windows.Forms.ComboBox();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.edPort)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                         this.cbHost,
                                                                         this.cbSchema,
                                                                         this.lbSchema,
                                                                         this.cbDatabase,
                                                                         this.lbDatabase,
                                                                         this.edPort,
                                                                         this.lbPort,
                                                                         this.lbHost,
                                                                         this.edPassword,
                                                                         this.lbPassword,
                                                                         this.edUser,
                                                                         this.lbUser});
      this.panel1.Location = new System.Drawing.Point(12, 11);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(216, 209);
      this.panel1.TabIndex = 0;
      // 
      // cbSchema
      // 
      this.cbSchema.Location = new System.Drawing.Point(88, 174);
      this.cbSchema.Name = "cbSchema";
      this.cbSchema.Size = new System.Drawing.Size(113, 21);
      this.cbSchema.TabIndex = 12;
      this.cbSchema.DropDown += new System.EventHandler(this.cbSchema_DropDown);
      // 
      // lbSchema
      // 
      this.lbSchema.Location = new System.Drawing.Point(10, 177);
      this.lbSchema.Name = "lbSchema";
      this.lbSchema.Size = new System.Drawing.Size(64, 16);
      this.lbSchema.TabIndex = 11;
      this.lbSchema.Text = "Schema";
      // 
      // cbDatabase
      // 
      this.cbDatabase.Location = new System.Drawing.Point(88, 142);
      this.cbDatabase.Name = "cbDatabase";
      this.cbDatabase.Size = new System.Drawing.Size(113, 21);
      this.cbDatabase.TabIndex = 10;
      this.cbDatabase.DropDown += new System.EventHandler(this.cbDatabase_DropDown);
      // 
      // lbDatabase
      // 
      this.lbDatabase.Location = new System.Drawing.Point(10, 145);
      this.lbDatabase.Name = "lbDatabase";
      this.lbDatabase.Size = new System.Drawing.Size(64, 16);
      this.lbDatabase.TabIndex = 6;
      this.lbDatabase.Text = "Database";
      // 
      // edPort
      // 
      this.edPort.Location = new System.Drawing.Point(88, 110);
      this.edPort.Maximum = new System.Decimal(new int[] {
                                                           10000,
                                                           0,
                                                           0,
                                                           0});
      this.edPort.Minimum = new System.Decimal(new int[] {
                                                           1,
                                                           0,
                                                           0,
                                                           0});
      this.edPort.Name = "edPort";
      this.edPort.Size = new System.Drawing.Size(113, 20);
      this.edPort.TabIndex = 5;
      this.edPort.Value = new System.Decimal(new int[] {
                                                         3306,
                                                         0,
                                                         0,
                                                         0});
      // 
      // lbPort
      // 
      this.lbPort.Location = new System.Drawing.Point(10, 113);
      this.lbPort.Name = "lbPort";
      this.lbPort.Size = new System.Drawing.Size(64, 16);
      this.lbPort.TabIndex = 3;
      this.lbPort.Text = "Port";
      // 
      // lbHost
      // 
      this.lbHost.Location = new System.Drawing.Point(10, 81);
      this.lbHost.Name = "lbHost";
      this.lbHost.Size = new System.Drawing.Size(64, 16);
      this.lbHost.TabIndex = 2;
      this.lbHost.Text = "Host";
      // 
      // edPassword
      // 
      this.edPassword.Location = new System.Drawing.Point(88, 46);
      this.edPassword.Name = "edPassword";
      this.edPassword.PasswordChar = '*';
      this.edPassword.Size = new System.Drawing.Size(113, 20);
      this.edPassword.TabIndex = 1;
      this.edPassword.Text = "";
      // 
      // lbPassword
      // 
      this.lbPassword.Location = new System.Drawing.Point(10, 49);
      this.lbPassword.Name = "lbPassword";
      this.lbPassword.Size = new System.Drawing.Size(64, 16);
      this.lbPassword.TabIndex = 1;
      this.lbPassword.Text = "Password";
      // 
      // edUser
      // 
      this.edUser.Location = new System.Drawing.Point(88, 14);
      this.edUser.Name = "edUser";
      this.edUser.Size = new System.Drawing.Size(113, 20);
      this.edUser.TabIndex = 0;
      this.edUser.Text = "";
      // 
      // lbUser
      // 
      this.lbUser.Location = new System.Drawing.Point(10, 17);
      this.lbUser.Name = "lbUser";
      this.lbUser.Size = new System.Drawing.Size(64, 16);
      this.lbUser.TabIndex = 0;
      this.lbUser.Text = "User";
      // 
      // btConnect
      // 
      this.btConnect.Location = new System.Drawing.Point(36, 232);
      this.btConnect.Name = "btConnect";
      this.btConnect.Size = new System.Drawing.Size(75, 24);
      this.btConnect.TabIndex = 1;
      this.btConnect.Text = "Connect";
      this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
      // 
      // btCancel
      // 
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Location = new System.Drawing.Point(124, 232);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(75, 24);
      this.btCancel.TabIndex = 2;
      this.btCancel.Text = "Cancel";
      // 
      // cbHost
      // 
      this.cbHost.Location = new System.Drawing.Point(88, 78);
      this.cbHost.Name = "cbHost";
      this.cbHost.Size = new System.Drawing.Size(113, 21);
      this.cbHost.TabIndex = 2;
      // 
      // ConnectForm
      // 
      this.AcceptButton = this.btConnect;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.CancelButton = this.btCancel;
      this.ClientSize = new System.Drawing.Size(239, 268);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.panel1,
                                                                  this.btCancel,
                                                                  this.btConnect});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(245, 293);
      this.Name = "ConnectForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Connect";
      this.Closing += new System.ComponentModel.CancelEventHandler(this.ConnectForm_Closing);
      this.Load += new System.EventHandler(this.ConnectForm_Load);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.edPort)).EndInit();
      this.ResumeLayout(false);

    }
    #endregion

    private void FillHostListThreadFunc() {

      Invoke(new MethodInvoker(SetStartingCursor));

      try {
        System.Data.DataTable sources = PgSqlProviderFactory.Instance.CreateDataSourceEnumerator().GetDataSources();

        foreach (System.Data.DataRow hostInfo in sources.Rows)
          if (cbHost != null && !cbHost.IsDisposed && !cbHost.Disposing)
            cbHost.Invoke(new AddHostItemDelegate(AddHostItem), new object[] { hostInfo["ServerName"].ToString() });
      }
      catch {
      }
      finally {
        try {
          Invoke(new MethodInvoker(SetDefaultCursor));
        }
        catch {
        }
      }
    }

    private void SetDefaultCursor() {

      if (!this.IsDisposed)
        Cursor = Cursors.Default;
    }

    private void SetStartingCursor() {

      Cursor = Cursors.AppStarting;
    }

    private void AddHostItem(string host) {

      cbHost.Items.Add(host);
    }

    private void btConnect_Click(object sender, System.EventArgs e) {

      connection.Close();

      connection.UserId = edUser.Text;
      connection.Password = edPassword.Text;
      connection.Host = cbHost.Text;
      connection.Port = Convert.ToInt32(edPort.Text);
      connection.Database = cbDatabase.Text;
      connection.Schema = cbSchema.Text;

      try {
        Cursor.Current = Cursors.WaitCursor;

        connection.Open();

        Cursor.Current = Cursors.Default;

        DialogResult = DialogResult.OK;
      }
      catch (PgSqlException exception) {
        Cursor.Current = Cursors.Default;

        retries--;
        if (retries == 0)
          DialogResult = DialogResult.Cancel;

        string msg = exception.Message.Trim();

        if (msg == "FATAL:  user \"" + edUser.Text + "\" does not exist"
          || msg == "FATAL:  no PostgreSQL user name specified in startup packet")
          ActiveControl = edUser;
        else if (msg == "No such host is known")
          ActiveControl = cbHost;
        else if (msg == "No connection could be made because the target machine actively refused it")
          ActiveControl = edPort;
        else if (msg == "FATAL:  Database \"" + cbDatabase.Text + "\" does not exist in the system catalog.")
          ActiveControl = cbDatabase;
        
        MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void cbDatabase_DropDown(object sender, System.EventArgs e) {
      
      Cursor.Current = Cursors.WaitCursor;
      cbDatabase.Items.Clear();
      cbSchema.Text = "";

      PgSqlConnection databaseConnection = new PgSqlConnection();
      databaseConnection.Host = cbHost.Text;
      databaseConnection.UserId = edUser.Text;
      databaseConnection.Password = edPassword.Text;
      databaseConnection.Port = (int)edPort.Value;

      try {
        databaseConnection.Open();
        System.Data.IDbCommand command = new PgSqlCommand("SELECT datname FROM pg_database WHERE datallowconn = true and datname <> 'template1'", databaseConnection);
        using (System.Data.IDataReader reader = command.ExecuteReader()) {
          while (reader.Read())
            cbDatabase.Items.Add(reader[0]);
        }
      }
      catch (Exception exception) {
        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally {
        Cursor.Current = Cursors.Default;
        databaseConnection.Close();
      }
    }

    private void cbSchema_DropDown(object sender, System.EventArgs e) {

      cbSchema.Items.Clear();
      if (cbDatabase.Text.Length == 0)
        return;

      Cursor.Current = Cursors.WaitCursor;

      PgSqlConnection databaseConnection = new PgSqlConnection();
      databaseConnection.Host = cbHost.Text;
      databaseConnection.UserId = edUser.Text;
      databaseConnection.Password = edPassword.Text;
      databaseConnection.Port = (int)edPort.Value;
      databaseConnection.Database = cbDatabase.Text;

      try {
        databaseConnection.Open();
        DataTable schemasTab = databaseConnection.GetSchema("Schemas");
        foreach (DataRow row in schemasTab.Rows)
          if (row["nsptyp"] != null && row["nsptyp"] != DBNull.Value && (int)row["nsptyp"] == 2)
            cbSchema.Items.Add(row["name"]);
      }
      catch (Exception exception) {
        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally {
        Cursor.Current = Cursors.Default;
        databaseConnection.Close();
      }
    }

    private delegate void AddHostItemDelegate(string host);

    private void ConnectForm_Load(object sender, EventArgs e) {

      fillHostsThread = new System.Threading.Thread(new System.Threading.ThreadStart(FillHostListThreadFunc));
      fillHostsThread.Start();
    }

    private void ConnectForm_Closing(object sender, System.ComponentModel.CancelEventArgs e) {

      if (fillHostsThread != null && fillHostsThread.ThreadState == System.Threading.ThreadState.Running)
        fillHostsThread.Abort();
    }
  }
}
