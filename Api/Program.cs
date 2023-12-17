using Domain.Entities;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Inicialize;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddInfrastructure(config);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Cors",
        builder =>
        {
            builder.WithOrigins("*");
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseInfrastructure(app.Environment);
var dbContext = new MongoContext<User>(config);
var start = new Start(dbContext);
start.seeds();

// Configure the HTTP request pipeline.


app.UseCors("Cors");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



public partial class Program
{
    public static void Main(string[] args)
    {
        
    }
}