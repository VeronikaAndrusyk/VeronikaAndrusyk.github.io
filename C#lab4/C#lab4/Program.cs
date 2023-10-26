/* 
 List<Passenger> passengers = new List<Passenger>
        {
            new Passenger { LastName = "Johnson", Destination = "New York", BaggageCount = 2, TotalWeight = 20.5 },
            new Passenger { LastName = "Smith", Destination = "Los Angeles", BaggageCount = 1, TotalWeight = 15.0 },
            new Passenger { LastName = "Williams", Destination = "Chicago", BaggageCount = 3, TotalWeight = 45.0 },
            new Passenger { LastName = "Jones", Destination = "New York", BaggageCount = 2, TotalWeight = 25.0 },
            new Passenger { LastName = "Brown", Destination = "Miami", BaggageCount = 1, TotalWeight = 18.0 },
            new Passenger { LastName = "Davis", Destination = "Los Angeles", BaggageCount = 2, TotalWeight = 22.5 },
            new Passenger { LastName = "Miller", Destination = "New York", BaggageCount = 1, TotalWeight = 14.0 },
            new Passenger { LastName = "Wilson", Destination = "Los Angeles", BaggageCount = 3, TotalWeight = 40.0 },
            new Passenger { LastName = "Moore", Destination = "New York", BaggageCount = 2, TotalWeight = 23.5 },
            new Passenger { LastName = "Taylor", Destination = "Los Angeles", BaggageCount = 1, TotalWeight = 16.0 }
        };

        string fileName = "Pasaghyr.json"; імя файлу 
        string jsonString = JsonSerializer.Serialize(passengers, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine("JSON file created successfully.");

Опція WriteIndented = true дозволяє додавати відступи та переноси рядків для полегшення читабельності створеного JSON-рядка.
 Цей рядок коду записує згенерований JSON-рядок у файл з ім'ям, яке було визначено у змінній fileName
 */

using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using C_lab4;

//використовую синхронний код для збереження даних у файл
class Program
{
    static void Main()
    {
       
        string fileName = "C:\\Users\\Asus\\OneDrive\\Робочий стіл\\C#\\C#lab4\\C#lab4\\Pasaghyr.json";
        string jsonData = File.ReadAllText(fileName);//зчитування даних з створеного вже файлу 
        List<Passenger> passengers = JsonSerializer.Deserialize<List<Passenger>>(jsonData);//це список пасажирів, який буде заповнений після десеріалізації JSON-рядка у список об'єктів
        //JsonSerializer.Deserialize<List<Passenger>>(jsonData) - це метод,
        //який перетворює JSON-рядок, що міститься у змінній jsonData, в об'єкт списку Passenger
        if (passengers != null)
        {   //вирівнювання ліворуч і 15 символів
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

            //цей цикл виконується у файлі. Він працює зі списком об'єктів passengers,
            //який був створений після того, як програма зчитала та десеріалізувала дані з файлу "Pasaghyr.json"
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

}

