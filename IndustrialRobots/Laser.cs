namespace IndustrialRobots;

public class Laser : Tools
{
    public Laser(ToolEventArgs t)
    {
        ToolName = t.ToolName;
        ClassType = t.ClassType;
        Category = t.Category;
        Material = t.Material;
        Weight = t.Weight;
        Availability = true;
        SerialNumber = t.SerialNumber;
        Watts = t.Watts;
        Lumen = t.Lumen;
    }

    public int Lumen { get; set; }
    public int Watts { get; set; }
}