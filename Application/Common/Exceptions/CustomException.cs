namespace Application.Common.Exceptions;

public class CustomException : Exception
{
    public List<string>? ErrorMessages { get; }

    public CustomException(string message, List<string>? errors = default)
        : base(message)
    {
        ErrorMessages = errors;
    }
}