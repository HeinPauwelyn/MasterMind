Module MasterMinde2

    Sub Main()
        InitializeConsole()

        Dim generatedCombination As New Combination
        'ShowColorCode(60, 1, generatedCombination)

        Dim postitionTop As Integer = 6
        Dim beurten As Integer

        Do
            Dim guessedCombination As New Combination(AskForCode(postitionTop))
            ShowColorCode(31, postitionTop - 1, guessedCombination)

            ShowEvaluation(postitionTop, generatedCombination, guessedCombination)

            If generatedCombination.Code = guessedCombination.Code Or beurten = 4 Then Exit Do

            postitionTop += 4
            beurten += 1
        Loop

        Console.WriteLine()
        Console.WriteLine()
        Console.BackgroundColor = ConsoleColor.White
        Console.WriteLine()
        Console.WriteLine("U hebt " & beurten + 1 & " keer gegokt.")
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()

    End Sub

    Sub InitializeConsole()
        Console.BackgroundColor = ConsoleColor.White
        Console.SetWindowSize(Console.LargestWindowWidth - 20, Console.LargestWindowHeight - 20)
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Black

        Console.SetCursorPosition(0, 2)
        Console.WriteLine("Kies uit volgende kleuren: ")

        ShowCollorBox(26, 1, "Y"c)
        ShowCollorBox(31, 1, "G"c)
        ShowCollorBox(36, 1, "B"c)
        ShowCollorBox(41, 1, "R"c)
        ShowCollorBox(46, 1, "P"c)

    End Sub

    Sub ShowCollorBox(positionLeft As Integer, positionTop As Integer, colorChar As Char)
        Select Case colorChar
            Case "Y"c
                Console.BackgroundColor = ConsoleColor.Yellow
            Case "G"c
                Console.BackgroundColor = ConsoleColor.Green

            Case "B"c
                Console.BackgroundColor = ConsoleColor.Blue

            Case "R"c
                Console.BackgroundColor = ConsoleColor.Red

            Case "P"c
                Console.BackgroundColor = ConsoleColor.DarkMagenta

        End Select

        Console.SetCursorPosition(positionLeft, positionTop)
        Console.Write("     ")
        Console.SetCursorPosition(positionLeft, positionTop + 1)
        Console.Write("  " & colorChar & "  ")
        Console.SetCursorPosition(positionLeft, positionTop + 2)
        Console.Write("     ")

        Console.BackgroundColor = ConsoleColor.White
    End Sub

    Function AskForCode(positionTop As Integer) As Char()
        Console.SetCursorPosition(0, positionTop)
        Console.Write("Geef een code: ")

        Dim enteredCode As String

        Do
            enteredCode = Console.ReadLine().ToUpper()

            If enteredCode.Length <> 4 Then
                Console.SetCursorPosition(15, positionTop)
                Console.Write("                                                                                                                   ")
                Console.SetCursorPosition(15, positionTop)
            Else
                Dim allowedCharater As String = "YGBRP"
                For Each character As Char In enteredCode
                    If Not (allowedCharater.Contains(character)) Then
                        Console.SetCursorPosition(15, positionTop)
                        Console.Write("                                                                                                                   ")
                        Console.SetCursorPosition(15, positionTop)
                        Continue Do
                    End If
                Next
                Exit Do
            End If
        Loop

        Dim codeAsArray(3) As Char

        Return enteredCode.ToCharArray()
    End Function

    Sub ShowColorCode(positionLeft As Integer, positionTop As Integer, combination As Combination)
        For counter As Integer = 0 To 3
            ShowCollorBox(positionLeft + (counter * 5), positionTop, combination.Code(counter))
        Next
    End Sub

    Sub ShowEvaluation(postitionTop As Integer, generatedCombination As Combination, guessedCombination As Combination)
        'beoordeling en beoordeling tonen
        Console.SetCursorPosition(60, postitionTop)
        For counter As Integer = 0 To 3
            If generatedCombination.Code(counter) = guessedCombination.Code(counter) Then
                Console.BackgroundColor = ConsoleColor.Green

            ElseIf generatedCombination.Code.Contains(guessedCombination.Code(counter)) Then
                Console.BackgroundColor = ConsoleColor.Cyan
            Else
                Console.BackgroundColor = ConsoleColor.Red
            End If
            Console.Write(" ")
            Console.BackgroundColor = ConsoleColor.White
            Console.Write(" ")
        Next
    End Sub

End Module
