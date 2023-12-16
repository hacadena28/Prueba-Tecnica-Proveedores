namespace Application.UseCases.Auth.Commands.Authentication;

public class AuthenticationValidator : AbstractValidator<AuthenticationCommand>
{
    public AuthenticationValidator()
    {
        RuleFor(_ => _.UserName).NotNull().MinimumLength(4).MaximumLength(10);
        RuleFor(_ => _.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(50);
    }
}