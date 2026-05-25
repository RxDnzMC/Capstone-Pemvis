Imports System.Security.Cryptography
Imports System.Text

Public Class Security

    ' ========================================
    ' FUNGSI MD5 HASH
    ' ========================================
    Public Shared Function MD5Hash(input As String) As String
        Try
            Using provider = New MD5CryptoServiceProvider()
                Dim hash = provider.ComputeHash(Encoding.UTF8.GetBytes(input))
                Dim sb As New StringBuilder()
                For Each b In hash
                    sb.Append(b.ToString("x2"))
                Next
                Return sb.ToString()
            End Using
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ' ========================================
    ' FUNGSI LOG AKTIVITAS
    ' ========================================
    Public Shared Sub LogAktivitas(userID As Integer, aktivitas As String, tabel As String, Optional recordID As Integer = 0, Optional keterangan As String = "")
        Try
            Dim ipAddress As String = GetIPAddress()
            Dim query As String = String.Format(
                "INSERT INTO tbl_Log (UserID, Aktivitas, Tabel, RecordID, Keterangan, TanggalAktivitas, IPAddress, Status) " &
                "VALUES ({0}, N'{1}', N'{2}', {3}, N'{4}', GETDATE(), N'{5}', 'Sukses')",
                userID, aktivitas, tabel, recordID, keterangan.Replace("'", "''"), ipAddress)

            Database.ExecuteNonQuery(query)
        Catch ex As Exception
            ' Jangan tampilkan error, hanya log saja
        End Try
    End Sub

    ' ========================================
    ' FUNGSI GET IP ADDRESS
    ' ========================================
    Private Shared Function GetIPAddress() As String
        Try
            Dim host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
            For Each ip In host.AddressList
                If ip.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                    Return ip.ToString()
                End If
            Next
        Catch
        End Try
        Return "127.0.0.1"
    End Function

End Class