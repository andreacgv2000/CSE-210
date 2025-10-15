using System;
using System.Collections.Generic;

abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string name = this.GetType().Name;
        return $"{Date:dd MMM yyyy} {name} ({Minutes} min) - " +
               $"Distance {GetDistance():0.00}, Speed {GetSpeed():0.00}, Pace {GetPace():0.00}";
    }
}

class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / Minutes) * 60;
    public override double GetPace() => Minutes / _distance;
}

class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * Minutes) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed;
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // each lap is 50 meters, convert to kilometers
        return _laps * 50 / 1000.0;
    }

    public override double GetSpeed() => (GetDistance() / Minutes) * 60;
    public override double GetPace() => Minutes / GetDistance();
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Exercise Tracker Menu ---");
            Console.WriteLine("1. Add Running Activity");
            Console.WriteLine("2. Add Cycling Activity");
            Console.WriteLine("3. Add Swimming Activity");
            Console.WriteLine("4. Display All Activities");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddRunning(activities);
                    break;
                case "2":
                    AddCycling(activities);
                    break;
                case "3":
                    AddSwimming(activities);
                    break;
                case "4":
                    DisplayActivities(activities);
                    break;
                case "5":
                    exit = true;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    static void AddRunning(List<Activity> list)
    {
        Console.Write("Enter date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter minutes: ");
        int minutes = int.Parse(Console.ReadLine());

        Console.Write("Enter distance (km): ");
        double distance = double.Parse(Console.ReadLine());

        list.Add(new Running(date, minutes, distance));
        Console.WriteLine("✅ Running activity added!");
    }

    static void AddCycling(List<Activity> list)
    {
        Console.Write("Enter date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter minutes: ");
        int minutes = int.Parse(Console.ReadLine());

        Console.Write("Enter average speed (km/h): ");
        double speed = double.Parse(Console.ReadLine());

        list.Add(new Cycling(date, minutes, speed));
        Console.WriteLine("✅ Cycling activity added!");
    }

    static void AddSwimming(List<Activity> list)
    {
        Console.Write("Enter date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter minutes: ");
        int minutes = int.Parse(Console.ReadLine());

        Console.Write("Enter number of laps: ");
        int laps = int.Parse(Console.ReadLine());

        list.Add(new Swimming(date, minutes, laps));
        Console.WriteLine("✅ Swimming activity added!");
    }

    static void DisplayActivities(List<Activity> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("No activities recorded yet.");
            return;
        }

        Console.WriteLine("\n--- Activity Summaries ---");
        foreach (var activity in list)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

