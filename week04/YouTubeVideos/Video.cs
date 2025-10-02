using System;
using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _length; // en segundos
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public string GetDuration()
    {
        int minutes = _length / 60;
        int seconds = _length % 60;
        return $"{minutes}m {seconds}s";
    }

    public void DisplayVideoSummary()
    {
        Console.WriteLine($"Title: {_title} | Author: {_author} | Duration: {GetDuration()} | Comments: {GetNumberOfComments()}");
    }

    public void DisplayAllComments()
    {
        Console.WriteLine("Comments:");
        foreach (var comment in _comments)
        {
            Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
        }
        Console.WriteLine("---------------------------");
    }

    public void HideRandomComment()
    {
        Random rand = new Random();
        int index = rand.Next(_comments.Count);
        _comments[index].HideComment();
    }

    public string GetAuthor()
    {
        return _author;
    }
}
