namespace EventTracker;

using Spectre.Console;

public class ConsoleUI
{
    public void Show()
    {

        do
        {
            AnsiConsole.Clear();

            var selection = AnsiConsole.Prompt(
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
                var eventSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices(new[]
                    {
                        "Add Event",
                        "Modify Event",
                        "Delete Event",
                        "Back"
                    }));
            }

            else if (selection == "Volunteers"){
                var volunteerSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices(new[]
                    {
                        "Add Volunteer",
                        "Modify Volunteer",
                        "Delete Volunteer",
                        "Back"
                    }));
            }

            else if (selection == "Tasks"){
                var taskSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices(new[]
                    {
                        "Add Task",
                        "Modify Task",
                        "Delete Task",
                        "Back"
                    }));
            }

            else if (selection == "Tools"){
                var toolSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices(new[]
                    {
                        "Add Tool",
                        "Modify Tool",
                        "Delete Tool",
                        "Back"
                    }));
            }

            else if (selection == "Reports"){
                var reportSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices(new[]
                    {
                        "Generate complete report",
                        "Show Total Sign Ups",
                        "Back"
                    }));
            }

        } while (selection !="End");
    }
}