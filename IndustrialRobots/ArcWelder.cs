namespace IndustrialRobots;

public class ArcWelder : Tools
{
    public ArcWelder(ToolEventArgs t)
    {
        ToolName = t.ToolName;
        ClassType = t.ClassType;
        Category = t.Category;
        Material = t.Material;
        Weight = t.Weight;
        Availability = true;
        SerialNumber = t.SerialNumber;
        Watts = t.Watts;
        Heat = t.Heat;
    }

    public int Watts { get; set; }
    public int Heat { get; set; }
}