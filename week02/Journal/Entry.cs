using System;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    public string ToFileString()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromFileString(string fileString)
    {
        string[] parts = fileString.Split('|');
        return new Entry(parts[1], parts[2], parts[0]);
    }
}
