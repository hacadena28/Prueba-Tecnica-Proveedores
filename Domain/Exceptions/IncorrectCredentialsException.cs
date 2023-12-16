using System.Runtime.Serialization;

namespace Domain.Exceptions;

public class IncorrectCredentialsException : CoreBusinessException
{
    public IncorrectCredentialsException()
    {
    }

    public IncorrectCredentialsException(string message) : base(message)
    {
    }

    public IncorrectCredentialsException(string message, Exception inner) : base(message, inner)
    {
    }

    protected IncorrectCredentialsException(SerializationInfo info, StreamingContext content) : base(info, content)
    {
    }
}