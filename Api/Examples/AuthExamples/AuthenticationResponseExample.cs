using Application.UseCases.Auth.Dto;
using MediatR;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.AuthExamples;

public class AuthenticationResponseExample: IMultipleExamplesProvider<AuthenticationDto>
{
    public IEnumerable<SwaggerExample<AuthenticationDto>> GetExamples()
    {
        var authDto = new AuthenticationDto(
            ObjectId.GenerateNewId().ToString()!,
            "Admin",
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJkOTY1MTRjNS01ZWY3LTRhNDgtYTI4My1lOWY3Mjk3YzY4YTYiLCJVaWQiOiI2NTdiZjUwOGE1MTBiYzMwYmZmNzZkMWIiLCJzdWIiOiJhZG1pbiIsImV4cCI6MTcwMjYzMzQ5MSwiaXNzIjoiQXBpU3VwcGxpZXIiLCJhdWQiOiJTdXBwbGllclVzZXIifQ.7uuNd9ETl2hUVdJILKkXVlb2px5FEm7jVDs9CfHslDQ"
        );
        
        yield return SwaggerExample.Create("crearAlarmaRequest",authDto);
    }
}