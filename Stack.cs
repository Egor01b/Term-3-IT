namespace Algorithms1;

public class Stack
{
    private Element _top = null;

    public void Push(object value)
    {
        _top = new Element()
        {
            Next = _top, Value = value
        };
    } 
    
    public object GetTop()
    {
        if (_top == null) return null;
        return _top.Value;
    }
    
    public object Pop()
    {
        var returnValue = _top.Value;
        _top = _top.Next;
        return returnValue;
    }

    private class Element
    {
        public Element Next;
        public object Value;
    }
}
