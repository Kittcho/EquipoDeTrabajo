using System;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Samples
{
  public class PicturesDemoControl : BaseDemoControl {
    private System.Windows.Forms.Panel middlePanel;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.DataGrid dataGrid;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Panel topPanel;
    private System.Windows.Forms.Button btShowImages;
    private System.Windows.Forms.Button btUpdate;
    private System.Windows.Forms.Button btClear;
    private System.Windows.Forms.Button btFill;
    private System.Windows.Forms.Splitter splitter;
    private System.Windows.Forms.Button btClearPicture;
    private System.Windows.Forms.Button btSave;
    private System.Windows.Forms.Button btLoad;

    private System.Data.DataSet dataSet;
    private Devart.Data.PostgreSql.PgSqlCommand selectCommand;
    private Devart.Data.PostgreSql.PgSqlDataAdapter dataAdapter;
    private Devart.Data.PostgreSql.PgSqlCommandBuilder commandBuilder;

    private System.ComponentModel.IContainer components = null;

    public PicturesDemoControl() {

      InitializeComponent();
    }

    public PicturesDemoControl(Devart.Data.PostgreSql.PgSqlConnection connection)
      : this () {

      selectCommand.Connection = connection;
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
      this.middlePanel = new System.Windows.Forms.Panel();
      this.btClearPicture = new System.Windows.Forms.Button();
      this.btSave = new System.Windows.Forms.Button();
      this.btLoad = new System.Windows.Forms.Button();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.splitter = new System.Windows.Forms.Splitter();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.dataGrid = new System.Windows.Forms.DataGrid();
      this.dataSet = new System.Data.DataSet();
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.topPanel = new System.Windows.Forms.Panel();
      this.btShowImages = new System.Windows.Forms.Button();
      this.btUpdate = new System.Windows.Forms.Button();
      this.btClear = new System.Windows.Forms.Button();
      this.btFill = new System.Windows.Forms.Button();
      this.selectCommand = new Devart.Data.PostgreSql.PgSqlCommand();
      this.dataAdapter = new Devart.Data.PostgreSql.PgSqlDataAdapter();
      this.commandBuilder = new Devart.Data.PostgreSql.PgSqlCommandBuilder();
      this.middlePanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
      this.topPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // middlePanel
      // 
      this.middlePanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                              this.btClearPicture,
                                                                              this.btSave,
                                                                              this.btLoad});
      this.middlePanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.middlePanel.Location = new System.Drawing.Point(0, 123);
      this.middlePanel.Name = "middlePanel";
      this.middlePanel.Size = new System.Drawing.Size(520, 24);
      this.middlePanel.TabIndex = 15;
      // 
      // btClearPicture
      // 
      this.btClearPicture.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btClearPicture.Location = new System.Drawing.Point(194, 0);
      this.btClearPicture.Name = "btClearPicture";
      this.btClearPicture.Size = new System.Drawing.Size(64, 23);
      this.btClearPicture.TabIndex = 2;
      this.btClearPicture.Text = "Clear";
      this.btClearPicture.Click += new System.EventHandler(this.btClearPicture_Click);
      // 
      // btSave
      // 
      this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btSave.Location = new System.Drawing.Point(97, 0);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(96, 23);
      this.btSave.TabIndex = 1;
      this.btSave.Text = "Save to file...";
      this.btSave.Click += new System.EventHandler(this.btSave_Click);
      // 
      // btLoad
      // 
      this.btLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btLoad.Name = "btLoad";
      this.btLoad.Size = new System.Drawing.Size(96, 23);
      this.btLoad.TabIndex = 0;
      this.btLoad.Text = "Load from file...";
      this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.DefaultExt = "bmp";
      this.openFileDialog.Filter = "Bitmaps (*.bmp)|*.bmp";
      // 
      // splitter
      // 
      this.splitter.Cursor = System.Windows.Forms.Cursors.HSplit;
      this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
      this.splitter.Location = new System.Drawing.Point(0, 120);
      this.splitter.MinExtra = 70;
      this.splitter.MinSize = 70;
      this.splitter.Name = "splitter";
      this.splitter.Size = new System.Drawing.Size(520, 3);
      this.splitter.TabIndex = 16;
      this.splitter.TabStop = false;
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.DefaultExt = "bmp";
      this.saveFileDialog.Filter = "Bitmaps (*.bmp)|*.bmp";
      // 
      // dataGrid
      // 
      this.dataGrid.AllowNavigation = false;
      this.dataGrid.AllowSorting = false;
      this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dataGrid.CaptionVisible = false;
      this.dataGrid.DataMember = "";
      this.dataGrid.DataSource = this.dataSet;
      this.dataGrid.Dock = System.Windows.Forms.DockStyle.Top;
      this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGrid.Location = new System.Drawing.Point(0, 24);
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.Size = new System.Drawing.Size(520, 96);
      this.dataGrid.TabIndex = 13;
      this.dataGrid.DataSourceChanged += new System.EventHandler(this.dataGrid_DataSourceChanged);
      this.dataGrid.CurrentCellChanged += new System.EventHandler(this.dataGrid_CurrentCellChanged);
      // 
      // dataSet
      // 
      this.dataSet.DataSetName = "NewDataSet";
      this.dataSet.Locale = new System.Globalization.CultureInfo("en-US");
      // 
      // pictureBox
      // 
      this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox.Location = new System.Drawing.Point(0, 147);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(520, 133);
      this.pictureBox.TabIndex = 14;
      this.pictureBox.TabStop = false;
      // 
      // topPanel
      // 
      this.topPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.btShowImages,
                                                                           this.btUpdate,
                                                                           this.btClear,
                                                                           this.btFill});
      this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.topPanel.Name = "topPanel";
      this.topPanel.Size = new System.Drawing.Size(520, 24);
      this.topPanel.TabIndex = 11;
      // 
      // btShowImages
      // 
      this.btShowImages.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btShowImages.Location = new System.Drawing.Point(330, 0);
      this.btShowImages.Name = "btShowImages";
      this.btShowImages.Size = new System.Drawing.Size(88, 23);
      this.btShowImages.TabIndex = 5;
      this.btShowImages.Text = "Show Images !";
      this.btShowImages.Click += new System.EventHandler(this.btShowImages_Click);
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
      // selectCommand
      // 
      this.selectCommand.CommandText = "SELECT * FROM pgsqlnet_pictures";
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
      // PicturesDemoControl
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.pictureBox,
                                                                  this.middlePanel,
                                                                  this.splitter,
                                                                  this.dataGrid,
                                                                  this.topPanel});
      this.Name = "PicturesDemoControl";
      this.Size = new System.Drawing.Size(520, 280);
      this.middlePanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
      this.topPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    #endregion
 
    private void UpdatePictureBox() {

      pictureBox.Image = null;
      writeStatus1 = "";
      writeStatus2 = "";
      DataTable table = dataSet.Tables["Table"];
      if (table != null && dataGrid.CurrentRowIndex >= 0 && dataGrid.CurrentRowIndex < table.Rows.Count) {
        object val = DBNull.Value;
        if (table.Rows[dataGrid.CurrentRowIndex].RowState != DataRowState.Deleted)
          val = table.Rows[dataGrid.CurrentRowIndex]["Picture"];
        if (val != DBNull.Value) {
          if (((byte[])val).Length > 0)
            pictureBox.Image = System.Drawing.Bitmap.FromStream(new MemoryStream((byte[])val));
          writeStatus1 = "Size: " + ((byte[])val).Length.ToString();
        }
        writeStatus2 = table.Rows.Count.ToString() + " rows selected";
      }
      OnWriteStatus();
    }

    private void btFill_Click(object sender, System.EventArgs e) {

        dataAdapter.Fill(dataSet, "Table");
        dataGrid.DataMember = "Table";
        UpdatePictureBox();
    }

    private void btClear_Click(object sender, System.EventArgs e) {
    
      dataGrid.DataMember = String.Empty;
      dataSet.Clear();
      foreach (DataTable table in dataSet.Tables)
        table.Constraints.Clear();
      UpdatePictureBox();
    }

    private void btUpdate_Click(object sender, System.EventArgs e) {
    
      if (dataSet.Tables.Count != 0)
        dataAdapter.Update(dataSet, "Table");
    }

    private void btShowImages_Click(object sender, System.EventArgs e) {

      Devart.Data.PostgreSql.PgSqlDataReader dataReader = selectCommand.ExecuteReader();

      int fieldNo = dataReader.GetOrdinal("Picture");

      while (dataReader.Read()) {
        int length = (int)dataReader.GetBytes(fieldNo, 0, null, 0, 0);
        byte[] buffer = new Byte[length];
        length = (int)dataReader.GetBytes(fieldNo, 0, buffer, 0, length);

        string pictureName = dataReader.GetString(1);

        if (length > 0) {
          Form form = new Form();
          form.Text = pictureName;
          form.Show();
          PictureBox pictureBox = new PictureBox();
          pictureBox.Parent = form;
          pictureBox.Dock =  DockStyle.Fill;
          pictureBox.Image = System.Drawing.Bitmap.FromStream(new MemoryStream(buffer));
        }
      }

      dataReader.Close();
    }

    private void btLoad_Click(object sender, System.EventArgs e) {

      DataTable table = dataSet.Tables["Table"];
      if (table != null) {
        if (dataGrid.CurrentRowIndex >= 0 && dataGrid.CurrentRowIndex < table.Rows.Count) {
          if (openFileDialog.ShowDialog() == DialogResult.OK) {
            FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
            byte[] val = new byte[fs.Length];
            fs.Read(val, 0, (int)fs.Length);
            fs.Close();
            table.Rows[dataGrid.CurrentRowIndex]["Picture"] = val;
          }
        }
        UpdatePictureBox();
      }
    }

    private void btSave_Click(object sender, System.EventArgs e) {

      DataTable table = dataSet.Tables["Table"];
      if (table != null) {
        if (dataGrid.CurrentRowIndex >= 0 && dataGrid.CurrentRowIndex < table.Rows.Count) {
          object val = table.Rows[dataGrid.CurrentRowIndex]["Picture"];
          if (val != DBNull.Value && saveFileDialog.ShowDialog() == DialogResult.OK) {
            FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.CreateNew,  FileAccess.Write);
            fs.Write((byte[])val, 0, ((byte[])val).Length);
            fs.Close();
          }
        }
      }
    }

    private void btClearPicture_Click(object sender, System.EventArgs e) {

      DataTable table = dataSet.Tables["Table"];
      if (table != null) {
        if (dataGrid.CurrentRowIndex >= 0 && dataGrid.CurrentRowIndex < table.Rows.Count)
          table.Rows[dataGrid.CurrentRowIndex]["Picture"] = DBNull.Value;

        UpdatePictureBox();
      }
    }

    private void dataGrid_CurrentCellChanged(object sender, System.EventArgs e) {

      UpdatePictureBox();
    }

    void dataGrid_DataSourceChanged(object sender, EventArgs e) {

      btLoad.Enabled = btSave.Enabled = !(dataGrid.DataSource == null || dataGrid.DataMember == String.Empty);
    }
  }
}

