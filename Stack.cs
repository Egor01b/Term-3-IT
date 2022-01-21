namespace Algorithms1;

public class Stack
{
    private Element _top = null;

    public void Push(string value)
    {
        _top = new Element()
        {
            Next = _top, Value = value
        };
    }

    public string Pop()
    {
        var returnValue = _top.Value;
        _top = _top.Next;
        return returnValue;
    }

    private class Element
    {
        public Element Next;
        public string Value;
    }
}