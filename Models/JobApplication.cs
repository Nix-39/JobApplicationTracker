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

    // Metod för att räkna ut antal dagar som gått sedan ansökan skickades in
    public int GetDaysSinceApplied()
    {
        return (DateTime.Now - ApplicationDate).Days;
    }

    // Metod för att returnera en sammanfattning av ansökan
    public string GetSummary()
    {
        return $"{CompanyName} - {PositionTitle} | {Status} | Sökt: {ApplicationDate:yyyy-MM-dd} ({GetDaysSinceApplied()} dagar sedan) | Lön: {SalaryExpectation:N0} kr";
    }

}
