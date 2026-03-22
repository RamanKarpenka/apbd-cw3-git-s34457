namespace apbd_cw3_git_s34457;

using apbd_cw3_git_s34457.Models;
using apbd_cw3_git_s34457.Services;

class Program
{
    static void Main()
    {
        var service = new RentalService();

        Console.WriteLine("=== ADD USERS ===");
        var student = new Student("Jan", "Kowalski");
        var student2 = new Student("Adam", "Nowak");
        var employee = new Employee("Anna", "Smith");

        service.AddUser(student);
        service.AddUser(student2);
        service.AddUser(employee);

        Console.WriteLine("Users added\n");

        Console.WriteLine("=== ADD EQUIPMENT ===");
        var laptop1 = new Laptop("Dell", 16, "i7");
        var laptop2 = new Laptop("HP", 8, "i5");
        var projector = new Projector("Epson", 3000, true);
        var camera = new Camera("Canon", 24, true);

        service.AddEquipment(laptop1);
        service.AddEquipment(laptop2);
        service.AddEquipment(projector);
        service.AddEquipment(camera);

        Console.WriteLine("Equipment added\n");
        
        Console.WriteLine("=== VALID RENT ===");
        service.RentEquipment(student, laptop1, 2);
        Console.WriteLine("Student rented laptop1\n");

        Console.WriteLine("=== RENT SAME EQUIPMENT (ERROR) ===");
        try
        {
            service.RentEquipment(student2, laptop1, 2);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e.Message + "\n");
        }
        
        Console.WriteLine("=== LIMIT TEST (STUDENT MAX 2) ===");
        try
        {
            service.RentEquipment(student, laptop2, 2);
            service.RentEquipment(student, projector, 2);
            
            service.RentEquipment(student, camera, 2);
        }
        catch (Exception e)
        {
            Console.WriteLine("LIMIT ERROR: " + e.Message + "\n");
        }
        
        Console.WriteLine("=== EMPLOYEE LIMIT (OK UP TO 5) ===");
        try
        {
            service.RentEquipment(employee, camera, 2);
            Console.WriteLine("Employee rented camera\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        Console.WriteLine("=== RETURN ON TIME ===");
        var penalty1 = service.ReturnEquipment(laptop1);
        Console.WriteLine($"Penalty (should be 0): {penalty1}\n");
        
        Console.WriteLine("=== LATE RETURN (SIMULATED) ===");

        service.RentEquipment(student2, laptop1, 1);
        
        var rentalsField = typeof(RentalService)
            .GetField("rentals", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        var rentals = (List<Rental>)rentalsField.GetValue(service);

        var lastRental = rentals.Last();
        lastRental.DueDate = DateTime.Now.AddDays(-2);

        var penalty2 = service.ReturnEquipment(laptop1);
        Console.WriteLine($"Penalty (should be > 0): {penalty2}\n");


        Console.WriteLine("=== FINAL REPORT ===");
        service.PrintReport();

        Console.WriteLine("\n=== DONE ===");
    }
}