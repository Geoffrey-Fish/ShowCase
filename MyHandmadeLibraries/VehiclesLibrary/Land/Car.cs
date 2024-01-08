namespace Vehicles.Land
{
    public class Car : Vehicle
    {
        public Car(string name, string type,
            int velocity, double weight,
            int passengers, string color,
            int wheels,
            int kiloWatts, int fuelTank, int consumptionPerHour) : base(name, type, velocity,
            weight, passengers)
        {
            Color = color;
            Wheels = wheels;
            LicencePlate = LicencePlateGenerator.LicencePlateGeneration();
            KiloWatts = kiloWatts;
            FuelTank = fuelTank;
            ConsumptionPerHour = consumptionPerHour;
        }

        public override string Sound()
        {
            return "vroomVroom,yoooooeeeeeeeaaaaahahhhhhhhh";
        }

        #region Stats

        public override string Name { get; set; }
        public override string Type { get; set; }
        public override int Velocity { get; set; }
        public override double Weight { get; set; }
        public override int Passengers { get; set; }

        /// <summary>
        ///     Car Color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        ///     Number of Wheels
        /// </summary>
        public int Wheels { get; set; }

        /// <summary>
        ///     LicencePlate Number, look for LicencePlateGenerator
        /// </summary>
        public string LicencePlate { get; set; }

        /// <summary>
        ///     Good ol' Horsepower
        /// </summary>
        public int KiloWatts { get; set; }

        /// <summary>
        ///     How much fuel is in the tank
        /// </summary>
        private int FuelTank { get; set; }

        /// <summary>
        ///     How much fuel is burned per Hour, Average speed
        /// </summary>
        private int ConsumptionPerHour { get; set; }

        #endregion
    }
}