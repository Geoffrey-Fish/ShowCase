using Newtonsoft.Json;

namespace IndustrialRobots;

public class SaveAllData
{
    #region Datapaths

    internal static string ToolsPath = "..\\listOfTools.json";
    internal static string RobotsPath = "..\\listOfRobots.json";
    internal static string ProtocolDataPath = "..\\ProtocolData.csv"; //This is the Protocol
    internal static string SerialNumbersPath = "..\\SerialNumbers.csv";

    #endregion

    #region Loadfunctions
    //Loadfunction for the ToolsList
    public static List<Tools> LoadToolsFromList()
    {
        if (File.Exists(ToolsPath))
        {
            var json = File.ReadAllText(ToolsPath);
            return JsonConvert.DeserializeObject<List<Tools>>(json);
        }

        return new List<Tools>();
    }

    //Loadfunction for the robotnik list
    public static List<Robotnik> LoadRobotsFromList()
    {
        if (File.Exists(RobotsPath))
        {
            var json = File.ReadAllText(RobotsPath);
            return JsonConvert.DeserializeObject<List<Robotnik>>(json);
        }

        return new List<Robotnik>();
    }


    //Load the serialnumbers
    public static List<int> LoadSerialNumbersList()
    {
        var snrs = new List<int>();
        if (File.Exists(SerialNumbersPath))
            using (var sr = new StreamReader(SerialNumbersPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    if (int.TryParse(line, out var serialNumber))
                        snrs.Add(serialNumber);
                    else
                        Console.WriteLine($"Failed to parse serial number: {line}");
                // You can handle the parsing failure as per your requirements
                // For example, you can log an error, skip the line, or take appropriate action
            }

        return snrs;
    }

    #endregion

    #region savefunctions
    public static void SaveSerialNumbersList(List<int> snrs)
    {
        using (var sw = new StreamWriter(SerialNumbersPath))
        {
            foreach (var serialNumber in snrs) sw.WriteLine(serialNumber.ToString());
        }
    }

    public static void SaveToolList(List<Tools> tools)
    {
        var serializer = new JsonSerializer();

        using (var sw = new StreamWriter(ToolsPath))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, tools);
        }
    }

    public static void SaveRoboList(List<Robotnik> robot)
    {
        var serializer = new JsonSerializer();

        using (var sw = new StreamWriter(RobotsPath))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, robot);
        }
    }
    #endregion
}