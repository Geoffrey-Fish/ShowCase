namespace IndustrialRobots;

public class ToolEventArgs : EventArgs
{
    public string? ToolName { get; set; }
    public string? ClassType { get; set; }
    public string? Category { get; set; }
    public string? Material { get; set; }
    public double Weight { get; set; }
    public int SerialNumber { get; set; }
    public int Watts { get; set; }
    public int Lumen { get; set; }
    public int Heat { get; set; }
    public int Length { get; set; }
    public int Flops { get; set; }
}