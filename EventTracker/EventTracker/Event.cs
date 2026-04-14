namespace EventTracker;

public class Event
{
    public string Name { get; }
    public int MaxVolunteers { get; }

    public Event(string name, int maxvolunteers)
    {
        Name = name;
        MaxVolunteers = maxvolunteers;
    }

    public override string ToString()
    {
        return $"{Name} (Max: {MaxVolunteers})";
    }
}