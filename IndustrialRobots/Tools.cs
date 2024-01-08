namespace IndustrialRobots;

//EventArgs for Tool Creation
public class Tools
{
    //set a list with serialNumbers
    public static List<int> SerialNumbers = SaveAllData.LoadSerialNumbersList();

    //Dictionary to store how much of each category is allowed,gets checked when Tool added
    public static Dictionary<string, int> Categories = new()
    {
        { "Destruction", 3 },
        { "Fixation", 1 },
        { "Manipulation", 2 },
        { "Welding", 2 }
    };

    public Tools()
    {
    }

    public Tools(string name, string classType, string category, string material, double weight, int serialNumber)
    {
        ToolName = name;
        ClassType = classType;
        Category = category;
        Material = material;
        Weight = weight;
        Availability = true;
        SerialNumber = serialNumber;
    }

    public string ToolName { get; set; }
    public string ClassType { get; set; } //Tool Type
    public string Category { get; set; } //what sort of tool
    public string Material { get; set; }
    public double Weight { get; set; } // Max load
    public bool Availability { get; set; } //If tool already chosen by robot
    public int SerialNumber { get; set; }

    //Initialize EventCaller for Toolcreation
    public event EventHandler<ToolEventArgs> ToolEvent;

    //unique numbers guaranteed
    public static int SerialNumberGenerator()
    {
        var rand = new Random();
        var sn = rand.Next(0, 20000);
        if (SerialNumbers.Contains(sn))
            sn = SerialNumberGenerator();
        SerialNumbers.Add(sn);
        SaveAllData.SaveSerialNumbersList(SerialNumbers);
        return sn;
    }


    //this is a nice one. Depending on type, create different subclass. Genius!
    public static Tools ToolConstructor(ToolEventArgs toolArgs)
    {
        return toolArgs.ClassType switch
        {
            "ArcWelder" => new ArcWelder(toolArgs),
            "Computer" => new Computer(toolArgs),
            "Drill" => new Drill(toolArgs),
            "DuctTape" => new DuctTape(toolArgs),
            "Laser" => new Laser(toolArgs)
        };
    }
}
