namespace EagleBank.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    
    public string HashedPassword { get; private set; }

    public User(Guid id, string firstName, string lastName, string email, string hashedPassword)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        HashedPassword = hashedPassword;
    }
    
    public static User CreateUser(string firstName, string lastName, string email, string hashedPassword)
    {
        return new User(Guid.NewGuid(), firstName, lastName, email, hashedPassword);
    }
}