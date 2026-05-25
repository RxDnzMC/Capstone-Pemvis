Imports System.Data
Imports MySqlConnector

Public Class Database

    ' ========================================
    ' CONNECTION STRING
    ' ========================================
    Private Shared connStr As String = "Server=localhost;Database=DB_NilaiMahasiswa;User=root;Password=;Port=3306;"
    Private Shared connStrMaster As String = "Server=localhost;User=root;Password=;Port=3306;"

    ' ========================================
    ' FUNGSI CEK DAN BUAT DATABASE
    ' ========================================
    Public Shared Function CekDanBuatDatabase() As Boolean
        Try
            ' Cek database ada atau tidak
            If CekDatabaseExist() Then
                Console.WriteLine("✓ Database sudah ada")
                Return True
            End If

            ' Database tidak ada, BUAT
            Console.WriteLine("⏳ Database tidak ada, membuat...")
            Return BuatDatabase()

        Catch ex As Exception
            Console.WriteLine("❌ Error CekDanBuatDatabase: " & ex.Message)
            Return False
        End Try
    End Function

    ' ========================================
    ' CEK DATABASE EXIST
    ' ========================================
    Private Shared Function CekDatabaseExist() As Boolean
        Try
            Using conn = New MySqlConnection(connStr)
                conn.Open()
                Console.WriteLine("✓ Database terhubung")
                Return True
            End Using
        Catch ex As Exception
            Console.WriteLine("⚠ Database belum ada: " & ex.Message)
            Return False
        End Try
    End Function

    ' ========================================
    ' BUAT DATABASE & TABEL
    ' ========================================
    Private Shared Function BuatDatabase() As Boolean
        Try
            ' STEP 1: CREATE DATABASE (gunakan Master Connection)
            Console.WriteLine("1️⃣ Membuat database...")
            Using connMaster = New MySqlConnection(connStrMaster)
                connMaster.Open()
                Console.WriteLine("   ✓ Terhubung ke MySQL")

                Dim createDB As String = "CREATE DATABASE IF NOT EXISTS DB_NilaiMahasiswa CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;"
                Using cmd = New MySqlCommand(createDB, connMaster)
                    cmd.ExecuteNonQuery()
                End Using
                Console.WriteLine("   ✓ Database berhasil dibuat")
            End Using

            ' STEP 2: TUNGGU DATABASE SIAP
            System.Threading.Thread.Sleep(2000)
            Console.WriteLine("2️⃣ Tunggu 2 detik...")

            ' STEP 3: CREATE TABLES
            Console.WriteLine("3️⃣ Membuat tabel dan data...")
            Using connDB = New MySqlConnection(connStr)
                connDB.Open()
                Console.WriteLine("   ✓ Terhubung ke DB_NilaiMahasiswa")

                Dim sqlScript As String = GetSQLScript()
                Dim queries As String() = sqlScript.Split(New String() {";"}, StringSplitOptions.RemoveEmptyEntries)

                Dim counter As Integer = 0
                For Each query In queries
                    Dim trimmed As String = query.Trim()
                    If Not String.IsNullOrWhiteSpace(trimmed) Then
                        Using cmd = New MySqlCommand(trimmed, connDB)
                            cmd.CommandTimeout = 300
                            cmd.ExecuteNonQuery()
                            counter += 1
                        End Using
                    End If
                Next

                Console.WriteLine($"   ✓ {counter} queries executed")
            End Using

            Console.WriteLine("✅ Database berhasil setup!")
            Return True

        Catch ex As Exception
            Console.WriteLine("❌ Error BuatDatabase: " & ex.Message)
            Console.WriteLine("   Stack: " & ex.StackTrace)
            Return False
        End Try
    End Function

    ' ========================================
    ' GET SQL SCRIPT
    ' ========================================
    Private Shared Function GetSQLScript() As String
        Return "
USE DB_NilaiMahasiswa;

CREATE TABLE IF NOT EXISTS tbl_ProgramStudi (
    ProdiID INT AUTO_INCREMENT PRIMARY KEY,
    NamaProdi VARCHAR(100) NOT NULL,
    Kode VARCHAR(10) NOT NULL UNIQUE,
    IsAktif TINYINT DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS tbl_TahunAkademik (
    TahunAkademikID INT AUTO_INCREMENT PRIMARY KEY,
    Tahun VARCHAR(9) NOT NULL UNIQUE,
    Semester INT NOT NULL,
    IsAktif TINYINT DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS tbl_Users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    NamaLengkap VARCHAR(100) NOT NULL,
    Role VARCHAR(20) NOT NULL,
    Email VARCHAR(100),
    NoTelepon VARCHAR(15),
    IsAktif TINYINT DEFAULT 1,
    TanggalDibuat DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS tbl_Mahasiswa (
    MahasiswaID INT AUTO_INCREMENT PRIMARY KEY,
    NIM VARCHAR(20) NOT NULL UNIQUE,
    NamaLengkap VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    NoTelepon VARCHAR(15),
    ProdiID INT NOT NULL,
    TahunMasuk INT,
    Alamat VARCHAR(255),
    IsAktif TINYINT DEFAULT 1,
    FOREIGN KEY (ProdiID) REFERENCES tbl_ProgramStudi(ProdiID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS tbl_MataKuliah (
    MataKuliahID INT AUTO_INCREMENT PRIMARY KEY,
    KodeMK VARCHAR(20) NOT NULL,
    NamaMK VARCHAR(100) NOT NULL,
    SKS INT,
    ProdiID INT NOT NULL,
    IsAktif TINYINT DEFAULT 1,
    FOREIGN KEY (ProdiID) REFERENCES tbl_ProgramStudi(ProdiID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS tbl_Nilai (
    NilaiID INT AUTO_INCREMENT PRIMARY KEY,
    MahasiswaID INT NOT NULL,
    MataKuliahID INT NOT NULL,
    TahunAkademikID INT NOT NULL,
    NilaiPraktikum DECIMAL(5,2),
    NilaiUTS DECIMAL(5,2),
    NilaiUAS DECIMAL(5,2),
    NilaiTugas DECIMAL(5,2),
    NilaiAffektif DECIMAL(5,2),
    NilaiAkhir DECIMAL(5,2),
    Grade VARCHAR(1),
    Keterangan VARCHAR(50),
    TanggalInput DATETIME DEFAULT CURRENT_TIMESTAMP,
    UserIDInput INT,
    FOREIGN KEY (MahasiswaID) REFERENCES tbl_Mahasiswa(MahasiswaID),
    FOREIGN KEY (MataKuliahID) REFERENCES tbl_MataKuliah(MataKuliahID),
    FOREIGN KEY (TahunAkademikID) REFERENCES tbl_TahunAkademik(TahunAkademikID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS tbl_Log (
    LogID INT AUTO_INCREMENT PRIMARY KEY,
    UserID INT NOT NULL,
    Aktivitas VARCHAR(100) NOT NULL,
    Tabel VARCHAR(50),
    RecordID INT,
    Keterangan LONGTEXT,
    TanggalAktivitas DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserID) REFERENCES tbl_Users(UserID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT IGNORE INTO tbl_ProgramStudi (NamaProdi, Kode) VALUES 
('Teknik Informatika', 'TI'),
('Sistem Informasi', 'SI'),
('Manajemen Informatika', 'MI');

INSERT IGNORE INTO tbl_TahunAkademik (Tahun, Semester) VALUES 
('2025/2026', 1),
('2025/2026', 2);

INSERT IGNORE INTO tbl_Users (Username, Password, NamaLengkap, Role, Email, NoTelepon) VALUES 
('admin', '21232f297a57a5a743894a0e4a801fc3', 'Administrator', 'Admin', 'admin@univ.ac.id', '081234567890'),
('dosen1', 'e807f1fcf82d132f9bb018ca6738a19f', 'Dr. Budi Santoso', 'Dosen', 'budi@univ.ac.id', '081234567891'),
('viewer1', '6512bd43d9caa6e02c990b0a82652dca', 'Viewer User', 'Viewer', 'viewer@univ.ac.id', '081234567892');

INSERT IGNORE INTO tbl_MataKuliah (KodeMK, NamaMK, SKS, ProdiID) VALUES 
('MI101', 'Pemrograman Dasar', 3, 1),
('MI102', 'Basis Data', 3, 1),
('MI103', 'Jaringan Komputer', 3, 1),
('SI101', 'Sistem Informasi Bisnis', 3, 2),
('SI102', 'Analisis Sistem', 3, 2);

INSERT IGNORE INTO tbl_Mahasiswa (NIM, NamaLengkap, Email, NoTelepon, ProdiID, TahunMasuk, Alamat) VALUES 
('2021001', 'Ahmad Rizki', 'ahmad@student.ac.id', '082111111111', 1, 2021, 'Jl. Merdeka No.1'),
('2021002', 'Bintang Permata', 'bintang@student.ac.id', '082111111112', 1, 2021, 'Jl. Sudirman No.2'),
('2021003', 'Citra Dewi', 'citra@student.ac.id', '082111111113', 1, 2021, 'Jl. Ahmad Yani No.3'),
('2022001', 'Doni Setiawan', 'doni@student.ac.id', '082111111114', 2, 2022, 'Jl. Gatot Subroto No.4'),
('2022002', 'Eka Putri', 'eka@student.ac.id', '082111111115', 2, 2022, 'Jl. Diponegoro No.5');
"
    End Function

    ' ========================================
    ' EXECUTE QUERY (SELECT)
    ' ========================================
    Public Shared Function ExecuteQuery(query As String) As DataTable
        Try
            Using conn = New MySqlConnection(connStr)
                Using adapter = New MySqlDataAdapter(query, conn)
                    Dim dt As New DataTable
                    adapter.Fill(dt)
                    Return dt
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("❌ ExecuteQuery Error: " & ex.Message)
            Return Nothing
        End Try
    End Function

    ' ========================================
    ' EXECUTE NON QUERY
    ' ========================================
    Public Shared Function ExecuteNonQuery(query As String) As Boolean
        Try
            Using conn = New MySqlConnection(connStr)
                conn.Open()
                Using cmd = New MySqlCommand(query, conn)
                    cmd.ExecuteNonQuery()
                    Return True
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("❌ ExecuteNonQuery Error: " & ex.Message)
            Return False
        End Try
    End Function

    ' ========================================
    ' EXECUTE SCALAR
    ' ========================================
    Public Shared Function ExecuteScalar(query As String) As Object
        Try
            Using conn = New MySqlConnection(connStr)
                conn.Open()
                Using cmd = New MySqlCommand(query, conn)
                    Return cmd.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("❌ ExecuteScalar Error: " & ex.Message)
            Return Nothing
        End Try
    End Function

    ' ========================================
    ' CEK KONEKSI
    ' ========================================
    Public Shared Function CekKoneksi() As Boolean
        Try
            Using conn = New MySqlConnection(connStr)
                conn.Open()
                Console.WriteLine("✓ Koneksi database berhasil")
                Return True
            End Using
        Catch ex As Exception
            Console.WriteLine("❌ Koneksi Error: " & ex.Message)
            Return False
        End Try
    End Function

End Class