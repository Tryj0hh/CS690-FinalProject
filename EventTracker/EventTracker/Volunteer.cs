namespace EventTracker;

public class Volunteer
{
    public string Name { get; }
    public string Event { get; }
    public string Tool { get; }
    public string TaskItem { get; }

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