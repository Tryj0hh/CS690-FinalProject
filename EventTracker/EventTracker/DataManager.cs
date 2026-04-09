namespace EventTracker;

public class DataManager
{
    FileSaver eventFile;
    FileSaver volunteerFile;
    FileSaver taskFile;
    FileSaver toolFile;

    public List<Event> Events { get; }
    public List<Volunteer> Volunteers { get; }
    public List<TaskItem> Tasks { get; }
    public List<Tool> Tools { get; }

    public DataManager()
    {
        eventFile = new FileSaver("events.txt");
        volunteerFile = new FileSaver("volunteers.txt");
        taskFile = new FileSaver("tasks.txt");
        toolFile = new FileSaver("tools.txt");

        Events = new List<Event>();
        Volunteers = new List<Volunteer>();
        Tasks = new List<TaskItem>();
        Tools = new List<Tool>();

        LoadEvents();
        LoadVolunteers();
        LoadTasks();
        LoadTools();
    }

    private void LoadEvents()
    {
        if (File.Exists("events.txt"))
        {
            var lines = File.ReadAllLines("events.txt");

            foreach (var line in lines)
            {
                var parts = line.Split("|");

                if (parts.Length == 2 && int.TryParse(parts[1], out int max))
                {
                    Events.Add(new Event(parts[0], max));
                }
            }
        }
    }

    public void AddEvent(Event ev)
    {
        Events.Add(ev);
        eventFile.AppendLine($"{ev.Name}|{ev.MaxVolunteers}");
    }

    public void RemoveEvent(Event ev)
    {
        Events.Remove(ev);
        SynchronizeEvents();
    }

    public void SynchronizeEvents()
    {
        File.Delete("events.txt");

        foreach (var ev in Events)
        {
            File.AppendAllText("events.txt",
                $"{ev.Name}|{ev.MaxVolunteers}" + Environment.NewLine);
        }
    }

    private void LoadVolunteers()
    {
        if (File.Exists("volunteers.txt"))
        {
            foreach (var line in File.ReadAllLines("volunteers.txt"))
            {
                var parts = line.Split("|");

                if (parts.Length == 4)
                {
                    Volunteers.Add(new Volunteer(
                        parts[0],
                        parts[1],
                        parts[2],
                        parts[3]
                    ));
                }
            }
        }
    }

    public void AddVolunteer(Volunteer v)
    {
        Volunteers.Add(v);
        volunteerFile.AppendLine($"{v.Name}|{v.Event}|{v.TaskItem}|{v.Tool}");
    }

    public void RemoveVolunteer(Volunteer v)
    {
        Volunteers.Remove(v);
        SynchronizeVolunteers();
    }

    public void SynchronizeVolunteers()
    {
        File.Delete("volunteers.txt");

        foreach (var v in Volunteers)
        {
            File.AppendAllText("volunteers.txt",
                $"{v.Name}|{v.Event}|{v.Tool}|{v.TaskItem}" + Environment.NewLine);
        }
    }

    private void LoadTasks()
    {
        if (File.Exists("tasks.txt"))
        {
            foreach (var line in File.ReadAllLines("tasks.txt"))
            {
                Tasks.Add(new TaskItem(line));
            }
        }
    }

    public void AddTask(TaskItem t)
    {
        Tasks.Add(t);
        taskFile.AppendLine(t.Name);
    }

    public void RemoveTask(TaskItem t)
    {
        Tasks.Remove(t);
        SynchronizeTasks();
    }

    public void SynchronizeTasks()
    {
        File.Delete("tasks.txt");

        foreach (var t in Tasks)
        {
            File.AppendAllText("tasks.txt", t.Name + Environment.NewLine);
        }
    }

    private void LoadTools()
    {
        if (File.Exists("tools.txt"))
        {
            foreach (var line in File.ReadAllLines("tools.txt"))
            {
                Tools.Add(new Tool(line));
            }
        }
    }

    public void AddTool(Tool t)
    {
        Tools.Add(t);
        toolFile.AppendLine(t.Name);
    }

    public void RemoveTool(Tool t)
    {
        Tools.Remove(t);
        SynchronizeTools();
    }

    public void SynchronizeTools()
    {
        File.Delete("tools.txt");

        foreach (var t in Tools)
        {
            File.AppendAllText("tools.txt", t.Name + Environment.NewLine);
        }
    }
}