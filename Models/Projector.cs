namespace apbd_cw3_git_s34457.Models;

public class Projector : Equipment
{
    public int Lumens { get; set; }
    public bool Hdmi  { get; set; }

    public Projector(string name, int lumens, bool hdmi) : base(name)
    {
        Lumens = lumens;
        Hdmi = hdmi;
    }
}