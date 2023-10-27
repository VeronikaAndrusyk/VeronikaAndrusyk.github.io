/*Клас Messenger містить метод Надіслати повідомлення (отримувач, текст).
Реалізувати непомітно для користувача підрахунок надісланих повідомлень.
Також повідомляти поліцію, якщо повідомлення містить слово «війна»*/

/*для цієї умови найкраще підійде патерн Singleton оскільки ми повинні розробити один екземпляр класу Messenger.
Він дозволяє створити клас, який гарантує, що тільки один екземпляр цього класу буде існувати протягом 
всієї роботи програми. Це означає, що коли будь-яка частина програми намагається отримати доступ до цього 
об'єкта, вона буде отримувати доступ до того самого єдиного екземпляра незалежно від того, де і коли вона 
його запитує. Це допоможе уникнути конфліктів, забезпечуючи, що дані користувачів зберігаються  у програмі.*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Messenger messenger = Messenger.Instance;
        Console.WriteLine($"Підрахунок надісланих повідомлень непомітно для користувача: {messenger.MessageCount}");
        Console.WriteLine("Введiть iм'я отримувача");
        string recipient = Console.ReadLine();
        Console.WriteLine("Введiть повiдомлення:");
        string message = Console.ReadLine();
        messenger.SendMessanger(recipient, message);
        Console.WriteLine($"Пiдрахунок надiсланих повiдомлень непомiтно для користувача: {messenger.MessageCount}");
    }
}

public class Messenger
{
    private static Messenger _instance;
    private int _messageCount;

    private Messenger() { }

    public static Messenger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Messenger();
            }
            return _instance;
        }
    }

    public void SendMessanger(string recipient, string message)
    {
        _messageCount++;
        Console.WriteLine($"Надiслано повiдомлення `{message}` користувачу {recipient}");
        NotifyPolice(message, recipient);
    }

    private void NotifyPolice(string message, string recipient)
    {
        string lowercaseMessage = message.ToLower();
        if (lowercaseMessage.Contains("війна"))
        {
            Console.WriteLine($"Повідомлення користувачу {recipient} містить слово 'війна'");
        }
    }

    public int MessageCount
    {
        get { return _messageCount; }
    }
}

