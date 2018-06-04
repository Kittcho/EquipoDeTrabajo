Imports Devart.Data.PostgreSql
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms

Namespace Samples
  Public Class PicturesDemoControl
    Inherits BaseDemoControl

    ' Fields
    Private WithEvents openFileDialog As System.Windows.Forms.OpenFileDialog
    Private WithEvents saveFileDialog As System.Windows.Forms.SaveFileDialog
    Private WithEvents dataSet As System.Data.DataSet
    Private WithEvents selectCommand As Devart.Data.PostgreSql.PgSqlCommand
    Private WithEvents dataAdapter As Devart.Data.PostgreSql.PgSqlDataAdapter
    Private WithEvents commandBuilder As Devart.Data.PostgreSql.PgSqlCommandBuilder
    Private WithEvents topPanel As System.Windows.Forms.Panel
    Private WithEvents btShowImages As System.Windows.Forms.Button
    Private WithEvents btUpdate As System.Windows.Forms.Button
    Private WithEvents btClear As System.Windows.Forms.Button
    Private WithEvents btFill As System.Windows.Forms.Button
    Private WithEvents splitter As System.Windows.Forms.Splitter
    Private WithEvents dataGrid As System.Windows.Forms.DataGrid
    Private WithEvents middlePanel As System.Windows.Forms.Panel
    Private WithEvents btClearPicture As System.Windows.Forms.Button
    Private WithEvents btSave As System.Windows.Forms.Button
    Private WithEvents btLoad As System.Windows.Forms.Button
    Private WithEvents pictureBox As System.Windows.Forms.PictureBox

    ' Methods
    Public Sub New()
      Me.components = Nothing
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
      Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
      Me.saveFileDialog = New System.Windows.Forms.SaveFileDialog()
      Me.dataSet = New System.Data.DataSet()
      Me.selectCommand = New Devart.Data.PostgreSql.PgSqlCommand()
      Me.dataAdapter = New Devart.Data.PostgreSql.PgSqlDataAdapter()
      Me.commandBuilder = New Devart.Data.PostgreSql.PgSqlCommandBuilder()
      Me.topPanel = New System.Windows.Forms.Panel()
      Me.btShowImages = New System.Windows.Forms.Button()
      Me.btUpdate = New System.Windows.Forms.Button()
      Me.btClear = New System.Windows.Forms.Button()
      Me.btFill = New System.Windows.Forms.Button()
      Me.splitter = New System.Windows.Forms.Splitter()
      Me.dataGrid = New System.Windows.Forms.DataGrid()
      Me.middlePanel = New System.Windows.Forms.Panel()
      Me.btClearPicture = New System.Windows.Forms.Button()
      Me.btSave = New System.Windows.Forms.Button()
      Me.btLoad = New System.Windows.Forms.Button()
      Me.pictureBox = New System.Windows.Forms.PictureBox()
      CType(Me.dataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.topPanel.SuspendLayout()
      CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.middlePanel.SuspendLayout()
      Me.SuspendLayout()
      '
      'openFileDialog
      '
      Me.openFileDialog.DefaultExt = "bmp"
      Me.openFileDialog.Filter = "Bitmaps (*.bmp)|*.bmp"
      '
      'saveFileDialog
      '
      Me.saveFileDialog.DefaultExt = "bmp"
      Me.saveFileDialog.Filter = "Bitmaps (*.bmp)|*.bmp"
      '
      'dataSet
      '
      Me.dataSet.DataSetName = "NewDataSet"
      Me.dataSet.Locale = New System.Globalization.CultureInfo("en-US")
      '
      'selectCommand
      '
      Me.selectCommand.CommandText = "SELECT * FROM pgsqlnet_pictures"
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
      'topPanel
      '
      Me.topPanel.Controls.AddRange(New System.Windows.Forms.Control() {Me.btShowImages, Me.btUpdate, Me.btClear, Me.btFill})
      Me.topPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me.topPanel.Name = "topPanel"
      Me.topPanel.Size = New System.Drawing.Size(520, 24)
      Me.topPanel.TabIndex = 12
      '
      'btShowImages
      '
      Me.btShowImages.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btShowImages.Location = New System.Drawing.Point(330, 0)
      Me.btShowImages.Name = "btShowImages"
      Me.btShowImages.Size = New System.Drawing.Size(88, 23)
      Me.btShowImages.TabIndex = 5
      Me.btShowImages.Text = "Show Images !"
      '
      'btUpdate
      '
      Me.btUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btUpdate.Location = New System.Drawing.Point(152, 0)
      Me.btUpdate.Name = "btUpdate"
      Me.btUpdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.btUpdate.TabIndex = 4
      Me.btUpdate.Text = "Update"
      '
      'btClear
      '
      Me.btClear.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btClear.Location = New System.Drawing.Point(76, 0)
      Me.btClear.Name = "btClear"
      Me.btClear.TabIndex = 3
      Me.btClear.Text = "Clear"
      '
      'btFill
      '
      Me.btFill.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btFill.Name = "btFill"
      Me.btFill.TabIndex = 2
      Me.btFill.Text = "Fill"
      '
      'splitter
      '
      Me.splitter.Cursor = System.Windows.Forms.Cursors.HSplit
      Me.splitter.Dock = System.Windows.Forms.DockStyle.Top
      Me.splitter.Location = New System.Drawing.Point(0, 120)
      Me.splitter.MinExtra = 70
      Me.splitter.MinSize = 70
      Me.splitter.Name = "splitter"
      Me.splitter.Size = New System.Drawing.Size(520, 3)
      Me.splitter.TabIndex = 18
      Me.splitter.TabStop = False
      '
      'dataGrid
      '
      Me.dataGrid.AllowNavigation = False
      Me.dataGrid.AllowSorting = False
      Me.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dataGrid.CaptionVisible = False
      Me.dataGrid.DataMember = ""
      Me.dataGrid.DataSource = Me.dataSet
      Me.dataGrid.Dock = System.Windows.Forms.DockStyle.Top
      Me.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.dataGrid.Location = New System.Drawing.Point(0, 24)
      Me.dataGrid.Name = "dataGrid"
      Me.dataGrid.Size = New System.Drawing.Size(520, 96)
      Me.dataGrid.TabIndex = 17
      '
      'middlePanel
      '
      Me.middlePanel.Controls.AddRange(New System.Windows.Forms.Control() {Me.btClearPicture, Me.btSave, Me.btLoad})
      Me.middlePanel.Dock = System.Windows.Forms.DockStyle.Top
      Me.middlePanel.Location = New System.Drawing.Point(0, 123)
      Me.middlePanel.Name = "middlePanel"
      Me.middlePanel.Size = New System.Drawing.Size(520, 24)
      Me.middlePanel.TabIndex = 19
      '
      'btClearPicture
      '
      Me.btClearPicture.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btClearPicture.Location = New System.Drawing.Point(194, 0)
      Me.btClearPicture.Name = "btClearPicture"
      Me.btClearPicture.Size = New System.Drawing.Size(64, 23)
      Me.btClearPicture.TabIndex = 2
      Me.btClearPicture.Text = "Clear"
      '
      'btSave
      '
      Me.btSave.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btSave.Location = New System.Drawing.Point(97, 0)
      Me.btSave.Name = "btSave"
      Me.btSave.Size = New System.Drawing.Size(96, 23)
      Me.btSave.TabIndex = 1
      Me.btSave.Text = "Save to file..."
      '
      'btLoad
      '
      Me.btLoad.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btLoad.Name = "btLoad"
      Me.btLoad.Size = New System.Drawing.Size(96, 23)
      Me.btLoad.TabIndex = 0
      Me.btLoad.Text = "Load from file..."
      '
      'pictureBox
      '
      Me.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pictureBox.Location = New System.Drawing.Point(0, 147)
      Me.pictureBox.Name = "pictureBox"
      Me.pictureBox.Size = New System.Drawing.Size(520, 133)
      Me.pictureBox.TabIndex = 20
      Me.pictureBox.TabStop = False
      '
      'PicturesDemoControl
      '
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pictureBox, Me.middlePanel, Me.splitter, Me.dataGrid, Me.topPanel})
      Me.Name = "PicturesDemoControl"
      Me.Size = New System.Drawing.Size(520, 280)
      CType(Me.dataSet, System.ComponentModel.ISupportInitialize).EndInit()
      Me.topPanel.ResumeLayout(False)
      CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.middlePanel.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

    ' Methods
    Private Sub btFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFill.Click
      Me.dataAdapter.Fill(Me.dataSet, "Table")
      Me.dataGrid.DataMember = "Table"
      Me.UpdatePictureBox()
    End Sub

    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
      Me.dataGrid.DataMember = String.Empty
      Me.dataSet.Clear()
      Dim table As DataTable
      For Each table In Me.dataSet.Tables
        table.Constraints.Clear()
      Next
      Me.UpdatePictureBox()
    End Sub

    Private Sub btUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUpdate.Click
      If (Me.dataSet.Tables.Count <> 0) Then
        Me.dataAdapter.Update(Me.dataSet, "Table")
      End If
    End Sub

    Private Sub btShowImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btShowImages.Click
      Dim dataReader As PgSqlDataReader = Me.selectCommand.ExecuteReader
      Dim fieldNo As Integer = dataReader.GetOrdinal("Picture")
      Do While dataReader.Read
        Dim length As Integer = CInt(dataReader.GetBytes(fieldNo, CLng(0), Nothing, 0, 0))
        Dim buffer As Byte() = New Byte(length - 1) {}
        length = CInt(dataReader.GetBytes(fieldNo, CLng(0), buffer, 0, length))
        Dim pictureName As String = dataReader.GetString(1)
        If (length > 0) Then
          Dim form As New Form()
          form.Text = pictureName
          form.Show()
          Dim pictureBox As New pictureBox()
          pictureBox.Parent = form
          pictureBox.Dock = DockStyle.Fill
          pictureBox.Image = Image.FromStream(New MemoryStream(buffer))
        End If
      Loop
      dataReader.Close()
    End Sub

    Private Sub btLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLoad.Click
      Dim table As DataTable = Me.dataSet.Tables.Item("Table")
      If (Not table Is Nothing) Then
        If (((Me.dataGrid.CurrentRowIndex >= 0) AndAlso (Me.dataGrid.CurrentRowIndex < table.Rows.Count)) AndAlso (Me.openFileDialog.ShowDialog = DialogResult.OK)) Then
          Dim fs As New FileStream(Me.openFileDialog.FileName, FileMode.Open, FileAccess.Read)
          Dim val As Byte() = New Byte(fs.Length - 1) {}
          fs.Read(val, 0, CInt(fs.Length))
          fs.Close()
          table.Rows.Item(Me.dataGrid.CurrentRowIndex).Item("Picture") = val
        End If
        Me.UpdatePictureBox()
      End If
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
      Dim table As DataTable = Me.dataSet.Tables.Item("Table")
      If ((Not table Is Nothing) AndAlso ((Me.dataGrid.CurrentRowIndex >= 0) AndAlso (Me.dataGrid.CurrentRowIndex < table.Rows.Count))) Then
        Dim val As Object = table.Rows.Item(Me.dataGrid.CurrentRowIndex).Item("Picture")
        If ((Not val Is DBNull.Value) AndAlso (Me.saveFileDialog.ShowDialog = DialogResult.OK)) Then
          Dim fs As New FileStream(Me.saveFileDialog.FileName, FileMode.CreateNew, FileAccess.Write)
          fs.Write(DirectCast(val, Byte()), 0, DirectCast(val, Byte()).Length)
          fs.Close()
        End If
      End If
    End Sub

    Private Sub btClearPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClearPicture.Click
      Dim table As DataTable = Me.dataSet.Tables.Item("Table")
      If (Not table Is Nothing) Then
        If ((Me.dataGrid.CurrentRowIndex >= 0) AndAlso (Me.dataGrid.CurrentRowIndex < table.Rows.Count)) Then
          table.Rows.Item(Me.dataGrid.CurrentRowIndex).Item("Picture") = DBNull.Value
        End If
        Me.UpdatePictureBox()
      End If
    End Sub

    Private Sub dataGrid_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataGrid.CurrentCellChanged
      Me.UpdatePictureBox()
    End Sub

    Private Sub UpdatePictureBox()
      Me.pictureBox.Image = Nothing
      MyBase.fieldWriteStatus1 = ""
      MyBase.fieldWriteStatus2 = ""
      Dim table As DataTable = Me.dataSet.Tables.Item("Table")
      If ((table IsNot Nothing) AndAlso (Me.dataGrid.CurrentRowIndex >= 0) AndAlso (Me.dataGrid.CurrentRowIndex < table.Rows.Count)) Then
        Dim val As Object = DBNull.Value
        If Not table.Rows.Item(Me.dataGrid.CurrentRowIndex).RowState = DataRowState.Deleted Then
          val = table.Rows.Item(Me.dataGrid.CurrentRowIndex).Item("Picture")
        End If
        If (Not val Is DBNull.Value) Then
          If (DirectCast(val, Byte()).Length > 0) Then
            Me.pictureBox.Image = Image.FromStream(New MemoryStream(DirectCast(val, Byte())))
          End If
          MyBase.fieldWriteStatus1 = ("Size: " & DirectCast(val, Byte()).Length.ToString)
        End If
        MyBase.fieldWriteStatus2 = (table.Rows.Count.ToString & " rows selected")
      End If
      MyBase.OnWriteStatus()
    End Sub

    Private Sub dataGrid_DataSourceChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataGrid.DataSourceChanged
      Dim gridOpen As Boolean = Not (dataGrid.DataSource Is Nothing Or dataGrid.DataMember Is String.Empty)
      btLoad.Enabled = gridOpen
      btSave.Enabled = gridOpen
    End Sub
  End Class
End Namespace