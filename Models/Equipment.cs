using apbd_cw3_git_s34457.Enums;

namespace apbd_cw3_git_s34457.Models;

public class Equipment
{
    private static int _idCounter = 1;

    public int Id { get; private set; }
    public string Name { get; set; }
    public EquipmentStatus Status{ get; set; }
    
    public Equipment(string name)
    {
        Id = _idCounter++;
        Name = name;
        Status = EquipmentStatus.Available;
    }
}