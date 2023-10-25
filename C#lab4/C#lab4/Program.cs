using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string fileName = "Pasaghyr.json";
        string jsonData = File.ReadAllText(fileName);
        List<Passenger> passengers = JsonSerializer.Deserialize<List<Passenger>>(jsonData);

        if (passengers != null)
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-15}", "Name", "Destination", "TotalWeightSeats", "totalWeight");
            foreach (var passenger in passengers)
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-15}", passenger.LastName, passenger.Destination, passenger.BaggageCount, passenger.TotalWeight);
            }
            double totalWeight = passengers.Sum(p => p.TotalWeight);
            Console.WriteLine($"Total Weight: {totalWeight}");

            Console.Write("enter the first destination: ");
            string destinationInput1 = Console.ReadLine();

            int totalSeats1 = 0;
            double totalWeight1 = 0;

            foreach (var passenger in passengers)
            {
                if (passenger.Destination.Equals(destinationInput1, StringComparison.OrdinalIgnoreCase))
                {
                    totalSeats1 += passenger.BaggageCount;
                    totalWeight1 += passenger.TotalWeight;
                }
            }

            Console.WriteLine($"The total number of luggage spaces to the destination {destinationInput1}: {totalSeats1}");
            Console.WriteLine($"The total weight of the luggage to the destination{destinationInput1}: {totalWeight1}");

            Console.Write("Enter the destination for the second calculation: ");
            string destinationInput2 = Console.ReadLine();

            double totalWeight2 = 0;

            foreach (var passenger in passengers)
            {
                if (passenger.Destination.Equals(destinationInput2, StringComparison.OrdinalIgnoreCase))
                {
                    totalWeight2 += passenger.TotalWeight;
                }
            }

            Console.WriteLine($"The total weight of the luggage to the destination {destinationInput2}: {totalWeight2}");
        }
        else
        {
            Console.WriteLine("Error.");
        }
    }

    public class Passenger
    {
        public string LastName { get; set; }
        public string Destination { get; set; }
        public int BaggageCount { get; set; }
        public double TotalWeight { get; set; }
    }
}
