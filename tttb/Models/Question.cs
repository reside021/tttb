﻿namespace tttb.Models;

public class Question
{
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Answer> Answers { get; set; } = [];
}
