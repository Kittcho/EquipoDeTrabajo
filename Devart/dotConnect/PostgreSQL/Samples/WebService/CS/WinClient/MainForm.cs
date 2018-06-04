using System;
using System.Data;
using System.Windows.Forms;

namespace WinClient {
  public partial class MainForm : Form {
    public MainForm() {
      InitializeComponent();
    }

    private void btRetrieve_Click(object sender, EventArgs e) {

      try {
        localhost.Service service = new WinClient.localhost.Service();
        DataSet ds = service.FetchData(cbQuery.SelectedItem.ToString());
        dataGridView.DataSource = ds.Tables[0];
        statusBar.Text = "\"" + cbQuery.Items[cbQuery.SelectedIndex].ToString() + "\" query was executed";
      }
      catch (Exception ex) {
        statusBar.Text = "";
        dataGridView.DataSource = null;
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void cbQuery_SelectedIndexChanged(object sender, EventArgs e) {

      if (cbQuery.SelectedIndex != -1) btRetrieve.Enabled = true;
    }
  }
}
