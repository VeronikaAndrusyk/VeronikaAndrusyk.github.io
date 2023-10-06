using System;

class Program
{
    static void Main(string[] args)
    {
        // Використання білдера для створення з'єднань з Інтернетом

        InternetConnection connection1 = new InternetConnection.InternetConnectionBuilder()
            .WithProtocol("HTTP")
            .WithCustomProperty("CustomProperty1", "Value1")
            .WithCustomProperty("CustomProperty2", "Value2")
            .Build();

        InternetConnection connection2 = new InternetConnection.InternetConnectionBuilder()
            .WithProtocol("HTTPS")
            .WithEncryption("TLS")
            .WithIpAddressVersion("IPv6")
            .WithCustomProperty("CustomProperty3", "Value3")
            .WithCustomProperty("CustomProperty4", "Value4")
            .Build();

        Console.WriteLine("Connection 1:");
        connection1.Connect();

        Console.WriteLine("\nConnection 2:");
        connection2.Connect();
    }
}

