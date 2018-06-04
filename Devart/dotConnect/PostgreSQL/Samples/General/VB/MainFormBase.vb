Imports AxSHDocVw
Imports Devart.Common
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
Imports System.Drawing
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms

Namespace Samples
  Public Class MainFormBase
    Inherits System.Windows.Forms.Form

    ' Fields
    Private baseWindowName As String
    Private fieldCatalogName As String
    Protected samples As ArrayList = New ArrayList(15)
    Private fromNavigate As Boolean = False
    Private history As history = New history(10)
    Private ReadOnly tempHtmlFile As String
    Private fieldCreateSqlText As String
    Private fieldDropSqlText As String
    Private lastButton As ToolBarButton = Nothing
    Private fieldConnection As DbConnection

    Private WithEvents imageTree As System.Windows.Forms.ImageList
    Private WithEvents cmBack As System.Windows.Forms.ContextMenu
    Private WithEvents cmForward As System.Windows.Forms.ContextMenu
    Private WithEvents imageArrows As System.Windows.Forms.ImageList
    Private WithEvents imageButtons As System.Windows.Forms.ImageList
    Private WithEvents pnDirect As System.Windows.Forms.Panel
    Private WithEvents linkAbout As System.Windows.Forms.LinkLabel
    Protected WithEvents lbDirect As System.Windows.Forms.Label
    Private WithEvents statusBar As System.Windows.Forms.StatusBar
    Private WithEvents statusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Private WithEvents statusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Private WithEvents statusBarPanel3 As System.Windows.Forms.StatusBarPanel
    Private WithEvents pnLeft As System.Windows.Forms.Panel
    Private WithEvents pnSampleList As System.Windows.Forms.Panel
    Private WithEvents tvSampleList As System.Windows.Forms.TreeView
    Private WithEvents pnNavigation As System.Windows.Forms.Panel
    Private WithEvents toolSeparator2 As System.Windows.Forms.ToolBar
    Private WithEvents toolNavigation As System.Windows.Forms.ToolBar
    Private WithEvents btBack As System.Windows.Forms.ToolBarButton
    Private WithEvents btForward As System.Windows.Forms.ToolBarButton
    Private WithEvents pnConnectionToolBar As System.Windows.Forms.Panel
    Private WithEvents spVert As System.Windows.Forms.Splitter
    Private WithEvents pnMain As System.Windows.Forms.Panel
    Private WithEvents pnViewToolBar As System.Windows.Forms.Panel
    Private WithEvents toolView As System.Windows.Forms.ToolBar
    Private WithEvents btDemo As System.Windows.Forms.ToolBarButton
    Private WithEvents btDescription As System.Windows.Forms.ToolBarButton
    Private WithEvents btSource As System.Windows.Forms.ToolBarButton
    Private WithEvents btSql As System.Windows.Forms.ToolBarButton
    Private WithEvents btSeparator2 As System.Windows.Forms.ToolBarButton
    Private WithEvents pnDemo As System.Windows.Forms.Panel
    Private WithEvents pnSql As System.Windows.Forms.Panel
    Private WithEvents textSql As System.Windows.Forms.RichTextBox
    Private WithEvents pnSqlType As System.Windows.Forms.Panel
    Private WithEvents toolSeparator1 As System.Windows.Forms.ToolBar
    Private WithEvents toolSqlType As System.Windows.Forms.ToolBar
    Private WithEvents btExecute As System.Windows.Forms.ToolBarButton
    Private WithEvents btSeparator1 As System.Windows.Forms.ToolBarButton
    Private WithEvents btCreate As System.Windows.Forms.ToolBarButton
    Private WithEvents btDrop As System.Windows.Forms.ToolBarButton
    Private WithEvents pnDescription As System.Windows.Forms.Panel
    Private WithEvents webDescription As AxSHDocVw.AxWebBrowser
    Private WithEvents pnSource As System.Windows.Forms.Panel
    Private WithEvents tbSource As System.Windows.Forms.RichTextBox
    Private WithEvents btConnect As System.Windows.Forms.ToolBarButton
    Private WithEvents btSeparat3 As System.Windows.Forms.ToolBarButton
    Private WithEvents btDisconnect As System.Windows.Forms.ToolBarButton
    Private WithEvents toolConnection As System.Windows.Forms.ToolBar

    ' Methods
    Public Sub New()
      AddHandler Application.ThreadException, New ThreadExceptionEventHandler(AddressOf Me.OnThreadException)
      AddHandler Me.history.HistoryChanged, New HistoryChangedHandler(AddressOf Me.FillContextMenu)
      Me.tempHtmlFile = IO.Path.Combine(Environment.CurrentDirectory, "sample.html")
      Me.InitializeComponent()
      Me.CreateTreeNodes()

    End Sub

    'Form overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()> _
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainFormBase))
      Me.imageTree = New System.Windows.Forms.ImageList(Me.components)
      Me.cmBack = New System.Windows.Forms.ContextMenu()
      Me.cmForward = New System.Windows.Forms.ContextMenu()
      Me.imageArrows = New System.Windows.Forms.ImageList(Me.components)
      Me.imageButtons = New System.Windows.Forms.ImageList(Me.components)
      Me.pnDirect = New System.Windows.Forms.Panel()
      Me.linkAbout = New System.Windows.Forms.LinkLabel()
      Me.lbDirect = New System.Windows.Forms.Label()
      Me.statusBar = New System.Windows.Forms.StatusBar()
      Me.statusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
      Me.statusBarPanel2 = New System.Windows.Forms.StatusBarPanel()
      Me.statusBarPanel3 = New System.Windows.Forms.StatusBarPanel()
      Me.pnLeft = New System.Windows.Forms.Panel()
      Me.pnSampleList = New System.Windows.Forms.Panel()
      Me.tvSampleList = New System.Windows.Forms.TreeView()
      Me.pnNavigation = New System.Windows.Forms.Panel()
      Me.toolSeparator2 = New System.Windows.Forms.ToolBar()
      Me.toolNavigation = New System.Windows.Forms.ToolBar()
      Me.btBack = New System.Windows.Forms.ToolBarButton()
      Me.btForward = New System.Windows.Forms.ToolBarButton()
      Me.pnConnectionToolBar = New System.Windows.Forms.Panel()
      Me.toolConnection = New System.Windows.Forms.ToolBar()
      Me.btConnect = New System.Windows.Forms.ToolBarButton()
      Me.btSeparat3 = New System.Windows.Forms.ToolBarButton()
      Me.btDisconnect = New System.Windows.Forms.ToolBarButton()
      Me.spVert = New System.Windows.Forms.Splitter()
      Me.pnMain = New System.Windows.Forms.Panel()
      Me.pnSql = New System.Windows.Forms.Panel()
      Me.textSql = New System.Windows.Forms.RichTextBox()
      Me.pnSqlType = New System.Windows.Forms.Panel()
      Me.toolSeparator1 = New System.Windows.Forms.ToolBar()
      Me.toolSqlType = New System.Windows.Forms.ToolBar()
      Me.btExecute = New System.Windows.Forms.ToolBarButton()
      Me.btSeparator1 = New System.Windows.Forms.ToolBarButton()
      Me.btCreate = New System.Windows.Forms.ToolBarButton()
      Me.btDrop = New System.Windows.Forms.ToolBarButton()
      Me.pnDescription = New System.Windows.Forms.Panel()
      Me.webDescription = New AxSHDocVw.AxWebBrowser()
      Me.pnSource = New System.Windows.Forms.Panel()
      Me.tbSource = New System.Windows.Forms.RichTextBox()
      Me.pnDemo = New System.Windows.Forms.Panel()
      Me.pnViewToolBar = New System.Windows.Forms.Panel()
      Me.toolView = New System.Windows.Forms.ToolBar()
      Me.btDemo = New System.Windows.Forms.ToolBarButton()
      Me.btDescription = New System.Windows.Forms.ToolBarButton()
      Me.btSource = New System.Windows.Forms.ToolBarButton()
      Me.btSql = New System.Windows.Forms.ToolBarButton()
      Me.btSeparator2 = New System.Windows.Forms.ToolBarButton()
      Me.pnDirect.SuspendLayout()
      CType(Me.statusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.statusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.statusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnLeft.SuspendLayout()
      Me.pnSampleList.SuspendLayout()
      Me.pnNavigation.SuspendLayout()
      Me.pnConnectionToolBar.SuspendLayout()
      Me.pnMain.SuspendLayout()
      Me.pnSql.SuspendLayout()
      Me.pnSqlType.SuspendLayout()
      Me.pnDescription.SuspendLayout()
      CType(Me.webDescription, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnSource.SuspendLayout()
      Me.pnViewToolBar.SuspendLayout()
      Me.SuspendLayout()
      '
      'imageTree
      '
      Me.imageTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
      Me.imageTree.ImageSize = New System.Drawing.Size(16, 16)
      Me.imageTree.ImageStream = CType(resources.GetObject("imageTree.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageTree.TransparentColor = System.Drawing.Color.Magenta
      '
      'imageArrows
      '
      Me.imageArrows.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
      Me.imageArrows.ImageSize = New System.Drawing.Size(17, 17)
      Me.imageArrows.ImageStream = CType(resources.GetObject("imageArrows.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageArrows.TransparentColor = System.Drawing.Color.Magenta
      '
      'imageButtons
      '
      Me.imageButtons.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
      Me.imageButtons.ImageSize = New System.Drawing.Size(16, 16)
      Me.imageButtons.ImageStream = CType(resources.GetObject("imageButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageButtons.TransparentColor = System.Drawing.Color.Magenta
      '
      'pnDirect
      '
      Me.pnDirect.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
      Me.pnDirect.Controls.AddRange(New System.Windows.Forms.Control() {Me.linkAbout, Me.lbDirect})
      Me.pnDirect.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnDirect.Name = "pnDirect"
      Me.pnDirect.Size = New System.Drawing.Size(1016, 48)
      Me.pnDirect.TabIndex = 11
      '
      'linkAbout
      '
      Me.linkAbout.Anchor = System.Windows.Forms.AnchorStyles.Right
      Me.linkAbout.AutoSize = True
      Me.linkAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.linkAbout.LinkColor = System.Drawing.Color.White
      Me.linkAbout.Location = New System.Drawing.Point(949, 14)
      Me.linkAbout.Name = "linkAbout"
      Me.linkAbout.Size = New System.Drawing.Size(41, 16)
      Me.linkAbout.TabIndex = 1
      Me.linkAbout.TabStop = True
      Me.linkAbout.Text = "About"
      '
      'lbDirect
      '
      Me.lbDirect.AutoSize = True
      Me.lbDirect.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.lbDirect.ForeColor = System.Drawing.Color.White
      Me.lbDirect.Name = "lbDirect"
      Me.lbDirect.Size = New System.Drawing.Size(0, 43)
      Me.lbDirect.TabIndex = 0
      '
      'statusBar
      '
      Me.statusBar.Location = New System.Drawing.Point(0, 703)
      Me.statusBar.Name = "statusBar"
      Me.statusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.statusBarPanel1, Me.statusBarPanel2, Me.statusBarPanel3})
      Me.statusBar.ShowPanels = True
      Me.statusBar.Size = New System.Drawing.Size(1016, 22)
      Me.statusBar.TabIndex = 12
      '
      'statusBarPanel1
      '
      Me.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
      Me.statusBarPanel1.Width = 333
      '
      'statusBarPanel2
      '
      Me.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
      Me.statusBarPanel2.Width = 333
      '
      'statusBarPanel3
      '
      Me.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
      Me.statusBarPanel3.Width = 333
      '
      'pnLeft
      '
      Me.pnLeft.AutoScroll = True
      Me.pnLeft.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnSampleList, Me.pnConnectionToolBar})
      Me.pnLeft.Dock = System.Windows.Forms.DockStyle.Left
      Me.pnLeft.Location = New System.Drawing.Point(0, 48)
      Me.pnLeft.Name = "pnLeft"
      Me.pnLeft.Size = New System.Drawing.Size(176, 655)
      Me.pnLeft.TabIndex = 13
      '
      'pnSampleList
      '
      Me.pnSampleList.BackColor = System.Drawing.SystemColors.ControlDark
      Me.pnSampleList.Controls.AddRange(New System.Windows.Forms.Control() {Me.tvSampleList, Me.pnNavigation})
      Me.pnSampleList.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnSampleList.Location = New System.Drawing.Point(0, 26)
      Me.pnSampleList.Name = "pnSampleList"
      Me.pnSampleList.Size = New System.Drawing.Size(176, 629)
      Me.pnSampleList.TabIndex = 10
      '
      'tvSampleList
      '
      Me.tvSampleList.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.tvSampleList.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tvSampleList.HideSelection = False
      Me.tvSampleList.ImageList = Me.imageTree
      Me.tvSampleList.Location = New System.Drawing.Point(0, 27)
      Me.tvSampleList.Name = "tvSampleList"
      Me.tvSampleList.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Samples catalog name", 1, 1)})
      Me.tvSampleList.Size = New System.Drawing.Size(176, 602)
      Me.tvSampleList.TabIndex = 9
      '
      'pnNavigation
      '
      Me.pnNavigation.BackColor = System.Drawing.SystemColors.Control
      Me.pnNavigation.Controls.AddRange(New System.Windows.Forms.Control() {Me.toolSeparator2, Me.toolNavigation})
      Me.pnNavigation.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnNavigation.Name = "pnNavigation"
      Me.pnNavigation.Size = New System.Drawing.Size(176, 27)
      Me.pnNavigation.TabIndex = 8
      '
      'toolSeparator2
      '
      Me.toolSeparator2.DropDownArrows = True
      Me.toolSeparator2.Location = New System.Drawing.Point(0, 25)
      Me.toolSeparator2.Name = "toolSeparator2"
      Me.toolSeparator2.ShowToolTips = True
      Me.toolSeparator2.Size = New System.Drawing.Size(176, 39)
      Me.toolSeparator2.TabIndex = 12
      '
      'toolNavigation
      '
      Me.toolNavigation.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.toolNavigation.AutoSize = False
      Me.toolNavigation.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btBack, Me.btForward})
      Me.toolNavigation.ButtonSize = New System.Drawing.Size(23, 22)
      Me.toolNavigation.DropDownArrows = True
      Me.toolNavigation.ImageList = Me.imageArrows
      Me.toolNavigation.Name = "toolNavigation"
      Me.toolNavigation.ShowToolTips = True
      Me.toolNavigation.Size = New System.Drawing.Size(176, 25)
      Me.toolNavigation.TabIndex = 11
      '
      'btBack
      '
      Me.btBack.DropDownMenu = Me.cmBack
      Me.btBack.ImageIndex = 0
      Me.btBack.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
      '
      'btForward
      '
      Me.btForward.DropDownMenu = Me.cmForward
      Me.btForward.ImageIndex = 2
      Me.btForward.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
      '
      'pnConnectionToolBar
      '
      Me.pnConnectionToolBar.BackColor = System.Drawing.SystemColors.Control
      Me.pnConnectionToolBar.Controls.AddRange(New System.Windows.Forms.Control() {Me.toolConnection})
      Me.pnConnectionToolBar.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnConnectionToolBar.Name = "pnConnectionToolBar"
      Me.pnConnectionToolBar.Size = New System.Drawing.Size(176, 26)
      Me.pnConnectionToolBar.TabIndex = 9
      '
      'toolConnection
      '
      Me.toolConnection.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.toolConnection.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btConnect, Me.btSeparat3, Me.btDisconnect})
      Me.toolConnection.ButtonSize = New System.Drawing.Size(81, 22)
      Me.toolConnection.Divider = False
      Me.toolConnection.DropDownArrows = True
      Me.toolConnection.ImageList = Me.imageButtons
      Me.toolConnection.Name = "toolConnection"
      Me.toolConnection.ShowToolTips = True
      Me.toolConnection.Size = New System.Drawing.Size(176, 23)
      Me.toolConnection.TabIndex = 1
      Me.toolConnection.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      '
      'btConnect
      '
      Me.btConnect.ImageIndex = 0
      Me.btConnect.Text = "Connect"
      '
      'btSeparat3
      '
      Me.btSeparat3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'btDisconnect
      '
      Me.btDisconnect.Enabled = False
      Me.btDisconnect.ImageIndex = 1
      Me.btDisconnect.Text = "Disconnect"
      '
      'spVert
      '
      Me.spVert.Location = New System.Drawing.Point(176, 48)
      Me.spVert.MinExtra = 380
      Me.spVert.MinSize = 176
      Me.spVert.Name = "spVert"
      Me.spVert.Size = New System.Drawing.Size(3, 655)
      Me.spVert.TabIndex = 14
      Me.spVert.TabStop = False
      '
      'pnMain
      '
      Me.pnMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnSql, Me.pnDescription, Me.pnSource, Me.pnDemo})
      Me.pnMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnViewToolBar})
      Me.pnMain.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnMain.Location = New System.Drawing.Point(179, 48)
      Me.pnMain.Name = "pnMain"
      Me.pnMain.Size = New System.Drawing.Size(837, 655)
      Me.pnMain.TabIndex = 15
      '
      'pnSql
      '
      Me.pnSql.BackColor = System.Drawing.SystemColors.ControlDark
      Me.pnSql.Controls.AddRange(New System.Windows.Forms.Control() {Me.textSql, Me.pnSqlType})
      Me.pnSql.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnSql.Location = New System.Drawing.Point(0, 26)
      Me.pnSql.Name = "pnSql"
      Me.pnSql.Size = New System.Drawing.Size(837, 546)
      Me.pnSql.TabIndex = 28
      Me.pnSql.Visible = False
      '
      'textSql
      '
      Me.textSql.BackColor = System.Drawing.SystemColors.Window
      Me.textSql.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.textSql.Dock = System.Windows.Forms.DockStyle.Fill
      Me.textSql.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.textSql.Location = New System.Drawing.Point(0, 27)
      Me.textSql.Name = "textSql"
      Me.textSql.ReadOnly = True
      Me.textSql.Size = New System.Drawing.Size(837, 519)
      Me.textSql.TabIndex = 11
      Me.textSql.Text = ""
      Me.textSql.WordWrap = False
      '
      'pnSqlType
      '
      Me.pnSqlType.BackColor = System.Drawing.SystemColors.Control
      Me.pnSqlType.Controls.AddRange(New System.Windows.Forms.Control() {Me.toolSeparator1, Me.toolSqlType})
      Me.pnSqlType.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnSqlType.Name = "pnSqlType"
      Me.pnSqlType.Size = New System.Drawing.Size(837, 27)
      Me.pnSqlType.TabIndex = 10
      '
      'toolSeparator1
      '
      Me.toolSeparator1.DropDownArrows = True
      Me.toolSeparator1.Location = New System.Drawing.Point(0, 25)
      Me.toolSeparator1.Name = "toolSeparator1"
      Me.toolSeparator1.ShowToolTips = True
      Me.toolSeparator1.Size = New System.Drawing.Size(837, 39)
      Me.toolSeparator1.TabIndex = 12
      '
      'toolSqlType
      '
      Me.toolSqlType.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.toolSqlType.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btExecute, Me.btSeparator1, Me.btCreate, Me.btDrop})
      Me.toolSqlType.ButtonSize = New System.Drawing.Size(80, 22)
      Me.toolSqlType.DropDownArrows = True
      Me.toolSqlType.ImageList = Me.imageButtons
      Me.toolSqlType.Name = "toolSqlType"
      Me.toolSqlType.ShowToolTips = True
      Me.toolSqlType.Size = New System.Drawing.Size(837, 25)
      Me.toolSqlType.TabIndex = 11
      Me.toolSqlType.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      '
      'btExecute
      '
      Me.btExecute.ImageIndex = 7
      Me.btExecute.Text = "Execute DDL"
      '
      'btSeparator1
      '
      Me.btSeparator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'btCreate
      '
      Me.btCreate.ImageIndex = 8
      Me.btCreate.Pushed = True
      Me.btCreate.Text = "Create"
      '
      'btDrop
      '
      Me.btDrop.ImageIndex = 9
      Me.btDrop.Text = "Drop"
      '
      'pnDescription
      '
      Me.pnDescription.BackColor = System.Drawing.SystemColors.ControlDark
      Me.pnDescription.Controls.AddRange(New System.Windows.Forms.Control() {Me.webDescription})
      Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnDescription.Location = New System.Drawing.Point(0, 26)
      Me.pnDescription.Name = "pnDescription"
      Me.pnDescription.Size = New System.Drawing.Size(837, 546)
      Me.pnDescription.TabIndex = 27
      '
      'webDescription
      '
      Me.webDescription.CausesValidation = False
      Me.webDescription.ContainingControl = Me
      Me.webDescription.Dock = System.Windows.Forms.DockStyle.Fill
      Me.webDescription.Enabled = True
      Me.webDescription.OcxState = CType(resources.GetObject("webDescription.OcxState"), System.Windows.Forms.AxHost.State)
      Me.webDescription.Size = New System.Drawing.Size(837, 546)
      Me.webDescription.TabIndex = 2
      '
      'pnSource
      '
      Me.pnSource.BackColor = System.Drawing.SystemColors.ControlDark
      Me.pnSource.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbSource})
      Me.pnSource.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnSource.Location = New System.Drawing.Point(0, 26)
      Me.pnSource.Name = "pnSource"
      Me.pnSource.Size = New System.Drawing.Size(837, 546)
      Me.pnSource.TabIndex = 26
      Me.pnSource.Visible = False
      '
      'tbSource
      '
      Me.tbSource.BackColor = System.Drawing.SystemColors.Window
      Me.tbSource.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.tbSource.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tbSource.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.tbSource.Name = "tbSource"
      Me.tbSource.ReadOnly = True
      Me.tbSource.Size = New System.Drawing.Size(837, 546)
      Me.tbSource.TabIndex = 2
      Me.tbSource.Text = ""
      Me.tbSource.WordWrap = False
      '
      'pnDemo
      '
      Me.pnDemo.BackColor = System.Drawing.SystemColors.Control
      Me.pnDemo.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnDemo.Location = New System.Drawing.Point(0, 26)
      Me.pnDemo.Name = "pnDemo"
      Me.pnDemo.Size = New System.Drawing.Size(837, 546)
      Me.pnDemo.TabIndex = 25
      '
      'pnViewToolBar
      '
      Me.pnViewToolBar.Controls.AddRange(New System.Windows.Forms.Control() {Me.toolView})
      Me.pnViewToolBar.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnViewToolBar.Name = "pnViewToolBar"
      Me.pnViewToolBar.Size = New System.Drawing.Size(837, 26)
      Me.pnViewToolBar.TabIndex = 13
      '
      'toolView
      '
      Me.toolView.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.toolView.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btDemo, Me.btDescription, Me.btSource, Me.btSql, Me.btSeparator2})
      Me.toolView.Divider = False
      Me.toolView.DropDownArrows = True
      Me.toolView.ImageList = Me.imageButtons
      Me.toolView.Name = "toolView"
      Me.toolView.ShowToolTips = True
      Me.toolView.Size = New System.Drawing.Size(837, 23)
      Me.toolView.TabIndex = 13
      Me.toolView.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      '
      'btDemo
      '
      Me.btDemo.ImageIndex = 3
      Me.btDemo.Text = "Demo"
      '
      'btDescription
      '
      Me.btDescription.ImageIndex = 2
      Me.btDescription.Pushed = True
      Me.btDescription.Text = "Description"
      '
      'btSource
      '
      Me.btSource.ImageIndex = 4
      Me.btSource.Text = "Source"
      '
      'btSql
      '
      Me.btSql.ImageIndex = 5
      Me.btSql.Text = "DDL"
      '
      'btSeparator2
      '
      Me.btSeparator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'MainFormBase
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(1016, 725)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnMain, Me.spVert, Me.pnLeft, Me.statusBar, Me.pnDirect})
      Me.MinimumSize = New System.Drawing.Size(560, 358)
      Me.Name = "MainFormBase"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Samples title"
      Me.pnDirect.ResumeLayout(False)
      CType(Me.statusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.statusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.statusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnLeft.ResumeLayout(False)
      Me.pnSampleList.ResumeLayout(False)
      Me.pnNavigation.ResumeLayout(False)
      Me.pnConnectionToolBar.ResumeLayout(False)
      Me.pnMain.ResumeLayout(False)
      Me.pnSql.ResumeLayout(False)
      Me.pnSqlType.ResumeLayout(False)
      Me.pnDescription.ResumeLayout(False)
      CType(Me.webDescription, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnSource.ResumeLayout(False)
      Me.pnViewToolBar.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

    ' Properties
    Protected Property CatalogName() As String
      Get
        Return Me.fieldCatalogName
      End Get
      Set(ByVal value As String)
        Me.fieldCatalogName = value
      End Set
    End Property

    Protected WriteOnly Property CreateSqlText() As String
      Set(ByVal value As String)
        Me.fieldCreateSqlText = value
      End Set
    End Property

    Protected WriteOnly Property DropSqlText() As String
      Set(ByVal value As String)
        Me.fieldDropSqlText = value
      End Set
    End Property

    Protected WriteOnly Property Connection() As DbConnection
      Set(ByVal value As DbConnection)
        Me.fieldConnection = value
        AddHandler Me.fieldConnection.StateChange, New StateChangeEventHandler(AddressOf Me.connection_StateChange)
      End Set
    End Property


    ' Methods
    Private Sub MainFormBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  
      If Not DesignMode Then
        Me.baseWindowName = Me.Text
        Me.tvSampleList.Nodes(0).Text = Me.CatalogName
        Me.tvSampleList.Nodes(0).Tag = New DemoCatalog(Me.CatalogName, Me.samples)
        Me.tvSampleList.SelectedNode = Me.tvSampleList.Nodes(0)
        Me.tvSampleList.SelectedNode = Me.tvSampleList.Nodes(0)
        Me.tvSampleList.ExpandAll()
      End If
    End Sub

    Protected Overridable Sub CreateDemos()
    End Sub

    Private Sub CreateTreeNodes()
      Me.CreateDemos()
      Dim imageIndex As Integer = Me.imageTree.Images.Count
      Dim folder As Demo
      For Each folder In Me.samples
        Dim folderNode As New TreeNode(folder.Name, 1, 1)
        folderNode.Tag = folder
        Me.tvSampleList.Nodes.Item(0).Nodes.Add(folderNode)
        Dim info As Demo
        For Each info In DirectCast(folder, DemoCatalog).SampleList
          Dim node As New TreeNode(info.Name, 0, 0)
          node.Tag = info
          Dim imageName As String = info.ImageResourceName
          If (Not imageName = "") Then
            Dim imageStream As IO.Stream = Me.GetType.Assembly.GetManifestResourceStream(imageName)
            Me.imageTree.Images.Add(Image.FromStream(imageStream))
            node.SelectedImageIndex = imageIndex
            node.ImageIndex = imageIndex
            imageIndex = imageIndex + 1
          End If
          folderNode.Nodes.Add(node)
        Next
      Next
    End Sub

    Private Sub tvSampleList_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvSampleList.AfterSelect

      If ((e.Node.Parent Is Nothing) OrElse (e.Node.Parent Is Me.tvSampleList.Nodes.Item(0))) Then
        Me.btDemo.Enabled = False
        Me.btSource.Enabled = False

        Me.statusBar.Panels.Item(1).Text = ""
        Me.statusBar.Panels.Item(2).Text = ""

        Me.OnViewButton(Me.btDescription, False)
      Else
        Dim demo As demo = DirectCast(e.Node.Tag, demo)
        Me.OnViewButton(IIf((Me.lastButton Is Nothing), Me.btDemo, Me.lastButton))
        Me.Text = (Me.baseWindowName & " - " & demo.Name)
        Me.btDemo.Enabled = True
        Me.btSource.Enabled = True
      End If
      If Not Me.fromNavigate Then
        Me.history.Add(DirectCast(e.Node.Tag, demo))
      End If
      Me.fromNavigate = False
      Me.RefreshClientArea()
    End Sub

    Private Sub RefreshClientArea()
      Dim currentDemo As Demo = Me.GetCurrentDemo
      Me.statusBar.Panels.Item(1).Text = ""
      Me.statusBar.Panels.Item(2).Text = ""
      If Me.btDemo.Pushed Then
        Dim demos As BaseDemoControl = currentDemo.GetDemo(Me.fieldConnection, New WriteStatusHandler(AddressOf Me.OnWriteStatus))
        Try
          Me.pnDemo.Controls.Clear()
          demos.Parent = Me.pnDemo
        Catch
          Return
        End Try
        demos.Dock = DockStyle.Fill
        Me.OnWriteStatus(demos)
      ElseIf Me.btSource.Pushed Then
        Dim fullPath As String = currentDemo.CodeFileName
        If File.Exists(fullPath) Then
          Dim sr As StreamReader = New StreamReader(fullPath)
          Try
            Me.tbSource.Text = sr.ReadToEnd
          Finally
            sr.Close()
          End Try
        End If
      ElseIf Me.btSql.Pushed Then
        Me.textSql.Text = IIf(Me.btCreate.Pushed, currentDemo.CreateSql, currentDemo.DropSql)
        If (Me.textSql.Text = "") Then
          Me.textSql.Text = IIf(Me.btCreate.Pushed, Me.fieldCreateSqlText, Me.fieldDropSqlText)
        End If
      ElseIf Me.btDescription.Pushed Then
        Dim o As New Object()
        currentDemo.GenerateReadMe(Me.tempHtmlFile)
        Me.webDescription.Navigate(Me.tempHtmlFile, (o), (o), (o), (o))
      End If
    End Sub

    Private Function GetCurrentDemo() As Demo
      Return DirectCast(Me.tvSampleList.SelectedNode.Tag, Demo)
    End Function

    Protected Sub OnWriteStatus(ByVal control As BaseDemoControl)
      Me.statusBar.Panels.Item(1).Text = control.WriteStatus1
      Me.statusBar.Panels.Item(2).Text = control.WriteStatus2
    End Sub

    Private Sub OnViewButton(ByVal button As ToolBarButton)

      Me.OnViewButton(button, True)
    End Sub

    Private Sub OnViewButton(ByVal button As ToolBarButton, ByVal savePushedButton As Boolean)
        Dim newControl As Control = Nothing
        If (button Is Me.btDescription) Then
          newControl = Me.pnDescription
        ElseIf (button Is Me.btDemo) Then
          newControl = Me.pnDemo
        ElseIf (button Is Me.btSource) Then
          newControl = Me.pnSource
        ElseIf (button Is Me.btSql) Then
          newControl = Me.pnSql
        End If
        Me.PushOneButton(button)
        If savePushedButton Then
          Me.lastButton = button
        End If
        newControl.Visible = True
        newControl.BringToFront()
    End Sub

    Private Sub PushOneButton(ByVal button As ToolBarButton)
      Dim toolBar As toolBar = button.Parent
      Dim i As Integer = 0
      Do While ((i < toolBar.Buttons.Count) AndAlso (toolBar.Buttons.Item(i).Style <> ToolBarButtonStyle.Separator))
        toolBar.Buttons.Item(i).Pushed = False
        i = i + 1
      Loop
      button.Pushed = True
    End Sub

    Private Sub toolConnection_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles toolConnection.ButtonClick
      If (e.Button Is Me.btConnect) Then
        Dim connForm As ConnectForm = New ConnectForm(Me.fieldConnection)
        connForm.ShowDialog()
      Else
        Me.fieldConnection.Close()
      End If
    End Sub

    Private Sub OnThreadException(ByVal sender As Object, ByVal t As ThreadExceptionEventArgs)
      MessageBox.Show(t.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
    End Sub

    Private Sub connection_StateChange(ByVal sender As Object, ByVal e As StateChangeEventArgs)
      Me.statusBar.Panels.Item(0).Text = Me.fieldConnection.State.ToString
      Dim closed As Boolean = (Me.fieldConnection.State = ConnectionState.Closed)
      Me.btConnect.Enabled = closed
      Me.btDisconnect.Enabled = Not closed
    End Sub

    Private Function NodeByName(ByVal node As TreeNode, ByVal nodeName As String) As TreeNode
      If (String.Compare(node.Text, nodeName, True) = 0) Then
        Return node
      End If
      Dim currentNode As TreeNode
      For Each currentNode In node.Nodes
        Dim foundNode As TreeNode = Me.NodeByName(currentNode, nodeName)
        If (Not foundNode Is Nothing) Then
          Return foundNode
        End If
      Next
      Return Nothing
    End Function

    Private Sub webDescription_BeforeNavigate2(ByVal sender As Object, ByVal e As DWebBrowserEvents2_BeforeNavigate2Event) Handles webDescription.BeforeNavigate2
      Dim sampleName As String = DirectCast(sender, AxWebBrowser).LocationName
      If (Not sampleName = "sample") Then
        Me.tvSampleList.SelectedNode = Me.NodeByName(Me.tvSampleList.Nodes.Item(0), sampleName)
      End If
    End Sub

    Private Sub webDescription_NavigateComplete2(ByVal sender As Object, ByVal e As DWebBrowserEvents2_NavigateComplete2Event) Handles webDescription.NavigateComplete2
      Dim name As String = Path.GetFileNameWithoutExtension(e.uRL.ToString)
      If (Not name = "sample") Then
        Me.tvSampleList.SelectedNode = Me.NodeByName(Me.tvSampleList.Nodes.Item(0), name)
      End If
      RemoveHandler Me.webDescription.BeforeNavigate2, New DWebBrowserEvents2_BeforeNavigate2EventHandler(AddressOf Me.webDescription_BeforeNavigate2)
    End Sub

    Private Sub toolView_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles toolView.ButtonClick
      Me.OnViewButton(e.Button)
      Me.RefreshClientArea()
    End Sub

    Private Sub toolSqlType_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles toolSqlType.ButtonClick
      If (e.Button Is Me.btCreate) Then
        Me.textSql.Text = Me.GetCurrentDemo.CreateSql
        If (Me.textSql.Text = "") Then
          Me.textSql.Text = Me.fieldCreateSqlText
        End If
        Me.btCreate.Pushed = True
        Me.btDrop.Pushed = False
      ElseIf (e.Button Is Me.btDrop) Then
        Me.textSql.Text = Me.GetCurrentDemo.DropSql
        If (Me.textSql.Text = "") Then
          Me.textSql.Text = Me.fieldDropSqlText
        End If
        Me.btCreate.Pushed = False
        Me.btDrop.Pushed = True
        ElseIf (e.Button Is Me.btExecute) Then
          MessageBox.Show("Is not available for Express Edition.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If
    End Sub

    Private Sub toolNavigation_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles toolNavigation.ButtonClick
      Me.fromNavigate = True
      If (e.Button Is Me.btBack) Then
        Me.history.Back()
      Else
        Me.history.Forward()
      End If
      Me.MoveNavigate()
    End Sub

    Private Sub history_Click(ByVal sender As Object, ByVal e As EventArgs)
      Me.fromNavigate = True
      Dim i As Integer = (DirectCast(sender, MenuItem).Index + 1)
      If (Me.cmBack Is DirectCast(sender, MenuItem).Parent) Then
        Me.history.BackTo(i)
      Else
        Me.history.ForwardTo(i)
      End If
      Me.MoveNavigate()
    End Sub

    Private Sub MoveNavigate()
      Dim target As Demo = DirectCast(Me.history.Current, Demo)
      If (target Is Me.tvSampleList.Nodes.Item(0).Tag) Then
        Me.tvSampleList.SelectedNode = Me.tvSampleList.Nodes.Item(0)
      Else
        Me.tvSampleList.SelectedNode = Me.NodeByName(Me.tvSampleList.Nodes.Item(0), target.Name)
      End If
    End Sub

    Private Sub FillContextMenu(ByVal sender As history)
      Me.CleanMenu(Me.cmBack)
      Me.CleanMenu(Me.cmForward)
      Dim element As Demo
      For Each element In sender.BackList
        Me.cmBack.MenuItems.Add(0, New MenuItem(element.Name))
        AddHandler Me.cmBack.MenuItems.Item(0).Click, New EventHandler(AddressOf Me.history_Click)
      Next
      element = Nothing
      For Each element In sender.ForwardList
        Me.cmForward.MenuItems.Add(0, New MenuItem(element.Name))
        AddHandler Me.cmForward.MenuItems.Item(0).Click, New EventHandler(AddressOf Me.history_Click)
      Next
      Dim empty As Boolean = (Me.cmBack.MenuItems.Count = 0)
      Me.btBack.ImageIndex = IIf(empty, 1, 0)
      Me.btBack.Enabled = Not empty
      empty = (Me.cmForward.MenuItems.Count = 0)
      Me.btForward.ImageIndex = IIf(empty, 3, 2)
      Me.btForward.Enabled = Not empty
    End Sub

    Private Sub CleanMenu(ByVal menu As ContextMenu)
      Dim mi As MenuItem
      For Each mi In menu.MenuItems
        RemoveHandler mi.Click, New EventHandler(AddressOf Me.history_Click)
      Next
      menu.MenuItems.Clear()
    End Sub

    Private Sub linkAbout_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkAbout.LinkClicked
      Dim aboutF As AboutForm = New AboutForm()
      aboutF.ShowDialog()
    End Sub

    Private Sub MainFormBase_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
      If File.Exists(tempHtmlFile) Then
        File.Delete(tempHtmlFile)
      End If
    End Sub
  End Class
End Namespace
