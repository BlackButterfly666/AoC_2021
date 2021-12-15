'   --- Day 6: Lanternfish ---
Public Class AOC2021a06

    Public path As String = "X:\Projekte\Advent of code\AoC_2021\2021\adventOfCode\input2021-06.txt"
    'Public path As String = "C:\Users\Notebook\source\input2021-03.txt"

    Sub OnStart()
        Dim read As New ReadInput(path)
        read.Read()

        Dim rawData() As String = {}
        'Dim rawNumber(read.rawData.Length - 1) As Integer

        For i As Integer = 0 To read.rawData.Length - 1
            ReDim Preserve rawData(i)
            rawData(i) = read.rawData(i)
        Next

        Dim dataArr() As String = {}
        Dim dataInput() As Integer = {1, 2, 1, 1, 1, 1, 1, 1, 2, 1, 3, 1, 1, 1, 1, 3, 1, 1, 1, 5, 1, 1, 1, 4, 5, 1, 1, 1, 3, 4, 1, 1, 1, 1, 1, 1, 1, 5, 1, 4, 1, 1, 1, 1, 1, 1, 1, 5, 1, 3, 1, 3, 1, 1, 1, 5, 1, 1, 1, 1, 1, 5, 4, 1, 2, 4, 4, 1, 1, 1, 1, 1, 5, 1, 1, 1, 1, 1, 5, 4, 3, 1, 1, 1, 1, 1, 1, 1, 5, 1, 3, 1, 4, 1, 1, 3, 1, 1, 1, 1, 1, 1, 2, 1, 4, 1, 3, 1, 1, 1, 1, 1, 5, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 4, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 1, 4, 1, 1, 1, 1, 1, 3, 1, 3, 3, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 1, 1, 1, 5, 1, 1, 1, 1, 2, 1, 1, 1, 4, 1, 1, 1, 2, 3, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 3, 1, 2, 1, 1, 5, 4, 1, 1, 2, 1, 1, 1, 3, 1, 4, 1, 1, 1, 1, 3, 1, 2, 5, 1, 1, 1, 5, 1, 1, 1, 1, 1, 4, 1, 1, 4, 1, 1, 1, 2, 2, 2, 2, 4, 3, 1, 1, 3, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1, 4, 2, 1, 4, 1, 1, 1, 1, 1, 5, 1, 1, 4, 2, 1, 1, 2, 5, 4, 2, 1, 1, 1, 1, 4, 2, 3, 5, 2, 1, 5, 1, 3, 1, 1, 5, 1, 1, 4, 5, 1, 1, 1, 1, 4}

        For i As Integer = 0 To rawData.Length - 1
            Dim str As String = rawData(i)
            Dim buffer() As String = Split(rawData(i), ",")
            'Dim buffer2() As String = Split(dataInput, ",")

            'For j As Integer = 0 To buffer.Length - 1
            '    ReDim Preserve dataArr(j)
            '    dataArr(j) = buffer(j)
            'Next
            'For j As Integer = 0 To buffer2.Length - 1
            '    ReDim Preserve dataArr(j)
            '    dataArr(j) = buffer2(j)
            'Next
        Next

        Dim daysLeft As New List(Of Integer)
        For i As Integer = 0 To dataArr.Length - 1
            daysLeft.Add(CInt(Int(Str(i))))
        Next

        Dim test() As Integer = {3, 4, 3, 1, 2}
        Dim testList As New List(Of Integer)
        'For i As Integer = 0 To test.Length - 1
        '    testList.Add(test(i))
        'Next
        For i As Integer = 0 To dataInput.Length - 1
            testList.Add(dataInput(i))

        Next

        'CalcFish(daysLeft)
        'CalcFish(testList)
        'CalcFishForever(daysLeft)
        CalcFishForever(testList)
    End Sub

    Sub CalcFish(daysLeft As List(Of Integer))
        'Dim daysLeft(str.Length - 1) As Integer
        'Dim daysLeft As New List(Of Integer)
        'For i As Integer = 0 To str.Length - 1
        '    daysLeft.Add(CInt(Int(str(i))))
        'Next
        Dim days As Integer = 80 'Part 1

        Dim list01 As New List(Of Integer)

        For i As Integer = 0 To daysLeft.Count - 1
            list01.Add(daysLeft(i))
        Next

        'Console.WriteLine(daysLeft.Count) '300
        For x As Integer = 0 To days - 1
            For i As Integer = 0 To daysLeft.Count - 1
                If daysLeft(i) = 0 Then
                    daysLeft(i) = 6
                    daysLeft.Add(8)
                Else
                    daysLeft(i) -= 1
                End If
            Next
            Console.WriteLine(x)
        Next
        Console.WriteLine(daysLeft.Count)
    End Sub

    Sub CalcFishForever(fishList As List(Of Integer))
        Dim days As Integer = 256 'Part 2
        Dim count() As Long = {0, 0, 0, 0, 0, 0, 0, 0, 0}

        For i As Integer = 0 To fishList.Count - 1
            ' Each day, a 0 becomes a 6 and adds a new 8 to the end of the list,
            ' while each other number decreases by 1 if it was present at the start of the day.

            Select Case True
                Case fishList(i) = 0
                    count(0) += 1
                Case fishList(i) = 1
                    count(1) += 1
                Case fishList(i) = 2
                    count(2) += 1
                Case fishList(i) = 3
                    count(3) += 1
                Case fishList(i) = 4
                    count(4) += 1
                Case fishList(i) = 5
                    count(5) += 1
                Case fishList(i) = 6
                    count(6) += 1
                Case fishList(i) = 7
                    count(7) += 1
                Case fishList(i) = 8
                    count(8) += 1
            End Select
        Next

        Dim buffer As Long = 0
        For i As Integer = 0 To days - 1
            Console.WriteLine("day: " & i)

            buffer = count(0)
            count(0) = count(1)
            count(1) = count(2)
            count(2) = count(3)
            count(3) = count(4)
            count(4) = count(5)
            count(5) = count(6)
            count(6) = count(7) + buffer
            count(7) = count(8)
            count(8) = buffer
        Next

        Dim a As Long
        For i As Integer = 0 To count.Length - 1
            a += count(i)
        Next
        Console.WriteLine(a)
        Console.WriteLine("count bei 0: " & count(0))
        Console.WriteLine("count bei 1: " & count(1))
        Console.WriteLine("count bei 2: " & count(2))
        Console.WriteLine("count bei 3: " & count(3))
        Console.WriteLine("count bei 4: " & count(4))
        Console.WriteLine("count bei 5: " & count(5))
        Console.WriteLine("count bei 6: " & count(6))
        Console.WriteLine("count bei 7: " & count(7))
        Console.WriteLine("count bei 8: " & count(8))
    End Sub

End Class
