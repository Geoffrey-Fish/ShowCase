
using Vehicles;

namespace MyNamespace
	{

	class Program
		{
		public static void Main(string[] args)
			{
			List<string> test = new List<string>(VehicleGenerator.DataListExporter("CarNames"));
			//	foreach(string s in test)
			//		{
			//		Console.WriteLine(s);
			//		}
			Console.WriteLine(test.Count);
			}
		}
	}
