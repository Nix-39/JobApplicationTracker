using System.Runtime.CompilerServices;

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
        
            // Kontrollerar att numret finns i listan
            private bool IsValidNumber(int number)
        {
            return number >= 1 && number <= Applications.Count;
        }

        // Ändrar status på en ansökan baserat på användarens val, saknas numret returneras false
        public bool UpdateStatus(int number, Status newStatus)
        {
            if (!IsValidNumber(number))
            {
                Console.WriteLine("Ogiltigt nummer.");
                return false;
            }

            JobApplication job = Applications[number - 1];
            job.Status = newStatus;

            // Första gången en ansökan får ett svar läggs svarsdatum till
            if (newStatus != Status.Applied && job.ResponseDate == null)
            {
                job.ResponseDate = DateTime.Now;
            }
            return true;
        }

        // Tar bort en ansökan baserat på användarens val, saknas numret returneras false
        public bool RemoveJob(int number)
        {
            if (!IsValidNumber(number))
            {
                Console.WriteLine("Ogiltigt nummer.");
                return false;
            }
            Applications.RemoveAt(number - 1);
            return true;
        }
    }
}
