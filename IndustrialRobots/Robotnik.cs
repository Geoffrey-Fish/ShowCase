namespace IndustrialRobots;

public class Robotnik
{
    private Protocol ProtoInstance;
    public string? Name { get; set; }
    public int Slots { get; set; } //Places in toolbox
    public double MaxWeight { get; set; } // Max load of tools only, assuming robotweight is irrelevant
    public double CurrentWeight { get; set; } //Weight of tools
    public List<Tools> ToolBox { get; set; } //Toolbox as a List, because Array is Bullshit

    public event EventHandler<RobotEventArgs> RobotEvent; //Eventhandler
    //Empty instance for the protocolinstance
    public Robotnik()
    {
    }

    public Robotnik(string? name, int slots, double maxWeight)
    {
        Name = name;
        Slots = slots;
        MaxWeight = maxWeight;
        CurrentWeight = 0;
        ToolBox = new List<Tools>();
    }


    //Add tool to robot and change status
    public void AddTool(Tools tool)
    {
        if (!tool.Availability)
        {
            MessageBox.Show("Tool already in use.");
            return;
        }

        if (ToolBox.Count >= Slots)
        {
            MessageBox.Show("Toolbox is full!");
            return;
        }

        if (!MaxAmountOfToolCategory(tool))
        {
            MessageBox.Show("Error! Maximum number of same tool reached!");
            return;
        }

        if (CurrentWeight + tool.Weight > MaxWeight)
        {
            MessageBox.Show("Abort. Max Weight reached with that tool.");
            return;
        }

        ProtoInstance = new Protocol();
        RobotEvent += ProtoInstance.AddProtocol;
        ToolBox.Add(tool);
        CurrentWeight += tool.Weight;
        tool.Availability = false;

        var toolAdded = new RobotEventArgs
        {
            Date = DateTime.Now,
            Direction = "Add",
            RobotName = Name,
            CurrentWeight = CurrentWeight,
            ToolName = tool.ToolName,
            ClassType = tool.ClassType,
            ToolWeight = tool.Weight,
            ToolSerialNumber = tool.SerialNumber
        };

        OnToolAdded(toolAdded);
    }

    //remove tool from robot and make it available again
    public void RemoveTool(Tools tool)
    {
        if (this.ToolBox.Contains(tool))
        {
            CurrentWeight -= tool.Weight;
            tool.Availability = true;
            ProtoInstance = new Protocol();
            RobotEvent += ProtoInstance.AddProtocol;
            ToolBox.Remove(tool);
        }
        else if (ToolBox.Count == 0)
        {
            MessageBox.Show("The Toolbox is empty, dafuq");
            return;
        }
        else
        {
            MessageBox.Show("This item is not in the Toolbox!");
            return;
        }

        var toolRemoved = new RobotEventArgs
        {
            Date = DateTime.Now,
            Direction = "Remove",
            RobotName = Name,
            CurrentWeight = CurrentWeight,
            ToolName = tool.ToolName,
            ClassType = tool.ClassType,
            ToolWeight = tool.Weight,
            ToolSerialNumber = tool.SerialNumber
        };

        OnToolTaken(toolRemoved);
    }

    private bool MaxAmountOfToolCategory(Tools tool) //This checks if maxAmount(predefined) is reached
    {
        var CategoryToCount = tool.Category;
        var counts = ToolBox.Count(x => x.Category == CategoryToCount);
        Tools.Categories.TryGetValue(CategoryToCount,
            out var catMax); //search for the maxvalue of the item in the dictionary for this
        return counts < catMax; //return bool if maxAmount is reached
    }

    //Eventhandler, sends info to the protocoll class for,well, protocolling^^
    protected virtual void OnToolAdded(RobotEventArgs toolAdded)
    {
        RobotEvent?.Invoke(this, toolAdded);
    }

    protected virtual void OnToolTaken(RobotEventArgs toolTaken)
    {
        RobotEvent?.Invoke(this, toolTaken);
    }
}