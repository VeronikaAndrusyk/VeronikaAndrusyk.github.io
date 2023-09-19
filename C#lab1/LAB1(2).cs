
/*Дано стек цілих чисел, який складається з n елементів.
Обчислити суму та кількість чисел, що діляться без остачі на 5.
Якщо таких чисел немає, вивести повідомлення «Чисел, що
діляться без остачі на 5, в стеку немає».*/
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Введiть кiлькiсть елементiв для стеку: ");
        int n = int.Parse(Console.ReadLine());

        // Створюємо стек
        Stack<int> stack = new Stack<int>();

        // Генеруємо випадкові числа та додаємо їх до стеку
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            int randomNumber = random.Next(1, 101); // Випадкові числа в діапазоні від 1 до 100
            stack.Push(randomNumber);
        }

        // Виводимо елементи стеку
        Console.WriteLine("Елементи стеку:");
        foreach (int item in stack)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine(); // Переведемо рядок

        // Обчислюємо суму та кількість чисел, що діляться без остачі на 5
        int sum = 0;
        int count = 0;
        foreach (int item in stack)
        {
            if (item % 5 == 0)
            {
                sum += item;
                count++;
            }
        }

        // Виводимо результат
        if (count > 0)
        {
            Console.WriteLine($"Сума чисел, що дiляться без остачi на 5: {sum}");
            Console.WriteLine($"Кiлькiсть таких чисел: {count}");
        }
        else
        {
            Console.WriteLine("Чисел, що дiляться без остачi на 5, в стеку немає.");
        }
    }
}



