namespace Vehicles.Land
{
    public class Truck : Vehicle
    {
        public Truck(string name, string type, int velocity,
            double weight, int passengers,string color, int wheels, 
            double maxLoad, int kiloWatts, int fuelTank,
            int consumptionPerHour) : 
            base(name, type, velocity, weight, passengers)
        {
            Color = color;
            Wheels = wheels;
            LicencePlate = LicencePlateGenerator.LicencePlateGeneration();
            MaxLoad = maxLoad;
            KiloWatts = kiloWatts;
            FuelTank = fuelTank;
            ConsumptionPerHour = consumptionPerHour;
        }

        public override string Sound()
        {
            return "Country roads, takeme home...";
        }

        #region Stats

        public override string Name { get; set; }
        public override string Type { get; set; }
        public override int Velocity { get; set; }
        public override double Weight { get; set; }
        public override int Passengers { get; set; }
        public string Color { get; set; }
        /// <summary>
        ///     Many Wheels go round and round
        /// </summary>
        public int Wheels { get; set; }

        /// <summary>
        ///     LicencePlate Number, look for LicencePlateGenerator
        /// </summary>
        public string LicencePlate { get; set; }

        /// <summary>
        ///     How much the Behemoth moves
        /// </summary>
        private double MaxLoad { get; }

        /// <summary>
        ///     Good ol' Horsepower
        /// </summary>
        public int KiloWatts { get; set; }

        /// How much fuel is in the tank
        /// </summary>
        private int FuelTank { get; set; }

        /// <summary>
        ///     How much fuel is burned per Hour, Average speed
        /// </summary>
        private int ConsumptionPerHour { get; set; }

        #endregion
    }
}