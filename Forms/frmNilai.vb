Public Class frmNilai

    Private isLoading As Boolean = True

    Private Sub frmNilai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadMahasiswa()
            LoadMataKuliah()
            LoadTahunAkademik()
            LoadNilai()
            ClearForm()
            isLoading = False
        Catch ex As Exception
            MessageBox.Show("Error Load Form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMahasiswa()
        Try
            Dim dt = Database.ExecuteQuery(
                "SELECT MahasiswaID, CONCAT(NIM, ' - ', NamaLengkap) AS Mahasiswa " &
                "FROM tbl_Mahasiswa WHERE IsAktif = 1 ORDER BY NIM")

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                cmbMahasiswa.DataSource = dt
                cmbMahasiswa.DisplayMember = "Mahasiswa"
                cmbMahasiswa.ValueMember = "MahasiswaID"
            Else
                ' Buat dummy data agar tidak error
                Dim dummyDt As New DataTable()
                dummyDt.Columns.Add("MahasiswaID", GetType(Integer))
                dummyDt.Columns.Add("Mahasiswa", GetType(String))
                dummyDt.Rows.Add(0, "-- Pilih Mahasiswa --")
                cmbMahasiswa.DataSource = dummyDt
                cmbMahasiswa.DisplayMember = "Mahasiswa"
                cmbMahasiswa.ValueMember = "MahasiswaID"
            End If
        Catch ex As Exception
            MessageBox.Show("Error Load Mahasiswa: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadMataKuliah()
        Try
            Dim dt = Database.ExecuteQuery(
                "SELECT MataKuliahID, CONCAT(KodeMK, ' - ', NamaMK) AS MataKuliah " &
                "FROM tbl_MataKuliah WHERE IsAktif = 1 ORDER BY KodeMK")

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                cmbMataKuliah.DataSource = dt
                cmbMataKuliah.DisplayMember = "MataKuliah"
                cmbMataKuliah.ValueMember = "MataKuliahID"
            Else
                Dim dummyDt As New DataTable()
                dummyDt.Columns.Add("MataKuliahID", GetType(Integer))
                dummyDt.Columns.Add("MataKuliah", GetType(String))
                dummyDt.Rows.Add(0, "-- Pilih Mata Kuliah --")
                cmbMataKuliah.DataSource = dummyDt
                cmbMataKuliah.DisplayMember = "MataKuliah"
                cmbMataKuliah.ValueMember = "MataKuliahID"
            End If
        Catch ex As Exception
            MessageBox.Show("Error Load Mata Kuliah: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadTahunAkademik()
        Try
            Dim dt = Database.ExecuteQuery(
                "SELECT TahunAkademikID, CONCAT(Tahun, ' Sem ', CAST(Semester AS CHAR)) AS TahunAkademik " &
                "FROM tbl_TahunAkademik ORDER BY Tahun DESC")

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                cmbTahunAkademik.DataSource = dt
                cmbTahunAkademik.DisplayMember = "TahunAkademik"
                cmbTahunAkademik.ValueMember = "TahunAkademikID"
            Else
                Dim dummyDt As New DataTable()
                dummyDt.Columns.Add("TahunAkademikID", GetType(Integer))
                dummyDt.Columns.Add("TahunAkademik", GetType(String))
                dummyDt.Rows.Add(0, "-- Pilih Tahun Akademik --")
                cmbTahunAkademik.DataSource = dummyDt
                cmbTahunAkademik.DisplayMember = "TahunAkademik"
                cmbTahunAkademik.ValueMember = "TahunAkademikID"
            End If
        Catch ex As Exception
            MessageBox.Show("Error Load Tahun Akademik: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadNilai()
        Try
            Dim query = "SELECT n.NilaiID, m.NIM, m.NamaLengkap, mk.NamaMK, " &
                        "n.NilaiPraktikum, n.NilaiUTS, n.NilaiUAS, n.NilaiTugas, n.NilaiAffektif, " &
                        "n.NilaiAkhir, n.Grade, n.Keterangan " &
                        "FROM tbl_Nilai n " &
                        "INNER JOIN tbl_Mahasiswa m ON n.MahasiswaID = m.MahasiswaID " &
                        "INNER JOIN tbl_MataKuliah mk ON n.MataKuliahID = mk.MataKuliahID " &
                        "ORDER BY m.NIM"

            Dim dt = Database.ExecuteQuery(query)

            If dt IsNot Nothing Then
                DataGridView1.DataSource = dt

                ' Set column widths jika ada data
                If DataGridView1.Columns.Count > 0 Then
                    DataGridView1.Columns(0).Width = 50   ' NilaiID
                    DataGridView1.Columns(1).Width = 70   ' NIM
                    DataGridView1.Columns(2).Width = 150  ' Nama
                    DataGridView1.Columns(3).Width = 150  ' MataKuliah
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error Load Nilai: " & ex.Message)
        End Try
    End Sub

    Private Sub ClearForm()
        Try
            txtNilaiPraktikum.Text = "0"
            txtNilaiUTS.Text = "0"
            txtNilaiUAS.Text = "0"
            txtNilaiTugas.Text = "0"
            txtNilaiAffektif.Text = "0"
            lblNilaiAkhir.Text = "0.00"
            lblGrade.Text = "-"
            lblKeterangan.Text = "-"

            ' Hanya set index jika ada items
            If cmbMahasiswa.Items.Count > 0 Then
                cmbMahasiswa.SelectedIndex = 0
            End If
            If cmbMataKuliah.Items.Count > 0 Then
                cmbMataKuliah.SelectedIndex = 0
            End If
            If cmbTahunAkademik.Items.Count > 0 Then
                cmbTahunAkademik.SelectedIndex = 0
            End If
        Catch ex As Exception
            Console.WriteLine("ClearForm Error: " & ex.Message)
        End Try
    End Sub

    Private Function ValidasiInput() As Boolean
        If cmbMahasiswa.SelectedIndex = -1 OrElse CInt(cmbMahasiswa.SelectedValue) = 0 Then
            MessageBox.Show("Pilih Mahasiswa!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbMahasiswa.Focus()
            Return False
        End If

        If cmbMataKuliah.SelectedIndex = -1 OrElse CInt(cmbMataKuliah.SelectedValue) = 0 Then
            MessageBox.Show("Pilih Mata Kuliah!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbMataKuliah.Focus()
            Return False
        End If

        If cmbTahunAkademik.SelectedIndex = -1 OrElse CInt(cmbTahunAkademik.SelectedValue) = 0 Then
            MessageBox.Show("Pilih Tahun Akademik!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbTahunAkademik.Focus()
            Return False
        End If

        If lblNilaiAkhir.Text = "0.00" OrElse lblNilaiAkhir.Text = "-" Then
            MessageBox.Show("Klik HITUNG terlebih dahulu!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Function GetGrade(nilai As Decimal) As String
        If nilai >= 85 Then
            Return "A"
        ElseIf nilai >= 75 Then
            Return "B"
        ElseIf nilai >= 65 Then
            Return "C"
        ElseIf nilai >= 50 Then
            Return "D"
        Else
            Return "E"
        End If
    End Function

    Private Function IsNumeric(value As String) As Boolean
        Dim result As Decimal
        Return Decimal.TryParse(value, result)
    End Function

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        ClearForm()
    End Sub

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
        Try
            If Not IsNumeric(txtNilaiPraktikum.Text) Then
                MessageBox.Show("Nilai Praktikum harus berupa angka!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNilaiPraktikum.Focus()
                Return
            End If
            If Not IsNumeric(txtNilaiUTS.Text) Then
                MessageBox.Show("Nilai UTS harus berupa angka!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNilaiUTS.Focus()
                Return
            End If
            If Not IsNumeric(txtNilaiUAS.Text) Then
                MessageBox.Show("Nilai UAS harus berupa angka!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNilaiUAS.Focus()
                Return
            End If
            If Not IsNumeric(txtNilaiTugas.Text) Then
                MessageBox.Show("Nilai Tugas harus berupa angka!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNilaiTugas.Focus()
                Return
            End If
            If Not IsNumeric(txtNilaiAffektif.Text) Then
                MessageBox.Show("Nilai Affektif harus berupa angka!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNilaiAffektif.Focus()
                Return
            End If

            Dim praktikum = CDec(txtNilaiPraktikum.Text)
            Dim uts = CDec(txtNilaiUTS.Text)
            Dim uas = CDec(txtNilaiUAS.Text)
            Dim tugas = CDec(txtNilaiTugas.Text)
            Dim affektif = CDec(txtNilaiAffektif.Text)

            If praktikum < 0 Or praktikum > 100 Or uts < 0 Or uts > 100 Or uas < 0 Or uas > 100 Or tugas < 0 Or tugas > 100 Or affektif < 0 Or affektif > 100 Then
                MessageBox.Show("Nilai harus antara 0 - 100!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim nilaiAkhir = (praktikum * 0.15) + (uts * 0.25) + (uas * 0.3) + (tugas * 0.2) + (affektif * 0.1)
            nilaiAkhir = Math.Round(nilaiAkhir, 2)

            lblNilaiAkhir.Text = nilaiAkhir.ToString("0.00")
            lblGrade.Text = GetGrade(nilaiAkhir)
            lblKeterangan.Text = If(nilaiAkhir >= 60, "Lulus", "Tidak Lulus")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If Not ValidasiInput() Then Return

            Dim mahasiswaID = CInt(cmbMahasiswa.SelectedValue)
            Dim mataKuliahID = CInt(cmbMataKuliah.SelectedValue)
            Dim tahunAkademikID = CInt(cmbTahunAkademik.SelectedValue)
            Dim praktikum = CDec(txtNilaiPraktikum.Text)
            Dim uts = CDec(txtNilaiUTS.Text)
            Dim uas = CDec(txtNilaiUAS.Text)
            Dim tugas = CDec(txtNilaiTugas.Text)
            Dim affektif = CDec(txtNilaiAffektif.Text)
            Dim nilaiAkhir = CDec(lblNilaiAkhir.Text)
            Dim grade = lblGrade.Text
            Dim keterangan = lblKeterangan.Text

            Dim checkQuery = String.Format(
                "SELECT COUNT(*) FROM tbl_Nilai WHERE MahasiswaID = {0} AND MataKuliahID = {1} AND TahunAkademikID = {2}",
                mahasiswaID, mataKuliahID, tahunAkademikID)
            Dim result = CInt(Database.ExecuteScalar(checkQuery))

            If result > 0 Then
                Dim updateQuery = String.Format(
                    "UPDATE tbl_Nilai SET NilaiPraktikum = {0}, NilaiUTS = {1}, NilaiUAS = {2}, NilaiTugas = {3}, " &
                    "NilaiAffektif = {4}, NilaiAkhir = {5}, Grade = N'{6}', Keterangan = N'{7}', " &
                    "TanggalUpdate = NOW(), UserIDUpdate = {8} " &
                    "WHERE MahasiswaID = {9} AND MataKuliahID = {10} AND TahunAkademikID = {11}",
                    praktikum, uts, uas, tugas, affektif, nilaiAkhir, grade, keterangan,
                    User.CurrentUser.UserID, mahasiswaID, mataKuliahID, tahunAkademikID)

                If Database.ExecuteNonQuery(updateQuery) Then
                    Security.LogAktivitas(User.CurrentUser.UserID, "UPDATE", "tbl_Nilai", 0, "Update Nilai")
                    MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadNilai()
                    ClearForm()
                End If
            Else
                Dim insertQuery = String.Format(
                    "INSERT INTO tbl_Nilai (MahasiswaID, MataKuliahID, TahunAkademikID, NilaiPraktikum, NilaiUTS, " &
                    "NilaiUAS, NilaiTugas, NilaiAffektif, NilaiAkhir, Grade, Keterangan, UserIDInput) " &
                    "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, N'{9}', N'{10}', {11})",
                    mahasiswaID, mataKuliahID, tahunAkademikID, praktikum, uts, uas, tugas, affektif,
                    nilaiAkhir, grade, keterangan, User.CurrentUser.UserID)

                If Database.ExecuteNonQuery(insertQuery) Then
                    Security.LogAktivitas(User.CurrentUser.UserID, "INSERT", "tbl_Nilai", 0, "Insert Nilai")
                    MessageBox.Show("Data berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadNilai()
                    ClearForm()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadNilai()
        ClearForm()
    End Sub
End Class