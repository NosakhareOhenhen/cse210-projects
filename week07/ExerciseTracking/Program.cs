using System;
using System.Collections.Generic;

public class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0.0;
    }

    public virtual double GetSpeed()
    {
        return 0.0;
    }

    public virtual double GetPace()
    {
        return 0.0;
    }

    public string GetSummary()
    {
        return $"{_date} {this.GetType().Name} ({_minutes} min): " +
               $"Distance {GetDistance():F1} miles, " +
               $"Speed {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }
}

public class Running : Activity
{
    private double _distanceRan;

    public Running(string date, int minutes, double distanceRan) : base(date, minutes)
    {
        _distanceRan = distanceRan;
    }

    public override double GetDistance()
    {
        return _distanceRan;
    }

    public override double GetSpeed()
    {
        if (_minutes == 0)
        {
            return 0.0;
        }
        return (_distanceRan / _minutes) * 60;
    }

    public override double GetPace()
    {
        if (_distanceRan == 0)
        {
            return 0.0;
        }
        return _minutes / _distanceRan;
    }
}

public class Cycling : Activity
{
    private double _speedCycled;

    public Cycling(string date, int minutes, double speedCycled) : base(date, minutes)
    {
        _speedCycled = speedCycled;
    }

    public override double GetDistance()
    {
        return (_speedCycled / 60.0) * GetMinutesFromBase();
    }

    private int GetMinutesFromBase()
    {
        return (int)typeof(Activity).GetField("_minutes", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(this);
    }

    public override double GetSpeed()
    {
        return _speedCycled;
    }

    public override double GetPace()
    {
        if (_speedCycled == 0)
        {
            return 0.0;
        }
        return 60.0 / _speedCycled;
    }
}

public class Swimming : Activity
{
    private int _laps;

    private const int LAP_LENGTH_METERS = 50;
    private const double METERS_TO_MILES = 0.000621371;

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * LAP_LENGTH_METERS * METERS_TO_MILES;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        int minutes = (int)typeof(Activity).GetField("_minutes", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(this);

        if (minutes == 0)
        {
            return 0.0;
        }
        return (distance / minutes) * 60;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        int minutes = (int)typeof(Activity).GetField("_minutes", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(this);

        if (distance == 0)
        {
            return 0.0;
        }
        return minutes / distance;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Exercise Tracking Program ---");

        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("03 Nov 2022", 30, 3.0));
        activities.Add(new Cycling("04 Nov 2022", 45, 15.0));
        activities.Add(new Swimming("05 Nov 2020", 25, 20));
        activities.Add(new Running("06 Nov 2022", 60, 6.5));
        activities.Add(new Swimming("07 Nov 2022", 30, 30));

        Console.WriteLine("\n--- Daily Activity Summaries ---");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("\n------------------------------");
    }
}
