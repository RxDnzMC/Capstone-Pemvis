Public Class frmReportLog

    Private Sub frmReportLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUser()
        DateTimePicker1.Value = Now.AddDays(-7)
        DateTimePicker2.Value = Now
        LoadReport()
    End Sub

    Private Sub LoadUser()
        Try
            Dim dt = Database.ExecuteQuery("SELECT UserID, NamaLengkap FROM tbl_Users WHERE IsAktif = 1 ORDER BY NamaLengkap")
            cmbUser.DataSource = dt
            cmbUser.DisplayMember = "NamaLengkap"
            cmbUser.ValueMember = "UserID"
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadReport()
        Try
            Dim userID = CInt(cmbUser.SelectedValue)
            Dim fromDate = DateTimePicker1.Value.Date
            Dim toDate = DateTimePicker2.Value.Date.AddDays(1)

            Dim query = String.Format(
                "SELECT l.LogID, u.NamaLengkap, l.Aktivitas, l.Tabel, l.RecordID, l.Keterangan, " &
                "l.TanggalAktivitas, l.IPAddress, l.Status " &
                "FROM tbl_Log l " &
                "INNER JOIN tbl_Users u ON l.UserID = u.UserID " &
                "WHERE l.UserID = {0} AND l.TanggalAktivitas >= '{1}' AND l.TanggalAktivitas < '{2}' " &
                "ORDER BY l.TanggalAktivitas DESC",
                userID, fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"))

            Dim dt = Database.ExecuteQuery(query)
            DataGridView1.DataSource = dt

            Security.LogAktivitas(User.CurrentUser.UserID, "View", "Report", 0, "Lihat Report Log")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadReport()
    End Sub

    Private Sub cmbUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUser.SelectedIndexChanged
        If cmbUser.SelectedIndex <> -1 Then
            LoadReport()
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        LoadReport()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        LoadReport()
    End Sub

End Class