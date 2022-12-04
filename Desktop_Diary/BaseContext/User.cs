using System;
using System.Collections.Generic;

namespace Desktop_Diary.BaseContext;

public class User
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public ICollection<Task> Tasks { get; } = new List<Task>();
}
