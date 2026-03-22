namespace apbd_cw3_git_s34457;

using apbd_cw3_git_s34457.Models;
using apbd_cw3_git_s34457.Services;

class Program
{
    static void Main()
    {
        var service = new RentalService();

        var student = new Student("Jan", "Kowalski");
        var employee = new Employee("Anna", "Nowak");

        service.AddUser(student);
        service.AddUser(employee);

        var laptop = new Laptop("Dell", 16, "i7");
        var projector = new Projector("Epson", 3000, true);

        service.AddEquipment(laptop);
        service.AddEquipment(projector);

        service.RentEquipment(student, laptop, 1);

        try
        {
            service.RentEquipment(student, laptop, 1);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        var penalty = service.ReturnEquipment(laptop);
        Console.WriteLine($"Penalty: {penalty}");

        service.PrintReport();
    }
}