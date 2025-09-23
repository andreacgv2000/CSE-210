using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToShortDateString();
        Prompt = prompt;
        Response = response;
    }

    // Muestra la entrada en consola
    public void Display()
    {
        Console.WriteLine($"{Date} - Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}\n");
    }

    // Formato para guardar en archivo
    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    // Convierte una línea del archivo en objeto Entry
    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        return new Entry(parts[1], parts[2]) { Date = parts[0] };
    }
}
