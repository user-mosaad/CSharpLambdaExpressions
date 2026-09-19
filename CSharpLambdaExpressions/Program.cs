namespace CSharpLambdaExpressions;

class Program
{
    delegate int Transform(int value);

    static void Main()
    {
        Transform doubler = x => x * 2; // assign a lambda expression
        Transform squarer = Square; // assign a named method

        Console.WriteLine(doubler(5));
        Console.WriteLine(squarer(5));

        int left = 1;

        // Using built-in delegate types
        Func<int, int, int> add = static (left, right) => left + right;
        Action<string> report = message => Console.WriteLine($"Report: {message}");

        int total = add(5, 4); // 9
        Console.WriteLine(total);
        report("some message");
    }

    static int Square(int value) => value * value;
}
