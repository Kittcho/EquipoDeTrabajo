<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
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
    Me.label2 = New System.Windows.Forms.Label
    Me.label1 = New System.Windows.Forms.Label
    Me.cbQuery = New System.Windows.Forms.ComboBox
    Me.dataGridView = New System.Windows.Forms.DataGridView
    Me.statusBar = New System.Windows.Forms.StatusBar
    Me.btRetrieve = New System.Windows.Forms.Button
    Me.topPanel = New System.Windows.Forms.Panel
    CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.topPanel.SuspendLayout()
    Me.SuspendLayout()
    '
    'label2
    '
    Me.label2.AutoSize = True
    Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
    Me.label2.Location = New System.Drawing.Point(3, 29)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(516, 13)
    Me.label2.TabIndex = 4
    Me.label2.Text = "Note that you have to configure the connection string in the web service's web.co" & _
        "nfig file"
    '
    'label1
    '
    Me.label1.AutoSize = True
    Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
    Me.label1.Location = New System.Drawing.Point(3, 8)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(146, 13)
    Me.label1.TabIndex = 3
    Me.label1.Text = "Choose an appropriate query:"
    '
    'cbQuery
    '
    Me.cbQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cbQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbQuery.FormattingEnabled = True
    Me.cbQuery.Items.AddRange(New Object() {"all employees", "all departments", "employees having commission", "average salary by departments", "employees' hire by years", "employees' number by departments", "employees having no subordinates", "employees having subordinates and manager", "employees with minimal salary by departments", "seniority-salary trend"})
    Me.cbQuery.Location = New System.Drawing.Point(155, 5)
    Me.cbQuery.Name = "cbQuery"
    Me.cbQuery.Size = New System.Drawing.Size(303, 21)
    Me.cbQuery.TabIndex = 5
    '
    'dataGridView
    '
    Me.dataGridView.AllowUserToAddRows = False
    Me.dataGridView.AllowUserToDeleteRows = False
    Me.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dataGridView.Location = New System.Drawing.Point(0, 49)
    Me.dataGridView.Name = "dataGridView"
    Me.dataGridView.ReadOnly = True
    Me.dataGridView.Size = New System.Drawing.Size(542, 302)
    Me.dataGridView.TabIndex = 14
    '
    'statusBar
    '
    Me.statusBar.Location = New System.Drawing.Point(0, 351)
    Me.statusBar.Name = "statusBar"
    Me.statusBar.ShowPanels = True
    Me.statusBar.Size = New System.Drawing.Size(542, 22)
    Me.statusBar.TabIndex = 13
    Me.statusBar.Text = "statusBar1"
    '
    'btRetrieve
    '
    Me.btRetrieve.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btRetrieve.Enabled = False
    Me.btRetrieve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
    Me.btRetrieve.Location = New System.Drawing.Point(464, 3)
    Me.btRetrieve.Name = "btRetrieve"
    Me.btRetrieve.Size = New System.Drawing.Size(75, 23)
    Me.btRetrieve.TabIndex = 1
    Me.btRetrieve.Text = "Retrieve"
    Me.btRetrieve.UseVisualStyleBackColor = True
    '
    'topPanel
    '
    Me.topPanel.Controls.Add(Me.cbQuery)
    Me.topPanel.Controls.Add(Me.label2)
    Me.topPanel.Controls.Add(Me.label1)
    Me.topPanel.Controls.Add(Me.btRetrieve)
    Me.topPanel.Dock = System.Windows.Forms.DockStyle.Top
    Me.topPanel.Location = New System.Drawing.Point(0, 0)
    Me.topPanel.Name = "topPanel"
    Me.topPanel.Size = New System.Drawing.Size(542, 49)
    Me.topPanel.TabIndex = 12
    '
    'MainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(542, 373)
    Me.Controls.Add(Me.dataGridView)
    Me.Controls.Add(Me.statusBar)
    Me.Controls.Add(Me.topPanel)
    Me.Name = "MainForm"
    Me.Text = "dotConnect for PostgreSQL demo - Using Web Services"
    CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.topPanel.ResumeLayout(False)
    Me.topPanel.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents cbQuery As System.Windows.Forms.ComboBox
    Private WithEvents dataGridView As System.Windows.Forms.DataGridView
    Private WithEvents statusBar As System.Windows.Forms.StatusBar
    Private WithEvents btRetrieve As System.Windows.Forms.Button
    Private WithEvents topPanel As System.Windows.Forms.Panel

End Class
