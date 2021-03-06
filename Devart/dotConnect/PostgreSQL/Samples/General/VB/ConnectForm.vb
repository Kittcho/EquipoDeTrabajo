'
'  dotConnect for PostgreSQL
'  Copyright � 2002-2006 Devart. All rights reserved.
'  ConnectForm
'  Last modified:

Imports Devart.Data.PostgreSql
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms

Namespace Samples
  Public Class ConnectForm
    Inherits Form

    ' Fields
    Private WithEvents btCancel As System.Windows.Forms.Button
    Private WithEvents btConnect As System.Windows.Forms.Button
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents cbHost As System.Windows.Forms.ComboBox
    Private WithEvents cbSchema As System.Windows.Forms.ComboBox
    Private WithEvents lbSchema As System.Windows.Forms.Label
    Private WithEvents cbDatabase As System.Windows.Forms.ComboBox
    Private WithEvents lbDatabase As System.Windows.Forms.Label
    Private WithEvents edPort As System.Windows.Forms.NumericUpDown
    Private WithEvents lbPort As System.Windows.Forms.Label
    Private WithEvents lbHost As System.Windows.Forms.Label
    Private WithEvents edPassword As System.Windows.Forms.TextBox
    Private WithEvents lbPassword As System.Windows.Forms.Label
    Private WithEvents edUser As System.Windows.Forms.TextBox
    Private WithEvents lbUser As System.Windows.Forms.Label

    Private connection As PgSqlConnection
    Private retries As Integer
    Private fillHostsThread As Thread

    ' Methods
    Public Sub New()
      Me.components = Nothing
      Me.connection = Nothing
      Me.retries = 3
      Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal connection As IDbConnection)
      Me.components = Nothing
      Me.connection = Nothing
      Me.retries = 3
      Me.InitializeComponent()
      Me.connection = DirectCast(connection, PgSqlConnection)
      Me.edUser.Text = Me.connection.UserId
      Me.edPassword.Text = Me.connection.Password
      Me.cbHost.Text = Me.connection.Host
      Me.edPort.Text = Me.connection.Port.ToString
      Me.cbDatabase.Text = Me.connection.Database
      Me.cbSchema.Text = Me.connection.Schema
    End Sub

    'Form overrides dispose to clean up the component list.
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
      Me.btCancel = New System.Windows.Forms.Button()
      Me.btConnect = New System.Windows.Forms.Button()
      Me.panel1 = New System.Windows.Forms.Panel()
      Me.cbHost = New System.Windows.Forms.ComboBox()
      Me.cbSchema = New System.Windows.Forms.ComboBox()
      Me.lbSchema = New System.Windows.Forms.Label()
      Me.cbDatabase = New System.Windows.Forms.ComboBox()
      Me.lbDatabase = New System.Windows.Forms.Label()
      Me.edPort = New System.Windows.Forms.NumericUpDown()
      Me.lbPort = New System.Windows.Forms.Label()
      Me.lbHost = New System.Windows.Forms.Label()
      Me.edPassword = New System.Windows.Forms.TextBox()
      Me.lbPassword = New System.Windows.Forms.Label()
      Me.edUser = New System.Windows.Forms.TextBox()
      Me.lbUser = New System.Windows.Forms.Label()
      Me.panel1.SuspendLayout()
      CType(Me.edPort, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btCancel
      '
      Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btCancel.Location = New System.Drawing.Point(124, 232)
      Me.btCancel.Name = "btCancel"
      Me.btCancel.Size = New System.Drawing.Size(75, 24)
      Me.btCancel.TabIndex = 9
      Me.btCancel.Text = "Cancel"
      '
      'btConnect
      '
      Me.btConnect.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btConnect.Location = New System.Drawing.Point(36, 232)
      Me.btConnect.Name = "btConnect"
      Me.btConnect.Size = New System.Drawing.Size(75, 24)
      Me.btConnect.TabIndex = 8
      Me.btConnect.Text = "Connect"
      '
      'panel1
      '
      Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbHost, Me.cbSchema, Me.lbSchema, Me.cbDatabase, Me.lbDatabase, Me.edPort, Me.lbPort, Me.lbHost, Me.edPassword, Me.lbPassword, Me.edUser, Me.lbUser})
      Me.panel1.Location = New System.Drawing.Point(12, 11)
      Me.panel1.Name = "panel1"
      Me.panel1.Size = New System.Drawing.Size(216, 209)
      Me.panel1.TabIndex = 10
      '
      'cbHost
      '
      Me.cbHost.Location = New System.Drawing.Point(88, 78)
      Me.cbHost.Name = "cbHost"
      Me.cbHost.Size = New System.Drawing.Size(113, 21)
      Me.cbHost.TabIndex = 2
      '
      'cbSchema
      '
      Me.cbSchema.Location = New System.Drawing.Point(88, 174)
      Me.cbSchema.Name = "cbSchema"
      Me.cbSchema.Size = New System.Drawing.Size(113, 21)
      Me.cbSchema.TabIndex = 12
      '
      'lbSchema
      '
      Me.lbSchema.Location = New System.Drawing.Point(10, 177)
      Me.lbSchema.Name = "lbSchema"
      Me.lbSchema.Size = New System.Drawing.Size(64, 16)
      Me.lbSchema.TabIndex = 11
      Me.lbSchema.Text = "Schema"
      '
      'cbDatabase
      '
      Me.cbDatabase.Location = New System.Drawing.Point(88, 142)
      Me.cbDatabase.Name = "cbDatabase"
      Me.cbDatabase.Size = New System.Drawing.Size(113, 21)
      Me.cbDatabase.TabIndex = 10
      '
      'lbDatabase
      '
      Me.lbDatabase.Location = New System.Drawing.Point(10, 145)
      Me.lbDatabase.Name = "lbDatabase"
      Me.lbDatabase.Size = New System.Drawing.Size(64, 16)
      Me.lbDatabase.TabIndex = 6
      Me.lbDatabase.Text = "Database"
      '
      'edPort
      '
      Me.edPort.Location = New System.Drawing.Point(88, 110)
      Me.edPort.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
      Me.edPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.edPort.Name = "edPort"
      Me.edPort.Size = New System.Drawing.Size(113, 20)
      Me.edPort.TabIndex = 5
      Me.edPort.Value = New Decimal(New Integer() {3306, 0, 0, 0})
      '
      'lbPort
      '
      Me.lbPort.Location = New System.Drawing.Point(10, 113)
      Me.lbPort.Name = "lbPort"
      Me.lbPort.Size = New System.Drawing.Size(64, 16)
      Me.lbPort.TabIndex = 3
      Me.lbPort.Text = "Port"
      '
      'lbHost
      '
      Me.lbHost.Location = New System.Drawing.Point(10, 81)
      Me.lbHost.Name = "lbHost"
      Me.lbHost.Size = New System.Drawing.Size(64, 16)
      Me.lbHost.TabIndex = 2
      Me.lbHost.Text = "Host"
      '
      'edPassword
      '
      Me.edPassword.Location = New System.Drawing.Point(88, 46)
      Me.edPassword.Name = "edPassword"
      Me.edPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
      Me.edPassword.Size = New System.Drawing.Size(113, 20)
      Me.edPassword.TabIndex = 1
      Me.edPassword.Text = ""
      '
      'lbPassword
      '
      Me.lbPassword.Location = New System.Drawing.Point(10, 49)
      Me.lbPassword.Name = "lbPassword"
      Me.lbPassword.Size = New System.Drawing.Size(64, 16)
      Me.lbPassword.TabIndex = 1
      Me.lbPassword.Text = "Password"
      '
      'edUser
      '
      Me.edUser.Location = New System.Drawing.Point(88, 14)
      Me.edUser.Name = "edUser"
      Me.edUser.Size = New System.Drawing.Size(113, 20)
      Me.edUser.TabIndex = 0
      Me.edUser.Text = ""
      '
      'lbUser
      '
      Me.lbUser.Location = New System.Drawing.Point(10, 17)
      Me.lbUser.Name = "lbUser"
      Me.lbUser.Size = New System.Drawing.Size(64, 16)
      Me.lbUser.TabIndex = 0
      Me.lbUser.Text = "User"
      '
      'ConnectForm
      '
      Me.AcceptButton = Me.btConnect
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me.btCancel
      Me.ClientSize = New System.Drawing.Size(239, 268)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.panel1, Me.btCancel, Me.btConnect})
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.MinimumSize = New System.Drawing.Size(245, 293)
      Me.Name = "ConnectForm"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Connect"
      Me.panel1.ResumeLayout(False)
      CType(Me.edPort, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

    ' Methods
    Private Sub AddHostItem(ByVal host As String)
      Me.cbHost.Items.Add(host)
    End Sub

    Private Sub btConnect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btConnect.Click
      Me.connection.Close()
      Me.connection.UserId = Me.edUser.Text
      Me.connection.Password = Me.edPassword.Text
      Me.connection.Host = Me.cbHost.Text
      Me.connection.Port = Convert.ToInt32(Me.edPort.Text)
      Me.connection.Database = Me.cbDatabase.Text
      Me.connection.Schema = Me.cbSchema.Text
      Try
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.connection.Open()
        Windows.Forms.Cursor.Current = Cursors.Default
        MyBase.DialogResult = Windows.Forms.DialogResult.OK
      Catch exception As PgSqlException
        Windows.Forms.Cursor.Current = Cursors.Default
        Me.retries -= 1
        If (Me.retries = 0) Then
          MyBase.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
        Dim text As String = exception.Message.Trim
        If (([text] = ("FATAL:  user """ & Me.edUser.Text & """ does not exist")) OrElse ([text] = "FATAL:  no PostgreSQL user name specified in startup packet")) Then
          MyBase.ActiveControl = Me.edUser
        ElseIf ([text] = "No such host is known") Then
          MyBase.ActiveControl = Me.cbHost
        ElseIf ([text] = "No connection could be made because the target machine actively refused it") Then
          MyBase.ActiveControl = Me.edPort
        ElseIf ([text] = ("FATAL:  Database """ & Me.cbDatabase.Text & """ does not exist in the system catalog.")) Then
          MyBase.ActiveControl = Me.cbDatabase
        End If
        MessageBox.Show([text], "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
      End Try
    End Sub

    Private Sub cdDatabase_DropDown(ByVal sender As Object, ByVal e As EventArgs) Handles cbDatabase.DropDown
      Windows.Forms.Cursor.Current = Cursors.WaitCursor
      Me.cbDatabase.Items.Clear()
      Me.cbSchema.Text = ""
      Dim connection As New PgSqlConnection()
      connection.Host = Me.cbHost.Text
      connection.UserId = Me.edUser.Text
      connection.Password = Me.edPassword.Text
      connection.Port = CInt(Me.edPort.Value)
      Try
        Try
          connection.Open()
          Dim command As IDbCommand = New PgSqlCommand("SELECT datname FROM pg_database WHERE datallowconn = true and datname <> 'template1'", connection)
          Dim reader As IDataReader = command.ExecuteReader
          Try
            Do While reader.Read
              Me.cbDatabase.Items.Add(reader.Item(0))
            Loop
          Finally
            reader.Close()
          End Try
        Catch exception As exception
          MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
      Finally
        Windows.Forms.Cursor.Current = Cursors.Default
        connection.Close()
      End Try
    End Sub

    Private Sub ConnectForm_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
      If ((Not Me.fillHostsThread Is Nothing) AndAlso (Me.fillHostsThread.ThreadState = ThreadState.Running)) Then
        Me.fillHostsThread.Abort()
      End If
    End Sub

    Private Sub FillHostListThreadFunc()
      MyBase.Invoke(New MethodInvoker(AddressOf Me.SetStartingCursor))
      Try
        Try
          Dim dataSources As DataTable = PgSqlProviderFactory.Instance.CreateDataSourceEnumerator.GetDataSources
          Dim row As DataRow
          For Each row In dataSources.Rows
            If Not (((Me.cbHost Is Nothing) OrElse Me.cbHost.IsDisposed) OrElse Me.cbHost.Disposing) Then
              Me.cbHost.Invoke(New AddHostItemDelegate(AddressOf Me.AddHostItem), New Object() {row.Item("ServerName").ToString})
            End If
          Next
        Catch
        End Try
      Finally
        Try
          MyBase.Invoke(New MethodInvoker(AddressOf Me.SetDefaultCursor))
        Catch
        End Try
      End Try
    End Sub

    Private Sub SetDefaultCursor()
      If Not MyBase.IsDisposed Then
        Me.Cursor = Cursors.Default
      End If
    End Sub

    Private Sub SetStartingCursor()
      Me.Cursor = Cursors.AppStarting
    End Sub

    Private Sub ConnectForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Me.fillHostsThread = New Thread(New ThreadStart(AddressOf Me.FillHostListThreadFunc))
      Me.fillHostsThread.Start()
    End Sub

    Private Sub cbSchema_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSchema.DropDown
      Me.cbSchema.Items.Clear()
      If (Me.cbDatabase.Text.Length <> 0) Then
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim connection As New PgSqlConnection()
        connection.Host = Me.cbHost.Text
        connection.UserId = Me.edUser.Text
        connection.Password = Me.edPassword.Text
        connection.Port = CInt(Me.edPort.Value)
        connection.Database = Me.cbDatabase.Text
        Try
          Try
            connection.Open()
            Dim schema As DataTable = connection.GetSchema("Schemas")
            Dim row As DataRow
            For Each row In schema.Rows
              If (((Not row.Item("nsptyp") Is Nothing) AndAlso (Not row.Item("nsptyp") Is DBNull.Value)) AndAlso (CInt(row.Item("nsptyp")) = 2)) Then
                Me.cbSchema.Items.Add(row.Item("name"))
              End If
            Next
          Catch exception As exception
            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
          End Try
        Finally
          Windows.Forms.Cursor.Current = Cursors.Default
          connection.Close()
        End Try
      End If
    End Sub

    ' Nested Types
    Private Delegate Sub AddHostItemDelegate(ByVal host As String)
  End Class
End Namespace