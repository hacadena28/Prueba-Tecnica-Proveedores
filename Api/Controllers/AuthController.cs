using Api.Examples.AuthExamples;
using Application.Common;
using Application.UseCases.Auth.Commands.Authentication;
using Application.UseCases.Auth.Dto;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Autenticar Usuarios.
    /// </summary>
    /// <remarks>
    ///Para Autenticarse en el sistema necesita proporcionar el UserName y la contraseña
    /// </remarks>
    /// <response code="401">Credenciales inválidas.</response>
    /// <response code="200">Autenticación exitosa.</response>
    /// <response code="400">Validaciones no cumplidas.</response>
    [HttpPost("Auth")]
    [SwaggerRequestExample(typeof(AuthenticationCommand), typeof(AuthenticationCommandExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AuthenticationResponseExample))]
    [SwaggerResponseExample(StatusCodes.Status401Unauthorized, typeof(AuthenticationResponseNoValidCredentialExample))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AuthenticationDto), StatusCodes.Status200OK)]
    public async Task<AuthenticationDto> Authentication(AuthenticationCommand command)
    {
        var auth = await _mediator.Send(command);
        return auth;
    }
}