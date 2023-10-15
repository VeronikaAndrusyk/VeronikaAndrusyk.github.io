using System;


class Product
{
    public string Category { get; set; }
    public decimal Price { get; set; }
    public DateTime PurchaseTime { get; set; }
    public string PaymentMethod { get; set; }
}

interface IDiscount
{
    decimal ApplyDiscount(decimal originalPrice);
}

class BaseDiscount : IDiscount
{
    public decimal ApplyDiscount(decimal originalPrice)
    {
        return originalPrice;
    }
}

abstract class DiscountDecorator : IDiscount
{
    protected IDiscount discount;

    public DiscountDecorator(IDiscount discount)
    {
        this.discount = discount;
    }

    public abstract decimal ApplyDiscount(decimal originalPrice);
}

class NighttimePurchaseDecorator : DiscountDecorator
{
    public NighttimePurchaseDecorator(IDiscount discount) : base(discount) { }

    public override decimal ApplyDiscount(decimal originalPrice)
    {
        if (IsNighttime())
        {
            return discount.ApplyDiscount(originalPrice) * 0.95m;
        }
        return discount.ApplyDiscount(originalPrice);
    }

    private bool IsNighttime()
    {
        int currentHour = DateTime.Now.Hour;
        return currentHour >= 20 || currentHour < 6;
    }
}

class CategoryDecorator : DiscountDecorator
{
    public CategoryDecorator(IDiscount discount) : base(discount) { }

    public override decimal ApplyDiscount(decimal originalPrice)
    {
        return discount.ApplyDiscount(originalPrice) * 0.95m;
    }
}

class CardPaymentDecorator : DiscountDecorator
{
    public CardPaymentDecorator(IDiscount discount) : base(discount) { }

    public override decimal ApplyDiscount(decimal originalPrice)
    {
        return discount.ApplyDiscount(originalPrice) * 0.98m;
    }
}

class PersonalDecorator : DiscountDecorator
{
    private decimal discountPercentage;

    public PersonalDecorator(IDiscount discount, decimal discountPercentage) : base(discount)
    {
        this.discountPercentage = discountPercentage;
    }

    public override decimal ApplyDiscount(decimal originalPrice)
    {
        return discount.ApplyDiscount(originalPrice) * (1 - discountPercentage / 100);
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
        if (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
        {
            Console.WriteLine("Invalid price input.");
            return;
        }

        Console.Write("Payment Method: ");
        string paymentMethod = Console.ReadLine();

        Product product = new Product
        {
            Category = category,
            Price = price,
            PurchaseTime = DateTime.Now,
            PaymentMethod = paymentMethod,
        };

        IDiscount discount = new BaseDiscount();

        if (IsNighttime())
        {
            discount = new NighttimePurchaseDecorator(discount);
        }

        discount = new CategoryDecorator(discount);

        if (paymentMethod.ToLower() == "card")
        {
            discount = new CardPaymentDecorator(discount);
        }

        discount = new PersonalDecorator(discount, 1); // персональна в 1%

        decimal finalPrice = discount.ApplyDiscount(product.Price);

        PrintProductInfo(product);
        PrintAppliedDiscounts(product.Price, paymentMethod);
        Console.WriteLine($"\nFinal Price: {finalPrice:C}");
    }

    private static bool IsNighttime()
    {
        int currentHour = DateTime.Now.Hour;
        return currentHour >= 20 || currentHour < 6;
    }

    private static void PrintProductInfo(Product product)
    {
        Console.WriteLine("\nProduct Information:");
        Console.WriteLine($"Product Name: Goods");
        Console.WriteLine($"Category: {product.Category}");
        Console.WriteLine($"Manufacturer: Js.Watsone");
        Console.WriteLine($"Price: {product.Price:C}");
        Console.WriteLine($"Description: good product");
        Console.WriteLine($"Purchase Time: {product.PurchaseTime}");
        Console.WriteLine($"Payment Method: {product.PaymentMethod}");
        Console.WriteLine($"Buyer: Veronika");
    }

    private static void PrintAppliedDiscounts(decimal price, string paymentMethod)
    {
        Console.WriteLine("\nApplied Discounts:");
        if (IsNighttime())
        {
            Console.WriteLine($"Nighttime Purchase Discount (-5%): {price * 0.95m:C}");
        }
        Console.WriteLine($"Category Discount (-5%): {price * 0.95m:C}");
        if (paymentMethod.ToLower() == "card")
        {
            Console.WriteLine($"Card Payment Discount (-2%): {price * 0.98m:C}");
        }
        Console.WriteLine($"Personal Discount (-1%): {price * 0.99m:C}");
    }
}
