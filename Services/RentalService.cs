namespace apbd_cw3_git_s34457.Services;

public class RentalService
{
    private List<User> users = new();
    private List<Equipment> equipment = new();
    private List<Rental> rentals = new();

    public void AddUser(User user) => users.Add(user);
    public void AddEquipment(Equipment eq) => equipment.Add(eq);

    public List<Equipment> GetAvailableEquipment()
        => equipment.Where(e => e.Status == EquipmentStatus.Available).ToList();

    public void RentEquipment(User user, Equipment eq, int days)
    {
        if (eq.Status != EquipmentStatus.Available)
            throw new Exception("Equipment not available");

        int active = rentals.Count(r => r.User == user && !r.IsReturned);

        if (active >= user.MaxRentals)
            throw new Exception("User exceeded limit");

        var rental = new Rental(user, eq, days);
        rentals.Add(rental);

        eq.Status = EquipmentStatus.Rented;
    }

    public decimal ReturnEquipment(Equipment eq)
    {
        var rental = rentals.First(r => r.Equipment == eq && !r.IsReturned);

        rental.ReturnDate = DateTime.Now;
        eq.Status = EquipmentStatus.Available;

        return rental.CalculatePenalty();
    }

    public void PrintReport()
    {
        Console.WriteLine("=== REPORT ===");

        foreach (var e in equipment)
            Console.WriteLine($"{e.Id} {e.Name} {e.Status}");
    }
}