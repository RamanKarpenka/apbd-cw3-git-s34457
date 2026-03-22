namespace apbd_cw3_git_s34457.Models;

public class Employee : User
{
    public override int MaxRentals => 5;

    public Employee(string f, string l) : base(f, l) { }
}