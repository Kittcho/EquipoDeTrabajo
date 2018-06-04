Namespace Samples
  Public Class MainForm
    Inherits MainFormBase

    ' Fields
    Friend WithEvents myConnection As Devart.Data.PostgreSql.PgSqlConnection

    ' Methods
    Public Sub New()
      Me.InitializeComponent()
      MyBase.Connection = Me.myConnection
      MyBase.CatalogName = "dotConnect for PostgreSQL samples"
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
      Me.myConnection = New Devart.Data.PostgreSql.PgSqlConnection()
      Me.SuspendLayout()
      '
      'lbDirect
      '
      Me.lbDirect.Size = New System.Drawing.Size(322, 43)
      Me.lbDirect.Text = "dotConnect for PostgreSQL"
      Me.lbDirect.Visible = True
      '
      'myConnection
      '
      Me.myConnection.ConnectionString = "User Id=postgres;Host=localhost;Database=testdb;Schema=test;"
      Me.myConnection.Name = "myConnection"
      Me.myConnection.Owner = Me
      '
      'MainForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(1016, 725)
      Me.Location = New System.Drawing.Point(0, 0)
      Me.Name = "MainForm"
      Me.Text = "dotConnect for PostgreSQL Samples"
      Me.ResumeLayout(False)
    End Sub

    ' Methods
    Protected Overrides Sub CreateDemos()
      Dim sampleGroup1 As New ArrayList(12)
      sampleGroup1.Add(New CrystalDemo())
      sampleGroup1.Add(New DataReaderDemo())
      sampleGroup1.Add(New DataSetDemo())
      sampleGroup1.Add(New MasterDetailDemo())
      sampleGroup1.Add(New MetaDataDemo())
      sampleGroup1.Add(New PicturesDemo())
      sampleGroup1.Add(New StoredProcDemo())
      sampleGroup1.Add(New TableDemo())
      sampleGroup1.Add(New TransactionsDemo())
      Dim catalog As New DemoCatalog("General demos", sampleGroup1)
      MyBase.samples.Add(catalog)
      Dim sampleGroup2 As New ArrayList(8)
      sampleGroup2.Add(New RefCursorDemo())
      sampleGroup2.Add(New RowDataReaderDemo())
      sampleGroup2.Add(New RowDataSetDemo())
      sampleGroup2.Add(New RowStoredProcDemo())
      catalog = New DemoCatalog("Technology demos", sampleGroup2)
      MyBase.samples.Add(catalog)
    End Sub
  End Class
End Namespace
