Public Class ReadInput
    Public path As String
    Public rawData() As String = {}
    Public Sub Read()
        Dim raw() As String = IO.File.ReadAllLines(path)

        For i As Integer = 0 To raw.Length - 1
            ReDim Preserve rawData(i)
            rawData(i) = raw(i)
        Next
    End Sub

    Sub New(path_ As String)
        path = path_
    End Sub
End Class
