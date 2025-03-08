using System;
using MediaPlatform.Factory;
using MediaPlatform.Models;
using MediaPlatform.Repositories;
using MediaPlatform.Services;

class Program
{
    static void Main()
    {
        // 1. Create repository & service
        IMediaRepository repo = new MediaRepository();
        var service = new MediaService(repo);

        // 2. Use the factory to create some media items
        var movie1 = MediaFactory.CreateMovie("Inception", 148, "Sci-Fi", "Christopher Nolan");
        var series1 = MediaFactory.CreateSeries("Breaking Bad", 62, "Crime, Thriller", "Vince Gilligan");
        var podcast1 = MediaFactory.CreatePodcast("My Favorite Podcast", 100, "Alice Johnson");

        // 3. Add media to the repository via the service
        service.AddMedia(movie1);
        service.AddMedia(series1);
        service.AddMedia(podcast1);

        // Using the alternate single factory method with an enum
        var movie2 = MediaFactory.CreateMedia(MediaType.Movie, "Interstellar", 169, "Sci-Fi", "Christopher Nolan");
        service.AddMedia(movie2);

        // 4. Fetch and display all media
        Console.WriteLine("\n--- All Media Items ---");
        var allMedia = service.GetAllMedia();
        foreach (var media in allMedia)
        {
            Console.WriteLine(media);
        }

        // 5. Fetch a specific media item by title
        string searchTitle = "Breaking Bad";
        Console.WriteLine($"\nSearching for '{searchTitle}'...");
        var foundMedia = service.GetMedia(searchTitle);
        if (foundMedia != null)
        {
            Console.WriteLine($"Found: {foundMedia}");
        }
        else
        {
            Console.WriteLine("Not found.");
        }

        Console.WriteLine("\nDone. Press any key to exit.");
        Console.ReadKey();
    }
}
