using Application.UseCases.Auth.Dto;
using Domain.Exceptions;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.AuthExamples;

public class AuthenticationResponseNoValidCredentialExample:IMultipleExamplesProvider<Response<string>>
{
    public IEnumerable<SwaggerExample<Response<string>>> GetExamples()
    {
        var response =new Response<string>("Credenciales incorrectas");
        
       
       
        
        yield return SwaggerExample.Create("credencialesNoValidas",response);
    }
}