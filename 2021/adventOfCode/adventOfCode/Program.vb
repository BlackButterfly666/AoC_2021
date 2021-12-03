Imports System

Module Program
    Sub Main(args As String())
        StartDay()
    End Sub

    'aktueller Tag
    Sub StartDay()
        'Tag 03 in 2021
        Dim aoc2021a03 As New AOC2021a03
        aoc2021a03.OnStart()

    End Sub

    'vorherige Tage
    Sub LastDays()
        'Tag 01 in 2021
        Dim aoc2021a01 As New AOC2021a01
        aoc2021a01.OnStart()

        'Tag 02 in 2021
        Dim aoc2021a02 As New AOC2021a02
        aoc2021a02.OnStart()
    End Sub
End Module
