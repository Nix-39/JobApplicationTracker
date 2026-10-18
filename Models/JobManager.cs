
namespace JobApplicationTracker.Models
{
    // Ansökningar hanteras och lagras i JobManager-klassen
    public class JobManager
    {
        public List<JobApplication> Applications { get; set; } = new List<JobApplication>();

        // Lägga till en ny ansökan
        public void AddJob(JobApplication job)
        {
            Applications.Add(job);
        }

        // Visa alla ansökningar
        public void ShowAll()
        {
            if (Applications.Count == 0)
            {
                Console.WriteLine("Inga ansökningar hittades.");
                return;
            }

            foreach (var job in Applications)
            {
                PrintJob(job);
            }
        }

        // Ändrar status för en ansökan men reutrnerar false om företaget inte finns med i listan
        public bool UpdateStatus(string companyName, Status newStatus)
        {
            var job = Applications.Find(a => a.CompanyName == companyName);

            if (job == null)
            {
                return false;
            }

            job.Status = newStatus;
            job.ResponseDate = DateTime.Now;
        
            return true;
        }

        // Tar bort en ansökan men returnerar false om företaget inte finns med i listan
        public bool RemoveJob(string companyName)

        {
            return Applications.RemoveAll(a => a.CompanyName == companyName) > 0;
        }

        // LINQ Where: Visar ansökningar med en vald status
        public void ShowByStatus(Status status)
        {
            var filtered = Applications.Where(a => a.Status == status);

            foreach (var job in filtered)
            {
                PrintJob(job);
            }
        }

        // LINQ OrderBy: Sorterar ansökningar efter datum med äldsta först
        public void ShowSortedByDate()
        {
            var sorted = Applications.OrderBy(a => a.ApplicationDate);

            foreach (var job in sorted)
            {
                PrintJob(job);
            }
        }

        // LINQ Count, GroupBy och Average: Visar statistik över ansökningar per status
        public void ShowStatistics()
        {
            Console.WriteLine($"Totalt antal ansökningar: {Applications.Count()}");

            foreach (var group in Applications.GroupBy(a => a.Status))
            {
                Console.WriteLine($"Status: {group.Key}, Antal: {group.Count()}");
            }

            var avg = Applications
                .Where(a => a.ResponseDate != null)
                .Average(a => (a.ResponseDate - a.ApplicationDate)?.TotalDays);

            if (avg == null)
            {
                Console.WriteLine("Genomsnittlig svarstid: Inga svar ännu");
            }
            else
            {
                Console.WriteLine($"Genomsnittlig svarstid: {avg:F1} dagar");
            }
        }

        // LINQ Where: Filtrerar ansökningar utan de som är äldre än 14 dagar
        public void ShowUnanswered()
        {
            var unanswered = Applications.Where(a => a.ResponseDate == null && a.GetDaysSinceApplied() > 14);
            
            foreach (var job in unanswered)
            {
                PrintJob(job);
            }
        }

        // Skriver ut en ansökan i färg efter status
        private static void PrintJob(JobApplication job)
        {
            Console.ForegroundColor = job.Status switch
            {
                Status.Applied => ConsoleColor.Yellow,
                Status.Interview => ConsoleColor.Blue,
                Status.Offer => ConsoleColor.Green,
                Status.Rejected => ConsoleColor.Red,
                _ => ConsoleColor.Gray
            };

            Console.WriteLine(job.GetSummary());
            Console.ResetColor();
        }
    }
}
