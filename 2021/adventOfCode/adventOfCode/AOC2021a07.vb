'   --- Day 7: The Treachery of Whales ---
Public Class AOC2021a07
    Public path As String = "X:\Projekte\Advent of code\AoC_2021\2021\adventOfCode\input2021-07.txt"
    Public testPath As String = "X:\Projekte\Advent of code\AoC_2021\2021\adventOfCode\input2021-07.txt"
    'Public path As String = "C:\Users\Notebook\source\input2021-03.txt"

    Sub OnStart()
        Dim read As New ReadInput(path)
        read.Read()

        Dim rawData(read.rawData.Length - 1) As String
        Dim rawNumber(read.rawData.Length - 1) As Integer

        For i As Integer = 0 To read.rawData.Length - 1
            Dim str As String = CStr(read.rawData(i))
            rawData = Split(str, ",")
        Next

        Dim rawDataList As New List(Of String)

        For i As Integer = 0 To rawData.Length - 1
            rawDataList.Add(rawData(i))
        Next

        Dim rawNumberList As New List(Of Integer)

        For i As Integer = 0 To rawData.Length - 1
            rawNumberList.Add(CInt(Int(rawDataList(i))))
        Next

        Dim testRawNumber() As Integer = {16, 1, 2, 0, 4, 2, 7, 1, 2, 14}
        Dim testRawNumberList As New List(Of Integer)

        For i As Integer = 0 To testRawNumber.Length - 1
            testRawNumberList.Add(testRawNumber(i))
        Next
        'CalcFuel(rawNumberList)
        CalcFuelExact(rawNumberList)
    End Sub

    Sub CalcFuel(position As List(Of Integer))
        'Zielposition: 358 FuelUse: 344138
        Dim targetPos As Integer = 483
        Dim fuelUse As Integer = 0
        Dim bufferInt As Integer

        position.Sort()

        targetPos = position.Count / 2
        bufferInt = (position(targetPos - 1) + position(targetPos)) / 2

        For i As Integer = 0 To position.Count - 1
            Dim buffer As Integer
            If position(i) >= bufferInt Then
                buffer = position(i) - bufferInt
                fuelUse += buffer
            Else
                buffer = bufferInt - position(i)
                fuelUse += buffer
            End If
        Next
        'Console.WriteLine("Zielposition: " & bufferInt & " FuelUse: " & fuelUse)
        fuelUse = 0
    End Sub

    Sub CalcFuelExact(position As List(Of Integer)) '{16, 1, 2, 0, 4, 2, 7, 1, 2, 14}
        Dim x As Integer

        'midpoint = x
        For i As Integer = 0 To position.Count - 1
            'Console.Write(position(i) & " ")
            Dim a As Integer
            a = position(i)
            x += a
            Console.WriteLine(x)
        Next

        Console.WriteLine("Insgesamt: " & x & "Anzahl: " & position.Count & "Durchschnitt: " & x / position.Count)
        x /= (position.Count)
        Console.WriteLine(x)

        Dim fuelUse As Integer = 0
        '482,5 - Rundung ist doof
        x = 482

        For i As Integer = 0 To position.Count - 1
            Dim bufferInt As Integer = 0
            Dim buffer As Integer

            Console.WriteLine("durchschnittsposition: " & x)

            If position(i) >= x Then
                buffer = position(i) - x
            Else
                buffer = x - position(i)
            End If

            Console.WriteLine("Positionsdifferenz: " & buffer)

            For j As Integer = buffer To 0 Step -1
                bufferInt += j
                'Console.WriteLine("fuelUse " & fuelUse)
            Next
            Console.WriteLine("fuelbuffer " & bufferInt)
            fuelUse += bufferInt
        Next
        Console.WriteLine(fuelUse)
        '94862124
    End Sub
End Class

