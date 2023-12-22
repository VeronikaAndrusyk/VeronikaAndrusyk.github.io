using System;
using System.Collections.Generic;

public interface ISubject
{
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void Notify(string message);
}

public interface IObserver
{
    void Update(string message);
}

public class UserProfile : ISubject
{
    private readonly HashSet<IObserver> observers = new HashSet<IObserver>();
    private readonly List<MediaItem> mediaItems = new List<MediaItem>();
    private readonly object lockObject = new object();

    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify(string message)
    {
        lock (lockObject)
        {
            foreach (var observer in observers)
            {
                observer.Update($"{observer.GetType().Name}: {message}");
            }
        }
    }

    public void AddMediaItem(MediaItem item)
    {
        mediaItems.Add(item);
        Notify($"New {item.Type} added: {item.Title}");
    }

    public List<MediaItem> GetMediaItemsWithDescription(string keyword)
    {
        return mediaItems.FindAll(item => item.Description.Contains(keyword));
    }
}

public class User : IObserver
{
    public string Name { get; }

    public User(string name)
    {
        Name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{Name} received notification: {message}");
    }
}

public class MediaItem
{
    public enum MediaType { Photo, Video }

    public string Author { get; }
    public string Title { get; }
    public string Description { get; }
    public string URL { get; }
    public int Width { get; }
    public int Height { get; }
    public int DurationInSeconds { get; }
    public MediaType Type { get; }

    public MediaItem(string author, string title, string description, string url, int width, int height)
    {
        Author = author;
        Title = title;
        Description = description;
        URL = url;
        Width = width;
        Height = height;
        Type = DetermineMediaType(url);
    }

    public MediaItem(string author, string title, string description, string url, int durationInSeconds)
    {
        Author = author;
        Title = title;
        Description = description;
        URL = url;
        DurationInSeconds = durationInSeconds;
        Type = DetermineMediaType(url);
    }

    private static MediaType DetermineMediaType(string url)
    {
        switch (url.ToLowerInvariant())
        {
            case var photo when photo.EndsWith(".jpg"):
                return MediaType.Photo;
            case var video when video.EndsWith(".mp4"):
                return MediaType.Video;
            default:
                return MediaType.Photo;
        }
    }
}

class Program
{
    static void Main()
    {
        UserProfile userProfile = new UserProfile();

        User user1 = new User("User1");
        User user2 = new User("User2");

        userProfile.Subscribe(user1);
        userProfile.Subscribe(user2);

        MediaItem photo = new MediaItem("Photographer1", "Sunset", "Beautiful sunset", "http://example.com/sunset.jpg", 1920, 1080);
        MediaItem video = new MediaItem("Videographer1", "Nature", "Scenic nature video", "http://example.com/nature.mp4", 60);

        userProfile.AddMediaItem(photo);
        userProfile.AddMediaItem(video);

        Console.Write("Enter a keyword to search for in media item descriptions: ");
        string keyword = Console.ReadLine();

        List<MediaItem> filteredItems = userProfile.GetMediaItemsWithDescription(keyword);

        if (filteredItems.Count > 0)
        {
            Console.WriteLine($"Media items with description containing '{keyword}':");
            foreach (var item in filteredItems)
            {
                Console.WriteLine($"{item.Type}: {item.Title} - {item.Description}");
            }
        }
        else
        {
            Console.WriteLine($"No media items found with description containing '{keyword}'.");
        }

        userProfile.Unsubscribe(user2);

        MediaItem newPhoto = new MediaItem("Photographer2", "Mountains", "Majestic mountain view", "http://example.com/mountains.jpg", 1920, 1200);
        userProfile.AddMediaItem(newPhoto);
    }
}
