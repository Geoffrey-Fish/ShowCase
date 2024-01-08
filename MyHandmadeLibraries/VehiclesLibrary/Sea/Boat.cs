namespace Vehicles.Sea
{
    public class Boat : Vehicle
    {
        public Boat(string name, string type, 
            int velocity, double weight,
            int passengers,string color, bool motorized) :
            base(name, type, velocity, weight, passengers)
        {
            Color = color;
            Motorized = motorized;
        }

        public override string Sound()
        {
            return "Average Boat sounds...";
        }

        #region Stats

        public override string Name { get; set; }
        public override string Type { get; set; }
        public override int Velocity { get; set; }
        public override double Weight { get; set; }
        public override int Passengers { get; set; }
public string Color { get; set; }
        /// <summary>
        ///     Fuel driven or Elbowgrease?
        /// </summary>
        public bool Motorized { get; set; }

        #endregion
        
    }
}