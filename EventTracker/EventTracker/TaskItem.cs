namespace EventTracker;

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