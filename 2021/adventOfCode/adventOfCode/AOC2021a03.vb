'   --- Day 2: Dive! ---
Public Class AOC2021a03
    Public path As String = "X:\Projekte\Advent of code\advent-of-code_old\2021\adventOfCode\input2021-03.txt"

    Sub OnStart()
        Dim read As New ReadInput(path)
        read.Read()

        Dim rawData(read.rawData.Length - 1) As String
        Dim rawNumber(read.rawData.Length - 1) As Integer

        For i As Integer = 0 To read.rawData.Length - 1
            rawData(i) = read.rawData(i)
        Next
        EnergyConsumptionCalc(read.rawData)
        'AirQualityCalc(read.rawData)
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
            Console.Write(mostCount(i)) ' 000101011101
            Console.Write(leastCount(i)) ' 111010100010
        Next
        AirQualityCalc(inputArr)
    End Sub

    Sub AirQualityCalc(inputArr() As String)

        'meist
        Dim mostCount As String = "000101011101"
        Dim leastCount As String = "111010100010"
        Dim mostBitsList As List(Of String)
        Dim leastBitsList As List(Of String)
        Dim str As String

        For i As Integer = 0 To mostCount.Length - 1






        Next


        For i As Integer = 0 To inputArr.Length - 1
            str = inputArr(i)
            If str(0) = mostCount(0) Then
                mostBitsList.Add(inputArr(i))
            Else
                leastBitsList.Add(inputArr(i))
            End If
        Next

        For i As Integer = 0 To mostBitsList.Count - 1
            Dim arr() As String = {}
            arr(i) = mostBitsList(i)
        Next





    End Sub
End Class

'0001 0101 1101 gamma
'349
'1110 1010 0010 epsilon
'3746
'1307354

