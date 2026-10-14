namespace JobApplicationTracker.Models;

// Kategoriserar en enskild jobbansökan
public class JobApplication
{
    public string CompanyName { get; set; }
    public string PositionTitle { get; set; }
    public Status Status { get; set; } = Status.Applied; // Nya ansökningar börjar med statusen "Applied"
    public DateTime ApplicationDate { get; set; } = DateTime.Now;
    public DateTime? ResponseDate { get; set; } // Nullable tills svar inkommit
    public int SalaryExpectation { get; set; }

    // Konstruktor som körs för att skapa en ny jobbansökan
    public JobApplication(string companyName, string positionTitle, int salaryExpectation, DateTime applicationDate)
    {
        CompanyName = companyName;
        PositionTitle = positionTitle;
        SalaryExpectation = salaryExpectation;
        ApplicationDate = applicationDate;
    }
}
