
Partial Class WebForm
  Inherits System.Web.UI.Page

  Protected Status As String = "'Done'"

  Protected Sub btRetrieve_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btRetrieve.Click
    Try
      Dim service As localhost.Service = New localhost.Service()
      Dim ds As System.Data.DataSet = service.FetchData(Me.cbQuery.SelectedItem.ToString)
      GridView.DataSource = ds.Tables.Item(0)
      GridView.DataBind()
      Status = "'Done'"
      If ds.Tables(0).Rows.Count = 0 Then
        lbResult.Visible = True
      Else
        lbResult.Visible = False
      End If
    Catch ex As Exception
      GridView.DataSource = Nothing
      lbResult.Visible = True
      lbResult.Text = ex.Message
    End Try
  End Sub
End Class
