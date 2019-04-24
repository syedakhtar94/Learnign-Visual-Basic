Module Module1

    Sub Main()
        Dim X As Double
        X = Console.ReadLine()
        Dim Y As Double
        Y = Console.ReadLine()
        Console.WriteLine("Integer Part of X = {0}", X \ 1)
        Console.WriteLine("Integer Part of Y = {0}", Y \ 1)
        Console.WriteLine("Fraction Part of X = {0}", X - (X \ 1))
        Console.WriteLine("Fraction Part of Y = {0}", Y - (Y \ 1))
        Console.WriteLine("X - Y = {0}", X - Y)
        Console.WriteLine("X + Y = {0}", X + Y)
        Console.WriteLine("X * Y = {0}", X * Y)
        Console.WriteLine("X / Y = {0}", X / Y)
        Console.WriteLine(X / 0) 'Modulus with zero gives Infinity '
        'Console.WriteLine(X \ 0) Throws an exception
    End Sub

End Module
