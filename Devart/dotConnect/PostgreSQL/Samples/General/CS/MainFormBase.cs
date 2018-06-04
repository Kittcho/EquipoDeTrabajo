using System;
using System.Data.Common;
using System.Windows.Forms;
using System.IO;
using mshtml;
using Devart.Common;

namespace Samples
{
  /// <summary>
  /// Summary description for MainFormBase.
  /// </summary>
  public class MainFormBase : System.Windows.Forms.Form
  {
    private System.Windows.Forms.StatusBar statusBar;
    private System.Windows.Forms.StatusBarPanel statusBarPanel1;
    private System.Windows.Forms.StatusBarPanel statusBarPanel2;
    private System.Windows.Forms.StatusBarPanel statusBarPanel3;
    private System.Windows.Forms.Splitter spVert;
    private System.ComponentModel.IContainer components;
    private System.Windows.Forms.TreeView tvSampleList;
    private System.Windows.Forms.Panel pnLeft;
    private System.Windows.Forms.Panel pnDirect;
    protected System.Windows.Forms.Label lbDirect;
    private System.Windows.Forms.LinkLabel linkAbout;
    private System.Windows.Forms.ToolBarButton btConnect;
    private System.Windows.Forms.ToolBarButton btDisconnect;
    private System.Windows.Forms.ToolBarButton btDescription;
    private System.Windows.Forms.ToolBarButton btDemo;
    private System.Windows.Forms.ToolBarButton btSource;
    private System.Windows.Forms.ToolBarButton btSql;
    private System.Windows.Forms.Panel pnMain;
    private System.Windows.Forms.Panel pnSampleList;
    private System.Windows.Forms.Panel pnConnectionToolBar;
    private System.Windows.Forms.Panel pnViewToolBar;
    private System.Windows.Forms.Panel pnNavigation;
    private System.Windows.Forms.ToolBarButton btBack;
    private System.Windows.Forms.ToolBarButton btForward;
    private System.Windows.Forms.Panel pnDemo;
    private System.Windows.Forms.Panel pnSource;
    private System.Windows.Forms.RichTextBox tbSource;
    private System.Windows.Forms.Panel pnDescription;
    private AxSHDocVw.AxWebBrowser webDescription;
    private System.Windows.Forms.Panel pnSql;
    private System.Windows.Forms.RichTextBox textSql;
    private System.Windows.Forms.ToolBarButton btExecute;
    private System.Windows.Forms.ToolBarButton btSeparator1;
    private System.Windows.Forms.ToolBarButton btSeparator2;
    private System.Windows.Forms.ToolBarButton btCreate;
    private System.Windows.Forms.ToolBarButton btDrop;
    private System.Windows.Forms.ImageList imageTree;
    private System.Windows.Forms.ImageList imageButtons;
    private System.Windows.Forms.ImageList imageArrows;
    private System.Windows.Forms.ContextMenu cmBack;
    private System.Windows.Forms.ContextMenu cmForward;
    private System.Windows.Forms.ToolBar toolConnection;
    private System.Windows.Forms.ToolBar toolNavigation;
    private System.Windows.Forms.ToolBar toolView;
    private System.Windows.Forms.ToolBar toolSqlType;
    private System.Windows.Forms.ToolBarButton btSeparat3;
    private System.Windows.Forms.Panel pnSqlType;
    private System.Windows.Forms.ToolBar toolSeparator1;
    private System.Windows.Forms.ToolBar toolSeparator2;

    private System.Windows.Forms.ToolBarButton lastButton = null;

    private string baseWindowName;
    private readonly string tempHtmlFile;
    private bool fromNavigate = false;

    protected System.Collections.ArrayList samples = new System.Collections.ArrayList(15);
    private History history = new History(10);

    private string createSqlText;
    private string dropSqlText;
    private string catalogName;

    private DbConnection connection;
    public MainFormBase() {

      Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(OnThreadException);
      history.HistoryChanged += new HistoryChangedHandler(this.FillContextMenu);
      tempHtmlFile = Path.Combine(Environment.CurrentDirectory, "sample.html");

      InitializeComponent();
    }

    public MainFormBase(string catalogName):this() {

      this.catalogName = catalogName;
      CreateTreeNodes();
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing ) {

      if( disposing ) {
        if (components != null) {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    protected virtual void CreateDemos() {
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainFormBase));
      this.pnLeft = new System.Windows.Forms.Panel();
      this.pnSampleList = new System.Windows.Forms.Panel();
      this.tvSampleList = new System.Windows.Forms.TreeView();
      this.imageTree = new System.Windows.Forms.ImageList(this.components);
      this.pnNavigation = new System.Windows.Forms.Panel();
      this.toolSeparator2 = new System.Windows.Forms.ToolBar();
      this.toolNavigation = new System.Windows.Forms.ToolBar();
      this.btBack = new System.Windows.Forms.ToolBarButton();
      this.cmBack = new System.Windows.Forms.ContextMenu();
      this.btForward = new System.Windows.Forms.ToolBarButton();
      this.cmForward = new System.Windows.Forms.ContextMenu();
      this.imageArrows = new System.Windows.Forms.ImageList(this.components);
      this.pnConnectionToolBar = new System.Windows.Forms.Panel();
      this.toolConnection = new System.Windows.Forms.ToolBar();
      this.btConnect = new System.Windows.Forms.ToolBarButton();
      this.btSeparat3 = new System.Windows.Forms.ToolBarButton();
      this.btDisconnect = new System.Windows.Forms.ToolBarButton();
      this.imageButtons = new System.Windows.Forms.ImageList(this.components);
      this.statusBar = new System.Windows.Forms.StatusBar();
      this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
      this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
      this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
      this.spVert = new System.Windows.Forms.Splitter();
      this.pnDirect = new System.Windows.Forms.Panel();
      this.linkAbout = new System.Windows.Forms.LinkLabel();
      this.lbDirect = new System.Windows.Forms.Label();
      this.pnMain = new System.Windows.Forms.Panel();
      this.pnSql = new System.Windows.Forms.Panel();
      this.textSql = new System.Windows.Forms.RichTextBox();
      this.pnSqlType = new System.Windows.Forms.Panel();
      this.toolSeparator1 = new System.Windows.Forms.ToolBar();
      this.toolSqlType = new System.Windows.Forms.ToolBar();
      this.btExecute = new System.Windows.Forms.ToolBarButton();
      this.btSeparator1 = new System.Windows.Forms.ToolBarButton();
      this.btCreate = new System.Windows.Forms.ToolBarButton();
      this.btDrop = new System.Windows.Forms.ToolBarButton();
      this.pnDescription = new System.Windows.Forms.Panel();
      this.webDescription = new AxSHDocVw.AxWebBrowser();
      this.pnSource = new System.Windows.Forms.Panel();
      this.tbSource = new System.Windows.Forms.RichTextBox();
      this.pnDemo = new System.Windows.Forms.Panel();
      this.pnViewToolBar = new System.Windows.Forms.Panel();
      this.toolView = new System.Windows.Forms.ToolBar();
      this.btDemo = new System.Windows.Forms.ToolBarButton();
      this.btDescription = new System.Windows.Forms.ToolBarButton();
      this.btSource = new System.Windows.Forms.ToolBarButton();
      this.btSql = new System.Windows.Forms.ToolBarButton();
      this.btSeparator2 = new System.Windows.Forms.ToolBarButton();
      this.pnLeft.SuspendLayout();
      this.pnSampleList.SuspendLayout();
      this.pnNavigation.SuspendLayout();
      this.pnConnectionToolBar.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
      this.pnDirect.SuspendLayout();
      this.pnMain.SuspendLayout();
      this.pnSql.SuspendLayout();
      this.pnSqlType.SuspendLayout();
      this.pnDescription.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.webDescription)).BeginInit();
      this.pnSource.SuspendLayout();
      this.pnViewToolBar.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnLeft
      // 
      this.pnLeft.AutoScroll = true;
      this.pnLeft.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                         this.pnSampleList,
                                                                         this.pnConnectionToolBar});
      this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnLeft.Location = new System.Drawing.Point(0, 48);
      this.pnLeft.Name = "pnLeft";
      this.pnLeft.Size = new System.Drawing.Size(176, 667);
      this.pnLeft.TabIndex = 0;
      // 
      // pnSampleList
      // 
      this.pnSampleList.BackColor = System.Drawing.SystemColors.ControlDark;
      this.pnSampleList.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                               this.tvSampleList,
                                                                               this.pnNavigation});
      this.pnSampleList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnSampleList.DockPadding.Bottom = 1;
      this.pnSampleList.DockPadding.Left = 1;
      this.pnSampleList.DockPadding.Right = 1;
      this.pnSampleList.Location = new System.Drawing.Point(0, 26);
      this.pnSampleList.Name = "pnSampleList";
      this.pnSampleList.Size = new System.Drawing.Size(176, 641);
      this.pnSampleList.TabIndex = 9;
      // 
      // tvSampleList
      // 
      this.tvSampleList.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tvSampleList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tvSampleList.HideSelection = false;
      this.tvSampleList.ImageList = this.imageTree;
      this.tvSampleList.Location = new System.Drawing.Point(1, 27);
      this.tvSampleList.Name = "tvSampleList";
      this.tvSampleList.Size = new System.Drawing.Size(174, 613);
      this.tvSampleList.TabIndex = 7;
      this.tvSampleList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSampleList_AfterSelect);
      // 
      // imageTree
      // 
      this.imageTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
      this.imageTree.ImageSize = new System.Drawing.Size(16, 16);
      this.imageTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageTree.ImageStream")));
      this.imageTree.TransparentColor = System.Drawing.Color.Magenta;
      // 
      // pnNavigation
      // 
      this.pnNavigation.BackColor = System.Drawing.SystemColors.Control;
      this.pnNavigation.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                               this.toolSeparator2,
                                                                               this.toolNavigation});
      this.pnNavigation.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnNavigation.Location = new System.Drawing.Point(1, 0);
      this.pnNavigation.Name = "pnNavigation";
      this.pnNavigation.Size = new System.Drawing.Size(174, 27);
      this.pnNavigation.TabIndex = 8;
      // 
      // toolSeparator2
      // 
      this.toolSeparator2.DropDownArrows = true;
      this.toolSeparator2.Location = new System.Drawing.Point(0, 25);
      this.toolSeparator2.Name = "toolSeparator2";
      this.toolSeparator2.ShowToolTips = true;
      this.toolSeparator2.Size = new System.Drawing.Size(174, 39);
      this.toolSeparator2.TabIndex = 12;
      // 
      // toolNavigation
      // 
      this.toolNavigation.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
      this.toolNavigation.AutoSize = false;
      this.toolNavigation.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                      this.btBack,
                                                                                      this.btForward});
      this.toolNavigation.ButtonSize = new System.Drawing.Size(23, 22);
      this.toolNavigation.DropDownArrows = true;
      this.toolNavigation.ImageList = this.imageArrows;
      this.toolNavigation.Name = "toolNavigation";
      this.toolNavigation.ShowToolTips = true;
      this.toolNavigation.Size = new System.Drawing.Size(174, 25);
      this.toolNavigation.TabIndex = 11;
      this.toolNavigation.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolNavigation_ButtonClick);
      // 
      // btBack
      // 
      this.btBack.DropDownMenu = this.cmBack;
      this.btBack.ImageIndex = 0;
      this.btBack.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
      // 
      // btForward
      // 
      this.btForward.DropDownMenu = this.cmForward;
      this.btForward.ImageIndex = 2;
      this.btForward.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
      // 
      // imageArrows
      // 
      this.imageArrows.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
      this.imageArrows.ImageSize = new System.Drawing.Size(17, 17);
      this.imageArrows.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageArrows.ImageStream")));
      this.imageArrows.TransparentColor = System.Drawing.Color.Magenta;
      // 
      // pnConnectionToolBar
      // 
      this.pnConnectionToolBar.BackColor = System.Drawing.SystemColors.Control;
      this.pnConnectionToolBar.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                      this.toolConnection});
      this.pnConnectionToolBar.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnConnectionToolBar.DockPadding.All = 2;
      this.pnConnectionToolBar.Name = "pnConnectionToolBar";
      this.pnConnectionToolBar.Size = new System.Drawing.Size(176, 26);
      this.pnConnectionToolBar.TabIndex = 8;
      // 
      // toolConnection
      // 
      this.toolConnection.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
      this.toolConnection.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                      this.btConnect,
                                                                                      this.btSeparat3,
                                                                                      this.btDisconnect});
      this.toolConnection.Divider = false;
      this.toolConnection.DropDownArrows = true;
      this.toolConnection.ImageList = this.imageButtons;
      this.toolConnection.Location = new System.Drawing.Point(2, 2);
      this.toolConnection.Name = "toolConnection";
      this.toolConnection.ShowToolTips = true;
      this.toolConnection.Size = new System.Drawing.Size(172, 23);
      this.toolConnection.TabIndex = 0;
      this.toolConnection.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
      this.toolConnection.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolConnection_ButtonClick);
      // 
      // btConnect
      // 
      this.btConnect.ImageIndex = 0;
      this.btConnect.Text = "Connect";
      // 
      // btSeparat3
      // 
      this.btSeparat3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
      // 
      // btDisconnect
      // 
      this.btDisconnect.Enabled = false;
      this.btDisconnect.ImageIndex = 1;
      this.btDisconnect.Text = "Disconnect";
      // 
      // imageButtons
      // 
      this.imageButtons.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
      this.imageButtons.ImageSize = new System.Drawing.Size(16, 16);
      this.imageButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageButtons.ImageStream")));
      this.imageButtons.TransparentColor = System.Drawing.Color.Magenta;
      // 
      // statusBar
      // 
      this.statusBar.Location = new System.Drawing.Point(0, 715);
      this.statusBar.Name = "statusBar";
      this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
                                                                                 this.statusBarPanel1,
                                                                                 this.statusBarPanel2,
                                                                                 this.statusBarPanel3});
      this.statusBar.ShowPanels = true;
      this.statusBar.Size = new System.Drawing.Size(1016, 22);
      this.statusBar.TabIndex = 5;
      // 
      // statusBarPanel1
      // 
      this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
      this.statusBarPanel1.Width = 333;
      // 
      // statusBarPanel2
      // 
      this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
      this.statusBarPanel2.Width = 333;
      // 
      // statusBarPanel3
      // 
      this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
      this.statusBarPanel3.Width = 333;
      // 
      // spVert
      // 
      this.spVert.Location = new System.Drawing.Point(176, 48);
      this.spVert.MinExtra = 380;
      this.spVert.MinSize = 176;
      this.spVert.Name = "spVert";
      this.spVert.Size = new System.Drawing.Size(3, 667);
      this.spVert.TabIndex = 7;
      this.spVert.TabStop = false;
      // 
      // pnDirect
      // 
      this.pnDirect.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
      this.pnDirect.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.linkAbout,
                                                                           this.lbDirect});
      this.pnDirect.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnDirect.Name = "pnDirect";
      this.pnDirect.Size = new System.Drawing.Size(1016, 48);
      this.pnDirect.TabIndex = 10;
      // 
      // linkAbout
      // 
      this.linkAbout.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.linkAbout.AutoSize = true;
      this.linkAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
      this.linkAbout.LinkColor = System.Drawing.Color.White;
      this.linkAbout.Location = new System.Drawing.Point(949, 14);
      this.linkAbout.Name = "linkAbout";
      this.linkAbout.Size = new System.Drawing.Size(41, 16);
      this.linkAbout.TabIndex = 1;
      this.linkAbout.TabStop = true;
      this.linkAbout.Text = "About";
      this.linkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAbout_LinkClicked);
      // 
      // lbDirect
      // 
      this.lbDirect.AutoSize = true;
      this.lbDirect.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
      this.lbDirect.ForeColor = System.Drawing.Color.White;
      this.lbDirect.Name = "lbDirect";
      this.lbDirect.Size = new System.Drawing.Size(0, 43);
      this.lbDirect.TabIndex = 0;
      // 
      // pnMain
      // 
      this.pnMain.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                         this.pnSql,
                                                                         this.pnDescription,
                                                                         this.pnSource,
                                                                         this.pnDemo,
                                                                         this.pnViewToolBar});
      this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnMain.Location = new System.Drawing.Point(179, 48);
      this.pnMain.Name = "pnMain";
      this.pnMain.Size = new System.Drawing.Size(837, 667);
      this.pnMain.TabIndex = 12;
      // 
      // pnSql
      // 
      this.pnSql.BackColor = System.Drawing.SystemColors.ControlDark;
      this.pnSql.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                        this.textSql,
                                                                        this.pnSqlType});
      this.pnSql.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnSql.DockPadding.Bottom = 1;
      this.pnSql.DockPadding.Left = 1;
      this.pnSql.DockPadding.Right = 1;
      this.pnSql.Location = new System.Drawing.Point(0, 26);
      this.pnSql.Name = "pnSql";
      this.pnSql.Size = new System.Drawing.Size(837, 558);
      this.pnSql.TabIndex = 27;
      this.pnSql.Visible = false;
      // 
      // textSql
      // 
      this.textSql.BackColor = System.Drawing.SystemColors.Window;
      this.textSql.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textSql.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textSql.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
      this.textSql.Location = new System.Drawing.Point(1, 27);
      this.textSql.Name = "textSql";
      this.textSql.ReadOnly = true;
      this.textSql.Size = new System.Drawing.Size(835, 530);
      this.textSql.TabIndex = 9;
      this.textSql.Text = "";
      this.textSql.WordWrap = false;
      // 
      // pnSqlType
      // 
      this.pnSqlType.BackColor = System.Drawing.SystemColors.Control;
      this.pnSqlType.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.toolSeparator1,
                                                                            this.toolSqlType});
      this.pnSqlType.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnSqlType.Location = new System.Drawing.Point(1, 0);
      this.pnSqlType.Name = "pnSqlType";
      this.pnSqlType.Size = new System.Drawing.Size(835, 27);
      this.pnSqlType.TabIndex = 10;
      // 
      // toolSeparator1
      // 
      this.toolSeparator1.DropDownArrows = true;
      this.toolSeparator1.Location = new System.Drawing.Point(0, 25);
      this.toolSeparator1.Name = "toolSeparator1";
      this.toolSeparator1.ShowToolTips = true;
      this.toolSeparator1.Size = new System.Drawing.Size(835, 39);
      this.toolSeparator1.TabIndex = 12;
      // 
      // toolSqlType
      // 
      this.toolSqlType.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
      this.toolSqlType.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                   this.btExecute,
                                                                                   this.btSeparator1,
                                                                                   this.btCreate,
                                                                                   this.btDrop});
      this.toolSqlType.ButtonSize = new System.Drawing.Size(80, 22);
      this.toolSqlType.DropDownArrows = true;
      this.toolSqlType.ImageList = this.imageButtons;
      this.toolSqlType.Name = "toolSqlType";
      this.toolSqlType.ShowToolTips = true;
      this.toolSqlType.Size = new System.Drawing.Size(835, 25);
      this.toolSqlType.TabIndex = 11;
      this.toolSqlType.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
      this.toolSqlType.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolSqlType_ButtonClick);
      // 
      // btExecute
      // 
      this.btExecute.ImageIndex = 7;
      this.btExecute.Text = "Execute DDL";
      // 
      // btSeparator1
      // 
      this.btSeparator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
      // 
      // btCreate
      // 
      this.btCreate.ImageIndex = 8;
      this.btCreate.Pushed = true;
      this.btCreate.Text = "Create";
      // 
      // btDrop
      // 
      this.btDrop.ImageIndex = 9;
      this.btDrop.Text = "Drop";
      // 
      // pnDescription
      // 
      this.pnDescription.BackColor = System.Drawing.SystemColors.ControlDark;
      this.pnDescription.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.webDescription});
      this.pnDescription.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnDescription.DockPadding.All = 1;
      this.pnDescription.Location = new System.Drawing.Point(0, 26);
      this.pnDescription.Name = "pnDescription";
      this.pnDescription.Size = new System.Drawing.Size(837, 558);
      this.pnDescription.TabIndex = 26;
      // 
      // webDescription
      // 
      this.webDescription.CausesValidation = false;
      this.webDescription.ContainingControl = this;
      this.webDescription.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webDescription.Enabled = true;
      this.webDescription.Location = new System.Drawing.Point(1, 1);
      this.webDescription.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("webDescription.OcxState")));
      this.webDescription.Size = new System.Drawing.Size(835, 556);
      this.webDescription.TabIndex = 1;
      this.webDescription.NavigateComplete2 += new AxSHDocVw.DWebBrowserEvents2_NavigateComplete2EventHandler(this.webDescription_NavigateComplete2);
      this.webDescription.BeforeNavigate2 += new AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(this.webDescription_BeforeNavigate2);
      // 
      // pnSource
      // 
      this.pnSource.BackColor = System.Drawing.SystemColors.ControlDark;
      this.pnSource.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.tbSource});
      this.pnSource.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnSource.DockPadding.All = 1;
      this.pnSource.Location = new System.Drawing.Point(0, 26);
      this.pnSource.Name = "pnSource";
      this.pnSource.Size = new System.Drawing.Size(837, 558);
      this.pnSource.TabIndex = 25;
      this.pnSource.Visible = false;
      // 
      // tbSource
      // 
      this.tbSource.BackColor = System.Drawing.SystemColors.Window;
      this.tbSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbSource.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbSource.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
      this.tbSource.Location = new System.Drawing.Point(1, 1);
      this.tbSource.Name = "tbSource";
      this.tbSource.ReadOnly = true;
      this.tbSource.Size = new System.Drawing.Size(835, 556);
      this.tbSource.TabIndex = 1;
      this.tbSource.Text = "";
      this.tbSource.WordWrap = false;
      // 
      // pnDemo
      // 
      this.pnDemo.BackColor = System.Drawing.SystemColors.Control;
      this.pnDemo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnDemo.Location = new System.Drawing.Point(0, 26);
      this.pnDemo.Name = "pnDemo";
      this.pnDemo.Size = new System.Drawing.Size(837, 558);
      this.pnDemo.TabIndex = 24;
      // 
      // pnViewToolBar
      // 
      this.pnViewToolBar.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.toolView});
      this.pnViewToolBar.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnViewToolBar.DockPadding.All = 2;
      this.pnViewToolBar.Name = "pnViewToolBar";
      this.pnViewToolBar.Size = new System.Drawing.Size(837, 26);
      this.pnViewToolBar.TabIndex = 13;
      // 
      // toolView
      // 
      this.toolView.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
      this.toolView.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                this.btDemo,
                                                                                this.btDescription,
                                                                                this.btSource,
                                                                                this.btSql,
                                                                                this.btSeparator2
      });
      this.toolView.Divider = false;
      this.toolView.DropDownArrows = true;
      this.toolView.ImageList = this.imageButtons;
      this.toolView.Location = new System.Drawing.Point(2, 2);
      this.toolView.Name = "toolView";
      this.toolView.ShowToolTips = true;
      this.toolView.Size = new System.Drawing.Size(833, 23);
      this.toolView.TabIndex = 13;
      this.toolView.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
      this.toolView.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolView_ButtonClick);
      // 
      // btDemo
      // 
      this.btDemo.ImageIndex = 3;
      this.btDemo.Text = "Demo";
      // 
      // btDescription
      // 
      this.btDescription.ImageIndex = 2;
      this.btDescription.Pushed = true;
      this.btDescription.Text = "Description";
      // 
      // btSource
      // 
      this.btSource.ImageIndex = 4;
      this.btSource.Text = "Source";
      // 
      // btSql
      // 
      this.btSql.ImageIndex = 5;
      this.btSql.Text = "DDL";
      // 
      // btSeparator2
      // 
      this.btSeparator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
      // 
      // MainFormBase
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(1016, 737);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.pnMain,
                                                                  this.spVert,
                                                                  this.pnLeft,
                                                                  this.pnDirect,
                                                                  this.statusBar});
      this.MinimumSize = new System.Drawing.Size(620, 358);
      this.Name = "MainFormBase";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Samples title";
      this.Load += new System.EventHandler(this.MainFormBase_Load);
      this.Closed += new EventHandler(this.MainFormBase_FormClosed);
      this.pnLeft.ResumeLayout(false);
      this.pnSampleList.ResumeLayout(false);
      this.pnNavigation.ResumeLayout(false);
      this.pnConnectionToolBar.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
      this.pnDirect.ResumeLayout(false);
      this.pnMain.ResumeLayout(false);
      this.pnSql.ResumeLayout(false);
      this.pnSqlType.ResumeLayout(false);
      this.pnDescription.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.webDescription)).EndInit();
      this.pnSource.ResumeLayout(false);
      this.pnViewToolBar.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    #endregion

    private void MainFormBase_Load(object sender, System.EventArgs e) {

      if (!DesignMode) {
        baseWindowName = this.Text;
        tvSampleList.SelectedNode = tvSampleList.Nodes[0];
        tvSampleList.ExpandAll();
      }
    }

    private void OnThreadException(object sender, System.Threading.ThreadExceptionEventArgs t) {

      MessageBox.Show(t.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void CreateTreeNodes() {

      tvSampleList.Nodes.Add(new TreeNode(catalogName, 1, 1));
      tvSampleList.Nodes[0].Tag = new DemoCatalog(catalogName, samples);

      CreateDemos();

      int imageIndex = imageTree.Images.Count;

      foreach (Demo folder in samples) {

        TreeNode folderNode = new TreeNode(folder.Name, 1, 1);
        folderNode.Tag = folder;
        tvSampleList.Nodes[0].Nodes.Add(folderNode);

        foreach(Demo info in ((DemoCatalog)folder).SampleList) {

          TreeNode node = new TreeNode(info.Name, 0, 0);
          node.Tag = info;

          string imageName = info.ImageResourceName;

          if (imageName != "") {
            Stream imageStream = this.GetType().Assembly.GetManifestResourceStream(imageName);
            imageTree.Images.Add(System.Drawing.Bitmap.FromStream(imageStream));
            node.SelectedImageIndex = node.ImageIndex = imageIndex++;
          }

          folderNode.Nodes.Add(node);
        }
      }
    }

    private void toolConnection_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e) {

      if (e.Button == btConnect)
        (new ConnectForm(connection)).ShowDialog();
      else
        connection.Close();
    }

    private void connection_StateChange(object sender, System.Data.StateChangeEventArgs e) {

      statusBar.Panels[0].Text = connection.State.ToString();

      bool closed = (connection.State == System.Data.ConnectionState.Closed);
      this.btConnect.Enabled = closed;
      this.btDisconnect.Enabled = !closed;
    }

    private void linkAbout_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {

      (new AboutForm()).ShowDialog();
    }

    private Demo GetCurrentDemo() {

      return (Demo)tvSampleList.SelectedNode.Tag;
    }

    private void tvSampleList_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {

      if (e.Node.Parent == null || e.Node.Parent == tvSampleList.Nodes[0]) {

        this.btDemo.Enabled = false;
        this.btSource.Enabled = false;

        statusBar.Panels[1].Text = "";
        statusBar.Panels[2].Text = "";

        OnViewButton(btDescription, false);
      }
      else {                      //not root node
        Demo demo = (Demo)e.Node.Tag;
        OnViewButton(lastButton == null ? btDemo : lastButton);
        this.Text = baseWindowName + " - " + demo.Name;
        this.btDemo.Enabled = true;
        this.btSource.Enabled = true;
      }

      if (!fromNavigate)
        history.Add((Demo)e.Node.Tag);
      fromNavigate = false;

      this.RefreshClientArea();
    }

    private void RefreshClientArea() {

      Demo currentDemo = GetCurrentDemo();

      statusBar.Panels[1].Text = "";
      statusBar.Panels[2].Text = "";

      //what button is pushed?
      if (btDemo.Pushed) {
        BaseDemoControl demos = currentDemo.GetDemo(connection, new WriteStatusHandler(OnWriteStatus));
        this.pnDemo.Controls.Clear();
        demos.Parent = this.pnDemo;
        demos.Dock = System.Windows.Forms.DockStyle.Fill;
        OnWriteStatus(demos);
      }
      else if (btSource.Pushed) {
        string fullPath = currentDemo.CodeFileName;
        if (File.Exists(fullPath)) {
          using (StreamReader sr = new StreamReader(fullPath)) {
            tbSource.Text = sr.ReadToEnd();
          }
        }
      }
      else if (btSql.Pushed) {
        textSql.Text = (btCreate.Pushed ? currentDemo.CreateSql : currentDemo.DropSql);
        if (textSql.Text == "")
          textSql.Text = (btCreate.Pushed ? createSqlText : dropSqlText);
      }
      else if (btDescription.Pushed) {
        object o = new Object();
        currentDemo.GenerateReadMe(tempHtmlFile);
        webDescription.Navigate(tempHtmlFile, ref o, ref o, ref o, ref o);
      }
    }

    private TreeNode NodeByName(TreeNode node, string nodeName){

      if (String.Compare(node.Text, nodeName, true) == 0)
        return node;

      foreach(TreeNode currentNode in node.Nodes) {
        TreeNode foundNode = NodeByName(currentNode, nodeName);
        if (foundNode != null)
          return foundNode;
      }

      return null;
    }

    private void webDescription_NavigateComplete2(object sender, AxSHDocVw.DWebBrowserEvents2_NavigateComplete2Event e) {

      string sampleName = ((AxSHDocVw.AxWebBrowser)sender).LocationName;
      if (sampleName != "sample")
        tvSampleList.SelectedNode = NodeByName(tvSampleList.Nodes[0], sampleName);
    }

    private void webDescription_BeforeNavigate2(object sender, AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2Event e) {

      string name = Path.GetFileNameWithoutExtension(e.uRL.ToString());
      if (name != "sample")
        tvSampleList.SelectedNode = NodeByName(tvSampleList.Nodes[0], name);
      webDescription.NavigateComplete2 -= new AxSHDocVw.DWebBrowserEvents2_NavigateComplete2EventHandler(webDescription_NavigateComplete2);
    }

    private void toolView_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e) {

      OnViewButton(e.Button);
      RefreshClientArea();
    }

    private void OnViewButton(ToolBarButton button) {

      OnViewButton(button, true);
    }

    private void OnViewButton(ToolBarButton button, bool savePushedButton) {

      Control newControl = null;

      if (button == btDescription)
        newControl = pnDescription;
      else if (button == btDemo)
        newControl = pnDemo;
      else if (button == btSource)
        newControl = pnSource;
      else if (button == btSql)
        newControl = pnSql;

      PushOneButton(button);

      if (savePushedButton)
        lastButton = button;
      
      newControl.Visible = true;
      newControl.BringToFront();
    }

    private void PushOneButton(ToolBarButton button) {

      ToolBar toolBar = button.Parent;

      for (int i = 0; i < toolBar.Buttons.Count && toolBar.Buttons[i].Style != ToolBarButtonStyle.Separator; i++)
        toolBar.Buttons[i].Pushed = false;

      button.Pushed = true;
    }

    private void toolSqlType_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e) {

      if (e.Button == btCreate) {
        textSql.Text = GetCurrentDemo().CreateSql;
        if (textSql.Text == "")
          textSql.Text = createSqlText;

        btCreate.Pushed = true;
        btDrop.Pushed = false;
      }
      else if (e.Button == btDrop) {
        textSql.Text = GetCurrentDemo().DropSql;
        if (textSql.Text == "")
          textSql.Text = dropSqlText;

        btCreate.Pushed = false;
        btDrop.Pushed = true;
      }
      else if (e.Button == btExecute)
        MessageBox.Show("Is not available for Express Edition.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    protected void OnWriteStatus(BaseDemoControl control) {

      statusBar.Panels[1].Text = control.WriteStatus1;
      statusBar.Panels[2].Text = control.WriteStatus2;
    }


    #region History navigation

    private void toolNavigation_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e) {

      fromNavigate = true;

      if (e.Button == btBack)
        history.Back();
      else
        history.Forward();

      MoveNavigate();
    }

    private void history_Click(object sender, System.EventArgs e) {

      fromNavigate = true;

      int i = ((MenuItem)sender).Index + 1;

      if (cmBack == ((MenuItem)sender).Parent)
        history.BackTo(i);
      else
        history.ForwardTo(i);

      MoveNavigate();
    }

    private void MoveNavigate () {

      Demo target = (Demo)history.Current;
      if (target == tvSampleList.Nodes[0].Tag)
        tvSampleList.SelectedNode = tvSampleList.Nodes[0];
      else
        tvSampleList.SelectedNode = NodeByName(tvSampleList.Nodes[0], target.Name);
    }

    private void FillContextMenu(History sender) {

      CleanMenu(cmBack);
      CleanMenu(cmForward);

      foreach (Demo element in sender.BackList) {
        cmBack.MenuItems.Add(0, new MenuItem(element.Name));
        cmBack.MenuItems[0].Click += new System.EventHandler(this.history_Click);
      }

      foreach (Demo element in sender.ForwardList) {
        cmForward.MenuItems.Add(0, new MenuItem(element.Name));
        cmForward.MenuItems[0].Click += new System.EventHandler(this.history_Click);
      }

      bool empty = (cmBack.MenuItems.Count == 0);
      btBack.ImageIndex = (empty ? 1 : 0);;
      btBack.Enabled = !empty;

      empty = (cmForward.MenuItems.Count == 0);
      btForward.ImageIndex = (empty ? 3 : 2);
      btForward.Enabled = !empty;
    }

    private void CleanMenu(ContextMenu menu) {

      foreach (MenuItem mi in menu.MenuItems)
        mi.Click -= new System.EventHandler(this.history_Click);

      menu.MenuItems.Clear();
    }

    #endregion
    protected string CreateSqlText {
      set {
        createSqlText = value;
      }
    }

    protected string DropSqlText {
      set {
        dropSqlText = value;
      }
    }

    protected string CatalogName {
      get {
        return catalogName;
      }
      set {
        catalogName = value;
      }
    }

    protected DbConnection Connection {
      set {
        connection = value;
        connection.StateChange += new System.Data.StateChangeEventHandler(this.connection_StateChange);
      }
    }
    private void MainFormBase_FormClosed(object sender, EventArgs e) {

      if (File.Exists(tempHtmlFile))
        File.Delete(tempHtmlFile);
    }
  }
}
