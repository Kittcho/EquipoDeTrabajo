Imports Devart.Data.PostgreSql
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Namespace Samples
  Public Class RowDataSetDemoControl
    Inherits BaseDemoControl

    ' Fields
    Private WithEvents command As Devart.Data.PostgreSql.PgSqlCommand
    Private WithEvents pgSqlDataAdapter As Devart.Data.PostgreSql.PgSqlDataAdapter
    Private WithEvents pgSqlCommandBuilder As Devart.Data.PostgreSql.PgSqlCommandBuilder
    Private WithEvents dataSet As System.Data.DataSet
    Private WithEvents splitter As System.Windows.Forms.Splitter
    Private WithEvents tbSql As System.Windows.Forms.TextBox
    Private WithEvents pnTop As System.Windows.Forms.Panel
    Private WithEvents btUpdate As System.Windows.Forms.Button
    Private WithEvents btClear As System.Windows.Forms.Button
    Private WithEvents btFill As System.Windows.Forms.Button
    Private WithEvents dataGrid As System.Windows.Forms.DataGrid

    ' Methods
    Public Sub New()
      Me.components = Nothing
      Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal connection As PgSqlConnection)
      Me.New()
      Me.command.Connection = connection
      Me.tbSql.Text = Me.command.CommandText
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.command = New Devart.Data.PostgreSql.PgSqlCommand()
      Me.pgSqlDataAdapter = New Devart.Data.PostgreSql.PgSqlDataAdapter()
      Me.pgSqlCommandBuilder = New Devart.Data.PostgreSql.PgSqlCommandBuilder()
      Me.dataSet = New System.Data.DataSet()
      Me.splitter = New System.Windows.Forms.Splitter()
      Me.tbSql = New System.Windows.Forms.TextBox()
      Me.pnTop = New System.Windows.Forms.Panel()
      Me.btUpdate = New System.Windows.Forms.Button()
      Me.btClear = New System.Windows.Forms.Button()
      Me.btFill = New System.Windows.Forms.Button()
      Me.dataGrid = New System.Windows.Forms.DataGrid()
      CType(Me.dataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnTop.SuspendLayout()
      CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'command
      '
      Me.command.CommandText = "SELECT * FROM Dept_Container"
      Me.command.Name = "command"
      Me.command.Owner = Me
      '
      'pgSqlDataAdapter
      '
      Me.pgSqlDataAdapter.SelectCommand = Me.command
      '
      'pgSqlCommandBuilder
      '
      Me.pgSqlCommandBuilder.DataAdapter = Me.pgSqlDataAdapter
      Me.pgSqlCommandBuilder.UpdatingFields = ""
      '
      'dataSet
      '
      Me.dataSet.DataSetName = "NewDataSet"
      Me.dataSet.Locale = New System.Globalization.CultureInfo("en-US")
      '
      'splitter
      '
      Me.splitter.Dock = System.Windows.Forms.DockStyle.Top
      Me.splitter.Location = New System.Drawing.Point(0, 88)
      Me.splitter.MinExtra = 50
      Me.splitter.Name = "splitter"
      Me.splitter.Size = New System.Drawing.Size(376, 3)
      Me.splitter.TabIndex = 10
      Me.splitter.TabStop = False
      '
      'tbSql
      '
      Me.tbSql.Dock = System.Windows.Forms.DockStyle.Top
      Me.tbSql.Location = New System.Drawing.Point(0, 24)
      Me.tbSql.Multiline = True
      Me.tbSql.Name = "tbSql"
      Me.tbSql.Size = New System.Drawing.Size(376, 64)
      Me.tbSql.TabIndex = 9
      '
      'pnTop
      '
      Me.pnTop.Controls.Add(Me.btUpdate)
      Me.pnTop.Controls.Add(Me.btClear)
      Me.pnTop.Controls.Add(Me.btFill)
      Me.pnTop.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnTop.Location = New System.Drawing.Point(0, 0)
      Me.pnTop.Name = "pnTop"
      Me.pnTop.Size = New System.Drawing.Size(376, 24)
      Me.pnTop.TabIndex = 8
      '
      'btUpdate
      '
      Me.btUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btUpdate.Location = New System.Drawing.Point(152, 0)
      Me.btUpdate.Name = "btUpdate"
      Me.btUpdate.Size = New System.Drawing.Size(75, 23)
      Me.btUpdate.TabIndex = 2
      Me.btUpdate.Text = "Update"
      '
      'btClear
      '
      Me.btClear.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btClear.Location = New System.Drawing.Point(76, 0)
      Me.btClear.Name = "btClear"
      Me.btClear.Size = New System.Drawing.Size(75, 23)
      Me.btClear.TabIndex = 1
      Me.btClear.Text = "Clear"
      '
      'btFill
      '
      Me.btFill.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btFill.Location = New System.Drawing.Point(0, 0)
      Me.btFill.Name = "btFill"
      Me.btFill.Size = New System.Drawing.Size(75, 23)
      Me.btFill.TabIndex = 0
      Me.btFill.Text = "Fill"
      '
      'dataGrid
      '
      Me.dataGrid.AllowNavigation = False
      Me.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dataGrid.CaptionVisible = False
      Me.dataGrid.DataMember = ""
      Me.dataGrid.DataSource = Me.dataSet
      Me.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dataGrid.GridLineColor = System.Drawing.SystemColors.ActiveBorder
      Me.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.dataGrid.Location = New System.Drawing.Point(0, 91)
      Me.dataGrid.Name = "dataGrid"
      Me.dataGrid.Size = New System.Drawing.Size(376, 147)
      Me.dataGrid.TabIndex = 11
      '
      'RowDataSetDemoControl
      '
      Me.Controls.Add(Me.dataGrid)
      Me.Controls.Add(Me.splitter)
      Me.Controls.Add(Me.tbSql)
      Me.Controls.Add(Me.pnTop)
      Me.Name = "RowDataSetDemoControl"
      Me.Size = New System.Drawing.Size(376, 238)
      CType(Me.dataSet, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnTop.ResumeLayout(False)
      CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

    ' Methods
    Private Sub btFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFill.Click
      Me.pgSqlDataAdapter.Fill(Me.dataSet, "Table")
      Me.dataGrid.DataMember = "Table"
    End Sub

    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
      Me.dataGrid.DataMember = String.Empty
      Me.dataSet.Clear()
      Dim table As DataTable
      For Each table In Me.dataSet.Tables
        table.Constraints.Clear()
        table.Columns.Clear()
      Next
    End Sub

    Private Sub btUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUpdate.Click
      If (dataSet.Tables.Count > 0) Then
        Me.pgSqlDataAdapter.Update(Me.dataSet, "Table")
      End If
    End Sub

    Private Sub tbSql_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSql.Leave
      Me.command.CommandText = Me.tbSql.Text
      Me.pgSqlCommandBuilder.RefreshSchema()
    End Sub
  End Class
End Namespace