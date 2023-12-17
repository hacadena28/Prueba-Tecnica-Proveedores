using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Api.Test;

public class AuthIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly WebApplicationFactory<Program> _factory;
    private readonly string _urlApi = "/api/supplier";

    public AuthIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task Post_Supplier_Endpoint_Return_Unauthorized()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync(_urlApi);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}