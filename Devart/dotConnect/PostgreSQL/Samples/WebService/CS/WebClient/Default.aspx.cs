using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
  protected string Status = "'Done'";

  protected void btRetrieve_Click(object sender, EventArgs e) {

    try {
      localhost.Service service = new localhost.Service();
      DataSet ds = service.FetchData(cbQuery.SelectedValue);
      GridView.DataSource = ds.Tables[0];
      GridView.DataBind();
      Status = "'Done'";
      if (0 == ds.Tables[0].Rows.Count)
        lbResult.Visible = true;
      else
        lbResult.Visible = false;
    }
    catch (Exception ex) {
      GridView.DataSource = null;
      lbResult.Visible = true;
      lbResult.Text = ex.Message;
    }
  }
}