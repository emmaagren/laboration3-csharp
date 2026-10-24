using System.Text.Json;

// Filen där gästbokens inlägg ska sparas.
string filePath = "guestbook.json";

// Skapar en lista som kan innehålla flera gästboksinlägg.
List<GuestbookEntry> entries = new List<GuestbookEntry>();

// Kontrollerar om det redan finns en sparad gästbok.
if (File.Exists(filePath))
{
    // Läser innehållet från JSON-filen.
    string json = File.ReadAllText(filePath);

    // Omvandlar JSON-texten till en lista med gästboksinlägg.
    entries = JsonSerializer.Deserialize<List<GuestbookEntry>>(json) ?? new List<GuestbookEntry>();
}

// Håller programmet igång tills användaren väljer att avsluta.
bool running = true;

while (running)
{
    // Rensar konsolen och visar menyn.
    Console.Clear();

    Console.WriteLine("=== GÄSTBOK ===");
    Console.WriteLine("1. Visa alla inlägg");
    Console.WriteLine("2. Lägg till inlägg");
    Console.WriteLine("3. Ta bort inlägg");
    Console.WriteLine("4. Avsluta");
    Console.WriteLine();

    Console.Write("Välj ett alternativ: ");
    string choice = Console.ReadLine() ?? "";

    // Hanterar användarens menyval.
    switch (choice)
    {
        case "1":
            // Kontrollerar om gästboken är tom.
            if (entries.Count == 0)
            {
                Console.WriteLine("Gästboken innehåller inga inlägg.");
            }
            else
            {
                // Skriver ut alla inlägg med tillhörande index.
                for (int i = 0; i < entries.Count; i++)
                {
                    Console.WriteLine($"{i}. {entries[i].Owner}: {entries[i].Message}");
                }
            }
            break;

        case "2":
            // Frågar efter namnet på personen som skriver inlägget.
            Console.Write("Ange ditt namn: ");
            string owner = Console.ReadLine() ?? "";

            // Frågar efter meddelandet.
            Console.Write("Skriv ditt inlägg: ");
            string message = Console.ReadLine() ?? "";

            // Kontrollerar att båda fälten innehåller text.
            if (string.IsNullOrWhiteSpace(owner) || string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("Fel: Både namn och meddelande måste fyllas i.");
                break;
            }

            // Skapar ett nytt objekt av klassen GuestbookEntry.
            GuestbookEntry entry = new GuestbookEntry();

            // Tilldelar objektet användarens uppgifter.
            entry.Owner = owner;
            entry.Message = message;

            // Lägger till inlägget i listan.
            entries.Add(entry);

            // Omvandlar listan med inlägg till JSON.
            string json = JsonSerializer.Serialize(entries);

            // Sparar JSON-texten i en fil.
            File.WriteAllText(filePath, json);

            Console.WriteLine("Inlägget har lagts till!");
            break;

        case "3":
            // Kontrollerar om det finns några inlägg att ta bort.
            if (entries.Count == 0)
            {
                Console.WriteLine("Det finns inga inlägg att ta bort.");
                break;
            }

            // Visar alla inlägg med deras index.
            for (int i = 0; i < entries.Count; i++)
            {
                Console.WriteLine($"{i}. {entries[i].Owner}: {entries[i].Message}");
            }

            // Frågar vilket inlägg användaren vill ta bort.
            Console.Write("Ange index för inlägget du vill ta bort: ");
            string input = Console.ReadLine() ?? "";

            // Kontrollerar att index är ett giltigt heltal inom listans gränser.
            if (!int.TryParse(input, out int index) || index < 0 || index >= entries.Count)
            {
                Console.WriteLine("Fel: Ange ett giltigt index.");
                break;
            }

            // Tar bort det valda inlägget.
            entries.RemoveAt(index);

            // Omvandlar den uppdaterade listan till JSON.
            string updatedJson = JsonSerializer.Serialize(entries);

            // Sparar den uppdaterade listan i JSON-filen.
            File.WriteAllText(filePath, updatedJson);

            Console.WriteLine("Inlägget har tagits bort!");
            break;

        case "4":
            running = false;
            break;

        default:
            Console.WriteLine("Ogiltigt val. Försök igen.");
            break;
    }

    // Väntar på användaren innan menyn visas igen.
    if (running)
    {
        Console.WriteLine();
        Console.WriteLine("Tryck Enter för att fortsätta...");
        Console.ReadLine();
    }
}