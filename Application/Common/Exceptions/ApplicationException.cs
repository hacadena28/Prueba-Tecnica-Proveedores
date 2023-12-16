namespace Application.Common.Exceptions;

public class EntityException : CustomException
{
    public EntityException(string message)
        : base(message, null)
    {
    }
}