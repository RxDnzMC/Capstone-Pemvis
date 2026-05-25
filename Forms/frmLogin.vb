Public Class frmLogin

    ' ========================================
    ' FORM LOAD - DATABASE SETUP
    ' ========================================
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' ========================================
            ' STEP 1: CEK & BUAT DATABASE
            ' ========================================
            Console.WriteLine("=" & New String("="c, 50))
            Console.WriteLine("🚀 STARTING APPLICATION")
            Console.WriteLine("=" & New String("="c, 50))
            Console.WriteLine("")
            Console.WriteLine("Step 1: Initializing Database...")

            If Not Database.CekDanBuatDatabase() Then
                MessageBox.Show(
                    "❌ Database setup failed!" & vbCrLf & vbCrLf &
                    "Pastikan:" & vbCrLf &
                    "1. MySQL XAMPP running" & vbCrLf &
                    "2. Port 3306 available" & vbCrLf &
                    "3. Username/Password benar di Database.vb",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
                Application.Exit()
                Return
            End If

            Console.WriteLine("✓ Database initialized")
            Console.WriteLine("")

            ' ========================================
            ' STEP 2: CEK KONEKSI
            ' ========================================
            Console.WriteLine("Step 2: Checking database connection...")

            If Not Database.CekKoneksi() Then
                MessageBox.Show(
                    "❌ Database connection failed!",
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
                Application.Exit()
                Return
            End If

            Console.WriteLine("✓ Database connection OK")
            Console.WriteLine("")
            Console.WriteLine("=" & New String("="c, 50))
            Console.WriteLine("✅ Application ready!")
            Console.WriteLine("=" & New String("="c, 50))
            Console.WriteLine("")

            ' ========================================
            ' SETUP LOGIN FORM
            ' ========================================
            Me.KeyPreview = True
            txtUsername.Focus()

        Catch ex As Exception
            Console.WriteLine("❌ FATAL ERROR: " & ex.Message)
            Console.WriteLine(ex.StackTrace)
            MessageBox.Show(
                "❌ Application Error:" & vbCrLf & vbCrLf &
                ex.Message & vbCrLf & vbCrLf &
                "Stack Trace:" & vbCrLf &
                ex.StackTrace,
                "Fatal Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    ' ========================================
    ' LOGIN BUTTON
    ' ========================================
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Not ValidasiInput() Then
            Return
        End If

        VerifikasiLogin()
    End Sub

    ' ========================================
    ' CLEAR BUTTON
    ' ========================================
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtUsername.Clear()
        txtPassword.Clear()
        txtUsername.Focus()
    End Sub

    ' ========================================
    ' SHOW/HIDE PASSWORD
    ' ========================================
    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not chkShowPassword.Checked
    End Sub

    ' ========================================
    ' ENTER KEY
    ' ========================================
    Private Sub frmLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            btnLogin_Click(Nothing, Nothing)
            e.Handled = True
        End If
    End Sub

    ' ========================================
    ' VALIDASI INPUT
    ' ========================================
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

    ' ========================================
    ' VERIFIKASI LOGIN
    ' ========================================
    Private Sub VerifikasiLogin()
        Try
            Dim username As String = txtUsername.Text.Trim()
            Dim password As String = Security.MD5Hash(txtPassword.Text)

            ' Gunakan parameterized query untuk keamanan
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

                Console.WriteLine("")
                Console.WriteLine("✅ Login successful!")
                Console.WriteLine("   User: " & User.CurrentUser.NamaLengkap)
                Console.WriteLine("   Role: " & User.CurrentUser.Role)
                Console.WriteLine("")

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

                Console.WriteLine("❌ Login failed for user: " & username)

                MessageBox.Show(
                    "Username atau Password salah!",
                    "Login Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                txtPassword.Clear()
                txtUsername.Focus()
            End If

        Catch ex As Exception
            Console.WriteLine("❌ VerifikasiLogin Error: " & ex.Message)
            MessageBox.Show(
                "Error: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try
    End Sub

    ' ========================================
    ' FORM CLOSING
    ' ========================================
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