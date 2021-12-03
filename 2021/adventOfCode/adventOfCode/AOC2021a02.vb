'   --- Day 2: Dive! ---
Public Class AOC2021a02
    Public path As String = "X:\Projekte\Advent of code\advent-of-code_old\2021\adventOfCode\input2021-02.txt"

    Sub OnStart()
        Dim read As New ReadInput(path)
        read.Read()

        Dim rawData(read.rawData.Length - 1) As String
        Dim rawNumber(read.rawData.Length - 1) As Integer
        Dim move(rawData.Length - 1) As Movement

        For i As Integer = 0 To read.rawData.Length - 1
            rawData(i) = read.rawData(i)
        Next

        For i As Integer = 0 To rawData.Length - 1
            Dim str() As String = Split(rawData(i), " ")
            Dim nM As New Movement(str(0), str(1))
            move(i) = nM
        Next

        'CalcPosition(move)
        CalcPrecisionPosition(move)
    End Sub

    Sub CalcPosition(move() As Movement)
        Dim depth As Integer = 0
        Dim position As Integer = 0

        For i As Integer = 0 To move.Length - 1
            If move(i).direction = "forward" Then
                position += move(i).steps
            ElseIf move(i).direction = "down" Then
                depth += move(i).steps
            ElseIf move(i).direction = "up" Then
                depth -= move(i).steps
            Else
                Console.WriteLine("Hilfe! Fehler! " & move(i).direction)
            End If
        Next

        Console.WriteLine("position " & position & "depth " & depth)
        position *= depth
        Console.WriteLine("position " & position) ' 2091984
    End Sub

    Sub CalcPrecisionPosition(move() As Movement)
        Dim depth As Integer = 0
        Dim position As Integer = 0
        Dim aim As Integer = 0

        Dim x As Integer

        For i As Integer = 0 To move.Length - 1
            If move(i).direction = "forward" Then
                position += move(i).steps
                x = aim * move(i).steps
                depth += x
                x = 0
            ElseIf move(i).direction = "down" Then
                aim += move(i).steps
            ElseIf move(i).direction = "up" Then
                aim -= move(i).steps
            Else
                Console.WriteLine("Hilfe! Fehler! " & move(i).direction)
            End If
        Next

        Console.WriteLine("position " & position & "depth " & depth)
        position *= depth
        Console.WriteLine("position " & position) ' 2086261056
    End Sub
End Class

Public Class Movement
    Public direction As String
    Public steps As Integer

    Sub New(dir As String, range As Integer)
        direction = dir
        steps = range
    End Sub
End Class
