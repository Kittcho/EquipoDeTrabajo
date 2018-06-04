Imports Devart.Data.PostgreSql
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Samples
  Public Class RefCursorDemoControl
    Inherits BaseDemoControl

    ' Fields
    Private WithEvents pgSqlCommand As Devart.Data.PostgreSql.PgSqlCommand
    Private WithEvents pnTop As System.Windows.Forms.Panel
    Private WithEvents btClear As System.Windows.Forms.Button
    Private WithEvents btExecute As System.Windows.Forms.Button
    Private WithEvents tbResult As System.Windows.Forms.TextBox

    ' Methods
    Public Sub New()
      Me.components = Nothing
      Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal connection As PgSqlConnection)
      Me.components = Nothing
      Me.InitializeComponent()
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
      Me.pnTop = New System.Windows.Forms.Panel()
      Me.btClear = New System.Windows.Forms.Button()
      Me.btExecute = New System.Windows.Forms.Button()
      Me.tbResult = New System.Windows.Forms.TextBox()
      Me.pnTop.SuspendLayout()
      Me.SuspendLayout()
      '
      'pgSqlCommand
      '
      Me.pgSqlCommand.CommandText = "SELECT * FROM getdeptCursor('dept')"
      Me.pgSqlCommand.Name = "pgSqlCommand"
      Me.pgSqlCommand.Owner = Me
      '
      'pnTop
      '
      Me.pnTop.Controls.Add(Me.btClear)
      Me.pnTop.Controls.Add(Me.btExecute)
      Me.pnTop.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnTop.Location = New System.Drawing.Point(0, 0)
      Me.pnTop.Name = "pnTop"
      Me.pnTop.Size = New System.Drawing.Size(376, 24)
      Me.pnTop.TabIndex = 2
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
      'btExecute
      '
      Me.btExecute.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btExecute.Location = New System.Drawing.Point(0, 0)
      Me.btExecute.Name = "btExecute"
      Me.btExecute.Size = New System.Drawing.Size(75, 23)
      Me.btExecute.TabIndex = 0
      Me.btExecute.Text = "Execute"
      '
      'tbResult
      '
      Me.tbResult.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tbResult.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.tbResult.Location = New System.Drawing.Point(0, 24)
      Me.tbResult.Multiline = True
      Me.tbResult.Name = "tbResult"
      Me.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.tbResult.Size = New System.Drawing.Size(376, 214)
      Me.tbResult.TabIndex = 8
      Me.tbResult.WordWrap = False
      '
      'RefCursorDemoControl
      '
      Me.Controls.Add(Me.tbResult)
      Me.Controls.Add(Me.pnTop)
      Me.Name = "RefCursorDemoControl"
      Me.Size = New System.Drawing.Size(376, 238)
      Me.pnTop.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

    ' Methods
    Private Sub btExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExecute.Click
      Dim num As Integer = 0
      Dim command As New pgSqlCommand("fetch all in ""dept""", Me.pgSqlCommand.Connection)
      Dim transaction As PgSqlTransaction = Me.pgSqlCommand.Connection.BeginTransaction
      Try
        Me.pgSqlCommand.ExecuteScalar()
        Dim reader As PgSqlDataReader = command.ExecuteReader
        If (reader.FieldCount > 0) Then
          Dim num2 As Integer
          For num2 = 0 To reader.FieldCount - 1
            Me.tbResult.AppendText((reader.GetName(num2).PadRight(10).Substring(0, 10) & " "))
          Next num2
          Me.tbResult.AppendText(ChrW(13) & ChrW(10))
          For num2 = 0 To reader.FieldCount - 1
            Me.tbResult.AppendText((String.Empty.PadRight(10, "-"c).Substring(0, 10) & " "))
          Next num2
          Me.tbResult.AppendText(ChrW(13) & ChrW(10))
          Do While reader.Read
            For num2 = 0 To reader.FieldCount - 1
              Me.tbResult.AppendText((reader.GetValue(num2).ToString.PadRight(10).Substring(0, 10) & " "))
            Next num2
            Me.tbResult.AppendText(ChrW(13) & ChrW(10))
            num += 1
          Loop
          Me.tbResult.AppendText(ChrW(13) & ChrW(10))
          Me.tbResult.AppendText((num.ToString & " rows selected." & ChrW(13) & ChrW(10)))
        Else
          Me.tbResult.AppendText("Statement executed." & ChrW(13) & ChrW(10))
        End If
        Me.tbResult.AppendText(ChrW(13) & ChrW(10))
        reader.Close()
        transaction.Commit()
      Catch exception As PgSqlException
        transaction.Rollback()
        Me.tbResult.AppendText((exception.Message & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10)))
        Throw
      End Try
    End Sub

    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
      Me.tbResult.Clear()
    End Sub
  End Class
End Namespace