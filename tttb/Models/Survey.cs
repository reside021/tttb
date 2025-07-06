﻿namespace tttb.Models;

public class Survey
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Question> Questions { get; set; } = [];
    public List<Interview> Interviews { get; set; } = [];
}
