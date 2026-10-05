namespace JobApplicationTracker
{
    // Hanterar alla ansökningar som användaren har gjort och deras status
    public class JobManager
    {
        // Lista över alla ansökningar
        public List<JobApplication> Applications { get; set; } = new List<JobApplication>();>

        // Lägger till en ny ansökan i listan
        public void AddJob(JobApplication job)
        {
            Applications.Add(job);
        }

        // Visar alla ansökningar och deras status, numrerade från 1
        public void ShowAll()
        {
            if (Applications.Count == 0)
            {
                Console.WriteLine("Inga ansökningar hittades.");
                return;
            }
            for (int i = 0; i < Applications.Count; i++)
            {
                var job = Applications[i];
                Console.WriteLine($"{i + 1}. {Applications[i].GetSummary()}");
            }
        }
    }
}
