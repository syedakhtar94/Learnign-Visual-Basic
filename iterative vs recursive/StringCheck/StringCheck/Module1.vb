Module Module1
    'Recursively checks if any allowed endings are present in the given word
    Function checkMe(myStr As String, MyArray() As String, x As Integer) As Boolean
        If myStr.EndsWith(MyArray(x)) Then
            Console.Write("Result By recursion: The Word Entered ends with " + MyArray(x) + vbLf)
            Return True
        ElseIf x < MyArray.Length - 1 Then
            Return checkMe(myStr, MyArray, x + 1)
        Else
            Return False
        End If
    End Function

    Sub Main()
        'defining array of ending strings
        Dim strcheck(0 To 2) As String
        strcheck(0) = "ing"
        strcheck(1) = "e"
        strcheck(2) = "ed"
        Console.WriteLine("The Program recursively and iteratevly checks if an entered word ends with any of the following: ing, e, ed")
        Console.WriteLine("Enter a Word")

        'Reading the word under consideration
        Dim myWord As String
        Dim checkstr As Boolean
        myWord = Console.ReadLine()

        'Iteratively checking if the word ends with any of the elements of the array 
        For Each x In strcheck
            If myWord.EndsWith(x) Then
                Console.Write("Result By iteration: The Word Entered ends with " + x + vbLf)
                checkstr = True
            End If
        Next
        If checkstr = False Then
            Console.Write("Result By iteration: The Word Entered does not end with any the following: ing, e, ed" + vbLf)
        End If

        'calling the Iterative function
        checkstr = checkMe(myWord, strcheck, 0)
        If checkstr = False Then
            Console.Write("Result By recursion: The Word Entered does not end with any the following: ing, e, ed" + vbLf)
        End If

    End Sub

End Module
