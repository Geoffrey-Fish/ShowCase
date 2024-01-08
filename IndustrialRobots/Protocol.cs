namespace IndustrialRobots;

public class Protocol
{
    private static string Path = "..\\ProtocolData.csv";

    public Protocol()
    {
    }
    public void AddProtocol(object sender, RobotEventArgs r)
    {
        var csvLine = string.Join(",",
            r.Date,
            r.Direction,
            r.RobotName,
            r.CurrentWeight,
            r.ToolName,
            r.ClassType,
            r.ToolWeight,
            r.ToolSerialNumber);

        if (File.Exists(Path))
        {
            using (StreamWriter sw = new StreamWriter(Path, true))
            {
                sw.WriteLine(csvLine);
            }
        }
        else
        {
            using (FileStream fs = new FileStream(Path, FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(csvLine);
            }
        }
    }


    public static void ShowProtocol()
    {
        using ProtocolDataSheet popUp = new();
        if (popUp.ShowDialog() == DialogResult.OK)
        {
            // Do stuff
        }
    }
}