Public Class User

    ' ========================================
    ' PROPERTIES
    ' ========================================
    Public Property UserID As Integer
    Public Property Username As String
    Public Property NamaLengkap As String
    Public Property Role As String
    Public Property Email As String
    Public Property NoTelepon As String

    ' ========================================
    ' STATIC CURRENT USER
    ' ========================================
    Public Shared Property CurrentUser As User

End Class