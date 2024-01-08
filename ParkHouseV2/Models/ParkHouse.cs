using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using Vehicles;
using Vehicles.Land;


namespace ParkHouseV2.Models;


[JsonConverter(typeof(ParkHouseConverter))]
public class ParkHouse
	{
	#region stats

	/// <summary>
	///     Status Light if void job successfull
	/// </summary>
	public bool OkLight { get; set; }

	/// <summary>
	///     Error Signal for ErrortextBox
	/// </summary>
	public bool ErrorLight { get; set; }

	/// <summary>
	///     MessageBoard if action is success
	/// </summary>
	public string OkMessage = "";

	/// <summary>
	///     MessageBoard if Error occours
	/// </summary>
	public string ErrorMessage = "";

	/// <summary>
	///     Sum of all Lots
	/// </summary>
	private int TotalLots { get; }

	/// <summary>
	///     Free Lots
	/// </summary>
	public int FreeLots { get; set; }

	/// <summary>
	///     Used Lots
	/// </summary>
	public int UsedLots { get; set; }

	/// <summary>
	///     Invented for the logic of the dropdown list in the ui
	/// </summary>
	public ObservableCollection<int> UsedLotNumbers { get; set; }

	/// <summary>
	///     Workaround for dropboxes
	/// </summary>
	public ObservableCollection<string> LicencePlates { get; set; }

	/// Workaround for Dropboxes
	public ObservableCollection<string> Models { get; set; }

	/// <summary>
	///     List of all parked vehicles
	/// </summary>
	[JsonConverter(typeof(VehicleArrayConverter))]
	public Vehicle[] parkingLots;

	#endregion


	#region Constructors

	/// <summary>
	///     Empty stub for loading from json save
	/// </summary>
	public ParkHouse()
		{
		}

	/// <summary>
	///     New ParkHouse
	/// </summary>
	/// <param name="Lots">Amount of Lots available</param>
	public ParkHouse(int Lots)
		{
		parkingLots = new Vehicle[Lots]; //New Array for the Vehicles to come
		for(var i = 0;i < Lots;i++)   //Assign null for every lot
			parkingLots[i] = null;
		TotalLots = Lots;
		FreeLots = Lots;
		UsedLots = 0;
		OkMessage
			= $"Parkhouse with {Lots.ToString()} Lots successfull created.";
		OkLight = true;
		UsedLotNumbers = new ObservableCollection<int>();
		LicencePlates = new ObservableCollection<string>();
		Models = new ObservableCollection<string>();
		}

	#endregion


	#region Load and Save

	public static ParkHouse LoadParkHouse()
		{
		var path = "..\\parkHouseData.json";
		if(File.Exists(path))
			{
			var json = File.ReadAllText(path);
			return JsonConvert.DeserializeObject<ParkHouse>(json);
			}

		return null;
		}

	/// <summary>
	///     Save the state of the Parkhouse
	///     idea: this is a test if i can save that parkhouse itself
	/// </summary>
	public void SaveAllData() //Vehicle[] parkingLots)
		{
		var path = "..\\parkHouseData.json";
		try
			{
			var json = JsonConvert.SerializeObject(this);
			using(var sw = new StreamWriter(path))
				{
				sw.WriteLine(json);
				}
			}

		catch(Exception ex)
			{
			ErrorMessage = $"Error occurred while saving data: {ex.Message}";
			}
		}

	#endregion


	#region Park in and out

	/// <summary>
	///     Check if there is space
	/// </summary>
	/// <param name="vehicle">the car to park</param>
	/// <returns>string if success, else error</returns>
	public void Parking(Vehicle vehicle)
		{
		if(IsHouseFull())
			{
			ErrorLight = true;
			ErrorMessage = "Error, full house!";
			return;
			}

		var searchFreeLot = RandomLotChooser(); //search random lot
		if(vehicle is Car car)
			{
			parkingLots[searchFreeLot] = car;
			Models.Add(car.Type);
			LicencePlates.Add(car.LicencePlate);
			}
		else if(vehicle is Motorcycle mo)
			{
			parkingLots[searchFreeLot] = mo;
			Models.Add(mo.Type);
			LicencePlates.Add(mo.LicencePlate);
			}
		else if(vehicle is Truck truck)
			{
			parkingLots[searchFreeLot] = truck;
			Models.Add(truck.Type);
			LicencePlates.Add(truck.LicencePlate);
			}

		OkLight = true;
		FreeLots--;
		UsedLots++;
		UsedLotNumbers.Add(searchFreeLot);

		SaveAllData();
		OkMessage
			= $"{vehicle.Name} parked at Lot Number: {searchFreeLot.ToString()}.";
		}

	/// <summary>
	///     remove car from lot and give it free again
	/// </summary>
	public void Leaving(Vehicle vehicle)
		{
		var lot = Array.IndexOf(parkingLots,vehicle);

		// todo: implement here logic for money cost
		parkingLots[lot] = null;
		OkLight = true;
		OkMessage = $"{vehicle.Name} {vehicle.Type} successfully gone.";
		FreeLots++;
		UsedLots--;
		UsedLotNumbers.Remove(lot);
		Models.Remove(vehicle.Type);
		if(vehicle is Car car)
			LicencePlates.Remove(car.LicencePlate);
		else if(vehicle is Motorcycle mo)
			LicencePlates.Remove(mo.LicencePlate);
		else if(vehicle is Truck truck)
			LicencePlates.Remove(truck.LicencePlate);
		SaveAllData();
		}

	#endregion


	#region querrymethods

	/// <summary>
	///     Checks if Lot is free(for whatever reason)
	/// </summary>
	/// <param name="lot"></param>
	/// <returns></returns>
	public bool IsLotFree(int lot)
		{
		return parkingLots[lot] == null;
		}

	/// <summary>
	///     Is Parkhouse full
	/// </summary>
	/// <returns>true if full</returns>
	public bool IsHouseFull()
		{
		if(!parkingLots.Contains(null) && FreeLots == 0)
			return true;

		return false;
		}

	/// <summary>
	///     Are there free Lots
	/// </summary>
	/// <returns>amount of free lots</returns>
	public int GetFreeLots()
		{
		var i = 0;
		foreach(var vec in parkingLots)
			if(vec != null)
				i++;

		return i;
		}

	/// <summary>
	///     Search Vehicle by Plate
	/// </summary>
	/// <returns>LotNumber</returns>
	public int GetVehicleByLicencePlate(string licencePlate)
		{
		//GENIUS: That was quite a piece of Work
		var correctVehicle = parkingLots.FirstOrDefault(vehicle =>
			(vehicle is Car car && car.LicencePlate == licencePlate) ||
			(vehicle is Motorcycle moto &&
			 moto.LicencePlate == licencePlate));
		if(correctVehicle != null)
			return Array.IndexOf(parkingLots,correctVehicle);

		return 0;
		}

	/// <summary>
	///     Search for Vehicles by type
	/// </summary>
	/// <returns>Amount with same type</returns>
	/// <exception cref="NotImplementedException"></exception>
	public int GetVehicleCountByType(string type)
		{
		return parkingLots.Count(vehicle =>
			(vehicle is Car car && car.Type == type) ||
			(vehicle is Motorcycle moto &&
			 moto.Type == type) ||
			(vehicle is Truck truck && truck.Type == type));
		}

	#endregion


	/// <summary>
	///     For more fun and diversity, choose random parkinglot
	/// </summary>
	/// <returns>number of parking lot to use</returns> 
	/// 
	/// 
	private int RandomLotChooser()
		{
		var rng = new Random();
		var place = rng.Next(TotalLots);
		place = parkingLots[place] != null
			? RandomLotChooser()
			: place; //Look if chosen plase is free, else reroll until it is
		return place;
		}


	#region Testcenter

	/// <summary>
	///     TestSetup, stupid, but works
	/// </summary>
	/// <param name="vec">which vehicle to place</param>
	/// <param name="i">on which position in the Array</param>
	public void TestSetParkLot(Vehicle vec,int i)
		{
		parkingLots[i] = vec;
		}

	public string ShowTime()
		{
		var result = "";
		var len = parkingLots.Length;
		for(var i = 0;i < len;i++)
			if(parkingLots[i] != null)
				result += parkingLots[i].Name;
		return result;
		}

	#endregion
	}