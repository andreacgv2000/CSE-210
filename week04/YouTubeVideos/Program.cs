using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Crear videos
        Video video1 = new Video("C# Basics", "Alice", 300);
        video1.AddComment(new Comment("John", "Great explanation!"));
        video1.AddComment(new Comment("Mary", "Very helpful."));
        video1.AddComment(new Comment("Steve", "Thanks!"));

        Video video2 = new Video("OOP Concepts", "Bob", 450);
        video2.AddComment(new Comment("Anna", "Loved the examples."));
        video2.AddComment(new Comment("Tom", "Clear and concise."));
        video2.AddComment(new Comment("Lucy", "More videos like this please."));

        Video video3 = new Video("Advanced C# Tips", "Charlie", 600);
        video3.AddComment(new Comment("Jake", "This is advanced indeed."));
        video3.AddComment(new Comment("Nina", "Excellent tutorial."));
        video3.AddComment(new Comment("Leo", "Helped me a lot."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Mostrar resumen de todos los videos
        Console.WriteLine("=== Video Summary ===");
        foreach (var video in videos)
        {
            video.DisplayVideoSummary();
        }

        Console.WriteLine("\n=== Display All Comments ===");
        foreach (var video in videos)
        {
            Console.WriteLine($"Video: {video.GetAuthor()}'s video");
            video.DisplayAllComments();
        }

        // Ejemplo de ocultar comentarios aleatorios
        Console.WriteLine("\n=== Hiding a random comment from each video ===");
        foreach (var video in videos)
        {
            video.HideRandomComment();
            video.DisplayAllComments();
        }

        // Ejemplo de buscar videos por autor
        Console.WriteLine("\n=== Search videos by author 'Alice' ===");
        var aliceVideos = videos.Where(v => v.GetAuthor() == "Alice");
        foreach (var v in aliceVideos)
        {
            v.DisplayVideoSummary();
        }
    }
}
