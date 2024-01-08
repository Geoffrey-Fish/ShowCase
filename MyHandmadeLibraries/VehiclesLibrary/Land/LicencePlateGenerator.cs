using System;

namespace Vehicles.Land
{
    public class LicencePlateGenerator
    {
        public static string LicencePlateGeneration()
        {
            var rng = new Random();

            var numbers = rng.Next(1, 9999); //The numbers on the Plate
            var cityLetter = rng.Next(0, 26); //German City Letter, simple version
            var firstLetter = rng.Next(0, 26); //German random letters
            var secondLetter = rng.Next(0, 26); //yepp, still random
            var city = (char)('A' + cityLetter);
            var first = (char)('A' + firstLetter);
            var second = (char)('A' + secondLetter);
            return
                $"{city.ToString()} - {first.ToString()}{second.ToString()} {numbers.ToString()}"; //classic german design
        }
    }
}