# JobApplicationTracker

Detta är en konsolapplikation som hjälper användare att hålla reda på jobbansökningar. Skrivet i C#.

# Funktioner
- Lägg till nya jobbansökningar med detaljer som företag, position, löneanspråk och datum.
- Visa alla jobbansökningar i en lista med detaljer som företag, position, löneanspråk, datum och status.
- Uppdatera status för en ansökan eller ta bort en ansökan från listan.
- Visa en filtrerad lista över jobbansökningar enligt deras status. (LINQ 'Where')
- Sortera jobbansökningar efter datum. (LINQ 'OrderBy')
- Statistik över ansökningar; totalt antal ('Count'), antal ansökningar per status ('GroupBy') samt genomsnittlig svarstid ('Average').
- Visa ansökningar som inte fått svar och är äldre än 14 dagar. (LINQ 'Where')
- Färgkodade statusar på de olika ansökningarna för bättre översikt.
- Felhantering för att säkerställa att användaren inte kan skriva in ogiltiga data för lön, datum och status.

# Så körs programmet
1. Klona repot eller ladda ner projektet.
2. Öppna projektet 'JobApplicationTracker.sln' i Visual Studio eller annan C# IDE.
3. Tryck *Ctrl + F5* för att köra applikationen.
4. Välj ett alternativ från menyn för att lägga till, visa eller sortera jobbansökningar. Det går även att uppdatera status eller ta bort en ansökan.

# Robin Boqvist 2026-10-18

# Reflektion

* 1. Hur hjälpte LINQ mig att skriva renare kod? *

Genom att använda LINQ kunde jag skriva kod som blir mer läsbar och enklare att förstå, det ger användaren möjlighet att sortera, filtrera och räkna ut statistik på en rad kod.
Alternativet hade varit att skriva if-satser, listor och loopar för att uppnå samma resultat, vilket hade gjort koden mer komplex och svår att underhålla.

* 2. Vilken del av projektet var mest utmanande och hur löste jag det? *

För mig är fortfarande helheten utmanande så jag har tagit mycket hjälp av AI och läst undervisningsmaterial för att få en fungerande kod för uppgiften.
Under tiden lär jag mig vad varje del gör och inlärningen går framåt. 
Tekniskt sett så var det svåraste att räkna ut genomsnittlig svarstid, då ResponseDate kan vara null behövde jag lösa det genom att filtrera med 'Where' så bara ansökningar som fått svar blir synliga och räknas med.
