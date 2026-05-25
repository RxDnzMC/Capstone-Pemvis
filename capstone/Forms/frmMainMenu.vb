Public Class frmMainMenu

    Private timerClock As New Timer()

    Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateStatus()
        SetMenuPermission()

        ' Setup timer untuk jam
        timerClock.Interval = 1000
        AddHandler timerClock.Tick, AddressOf TimerClock_Tick
        timerClock.Start()
    End Sub

    Private Sub UpdateStatus()
        Label2.Text = "User: " & User.CurrentUser.NamaLengkap & " (" & User.CurrentUser.Role & ") | Email: " & User.CurrentUser.Email
        ToolStripStatusLabel1.Text = "Selamat datang di Sistem Pengolahan Nilai Mahasiswa"
    End Sub

    Private Sub SetMenuPermission()
        If User.CurrentUser.Role = "Viewer" Then
            MenuMahasiswa.Enabled = False
            MenuNilai.Enabled = False
            MenuMataKuliah.Enabled = False
        ElseIf User.CurrentUser.Role = "Dosen" Then
            MenuMahasiswa.Enabled = False
            MenuMataKuliah.Enabled = False
        End If
    End Sub

    Private Sub TimerClock_Tick(sender As Object, e As EventArgs)
        ToolStripStatusLabel2.Text = "Waktu: " & Now.ToString("HH:mm:ss")
    End Sub

    Private Sub MenuMahasiswa_Click(sender As Object, e As EventArgs) Handles MenuMahasiswa.Click
        frmMahasiswa.Show()
    End Sub

    Private Sub MenuMataKuliah_Click(sender As Object, e As EventArgs) Handles MenuMataKuliah.Click
        MessageBox.Show("Menu Mata Kuliah - Fitur dalam pengembangan", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub MenuNilai_Click(sender As Object, e As EventArgs) Handles MenuNilai.Click
        frmNilai.Show()
    End Sub

    Private Sub MenuReportNilai_Click(sender As Object, e As EventArgs) Handles MenuReportNilai.Click
        frmReportNilai.Show()
    End Sub

    Private Sub MenuReportLog_Click(sender As Object, e As EventArgs) Handles MenuReportLog.Click
        frmReportLog.Show()
    End Sub

    Private Sub MenuLogout_Click(sender As Object, e As EventArgs) Handles MenuLogout.Click
        If MessageBox.Show("Apakah anda yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Security.LogAktivitas(User.CurrentUser.UserID, "Logout", "tbl_Users", User.CurrentUser.UserID, "Logout")
            User.CurrentUser = Nothing
            timerClock.Stop()
            frmLogin.Show()
            Me.Close()
        End If
    End Sub

    Private Sub MenuKeluar_Click(sender As Object, e As EventArgs) Handles MenuKeluar.Click
        If MessageBox.Show("Apakah anda yakin ingin keluar dari aplikasi?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Security.LogAktivitas(User.CurrentUser.UserID, "Aplikasi Ditutup", "Aplikasi", 0, "User menutup aplikasi")
            timerClock.Stop()
            Application.Exit()
        End If
    End Sub

End Class