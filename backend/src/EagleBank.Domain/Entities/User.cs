namespace EagleBank.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    public User(Guid id, string firstName, string lastName, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
    
    public static User CreateUser(string firstName, string lastName, string email)
    {
        return new User(Guid.NewGuid(), firstName, lastName, email);
    }
}