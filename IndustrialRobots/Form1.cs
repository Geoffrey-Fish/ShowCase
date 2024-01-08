namespace IndustrialRobots;

public partial class Form1 : Form
{
    #region fields
    //set a robots list for saving
    private List<Robotnik>? RoboList;
    //set a tool list for saving
    private List<Tools>? ToolList;

    #endregion

    #region Initialization
    public Form1()
    {
        InitializeComponent();
        //Closing operation for saving
        FormClosing += Form1_FormClosing;
        //Robotlist, if exists load Robots
        RoboList = SaveAllData.LoadRobotsFromList();
        //ToolsList, if exists, load tools
        ToolList = SaveAllData.LoadToolsFromList();
        //Combobox setups:
        addToolM_cobo_SetUp();
        chooseRobotM_cobo_SetUp();

        //Todo: Sorting System
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    #endregion

    #region Tool Creation Form. Instance new tool,list it for toolChooser
    private void createToolM_btn_Click(object sender, EventArgs e)
    {
        using var popUp = new ToolCreation();
        if (popUp.ShowDialog() == DialogResult.OK)
        {
            var toolStats = new ToolEventArgs
            {
                ClassType = popUp.ClassType,
                ToolName = popUp.Name,
                Category = popUp.Category,
                Material = popUp.Material,
                Weight = popUp.Weight,
                SerialNumber = popUp.SerialNumber,
                Watts = popUp.Watts,
                Lumen = popUp.Lumen,
                Heat = popUp.Heat,
                Length = popUp.Length,
                Flops = popUp.Flops
            };

            //Create tool, add to toolslist
            if (ToolList != null)
            {
                switch (popUp.ClassType)
                {
                    case "Drill":
                        ToolList.Add(new Drill(toolStats));
                        break;
                    case "ArcWelder":
                        ToolList.Add(new ArcWelder(toolStats));
                        break;
                    case "Computer":
                        ToolList.Add(new Computer(toolStats));
                        break;
                    case "DuctTape":
                        ToolList.Add(new DuctTape(toolStats));
                        break;
                    case "Laser":
                        ToolList.Add(new Laser(toolStats));
                        break;
                }

                SaveAllData.SaveToolList(ToolList);
            }

            //update dropdownlist
            addToolM_cobo_SetUp();
        }
    }
    #endregion

    #region Robot Creation Form instance a new robot,// let it be listed by the protocol
    private void createRobotM_btn_Click(object sender, EventArgs e)
    {
        using var popUp = new RobotCreation();
        //After the form is completed and the create button was clicked,
        //it will get all data from the closed form to work with
        if (popUp.ShowDialog() == DialogResult.OK)
        {
            var roboname = popUp.RobotName;
            var slots = popUp.ToolBoxSize;
            var maxWeight = popUp.MaxWeight;

            Robotnik robotnik = new(roboname, slots, maxWeight);

            //Add Robot to RobotList,dropdown menu
            if (RoboList != null)
            {
                RoboList.Add(robotnik);
                SaveAllData.SaveRoboList(RoboList);
            }

            //actualisation dropdown list
            chooseRobotM_cobo_SetUp();
        }
    }
    #endregion

    #region Choose Robot

    //Choose Robot from Dropdown
    private void chooseRobotM_cobo_SetUp()
    {
        choseRobotM_cobo.DataSource = null; //clear it
        choseRobotM_cobo.DataSource = RoboList; //reassign it with new entries
        choseRobotM_cobo.DisplayMember = "Name";
    }
    //Update infofields after selecting a Robot
    private void choseRobotM_cobo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RoboList != null && RoboList.Count > 0)
        {
            Robotnik robo = (Robotnik)choseRobotM_cobo.SelectedItem; //Form Robot linked
            if (choseRobotM_cobo.SelectedItem != null) //Necessary if first action is the creation and not to choose a robot from the list
            {
                currentRobotM_tbx.Text = robo.Name; //Name Tag in Form
                currentLoad_tbx.Text = robo.CurrentWeight.ToString("##.##"); //Weight Tag in Form
                slotsM_tbx.Text = robo.Slots.ToString(); //Show total number of Slots
                addToolM_cobo_SetUp();
                currentToolsM_cobo_Setup(robo);
                removeTool_cobo_SetUp(robo);
            }
        }
    }
    #endregion

    #region Add Tools

    private void addToolM_cobo_SetUp()
    {
        addToolM_cobo.DataSource = null;
        //Sort out all tools that are currently in use
        var availableToolsList = ToolList.Where(tool => tool.Availability).ToList();
        addToolM_cobo.DataSource = availableToolsList; //the List
        //addToolM_cobo.DataSource = ToolList;
        addToolM_cobo.DisplayMember = "ToolName";
    }
    private void addToolM_cobo_SelectedIndexChanged(object sender, EventArgs e)
    {
        addToolM_btn.Enabled = true;
    }
    //Add tool to Robot & new protocoll entry
    private void addToolM_btn_Click(object sender, EventArgs e)
    {
        if (choseRobotM_cobo.SelectedItem != null && addToolM_cobo.SelectedItem != null)
        {
            var robotnik = (Robotnik)choseRobotM_cobo.SelectedItem;
            var tool = (Tools)addToolM_cobo.SelectedItem;
            if (robotnik.ToolBox.Count >= robotnik.Slots)
            {
                MessageBox.Show("Your Toolbox is allready full.");
                return;
            }
            if (tool.Availability)
            {
                robotnik.AddTool(tool); //Add tool to robot
                addToolM_btn.Enabled = false; //safety measure
                SaveAllData.SaveRoboList(RoboList);//save states for protocols
                SaveAllData.SaveToolList(ToolList);
                currentToolsM_cobo_Setup(robotnik); //update current robots tool dropdown & infos
                removeTool_cobo_SetUp(robotnik);
                addToolM_cobo_SetUp();
            }
            else
            {
                MessageBox.Show(@"Tool allready used");
            }
        }
        else
        {
            MessageBox.Show("Error, no robot active");
        }
    }

    #endregion

    #region Remove Tools

    //update database for dropdown menu tools
    private void removeTool_cobo_SetUp(Robotnik robotnik)
    {
        if (robotnik.ToolBox != null && robotnik.CurrentWeight > 0)
        {
            removeTool_cobo.DataSource = null;
            removeTool_cobo.DataSource = robotnik.ToolBox;
            removeTool_cobo.DisplayMember = "Name";
        }
    }
    //First, take the tool of the robot into focus
    private void removeTool_cobo_SelectedIndexChanged(object sender, EventArgs e)
    {
        removeToolM_btn.Enabled = true;
    }
    //Then, remove Tool from robot & new protocoll entry
    private void removeToolM_btn_Click(object sender, EventArgs e)
    {
        if (removeTool_cobo.SelectedItem != null && choseRobotM_cobo.SelectedItem != null)
        {
            var robotnik = (Robotnik)choseRobotM_cobo.SelectedItem;
            var tool = (Tools)removeTool_cobo.SelectedItem;
            if (robotnik.ToolBox.Count == 0)
            {
                MessageBox.Show("Sumding wung.Toolbox empty???");
                return;
            }
            if (!tool.Availability)
            {
                robotnik.RemoveTool(tool);
                SlotsBlockedUpdate(robotnik);
                removeToolM_btn.Enabled = false; //safety lock
                SaveAllData.SaveRoboList(RoboList);//save states for protocols
                SaveAllData.SaveToolList(ToolList);

                removeTool_cobo_SetUp(robotnik); //update dropdowns
                currentToolsM_cobo_Setup(robotnik);
                addToolM_cobo_SetUp();
            }
            else
            {
                MessageBox.Show("That item is allready free!");
                removeToolM_btn.Enabled = false;
            }
        }
        else //if all empty
        {
            removeToolM_btn.Enabled = false;
            MessageBox.Show("Please select robot and tool.");
        }
    }

    #endregion

    #region CurrentToolsInfo

    //call for to current robots toolbox dropdown menu
    private void currentToolsM_cobo_Setup(Robotnik robotnik)
    {
        currentToolsM_cobo.DataSource = null;
        currentToolsM_cobo.DataSource = robotnik.ToolBox;
        currentToolsM_cobo.DisplayMember = "ToolName";
        currentLoad_tbx.Text = robotnik.CurrentWeight.ToString("##.##");
        SlotsBlockedUpdate(robotnik); //Little visual helper
    }

    private void currentToolsM_cobo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (currentToolsM_cobo.SelectedItem != null)
        {
            var tool = (Tools)currentToolsM_cobo.SelectedItem;
            //set it for removal as a choice
            removeTool_cobo.SelectedItem = tool;
            currentToolsM_InfoBoxUpdate(tool);
        }
    }

    //show current infos about the tool in the toolbox
    private void currentToolsM_InfoBoxUpdate(Tools tool)
    {
        ctname_lbl.Text = tool.ToolName;
        ctType_lbl.Text = tool.ClassType;
        ctCat_lbl.Text = tool.Category;
        ctweight_lbl.Text = tool.Weight.ToString("##.##");
        ctsnr_lbl.Text = tool.SerialNumber.ToString();
        //Now it gets tricky and messy,see Protocol Tooltable for more
        if (tool is Drill drill)
        {
            ctWatts_lbl.Text = drill.Watts.ToString();
        }
        else if (tool is ArcWelder arc)
        {
            ctWatts_lbl.Text = arc.Watts.ToString();
            ctHeat_lbl.Text = arc.Heat.ToString();
        }
        else if (tool is Laser laser)
        {
            ctWatts_lbl.Text = laser.Watts.ToString();
            ctLumen_lbl.Text = laser.Lumen.ToString();
        }
        else if (tool is Computer com)
        {
            ctWatts_lbl.Text = com.Watts.ToString();
            ctFlops_lbl.Text = com.Flops.ToString();
        }
        else if (tool is DuctTape duc)
        {
            ctLength_lbl.Text = duc.Length.ToString();
        }
    }

    //Updatefunction for Slotsfield current Robot
    private void SlotsBlockedUpdate(Robotnik robotnik)
    {
        var count = robotnik.ToolBox.Count;
        slotsBlocked_tbx.Text = count.ToString();
    }

    #endregion

    #region Miscallenous

    //show protocolldatasheet
    private void protocolM_btn_Click(object sender, EventArgs e)
    {
        //just to be sure everything is up to date
        SaveAllData.SaveRoboList(RoboList);//save states for protocols
        SaveAllData.SaveToolList(ToolList);

        Protocol.ShowProtocol();
    }

    #endregion

    #region Close App

    //On closing of the App
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Perform saving operations here
        SaveAllData.SaveToolList(ToolList);
        SaveAllData.SaveRoboList(RoboList);
        MessageBox.Show("All saved, see ya!");
    }

    #endregion


}