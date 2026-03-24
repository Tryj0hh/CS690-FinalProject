namespace EventTracker;

using System.IO;

public class FileSaver
{
    private string fileName;

    public FileSaver(string fileName)
    {
        this.fileName = fileName;

        if (!File.Exists(this.fileName))
        {
            File.Create(this.fileName).Close();
        }
    }

    public void AppendLine(string line)
    {
        File.AppendAllText(this.fileName, line + Environment.NewLine);
    }

    public void OverwriteAll(List<string> lines)
    {
        File.Delete(this.fileName);

        foreach (var line in lines)
        {
            File.AppendAllText(this.fileName, line + Environment.NewLine);
        }
    }
}