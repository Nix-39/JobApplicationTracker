using JobApplicationTracker.Models;

var manager = new JobManager();
var running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("-= JOB APPLICATION TRACKER =-");
    Console.WriteLine("1. Lägg till ny ansökan");
    Console.WriteLine("2. Visa alla ansökningar");
    Console.WriteLine("3. Filtrera ansökningar efter status");
    Console.WriteLine("4. Sortera ansökningar efter datum");
    Console.WriteLine("5. Visa statistik");
    Console.WriteLine("6. Uppdatera status för ansökan");
    Console.WriteLine("7. Ta bort en ansökan");
    Console.WriteLine("8. Visa ansökningar utan svar (äldre än 14 dagar)");
    Console.WriteLine("0. Avsluta");
    Console.Write("Välj: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Write("Företag: ");
            var company = Console.ReadLine();
            Console.Write("Befattning: ");
            var title = Console.ReadLine();

            Console.Write("Önskad lön: ");
            int salary;
            while (!int.TryParse(Console.ReadLine(), out salary))
            {
                Console.Write("Ogiltig lön. Försök igen: ");
            }

            Console.Write("Datum (yyyy-MM-dd): ");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.Write("Ogiltigt datum. Försök igen: ");
            }

            manager.AddJob(new JobApplication(company, title, salary, date));
            Console.WriteLine("Ansökan tillagd!");
            break;

        case "2":
            manager.ShowAll();
            break;

        case "3":
            Console.Write("Status (Applied, Interview, Offer, Rejected): ");
            var filterStatus = Enum.Parse<Status>(Console.ReadLine(), true);
            manager.ShowByStatus(filterStatus);
            break;

        case "4":
            manager.ShowSortedByDate();
            break;

        case "5":
            manager.ShowStatistics();
            break;

        case "6":
            Console.Write("Företag: ");
            var updateCompany = Console.ReadLine();
            Console.Write("Ny status (Applied, Interview, Offer, Rejected): ");
            var newStatus = Enum.Parse<Status>(Console.ReadLine(), true);
            if (manager.UpdateStatus(updateCompany, newStatus))
            {
                Console.WriteLine("Status uppdaterad!");
            }
            else
            {
                Console.WriteLine("Hittade inget företag med det namnet.");
            }
            break;

        case "7":
            Console.Write("Företag att ta bort: ");
            if (manager.RemoveJob(Console.ReadLine()))
            {
                Console.WriteLine("Ansökan borttagen!");
            }
            else
            {
                Console.WriteLine("Hittade inget företag med det namnet.");
            }
            break;

        case "8":
            manager.ShowUnanswered();
            break;

        case "0":
            running = false;
            Console.WriteLine("Hej då!");
            break;
        default:
            Console.WriteLine("Ogiltigt val. Försök igen.");
            break;
    }
}