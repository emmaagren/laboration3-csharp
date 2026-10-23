// Skapar en lista som kan innehålla flera gästboksinlägg
List<GuestbookEntry> entries = new List<GuestbookEntry>();

// Frågar efter namnet på personen som skriver inlägget.
Console.Write("Ange ditt namn: ");
string owner = Console.ReadLine() ?? "";

// Frågar efter meddelandet.
Console.Write("Skriv ditt inlägg: ");
string message = Console.ReadLine() ?? "";

// Skapar ett nytt gästboksinlägg.
GuestbookEntry entry = new GuestbookEntry();

// Tilldelar inlägget användarens uppgifter.
entry.Owner = owner;
entry.Message = message;

// Lägger till inlägget i listan.
entries.Add(entry);

// Skriver ut alla inlägg i gästboken.
Console.WriteLine("\nGästbokens inlägg:");

foreach (GuestbookEntry item in entries)
{
    Console.WriteLine($"Ägare: {item.Owner}");
    Console.WriteLine($"Inlägg: {item.Message}");
}