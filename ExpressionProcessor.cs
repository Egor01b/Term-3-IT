namespace Algorithms1;

public class ExpressionProcessor
{
    private char[] _signs = "+-/*".ToCharArray();

    private char[] _numbers = "1234567890".ToCharArray();

    public Stack TokenizeString(string str)
    {
        var ar = str.ToCharArray();
        var buffer = 0;
        var returnValue = new Stack();
        for (int i = 0; i < ar.Length; i++)
        {
            if (_numbers.Contains(ar[i]))
            {
                buffer *= 10;
                buffer += ar[i] - '0';
            }
            else if (ar[i] == ' ')
            {
                if (buffer != 0)
                {
                    returnValue.Push(buffer);
                    buffer = 0;
                }
            }
            else if (_signs.Contains(ar[i]))
            {
                if (buffer != 0)
                {
                    returnValue.Push(buffer);
                    buffer = 0;
                }

                returnValue.Push(ar[i]);
            }
        }

        return returnValue;
    }
}