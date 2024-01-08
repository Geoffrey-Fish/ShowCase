using System;
using System.Linq;

using Newtonsoft.Json;

using Vehicles;


namespace ParkHouseV2.Models;


public class ParkHouseConverter:JsonConverter
	{
	public override void WriteJson(JsonWriter writer,object value,JsonSerializer serializer)
		{
		var parkHouse = (ParkHouse)value;
		var parkingLots = parkHouse.parkingLots.Select(v => v ?? null).ToArray();
		serializer.Serialize(writer,parkingLots);
		}

	public override object ReadJson(JsonReader reader,Type objectType,object existingValue,JsonSerializer serializer)
		{
		var parkHouse = new ParkHouse();

		var parkingLots = serializer.Deserialize<Vehicle[]>(reader);
		parkHouse.parkingLots = parkingLots.Select(v => v ?? null).ToArray();

		return parkHouse;
		}

	public override bool CanConvert(Type objectType)
		{
		return objectType == typeof(ParkHouse);
		}
	}