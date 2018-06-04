Imports Devart.Data.PostgreSql
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Namespace Samples
  Public Class MetaDataDemoControl
    Inherits BaseDemoControl

    ' Fields
    Private dtRestrict As DataTable
    Private WithEvents connection As Devart.Data.PostgreSql.PgSqlConnection
    Private WithEvents topPanel As System.Windows.Forms.Panel
    Private WithEvents btRefresh As System.Windows.Forms.Button
    Private WithEvents splitter As System.Windows.Forms.Splitter
    Private WithEvents panelForGrids As System.Windows.Forms.Panel
    Private WithEvents tvSchemaView As System.Windows.Forms.TreeView
    Private WithEvents spltHorizontal As System.Windows.Forms.Splitter
    Private WithEvents pnRestrict As System.Windows.Forms.Panel
    Private WithEvents propertyGrid As System.Windows.Forms.PropertyGrid
    Private WithEvents lbRest As System.Windows.Forms.Label
    Private WithEvents lbColl As System.Windows.Forms.Label
    Private WithEvents dgShowMeta As System.Windows.Forms.DataGrid

    ' Methods
    Public Sub New()
      Me.components = Nothing
      Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal connection As PgSqlConnection)
      Me.New()
      Me.connection = connection
      If (connection.State = ConnectionState.Open) Then
        Me.BuildTree()
      End If
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
      Me.connection = New Devart.Data.PostgreSql.PgSqlConnection()
      Me.topPanel = New System.Windows.Forms.Panel()
      Me.btRefresh = New System.Windows.Forms.Button()
      Me.splitter = New System.Windows.Forms.Splitter()
      Me.panelForGrids = New System.Windows.Forms.Panel()
      Me.tvSchemaView = New System.Windows.Forms.TreeView()
      Me.spltHorizontal = New System.Windows.Forms.Splitter()
      Me.pnRestrict = New System.Windows.Forms.Panel()
      Me.propertyGrid = New System.Windows.Forms.PropertyGrid()
      Me.lbRest = New System.Windows.Forms.Label()
      Me.lbColl = New System.Windows.Forms.Label()
      Me.dgShowMeta = New System.Windows.Forms.DataGrid()
      Me.topPanel.SuspendLayout()
      Me.panelForGrids.SuspendLayout()
      Me.pnRestrict.SuspendLayout()
      CType(Me.dgShowMeta, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'connection
      '
      Me.connection.Name = "connection"
      Me.connection.Owner = Me
      '
      'topPanel
      '
      Me.topPanel.Controls.Add(Me.btRefresh)
      Me.topPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me.topPanel.Location = New System.Drawing.Point(0, 0)
      Me.topPanel.Name = "topPanel"
      Me.topPanel.Size = New System.Drawing.Size(400, 24)
      Me.topPanel.TabIndex = 11
      '
      'btRefresh
      '
      Me.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btRefresh.Location = New System.Drawing.Point(0, 0)
      Me.btRefresh.Name = "btRefresh"
      Me.btRefresh.Size = New System.Drawing.Size(75, 23)
      Me.btRefresh.TabIndex = 2
      Me.btRefresh.Text = "Refresh"
      '
      'splitter
      '
      Me.splitter.Location = New System.Drawing.Point(160, 24)
      Me.splitter.MinExtra = 100
      Me.splitter.MinSize = 100
      Me.splitter.Name = "splitter"
      Me.splitter.Size = New System.Drawing.Size(3, 276)
      Me.splitter.TabIndex = 13
      Me.splitter.TabStop = False
      '
      'panelForGrids
      '
      Me.panelForGrids.Controls.Add(Me.tvSchemaView)
      Me.panelForGrids.Controls.Add(Me.spltHorizontal)
      Me.panelForGrids.Controls.Add(Me.pnRestrict)
      Me.panelForGrids.Controls.Add(Me.lbColl)
      Me.panelForGrids.Dock = System.Windows.Forms.DockStyle.Left
      Me.panelForGrids.Location = New System.Drawing.Point(0, 24)
      Me.panelForGrids.Name = "panelForGrids"
      Me.panelForGrids.Size = New System.Drawing.Size(160, 276)
      Me.panelForGrids.TabIndex = 12
      '
      'tvSchemaView
      '
      Me.tvSchemaView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tvSchemaView.HideSelection = False
      Me.tvSchemaView.Location = New System.Drawing.Point(0, 15)
      Me.tvSchemaView.Name = "tvSchemaView"
      Me.tvSchemaView.Size = New System.Drawing.Size(160, 170)
      Me.tvSchemaView.TabIndex = 7
      '
      'spltHorizontal
      '
      Me.spltHorizontal.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.spltHorizontal.Location = New System.Drawing.Point(0, 185)
      Me.spltHorizontal.MinExtra = 60
      Me.spltHorizontal.MinSize = 50
      Me.spltHorizontal.Name = "spltHorizontal"
      Me.spltHorizontal.Size = New System.Drawing.Size(160, 3)
      Me.spltHorizontal.TabIndex = 5
      Me.spltHorizontal.TabStop = False
      Me.spltHorizontal.Visible = False
      '
      'pnRestrict
      '
      Me.pnRestrict.Controls.Add(Me.propertyGrid)
      Me.pnRestrict.Controls.Add(Me.lbRest)
      Me.pnRestrict.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.pnRestrict.Location = New System.Drawing.Point(0, 188)
      Me.pnRestrict.Name = "pnRestrict"
      Me.pnRestrict.Size = New System.Drawing.Size(160, 88)
      Me.pnRestrict.TabIndex = 6
      Me.pnRestrict.Visible = False
      '
      'propertyGrid
      '
      Me.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
      Me.propertyGrid.HelpVisible = False
      Me.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar
      Me.propertyGrid.Location = New System.Drawing.Point(0, 15)
      Me.propertyGrid.Name = "propertyGrid"
      Me.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort
      Me.propertyGrid.Size = New System.Drawing.Size(160, 73)
      Me.propertyGrid.TabIndex = 7
      Me.propertyGrid.ToolbarVisible = False
      '
      'lbRest
      '
      Me.lbRest.BackColor = System.Drawing.SystemColors.ActiveCaption
      Me.lbRest.Dock = System.Windows.Forms.DockStyle.Top
      Me.lbRest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.lbRest.Location = New System.Drawing.Point(0, 0)
      Me.lbRest.Name = "lbRest"
      Me.lbRest.Size = New System.Drawing.Size(160, 15)
      Me.lbRest.TabIndex = 4
      Me.lbRest.Text = "Restrictions"
      '
      'lbColl
      '
      Me.lbColl.BackColor = System.Drawing.SystemColors.ActiveCaption
      Me.lbColl.Dock = System.Windows.Forms.DockStyle.Top
      Me.lbColl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.lbColl.Location = New System.Drawing.Point(0, 0)
      Me.lbColl.Name = "lbColl"
      Me.lbColl.Size = New System.Drawing.Size(160, 15)
      Me.lbColl.TabIndex = 3
      Me.lbColl.Text = "Collections"
      '
      'dgShowMeta
      '
      Me.dgShowMeta.AllowNavigation = False
      Me.dgShowMeta.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dgShowMeta.CaptionVisible = False
      Me.dgShowMeta.DataMember = ""
      Me.dgShowMeta.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dgShowMeta.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.dgShowMeta.Location = New System.Drawing.Point(163, 24)
      Me.dgShowMeta.Name = "dgShowMeta"
      Me.dgShowMeta.ReadOnly = True
      Me.dgShowMeta.Size = New System.Drawing.Size(237, 276)
      Me.dgShowMeta.TabIndex = 14
      '
      'MetaDataDemoControl
      '
      Me.Controls.Add(Me.dgShowMeta)
      Me.Controls.Add(Me.splitter)
      Me.Controls.Add(Me.panelForGrids)
      Me.Controls.Add(Me.topPanel)
      Me.Name = "MetaDataDemoControl"
      Me.Size = New System.Drawing.Size(400, 300)
      Me.topPanel.ResumeLayout(False)
      Me.panelForGrids.ResumeLayout(False)
      Me.pnRestrict.ResumeLayout(False)
      CType(Me.dgShowMeta, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

    ' Methods
    Private Sub btRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefresh.Click
      If (Me.tvSchemaView.Nodes.Count = 0) Then
        Me.BuildTree()
      ElseIf Me.pnRestrict.Visible Then
        Dim table As DataTable = DirectCast(Me.propertyGrid.SelectedObject, DataRowView).DataView.Table
        Dim count As Integer = table.Columns.Count
        Dim restrictionValues As String() = New String(count - 1) {}
        Dim i As Integer
        For i = 0 To count - 1
          If (table.Rows.Item(0).Item(i).ToString <> "") Then
            restrictionValues(i) = table.Rows.Item(0).Item(i).ToString
          End If
        Next i
        Me.dgShowMeta.DataSource = Me.connection.GetSchema(table.TableName, restrictionValues)
      End If
    End Sub

    Private Sub tvSchemaView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvSchemaView.AfterSelect
      Try
        Me.dgShowMeta.DataSource = Me.connection.GetSchema(e.Node.Text)
      Catch
        Me.dgShowMeta.DataSource = Nothing
      End Try
      Dim table As New DataTable(e.Node.Text)
      Dim row As DataRow
      For Each row In Me.dtRestrict.Rows
        If (row.Item("CollectionName").ToString = e.Node.Text) Then
          table.Columns.Add(row.Item("RestrictionName").ToString)
        End If
      Next
      If (table.Columns.Count = 0) Then
        Me.pnRestrict.Visible = False
        Me.spltHorizontal.Visible = False
        MyBase.fieldWriteStatus2 = ""
        MyBase.OnWriteStatus()
      Else
        table.Rows.Add(table.NewRow)
        Me.spltHorizontal.Visible = True
        Me.pnRestrict.Visible = True
        Me.propertyGrid.SelectedObject = table.DefaultView.Item(0)
        MyBase.fieldWriteStatus2 = ("Enter restrictions for " & e.Node.Text)
        MyBase.OnWriteStatus()
      End If
    End Sub

    Private Sub BuildTree()
      Dim schema As DataTable = Me.connection.GetSchema
      Me.tvSchemaView.Nodes.Add(New TreeNode("MetaDataCollections"))
      Dim enumerator As IEnumerator = schema.Rows.GetEnumerator
      Do While enumerator.MoveNext
        Me.tvSchemaView.Nodes.Item(0).Nodes.Add(New TreeNode(DirectCast(enumerator.Current, DataRow).Item("CollectionName").ToString))
      Loop
      Me.tvSchemaView.Nodes.Item(0).Expand()
      Me.dtRestrict = Me.connection.GetSchema("Restrictions")
      Me.dgShowMeta.DataSource = Nothing
      MyBase.fieldWriteStatus1 = "Select database object"
      MyBase.OnWriteStatus()
    End Sub
  End Class
End Namespace