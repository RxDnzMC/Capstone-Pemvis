Public Class frmNilai

    Private Sub frmNilai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMahasiswa()
        LoadMataKuliah()
        LoadTahunAkademik()
        LoadNilai()
    End Sub

    Private Sub LoadMahasiswa()
        Try
            Dim dt = Database.ExecuteQuery("SELECT MahasiswaID, NIM + ' - ' + NamaLengkap AS Mahasiswa FROM tbl_Mahasiswa WHERE IsAktif = 1 ORDER BY NIM")
            cmbMahasiswa.DataSource = dt
            cmbMahasiswa.DisplayMember = "Mahasiswa"
            cmbMahasiswa.ValueMember = "MahasiswaID"
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadMataKuliah()
        Try
            Dim dt = Database.ExecuteQuery("SELECT MataKuliahID, KodeMK + ' - ' + NamaMK AS MataKuliah FROM tbl_MataKuliah WHERE IsAktif = 1 ORDER BY KodeMK")
            cmbMataKuliah.DataSource = dt
            cmbMataKuliah.DisplayMember = "MataKuliah"
            cmbMataKuliah.ValueMember = "MataKuliahID"
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
            DataGridView1.DataSource = dt

            ' Set column widths
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns(0).Width = 50
                DataGridView1.Columns(1).Width = 70
                DataGridView1.Columns(2).Width = 120
                DataGridView1.Columns(3).Width = 100
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        ClearForm()
    End Sub

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
        Try
            ' Validasi input tidak kosong
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

            ' Validasi range nilai (0-100)
            If praktikum < 0 Or praktikum > 100 Or uts < 0 Or uts > 100 Or uas < 0 Or uas > 100 Or tugas < 0 Or tugas > 100 Or affektif < 0 Or affektif > 100 Then
                MessageBox.Show("Nilai harus antara 0 - 100!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Rumus: (P*0.15) + (UTS*0.25) + (UAS*0.30) + (Tugas*0.20) + (Affektif*0.10)
            Dim nilaiAkhir = (praktikum * 0.15) + (uts * 0.25) + (uas * 0.3) + (tugas * 0.2) + (affektif * 0.1)
            nilaiAkhir = Math.Round(nilaiAkhir, 2)

            Dim grade = GetGrade(nilaiAkhir)
            Dim keterangan = If(nilaiAkhir >= 60, "Lulus", "Tidak Lulus")

            ' Tampilkan hasil
            lblNilaiAkhir.Text = nilaiAkhir.ToString("0.00")
            lblGrade.Text = grade
            lblKeterangan.Text = keterangan

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

            ' Cek data sudah ada atau belum
            Dim checkQuery = String.Format(
                "SELECT COUNT(*) FROM tbl_Nilai WHERE MahasiswaID = {0} AND MataKuliahID = {1} AND TahunAkademikID = {2}",
                mahasiswaID, mataKuliahID, tahunAkademikID)

            Dim result = CInt(Database.ExecuteScalar(checkQuery))

            If result > 0 Then
                ' Update
                Dim updateQuery = String.Format(
                    "UPDATE tbl_Nilai SET NilaiPraktikum = {0}, NilaiUTS = {1}, NilaiUAS = {2}, NilaiTugas = {3}, " &
                    "NilaiAffektif = {4}, NilaiAkhir = {5}, Grade = N'{6}', Keterangan = N'{7}', " &
                    "TanggalUpdate = GETDATE(), UserIDUpdate = {8} " &
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
                ' Insert
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

    Private Function ValidasiInput() As Boolean
        If cmbMahasiswa.SelectedIndex = -1 Then
            MessageBox.Show("Pilih Mahasiswa!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cmbMataKuliah.SelectedIndex = -1 Then
            MessageBox.Show("Pilih Mata Kuliah!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cmbTahunAkademik.SelectedIndex = -1 Then
            MessageBox.Show("Pilih Tahun Akademik!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If lblNilaiAkhir.Text = "0.00" Then
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

    Private Sub ClearForm()
        txtNilaiPraktikum.Text = "0"
        txtNilaiUTS.Text = "0"
        txtNilaiUAS.Text = "0"
        txtNilaiTugas.Text = "0"
        txtNilaiAffektif.Text = "0"
        lblNilaiAkhir.Text = "0.00"
        lblGrade.Text = "-"
        lblKeterangan.Text = "-"
        cmbMahasiswa.SelectedIndex = 0
        cmbMataKuliah.SelectedIndex = 0
        cmbTahunAkademik.SelectedIndex = 0
    End Sub

End Class