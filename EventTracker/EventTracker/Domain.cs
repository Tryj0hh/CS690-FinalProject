namespace EventTracker;

public class Event
{
    public string Name { get; }
    public int MaxVolunteers { get ;}

    public Event (string name, int maxvolunteers)
    {
        Name = name;
        MaxVolunteers = maxvolunteers;
    }

    public override string ToString()
    {
        return $"{Name} (Max: {MaxVolunteers})";
    }
}

public class Volunteer
{
    public string Name { get; }
    public string Event { get; }
    public string Tool {get; }
    public string TaskItem {get; }

    public Volunteer(string name, string eventName, string taskItem, string tool)
    {
        Name = name;
        Event = eventName;
        Tool = tool;
        TaskItem = taskItem;
    }

    public override string ToString()
    {
        return $"{Name}: {Event} | {TaskItem} | {Tool}";
    }
}

public class TaskItem
{
    public string Name { get; }

    public TaskItem(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}

public class Tool
{
    public string Name { get; }

    public Tool(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}