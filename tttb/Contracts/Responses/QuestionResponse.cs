namespace tttb.Contracts.Responses
{
    public record QuestionResponse
    {
        public int Id { get; init; }
        public int OrderNumber { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public List<AnswerResponse> Answers { get; init; } = [];
    }
}
