namespace Cw2.Exceptions;

public class OverfillException : SystemException
{
    public OverfillException() : base("Przekroczono dopuszczalna wage ladunku dla danego kontenera!")
    {
    }
    public OverfillException(string message) : base(message)
    {
    }
    
    
}