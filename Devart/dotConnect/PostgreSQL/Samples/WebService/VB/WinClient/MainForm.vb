Public Class MainForm

    Private Sub cbQuery_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbQuery.SelectedIndexChanged
        If (cbQuery.SelectedIndex <> -1) Then btRetrieve.Enabled = True
    End Sub

    Private Sub btRetrieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRetrieve.Click
        Try
            Dim service As localhost.Service
            service = New WinClient.localhost.Service()
            Dim ds As DataSet = service.FetchData(Me.cbQuery.SelectedItem.ToString)
            Me.dataGridView.DataSource = ds.Tables.Item(0)
            Me.statusBar.Text = ("""" & Me.cbQuery.Items.Item(Me.cbQuery.SelectedIndex).ToString & """ query was executed")
        Catch ex As Exception
            Me.statusBar.Text = ""
            Me.dataGridView.DataSource = Nothing
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub
End Class
