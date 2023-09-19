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

        Stack<int> stack = new Stack<int>();

        Console.WriteLine(" Введiть елементи для стеку:");
        for (int i = 0; i < n; i++)
        {
            int element = int.Parse(Console.ReadLine());
            stack.Push(element);
        }

        /*Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            int randomNumber = random.Next(1, 101); 
            stack.Push(randomNumber);
        }*/

        Console.WriteLine("Елементи стеку:");
        foreach (int item in stack)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

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
