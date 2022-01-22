using System.Collections.Generic;
using System;

namespace Algorithms1;

public class ExpressionProcessor
{
    private char[] _signs = "+-/*^".ToCharArray();

    private char[] _numbers = "1234567890".ToCharArray();

    private Dictionary<char, int> _operatorPrior = new Dictionary<char, int>()
    {
        {
            '+', 1
        },
        {
            '-', 1
        },
        {
            '*', 2
        },
        {
            '/', 2
        },
        {
            '^', 4
        }
    };

    public Stack TokenizeString(string str)
    {
        var ar = str.ToCharArray();
        float buffer  = 0;
        var returnValue = new Stack();
        var operationStack = new Stack();
        foreach (var s in ar)
        {
            if (_numbers.Contains(s))
            {
                buffer *= 10;
                buffer += s - '0';
            }
            else if (s == ' ')
            {
                if (buffer != 0)
                {
                    returnValue.Push(buffer);
                    buffer = 0;
                }
                continue;
            }
            else if (_signs.Contains(s))
            {
                if (buffer != 0)
                {
                    returnValue.Push(buffer);
                    buffer = 0;
                }

                
                if (operationStack.GetTop() != null && _signs.Contains((char)operationStack.GetTop()))
                {
                    var stackPrior = _operatorPrior[(char)operationStack.GetTop()];
                    while (_operatorPrior[s] <= stackPrior)
                    {
                        returnValue.Push(operationStack.Pop());
                        stackPrior = _operatorPrior[(char)operationStack.GetTop()];
                    }
                }
                operationStack.Push(s);
            }
            else if (s == '(')
                operationStack.Push(s);
            else if (s == ')')
            {
                while ((char) operationStack.GetTop() != '(')
                    returnValue.Push(operationStack.Pop());
                operationStack.Pop();
            }
        }

        if (buffer != 0)
            operationStack.Push(buffer);
        while (operationStack.GetTop() != null)
            returnValue.Push(operationStack.Pop());

        return returnValue;
    }

    public float Calculate(Stack expression_)
    {
        var s = new Stack();
        var expression = new Stack();
        while(expression_.GetTop() != null)
        {
            expression.Push(expression_.Pop());
        }
        while (true)
        {
            var t = expression.Pop();
            if (t is float) 
            { 
                s.Push(t); 
            }
            else if (t is char)
            {
                var first = (float)s.Pop();
                if ((char) t == '+') s.Push((float) s.Pop() + first);
                else if ((char) t == '-') s.Push((float) s.Pop() - first);
                else if ((char) t == '*') s.Push((float) s.Pop() * first);
                else if ((char) t == '/') s.Push((float) s.Pop() / first);
                else if ((char) t == '^') s.Push(Math.Pow((float)(s.Pop()), first));
            }

            if (expression.GetTop() == null) return (float) s.Pop();
        }
    }
}
