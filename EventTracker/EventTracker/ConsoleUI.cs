namespace EventTracker;

using Spectre.Console;

public class ConsoleUI
{
    DataManager dataManager;

    public ConsoleUI(){
        dataManager = new DataManager();
    }

    public void Show()
    {
        string selection;
        string eventSelection;
        string volunteerSelection;
        string taskSelection;
        string toolSelection;
        string reportSelection;

        do
        {
            AnsiConsole.Clear();

            selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices(new[]
                    {
                        "Events",
                        "Volunteers",
                        "Tasks",
                        "Tools",
                        "Reports",
                        "End"
                    }));
            
            if (selection == "Events"){
                do 
                {
                    AnsiConsole.Clear();

                    eventSelection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What do you want to do?")
                        .AddChoices(new[]
                        {
                            "Add Event",
                            "Modify Event",
                            "Delete Event",
                            "Back"
                        }));

                        if (eventSelection == "Add Event"){
                            var name = AnsiConsole.Ask<string>("Enter event name:");
                            var max = AnsiConsole.Ask<int>("Enter max volunteer capacity");

                            dataManager.AddEvent(new Event(name, max));

                            AnsiConsole.WriteLine("You have added an event");
                            AnsiConsole.WriteLine("Click any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        else if (eventSelection == "Delete Event"){
                            if (dataManager.Events.Count == 0){
                                AnsiConsole.WriteLine("No events to delete");
                                AnsiConsole.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }

                            var selected = AnsiConsole.Prompt(
                                new SelectionPrompt<Event>()
                                    .Title("Select event:")
                                    .AddChoices(dataManager.Events));

                            dataManager.RemoveEvent(selected);

                            AnsiConsole.WriteLine("Event Deleted");
                            AnsiConsole.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }
                } while (eventSelection != "Back");
            }

            else if (selection == "Volunteers"){
                do
                {
                volunteerSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices(new[]
                    {
                        "Add Volunteer",
                        "Modify Volunteer",
                        "Delete Volunteer",
                        "Back"
                    }));

                    if (volunteerSelection == "Add Volunteer"){
                        var name = AnsiConsole.Ask<string>("Enter volunteer name:");

                        dataManager.AddVolunteer(new Volunteer(name));

                        AnsiConsole.WriteLine("You have added a volunteer");
                        AnsiConsole.WriteLine("Click any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    else if (volunteerSelection == "Delete Volunteer"){
                        if (dataManager.Volunteers.Count == 0){
                                AnsiConsole.WriteLine("No volunteers to delete");
                                AnsiConsole.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }

                        var selected = AnsiConsole.Prompt(
                            new SelectionPrompt<Volunteer>()
                                .Title("Select volunteer:")
                                .AddChoices(dataManager.Volunteers));

                        dataManager.RemoveVolunteer(selected);

                        AnsiConsole.WriteLine("Volunteer Deleted");
                        AnsiConsole.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }

                } while (volunteerSelection != "Back");
            }

            else if (selection == "Tasks"){
                do
                {
                taskSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices(new[]
                    {
                        "Add Task",
                        "Modify Task",
                        "Delete Task",
                        "Back"
                    }));

                    if (taskSelection == "Add Task"){
                        var name = AnsiConsole.Ask<string>("Enter task name:");

                        dataManager.AddTask(new TaskItem(name));

                        AnsiConsole.WriteLine("You have added a task");
                        AnsiConsole.WriteLine("Click any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    else if (taskSelection == "Delete Task"){
                        if (dataManager.Tasks.Count == 0){
                                AnsiConsole.WriteLine("No tasks to delete");
                                AnsiConsole.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }

                        var selected = AnsiConsole.Prompt(
                            new SelectionPrompt<TaskItem>()
                                .Title("Select task:")
                                .AddChoices(dataManager.Tasks));

                        dataManager.RemoveTask(selected);

                        AnsiConsole.WriteLine("Task Deleted");
                        AnsiConsole.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }

                } while (taskSelection != "Back");
            }

            else if (selection == "Tools"){
                do
                {
                toolSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices(new[]
                    {
                        "Add Tool",
                        "Modify Tool",
                        "Delete Tool",
                        "Back"
                    }));

                    if (toolSelection == "Add Tool"){
                        var name = AnsiConsole.Ask<string>("Enter tool name:");

                        dataManager.AddTool(new Tool(name));

                        AnsiConsole.WriteLine("You have added a tool");
                        AnsiConsole.WriteLine("Click any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    else if (toolSelection == "Delete Tool"){
                        if (dataManager.Tools.Count == 0){
                                AnsiConsole.WriteLine("No tools to delete");
                                AnsiConsole.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }

                        var selected = AnsiConsole.Prompt(
                            new SelectionPrompt<Tool>()
                                .Title("Select tool:")
                                .AddChoices(dataManager.Tools));

                        dataManager.RemoveTool(selected);

                        AnsiConsole.WriteLine("Tool Deleted");
                        AnsiConsole.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }

                } while (toolSelection != "Back");    
            }

            else if (selection == "Reports"){
                do
                {
                reportSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices(new[]
                    {
                        "Generate complete report",
                        "Show Total Sign Ups",
                        "Back"
                    }));
                } while (reportSelection != "Back");
            }

        } while (selection !="End");
    }
}