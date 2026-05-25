<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNilai
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnHitung = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnBaru = New System.Windows.Forms.Button()
        Me.lblGrade = New System.Windows.Forms.Label()
        Me.lblKeterangan = New System.Windows.Forms.Label()
        Me.lblNilaiAkhir = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNilaiAffektif = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNilaiTugas = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNilaiUAS = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNilaiUTS = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNilaiPraktikum = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTahunAkademik = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbMataKuliah = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMahasiswa = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()

        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()

        ' GroupBox1
        Me.GroupBox1.Controls.Add(Me.btnRefresh)
        Me.GroupBox1.Controls.Add(Me.btnHitung)
        Me.GroupBox1.Controls.Add(Me.btnSimpan)
        Me.GroupBox1.Controls.Add(Me.btnBaru)
        Me.GroupBox1.Controls.Add(Me.lblGrade)
        Me.GroupBox1.Controls.Add(Me.lblKeterangan)
        Me.GroupBox1.Controls.Add(Me.lblNilaiAkhir)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtNilaiAffektif)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtNilaiTugas)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtNilaiUAS)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtNilaiUTS)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtNilaiPraktikum)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbTahunAkademik)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cmbMataKuliah)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbMahasiswa)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1000, 350)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Form Input Nilai Mahasiswa"

        ' Label1
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mahasiswa"

        ' cmbMahasiswa
        Me.cmbMahasiswa.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.cmbMahasiswa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMahasiswa.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbMahasiswa.FormattingEnabled = True
        Me.cmbMahasiswa.Location = New System.Drawing.Point(20, 57)
        Me.cmbMahasiswa.Name = "cmbMahasiswa"
        Me.cmbMahasiswa.Size = New System.Drawing.Size(280, 25)
        Me.cmbMahasiswa.TabIndex = 1

        ' Label2
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(320, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mata Kuliah"

        ' cmbMataKuliah
        Me.cmbMataKuliah.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.cmbMataKuliah.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMataKuliah.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbMataKuliah.FormattingEnabled = True
        Me.cmbMataKuliah.Location = New System.Drawing.Point(320, 57)
        Me.cmbMataKuliah.Name = "cmbMataKuliah"
        Me.cmbMataKuliah.Size = New System.Drawing.Size(280, 25)
        Me.cmbMataKuliah.TabIndex = 2

        ' Label11
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(620, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 19)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Tahun Akademik"

        ' cmbTahunAkademik
        Me.cmbTahunAkademik.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.cmbTahunAkademik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTahunAkademik.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbTahunAkademik.FormattingEnabled = True
        Me.cmbTahunAkademik.Location = New System.Drawing.Point(620, 57)
        Me.cmbTahunAkademik.Name = "cmbTahunAkademik"
        Me.cmbTahunAkademik.Size = New System.Drawing.Size(180, 25)
        Me.cmbTahunAkademik.TabIndex = 3

        ' Label3
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 19)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Nilai Praktikum"

        ' txtNilaiPraktikum
        Me.txtNilaiPraktikum.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.txtNilaiPraktikum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNilaiPraktikum.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNilaiPraktikum.Location = New System.Drawing.Point(20, 127)
        Me.txtNilaiPraktikum.Name = "txtNilaiPraktikum"
        Me.txtNilaiPraktikum.Size = New System.Drawing.Size(100, 25)
        Me.txtNilaiPraktikum.TabIndex = 4
        Me.txtNilaiPraktikum.Text = "0"

        ' Label4
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(140, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "UTS"

        ' txtNilaiUTS
        Me.txtNilaiUTS.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.txtNilaiUTS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNilaiUTS.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNilaiUTS.Location = New System.Drawing.Point(140, 127)
        Me.txtNilaiUTS.Name = "txtNilaiUTS"
        Me.txtNilaiUTS.Size = New System.Drawing.Size(100, 25)
        Me.txtNilaiUTS.TabIndex = 5
        Me.txtNilaiUTS.Text = "0"

        ' Label5
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(260, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 19)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "UAS"

        ' txtNilaiUAS
        Me.txtNilaiUAS.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.txtNilaiUAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNilaiUAS.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNilaiUAS.Location = New System.Drawing.Point(260, 127)
        Me.txtNilaiUAS.Name = "txtNilaiUAS"
        Me.txtNilaiUAS.Size = New System.Drawing.Size(100, 25)
        Me.txtNilaiUAS.TabIndex = 6
        Me.txtNilaiUAS.Text = "0"

        ' Label6
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(380, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 19)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Nilai Tugas"

        ' txtNilaiTugas
        Me.txtNilaiTugas.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.txtNilaiTugas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNilaiTugas.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNilaiTugas.Location = New System.Drawing.Point(380, 127)
        Me.txtNilaiTugas.Name = "txtNilaiTugas"
        Me.txtNilaiTugas.Size = New System.Drawing.Size(100, 25)
        Me.txtNilaiTugas.TabIndex = 7
        Me.txtNilaiTugas.Text = "0"

        ' Label7
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(500, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 19)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Nilai Affektif"

        ' txtNilaiAffektif
        Me.txtNilaiAffektif.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.txtNilaiAffektif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNilaiAffektif.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNilaiAffektif.Location = New System.Drawing.Point(500, 127)
        Me.txtNilaiAffektif.Name = "txtNilaiAffektif"
        Me.txtNilaiAffektif.Size = New System.Drawing.Size(100, 25)
        Me.txtNilaiAffektif.TabIndex = 8
        Me.txtNilaiAffektif.Text = "0"

        ' Label8
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(640, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 19)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Nilai Akhir"

        ' lblNilaiAkhir
        Me.lblNilaiAkhir.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.lblNilaiAkhir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNilaiAkhir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNilaiAkhir.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185)
        Me.lblNilaiAkhir.Location = New System.Drawing.Point(640, 127)
        Me.lblNilaiAkhir.Name = "lblNilaiAkhir"
        Me.lblNilaiAkhir.Size = New System.Drawing.Size(100, 25)
        Me.lblNilaiAkhir.TabIndex = 17
        Me.lblNilaiAkhir.Text = "0.00"
        Me.lblNilaiAkhir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' Label9
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(760, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 19)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Grade"

        ' lblGrade
        Me.lblGrade.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.lblGrade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGrade.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrade.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185)
        Me.lblGrade.Location = New System.Drawing.Point(760, 127)
        Me.lblGrade.Name = "lblGrade"
        Me.lblGrade.Size = New System.Drawing.Size(40, 25)
        Me.lblGrade.TabIndex = 19
        Me.lblGrade.Text = "-"
        Me.lblGrade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' Label10
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(820, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 19)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Keterangan"

        ' lblKeterangan
        Me.lblKeterangan.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.lblKeterangan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKeterangan.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblKeterangan.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185)
        Me.lblKeterangan.Location = New System.Drawing.Point(820, 127)
        Me.lblKeterangan.Name = "lblKeterangan"
        Me.lblKeterangan.Size = New System.Drawing.Size(160, 25)
        Me.lblKeterangan.TabIndex = 21
        Me.lblKeterangan.Text = "-"
        Me.lblKeterangan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' btnBaru
        Me.btnBaru.BackColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.btnBaru.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBaru.FlatAppearance.BorderSize = 0
        Me.btnBaru.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBaru.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnBaru.ForeColor = System.Drawing.Color.White
        Me.btnBaru.Location = New System.Drawing.Point(20, 180)
        Me.btnBaru.Name = "btnBaru"
        Me.btnBaru.Size = New System.Drawing.Size(90, 35)
        Me.btnBaru.TabIndex = 9
        Me.btnBaru.Text = "BARU"
        Me.btnBaru.UseVisualStyleBackColor = False

        ' btnHitung
        Me.btnHitung.BackColor = System.Drawing.Color.FromArgb(155, 89, 182)
        Me.btnHitung.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHitung.FlatAppearance.BorderSize = 0
        Me.btnHitung.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHitung.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnHitung.ForeColor = System.Drawing.Color.White
        Me.btnHitung.Location = New System.Drawing.Point(120, 180)
        Me.btnHitung.Name = "btnHitung"
        Me.btnHitung.Size = New System.Drawing.Size(90, 35)
        Me.btnHitung.TabIndex = 10
        Me.btnHitung.Text = "HITUNG"
        Me.btnHitung.UseVisualStyleBackColor = False

        ' btnSimpan
        Me.btnSimpan.BackColor = System.Drawing.Color.FromArgb(46, 204, 113)
        Me.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSimpan.FlatAppearance.BorderSize = 0
        Me.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.ForeColor = System.Drawing.Color.White
        Me.btnSimpan.Location = New System.Drawing.Point(220, 180)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(90, 35)
        Me.btnSimpan.TabIndex = 11
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.UseVisualStyleBackColor = False

        ' btnRefresh
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(149, 165, 166)
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(320, 180)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 35)
        Me.btnRefresh.TabIndex = 12
        Me.btnRefresh.Text = "REFRESH"
        Me.btnRefresh.UseVisualStyleBackColor = False

        ' DataGridView1
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 350)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1000, 250)
        Me.DataGridView1.TabIndex = 1

        ' frmNilai
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmNilai"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input Nilai Mahasiswa"

        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnHitung As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnBaru As Button
    Friend WithEvents lblGrade As Label
    Friend WithEvents lblKeterangan As Label
    Friend WithEvents lblNilaiAkhir As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtNilaiAffektif As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNilaiTugas As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNilaiUAS As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNilaiUTS As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNilaiPraktikum As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTahunAkademik As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbMataKuliah As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbMahasiswa As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
End Class