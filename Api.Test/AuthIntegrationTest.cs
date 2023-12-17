using System.Net;
using System.Text;
using Application.UseCases.Suppliers.Commands.SupplierCreate;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace Api.Test;

public class AuthIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly WebApplicationFactory<Program> _factory;
    private readonly string UrlApi = "/api/supplier";

    public AuthIntegrationTest(WebApplicationFactory<Program> factory, ITestOutputHelper output)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task Post_Supplier_Endpoint_Return_Unauthorized()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync(UrlApi);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}