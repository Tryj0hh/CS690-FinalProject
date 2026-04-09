namespace EventTracker.Tests;

public class EventTests
{
    [Fact]
    public void Event_StoresNameAndMaxVolunteers()
    {
        var ev = new Event("Charity Run", 50);

        Assert.Equal("Charity Run", ev.Name);
        Assert.Equal(50, ev.MaxVolunteers);
    }

    [Fact]
    public void Event_ToString_ReturnsFormattedString()
    {
        var ev = new Event("Charity Run", 50);

        Assert.Equal("Charity Run (Max: 50)", ev.ToString());
    }

    [Fact]
    public void Event_AllowsZeroMaxVolunteers()
    {
        var ev = new Event("Small Meetup", 0);

        Assert.Equal(0, ev.MaxVolunteers);
    }

    [Fact]
    public void Event_AllowsEmptyName()
    {
        var ev = new Event("", 10);

        Assert.Equal("", ev.Name);
    }
}

public class VolunteerTests
{
    [Fact]
    public void Volunteer_StoresAllProperties()
    {
        var v = new Volunteer("Alice", "Charity Run", "Setup", "Hammer");

        Assert.Equal("Alice", v.Name);
        Assert.Equal("Charity Run", v.Event);
        Assert.Equal("Setup", v.TaskItem);
        Assert.Equal("Hammer", v.Tool);
    }

    [Fact]
    public void Volunteer_ToString_ReturnsFormattedString()
    {
        var v = new Volunteer("Alice", "Charity Run", "Setup", "Hammer");

        Assert.Equal("Alice: Charity Run | Setup | Hammer", v.ToString());
    }

    [Fact]
    public void Volunteer_Constructor_MapsTaskAndToolCorrectly()
    {
        // Verifies the constructor param order: (name, eventName, taskItem, tool)
        var v = new Volunteer("Bob", "Festival", "Cooking", "Spatula");

        Assert.Equal("Cooking", v.TaskItem);
        Assert.Equal("Spatula", v.Tool);
    }
}

public class TaskItemTests
{
    [Fact]
    public void TaskItem_StoresName()
    {
        var task = new TaskItem("Setup Chairs");

        Assert.Equal("Setup Chairs", task.Name);
    }

    [Fact]
    public void TaskItem_ToString_ReturnsName()
    {
        var task = new TaskItem("Setup Chairs");

        Assert.Equal("Setup Chairs", task.ToString());
    }
}

public class ToolTests
{
    [Fact]
    public void Tool_StoresName()
    {
        var tool = new Tool("Hammer");

        Assert.Equal("Hammer", tool.Name);
    }

    [Fact]
    public void Tool_ToString_ReturnsName()
    {
        var tool = new Tool("Hammer");

        Assert.Equal("Hammer", tool.ToString());
    }
}