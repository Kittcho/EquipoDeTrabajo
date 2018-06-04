using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Samples {

  /// <summary>
  /// Summary description for AboutForm.
  /// </summary>
  internal class AboutForm : System.Windows.Forms.Form {

    private System.Windows.Forms.Button btClose;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lbVersion;
    private System.Windows.Forms.LinkLabel lbWeb;
    private System.Windows.Forms.LinkLabel lbMail;
    private System.Windows.Forms.Label lbDbMonitor;
    private System.Windows.Forms.Label lbDbMonitorVer;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pbBevel;
    private System.Windows.Forms.Label lbEdition;
    private System.Windows.Forms.PictureBox pictureBox1;

    private IServiceProvider serviceProvider;

    private const string sNotAvailable = "not available";
    private System.Windows.Forms.Label lblBeta;
    private const string sNotSupported = "not supported";
    private const string sSupported = "supported";

    public AboutForm() {

      InitializeComponent();

      lbDbMonitorVer.Text = sNotSupported;

      lbEdition.Text = "Express Edition";
	
	lbVersion.Text = Devart.Data.PostgreSql.ProductInfo.Version;
      lbWeb.Links.Add(0, lbWeb.Text.Length, "http://www.devart.com/dotconnect/postgresql");
      lbMail.Links.Add(0, lbMail.Text.Length, "mailto:support@devart.com");
    }

    internal IServiceProvider ServiceProvider {
      get {
        return serviceProvider;
      }
      set {
        serviceProvider = value;
      }
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing ) {

      if( disposing ) {
        if(components != null) {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AboutForm));
      this.btClose = new System.Windows.Forms.Button();
      this.lbWeb = new System.Windows.Forms.LinkLabel();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.lbMail = new System.Windows.Forms.LinkLabel();
      this.label5 = new System.Windows.Forms.Label();
      this.lbVersion = new System.Windows.Forms.Label();
      this.lbDbMonitor = new System.Windows.Forms.Label();
      this.lbDbMonitorVer = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lbEdition = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.pbBevel = new System.Windows.Forms.PictureBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.lblBeta = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btClose
      // 
      this.btClose.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btClose.Location = new System.Drawing.Point(288, 208);
      this.btClose.Name = "btClose";
      this.btClose.Size = new System.Drawing.Size(75, 25);
      this.btClose.TabIndex = 0;
      this.btClose.Text = "Close";
      // 
      // lbWeb
      // 
      this.lbWeb.AutoSize = true;
      this.lbWeb.Location = new System.Drawing.Point(152, 123);
      this.lbWeb.Name = "lbWeb";
      this.lbWeb.Size = new System.Drawing.Size(128, 14);
      this.lbWeb.TabIndex = 1;
      this.lbWeb.TabStop = true;
      this.lbWeb.Text = "www.devart.com/dotconnect/postgresql";
      this.lbWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbWeb_LinkClicked);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(24, 99);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(272, 14);
      this.label2.TabIndex = 3;
      this.label2.Text = "Copyright (c) 2002-2018 Devart. All rights reserved.";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(24, 123);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(31, 14);
      this.label3.TabIndex = 4;
      this.label3.Text = "Web:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(24, 147);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(39, 14);
      this.label4.TabIndex = 5;
      this.label4.Text = "E-mail:";
      // 
      // lbMail
      // 
      this.lbMail.AutoSize = true;
      this.lbMail.Location = new System.Drawing.Point(152, 147);
      this.lbMail.Name = "lbMail";
      this.lbMail.Size = new System.Drawing.Size(105, 14);
      this.lbMail.TabIndex = 6;
      this.lbMail.TabStop = true;
      this.lbMail.Text = "support@devart.com";
      this.lbMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbMail_LinkClicked);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(24, 75);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 14);
      this.label5.TabIndex = 7;
      this.label5.Text = "Version";
      // 
      // lbVersion
      // 
      this.lbVersion.AutoSize = true;
      this.lbVersion.ForeColor = System.Drawing.Color.Navy;
      this.lbVersion.Location = new System.Drawing.Point(152, 75);
      this.lbVersion.Name = "lbVersion";
      this.lbVersion.Size = new System.Drawing.Size(39, 14);
      this.lbVersion.TabIndex = 8;
      this.lbVersion.Text = "1.0.2.0";
      // 
      // lbDbMonitor
      // 
      this.lbDbMonitor.AutoSize = true;
      this.lbDbMonitor.Location = new System.Drawing.Point(24, 171);
      this.lbDbMonitor.Name = "lbDbMonitor";
      this.lbDbMonitor.Size = new System.Drawing.Size(60, 14);
      this.lbDbMonitor.TabIndex = 9;
      this.lbDbMonitor.Text = "DBMonitor:";
      // 
      // lbDbMonitorVer
      // 
      this.lbDbMonitorVer.AutoSize = true;
      this.lbDbMonitorVer.ForeColor = System.Drawing.Color.Navy;
      this.lbDbMonitorVer.Location = new System.Drawing.Point(152, 171);
      this.lbDbMonitorVer.Name = "lbDbMonitorVer";
      this.lbDbMonitorVer.Size = new System.Drawing.Size(58, 14);
      this.lbDbMonitorVer.TabIndex = 10;
      this.lbDbMonitorVer.Text = "supported.";
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                         this.lbEdition,
                                                                         this.label1});
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(370, 63);
      this.panel1.TabIndex = 11;
      // 
      // lbEdition
      // 
      this.lbEdition.AutoSize = true;
      this.lbEdition.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
      this.lbEdition.ForeColor = System.Drawing.Color.Navy;
      this.lbEdition.Location = new System.Drawing.Point(37, 38);
      this.lbEdition.Name = "lbEdition";
      this.lbEdition.Size = new System.Drawing.Size(126, 17);
      this.lbEdition.TabIndex = 4;
      this.lbEdition.Text = "Professional Edition";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
      this.label1.ForeColor = System.Drawing.Color.Navy;
      this.label1.Location = new System.Drawing.Point(4, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(372, 23);
      this.label1.TabIndex = 3;
      this.label1.Text = "dotConnect for PostgreSQL";
      // 
      // pbBevel
      // 
      this.pbBevel.Image = ((System.Drawing.Bitmap)(resources.GetObject("pbBevel.Image")));
      this.pbBevel.Location = new System.Drawing.Point(0, 196);
      this.pbBevel.Name = "pbBevel";
      this.pbBevel.Size = new System.Drawing.Size(368, 8);
      this.pbBevel.TabIndex = 12;
      this.pbBevel.TabStop = false;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(0, 63);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(360, 8);
      this.pictureBox1.TabIndex = 13;
      this.pictureBox1.TabStop = false;
      // 
      // lblBeta
      // 
      this.lblBeta.AutoSize = true;
      this.lblBeta.Location = new System.Drawing.Point(208, 75);
      this.lblBeta.Name = "lblBeta";
      this.lblBeta.Size = new System.Drawing.Size(0, 14);
      this.lblBeta.TabIndex = 17;
      // 
      // AboutForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
      this.ClientSize = new System.Drawing.Size(370, 239);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.lblBeta,
                                                                  this.lbDbMonitor,
                                                                  this.label5,
                                                                  this.label4,
                                                                  this.label3,
                                                                  this.label2,
                                                                  this.lbDbMonitorVer,
                                                                  this.lbVersion,
                                                                  this.lbMail,
                                                                  this.lbWeb,
                                                                  this.btClose,
                                                                  this.panel1,
                                                                  this.pictureBox1,
                                                                  this.pbBevel});
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "About dotConnect for PostgreSQL";
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    #endregion

    private void lbWeb_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {

      Process.Start(e.Link.LinkData.ToString());
    }

    private void lbMail_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {

      Process.Start(e.Link.LinkData.ToString());
    }
  }
}
