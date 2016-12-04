Public Class Combination
    Property Code As Char()

    Sub New(codeValue As Char())
        Code = codeValue
    End Sub

    Sub New()
        generatedCode()
    End Sub

    Sub GeneratedCode()
        Dim combinationChars() As Char = {"Y"c, "G"c, "B"c, "R"c, "P"c}
        Dim rndm As New Random
        ReDim Code(3)

        For counter As Integer = 0 To 3
            Code(counter) = combinationChars(rndm.Next(5))
        Next

    End Sub
End Class
