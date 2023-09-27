/*Дано стек цілих чисел, який складається з n елементів.
Обчислити суму та кількість чисел, що діляться без остачі на 5.
Якщо таких чисел немає, вивести повідомлення «Чисел, що
діляться без остачі на 5, в стеку немає».*/
//зробити через pop!
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Введiть кiлькiсть елементiв для стеку: ");
        int n = int.Parse(Console.ReadLine());

        Stack<int> stack = new Stack<int>();

        Console.WriteLine(" Введiть елементи для стеку:");
        for (int i = 0; i < n; i++)
        {
            int element = int.Parse(Console.ReadLine());
            stack.Push(element);
        }

        Console.WriteLine("Елементи стеку:");

        // Calculate the sum and count of numbers divisible by 5
        int sum = 0;
        int count = 0;

        while (stack.Count > 0)
        {
            int item = stack.Pop();
            Console.Write(item + " ");

            if (item % 5 == 0)
            {
                sum += item;
                count++;
            }
        }
        Console.WriteLine();

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
