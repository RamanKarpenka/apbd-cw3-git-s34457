namespace apbd_cw3_git_s34457.Models;

public class Camera : Equipment
{
    public int Megapixels { get; set; }
    public bool IsDigital { get; set; }

    public Camera(string name, int megapixels, bool isDigital) : base(name)
    {
        Megapixels = megapixels;
        IsDigital = isDigital;
    }
}