namespace EventTracker;

using Spectre.Console;

public class ConsoleUI
{
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