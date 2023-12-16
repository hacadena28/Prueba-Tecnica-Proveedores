using Infrastructure.Adapters;
using Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
namespace Infrastructure.Extensions.Middleware;

public static class MiddlewareExtensions
{
  public static void UserErrorHandlingMiddleware(this IApplicationBuilder app)
  {
    app.UseMiddleware<ErrorHandlerMiddleware>();
  }
}