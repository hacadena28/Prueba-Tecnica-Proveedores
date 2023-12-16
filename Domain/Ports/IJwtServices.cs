using Domain.Entities;

namespace Domain.Ports;

public interface IJwtServices
{
    Task<string> GenerateToken(User user);
}