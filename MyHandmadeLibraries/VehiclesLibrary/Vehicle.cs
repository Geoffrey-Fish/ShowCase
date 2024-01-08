namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(string name, string type, int velocity, double weight, int passengers)
        {
            Name = name;
            Type = type;
            Velocity = velocity;
            Weight = weight;
            Passengers = passengers;
        }


        /// <summary>
        ///     Name of the Vehicle
        /// </summary>
        public abstract string Name { get; set; }

        /// <summary>
        ///     Type of the Vehicle, i.e. Car, Bike, Boat
        /// </summary>
        public abstract string Type { get; set; }

        /// <summary>
        ///     Max velocity of the Vehicle
        /// </summary>
        public abstract int Velocity { get; set; }

        /// <summary>
        ///     Weight of the Vehicle
        /// </summary>
        public abstract double Weight { get; set; }

        /// <summary>
        ///     Amount of Passengers that fit in
        /// </summary>
        public abstract int Passengers { get; set; }

        /// <summary>
        ///     What sound the Vehicle makes
        /// </summary>
        /// <returns>A string representing a Sound</returns>
        public abstract string Sound();

        public virtual string BaseInfos()
        {
            var info =
                $"Name: {Name},Type: {Type},Velocity: {Velocity.ToString()},Weight:" +
                $" {Weight.ToString("##.##")},Passengers: {Passengers.ToString()}";
            return info;
        }
    }
}