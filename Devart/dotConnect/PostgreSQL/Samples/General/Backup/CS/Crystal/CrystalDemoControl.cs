using System;

namespace Samples
{
  public class CrystalDemoControl : Samples.BaseDemoControl
  {
    private System.Windows.Forms.Panel topPanel;
    private System.Windows.Forms.Button btView;
    private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
    private Samples.Crystal.CrystalReport crystalReport = new Samples.Crystal.CrystalReport();
    private Samples.Crystal.ReportDataSet reportDataSet;
    private Devart.Data.PostgreSql.PgSqlCommand selectCommand;
    private Devart.Data.PostgreSql.PgSqlDataAdapter dataAdapter;
    private System.ComponentModel.IContainer components = null;

    public CrystalDemoControl()
    {
      InitializeComponent();
    }

    public CrystalDemoControl(Devart.Data.PostgreSql.PgSqlConnection connection)    
      : this () {

      this.selectCommand.Connection = connection;
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
      this.selectCommand = new Devart.Data.PostgreSql.PgSqlCommand();
      this.dataAdapter = new Devart.Data.PostgreSql.PgSqlDataAdapter();
      this.topPanel = new System.Windows.Forms.Panel();
      this.btView = new System.Windows.Forms.Button();
      this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
      this.reportDataSet = new Samples.Crystal.ReportDataSet();
      this.topPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.reportDataSet)).BeginInit();
      this.SuspendLayout();
      // 
      // selectCommand
      // 
      this.selectCommand.CommandText = "SELECT M.EmpNo, M.EName, M.Job, E.ENAME AS Mgr, M.Sal, M.DeptNo, D.DName, D.Loc\n    " +
        "   FROM Emp E, Dept D, Emp M\n       WHERE M.MGR = E.EMPNO AND E.DeptNo = D.DeptN" +
        "o\n       ORDER BY M.DeptNo ";
      this.selectCommand.Name = "selectCommand";
      this.selectCommand.Owner = this;
      // 
      // dataAdapter
      // 
      this.dataAdapter.SelectCommand = this.selectCommand;
      // 
      // topPanel
      // 
      this.topPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.btView});
      this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.topPanel.Name = "topPanel";
      this.topPanel.Size = new System.Drawing.Size(312, 24);
      this.topPanel.TabIndex = 3;
      // 
      // btView
      // 
      this.btView.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btView.Name = "btView";
      this.btView.TabIndex = 2;
      this.btView.Text = "View";
      this.btView.Click += new System.EventHandler(this.btView_Click);
      // 
      // crystalReportViewer
      // 
      this.crystalReportViewer.ActiveViewIndex = -1;
      this.crystalReportViewer.DisplayGroupTree = false;
      this.crystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.crystalReportViewer.Location = new System.Drawing.Point(0, 24);
      this.crystalReportViewer.Name = "crystalReportViewer";
      this.crystalReportViewer.ReportSource = null;
      this.crystalReportViewer.Size = new System.Drawing.Size(312, 200);
      this.crystalReportViewer.TabIndex = 4;
      // 
      // reportDataSet
      // 
      this.reportDataSet.DataSetName = "reportDataSet";
      this.reportDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
      this.reportDataSet.Namespace = "http://www.tempuri.org/ReportDataSet.xsd";
      // 
      // CrystalDemoControl
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.crystalReportViewer,
                                                                  this.topPanel});
      this.Name = "CrystalDemoControl";
      this.Size = new System.Drawing.Size(312, 224);
      this.topPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.reportDataSet)).EndInit();
      this.ResumeLayout(false);

    }
    #endregion

    private void btView_Click(object sender, System.EventArgs e) {
    
      dataAdapter.Fill(reportDataSet.Emp);
                  
      // Use Report Engine object model to pass populated dataset to report
      crystalReport.SetDataSource(reportDataSet);

      crystalReportViewer.ReportSource = crystalReport;
    }
  }
}

