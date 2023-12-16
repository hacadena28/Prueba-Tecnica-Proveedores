using Application.UseCases.Auth.Dto;
using Domain.Ports;
using AuthenticationService = Domain.Services.AuthenticationService;


namespace Application.UseCases.Auth.Commands.Authentication;

public class AuthenticationCommandHandler : IRequestHandler<AuthenticationCommand, AuthenticationDto>
{
    private readonly AuthenticationService _authenticationService;
    private readonly IJwtServices _jwtService;


    public AuthenticationCommandHandler(AuthenticationService authenticationService, IJwtServices jwtService)
    {
        _authenticationService =
            authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        _jwtService = jwtService;
    }

    public async Task<AuthenticationDto> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
    {
        var user = await _authenticationService.ValidateUserCredentials(request.UserName, request.Password);


        var tokenGenerated = await _jwtService.GenerateToken(user);

        var auth = new AuthenticationDto(user.Id, user.UserName, tokenGenerated);


        return auth;
    }
}