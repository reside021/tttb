namespace tttb.Contracts.Responses
{
    public record NextQuestionIdResponse
    {
        public int? NextQuestionId { get; init; }
        public bool HasNext => NextQuestionId.HasValue;
    }
}
