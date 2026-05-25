Imports System.Configuration

Module Program
    <STAThread()>
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Try
            Console.WriteLine("=" & String.Empty.PadRight(50, "="))
            Console.WriteLine("🚀 APLIKASI MULAI")
            Console.WriteLine("=" & String.Empty.PadRight(50, "="))

            ' ========================================
            ' STEP 1: CEK & BUAT DATABASE
            ' ========================================
            Console.WriteLine("⏳ Step 1: Mengecek & membuat database...")
            If Not Database.CekDanBuatDatabase() Then
                MessageBox.Show(
                    "❌ Database gagal dibuat!" & vbCrLf & vbCrLf &
                    "Pastikan:" & vbCrLf &
                    "1. MySQL Server RUNNING" & vbCrLf &
                    "2. Username/Password benar di Database.vb" & vbCrLf &
                    "3. Port 3306 tidak tertanam",
                    "Error Setup Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
                Application.Exit()
                Return
            End If
            Console.WriteLine("✅ Database OK")

            ' ========================================
            ' STEP 2: CEK KONEKSI
            ' ========================================
            Console.WriteLine("⏳ Step 2: Mengecek koneksi database...")
            If Not Database.CekKoneksi() Then
                MessageBox.Show(
                    "❌ Koneksi database gagal!",
                    "Error Koneksi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
                Application.Exit()
                Return
            End If
            Console.WriteLine("✅ Koneksi OK")

            ' ========================================
            ' STEP 3: JALANKAN LOGIN FORM
            ' ========================================
            Console.WriteLine("⏳ Step 3: Menampilkan Login Form...")
            Application.Run(New frmLogin())

            Console.WriteLine("=" & String.Empty.PadRight(50, "="))
            Console.WriteLine("👋 APLIKASI DITUTUP")
            Console.WriteLine("=" & String.Empty.PadRight(50, "="))

        Catch ex As Exception
            MessageBox.Show(
                "❌ Error Fatal:" & vbCrLf & vbCrLf &
                ex.Message & vbCrLf & vbCrLf &
                "Stack Trace:" & vbCrLf &
                ex.StackTrace,
                "Fatal Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub
End Module