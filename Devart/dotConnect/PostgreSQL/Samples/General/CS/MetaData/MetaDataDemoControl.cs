using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace Samples
{
  public class MetaDataDemoControl : BaseDemoControl
  {
    private System.Windows.Forms.Panel topPanel;
    private System.Windows.Forms.Button btRefresh;
    private System.Windows.Forms.Panel panelForGrids;
    private System.Windows.Forms.Splitter splitter;
    private System.Windows.Forms.DataGrid dgShowMeta;
    private System.Windows.Forms.Splitter spltHorizontal;
    private System.Windows.Forms.TreeView tvSchemaView;
    private System.ComponentModel.IContainer components = null;
    private Devart.Data.PostgreSql.PgSqlConnection connection;
    private System.Windows.Forms.PropertyGrid propertyGrid;
    private System.Windows.Forms.Panel pnRestrict;
    private System.Windows.Forms.Label lbRest;
    private System.Windows.Forms.Label lbColl;
    private System.Data.DataTable dtRestrict;

    public MetaDataDemoControl() {

      InitializeComponent();
    }

    public MetaDataDemoControl(Devart.Data.PostgreSql.PgSqlConnection connection)
      : this () {

      this.connection = connection;
      if (connection.State == System.Data.ConnectionState.Open)
        BuildTree();
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
      this.topPanel = new System.Windows.Forms.Panel();
      this.btRefresh = new System.Windows.Forms.Button();
      this.panelForGrids = new System.Windows.Forms.Panel();
      this.tvSchemaView = new System.Windows.Forms.TreeView();
      this.spltHorizontal = new System.Windows.Forms.Splitter();
      this.pnRestrict = new System.Windows.Forms.Panel();
      this.propertyGrid = new System.Windows.Forms.PropertyGrid();
      this.lbRest = new System.Windows.Forms.Label();
      this.lbColl = new System.Windows.Forms.Label();
      this.splitter = new System.Windows.Forms.Splitter();
      this.dgShowMeta = new System.Windows.Forms.DataGrid();
      this.connection = new Devart.Data.PostgreSql.PgSqlConnection();
      this.topPanel.SuspendLayout();
      this.panelForGrids.SuspendLayout();
      this.pnRestrict.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgShowMeta)).BeginInit();
      this.SuspendLayout();
      // 
      // topPanel
      // 
      this.topPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.btRefresh});
      this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.topPanel.Name = "topPanel";
      this.topPanel.Size = new System.Drawing.Size(400, 24);
      this.topPanel.TabIndex = 10;
      // 
      // btRefresh
      // 
      this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btRefresh.Name = "btRefresh";
      this.btRefresh.TabIndex = 2;
      this.btRefresh.Text = "Refresh";
      this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
      // 
      // panelForGrids
      // 
      this.panelForGrids.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.tvSchemaView,
                                                                                this.spltHorizontal,
                                                                                this.pnRestrict,
                                                                                this.lbColl});
      this.panelForGrids.Dock = System.Windows.Forms.DockStyle.Left;
      this.panelForGrids.Location = new System.Drawing.Point(0, 24);
      this.panelForGrids.Name = "panelForGrids";
      this.panelForGrids.Size = new System.Drawing.Size(160, 276);
      this.panelForGrids.TabIndex = 3;
      // 
      // tvSchemaView
      // 
      this.tvSchemaView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tvSchemaView.HideSelection = false;
      this.tvSchemaView.ImageIndex = -1;
      this.tvSchemaView.Location = new System.Drawing.Point(0, 15);
      this.tvSchemaView.Name = "tvSchemaView";
      this.tvSchemaView.SelectedImageIndex = -1;
      this.tvSchemaView.Size = new System.Drawing.Size(160, 170);
      this.tvSchemaView.TabIndex = 2;
      this.tvSchemaView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSchemaView_AfterSelect);
      // 
      // spltHorizontal
      // 
      this.spltHorizontal.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.spltHorizontal.Location = new System.Drawing.Point(0, 185);
      this.spltHorizontal.MinExtra = 60;
      this.spltHorizontal.MinSize = 50;
      this.spltHorizontal.Name = "spltHorizontal";
      this.spltHorizontal.Size = new System.Drawing.Size(160, 3);
      this.spltHorizontal.TabIndex = 1;
      this.spltHorizontal.TabStop = false;
      this.spltHorizontal.Visible = false;
      // 
      // pnRestrict
      // 
      this.pnRestrict.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                             this.propertyGrid,
                                                                             this.lbRest});
      this.pnRestrict.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnRestrict.Location = new System.Drawing.Point(0, 188);
      this.pnRestrict.Name = "pnRestrict";
      this.pnRestrict.Size = new System.Drawing.Size(160, 88);
      this.pnRestrict.TabIndex = 4;
      this.pnRestrict.Visible = false;
      // 
      // propertyGrid
      // 
      this.propertyGrid.CommandsVisibleIfAvailable = true;
      this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyGrid.HelpVisible = false;
      this.propertyGrid.LargeButtons = false;
      this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
      this.propertyGrid.Location = new System.Drawing.Point(0, 15);
      this.propertyGrid.Name = "propertyGrid";
      this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
      this.propertyGrid.Size = new System.Drawing.Size(160, 73);
      this.propertyGrid.TabIndex = 6;
      this.propertyGrid.Text = "PropertyGrid";
      this.propertyGrid.ToolbarVisible = false;
      this.propertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
      this.propertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
      // 
      // lbRest
      // 
      this.lbRest.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.lbRest.Dock = System.Windows.Forms.DockStyle.Top;
      this.lbRest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.lbRest.Name = "lbRest";
      this.lbRest.Size = new System.Drawing.Size(160, 15);
      this.lbRest.TabIndex = 4;
      this.lbRest.Text = "Restrictions";
      // 
      // lbColl
      // 
      this.lbColl.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.lbColl.Dock = System.Windows.Forms.DockStyle.Top;
      this.lbColl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.lbColl.Name = "lbColl";
      this.lbColl.Size = new System.Drawing.Size(160, 15);
      this.lbColl.TabIndex = 3;
      this.lbColl.Text = "Collections";
      // 
      // splitter
      // 
      this.splitter.Location = new System.Drawing.Point(160, 24);
      this.splitter.MinExtra = 100;
      this.splitter.MinSize = 100;
      this.splitter.Name = "splitter";
      this.splitter.Size = new System.Drawing.Size(3, 276);
      this.splitter.TabIndex = 11;
      this.splitter.TabStop = false;
      // 
      // dgShowMeta
      // 
      this.dgShowMeta.AllowNavigation = false;
      this.dgShowMeta.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dgShowMeta.CaptionVisible = false;
      this.dgShowMeta.DataMember = "";
      this.dgShowMeta.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgShowMeta.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dgShowMeta.Location = new System.Drawing.Point(163, 24);
      this.dgShowMeta.Name = "dgShowMeta";
      this.dgShowMeta.ReadOnly = true;
      this.dgShowMeta.Size = new System.Drawing.Size(237, 276);
      this.dgShowMeta.TabIndex = 12;
      // 
      // connection
      // 
      this.connection.Name = "connection";
      this.connection.Owner = this;
      // 
      // MetaDataDemoControl
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.dgShowMeta,
                                                                  this.splitter,
                                                                  this.panelForGrids,
                                                                  this.topPanel});
      this.Name = "MetaDataDemoControl";
      this.Size = new System.Drawing.Size(400, 300);
      this.topPanel.ResumeLayout(false);
      this.panelForGrids.ResumeLayout(false);
      this.pnRestrict.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgShowMeta)).EndInit();
      this.ResumeLayout(false);

    }
    #endregion

    private void tvSchemaView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {

      try {
        dgShowMeta.DataSource = this.connection.GetSchema(e.Node.Text);
      }
      catch {
        dgShowMeta.DataSource = null;
      }

      // get restrictions table for selected database object
      DataTable propGridSource = new DataTable(e.Node.Text);

      foreach (DataRow row in dtRestrict.Rows) {
        if (row["CollectionName"].ToString() == e.Node.Text) {// restriction found
          propGridSource.Columns.Add(row["RestrictionName"].ToString());
        }
      }

      bool gridNotEmpty = (propGridSource.Columns.Count == 0);

      spltHorizontal.Visible = gridNotEmpty;
      pnRestrict.Visible = gridNotEmpty;

      if (gridNotEmpty) {
        propGridSource.Rows.Add(propGridSource.NewRow());
        propertyGrid.SelectedObject = propGridSource.DefaultView[0];
        writeStatus2 = "Enter restrictions for " + e.Node.Text;
      }
      else
        writeStatus2 = "";

      OnWriteStatus();
    }

    private void btRefresh_Click(object sender, System.EventArgs e) {

      if (tvSchemaView.Nodes.Count == 0)
        BuildTree();
      else {

        if (!this.pnRestrict.Visible)
          return;

        DataTable dtFromProp = ((DataRowView)this.propertyGrid.SelectedObject).DataView.Table;
        int restrNumber = dtFromProp.Columns.Count;
        string[] restrArray = new string[restrNumber];

        for (int i = 0; i < restrNumber; i++)
          if (dtFromProp.Rows[0][i].ToString() != "")
            restrArray[i] = dtFromProp.Rows[0][i].ToString();

        this.dgShowMeta.DataSource = connection.GetSchema(dtFromProp.TableName, restrArray);
      }
    }

    private void BuildTree() {

      DataTable dt = connection.GetSchema();

      tvSchemaView.Nodes.Add(new TreeNode("MetaDataCollections"));

      IEnumerator enumer = dt.Rows.GetEnumerator();

      while (enumer.MoveNext())  //skip "MetaDataCollections"
        tvSchemaView.Nodes[0].Nodes.Add(new TreeNode(((DataRow)enumer.Current)["CollectionName"].ToString()));

      tvSchemaView.Nodes[0].Expand();

      dtRestrict = connection.GetSchema("Restrictions");

      dgShowMeta.DataSource = null;
      writeStatus1 = "Select database object";
      OnWriteStatus();
    }
  }
}