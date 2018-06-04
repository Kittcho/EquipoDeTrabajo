Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Windows.Forms

Namespace Samples
  Public Class AboutForm
    Inherits System.Windows.Forms.Form

    ' Fields

    Friend WithEvents pbBevel As System.Windows.Forms.PictureBox
    Friend WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents lbWeb As System.Windows.Forms.LinkLabel
    Friend WithEvents lbMail As System.Windows.Forms.LinkLabel
    Friend WithEvents lbVersion As System.Windows.Forms.Label
    Friend WithEvents lbDbMonitorVer As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents lbDbMonitor As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents lbEdition As System.Windows.Forms.Label
    Friend WithEvents panel1 As System.Windows.Forms.Panel

    Private fieldServiceProvider As IServiceProvider
    Private Const sNotAvailable As String = "not available"
    Private Const sNotSupported As String = "not supported"
    Private Const sSupported As String = "supported"

    ' Methods
    Public Sub New()
      Me.InitializeComponent()
      Me.lbDbMonitorVer.Text = sNotSupported

       Me.lbEdition.Text = "Express Edition"
      Me.lbVersion.Text = Devart.Data.PostgreSql.ProductInfo.Version
      Me.lbWeb.Links.Add(0, Me.lbWeb.Text.Length, "http://www.devart.com/dotconnect/postgresql")
      Me.lbMail.Links.Add(0, Me.lbMail.Text.Length, "mailto:support@devart.com")
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
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AboutForm))
      Me.panel1 = New System.Windows.Forms.Panel()
      Me.lbEdition = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me.lbDbMonitor = New System.Windows.Forms.Label()
      Me.label5 = New System.Windows.Forms.Label()
      Me.label4 = New System.Windows.Forms.Label()
      Me.label3 = New System.Windows.Forms.Label()
      Me.label2 = New System.Windows.Forms.Label()
      Me.lbDbMonitorVer = New System.Windows.Forms.Label()
      Me.lbVersion = New System.Windows.Forms.Label()
      Me.lbMail = New System.Windows.Forms.LinkLabel()
      Me.lbWeb = New System.Windows.Forms.LinkLabel()
      Me.btClose = New System.Windows.Forms.Button()
      Me.pictureBox1 = New System.Windows.Forms.PictureBox()
      Me.pbBevel = New System.Windows.Forms.PictureBox()
      Me.panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'panel1
      '
      Me.panel1.BackColor = System.Drawing.Color.White
      Me.panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lbEdition, Me.label1})
      Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.panel1.Name = "panel1"
      Me.panel1.Size = New System.Drawing.Size(370, 63)
      Me.panel1.TabIndex = 12
      '
      'lbEdition
      '
      Me.lbEdition.AutoSize = True
      Me.lbEdition.Font = New System.Drawing.Font("Tahoma", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.lbEdition.ForeColor = System.Drawing.Color.Navy
      Me.lbEdition.Location = New System.Drawing.Point(37, 38)
      Me.lbEdition.Name = "lbEdition"
      Me.lbEdition.Size = New System.Drawing.Size(126, 17)
      Me.lbEdition.TabIndex = 4
      Me.lbEdition.Text = "Professional Edition"
      '
      'label1
      '
      Me.label1.AutoSize = True
      Me.label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.label1.ForeColor = System.Drawing.Color.Navy
      Me.label1.Location = New System.Drawing.Point(4, 12)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(231, 23)
      Me.label1.TabIndex = 3
      Me.label1.Text = "dotConnect for PostgreSQL"
      '
      'lbDbMonitor
      '
      Me.lbDbMonitor.AutoSize = True
      Me.lbDbMonitor.Location = New System.Drawing.Point(24, 168)
      Me.lbDbMonitor.Name = "lbDbMonitor"
      Me.lbDbMonitor.Size = New System.Drawing.Size(60, 14)
      Me.lbDbMonitor.TabIndex = 22
      Me.lbDbMonitor.Text = "DBMonitor:"
      '
      'label5
      '
      Me.label5.AutoSize = True
      Me.label5.Location = New System.Drawing.Point(24, 72)
      Me.label5.Name = "label5"
      Me.label5.Size = New System.Drawing.Size(41, 14)
      Me.label5.TabIndex = 20
      Me.label5.Text = "Version"
      '
      'label4
      '
      Me.label4.AutoSize = True
      Me.label4.Location = New System.Drawing.Point(24, 144)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(39, 14)
      Me.label4.TabIndex = 18
      Me.label4.Text = "E-mail:"
      '
      'label3
      '
      Me.label3.AutoSize = True
      Me.label3.Location = New System.Drawing.Point(24, 120)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(31, 14)
      Me.label3.TabIndex = 17
      Me.label3.Text = "Web:"
      '
      'label2
      '
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(24, 96)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(261, 14)
      Me.label2.TabIndex = 16
      Me.label2.Text = "Copyright (c) 2002-2018 Devart. All rights reserved."
      '
      'lbDbMonitorVer
      '
      Me.lbDbMonitorVer.AutoSize = True
      Me.lbDbMonitorVer.ForeColor = System.Drawing.Color.Navy
      Me.lbDbMonitorVer.Location = New System.Drawing.Point(152, 168)
      Me.lbDbMonitorVer.Name = "lbDbMonitorVer"
      Me.lbDbMonitorVer.Size = New System.Drawing.Size(58, 14)
      Me.lbDbMonitorVer.TabIndex = 23
      Me.lbDbMonitorVer.Text = "supported."
      '
      'lbVersion
      '
      Me.lbVersion.AutoSize = True
      Me.lbVersion.ForeColor = System.Drawing.Color.Navy
      Me.lbVersion.Location = New System.Drawing.Point(152, 72)
      Me.lbVersion.Name = "lbVersion"
      Me.lbVersion.Size = New System.Drawing.Size(39, 14)
      Me.lbVersion.TabIndex = 21
      Me.lbVersion.Text = "1.0.2.0"
      '
      'lbMail
      '
      Me.lbMail.AutoSize = True
      Me.lbMail.Location = New System.Drawing.Point(152, 144)
      Me.lbMail.Name = "lbMail"
      Me.lbMail.Size = New System.Drawing.Size(105, 14)
      Me.lbMail.TabIndex = 19
      Me.lbMail.TabStop = True
      Me.lbMail.Text = "support@devart.com"
      '
      'lbWeb
      '
      Me.lbWeb.AutoSize = True
      Me.lbWeb.Location = New System.Drawing.Point(152, 120)
      Me.lbWeb.Name = "lbWeb"
      Me.lbWeb.Size = New System.Drawing.Size(128, 14)
      Me.lbWeb.TabIndex = 15
      Me.lbWeb.TabStop = True
      Me.lbWeb.Text = "www.devart.com/dotconnect/postgresql"
      '
      'btClose
      '
      Me.btClose.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
      Me.btClose.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btClose.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btClose.Location = New System.Drawing.Point(288, 208)
      Me.btClose.Name = "btClose"
      Me.btClose.Size = New System.Drawing.Size(75, 25)
      Me.btClose.TabIndex = 14
      Me.btClose.Text = "Close"
      '
      'pictureBox1
      '
      Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Bitmap)
      Me.pictureBox1.Location = New System.Drawing.Point(0, 63)
      Me.pictureBox1.Name = "pictureBox1"
      Me.pictureBox1.Size = New System.Drawing.Size(360, 8)
      Me.pictureBox1.TabIndex = 25
      Me.pictureBox1.TabStop = False
      '
      'pbBevel
      '
      Me.pbBevel.Image = CType(resources.GetObject("pbBevel.Image"), System.Drawing.Bitmap)
      Me.pbBevel.Location = New System.Drawing.Point(0, 192)
      Me.pbBevel.Name = "pbBevel"
      Me.pbBevel.Size = New System.Drawing.Size(368, 8)
      Me.pbBevel.TabIndex = 24
      Me.pbBevel.TabStop = False
      '
      'AboutForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
      Me.ClientSize = New System.Drawing.Size(370, 239)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lbDbMonitor, Me.label5, Me.label4, Me.label3, Me.label2, Me.lbDbMonitorVer, Me.lbVersion, Me.lbMail, Me.lbWeb, Me.btClose, Me.pictureBox1, Me.pbBevel, Me.panel1})
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AboutForm"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "About dotConnect for PostgreSQL"
      Me.panel1.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

    ' Properties
    Friend Property ServiceProvider() As IServiceProvider
      Get
        Return Me.fieldServiceProvider
      End Get
      Set(ByVal value As IServiceProvider)
        Me.fieldServiceProvider = value
      End Set
    End Property

    ' Methods
    Private Sub lbMail_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbMail.LinkClicked
      Process.Start(e.Link.LinkData.ToString)
    End Sub

    Private Sub lbWeb_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbWeb.LinkClicked
      Process.Start(e.Link.LinkData.ToString)
    End Sub
  End Class
End Namespace
