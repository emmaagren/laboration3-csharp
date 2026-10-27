# Laboration 3 – Gästbok i C#

Detta projekt är skapat som en del av Laboration 3 i kursen Programmering i C#.NET vid Mittuniversitetet.

## Beskrivning

Programmet är en konsolapplikation som fungerar som en enkel gästbok. Användaren kan lägga till, visa och ta bort inlägg genom ett menysystem.

Varje inlägg innehåller ett namn och ett meddelande. Inläggen sparas i en JSON-fil så att de finns kvar när programmet avslutas och startas igen.

## Funktioner

- Visa alla inlägg i gästboken.
- Lägga till nya inlägg med namn och meddelande.
- Ta bort inlägg genom att ange deras index.
- Kontrollera att inmatningsfält inte är tomma.
- Hantera ogiltiga menyval och index.
- Spara och läsa inlägg från en JSON-fil.

## Tekniker

- C# och .NET
- Objektorienterad programmering med klasser och objekt
- Listor (`List`)
- JSON-serialisering och deserialisering med `System.Text.Json`
- Filhantering och felhantering

## Installation och körning

För att köra programmet behöver du ha .NET SDK installerat.

1. Klona projektet från GitHub:

   `git clone https://github.com/emmaagren/laboration3-csharp.git`

2. Öppna projektmappen:

   `cd laboration3-csharp`

3. Starta programmet:

   `dotnet run`

Följ sedan instruktionerna i konsolens meny.

## Författare

Emma Ågren, student, Mittuniversitetet.