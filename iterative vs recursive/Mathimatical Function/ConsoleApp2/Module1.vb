Module Module1
    'Recursively evaluating the function
    Public Function V(ByVal x As Integer) As Integer
        If x <= 3 Then
            Return 3
        Else
            Return 2 * (V(x - 1)) + 3 * (V(x - 3))
        End If
    End Function
    Sub Main()
        'v(x) = 2v(x-1)+3v(x-3)
        'v(x) = 3 for x<=3

        Dim myInt As Integer
        Console.WriteLine("enter Integer: ")
        myInt = Console.ReadLine

        'Last working iteration provides INVALID asnwers
        If myInt > 3 Then
            Dim I As Integer = myInt
            Dim J As Integer = myInt
            Dim result As Integer = 3
            While I > 3
                result = result * 2
                I -= 1
            End While
            I = 3
            While J > 3
                I *= 3
                J -= 3
            End While
            result = result + I
            Console.WriteLine("Result by Iteration: " + result.ToString)
        Else
            Console.WriteLine("Result by Iteration: 3")
        End If

        'The Recursion is done in a try catch block as the recusive calls give a stack overfolow exception if the function is passed a value greater than 12
        Try
            Console.WriteLine("Result by recursion: " + V(myInt).ToString)
        Catch ex As Exception
            Console.WriteLine("Value of intger = " + myInt.ToString + " is too large and recursive calls overflow the stack")
        End Try

    End Sub

End Module
