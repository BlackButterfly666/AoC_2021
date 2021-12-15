'   --- Day 3: Binary Diagnostic ---
Public Class AOC2021a03
    Public path As String = "X:\Projekte\Advent of code\AoC_2021\2021\adventOfCode\input2021-03.txt"
    'Public path As String = "C:\Users\Notebook\source\input2021-03.txt"

    Sub OnStart()
        Dim read As New ReadInput(path)
        read.Read()

        Dim rawData(read.rawData.Length - 1) As String
        Dim rawNumber(read.rawData.Length - 1) As Integer

        For i As Integer = 0 To read.rawData.Length - 1
            rawData(i) = read.rawData(i)
        Next
        EnergyConsumptionCalc(read.rawData)
    End Sub

    Dim mostCount(11) As Integer 'Oxygen
    Dim leastCount(11) As Integer 'CO2

    Sub EnergyConsumptionCalc(inputArr() As String)
        Dim str As String
        For i As Integer = 0 To inputArr.Length - 1
            str = inputArr(i)
            For j As Integer = 0 To str.Length - 1
                If str(j) = "1" Then
                    mostCount(j) += 1
                End If
            Next
        Next

        For i As Integer = 0 To mostCount.Length - 1
            If mostCount(i) >= inputArr.Length / 2 Then
                mostCount(i) = 1
                leastCount(i) = 0
            Else
                mostCount(i) = 0
                leastCount(i) = 1
            End If
        Next

        For i As Integer = 0 To mostCount.Length - 1
            'Console.Write(mostCount(i)) ' 000101011101
            'Console.WriteLine(" ")
            'Console.Write(leastCount(i)) ' 111010100010
        Next
        O2Rate(inputArr)
    End Sub

    Sub O2Rate(inputArr() As String)
        Dim oxygenRate(inputArr.Length - 1) As String
        Dim co2Rate(inputArr.Length - 1) As String
        Dim mostBit As String
        Dim bufferList As New List(Of String)

        For i As Integer = 0 To inputArr.Length - 1
            oxygenRate(i) = inputArr(i)
            co2Rate(i) = inputArr(i)
        Next

        For length As Integer = 0 To 11
            Dim positiveBit As Integer = 0
            Dim negativeBit As Integer = 0
            Dim str As String

            'bits zählen
            For count As Integer = 0 To oxygenRate.Length - 1
                str = oxygenRate(count)
                If str(length) = "1" Then
                    positiveBit += 1
                Else
                    negativeBit += 1
                End If
            Next

            'bits vergleichen
            If positiveBit >= negativeBit Then
                mostBit = "1"
            Else
                mostBit = "0"
            End If

            'bit Reihen mit mostbit abgleichen. wenn richtig, dann auf liste
            For i As Integer = 0 To oxygenRate.Length - 1
                str = oxygenRate(i)
                If str(length) = mostBit Then
                    bufferList.Add(str)
                End If
            Next

            'redim array, werfe listen inhalt in array, cleare bufferliste
            ReDim oxygenRate(bufferList.Count - 1)
            For i As Integer = 0 To bufferList.Count - 1
                oxygenRate(i) = bufferList(i)
            Next
            bufferList.Clear()
            positiveBit = 0
            negativeBit = 0
        Next
        Console.WriteLine(oxygenRate(0))

        For length As Integer = 0 To 11
            Dim positiveBit As Integer = 0
            Dim negativeBit As Integer = 0
            Dim str As String

            'bits zählen
            For count As Integer = 0 To co2Rate.Length - 1
                str = co2Rate(count)
                If str(length) = "1" Then
                    positiveBit += 1
                Else
                    negativeBit += 1
                End If
            Next

            'bits vergleichen
            If positiveBit < negativeBit Then
                mostBit = "1"
            Else
                mostBit = "0"
            End If

            'bit Reihen mit mostbit abgleichen. wenn richtig, dann auf liste
            For i As Integer = 0 To co2Rate.Length - 1
                str = co2Rate(i)
                If str(length) = mostBit Then
                    bufferList.Add(str)
                End If
            Next

            Console.WriteLine(bufferList.Count)
            'redim array, werfe listen inhalt in array, cleare bufferliste
            If bufferList.Count > 0 Then
                ReDim co2Rate(bufferList.Count - 1)

                For i As Integer = 0 To bufferList.Count - 1
                    co2Rate(i) = bufferList(i)
                Next
                bufferList.Clear()
                positiveBit = 0
                negativeBit = 0
            Else
                Exit For
            End If
        Next
        Console.WriteLine(co2Rate(0))
    End Sub
End Class
