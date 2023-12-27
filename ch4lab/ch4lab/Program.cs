using System;
using System.Collections.Generic;


public interface IObserver
{
    void Update(string post);
}


public class User : IObserver
{
    public string Username { get; private set; }
    private List<string> interests;

    public User(string username, List<string> interests)
    {
        Username = username;
        this.interests = interests;
    }

    public void Update(string post)
    {
        Console.WriteLine($"{Username}: Новий пост - {post}");
    }

    public bool HasInterest(string post)
    {
        foreach (var interest in interests)
        {
            if (post.Contains(interest, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}


public class SocialMediaProfile
{
    private List<IObserver> observers = new List<IObserver>();

    public string ProfileName { get; private set; }

    public SocialMediaProfile(string profileName)
    {
        ProfileName = profileName;
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void PublishPost(string post)
    {
        Console.WriteLine($"{ProfileName} опублікував пост: {post}");

        foreach (var observer in observers)
        {
            if ((observer as User).HasInterest(post))
            {
                observer.Update(post);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        
        var user1 = new User("User1", new List<string> { "коти", "меми", "технології", "програмування" });
        var user2 = new User("User2", new List<string> { "технології", "програмування" });

        var socialMediaProfile = new SocialMediaProfile("SomeProfile");

        
        socialMediaProfile.AddObserver(user1);
        socialMediaProfile.AddObserver(user2);

       
        socialMediaProfile.PublishPost("Коти дуже смішні!");
        socialMediaProfile.PublishPost("Програмування на C#");

       
        socialMediaProfile.RemoveObserver(user1);

        
        socialMediaProfile.PublishPost("Новий мем");

        Console.ReadLine();
    }
}
