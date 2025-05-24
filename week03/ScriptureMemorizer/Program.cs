using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("Mosiah", 2, 41), "And moreover, I would desire that ye should consider on the blessed and happy state of those that keep the commandments of God. For behold, they are blessed in all things, both temporal and spiritual; and if they hold out faithful to the end, they are received into heaven, that thereby they may dwell with God in a state of never-ending happiness. O remember, remember that these things are true; for the Lord God hath spoken it.")
        };

        Random random = new Random();
        int randomIndex = random.Next(0, scriptureLibrary.Count);
        Scripture currentScripture = scriptureLibrary[randomIndex];

        string userInput = "";

        while (userInput.ToLower() != "quit" && !currentScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());

            if (currentScripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
            userInput = Console.ReadLine();

            if (userInput.ToLower() != "quit")
            {
                currentScripture.HideRandomWords(random.Next(3, 6));
            }
        }

        Console.WriteLine("\nProgram ended. Goodbye!");
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] rawWords = text.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string rawWord in rawWords)
        {
            _words.Add(new Word(rawWord));
        }
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        List<Word> unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();

        if (unhiddenWords.Count == 0)
        {
            return;
        }

        for (int i = 0; i < count && unhiddenWords.Count > 0; i++)
        {
            int randomIndex = random.Next(0, unhiddenWords.Count);
            unhiddenWords[randomIndex].Hide();
            unhiddenWords.RemoveAt(randomIndex);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{scriptureText}";
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = null;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse.HasValue)
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse.Value}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}
