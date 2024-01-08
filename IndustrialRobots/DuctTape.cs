namespace IndustrialRobots;

public class DuctTape : Tools
{
    public DuctTape(ToolEventArgs t)
    {
        ToolName = t.ToolName;
        ClassType = t.ClassType;
        Category = t.Category;
        Material = t.Material;
        Weight = t.Weight;
        Availability = true;
        SerialNumber = t.SerialNumber;
        Length = t.Length;
    }

    public int Length { get; set; }
}