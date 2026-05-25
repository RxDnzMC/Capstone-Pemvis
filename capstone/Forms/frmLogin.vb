Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtUsername.Focus()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Not ValidasiInput() Then
            Return
        End If

        VerifikasiLogin()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtUsername.Clear()
        txtPassword.Clear()
        txtUsername.Focus()
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not chkShowPassword.Checked
    End Sub

    Private Sub frmLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            btnLogin_Click(Nothing, Nothing)
            e.Handled = True
        End If
    End Sub

    Private Function ValidasiInput() As Boolean
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Username tidak boleh kosong!", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Password tidak boleh kosong!", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If

        If txtPassword.Text.Length < 3 Then
            MessageBox.Show("Password minimal 3 karakter!", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub VerifikasiLogin()
        Try
            Dim username As String = txtUsername.Text.Trim()
            Dim password As String = Security.MD5Hash(txtPassword.Text)

            Dim query As String = String.Format(
                "SELECT UserID, Username, NamaLengkap, Role, Email, NoTelepon " &
                "FROM tbl_Users " &
                "WHERE Username = N'{0}' AND Password = N'{1}' AND IsAktif = 1",
                username.Replace("'", "''"), password)

            Dim dt = Database.ExecuteQuery(query)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim row = dt.Rows(0)

                User.CurrentUser = New User With {
                    .UserID = CInt(row("UserID")),
                    .Username = row("Username").ToString(),
                    .NamaLengkap = row("NamaLengkap").ToString(),
                    .Role = row("Role").ToString(),
                    .Email = row("Email").ToString(),
                    .NoTelepon = row("NoTelepon").ToString()
                }

                Security.LogAktivitas(
                    User.CurrentUser.UserID,
                    "Login",
                    "tbl_Users",
                    User.CurrentUser.UserID,
                    "Login Berhasil")

                MessageBox.Show(
                    "Login Berhasil!" & vbCrLf & "Selamat datang " & User.CurrentUser.NamaLengkap,
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                frmMainMenu.Show()
                Me.Hide()

            Else
                Security.LogAktivitas(
                    0,
                    "Login",
                    "tbl_Users",
                    0,
                    "Login Gagal - Username/Password salah untuk user: " & username)

                MessageBox.Show(
                    "Username atau Password salah!",
                    "Login Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                txtPassword.Clear()
                txtUsername.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(
                "Error: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show(
            "Apakah anda yakin ingin keluar dari aplikasi?",
            "Konfirmasi",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question) = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

End Class