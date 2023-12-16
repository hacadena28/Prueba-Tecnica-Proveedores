using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Inicialize;

public class Start
{
    private readonly MongoContext<User> _context;

    public Start(MongoContext<User> context)
    {
        _context = context;
    }

    public void seeds()
    {
        var userCollection = _context.DataBase;

        var user = new User("admin", "12345678");

        userCollection.InsertOne(user);
    }
}