Imports Devart.Data.PostgreSql
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Samples
  Public Class DataReaderDemoControl
    Inherits BaseDemoControl

    ' Fields
    Private WithEvents btClear As Button
    Private WithEvents btExecute As Button
    Private components As Container
    Private WithEvents pnTop As Panel
    Private WithEvents splitter As Splitter
    Private WithEvents tbResult As TextBox
    Private WithEvents command As Devart.Data.PostgreSql.PgSqlCommand
    Private WithEvents tbSql As TextBox

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

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          components.Dispose()
        End If
      End If
      MyBase.Dispose(disposing)
    End Sub

    Private Sub InitializeComponent()
      Me.pnTop = New System.Windows.Forms.Panel()
      Me.btClear = New System.Windows.Forms.Button()
      Me.btExecute = New System.Windows.Forms.Button()
      Me.tbSql = New System.Windows.Forms.TextBox()
      Me.splitter = New System.Windows.Forms.Splitter()
      Me.tbResult = New System.Windows.Forms.TextBox()
      Me.command = New Devart.Data.PostgreSql.PgSqlCommand()
      Me.pnTop.SuspendLayout()
      Me.SuspendLayout()
      '
      'pnTop
      '
      Me.pnTop.Controls.Add(Me.btClear)
      Me.pnTop.Controls.Add(Me.btExecute)
      Me.pnTop.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnTop.Location = New System.Drawing.Point(0, 0)
      Me.pnTop.Name = "pnTop"
      Me.pnTop.Size = New System.Drawing.Size(376, 24)
      Me.pnTop.TabIndex = 0
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
      'tbSql
      '
      Me.tbSql.Dock = System.Windows.Forms.DockStyle.Top
      Me.tbSql.Location = New System.Drawing.Point(0, 24)
      Me.tbSql.Multiline = True
      Me.tbSql.Name = "tbSql"
      Me.tbSql.Size = New System.Drawing.Size(376, 64)
      Me.tbSql.TabIndex = 1
      '
      'splitter
      '
      Me.splitter.Dock = System.Windows.Forms.DockStyle.Top
      Me.splitter.Location = New System.Drawing.Point(0, 88)
      Me.splitter.MinExtra = 50
      Me.splitter.Name = "splitter"
      Me.splitter.Size = New System.Drawing.Size(376, 3)
      Me.splitter.TabIndex = 2
      Me.splitter.TabStop = False
      '
      'tbResult
      '
      Me.tbResult.BackColor = System.Drawing.SystemColors.Window
      Me.tbResult.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tbResult.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.tbResult.Location = New System.Drawing.Point(0, 91)
      Me.tbResult.Multiline = True
      Me.tbResult.Name = "tbResult"
      Me.tbResult.ReadOnly = True
      Me.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.tbResult.Size = New System.Drawing.Size(376, 147)
      Me.tbResult.TabIndex = 3
      Me.tbResult.WordWrap = False
      '
      'command
      '
      Me.command.CommandText = "SELECT * FROM Dept"
      Me.command.Name = "command"
      '
      'DataReaderDemoControl
      '
      Me.Controls.Add(Me.tbResult)
      Me.Controls.Add(Me.splitter)
      Me.Controls.Add(Me.tbSql)
      Me.Controls.Add(Me.pnTop)
      Me.Name = "DataReaderDemoControl"
      Me.Size = New System.Drawing.Size(376, 238)
      Me.pnTop.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

    ' Methods
    Private Sub btClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btClear.Click
      Me.tbResult.Clear()
      MyBase.fieldWriteStatus1 = "Result is cleared"
      MyBase.OnWriteStatus()
    End Sub

    Private Sub btExecute_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btExecute.Click
      Dim recCount As Integer = 0
      Dim dataReader As PgSqlDataReader = Nothing
      Try
        Try
          dataReader = Me.command.ExecuteReader
          If (dataReader.FieldCount > 0) Then
            Dim i As Integer
            For i = 0 To dataReader.FieldCount - 1

              Me.tbResult.AppendText((dataReader.GetName(i).PadRight(11).Substring(0, 11) & ChrW(9)))
            Next i
            Me.tbResult.AppendText(ChrW(13) & ChrW(10))
            For i = 0 To dataReader.FieldCount - 1

              Me.tbResult.AppendText((String.Empty.PadRight(11, "-"c).Substring(0, 11) & ChrW(9)))
            Next i
            Me.tbResult.AppendText(ChrW(13) & ChrW(10))
            Do While dataReader.Read

              For i = 0 To dataReader.FieldCount - 1
                If dataReader.IsDBNull(i) Then
                  Me.tbResult.AppendText(("(null)".PadRight(11).Substring(0, 11) & ChrW(9)))
                Else
                  Me.tbResult.AppendText((dataReader.GetValue(i).ToString.PadRight(11).Substring(0, 11) & ChrW(9)))
                End If
              Next i
              Me.tbResult.AppendText(ChrW(13) & ChrW(10))
              recCount += 1
            Loop
            MyBase.fieldWriteStatus1 = (recCount.ToString & " rows selected")
          Else
            MyBase.fieldWriteStatus1 = "Statement executed"
          End If
          Me.tbResult.AppendText(ChrW(13) & ChrW(10))
          MyBase.OnWriteStatus()
        Catch exception As PgSqlException
          Me.tbResult.AppendText((exception.Message & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10)))
          Throw
        End Try
      Finally
        If (Not dataReader Is Nothing) Then
          dataReader.Close()
        End If
      End Try
    End Sub

    Private Sub tbSql_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles tbSql.Leave
      Me.command.CommandText = Me.tbSql.Text
    End Sub

  End Class
End Namespace