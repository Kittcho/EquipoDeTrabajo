Imports Devart.Data.PostgreSql
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Namespace Samples
  Public Class TransactionsDemoControl
    Inherits BaseDemoControl

    ' Fields
    Private transaction As PgSqlTransaction
    Private WithEvents selectCommand As Devart.Data.PostgreSql.PgSqlCommand
    Private WithEvents dataAdapter As Devart.Data.PostgreSql.PgSqlDataAdapter
    Private WithEvents commandBuilder As Devart.Data.PostgreSql.PgSqlCommandBuilder
    Private WithEvents dataSet As System.Data.DataSet
    Private WithEvents topPanel As System.Windows.Forms.Panel
    Private WithEvents btRollback As System.Windows.Forms.Button
    Private WithEvents btCommit As System.Windows.Forms.Button
    Private WithEvents btBegin As System.Windows.Forms.Button
    Private WithEvents btUpdate As System.Windows.Forms.Button
    Private WithEvents btClear As System.Windows.Forms.Button
    Private WithEvents btFill As System.Windows.Forms.Button
    Private WithEvents dataGrid As System.Windows.Forms.DataGrid

    ' Methods
    Public Sub New()
      Me.components = Nothing
      Me.transaction = Nothing
      Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal connection As PgSqlConnection)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.selectCommand = New Devart.Data.PostgreSql.PgSqlCommand()
      Me.dataAdapter = New Devart.Data.PostgreSql.PgSqlDataAdapter()
      Me.commandBuilder = New Devart.Data.PostgreSql.PgSqlCommandBuilder()
      Me.dataSet = New System.Data.DataSet()
      Me.topPanel = New System.Windows.Forms.Panel()
      Me.btRollback = New System.Windows.Forms.Button()
      Me.btCommit = New System.Windows.Forms.Button()
      Me.btBegin = New System.Windows.Forms.Button()
      Me.btUpdate = New System.Windows.Forms.Button()
      Me.btClear = New System.Windows.Forms.Button()
      Me.btFill = New System.Windows.Forms.Button()
      Me.dataGrid = New System.Windows.Forms.DataGrid()
      CType(Me.dataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.topPanel.SuspendLayout()
      CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'selectCommand
      '
      Me.selectCommand.CommandText = "Select * from dept"
      Me.selectCommand.Name = "selectCommand"
      Me.selectCommand.Owner = Me
      '
      'dataAdapter
      '
      Me.dataAdapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey
      Me.dataAdapter.SelectCommand = Me.selectCommand
      '
      'commandBuilder
      '
      Me.commandBuilder.DataAdapter = Me.dataAdapter
      Me.commandBuilder.Quoted = True
      Me.commandBuilder.UpdatingFields = ""
      '
      'dataSet
      '
      Me.dataSet.DataSetName = "NewDataSet"
      Me.dataSet.Locale = New System.Globalization.CultureInfo("en-US")
      '
      'topPanel
      '
      Me.topPanel.Controls.Add(Me.btRollback)
      Me.topPanel.Controls.Add(Me.btCommit)
      Me.topPanel.Controls.Add(Me.btBegin)
      Me.topPanel.Controls.Add(Me.btUpdate)
      Me.topPanel.Controls.Add(Me.btClear)
      Me.topPanel.Controls.Add(Me.btFill)
      Me.topPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me.topPanel.Location = New System.Drawing.Point(0, 0)
      Me.topPanel.Name = "topPanel"
      Me.topPanel.Size = New System.Drawing.Size(477, 24)
      Me.topPanel.TabIndex = 3
      '
      'btRollback
      '
      Me.btRollback.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btRollback.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.btRollback.ForeColor = System.Drawing.Color.Navy
      Me.btRollback.Location = New System.Drawing.Point(392, 0)
      Me.btRollback.Name = "btRollback"
      Me.btRollback.Size = New System.Drawing.Size(75, 23)
      Me.btRollback.TabIndex = 7
      Me.btRollback.Text = "Rollback"
      '
      'btCommit
      '
      Me.btCommit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btCommit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.btCommit.ForeColor = System.Drawing.Color.Navy
      Me.btCommit.Location = New System.Drawing.Point(316, 0)
      Me.btCommit.Name = "btCommit"
      Me.btCommit.Size = New System.Drawing.Size(75, 23)
      Me.btCommit.TabIndex = 6
      Me.btCommit.Text = "Commit"
      '
      'btBegin
      '
      Me.btBegin.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btBegin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.btBegin.ForeColor = System.Drawing.Color.Navy
      Me.btBegin.Location = New System.Drawing.Point(240, 0)
      Me.btBegin.Name = "btBegin"
      Me.btBegin.Size = New System.Drawing.Size(75, 23)
      Me.btBegin.TabIndex = 5
      Me.btBegin.Text = "Begin"
      '
      'btUpdate
      '
      Me.btUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btUpdate.Location = New System.Drawing.Point(76, 0)
      Me.btUpdate.Name = "btUpdate"
      Me.btUpdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.btUpdate.Size = New System.Drawing.Size(75, 23)
      Me.btUpdate.TabIndex = 4
      Me.btUpdate.Text = "Update"
      '
      'btClear
      '
      Me.btClear.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btClear.Location = New System.Drawing.Point(152, 0)
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
      'dataGrid
      '
      Me.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dataGrid.CaptionVisible = False
      Me.dataGrid.DataMember = ""
      Me.dataGrid.DataSource = Me.dataSet
      Me.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.dataGrid.Location = New System.Drawing.Point(0, 24)
      Me.dataGrid.Name = "dataGrid"
      Me.dataGrid.Size = New System.Drawing.Size(477, 310)
      Me.dataGrid.TabIndex = 4
      '
      'TransactionsDemoControl
      '
      Me.Controls.Add(Me.dataGrid)
      Me.Controls.Add(Me.topPanel)
      Me.Name = "TransactionsDemoControl"
      Me.Size = New System.Drawing.Size(477, 334)
      CType(Me.dataSet, System.ComponentModel.ISupportInitialize).EndInit()
      Me.topPanel.ResumeLayout(False)
      CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
    End Sub

    ' Methods
    Private Sub btFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFill.Click
      Me.dataAdapter.Fill(Me.dataSet, "Table")
      Me.dataGrid.DataMember = "Table"
    End Sub

    Private Sub btUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUpdate.Click
      If Me.dataSet.Tables.Count > 0 Then
        Me.dataAdapter.Update(Me.dataSet, "Table")
      End If
    End Sub

    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
      Me.dataGrid.DataSource = Nothing
      Me.dataSet = New dataSet()
      Me.dataGrid.DataSource = Me.dataSet
    End Sub

    Private Sub btBegin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBegin.Click
      Me.transaction = Me.selectCommand.Connection.BeginTransaction
      MyBase.fieldWriteStatus1 = "Transaction started"
      MyBase.fieldWriteStatus2 = "In transaction"
      MyBase.OnWriteStatus()
    End Sub

    Private Sub btCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCommit.Click
      If (Not Me.transaction Is Nothing) Then
        Me.transaction.Commit()
        Me.transaction = Nothing
        MyBase.fieldWriteStatus1 = "Commit complete"
        MyBase.fieldWriteStatus2 = ""
        MyBase.OnWriteStatus()
      End If
    End Sub

    Private Sub btRollback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRollback.Click
      If (Not Me.transaction Is Nothing) Then
        Me.transaction.Rollback()
        Me.transaction = Nothing
        MyBase.fieldWriteStatus1 = "Rollback complete"
        MyBase.fieldWriteStatus2 = ""
        MyBase.OnWriteStatus()
      End If
    End Sub
  End Class
End Namespace