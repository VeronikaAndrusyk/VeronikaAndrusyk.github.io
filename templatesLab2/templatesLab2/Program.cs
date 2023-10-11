using System;
using System.Collections.Generic;

// визначаю стратегію
interface IDiscountStrategy
{
    decimal CalculateDiscount(decimal originalPrice);
}

// конкретні стратегії знижок
class NighttimePurchaseDiscount : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal originalPrice)
    {
        int currentHour = DateTime.Now.Hour;

        if (currentHour >= 18 || currentHour < 5)
        {
            return originalPrice * 0.95m;
        }
        else
        {
            return originalPrice;
        }
    }
}

class CategoryDiscount : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal originalPrice)
    {
        return originalPrice * 0.95m;
    }
}

class CardPaymentDiscount : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal originalPrice)
    {
        return originalPrice * 0.98m;
    }
}

class PersonalDiscount : IDiscountStrategy
{
    private decimal discountPercentage;

    public PersonalDiscount(decimal discountPercentage)
    {
        this.discountPercentage = discountPercentage;
    }

    public decimal CalculateDiscount(decimal originalPrice)
    {
        return originalPrice * (1 - discountPercentage / 100);
    }
}

class Product
{
    //public string Name { get; set; }
    public string Category { get; set; }
    //public string Manufacturer { get; set; }
    public decimal Price { get; set; }
    //public string Description { get; set; }
    public DateTime PurchaseTime { get; set; }
    public string PaymentMethod { get; set; }
    //public string Buyer { get; set; }
}

class DiscountCalculator
{
    private List<IDiscountStrategy> discountStrategies;

    public DiscountCalculator()
    {
        discountStrategies = new List<IDiscountStrategy>();
    }

    public void AddDiscountStrategy(IDiscountStrategy strategy)
    {
        discountStrategies.Add(strategy);
    }

    public decimal CalculateFinalPrice(Product product)
    {
        decimal finalPrice = product.Price;

        foreach (var strategy in discountStrategies)
        {
            finalPrice = strategy.CalculateDiscount(finalPrice);
        }

        return finalPrice;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter product details:");

        Console.Write("Category: ");
        string category = Console.ReadLine();

        Console.Write("Price: ");
        decimal price;
        if (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid price input.");
            return;
        }

        Console.Write("Payment Method: ");
        string paymentMethod = Console.ReadLine();


        // екземпляр продукту
        Product product = new Product
        {
      
            Category = category,
            Price = price,
            PurchaseTime = DateTime.Now,
            PaymentMethod = paymentMethod,
        };

        // калькулятор знижок
        DiscountCalculator calculator = new DiscountCalculator();
        var nighttimeDiscount = new NighttimePurchaseDiscount();
        var categoryDiscount = new CategoryDiscount();
        var cardPaymentDiscount = new CardPaymentDiscount();
        var personalDiscount = new PersonalDiscount(1);

        calculator.AddDiscountStrategy(nighttimeDiscount);
        calculator.AddDiscountStrategy(categoryDiscount);


        // чи є спосіб оплати «карткою»
        if (paymentMethod.ToLower() == "card")
        {
            calculator.AddDiscountStrategy(cardPaymentDiscount);
        }

        
        decimal finalPrice = calculator.CalculateFinalPrice(product);

        
        Console.WriteLine("\nProduct Information:");
        Console.WriteLine($"Product Name: Goods");
        Console.WriteLine($"Category: {product.Category}");
        Console.WriteLine($"Manufacturer: Js.Watsone");
        Console.WriteLine($"Price: {product.Price:C}");
        Console.WriteLine($"Description: good product");
        Console.WriteLine($"Purchase Time: {product.PurchaseTime}");
        Console.WriteLine($"Payment Method: {product.PaymentMethod}");
        Console.WriteLine($"Buyer: Veronika");

       
        Console.WriteLine("\nApplied Discounts:");
        Console.WriteLine($"Nighttime Purchase Discount (-5%): {nighttimeDiscount.CalculateDiscount(price):C}");
        Console.WriteLine($"Category Discount (-5%): {categoryDiscount.CalculateDiscount(price):C}");
        if (paymentMethod.ToLower() == "card")
        {
            Console.WriteLine($"Card Payment Discount (-2%): {cardPaymentDiscount.CalculateDiscount(price):C}");
        }
        Console.WriteLine($"Personal Discount (-1%): {personalDiscount.CalculateDiscount(price):C}");

        
        Console.WriteLine($"\nFinal Price: {finalPrice:C}");
    }
}
