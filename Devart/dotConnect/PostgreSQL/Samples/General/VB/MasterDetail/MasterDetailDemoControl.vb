Imports Devart.Data.PostgreSql
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Namespace Samples
  Public Class MasterDetailDemoControl
    Inherits BaseDemoControl

    ' Fields
    Private WithEvents masterCommand As Devart.Data.PostgreSql.PgSqlCommand
    Private WithEvents detailCommand As Devart.Data.PostgreSql.PgSqlCommand
    Private WithEvents masterDataAdapter As Devart.Data.PostgreSql.PgSqlDataAdapter
    Private WithEvents detailDataAdapter As Devart.Data.PostgreSql.PgSqlDataAdapter
    Private WithEvents masterCommandBuilder As Devart.Data.PostgreSql.PgSqlCommandBuilder
    Private WithEvents detailCommandBuilder As Devart.Data.PostgreSql.PgSqlCommandBuilder
    Private WithEvents dataSet As System.Data.DataSet
    Private WithEvents topPanel As System.Windows.Forms.Panel
    Private WithEvents btUpdate As System.Windows.Forms.Button
    Private WithEvents btClear As System.Windows.Forms.Button
    Private WithEvents btFill As System.Windows.Forms.Button
    Private WithEvents splitter As System.Windows.Forms.Splitter
    Private WithEvents detailGrid As System.Windows.Forms.DataGrid
    Private WithEvents masterGrid As System.Windows.Forms.DataGrid

    ' Methods
    Public Sub New()
      Me.components = Nothing
      Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal connection As PgSqlConnection)
      Me.New()
      Me.masterCommand.Connection = connection
      Me.detailCommand.Connection = connection
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

      Me.masterCommand = New Devart.Data.PostgreSql.PgSqlCommand()
      Me.detailCommand = New Devart.Data.PostgreSql.PgSqlCommand()
      Me.masterDataAdapter = New Devart.Data.PostgreSql.PgSqlDataAdapter()
      Me.detailDataAdapter = New Devart.Data.PostgreSql.PgSqlDataAdapter()
      Me.masterCommandBuilder = New Devart.Data.PostgreSql.PgSqlCommandBuilder()
      Me.detailCommandBuilder = New Devart.Data.PostgreSql.PgSqlCommandBuilder()
      Me.dataSet = New System.Data.DataSet()
      Me.topPanel = New System.Windows.Forms.Panel()
      Me.btUpdate = New System.Windows.Forms.Button()
      Me.btClear = New System.Windows.Forms.Button()
      Me.btFill = New System.Windows.Forms.Button()
      Me.splitter = New System.Windows.Forms.Splitter()
      Me.detailGrid = New System.Windows.Forms.DataGrid()
      Me.masterGrid = New System.Windows.Forms.DataGrid()
      CType(Me.dataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.topPanel.SuspendLayout()
      CType(Me.detailGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.masterGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'masterCommand
      '
      Me.masterCommand.CommandText = "SELECT * FROM Dept"
      Me.masterCommand.Name = "masterCommand"
      Me.masterCommand.Owner = Me
      '
      'detailCommand
      '
      Me.detailCommand.CommandText = "SELECT EMPNO,ENAME,JOB,MGR,HIREDATE,DEPTNO FROM Emp"
      Me.detailCommand.Name = "detailCommand"
      Me.detailCommand.Owner = Me
      '
      'masterDataAdapter
      '
      Me.masterDataAdapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey
      Me.masterDataAdapter.SelectCommand = Me.masterCommand
      '
      'detailDataAdapter
      '
      Me.detailDataAdapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey
      Me.detailDataAdapter.SelectCommand = Me.detailCommand
      '
      'masterCommandBuilder
      '
      Me.masterCommandBuilder.DataAdapter = Me.masterDataAdapter
      Me.masterCommandBuilder.Quoted = True
      Me.masterCommandBuilder.UpdatingFields = ""
      '
      'detailCommandBuilder
      '
      Me.detailCommandBuilder.DataAdapter = Me.detailDataAdapter
      Me.detailCommandBuilder.Quoted = True
      Me.detailCommandBuilder.ConflictOption = System.Data.ConflictOption.OverwriteChanges
      Me.detailCommandBuilder.UpdatingFields = ""
      '
      'dataSet
      '
      Me.dataSet.DataSetName = "NewDataSet"
      Me.dataSet.Locale = New System.Globalization.CultureInfo("en")
      '
      'topPanel
      '
      Me.topPanel.Controls.Add(Me.btUpdate)
      Me.topPanel.Controls.Add(Me.btClear)
      Me.topPanel.Controls.Add(Me.btFill)
      Me.topPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me.topPanel.Location = New System.Drawing.Point(0, 0)
      Me.topPanel.Name = "topPanel"
      Me.topPanel.Size = New System.Drawing.Size(400, 24)
      Me.topPanel.TabIndex = 10
      '
      'btUpdate
      '
      Me.btUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btUpdate.Location = New System.Drawing.Point(152, 0)
      Me.btUpdate.Name = "btUpdate"
      Me.btUpdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.btUpdate.Size = New System.Drawing.Size(75, 23)
      Me.btUpdate.TabIndex = 4
      Me.btUpdate.Text = "Update"
      '
      'btClear
      '
      Me.btClear.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btClear.Location = New System.Drawing.Point(76, 0)
      Me.btClear.Name = "btClear"
      Me.btClear.Size = New System.Drawing.Size(75, 23)
      Me.btClear.TabIndex = 3
      Me.btClear.Text = "Clear"
      '
      'btFill
      '
      Me.btFill.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btFill.Location = New System.Drawing.Point(0, 0)
      Me.btFill.Name = "btFill"
      Me.btFill.Size = New System.Drawing.Size(75, 23)
      Me.btFill.TabIndex = 2
      Me.btFill.Text = "Fill"
      '
      'splitter
      '
      Me.splitter.Cursor = System.Windows.Forms.Cursors.HSplit
      Me.splitter.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.splitter.Location = New System.Drawing.Point(0, 149)
      Me.splitter.MinExtra = 50
      Me.splitter.MinSize = 50
      Me.splitter.Name = "splitter"
      Me.splitter.Size = New System.Drawing.Size(400, 3)
      Me.splitter.TabIndex = 15
      Me.splitter.TabStop = False
      '
      'detailGrid
      '
      Me.detailGrid.AllowNavigation = False
      Me.detailGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.detailGrid.CaptionVisible = False
      Me.detailGrid.DataMember = ""
      Me.detailGrid.DataSource = Me.dataSet
      Me.detailGrid.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.detailGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.detailGrid.Location = New System.Drawing.Point(0, 152)
      Me.detailGrid.Name = "detailGrid"
      Me.detailGrid.Size = New System.Drawing.Size(400, 128)
      Me.detailGrid.TabIndex = 14
      '
      'masterGrid
      '
      Me.masterGrid.AllowNavigation = False
      Me.masterGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.masterGrid.CaptionVisible = False
      Me.masterGrid.DataMember = ""
      Me.masterGrid.DataSource = Me.dataSet
      Me.masterGrid.Dock = System.Windows.Forms.DockStyle.Fill
      Me.masterGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.masterGrid.Location = New System.Drawing.Point(0, 24)
      Me.masterGrid.Name = "masterGrid"
      Me.masterGrid.Size = New System.Drawing.Size(400, 125)
      Me.masterGrid.TabIndex = 16
      '
      'MasterDetailDemoControl
      '
      Me.Controls.Add(Me.masterGrid)
      Me.Controls.Add(Me.splitter)
      Me.Controls.Add(Me.detailGrid)
      Me.Controls.Add(Me.topPanel)
      Me.Name = "MasterDetailDemoControl"
      Me.Size = New System.Drawing.Size(400, 280)
      CType(Me.dataSet, System.ComponentModel.ISupportInitialize).EndInit()
      Me.topPanel.ResumeLayout(False)
      CType(Me.detailGrid, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.masterGrid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
    End Sub

    ' Methods
    Private Sub btFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFill.Click
      Me.dataSet.Relations.Clear()
      Me.masterDataAdapter.Fill(Me.dataSet, "Master")
      Me.detailDataAdapter.Fill(Me.dataSet, "Detail")
      Me.dataSet.Relations.Add("Relation", Me.dataSet.Tables.Item("Master").Columns.Item("DEPTNO"), Me.dataSet.Tables.Item("Detail").Columns.Item("DEPTNO"))
      Me.masterGrid.DataMember = "Master"
      Me.detailGrid.DataMember = "Master.Relation"
      MyBase.fieldWriteStatus1 = "Change department to see its employees"
      MyBase.OnWriteStatus()
    End Sub

    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
      Me.dataSet.Clear()
      MyBase.fieldWriteStatus1 = ""
      MyBase.OnWriteStatus()
    End Sub

    Private Sub btUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUpdate.Click
      Me.masterDataAdapter.Update(Me.dataSet, "Master")
      Me.detailDataAdapter.Update(Me.dataSet, "Detail")
    End Sub
  End Class
End Namespace