namespace apbd_cw3_git_s34457.Models;

public abstract class User
{
    private static int _idCounter = 1;
    
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public abstract int MaxRentals { get; }

    public User(string firstName, string lastName)
    {
        Id = _idCounter++;
        FirstName = firstName;
        LastName = lastName;
    }
}