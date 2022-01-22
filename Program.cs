using Algorithms1;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine();
        var ep = new ExpressionProcessor();
        var ts = ep.TokenizeString(input);
        Console.WriteLine(ep.Calculate(ts));
    }
}
