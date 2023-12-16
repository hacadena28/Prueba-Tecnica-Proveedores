using Application.UseCases.Auth.Dto;

namespace Application.UseCases.Auth.Commands.Authentication;

public record AuthenticationCommand(
    string UserName,
    string Password
) : IRequest<AuthenticationDto>;