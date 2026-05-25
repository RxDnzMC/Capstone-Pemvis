Public Class NilaiMahasiswa

    ' ========================================
    ' PROPERTIES
    ' ========================================
    Public Property NilaiID As Integer
    Public Property MahasiswaID As Integer
    Public Property MahasiswaNama As String
    Public Property MahasiswaNIM As String
    Public Property MataKuliahID As Integer
    Public Property MataKuliahNama As String
    Public Property TahunAkademikID As Integer
    Public Property TahunAkademik As String
    Public Property NilaiPraktikum As Decimal
    Public Property NilaiUTS As Decimal
    Public Property NilaiUAS As Decimal
    Public Property NilaiTugas As Decimal
    Public Property NilaiAffektif As Decimal
    Public Property NilaiAkhir As Decimal
    Public Property Grade As String
    Public Property Keterangan As String
    Public Property TanggalInput As DateTime
    Public Property UserInput As String

    ' ========================================
    ' FUNGSI HITUNG NILAI AKHIR
    ' ========================================
    Public Function HitungNilaiAkhir() As Decimal
        Dim hasil = (NilaiPraktikum * 0.15) + (NilaiUTS * 0.25) + (NilaiUAS * 0.3) + (NilaiTugas * 0.2) + (NilaiAffektif * 0.1)
        Return Math.Round(hasil, 2)
    End Function

    ' ========================================
    ' FUNGSI AMBIL GRADE
    ' ========================================
    Public Function GetGrade(nilai As Decimal) As String
        If nilai >= 85 Then
            Return "A"
        ElseIf nilai >= 75 Then
            Return "B"
        ElseIf nilai >= 65 Then
            Return "C"
        ElseIf nilai >= 50 Then
            Return "D"
        Else
            Return "E"
        End If
    End Function

    ' ========================================
    ' FUNGSI AMBIL KETERANGAN
    ' ========================================
    Public Function GetKeterangan(nilai As Decimal) As String
        If nilai >= 60 Then
            Return "Lulus"
        Else
            Return "Tidak Lulus"
        End If
    End Function

End Class