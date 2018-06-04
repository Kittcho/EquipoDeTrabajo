Imports Devart.Data.PostgreSql
Imports CrystalDecisions.Windows.Forms
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Namespace Samples
  Public Class CrystalDemoControl
    Inherits BaseDemoControl

    ' Fields
    Private crystalReport As crystalReport
    Private WithEvents btView As System.Windows.Forms.Button
    Private WithEvents topPanel As System.Windows.Forms.Panel
    Private WithEvents crystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Private WithEvents selectCommand As Devart.Data.PostgreSql.PgSqlCommand
    Private WithEvents dataAdapter As Devart.Data.PostgreSql.PgSqlDataAdapter
    Friend WithEvents ReportDataSet1 As ReportDataSet
    Friend WithEvents DataTable1 As System.Data.DataTable

    ' Methods
    Public Sub New()
      Me.crystalReport = New crystalReport()
      Me.components = Nothing
      Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal connection As IDbConnection)
      Me.New()
      Me.selectCommand.Connection = connection
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          components.Dispose()
        End If
      End If
      MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor. 
    Private Sub InitializeComponent()
      Me.btView = New System.Windows.Forms.Button()
      Me.topPanel = New System.Windows.Forms.Panel()
      Me.crystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
      Me.selectCommand = New Devart.Data.PostgreSql.PgSqlCommand()
      Me.dataAdapter = New Devart.Data.PostgreSql.PgSqlDataAdapter()
      Me.ReportDataSet1 = New ReportDataSet()
      Me.topPanel.SuspendLayout()
      CType(Me.ReportDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btView
      '
      Me.btView.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btView.Location = New System.Drawing.Point(0, 0)
      Me.btView.Name = "btView"
      Me.btView.Size = New System.Drawing.Size(75, 23)
      Me.btView.TabIndex = 2
      Me.btView.Text = "View"
      '
      'topPanel
      '
      Me.topPanel.Controls.Add(Me.btView)
      Me.topPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me.topPanel.Location = New System.Drawing.Point(0, 0)
      Me.topPanel.Name = "topPanel"
      Me.topPanel.Size = New System.Drawing.Size(312, 24)
      Me.topPanel.TabIndex = 5
      '
      'crystalReportViewer
      '
      Me.crystalReportViewer.ActiveViewIndex = -1
      Me.crystalReportViewer.DisplayGroupTree = False
      Me.crystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
      Me.crystalReportViewer.Location = New System.Drawing.Point(0, 24)
      Me.crystalReportViewer.Name = "crystalReportViewer"
      Me.crystalReportViewer.SelectionFormula = ""
      Me.crystalReportViewer.Size = New System.Drawing.Size(312, 200)
      Me.crystalReportViewer.TabIndex = 6
      '
      'selectCommand
      '
      Me.selectCommand.CommandText = "SELECT M.EmpNo, M.EName, M.Job, E.ENAME AS Mgr, M.Sal, M.DeptNo, D.DName, D.Loc" & Microsoft.VisualBasic.ChrW(10) & " " & _
          "      FROM Emp E, Dept D, Emp M" & Microsoft.VisualBasic.ChrW(10) & "       WHERE M.MGR = E.EMPNO AND E.DeptNo = D.De" & _
          "ptNo" & Microsoft.VisualBasic.ChrW(10) & "       ORDER BY M.DeptNo "
      Me.selectCommand.Name = "selectCommand"
      '
      'dataAdapter
      '
      Me.dataAdapter.SelectCommand = Me.selectCommand
      '
      'ReportDataSet1
      '
      Me.ReportDataSet1.DataSetName = "ReportDataSet"
      Me.ReportDataSet1.Locale = New System.Globalization.CultureInfo("ru-RU")
      '
      'CrystalDemoControl
      '
      Me.Controls.Add(Me.crystalReportViewer)
      Me.Controls.Add(Me.topPanel)
      Me.Name = "CrystalDemoControl"
      Me.Size = New System.Drawing.Size(312, 224)
      Me.topPanel.ResumeLayout(False)
      CType(Me.ReportDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

    ' Methods
    Private Sub btView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btView.Click
      Me.dataAdapter.Fill(Me.ReportDataSet1.Emp)
      Me.crystalReport.SetDataSource(Me.ReportDataSet1)
      Me.crystalReportViewer.ReportSource = Me.crystalReport
    End Sub
  End Class
End Namespace