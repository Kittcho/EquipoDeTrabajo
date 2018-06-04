namespace WinClient
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.btRetrieve = new System.Windows.Forms.Button();
      this.topPanel = new System.Windows.Forms.Panel();
      this.cbQuery = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.statusBar = new System.Windows.Forms.StatusBar();
      this.dataGridView = new System.Windows.Forms.DataGridView();
      this.topPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // btRetrieve
      // 
      this.btRetrieve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btRetrieve.Enabled = false;
      this.btRetrieve.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btRetrieve.Location = new System.Drawing.Point(464, 3);
      this.btRetrieve.Name = "btRetrieve";
      this.btRetrieve.Size = new System.Drawing.Size(75, 23);
      this.btRetrieve.TabIndex = 1;
      this.btRetrieve.Text = "Retrieve";
      this.btRetrieve.UseVisualStyleBackColor = true;
      this.btRetrieve.Click += new System.EventHandler(this.btRetrieve_Click);
      // 
      // topPanel
      // 
      this.topPanel.Controls.Add(this.cbQuery);
      this.topPanel.Controls.Add(this.label2);
      this.topPanel.Controls.Add(this.label1);
      this.topPanel.Controls.Add(this.btRetrieve);
      this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.topPanel.Location = new System.Drawing.Point(0, 0);
      this.topPanel.Name = "topPanel";
      this.topPanel.Size = new System.Drawing.Size(542, 49);
      this.topPanel.TabIndex = 9;
      // 
      // cbQuery
      // 
      this.cbQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbQuery.FormattingEnabled = true;
      this.cbQuery.Items.AddRange(new object[] {
            "all employees",
            "all departments",
            "employees having commission",
            "average salary by departments",
            "employees\' hire by years",
            "employees\' number by departments",
            "employees having no subordinates",
            "employees having subordinates and manager",
            "employees with minimal salary by departments",
            "seniority-salary trend"});
      this.cbQuery.Location = new System.Drawing.Point(155, 5);
      this.cbQuery.Name = "cbQuery";
      this.cbQuery.Size = new System.Drawing.Size(303, 21);
      this.cbQuery.TabIndex = 5;
      this.cbQuery.SelectedIndexChanged += new System.EventHandler(this.cbQuery_SelectedIndexChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(3, 29);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(516, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Note that you have to configure the connection string in the web service\'s web.co" +
          "nfig file";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(3, 8);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(146, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Choose an appropriate query:";
      // 
      // statusBar
      // 
      this.statusBar.Location = new System.Drawing.Point(0, 351);
      this.statusBar.Name = "statusBar";
      this.statusBar.ShowPanels = true;
      this.statusBar.Size = new System.Drawing.Size(542, 22);
      this.statusBar.TabIndex = 10;
      this.statusBar.Text = "statusBar1";
      // 
      // dataGridView
      // 
      this.dataGridView.AllowUserToAddRows = false;
      this.dataGridView.AllowUserToDeleteRows = false;
      this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView.Location = new System.Drawing.Point(0, 49);
      this.dataGridView.Name = "dataGridView";
      this.dataGridView.ReadOnly = true;
      this.dataGridView.Size = new System.Drawing.Size(542, 302);
      this.dataGridView.TabIndex = 11;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(542, 373);
      this.Controls.Add(this.dataGridView);
      this.Controls.Add(this.statusBar);
      this.Controls.Add(this.topPanel);
      this.Name = "MainForm";
      this.Text = "dotConnect for PostgreSQL demo - Using Web Services";
      this.topPanel.ResumeLayout(false);
      this.topPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btRetrieve;
    private System.Windows.Forms.Panel topPanel;
    private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ComboBox cbQuery;
      private System.Windows.Forms.StatusBar statusBar;
    private System.Windows.Forms.DataGridView dataGridView;
  }
}

