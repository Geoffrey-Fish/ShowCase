using System;
using System.Collections.Generic;

using Vehicles.Air;
using Vehicles.Land;
using Vehicles.Sea;
using Vehicles.Space;

namespace Vehicles
{
    public class VehicleGenerator
    {
        #region DataLists
        private static List<string> Colors = new List<string>()
        {
            "Green",
            "Black",
            "Red",
            "Yellow",
            "Gray",
            "White",
            "Brown",
            "Blue",
            "Khaki",
            "Orange",
            "Violet"
        };

        private static List<string> CarNames = new List<string>()
    {
        "Toyota",
        "Honda",
        "Ford",
        "Chevrolet",
        "BMW",
        "Mercedes-Benz",
        "Audi",
        "Volkswagen",
        "Nissan",
        "Hyundai",
        "Kia",
        "Subaru",
        "Mazda",
        "Lexus",
        "Volvo"
        // Add more fitting names for Cars
    };

        private static List<string> CarTypes = new List<string>()
    {
        "Sedan",
        "SUV",
        "Hatchback",
        "Convertible",
        "Coupe",
        "Wagon",
        "Sports Car"
        // Add more fitting types for Cars
    };

        private static List<string> MotorcycleNames = new List<string>()
    {
        "Harley-Davidson",
        "Honda",
        "Yamaha",
        "Kawasaki",
        "Suzuki",
        "Ducati",
        "BMW",
        "Triumph"
        // Add more fitting names for Motorcycles
    };

        private static List<string> MotorcycleTypes = new List<string>()
    {
        "Cruiser",
        "Sport Bike",
        "Touring Bike",
        "Dual Sport",
        "Scooter",
        "Off-Road"
        // Add more fitting types for Motorcycles
    };

        private static List<string> BycicleNames = new List<string>()
    {
        "Trek",
        "Giant",
        "Specialized",
        "Cannondale",
        "Scott",
        "Bianchi",
        "Santa Cruz",
        "Yeti",
        "Marin",
        "Kona"
        // Add more fitting names for Bycicles
    };

        private static List<string> BycicleTypes = new List<string>()
    {
        "Mountain Bike",
        "Road Bike",
        "Hybrid Bike",
        "Cruiser Bike",
        "Electric Bike"
        // Add more fitting types for Bycicles
    };

        private static List<string> TruckNames = new List<string>()
    {
        "Ford",
        "Chevrolet",
        "Dodge",
        "Toyota",
        "GMC",
        "Ram",
        "Nissan",
        "Jeep"
        // Add more fitting names for Trucks
    };

        private static List<string> TruckTypes = new List<string>()
    {
        "Pickup Truck",
        "SUV",
        "Off-Road Truck",
        "Tow Truck",
        "Dump Truck"
        // Add more fitting types for Trucks
    };

        private static List<string> HelicopterNames = new List<string>()
    {
        "Bell",
        "Airbus",
        "Sikorsky",
        "Robinson",
        "AgustaWestland",
        "Boeing",
        "Eurocopter"
        // Add more fitting names for Helicopters
    };

        private static List<string> HelicopterTypes = new List<string>()
    {
        "Light Helicopter",
        "Medium Helicopter",
        "Heavy Helicopter"
        // Add more fitting types for Helicopters
    };

        private static List<string> PlaneNames = new List<string>()
    {
        "Boeing",
        "Airbus",
        "Cessna",
        "Embraer",
        "Bombardier",
        "Gulfstream",
        "Dassault"
        // Add more fitting names for Planes
    };

        private static List<string> PlaneTypes = new List<string>()
    {
        "Commercial Airliner",
        "Business Jet",
        "Private Plane",
        "Cargo Plane"
        // Add more fitting types for Planes
    };

        private static List<string> BoatNames = new List<string>()
    {
        "Bayliner",
        "Sea Ray",
        "Boston Whaler",
        "MasterCraft",
        "Regal",
        "Grady-White",
        "Cobalt",
        "Malibu",
        "Chaparral",
        "Tracker"
        // Add more fitting names for Boats
    };

        private static List<string> BoatTypes = new List<string>()
    {
        "Yacht",
        "Sailboat",
        "Speedboat",
        "Pontoon Boat",
        "Fishing Boat",
        "Jet Ski"
        // Add more fitting types for Boats
    };

        private static List<string> ShipNames = new List<string>()
    {
        "Royal Caribbean",
        "Carnival",
        "Norwegian",
        "MSC",
        "Princess",
        "Disney",
        "Holland America",
        "Celebrity"
        // Add more fitting names for Ships
    };

        private static List<string> ShipTypes = new List<string>()
    {
        "Cruise Ship",
        "Ferry",
        "Cargo Ship",
        "Sailing Ship"
        // Add more fitting types for Ships
    };

        private static List<string> RocketNames = new List<string>()
    {
        "Falcon 9",
        "Delta IV",
        "Atlas V",
        "Soyuz",
        "SpaceX Starship",
        "Long March",
        "H-IIA",
        "Vega"
        // Add more fitting names for Rockets
    };

        private static List<string> RocketTypes = new List<string>()
    {
        "Orbital Rocket",
        "Space Launch Vehicle",
        "Interplanetary Rocket"
        // Add more fitting types for Rockets
    };

        private static List<string> SatelliteNames = new List<string>()
    {
        "Hubble",
        "ISS",
        "GPS",
        "Communications Satellite",
        "Weather Satellite",
        "Spy Satellite"
        // Add more fitting names for Satellites
    };

        private static List<string> SatelliteTypes = new List<string>()
    {
        "Earth Observation Satellite",
        "Navigation Satellite",
        "Communication Satellite",
        "Weather Satellite",
        "Spy Satellite"
        // Add more fitting types for Satellites
    };
        #endregion

        /// <summary>
        /// Get the Lists out of this Library for further use
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<string> DataListExporter(string type)
        {
            switch (type)
            {
                case "Colors":
                    return Colors;
                case " CarNames":
                    return CarNames;
                case "CarTypes":
                    return CarTypes;
                case "MotorcycleNames":
                    return MotorcycleNames;
                case "MotorcycleTypes":
                    return MotorcycleTypes;
                case "BycicleNames":
                    return BycicleNames;
                case "BycicleTypes":
                    return BycicleTypes;
                case "TruckNames":
                    return TruckNames;
                case "TruckTypes":
                    return TruckTypes;
                case "HelicopterNames":
                    return HelicopterNames;
                case "HelicopterTypes":
                    return HelicopterTypes;
                case "PlaneNames":
                    return PlaneNames;
                case "PlaneTypes":
                    return PlaneTypes;
                case "BoatNames":
                    return BoatNames;
                case "BoatTypes":
                    return BoatTypes;
                case "ShipNames":
                    return ShipNames;
                case "ShipTypes":
                    return ShipTypes;
                case "RocketNames":
                    return RocketNames;
                case "RocketTypes":
                    return RocketTypes;
                case "SatelliteNames":
                    return SatelliteNames;
                case "SatelliteTypes":
                    return SatelliteTypes;
                default:
                    return null;
            }
        }
        
        
        
        
        
        //Random Generator, LEET Edition^^
        private static Random rng = new Random(1337);

        //Base stats from Vehicle
        /// <summary>
        /// Base stats for all Vehicles.
        /// Ranges received from Generators.
        /// </summary>
        /// <param name="velomod"> min and max value</param>
        /// <param name="weightmod">min and max value</param>
        /// <param name="passmod">min and max value</param>
        /// <returns>dictionary with random values</returns>
        private static Dictionary<string, decimal> BasicStats(int[] velomod, int[] weightmod, int[] passmod)
        {
            Dictionary<string, decimal> stats = new Dictionary<string, decimal>();
            //Velocity
            decimal velocity = rng.Next(velomod[0], velomod[1]);
            stats.Add("Velocity", velocity);
            decimal weight = rng.Next(weightmod[0], weightmod[1]);
            stats.Add("Weight", weight);
            decimal passengers = rng.Next(passmod[0], passmod[1]);
            stats.Add("Passengers", passengers);
            return stats;
        }

        //Land
        public static Car CarGenerator()
        {
            //Randomize it!
            Dictionary<string, decimal> stats =
                BasicStats(new int[] { 60, 240 },
                    new int[] { 500, 1500 },
                    new int[] { 4, 7 });
            string name = CarNames[rng.Next(0, CarNames.Count)];
            string type = CarTypes[rng.Next(0, CarTypes.Count)];
            int velocity = Convert.ToInt32(stats["Velocity"]);
            double weight = Convert.ToDouble(stats["Weight"]);
            int passengers = Convert.ToInt32(stats["Passengers"]);
            string color = Colors[rng.Next(0, Colors.Count)];
            int wheels = 4;
            int kw = rng.Next(40, 250);
            int fuel = rng.Next(30, 71);
            int consumption = rng.Next(4, 14);

            return new Car(name, type, velocity, weight, passengers, color, wheels, kw, fuel,
                consumption);
        }

        public static Motorcycle MotorcycleGenerator()
        {
            //Randomize it!
            Dictionary<string, decimal> stats =
                BasicStats(new int[] { 80, 340 },
                new int[] { 350, 1000 },
                new int[] { 1, 3 });
            string name = MotorcycleNames[rng.Next(0, MotorcycleNames.Count)];
            string type = MotorcycleTypes[rng.Next(0, MotorcycleTypes.Count)];
            int velocity = Convert.ToInt32(stats["Velocity"]);
            double weight = Convert.ToDouble(stats["Weight"]);
            int passengers = Convert.ToInt32(stats["Passengers"]);
            string color = Colors[rng.Next(0, Colors.Count)];
            int wheels = 4;
            int kw = rng.Next(40, 250);
            int fuel = rng.Next(30, 71);
            int consumption = rng.Next(4, 14);

            return new Motorcycle(name, type, velocity, weight, passengers, color, wheels, kw, fuel, consumption);
        }

        public static Truck TruckGenerator()
        {
            //Randomize it!
            Dictionary<string, decimal> stats =
                BasicStats(new int[] { 50, 120 },
                    new int[] { 1200, 55000 },
                    new int[] { 1, 5 });
            string name = TruckNames[rng.Next(0, TruckNames.Count)];
            string type = TruckTypes[rng.Next(0, TruckTypes.Count)];
            int velocity = Convert.ToInt32(stats["Velocity"]);
            double weight = Convert.ToDouble(stats["Weight"]);
            int passengers = Convert.ToInt32(stats["Passengers"]);
            string color = Colors[rng.Next(0, Colors.Count)];
            int wheels = rng.Next(4, 21);
            double maxLoad = rng.Next(1500, 35000);
            int kw = rng.Next(80, 750);
            int fuel = rng.Next(150, 2400);
            int consumption = rng.Next(14, 66);

            return new Truck(name, type, velocity, weight, passengers, color, wheels, maxLoad, kw, fuel, consumption);
        }

        public static Bycicle BycicleGenerator()
        {
            //Randomize it!
            bool yesNo = false;
            int isPedelec = rng.Next(0, 2); //Flip a coin
            yesNo = isPedelec == 1 ? true : false; //Is it Powered? 1 is true
            int[] velomod;// For the Basicstats
            if (yesNo)
            {
                velomod = new int[] { 15, 77 };
            }
            else
            {
                velomod = new int[] { 1, 45 };
            }
            Dictionary<string, decimal> stats =
                BasicStats(velomod,
                    new int[] { 5, 30 },
                    new int[] { 1, 3 });
            string name = BycicleNames[rng.Next(0, BycicleNames.Count)];
            string type = BycicleTypes[rng.Next(0, BycicleTypes.Count)];
            int velocity = Convert.ToInt32(stats["Velocity"]);
            double weight = Convert.ToDouble(stats["Weight"]);
            int passengers = Convert.ToInt32(stats["Passengers"]);
            string color = Colors[rng.Next(0, Colors.Count)];
            bool pedelec = yesNo; //see top of Method

            return new Bycicle(name, type, velocity, weight, passengers, color, pedelec);
        }

        //Air
        public static Helicopter HelicopterGenerator()
        {
            //Randomize it!
            Dictionary<string, decimal> stats =
                BasicStats(new int[] { 150, 340 },
                    new int[] { 1500, 9000 },
                    new int[] { 1, 13 });
            string name = HelicopterNames[rng.Next(0, HelicopterNames.Count)];
            string type = HelicopterTypes[rng.Next(0, HelicopterTypes.Count)];
            int velocity = Convert.ToInt32(stats["Velocity"]);
            double weight = Convert.ToDouble(stats["Weight"]);
            int passengers = Convert.ToInt32(stats["Passengers"]);
            int maxAltitude = rng.Next(600, 7500);
            string color = Colors[rng.Next(0, Colors.Count)];
            int kw = rng.Next(600, 3900);
            int fuel = rng.Next(600, 3200);
            int consumption = rng.Next(20, 80);

            return new Helicopter(name, type, velocity, weight, passengers, color, maxAltitude, kw, fuel, consumption);
        }

        public static Plane PlaneGenerator()
        {
            //Randomize it!
            Dictionary<string, decimal> stats =
                BasicStats(new int[] { 340, 1100 },
                    new int[] { 3550, 80000 },
                    new int[] { 12, 550 });
            string name = PlaneNames[rng.Next(0, PlaneNames.Count)];
            string type = PlaneTypes[rng.Next(0, PlaneTypes.Count)];
            int velocity = Convert.ToInt32(stats["Velocity"]);
            double weight = Convert.ToDouble(stats["Weight"]);
            int passengers = Convert.ToInt32(stats["Passengers"]);
            string color = Colors[rng.Next(0, Colors.Count)];
            int maxAltitude = rng.Next(1000, 10000);
            int kw = rng.Next(800, 30000);
            int fuel = rng.Next(9000, 20000);
            int consumption = rng.Next(280, 980);

            return new Plane(name, type, velocity, weight, passengers, maxAltitude, color, kw, fuel, consumption);
        }

        //Sea
        public static Boat BoatGenerator()
        {
            //Randomize it!
            bool yesNo = false;
            int isMotor = rng.Next(0, 2); //Flip a coin
            yesNo = isMotor == 1 ? true : false; //Is it Powered? 1 is true
            int[] velomod;// For the Basicstats
            if (yesNo)
            {
                velomod = new int[] { 10, 50 };
            }
            else
            {
                velomod = new int[] { 1, 10 };
            }
            Dictionary<string, decimal> stats =

                BasicStats(velomod,
                    new int[] { 50, 800 },
                    new int[] { 1, 13 });
            string name = BoatNames[rng.Next(0, BoatNames.Count)];
            string type = BoatTypes[rng.Next(0, BoatTypes.Count)];
            int velocity = Convert.ToInt32(stats["Velocity"]);
            double weight = Convert.ToDouble(stats["Weight"]);
            int passengers = Convert.ToInt32(stats["Passengers"]);
            string color = Colors[rng.Next(0, Colors.Count)];
            bool motorized = yesNo;

            return new Boat(name, type, velocity, weight, passengers, color, motorized);
        }

        public static Ship ShipGenerator()
        {
            //Randomize it!
            Dictionary<string, decimal> stats =
                BasicStats(new int[] { 80, 340 },
                    new int[] { 350, 1000 },
                    new int[] { 1, 3 });
            string name = ShipNames[rng.Next(0, ShipNames.Count)];
            string type = ShipTypes[rng.Next(0, ShipTypes.Count)];
            int velocity = Convert.ToInt32(stats["Velocity"]);
            double weight = Convert.ToDouble(stats["Weight"]);
            int passengers = Convert.ToInt32(stats["Passengers"]);
            string color = Colors[rng.Next(0, Colors.Count)];
            int maxLoad = rng.Next(4000, 90000);
            int kw = rng.Next(900, 30000);
            int fuel = rng.Next(3000, 90000);
            int consumption = rng.Next(300, 1500);

            return new Ship(name, type, velocity, weight, passengers, color, maxLoad, kw, fuel, consumption);
        }

        //Space
        public static Rocket RocketGenerator()
        {
            //Randomize it!
            Dictionary<string, decimal> stats =
                BasicStats(new int[] { 1500, 3500 },
                    new int[] { 8000, 100000 },
                    new int[] { 1, 13 });
            string name = RocketNames[rng.Next(0, RocketNames.Count)];
            string type = RocketTypes[rng.Next(0, RocketTypes.Count)];
            int velocity = Convert.ToInt32(stats["Velocity"]);
            double weight = Convert.ToDouble(stats["Weight"]);
            int passengers = Convert.ToInt32(stats["Passengers"]);
            string color = Colors[rng.Next(0, Colors.Count)];
            int maxAltitude = rng.Next(10000, 50000);
            int kw = rng.Next(4000, 50000);
            int fuel = rng.Next(5000, 20000);
            int consumption = rng.Next(500, 4000);

            return new Rocket(name, type, velocity, weight, passengers, color, maxAltitude, kw, fuel, consumption);
        }

        public static Satellite SatelliteGenerator()
        {
            //Randomize it!
            Dictionary<string, decimal> stats =
                BasicStats(new int[] { 800, 3400 },
                    new int[] { 3500, 10000 },
                    new int[] { 1, 3 });
            string name = SatelliteNames[rng.Next(0, SatelliteNames.Count)];
            string type = SatelliteTypes[rng.Next(0, SatelliteTypes.Count)];
            int velocity = Convert.ToInt32(stats["Velocity"]);
            double weight = Convert.ToDouble(stats["Weight"]);
            int passengers = Convert.ToInt32(stats["Passengers"]);
            string color = Colors[rng.Next(0, Colors.Count)];
            int maxAltitude = rng.Next(8000, 20000);
            int kw = rng.Next(100, 1800);
            int fuel = rng.Next(600, 1500);
            int consumption = rng.Next(40, 140);

            return new Satellite(name, type, velocity, weight, passengers, color, maxAltitude, kw, fuel, consumption);
        }

    }
}