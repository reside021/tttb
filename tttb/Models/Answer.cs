﻿namespace tttb.Models;

public class Answer
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public Question? Question { get; set; }
    public string Content { get; set; }
    public bool IsCorrect { get; set; }     
}
