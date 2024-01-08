namespace IndustrialRobots;

public class Drill : Tools
{
    public Drill(ToolEventArgs t)
    {
        ToolName = t.ToolName;
        ClassType = t.ClassType;
        Category = t.Category;
        Material = t.Material;
        Weight = t.Weight;
        Availability = true;
        SerialNumber = t.SerialNumber;
        Watts = t.Watts;
    }

    public int Watts { get; set; }
}