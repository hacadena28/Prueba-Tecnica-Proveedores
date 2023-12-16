using FluentValidation.Results;

namespace Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("Se han producido uno o mas errores de validacion")
    {
        Errors = new List<string>();
    }

    public List<string> Errors { get; }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        foreach (var failure in failures)
        {
            Errors.Add(failure.ErrorMessage);
        }
    }
}