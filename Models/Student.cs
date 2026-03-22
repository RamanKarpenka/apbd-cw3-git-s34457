namespace apbd_cw3_git_s34457.Models;

public class Student : User
{
    public override int MaxRentals => 2;

    public Student(string f, string l) : base(f, l)  { }
}