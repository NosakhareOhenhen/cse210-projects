using System;
using System.Collections.Generic;

// Comment class to track commenter name and text
public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

// Video class to track video information and comments
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; } = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public List<Comment> GetAllComments()
    {
        return new List<Comment>(Comments);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create 3-4 videos
        var video1 = new Video("C# Tutorial for Beginners", "Programming Guru", 720);
        var video2 = new Video("Learn Python in 10 Minutes", "Code Master", 600);
        var video3 = new Video("Building Web Apps with ASP.NET", "Web Dev Pro", 900);
        var video4 = new Video("Machine Learning Basics", "AI Explorer", 1200);

        // Add comments to video1
        video1.AddComment(new Comment("JohnDoe", "Great tutorial! Very helpful."));
        video1.AddComment(new Comment("JaneSmith", "I finally understand classes now."));
        video1.AddComment(new Comment("MikeJohnson", "Could you make one about inheritance?"));

        // Add comments to video2
        video2.AddComment(new Comment("PythonFan", "Python is so much easier than C++"));
        video2.AddComment(new Comment("BeginnerCoder", "This was exactly what I needed!"));
        video2.AddComment(new Comment("TechEnthusiast", "Short and to the point. Love it!"));

        // Add comments to video3
        video3.AddComment(new Comment("WebDevNewbie", "ASP.NET seems powerful but complex"));
        video3.AddComment(new Comment("DotNetExpert", "Good overview of the framework"));
        video3.AddComment(new Comment("Designer123", "Would love to see more UI examples"));

        // Add comments to video4
        video4.AddComment(new Comment("DataScientist", "Clear explanation of ML concepts"));
        video4.AddComment(new Comment("Student2023", "What libraries would you recommend for beginners?"));
        video4.AddComment(new Comment("AIResearcher", "Nice introduction to the field"));

        // Put videos in a list
        var videos = new List<Video> { video1, video2, video3, video4 };

        // Iterate through videos and display information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.GetAllComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine(); // Add blank line between videos
        }
    }
}