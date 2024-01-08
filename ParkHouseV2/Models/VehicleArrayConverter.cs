using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Vehicles;
using Vehicles.Land;


namespace ParkHouseV2.Models;


/// <summary>
/// This stuff right here is thanks to mr. Roboto.
/// The reason behind this code is that a parkhouse holds an array of vehicles. but these are cars, bikes etc.
/// During deserialization my code broke because it wanted all to be vehicle.
/// Here this piece of code changes the behaviour of NewtonsoftJson so every object gets serialized and deserialized specific to what they need.
/// </summary>
public class VehicleArrayConverter:JsonConverter
	{
	public override bool CanConvert(Type objectType)
		{
		return objectType == typeof(Vehicle[]);
		}

	public override object ReadJson(JsonReader reader,Type objectType,object existingValue,JsonSerializer serializer)
		{
		var array = JArray.Load(reader);
		var vehicles = new Vehicle[array.Count];

		for(var i = 0;i < array.Count;i++)
			{
			var obj = array[i];
			var typeName = (string)obj["TypeName"];

			// Deserialize the object based on its specific type
			Vehicle vehicle;
			switch(typeName)
				{
				case "Car":
					vehicle = obj.ToObject<Car>(serializer);
					break;
				case "Motorcycle":
					vehicle = obj.ToObject<Motorcycle>(serializer);
					break;
				case "Truck":
					vehicle = obj.ToObject<Truck>(serializer);
					break;
				default:
					throw new JsonSerializationException("Unknown vehicle type: " + typeName);
				}

			vehicles[i] = vehicle;
			}

		return vehicles;
		}

	public override void WriteJson(JsonWriter writer,object value,JsonSerializer serializer)
		{
		var vehicles = (Vehicle[])value;
		writer.WriteStartArray();

		foreach(var vehicle in vehicles)
			{
			// Add a "TypeName" property to identify the specific type during deserialization
			writer.WriteStartObject();
			writer.WritePropertyName("TypeName");
			writer.WriteValue(vehicle.GetType().Name);
			serializer.Serialize(writer,vehicle);
			writer.WriteEndObject();
			}

		writer.WriteEndArray();
		}
	}