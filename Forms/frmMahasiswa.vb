Public Class frmMahasiswa

    Private isEditing As Boolean = False
    Private currentMahasiswaID As Integer = 0

    Private Sub frmMahasiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProdi()
        LoadData()
        ClearForm()
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

    Private Sub LoadData()
        Try
            Dim query = "SELECT m.MahasiswaID, m.NIM, m.NamaLengkap, ps.NamaProdi, m.ProdiID, " &
                    "m.Email, m.NoTelepon, m.Alamat, m.TahunMasuk " &
                    "FROM tbl_Mahasiswa m " &
                    "INNER JOIN tbl_ProgramStudi ps ON m.ProdiID = ps.ProdiID " &
                    "WHERE m.IsAktif = 1 ORDER BY m.NIM"

            Dim dt = Database.ExecuteQuery(query)
            DataGridView1.DataSource = dt

            ' Sembunyikan kolom ProdiID
            If DataGridView1.Columns.Count >= 5 Then
                DataGridView1.Columns(4).Visible = False ' ProdiID
            End If

            ' Atur lebar kolom yang terlihat
            With DataGridView1
                .Columns(0).Width = 50   ' MahasiswaID
                .Columns(1).Width = 80   ' NIM
                .Columns(2).Width = 150  ' NamaLengkap
                .Columns(3).Width = 120  ' NamaProdi
                .Columns(5).Width = 150  ' Email
                .Columns(6).Width = 100  ' NoTelepon
                .Columns(7).Width = 200  ' Alamat
                .Columns(8).Width = 80   ' TahunMasuk
            End With

        Catch ex As Exception
            MessageBox.Show("Error LoadData: " & ex.Message)
        End Try
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        ClearForm()
        txtNIM.Focus()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If Not ValidasiInput() Then Return

        Try
            If isEditing Then
                UpdateMahasiswa()
            Else
                InsertMahasiswa()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub InsertMahasiswa()
        Try
            Dim query = String.Format(
                "INSERT INTO tbl_Mahasiswa (NIM, NamaLengkap, Email, NoTelepon, ProdiID, TahunMasuk, Alamat, IsAktif) " &
                "VALUES (N'{0}', N'{1}', N'{2}', N'{3}', {4}, {5}, N'{6}', 1)",
                txtNIM.Text.Replace("'", "''"),
                txtNama.Text.Replace("'", "''"),
                txtEmail.Text.Replace("'", "''"),
                txtNoTelepon.Text.Replace("'", "''"),
                cmbProdi.SelectedValue,
                numTahunMasuk.Value,
                txtAlamat.Text.Replace("'", "''"))

            If Database.ExecuteNonQuery(query) Then
                Security.LogAktivitas(User.CurrentUser.UserID, "INSERT", "tbl_Mahasiswa", 0, "Insert Mahasiswa: " & txtNIM.Text)
                MessageBox.Show("Data berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
                ClearForm()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih data yang ingin diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            isEditing = True
            Dim row = DataGridView1.SelectedRows(0)

            currentMahasiswaID = CInt(row.Cells(0).Value)      ' MahasiswaID
            txtNIM.Text = row.Cells(1).Value.ToString()        ' NIM
            txtNama.Text = row.Cells(2).Value.ToString()       ' NamaLengkap
            cmbProdi.SelectedValue = CInt(row.Cells(4).Value)  ' ProdiID (tersembunyi)
            txtEmail.Text = row.Cells(5).Value?.ToString()     ' Email
            txtNoTelepon.Text = row.Cells(6).Value?.ToString() ' NoTelepon
            txtAlamat.Text = row.Cells(7).Value?.ToString()    ' Alamat
            numTahunMasuk.Value = CInt(row.Cells(8).Value)     ' TahunMasuk

            txtNIM.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show("Error saat edit: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateMahasiswa()
        Try
            Dim query = String.Format(
                "UPDATE tbl_Mahasiswa SET NamaLengkap = N'{0}', Email = N'{1}', NoTelepon = N'{2}', " &
                "ProdiID = {3}, TahunMasuk = {4}, Alamat = N'{5}' " &
                "WHERE MahasiswaID = {6}",
                txtNama.Text.Replace("'", "''"),
                txtEmail.Text.Replace("'", "''"),
                txtNoTelepon.Text.Replace("'", "''"),
                cmbProdi.SelectedValue,
                numTahunMasuk.Value,
                txtAlamat.Text.Replace("'", "''"),
                currentMahasiswaID)

            If Database.ExecuteNonQuery(query) Then
                Security.LogAktivitas(User.CurrentUser.UserID, "UPDATE", "tbl_Mahasiswa", currentMahasiswaID, "Update Mahasiswa: " & txtNIM.Text)
                MessageBox.Show("Data berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
                ClearForm()
                isEditing = False
                txtNIM.ReadOnly = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih data yang ingin dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("Apakah anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Dim mahasiswaID = CInt(DataGridView1.SelectedRows(0).Cells(0).Value)
                Dim query = String.Format("UPDATE tbl_Mahasiswa SET IsAktif = 0 WHERE MahasiswaID = {0}", mahasiswaID)

                If Database.ExecuteNonQuery(query) Then
                    Security.LogAktivitas(User.CurrentUser.UserID, "DELETE", "tbl_Mahasiswa", mahasiswaID, "Hapus Mahasiswa")
                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadData()
                    ClearForm()
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadData()
        ClearForm()
    End Sub

    Private Function ValidasiInput() As Boolean
        If String.IsNullOrWhiteSpace(txtNIM.Text) Then
            MessageBox.Show("NIM tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNIM.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            Return False
        End If

        If cmbProdi.SelectedIndex = -1 Then
            MessageBox.Show("Program Studi harus dipilih!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbProdi.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub ClearForm()
        txtNIM.Clear()
        txtNama.Clear()
        txtEmail.Clear()
        txtNoTelepon.Clear()
        txtAlamat.Clear()
        numTahunMasuk.Value = 2025
        cmbProdi.SelectedIndex = 0
        isEditing = False
        currentMahasiswaID = 0
        txtNIM.ReadOnly = False
    End Sub

End Class