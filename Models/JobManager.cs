
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
    }
}
