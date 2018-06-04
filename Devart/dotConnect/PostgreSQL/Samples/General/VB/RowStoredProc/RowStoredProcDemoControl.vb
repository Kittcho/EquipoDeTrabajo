Imports Devart.Data.PostgreSql
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Namespace Samples
  Public Class RowStoredProcDemoControl
    Inherits BaseDemoControl

    ' Fields
    Private WithEvents pgSqlCommand As Devart.Data.PostgreSql.PgSqlCommand
    Private WithEvents pgSqlDataAdapter As Devart.Data.PostgreSql.PgSqlDataAdapter
    Private WithEvents pgSqlCommandBuilder As Devart.Data.PostgreSql.PgSqlCommandBuilder
    Private WithEvents dataSet As System.Data.DataSet
    Private WithEvents pnTop As System.Windows.Forms.Panel
    Private WithEvents btClear As System.Windows.Forms.Button
    Private WithEvents btFill As System.Windows.Forms.Button
    Private WithEvents edParamValue As System.Windows.Forms.TextBox
    Private WithEvents lbStoredProcName As System.Windows.Forms.Label
    Private WithEvents dataGrid As System.Windows.Forms.DataGrid

    ' Methods
    Public Sub New()
      Me.components = Nothing
      Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal connection As PgSqlConnection)
      Me.New()
      Me.pgSqlCommand.Connection = connection
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
      Me.pgSqlCommand = New Devart.Data.PostgreSql.PgSqlCommand()
      Me.pgSqlDataAdapter = New Devart.Data.PostgreSql.PgSqlDataAdapter()
      Me.pgSqlCommandBuilder = New Devart.Data.PostgreSql.PgSqlCommandBuilder()
      Me.dataSet = New System.Data.DataSet()
      Me.pnTop = New System.Windows.Forms.Panel()
      Me.btClear = New System.Windows.Forms.Button()
      Me.btFill = New System.Windows.Forms.Button()
      Me.edParamValue = New System.Windows.Forms.TextBox()
      Me.lbStoredProcName = New System.Windows.Forms.Label()
      Me.dataGrid = New System.Windows.Forms.DataGrid()
      CType(Me.dataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnTop.SuspendLayout()
      CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'pgSqlCommand
      '
      Me.pgSqlCommand.CommandType = System.Data.CommandType.StoredProcedure
      Me.pgSqlCommand.CommandText = "getdept"
      Me.pgSqlCommand.Name = "pgSqlCommand"
      Me.pgSqlCommand.Parameters.Add(New Devart.Data.PostgreSql.PgSqlParameter("p1", "dept_container", System.Data.ParameterDirection.Input, False, "", System.Data.DataRowVersion.Current, "1, '(1, N a m e , location)' "))
      Me.pgSqlCommand.Owner = Me
      '
      'pgSqlDataAdapter
      '
      Me.pgSqlDataAdapter.SelectCommand = Me.pgSqlCommand
      '
      'pgSqlCommandBuilder
      '
      Me.pgSqlCommandBuilder.DataAdapter = Me.pgSqlDataAdapter
      Me.pgSqlCommandBuilder.UpdatingFields = ""
      '
      'dataSet
      '
      Me.dataSet.DataSetName = "NewDataSet"
      Me.dataSet.EnforceConstraints = False
      '
      'pnTop
      '
      Me.pnTop.Controls.Add(Me.btClear)
      Me.pnTop.Controls.Add(Me.btFill)
      Me.pnTop.Controls.Add(Me.edParamValue)
      Me.pnTop.Controls.Add(Me.lbStoredProcName)
      Me.pnTop.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnTop.Location = New System.Drawing.Point(0, 0)
      Me.pnTop.Name = "pnTop"
      Me.pnTop.Size = New System.Drawing.Size(456, 43)
      Me.pnTop.TabIndex = 3
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
      'edParamValue
      '
      Me.edParamValue.Location = New System.Drawing.Point(264, 12)
      Me.edParamValue.Name = "edParamValue"
      Me.edParamValue.Size = New System.Drawing.Size(176, 20)
      Me.edParamValue.TabIndex = 10
      Me.edParamValue.Text = "(1, '(1, N a m e , location)' )"
      '
      'lbStoredProcName
      '
      Me.lbStoredProcName.Location = New System.Drawing.Point(160, 16)
      Me.lbStoredProcName.Name = "lbStoredProcName"
      Me.lbStoredProcName.Size = New System.Drawing.Size(88, 16)
      Me.lbStoredProcName.TabIndex = 9
      Me.lbStoredProcName.Text = "Parameter value"
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
      Me.dataGrid.Location = New System.Drawing.Point(0, 43)
      Me.dataGrid.Name = "dataGrid"
      Me.dataGrid.Size = New System.Drawing.Size(456, 195)
      Me.dataGrid.TabIndex = 6
      '
      'RowStoredProcDemoControl
      '
      Me.Controls.Add(Me.dataGrid)
      Me.Controls.Add(Me.pnTop)
      Me.Name = "RowStoredProcDemoControl"
      Me.Size = New System.Drawing.Size(456, 238)
      CType(Me.dataSet, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnTop.ResumeLayout(False)
      Me.pnTop.PerformLayout()
      CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

    ' Methods
    Private Sub btFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFill.Click
      Me.pgSqlCommand.Parameters.Item(0).Value = Me.edParamValue.Text
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
  End Class
End Namespace