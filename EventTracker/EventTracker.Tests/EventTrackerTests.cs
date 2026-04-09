namespace EventTracker.Tests;

public class DataManagerTests : IDisposable
{
    private readonly string _tempDir;

    public DataManagerTests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(_tempDir);
        Directory.SetCurrentDirectory(_tempDir);
    }

    public void Dispose()
    {
        Directory.SetCurrentDirectory(Path.GetTempPath());
        Directory.Delete(_tempDir, recursive: true);
    }

    // DataManager Tests

    [Fact]
    public void Events_SurviveRestart()
    {
        var dm1 = new DataManager();
        dm1.AddEvent(new Event("Charity Run", 50));

        var dm2 = new DataManager();

        Assert.Single(dm2.Events);
        Assert.Equal("Charity Run", dm2.Events[0].Name);
        Assert.Equal(50, dm2.Events[0].MaxVolunteers);
    }

    [Fact]
    public void Volunteers_SurviveRestart()
    {
        var dm1 = new DataManager();
        dm1.AddVolunteer(new Volunteer("Alice", "Charity Run", "Setup", "Hammer"));

        var dm2 = new DataManager();

        Assert.Single(dm2.Volunteers);
        Assert.Equal("Alice", dm2.Volunteers[0].Name);
        Assert.Equal("Charity Run", dm2.Volunteers[0].Event);
        Assert.Equal("Setup", dm2.Volunteers[0].TaskItem);
        Assert.Equal("Hammer", dm2.Volunteers[0].Tool);
    }

    [Fact]
    public void Tasks_SurviveRestart()
    {
        var dm1 = new DataManager();
        dm1.AddTask(new TaskItem("Setup Chairs"));

        var dm2 = new DataManager();

        Assert.Single(dm2.Tasks);
        Assert.Equal("Setup Chairs", dm2.Tasks[0].Name);
    }

    [Fact]
    public void Tools_SurviveRestart()
    {
        var dm1 = new DataManager();
        dm1.AddTool(new Tool("Hammer"));

        var dm2 = new DataManager();

        Assert.Single(dm2.Tools);
        Assert.Equal("Hammer", dm2.Tools[0].Name);
    }

    [Fact]
    public void RemoveEvent_OnlyDeletesTheSelectedEvent()
    {
        var dm = new DataManager();
        var evA = new Event("Event A", 10);
        var evB = new Event("Event B", 20);
        dm.AddEvent(evA);
        dm.AddEvent(evB);

        dm.RemoveEvent(evA);

        Assert.Single(dm.Events);
        Assert.Equal("Event B", dm.Events[0].Name);
    }

    [Fact]
    public void RemoveVolunteer_OnlyDeletesTheSelectedVolunteer()
    {
        var dm = new DataManager();
        var alice = new Volunteer("Alice", "Charity Run", "Setup", "Hammer");
        var bob = new Volunteer("Bob", "Charity Run", "Cleanup", "Broom");
        dm.AddVolunteer(alice);
        dm.AddVolunteer(bob);

        dm.RemoveVolunteer(alice);

        Assert.Single(dm.Volunteers);
        Assert.Equal("Bob", dm.Volunteers[0].Name);
    }

    [Fact]
    public void RemoveTask_OnlyDeletesTheSelectedTask()
    {
        var dm = new DataManager();
        var t1 = new TaskItem("Setup Chairs");
        var t2 = new TaskItem("Clean Up");
        dm.AddTask(t1);
        dm.AddTask(t2);

        dm.RemoveTask(t1);

        Assert.Single(dm.Tasks);
        Assert.Equal("Clean Up", dm.Tasks[0].Name);
    }

    [Fact]
    public void RemoveTool_OnlyDeletesTheSelectedTool()
    {
        var dm = new DataManager();
        var t1 = new Tool("Hammer");
        var t2 = new Tool("Screwdriver");
        dm.AddTool(t1);
        dm.AddTool(t2);

        dm.RemoveTool(t1);

        Assert.Single(dm.Tools);
        Assert.Equal("Screwdriver", dm.Tools[0].Name);
    }

    [Fact]
    public void RemovedEvent_DoesNotComeBackAfterRestart()
    {
        var dm1 = new DataManager();
        var ev = new Event("Charity Run", 50);
        dm1.AddEvent(ev);
        dm1.RemoveEvent(ev);

        var dm2 = new DataManager();

        Assert.Empty(dm2.Events);
    }

    [Fact]
    public void RemovedVolunteer_DoesNotComeBackAfterRestart()
    {
        var dm1 = new DataManager();
        var v = new Volunteer("Alice", "Charity Run", "Setup", "Hammer");
        dm1.AddVolunteer(v);
        dm1.RemoveVolunteer(v);

        var dm2 = new DataManager();

        Assert.Empty(dm2.Volunteers);
    }

    [Fact]
    public void RemovedTask_DoesNotComeBackAfterRestart()
    {
        var dm1 = new DataManager();
        var t = new TaskItem("Setup Chairs");
        dm1.AddTask(t);
        dm1.RemoveTask(t);

        var dm2 = new DataManager();

        Assert.Empty(dm2.Tasks);
    }

    [Fact]
    public void RemovedTool_DoesNotComeBackAfterRestart()
    {
        var dm1 = new DataManager();
        var t = new Tool("Hammer");
        dm1.AddTool(t);
        dm1.RemoveTool(t);

        var dm2 = new DataManager();

        Assert.Empty(dm2.Tools);
    }

    [Fact]
    public void IsEventFull_WhenExactlyAtCapacity_BlocksSignUp()
    {
        var dm = new DataManager();
        var ev = new Event("Charity Run", 2);
        dm.AddEvent(ev);
        dm.AddVolunteer(new Volunteer("Alice", "Charity Run", "Setup", "Hammer"));
        dm.AddVolunteer(new Volunteer("Bob", "Charity Run", "Cleanup", "Broom"));

        Assert.True(dm.IsEventFull(ev));
    }

    [Fact]
    public void IsEventFull_WhenUnderCapacity_AllowsSignUp()
    {
        var dm = new DataManager();
        var ev = new Event("Charity Run", 5);
        dm.AddEvent(ev);
        dm.AddVolunteer(new Volunteer("Alice", "Charity Run", "Setup", "Hammer"));

        Assert.False(dm.IsEventFull(ev));
    }

    [Fact]
    public void IsEventFull_OnlyCountsVolunteersForThatEvent()
    {
        var dm = new DataManager();
        var eventA = new Event("Event A", 1);
        var eventB = new Event("Event B", 5);
        dm.AddEvent(eventA);
        dm.AddEvent(eventB);
        dm.AddVolunteer(new Volunteer("Alice", "Event B", "Setup", "Hammer"));

        Assert.False(dm.IsEventFull(eventA));
    }

    [Fact]
    public void IsEventFull_AfterRemovingVolunteer_AllowsSignUpAgain()
    {
        var dm = new DataManager();
        var ev = new Event("Charity Run", 1);
        dm.AddEvent(ev);
        var v = new Volunteer("Alice", "Charity Run", "Setup", "Hammer");
        dm.AddVolunteer(v);

        dm.RemoveVolunteer(v);

        Assert.False(dm.IsEventFull(ev));
    }

    // FileSaver Tests

    [Fact]
    public void FileSaver_CreatesFileOnConstruction()
    {
        new FileSaver("test.txt");

        Assert.True(File.Exists("test.txt"));
    }

    [Fact]
    public void FileSaver_AppendLine_WritesLineToFile()
    {
        var saver = new FileSaver("test.txt");

        saver.AppendLine("hello");

        var lines = File.ReadAllLines("test.txt");
        Assert.Contains("hello", lines);
    }

    [Fact]
    public void FileSaver_AppendLine_MultipleLinesAllWritten()
    {
        var saver = new FileSaver("test.txt");

        saver.AppendLine("line one");
        saver.AppendLine("line two");
        saver.AppendLine("line three");

        var lines = File.ReadAllLines("test.txt");
        Assert.Contains("line one", lines);
        Assert.Contains("line two", lines);
        Assert.Contains("line three", lines);
    }

    [Fact]
    public void FileSaver_OverwriteAll_ReplacesExistingContent()
    {
        var saver = new FileSaver("test.txt");
        saver.AppendLine("old content");

        saver.OverwriteAll(new List<string> { "new content" });

        var lines = File.ReadAllLines("test.txt");
        Assert.DoesNotContain("old content", lines);
        Assert.Contains("new content", lines);
    }

    [Fact]
    public void FileSaver_OverwriteAll_WritesAllNewLines()
    {
        var saver = new FileSaver("test.txt");

        saver.OverwriteAll(new List<string> { "alpha", "beta", "gamma" });

        var lines = File.ReadAllLines("test.txt");
        Assert.Contains("alpha", lines);
        Assert.Contains("beta", lines);
        Assert.Contains("gamma", lines);
    }

    [Fact]
    public void FileSaver_OverwriteAll_WithEmptyList_ClearsAllContent()
    {
        var saver = new FileSaver("test.txt");
        saver.AppendLine("some data");

        saver.OverwriteAll(new List<string>());

        var isEmpty = !File.Exists("test.txt") || File.ReadAllText("test.txt") == "";
        Assert.True(isEmpty);
    }

    // Model Tests

    [Fact]
    public void Event_ToString_ShowsNameAndCapacity()
    {
        // Spectre.Console calls ToString() to display events in selection menus.
        // If this format breaks, events will show incorrectly in the UI.
        var ev = new Event("Charity Run", 50);

        Assert.Equal("Charity Run (Max: 50)", ev.ToString());
    }

    [Fact]
    public void Volunteer_ToString_ShowsAllAssignments()
    {
        // This is what gets printed in the "Generate complete report" screen.
        // If this format breaks, the report will show incomplete information.
        var v = new Volunteer("Alice", "Charity Run", "Setup", "Hammer");

        Assert.Equal("Alice: Charity Run | Setup | Hammer", v.ToString());
    }

    [Fact]
    public void Volunteer_TaskAndTool_AreNotSwapped()
    {
        // The Volunteer constructor takes (name, eventName, taskItem, tool) in that order.
        // This test guards against accidentally swapping task and tool, which would
        // cause volunteers to be saved and displayed with the wrong assignments.
        var v = new Volunteer("Alice", "Charity Run", "Setup", "Hammer");

        Assert.Equal("Setup", v.TaskItem);
        Assert.Equal("Hammer", v.Tool);
    }

    [Fact]
    public void TaskItem_ToString_ShowsNameInMenu()
    {
        // Spectre.Console calls ToString() to display tasks in selection menus.
        // If this returns something unexpected, tasks won't be readable in the UI.
        var task = new TaskItem("Setup Chairs");

        Assert.Equal("Setup Chairs", task.ToString());
    }

    [Fact]
    public void Tool_ToString_ShowsNameInMenu()
    {
        // Spectre.Console calls ToString() to display tools in selection menus.
        // If this returns something unexpected, tools won't be readable in the UI.
        var tool = new Tool("Hammer");

        Assert.Equal("Hammer", tool.ToString());
    }
}