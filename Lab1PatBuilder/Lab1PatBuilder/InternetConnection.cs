using System;
using System.Collections.Generic;


public class InternetConnection
{
    public string Protocol { get; private set; }
    public string Encryption { get; private set; }
    public string IpAddressVersion { get; private set; }
    public Dictionary<string, string> OtherProperties { get; private set; }

    private InternetConnection() { }// приватний конструктор

    // внутрішній клас для побудови з'єднання з Інтернетом
    public class InternetConnectionBuilder
    {
        private InternetConnection connection;

        public InternetConnectionBuilder()
        {
            connection = new InternetConnection();
        }

        public InternetConnectionBuilder WithProtocol(string protocol)//цей метод приймає рядок protocol і встановлює властивість Protocol
                                                                      //об'єкта InternetConnection на передане значення protocol
        {
            connection.Protocol = protocol;
            return this;
        }

        public InternetConnectionBuilder WithEncryption(string encryption)
        {
            connection.Encryption = encryption;
            return this;
        }

        public InternetConnectionBuilder WithIpAddressVersion(string ipAddressVersion)
        {
            connection.IpAddressVersion = ipAddressVersion;
            return this;
        }

        public InternetConnectionBuilder WithCustomProperty(string key, string value)//цей метод приймає два рядки: key і value. Він використовує
                                                                                     //OtherProperties, як словник (Dictionary), щоб зберігати додаткові
                                                                                     //користувацькі властивості об'єкта InternetConnection
        {
            if (connection.OtherProperties == null)
            {
                connection.OtherProperties = new Dictionary<string, string>();
            }

            connection.OtherProperties[key] = value;
            return this;
        }

        public InternetConnection Build()
        {
            return connection;
        }
    }

    public void Connect()
    {
        Console.WriteLine($"Connecting using {Protocol} protocol...");

        if (!string.IsNullOrEmpty(IpAddressVersion))
        {
            Console.WriteLine($"Using {IpAddressVersion} IP address version...");
        }
        else
        {
            Console.WriteLine("No IP address version specified. Using default (IPv4)...");
        }

        if (!string.IsNullOrEmpty(Encryption))
        {
            Console.WriteLine($"Using {Encryption} encryption...");
        }
        else
        {
            Console.WriteLine("No encryption specified.");
        }

        if (OtherProperties != null)
        {
            foreach (var property in OtherProperties)
            {
                Console.WriteLine($"Custom property: {property.Key} = {property.Value}");
            }
        }
    }
}
