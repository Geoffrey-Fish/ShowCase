using System;

using Vehicles;
using Vehicles.Land;


namespace ParkHouseV2.Models;


public class CustomVehicleCreator
	{
	//todo: custom pseudo creator, change name,type and licenceplate before returning it to mainwindow
	//todo: mainwindow, how do you get the infos there???
	private static Car _car { get; set; }
	private static Motorcycle _bike { get; set; }
	private static Truck _truck { get; set; }

	public static void CustomVehicleCreation(string vehicle,string model,string licence)
		{
		if(vehicle == "car")
			{
			_car = VehicleGenerator.CarGenerator();
			_car.Type = model;
			_car.LicencePlate = licence;
			}
		else if(vehicle == "bike")
			{
			_bike = VehicleGenerator.MotorcycleGenerator();
			_bike.Type = model;
			_bike.LicencePlate = licence;
			}
		else if(vehicle == "truck")
			{
			_truck = VehicleGenerator.TruckGenerator();
			_truck.Type = model;
			_truck.LicencePlate = licence;
			}
		else
			{
			throw new NotImplementedException();
			}
		}
	}