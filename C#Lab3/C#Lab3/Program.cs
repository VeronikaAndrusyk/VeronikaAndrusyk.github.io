using System;
using System.Xml;

class Program
{
    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        try
        {
            // завантаження з файлу
            xmlDoc.Load("Pasaghyr.xml");

            XmlElement root = xmlDoc.DocumentElement;

            if (root != null)
            {
                Console.WriteLine("Information about passengers:");
                XmlNodeList passengers = root.GetElementsByTagName("Passenger");

                foreach (XmlNode passenger in passengers)
                {
                    string lastName = passenger.Attributes["LastName"].Value;
                    string destination = passenger.Attributes["Destination"].Value;
                    int baggageCount = int.Parse(passenger.Attributes["BaggageCount"].Value);
                    double totalWeight = double.Parse(passenger.Attributes["TotalWeight"].Value);

                    Console.WriteLine($"Surname: {lastName}, Destination: {destination}, Number of luggage seats: {baggageCount}, Total weight of luggage: {totalWeight} kg");
                }

                Console.Write("Enter the first destination to calculate total luggage information: ");
                string inputDestination = Console.ReadLine();

                int totalLuggageSeats = 0;
                double totalLuggageWeight = 0.0;

                foreach (XmlNode passenger in passengers)
                {
                    string destination = passenger.Attributes["Destination"].Value;

                    if (destination.Equals(inputDestination, StringComparison.OrdinalIgnoreCase))
                    {
                        int baggageCount = int.Parse(passenger.Attributes["BaggageCount"].Value);
                        double luggageWeight = double.Parse(passenger.Attributes["TotalWeight"].Value);

                        totalLuggageSeats += baggageCount;
                        totalLuggageWeight += luggageWeight;
                    }
                }

                Console.WriteLine($"Total number of luggage seats to {inputDestination}: {totalLuggageSeats}");
                Console.WriteLine($"Total luggage weight to {inputDestination}: {totalLuggageWeight} kg");

                Console.Write("Enter the second destination to calculate total luggage information: ");
                string inputDestination1 = Console.ReadLine();

                double totalLuggageWeight1 = 0.0;

                foreach (XmlNode passenger in passengers)
                {
                    string destination1 = passenger.Attributes["Destination"].Value;

                    if (destination1.Equals(inputDestination1, StringComparison.OrdinalIgnoreCase))
                    {
                        double luggageWeight = double.Parse(passenger.Attributes["TotalWeight"].Value);
                        totalLuggageWeight1 += luggageWeight;
                    }
                }

                Console.WriteLine($"Total luggage weight to {inputDestination1}: {totalLuggageWeight1} kg");
            }
            else
            {
                Console.WriteLine("XML file does not contain a root element.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }
}
