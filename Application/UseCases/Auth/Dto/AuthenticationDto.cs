namespace Application.UseCases.Auth.Dto;

public record AuthenticationDto(string UserId, string UserName, string TokenGenerated);