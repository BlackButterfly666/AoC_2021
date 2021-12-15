'   --- Day 4: Giant Squid ---
Public Class AOC2021a04
    Public pathField As String = "X:\Projekte\Advent of code\AoC_2021\2021\adventOfCode\input2021-04test-field.txt"
    Public pathNumbers As String = "X:\Projekte\Advent of code\AoC_2021\2021\adventOfCode\input2021-04test-numbers.txt"
    'Public path As String = "C:\Users\Notebook\source\input2021-04.txt"

    Sub OnStart()
        Dim readField As New ReadInput(pathField)
        Dim readNumbers As New ReadInput(pathNumbers)
        readField.Read()
        readNumbers.Read()

        Dim rawDataField(readField.rawData.Length - 1) As String
        Dim rawDataNumbers(readNumbers.rawData.Length - 1) As String
        Dim rawNumberField(readField.rawData.Length - 1) As Integer
        Dim rawNumberNumbers(readNumbers.rawData.Length - 1) As Integer

        For i As Integer = 0 To readField.rawData.Length - 1
            rawDataField(i) = readField.rawData(i)
        Next

        For i As Integer = 0 To readNumbers.rawData.Length - 1
            rawDataNumbers(i) = readNumbers.rawData(i)
        Next

        FieldAndNumbersToLists(rawDataField, rawDataNumbers)

    End Sub

    Sub FieldAndNumbersToLists(rawField() As String, rawNumbers() As String)
        Dim bufferArr() As String = {}
        Dim DataField() As Integer = {}
        Dim str As String
        Dim field As New List(Of Integer)
        Dim numbers As New List(Of Integer)

        'numbers in list geschrieben
        For i As Integer = 0 To rawNumbers.Length - 1
            str = rawNumbers(i)
            Dim buffer(str.Length - 1) As String

            buffer = Split(str, ",")
            For j As Integer = 0 To buffer.Length - 1
                If buffer(j) IsNot "" Then
                    numbers.Add(CInt(Int(buffer(j))))
                Else
                End If
            Next
        Next

        'For i As Integer = 0 To numbers.Count - 1
        '    'Console.Write(numbers(i))
        'Next

        'fieldnumbers in list geschrieben
        For i As Integer = 0 To rawField.Length - 1
            str = rawField(i)
            Console.WriteLine(str)

            'Zeile einlesen und Spliten
            Dim buffer() As String = Split(rawField(i), " ")

            For j As Integer = 0 To buffer.Length - 1
                If buffer(j) IsNot "" Then
                    field.Add(buffer(j))
                Else
                End If
            Next
        Next

        BuildField(field, numbers)
    End Sub

    Sub Dings()


        Dim fieldNumbers As New List(Of Integer)

        For y As Integer = 0 To fieldNumbers.Count - 1
            For x As Integer = 0 To fieldNumbers.Count - 1

            Next
        Next


        'line(countLine) = Buffer(j)
        'countLine += 1
        'If countLine > 5 Then
        '    countLine = 0
        '    ''row(countRow) = line

        '    'For x As Integer = 0 To line.Length - 1
        '    'Next
        'End If
        ''field.Add(CInt(Int(buffer(j))))

        'Dim nQ As New Question(question(0), question(1), question(2), question(3), question(4), question(5), question(6))
        'ReDim Preserve Questions(i + 1)
        'Questions(i) = nQ

        'Console.WriteLine()

        '22 13 17 11  0
        '8  2 23  4 24
        '21  9 14 16  7
        '6 10  3 18  5
        '1 12 20 15 19

    End Sub

    Sub BuildField(fieldList As List(Of Integer), numbers As List(Of Integer))

        Dim xrow() As Integer = {}
        Dim nF() As Field = {}

        For y As Integer = 0 To (fieldList.Count - 1) / 5 Step 5
            For x As Integer = 0 To fieldList.Count - 1 Step 5
                Dim row() As Integer = {fieldList(x), fieldList(x + 1), fieldList(x + 2), fieldList(x + 3), fieldList(x + 4)}
                For i As Integer = 0 To row.Length - 1
                    ReDim Preserve xrow(i)
                    xrow(i) = row(i)
                Next
            Next

            Dim column() As Integer = {xrow(y), xrow(y + 1), xrow(y + 2), xrow(y + 3), xrow(y + 4)}
            'nF(column)

        Next



    End Sub
End Class


Public Class Field

    Public column(4) As Integer

    Sub New(columnArr() As Integer)
        column = columnArr
    End Sub
End Class

