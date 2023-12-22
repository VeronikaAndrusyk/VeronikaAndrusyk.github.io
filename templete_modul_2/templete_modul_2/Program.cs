/*
   Для досягнення синхронної взаємодії між декількома пристроями(годинник, смартфон та
   безпровідні навушники) я вважаю варто  використовувати шаблон програмування "Спостерігач".
   Цей шаблон дозволяє одному об'єкту (суб'єкту) сповіщати інших об'єктів (спостерігачів) про будь-які зміни в їхньому стані та для  досягнення синхронної взаємодії між цими пристроями.
   У моїй задачі, я  розглядаю кожен пристрій як спостерігач і синхронізую їх стани через цей шаблон.
 */
using System;
using System.Collections.Generic;

// Спостерігач
interface IObserver
{
    void Update(string message);
}

// Суб'єкт
class Subject
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}


class Clock : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Годинник: Отримано повідомлення - {message}");
    }
}

class Smartphone : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Смартфон: Отримано повідомлення - {message}");
    }
}

class WirelessHeadphones : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Навушники: Отримано повідомлення - {message}");
    }
}

// Приклад використання
class Program
{
    static void Main()
    {
        Subject subject = new Subject();

        
        Clock clock = new Clock();
        Smartphone smartphone = new Smartphone();
        WirelessHeadphones headphones = new WirelessHeadphones();

        subject.AddObserver(clock);
        subject.AddObserver(smartphone);
        subject.AddObserver(headphones);

        subject.NotifyObservers("Нове повідомлення прийшло!");

        subject.RemoveObserver(clock);
        subject.RemoveObserver(smartphone);
        subject.RemoveObserver(headphones);

        Console.ReadLine();
    }
}
