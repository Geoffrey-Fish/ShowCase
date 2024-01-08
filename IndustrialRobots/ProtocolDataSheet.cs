using Newtonsoft.Json;

using System.Data;

namespace IndustrialRobots;

public partial class ProtocolDataSheet : Form
{
    public ProtocolDataSheet() //This form, Main init
    {
        _dataSet = new DataSet(); //  dataSet for communication
        InitializeComponent();
        CreateProtocolTable(ProtocolTable);
        CreateToolTable(ToolTable);
        CreateRobotTable(RobotTable);
        //Instanciate bindingsources
        _bsProtocol = new BindingSource();
        _bsTool = new BindingSource();
        _bsRobot = new BindingSource();
        //bindingsource to table
        _bsProtocol.DataSource = ProtocolTable;
        _bsTool.DataSource = ToolTable;
        _bsRobot.DataSource = RobotTable;
    }

    #region initialization

    internal static string ToolsPath = "..\\listOfTools.json";

    internal static string RobotsPath = "..\\listOfRobots.json";

    internal static string ProtocolDataPath = "..\\ProtocolData.csv";

    //Bindings of the tables
    private readonly BindingSource _bsProtocol;
    private readonly BindingSource _bsRobot;

    private readonly BindingSource _bsTool;

    //Dataset is the table collection
    private readonly DataSet _dataSet;

    //Instance the tables for protocol, robotlist and toolslist
    public DataTable ProtocolTable = new("Protocol");
    public DataTable RobotTable = new("RobotTable");
    public DataTable ToolTable = new("ToolTable");

    #endregion

    #region ProtocolTable related

    //Create Protocol
    private void CreateProtocolTable(DataTable protocolTable)
    {
        var dtaColumn =
            new DataColumn
            {
                DataType = typeof(DateTime), //storage type
                ColumnName = "Date", // column name
                Caption = "DateTime" //reader friendly column name
            };
        protocolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(string), //storage type
            ColumnName = "Direction", // column name
            Caption = "Add or Rem" //reader friendly column name
        };
        protocolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(string), //storage type
            ColumnName = "RobotName", // column name
            Caption = "Robot Name" //reader friendly column name
        };
        protocolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(double), //storage type
            ColumnName = "RoboWeight", // column name
            Caption = "RobotLoad" //reader friendly column name
        };
        protocolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(string), //storage type
            ColumnName = "ToolName", // column name
            Caption = "Tool Name" //reader friendly column name
        };
        protocolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(string), //storage type
            ColumnName = "ToolType", // column name
            Caption = "Tool Type" //reader friendly column name
        };
        protocolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(double), //storage type
            ColumnName = "Weight", // column name
            Caption = "Item Weight" //reader friendly column name
        };
        protocolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(int), //storage type
            ColumnName = "SNR", // column name
            Caption = "SerialNumber" //reader friendly column name
        };
        protocolTable.Columns.Add(dtaColumn);

        //Now add the table to the _dataset
        _dataSet.Tables.Add(protocolTable);
    }

    //Protocol Datasheet Button Click
    private void loadProtocolDV_btn_Click(object sender, EventArgs e)
    {
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = _bsProtocol;
        if (File.Exists(ProtocolDataPath))
        {
            using StreamReader sr = new(ProtocolDataPath);
            while (!sr.EndOfStream)
            {
                var rows = sr.ReadLine()?.Split(',');
                ProtocolTable.Rows.Add(rows);
            }
            loadProtocolDV_btn.Enabled = false;
            loadToolDV_btn.Enabled = true;
            loadRoboDV_btn.Enabled = true;
        }
        else
        {
            MessageBox.Show("No file found.");
        }
    }

    #endregion

    #region ToolProtocol related

    //ToolProtocol design
    private void CreateToolTable(DataTable toolTable)
    {
        var dtaColumn =
            new DataColumn
            {
                DataType = typeof(string), //storage type
                ColumnName = "Name", // column name
                Caption = "Name" //reader friendly column name
            };
        toolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(string), //storage type
            ColumnName = "ClassType", // column name
            Caption = "Type" //reader friendly column name
        };
        toolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(string), //storage type
            ColumnName = "Category", // column name
            Caption = "Category" //reader friendly column name
        };
        toolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(string), //storage type
            ColumnName = "Material", // column name
            Caption = "Material" //reader friendly column name
        };
        toolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(double), //storage type
            ColumnName = "Weight", // column name
            Caption = "Weight" //reader friendly column name
        };
        toolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(int), //storage type
            ColumnName = "SNR", // column name
            Caption = "SerialNumber" //reader friendly column name
        };
        toolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(int), //storage type
            ColumnName = "Watts", // column name
            Caption = "Watts" //reader friendly column name
        };
        toolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(int), //storage type
            ColumnName = "Lumen", // column name
            Caption = "Lumen" //reader friendly column name
        };
        toolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(int), //storage type
            ColumnName = "Heat", // column name
            Caption = "Heat" //reader friendly column name
        };
        toolTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(int), //storage type
            ColumnName = "Length", // column name
            Caption = "Length" //reader friendly column name
        };
        toolTable.Columns.Add(dtaColumn);
        dtaColumn = new DataColumn
        {
            DataType = typeof(int), //storage type
            ColumnName = "Flops", // column name
            Caption = "Flops" //reader friendly column name
        };
        toolTable.Columns.Add(dtaColumn);
        _dataSet.Tables.Add(toolTable);
    }

    //ToolProtocol Button Click
    private void loadToolDV_btn_Click(object sender, EventArgs e)
    {
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = _bsTool;
        if (File.Exists(ToolsPath))
        {
            var json = File.ReadAllText(ToolsPath);
            var toolsList = JsonConvert.DeserializeObject<List<Tools>>(json);
            foreach (object tool in toolsList)
            {
                var newRow = ToolTable.NewRow();
                if (tool is Tools tools)
                {
                    newRow["Name"] = tools.ToolName;
                    newRow["ClassType"] = tools.ClassType;
                    newRow["Category"] = tools.Category;
                    newRow["Material"] = tools.Material;
                    newRow["Weight"] = tools.Weight;
                    newRow["SNR"] = tools.SerialNumber;
                }

                //Now it gets tricky and messy, i need to guess each time which tool it is and add the columns accordingly!
                //now after long tests with chat, i have a solution on my own!Take that, ml bitch.
                if (tool is Drill drill)
                {
                    newRow["Watts"] = drill.Watts;
                }
                else if (tool is ArcWelder arc)
                {
                    newRow["Watts"] = arc.Watts;
                    newRow["Heat"] = arc.Heat;
                }
                else if (tool is Laser laser)
                {
                    newRow["Watts"] = laser.Watts;
                    newRow["Lumen"] = laser.Lumen;
                }
                else if (tool is Computer com)
                {
                    newRow["Watts"] = com.Watts;
                    newRow["Flops"] = com.Flops;
                }
                else if (tool is DuctTape duc)
                {
                    newRow["Length"] = duc.Length;
                }

                ToolTable.Rows.Add(newRow);
            }
            loadProtocolDV_btn.Enabled = true;
            loadToolDV_btn.Enabled = false;
            loadRoboDV_btn.Enabled = true;
        }
        else
        {
            MessageBox.Show("Sorry, no file found.");
        }
    }

    #endregion

    #region RobotProtocol related

    //RobotProtocol design
    private void CreateRobotTable(DataTable robotTable)
    {
        var dtaColumn =
            new DataColumn
            {
                DataType = typeof(string), //storage type
                ColumnName = "Name", // column name
                Caption = "Name" //reader friendly column name
            };
        robotTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(int), //storage type
            ColumnName = "MaxSlots", // column name
            Caption = "Max Slots" //reader friendly column name
        };
        robotTable.Columns.Add(dtaColumn);
        dtaColumn = new DataColumn
        {
            DataType = typeof(int), //storage type
            ColumnName = "FreeSlots", // column name
            Caption = "Free Slots" //reader friendly column name
        };
        robotTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(double), //storage type
            ColumnName = "MaxWeight", // column name
            Caption = "Maximum Weight" //reader friendly column name
        };
        robotTable.Columns.Add(dtaColumn);

        dtaColumn = new DataColumn
        {
            DataType = typeof(double), //storage type
            ColumnName = "CurrentWeight", // column name
            Caption = "Current Weight" //reader friendly column name
        };
        robotTable.Columns.Add(dtaColumn);

        //Now add the table to the _dataset
        _dataSet.Tables.Add(robotTable);
    }

    //Robotprotocol Button Click
    private void loadRoboDV_btn_Click(object sender, EventArgs e)
    {
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = _bsRobot;
        if (File.Exists(RobotsPath))
        {
            var json = File.ReadAllText(RobotsPath);
            var robotList = JsonConvert.DeserializeObject<List<Robotnik>>(json)!;
            foreach (var robo in robotList)
            {
                var newRow = RobotTable.NewRow(); //create new row
                newRow["Name"] = robo.Name; //write in each corresponding column the value
                newRow["FreeSlots"] = robo.Slots - robo.ToolBox.Count();
                newRow["MaxSlots"] = robo.Slots;
                newRow["MaxWeight"] = robo.MaxWeight;
                newRow["CurrentWeight"] = robo.CurrentWeight;
                RobotTable.Rows.Add(newRow); //Add Row to Table
            }
            loadProtocolDV_btn.Enabled = true;
            loadToolDV_btn.Enabled = true;
            loadRoboDV_btn.Enabled = false;
        }
        else
        {
            MessageBox.Show("Bro, there ain't no file yet.");
        }
    }

    #endregion

}