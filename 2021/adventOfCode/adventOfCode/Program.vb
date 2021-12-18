Imports System

Module Program
    Sub Main(args As String())
        StartDay()
    End Sub

    'aktueller Tag
    Sub StartDay()
        'Tag 05 in 2021
        Dim aoc2021a05 As New AOC2021a05
        aoc2021a05.OnStart()
    End Sub

    'nicht fertig
    Sub ToFinish()
        'Tag 04 in 2021
        Dim aoc2021a04 As New AOC2021a04
        aoc2021a04.OnStart()

        'Tag 08 in 2021
        Dim aoc2021a08 As New AOC2021a08
        aoc2021a08.OnStart()
    End Sub

    'vorherige Tage
    Sub LastDays()

        'Tag 07 in 2021
        Dim aoc2021a07 As New AOC2021a07
        aoc2021a07.OnStart()

        'Tag 06 in 2021
        Dim aoc2021a06 As New AOC2021a06
        aoc2021a06.OnStart()




        'Tag 03 in 2021
        Dim aoc2021a03 As New AOC2021a03
        aoc2021a03.OnStart()

        'Tag 02 in 2021
        Dim aoc2021a02 As New AOC2021a02
        aoc2021a02.OnStart()

        'Tag 01 in 2021
        Dim aoc2021a01 As New AOC2021a01
        aoc2021a01.OnStart()
    End Sub
End Module
