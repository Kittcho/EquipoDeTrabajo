Imports Devart.Data.PostgreSql
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Samples
  Public Class RowDataReaderDemoControl
    Inherits BaseDemoControl

    ' Fields
    Private WithEvents tbResult As System.Windows.Forms.TextBox
    Private WithEvents splitter As System.Windows.Forms.Splitter
    Private WithEvents tbSql As System.Windows.Forms.TextBox
    Private WithEvents btExecute As System.Windows.Forms.Button
    Private WithEvents command As Devart.Data.PostgreSql.PgSqlCommand
    Private WithEvents pnTop As System.Windows.Forms.Panel
    Private WithEvents btClear As System.Windows.Forms.Button

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
      Me.tbResult = New System.Windows.Forms.TextBox()
      Me.splitter = New System.Windows.Forms.Splitter()
      Me.tbSql = New System.Windows.Forms.TextBox()
      Me.btExecute = New System.Windows.Forms.Button()
      Me.command = New Devart.Data.PostgreSql.PgSqlCommand()
      Me.pnTop = New System.Windows.Forms.Panel()
      Me.btClear = New System.Windows.Forms.Button()
      Me.pnTop.SuspendLayout()
      Me.SuspendLayout()
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
      Me.tbResult.TabIndex = 9
      Me.tbResult.WordWrap = False
      '
      'splitter
      '
      Me.splitter.Dock = System.Windows.Forms.DockStyle.Top
      Me.splitter.Location = New System.Drawing.Point(0, 88)
      Me.splitter.MinExtra = 50
      Me.splitter.Name = "splitter"
      Me.splitter.Size = New System.Drawing.Size(376, 3)
      Me.splitter.TabIndex = 8
      Me.splitter.TabStop = False
      '
      'tbSql
      '
      Me.tbSql.Dock = System.Windows.Forms.DockStyle.Top
      Me.tbSql.Location = New System.Drawing.Point(0, 24)
      Me.tbSql.Multiline = True
      Me.tbSql.Name = "tbSql"
      Me.tbSql.Size = New System.Drawing.Size(376, 64)
      Me.tbSql.TabIndex = 7
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
      'command
      '
      Me.command.CommandText = "SELECT * FROM dept_container"
      Me.command.Name = "command"
      Me.command.Owner = Me
      '
      'pnTop
      '
      Me.pnTop.Controls.Add(Me.btClear)
      Me.pnTop.Controls.Add(Me.btExecute)
      Me.pnTop.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnTop.Location = New System.Drawing.Point(0, 0)
      Me.pnTop.Name = "pnTop"
      Me.pnTop.Size = New System.Drawing.Size(376, 24)
      Me.pnTop.TabIndex = 6
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
      'RowDataReaderDemoControl
      '
      Me.Controls.Add(Me.tbResult)
      Me.Controls.Add(Me.splitter)
      Me.Controls.Add(Me.tbSql)
      Me.Controls.Add(Me.pnTop)
      Me.Name = "RowDataReaderDemoControl"
      Me.Size = New System.Drawing.Size(376, 238)
      Me.pnTop.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

    ' Methods
    Private Sub btExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExecute.Click
      Dim num As Integer = 0
      Try
        Dim reader As PgSqlDataReader = Me.command.ExecuteReader
        If (reader.FieldCount > 0) Then
          Dim num2 As Integer
          Dim str As String = ""
          For num2 = 0 To reader.FieldCount - 1
            Dim pgSqlRowType As pgSqlRowType = reader.GetPgSqlRowType(num2)
            If (Not pgSqlRowType Is Nothing) Then
              str = (str & Me.AddAttributes(pgSqlRowType))
            Else
              Me.tbResult.AppendText((reader.GetName(num2).PadRight(10).Substring(0, 10) & " "))
              str = (str & String.Empty.PadRight(10, "-"c).Substring(0, 10) & " ")
            End If
          Next num2
          Me.tbResult.AppendText((ChrW(13) & ChrW(10) & str & ChrW(13) & ChrW(10)))
          Do While reader.Read
            For num2 = 0 To reader.FieldCount - 1
              If (Not reader.GetPgSqlRowType(num2) Is Nothing) Then
                Me.AddAttributeValues(reader.GetPgSqlRow(num2))
              Else
                Me.tbResult.AppendText((reader.GetValue(num2).ToString.PadRight(10).Substring(0, 10) & " "))
              End If
            Next num2
            Me.tbResult.AppendText(ChrW(13) & ChrW(10))
            num += 1
          Loop
          Me.tbResult.AppendText((ChrW(13) & ChrW(10) & num.ToString & " rows selected." & ChrW(13) & ChrW(10)))
          MyBase.fieldWriteStatus1 = (num.ToString & " rows selected")
        Else
          Me.tbResult.AppendText("Statement executed." & ChrW(13) & ChrW(10))
          MyBase.fieldWriteStatus1 = "Statement executed"
        End If
        Me.tbResult.AppendText(ChrW(13) & ChrW(10))
        reader.Close()
      Catch exception As PgSqlException
        Me.tbResult.AppendText((exception.Message & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10)))
        Throw
      End Try
    End Sub

    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
      Me.tbResult.Clear()
      MyBase.fieldWriteStatus1 = "Result is cleared"
      MyBase.OnWriteStatus()
    End Sub

    Private Sub tbSql_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSql.Leave
      Me.command.CommandText = Me.tbSql.Text
    End Sub

    Private Function AddAttributes(ByVal pgType As PgSqlRowType) As String
      Dim str As String = String.Empty
      If (Not pgType.Attributes Is Nothing) Then
        Dim i As Integer
        For i = 0 To pgType.Attributes.Count - 1
          If (Not pgType.Attributes.Item(i).RowType Is Nothing) Then
            Me.AddAttributes(pgType.Attributes.Item(i).RowType)
          ElseIf (Not pgType.Attributes.Item(i) Is Nothing) Then
            Me.tbResult.AppendText((pgType.Attributes.Item(i).Name.PadRight(10).Substring(0, 10) & " "))
            str = (str & String.Empty.PadRight(10, "-"c).Substring(0, 10) & " ")
          End If
        Next i
      End If
      Return str
    End Function

    Private Sub AddAttributeValues(ByVal pgObject As PgSqlRow)
      If (Not pgObject Is Nothing) Then
        Dim i As Integer
        For i = 0 To pgObject.RowType.Attributes.Count - 1
          Dim attribute As PgSqlAttribute = pgObject.RowType.Attributes.Item(i)
          If (Not attribute.RowType Is Nothing) Then
            Me.AddAttributeValues(DirectCast(pgObject.Item(attribute), PgSqlRow))
          ElseIf (Not pgObject.Item(attribute) Is Nothing) Then
            Me.tbResult.AppendText((pgObject.Item(attribute).ToString.PadRight(10).Substring(0, 10) & " "))
          End If
        Next i
      End If
    End Sub
  End Class
End Namespace