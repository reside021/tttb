namespace tttb.Contracts.Requests;

public record CreateResultRequest
{
    public int InterviewId { get; init; }
    public int AnswerId { get; init; }
}
