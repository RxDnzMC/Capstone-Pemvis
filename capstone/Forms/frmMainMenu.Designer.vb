<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMainMenu
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMahasiswa = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMataKuliah = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuNilai = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuReportNilai = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuReportLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAkun = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuKeluar = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelContent = New System.Windows.Forms.Panel()

        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()

        ' MenuStrip1
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.MenuStrip1.ForeColor = System.Drawing.Color.White
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {
            Me.MenuMaster, Me.MenuReport, Me.MenuAkun})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1024, 27)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"

        ' MenuMaster
        Me.MenuMaster.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {
            Me.MenuMahasiswa, Me.MenuMataKuliah, Me.MenuNilai})
        Me.MenuMaster.ForeColor = System.Drawing.Color.White
        Me.MenuMaster.Name = "MenuMaster"
        Me.MenuMaster.Size = New System.Drawing.Size(76, 23)
        Me.MenuMaster.Text = "Master Data"

        ' MenuMahasiswa
        Me.MenuMahasiswa.Name = "MenuMahasiswa"
        Me.MenuMahasiswa.Size = New System.Drawing.Size(141, 22)
        Me.MenuMahasiswa.Text = "Mahasiswa"

        ' MenuMataKuliah
        Me.MenuMataKuliah.Name = "MenuMataKuliah"
        Me.MenuMataKuliah.Size = New System.Drawing.Size(141, 22)
        Me.MenuMataKuliah.Text = "Mata Kuliah"

        ' MenuNilai
        Me.MenuNilai.Name = "MenuNilai"
        Me.MenuNilai.Size = New System.Drawing.Size(141, 22)
        Me.MenuNilai.Text = "Input Nilai"

        ' MenuReport
        Me.MenuReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {
            Me.MenuReportNilai, Me.MenuReportLog})
        Me.MenuReport.ForeColor = System.Drawing.Color.White
        Me.MenuReport.Name = "MenuReport"
        Me.MenuReport.Size = New System.Drawing.Size(54, 23)
        Me.MenuReport.Text = "Report"

        ' MenuReportNilai
        Me.MenuReportNilai.Name = "MenuReportNilai"
        Me.MenuReportNilai.Size = New System.Drawing.Size(195, 22)
        Me.MenuReportNilai.Text = "Report Nilai Mahasiswa"

        ' MenuReportLog
        Me.MenuReportLog.Name = "MenuReportLog"
        Me.MenuReportLog.Size = New System.Drawing.Size(195, 22)
        Me.MenuReportLog.Text = "Report Log Aktivitas"

        ' MenuAkun
        Me.MenuAkun.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.MenuAkun.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {
            Me.MenuLogout, Me.MenuKeluar})
        Me.MenuAkun.ForeColor = System.Drawing.Color.White
        Me.MenuAkun.Name = "MenuAkun"
        Me.MenuAkun.Size = New System.Drawing.Size(47, 23)
        Me.MenuAkun.Text = "Akun"

        ' MenuLogout
        Me.MenuLogout.Name = "MenuLogout"
        Me.MenuLogout.Size = New System.Drawing.Size(112, 22)
        Me.MenuLogout.Text = "Logout"

        ' MenuKeluar
        Me.MenuKeluar.Name = "MenuKeluar"
        Me.MenuKeluar.Size = New System.Drawing.Size(112, 22)
        Me.MenuKeluar.Text = "Keluar"

        ' StatusStrip1
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {
            Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 639)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1024, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"

        ' ToolStripStatusLabel1
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(900, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' ToolStripStatusLabel2
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(109, 17)
        Me.ToolStripStatusLabel2.Text = "Waktu: 00:00:00"

        ' Panel1
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 90)
        Me.Panel1.TabIndex = 2

        ' Label1
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(20, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(490, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sistem Pengolahan Nilai Mahasiswa"

        ' Label2
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(20, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "User: "

        ' PanelContent
        Me.PanelContent.BackColor = System.Drawing.Color.White
        Me.PanelContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContent.Location = New System.Drawing.Point(0, 117)
        Me.PanelContent.Name = "PanelContent"
        Me.PanelContent.Size = New System.Drawing.Size(1024, 522)
        Me.PanelContent.TabIndex = 3

        ' frmMainMenu
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 661)
        Me.Controls.Add(Me.PanelContent)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistem Nilai Mahasiswa - Main Menu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized

        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuMaster As ToolStripMenuItem
    Friend WithEvents MenuMahasiswa As ToolStripMenuItem
    Friend WithEvents MenuMataKuliah As ToolStripMenuItem
    Friend WithEvents MenuNilai As ToolStripMenuItem
    Friend WithEvents MenuReport As ToolStripMenuItem
    Friend WithEvents MenuReportNilai As ToolStripMenuItem
    Friend WithEvents MenuReportLog As ToolStripMenuItem
    Friend WithEvents MenuAkun As ToolStripMenuItem
    Friend WithEvents MenuLogout As ToolStripMenuItem
    Friend WithEvents MenuKeluar As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelContent As Panel
End Class