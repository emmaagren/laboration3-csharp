// Klass som representerar ett inlägg i gästboken
public class GuestbookEntry
{
    // Namnet på personen som skrivit inlägget
    public string Owner { get; set; } = "";

    // Texten som personen skrivit
    public string Message { get; set; } = "";
}