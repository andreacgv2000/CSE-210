using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // Clase que representa una palabra
    class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        // Oculta la palabra reemplazándola con guiones bajos
        public void Hide()
        {
            _isHidden = true;
        }

        // Devuelve el texto oculto o visible según el estado
        public string GetDisplayText()
        {
            return _isHidden ? new string('_', _text.Length) : _text;
        }

        // Comprueba si la palabra ya está oculta
        public bool IsHidden()
        {
            return _isHidden;
        }
    }

    // Clase que representa la referencia de la escritura
    class Reference
    {
        private string _book;
        private int _chapter;
        private int _verseStart;
        private int? _verseEnd;

        // Constructor para un solo versículo
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verse;
            _verseEnd = null;
        }

        // Constructor para un rango de versículos
        public Reference(string book, int chapter, int verseStart, int verseEnd)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verseStart;
            _verseEnd = verseEnd;
        }

        public string GetDisplayText()
        {
            if (_verseEnd.HasValue)
                return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
            else
                return $"{_book} {_chapter}:{_verseStart}";
        }
    }

    // Clase que representa la escritura completa
    class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(w => new Word(w)).ToList();
        }

        // Devuelve la escritura con palabras ocultas según su estado
        public string GetDisplayText()
        {
            return $"{_reference.GetDisplayText()} \n" + string.Join(" ", _words.Select(w => w.GetDisplayText()));
        }

        // Oculta un número de palabras aleatorias no ocultas
        public void HideRandomWords(int numberToHide = 3)
        {
            var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
            if (visibleWords.Count == 0) return;

            var rand = new Random();
            for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
            {
                int index = rand.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }

        // Comprueba si todas las palabras están ocultas
        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Biblioteca de escrituras (para creatividad y 100%)
            List<Scripture> scriptures = new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
                new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
                new Scripture(new Reference("Psalm", 23, 1, 6), "The Lord is my shepherd, I shall not want. He makes me lie down in green pastures. He leads me beside quiet waters. He refreshes my soul.")
            };

            var rand = new Random();
            Scripture currentScripture = scriptures[rand.Next(scriptures.Count)];

            while (true)
            {
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit") break;

                currentScripture.HideRandomWords();

                if (currentScripture.AllWordsHidden())
                {
                    Console.Clear();
                    Console.WriteLine(currentScripture.GetDisplayText());
                    Console.WriteLine("\nAll words are hidden. Good job!");
                    break;
                }
            }

            Console.WriteLine("\nThanks for using Scripture Memorizer!");
        }
    }
}
