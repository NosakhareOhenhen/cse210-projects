using System;
using System.Collections.Generic;

// Comment class to represent individual comments
public class Comment
{
    // Private fields
    private string _commenterName;
    private string _commentText;

    // Constructor
    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    // Public getter methods
    public string GetCommenterName() => _commenterName;
    public string GetCommentText() => _commentText;
}

// Video class to represent YouTube videos
public class Video
{
    // Private fields
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    // Method to add a comment
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to get number of comments
    public int GetNumberOfComments() => _comments.Count;

    // Method to get all comments
    public List<Comment> GetComments() => new List<Comment>(_comments);

    // Public getter methods
    public string GetTitle() => _title;
    public string GetAuthor() => _author;
    public int GetLengthInSeconds() => _lengthInSeconds;
}

class Program
{
    static void Main(string[] args)
    {
        // Create 4 sample videos
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
        video3.AddComment(new Comment("BackendDev", "Excellent explanation of MVC pattern"));

        // Add comments to video4
        video4.AddComment(new Comment("DataScientist", "Clear explanation of ML concepts"));
        video4.AddComment(new Comment("Student2023", "What libraries would you recommend for beginners?"));
        video4.AddComment(new Comment("AIResearcher", "Nice introduction to the field"));

        // Create a list of videos
        var videos = new List<Video> { video1, video2, video3, video4 };

        // Display information for each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine(); // Add a blank line between videos
        }
    }
}

