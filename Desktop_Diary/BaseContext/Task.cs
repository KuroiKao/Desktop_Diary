using System;

namespace Desktop_Diary.BaseContext;

public class Task
{
   public int TaskId { get; set; }

    private string? _header;
    private string? _description;
    public string? Header
    {
        get { return _header; }
        set { _header = value;}
    }
    public string? Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public DateTime? DateCreation { get; set; } = DateTime.Now;
    public DateTime? DateCompletion { get; set; }

    public bool IsCompleted { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
