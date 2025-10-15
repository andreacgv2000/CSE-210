using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    // Base class
    class Activity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; } // in seconds

        public Activity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void ShowStartMessage()
        {
            Console.Clear();
            Console.WriteLine($"--- {Name} ---");
            Console.WriteLine($"{Description}");
            Console.WriteLine();
            Console.Write("Enter duration in seconds: ");
            Duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Get ready...");
            Spinner(3);
        }

        public void ShowEndMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Great job! You have completed the activity.");
            Spinner(3);
        }

        protected void Spinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            for (int i = 0; i < seconds * 4; i++)
            {
                Console.Write(spinner[i % 4]);
                Thread.Sleep(250);
                Console.Write("\b");
            }
        }
    }

    // Breathing activity
    class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing", "Perform deep breaths to relax.") { }

        public void Run()
        {
            ShowStartMessage();
            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            while (DateTime.Now < endTime)
            {
                Console.WriteLine("Breathe in...");
                Countdown(4);
                Console.WriteLine("Breathe out...");
                Countdown(4);
            }
            ShowEndMessage();
        }

        private void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b");
            }
            Console.WriteLine();
        }
    }

    // Reflection activity
    class ReflectionActivity : Activity
    {
        private string[] prompts = {
            "Think of a time in your life that made you proud.",
            "Think about someone you helped recently.",
            "Recall a challenge you overcame."
        };

        private string[] questions = {
            "What did you learn from this experience?",
            "How did it make you feel?",
            "What could you do differently next time?"
        };

        public ReflectionActivity() : base("Reflection", "Reflect on important experiences in your life.") { }

        public void Run()
        {
            ShowStartMessage();
            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Length)];
            Console.WriteLine($"Prompt: {prompt}");
            Console.WriteLine("Reflect on this...");
            Spinner(5);

            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            while (DateTime.Now < endTime)
            {
                string question = questions[rand.Next(questions.Length)];
                Console.WriteLine(question);
                Spinner(5);
            }
            ShowEndMessage();
        }
    }

    // Listing activity
    class ListingActivity : Activity
    {
        private string[] prompts = {
            "List things you are grateful for.",
            "List people you admire.",
            "Make a list of your recent achievements."
        };

        public ListingActivity() : base("Listing", "Write as many responses as you can to a prompt.") { }

        public void Run()
        {
            ShowStartMessage();
            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Length)];
            Console.WriteLine($"Prompt: {prompt}");
            Console.WriteLine("Start writing your responses! Press Enter after each one.");
            Console.WriteLine("Get ready...");
            Spinner(3);

            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            List<string> responses = new List<string>();
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    responses.Add(input);
            }

            Console.WriteLine($"You wrote {responses.Count} responses!");
            ShowEndMessage();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Mindfulness Program ===");
                Console.WriteLine("1. Breathing");
                Console.WriteLine("2. Reflection");
                Console.WriteLine("3. Listing");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BreathingActivity breathing = new BreathingActivity();
                        breathing.Run();
                        break;
                    case "2":
                        ReflectionActivity reflection = new ReflectionActivity();
                        reflection.Run();
                        break;
                    case "3":
                        ListingActivity listing = new ListingActivity();
                        listing.Run();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
