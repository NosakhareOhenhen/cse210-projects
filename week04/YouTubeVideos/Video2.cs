using System;
using System.Collections.Generic;

public class Comment
{
    private string commenterName;
    private string text;

    public Comment(string commenterName, string text)
    {
        this.commenterName = commenterName;
        this.text = text;
    }

    public string GetCommenterName()
    {
        return commenterName;
    }

    public string GetText()
    {
        return text;
    }
}

public class Video
{
    private string title;
    private string author;
    private int lengthInSeconds;
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        this.title = title;
        this.author = author;
        this.lengthInSeconds = lengthInSeconds;
        this.comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetAuthor()
    {
        return author;
    }

    public int GetLengthInSeconds()
    {
        return lengthInSeconds;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create 4 videos
        Video video1 = new Video("Introduction to Python", "Alice Johnson", 3000);
        Video video2 = new Video("JavaScript for Beginners", "Bob Smith", 2500);
        Video video3 = new Video("C# Basics", "Clara Brown", 3500);
        Video video4 = new Video("Web Development Tips", "David Lee", 2000);

        // Add 3-4 comments to each video
        video1.AddComment(new Comment("Eve", "Great intro, thanks!"));
        video1.AddComment(new Comment("Frank", "Very helpful."));
        video1.AddComment(new Comment("Grace", "Can you cover more topics?"));
        video1.AddComment(new Comment("Hank", "Awesome video!"));

        video2.AddComment(new Comment("Ivy", "Clear explanations."));
        video2.AddComment(new Comment("Jack", "Good pace."));
        video2.AddComment(new Comment("Kelly", "Looking forward to more!"));

        video3.AddComment(new Comment("Liam", "Excellent tutorial."));
        video3.AddComment(new Comment("Mia", "Very detailed."));
        video3.AddComment(new Comment("Noah", "Great job!"));
        video3.AddComment(new Comment("Olivia", "More examples please."));

        video4.AddComment(new Comment("Peter", "Useful tips."));
        video4.AddComment(new Comment("Quinn", "Well explained."));
        video4.AddComment(new Comment("Rose", "Nice content."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Iterate through the list and display details
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }
            Console.WriteLine(); // Blank line for readability between videos
        }
    }
}