namespace Vehicles.Sea
{
    public class Ship : Vehicle
    {
        public Ship(string name, string type, 
            int velocity, double weight, int passengers,
            string color, double maxLoad,
            int kiloWatts, int fuelTank,
            int consumptionPerHour) :
            base(name, type, velocity, weight, passengers)
        {
            Color = Color;
            MaxLoad = maxLoad;
            KiloWatts = kiloWatts;
            FuelTank = fuelTank;
            ConsumptionPerHour = consumptionPerHour;
        }

        public override string Sound()
        {
            return "HOOOOOOOOONNNNNNNK";
        }

        #region Stats

        public override string Name { get; set; }
        public override string Type { get; set; }
        public override int Velocity { get; set; }
        public override double Weight { get; set; }
        public override int Passengers { get; set;}
        public string Color { get; set; }

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