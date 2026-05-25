Public Class frmReportNilai

    Private Sub frmReportNilai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProdi()
        LoadTahunAkademik()
        LoadReport()
    End Sub

    Private Sub LoadProdi()
        Try
            Dim dt = Database.ExecuteQuery("SELECT ProdiID, NamaProdi FROM tbl_ProgramStudi WHERE IsAktif = 1")
            cmbProdi.DataSource = dt
            cmbProdi.DisplayMember = "NamaProdi"
            cmbProdi.ValueMember = "ProdiID"
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadTahunAkademik()
        Try
            Dim dt = Database.ExecuteQuery("SELECT TahunAkademikID, Tahun + ' Sem ' + CAST(Semester AS NVARCHAR) AS TahunAkademik FROM tbl_TahunAkademik ORDER BY Tahun DESC")
            cmbTahunAkademik.DataSource = dt
            cmbTahunAkademik.DisplayMember = "TahunAkademik"
            cmbTahunAkademik.ValueMember = "TahunAkademikID"
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadReport()
        Try
            Dim prodiID = CInt(cmbProdi.SelectedValue)
            Dim tahunAkademikID = CInt(cmbTahunAkademik.SelectedValue)

            Dim query = String.Format(
                "SELECT m.NIM, m.NamaLengkap, mk.NamaMK, " &
                "n.NilaiPraktikum, n.NilaiUTS, n.NilaiUAS, n.NilaiTugas, n.NilaiAffektif, " &
                "n.NilaiAkhir, n.Grade, n.Keterangan " &
                "FROM tbl_Nilai n " &
                "INNER JOIN tbl_Mahasiswa m ON n.MahasiswaID = m.MahasiswaID " &
                "INNER JOIN tbl_MataKuliah mk ON n.MataKuliahID = mk.MataKuliahID " &
                "WHERE m.ProdiID = {0} AND n.TahunAkademikID = {1} " &
                "ORDER BY m.NIM, mk.NamaMK", prodiID, tahunAkademikID)

            Dim dt = Database.ExecuteQuery(query)
            DataGridView1.DataSource = dt

            Security.LogAktivitas(User.CurrentUser.UserID, "View", "Report", 0, "Lihat Report Nilai")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadReport()
    End Sub

    Private Sub cmbProdi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProdi.SelectedIndexChanged
        If cmbProdi.SelectedIndex <> -1 Then
            LoadReport()
        End If
    End Sub

    Private Sub cmbTahunAkademik_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTahunAkademik.SelectedIndexChanged
        If cmbTahunAkademik.SelectedIndex <> -1 Then
            LoadReport()
        End If
    End Sub

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        Try
            Dim printDoc As New Printing.PrintDocument()

            If PrintDialog1.ShowDialog() = DialogResult.OK Then
                MessageBox.Show("Fitur cetak sedang dalam pengembangan", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class