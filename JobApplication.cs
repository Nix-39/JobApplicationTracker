namespace JobApplicationTracker
{
    // Representerar en jobbansökan
    public class JobApplication
    {
        // Attribut för att lagra företagets namn
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public Status Status { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime? ResponseDate { get; set; } // Nullable, eftersom det kanske inte finns något svar än
        public int SalaryExpectation { get; set; }

        // Konstruktör - initialiserar en ny instans av JobApplication-klassen
        public JobApplication(string companyName, string position, Status status, DateTime applicationDate, int salaryExpectation)
        {
            CompanyName = companyName;
            Position = position;
            Status = status;
            ApplicationDate = applicationDate;
            SalaryExpectation = salaryExpectation;
            Status = Status.Applied; // Standardstatus är "Applied"
            ResponseDate = null; // Ingen respons ännu
        }
        // Returnerar antal dagar sedan ansökan skickades
        public int GetDaysSinceApplied()
        {
            TimeSpan difference = DateTime.Now - ApplicationDate;
            return difference.Days;
        }
        // Returnerar en kort sammanfattning av ansökan som text
        public string GetSummary()
        {
            return $"{CompanyName} - {Position} | Status: {Status} | " + 
                   $"Sökt: {ApplicationDate: yyyy-MM-dd} ({GetDaysSinceApplied()} dagar sedan) |" +
                   $"Lön: {SalaryExpectation:N0} kr"; 
        }
    }
}
