namespace apbd_cw3_git_s34457.Models;

public class Laptop : Equipment
{
    public int Ram { get; set; }
    public string Cpu  { get; set; }

    public Laptop(string name, int ram, string cpu) : base(name)
    {
        Ram = ram;
        Cpu = cpu;
    }
}