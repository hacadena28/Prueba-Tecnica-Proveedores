using Api.Examples.AuthExamples;
using Application.Common;
using Application.UseCases.Auth.Commands.Authentication;
using Application.UseCases.Auth.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Autenticar Usuarios.
    /// </summary>
    /// <remarks>
    ///Para Autenticarse en el sistema necesita proporcionar el UserName y la contraseña
    /// </remarks>
    [HttpPost("Auth")]
    [SwaggerRequestExample(typeof(AuthenticationCommand), typeof(AuthenticationCommandExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AuthenticationResponseExample))]
    [SwaggerResponseExample(400, typeof(Response<string>))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AuthenticationDto), StatusCodes.Status200OK)]
    public async Task<AuthenticationDto> Authentication(AuthenticationCommand command)
    {
        return await _mediator.Send(command);
    }
}