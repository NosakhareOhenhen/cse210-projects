using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public List<Comment> GetComments()
    {
        return Comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create 4 videos
        Video video1 = new Video("Python Programming Basics", "Uwa  Gold", 3600);
        Video video2 = new Video("JavaScript Crash Course", "Erica Ogbe, 2700);
        Video video3 = new Video("C# Tutorial for Beginners", "Soso Rash", 4500);
        Video video4 = new Video("Web Design Tips", "Sweet Precious ", 1800);

        // Add 3-4 comments to each video
        video1.AddComment(new Comment("Massive doll", "Great tutorial, thanks!"));
        video1.AddComment(new Comment("Cue", "Very clear explanation."));
        video1.AddComment(new Comment("Charlie", "Can you do more advanced topics?"));
        video1.AddComment(new Comment("Ik", "Loved the examples!"));

        video2.AddComment(new Comment("Emeka", "Helpful for beginners."));
        video2.AddComment(new Comment("ogie", "Nice pacing."));
        video2.AddComment(new Comment("Grace", "Looking forward to part 2."));

        video3.AddComment(new Comment("Efeosa", "Excellent content!"));
        video3.AddComment(new Comment("Ivy", "Very detailed."));
        video3.AddComment(new Comment("ovo", "Great teacher!"));
        video3.AddComment(new Comment("ovie", "More exercises please."));

        video4.AddComment(new Comment("Sade", "Good design tips."));
        video4.AddComment(new Comment("chijoke, "Very useful."));
        video4.AddComment(new Comment("Omons", "Clear and concise."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Iterate through the list and display details
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(); // Blank line for readability between videos
        }
    }
}