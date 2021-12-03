'   --- Day 1: Sonar Sweep ---
Public Class AOC2021a01
    Public path As String = "X:\Projekte\Advent of code\advent-of-code_old\2021\adventOfCode\input2021-01.txt"
    Dim count As Integer = 0

    Sub OnStart()
        Dim read As New ReadInput(path)
        read.Read()

        Dim rawData(read.rawData.Length - 1) As String
        Dim rawNumber(read.rawData.Length - 1) As Integer


        For i As Integer = 0 To read.rawData.Length - 1
            rawData(i) = read.rawData(i)
        Next

        For i As Integer = 0 To rawData.Length - 1
            rawNumber(i) = CInt(Int(rawData(i)))
        Next

        'CompareDeepth(rawNumber)
        CompareDeepthBetter(rawNumber)
    End Sub

    Sub CompareDeepth(rawNumber() As Integer) 'part 1
        'for 1 to length-1
        For i As Integer = 1 To rawNumber.Length - 1
            If rawNumber(i - 1) - rawNumber(i) < 0 Then
                count += 1
            End If
        Next

        Console.WriteLine("How many measurements are larger than the previous measurement? It is: " & count)
    End Sub

    Sub CompareDeepthBetter(rawNumber() As Integer) 'part 2
        Dim groupNumbers(rawNumber.Length) As Integer '= {}

        For i As Integer = 2 To rawNumber.Length - 1
            groupNumbers(i - 2) = rawNumber(i - 2) + rawNumber(i - 1) + rawNumber(i)
        Next

        For i As Integer = 1 To groupNumbers.Length - 1
            If groupNumbers(i - 1) - groupNumbers(i) < 0 Then
                count += 1
            End If
        Next

        Console.WriteLine("Consider sums of a three-measurement sliding window. How many sums are larger than the previous sum? It is:" & count)
    End Sub
End Class
