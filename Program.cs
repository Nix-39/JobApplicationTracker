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
            var salary = int.Parse(Console.ReadLine());
            Console.Write("Datum (yyyy-MM-dd): ");
            var date = DateTime.Parse(Console.ReadLine());
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



        case "0":
            running = false;
            Console.WriteLine("Hej då!");
            break;
        default:
            Console.WriteLine("Ogiltigt val. Försök igen.");
            break;
    }
}