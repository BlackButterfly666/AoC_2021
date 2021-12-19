'   --- Day 5: Hydrothermal Venture ---
Public Class AOC2021a05

    Public path As String = "X:\Projekte\Advent of code\AoC_2021\2021\adventOfCode\input2021-05.txt"
    'Public path As String = "X:\Projekte\Advent of code\AoC_2021\2021\adventOfCode\input2021-05test.txt"

    Dim vents As New List(Of Vent)


    Sub OnStart()
        Dim read As New ReadInput(path)
        read.Read()

        Dim rawData(read.rawData.Length - 1) As String
        'Dim rawNumber(read.rawData.Length - 1) As Integer

        For i As Integer = 0 To read.rawData.Length - 1
            Dim str() As String
            Dim buffer() As String
            Dim a(1) As Integer
            Dim b(1) As Integer
            str = Split(read.rawData(i), " -> ")
            'str "x,y" zu x und y teilen
            buffer = Split(str(0), ",")
            a(0) = CInt(Int(buffer(0)))
            a(1) = CInt(Int(buffer(1)))

            buffer = Split(str(1), ",")
            b(0) = CInt(Int(buffer(0)))
            b(1) = CInt(Int(buffer(1)))

            Dim x As New Vent(a, b)
            vents.Add(x)
        Next
        ClearLines()
        BuildField()
        'PrintIt()
        SearchVents()
        SortDiagonalVents()
        SearchDiagonalVents()
        CombineVentLists()
        CountVentCrossing()
    End Sub

    Dim diagonal As New List(Of Vent)
    Dim straight As New List(Of Vent)

    Sub ClearLines()
        For i As Integer = 0 To vents.Count - 1
            If vents(i).fromPos(0) <> vents(i).toPos(0) And vents(i).fromPos(1) <> vents(i).toPos(1) Then
                diagonal.Add(vents(i))
            Else
                straight.Add(vents(i))
            End If
        Next
    End Sub

    Dim fieldList As New List(Of List(Of Integer)) 'y -> vertical

    'Dim inputCount As Integer = 9
    Dim inputCount As Integer = 1000


    Sub BuildField()
        For j As Integer = 0 To inputCount
            Dim fieldLine As New List(Of Integer) 'x -> horizontal -> beschreiben mit count
            For i As Integer = 0 To inputCount
                fieldLine.Add(0)
            Next
            fieldList.Add(fieldLine)
        Next
    End Sub

    Sub PrintIt()
        For i As Integer = 0 To fieldList.Count - 1
            Dim fieldLine As List(Of Integer) = fieldList(i)
            For j As Integer = 0 To fieldLine.Count - 1
                Console.Write(fieldLine(j) & " ")
            Next
            Console.WriteLine()
        Next
    End Sub

    Dim allVents As New List(Of Integer())

    Sub SearchVents()
        'vents List of Vents
        For i As Integer = 0 To straight.Count - 1

            Dim xFrom As Integer = straight(i).fromPos(0)
            Dim xTo As Integer = straight(i).toPos(0)
            Dim yFrom As Integer = straight(i).fromPos(1)
            Dim yTo As Integer = straight(i).toPos(1)

            If xFrom = xTo Then
                If yFrom > yTo Then
                    For j As Integer = yTo To yFrom
                        allVents.Add({xFrom, j})
                    Next
                ElseIf yFrom < yTo Then
                    For j As Integer = yFrom To yTo
                        allVents.Add({xFrom, j})
                    Next
                End If
            ElseIf yFrom = yTo Then
                If xFrom > xTo Then
                    For j As Integer = xTo To xFrom
                        allVents.Add({j, yFrom})
                    Next
                ElseIf xFrom < xTo Then
                    For j As Integer = xFrom To xTo
                        allVents.Add({j, yFrom})
                    Next
                End If
            End If
        Next

        For i As Integer = 0 To allVents.Count - 1
            Dim x() As Integer = allVents(i)

            'Console.WriteLine(x(0) & " " & x(1))
        Next

    End Sub

    Dim samesame As New List(Of Vent) '(1,1  2,2  3,3)
    Dim parallel As New List(Of Vent) '(7,9  8,8  9,7)

    Sub SortDiagonalVents()
        'diagonal 

        For i As Integer = 0 To diagonal.Count - 1

            Dim xFrom As Integer = diagonal(i).fromPos(0)
            Dim xTo As Integer = diagonal(i).toPos(0)
            Dim yFrom As Integer = diagonal(i).fromPos(1)
            Dim yTo As Integer = diagonal(i).toPos(1)

            If xFrom = yFrom And xTo = yTo Then
                samesame.Add(diagonal(i))
            Else
                parallel.Add(diagonal(i))
            End If
        Next
    End Sub

    Dim allDiagonalVents As New List(Of Integer())

    Sub SearchDiagonalVents()
        For i As Integer = 0 To samesame.Count - 1
            Dim xFrom As Integer = samesame(i).fromPos(0)
            Dim xTo As Integer = samesame(i).toPos(0)

            If xFrom < xTo Then
                For j As Integer = xFrom To xTo
                    allDiagonalVents.Add({j, j})
                Next
            ElseIf xFrom > xTo Then
                For j As Integer = xTo To xFrom
                    allDiagonalVents.Add({j, j})
                Next
            End If
        Next

        For i As Integer = 0 To parallel.Count - 1
            Dim xFrom As Integer = parallel(i).fromPos(0)
            Dim xTo As Integer = parallel(i).toPos(0)
            Dim yFrom As Integer = parallel(i).fromPos(1)
            Dim yTo As Integer = parallel(i).toPos(1)

            'x,y -> x,y
            '6,4 -> 2,0
            '7,9 -> 9,7
            '____________________________________________________________________________
            'Todo

            If xFrom > xTo And yFrom > yTo Then     '6,4 -> 2,0
                For j As Integer = 0 To xFrom - xTo
                    allDiagonalVents.Add({xFrom - j, yFrom - j})
                Next
            ElseIf xFrom > xTo And yFrom < yTo Then '9,7 -> 7,9
                For j As Integer = 0 To xFrom - xTo
                    allDiagonalVents.Add({xFrom - j, yFrom + j})
                Next
            ElseIf xFrom < xTo And yFrom > yTo Then '7,9 -> 9,7 
                For j As Integer = 0 To xTo - xFrom
                    allDiagonalVents.Add({xFrom + j, yFrom - j})
                Next
            ElseIf xFrom < xTo And yFrom < yTo Then '2,0 -> 6,4
                For j As Integer = 0 To xTo - xFrom
                    allDiagonalVents.Add({xFrom + j, yFrom + j})
                Next
            Else
                Console.WriteLine("Diagonal Vents laufen nicht")
            End If







            'If xFrom < yFrom Then
            '    Dim a As Integer = (yFrom - xFrom) + 1
            '    For j As Integer = 0 To a
            '        allDiagonalVents.Add({xFrom + j, yFrom - j})
            '    Next
            'ElseIf xFrom > yFrom Then
            '    Dim a As Integer = (xFrom - yFrom) + 1
            '    For j As Integer = 0 To a
            '        allDiagonalVents.Add({yFrom + j, xFrom - j})
            '    Next
            'End If
            '_____________________________________________________________________________
        Next
    End Sub

    Sub CombineVentLists()
        For i As Integer = 0 To allDiagonalVents.Count - 1
            allVents.Add(allDiagonalVents(i))
        Next
    End Sub

    Dim rightVents As Integer
    Sub CountVentCrossing()
        For i As Integer = 0 To allVents.Count - 1
            Dim arr As Integer() = allVents(i)

            Dim y As Integer = arr(1)
            Dim fieldLine As List(Of Integer) = fieldList(y)

            Dim x As Integer = arr(0)
            fieldLine(x) += 1
        Next
            SearchRightVents()
        'For i As Integer = 0 To fieldList.Count - 1
        '    Dim fieldLine As List(Of Integer) = fieldList(i)
        '    For k As Integer = 0 To fieldLine.Count - 1
        '        If fieldLine(k) <> 0 And fieldLine(k) <> 1001 Then
        '            rightVents += 1
        '            'Console.WriteLine(rightVents)

        '        End If
        '    Next
        'Next
        'PrintIt()
        'Console.WriteLine(rightVents)
    End Sub

    Sub SearchRightVents()
        Dim dict As New Dictionary(Of Integer, Integer)
        For i As Integer = 0 To fieldList.Count - 1
            Dim fieldLine As List(Of Integer) = fieldList(i)
            For k As Integer = 0 To fieldLine.Count - 1
                If dict.ContainsKey(fieldLine(k)) Then
                    dict.Item(fieldLine(k)) += 1
                Else
                    dict.Add(fieldLine(k), 1)
                End If

                For Each element In dict.Keys
                    dict.Remove(0)
                    dict.Remove(1)
                Next


                For Each element In dict.Keys

                    'Console.WriteLine(element)
                Next

                'If fieldLine(k) <> 0 And fieldLine(k) <> 1001 Then
                '    rightVents += 1
                '    'Console.WriteLine(rightVents)

                'End If
            Next
        Next

        'PrintIt()
        'Console.WriteLine(" ")

        Dim count As Integer = dict.Item(2) + dict.Item(3) + dict.Item(4) + dict.Item(5)
        'Console.WriteLine(dict.Item(2))
        'Console.WriteLine(dict.Item(3))
        'Console.WriteLine(dict.Item(4))
        Console.WriteLine("dict.Count: " & dict.Count)
        Console.WriteLine("all entrties above 2: " & count)
    End Sub
End Class

Public Class Vent
    Public fromPos(1) As Integer
    Public toPos(1) As Integer

    Sub New(fromP() As Integer, toP() As Integer)
        fromPos = fromP
        toPos = toP
    End Sub
End Class

'22088 richtig