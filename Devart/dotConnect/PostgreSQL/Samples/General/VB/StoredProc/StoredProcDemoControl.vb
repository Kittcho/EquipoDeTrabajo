Imports Devart.Data.PostgreSql
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Namespace Samples
  Public Class StoredProcDemoControl
    Inherits BaseDemoControl

    ' Fields
    Private WithEvents topPanel As System.Windows.Forms.Panel
    Private WithEvents lbParams As System.Windows.Forms.Label
    Private WithEvents tbLoc As System.Windows.Forms.TextBox
    Private WithEvents tbDname As System.Windows.Forms.TextBox
    Private WithEvents tbDeptno As System.Windows.Forms.TextBox
    Private WithEvents lbParam3 As System.Windows.Forms.Label
    Private WithEvents lbParam2 As System.Windows.Forms.Label
    Private WithEvents lbParam1 As System.Windows.Forms.Label
    Private WithEvents btClear As System.Windows.Forms.Button
    Private WithEvents btFill As System.Windows.Forms.Button
    Private WithEvents btExecute As System.Windows.Forms.Button
    Private WithEvents edStoredProcName As System.Windows.Forms.ComboBox
    Private WithEvents lbStoredProc As System.Windows.Forms.Label
    Private WithEvents procedureCommand As Devart.Data.PostgreSql.PgSqlCommand
    Private WithEvents selectCommand As Devart.Data.PostgreSql.PgSqlCommand
    Private WithEvents dataAdapter As Devart.Data.PostgreSql.PgSqlDataAdapter
    Private WithEvents dataGrid As System.Windows.Forms.DataGrid

    ' Methods
    Public Sub New()
      Me.components = Nothing
      Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal connection As PgSqlConnection)
      Me.New()
      Dim locConnection As PgSqlConnection = connection
      Me.procedureCommand.Connection = locConnection
      Me.selectCommand.Connection = locConnection
      Me.edStoredProcName.Text = Me.procedureCommand.CommandText
      Me.tbDeptno.Text = Me.procedureCommand.Parameters.Item("@pdeptno").Value.ToString
      Me.tbDname.Text = Me.procedureCommand.Parameters.Item("@pdname").Value.ToString
      Me.tbLoc.Text = Me.procedureCommand.Parameters.Item("@ploc").Value.ToString
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
      Me.topPanel = New System.Windows.Forms.Panel()
      Me.lbParams = New System.Windows.Forms.Label()
      Me.tbLoc = New System.Windows.Forms.TextBox()
      Me.tbDname = New System.Windows.Forms.TextBox()
      Me.tbDeptno = New System.Windows.Forms.TextBox()
      Me.lbParam3 = New System.Windows.Forms.Label()
      Me.lbParam2 = New System.Windows.Forms.Label()
      Me.lbParam1 = New System.Windows.Forms.Label()
      Me.btClear = New System.Windows.Forms.Button()
      Me.btFill = New System.Windows.Forms.Button()
      Me.btExecute = New System.Windows.Forms.Button()
      Me.edStoredProcName = New System.Windows.Forms.ComboBox()
      Me.lbStoredProc = New System.Windows.Forms.Label()
      Me.dataGrid = New System.Windows.Forms.DataGrid()
      Me.procedureCommand = New Devart.Data.PostgreSql.PgSqlCommand()
      Me.selectCommand = New Devart.Data.PostgreSql.PgSqlCommand()
      Me.dataAdapter = New Devart.Data.PostgreSql.PgSqlDataAdapter()
      Me.topPanel.SuspendLayout()
      CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'topPanel
      '
      Me.topPanel.Controls.Add(Me.lbParams)
      Me.topPanel.Controls.Add(Me.tbLoc)
      Me.topPanel.Controls.Add(Me.tbDname)
      Me.topPanel.Controls.Add(Me.tbDeptno)
      Me.topPanel.Controls.Add(Me.lbParam3)
      Me.topPanel.Controls.Add(Me.lbParam2)
      Me.topPanel.Controls.Add(Me.lbParam1)
      Me.topPanel.Controls.Add(Me.btClear)
      Me.topPanel.Controls.Add(Me.btFill)
      Me.topPanel.Controls.Add(Me.btExecute)
      Me.topPanel.Controls.Add(Me.edStoredProcName)
      Me.topPanel.Controls.Add(Me.lbStoredProc)
      Me.topPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me.topPanel.Location = New System.Drawing.Point(0, 0)
      Me.topPanel.Name = "topPanel"
      Me.topPanel.Size = New System.Drawing.Size(477, 88)
      Me.topPanel.TabIndex = 9
      '
      'lbParams
      '
      Me.lbParams.AutoSize = True
      Me.lbParams.Location = New System.Drawing.Point(8, 32)
      Me.lbParams.Name = "lbParams"
      Me.lbParams.Size = New System.Drawing.Size(147, 13)
      Me.lbParams.TabIndex = 18
      Me.lbParams.Text = "Stored procedure parameters:"
      '
      'tbLoc
      '
      Me.tbLoc.Location = New System.Drawing.Point(338, 52)
      Me.tbLoc.Name = "tbLoc"
      Me.tbLoc.Size = New System.Drawing.Size(127, 20)
      Me.tbLoc.TabIndex = 17
      '
      'tbDname
      '
      Me.tbDname.Location = New System.Drawing.Point(171, 52)
      Me.tbDname.Name = "tbDname"
      Me.tbDname.Size = New System.Drawing.Size(119, 20)
      Me.tbDname.TabIndex = 16
      '
      'tbDeptno
      '
      Me.tbDeptno.Location = New System.Drawing.Point(47, 52)
      Me.tbDeptno.Name = "tbDeptno"
      Me.tbDeptno.Size = New System.Drawing.Size(65, 20)
      Me.tbDeptno.TabIndex = 15
      '
      'lbParam3
      '
      Me.lbParam3.AutoSize = True
      Me.lbParam3.Location = New System.Drawing.Point(311, 56)
      Me.lbParam3.Name = "lbParam3"
      Me.lbParam3.Size = New System.Drawing.Size(25, 13)
      Me.lbParam3.TabIndex = 14
      Me.lbParam3.Text = "Loc"
      '
      'lbParam2
      '
      Me.lbParam2.AutoSize = True
      Me.lbParam2.Location = New System.Drawing.Point(128, 55)
      Me.lbParam2.Name = "lbParam2"
      Me.lbParam2.Size = New System.Drawing.Size(41, 13)
      Me.lbParam2.TabIndex = 13
      Me.lbParam2.Text = "Dname"
      '
      'lbParam1
      '
      Me.lbParam1.AutoSize = True
      Me.lbParam1.Location = New System.Drawing.Point(3, 54)
      Me.lbParam1.Name = "lbParam1"
      Me.lbParam1.Size = New System.Drawing.Size(42, 13)
      Me.lbParam1.TabIndex = 12
      Me.lbParam1.Text = "Deptno"
      '
      'btClear
      '
      Me.btClear.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btClear.Location = New System.Drawing.Point(152, 0)
      Me.btClear.Name = "btClear"
      Me.btClear.Size = New System.Drawing.Size(75, 23)
      Me.btClear.TabIndex = 11
      Me.btClear.Text = "Clear"
      '
      'btFill
      '
      Me.btFill.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btFill.Location = New System.Drawing.Point(76, 0)
      Me.btFill.Name = "btFill"
      Me.btFill.Size = New System.Drawing.Size(75, 23)
      Me.btFill.TabIndex = 10
      Me.btFill.Text = "Fill"
      '
      'btExecute
      '
      Me.btExecute.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btExecute.Location = New System.Drawing.Point(0, 0)
      Me.btExecute.Name = "btExecute"
      Me.btExecute.Size = New System.Drawing.Size(75, 23)
      Me.btExecute.TabIndex = 9
      Me.btExecute.Text = "Execute"
      '
      'edStoredProcName
      '
      Me.edStoredProcName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.edStoredProcName.Items.AddRange(New Object() {"Dept_Insert", "Dept_Update"})
      Me.edStoredProcName.Location = New System.Drawing.Point(328, 6)
      Me.edStoredProcName.Name = "edStoredProcName"
      Me.edStoredProcName.Size = New System.Drawing.Size(144, 21)
      Me.edStoredProcName.TabIndex = 8
      '
      'lbStoredProc
      '
      Me.lbStoredProc.AutoSize = True
      Me.lbStoredProc.Location = New System.Drawing.Point(232, 8)
      Me.lbStoredProc.Name = "lbStoredProc"
      Me.lbStoredProc.Size = New System.Drawing.Size(89, 13)
      Me.lbStoredProc.TabIndex = 7
      Me.lbStoredProc.Text = "Stored procedure"
      '
      'dataGrid
      '
      Me.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dataGrid.CaptionVisible = False
      Me.dataGrid.DataMember = ""
      Me.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.dataGrid.Location = New System.Drawing.Point(0, 88)
      Me.dataGrid.Name = "dataGrid"
      Me.dataGrid.Size = New System.Drawing.Size(477, 246)
      Me.dataGrid.TabIndex = 11
      '
      'procedureCommand
      '
      Me.procedureCommand.CommandText = "Dept_Insert"
      Me.procedureCommand.CommandType = System.Data.CommandType.StoredProcedure
      Me.procedureCommand.Name = "procedureCommand"
      Me.procedureCommand.Parameters.Add(New Devart.Data.PostgreSql.PgSqlParameter("@pdeptno", Devart.Data.PostgreSql.PgSqlType.Int, 3, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, "50"))
      Me.procedureCommand.Parameters.Add(New Devart.Data.PostgreSql.PgSqlParameter("@pdname", Devart.Data.PostgreSql.PgSqlType.VarChar, 10, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, "RESEARCH"))
      Me.procedureCommand.Parameters.Add(New Devart.Data.PostgreSql.PgSqlParameter("@ploc", Devart.Data.PostgreSql.PgSqlType.VarChar, 10, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, "NEW YORK"))
      '
      'selectCommand
      '
      Me.selectCommand.CommandText = "SELECT * FROM DEPT"
      Me.selectCommand.Name = "selectCommand"
      '
      'dataAdapter
      '
      Me.dataAdapter.SelectCommand = Me.selectCommand
      '
      'StoredProcDemoControl
      '
      Me.Controls.Add(Me.dataGrid)
      Me.Controls.Add(Me.topPanel)
      Me.Name = "StoredProcDemoControl"
      Me.Size = New System.Drawing.Size(477, 334)
      Me.topPanel.ResumeLayout(False)
      Me.topPanel.PerformLayout()
      CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

    ' Methods
    Private Sub btExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExecute.Click
      Me.procedureCommand.CommandText = Me.edStoredProcName.Text
      Me.procedureCommand.Parameters.Item("@pdeptno").Value = Convert.ToInt32(Me.tbDeptno.Text)
      Me.procedureCommand.Parameters.Item("@pdname").Value = Me.tbDname.Text
      Me.procedureCommand.Parameters.Item("@ploc").Value = Me.tbLoc.Text
      Me.procedureCommand.ExecuteNonQuery()
      MyBase.fieldWriteStatus1 = "Procedure executed successfully"
      MyBase.OnWriteStatus()
    End Sub

    Private Sub btFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFill.Click
      Dim ds As New DataSet()
      Me.dataAdapter.Fill(ds)
      Me.dataGrid.DataSource = ds.Tables.Item(0)
    End Sub

    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
      Me.dataGrid.DataSource = Nothing
      MyBase.fieldWriteStatus1 = ""
      MyBase.OnWriteStatus()
    End Sub
  End Class
End Namespace