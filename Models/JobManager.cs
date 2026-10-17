
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
                Console.WriteLine(job.GetSummary());
            }
        }

        // Ändrar status för en ansökan men reutrnerar false om företaget inte finns
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

        // Tar bort en ansökan men returnerar false om företaget inte finns
        public bool RemoveJob(string companyName)

        {
            return Applications.RemoveAll(a => a.CompanyName == companyName) > 0;
        }
    }
}
