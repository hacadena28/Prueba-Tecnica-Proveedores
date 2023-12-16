using Domain.Entities;
using Domain.Exceptions;
using Domain.Ports;

namespace Domain.Services;

public class AuthenticationService
{
    private readonly IGenericRepository<User> _repository;

    public AuthenticationService(IGenericRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<User> ValidateUserCredentials(string userName, string password)
    {
        var user = (await _repository.FindAsync(
            u => u.UserName == userName && u.Password == password
        )).FirstOrDefault();
        if (user == null)
        {
            throw new IncorrectCredentialsException();
        }


        return user;
    }
}