namespace EventTracker;

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