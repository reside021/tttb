using tttb.Contracts.Responses;

namespace tttb.Services
{
    public interface IQuestionService
    {
        Task<QuestionResponse> GetByIdAsync(int id);
    }
}
