namespace IndustrialRobots;

public class RobotEventArgs : EventArgs
{
    public DateTime Date { get; set; }
    public string? Direction { get; set; }
    public string? RobotName { get; set; }
    public double CurrentWeight { get; set; }
    public string? ToolName { get; set; }
    public string? ClassType { get; set; }
    public double ToolWeight { get; set; }
    public int ToolSerialNumber { get; set; }
}