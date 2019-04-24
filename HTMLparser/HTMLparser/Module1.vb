Imports System.IO
Imports System
Imports System.Text.RegularExpressions
Module Module1
    Function Modyfier(ByVal mystr As String, ByVal word As String) As String
        'skips any text within a tag and calls modifyer in the remaining substring
        If mystr.Contains("<") = True Then
            Dim count = mystr.IndexOf("<")
            Dim endcount = mystr.IndexOf(">")
            If count = 0 Then
                Return (mystr.Substring(0, endcount + 1) + Modyfier(mystr.Substring(endcount + 1), word))
            Else
                Dim temp = mystr.Substring(0, mystr.IndexOf("<"))
                temp = temp.Replace(word, "<span style=""background-color: blue; color: white"">" + word + "<table width=""100%"" border=""0"">")
                Return temp + Modyfier(mystr.Substring(mystr.IndexOf("<")), word)
            End If
        Else
            mystr = mystr.Replace(word, "<span style=""background-color: blue; color: white"">" + word + "<table width=""100%"" border=""0"">")
            Return mystr
        End If

    End Function
    Sub Main()


        Try
            Dim sr As StreamReader = New StreamReader("Test.html")
            Dim line As String
            Dim doc As String
            Dim body As String
            Dim countBody As Integer
            Dim countBodyEnd As Integer
            Dim keyword As String
            Dim newstring As String
            Dim endStr As String
            'reading the file in a string
            Do
                line = sr.ReadLine()
                doc = doc + line + vbLf
            Loop Until line Is Nothing
            'extracting the body of the document from the rest, StringCompariosn culture is set so the search is not case sensitive
            newstring = doc.Substring(0, doc.IndexOf("<body", 0, StringComparison.CurrentCultureIgnoreCase))
            countBody = doc.IndexOf("<body", 0, StringComparison.CurrentCultureIgnoreCase)
            countBodyEnd = doc.IndexOf("</body", 0, StringComparison.CurrentCultureIgnoreCase)
            'Saving the document after the end body tag in ecdstr
            endStr = doc.Substring(countBodyEnd, doc.Length - countBodyEnd)
            body = doc.Substring(countBody, countBodyEnd - countBody)
            newstring = newstring + body.Substring(0, body.IndexOf(">") + 1)
            countBody = body.IndexOf(">") + 1
            body = body.Substring(countBody, body.Length - countBody)
            'taking in keyword
            keyword = Console.ReadLine
            keyword = " " + keyword + " "
            'calling the Modyfier on just the body 
            body = Modyfier(body, keyword)

            newstring = newstring + body + endStr
            Console.WriteLine(newstring)
            sr.Close()
            Dim srs As StreamWriter = New StreamWriter("Test.html")
            srs.Write(newstring)
            srs.Close()
        Catch E As Exception
            Console.WriteLine("The file could not be read:")
            Console.WriteLine(E.Message)
        End Try
    End Sub


End Module
