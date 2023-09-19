/*Дано структуру даних (колекцію) відповідно до варіанта. Додати
зазначену кількість елементів, які описують відповідну предметну
область. Вивести всі елементи на консоль в прямому та зворотному
порядку. Вивести кількість елементів у колекції. Очистити колекцію.*/
using System;
class Program
{
    static void Main()
    {
        string[] cities = { "Львiв", "Київ", "Харкiв", "Херсон", "Ужгород", "Суми", "Броди", "Миколаїв", "Рiвне", "Житомир" };
        Console.WriteLine("Мiста України");
        foreach (string city in cities)
        {
            Console.WriteLine(city);
        }

        Array.Reverse(cities);
        Console.WriteLine("\n Мiста України у зворотньому порядку");
        foreach (string city in cities)
        {
            Console.WriteLine(city);
        }

        Console.WriteLine("\nКiлькiсть елементiв у масивi: " + cities.Length);
        Array.Clear(cities, 0, cities.Length);
    }
    

    

}
