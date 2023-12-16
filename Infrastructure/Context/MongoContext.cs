using Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Context;

public class MongoContext<T>
{
    private readonly IMongoDatabase _database;

    public MongoContext(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("database"));
        _database = client.GetDatabase(config.GetConnectionString("databaseName"));
    }

    public IMongoCollection<T> DataBase => _database.GetCollection<T>(typeof(T).Name);
}