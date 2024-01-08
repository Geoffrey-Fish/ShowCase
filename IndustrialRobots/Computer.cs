namespace IndustrialRobots;

public class Computer : Tools
{
    public Computer(ToolEventArgs t)
    {
        ToolName = t.ToolName;
        ClassType = t.ClassType;
        Category = t.Category;
        Material = t.Material;
        Weight = t.Weight;
        Availability = true;
        SerialNumber = t.SerialNumber;
        Watts = t.Watts;
        Flops = t.Flops;
    }

    public int Watts { get; set; }
    public int Flops { get; set; }
}