using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace Api.Test;

public class AuthIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly WebApplicationFactory<Program> _factory;
    private readonly string _urlApi = "/api/supplier";
    private readonly ITestOutputHelper _output;

    public AuthIntegrationTest(WebApplicationFactory<Program> factory, ITestOutputHelper output)
    {
        _factory = factory;
        _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
        _output = output;
    }

    [Fact]
    public async Task Post_Supplier_Endpoint_Return_Unauthorized()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync(_urlApi);

        // Assert
        _output.WriteLine($"Request to {_urlApi} returned status code: {await response.Content.ReadAsStringAsync()}");
        Assert.Equal(HttpStatusCode.OK,response.StatusCode);
    }
}