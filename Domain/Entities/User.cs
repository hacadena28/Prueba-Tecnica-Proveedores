namespace Domain.Entities;

public class User : EntityBase<string>
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public User(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public User()
    {
    }
}