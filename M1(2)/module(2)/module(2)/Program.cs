/*Для розв'язання цієї задачі , можна використовувати
 * шаблон проектування Prototype. Цей шаблон дозволяє 
 * створювати нові об'єкти, скориставшись існуючим об'єктом-прототипом.Для моєї задачі
 * я вважаю потрібно створити копії об'єктів, зберігаючи їхні стриктури та стан*/

using System;

// rлас  який буде використовуватися як прототип
class Payment : ICloneable
{
    public int Id { get; set; }
    public string Purpose { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public bool IsPaid { get; set; }
    public Receiver Receiver { get; set; }

    public Payment(int id, string purpose, DateTime date, decimal amount, bool isPaid, Receiver receiver)
    {
        Id = id;
        Purpose = purpose;
        Date = date;
        Amount = amount;
        IsPaid = isPaid;
        Receiver = receiver;
    }

    // реалізація методу Clone 
    public object Clone()
    {
        return MemberwiseClone();
    }
}

// клас для Отримувача
class Receiver
{
    public string Name { get; set; }
    public string EDRPOUCode { get; set; }

    public Receiver(string name, string edrpouCode)
    {
        Name = name;
        EDRPOUCode = edrpouCode;
    }
}

class Program
{
    static void Main()
    {
        

        // створення об'єкта-прототипу
        var originalPayment = new Payment(1, "Payment for goods", DateTime.Now, 100.50m, false, new Receiver("Company ABC", "123456789"));

        // створення копії платежу
        var copiedPayment = (Payment)originalPayment.Clone();
        copiedPayment.Date = new DateTime(2023, 11, 30);

        // вивід  оригінальний та скопійований платіж
        Console.WriteLine("Original Payment:");
        Console.WriteLine(originalPayment.Id + " " + originalPayment.Purpose + " " + originalPayment.Date + " " + originalPayment.Amount + " " + originalPayment.Receiver.Name + " " + originalPayment.Receiver.EDRPOUCode);

        Console.WriteLine("\nCopied Payment:");
        Console.WriteLine(copiedPayment.Id + " " + copiedPayment.Purpose + " " + copiedPayment.Date + " " + copiedPayment.Amount + " " + copiedPayment.Receiver.Name + " " + copiedPayment.Receiver.EDRPOUCode);

        Console.ReadLine();
    }
}



