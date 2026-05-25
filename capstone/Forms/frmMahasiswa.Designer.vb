<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMahasiswa
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnBaru = New System.Windows.Forms.Button()
        Me.txtAlamat = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numTahunMasuk = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbProdi = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNoTelepon = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNIM = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()

        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTahunMasuk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()

        ' DataGridView1
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView1.Location = New System.Drawing.Point(0, 310)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1000, 290)
        Me.DataGridView1.TabIndex = 0

        ' GroupBox1
        Me.GroupBox1.Controls.Add(Me.btnRefresh)
        Me.GroupBox1.Controls.Add(Me.btnHapus)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.btnSimpan)
        Me.GroupBox1.Controls.Add(Me.btnBaru)
        Me.GroupBox1.Controls.Add(Me.txtAlamat)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.numTahunMasuk)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbProdi)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtNoTelepon)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.lblEmail)
        Me.GroupBox1.Controls.Add(Me.txtNama)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNIM)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1000, 310)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Form Input Data Mahasiswa"

        ' Label1
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NIM"

        ' txtNIM
        Me.txtNIM.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.txtNIM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNIM.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNIM.Location = New System.Drawing.Point(20, 57)
        Me.txtNIM.Name = "txtNIM"
        Me.txtNIM.Size = New System.Drawing.Size(150, 25)
        Me.txtNIM.TabIndex = 1

        ' Label2
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(200, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama Lengkap"

        ' txtNama
        Me.txtNama.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.txtNama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNama.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNama.Location = New System.Drawing.Point(200, 57)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(250, 25)
        Me.txtNama.TabIndex = 2

        ' Label3
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(480, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Program Studi"

        ' cmbProdi
        Me.cmbProdi.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProdi.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbProdi.FormattingEnabled = True
        Me.cmbProdi.Location = New System.Drawing.Point(480, 57)
        Me.cmbProdi.Name = "cmbProdi"
        Me.cmbProdi.Size = New System.Drawing.Size(160, 25)
        Me.cmbProdi.TabIndex = 3

        ' Label4
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(670, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 19)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Tahun Masuk"

        ' numTahunMasuk
        Me.numTahunMasuk.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.numTahunMasuk.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.numTahunMasuk.Location = New System.Drawing.Point(670, 57)
        Me.numTahunMasuk.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.numTahunMasuk.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.numTahunMasuk.Name = "numTahunMasuk"
        Me.numTahunMasuk.Size = New System.Drawing.Size(100, 25)
        Me.numTahunMasuk.TabIndex = 4
        Me.numTahunMasuk.Value = New Decimal(New Integer() {2025, 0, 0, 0})

        ' Label5
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(800, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 19)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Email"

        ' txtEmail
        Me.txtEmail.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtEmail.Location = New System.Drawing.Point(800, 57)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(170, 25)
        Me.txtEmail.TabIndex = 5

        ' lblEmail
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(20, 100)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(80, 19)
        Me.lblEmail.TabIndex = 10
        Me.lblEmail.Text = "No. Telepon"

        ' txtNoTelepon
        Me.txtNoTelepon.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.txtNoTelepon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoTelepon.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNoTelepon.Location = New System.Drawing.Point(20, 122)
        Me.txtNoTelepon.Name = "txtNoTelepon"
        Me.txtNoTelepon.Size = New System.Drawing.Size(150, 25)
        Me.txtNoTelepon.TabIndex = 6

        ' Label7
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(200, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 19)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Alamat"

        ' txtAlamat
        Me.txtAlamat.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.txtAlamat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlamat.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtAlamat.Location = New System.Drawing.Point(200, 122)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(770, 50)
        Me.txtAlamat.TabIndex = 7

        ' Label6
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 19)
        Me.Label6.TabIndex = 14

        ' btnBaru
        Me.btnBaru.BackColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.btnBaru.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBaru.FlatAppearance.BorderSize = 0
        Me.btnBaru.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBaru.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnBaru.ForeColor = System.Drawing.Color.White
        Me.btnBaru.Location = New System.Drawing.Point(20, 235)
        Me.btnBaru.Name = "btnBaru"
        Me.btnBaru.Size = New System.Drawing.Size(90, 35)
        Me.btnBaru.TabIndex = 8
        Me.btnBaru.Text = "BARU"
        Me.btnBaru.UseVisualStyleBackColor = False

        ' btnSimpan
        Me.btnSimpan.BackColor = System.Drawing.Color.FromArgb(46, 204, 113)
        Me.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSimpan.FlatAppearance.BorderSize = 0
        Me.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.ForeColor = System.Drawing.Color.White
        Me.btnSimpan.Location = New System.Drawing.Point(120, 235)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(90, 35)
        Me.btnSimpan.TabIndex = 9
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.UseVisualStyleBackColor = False

        ' btnEdit
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(241, 196, 15)
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(220, 235)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(90, 35)
        Me.btnEdit.TabIndex = 10
        Me.btnEdit.Text = "UBAH"
        Me.btnEdit.UseVisualStyleBackColor = False

        ' btnHapus
        Me.btnHapus.BackColor = System.Drawing.Color.FromArgb(231, 76, 60)
        Me.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHapus.FlatAppearance.BorderSize = 0
        Me.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHapus.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnHapus.ForeColor = System.Drawing.Color.White
        Me.btnHapus.Location = New System.Drawing.Point(320, 235)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(90, 35)
        Me.btnHapus.TabIndex = 11
        Me.btnHapus.Text = "HAPUS"
        Me.btnHapus.UseVisualStyleBackColor = False

        ' btnRefresh
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(149, 165, 166)
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(420, 235)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 35)
        Me.btnRefresh.TabIndex = 12
        Me.btnRefresh.Text = "REFRESH"
        Me.btnRefresh.UseVisualStyleBackColor = False

        ' frmMahasiswa
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmMahasiswa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Mahasiswa"

        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTahunMasuk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnBaru As Button
    Friend WithEvents txtAlamat As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents numTahunMasuk As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbProdi As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNoTelepon As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNIM As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class