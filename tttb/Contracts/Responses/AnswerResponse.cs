namespace tttb.Contracts.Responses
{
    public record AnswerResponse
    {
        public int Id { get; init; }
        public int QuestionId { get; init; }
        public string Content { get; init; }
        public bool IsCorrect { get; init; }
    }
}
