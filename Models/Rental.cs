namespace apbd_cw3_git_s34457.Models;

public class Rental
{
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public bool IsReturned => ReturnDate != null;

    public Rental(User user, Equipment equipment, int days)
    {
        User = user;
        Equipment = equipment;
        RentDate = DateTime.Now;
        DueDate = RentDate.AddDays(days);
    }

    public decimal CalculatePenalty()
    {
        if (ReturnDate == null || ReturnDate <= DueDate)
            return 0;

        int lateDays = (ReturnDate.Value - DueDate).Days;
        return lateDays * 10;
    }
}